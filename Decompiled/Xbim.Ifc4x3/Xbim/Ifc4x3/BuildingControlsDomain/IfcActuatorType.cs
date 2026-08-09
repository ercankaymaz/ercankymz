using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.BuildingControlsDomain;

[ExpressType("IfcActuatorType", 485)]
public class IfcActuatorType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcActuatorType>, IIfcActuatorType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcActuatorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcActuatorTypeEnum PredefinedType
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
			SetValue(delegate(IfcActuatorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcActuatorType), 10)]
	Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum IIfcActuatorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcActuatorTypeEnum.ELECTRICACTUATOR => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.ELECTRICACTUATOR, 
				IfcActuatorTypeEnum.HANDOPERATEDACTUATOR => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.HANDOPERATEDACTUATOR, 
				IfcActuatorTypeEnum.HYDRAULICACTUATOR => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.HYDRAULICACTUATOR, 
				IfcActuatorTypeEnum.PNEUMATICACTUATOR => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.PNEUMATICACTUATOR, 
				IfcActuatorTypeEnum.THERMOSTATICACTUATOR => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.THERMOSTATICACTUATOR, 
				IfcActuatorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.USERDEFINED, 
				IfcActuatorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.ELECTRICACTUATOR:
				PredefinedType = IfcActuatorTypeEnum.ELECTRICACTUATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.HANDOPERATEDACTUATOR:
				PredefinedType = IfcActuatorTypeEnum.HANDOPERATEDACTUATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.HYDRAULICACTUATOR:
				PredefinedType = IfcActuatorTypeEnum.HYDRAULICACTUATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.PNEUMATICACTUATOR:
				PredefinedType = IfcActuatorTypeEnum.PNEUMATICACTUATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.THERMOSTATICACTUATOR:
				PredefinedType = IfcActuatorTypeEnum.THERMOSTATICACTUATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.USERDEFINED:
				PredefinedType = IfcActuatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcActuatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcActuatorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcActuatorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcActuatorTypeEnum)Enum.Parse(typeof(IfcActuatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcActuatorType other)
	{
		return this == other;
	}
}
