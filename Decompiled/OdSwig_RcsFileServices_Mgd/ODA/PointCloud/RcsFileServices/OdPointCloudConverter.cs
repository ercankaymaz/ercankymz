using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudConverter : IDisposable
{
	public delegate void SwigDelegateOdPointCloudConverter_0([MarshalAs(UnmanagedType.LPWStr)] string rcsFilePath, bool bMTMode);

	public delegate void SwigDelegateOdPointCloudConverter_1([MarshalAs(UnmanagedType.LPWStr)] string rcsFilePath);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudConverter_0 swigDelegate0;

	private SwigDelegateOdPointCloudConverter_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudConverter(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudConverter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudConverter()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudConverter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void convertToRcsFormat(string rcsFilePath, bool bMTMode)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudConverter_convertToRcsFormat__SWIG_0(swigCPtr, rcsFilePath, bMTMode);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void convertToRcsFormat(string rcsFilePath)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudConverter_convertToRcsFormat__SWIG_1(swigCPtr, rcsFilePath);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudConverter_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudConverter()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudConverter(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudConverter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("convertToRcsFormat", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodconvertToRcsFormat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("convertToRcsFormat", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodconvertToRcsFormat__SWIG_1;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudConverter_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudConverter));
	}

	private void SwigDirectorMethodconvertToRcsFormat__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string rcsFilePath, bool bMTMode)
	{
		try
		{
			convertToRcsFormat(rcsFilePath, bMTMode);
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodconvertToRcsFormat__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string rcsFilePath)
	{
		try
		{
			convertToRcsFormat(rcsFilePath);
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
