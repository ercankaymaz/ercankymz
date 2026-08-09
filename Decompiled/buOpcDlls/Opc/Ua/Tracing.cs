using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class Tracing
{
	private static readonly object s_syncRoot = new object();

	private static Tracing s_instance;

	public static Tracing Instance
	{
		get
		{
			if (s_instance == null)
			{
				lock (s_syncRoot)
				{
					if (s_instance == null)
					{
						s_instance = new Tracing();
					}
				}
			}
			return s_instance;
		}
	}

	public event EventHandler<TraceEventArgs> TraceEventHandler;

	private Tracing()
	{
	}

	public static bool IsEnabled()
	{
		if (s_instance != null)
		{
			return s_instance.TraceEventHandler != null;
		}
		return false;
	}

	internal void RaiseTraceEvent(TraceEventArgs eventArgs)
	{
		if (this.TraceEventHandler != null)
		{
			try
			{
				this.TraceEventHandler(this, eventArgs);
			}
			catch (Exception e)
			{
				Utils.Trace(e, "Exception invoking Trace Event Handler", handled: true, null);
			}
		}
	}
}
