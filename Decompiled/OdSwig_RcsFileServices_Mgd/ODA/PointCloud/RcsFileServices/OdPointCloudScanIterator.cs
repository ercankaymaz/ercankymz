using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudScanIterator : IDisposable
{
	public delegate void SwigDelegateOdPointCloudScanIterator_0();

	public delegate void SwigDelegateOdPointCloudScanIterator_1();

	public delegate bool SwigDelegateOdPointCloudScanIterator_2();

	public delegate IntPtr SwigDelegateOdPointCloudScanIterator_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudScanIterator_4();

	public delegate bool SwigDelegateOdPointCloudScanIterator_5();

	public delegate IntPtr SwigDelegateOdPointCloudScanIterator_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudScanIterator_0 swigDelegate0;

	private SwigDelegateOdPointCloudScanIterator_1 swigDelegate1;

	private SwigDelegateOdPointCloudScanIterator_2 swigDelegate2;

	private SwigDelegateOdPointCloudScanIterator_3 swigDelegate3;

	private SwigDelegateOdPointCloudScanIterator_4 swigDelegate4;

	private SwigDelegateOdPointCloudScanIterator_5 swigDelegate5;

	private SwigDelegateOdPointCloudScanIterator_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudScanIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudScanIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudScanIterator()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudScanIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void start()
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_start(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step()
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_step(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_done(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudScanDatabase getScanDb()
	{
		OdPointCloudScanDatabase result = Helpers.GetObject<OdPointCloudScanDatabase>(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_getScanDb(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getScanTitle()
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_getScanTitle(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getScanIsVisible()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_getScanIsVisible(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getScanTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_getScanTransform(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudScanIterator()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudScanIterator(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudScanIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodstep;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getScanDb", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetScanDb;
		}
		if (SwigDerivedClassHasMethod("getScanTitle", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetScanTitle;
		}
		if (SwigDerivedClassHasMethod("getScanIsVisible", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetScanIsVisible;
		}
		if (SwigDerivedClassHasMethod("getScanTransform", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetScanTransform;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudScanIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudScanIterator));
	}

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private void SwigDirectorMethodstep()
	{
		try
		{
			step();
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private IntPtr SwigDirectorMethodgetScanDb()
	{
		return OdPointCloudScanDatabase.getCPtr(getScanDb()).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetScanTitle()
	{
		return getScanTitle();
	}

	private bool SwigDirectorMethodgetScanIsVisible()
	{
		return getScanIsVisible();
	}

	private IntPtr SwigDirectorMethodgetScanTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getScanTransform()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				RcsFileServices_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				RcsFileServices_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				RcsFileServices_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
