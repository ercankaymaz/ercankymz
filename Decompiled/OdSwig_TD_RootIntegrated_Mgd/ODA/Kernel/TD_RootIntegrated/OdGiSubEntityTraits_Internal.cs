using System;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSubEntityTraits_Internal : OdGiSubEntityTraits
{
	public OdGiSubEntityTraits_Internal(IntPtr cPtr, bool cMemoryOwn)
		: base(cPtr, cMemoryOwn)
	{
	}

	public override void setColor(ushort color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setColor(OdGiSubEntityTraits.getCPtr(this), color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setLayer(OdDbStub layerId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLayer(OdGiSubEntityTraits.getCPtr(this), OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setTrueColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setTrueColor(OdGiSubEntityTraits.getCPtr(this), OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setLineType(OdDbStub lineTypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineType(OdGiSubEntityTraits.getCPtr(this), OdDbStub.getCPtr(lineTypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setSelectionMarker(IntPtr selectionMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionMarker(OdGiSubEntityTraits.getCPtr(this), selectionMarker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setFillType(OdGiFillType fillType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillType(OdGiSubEntityTraits.getCPtr(this), (int)fillType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setLineWeight(LineWeight lineWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineWeight(OdGiSubEntityTraits.getCPtr(this), (int)lineWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setThickness(double thickness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setThickness(OdGiSubEntityTraits.getCPtr(this), thickness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setMaterial(OdDbStub materialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setMaterial(OdGiSubEntityTraits.getCPtr(this), OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setMapper(OdGiMapper pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setMapper(OdGiSubEntityTraits.getCPtr(this), OdGiMapper.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_color(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_trueColor(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub layer()
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_layer(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub lineType()
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineType(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fillType(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public override LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineWeight(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public override double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineTypeScale(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_thickness(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_plotStyleNameType(OdGiSubEntityTraits.getCPtr(this));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public override OdDbStub plotStyleNameId()
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_plotStyleNameId(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub material()
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_material(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiMapper mapper()
	{
		OdGiMapper result = new OdGiMapper(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_mapper(OdGiSubEntityTraits.getCPtr(this)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
