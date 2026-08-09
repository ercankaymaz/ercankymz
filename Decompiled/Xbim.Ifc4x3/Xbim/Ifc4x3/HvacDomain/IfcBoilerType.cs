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

[ExpressType("IfcBoilerType", 142)]
public class IfcBoilerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBoilerType>, IIfcBoilerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcBoilerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcBoilerTypeEnum PredefinedType
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
			SetValue(delegate(IfcBoilerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcBoilerType), 10)]
	Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum IIfcBoilerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBoilerTypeEnum.STEAM => Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.STEAM, 
				IfcBoilerTypeEnum.WATER => Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.WATER, 
				IfcBoilerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.USERDEFINED, 
				IfcBoilerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.WATER:
				PredefinedType = IfcBoilerTypeEnum.WATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.STEAM:
				PredefinedType = IfcBoilerTypeEnum.STEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.USERDEFINED:
				PredefinedType = IfcBoilerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBoilerTypeEnum.NOTDEFINED:
				PredefinedType = IfcBoilerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcBoilerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBoilerTypeEnum)Enum.Parse(typeof(IfcBoilerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoilerType other)
	{
		return this == other;
	}
}
