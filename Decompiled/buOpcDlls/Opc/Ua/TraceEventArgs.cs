using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class TraceEventArgs : EventArgs
{
	public int TraceMask { get; private set; }

	public string Format { get; private set; }

	public object[] Arguments { get; private set; }

	public string Message { get; private set; }

	public Exception Exception { get; private set; }

	internal TraceEventArgs(int traceMask, string format, string message, Exception exception, object[] args)
	{
		TraceMask = traceMask;
		Format = format;
		Message = message;
		Exception = exception;
		Arguments = args;
	}
}
