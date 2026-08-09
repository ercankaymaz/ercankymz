using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdRcsPointDataIterator : IDisposable
{
	public delegate void SwigDelegateOdRcsPointDataIterator_0();

	public delegate bool SwigDelegateOdRcsPointDataIterator_1();

	public delegate uint SwigDelegateOdRcsPointDataIterator_2(IntPtr coordinates, IntPtr colors, uint requiredNumberOfPoints);

	public delegate uint SwigDelegateOdRcsPointDataIterator_3(IntPtr coordinates, IntPtr colors, IntPtr normals, uint requiredNumberOfPoints);

	public delegate uint SwigDelegateOdRcsPointDataIterator_4(IntPtr coordinates, IntPtr colors, IntPtr normalIndexes, IntPtr intensities, uint requiredNumberOfPoints);

	public delegate uint SwigDelegateOdRcsPointDataIterator_5(IntPtr receiver, uint requiredNumberOfPoints);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRcsPointDataIterator_0 swigDelegate0;

	private SwigDelegateOdRcsPointDataIterator_1 swigDelegate1;

	private SwigDelegateOdRcsPointDataIterator_2 swigDelegate2;

	private SwigDelegateOdRcsPointDataIterator_3 swigDelegate3;

	private SwigDelegateOdRcsPointDataIterator_4 swigDelegate4;

	private SwigDelegateOdRcsPointDataIterator_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[3]
	{
		typeof(OdGePoint3dArray),
		typeof(OdCmEntityColorArray),
		typeof(uint)
	};

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGePoint3dArray),
		typeof(OdCmEntityColorArray),
		typeof(OdGeVector3dArray),
		typeof(uint)
	};

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(OdGePoint3dArray),
		typeof(OdCmEntityColorArray),
		typeof(OdUInt16Array),
		typeof(OdUInt8Array),
		typeof(uint)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRcsPointDataReceiver),
		typeof(uint)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRcsPointDataIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRcsPointDataIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRcsPointDataIterator()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdRcsPointDataIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void start()
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_start(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_done(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getPoints(OdGePoint3dArray coordinates, OdCmEntityColorArray colors, uint requiredNumberOfPoints)
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_getPoints__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(coordinates).Handle, OdCmEntityColorArray.getCPtr(colors).Handle, requiredNumberOfPoints);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getPoints(OdGePoint3dArray coordinates, OdCmEntityColorArray colors, OdGeVector3dArray normals, uint requiredNumberOfPoints)
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_getPoints__SWIG_1(swigCPtr, OdGePoint3dArray.getCPtr(coordinates).Handle, OdCmEntityColorArray.getCPtr(colors).Handle, OdGeVector3dArray.getCPtr(normals).Handle, requiredNumberOfPoints);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getPoints(OdGePoint3dArray coordinates, OdCmEntityColorArray colors, OdUInt16Array normalIndexes, OdUInt8Array intensities, uint requiredNumberOfPoints)
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_getPoints__SWIG_2(swigCPtr, OdGePoint3dArray.getCPtr(coordinates).Handle, OdCmEntityColorArray.getCPtr(colors).Handle, OdUInt16Array.getCPtr(normalIndexes).Handle, OdUInt8Array.getCPtr(intensities).Handle, requiredNumberOfPoints);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getPoints(OdRcsPointDataReceiver receiver, uint requiredNumberOfPoints)
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_getPoints__SWIG_3(swigCPtr, OdRcsPointDataReceiver.getCPtr(receiver), requiredNumberOfPoints);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRcsPointDataIterator()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdRcsPointDataIterator(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRcsPointDataIterator) != GetType();
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
		if (SwigDerivedClassHasMethod("getPoints", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPoints", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPoints", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetPoints__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getPoints", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetPoints__SWIG_3;
		}
		RcsFileServices_GlobalsPINVOKE.OdRcsPointDataIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRcsPointDataIterator));
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

	private uint SwigDirectorMethodgetPoints__SWIG_0(IntPtr coordinates, IntPtr colors, uint requiredNumberOfPoints)
	{
		return getPoints(new OdGePoint3dArray(coordinates, cMemoryOwn: true), new OdCmEntityColorArray(colors, cMemoryOwn: true), requiredNumberOfPoints);
	}

	private uint SwigDirectorMethodgetPoints__SWIG_1(IntPtr coordinates, IntPtr colors, IntPtr normals, uint requiredNumberOfPoints)
	{
		return getPoints(new OdGePoint3dArray(coordinates, cMemoryOwn: true), new OdCmEntityColorArray(colors, cMemoryOwn: true), new OdGeVector3dArray(normals, cMemoryOwn: true), requiredNumberOfPoints);
	}

	private uint SwigDirectorMethodgetPoints__SWIG_2(IntPtr coordinates, IntPtr colors, IntPtr normalIndexes, IntPtr intensities, uint requiredNumberOfPoints)
	{
		return getPoints(new OdGePoint3dArray(coordinates, cMemoryOwn: true), new OdCmEntityColorArray(colors, cMemoryOwn: true), new OdUInt16Array(normalIndexes, cMemoryOwn: true), new OdUInt8Array(intensities, cMemoryOwn: true), requiredNumberOfPoints);
	}

	private uint SwigDirectorMethodgetPoints__SWIG_3(IntPtr receiver, uint requiredNumberOfPoints)
	{
		return getPoints(new OdRcsPointDataReceiver(receiver, cMemoryOwn: false), requiredNumberOfPoints);
	}
}
