using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleRefraction", 636)]
public class IfcSurfaceStyleRefraction : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceStyleRefraction, IIfcPresentationItem, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IEquatable<IfcSurfaceStyleRefraction>
{
	private IfcReal? _refractionIndex;

	private IfcReal? _dispersionFactor;

	IfcReal? IIfcSurfaceStyleRefraction.RefractionIndex
	{
		get
		{
			return RefractionIndex;
		}
		set
		{
			RefractionIndex = value;
		}
	}

	IfcReal? IIfcSurfaceStyleRefraction.DispersionFactor
	{
		get
		{
			return DispersionFactor;
		}
		set
		{
			DispersionFactor = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcReal? RefractionIndex
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
			SetValue(delegate(IfcReal? v)
			{
				_refractionIndex = v;
			}, _refractionIndex, value, "RefractionIndex", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcReal? DispersionFactor
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
			SetValue(delegate(IfcReal? v)
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
