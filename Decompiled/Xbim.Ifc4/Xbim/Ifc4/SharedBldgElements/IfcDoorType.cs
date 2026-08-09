using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcDoorType", 1152)]
public class IfcDoorType : IfcBuildingElementType, IInstantiableEntity, IPersistEntity, IPersist, IIfcDoorType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDoorType>, IExpressValidatable
{
	public enum IfcDoorTypeClause
	{
		CorrectPredefinedType
	}

	private IfcDoorTypeEnum _predefinedType;

	private IfcDoorTypeOperationEnum _operationType;

	private IfcBoolean? _parameterTakesPrecedence;

	private IfcLabel? _userDefinedOperationType;

	IfcDoorTypeEnum IIfcDoorType.PredefinedType
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

	IfcDoorTypeOperationEnum IIfcDoorType.OperationType
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

	IfcBoolean? IIfcDoorType.ParameterTakesPrecedence
	{
		get
		{
			return ParameterTakesPrecedence;
		}
		set
		{
			ParameterTakesPrecedence = value;
		}
	}

	IfcLabel? IIfcDoorType.UserDefinedOperationType
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDoorTypeEnum PredefinedType
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
			SetValue(delegate(IfcDoorTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcDoorTypeOperationEnum OperationType
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
			SetValue(delegate(IfcDoorTypeOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcBoolean? ParameterTakesPrecedence
	{
		get
		{
			if (_activated)
			{
				return _parameterTakesPrecedence;
			}
			Activate();
			return _parameterTakesPrecedence;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_parameterTakesPrecedence = v;
			}, _parameterTakesPrecedence, value, "ParameterTakesPrecedence", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcDoorType(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcDoorTypeEnum)Enum.Parse(typeof(IfcDoorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_operationType = (IfcDoorTypeOperationEnum)Enum.Parse(typeof(IfcDoorTypeOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_parameterTakesPrecedence = value.BooleanVal;
			break;
		case 12:
			_userDefinedOperationType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoorType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDoorTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDoorTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcDoorTypeEnum.USERDEFINED || (PredefinedType == IfcDoorTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDoorType>()?.LogError($"Exception thrown evaluating where-clause 'IfcDoorType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDoorTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
