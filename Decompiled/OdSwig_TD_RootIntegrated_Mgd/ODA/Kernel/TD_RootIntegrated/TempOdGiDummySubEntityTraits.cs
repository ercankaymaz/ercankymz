using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TempOdGiDummySubEntityTraits : OdGiSubEntityTraits
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TempOdGiDummySubEntityTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TempOdGiDummySubEntityTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TempOdGiDummySubEntityTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual void setColor(ushort arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setColor(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTrueColor(OdCmEntityColor arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLayer(OdDbStub arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setLayer(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineType(OdDbStub arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setLineType(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionMarker(IntPtr arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setSelectionMarker(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillType(OdGiFillType arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setFillType(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillPlane(OdGeVector3d arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setFillPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setFillPlane()
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setFillPlane__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineWeight(LineWeight arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setLineWeight(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineTypeScale(double arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setLineTypeScale__SWIG_0(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setLineTypeScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setLineTypeScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setThickness(double arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setThickness(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setPlotStyleName(PlotStyleNameType arg0, OdDbStub arg1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setPlotStyleName__SWIG_0(swigCPtr, (int)arg0, OdDbStub.getCPtr(arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setPlotStyleName(PlotStyleNameType arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setPlotStyleName__SWIG_1(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMaterial(OdDbStub arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setMaterial(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMapper(OdGiMapper arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setMapper(swigCPtr, OdGiMapper.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setVisualStyle(OdDbStub arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setVisualStyle(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTransparency(OdCmTransparency arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setTransparency(swigCPtr, OdCmTransparency.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDrawFlags(uint arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setDrawFlags(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionGeom(bool arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setSelectionGeom(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setShadowFlags(OdGiSubEntityTraits_ShadowFlags arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setShadowFlags(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSectionable(bool arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setSectionable(swigCPtr, arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_setSelectionFlags(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_trueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public new virtual bool fillPlane(OdGeVector3d arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_fillPlane(swigCPtr, OdGeVector3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public new virtual double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public new virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void addLight(OdDbStub arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_addLight(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint drawFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_drawFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool selectionGeom()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_selectionGeom(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_shadowFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public new virtual bool sectionable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_sectionable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiDummySubEntityTraits_selectionFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}
}
