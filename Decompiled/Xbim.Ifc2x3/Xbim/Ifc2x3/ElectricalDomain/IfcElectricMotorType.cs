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

[ExpressType("IfcElectricMotorType", 370)]
public class IfcElectricMotorType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricMotorType>, IIfcElectricMotorType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcElectricMotorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcElectricMotorTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricMotorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricMotorType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum IIfcElectricMotorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricMotorTypeEnum.DC => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.DC, 
				IfcElectricMotorTypeEnum.INDUCTION => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.INDUCTION, 
				IfcElectricMotorTypeEnum.POLYPHASE => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.POLYPHASE, 
				IfcElectricMotorTypeEnum.RELUCTANCESYNCHRONOUS => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.RELUCTANCESYNCHRONOUS, 
				IfcElectricMotorTypeEnum.SYNCHRONOUS => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.SYNCHRONOUS, 
				IfcElectricMotorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.USERDEFINED, 
				IfcElectricMotorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.DC:
				PredefinedType = IfcElectricMotorTypeEnum.DC;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.INDUCTION:
				PredefinedType = IfcElectricMotorTypeEnum.INDUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.POLYPHASE:
				PredefinedType = IfcElectricMotorTypeEnum.POLYPHASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.RELUCTANCESYNCHRONOUS:
				PredefinedType = IfcElectricMotorTypeEnum.RELUCTANCESYNCHRONOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.SYNCHRONOUS:
				PredefinedType = IfcElectricMotorTypeEnum.SYNCHRONOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricMotorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricMotorTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricMotorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricMotorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricMotorTypeEnum)Enum.Parse(typeof(IfcElectricMotorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricMotorType other)
	{
		return this == other;
	}
}
