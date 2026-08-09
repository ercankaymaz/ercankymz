using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.BuildingcontrolsDomain;

[ExpressType("IfcSensorType", 375)]
public class IfcSensorType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSensorType>, IIfcSensorType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcSensorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcSensorTypeEnum PredefinedType
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
			SetValue(delegate(IfcSensorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcSensorType), 10)]
	Xbim.Ifc4.Interfaces.IfcSensorTypeEnum IIfcSensorType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcSensorTypeEnum.CO2SENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CO2SENSOR;
			case IfcSensorTypeEnum.FIRESENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FIRESENSOR;
			case IfcSensorTypeEnum.FLOWSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FLOWSENSOR;
			case IfcSensorTypeEnum.GASSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.GASSENSOR;
			case IfcSensorTypeEnum.HEATSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HEATSENSOR;
			case IfcSensorTypeEnum.HUMIDITYSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HUMIDITYSENSOR;
			case IfcSensorTypeEnum.LIGHTSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LIGHTSENSOR;
			case IfcSensorTypeEnum.MOISTURESENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOISTURESENSOR;
			case IfcSensorTypeEnum.MOVEMENTSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOVEMENTSENSOR;
			case IfcSensorTypeEnum.PRESSURESENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PRESSURESENSOR;
			case IfcSensorTypeEnum.SMOKESENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SMOKESENSOR;
			case IfcSensorTypeEnum.SOUNDSENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SOUNDSENSOR;
			case IfcSensorTypeEnum.TEMPERATURESENSOR:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.TEMPERATURESENSOR;
			case IfcSensorTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.USERDEFINED;
			}
			case IfcSensorTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.COSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CO2SENSOR:
				PredefinedType = IfcSensorTypeEnum.CO2SENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONDUCTANCESENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONTACTSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FIRESENSOR:
				PredefinedType = IfcSensorTypeEnum.FIRESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FLOWSENSOR:
				PredefinedType = IfcSensorTypeEnum.FLOWSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FROSTSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.GASSENSOR:
				PredefinedType = IfcSensorTypeEnum.GASSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HEATSENSOR:
				PredefinedType = IfcSensorTypeEnum.HEATSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HUMIDITYSENSOR:
				PredefinedType = IfcSensorTypeEnum.HUMIDITYSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.IDENTIFIERSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.IONCONCENTRATIONSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LEVELSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LIGHTSENSOR:
				PredefinedType = IfcSensorTypeEnum.LIGHTSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOISTURESENSOR:
				PredefinedType = IfcSensorTypeEnum.MOISTURESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOVEMENTSENSOR:
				PredefinedType = IfcSensorTypeEnum.MOVEMENTSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PHSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PRESSURESENSOR:
				PredefinedType = IfcSensorTypeEnum.PRESSURESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIATIONSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIOACTIVITYSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SMOKESENSOR:
				PredefinedType = IfcSensorTypeEnum.SMOKESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SOUNDSENSOR:
				PredefinedType = IfcSensorTypeEnum.SOUNDSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.TEMPERATURESENSOR:
				PredefinedType = IfcSensorTypeEnum.TEMPERATURESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.WINDSENSOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.USERDEFINED:
				PredefinedType = IfcSensorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.NOTDEFINED:
				PredefinedType = IfcSensorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSensorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSensorTypeEnum)Enum.Parse(typeof(IfcSensorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSensorType other)
	{
		return this == other;
	}
}
