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

[ExpressType("IfcUnitaryControlElementType", 1309)]
public class IfcUnitaryControlElementType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcUnitaryControlElementType>, IIfcUnitaryControlElementType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcUnitaryControlElementTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcUnitaryControlElementTypeEnum PredefinedType
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
			SetValue(delegate(IfcUnitaryControlElementTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcUnitaryControlElementType), 10)]
	Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum IIfcUnitaryControlElementType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcUnitaryControlElementTypeEnum.ALARMPANEL => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.ALARMPANEL, 
				IfcUnitaryControlElementTypeEnum.BASESTATIONCONTROLLER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum>(), 
				IfcUnitaryControlElementTypeEnum.COMBINED => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum>(), 
				IfcUnitaryControlElementTypeEnum.CONTROLPANEL => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.CONTROLPANEL, 
				IfcUnitaryControlElementTypeEnum.GASDETECTIONPANEL => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.GASDETECTIONPANEL, 
				IfcUnitaryControlElementTypeEnum.HUMIDISTAT => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.HUMIDISTAT, 
				IfcUnitaryControlElementTypeEnum.INDICATORPANEL => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.INDICATORPANEL, 
				IfcUnitaryControlElementTypeEnum.MIMICPANEL => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.MIMICPANEL, 
				IfcUnitaryControlElementTypeEnum.THERMOSTAT => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.THERMOSTAT, 
				IfcUnitaryControlElementTypeEnum.WEATHERSTATION => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.WEATHERSTATION, 
				IfcUnitaryControlElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.USERDEFINED, 
				IfcUnitaryControlElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.ALARMPANEL:
				PredefinedType = IfcUnitaryControlElementTypeEnum.ALARMPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.CONTROLPANEL:
				PredefinedType = IfcUnitaryControlElementTypeEnum.CONTROLPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.GASDETECTIONPANEL:
				PredefinedType = IfcUnitaryControlElementTypeEnum.GASDETECTIONPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.INDICATORPANEL:
				PredefinedType = IfcUnitaryControlElementTypeEnum.INDICATORPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.MIMICPANEL:
				PredefinedType = IfcUnitaryControlElementTypeEnum.MIMICPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.HUMIDISTAT:
				PredefinedType = IfcUnitaryControlElementTypeEnum.HUMIDISTAT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.THERMOSTAT:
				PredefinedType = IfcUnitaryControlElementTypeEnum.THERMOSTAT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.WEATHERSTATION:
				PredefinedType = IfcUnitaryControlElementTypeEnum.WEATHERSTATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.USERDEFINED:
				PredefinedType = IfcUnitaryControlElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcUnitaryControlElementTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcUnitaryControlElementType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcUnitaryControlElementTypeEnum)Enum.Parse(typeof(IfcUnitaryControlElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcUnitaryControlElementType other)
	{
		return this == other;
	}
}
