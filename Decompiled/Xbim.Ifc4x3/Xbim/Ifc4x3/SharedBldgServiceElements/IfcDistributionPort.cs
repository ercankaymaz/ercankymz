using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionPort", 178)]
public class IfcDistributionPort : IfcPort, IIfcDistributionPort, IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionPort>
{
	private IfcFlowDirectionEnum? _flowDirection;

	private IfcDistributionPortTypeEnum? _predefinedType;

	private IfcDistributionSystemEnum? _systemType;

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 8)]
	Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum? IIfcDistributionPort.FlowDirection
	{
		get
		{
			return FlowDirection switch
			{
				IfcFlowDirectionEnum.SINK => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SINK, 
				IfcFlowDirectionEnum.SOURCE => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCE, 
				IfcFlowDirectionEnum.SOURCEANDSINK => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCEANDSINK, 
				IfcFlowDirectionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCE:
				FlowDirection = IfcFlowDirectionEnum.SOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SINK:
				FlowDirection = IfcFlowDirectionEnum.SINK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCEANDSINK:
				FlowDirection = IfcFlowDirectionEnum.SOURCEANDSINK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.NOTDEFINED:
				FlowDirection = IfcFlowDirectionEnum.NOTDEFINED;
				break;
			case null:
				FlowDirection = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 9)]
	Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum? IIfcDistributionPort.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDistributionPortTypeEnum.CABLE => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.CABLE, 
				IfcDistributionPortTypeEnum.CABLECARRIER => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.CABLECARRIER, 
				IfcDistributionPortTypeEnum.DUCT => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.DUCT, 
				IfcDistributionPortTypeEnum.PIPE => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.PIPE, 
				IfcDistributionPortTypeEnum.WIRELESS => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum>(), 
				IfcDistributionPortTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.USERDEFINED, 
				IfcDistributionPortTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.CABLE:
				PredefinedType = IfcDistributionPortTypeEnum.CABLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.CABLECARRIER:
				PredefinedType = IfcDistributionPortTypeEnum.CABLECARRIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.DUCT:
				PredefinedType = IfcDistributionPortTypeEnum.DUCT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.PIPE:
				PredefinedType = IfcDistributionPortTypeEnum.PIPE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.USERDEFINED:
				PredefinedType = IfcDistributionPortTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionPortTypeEnum.NOTDEFINED:
				PredefinedType = IfcDistributionPortTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 10)]
	Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum? IIfcDistributionPort.SystemType
	{
		get
		{
			return SystemType switch
			{
				IfcDistributionSystemEnum.AIRCONDITIONING => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.AIRCONDITIONING, 
				IfcDistributionSystemEnum.AUDIOVISUAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.AUDIOVISUAL, 
				IfcDistributionSystemEnum.CATENARY_SYSTEM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.CHEMICAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHEMICAL, 
				IfcDistributionSystemEnum.CHILLEDWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHILLEDWATER, 
				IfcDistributionSystemEnum.COMMUNICATION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMMUNICATION, 
				IfcDistributionSystemEnum.COMPRESSEDAIR => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMPRESSEDAIR, 
				IfcDistributionSystemEnum.CONDENSERWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONDENSERWATER, 
				IfcDistributionSystemEnum.CONTROL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONTROL, 
				IfcDistributionSystemEnum.CONVEYING => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONVEYING, 
				IfcDistributionSystemEnum.DATA => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DATA, 
				IfcDistributionSystemEnum.DISPOSAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DISPOSAL, 
				IfcDistributionSystemEnum.DOMESTICCOLDWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICCOLDWATER, 
				IfcDistributionSystemEnum.DOMESTICHOTWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICHOTWATER, 
				IfcDistributionSystemEnum.DRAINAGE => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DRAINAGE, 
				IfcDistributionSystemEnum.EARTHING => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EARTHING, 
				IfcDistributionSystemEnum.ELECTRICAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTRICAL, 
				IfcDistributionSystemEnum.ELECTROACOUSTIC => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTROACOUSTIC, 
				IfcDistributionSystemEnum.EXHAUST => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EXHAUST, 
				IfcDistributionSystemEnum.FIREPROTECTION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FIREPROTECTION, 
				IfcDistributionSystemEnum.FIXEDTRANSMISSIONNETWORK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.FUEL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FUEL, 
				IfcDistributionSystemEnum.GAS => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.GAS, 
				IfcDistributionSystemEnum.HAZARDOUS => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HAZARDOUS, 
				IfcDistributionSystemEnum.HEATING => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HEATING, 
				IfcDistributionSystemEnum.LIGHTING => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTING, 
				IfcDistributionSystemEnum.LIGHTNINGPROTECTION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTNINGPROTECTION, 
				IfcDistributionSystemEnum.MOBILENETWORK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.MONITORINGSYSTEM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE, 
				IfcDistributionSystemEnum.OIL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OIL, 
				IfcDistributionSystemEnum.OPERATIONAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OPERATIONAL, 
				IfcDistributionSystemEnum.OPERATIONALTELEPHONYSYSTEM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.OVERHEAD_CONTACTLINE_SYSTEM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.POWERGENERATION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.POWERGENERATION, 
				IfcDistributionSystemEnum.RAINWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.RAINWATER, 
				IfcDistributionSystemEnum.REFRIGERATION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.REFRIGERATION, 
				IfcDistributionSystemEnum.RETURN_CIRCUIT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum>(), 
				IfcDistributionSystemEnum.SECURITY => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SECURITY, 
				IfcDistributionSystemEnum.SEWAGE => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SEWAGE, 
				IfcDistributionSystemEnum.SIGNAL => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SIGNAL, 
				IfcDistributionSystemEnum.STORMWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.STORMWATER, 
				IfcDistributionSystemEnum.TELEPHONE => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TELEPHONE, 
				IfcDistributionSystemEnum.TV => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TV, 
				IfcDistributionSystemEnum.VACUUM => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VACUUM, 
				IfcDistributionSystemEnum.VENT => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENT, 
				IfcDistributionSystemEnum.VENTILATION => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENTILATION, 
				IfcDistributionSystemEnum.WASTEWATER => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WASTEWATER, 
				IfcDistributionSystemEnum.WATERSUPPLY => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WATERSUPPLY, 
				IfcDistributionSystemEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.USERDEFINED, 
				IfcDistributionSystemEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.AIRCONDITIONING:
				SystemType = IfcDistributionSystemEnum.AIRCONDITIONING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.AUDIOVISUAL:
				SystemType = IfcDistributionSystemEnum.AUDIOVISUAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHEMICAL:
				SystemType = IfcDistributionSystemEnum.CHEMICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHILLEDWATER:
				SystemType = IfcDistributionSystemEnum.CHILLEDWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMMUNICATION:
				SystemType = IfcDistributionSystemEnum.COMMUNICATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMPRESSEDAIR:
				SystemType = IfcDistributionSystemEnum.COMPRESSEDAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONDENSERWATER:
				SystemType = IfcDistributionSystemEnum.CONDENSERWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONTROL:
				SystemType = IfcDistributionSystemEnum.CONTROL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONVEYING:
				SystemType = IfcDistributionSystemEnum.CONVEYING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DATA:
				SystemType = IfcDistributionSystemEnum.DATA;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DISPOSAL:
				SystemType = IfcDistributionSystemEnum.DISPOSAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICCOLDWATER:
				SystemType = IfcDistributionSystemEnum.DOMESTICCOLDWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICHOTWATER:
				SystemType = IfcDistributionSystemEnum.DOMESTICHOTWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DRAINAGE:
				SystemType = IfcDistributionSystemEnum.DRAINAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EARTHING:
				SystemType = IfcDistributionSystemEnum.EARTHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTRICAL:
				SystemType = IfcDistributionSystemEnum.ELECTRICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTROACOUSTIC:
				SystemType = IfcDistributionSystemEnum.ELECTROACOUSTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EXHAUST:
				SystemType = IfcDistributionSystemEnum.EXHAUST;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FIREPROTECTION:
				SystemType = IfcDistributionSystemEnum.FIREPROTECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FUEL:
				SystemType = IfcDistributionSystemEnum.FUEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.GAS:
				SystemType = IfcDistributionSystemEnum.GAS;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HAZARDOUS:
				SystemType = IfcDistributionSystemEnum.HAZARDOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HEATING:
				SystemType = IfcDistributionSystemEnum.HEATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTING:
				SystemType = IfcDistributionSystemEnum.LIGHTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTNINGPROTECTION:
				SystemType = IfcDistributionSystemEnum.LIGHTNINGPROTECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE:
				SystemType = IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OIL:
				SystemType = IfcDistributionSystemEnum.OIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OPERATIONAL:
				SystemType = IfcDistributionSystemEnum.OPERATIONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.POWERGENERATION:
				SystemType = IfcDistributionSystemEnum.POWERGENERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.RAINWATER:
				SystemType = IfcDistributionSystemEnum.RAINWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.REFRIGERATION:
				SystemType = IfcDistributionSystemEnum.REFRIGERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SECURITY:
				SystemType = IfcDistributionSystemEnum.SECURITY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SEWAGE:
				SystemType = IfcDistributionSystemEnum.SEWAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SIGNAL:
				SystemType = IfcDistributionSystemEnum.SIGNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.STORMWATER:
				SystemType = IfcDistributionSystemEnum.STORMWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TELEPHONE:
				SystemType = IfcDistributionSystemEnum.TELEPHONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TV:
				SystemType = IfcDistributionSystemEnum.TV;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VACUUM:
				SystemType = IfcDistributionSystemEnum.VACUUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENT:
				SystemType = IfcDistributionSystemEnum.VENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENTILATION:
				SystemType = IfcDistributionSystemEnum.VENTILATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WASTEWATER:
				SystemType = IfcDistributionSystemEnum.WASTEWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WATERSUPPLY:
				SystemType = IfcDistributionSystemEnum.WATERSUPPLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.USERDEFINED:
				SystemType = IfcDistributionSystemEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.NOTDEFINED:
				SystemType = IfcDistributionSystemEnum.NOTDEFINED;
				break;
			case null:
				SystemType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcFlowDirectionEnum? FlowDirection
	{
		get
		{
			if (_activated)
			{
				return _flowDirection;
			}
			Activate();
			return _flowDirection;
		}
		set
		{
			SetValue(delegate(IfcFlowDirectionEnum? v)
			{
				_flowDirection = v;
			}, _flowDirection, value, "FlowDirection", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 26)]
	public IfcDistributionPortTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDistributionPortTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcDistributionSystemEnum? SystemType
	{
		get
		{
			if (_activated)
			{
				return _systemType;
			}
			Activate();
			return _systemType;
		}
		set
		{
			SetValue(delegate(IfcDistributionSystemEnum? v)
			{
				_systemType = v;
			}, _systemType, value, "SystemType", 10);
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

	internal IfcDistributionPort(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_flowDirection = (IfcFlowDirectionEnum)Enum.Parse(typeof(IfcFlowDirectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_predefinedType = (IfcDistributionPortTypeEnum)Enum.Parse(typeof(IfcDistributionPortTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_systemType = (IfcDistributionSystemEnum)Enum.Parse(typeof(IfcDistributionSystemEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionPort other)
	{
		return this == other;
	}
}
