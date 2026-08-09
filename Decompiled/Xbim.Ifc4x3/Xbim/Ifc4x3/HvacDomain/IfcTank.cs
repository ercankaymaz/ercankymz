using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcTank", 1293)]
public class IfcTank : IfcFlowStorageDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTank>, IIfcTank, IIfcFlowStorageDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcTankTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcTankTypeEnum? PredefinedType
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
			SetValue(delegate(IfcTankTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcTank), 9)]
	Xbim.Ifc4.Interfaces.IfcTankTypeEnum? IIfcTank.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTankTypeEnum.BASIN => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BASIN, 
				IfcTankTypeEnum.BREAKPRESSURE => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BREAKPRESSURE, 
				IfcTankTypeEnum.EXPANSION => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.EXPANSION, 
				IfcTankTypeEnum.FEEDANDEXPANSION => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.FEEDANDEXPANSION, 
				IfcTankTypeEnum.OILRETENTIONTRAY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTankTypeEnum>(), 
				IfcTankTypeEnum.PRESSUREVESSEL => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.PRESSUREVESSEL, 
				IfcTankTypeEnum.STORAGE => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.STORAGE, 
				IfcTankTypeEnum.VESSEL => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.VESSEL, 
				IfcTankTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED, 
				IfcTankTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTankTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BASIN:
				PredefinedType = IfcTankTypeEnum.BASIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BREAKPRESSURE:
				PredefinedType = IfcTankTypeEnum.BREAKPRESSURE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.EXPANSION:
				PredefinedType = IfcTankTypeEnum.EXPANSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.FEEDANDEXPANSION:
				PredefinedType = IfcTankTypeEnum.FEEDANDEXPANSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.PRESSUREVESSEL:
				PredefinedType = IfcTankTypeEnum.PRESSUREVESSEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.STORAGE:
				PredefinedType = IfcTankTypeEnum.STORAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.VESSEL:
				PredefinedType = IfcTankTypeEnum.VESSEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.NOTDEFINED:
				PredefinedType = IfcTankTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcTank(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTankTypeEnum)Enum.Parse(typeof(IfcTankTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTank other)
	{
		return this == other;
	}
}
