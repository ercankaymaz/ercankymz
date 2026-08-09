using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdFontMapper : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFontMapper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFontMapper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdFontMapper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public static void init(OdStreamBuf io)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_init(OdStreamBuf.getCPtr(io));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void uninit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_uninit();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isLoaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_isLoaded();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string getName(string name, bool nesting)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_getName__SWIG_0(name, nesting);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string getName(string name)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_getName__SWIG_1(name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string getName(string name, ref OdDbBaseHostAppServices ss, bool nesting)
	{
		IntPtr jarg = ((ss == null) ? IntPtr.Zero : OdDbBaseHostAppServices.getCPtr(ss).Handle);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_getName__SWIG_2(name, ref jarg, nesting);
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
				ss = null;
			}
			if (jarg != intPtr)
			{
				ss = Helpers.GetRXObject<OdDbBaseHostAppServices>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static string getName(string name, ref OdDbBaseHostAppServices ss)
	{
		IntPtr jarg = ((ss == null) ? IntPtr.Zero : OdDbBaseHostAppServices.getCPtr(ss).Handle);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_getName__SWIG_3(name, ref jarg);
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
				ss = null;
			}
			if (jarg != intPtr)
			{
				ss = Helpers.GetRXObject<OdDbBaseHostAppServices>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontMapper_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
