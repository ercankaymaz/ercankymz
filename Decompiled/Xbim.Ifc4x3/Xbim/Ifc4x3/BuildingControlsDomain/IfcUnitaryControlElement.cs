using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.BuildingControlsDomain;

[ExpressType("IfcUnitaryControlElement", 1308)]
public class IfcUnitaryControlElement : IfcDistributionControlElement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcUnitaryControlElement>, IIfcUnitaryControlElement, IIfcDistributionControlElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcUnitaryControlElementTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcUnitaryControlElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcUnitaryControlElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcUnitaryControlElement), 9)]
	Xbim.Ifc4.Interfaces.IfcUnitaryControlElementTypeEnum? IIfcUnitaryControlElement.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcUnitaryControlElement(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcUnitaryControlElementTypeEnum)Enum.Parse(typeof(IfcUnitaryControlElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcUnitaryControlElement other)
	{
		return this == other;
	}
}
