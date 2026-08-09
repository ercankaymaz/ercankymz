using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IInterface : IDisposable
{
	IInterfaceInfo InterfaceInfo { get; }

	IParameterCollection Parameters { get; }

	bool IsOpen
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	[SpecialName]
	event EventHandler<EventArgs> InterfaceClosed;

	[SpecialName]
	event EventHandler<EventArgs> InterfaceClosing;

	[SpecialName]
	event EventHandler<EventArgs> InterfaceOpened;

	[SpecialName]
	event EventHandler<EventArgs> InterfaceOpening;

	IInterface Open();

	void Close();

	List<ICameraInfo> EnumerateCameras();
}
