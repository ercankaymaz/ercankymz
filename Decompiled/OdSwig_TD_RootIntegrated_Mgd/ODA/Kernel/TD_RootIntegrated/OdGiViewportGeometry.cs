using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewportGeometry : OdGiGeometry
{
	public delegate IntPtr SwigDelegateOdGiViewportGeometry_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_1();

	public delegate void SwigDelegateOdGiViewportGeometry_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_3();

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_4();

	public delegate void SwigDelegateOdGiViewportGeometry_5(IntPtr normal);

	public delegate void SwigDelegateOdGiViewportGeometry_6(IntPtr xfm);

	public delegate void SwigDelegateOdGiViewportGeometry_7();

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_8(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_9(int behavior, IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_10(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_11(int behavior, IntPtr scale);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_12(int behavior);

	public delegate void SwigDelegateOdGiViewportGeometry_13(IntPtr center, double radius, IntPtr normal);

	public delegate void SwigDelegateOdGiViewportGeometry_14(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiViewportGeometry_15(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType);

	public delegate void SwigDelegateOdGiViewportGeometry_16(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle);

	public delegate void SwigDelegateOdGiViewportGeometry_17(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType);

	public delegate void SwigDelegateOdGiViewportGeometry_18(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint);

	public delegate void SwigDelegateOdGiViewportGeometry_19(IntPtr numVertices, IntPtr pNormal, IntPtr baseSubEntMarker);

	public delegate void SwigDelegateOdGiViewportGeometry_20(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiViewportGeometry_21(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_22(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_23(IntPtr numVertices, IntPtr pNormal);

	public delegate void SwigDelegateOdGiViewportGeometry_24(IntPtr polyline, uint fromIndex, uint numSegs);

	public delegate void SwigDelegateOdGiViewportGeometry_25(IntPtr polyline, uint fromIndex);

	public delegate void SwigDelegateOdGiViewportGeometry_26(IntPtr polyline);

	public delegate void SwigDelegateOdGiViewportGeometry_27(IntPtr numRows);

	public delegate void SwigDelegateOdGiViewportGeometry_28(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_29(IntPtr position, IntPtr normal, IntPtr direction, double height, double width, double oblique, [MarshalAs(UnmanagedType.LPWStr)] string msg);

	public delegate void SwigDelegateOdGiViewportGeometry_30(IntPtr position, IntPtr normal, IntPtr direction, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiViewportGeometry_31(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGiViewportGeometry_32(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGiViewportGeometry_33(IntPtr nurbsCurve);

	public delegate void SwigDelegateOdGiViewportGeometry_34(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType);

	public delegate void SwigDelegateOdGiViewportGeometry_35(IntPtr ellipArc, IntPtr endPointsOverrides);

	public delegate void SwigDelegateOdGiViewportGeometry_36(IntPtr ellipArc);

	public delegate void SwigDelegateOdGiViewportGeometry_37(IntPtr pDrawable);

	public delegate void SwigDelegateOdGiViewportGeometry_38(IntPtr pBoundary);

	public delegate void SwigDelegateOdGiViewportGeometry_39();

	public delegate void SwigDelegateOdGiViewportGeometry_40(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec, int trpMode);

	public delegate void SwigDelegateOdGiViewportGeometry_41(IntPtr img, IntPtr origin, IntPtr uVec, IntPtr vVec);

	public delegate void SwigDelegateOdGiViewportGeometry_42(IntPtr edges);

	public delegate IntPtr SwigDelegateOdGiViewportGeometry_43();

	public delegate void SwigDelegateOdGiViewportGeometry_44(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGiViewportGeometry_45(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers, int nPointSize);

	public delegate void SwigDelegateOdGiViewportGeometry_46(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pSubEntMarkers);

	public delegate void SwigDelegateOdGiViewportGeometry_47(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals);

	public delegate void SwigDelegateOdGiViewportGeometry_48(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency);

	public delegate void SwigDelegateOdGiViewportGeometry_49(IntPtr numPoints, IntPtr pColors, IntPtr pNormals);

	public delegate void SwigDelegateOdGiViewportGeometry_50(IntPtr numPoints, IntPtr pColors);

	public delegate void SwigDelegateOdGiViewportGeometry_51(IntPtr numPoints, IntPtr pNormals);

	public delegate void SwigDelegateOdGiViewportGeometry_52(IntPtr numPoints);

	public delegate void SwigDelegateOdGiViewportGeometry_53(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint);

	public delegate void SwigDelegateOdGiViewportGeometry_54(IntPtr pCloud);

	public delegate bool SwigDelegateOdGiViewportGeometry_55(IntPtr giBrep);

	public delegate void SwigDelegateOdGiViewportGeometry_56(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_57(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_58(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_59(IntPtr numVertices);

	public delegate void SwigDelegateOdGiViewportGeometry_60(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade);

	public delegate void SwigDelegateOdGiViewportGeometry_61(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast);

	public delegate void SwigDelegateOdGiViewportGeometry_62(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness);

	public delegate void SwigDelegateOdGiViewportGeometry_63(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency);

	public delegate void SwigDelegateOdGiViewportGeometry_64(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary);

	public delegate void SwigDelegateOdGiViewportGeometry_65(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned, bool allowClipping);

	public delegate void SwigDelegateOdGiViewportGeometry_66(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned);

	public delegate void SwigDelegateOdGiViewportGeometry_67(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile);

	public delegate void SwigDelegateOdGiViewportGeometry_68(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable, bool dcAligned, bool allowClipping);

	public delegate void SwigDelegateOdGiViewportGeometry_69(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable, bool dcAligned);

	public delegate void SwigDelegateOdGiViewportGeometry_70(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiViewportGeometry_0 swigDelegate0;

	private SwigDelegateOdGiViewportGeometry_1 swigDelegate1;

	private SwigDelegateOdGiViewportGeometry_2 swigDelegate2;

	private SwigDelegateOdGiViewportGeometry_3 swigDelegate3;

	private SwigDelegateOdGiViewportGeometry_4 swigDelegate4;

	private SwigDelegateOdGiViewportGeometry_5 swigDelegate5;

	private SwigDelegateOdGiViewportGeometry_6 swigDelegate6;

	private SwigDelegateOdGiViewportGeometry_7 swigDelegate7;

	private SwigDelegateOdGiViewportGeometry_8 swigDelegate8;

	private SwigDelegateOdGiViewportGeometry_9 swigDelegate9;

	private SwigDelegateOdGiViewportGeometry_10 swigDelegate10;

	private SwigDelegateOdGiViewportGeometry_11 swigDelegate11;

	private SwigDelegateOdGiViewportGeometry_12 swigDelegate12;

	private SwigDelegateOdGiViewportGeometry_13 swigDelegate13;

	private SwigDelegateOdGiViewportGeometry_14 swigDelegate14;

	private SwigDelegateOdGiViewportGeometry_15 swigDelegate15;

	private SwigDelegateOdGiViewportGeometry_16 swigDelegate16;

	private SwigDelegateOdGiViewportGeometry_17 swigDelegate17;

	private SwigDelegateOdGiViewportGeometry_18 swigDelegate18;

	private SwigDelegateOdGiViewportGeometry_19 swigDelegate19;

	private SwigDelegateOdGiViewportGeometry_20 swigDelegate20;

	private SwigDelegateOdGiViewportGeometry_21 swigDelegate21;

	private SwigDelegateOdGiViewportGeometry_22 swigDelegate22;

	private SwigDelegateOdGiViewportGeometry_23 swigDelegate23;

	private SwigDelegateOdGiViewportGeometry_24 swigDelegate24;

	private SwigDelegateOdGiViewportGeometry_25 swigDelegate25;

	private SwigDelegateOdGiViewportGeometry_26 swigDelegate26;

	private SwigDelegateOdGiViewportGeometry_27 swigDelegate27;

	private SwigDelegateOdGiViewportGeometry_28 swigDelegate28;

	private SwigDelegateOdGiViewportGeometry_29 swigDelegate29;

	private SwigDelegateOdGiViewportGeometry_30 swigDelegate30;

	private SwigDelegateOdGiViewportGeometry_31 swigDelegate31;

	private SwigDelegateOdGiViewportGeometry_32 swigDelegate32;

	private SwigDelegateOdGiViewportGeometry_33 swigDelegate33;

	private SwigDelegateOdGiViewportGeometry_34 swigDelegate34;

	private SwigDelegateOdGiViewportGeometry_35 swigDelegate35;

	private SwigDelegateOdGiViewportGeometry_36 swigDelegate36;

	private SwigDelegateOdGiViewportGeometry_37 swigDelegate37;

	private SwigDelegateOdGiViewportGeometry_38 swigDelegate38;

	private SwigDelegateOdGiViewportGeometry_39 swigDelegate39;

	private SwigDelegateOdGiViewportGeometry_40 swigDelegate40;

	private SwigDelegateOdGiViewportGeometry_41 swigDelegate41;

	private SwigDelegateOdGiViewportGeometry_42 swigDelegate42;

	private SwigDelegateOdGiViewportGeometry_43 swigDelegate43;

	private SwigDelegateOdGiViewportGeometry_44 swigDelegate44;

	private SwigDelegateOdGiViewportGeometry_45 swigDelegate45;

	private SwigDelegateOdGiViewportGeometry_46 swigDelegate46;

	private SwigDelegateOdGiViewportGeometry_47 swigDelegate47;

	private SwigDelegateOdGiViewportGeometry_48 swigDelegate48;

	private SwigDelegateOdGiViewportGeometry_49 swigDelegate49;

	private SwigDelegateOdGiViewportGeometry_50 swigDelegate50;

	private SwigDelegateOdGiViewportGeometry_51 swigDelegate51;

	private SwigDelegateOdGiViewportGeometry_52 swigDelegate52;

	private SwigDelegateOdGiViewportGeometry_53 swigDelegate53;

	private SwigDelegateOdGiViewportGeometry_54 swigDelegate54;

	private SwigDelegateOdGiViewportGeometry_55 swigDelegate55;

	private SwigDelegateOdGiViewportGeometry_56 swigDelegate56;

	private SwigDelegateOdGiViewportGeometry_57 swigDelegate57;

	private SwigDelegateOdGiViewportGeometry_58 swigDelegate58;

	private SwigDelegateOdGiViewportGeometry_59 swigDelegate59;

	private SwigDelegateOdGiViewportGeometry_60 swigDelegate60;

	private SwigDelegateOdGiViewportGeometry_61 swigDelegate61;

	private SwigDelegateOdGiViewportGeometry_62 swigDelegate62;

	private SwigDelegateOdGiViewportGeometry_63 swigDelegate63;

	private SwigDelegateOdGiViewportGeometry_64 swigDelegate64;

	private SwigDelegateOdGiViewportGeometry_65 swigDelegate65;

	private SwigDelegateOdGiViewportGeometry_66 swigDelegate66;

	private SwigDelegateOdGiViewportGeometry_67 swigDelegate67;

	private SwigDelegateOdGiViewportGeometry_68 swigDelegate68;

	private SwigDelegateOdGiViewportGeometry_69 swigDelegate69;

	private SwigDelegateOdGiViewportGeometry_70 swigDelegate70;

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

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(OdGePoint3d[]) };

	private static Type[] swigMethodTypes60 = new Type[9]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes61 = new Type[8]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes62 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes63 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[]),
		typeof(bool)
	};

	private static Type[] swigMethodTypes64 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiRasterImage),
		typeof(OdGePoint2d[])
	};

	private static Type[] swigMethodTypes65 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes66 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool)
	};

	private static Type[] swigMethodTypes67 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile)
	};

	private static Type[] swigMethodTypes68 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiSelfGdiDrawable),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes69 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiSelfGdiDrawable),
		typeof(bool)
	};

	private static Type[] swigMethodTypes70 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiSelfGdiDrawable)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewportGeometry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewportGeometry obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewportGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiViewportGeometry cast(OdRxObject pObj)
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_isASwigExplicitOdGiViewportGeometry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_queryXSwigExplicitOdGiViewportGeometry(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiViewportGeometry createObject()
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void polylineEye(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_polylineEye(swigCPtr, intPtr);
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

	public virtual void polygonEye(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_polygonEye(swigCPtr, intPtr);
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

	public virtual void polylineDc(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_polylineDc(swigCPtr, intPtr);
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

	public virtual void polygonDc(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_polygonDc(swigCPtr, intPtr);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_rasterImageDc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_rasterImageDc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_rasterImageDc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_rasterImageDc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency);
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

	public virtual void rasterImageDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_rasterImageDc__SWIG_4(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr);
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

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned, bool allowClipping)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_metafileDc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned, allowClipping);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_metafileDc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_metafileDc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ownerDrawDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiSelfGdiDrawable pDrawable, bool dcAligned, bool allowClipping)
	{
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes68))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDcSwigExplicitOdGiViewportGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable), dcAligned, allowClipping);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable), dcAligned, allowClipping);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ownerDrawDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiSelfGdiDrawable pDrawable, bool dcAligned)
	{
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes69))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDcSwigExplicitOdGiViewportGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable), dcAligned);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable), dcAligned);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ownerDrawDc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiSelfGdiDrawable pDrawable)
	{
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes70))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDcSwigExplicitOdGiViewportGeometry__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_ownerDrawDc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiSelfGdiDrawable.getCPtr(pDrawable));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiViewportGeometry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewportGeometry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiViewportGeometry) != GetType();
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
		if (SwigDerivedClassHasMethod("polylineEye", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodpolylineEye;
		}
		if (SwigDerivedClassHasMethod("polygonEye", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodpolygonEye;
		}
		if (SwigDerivedClassHasMethod("polylineDc", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodpolylineDc;
		}
		if (SwigDerivedClassHasMethod("polygonDc", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodpolygonDc;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodrasterImageDc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodrasterImageDc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodrasterImageDc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodrasterImageDc__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("rasterImageDc", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodrasterImageDc__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodmetafileDc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodmetafileDc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("metafileDc", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodmetafileDc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodownerDrawDc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodownerDrawDc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("ownerDrawDc", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodownerDrawDc__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportGeometry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiViewportGeometry));
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

	private void SwigDirectorMethodpolylineEye(IntPtr numVertices)
	{
		try
		{
			polylineEye(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygonEye(IntPtr numVertices)
	{
		try
		{
			polygonEye(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolylineDc(IntPtr numVertices)
	{
		try
		{
			polylineDc(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodpolygonDc(IntPtr numVertices)
	{
		try
		{
			polygonDc(Helpers.UnMarshalPoint3dArray(numVertices));
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

	private void SwigDirectorMethodrasterImageDc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness, contrast, fade);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness, contrast);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_3(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency);
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

	private void SwigDirectorMethodrasterImageDc__SWIG_4(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary)
	{
		try
		{
			rasterImageDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary));
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

	private void SwigDirectorMethodmetafileDc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned, bool allowClipping)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), dcAligned, allowClipping);
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

	private void SwigDirectorMethodmetafileDc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), dcAligned);
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

	private void SwigDirectorMethodmetafileDc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile)
	{
		try
		{
			metafileDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodownerDrawDc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable, bool dcAligned, bool allowClipping)
	{
		try
		{
			ownerDrawDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiSelfGdiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), dcAligned, allowClipping);
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

	private void SwigDirectorMethodownerDrawDc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable, bool dcAligned)
	{
		try
		{
			ownerDrawDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiSelfGdiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), dcAligned);
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

	private void SwigDirectorMethodownerDrawDc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pDrawable)
	{
		try
		{
			ownerDrawDc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiSelfGdiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
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
