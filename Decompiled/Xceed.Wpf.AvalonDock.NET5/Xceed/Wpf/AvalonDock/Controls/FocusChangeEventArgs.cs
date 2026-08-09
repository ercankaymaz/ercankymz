using System;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class FocusChangeEventArgs : EventArgs
{
	public IntPtr GotFocusWinHandle { get; private set; }

	public IntPtr LostFocusWinHandle { get; private set; }

	public FocusChangeEventArgs(IntPtr gotFocusWinHandle, IntPtr lostFocusWinHandle)
	{
		GotFocusWinHandle = gotFocusWinHandle;
		LostFocusWinHandle = lostFocusWinHandle;
	}
}
