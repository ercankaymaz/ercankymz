using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdModelerTools : OdRxObject
{
	public delegate IntPtr SwigDelegateOdModelerTools_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdModelerTools_1();

	public delegate void SwigDelegateOdModelerTools_2(IntPtr pSource);

	public delegate int SwigDelegateOdModelerTools_3();

	public delegate void SwigDelegateOdModelerTools_4(uint nThreads, IntPtr aThreads);

	public delegate void SwigDelegateOdModelerTools_5(uint nThreads, IntPtr aThreads);

	public delegate bool SwigDelegateOdModelerTools_6();

	public delegate bool SwigDelegateOdModelerTools_7();

	public delegate bool SwigDelegateOdModelerTools_8();

	public delegate int SwigDelegateOdModelerTools_9(IntPtr arg0, IntPtr report);

	public delegate void SwigDelegateOdModelerTools_10(IntPtr func, IntPtr data);

	public delegate int SwigDelegateOdModelerTools_11(IntPtr geom, IntPtr aHatch);

	public delegate bool SwigDelegateOdModelerTools_12(IntPtr pEntity, uint color);

	public delegate bool SwigDelegateOdModelerTools_13(IntPtr pEntity, uint color);

	public delegate int SwigDelegateOdModelerTools_14(int testMode);

	public delegate int SwigDelegateOdModelerTools_15(IntPtr obj1, IntPtr subId1, IntPtr toWc1, IntPtr obj2, IntPtr subId2, IntPtr toWc2, IntPtr nearestPt1, IntPtr nearestPt2);

	public delegate int SwigDelegateOdModelerTools_16(IntPtr obj, IntPtr subId, IntPtr toWc, IntPtr curve, IntPtr nearestPt1, IntPtr nearestPt2);

	public delegate int SwigDelegateOdModelerTools_17(IntPtr obj, IntPtr subId, IntPtr toWc, IntPtr inPt, IntPtr nearestPt);

	public delegate int SwigDelegateOdModelerTools_18(IntPtr obj1, IntPtr subId1, IntPtr toWc1, IntPtr pts2, IntPtr edges2, IntPtr nearestPt1, IntPtr nearestPt2);

	public delegate int SwigDelegateOdModelerTools_19(IntPtr srcModeler, IntPtr mtx, IntPtr pCloneModeler);

	public delegate int SwigDelegateOdModelerTools_20(IntPtr object_, IntPtr direction, IntPtr maxPoint);

	public delegate int SwigDelegateOdModelerTools_21(IntPtr object_, IntPtr direction, IntPtr minPoint, IntPtr maxPoint);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdModelerTools_0 swigDelegate0;

	private SwigDelegateOdModelerTools_1 swigDelegate1;

	private SwigDelegateOdModelerTools_2 swigDelegate2;

	private SwigDelegateOdModelerTools_3 swigDelegate3;

	private SwigDelegateOdModelerTools_4 swigDelegate4;

	private SwigDelegateOdModelerTools_5 swigDelegate5;

	private SwigDelegateOdModelerTools_6 swigDelegate6;

	private SwigDelegateOdModelerTools_7 swigDelegate7;

	private SwigDelegateOdModelerTools_8 swigDelegate8;

	private SwigDelegateOdModelerTools_9 swigDelegate9;

	private SwigDelegateOdModelerTools_10 swigDelegate10;

	private SwigDelegateOdModelerTools_11 swigDelegate11;

	private SwigDelegateOdModelerTools_12 swigDelegate12;

	private SwigDelegateOdModelerTools_13 swigDelegate13;

	private SwigDelegateOdModelerTools_14 swigDelegate14;

	private SwigDelegateOdModelerTools_15 swigDelegate15;

	private SwigDelegateOdModelerTools_16 swigDelegate16;

	private SwigDelegateOdModelerTools_17 swigDelegate17;

	private SwigDelegateOdModelerTools_18 swigDelegate18;

	private SwigDelegateOdModelerTools_19 swigDelegate19;

	private SwigDelegateOdModelerTools_20 swigDelegate20;

	private SwigDelegateOdModelerTools_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegate),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntityPtrArray)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes15 = new Type[8]
	{
		typeof(OdModelerGeometry),
		typeof(OdDbSubentId),
		typeof(OdGeMatrix3d),
		typeof(OdModelerGeometry),
		typeof(OdDbSubentId),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes16 = new Type[6]
	{
		typeof(OdModelerGeometry),
		typeof(OdDbSubentId),
		typeof(OdGeMatrix3d),
		typeof(OdGeCurve3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes17 = new Type[5]
	{
		typeof(OdModelerGeometry),
		typeof(OdDbSubentId),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes18 = new Type[7]
	{
		typeof(OdModelerGeometry),
		typeof(OdDbSubentId),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdInt32Array),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes19 = new Type[3]
	{
		typeof(OdModelerGeometry),
		typeof(OdGeMatrix3d),
		typeof(OdModelerGeometry).MakeByRefType()
	};

	private static Type[] swigMethodTypes20 = new Type[3]
	{
		typeof(OdModelerGeometry),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes21 = new Type[4]
	{
		typeof(OdModelerGeometry),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdModelerTools(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdModelerTools obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdModelerTools(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdModelerTools cast(OdRxObject pObj)
	{
		OdModelerTools rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerTools>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_isASwigExplicitOdModelerTools(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_queryXSwigExplicitOdModelerTools(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdModelerTools createObject()
	{
		OdModelerTools rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerTools>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult deleteModelerBulletins()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_deleteModelerBulletins(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void beginThreadSafetyMode(uint nThreads, uint[] aThreads)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_beginThreadSafetyMode(swigCPtr, nThreads, ODA.Kernel.TD_RootIntegrated.Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endThreadSafetyMode(uint nThreads, uint[] aThreads)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_endThreadSafetyMode(swigCPtr, nThreads, ODA.Kernel.TD_RootIntegrated.Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool startThread()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_startThread(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool stopThread()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_stopThread(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isThreadStarted()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_isThreadStarted(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult check3dSolid(OdDb3dSolid arg0, ref string report)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(report);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_check3dSolid(swigCPtr, OdDb3dSolid.getCPtr(arg0), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				report = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void executeInMainHistoryStream(TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegate func, IntPtr data)
	{
		TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegateNative mainHistStreamFuncDelegateNative = null;
		if (func != null)
		{
			mainHistStreamFuncDelegateNative = delegate(IntPtr __arg)
			{
				func(__arg);
			};
		}
		IntPtr jarg = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mainHistStreamFuncDelegateNative));
		DelegateHolder.Add(mainHistStreamFuncDelegateNative);
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_executeInMainHistoryStream(swigCPtr, jarg, data);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult createHatchFromModelerGeometry(OdDbEntity geom, OdDbEntityPtrArray aHatch)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_createHatchFromModelerGeometry(swigCPtr, OdDbEntity.getCPtr(geom), OdDbEntityPtrArray.getCPtr(aHatch));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool getAdeskTrueCol(IntPtr pEntity, out uint color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getAdeskTrueCol(swigCPtr, pEntity, out color);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getAdeskCol(IntPtr pEntity, out uint color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getAdeskCol(swigCPtr, pEntity, out color);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int setTestMode(int testMode)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_setTestMode(swigCPtr, testMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getClosestPoints(OdModelerGeometry obj1, OdDbSubentId subId1, OdGeMatrix3d toWc1, OdModelerGeometry obj2, OdDbSubentId subId2, OdGeMatrix3d toWc2, OdGePoint3d nearestPt1, OdGePoint3d nearestPt2)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getClosestPoints__SWIG_0(swigCPtr, OdModelerGeometry.getCPtr(obj1), OdDbSubentId.getCPtr(subId1), OdGeMatrix3d.getCPtr(toWc1), OdModelerGeometry.getCPtr(obj2), OdDbSubentId.getCPtr(subId2), OdGeMatrix3d.getCPtr(toWc2), OdGePoint3d.getCPtr(nearestPt1), OdGePoint3d.getCPtr(nearestPt2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPoints(OdModelerGeometry obj, OdDbSubentId subId, OdGeMatrix3d toWc, OdGeCurve3d curve, OdGePoint3d nearestPt1, OdGePoint3d nearestPt2)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getClosestPoints__SWIG_1(swigCPtr, OdModelerGeometry.getCPtr(obj), OdDbSubentId.getCPtr(subId), OdGeMatrix3d.getCPtr(toWc), OdGeCurve3d.getCPtr(curve), OdGePoint3d.getCPtr(nearestPt1), OdGePoint3d.getCPtr(nearestPt2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPoints(OdModelerGeometry obj, OdDbSubentId subId, OdGeMatrix3d toWc, OdGePoint3d inPt, OdGePoint3d nearestPt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getClosestPoints__SWIG_2(swigCPtr, OdModelerGeometry.getCPtr(obj), OdDbSubentId.getCPtr(subId), OdGeMatrix3d.getCPtr(toWc), OdGePoint3d.getCPtr(inPt), OdGePoint3d.getCPtr(nearestPt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPoints(OdModelerGeometry obj1, OdDbSubentId subId1, OdGeMatrix3d toWc1, OdGePoint3dArray pts2, OdInt32Array edges2, OdGePoint3d nearestPt1, OdGePoint3d nearestPt2)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getClosestPoints__SWIG_3(swigCPtr, OdModelerGeometry.getCPtr(obj1), OdDbSubentId.getCPtr(subId1), OdGeMatrix3d.getCPtr(toWc1), OdGePoint3dArray.getCPtr(pts2).Handle, OdInt32Array.getCPtr(edges2).Handle, OdGePoint3d.getCPtr(nearestPt1), OdGePoint3d.getCPtr(nearestPt2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult cloneAndXform(OdModelerGeometry srcModeler, OdGeMatrix3d mtx, ref OdModelerGeometry pCloneModeler)
	{
		IntPtr jarg = ((pCloneModeler == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pCloneModeler).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_cloneAndXform(swigCPtr, OdModelerGeometry.getCPtr(srcModeler), OdGeMatrix3d.getCPtr(mtx), ref jarg);
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
				pCloneModeler = null;
			}
			else if (jarg != intPtr)
			{
				pCloneModeler = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getMaxPoint(OdModelerGeometry object_, OdGeVector3d direction, OdGePoint3d maxPoint)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getMaxPoint(swigCPtr, OdModelerGeometry.getCPtr(object_), OdGeVector3d.getCPtr(direction), OdGePoint3d.getCPtr(maxPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getExtremePoints(OdModelerGeometry object_, OdGeVector3d direction, OdGePoint3d minPoint, OdGePoint3d maxPoint)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getExtremePoints(swigCPtr, OdModelerGeometry.getCPtr(object_), OdGeVector3d.getCPtr(direction), OdGePoint3d.getCPtr(minPoint), OdGePoint3d.getCPtr(maxPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("deleteModelerBulletins", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddeleteModelerBulletins;
		}
		if (SwigDerivedClassHasMethod("beginThreadSafetyMode", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodbeginThreadSafetyMode;
		}
		if (SwigDerivedClassHasMethod("endThreadSafetyMode", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodendThreadSafetyMode;
		}
		if (SwigDerivedClassHasMethod("startThread", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodstartThread;
		}
		if (SwigDerivedClassHasMethod("stopThread", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodstopThread;
		}
		if (SwigDerivedClassHasMethod("isThreadStarted", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisThreadStarted;
		}
		if (SwigDerivedClassHasMethod("check3dSolid", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcheck3dSolid;
		}
		if (SwigDerivedClassHasMethod("executeInMainHistoryStream", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodexecuteInMainHistoryStream;
		}
		if (SwigDerivedClassHasMethod("createHatchFromModelerGeometry", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcreateHatchFromModelerGeometry;
		}
		if (SwigDerivedClassHasMethod("getAdeskTrueCol", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetAdeskTrueCol;
		}
		if (SwigDerivedClassHasMethod("getAdeskCol", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetAdeskCol;
		}
		if (SwigDerivedClassHasMethod("setTestMode", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetTestMode;
		}
		if (SwigDerivedClassHasMethod("getClosestPoints", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetClosestPoints__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getClosestPoints", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetClosestPoints__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPoints", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetClosestPoints__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getClosestPoints", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetClosestPoints__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("cloneAndXform", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcloneAndXform;
		}
		if (SwigDerivedClassHasMethod("getMaxPoint", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetMaxPoint;
		}
		if (SwigDerivedClassHasMethod("getExtremePoints", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetExtremePoints;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerTools_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdModelerTools));
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

	private int SwigDirectorMethoddeleteModelerBulletins()
	{
		return (int)deleteModelerBulletins();
	}

	private void SwigDirectorMethodbeginThreadSafetyMode(uint nThreads, IntPtr aThreads)
	{
		try
		{
			beginThreadSafetyMode(nThreads, ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalUInt32FixedArray(aThreads));
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

	private void SwigDirectorMethodendThreadSafetyMode(uint nThreads, IntPtr aThreads)
	{
		try
		{
			endThreadSafetyMode(nThreads, ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalUInt32FixedArray(aThreads));
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

	private bool SwigDirectorMethodstartThread()
	{
		return startThread();
	}

	private bool SwigDirectorMethodstopThread()
	{
		return stopThread();
	}

	private bool SwigDirectorMethodisThreadStarted()
	{
		return isThreadStarted();
	}

	private int SwigDirectorMethodcheck3dSolid(IntPtr arg0, IntPtr report)
	{
		OdSwigDirectorHelper.director_UnpackData(report, out var pOriginalObject, out var pFunction);
		string report2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = report2;
		try
		{
			return (int)check3dSolid(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(arg0, bOwn: false, bTryAddToTransaction: false), ref report2);
		}
		finally
		{
			if (report2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(report2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(report);
		}
	}

	private void SwigDirectorMethodexecuteInMainHistoryStream(IntPtr func, IntPtr data)
	{
		try
		{
			executeInMainHistoryStream(((Func<TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegate>)delegate
			{
				IntPtr nativeCallback = func;
				TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = delegate(IntPtr __arg)
					{
						(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegateNative)) as TD_DbCoreIntegrated_Globals.MainHistStreamFuncDelegateNative)(__arg);
					};
				}
				return result;
			})(), data);
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

	private int SwigDirectorMethodcreateHatchFromModelerGeometry(IntPtr geom, IntPtr aHatch)
	{
		return (int)createHatchFromModelerGeometry(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(geom, bOwn: false, bTryAddToTransaction: false), new OdDbEntityPtrArray(aHatch, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodgetAdeskTrueCol(IntPtr pEntity, uint color)
	{
		return getAdeskTrueCol(pEntity, out color);
	}

	private bool SwigDirectorMethodgetAdeskCol(IntPtr pEntity, uint color)
	{
		return getAdeskCol(pEntity, out color);
	}

	private int SwigDirectorMethodsetTestMode(int testMode)
	{
		return setTestMode(testMode);
	}

	private int SwigDirectorMethodgetClosestPoints__SWIG_0(IntPtr obj1, IntPtr subId1, IntPtr toWc1, IntPtr obj2, IntPtr subId2, IntPtr toWc2, IntPtr nearestPt1, IntPtr nearestPt2)
	{
		return (int)getClosestPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(obj1, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subId1, cMemoryOwn: false), new OdGeMatrix3d(toWc1, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(obj2, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subId2, cMemoryOwn: false), new OdGeMatrix3d(toWc2, cMemoryOwn: false), new OdGePoint3d(nearestPt1, cMemoryOwn: false), new OdGePoint3d(nearestPt2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPoints__SWIG_1(IntPtr obj, IntPtr subId, IntPtr toWc, IntPtr curve, IntPtr nearestPt1, IntPtr nearestPt2)
	{
		return (int)getClosestPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(obj, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subId, cMemoryOwn: false), new OdGeMatrix3d(toWc, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdGeCurve3d>(curve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(nearestPt1, cMemoryOwn: false), new OdGePoint3d(nearestPt2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPoints__SWIG_2(IntPtr obj, IntPtr subId, IntPtr toWc, IntPtr inPt, IntPtr nearestPt)
	{
		return (int)getClosestPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(obj, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subId, cMemoryOwn: false), new OdGeMatrix3d(toWc, cMemoryOwn: false), new OdGePoint3d(inPt, cMemoryOwn: false), new OdGePoint3d(nearestPt, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPoints__SWIG_3(IntPtr obj1, IntPtr subId1, IntPtr toWc1, IntPtr pts2, IntPtr edges2, IntPtr nearestPt1, IntPtr nearestPt2)
	{
		return (int)getClosestPoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(obj1, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subId1, cMemoryOwn: false), new OdGeMatrix3d(toWc1, cMemoryOwn: false), new OdGePoint3dArray(pts2, cMemoryOwn: true), new OdInt32Array(edges2, cMemoryOwn: true), new OdGePoint3d(nearestPt1, cMemoryOwn: false), new OdGePoint3d(nearestPt2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcloneAndXform(IntPtr srcModeler, IntPtr mtx, IntPtr pCloneModeler)
	{
		OdSwigDirectorHelper.director_UnpackData(pCloneModeler, out var pOriginalObject, out var pFunction);
		OdModelerGeometry pCloneModeler2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)cloneAndXform(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(srcModeler, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(mtx, cMemoryOwn: false), ref pCloneModeler2);
		}
		finally
		{
			IntPtr handle = OdModelerGeometry.getCPtr(pCloneModeler2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCloneModeler);
		}
	}

	private int SwigDirectorMethodgetMaxPoint(IntPtr object_, IntPtr direction, IntPtr maxPoint)
	{
		return (int)getMaxPoint(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(object_, bOwn: false, bTryAddToTransaction: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGePoint3d(maxPoint, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetExtremePoints(IntPtr object_, IntPtr direction, IntPtr minPoint, IntPtr maxPoint)
	{
		return (int)getExtremePoints(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(object_, bOwn: false, bTryAddToTransaction: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGePoint3d(minPoint, cMemoryOwn: false), new OdGePoint3d(maxPoint, cMemoryOwn: false));
	}
}
