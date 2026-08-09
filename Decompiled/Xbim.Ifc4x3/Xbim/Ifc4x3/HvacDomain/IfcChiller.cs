using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcChiller", 1119)]
public class IfcChiller : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcChiller>, IIfcChiller, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcChillerTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcChillerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcChillerTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcChiller), 9)]
	Xbim.Ifc4.Interfaces.IfcChillerTypeEnum? IIfcChiller.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcChillerTypeEnum.AIRCOOLED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.AIRCOOLED, 
				IfcChillerTypeEnum.HEATRECOVERY => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.HEATRECOVERY, 
				IfcChillerTypeEnum.WATERCOOLED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.WATERCOOLED, 
				IfcChillerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.USERDEFINED, 
				IfcChillerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.AIRCOOLED:
				PredefinedType = IfcChillerTypeEnum.AIRCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.WATERCOOLED:
				PredefinedType = IfcChillerTypeEnum.WATERCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.HEATRECOVERY:
				PredefinedType = IfcChillerTypeEnum.HEATRECOVERY;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.USERDEFINED:
				PredefinedType = IfcChillerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.NOTDEFINED:
				PredefinedType = IfcChillerTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcChiller(IModel model, int label, bool activated)
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
			_predefinedType = (IfcChillerTypeEnum)Enum.Parse(typeof(IfcChillerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcChiller other)
	{
		return this == other;
	}
}
