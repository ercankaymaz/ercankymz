using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcFlowMeter", 1182)]
public class IfcFlowMeter : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFlowMeter>, IIfcFlowMeter, IIfcFlowController, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcFlowMeterTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcFlowMeterTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFlowMeterTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcFlowMeter), 9)]
	Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum? IIfcFlowMeter.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFlowMeterTypeEnum.ENERGYMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.ENERGYMETER, 
				IfcFlowMeterTypeEnum.GASMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.GASMETER, 
				IfcFlowMeterTypeEnum.OILMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.OILMETER, 
				IfcFlowMeterTypeEnum.WATERMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.WATERMETER, 
				IfcFlowMeterTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED, 
				IfcFlowMeterTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.ENERGYMETER:
				PredefinedType = IfcFlowMeterTypeEnum.ENERGYMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.GASMETER:
				PredefinedType = IfcFlowMeterTypeEnum.GASMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.OILMETER:
				PredefinedType = IfcFlowMeterTypeEnum.OILMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.WATERMETER:
				PredefinedType = IfcFlowMeterTypeEnum.WATERMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED:
				PredefinedType = IfcFlowMeterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.NOTDEFINED:
				PredefinedType = IfcFlowMeterTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFlowMeter(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFlowMeterTypeEnum)Enum.Parse(typeof(IfcFlowMeterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFlowMeter other)
	{
		return this == other;
	}
}
