using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionSystem", 1150)]
public class IfcDistributionSystem : IfcSystem, IIfcDistributionSystem, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcDistributionSystem>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _longName;

	private IfcDistributionSystemEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcDistributionSystem), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDistributionSystem.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDistributionSystem), 7)]
	Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum? IIfcDistributionSystem.PredefinedType
	{
		get
		{
			return PredefinedType switch
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
				PredefinedType = IfcDistributionSystemEnum.AIRCONDITIONING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.AUDIOVISUAL:
				PredefinedType = IfcDistributionSystemEnum.AUDIOVISUAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHEMICAL:
				PredefinedType = IfcDistributionSystemEnum.CHEMICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CHILLEDWATER:
				PredefinedType = IfcDistributionSystemEnum.CHILLEDWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMMUNICATION:
				PredefinedType = IfcDistributionSystemEnum.COMMUNICATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.COMPRESSEDAIR:
				PredefinedType = IfcDistributionSystemEnum.COMPRESSEDAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONDENSERWATER:
				PredefinedType = IfcDistributionSystemEnum.CONDENSERWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONTROL:
				PredefinedType = IfcDistributionSystemEnum.CONTROL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.CONVEYING:
				PredefinedType = IfcDistributionSystemEnum.CONVEYING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DATA:
				PredefinedType = IfcDistributionSystemEnum.DATA;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DISPOSAL:
				PredefinedType = IfcDistributionSystemEnum.DISPOSAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICCOLDWATER:
				PredefinedType = IfcDistributionSystemEnum.DOMESTICCOLDWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DOMESTICHOTWATER:
				PredefinedType = IfcDistributionSystemEnum.DOMESTICHOTWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.DRAINAGE:
				PredefinedType = IfcDistributionSystemEnum.DRAINAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EARTHING:
				PredefinedType = IfcDistributionSystemEnum.EARTHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTRICAL:
				PredefinedType = IfcDistributionSystemEnum.ELECTRICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.ELECTROACOUSTIC:
				PredefinedType = IfcDistributionSystemEnum.ELECTROACOUSTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.EXHAUST:
				PredefinedType = IfcDistributionSystemEnum.EXHAUST;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FIREPROTECTION:
				PredefinedType = IfcDistributionSystemEnum.FIREPROTECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.FUEL:
				PredefinedType = IfcDistributionSystemEnum.FUEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.GAS:
				PredefinedType = IfcDistributionSystemEnum.GAS;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HAZARDOUS:
				PredefinedType = IfcDistributionSystemEnum.HAZARDOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.HEATING:
				PredefinedType = IfcDistributionSystemEnum.HEATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTING:
				PredefinedType = IfcDistributionSystemEnum.LIGHTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.LIGHTNINGPROTECTION:
				PredefinedType = IfcDistributionSystemEnum.LIGHTNINGPROTECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE:
				PredefinedType = IfcDistributionSystemEnum.MUNICIPALSOLIDWASTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OIL:
				PredefinedType = IfcDistributionSystemEnum.OIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.OPERATIONAL:
				PredefinedType = IfcDistributionSystemEnum.OPERATIONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.POWERGENERATION:
				PredefinedType = IfcDistributionSystemEnum.POWERGENERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.RAINWATER:
				PredefinedType = IfcDistributionSystemEnum.RAINWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.REFRIGERATION:
				PredefinedType = IfcDistributionSystemEnum.REFRIGERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SECURITY:
				PredefinedType = IfcDistributionSystemEnum.SECURITY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SEWAGE:
				PredefinedType = IfcDistributionSystemEnum.SEWAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.SIGNAL:
				PredefinedType = IfcDistributionSystemEnum.SIGNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.STORMWATER:
				PredefinedType = IfcDistributionSystemEnum.STORMWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TELEPHONE:
				PredefinedType = IfcDistributionSystemEnum.TELEPHONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.TV:
				PredefinedType = IfcDistributionSystemEnum.TV;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VACUUM:
				PredefinedType = IfcDistributionSystemEnum.VACUUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENT:
				PredefinedType = IfcDistributionSystemEnum.VENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.VENTILATION:
				PredefinedType = IfcDistributionSystemEnum.VENTILATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WASTEWATER:
				PredefinedType = IfcDistributionSystemEnum.WASTEWATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.WATERSUPPLY:
				PredefinedType = IfcDistributionSystemEnum.WATERSUPPLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.USERDEFINED:
				PredefinedType = IfcDistributionSystemEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionSystemEnum.NOTDEFINED:
				PredefinedType = IfcDistributionSystemEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 22)]
	public IfcDistributionSystemEnum? PredefinedType
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
			SetValue(delegate(IfcDistributionSystemEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
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
		}
	}

	internal IfcDistributionSystem(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_longName = value.StringVal;
			break;
		case 6:
			_predefinedType = (IfcDistributionSystemEnum)Enum.Parse(typeof(IfcDistributionSystemEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionSystem other)
	{
		return this == other;
	}
}
