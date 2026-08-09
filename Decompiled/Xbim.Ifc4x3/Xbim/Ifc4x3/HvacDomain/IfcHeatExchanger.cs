using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcHeatExchanger", 1187)]
public class IfcHeatExchanger : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcHeatExchanger>, IIfcHeatExchanger, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcHeatExchangerTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcHeatExchangerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcHeatExchangerTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcHeatExchanger), 9)]
	Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum? IIfcHeatExchanger.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcHeatExchangerTypeEnum.PLATE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE, 
				IfcHeatExchangerTypeEnum.SHELLANDTUBE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE, 
				IfcHeatExchangerTypeEnum.TURNOUTHEATING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum>(), 
				IfcHeatExchangerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED, 
				IfcHeatExchangerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE:
				PredefinedType = IfcHeatExchangerTypeEnum.PLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE:
				PredefinedType = IfcHeatExchangerTypeEnum.SHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcHeatExchanger(IModel model, int label, bool activated)
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
			_predefinedType = (IfcHeatExchangerTypeEnum)Enum.Parse(typeof(IfcHeatExchangerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHeatExchanger other)
	{
		return this == other;
	}
}
