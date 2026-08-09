using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcAirToAirHeatRecovery", 1097)]
public class IfcAirToAirHeatRecovery : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAirToAirHeatRecovery>, IIfcAirToAirHeatRecovery, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcAirToAirHeatRecoveryTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcAirToAirHeatRecoveryTypeEnum? PredefinedType
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
			SetValue(delegate(IfcAirToAirHeatRecoveryTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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

	[CrossSchemaAttribute(typeof(IIfcAirToAirHeatRecovery), 9)]
	Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum? IIfcAirToAirHeatRecovery.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECOUNTERFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATECROSSFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.FIXEDPLATEPARALLELFLOWEXCHANGER, 
				IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.HEATPIPE, 
				IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.ROTARYWHEEL, 
				IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.RUNAROUNDCOILLOOP, 
				IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONCOILTYPEHEATEXCHANGERS, 
				IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.THERMOSIPHONSEALEDTUBEHEATEXCHANGERS, 
				IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.TWINTOWERENTHALPYRECOVERYLOOPS, 
				IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.USERDEFINED, 
				IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAirToAirHeatRecoveryTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAirToAirHeatRecovery(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAirToAirHeatRecoveryTypeEnum)Enum.Parse(typeof(IfcAirToAirHeatRecoveryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAirToAirHeatRecovery other)
	{
		return this == other;
	}
}
