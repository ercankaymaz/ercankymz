using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdRcsVoxel : IDisposable
{
	public delegate uint SwigDelegateOdRcsVoxel_0();

	public delegate IntPtr SwigDelegateOdRcsVoxel_1();

	public delegate IntPtr SwigDelegateOdRcsVoxel_2();

	public delegate IntPtr SwigDelegateOdRcsVoxel_3();

	public delegate uint SwigDelegateOdRcsVoxel_4(uint arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRcsVoxel_0 swigDelegate0;

	private SwigDelegateOdRcsVoxel_1 swigDelegate1;

	private SwigDelegateOdRcsVoxel_2 swigDelegate2;

	private SwigDelegateOdRcsVoxel_3 swigDelegate3;

	private SwigDelegateOdRcsVoxel_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(uint) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRcsVoxel(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRcsVoxel obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRcsVoxel()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdRcsVoxel(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual uint getTotalNumberOfPoints()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getTotalNumberOfPoints(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRcsPointDataIterator getPointDataIterator()
	{
		OdRcsPointDataIterator result = Helpers.GetObject<OdRcsPointDataIterator>(RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getPointDataIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getExtents(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getAccumulatedExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(SwigDerivedClassHasMethod("getAccumulatedExtents", swigMethodTypes3) ? RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getAccumulatedExtentsSwigExplicitOdRcsVoxel(swigCPtr) : RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getAccumulatedExtents(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getNumberOfPointsForLOD(uint arg0)
	{
		uint result = (SwigDerivedClassHasMethod("getNumberOfPointsForLOD", swigMethodTypes4) ? RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getNumberOfPointsForLODSwigExplicitOdRcsVoxel(swigCPtr, arg0) : RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getNumberOfPointsForLOD(swigCPtr, arg0));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRcsVoxel()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdRcsVoxel(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRcsVoxel) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getTotalNumberOfPoints", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetTotalNumberOfPoints;
		}
		if (SwigDerivedClassHasMethod("getPointDataIterator", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetPointDataIterator;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("getAccumulatedExtents", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetAccumulatedExtents;
		}
		if (SwigDerivedClassHasMethod("getNumberOfPointsForLOD", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetNumberOfPointsForLOD;
		}
		RcsFileServices_GlobalsPINVOKE.OdRcsVoxel_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRcsVoxel));
	}

	private uint SwigDirectorMethodgetTotalNumberOfPoints()
	{
		return getTotalNumberOfPoints();
	}

	private IntPtr SwigDirectorMethodgetPointDataIterator()
	{
		return OdRcsPointDataIterator.getCPtr(getPointDataIterator()).Handle;
	}

	private IntPtr SwigDirectorMethodgetExtents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(getExtents()).Handle;
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

	private IntPtr SwigDirectorMethodgetAccumulatedExtents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(getAccumulatedExtents()).Handle;
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

	private uint SwigDirectorMethodgetNumberOfPointsForLOD(uint arg0)
	{
		return getNumberOfPointsForLOD(arg0);
	}
}
