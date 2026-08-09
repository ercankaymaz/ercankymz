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

[ExpressType("IfcDoor", 213)]
public class IfcDoor : IfcBuildingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcDoor, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDoor>, IExpressValidatable
{
	public enum IfcDoorClause
	{
		CorrectStyleAssigned
	}

	private IfcPositiveLengthMeasure? _overallHeight;

	private IfcPositiveLengthMeasure? _overallWidth;

	private IfcDoorTypeEnum? _predefinedType;

	private IfcDoorTypeOperationEnum? _operationType;

	private IfcLabel? _userDefinedOperationType;

	IfcPositiveLengthMeasure? IIfcDoor.OverallHeight
	{
		get
		{
			return OverallHeight;
		}
		set
		{
			OverallHeight = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcDoor.OverallWidth
	{
		get
		{
			return OverallWidth;
		}
		set
		{
			OverallWidth = value;
		}
	}

	IfcDoorTypeEnum? IIfcDoor.PredefinedType
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

	IfcDoorTypeOperationEnum? IIfcDoor.OperationType
	{
		get
		{
			return OperationType;
		}
		set
		{
			OperationType = value;
		}
	}

	IfcLabel? IIfcDoor.UserDefinedOperationType
	{
		get
		{
			return UserDefinedOperationType;
		}
		set
		{
			UserDefinedOperationType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 33)]
	public IfcPositiveLengthMeasure? OverallHeight
	{
		get
		{
			if (_activated)
			{
				return _overallHeight;
			}
			Activate();
			return _overallHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
	public IfcPositiveLengthMeasure? OverallWidth
	{
		get
		{
			if (_activated)
			{
				return _overallWidth;
			}
			Activate();
			return _overallWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcDoorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDoorTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcDoorTypeOperationEnum? OperationType
	{
		get
		{
			if (_activated)
			{
				return _operationType;
			}
			Activate();
			return _operationType;
		}
		set
		{
			SetValue(delegate(IfcDoorTypeOperationEnum? v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public IfcLabel? UserDefinedOperationType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedOperationType;
			}
			Activate();
			return _userDefinedOperationType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedOperationType = v;
			}, _userDefinedOperationType, value, "UserDefinedOperationType", 13);
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

	internal IfcDoor(IModel model, int label, bool activated)
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
			_overallHeight = value.RealVal;
			break;
		case 9:
			_overallWidth = value.RealVal;
			break;
		case 10:
			_predefinedType = (IfcDoorTypeEnum)Enum.Parse(typeof(IfcDoorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_operationType = (IfcDoorTypeOperationEnum)Enum.Parse(typeof(IfcDoorTypeOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 12:
			_userDefinedOperationType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoor other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDoorClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDoorClause.CorrectStyleAssigned)
			{
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCDOORTYPE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDoor>()?.LogError($"Exception thrown evaluating where-clause 'IfcDoor.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDoorClause.CorrectStyleAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoor.CorrectStyleAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
