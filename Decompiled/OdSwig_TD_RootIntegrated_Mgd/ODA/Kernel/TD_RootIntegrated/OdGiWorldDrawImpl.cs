using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWorldDrawImpl : OdGiWorldDraw_
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWorldDrawImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWorldDrawImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiWorldDrawImpl()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void setContext(OdGiContext pUserContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setContext(swigCPtr, OdGiContext.getCPtr(pUserContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiContext dummyGiContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_dummyGiContext(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_trueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public virtual LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_drawFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint lockFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_lockFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool selectionGeom()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_selectionGeom(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_shadowFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public virtual bool sectionable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_sectionable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_selectionFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}

	public virtual OdCmEntityColor secondaryTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_secondaryTrueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDgLinetypeModifiers lineStyleModifiers()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_lineStyleModifiers(swigCPtr);
		OdGiDgLinetypeModifiers result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFill fill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_fill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiAuxiliaryData auxData()
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_auxData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setTrueColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub pPlotStyleNameId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setPlotStyleName__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setPlotStyleName__SWIG_1(swigCPtr, (int)plotStyleNameType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColor(ushort color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setColor(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLayer(OdDbStub layerId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLayer(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineType(OdDbStub lineTypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLineType(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFillType(OdGiFillType fillType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setFillType(swigCPtr, (int)fillType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineWeight(LineWeight lineWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLineWeight(swigCPtr, (int)lineWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineTypeScale(double lineTypeScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLineTypeScale(swigCPtr, lineTypeScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setThickness(double thickness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setThickness(swigCPtr, thickness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionMarker(IntPtr selectionMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setSelectionMarker(swigCPtr, selectionMarker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaterial(OdDbStub pMaterialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setMaterial(swigCPtr, OdDbStub.getCPtr(pMaterialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setMapper(swigCPtr, OdGiMapper.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawFlags(uint drawFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setDrawFlags(swigCPtr, drawFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLockFlags(uint lockFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLockFlags(swigCPtr, lockFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionGeom(bool bSelectionFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setSelectionGeom(swigCPtr, bSelectionFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadowFlags(OdGiSubEntityTraits_ShadowFlags shadowFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setShadowFlags(swigCPtr, (int)shadowFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSectionable(bool bSectionableFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setSectionable(swigCPtr, bSectionableFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags selectionFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setSelectionFlags(swigCPtr, (int)selectionFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSecondaryTrueColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setSecondaryTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFill(OdGiFill pFill)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setFill(swigCPtr, OdGiFill.getCPtr(pFill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAuxData(OdGiAuxiliaryData pAuxData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_setAuxData(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new OdGiContext context()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_context(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDrawImpl_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
