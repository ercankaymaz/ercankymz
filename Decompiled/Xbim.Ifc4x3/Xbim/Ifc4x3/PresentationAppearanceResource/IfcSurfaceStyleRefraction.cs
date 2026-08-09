using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleRefraction", 636)]
public class IfcSurfaceStyleRefraction : IfcPresentationItem, IIfcSurfaceStyleRefraction, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IInstantiableEntity, IfcSurfaceStyleElementSelect, IEquatable<IfcSurfaceStyleRefraction>
{
	private Xbim.Ifc4x3.MeasureResource.IfcReal? _refractionIndex;

	private Xbim.Ifc4x3.MeasureResource.IfcReal? _dispersionFactor;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRefraction), 1)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcSurfaceStyleRefraction.RefractionIndex
	{
		get
		{
			if (!RefractionIndex.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(RefractionIndex.Value);
		}
		set
		{
			RefractionIndex = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRefraction), 2)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcSurfaceStyleRefraction.DispersionFactor
	{
		get
		{
			if (!DispersionFactor.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(DispersionFactor.Value);
		}
		set
		{
			DispersionFactor = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? RefractionIndex
	{
		get
		{
			if (_activated)
			{
				return _refractionIndex;
			}
			Activate();
			return _refractionIndex;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_refractionIndex = v;
			}, _refractionIndex, value, "RefractionIndex", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? DispersionFactor
	{
		get
		{
			if (_activated)
			{
				return _dispersionFactor;
			}
			Activate();
			return _dispersionFactor;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_dispersionFactor = v;
			}, _dispersionFactor, value, "DispersionFactor", 2);
		}
	}

	internal IfcSurfaceStyleRefraction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_refractionIndex = value.RealVal;
			break;
		case 1:
			_dispersionFactor = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyleRefraction other)
	{
		return this == other;
	}
}
