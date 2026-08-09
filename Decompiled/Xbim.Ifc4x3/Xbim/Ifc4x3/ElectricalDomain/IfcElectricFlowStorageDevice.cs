using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricFlowStorageDevice", 1159)]
public class IfcElectricFlowStorageDevice : IfcFlowStorageDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricFlowStorageDevice>, IIfcElectricFlowStorageDevice, IIfcFlowStorageDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcElectricFlowStorageDeviceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcElectricFlowStorageDeviceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElectricFlowStorageDeviceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricFlowStorageDevice), 9)]
	Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum? IIfcElectricFlowStorageDevice.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricFlowStorageDeviceTypeEnum.BATTERY => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.BATTERY, 
				IfcElectricFlowStorageDeviceTypeEnum.CAPACITOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum>(), 
				IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK, 
				IfcElectricFlowStorageDeviceTypeEnum.COMPENSATOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum>(), 
				IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER, 
				IfcElectricFlowStorageDeviceTypeEnum.INDUCTOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum>(), 
				IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK, 
				IfcElectricFlowStorageDeviceTypeEnum.RECHARGER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum>(), 
				IfcElectricFlowStorageDeviceTypeEnum.UPS => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.UPS, 
				IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED, 
				IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.BATTERY:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.BATTERY;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.UPS:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.UPS;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricFlowStorageDevice(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricFlowStorageDeviceTypeEnum)Enum.Parse(typeof(IfcElectricFlowStorageDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricFlowStorageDevice other)
	{
		return this == other;
	}
}
