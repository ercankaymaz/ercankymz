using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcUnitaryEquipmentType", 234)]
public class IfcUnitaryEquipmentType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcUnitaryEquipmentType>, IIfcUnitaryEquipmentType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcUnitaryEquipmentTypeClause
	{
		WR1
	}

	private IfcUnitaryEquipmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcUnitaryEquipmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcUnitaryEquipmentTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcUnitaryEquipmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum IIfcUnitaryEquipmentType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcUnitaryEquipmentTypeEnum.AIRHANDLER:
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRHANDLER;
			case IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT:
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT;
			case IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM:
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM;
			case IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT:
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT;
			case IfcUnitaryEquipmentTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.USERDEFINED;
			}
			case IfcUnitaryEquipmentTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRHANDLER:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.AIRHANDLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.DEHUMIDIFIER:
				base.ElementType = value.ToString();
				PredefinedType = IfcUnitaryEquipmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.USERDEFINED:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcUnitaryEquipmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcUnitaryEquipmentTypeEnum)Enum.Parse(typeof(IfcUnitaryEquipmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcUnitaryEquipmentType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcUnitaryEquipmentTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcUnitaryEquipmentTypeClause.WR1)
			{
				result = PredefinedType != IfcUnitaryEquipmentTypeEnum.USERDEFINED || (PredefinedType == IfcUnitaryEquipmentTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcUnitaryEquipmentType>()?.LogError($"Exception thrown evaluating where-clause 'IfcUnitaryEquipmentType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcUnitaryEquipmentTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcUnitaryEquipmentType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
