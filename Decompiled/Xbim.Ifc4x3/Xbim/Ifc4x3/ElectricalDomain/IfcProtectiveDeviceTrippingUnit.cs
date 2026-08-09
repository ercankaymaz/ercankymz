using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcProtectiveDeviceTrippingUnit", 1236)]
public class IfcProtectiveDeviceTrippingUnit : IfcDistributionControlElement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProtectiveDeviceTrippingUnit>, IIfcProtectiveDeviceTrippingUnit, IIfcDistributionControlElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcProtectiveDeviceTrippingUnitTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcProtectiveDeviceTrippingUnitTypeEnum? PredefinedType
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
			SetValue(delegate(IfcProtectiveDeviceTrippingUnitTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcProtectiveDeviceTrippingUnit), 9)]
	Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum? IIfcProtectiveDeviceTrippingUnit.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTROMAGNETIC => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTROMAGNETIC, 
				IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTRONIC => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTRONIC, 
				IfcProtectiveDeviceTrippingUnitTypeEnum.RESIDUALCURRENT => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.RESIDUALCURRENT, 
				IfcProtectiveDeviceTrippingUnitTypeEnum.THERMAL => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.THERMAL, 
				IfcProtectiveDeviceTrippingUnitTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.USERDEFINED, 
				IfcProtectiveDeviceTrippingUnitTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTRONIC:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTRONIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTROMAGNETIC:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.ELECTROMAGNETIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.RESIDUALCURRENT:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.RESIDUALCURRENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.THERMAL:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.THERMAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.USERDEFINED:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTrippingUnitTypeEnum.NOTDEFINED:
				PredefinedType = IfcProtectiveDeviceTrippingUnitTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcProtectiveDeviceTrippingUnit(IModel model, int label, bool activated)
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
			_predefinedType = (IfcProtectiveDeviceTrippingUnitTypeEnum)Enum.Parse(typeof(IfcProtectiveDeviceTrippingUnitTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProtectiveDeviceTrippingUnit other)
	{
		return this == other;
	}
}
