using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdSourcePointIterator : IDisposable
{
	public delegate void SwigDelegateOdSourcePointIterator_0();

	public delegate bool SwigDelegateOdSourcePointIterator_1();

	public delegate bool SwigDelegateOdSourcePointIterator_2(IntPtr point);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdSourcePointIterator_0 swigDelegate0;

	private SwigDelegateOdSourcePointIterator_1 swigDelegate1;

	private SwigDelegateOdSourcePointIterator_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdSourcePoint).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSourcePointIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSourcePointIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSourcePointIterator()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdSourcePointIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void start()
	{
		RcsFileServices_GlobalsPINVOKE.OdSourcePointIterator_start(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdSourcePointIterator_done(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPoint(ref OdSourcePoint point)
	{
		IntPtr jarg = ((point == null) ? IntPtr.Zero : OdSourcePoint.getCPtr(point).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = RcsFileServices_GlobalsPINVOKE.OdSourcePointIterator_getPoint(swigCPtr, ref jarg);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				point = null;
			}
			if (jarg != intPtr)
			{
				point = Helpers.GetObject<OdSourcePoint>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdSourcePointIterator_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSourcePointIterator()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdSourcePointIterator(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSourcePointIterator) != GetType();
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
		if (SwigDerivedClassHasMethod("done", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetPoint;
		}
		RcsFileServices_GlobalsPINVOKE.OdSourcePointIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSourcePointIterator));
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private bool SwigDirectorMethodgetPoint(IntPtr point)
	{
		OdSwigDirectorHelper.director_UnpackData(point, out var pOriginalObject, out var pFunction);
		OdSourcePoint point2 = Helpers.GetObject<OdSourcePoint>(pOriginalObject, bOwn: false, bTryAddToTransaction: false);
		try
		{
			return getPoint(ref point2);
		}
		finally
		{
			IntPtr handle = OdSourcePoint.getCPtr(point2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(point);
		}
	}
}
