using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Basler.Pylon;

public interface IStreamGrabber
{
	IBufferFactory BufferFactory { get; set; }

	object UserData { get; set; }

	WaitHandle GrabStopWaitHandle { get; }

	WaitHandle GrabResultWaitHandle { get; }

	bool IsGrabbing
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	[SpecialName]
	event EventHandler<GrabStopEventArgs> GrabStopped;

	[SpecialName]
	event EventHandler<GrabStopEventArgs> GrabStopping;

	[SpecialName]
	event EventHandler<EventArgs> GrabStarted;

	[SpecialName]
	event EventHandler<EventArgs> GrabStarting;

	[SpecialName]
	event EventHandler<ImageGrabbedEventArgs> ImageGrabbed;

	void Start(long maxImages, GrabStrategy strategy, GrabLoop grabLoopType);

	void Start(GrabStrategy strategy, GrabLoop grabLoopType);

	void Start(long maxImages);

	void Start();

	void Stop();

	IGrabResult RetrieveResult(int timeoutMs, TimeoutHandling timeoutHandling);

	IGrabResult GrabOne(int timeoutMs, TimeoutHandling timeoutHandling);

	IGrabResult GrabOne(int timeoutMs);
}
