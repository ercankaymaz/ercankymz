using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcSolarDevice", 1270)]
public class IfcSolarDevice : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSolarDevice>, IIfcSolarDevice, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcSolarDeviceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcSolarDeviceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSolarDeviceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcSolarDevice), 9)]
	Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum? IIfcSolarDevice.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSolarDeviceTypeEnum.SOLARCOLLECTOR => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARCOLLECTOR, 
				IfcSolarDeviceTypeEnum.SOLARPANEL => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARPANEL, 
				IfcSolarDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.USERDEFINED, 
				IfcSolarDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARCOLLECTOR:
				PredefinedType = IfcSolarDeviceTypeEnum.SOLARCOLLECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARPANEL:
				PredefinedType = IfcSolarDeviceTypeEnum.SOLARPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcSolarDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcSolarDeviceTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSolarDevice(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSolarDeviceTypeEnum)Enum.Parse(typeof(IfcSolarDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSolarDevice other)
	{
		return this == other;
	}
}
