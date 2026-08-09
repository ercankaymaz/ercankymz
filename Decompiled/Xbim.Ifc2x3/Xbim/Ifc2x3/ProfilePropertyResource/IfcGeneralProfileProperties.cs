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

[ExpressType("IfcGeneralProfileProperties", 648)]
public class IfcGeneralProfileProperties : IfcProfileProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeneralProfileProperties>, IExpressValidatable
{
	public enum IfcGeneralProfilePropertiesClause
	{
		WR1
	}

	private IfcMassPerLengthMeasure? _physicalWeight;

	private IfcPositiveLengthMeasure? _perimeter;

	private IfcPositiveLengthMeasure? _minimumPlateThickness;

	private IfcPositiveLengthMeasure? _maximumPlateThickness;

	private IfcAreaMeasure? _crossSectionArea;

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcMassPerLengthMeasure? PhysicalWeight
	{
		get
		{
			if (_activated)
			{
				return _physicalWeight;
			}
			Activate();
			return _physicalWeight;
		}
		set
		{
			SetValue(delegate(IfcMassPerLengthMeasure? v)
			{
				_physicalWeight = v;
			}, _physicalWeight, value, "PhysicalWeight", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure? Perimeter
	{
		get
		{
			if (_activated)
			{
				return _perimeter;
			}
			Activate();
			return _perimeter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_perimeter = v;
			}, _perimeter, value, "Perimeter", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure? MinimumPlateThickness
	{
		get
		{
			if (_activated)
			{
				return _minimumPlateThickness;
			}
			Activate();
			return _minimumPlateThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_minimumPlateThickness = v;
			}, _minimumPlateThickness, value, "MinimumPlateThickness", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? MaximumPlateThickness
	{
		get
		{
			if (_activated)
			{
				return _maximumPlateThickness;
			}
			Activate();
			return _maximumPlateThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_maximumPlateThickness = v;
			}, _maximumPlateThickness, value, "MaximumPlateThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcAreaMeasure? CrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _crossSectionArea;
			}
			Activate();
			return _crossSectionArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_crossSectionArea = v;
			}, _crossSectionArea, value, "CrossSectionArea", 7);
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

	internal IfcGeneralProfileProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_physicalWeight = value.RealVal;
			break;
		case 3:
			_perimeter = value.RealVal;
			break;
		case 4:
			_minimumPlateThickness = value.RealVal;
			break;
		case 5:
			_maximumPlateThickness = value.RealVal;
			break;
		case 6:
			_crossSectionArea = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeneralProfileProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGeneralProfilePropertiesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcGeneralProfilePropertiesClause.WR1)
			{
				result = !Functions.EXISTS(CrossSectionArea) || (double?)CrossSectionArea > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGeneralProfileProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcGeneralProfileProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcGeneralProfilePropertiesClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeneralProfileProperties.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
