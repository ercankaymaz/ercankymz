using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiBaseVectorizerImpl : OdGiBaseVectorizer
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiBaseVectorizerImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiBaseVectorizerImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiBaseVectorizerImpl()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void setUp(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setUp(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				view = null;
			}
			if (jarg != intPtr)
			{
				view = Helpers.GetRXObject<OdGsViewImpl>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGsViewImpl view()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_view(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint awareFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_awareFlags__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetAwareFlags()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_resetAwareFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPsPlotStyleData effectivePlotStyle()
	{
		OdPsPlotStyleData result = new OdPsPlotStyleData(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_effectivePlotStyle(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsView_RenderMode getRenderMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getRenderMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_RenderMode)result;
	}

	public void clearLinetypeCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_clearLinetypeCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLinetypesEnabled(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setLinetypesEnabled(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLinetypesEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_isLinetypesEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSkipViewSectioning(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setSkipViewSectioning(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isViewSectioningSkipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_isViewSectioningSkipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setModelSection(OdGiDrawable pSection, bool bUseSectionGeometryMap)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setModelSection(swigCPtr, OdGiDrawable.getCPtr(pSection), bUseSectionGeometryMap);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDrawable liveSection()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_liveSection(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeMatrix3d modelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_modelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d worldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_worldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d objectToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_objectToDeviceMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int lineweightToPixels(LineWeight lineweight)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_lineweightToPixels__SWIG_0(swigCPtr, (int)lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double lineweightToPixels(double lineweight)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_lineweightToPixels__SWIG_1(swigCPtr, lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasLineweightOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_hasLineweightOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasLinestyleOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_hasLinestyleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMultiplyLineStyleScale()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_isMultiplyLineStyleScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiLineweightOverride currentLineweightOverride()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_currentLineweightOverride(swigCPtr);
		OdGiLineweightOverride result = ((intPtr == IntPtr.Zero) ? null : new OdGiLineweightOverride(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint paletteColor(ushort colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_paletteColor__SWIG_0(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint paletteColor(short colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_paletteColor__SWIG_1(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint[] getPalette(int pNumColors)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getPalette__SWIG_0(swigCPtr, pNumColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public uint[] getPalette()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getPalette__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public bool hasPaletteOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_hasPaletteOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getModelToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getModelToEyeTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getEyeToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getEyeToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getWorldToEyeTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getEyeToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getEyeToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_isPerspective(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doPerspective(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_doPerspective(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doInversePerspective(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_doInversePerspective(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity, bool includePerspective)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getNumPixelsInUnitSquare__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity), includePerspective);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getNumPixelsInUnitSquare__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d getCameraLocation()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getCameraLocation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getCameraTarget()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getCameraTarget(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getCameraUpVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getCameraUpVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d viewDir()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_viewDir(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint viewportId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_viewportId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short acadWindowId()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_acadWindowId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getViewportDcCorners(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getViewportDcCorners(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getFrontAndBackClipValues(out bool clipFront, out bool clipBack, out double front, out double back)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_getFrontAndBackClipValues(swigCPtr, out clipFront, out clipBack, out front, out back);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double linetypeScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_linetypeScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double linetypeGenerationCriteria()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_linetypeGenerationCriteria(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool layerVisible(OdDbStub layerId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_layerVisible(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiContextualColors contextualColors()
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_contextualColors(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub annotationScaleId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_annotationScaleId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void pushModelTransform(OdGeVector3d normal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_pushModelTransform__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushModelTransform(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_pushModelTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popModelTransform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_popModelTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void xline(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_xline(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void ray(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_ray(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void shell(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_shell(swigCPtr, intPtr);
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

	public new virtual void mesh(MeshData numRows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(numRows);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_mesh(swigCPtr, intPtr);
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

	public new virtual void setExtents(OdGePoint3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setExtents(swigCPtr, OdGePoint3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public new virtual uint sequenceNumber()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_sequenceNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isValidId(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_isValidId(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_viewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setFillPlane(OdGeVector3d pNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setFillPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillPlane()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setFillPlane__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillType(OdGiFillType fillType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setFillType(swigCPtr, (int)fillType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint setupForEntity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setupForEntity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool pushLineweightOverride(OdGiLineweightOverride pOverride)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_pushLineweightOverride(swigCPtr, OdGiLineweightOverride.getCPtr(pOverride));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void popLineweightOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_popLineweightOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool pushPaletteOverride(OdGiPalette pOverride)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_pushPaletteOverride(swigCPtr, OdGiPalette.getCPtr(pOverride));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void popPaletteOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_popPaletteOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasPaletteOverrides()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_hasPaletteOverrides(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiViewport giViewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_giViewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGsView gsView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_gsView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual double annotationScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_annotationScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void beginViewVectorization()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_beginViewVectorization(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void endViewVectorization()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_endViewVectorization(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void onTraitsModified()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_onTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiSubEntityTraitsData effectiveTraits()
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_effectiveTraits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int vectorizingFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_vectorizingFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVectorizingFlags(int flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBaseVectorizerImpl_setVectorizingFlags(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
