using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDb3dProfile : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDb3dProfile_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDb3dProfile_1();

	public delegate void SwigDelegateOdDb3dProfile_2(IntPtr src);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDb3dProfile_0 swigDelegate0;

	private SwigDelegateOdDb3dProfile_1 swigDelegate1;

	private SwigDelegateOdDb3dProfile_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDb3dProfile(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDb3dProfile obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDb3dProfile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDb3dProfile cast(OdRxObject pObj)
	{
		OdDb3dProfile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dProfile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isASwigExplicitOdDb3dProfile(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_queryXSwigExplicitOdDb3dProfile(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDb3dProfile()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDb3dProfile(OdDbEntity pEntity)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_1(OdDbEntity.getCPtr(pEntity)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDb3dProfile(OdDbFullSubentPath faceSubentPath)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_2(OdDbFullSubentPath.getCPtr(faceSubentPath)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdDb3dProfile createObject(OdDbFullSubentPath faceSubentPath)
	{
		OdDb3dProfile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dProfile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_createObject__SWIG_0(OdDbFullSubentPath.getCPtr(faceSubentPath)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDb3dProfile(OdDbVertexRef vertexRef)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_3(OdDbVertexRef.getCPtr(vertexRef)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDb3dProfile(OdDb3dProfile src)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_4(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDb3dProfile(OdDbPathRef pathRef)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dProfile__SWIG_5(OdDbPathRef.getCPtr(pathRef)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDb3dProfile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void copyFrom(OdRxObject src)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_copyFromSwigExplicitOdDb3dProfile(swigCPtr, OdRxObject.getCPtr(src));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_copyFrom(swigCPtr, OdRxObject.getCPtr(src));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbEntity entity()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_entity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult set(OdDbEntity pEntity)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_set__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbVertexRef vertexRef)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_set__SWIG_1(swigCPtr, OdDbVertexRef.getCPtr(vertexRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getVertexRef(ref OdDbVertexRef vertexRef)
	{
		IntPtr jarg = ((vertexRef == null) ? IntPtr.Zero : OdDbVertexRef.getCPtr(vertexRef).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_getVertexRef(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				vertexRef = null;
			}
			if (jarg != intPtr)
			{
				vertexRef = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbVertexRef>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult set(OdDbPathRef pathRef)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_set__SWIG_2(swigCPtr, OdDbPathRef.getCPtr(pathRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDb3dProfile Assign(OdDb3dProfile src)
	{
		OdDb3dProfile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dProfile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_Assign(swigCPtr, getCPtr(src)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isClosed__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPlanar()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isPlanar(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSubent()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isSubent(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isFace()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isFace(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEdge()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isEdge(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_isValid(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getPathRef(ref OdDbPathRef pathRef)
	{
		IntPtr jarg = ((pathRef == null) ? IntPtr.Zero : OdDbPathRef.getCPtr(pathRef).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_getPathRef(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pathRef = null;
			}
			if (jarg != intPtr)
			{
				pathRef = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPathRef>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult mergeProfiles(OdArray_OdDb3dProfile__p_OdObjectsAllocator profileArr, bool mergeEdges, bool mergeCurves, OdArray_OdDb3dProfile__p_OdObjectsAllocator mergedProfileArr)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_mergeProfiles(OdArray_OdDb3dProfile__p_OdObjectsAllocator.getCPtr(profileArr), mergeEdges, mergeCurves, OdArray_OdDb3dProfile__p_OdObjectsAllocator.getCPtr(mergedProfileArr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDb3dProfile createObject()
	{
		OdDb3dProfile rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dProfile>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dProfile_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDb3dProfile));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr src)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(src, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
