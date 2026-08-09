using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiClippedGeometryOutput : OdRxObject
{
	public class ClippedGeometryOutputInterface : IDisposable
	{
		public delegate IntPtr SwigDelegateClippedGeometryOutputInterface_0();

		public delegate IntPtr SwigDelegateClippedGeometryOutputInterface_1();

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateClippedGeometryOutputInterface_0 swigDelegate0;

		private SwigDelegateClippedGeometryOutputInterface_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[0];

		private static Type[] swigMethodTypes1 = new Type[0];

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ClippedGeometryOutputInterface(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ClippedGeometryOutputInterface obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ClippedGeometryOutputInterface()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiClippedGeometryOutput_ClippedGeometryOutputInterface(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual OdGiConveyorGeometry destinationGeometry()
		{
			OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ClippedGeometryOutputInterface_destinationGeometry(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual OdGiConveyorContext conveyorContext()
		{
			OdGiConveyorContext_Internal result = new OdGiConveyorContext_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ClippedGeometryOutputInterface_conveyorContext(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ClippedGeometryOutputInterface()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClippedGeometryOutput_ClippedGeometryOutputInterface(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(ClippedGeometryOutputInterface) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("destinationGeometry", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethoddestinationGeometry;
			}
			if (SwigDerivedClassHasMethod("conveyorContext", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorMethodconveyorContext;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ClippedGeometryOutputInterface_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(ClippedGeometryOutputInterface));
		}

		private IntPtr SwigDirectorMethoddestinationGeometry()
		{
			return destinationGeometry().GetInterfaceCPtr().Handle;
		}

		private IntPtr SwigDirectorMethodconveyorContext()
		{
			return conveyorContext().GetInterfaceCPtr().Handle;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiClippedGeometryOutput(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiClippedGeometryOutput obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiClippedGeometryOutput(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiConveyorGeometry destGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_destGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiConveyorContext drawContext()
	{
		OdGiConveyorContext_Internal result = new OdGiConveyorContext_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_drawContext(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void copyFrom(OdRxObject pSource)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ClippedGeometryOutputInterface getInterface()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_getInterface(swigCPtr);
		ClippedGeometryOutputInterface result = ((intPtr == IntPtr.Zero) ? null : new ClippedGeometryOutputInterface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInterface(ClippedGeometryOutputInterface pInterface)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setInterface(swigCPtr, ClippedGeometryOutputInterface.getCPtr(pInterface));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiClippedGeometryOutputCallback geometryProcessingCallback()
	{
		OdGiClippedGeometryOutputCallback rXObject = Helpers.GetRXObject<OdGiClippedGeometryOutputCallback>(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_geometryProcessingCallback(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setGeometryProcessingCallback(OdGiClippedGeometryOutputCallback pCallback)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setGeometryProcessingCallback(swigCPtr, OdGiClippedGeometryOutputCallback.getCPtr(pCallback));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isProcessingEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_isProcessingEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProcessingEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setProcessingEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNonSectionableGeometryClipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_isNonSectionableGeometryClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNonSectionableGeometryClipping(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setNonSectionableGeometryClipping(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTraitsOverrideFlags(uint nFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setTraitsOverrideFlags(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint traitsOverrideFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_traitsOverrideFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTraitsOverrides(OdGiSubEntityTraitsData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setTraitsOverrides(swigCPtr, OdGiSubEntityTraitsData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiSubEntityTraitsData traitsOverrides()
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_traitsOverrides__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setupDrawableProcessing()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setupDrawableProcessing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setupTraits(OdGiConveyorContext context)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_setupTraits(swigCPtr, context.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void releaseTraits(OdGiConveyorContext context)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_releaseTraits(swigCPtr, context.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void plineProc(OdGiPolyline polyline, OdGeMatrix3d pXfm, uint fromIndex, uint numSegs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_plineProc(swigCPtr, OdGiPolyline.getCPtr(polyline), OdGeMatrix3d.getCPtr(pXfm), fromIndex, numSegs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polylineProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion, IntPtr baseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polylineProc(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion), baseSubEntMarker);
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

	public void polygonProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polygonProc(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pExtrusion));
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

	public void xlineProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_xlineProc(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rayProc(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_rayProc(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void meshProc(MeshData numRows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(numRows);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_meshProc(swigCPtr, intPtr);
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

	public void shellProc(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_shellProc(swigCPtr, intPtr);
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

	public void circleProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circleProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circleProc2__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circleProc2__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circleProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circleProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArcProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circularArcProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArcProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_circularArcProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void ellipArcProc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointOverrides, OdGiArcType arcType, OdGeVector3d pExtrusion)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ellipArcProc(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType, OdGeVector3d.getCPtr(pExtrusion));
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

	public void nurbsProc(OdGeNurbCurve3d nurbsCurve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_nurbsProc(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void textProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_textProc(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void textProc2(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion, OdGeExtents3d extentsBox)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_textProc2(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), msg, raw, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion), OdGeExtents3d.getCPtr(extentsBox));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_shapeProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle), OdGeVector3d.getCPtr(pExtrusion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_shapeProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rasterImageProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast, double fade)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(uvBoundary);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_rasterImageProc(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiRasterImage.getCPtr(pImage), intPtr, transparency, brightness, contrast, fade);
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

	public void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned, bool allowClipping)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_metafileProc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned, allowClipping);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_metafileProc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile), dcAligned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_metafileProc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGiMetafile.getCPtr(pMetafile));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void xlineProc2(OdGePoint3d basePoint, OdGeVector3d direction)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_xlineProc2(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rayProc2(OdGePoint3d basePoint, OdGeVector3d direction)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_rayProc2(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(direction));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] pBezierTypes, OdGiFaceData pFaceData)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ttfPolyDrawProc__SWIG_0(swigCPtr, intPtr, intPtr2, Helpers.MarshalbyteFixedArray(pBezierTypes), OdGiFaceData.getCPtr(pFaceData));
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

	public void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] pBezierTypes)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_ttfPolyDrawProc__SWIG_1(swigCPtr, intPtr, intPtr2, Helpers.MarshalbyteFixedArray(pBezierTypes));
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_0(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_1(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers));
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_2(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), OdGeVector3d.getCPtr(pExtrusions));
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_3(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals));
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_4(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency));
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

	public void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_polypointProc__SWIG_5(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors));
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

	public void rowOfDotsProc(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_rowOfDotsProc(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pointCloudProc(OdGiPointCloud pCloud, OdGiPointCloudFilter pFilter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_pointCloudProc(swigCPtr, OdGiPointCloud.getCPtr(pCloud), OdGiPointCloudFilter.getCPtr(pFilter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void edgeProc(OdGeCurve2dArray edges, OdGeMatrix3d pXform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_edgeProc__SWIG_0(swigCPtr, OdGeCurve2dArray.getCPtr(edges), OdGeMatrix3d.getCPtr(pXform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void edgeProc(OdGeCurve2dArray edges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_edgeProc__SWIG_1(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutput_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
