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

[ExpressType("IfcEvaporativeCoolerType", 621)]
public class IfcEvaporativeCoolerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEvaporativeCoolerType>, IIfcEvaporativeCoolerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcEvaporativeCoolerTypeClause
	{
		WR1
	}

	private IfcEvaporativeCoolerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcEvaporativeCoolerTypeEnum PredefinedType
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
			SetValue(delegate(IfcEvaporativeCoolerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcEvaporativeCoolerType), 10)]
	Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum IIfcEvaporativeCoolerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION, 
				IfcEvaporativeCoolerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.USERDEFINED, 
				IfcEvaporativeCoolerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.USERDEFINED:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.NOTDEFINED:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcEvaporativeCoolerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEvaporativeCoolerTypeEnum)Enum.Parse(typeof(IfcEvaporativeCoolerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvaporativeCoolerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEvaporativeCoolerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcEvaporativeCoolerTypeClause.WR1)
			{
				result = PredefinedType != IfcEvaporativeCoolerTypeEnum.USERDEFINED || (PredefinedType == IfcEvaporativeCoolerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEvaporativeCoolerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcEvaporativeCoolerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcEvaporativeCoolerTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEvaporativeCoolerType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
