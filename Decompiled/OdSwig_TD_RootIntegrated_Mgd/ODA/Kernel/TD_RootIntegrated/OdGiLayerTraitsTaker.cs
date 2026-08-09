using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLayerTraitsTaker : OdGiLayerTraits_
{
	private object locker = new object();

	private HandleRef swigCPtr;

	private OdGiSubEntityTraits pSETraits;

	private OdGiSubEntityTraits pTraits1
	{
		get
		{
			if (pSETraits == null)
			{
				pSETraits = new OdGiSubEntityTraits_Internal(OdGiLayerTraitsTaker_OdGiSubEntityTraits_Upcast(swigCPtr.Handle), cMemoryOwn: false);
			}
			return pSETraits;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLayerTraitsTaker(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLayerTraitsTaker obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLayerTraitsTaker(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void setFillPlane(OdGeVector3d pNormal)
	{
		pTraits1.setFillPlane(pNormal);
	}

	public virtual bool fillPlane(OdGeVector3d normal)
	{
		return pTraits1.fillPlane(normal);
	}

	public virtual void addLight(OdDbStub lightId)
	{
		pTraits1.addLight(lightId);
	}

	public void setRefView(OdGiBaseVectorizer pRefView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setRefView(swigCPtr, OdGiBaseVectorizer.getCPtr(pRefView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset(OdGiLayerTraitsData ltData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_reset__SWIG_0(swigCPtr, OdGiLayerTraitsData.getCPtr(ltData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_reset__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual LineWeight lineweight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_lineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public new virtual OdDbStub linetype()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_linetype(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public new virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub materialId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_materialId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setColor__SWIG_0(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineweight(LineWeight lineweight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setLineweight(swigCPtr, (int)lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLinetype(OdDbStub pLinetypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setLinetype(swigCPtr, OdDbStub.getCPtr(pLinetypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub pPlotStyleNameId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setPlotStyleName__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setPlotStyleName__SWIG_1(swigCPtr, (int)plotStyleNameType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isOff()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_isOff(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOff(bool bVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setOff(swigCPtr, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPlottable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_isPlottable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPlottable(bool bVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setPlottable(swigCPtr, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLocked()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_isLocked(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLocked(bool bVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setLocked(swigCPtr, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_trueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public virtual LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_drawFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool selectionGeom()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_selectionGeom(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_shadowFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public virtual bool sectionable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_sectionable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_selectionFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}

	public virtual void setTrueColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColor(ushort color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setColor__SWIG_1(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineType(OdDbStub lineTypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setLineType(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineWeight(LineWeight lineWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setLineWeight(swigCPtr, (int)lineWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMaterial(OdDbStub pMaterialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setMaterial(swigCPtr, OdDbStub.getCPtr(pMaterialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor secondaryTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_secondaryTrueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDgLinetypeModifiers lineStyleModifiers()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_lineStyleModifiers(swigCPtr);
		OdGiDgLinetypeModifiers result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFill fill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_fill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public virtual bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isDragging()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_isDragging(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiContext context()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_context(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setContext(OdGiContext pContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setContext(swigCPtr, OdGiContext.getCPtr(pContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiViewport viewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_viewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint sequenceNumber()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_sequenceNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidId(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_isValidId(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_viewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiAuxiliaryData auxData()
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_auxData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setAuxData(OdGiAuxiliaryData pAuxData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_setAuxData(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static IntPtr OdGiLayerTraitsTaker_OdGiViewportDraw__Upcast(IntPtr ptr)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_OdGiLayerTraitsTaker_OdGiViewportDraw__Upcast(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static IntPtr OdGiLayerTraitsTaker_OdGiSubEntityTraits_Upcast(IntPtr ptr)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraitsTaker_OdGiLayerTraitsTaker_OdGiSubEntityTraits_Upcast(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
