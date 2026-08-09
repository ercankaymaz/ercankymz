using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCoolingTower", 1142)]
public class IfcCoolingTower : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoolingTower>, IIfcCoolingTower, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCoolingTowerTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCoolingTowerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCoolingTowerTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCoolingTower), 9)]
	Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum? IIfcCoolingTower.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT, 
				IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT, 
				IfcCoolingTowerTypeEnum.NATURALDRAFT => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NATURALDRAFT, 
				IfcCoolingTowerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.USERDEFINED, 
				IfcCoolingTowerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NATURALDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.NATURALDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.MECHANICALINDUCEDDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT:
				PredefinedType = IfcCoolingTowerTypeEnum.MECHANICALFORCEDDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.USERDEFINED:
				PredefinedType = IfcCoolingTowerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoolingTowerTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoolingTowerTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCoolingTower(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoolingTowerTypeEnum)Enum.Parse(typeof(IfcCoolingTowerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoolingTower other)
	{
		return this == other;
	}
}
