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
			void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState) { }
			void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId) { }
			void IMMNotificationClient.OnDeviceRemoved(string deviceId) { }
			void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) { }
			void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
			{
				//if (defaultDeviceId != null)
					form.MuteSession();
			}
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
		const uint EVENT_SYSTEM_FOREGROUND = 3;
		const uint WINEVENT_OUTOFCONTEXT = 0;
		static MMDeviceEnumerator audio = new();
		NotificationClient? client;
		//static CoreAudioController audio = new();
		//Observer? observer;
		bool background = false;
		IntPtr handle;
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
			if (mute == null && !????ToolStripMenuItem.Checked)
				return;
			//MuteSession(handle != (hwnd ?? GetForegroundWindow()));
			if (GetWindowThreadProcessId(handle, out int pid) != 0)
				foreach (MMDevice device in audio.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
					for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
						if (device.AudioSessionManager.Sessions[i].GetProcessID == pid)
							device.AudioSessionManager.Sessions[i].SimpleAudioVolume.Mute = mute ?? background;
		}

		public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread,
			uint dwmsEventTime)
		{ // hwnd: handle to a window
			handle = FindWindow(null, "????");
			if (!background || background && handle == hwnd) 
			{
				background = !background;
				MuteSession(); 
			}
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
			eventhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, proc, 0, 0, WINEVENT_OUTOFCONTEXT);
			????ToolStripMenuItem.Checked = true;
			if (reg?.GetValue("BGMuter") != null)
				?}????????ToolStripMenuItem.Checked = true;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			Hide();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void ????ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			MuteSession(????ToolStripMenuItem.Checked);
		}

		private void ?}????????ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			if (?}????????ToolStripMenuItem.Checked)		
				reg?.SetValue("BGMuter", Application.ExecutablePath);
			else
				reg?.DeleteValue("BGMuter", false);
		}

		private void ???}ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

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
			UnhookWinEvent(eventhook); // ???????qcallback
			MuteSession(false);
			gch.Free();
		}
	}
}