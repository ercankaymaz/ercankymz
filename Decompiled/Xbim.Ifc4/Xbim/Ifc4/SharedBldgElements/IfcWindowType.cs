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

[ExpressType("IfcWindowType", 1317)]
public class IfcWindowType : IfcBuildingElementType, IInstantiableEntity, IPersistEntity, IPersist, IIfcWindowType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindowType>, IExpressValidatable
{
	public enum IfcWindowTypeClause
	{
		CorrectPredefinedType
	}

	private IfcWindowTypeEnum _predefinedType;

	private IfcWindowTypePartitioningEnum _partitioningType;

	private IfcBoolean? _parameterTakesPrecedence;

	private IfcLabel? _userDefinedPartitioningType;

	IfcWindowTypeEnum IIfcWindowType.PredefinedType
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

	IfcWindowTypePartitioningEnum IIfcWindowType.PartitioningType
	{
		get
		{
			return PartitioningType;
		}
		set
		{
			PartitioningType = value;
		}
	}

	IfcBoolean? IIfcWindowType.ParameterTakesPrecedence
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

	IfcLabel? IIfcWindowType.UserDefinedPartitioningType
	{
		get
		{
			return UserDefinedPartitioningType;
		}
		set
		{
			UserDefinedPartitioningType = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcWindowTypeEnum PredefinedType
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
			SetValue(delegate(IfcWindowTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcWindowTypePartitioningEnum PartitioningType
	{
		get
		{
			if (_activated)
			{
				return _partitioningType;
			}
			Activate();
			return _partitioningType;
		}
		set
		{
			SetValue(delegate(IfcWindowTypePartitioningEnum v)
			{
				_partitioningType = v;
			}, _partitioningType, value, "PartitioningType", 11);
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
	public IfcLabel? UserDefinedPartitioningType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedPartitioningType;
			}
			Activate();
			return _userDefinedPartitioningType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedPartitioningType = v;
			}, _userDefinedPartitioningType, value, "UserDefinedPartitioningType", 13);
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

	internal IfcWindowType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWindowTypeEnum)Enum.Parse(typeof(IfcWindowTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_partitioningType = (IfcWindowTypePartitioningEnum)Enum.Parse(typeof(IfcWindowTypePartitioningEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_parameterTakesPrecedence = value.BooleanVal;
			break;
		case 12:
			_userDefinedPartitioningType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindowType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWindowTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWindowTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcWindowTypeEnum.USERDEFINED || (PredefinedType == IfcWindowTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWindowType>()?.LogError($"Exception thrown evaluating where-clause 'IfcWindowType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWindowTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindowType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
