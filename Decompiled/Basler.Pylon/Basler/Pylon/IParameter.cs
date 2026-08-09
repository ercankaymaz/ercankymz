using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IParameter
{
	IAdvancedParameterAccess Advanced { get; }

	bool IsEmpty
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool IsWritable
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	bool IsReadable
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	string FullName { get; }

	string Name { get; }

	[SpecialName]
	event EventHandler<ParameterValueChangedEventArgs> ParameterValueChanged;

	[SpecialName]
	event EventHandler<ParameterChangedEventArgs> ParameterChanged;

	new string ToString();

	void ParseAndSetValue(string value);
}
