using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcCommunicationsApplianceType", 1128)]
public class IfcCommunicationsApplianceType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCommunicationsApplianceType>, IIfcCommunicationsApplianceType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcCommunicationsApplianceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCommunicationsApplianceTypeEnum PredefinedType
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
			SetValue(delegate(IfcCommunicationsApplianceTypeEnum v)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCommunicationsApplianceType), 10)]
	Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum IIfcCommunicationsApplianceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCommunicationsApplianceTypeEnum.ANTENNA => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.ANTENNA, 
				IfcCommunicationsApplianceTypeEnum.AUTOMATON => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.COMPUTER => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.COMPUTER, 
				IfcCommunicationsApplianceTypeEnum.FAX => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.FAX, 
				IfcCommunicationsApplianceTypeEnum.GATEWAY => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.GATEWAY, 
				IfcCommunicationsApplianceTypeEnum.INTELLIGENTPERIPHERAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.IPNETWORKEQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.LINESIDEELECTRONICUNIT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.MODEM => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.MODEM, 
				IfcCommunicationsApplianceTypeEnum.NETWORKAPPLIANCE => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKAPPLIANCE, 
				IfcCommunicationsApplianceTypeEnum.NETWORKBRIDGE => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKBRIDGE, 
				IfcCommunicationsApplianceTypeEnum.NETWORKHUB => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKHUB, 
				IfcCommunicationsApplianceTypeEnum.OPTICALLINETERMINAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.OPTICALNETWORKUNIT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.PRINTER => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.PRINTER, 
				IfcCommunicationsApplianceTypeEnum.RADIOBLOCKCENTER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.REPEATER => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.REPEATER, 
				IfcCommunicationsApplianceTypeEnum.ROUTER => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.ROUTER, 
				IfcCommunicationsApplianceTypeEnum.SCANNER => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.SCANNER, 
				IfcCommunicationsApplianceTypeEnum.TELECOMMAND => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.TELEPHONYEXCHANGE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.TRANSITIONCOMPONENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.TRANSPONDER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.TRANSPORTEQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum>(), 
				IfcCommunicationsApplianceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.USERDEFINED, 
				IfcCommunicationsApplianceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.ANTENNA:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.ANTENNA;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.COMPUTER:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.COMPUTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.FAX:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.FAX;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.GATEWAY:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.GATEWAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.MODEM:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.MODEM;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKAPPLIANCE:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.NETWORKAPPLIANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKBRIDGE:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.NETWORKBRIDGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NETWORKHUB:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.NETWORKHUB;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.PRINTER:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.PRINTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.REPEATER:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.REPEATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.ROUTER:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.ROUTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.SCANNER:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.SCANNER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.USERDEFINED:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCommunicationsApplianceTypeEnum.NOTDEFINED:
				PredefinedType = IfcCommunicationsApplianceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCommunicationsApplianceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCommunicationsApplianceTypeEnum)Enum.Parse(typeof(IfcCommunicationsApplianceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCommunicationsApplianceType other)
	{
		return this == other;
	}
}
