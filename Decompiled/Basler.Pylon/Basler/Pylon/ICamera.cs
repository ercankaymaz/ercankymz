using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface ICamera : IDisposable
{
	ICameraInfo CameraInfo { get; set; }

	IParameterCollection Parameters { get; }

	IStreamGrabber StreamGrabber { get; }

	bool IsConnected
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	bool IsOpen
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	[SpecialName]
	event EventHandler<EventArgs> ConnectionLost;

	[SpecialName]
	event EventHandler<EventArgs> CameraClosed;

	[SpecialName]
	event EventHandler<EventArgs> CameraClosing;

	[SpecialName]
	event EventHandler<EventArgs> CameraOpened;

	[SpecialName]
	event EventHandler<EventArgs> CameraOpening;

	[return: MarshalAs(UnmanagedType.U1)]
	bool Open(int timeoutMs, TimeoutHandling timeoutHandling);

	ICamera Open();

	void Close();

	[return: MarshalAs(UnmanagedType.U1)]
	bool WaitForFrameTriggerReady(int timeoutMs, TimeoutHandling timeoutHandling);

	void ExecuteSoftwareTrigger();

	Version GetSfncVersion();

	Stream CreateFileStream(string Filename, FileAccess Direction);
}
