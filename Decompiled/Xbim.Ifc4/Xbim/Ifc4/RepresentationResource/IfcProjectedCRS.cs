using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcProjectedCRS", 1230)]
public class IfcProjectedCRS : IfcCoordinateReferenceSystem, IInstantiableEntity, IPersistEntity, IPersist, IIfcProjectedCRS, IIfcCoordinateReferenceSystem, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcProjectedCRS>, IExpressValidatable
{
	public enum IfcProjectedCRSClause
	{
		IsLengthUnit
	}

	private IfcIdentifier? _mapProjection;

	private IfcIdentifier? _mapZone;

	private IfcNamedUnit _mapUnit;

	IfcIdentifier? IIfcProjectedCRS.MapProjection
	{
		get
		{
			return MapProjection;
		}
		set
		{
			MapProjection = value;
		}
	}

	IfcIdentifier? IIfcProjectedCRS.MapZone
	{
		get
		{
			return MapZone;
		}
		set
		{
			MapZone = value;
		}
	}

	IIfcNamedUnit IIfcProjectedCRS.MapUnit
	{
		get
		{
			return MapUnit;
		}
		set
		{
			MapUnit = value as IfcNamedUnit;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcIdentifier? MapProjection
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_mapProjection = v;
			}, _mapProjection, value, "MapProjection", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcIdentifier? MapZone
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_mapZone = v;
			}, _mapZone, value, "MapZone", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcNamedUnit MapUnit
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
			SetValue(delegate(IfcNamedUnit v)
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
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_mapProjection = value.StringVal;
			break;
		case 5:
			_mapZone = value.StringVal;
			break;
		case 6:
			_mapUnit = (IfcNamedUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProjectedCRS other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcProjectedCRSClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcProjectedCRSClause.IsLengthUnit)
			{
				result = !Functions.EXISTS(MapUnit) || MapUnit.UnitType == IfcUnitEnum.LENGTHUNIT;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProjectedCRS>()?.LogError($"Exception thrown evaluating where-clause 'IfcProjectedCRS.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcProjectedCRSClause.IsLengthUnit))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProjectedCRS.IsLengthUnit",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
