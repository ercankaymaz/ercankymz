using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWorldGeometry : OdGiGeometry
{
	public delegate IntPtr SwigDelegateOdGiWorldGeometry_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_1();

	public delegate void SwigDelegateOdGiWorldGeometry_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_3();

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_4();

	public delegate void SwigDelegateOdGiWorldGeometry_5(IntPtr normal);

	public delegate void SwigDelegateOdGiWorldGeometry_6(IntPtr xfm);

	public delegate void SwigDelegateOdGiWorldGeometry_7();

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_8(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_9(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_10(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_11(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_12(int behavior);

	public delegate void SwigDelegateOdGiWorldGeometry_13(IntPtr center, double radius, IntPtr normal);

	public delegate void SwigDelegateOdGiWorldGeometry_14(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiWorldGeometry_15(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType);

	public delegate void SwigDelegateOdGiWorldGeometry_16(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle);

	public delegate void SwigDelegateOdGiWorldGeometry_17(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType);

	public delegate void SwigDelegateOdGiWorldGeometry_18(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiWorldGeometry_19(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker);

	public delegate void SwigDelegateOdGiWorldGeometry_20(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiWorldGeometry_21(IntPtr numVertices);

	public delegate void SwigDelegateOdGiWorldGeometry_22(IntPtr numVertices);

	public delegate void SwigDelegateOdGiWorldGeometry_23(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiWorldGeometry_24(IntPtr polyline, uint fromIndex, uint numSegs);

	public delegate void SwigDelegateOdGiWorldGeometry_25(IntPtr polyline, uint fromIndex);

	public delegate void SwigDelegateOdGiWorldGeometry_26(IntPtr polyline);

	public delegate void SwigDelegateOdGiWorldGeometry_27(IntPtr numRows);

	public delegate void SwigDelegateOdGiWorldGeometry_28(IntPtr numVertices);

	public delegate void SwigDelegateOdGiWorldGeometry_29(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiWorldGeometry_30(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiWorldGeometry_31(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGiWorldGeometry_32(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGiWorldGeometry_33(IntPtr nurbsCurve);

	public delegate void SwigDelegateOdGiWorldGeometry_34(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType);

	public delegate void SwigDelegateOdGiWorldGeometry_35(IntPtr ellipArc, IntPtr endPointsOverrides);

	public delegate void SwigDelegateOdGiWorldGeometry_36(IntPtr ellipArc);

	public delegate void SwigDelegateOdGiWorldGeometry_37(IntPtr pDrawable);

	public delegate void SwigDelegateOdGiWorldGeometry_38(IntPtr pBoundary);

	public delegate void SwigDelegateOdGiWorldGeometry_39();

	public delegate void SwigDelegateOdGiWorldGeometry_40(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode);

	public delegate void SwigDelegateOdGiWorldGeometry_41(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec);

	public delegate void SwigDelegateOdGiWorldGeometry_42(IntPtr edges);

	public delegate IntPtr SwigDelegateOdGiWorldGeometry_43();

	public delegate void SwigDelegateOdGiWorldGeometry_44(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGiWorldGeometry_45(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize);

	public delegate void SwigDelegateOdGiWorldGeometry_46(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers);

	public delegate void SwigDelegateOdGiWorldGeometry_47(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals);

	public delegate void SwigDelegateOdGiWorldGeometry_48(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency);

	public delegate void SwigDelegateOdGiWorldGeometry_49(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint);

	public delegate void SwigDelegateOdGiWorldGeometry_50(IntPtr pCloud);

	public delegate bool SwigDelegateOdGiWorldGeometry_51(IntPtr giBrep);

	public delegate void SwigDelegateOdGiWorldGeometry_52(IntPtr newExtents);

	public delegate void SwigDelegateOdGiWorldGeometry_53();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiWorldGeometry_0 swigDelegate0;

	private SwigDelegateOdGiWorldGeometry_1 swigDelegate1;

	private SwigDelegateOdGiWorldGeometry_2 swigDelegate2;

	private SwigDelegateOdGiWorldGeometry_3 swigDelegate3;

	private SwigDelegateOdGiWorldGeometry_4 swigDelegate4;

	private SwigDelegateOdGiWorldGeometry_5 swigDelegate5;

	private SwigDelegateOdGiWorldGeometry_6 swigDelegate6;

	private SwigDelegateOdGiWorldGeometry_7 swigDelegate7;

	private SwigDelegateOdGiWorldGeometry_8 swigDelegate8;

	private SwigDelegateOdGiWorldGeometry_9 swigDelegate9;

	private SwigDelegateOdGiWorldGeometry_10 swigDelegate10;

	private SwigDelegateOdGiWorldGeometry_11 swigDelegate11;

	private SwigDelegateOdGiWorldGeometry_12 swigDelegate12;

	private SwigDelegateOdGiWorldGeometry_13 swigDelegate13;

	private SwigDelegateOdGiWorldGeometry_14 swigDelegate14;

	private SwigDelegateOdGiWorldGeometry_15 swigDelegate15;

	private SwigDelegateOdGiWorldGeometry_16 swigDelegate16;

	private SwigDelegateOdGiWorldGeometry_17 swigDelegate17;

	private SwigDelegateOdGiWorldGeometry_18 swigDelegate18;

	private SwigDelegateOdGiWorldGeometry_19 swigDelegate19;

	private SwigDelegateOdGiWorldGeometry_20 swigDelegate20;

	private SwigDelegateOdGiWorldGeometry_21 swigDelegate21;

	private SwigDelegateOdGiWorldGeometry_22 swigDelegate22;

	private SwigDelegateOdGiWorldGeometry_23 swigDelegate23;

	private SwigDelegateOdGiWorldGeometry_24 swigDelegate24;

	private SwigDelegateOdGiWorldGeometry_25 swigDelegate25;

	private SwigDelegateOdGiWorldGeometry_26 swigDelegate26;

	private SwigDelegateOdGiWorldGeometry_27 swigDelegate27;

	private SwigDelegateOdGiWorldGeometry_28 swigDelegate28;

	private SwigDelegateOdGiWorldGeometry_29 swigDelegate29;

	private SwigDelegateOdGiWorldGeometry_30 swigDelegate30;

	private SwigDelegateOdGiWorldGeometry_31 swigDelegate31;

	private SwigDelegateOdGiWorldGeometry_32 swigDelegate32;

	private SwigDelegateOdGiWorldGeometry_33 swigDelegate33;

	private SwigDelegateOdGiWorldGeometry_34 swigDelegate34;

	private SwigDelegateOdGiWorldGeometry_35 swigDelegate35;

	private SwigDelegateOdGiWorldGeometry_36 swigDelegate36;

	private SwigDelegateOdGiWorldGeometry_37 swigDelegate37;

	private SwigDelegateOdGiWorldGeometry_38 swigDelegate38;

	private SwigDelegateOdGiWorldGeometry_39 swigDelegate39;

	private SwigDelegateOdGiWorldGeometry_40 swigDelegate40;

	private SwigDelegateOdGiWorldGeometry_41 swigDelegate41;

	private SwigDelegateOdGiWorldGeometry_42 swigDelegate42;

	private SwigDelegateOdGiWorldGeometry_43 swigDelegate43;

	private SwigDelegateOdGiWorldGeometry_44 swigDelegate44;

	private SwigDelegateOdGiWorldGeometry_45 swigDelegate45;

	private SwigDelegateOdGiWorldGeometry_46 swigDelegate46;

	private SwigDelegateOdGiWorldGeometry_47 swigDelegate47;

	private SwigDelegateOdGiWorldGeometry_48 swigDelegate48;

	private SwigDelegateOdGiWorldGeometry_49 swigDelegate49;

	private SwigDelegateOdGiWorldGeometry_50 swigDelegate50;

	private SwigDelegateOdGiWorldGeometry_51 swigDelegate51;

	private SwigDelegateOdGiWorldGeometry_52 swigDelegate52;

	private SwigDelegateOdGiWorldGeometry_53 swigDelegate53;

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
		typeof(int),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGiPointCloud) };

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdGiBrep) };

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes53 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWorldGeometry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWorldGeometry obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiWorldGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiWorldGeometry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiWorldGeometry(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGiWorldGeometry cast(OdRxObject pObj)
	{
		OdGiWorldGeometry rXObject = Helpers.GetRXObject<OdGiWorldGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_isASwigExplicitOdGiWorldGeometry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_queryXSwigExplicitOdGiWorldGeometry(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiWorldGeometry createObject()
	{
		OdGiWorldGeometry rXObject = Helpers.GetRXObject<OdGiWorldGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setExtents(OdGePoint3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_setExtents(swigCPtr, OdGePoint3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void startAttributesSegment()
	{
		if (SwigDerivedClassHasMethod("startAttributesSegment", swigMethodTypes53))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_startAttributesSegmentSwigExplicitOdGiWorldGeometry(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_startAttributesSegment(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("rowOfDots", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodrowOfDots;
		}
		if (SwigDerivedClassHasMethod("pointCloud", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodpointCloud;
		}
		if (SwigDerivedClassHasMethod("brep", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodbrep;
		}
		if (SwigDerivedClassHasMethod("setExtents", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetExtents;
		}
		if (SwigDerivedClassHasMethod("startAttributesSegment", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodstartAttributesSegment;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiWorldGeometry));
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

	private void SwigDirectorMethodsetExtents(IntPtr newExtents)
	{
		try
		{
			setExtents((newExtents == IntPtr.Zero) ? null : new OdGePoint3d(newExtents, cMemoryOwn: false));
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

	private void SwigDirectorMethodstartAttributesSegment()
	{
		try
		{
			startAttributesSegment();
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
}
