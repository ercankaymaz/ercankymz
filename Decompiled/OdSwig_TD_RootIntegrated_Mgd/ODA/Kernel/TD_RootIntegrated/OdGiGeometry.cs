using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGeometry : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiGeometry_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiGeometry_1();

	public delegate void SwigDelegateOdGiGeometry_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiGeometry_3();

	public delegate IntPtr SwigDelegateOdGiGeometry_4();

	public delegate void SwigDelegateOdGiGeometry_5(IntPtr normal);

	public delegate void SwigDelegateOdGiGeometry_6(IntPtr xfm);

	public delegate void SwigDelegateOdGiGeometry_7();

	public delegate IntPtr SwigDelegateOdGiGeometry_8(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiGeometry_9(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiGeometry_10(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiGeometry_11(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiGeometry_12(int behavior);

	public delegate void SwigDelegateOdGiGeometry_13(IntPtr center, double radius, IntPtr normal);

	public delegate void SwigDelegateOdGiGeometry_14(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiGeometry_15(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType);

	public delegate void SwigDelegateOdGiGeometry_16(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle);

	public delegate void SwigDelegateOdGiGeometry_17(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType);

	public delegate void SwigDelegateOdGiGeometry_18(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiGeometry_19(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker);

	public delegate void SwigDelegateOdGiGeometry_20(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiGeometry_21(IntPtr numVertices);

	public delegate void SwigDelegateOdGiGeometry_22(IntPtr numVertices);

	public delegate void SwigDelegateOdGiGeometry_23(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiGeometry_24(IntPtr polyline, uint fromIndex, uint numSegs);

	public delegate void SwigDelegateOdGiGeometry_25(IntPtr polyline, uint fromIndex);

	public delegate void SwigDelegateOdGiGeometry_26(IntPtr polyline);

	public delegate void SwigDelegateOdGiGeometry_27(IntPtr numRows);

	public delegate void SwigDelegateOdGiGeometry_28(IntPtr numVertices);

	public delegate void SwigDelegateOdGiGeometry_29(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiGeometry_30(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiGeometry_31(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGiGeometry_32(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGiGeometry_33(IntPtr nurbsCurve);

	public delegate void SwigDelegateOdGiGeometry_34(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType);

	public delegate void SwigDelegateOdGiGeometry_35(IntPtr ellipArc, IntPtr endPointsOverrides);

	public delegate void SwigDelegateOdGiGeometry_36(IntPtr ellipArc);

	public delegate void SwigDelegateOdGiGeometry_37(IntPtr pDrawable);

	public delegate void SwigDelegateOdGiGeometry_38(IntPtr pBoundary);

	public delegate void SwigDelegateOdGiGeometry_39();

	public delegate void SwigDelegateOdGiGeometry_40(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode);

	public delegate void SwigDelegateOdGiGeometry_41(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec);

	public delegate void SwigDelegateOdGiGeometry_42(IntPtr edges);

	public delegate IntPtr SwigDelegateOdGiGeometry_43();

	public delegate void SwigDelegateOdGiGeometry_44(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGiGeometry_45(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize);

	public delegate void SwigDelegateOdGiGeometry_46(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers);

	public delegate void SwigDelegateOdGiGeometry_47(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals);

	public delegate void SwigDelegateOdGiGeometry_48(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency);

	public delegate void SwigDelegateOdGiGeometry_49(IntPtr numPoints, IntPtr pColors, IntPtr pNormals);

	public delegate void SwigDelegateOdGiGeometry_50(IntPtr numPoints, IntPtr pColors);

	public delegate void SwigDelegateOdGiGeometry_51(IntPtr numPoints, IntPtr pNormals);

	public delegate void SwigDelegateOdGiGeometry_52(IntPtr numPoints);

	public delegate void SwigDelegateOdGiGeometry_53(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint);

	public delegate void SwigDelegateOdGiGeometry_54(IntPtr pCloud);

	public delegate bool SwigDelegateOdGiGeometry_55(IntPtr giBrep);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiGeometry_0 swigDelegate0;

	private SwigDelegateOdGiGeometry_1 swigDelegate1;

	private SwigDelegateOdGiGeometry_2 swigDelegate2;

	private SwigDelegateOdGiGeometry_3 swigDelegate3;

	private SwigDelegateOdGiGeometry_4 swigDelegate4;

	private SwigDelegateOdGiGeometry_5 swigDelegate5;

	private SwigDelegateOdGiGeometry_6 swigDelegate6;

	private SwigDelegateOdGiGeometry_7 swigDelegate7;

	private SwigDelegateOdGiGeometry_8 swigDelegate8;

	private SwigDelegateOdGiGeometry_9 swigDelegate9;

	private SwigDelegateOdGiGeometry_10 swigDelegate10;

	private SwigDelegateOdGiGeometry_11 swigDelegate11;

	private SwigDelegateOdGiGeometry_12 swigDelegate12;

	private SwigDelegateOdGiGeometry_13 swigDelegate13;

	private SwigDelegateOdGiGeometry_14 swigDelegate14;

	private SwigDelegateOdGiGeometry_15 swigDelegate15;

	private SwigDelegateOdGiGeometry_16 swigDelegate16;

	private SwigDelegateOdGiGeometry_17 swigDelegate17;

	private SwigDelegateOdGiGeometry_18 swigDelegate18;

	private SwigDelegateOdGiGeometry_19 swigDelegate19;

	private SwigDelegateOdGiGeometry_20 swigDelegate20;

	private SwigDelegateOdGiGeometry_21 swigDelegate21;

	private SwigDelegateOdGiGeometry_22 swigDelegate22;

	private SwigDelegateOdGiGeometry_23 swigDelegate23;

	private SwigDelegateOdGiGeometry_24 swigDelegate24;

	private SwigDelegateOdGiGeometry_25 swigDelegate25;

	private SwigDelegateOdGiGeometry_26 swigDelegate26;

	private SwigDelegateOdGiGeometry_27 swigDelegate27;

	private SwigDelegateOdGiGeometry_28 swigDelegate28;

	private SwigDelegateOdGiGeometry_29 swigDelegate29;

	private SwigDelegateOdGiGeometry_30 swigDelegate30;

	private SwigDelegateOdGiGeometry_31 swigDelegate31;

	private SwigDelegateOdGiGeometry_32 swigDelegate32;

	private SwigDelegateOdGiGeometry_33 swigDelegate33;

	private SwigDelegateOdGiGeometry_34 swigDelegate34;

	private SwigDelegateOdGiGeometry_35 swigDelegate35;

	private SwigDelegateOdGiGeometry_36 swigDelegate36;

	private SwigDelegateOdGiGeometry_37 swigDelegate37;

	private SwigDelegateOdGiGeometry_38 swigDelegate38;

	private SwigDelegateOdGiGeometry_39 swigDelegate39;

	private SwigDelegateOdGiGeometry_40 swigDelegate40;

	private SwigDelegateOdGiGeometry_41 swigDelegate41;

	private SwigDelegateOdGiGeometry_42 swigDelegate42;

	private SwigDelegateOdGiGeometry_43 swigDelegate43;

	private SwigDelegateOdGiGeometry_44 swigDelegate44;

	private SwigDelegateOdGiGeometry_45 swigDelegate45;

	private SwigDelegateOdGiGeometry_46 swigDelegate46;

	private SwigDelegateOdGiGeometry_47 swigDelegate47;

	private SwigDelegateOdGiGeometry_48 swigDelegate48;

	private SwigDelegateOdGiGeometry_49 swigDelegate49;

	private SwigDelegateOdGiGeometry_50 swigDelegate50;

	private SwigDelegateOdGiGeometry_51 swigDelegate51;

	private SwigDelegateOdGiGeometry_52 swigDelegate52;

	private SwigDelegateOdGiGeometry_53 swigDelegate53;

	private SwigDelegateOdGiGeometry_54 swigDelegate54;

	private SwigDelegateOdGiGeometry_55 swigDelegate55;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGiPositionTransformBehavior),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiPositionTransformBehavior),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiScaleTransformBehavior),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdGiScaleTransformBehavior),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGiOrientationTransformBehavior) };

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes15 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes16 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes17 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes19 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes24 = new Type[3]
	{
		typeof(OdGiPolyline),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdGiPolyline),
		typeof(uint)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGiPolyline) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes29 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(string)
	};

	private static Type[] swigMethodTypes30 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(string),
		typeof(bool),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes31 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdGeNurbCurve3d) };

	private static Type[] swigMethodTypes34 = new Type[3]
	{
		typeof(OdGeEllipArc3d),
		typeof(OdGePoint3d[]),
		typeof(OdGiArcType)
	};

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(OdGeEllipArc3d),
		typeof(OdGePoint3d[])
	};

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdGeEllipArc3d) };

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[5]
	{
		typeof(OdGiImageBGRA32),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage_TransparencyMode)
	};

	private static Type[] swigMethodTypes41 = new Type[4]
	{
		typeof(OdGiImageBGRA32),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdGeCurve2dArray) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes45 = new Type[6]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(IntPtr[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes46 = new Type[5]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(IntPtr[])
	};

	private static Type[] swigMethodTypes47 = new Type[4]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes48 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency)
	};

	private static Type[] swigMethodTypes49 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes51 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes53 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdGiPointCloud) };

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiBrep) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGeometry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGeometry obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiGeometry cast(OdRxObject pObj)
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_isASwigExplicitOdGiGeometry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_queryXSwigExplicitOdGiGeometry(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiGeometry createObject()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void pushModelTransform(OdGeVector3d normal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushModelTransform__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushModelTransform(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushModelTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popModelTransform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_popModelTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d pushPositionTransform(OdGiPositionTransformBehavior behavior, OdGePoint3d pos)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushPositionTransformSwigExplicitOdGiGeometry__SWIG_0(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(pos)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushPositionTransform__SWIG_0(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(pos)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushPositionTransform(OdGiPositionTransformBehavior behavior, OdGePoint2d pos)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushPositionTransformSwigExplicitOdGiGeometry__SWIG_1(swigCPtr, (int)behavior, OdGePoint2d.getCPtr(pos)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushPositionTransform__SWIG_1(swigCPtr, (int)behavior, OdGePoint2d.getCPtr(pos)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushScaleTransform(OdGiScaleTransformBehavior behavior, OdGePoint3d scale)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushScaleTransformSwigExplicitOdGiGeometry__SWIG_0(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(scale)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushScaleTransform__SWIG_0(swigCPtr, (int)behavior, OdGePoint3d.getCPtr(scale)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushScaleTransform(OdGiScaleTransformBehavior behavior, OdGePoint2d scale)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushScaleTransformSwigExplicitOdGiGeometry__SWIG_1(swigCPtr, (int)behavior, OdGePoint2d.getCPtr(scale)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushScaleTransform__SWIG_1(swigCPtr, (int)behavior, OdGePoint2d.getCPtr(scale)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d pushOrientationTransform(OdGiOrientationTransformBehavior behavior)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("pushOrientationTransform", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushOrientationTransformSwigExplicitOdGiGeometry(swigCPtr, (int)behavior) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushOrientationTransform(swigCPtr, (int)behavior), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void circle(OdGePoint3d center, double radius, OdGeVector3d normal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circle__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circle(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circle__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circularArc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circularArc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circularArc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_circularArc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal, IntPtr baseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyline__SWIG_0(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), baseSubEntMarker);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyline__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polyline(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyline__SWIG_2(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polygon(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polygon__SWIG_0(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polygon(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("polygon", swigMethodTypes23))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polygonSwigExplicitOdGiGeometry__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polygon__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pline(OdGiPolyline polyline, uint fromIndex, uint numSegs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pline__SWIG_0(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex, numSegs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pline(OdGiPolyline polyline, uint fromIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pline__SWIG_1(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pline(OdGiPolyline polyline)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pline__SWIG_2(swigCPtr, OdGiPolyline.getCPtr(polyline));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mesh(MeshData numRows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(numRows);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_mesh(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void shell(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_shell(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, string msg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_text__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, msg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, string msg, bool raw, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_text__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), msg, raw, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xline(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_xline(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ray(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_ray(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void nurbs(OdGeNurbCurve3d nurbsCurve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_nurbs(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void EllipArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides, OdGiArcType arcType)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_EllipArc(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipticArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_ellipticArc__SWIG_0(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipticArc(OdGeEllipArc3d ellipArc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_ellipticArc__SWIG_1(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void draw(OdGiDrawable pDrawable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_draw(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushClipBoundary__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popClipBoundary()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_popClipBoundary(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec, OdGiRasterImage_TransparencyMode trpMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_image__SWIG_0(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec), (int)trpMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_image__SWIG_1(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void edge(OdGeCurve2dArray edges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_edge(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiPathNode currentGiPath()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_currentGiPathSwigExplicitOdGiGeometry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_currentGiPath(swigCPtr));
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes44))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushClipBoundarySwigExplicitOdGiGeometry__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pushClipBoundary__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes45))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_0(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_0(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes46))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_1(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_1(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes47))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_2(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_2(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes48))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_3(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_3(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_4(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes49))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_5(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdGeVector3d.getCPtr(pNormals));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_5(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdGeVector3d.getCPtr(pNormals));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes50))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_6(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_6(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_7(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes51))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_8(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormals));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_8(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormals));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polypoint(OdGePoint3d[] numPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes52))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypointSwigExplicitOdGiGeometry__SWIG_9(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polypoint__SWIG_9(swigCPtr, intPtr);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors, OdCmTransparency pFillTransparencies)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyPolygon__SWIG_0(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors), OdCmTransparency.getCPtr(pFillTransparencies));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyPolygon__SWIG_1(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyPolygon__SWIG_2(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyPolygon__SWIG_3(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_polyPolygon__SWIG_4(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rowOfDots(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		if (SwigDerivedClassHasMethod("rowOfDots", swigMethodTypes53))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_rowOfDotsSwigExplicitOdGiGeometry(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_rowOfDots(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pointCloud(OdGiPointCloud pCloud)
	{
		if (SwigDerivedClassHasMethod("pointCloud", swigMethodTypes54))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pointCloudSwigExplicitOdGiGeometry(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_pointCloud(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool brep(OdGiBrep giBrep)
	{
		bool result = (SwigDerivedClassHasMethod("brep", swigMethodTypes55) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_brepSwigExplicitOdGiGeometry(swigCPtr, OdGiBrep.getCPtr(giBrep)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_brep(swigCPtr, OdGiBrep.getCPtr(giBrep)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void WorldLine(OdGePoint3d startPoint, OdGePoint3d endPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_WorldLine(swigCPtr, OdGePoint3d.getCPtr(startPoint), OdGePoint3d.getCPtr(endPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiGeometry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGeometry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiGeometry) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodpushModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodpushModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodpushPositionTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushPositionTransform", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodpushPositionTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodpushScaleTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushScaleTransform", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodpushScaleTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushOrientationTransform", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodpushOrientationTransform;
		}
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcircle__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circle", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodcircle__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodcircularArc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodcircularArc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodcircularArc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("circularArc", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcircularArc__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodpolyline__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodpolyline__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("polyline", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodpolyline__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("polygon", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodpolygon__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polygon", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodpolygon__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodpline__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodpline__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pline", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodpline__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("mesh", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodmesh;
		}
		if (SwigDerivedClassHasMethod("shell", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodshell;
		}
		if (SwigDerivedClassHasMethod("text", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodtext__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("text", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodtext__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodxline;
		}
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodray;
		}
		if (SwigDerivedClassHasMethod("nurbs", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodnurbs;
		}
		if (SwigDerivedClassHasMethod("EllipArc", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodEllipArc;
		}
		if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodellipticArc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("ellipticArc", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodellipticArc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("image", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodimage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("image", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodimage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("edge", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodedge;
		}
		if (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodcurrentGiPath;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodpolypoint__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodpolypoint__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodpolypoint__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodpolypoint__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodpolypoint__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodpolypoint__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodpolypoint__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("polypoint", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodpolypoint__SWIG_9;
		}
		if (SwigDerivedClassHasMethod("rowOfDots", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodrowOfDots;
		}
		if (SwigDerivedClassHasMethod("pointCloud", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodpointCloud;
		}
		if (SwigDerivedClassHasMethod("brep", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodbrep;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiGeometry));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetModelToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToWorldTransform()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodgetWorldToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToModelTransform()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodpushModelTransform__SWIG_0(IntPtr normal)
	{
		try
		{
			pushModelTransform(new OdGeVector3d(normal, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpushModelTransform__SWIG_1(IntPtr xfm)
	{
		try
		{
			pushModelTransform(new OdGeMatrix3d(xfm, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpopModelTransform()
	{
		try
		{
			popModelTransform();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodpushPositionTransform__SWIG_0(int behavior, IntPtr pos)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushPositionTransform((OdGiPositionTransformBehavior)behavior, new OdGePoint3d(pos, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodpushPositionTransform__SWIG_1(int behavior, IntPtr pos)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushPositionTransform((OdGiPositionTransformBehavior)behavior, new OdGePoint2d(pos, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodpushScaleTransform__SWIG_0(int behavior, IntPtr scale)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushScaleTransform((OdGiScaleTransformBehavior)behavior, new OdGePoint3d(scale, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodpushScaleTransform__SWIG_1(int behavior, IntPtr scale)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushScaleTransform((OdGiScaleTransformBehavior)behavior, new OdGePoint2d(scale, cMemoryOwn: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodpushOrientationTransform(int behavior)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(pushOrientationTransform((OdGiOrientationTransformBehavior)behavior)).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodcircle__SWIG_0(IntPtr center, double radius, IntPtr normal)
	{
		try
		{
			circle(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcircle__SWIG_1(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint)
	{
		try
		{
			circle(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcircularArc__SWIG_0(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType)
	{
		try
		{
			circularArc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(startVector, cMemoryOwn: false), sweepAngle, (OdGiArcType)arcType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcircularArc__SWIG_1(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle)
	{
		try
		{
			circularArc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(startVector, cMemoryOwn: false), sweepAngle);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcircularArc__SWIG_2(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType)
	{
		try
		{
			circularArc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false), (OdGiArcType)arcType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodcircularArc__SWIG_3(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint)
	{
		try
		{
			circularArc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolyline__SWIG_0(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), baseSubEntMarker);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolyline__SWIG_1(IntPtr numVertices, IntPtr pNormal)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolyline__SWIG_2(IntPtr numVertices)
	{
		try
		{
			polyline(Helpers.UnMarshalPoint3dArray(numVertices));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolygon__SWIG_0(IntPtr numVertices)
	{
		try
		{
			polygon(Helpers.UnMarshalPoint3dArray(numVertices));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolygon__SWIG_1(IntPtr numVertices, IntPtr pNormal)
	{
		try
		{
			polygon(Helpers.UnMarshalPoint3dArray(numVertices), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpline__SWIG_0(IntPtr polyline, uint fromIndex, uint numSegs)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false), fromIndex, numSegs);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpline__SWIG_1(IntPtr polyline, uint fromIndex)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false), fromIndex);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpline__SWIG_2(IntPtr polyline)
	{
		try
		{
			pline(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmesh(IntPtr numRows)
	{
		try
		{
			mesh(Helpers.UnMarshalMeshData(numRows));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodshell(IntPtr numVertices)
	{
		try
		{
			shell(Helpers.UnMarshalShellData(numVertices));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtext__SWIG_0(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg)
	{
		try
		{
			text(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), height, width, oblique, msg);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtext__SWIG_1(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle)
	{
		try
		{
			text(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodxline(IntPtr firstPoint, IntPtr secondPoint)
	{
		try
		{
			xline(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodray(IntPtr basePoint, IntPtr throughPoint)
	{
		try
		{
			ray(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGePoint3d(throughPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodnurbs(IntPtr nurbsCurve)
	{
		try
		{
			nurbs(new OdGeNurbCurve3d(nurbsCurve, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodEllipArc(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType)
	{
		try
		{
			EllipArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false), Helpers.UnMarshalPointPair(endPointsOverrides), (OdGiArcType)arcType);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodellipticArc__SWIG_0(IntPtr ellipArc, IntPtr endPointsOverrides)
	{
		try
		{
			ellipticArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false), Helpers.UnMarshalPointPair(endPointsOverrides));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodellipticArc__SWIG_1(IntPtr ellipArc)
	{
		try
		{
			ellipticArc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoddraw(IntPtr pDrawable)
	{
		try
		{
			draw(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpushClipBoundary__SWIG_0(IntPtr pBoundary)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpopClipBoundary()
	{
		try
		{
			popClipBoundary();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodimage__SWIG_0(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode)
	{
		try
		{
			image(new OdGiImageBGRA32(img, cMemoryOwn: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(uVec, cMemoryOwn: false), new OdGeVector3d(vVec, cMemoryOwn: false), (OdGiRasterImage_TransparencyMode)trpMode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodimage__SWIG_1(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec)
	{
		try
		{
			image(new OdGiImageBGRA32(img, cMemoryOwn: false), new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(uVec, cMemoryOwn: false), new OdGeVector3d(vVec, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodedge(IntPtr edges)
	{
		try
		{
			edge(new OdGeCurve2dArray(edges, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodcurrentGiPath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiPathNode.getCPtr(currentGiPath()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodpushClipBoundary__SWIG_1(IntPtr pBoundary, IntPtr pClipInfo)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false), (pClipInfo == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(pClipInfo, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_0(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_1(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pSubEntMarkers));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_2(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_3(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_5(IntPtr numPoints, IntPtr pColors, IntPtr pNormals)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_6(IntPtr numPoints, IntPtr pColors)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_8(IntPtr numPoints, IntPtr pNormals)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpolypoint__SWIG_9(IntPtr numPoints)
	{
		try
		{
			polypoint(Helpers.UnMarshalPoint3dArray(numPoints));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodrowOfDots(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint)
	{
		try
		{
			rowOfDots(numPoints, new OdGePoint3d(startPoint, cMemoryOwn: false), new OdGeVector3d(dirToNextPoint, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodpointCloud(IntPtr pCloud)
	{
		try
		{
			pointCloud(Helpers.GetRXObject<OdGiPointCloud>(pCloud, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodbrep(IntPtr giBrep)
	{
		return brep(Helpers.GetRXObject<OdGiBrep>(giBrep, bOwn: false, bTryAddToTransaction: false));
	}
}
