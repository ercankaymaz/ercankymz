using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcSwitchingDeviceType", 153)]
public class IfcSwitchingDeviceType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSwitchingDeviceType>, IIfcSwitchingDeviceType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcSwitchingDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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

	[CrossSchemaAttribute(typeof(IIfcSwitchingDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum IIfcSwitchingDeviceType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcSwitchingDeviceTypeEnum.CONTACTOR:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.CONTACTOR;
			case IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP;
			case IfcSwitchingDeviceTypeEnum.STARTER:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.STARTER;
			case IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SWITCHDISCONNECTOR;
			case IfcSwitchingDeviceTypeEnum.TOGGLESWITCH:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.TOGGLESWITCH;
			case IfcSwitchingDeviceTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.USERDEFINED;
			}
			case IfcSwitchingDeviceTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.CONTACTOR:
				PredefinedType = IfcSwitchingDeviceTypeEnum.CONTACTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.DIMMERSWITCH:
				base.ElementType = value.ToString();
				PredefinedType = IfcSwitchingDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP:
				PredefinedType = IfcSwitchingDeviceTypeEnum.EMERGENCYSTOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.KEYPAD:
				base.ElementType = value.ToString();
				PredefinedType = IfcSwitchingDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.MOMENTARYSWITCH:
				base.ElementType = value.ToString();
				PredefinedType = IfcSwitchingDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSwitchingDeviceTypeEnum.SELECTORSWITCH:
				base.ElementType = value.ToString();
				PredefinedType = IfcSwitchingDeviceTypeEnum.USERDEFINED;
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
