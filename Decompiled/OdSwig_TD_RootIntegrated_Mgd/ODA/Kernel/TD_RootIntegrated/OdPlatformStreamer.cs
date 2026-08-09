using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPlatformStreamer : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPlatformStreamer(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPlatformStreamer obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPlatformStreamer()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPlatformStreamer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static sbyte rdInt8(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			sbyte result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdInt8(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static byte rdUInt8(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			byte result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdUInt8(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static short rdInt16(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			short result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdInt16(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static ushort rdUInt16(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdUInt16(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static int rdInt32(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdInt32(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint rdUInt32(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdUInt32(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static long rdInt64(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			long result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdInt64(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static ulong rdUInt64(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdUInt64(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static float rdFloat(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			float result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdFloat(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static double rdDouble(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdDouble(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void rd2Doubles(ref OdStreamBuf streamBuf, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rd2Doubles(ref jarg, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void rd3Doubles(ref OdStreamBuf streamBuf, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rd3Doubles(ref jarg, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void rdDoubles(ref OdStreamBuf streamBuf, int numDoubles, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdDoubles(ref jarg, numDoubles, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrInt8(ref OdStreamBuf streamBuf, sbyte value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrInt8(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrUInt8(ref OdStreamBuf streamBuf, byte value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrUInt8(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrInt16(ref OdStreamBuf streamBuf, short value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrInt16(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrUInt16(ref OdStreamBuf streamBuf, ushort value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrUInt16(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrInt32(ref OdStreamBuf streamBuf, int value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrInt32(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrUInt32(ref OdStreamBuf streamBuf, uint value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrUInt32(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrInt64(ref OdStreamBuf streamBuf, long value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrInt64(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrUInt64(ref OdStreamBuf streamBuf, ulong value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrUInt64(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrFloat(ref OdStreamBuf streamBuf, float value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrFloat(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrDouble(ref OdStreamBuf streamBuf, double value)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrDouble(ref jarg, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wr2Doubles(ref OdStreamBuf streamBuf, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wr2Doubles(ref jarg, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wr3Doubles(ref OdStreamBuf streamBuf, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wr3Doubles(ref jarg, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void wrDoubles(ref OdStreamBuf streamBuf, int numDoubles, IntPtr doubles)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_wrDoubles(ref jarg, numDoubles, doubles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static string rdString(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdPlatformStreamer_rdString(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdPlatformStreamer()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPlatformStreamer(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
