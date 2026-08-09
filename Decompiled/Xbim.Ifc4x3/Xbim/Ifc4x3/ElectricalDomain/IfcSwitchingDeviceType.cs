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

[ExpressType("IfcSwitchingDeviceType", 153)]
public class IfcSwitchingDeviceType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSwitchingDeviceType>, IIfcSwitchingDeviceType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcSwitchingDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSwitchingDeviceTypeEnum PredefinedType
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
			SetValue(delegate(IfcSwitchingDeviceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcSwitchingDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum IIfcSwitchingDeviceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSwitchingDeviceTypeEnum.CONTACTOR => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.CONTACTOR, 
				IfcSwitchingDeviceTypeEnum.DIMMERSWITCH => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.DIMMERSWITCH, 
				IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP, 
				IfcSwitchingDeviceTypeEnum.KEYPAD => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.KEYPAD, 
				IfcSwitchingDeviceTypeEnum.MOMENTARYSWITCH => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.MOMENTARYSWITCH, 
				IfcSwitchingDeviceTypeEnum.RELAY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum>(), 
				IfcSwitchingDeviceTypeEnum.SELECTORSWITCH => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SELECTORSWITCH, 
				IfcSwitchingDeviceTypeEnum.STARTER => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.STARTER, 
				IfcSwitchingDeviceTypeEnum.START_AND_STOP_EQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum>(), 
				IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR, 
				IfcSwitchingDeviceTypeEnum.TOGGLESWITCH => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.TOGGLESWITCH, 
				IfcSwitchingDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.USERDEFINED, 
				IfcSwitchingDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.CONTACTOR:
				PredefinedType = IfcSwitchingDeviceTypeEnum.CONTACTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.DIMMERSWITCH:
				PredefinedType = IfcSwitchingDeviceTypeEnum.DIMMERSWITCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP:
				PredefinedType = IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.KEYPAD:
				PredefinedType = IfcSwitchingDeviceTypeEnum.KEYPAD;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.MOMENTARYSWITCH:
				PredefinedType = IfcSwitchingDeviceTypeEnum.MOMENTARYSWITCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SELECTORSWITCH:
				PredefinedType = IfcSwitchingDeviceTypeEnum.SELECTORSWITCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.STARTER:
				PredefinedType = IfcSwitchingDeviceTypeEnum.STARTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR:
				PredefinedType = IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.TOGGLESWITCH:
				PredefinedType = IfcSwitchingDeviceTypeEnum.TOGGLESWITCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcSwitchingDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcSwitchingDeviceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSwitchingDeviceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSwitchingDeviceTypeEnum)Enum.Parse(typeof(IfcSwitchingDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSwitchingDeviceType other)
	{
		return this == other;
	}
}
