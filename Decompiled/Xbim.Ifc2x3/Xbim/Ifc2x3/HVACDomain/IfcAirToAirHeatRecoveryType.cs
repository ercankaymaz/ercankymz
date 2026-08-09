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

[ExpressType("IfcAirToAirHeatRecoveryType", 588)]
public class IfcAirToAirHeatRecoveryType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAirToAirHeatRecoveryType>, IIfcAirToAirHeatRecoveryType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcAirToAirHeatRecoveryTypeClause
	{
		WR1
	}

	private IfcAirToAirHeatRecoveryTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcAirToAirHeatRecoveryTypeEnum PredefinedType
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
			SetValue(delegate(IfcAirToAirHeatRecoveryTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcAirToAirHeatRecoveryType), 10)]
	Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum IIfcAirToAirHeatRecoveryType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL, 
				IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP, 
				IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE, 
				IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS, 
				IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS, 
				IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS, 
				IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED, 
				IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED:
				PredefinedType = IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAirToAirHeatRecoveryType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAirToAirHeatRecoveryTypeEnum)Enum.Parse(typeof(IfcAirToAirHeatRecoveryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAirToAirHeatRecoveryType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAirToAirHeatRecoveryTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAirToAirHeatRecoveryTypeClause.WR1)
			{
				result = PredefinedType != IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED || (PredefinedType == IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAirToAirHeatRecoveryType>()?.LogError($"Exception thrown evaluating where-clause 'IfcAirToAirHeatRecoveryType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAirToAirHeatRecoveryTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAirToAirHeatRecoveryType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
