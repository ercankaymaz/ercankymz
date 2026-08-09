using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcHeatExchangerType", 365)]
public class IfcHeatExchangerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcHeatExchangerType>, IIfcHeatExchangerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcHeatExchangerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcHeatExchangerTypeEnum PredefinedType
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
			SetValue(delegate(IfcHeatExchangerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcHeatExchangerType), 10)]
	Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum IIfcHeatExchangerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcHeatExchangerTypeEnum.PLATE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE, 
				IfcHeatExchangerTypeEnum.SHELLANDTUBE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE, 
				IfcHeatExchangerTypeEnum.TURNOUTHEATING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum>(), 
				IfcHeatExchangerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED, 
				IfcHeatExchangerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE:
				PredefinedType = IfcHeatExchangerTypeEnum.PLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE:
				PredefinedType = IfcHeatExchangerTypeEnum.SHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcHeatExchangerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcHeatExchangerTypeEnum)Enum.Parse(typeof(IfcHeatExchangerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHeatExchangerType other)
	{
		return this == other;
	}
}
