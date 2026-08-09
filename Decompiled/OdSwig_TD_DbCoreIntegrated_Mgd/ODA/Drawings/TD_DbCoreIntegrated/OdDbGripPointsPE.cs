using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGripPointsPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGripPointsPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGripPointsPE_1();

	public delegate void SwigDelegateOdDbGripPointsPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGripPointsPE_3(IntPtr pEntity, IntPtr gripPoints);

	public delegate int SwigDelegateOdDbGripPointsPE_4(IntPtr pEntity, IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbGripPointsPE_5(IntPtr pEntity, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags);

	public delegate int SwigDelegateOdDbGripPointsPE_6(IntPtr pEntity, IntPtr grips, IntPtr offset, int bitFlags);

	public delegate int SwigDelegateOdDbGripPointsPE_7(IntPtr pEntity, IntPtr stretchPoints);

	public delegate int SwigDelegateOdDbGripPointsPE_8(IntPtr pEntity, IntPtr indices, IntPtr offset);

	public delegate int SwigDelegateOdDbGripPointsPE_9(IntPtr pEntity, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints);

	public delegate int SwigDelegateOdDbGripPointsPE_10(IntPtr pEntity, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insert);

	public delegate int SwigDelegateOdDbGripPointsPE_11(IntPtr pEntity, IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbGripPointsPE_12(IntPtr pEntity, IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGripPointsPE_0 swigDelegate0;

	private SwigDelegateOdDbGripPointsPE_1 swigDelegate1;

	private SwigDelegateOdDbGripPointsPE_2 swigDelegate2;

	private SwigDelegateOdDbGripPointsPE_3 swigDelegate3;

	private SwigDelegateOdDbGripPointsPE_4 swigDelegate4;

	private SwigDelegateOdDbGripPointsPE_5 swigDelegate5;

	private SwigDelegateOdDbGripPointsPE_6 swigDelegate6;

	private SwigDelegateOdDbGripPointsPE_7 swigDelegate7;

	private SwigDelegateOdDbGripPointsPE_8 swigDelegate8;

	private SwigDelegateOdDbGripPointsPE_9 swigDelegate9;

	private SwigDelegateOdDbGripPointsPE_10 swigDelegate10;

	private SwigDelegateOdDbGripPointsPE_11 swigDelegate11;

	private SwigDelegateOdDbGripPointsPE_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes5 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(int)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdIntArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes9 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes10 = new Type[8]
	{
		typeof(OdDbEntity),
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes11 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGripPointsPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGripPointsPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGripPointsPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbGripPointsPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGripPointsPE(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbGripPointsPE cast(OdRxObject pObj)
	{
		OdDbGripPointsPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGripPointsPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_isASwigExplicitOdDbGripPointsPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_queryXSwigExplicitOdDbGripPointsPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getGripPoints(OdDbEntity pEntity, OdGePoint3dArray gripPoints)
	{
		int result = (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPointsSwigExplicitOdDbGripPointsPE__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), OdGePoint3dArray.getCPtr(gripPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPoints__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), OdGePoint3dArray.getCPtr(gripPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdDbEntity pEntity, OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAtSwigExplicitOdDbGripPointsPE__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAt__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPoints(OdDbEntity pEntity, OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPointsSwigExplicitOdDbGripPointsPE__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPoints__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAt(OdDbEntity pEntity, OdDbVoidPtrArray grips, OdGeVector3d offset, int bitFlags)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAtSwigExplicitOdDbGripPointsPE__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAt__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbVoidPtrArray.getCPtr(grips), OdGeVector3d.getCPtr(offset), bitFlags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getStretchPoints(OdDbEntity pEntity, OdGePoint3dArray stretchPoints)
	{
		int result = (SwigDerivedClassHasMethod("getStretchPoints", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getStretchPointsSwigExplicitOdDbGripPointsPE(swigCPtr, OdDbEntity.getCPtr(pEntity), OdGePoint3dArray.getCPtr(stretchPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getStretchPoints(swigCPtr, OdDbEntity.getCPtr(pEntity), OdGePoint3dArray.getCPtr(stretchPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveStretchPointsAt(OdDbEntity pEntity, OdIntArray indices, OdGeVector3d offset)
	{
		int result = (SwigDerivedClassHasMethod("moveStretchPointsAt", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveStretchPointsAtSwigExplicitOdDbGripPointsPE(swigCPtr, OdDbEntity.getCPtr(pEntity), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveStretchPointsAt(swigCPtr, OdDbEntity.getCPtr(pEntity), OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOsnapPoints(OdDbEntity pEntity, OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints)
	{
		int result = (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getOsnapPointsSwigExplicitOdDbGripPointsPE__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getOsnapPoints__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pEntity), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOsnapPoints(OdDbEntity pEntity, OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d xWorldToEye, OdGePoint3dArray snapPoints, OdGeMatrix3d insert)
	{
		int result = (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getOsnapPointsSwigExplicitOdDbGripPointsPE__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insert)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getOsnapPoints__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(xWorldToEye), OdGePoint3dArray.getCPtr(snapPoints).Handle, OdGeMatrix3d.getCPtr(insert)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPointsAtSubentPath(OdDbEntity pEntity, OdDbFullSubentPath path, OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("getGripPointsAtSubentPath", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPointsAtSubentPathSwigExplicitOdDbGripPointsPE(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getGripPointsAtSubentPath(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAtSubentPaths(OdDbEntity pEntity, OdDbFullSubentPathArray paths, OdDbVoidPtrArray gripAppData, OdGeVector3d offset, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAtSubentPaths", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAtSubentPathsSwigExplicitOdDbGripPointsPE(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_moveGripPointsAtSubentPaths(swigCPtr, OdDbEntity.getCPtr(pEntity), OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbGripPointsPE createObject()
	{
		OdDbGripPointsPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGripPointsPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetGripPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmoveGripPointsAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getGripPoints", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetGripPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAt", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodmoveGripPointsAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getStretchPoints", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetStretchPoints;
		}
		if (SwigDerivedClassHasMethod("moveStretchPointsAt", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodmoveStretchPointsAt;
		}
		if (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetOsnapPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetOsnapPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getGripPointsAtSubentPath", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAtSubentPaths", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodmoveGripPointsAtSubentPaths;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGripPointsPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGripPointsPE));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgetGripPoints__SWIG_0(IntPtr pEntity, IntPtr gripPoints)
	{
		return (int)getGripPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(gripPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodmoveGripPointsAt__SWIG_0(IntPtr pEntity, IntPtr indices, IntPtr offset)
	{
		return (int)moveGripPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetGripPoints__SWIG_1(IntPtr pEntity, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, int bitFlags)
	{
		return (int)getGripPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdDbGripDataPtrArray(grips, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodmoveGripPointsAt__SWIG_1(IntPtr pEntity, IntPtr grips, IntPtr offset, int bitFlags)
	{
		return (int)moveGripPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdDbVoidPtrArray(grips, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitFlags);
	}

	private int SwigDirectorMethodgetStretchPoints(IntPtr pEntity, IntPtr stretchPoints)
	{
		return (int)getStretchPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(stretchPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodmoveStretchPointsAt(IntPtr pEntity, IntPtr indices, IntPtr offset)
	{
		return (int)moveStretchPointsAt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdIntArray(indices, cMemoryOwn: true), new OdGeVector3d(offset, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetOsnapPoints__SWIG_0(IntPtr pEntity, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints)
	{
		return (int)getOsnapPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetOsnapPoints__SWIG_1(IntPtr pEntity, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr xWorldToEye, IntPtr snapPoints, IntPtr insert)
	{
		return (int)getOsnapPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(xWorldToEye, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true), new OdGeMatrix3d(insert, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetGripPointsAtSubentPath(IntPtr pEntity, IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags)
	{
		return (int)getGripPointsAtSubentPath(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(path, cMemoryOwn: false), new OdDbGripDataPtrArray(grips, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitflags);
	}

	private int SwigDirectorMethodmoveGripPointsAtSubentPaths(IntPtr pEntity, IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags)
	{
		return (int)moveGripPointsAtSubentPaths(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPathArray(paths, cMemoryOwn: false), new OdDbVoidPtrArray(gripAppData, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitflags);
	}
}
