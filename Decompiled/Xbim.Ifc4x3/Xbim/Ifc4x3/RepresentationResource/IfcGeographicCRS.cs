using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcGeographicCRS", 1442)]
public class IfcGeographicCRS : IfcCoordinateReferenceSystem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeographicCRS>
{
	private IfcIdentifier? _primeMeridian;

	private IfcNamedUnit _angleUnit;

	private IfcNamedUnit _heightUnit;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcIdentifier? PrimeMeridian
	{
		get
		{
			if (_activated)
			{
				return _primeMeridian;
			}
			Activate();
			return _primeMeridian;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_primeMeridian = v;
			}, _primeMeridian, value, "PrimeMeridian", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcNamedUnit AngleUnit
	{
		get
		{
			if (_activated)
			{
				return _angleUnit;
			}
			Activate();
			return _angleUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcNamedUnit v)
			{
				_angleUnit = v;
			}, _angleUnit, value, "AngleUnit", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcNamedUnit HeightUnit
	{
		get
		{
			if (_activated)
			{
				return _heightUnit;
			}
			Activate();
			return _heightUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcNamedUnit v)
			{
				_heightUnit = v;
			}, _heightUnit, value, "HeightUnit", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (AngleUnit != null)
			{
				yield return AngleUnit;
			}
			if (HeightUnit != null)
			{
				yield return HeightUnit;
			}
		}
	}

	internal IfcGeographicCRS(IModel model, int label, bool activated)
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
			_primeMeridian = value.StringVal;
			break;
		case 4:
			_angleUnit = (IfcNamedUnit)value.EntityVal;
			break;
		case 5:
			_heightUnit = (IfcNamedUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeographicCRS other)
	{
		return this == other;
	}
}
