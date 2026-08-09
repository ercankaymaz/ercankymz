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

[ExpressType("IfcCoolingTowerType", 478)]
public class IfcCoolingTowerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoolingTowerType>, IIfcCoolingTowerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcCoolingTowerTypeClause
	{
		WR1
	}

	private IfcCoolingTowerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCoolingTowerTypeEnum PredefinedType
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
			SetValue(delegate(IfcCoolingTowerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCoolingTowerType), 10)]
	Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum IIfcCoolingTowerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoolingTowerTypeEnum.NATURALDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NATURALDRAFT, 
				IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT, 
				IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT, 
				IfcCoolingTowerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.USERDEFINED, 
				IfcCoolingTowerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NATURALDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.NATURALDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.USERDEFINED:
				PredefinedType = IfcCoolingTowerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoolingTowerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCoolingTowerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoolingTowerTypeEnum)Enum.Parse(typeof(IfcCoolingTowerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoolingTowerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCoolingTowerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCoolingTowerTypeClause.WR1)
			{
				result = PredefinedType != IfcCoolingTowerTypeEnum.USERDEFINED || (PredefinedType == IfcCoolingTowerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCoolingTowerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcCoolingTowerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCoolingTowerTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCoolingTowerType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
