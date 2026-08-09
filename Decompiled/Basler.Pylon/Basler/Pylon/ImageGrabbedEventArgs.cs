using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public class ImageGrabbedEventArgs(IGrabResult grabResult) : EventArgs
{
	private IGrabResult m_grabResult = grabResult;

	private bool m_isClone = false;

	public bool IsClone
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return m_isClone;
		}
	}

	public IGrabResult GrabResult => m_grabResult;

	public ImageGrabbedEventArgs Clone()
	{
		ImageGrabbedEventArgs e = new ImageGrabbedEventArgs(m_grabResult.Clone());
		e.m_isClone = true;
		return e;
	}

	public void DisposeGrabResultIfClone()
	{
		if (IsClone)
		{
			m_grabResult?.Dispose();
		}
	}
}
