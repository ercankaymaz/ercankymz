using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedComponentElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcVibrationIsolatorType", 137)]
public class IfcVibrationIsolatorType : IfcDiscreteAccessoryType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVibrationIsolatorType>, IIfcVibrationIsolatorType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcVibrationIsolatorTypeClause
	{
		WR1
	}

	private IfcVibrationIsolatorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcVibrationIsolatorTypeEnum PredefinedType
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
			SetValue(delegate(IfcVibrationIsolatorTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcVibrationIsolatorType), 10)]
	Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum IIfcVibrationIsolatorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcVibrationIsolatorTypeEnum.COMPRESSION => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION, 
				IfcVibrationIsolatorTypeEnum.SPRING => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING, 
				IfcVibrationIsolatorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED, 
				IfcVibrationIsolatorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION:
				PredefinedType = IfcVibrationIsolatorTypeEnum.COMPRESSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING:
				PredefinedType = IfcVibrationIsolatorTypeEnum.SPRING;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcVibrationIsolatorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcVibrationIsolatorTypeEnum)Enum.Parse(typeof(IfcVibrationIsolatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVibrationIsolatorType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcVibrationIsolatorTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcVibrationIsolatorTypeClause.WR1)
			{
				result = PredefinedType != IfcVibrationIsolatorTypeEnum.USERDEFINED || (PredefinedType == IfcVibrationIsolatorTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcVibrationIsolatorType>()?.LogError($"Exception thrown evaluating where-clause 'IfcVibrationIsolatorType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcVibrationIsolatorTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcVibrationIsolatorType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
