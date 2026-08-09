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

[ExpressType("IfcTransformerType", 549)]
public class IfcTransformerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTransformerType>, IIfcTransformerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcTransformerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTransformerTypeEnum PredefinedType
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
			SetValue(delegate(IfcTransformerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcTransformerType), 10)]
	Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum IIfcTransformerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTransformerTypeEnum.CHOPPER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum>(), 
				IfcTransformerTypeEnum.COMBINED => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum>(), 
				IfcTransformerTypeEnum.CURRENT => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.CURRENT, 
				IfcTransformerTypeEnum.FREQUENCY => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.FREQUENCY, 
				IfcTransformerTypeEnum.INVERTER => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.INVERTER, 
				IfcTransformerTypeEnum.RECTIFIER => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.RECTIFIER, 
				IfcTransformerTypeEnum.VOLTAGE => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.VOLTAGE, 
				IfcTransformerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.USERDEFINED, 
				IfcTransformerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.CURRENT:
				PredefinedType = IfcTransformerTypeEnum.CURRENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.FREQUENCY:
				PredefinedType = IfcTransformerTypeEnum.FREQUENCY;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.INVERTER:
				PredefinedType = IfcTransformerTypeEnum.INVERTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.RECTIFIER:
				PredefinedType = IfcTransformerTypeEnum.RECTIFIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.VOLTAGE:
				PredefinedType = IfcTransformerTypeEnum.VOLTAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.USERDEFINED:
				PredefinedType = IfcTransformerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.NOTDEFINED:
				PredefinedType = IfcTransformerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcTransformerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTransformerTypeEnum)Enum.Parse(typeof(IfcTransformerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTransformerType other)
	{
		return this == other;
	}
}
