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

[ExpressType("IfcHumidifierType", 64)]
public class IfcHumidifierType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcHumidifierType>, IIfcHumidifierType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcHumidifierTypeClause
	{
		WR1
	}

	private IfcHumidifierTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcHumidifierTypeEnum PredefinedType
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
			SetValue(delegate(IfcHumidifierTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcHumidifierType), 10)]
	Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum IIfcHumidifierType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcHumidifierTypeEnum.STEAMINJECTION => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.STEAMINJECTION, 
				IfcHumidifierTypeEnum.ADIABATICAIRWASHER => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICAIRWASHER, 
				IfcHumidifierTypeEnum.ADIABATICPAN => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICPAN, 
				IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT, 
				IfcHumidifierTypeEnum.ADIABATICATOMIZING => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICATOMIZING, 
				IfcHumidifierTypeEnum.ADIABATICULTRASONIC => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICULTRASONIC, 
				IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA, 
				IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE, 
				IfcHumidifierTypeEnum.ASSISTEDELECTRIC => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDELECTRIC, 
				IfcHumidifierTypeEnum.ASSISTEDNATURALGAS => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDNATURALGAS, 
				IfcHumidifierTypeEnum.ASSISTEDPROPANE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDPROPANE, 
				IfcHumidifierTypeEnum.ASSISTEDBUTANE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDBUTANE, 
				IfcHumidifierTypeEnum.ASSISTEDSTEAM => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDSTEAM, 
				IfcHumidifierTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.USERDEFINED, 
				IfcHumidifierTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.STEAMINJECTION:
				PredefinedType = IfcHumidifierTypeEnum.STEAMINJECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICAIRWASHER:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICAIRWASHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICPAN:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICPAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICATOMIZING:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICATOMIZING;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICULTRASONIC:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICULTRASONIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDELECTRIC:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDELECTRIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDNATURALGAS:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDNATURALGAS;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDPROPANE:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDPROPANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDBUTANE:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDBUTANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDSTEAM:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDSTEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.USERDEFINED:
				PredefinedType = IfcHumidifierTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.NOTDEFINED:
				PredefinedType = IfcHumidifierTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcHumidifierType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcHumidifierTypeEnum)Enum.Parse(typeof(IfcHumidifierTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHumidifierType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcHumidifierTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcHumidifierTypeClause.WR1)
			{
				result = PredefinedType != IfcHumidifierTypeEnum.USERDEFINED || (PredefinedType == IfcHumidifierTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcHumidifierType>()?.LogError($"Exception thrown evaluating where-clause 'IfcHumidifierType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcHumidifierTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcHumidifierType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
