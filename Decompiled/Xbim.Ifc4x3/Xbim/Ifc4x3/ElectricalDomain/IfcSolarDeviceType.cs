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

[ExpressType("IfcSolarDeviceType", 1271)]
public class IfcSolarDeviceType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSolarDeviceType>, IIfcSolarDeviceType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcSolarDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSolarDeviceTypeEnum PredefinedType
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
			SetValue(delegate(IfcSolarDeviceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcSolarDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum IIfcSolarDeviceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSolarDeviceTypeEnum.SOLARCOLLECTOR => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARCOLLECTOR, 
				IfcSolarDeviceTypeEnum.SOLARPANEL => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.SOLARPANEL, 
				IfcSolarDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.USERDEFINED, 
				IfcSolarDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSolarDeviceTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSolarDeviceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSolarDeviceTypeEnum)Enum.Parse(typeof(IfcSolarDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSolarDeviceType other)
	{
		return this == other;
	}
}
