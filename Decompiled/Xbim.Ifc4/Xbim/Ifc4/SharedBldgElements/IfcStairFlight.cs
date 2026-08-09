using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcStairFlight", 25)]
public class IfcStairFlight : IfcBuildingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcStairFlight, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStairFlight>, IExpressValidatable
{
	public enum IfcStairFlightClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcInteger? _numberOfRisers;

	private IfcInteger? _numberOfTreads;

	private IfcPositiveLengthMeasure? _riserHeight;

	private IfcPositiveLengthMeasure? _treadLength;

	private IfcStairFlightTypeEnum? _predefinedType;

	IfcInteger? IIfcStairFlight.NumberOfRisers
	{
		get
		{
			return NumberOfRisers;
		}
		set
		{
			NumberOfRisers = value;
		}
	}

	IfcInteger? IIfcStairFlight.NumberOfTreads
	{
		get
		{
			return NumberOfTreads;
		}
		set
		{
			NumberOfTreads = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcStairFlight.RiserHeight
	{
		get
		{
			return RiserHeight;
		}
		set
		{
			RiserHeight = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcStairFlight.TreadLength
	{
		get
		{
			return TreadLength;
		}
		set
		{
			TreadLength = value;
		}
	}

	IfcStairFlightTypeEnum? IIfcStairFlight.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 33)]
	public IfcInteger? NumberOfRisers
	{
		get
		{
			if (_activated)
			{
				return _numberOfRisers;
			}
			Activate();
			return _numberOfRisers;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_numberOfRisers = v;
			}, _numberOfRisers, value, "NumberOfRisers", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
	public IfcInteger? NumberOfTreads
	{
		get
		{
			if (_activated)
			{
				return _numberOfTreads;
			}
			Activate();
			return _numberOfTreads;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_numberOfTreads = v;
			}, _numberOfTreads, value, "NumberOfTreads", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
	public IfcPositiveLengthMeasure? RiserHeight
	{
		get
		{
			if (_activated)
			{
				return _riserHeight;
			}
			Activate();
			return _riserHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_riserHeight = v;
			}, _riserHeight, value, "RiserHeight", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public IfcPositiveLengthMeasure? TreadLength
	{
		get
		{
			if (_activated)
			{
				return _treadLength;
			}
			Activate();
			return _treadLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_treadLength = v;
			}, _treadLength, value, "TreadLength", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcStairFlightTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcStairFlightTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 13);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcStairFlight(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_numberOfRisers = value.IntegerVal;
			break;
		case 9:
			_numberOfTreads = value.IntegerVal;
			break;
		case 10:
			_riserHeight = value.RealVal;
			break;
		case 11:
			_treadLength = value.RealVal;
			break;
		case 12:
			_predefinedType = (IfcStairFlightTypeEnum)Enum.Parse(typeof(IfcStairFlightTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStairFlight other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStairFlightClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStairFlightClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcStairFlightTypeEnum.USERDEFINED || (PredefinedType == IfcStairFlightTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcStairFlightClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCSTAIRFLIGHTTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStairFlight>()?.LogError($"Exception thrown evaluating where-clause 'IfcStairFlight.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStairFlightClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStairFlight.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStairFlightClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStairFlight.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
