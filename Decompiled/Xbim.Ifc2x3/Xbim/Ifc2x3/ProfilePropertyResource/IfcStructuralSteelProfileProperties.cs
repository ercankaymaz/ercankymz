using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcStructuralSteelProfileProperties", 692)]
public class IfcStructuralSteelProfileProperties : IfcStructuralProfileProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcStructuralSteelProfileProperties>, IExpressValidatable
{
	public enum IfcStructuralSteelProfilePropertiesClause
	{
		WR31,
		WR32
	}

	private IfcAreaMeasure? _shearAreaZ;

	private IfcAreaMeasure? _shearAreaY;

	private IfcPositiveRatioMeasure? _plasticShapeFactorY;

	private IfcPositiveRatioMeasure? _plasticShapeFactorZ;

	[EntityAttribute(24, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcAreaMeasure? ShearAreaZ
	{
		get
		{
			if (_activated)
			{
				return _shearAreaZ;
			}
			Activate();
			return _shearAreaZ;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_shearAreaZ = v;
			}, _shearAreaZ, value, "ShearAreaZ", 24);
		}
	}

	[EntityAttribute(25, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcAreaMeasure? ShearAreaY
	{
		get
		{
			if (_activated)
			{
				return _shearAreaY;
			}
			Activate();
			return _shearAreaY;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_shearAreaY = v;
			}, _shearAreaY, value, "ShearAreaY", 25);
		}
	}

	[EntityAttribute(26, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public IfcPositiveRatioMeasure? PlasticShapeFactorY
	{
		get
		{
			if (_activated)
			{
				return _plasticShapeFactorY;
			}
			Activate();
			return _plasticShapeFactorY;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_plasticShapeFactorY = v;
			}, _plasticShapeFactorY, value, "PlasticShapeFactorY", 26);
		}
	}

	[EntityAttribute(27, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public IfcPositiveRatioMeasure? PlasticShapeFactorZ
	{
		get
		{
			if (_activated)
			{
				return _plasticShapeFactorZ;
			}
			Activate();
			return _plasticShapeFactorZ;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_plasticShapeFactorZ = v;
			}, _plasticShapeFactorZ, value, "PlasticShapeFactorZ", 27);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ProfileDefinition != null)
			{
				yield return base.ProfileDefinition;
			}
		}
	}

	internal IfcStructuralSteelProfileProperties(IModel model, int label, bool activated)
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
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 23:
			_shearAreaZ = value.RealVal;
			break;
		case 24:
			_shearAreaY = value.RealVal;
			break;
		case 25:
			_plasticShapeFactorY = value.RealVal;
			break;
		case 26:
			_plasticShapeFactorZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSteelProfileProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralSteelProfilePropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralSteelProfilePropertiesClause.WR31:
				result = !Functions.EXISTS(ShearAreaY) || (double?)ShearAreaY >= 0.0;
				break;
			case IfcStructuralSteelProfilePropertiesClause.WR32:
				result = !Functions.EXISTS(ShearAreaZ) || (double?)ShearAreaZ >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralSteelProfileProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralSteelProfileProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralSteelProfilePropertiesClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSteelProfileProperties.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralSteelProfilePropertiesClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSteelProfileProperties.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
