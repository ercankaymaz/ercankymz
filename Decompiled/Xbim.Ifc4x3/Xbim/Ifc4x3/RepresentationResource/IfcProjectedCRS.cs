using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcProjectedCRS", 1230)]
public class IfcProjectedCRS : IfcCoordinateReferenceSystem, IIfcProjectedCRS, IIfcCoordinateReferenceSystem, IPersistEntity, IPersist, Xbim.Ifc4.RepresentationResource.IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProjectedCRS>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _verticalDatum;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _mapProjection;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _mapZone;

	private Xbim.Ifc4x3.MeasureResource.IfcNamedUnit _mapUnit;

	[CrossSchemaAttribute(typeof(IIfcProjectedCRS), 5)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcProjectedCRS.MapProjection
	{
		get
		{
			if (!MapProjection.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(MapProjection.Value);
		}
		set
		{
			MapProjection = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProjectedCRS), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcProjectedCRS.MapZone
	{
		get
		{
			if (!MapZone.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(MapZone.Value);
		}
		set
		{
			MapZone = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProjectedCRS), 7)]
	IIfcNamedUnit IIfcProjectedCRS.MapUnit
	{
		get
		{
			return MapUnit;
		}
		set
		{
			MapUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? VerticalDatum
	{
		get
		{
			if (_activated)
			{
				return _verticalDatum;
			}
			Activate();
			return _verticalDatum;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_verticalDatum = v;
			}, _verticalDatum, value, "VerticalDatum", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? MapProjection
	{
		get
		{
			if (_activated)
			{
				return _mapProjection;
			}
			Activate();
			return _mapProjection;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_mapProjection = v;
			}, _mapProjection, value, "MapProjection", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? MapZone
	{
		get
		{
			if (_activated)
			{
				return _mapZone;
			}
			Activate();
			return _mapZone;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_mapZone = v;
			}, _mapZone, value, "MapZone", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcNamedUnit MapUnit
	{
		get
		{
			if (_activated)
			{
				return _mapUnit;
			}
			Activate();
			return _mapUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNamedUnit v)
			{
				_mapUnit = v;
			}, _mapUnit, value, "MapUnit", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (MapUnit != null)
			{
				yield return MapUnit;
			}
		}
	}

	internal IfcProjectedCRS(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_verticalDatum = value.StringVal;
			break;
		case 4:
			_mapProjection = value.StringVal;
			break;
		case 5:
			_mapZone = value.StringVal;
			break;
		case 6:
			_mapUnit = (Xbim.Ifc4x3.MeasureResource.IfcNamedUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProjectedCRS other)
	{
		return this == other;
	}
}
