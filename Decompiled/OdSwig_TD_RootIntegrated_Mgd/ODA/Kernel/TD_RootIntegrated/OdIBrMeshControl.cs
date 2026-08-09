using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrMeshControl : IDisposable
{
	public delegate int SwigDelegateOdIBrMeshControl_0(uint maxSubs);

	public delegate int SwigDelegateOdIBrMeshControl_1();

	public delegate int SwigDelegateOdIBrMeshControl_2(uint maxSubs);

	public delegate int SwigDelegateOdIBrMeshControl_3(double maxNodeSpace);

	public delegate int SwigDelegateOdIBrMeshControl_4();

	public delegate int SwigDelegateOdIBrMeshControl_5(double maxNodeSpace);

	public delegate int SwigDelegateOdIBrMeshControl_6(double angTol);

	public delegate int SwigDelegateOdIBrMeshControl_7();

	public delegate int SwigDelegateOdIBrMeshControl_8(double angTol);

	public delegate int SwigDelegateOdIBrMeshControl_9(double distTol);

	public delegate int SwigDelegateOdIBrMeshControl_10();

	public delegate int SwigDelegateOdIBrMeshControl_11(double distTol);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdIBrMeshControl_0 swigDelegate0;

	private SwigDelegateOdIBrMeshControl_1 swigDelegate1;

	private SwigDelegateOdIBrMeshControl_2 swigDelegate2;

	private SwigDelegateOdIBrMeshControl_3 swigDelegate3;

	private SwigDelegateOdIBrMeshControl_4 swigDelegate4;

	private SwigDelegateOdIBrMeshControl_5 swigDelegate5;

	private SwigDelegateOdIBrMeshControl_6 swigDelegate6;

	private SwigDelegateOdIBrMeshControl_7 swigDelegate7;

	private SwigDelegateOdIBrMeshControl_8 swigDelegate8;

	private SwigDelegateOdIBrMeshControl_9 swigDelegate9;

	private SwigDelegateOdIBrMeshControl_10 swigDelegate10;

	private SwigDelegateOdIBrMeshControl_11 swigDelegate11;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(uint).MakeByRefType() };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrMeshControl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrMeshControl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIBrMeshControl()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrMeshControl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdBrErrorStatus setMaxSubdivisions(uint maxSubs)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setMaxSubdivisions__SWIG_0(swigCPtr, maxSubs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setMaxSubdivisions()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setMaxSubdivisions__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getMaxSubdivisions(out uint maxSubs)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_getMaxSubdivisions(swigCPtr, out maxSubs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setMaxNodeSpacing(double maxNodeSpace)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setMaxNodeSpacing__SWIG_0(swigCPtr, maxNodeSpace);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setMaxNodeSpacing()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setMaxNodeSpacing__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getMaxNodeSpacing(out double maxNodeSpace)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_getMaxNodeSpacing(swigCPtr, out maxNodeSpace);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setAngTol(double angTol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setAngTol__SWIG_0(swigCPtr, angTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setAngTol()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setAngTol__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getAngTol(out double angTol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_getAngTol(swigCPtr, out angTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setDistTol(double distTol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setDistTol__SWIG_0(swigCPtr, distTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setDistTol()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_setDistTol__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getDistTol(out double distTol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_getDistTol(swigCPtr, out distTol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	protected OdIBrMeshControl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdIBrMeshControl(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdIBrMeshControl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setMaxSubdivisions", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetMaxSubdivisions__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaxSubdivisions", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetMaxSubdivisions__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getMaxSubdivisions", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetMaxSubdivisions;
		}
		if (SwigDerivedClassHasMethod("setMaxNodeSpacing", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetMaxNodeSpacing__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaxNodeSpacing", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetMaxNodeSpacing__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getMaxNodeSpacing", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetMaxNodeSpacing;
		}
		if (SwigDerivedClassHasMethod("setAngTol", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetAngTol__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setAngTol", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetAngTol__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getAngTol", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetAngTol;
		}
		if (SwigDerivedClassHasMethod("setDistTol", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetDistTol__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDistTol", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetDistTol__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getDistTol", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetDistTol;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshControl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdIBrMeshControl));
	}

	private int SwigDirectorMethodsetMaxSubdivisions__SWIG_0(uint maxSubs)
	{
		return (int)setMaxSubdivisions(maxSubs);
	}

	private int SwigDirectorMethodsetMaxSubdivisions__SWIG_1()
	{
		return (int)setMaxSubdivisions();
	}

	private int SwigDirectorMethodgetMaxSubdivisions(uint maxSubs)
	{
		return (int)getMaxSubdivisions(out maxSubs);
	}

	private int SwigDirectorMethodsetMaxNodeSpacing__SWIG_0(double maxNodeSpace)
	{
		return (int)setMaxNodeSpacing(maxNodeSpace);
	}

	private int SwigDirectorMethodsetMaxNodeSpacing__SWIG_1()
	{
		return (int)setMaxNodeSpacing();
	}

	private int SwigDirectorMethodgetMaxNodeSpacing(double maxNodeSpace)
	{
		return (int)getMaxNodeSpacing(out maxNodeSpace);
	}

	private int SwigDirectorMethodsetAngTol__SWIG_0(double angTol)
	{
		return (int)setAngTol(angTol);
	}

	private int SwigDirectorMethodsetAngTol__SWIG_1()
	{
		return (int)setAngTol();
	}

	private int SwigDirectorMethodgetAngTol(double angTol)
	{
		return (int)getAngTol(out angTol);
	}

	private int SwigDirectorMethodsetDistTol__SWIG_0(double distTol)
	{
		return (int)setDistTol(distTol);
	}

	private int SwigDirectorMethodsetDistTol__SWIG_1()
	{
		return (int)setDistTol();
	}

	private int SwigDirectorMethodgetDistTol(double distTol)
	{
		return (int)getDistTol(out distTol);
	}
}
