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

[ExpressType("IfcTransformerType", 549)]
public class IfcTransformerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTransformerType>, IIfcTransformerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcTransformerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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

	[CrossSchemaAttribute(typeof(IIfcTransformerType), 10)]
	Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum IIfcTransformerType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcTransformerTypeEnum.CURRENT:
				return Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.CURRENT;
			case IfcTransformerTypeEnum.FREQUENCY:
				return Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.FREQUENCY;
			case IfcTransformerTypeEnum.VOLTAGE:
				return Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.VOLTAGE;
			case IfcTransformerTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.USERDEFINED;
			}
			case IfcTransformerTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
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
				base.ElementType = value.ToString();
				PredefinedType = IfcTransformerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransformerTypeEnum.RECTIFIER:
				base.ElementType = value.ToString();
				PredefinedType = IfcTransformerTypeEnum.USERDEFINED;
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
