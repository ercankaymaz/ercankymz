using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbShModelerHistory : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbShModelerHistory_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbShModelerHistory_1();

	public delegate void SwigDelegateOdDbShModelerHistory_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbShModelerHistory_3(IntPtr pSolid, IntPtr pHistObj);

	public delegate void SwigDelegateOdDbShModelerHistory_4(IntPtr pHistObj, bool bShowHistory, bool bRecordHistory);

	public delegate void SwigDelegateOdDbShModelerHistory_5(IntPtr pHistObj, bool bShowHistory);

	public delegate void SwigDelegateOdDbShModelerHistory_6(IntPtr pHistObj, bool bRecordHistory);

	public delegate void SwigDelegateOdDbShModelerHistory_7(IntPtr pHistObj);

	public delegate int SwigDelegateOdDbShModelerHistory_8(IntPtr pSolid, double dXLen, double dYLen, double dZLen);

	public delegate int SwigDelegateOdDbShModelerHistory_9(IntPtr pSolid, double dHeight, double dXRadius, double dYRadius, double dTopXRadius);

	public delegate int SwigDelegateOdDbShModelerHistory_10(IntPtr pSolid, double dXLen, double dYLen, double dZLen);

	public delegate int SwigDelegateOdDbShModelerHistory_11(IntPtr pSolid, double dHeight, int iSides, double dRadius, double dTopRadius);

	public delegate int SwigDelegateOdDbShModelerHistory_12(IntPtr pSolid, double dRadius);

	public delegate int SwigDelegateOdDbShModelerHistory_13(IntPtr pSolid, double dMajorRadius, double dMinorRadius);

	public delegate int SwigDelegateOdDbShModelerHistory_14(IntPtr pSolid, IntPtr subentId, IntPtr color);

	public delegate int SwigDelegateOdDbShModelerHistory_15(IntPtr pSolid, IntPtr subentId, IntPtr matId);

	public delegate int SwigDelegateOdDbShModelerHistory_16(IntPtr pSolid, IntPtr crossSections, IntPtr guideCurves, IntPtr pPathCurve, IntPtr loftOpt);

	public delegate int SwigDelegateOdDbShModelerHistory_17(IntPtr pSolid, IntPtr pRevolveCurve, IntPtr axisPoint, IntPtr axisDir, double dAngleOfRevolution, double dStartAngle, IntPtr revolveOpt);

	public delegate int SwigDelegateOdDbShModelerHistory_18(IntPtr pSolid, IntPtr pSweepCurve, IntPtr pPathCurve, IntPtr directioVector, IntPtr sweepOpt);

	public delegate int SwigDelegateOdDbShModelerHistory_19(IntPtr pSolid, IntPtr pSecondEll, int operation);

	public delegate int SwigDelegateOdDbShModelerHistory_20(IntPtr objSolidId);

	public delegate int SwigDelegateOdDbShModelerHistory_21(IntPtr pSolid, IntPtr xform);

	public delegate int SwigDelegateOdDbShModelerHistory_22(IntPtr pSolid, IntPtr edgeSubentIds, IntPtr radius, IntPtr startSetback, IntPtr endSetback);

	public delegate int SwigDelegateOdDbShModelerHistory_23(IntPtr pSolid, IntPtr edgeSubentIds, IntPtr baseFaceSubentId, double baseDist, double otherDist);

	public delegate int SwigDelegateOdDbShModelerHistory_24(IntPtr pHistObj, IntPtr params_, int requiredType);

	public delegate bool SwigDelegateOdDbShModelerHistory_25(IntPtr pWd, IntPtr pSolid);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbShModelerHistory_0 swigDelegate0;

	private SwigDelegateOdDbShModelerHistory_1 swigDelegate1;

	private SwigDelegateOdDbShModelerHistory_2 swigDelegate2;

	private SwigDelegateOdDbShModelerHistory_3 swigDelegate3;

	private SwigDelegateOdDbShModelerHistory_4 swigDelegate4;

	private SwigDelegateOdDbShModelerHistory_5 swigDelegate5;

	private SwigDelegateOdDbShModelerHistory_6 swigDelegate6;

	private SwigDelegateOdDbShModelerHistory_7 swigDelegate7;

	private SwigDelegateOdDbShModelerHistory_8 swigDelegate8;

	private SwigDelegateOdDbShModelerHistory_9 swigDelegate9;

	private SwigDelegateOdDbShModelerHistory_10 swigDelegate10;

	private SwigDelegateOdDbShModelerHistory_11 swigDelegate11;

	private SwigDelegateOdDbShModelerHistory_12 swigDelegate12;

	private SwigDelegateOdDbShModelerHistory_13 swigDelegate13;

	private SwigDelegateOdDbShModelerHistory_14 swigDelegate14;

	private SwigDelegateOdDbShModelerHistory_15 swigDelegate15;

	private SwigDelegateOdDbShModelerHistory_16 swigDelegate16;

	private SwigDelegateOdDbShModelerHistory_17 swigDelegate17;

	private SwigDelegateOdDbShModelerHistory_18 swigDelegate18;

	private SwigDelegateOdDbShModelerHistory_19 swigDelegate19;

	private SwigDelegateOdDbShModelerHistory_20 swigDelegate20;

	private SwigDelegateOdDbShModelerHistory_21 swigDelegate21;

	private SwigDelegateOdDbShModelerHistory_22 swigDelegate22;

	private SwigDelegateOdDbShModelerHistory_23 swigDelegate23;

	private SwigDelegateOdDbShModelerHistory_24 swigDelegate24;

	private SwigDelegateOdDbShModelerHistory_25 swigDelegate25;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbObject).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbObject).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbObject).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdDb3dSolid),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes9 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes10 = new Type[4]
	{
		typeof(OdDb3dSolid),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes11 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(double),
		typeof(int),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(double)
	};

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdDb3dSolid),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbSubentId),
		typeof(OdCmColor)
	};

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbSubentId),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes16 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbEntityPtrArray),
		typeof(OdDbEntityPtrArray),
		typeof(OdDbEntity),
		typeof(OdDbLoftOptions)
	};

	private static Type[] swigMethodTypes17 = new Type[7]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbEntity),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(OdDbRevolveOptions)
	};

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(OdGeVector3d),
		typeof(OdDbSweepOptions)
	};

	private static Type[] swigMethodTypes19 = new Type[3]
	{
		typeof(OdDb3dSolid),
		typeof(OdDb3dSolid),
		typeof(OdDb_BoolOperType)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(OdDb3dSolid),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes22 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(OdArray_OdDbSubentId__p_OdObjectsAllocator),
		typeof(OdDoubleArray),
		typeof(OdDoubleArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes23 = new Type[5]
	{
		typeof(OdDb3dSolid),
		typeof(OdArray_OdDbSubentId__p_OdObjectsAllocator),
		typeof(OdDbSubentId),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes24 = new Type[3]
	{
		typeof(OdDbObject).MakeByRefType(),
		typeof(SWIGTYPE_p_p_OdDb3dSolidGeomParams),
		typeof(OdDb3dSolid_GeomType)
	};

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdGiWorldDraw),
		typeof(OdDb3dSolid)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbShModelerHistory(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbShModelerHistory obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbShModelerHistory(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbShModelerHistory cast(OdRxObject pObj)
	{
		OdDbShModelerHistory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbShModelerHistory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_isASwigExplicitOdDbShModelerHistory(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_queryXSwigExplicitOdDbShModelerHistory(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbShModelerHistory createObject()
	{
		OdDbShModelerHistory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbShModelerHistory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId createShHistory(OdDb3dSolid pSolid, ref OdDbObject pHistObj)
	{
		IntPtr jarg = ((pHistObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pHistObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createShHistory(swigCPtr, OdDb3dSolid.getCPtr(pSolid), ref jarg), cMemoryOwn: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pHistObj = null;
			}
			else if (jarg != intPtr)
			{
				pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void getHistoryVariables(OdDbObject pHistObj, out bool bShowHistory, out bool bRecordHistory)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_getHistoryVariables(swigCPtr, OdDbObject.getCPtr(pHistObj), out bShowHistory, out bRecordHistory);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShowHistory(ref OdDbObject pHistObj, bool bShowHistory)
	{
		IntPtr jarg = ((pHistObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pHistObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_setShowHistory(swigCPtr, ref jarg, bShowHistory);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pHistObj = null;
			}
			else if (jarg != intPtr)
			{
				pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void setRecordHistory(ref OdDbObject pHistObj, bool bRecordHistory)
	{
		IntPtr jarg = ((pHistObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pHistObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_setRecordHistory(swigCPtr, ref jarg, bRecordHistory);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pHistObj = null;
			}
			else if (jarg != intPtr)
			{
				pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void clearHistory(ref OdDbObject pHistObj)
	{
		IntPtr jarg = ((pHistObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pHistObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_clearHistory(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pHistObj = null;
			}
			else if (jarg != intPtr)
			{
				pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult createBox(OdDb3dSolid pSolid, double dXLen, double dYLen, double dZLen)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createBox(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dXLen, dYLen, dZLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createFrustum(OdDb3dSolid pSolid, double dHeight, double dXRadius, double dYRadius, double dTopXRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createFrustum(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dHeight, dXRadius, dYRadius, dTopXRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createWedge(OdDb3dSolid pSolid, double dXLen, double dYLen, double dZLen)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createWedge(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dXLen, dYLen, dZLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createPyramid(OdDb3dSolid pSolid, double dHeight, int iSides, double dRadius, double dTopRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createPyramid(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dHeight, iSides, dRadius, dTopRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSphere(OdDb3dSolid pSolid, double dRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createSphere(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createTorus(OdDb3dSolid pSolid, double dMajorRadius, double dMinorRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createTorus(swigCPtr, OdDb3dSolid.getCPtr(pSolid), dMajorRadius, dMinorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentColor(OdDb3dSolid pSolid, OdDbSubentId subentId, OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_setSubentColor(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterial(OdDb3dSolid pSolid, OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_setSubentMaterial(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoftedSolid(OdDb3dSolid pSolid, OdDbEntityPtrArray crossSections, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, OdDbLoftOptions loftOpt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createLoftedSolid(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbEntityPtrArray.getCPtr(crossSections), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), OdDbLoftOptions.getCPtr(loftOpt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedSolid(OdDb3dSolid pSolid, OdDbEntity pRevolveCurve, OdGePoint3d axisPoint, OdGeVector3d axisDir, double dAngleOfRevolution, double dStartAngle, OdDbRevolveOptions revolveOpt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createRevolvedSolid(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbEntity.getCPtr(pRevolveCurve), OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), dAngleOfRevolution, dStartAngle, OdDbRevolveOptions.getCPtr(revolveOpt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptSolid(OdDb3dSolid pSolid, OdDbEntity pSweepCurve, OdDbEntity pPathCurve, OdGeVector3d directioVector, OdDbSweepOptions sweepOpt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_createSweptSolid(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDbEntity.getCPtr(pSweepCurve), OdDbEntity.getCPtr(pPathCurve), OdGeVector3d.getCPtr(directioVector), OdDbSweepOptions.getCPtr(sweepOpt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult booleanOper(OdDb3dSolid pSolid, OdDb3dSolid pSecondEll, OdDb_BoolOperType operation)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_booleanOper(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdDb3dSolid.getCPtr(pSecondEll), (int)operation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult postInDatabase(OdDbObjectId objSolidId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_postInDatabase(swigCPtr, OdDbObjectId.getCPtr(objSolidId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult subTransformBy(OdDb3dSolid pSolid, OdGeMatrix3d xform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_subTransformBy(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdGeMatrix3d.getCPtr(xform));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult filletEdges(OdDb3dSolid pSolid, OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDoubleArray radius, OdDoubleArray startSetback, OdDoubleArray endSetback)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_filletEdges(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDoubleArray.getCPtr(radius).Handle, OdDoubleArray.getCPtr(startSetback).Handle, OdDoubleArray.getCPtr(endSetback).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult chamferEdges(OdDb3dSolid pSolid, OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDbSubentId baseFaceSubentId, double baseDist, double otherDist)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_chamferEdges(swigCPtr, OdDb3dSolid.getCPtr(pSolid), OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDbSubentId.getCPtr(baseFaceSubentId), baseDist, otherDist);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDb3dSolid_GeomType determineGeomType(ref OdDbObject pHistObj, SWIGTYPE_p_p_OdDb3dSolidGeomParams params_, OdDb3dSolid_GeomType requiredType)
	{
		IntPtr jarg = ((pHistObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pHistObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_determineGeomType(swigCPtr, ref jarg, SWIGTYPE_p_p_OdDb3dSolidGeomParams.getCPtr(params_), (int)requiredType);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdDb3dSolid_GeomType)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pHistObj = null;
			}
			else if (jarg != intPtr)
			{
				pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual bool subWorldDraw(OdGiWorldDraw pWd, OdDb3dSolid pSolid)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_subWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd), OdDb3dSolid.getCPtr(pSolid));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("createShHistory", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateShHistory;
		}
		if (SwigDerivedClassHasMethod("getHistoryVariables", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetHistoryVariables;
		}
		if (SwigDerivedClassHasMethod("setShowHistory", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetShowHistory;
		}
		if (SwigDerivedClassHasMethod("setRecordHistory", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetRecordHistory;
		}
		if (SwigDerivedClassHasMethod("clearHistory", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodclearHistory;
		}
		if (SwigDerivedClassHasMethod("createBox", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreateBox;
		}
		if (SwigDerivedClassHasMethod("createFrustum", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateFrustum;
		}
		if (SwigDerivedClassHasMethod("createWedge", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcreateWedge;
		}
		if (SwigDerivedClassHasMethod("createPyramid", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcreatePyramid;
		}
		if (SwigDerivedClassHasMethod("createSphere", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcreateSphere;
		}
		if (SwigDerivedClassHasMethod("createTorus", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcreateTorus;
		}
		if (SwigDerivedClassHasMethod("setSubentColor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetSubentColor;
		}
		if (SwigDerivedClassHasMethod("setSubentMaterial", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetSubentMaterial;
		}
		if (SwigDerivedClassHasMethod("createLoftedSolid", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodcreateLoftedSolid;
		}
		if (SwigDerivedClassHasMethod("createRevolvedSolid", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodcreateRevolvedSolid;
		}
		if (SwigDerivedClassHasMethod("createSweptSolid", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcreateSweptSolid;
		}
		if (SwigDerivedClassHasMethod("booleanOper", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodbooleanOper;
		}
		if (SwigDerivedClassHasMethod("postInDatabase", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodpostInDatabase;
		}
		if (SwigDerivedClassHasMethod("subTransformBy", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsubTransformBy;
		}
		if (SwigDerivedClassHasMethod("filletEdges", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodfilletEdges;
		}
		if (SwigDerivedClassHasMethod("chamferEdges", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodchamferEdges;
		}
		if (SwigDerivedClassHasMethod("determineGeomType", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethoddetermineGeomType;
		}
		if (SwigDerivedClassHasMethod("subWorldDraw", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsubWorldDraw;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbShModelerHistory_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbShModelerHistory));
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

	private IntPtr SwigDirectorMethodcreateShHistory(IntPtr pSolid, IntPtr pHistObj)
	{
		OdSwigDirectorHelper.director_UnpackData(pHistObj, out var pOriginalObject, out var pFunction);
		OdDbObject p_pHistObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return ((Func<IntPtr>)delegate
			{
				try
				{
					return OdDbObjectId.getCPtr(createShHistory(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), ref p_pHistObj)).Handle;
				}
				catch (OdEdEmptyInput odEdEmptyInput)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
					throw odEdEmptyInput;
				}
				catch (OdEdOtherInput odEdOtherInput)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
					throw odEdOtherInput;
				}
				catch (OdError odError)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
					throw odError;
				}
				catch (Exception ex)
				{
					TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
					throw ex;
				}
			})();
		}
		finally
		{
			IntPtr handle = OdDbObject.getCPtr(p_pHistObj).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pHistObj);
		}
	}

	private void SwigDirectorMethodgetHistoryVariables(IntPtr pHistObj, bool bShowHistory, bool bRecordHistory)
	{
		try
		{
			getHistoryVariables(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pHistObj, bOwn: true, bTryAddToTransaction: false), out bShowHistory, out bRecordHistory);
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

	private void SwigDirectorMethodsetShowHistory(IntPtr pHistObj, bool bShowHistory)
	{
		OdSwigDirectorHelper.director_UnpackData(pHistObj, out var pOriginalObject, out var pFunction);
		OdDbObject pHistObj2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			setShowHistory(ref pHistObj2, bShowHistory);
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
		finally
		{
			IntPtr handle = OdDbObject.getCPtr(pHistObj2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pHistObj);
		}
	}

	private void SwigDirectorMethodsetRecordHistory(IntPtr pHistObj, bool bRecordHistory)
	{
		OdSwigDirectorHelper.director_UnpackData(pHistObj, out var pOriginalObject, out var pFunction);
		OdDbObject pHistObj2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			setRecordHistory(ref pHistObj2, bRecordHistory);
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
		finally
		{
			IntPtr handle = OdDbObject.getCPtr(pHistObj2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pHistObj);
		}
	}

	private void SwigDirectorMethodclearHistory(IntPtr pHistObj)
	{
		OdSwigDirectorHelper.director_UnpackData(pHistObj, out var pOriginalObject, out var pFunction);
		OdDbObject pHistObj2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			clearHistory(ref pHistObj2);
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
		finally
		{
			IntPtr handle = OdDbObject.getCPtr(pHistObj2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pHistObj);
		}
	}

	private int SwigDirectorMethodcreateBox(IntPtr pSolid, double dXLen, double dYLen, double dZLen)
	{
		return (int)createBox(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dXLen, dYLen, dZLen);
	}

	private int SwigDirectorMethodcreateFrustum(IntPtr pSolid, double dHeight, double dXRadius, double dYRadius, double dTopXRadius)
	{
		return (int)createFrustum(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dHeight, dXRadius, dYRadius, dTopXRadius);
	}

	private int SwigDirectorMethodcreateWedge(IntPtr pSolid, double dXLen, double dYLen, double dZLen)
	{
		return (int)createWedge(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dXLen, dYLen, dZLen);
	}

	private int SwigDirectorMethodcreatePyramid(IntPtr pSolid, double dHeight, int iSides, double dRadius, double dTopRadius)
	{
		return (int)createPyramid(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dHeight, iSides, dRadius, dTopRadius);
	}

	private int SwigDirectorMethodcreateSphere(IntPtr pSolid, double dRadius)
	{
		return (int)createSphere(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dRadius);
	}

	private int SwigDirectorMethodcreateTorus(IntPtr pSolid, double dMajorRadius, double dMinorRadius)
	{
		return (int)createTorus(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), dMajorRadius, dMinorRadius);
	}

	private int SwigDirectorMethodsetSubentColor(IntPtr pSolid, IntPtr subentId, IntPtr color)
	{
		return (int)setSubentColor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subentId, cMemoryOwn: false), new OdCmColor(color, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetSubentMaterial(IntPtr pSolid, IntPtr subentId, IntPtr matId)
	{
		return (int)setSubentMaterial(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdDbSubentId(subentId, cMemoryOwn: false), new OdDbObjectId(matId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodcreateLoftedSolid(IntPtr pSolid, IntPtr crossSections, IntPtr guideCurves, IntPtr pPathCurve, IntPtr loftOpt)
	{
		return (int)createLoftedSolid(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdDbEntityPtrArray(crossSections, cMemoryOwn: false), new OdDbEntityPtrArray(guideCurves, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pPathCurve, bOwn: false, bTryAddToTransaction: false), new OdDbLoftOptions(loftOpt, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcreateRevolvedSolid(IntPtr pSolid, IntPtr pRevolveCurve, IntPtr axisPoint, IntPtr axisDir, double dAngleOfRevolution, double dStartAngle, IntPtr revolveOpt)
	{
		return (int)createRevolvedSolid(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pRevolveCurve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(axisPoint, cMemoryOwn: false), new OdGeVector3d(axisDir, cMemoryOwn: false), dAngleOfRevolution, dStartAngle, new OdDbRevolveOptions(revolveOpt, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcreateSweptSolid(IntPtr pSolid, IntPtr pSweepCurve, IntPtr pPathCurve, IntPtr directioVector, IntPtr sweepOpt)
	{
		return (int)createSweptSolid(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSweepCurve, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pPathCurve, bOwn: false, bTryAddToTransaction: false), new OdGeVector3d(directioVector, cMemoryOwn: false), new OdDbSweepOptions(sweepOpt, cMemoryOwn: false));
	}

	private int SwigDirectorMethodbooleanOper(IntPtr pSolid, IntPtr pSecondEll, int operation)
	{
		return (int)booleanOper(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSecondEll, bOwn: false, bTryAddToTransaction: false), (OdDb_BoolOperType)operation);
	}

	private int SwigDirectorMethodpostInDatabase(IntPtr objSolidId)
	{
		return (int)postInDatabase(new OdDbObjectId(objSolidId, cMemoryOwn: true));
	}

	private int SwigDirectorMethodsubTransformBy(IntPtr pSolid, IntPtr xform)
	{
		return (int)subTransformBy(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xform, cMemoryOwn: false));
	}

	private int SwigDirectorMethodfilletEdges(IntPtr pSolid, IntPtr edgeSubentIds, IntPtr radius, IntPtr startSetback, IntPtr endSetback)
	{
		return (int)filletEdges(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdArray_OdDbSubentId__p_OdObjectsAllocator(edgeSubentIds, cMemoryOwn: false), new OdDoubleArray(radius, cMemoryOwn: true), new OdDoubleArray(startSetback, cMemoryOwn: true), new OdDoubleArray(endSetback, cMemoryOwn: true));
	}

	private int SwigDirectorMethodchamferEdges(IntPtr pSolid, IntPtr edgeSubentIds, IntPtr baseFaceSubentId, double baseDist, double otherDist)
	{
		return (int)chamferEdges(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false), new OdArray_OdDbSubentId__p_OdObjectsAllocator(edgeSubentIds, cMemoryOwn: false), new OdDbSubentId(baseFaceSubentId, cMemoryOwn: false), baseDist, otherDist);
	}

	private int SwigDirectorMethoddetermineGeomType(IntPtr pHistObj, IntPtr params_, int requiredType)
	{
		OdSwigDirectorHelper.director_UnpackData(pHistObj, out var pOriginalObject, out var pFunction);
		OdDbObject pHistObj2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)determineGeomType(ref pHistObj2, (params_ == IntPtr.Zero) ? null : new SWIGTYPE_p_p_OdDb3dSolidGeomParams(params_, futureUse: false), (OdDb3dSolid_GeomType)requiredType);
		}
		finally
		{
			IntPtr handle = OdDbObject.getCPtr(pHistObj2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pHistObj);
		}
	}

	private bool SwigDirectorMethodsubWorldDraw(IntPtr pWd, IntPtr pSolid)
	{
		return subWorldDraw(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiWorldDraw>(pWd, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(pSolid, bOwn: false, bTryAddToTransaction: false));
	}
}
