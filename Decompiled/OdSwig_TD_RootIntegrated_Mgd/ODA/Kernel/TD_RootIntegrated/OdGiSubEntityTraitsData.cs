using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSubEntityTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const int kSelectionGeom = 256;

	public const int kSectionable = 512;

	public const int kInheritableSelFlags = 512;

	public const int kSelectionFlagsMask = 255;

	public const int kLayerOff = 1;

	public const int kLayerFrozen = 2;

	public const int kLayerNonPlottable = 4;

	public const int kGeomDisplayNormally = 1;

	public const int kGeomSelectNormally = 2;

	public const int kGeomDisplayHighlighted = 4;

	public const int kGeomSelectHighlighted = 8;

	public const int kGeomAllVisibilityFlags = 15;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSubEntityTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSubEntityTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiSubEntityTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSubEntityTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiSubEntityTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSubEntityTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort flags()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_flags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort selFlags()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_selFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort geomVisibilityFlags()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_geomVisibilityFlags__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort geomVisibilityFlags(bool bHighlighted)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_geomVisibilityFlags__SWIG_1(swigCPtr, bHighlighted);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLayerFrozen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_isLayerFrozen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLayerPlottable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_isLayerPlottable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLayerOff()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_isLayerOff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLayerVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_isLayerVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool visibility()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_visibility(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_trueColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_transparency(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint drawFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_drawFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint lockFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_lockFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool selectionGeom()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_selectionGeom(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_shadowFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public bool sectionable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_sectionable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_selectionFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}

	public OdCmEntityColor secondaryTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_secondaryTrueColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDgLinetypeModifiers lineStyleModifiers()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_lineStyleModifiers(swigCPtr);
		OdGiDgLinetypeModifiers result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFill fill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_fill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiAuxiliaryData auxData()
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_auxData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setFlags(ushort flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setFlags(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSelFlags(ushort selFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setSelFlags(swigCPtr, selFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTrueColor(OdCmEntityColor trueColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(trueColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(ushort colorIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setColor(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayer(OdDbStub layerId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLayer(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineType(OdDbStub lineTypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLineType(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillType(OdGiFillType fillType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setFillType(swigCPtr, (int)fillType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineWeight(LineWeight lineWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLineWeight(swigCPtr, (int)lineWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineTypeScale(double lineTypeScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLineTypeScale(swigCPtr, lineTypeScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setThickness(double thickness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setThickness(swigCPtr, thickness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub pPlotStyleNameId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setPlotStyleName(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMaterial(OdDbStub materialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setMaterial(swigCPtr, OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMapper(OdGiMapper pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setMapper(swigCPtr, OdGiMapper.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDrawFlags(uint drawFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setDrawFlags(swigCPtr, drawFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLockFlags(uint lockFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLockFlags(swigCPtr, lockFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSelectionGeom(bool bSelectionFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setSelectionGeom(swigCPtr, bSelectionFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShadowFlags(OdGiSubEntityTraits_ShadowFlags shadowFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setShadowFlags(swigCPtr, (int)shadowFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSectionable(bool bSectionableFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setSectionable(swigCPtr, bSectionableFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags selectionFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setSelectionFlags(swigCPtr, (int)selectionFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSecondaryTrueColor(OdCmEntityColor trueColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setSecondaryTrueColor(swigCPtr, OdCmEntityColor.getCPtr(trueColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFill(OdGiFill pFill)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setFill(swigCPtr, OdGiFill.getCPtr(pFill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAuxData(OdGiAuxiliaryData pAuxData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsData_setAuxData(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
