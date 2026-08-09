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

[ExpressType("IfcElectricGeneratorType", 241)]
public class IfcElectricGeneratorType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricGeneratorType>, IIfcElectricGeneratorType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcElectricGeneratorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcElectricGeneratorTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricGeneratorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricGeneratorType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum IIfcElectricGeneratorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricGeneratorTypeEnum.CHP => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.CHP, 
				IfcElectricGeneratorTypeEnum.ENGINEGENERATOR => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.ENGINEGENERATOR, 
				IfcElectricGeneratorTypeEnum.STANDALONE => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.STANDALONE, 
				IfcElectricGeneratorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.USERDEFINED, 
				IfcElectricGeneratorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.CHP:
				PredefinedType = IfcElectricGeneratorTypeEnum.CHP;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.ENGINEGENERATOR:
				PredefinedType = IfcElectricGeneratorTypeEnum.ENGINEGENERATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.STANDALONE:
				PredefinedType = IfcElectricGeneratorTypeEnum.STANDALONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricGeneratorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricGeneratorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricGeneratorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricGeneratorTypeEnum)Enum.Parse(typeof(IfcElectricGeneratorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricGeneratorType other)
	{
		return this == other;
	}
}
