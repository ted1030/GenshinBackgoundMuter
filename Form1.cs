using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
//using AudioSwitcher.AudioApi;
//using AudioSwitcher.AudioApi.CoreAudio;
//using System.Xml.Linq;
using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;

namespace BGMuter
{
	public partial class Form1 : Form
	{
		class NotificationClient : IMMNotificationClient
		{
			Form1 form;
			public NotificationClient(Form1 form1)
			{
				form = form1;
			}
			void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState) => form.MuteSession();
			void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId) { }
			void IMMNotificationClient.OnDeviceRemoved(string deviceId) { }
			void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) { }
			void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) => form.MuteSession();
		}

		//class Observer : IObserver<DeviceChangedArgs>
		//{
		//	Form1 form;
		//	public Observer(Form1 form1)
		//	{
		//		form = form1;
		//	}
		//	public void OnCompleted() { }
		//	public void OnError(Exception error) { }
		//	public void OnNext(DeviceChangedArgs value)
		//	{
		//		form.SetMute();
		//	}
		//}

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc,
			uint idProcess, uint idThread, uint dwFlags);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool UnhookWinEvent(IntPtr hWinEventHook);
		[DllImport("User32.dll", SetLastError = true)]
		static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
		[DllImport("User32.dll", SetLastError = true)]
		static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);
		delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread,
			uint dwmsEventTime); // delegate: function pointer
		const uint EVENT_SYSTEM_FOREGROUND = 0x3;
		const uint EVENT_SYSTEM_MINIMIZEEND = 0x17;
		const uint EVENT_SYSTEM_MINIMIZESTART = 0x16;
		const uint WINEVENT_OUTOFCONTEXT = 0;
		static MMDeviceEnumerator audio = new();
		NotificationClient? client;
		//static CoreAudioController audio = new();
		//Observer? observer;
		bool background = false;
		IntPtr handle = FindWindow(null, "原神");
		IntPtr eventhook;
		GCHandle gch;
		RegistryKey? reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

		//int unchanged = 0;
		//while (unchanged<audio.GetDevices(DeviceType.Playback, DeviceState.Active).Count())
		//{
		//	unchanged = 0;
		//	audio.GetDevices(DeviceType.Playback, DeviceState.Active).SelectMany(x => x.SessionController).Where(x => x.ProcessId == pid).ToList().ForEach(x => { x.IsMuted = mute; unchanged++; });
		//}

		public void MuteSession(bool? mute = null)
		{
			if (mute == null && !啟用ToolStripMenuItem.Checked)
				return;
			if (GetWindowThreadProcessId(handle, out int pid) != 0)
				foreach (MMDevice device in audio.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
					for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
						if (device.AudioSessionManager.Sessions[i].GetProcessID == pid)
							device.AudioSessionManager.Sessions[i].SimpleAudioVolume.Mute = mute ?? background;
		}

		public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread,
			uint dwmsEventTime)
		{
			// hwnd: the handle to the window
			if (hwnd != handle || eventType != EVENT_SYSTEM_MINIMIZEEND && eventType != EVENT_SYSTEM_MINIMIZESTART)
				return;
			handle = FindWindow(null, "原神");
			background = eventType != EVENT_SYSTEM_MINIMIZEEND;
			MuteSession();
		}

		public Form1()
		{
			InitializeComponent();
			Application.ApplicationExit += ApplicationExit;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			client = new(this);
			audio.RegisterEndpointNotificationCallback(client);
			//observer = new(this);
			//audio.AudioDeviceChanged.Subscribe(observer);
			WinEventDelegate proc = new(WinEventProc);
			gch = GCHandle.Alloc(proc);
			eventhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_MINIMIZEEND, IntPtr.Zero, proc, 0, 0, WINEVENT_OUTOFCONTEXT);
			啟用ToolStripMenuItem.Checked = true;
			if (reg?.GetValue("BGMuter") != null)
				開機時啟動ToolStripMenuItem.Checked = true;
		}

		private void Form1_Shown(object sender, EventArgs e) => Hide();

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void 啟用ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			MuteSession(啟用ToolStripMenuItem.Checked);
		}

		private void 開機時啟動ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			if (開機時啟動ToolStripMenuItem.Checked)
				reg?.SetValue("BGMuter", Application.ExecutablePath);
			else
				reg?.DeleteValue("BGMuter", false);
		}

		private void 離開ToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
				Hide();
		}

		private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Show();
				WindowState = FormWindowState.Normal;
				ShowInTaskbar = true;
			}
		}

		private void ApplicationExit(object? sender, EventArgs e)
		{
			UnhookWinEvent(eventhook); // 解除自訂callback
			MuteSession(false);
			gch.Free();
		}
	}
}