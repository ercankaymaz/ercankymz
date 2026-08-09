using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiEmptyGeometry : OdGiConveyorGeometry, IDisposable
{
	public delegate void SwigDelegateOdGiEmptyGeometry_0(IntPtr polyline, IntPtr xfm, uint fromIndex, uint numSegs);

	public delegate void SwigDelegateOdGiEmptyGeometry_1(IntPtr numPoints, IntPtr pNormal, IntPtr pExtrusion, IntPtr baseSubEntMarker);

	public delegate void SwigDelegateOdGiEmptyGeometry_2(IntPtr numPoints, IntPtr pNormal, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_3(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGiEmptyGeometry_4(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGiEmptyGeometry_5(IntPtr rows);

	public delegate void SwigDelegateOdGiEmptyGeometry_6(IntPtr numVertices);

	public delegate void SwigDelegateOdGiEmptyGeometry_7(IntPtr center, double radius, IntPtr normal, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_8(IntPtr center, double radius, IntPtr normal, IntPtr arg3, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_9(IntPtr center, double radius, IntPtr normal, IntPtr arg3);

	public delegate void SwigDelegateOdGiEmptyGeometry_10(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_11(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_12(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_13(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_14(IntPtr nurbsCurve);

	public delegate void SwigDelegateOdGiEmptyGeometry_15(IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_16(IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion, IntPtr arg8);

	public delegate void SwigDelegateOdGiEmptyGeometry_17(IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion);

	public delegate void SwigDelegateOdGiEmptyGeometry_18(IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle);

	public delegate void SwigDelegateOdGiEmptyGeometry_19(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade);

	public delegate void SwigDelegateOdGiEmptyGeometry_20(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned, bool allowClipping);

	public delegate void SwigDelegateOdGiEmptyGeometry_21(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned);

	public delegate void SwigDelegateOdGiEmptyGeometry_22(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile);

	public delegate void SwigDelegateOdGiEmptyGeometry_23(IntPtr basePoint, IntPtr direction);

	public delegate void SwigDelegateOdGiEmptyGeometry_24(IntPtr basePoint, IntPtr direction);

	public delegate void SwigDelegateOdGiEmptyGeometry_25(IntPtr arg0, bool arg1);

	public delegate void SwigDelegateOdGiEmptyGeometry_26(IntPtr arg0);

	public delegate int SwigDelegateOdGiEmptyGeometry_27();

	public delegate bool SwigDelegateOdGiEmptyGeometry_28(char arg0, bool arg1, IntPtr arg2, IntPtr arg3);

	public delegate void SwigDelegateOdGiEmptyGeometry_29(IntPtr arg0, uint arg1);

	public delegate void SwigDelegateOdGiEmptyGeometry_30(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions, IntPtr pSubEntMarkers, int nPointSize);

	public delegate void SwigDelegateOdGiEmptyGeometry_31(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions, IntPtr pSubEntMarkers);

	public delegate void SwigDelegateOdGiEmptyGeometry_32(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions);

	public delegate void SwigDelegateOdGiEmptyGeometry_33(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals);

	public delegate void SwigDelegateOdGiEmptyGeometry_34(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency);

	public delegate void SwigDelegateOdGiEmptyGeometry_35(IntPtr numPoints, IntPtr pColors);

	public delegate void SwigDelegateOdGiEmptyGeometry_36(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint);

	public delegate void SwigDelegateOdGiEmptyGeometry_37(IntPtr pCloud, IntPtr pFilter);

	public delegate void SwigDelegateOdGiEmptyGeometry_38(IntPtr pCloud);

	public delegate void SwigDelegateOdGiEmptyGeometry_39(IntPtr edges, IntPtr pXform);

	public delegate void SwigDelegateOdGiEmptyGeometry_40(IntPtr edges);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiEmptyGeometry_0 swigDelegate0;

	private SwigDelegateOdGiEmptyGeometry_1 swigDelegate1;

	private SwigDelegateOdGiEmptyGeometry_2 swigDelegate2;

	private SwigDelegateOdGiEmptyGeometry_3 swigDelegate3;

	private SwigDelegateOdGiEmptyGeometry_4 swigDelegate4;

	private SwigDelegateOdGiEmptyGeometry_5 swigDelegate5;

	private SwigDelegateOdGiEmptyGeometry_6 swigDelegate6;

	private SwigDelegateOdGiEmptyGeometry_7 swigDelegate7;

	private SwigDelegateOdGiEmptyGeometry_8 swigDelegate8;

	private SwigDelegateOdGiEmptyGeometry_9 swigDelegate9;

	private SwigDelegateOdGiEmptyGeometry_10 swigDelegate10;

	private SwigDelegateOdGiEmptyGeometry_11 swigDelegate11;

	private SwigDelegateOdGiEmptyGeometry_12 swigDelegate12;

	private SwigDelegateOdGiEmptyGeometry_13 swigDelegate13;

	private SwigDelegateOdGiEmptyGeometry_14 swigDelegate14;

	private SwigDelegateOdGiEmptyGeometry_15 swigDelegate15;

	private SwigDelegateOdGiEmptyGeometry_16 swigDelegate16;

	private SwigDelegateOdGiEmptyGeometry_17 swigDelegate17;

	private SwigDelegateOdGiEmptyGeometry_18 swigDelegate18;

	private SwigDelegateOdGiEmptyGeometry_19 swigDelegate19;

	private SwigDelegateOdGiEmptyGeometry_20 swigDelegate20;

	private SwigDelegateOdGiEmptyGeometry_21 swigDelegate21;

	private SwigDelegateOdGiEmptyGeometry_22 swigDelegate22;

	private SwigDelegateOdGiEmptyGeometry_23 swigDelegate23;

	private SwigDelegateOdGiEmptyGeometry_24 swigDelegate24;

	private SwigDelegateOdGiEmptyGeometry_25 swigDelegate25;

	private SwigDelegateOdGiEmptyGeometry_26 swigDelegate26;

	private SwigDelegateOdGiEmptyGeometry_27 swigDelegate27;

	private SwigDelegateOdGiEmptyGeometry_28 swigDelegate28;

	private SwigDelegateOdGiEmptyGeometry_29 swigDelegate29;

	private SwigDelegateOdGiEmptyGeometry_30 swigDelegate30;

	private SwigDelegateOdGiEmptyGeometry_31 swigDelegate31;

	private SwigDelegateOdGiEmptyGeometry_32 swigDelegate32;

	private SwigDelegateOdGiEmptyGeometry_33 swigDelegate33;

	private SwigDelegateOdGiEmptyGeometry_34 swigDelegate34;

	private SwigDelegateOdGiEmptyGeometry_35 swigDelegate35;

	private SwigDelegateOdGiEmptyGeometry_36 swigDelegate36;

	private SwigDelegateOdGiEmptyGeometry_37 swigDelegate37;

	private SwigDelegateOdGiEmptyGeometry_38 swigDelegate38;

	private SwigDelegateOdGiEmptyGeometry_39 swigDelegate39;

	private SwigDelegateOdGiEmptyGeometry_40 swigDelegate40;

	private static Type[] swigMethodTypes0 = new Type[4]
	{
		typeof(OdGiPolyline),
		typeof(OdGeMatrix3d),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes1 = new Type[4]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes2 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes10 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes11 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdGiArcType),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGiArcType),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes13 = new Type[4]
	{
		typeof(OdGeEllipArc3d),
		typeof(OdGePoint3d[]),
		typeof(OdGiArcType),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGeNurbCurve3d) };

	private static Type[] swigMethodTypes15 = new Type[7]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(string),
		typeof(bool),
		typeof(OdGiTextStyle),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes16 = new Type[8]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(string),
		typeof(bool),
		typeof(OdGiTextStyle),
		typeof(OdGeVector3d),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes17 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(int),
		typeof(OdGiTextStyle),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(int),
		typeof(OdGiTextStyle)
	};

	private static Type[] swigMethodTypes19 = new Type[9]
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

	private static Type[] swigMethodTypes20 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes21 = new Type[5]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile),
		typeof(bool)
	};

	private static Type[] swigMethodTypes22 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiMetafile)
	};

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[4]
	{
		typeof(char),
		typeof(bool),
		typeof(OdGePoint3d),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdGeBoundBlock3d),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes30 = new Type[7]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(IntPtr[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes31 = new Type[6]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(IntPtr[])
	};

	private static Type[] swigMethodTypes32 = new Type[5]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes33 = new Type[4]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes34 = new Type[3]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor),
		typeof(OdCmTransparency)
	};

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(OdGePoint3d[]),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes36 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdGiPointCloud),
		typeof(OdGiPointCloudFilter)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGiPointCloud) };

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(OdGeCurve2dArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGeCurve2dArray) };

	public static OdGiConveyorGeometry kVoid
	{
		get
		{
			OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_kVoid_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_kVoid_set(value.GetInterfaceCPtr());
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiEmptyGeometry(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiEmptyGeometry obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiEmptyGeometry()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiEmptyGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorGeometry.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_OdGiConveyorGeometry_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual void plineProc(OdGiPolyline polyline, OdGeMatrix3d xfm, uint fromIndex, uint numSegs)
	{
		if (SwigDerivedClassHasMethod("plineProc", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_plineProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGiPolyline.getCPtr(polyline), OdGeMatrix3d.getCPtr(xfm), fromIndex, numSegs);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_plineProc(swigCPtr, OdGiPolyline.getCPtr(polyline), OdGeMatrix3d.getCPtr(xfm), fromIndex, numSegs);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circleProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("circleProc", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circleProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("circleProc", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArcProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("circularArcProc", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circularArcProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circularArcProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circularArcProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("circularArcProc", swigMethodTypes12))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circularArcProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circularArcProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polylineProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion, IntPtr baseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polylineProc", swigMethodTypes1))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polylineProcSwigExplicitOdGiEmptyGeometry(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion), baseSubEntMarker);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polylineProc(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion), baseSubEntMarker);
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

	public virtual void polygonProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polygonProc", swigMethodTypes2))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polygonProcSwigExplicitOdGiEmptyGeometry(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polygonProc(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion));
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

	public virtual void meshProc(MeshData rows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(rows);
		try
		{
			if (SwigDerivedClassHasMethod("meshProc", swigMethodTypes5))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_meshProcSwigExplicitOdGiEmptyGeometry(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_meshProc(swigCPtr, intPtr);
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

	public virtual void shellProc(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			if (SwigDerivedClassHasMethod("shellProc", swigMethodTypes6))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shellProcSwigExplicitOdGiEmptyGeometry(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shellProc(swigCPtr, intPtr);
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

	public virtual void textProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("textProc", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_textProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_textProc(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("shapeProc", swigMethodTypes17))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shapeProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shapeProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle)
	{
		if (SwigDerivedClassHasMethod("shapeProc", swigMethodTypes18))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shapeProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_shapeProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xlineProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		if (SwigDerivedClassHasMethod("xlineProc", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_xlineProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_xlineProc(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayProc(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		if (SwigDerivedClassHasMethod("rayProc", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rayProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rayProc(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void nurbsProc(OdGeNurbCurve3d nurbsCurve)
	{
		if (SwigDerivedClassHasMethod("nurbsProc", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_nurbsProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_nurbsProc(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ellipArcProc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			if (SwigDerivedClassHasMethod("ellipArcProc", swigMethodTypes13))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ellipArcProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ellipArcProc(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
			}
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

	public virtual void rasterImageProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			if (SwigDerivedClassHasMethod("rasterImageProc", swigMethodTypes19))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rasterImageProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rasterImageProc(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
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

	public virtual void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned, bool allowClipping)
	{
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes20))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned, allowClipping);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned, allowClipping);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned)
	{
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile)
	{
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes22))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProcSwigExplicitOdGiEmptyGeometry__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_metafileProc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes30))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_0(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes31))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_1(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
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

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes32))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_2(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_2(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions));
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

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes33))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_3(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_3(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
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

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes34))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_4(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_4(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
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

	public virtual void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes35))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProcSwigExplicitOdGiEmptyGeometry__SWIG_5(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc__SWIG_5(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors));
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

	public virtual void rowOfDotsProc(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		if (SwigDerivedClassHasMethod("rowOfDotsProc", swigMethodTypes36))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rowOfDotsProcSwigExplicitOdGiEmptyGeometry(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rowOfDotsProc(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pointCloudProc(OdGiPointCloud pCloud, OdGiPointCloudFilter pFilter)
	{
		if (SwigDerivedClassHasMethod("pointCloudProc", swigMethodTypes37))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_pointCloudProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGiPointCloud.getCPtr(pCloud), OdGiPointCloudFilter.getCPtr(pFilter));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_pointCloudProc__SWIG_0(swigCPtr, OdGiPointCloud.getCPtr(pCloud), OdGiPointCloudFilter.getCPtr(pFilter));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pointCloudProc(OdGiPointCloud pCloud)
	{
		if (SwigDerivedClassHasMethod("pointCloudProc", swigMethodTypes38))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_pointCloudProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_pointCloudProc__SWIG_1(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void edgeProc(OdGeCurve2dArray edges, OdGeMatrix3d pXform)
	{
		if (SwigDerivedClassHasMethod("edgeProc", swigMethodTypes39))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_edgeProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGeCurve2dArray.getCPtr(edges), OdGeMatrix3d.getCPtr(pXform));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_edgeProc__SWIG_0(swigCPtr, OdGeCurve2dArray.getCPtr(edges), OdGeMatrix3d.getCPtr(pXform));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void edgeProc(OdGeCurve2dArray edges)
	{
		if (SwigDerivedClassHasMethod("edgeProc", swigMethodTypes40))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_edgeProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_edgeProc__SWIG_1(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void polylineProc(int arg0, OdGePoint3d arg1, OdGeVector3d arg2, OdGeVector3d arg3, int arg4)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polylineProc__SWIG_1(swigCPtr, arg0, OdGePoint3d.getCPtr(arg1), OdGeVector3d.getCPtr(arg2), OdGeVector3d.getCPtr(arg3), arg4);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d arg3, OdGeVector3d pExtrusion)
	{
		if (SwigDerivedClassHasMethod("circleProc2", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc2SwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(arg3), OdGeVector3d.getCPtr(pExtrusion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc2__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(arg3), OdGeVector3d.getCPtr(pExtrusion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d arg3)
	{
		if (SwigDerivedClassHasMethod("circleProc2", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc2SwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(arg3));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_circleProc2__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(arg3));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void textProc2(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion, OdGeExtents3d arg8)
	{
		if (SwigDerivedClassHasMethod("textProc2", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_textProc2SwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion), OdGeExtents3d.getCPtr(arg8));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_textProc2(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion), OdGeExtents3d.getCPtr(arg8));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void xlineProc2(OdGePoint3d basePoint, OdGeVector3d direction)
	{
		if (SwigDerivedClassHasMethod("xlineProc2", swigMethodTypes23))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_xlineProc2SwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_xlineProc2(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayProc2(OdGePoint3d basePoint, OdGeVector3d direction)
	{
		if (SwigDerivedClassHasMethod("rayProc2", swigMethodTypes24))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rayProc2SwigExplicitOdGiEmptyGeometry(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rayProc2(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExtentsProc(OdGePoint3d arg0, bool arg1)
	{
		if (SwigDerivedClassHasMethod("setExtentsProc", swigMethodTypes25))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_setExtentsProcSwigExplicitOdGiEmptyGeometry__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(arg0), arg1);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_setExtentsProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(arg0), arg1);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExtentsProc(OdGePoint3d arg0)
	{
		if (SwigDerivedClassHasMethod("setExtentsProc", swigMethodTypes26))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_setExtentsProcSwigExplicitOdGiEmptyGeometry__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_setExtentsProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int ttfCharProcFlags()
	{
		int result = (SwigDerivedClassHasMethod("ttfCharProcFlags", swigMethodTypes27) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfCharProcFlagsSwigExplicitOdGiEmptyGeometry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfCharProcFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool ttfCharProc(char arg0, bool arg1, OdGePoint3d arg2, OdGeBoundBlock3d arg3)
	{
		bool result = (SwigDerivedClassHasMethod("ttfCharProc", swigMethodTypes28) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfCharProcSwigExplicitOdGiEmptyGeometry(swigCPtr, arg0, arg1, OdGePoint3d.getCPtr(arg2), OdGeBoundBlock3d.getCPtr(arg3)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfCharProc(swigCPtr, arg0, arg1, OdGePoint3d.getCPtr(arg2), OdGeBoundBlock3d.getCPtr(arg3)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] arg2, OdGiFaceData pFaceData)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfPolyDrawProc__SWIG_0(swigCPtr, intPtr, intPtr2, Helpers.MarshalbyteFixedArray(arg2), OdGiFaceData.getCPtr(pFaceData));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}
	}

	public virtual void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] arg2)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_ttfPolyDrawProc__SWIG_1(swigCPtr, intPtr, intPtr2, Helpers.MarshalbyteFixedArray(arg2));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}
	}

	public virtual void conveyorBoundaryInfoProc(OdGeBoundBlock3d arg0, out uint arg1)
	{
		if (SwigDerivedClassHasMethod("conveyorBoundaryInfoProc", swigMethodTypes29))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_conveyorBoundaryInfoProcSwigExplicitOdGiEmptyGeometry(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0), out arg1);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_conveyorBoundaryInfoProc(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0), out arg1);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_0(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_1(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_2(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions));
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_3(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_4(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_5(swigCPtr, pContext.GetInterfaceCPtr(), intPtr, OdCmEntityColor.getCPtr(pColors));
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

	public void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polypointProc2__SWIG_6(swigCPtr, pContext.GetInterfaceCPtr(), intPtr);
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

	public void rowOfDotsProc2(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_rowOfDotsProc2(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors, OdCmTransparency pFillTransparencies)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polyPolygonProc2__SWIG_0(swigCPtr, pContext.GetInterfaceCPtr(), numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors), OdCmTransparency.getCPtr(pFillTransparencies));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polyPolygonProc2__SWIG_1(swigCPtr, pContext.GetInterfaceCPtr(), numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polyPolygonProc2__SWIG_2(swigCPtr, pContext.GetInterfaceCPtr(), numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polyPolygonProc2__SWIG_3(swigCPtr, pContext.GetInterfaceCPtr(), numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_polyPolygonProc2__SWIG_4(swigCPtr, pContext.GetInterfaceCPtr(), numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pointCloudProc2(OdGiConveyorContext pContext, OdGiPointCloud pCloud, OdGiPointCloudFilter pFilter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_pointCloudProc2(swigCPtr, pContext.GetInterfaceCPtr(), OdGiPointCloud.getCPtr(pCloud), OdGiPointCloudFilter.getCPtr(pFilter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiEmptyGeometry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiEmptyGeometry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiEmptyGeometry) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("plineProc", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodplineProc;
		}
		if (SwigDerivedClassHasMethod("polylineProc", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodpolylineProc;
		}
		if (SwigDerivedClassHasMethod("polygonProc", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodpolygonProc;
		}
		if (SwigDerivedClassHasMethod("xlineProc", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodxlineProc;
		}
		if (SwigDerivedClassHasMethod("rayProc", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodrayProc;
		}
		if (SwigDerivedClassHasMethod("meshProc", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodmeshProc;
		}
		if (SwigDerivedClassHasMethod("shellProc", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodshellProc;
		}
		if (SwigDerivedClassHasMethod("circleProc", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcircleProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circleProc2", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcircleProc2__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circleProc2", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcircleProc2__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circleProc", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcircleProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("circularArcProc", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcircularArcProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("circularArcProc", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcircularArcProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("ellipArcProc", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodellipArcProc;
		}
		if (SwigDerivedClassHasMethod("nurbsProc", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodnurbsProc;
		}
		if (SwigDerivedClassHasMethod("textProc", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodtextProc;
		}
		if (SwigDerivedClassHasMethod("textProc2", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodtextProc2;
		}
		if (SwigDerivedClassHasMethod("shapeProc", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodshapeProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("shapeProc", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodshapeProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("rasterImageProc", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodrasterImageProc;
		}
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodmetafileProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodmetafileProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("metafileProc", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodmetafileProc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("xlineProc2", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodxlineProc2;
		}
		if (SwigDerivedClassHasMethod("rayProc2", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodrayProc2;
		}
		if (SwigDerivedClassHasMethod("setExtentsProc", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetExtentsProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setExtentsProc", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetExtentsProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("ttfCharProcFlags", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodttfCharProcFlags;
		}
		if (SwigDerivedClassHasMethod("ttfCharProc", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodttfCharProc;
		}
		if (SwigDerivedClassHasMethod("conveyorBoundaryInfoProc", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodconveyorBoundaryInfoProc;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodpolypointProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodpolypointProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodpolypointProc__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodpolypointProc__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodpolypointProc__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("polypointProc", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodpolypointProc__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("rowOfDotsProc", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodrowOfDotsProc;
		}
		if (SwigDerivedClassHasMethod("pointCloudProc", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodpointCloudProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pointCloudProc", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodpointCloudProc__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("edgeProc", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodedgeProc__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("edgeProc", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodedgeProc__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEmptyGeometry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiEmptyGeometry));
	}

	private void SwigDirectorMethodplineProc(IntPtr polyline, IntPtr xfm, uint fromIndex, uint numSegs)
	{
		try
		{
			plineProc(Helpers.GetRXObject<OdGiPolyline>(polyline, bOwn: false, bTryAddToTransaction: false), (xfm == IntPtr.Zero) ? null : new OdGeMatrix3d(xfm, cMemoryOwn: false), fromIndex, numSegs);
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

	private void SwigDirectorMethodpolylineProc(IntPtr numPoints, IntPtr pNormal, IntPtr pExtrusion, IntPtr baseSubEntMarker)
	{
		try
		{
			polylineProc(Helpers.UnMarshalPoint3dArray(numPoints), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false), baseSubEntMarker);
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

	private void SwigDirectorMethodpolygonProc(IntPtr numPoints, IntPtr pNormal, IntPtr pExtrusion)
	{
		try
		{
			polygonProc(Helpers.UnMarshalPoint3dArray(numPoints), (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodxlineProc(IntPtr firstPoint, IntPtr secondPoint)
	{
		try
		{
			xlineProc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodrayProc(IntPtr basePoint, IntPtr throughPoint)
	{
		try
		{
			rayProc(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGePoint3d(throughPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodmeshProc(IntPtr rows)
	{
		try
		{
			meshProc(Helpers.UnMarshalMeshData(rows));
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

	private void SwigDirectorMethodshellProc(IntPtr numVertices)
	{
		try
		{
			shellProc(Helpers.UnMarshalShellData(numVertices));
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

	private void SwigDirectorMethodcircleProc__SWIG_0(IntPtr center, double radius, IntPtr normal, IntPtr pExtrusion)
	{
		try
		{
			circleProc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircleProc2__SWIG_0(IntPtr center, double radius, IntPtr normal, IntPtr arg3, IntPtr pExtrusion)
	{
		try
		{
			circleProc2(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(arg3, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircleProc2__SWIG_1(IntPtr center, double radius, IntPtr normal, IntPtr arg3)
	{
		try
		{
			circleProc2(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(arg3, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircleProc__SWIG_1(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, IntPtr pExtrusion)
	{
		try
		{
			circleProc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircularArcProc__SWIG_0(IntPtr center, double radius, IntPtr normal, IntPtr startVector, double sweepAngle, int arcType, IntPtr pExtrusion)
	{
		try
		{
			circularArcProc(new OdGePoint3d(center, cMemoryOwn: false), radius, new OdGeVector3d(normal, cMemoryOwn: false), new OdGeVector3d(startVector, cMemoryOwn: false), sweepAngle, (OdGiArcType)arcType, (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodcircularArcProc__SWIG_1(IntPtr firstPoint, IntPtr secondPoint, IntPtr thirdPoint, int arcType, IntPtr pExtrusion)
	{
		try
		{
			circularArcProc(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false), new OdGePoint3d(thirdPoint, cMemoryOwn: false), (OdGiArcType)arcType, (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodellipArcProc(IntPtr ellipArc, IntPtr endPointsOverrides, int arcType, IntPtr pExtrusion)
	{
		try
		{
			ellipArcProc(new OdGeEllipArc3d(ellipArc, cMemoryOwn: false), Helpers.UnMarshalPointPair(endPointsOverrides), (OdGiArcType)arcType, (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodnurbsProc(IntPtr nurbsCurve)
	{
		try
		{
			nurbsProc(new OdGeNurbCurve3d(nurbsCurve, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextProc(IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			textProc(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodtextProc2(IntPtr position, IntPtr direction, IntPtr upVector, [MarshalAs(UnmanagedType.LPWStr)] string msg, bool raw, IntPtr pTextStyle, IntPtr pExtrusion, IntPtr arg8)
	{
		try
		{
			textProc2(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), msg, raw, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false), (arg8 == IntPtr.Zero) ? null : new OdGeExtents3d(arg8, cMemoryOwn: false));
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

	private void SwigDirectorMethodshapeProc__SWIG_0(IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle, IntPtr pExtrusion)
	{
		try
		{
			shapeProc(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false), (pExtrusion == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusion, cMemoryOwn: false));
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

	private void SwigDirectorMethodshapeProc__SWIG_1(IntPtr position, IntPtr direction, IntPtr upVector, int shapeNumber, IntPtr pTextStyle)
	{
		try
		{
			shapeProc(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), shapeNumber, (pTextStyle == IntPtr.Zero) ? null : new OdGiTextStyle(pTextStyle, cMemoryOwn: false));
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

	private void SwigDirectorMethodrasterImageProc(IntPtr origin, IntPtr u, IntPtr v, IntPtr pImage, IntPtr uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		try
		{
			rasterImageProc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalPoint2dArray(uvBoundary), transparency, brightness, contrast, fade);
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

	private void SwigDirectorMethodmetafileProc__SWIG_0(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned, bool allowClipping)
	{
		try
		{
			metafileProc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), dcAligned, allowClipping);
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

	private void SwigDirectorMethodmetafileProc__SWIG_1(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile, bool dcAligned)
	{
		try
		{
			metafileProc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false), dcAligned);
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

	private void SwigDirectorMethodmetafileProc__SWIG_2(IntPtr origin, IntPtr u, IntPtr v, IntPtr pMetafile)
	{
		try
		{
			metafileProc(new OdGePoint3d(origin, cMemoryOwn: false), new OdGeVector3d(u, cMemoryOwn: false), new OdGeVector3d(v, cMemoryOwn: false), Helpers.GetRXObject<OdGiMetafile>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodxlineProc2(IntPtr basePoint, IntPtr direction)
	{
		try
		{
			xlineProc2(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false));
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

	private void SwigDirectorMethodrayProc2(IntPtr basePoint, IntPtr direction)
	{
		try
		{
			rayProc2(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetExtentsProc__SWIG_0(IntPtr arg0, bool arg1)
	{
		try
		{
			setExtentsProc((arg0 == IntPtr.Zero) ? null : new OdGePoint3d(arg0, cMemoryOwn: false), arg1);
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

	private void SwigDirectorMethodsetExtentsProc__SWIG_1(IntPtr arg0)
	{
		try
		{
			setExtentsProc((arg0 == IntPtr.Zero) ? null : new OdGePoint3d(arg0, cMemoryOwn: false));
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

	private int SwigDirectorMethodttfCharProcFlags()
	{
		return ttfCharProcFlags();
	}

	private bool SwigDirectorMethodttfCharProc(char arg0, bool arg1, IntPtr arg2, IntPtr arg3)
	{
		return ttfCharProc(arg0, arg1, new OdGePoint3d(arg2, cMemoryOwn: false), (arg3 == IntPtr.Zero) ? null : new OdGeBoundBlock3d(arg3, cMemoryOwn: false));
	}

	private void SwigDirectorMethodconveyorBoundaryInfoProc(IntPtr arg0, uint arg1)
	{
		try
		{
			conveyorBoundaryInfoProc(new OdGeBoundBlock3d(arg0, cMemoryOwn: false), out arg1);
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

	private void SwigDirectorMethodpolypointProc__SWIG_0(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions, IntPtr pSubEntMarkers, int nPointSize)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), (pExtrusions == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusions, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	private void SwigDirectorMethodpolypointProc__SWIG_1(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions, IntPtr pSubEntMarkers)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), (pExtrusions == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusions, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pSubEntMarkers));
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

	private void SwigDirectorMethodpolypointProc__SWIG_2(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals, IntPtr pExtrusions)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false), (pExtrusions == IntPtr.Zero) ? null : new OdGeVector3d(pExtrusions, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolypointProc__SWIG_3(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency, IntPtr pNormals)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false), (pNormals == IntPtr.Zero) ? null : new OdGeVector3d(pNormals, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolypointProc__SWIG_4(IntPtr numPoints, IntPtr pColors, IntPtr pTransparency)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false), (pTransparency == IntPtr.Zero) ? null : new OdCmTransparency(pTransparency, cMemoryOwn: false));
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

	private void SwigDirectorMethodpolypointProc__SWIG_5(IntPtr numPoints, IntPtr pColors)
	{
		try
		{
			polypointProc(Helpers.UnMarshalPoint3dArray(numPoints), (pColors == IntPtr.Zero) ? null : new OdCmEntityColor(pColors, cMemoryOwn: false));
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

	private void SwigDirectorMethodrowOfDotsProc(int numPoints, IntPtr startPoint, IntPtr dirToNextPoint)
	{
		try
		{
			rowOfDotsProc(numPoints, new OdGePoint3d(startPoint, cMemoryOwn: false), new OdGeVector3d(dirToNextPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodpointCloudProc__SWIG_0(IntPtr pCloud, IntPtr pFilter)
	{
		try
		{
			pointCloudProc(Helpers.GetRXObject<OdGiPointCloud>(pCloud, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiPointCloudFilter>(pFilter, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodpointCloudProc__SWIG_1(IntPtr pCloud)
	{
		try
		{
			pointCloudProc(Helpers.GetRXObject<OdGiPointCloud>(pCloud, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodedgeProc__SWIG_0(IntPtr edges, IntPtr pXform)
	{
		try
		{
			edgeProc(new OdGeCurve2dArray(edges, cMemoryOwn: false), (pXform == IntPtr.Zero) ? null : new OdGeMatrix3d(pXform, cMemoryOwn: false));
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

	private void SwigDirectorMethodedgeProc__SWIG_1(IntPtr edges)
	{
		try
		{
			edgeProc(new OdGeCurve2dArray(edges, cMemoryOwn: false));
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
