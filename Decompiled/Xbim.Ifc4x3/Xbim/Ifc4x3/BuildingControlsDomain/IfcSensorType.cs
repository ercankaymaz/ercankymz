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

[ExpressType("IfcSensorType", 375)]
public class IfcSensorType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSensorType>, IIfcSensorType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcSensorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
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

	[CrossSchemaAttribute(typeof(IIfcSensorType), 10)]
	Xbim.Ifc4.Interfaces.IfcSensorTypeEnum IIfcSensorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSensorTypeEnum.CO2SENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CO2SENSOR, 
				IfcSensorTypeEnum.CONDUCTANCESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONDUCTANCESENSOR, 
				IfcSensorTypeEnum.CONTACTSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONTACTSENSOR, 
				IfcSensorTypeEnum.COSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.COSENSOR, 
				IfcSensorTypeEnum.EARTHQUAKESENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.FIRESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FIRESENSOR, 
				IfcSensorTypeEnum.FLOWSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FLOWSENSOR, 
				IfcSensorTypeEnum.FOREIGNOBJECTDETECTIONSENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.FROSTSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FROSTSENSOR, 
				IfcSensorTypeEnum.GASSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.GASSENSOR, 
				IfcSensorTypeEnum.HEATSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HEATSENSOR, 
				IfcSensorTypeEnum.HUMIDITYSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.HUMIDITYSENSOR, 
				IfcSensorTypeEnum.IDENTIFIERSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.IDENTIFIERSENSOR, 
				IfcSensorTypeEnum.IONCONCENTRATIONSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.IONCONCENTRATIONSENSOR, 
				IfcSensorTypeEnum.LEVELSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LEVELSENSOR, 
				IfcSensorTypeEnum.LIGHTSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LIGHTSENSOR, 
				IfcSensorTypeEnum.MOISTURESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOISTURESENSOR, 
				IfcSensorTypeEnum.MOVEMENTSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.MOVEMENTSENSOR, 
				IfcSensorTypeEnum.OBSTACLESENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.PHSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PHSENSOR, 
				IfcSensorTypeEnum.PRESSURESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PRESSURESENSOR, 
				IfcSensorTypeEnum.RADIATIONSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIATIONSENSOR, 
				IfcSensorTypeEnum.RADIOACTIVITYSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIOACTIVITYSENSOR, 
				IfcSensorTypeEnum.RAINSENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.SMOKESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SMOKESENSOR, 
				IfcSensorTypeEnum.SNOWDEPTHSENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.SOUNDSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.SOUNDSENSOR, 
				IfcSensorTypeEnum.TEMPERATURESENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.TEMPERATURESENSOR, 
				IfcSensorTypeEnum.TRAINSENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.TURNOUTCLOSURESENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.WHEELSENSOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSensorTypeEnum>(), 
				IfcSensorTypeEnum.WINDSENSOR => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.WINDSENSOR, 
				IfcSensorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.USERDEFINED, 
				IfcSensorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.COSENSOR:
				PredefinedType = IfcSensorTypeEnum.COSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CO2SENSOR:
				PredefinedType = IfcSensorTypeEnum.CO2SENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONDUCTANCESENSOR:
				PredefinedType = IfcSensorTypeEnum.CONDUCTANCESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.CONTACTSENSOR:
				PredefinedType = IfcSensorTypeEnum.CONTACTSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FIRESENSOR:
				PredefinedType = IfcSensorTypeEnum.FIRESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FLOWSENSOR:
				PredefinedType = IfcSensorTypeEnum.FLOWSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.FROSTSENSOR:
				PredefinedType = IfcSensorTypeEnum.FROSTSENSOR;
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
				PredefinedType = IfcSensorTypeEnum.IDENTIFIERSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.IONCONCENTRATIONSENSOR:
				PredefinedType = IfcSensorTypeEnum.IONCONCENTRATIONSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.LEVELSENSOR:
				PredefinedType = IfcSensorTypeEnum.LEVELSENSOR;
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
				PredefinedType = IfcSensorTypeEnum.PHSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.PRESSURESENSOR:
				PredefinedType = IfcSensorTypeEnum.PRESSURESENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIATIONSENSOR:
				PredefinedType = IfcSensorTypeEnum.RADIATIONSENSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSensorTypeEnum.RADIOACTIVITYSENSOR:
				PredefinedType = IfcSensorTypeEnum.RADIOACTIVITYSENSOR;
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
				PredefinedType = IfcSensorTypeEnum.WINDSENSOR;
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
