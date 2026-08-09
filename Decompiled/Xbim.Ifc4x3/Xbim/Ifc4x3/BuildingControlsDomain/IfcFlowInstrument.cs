using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.BuildingControlsDomain;

[ExpressType("IfcFlowInstrument", 1181)]
public class IfcFlowInstrument : IfcDistributionControlElement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFlowInstrument>, IIfcFlowInstrument, IIfcDistributionControlElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcFlowInstrumentTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcFlowInstrumentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFlowInstrumentTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcFlowInstrument), 9)]
	Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum? IIfcFlowInstrument.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFlowInstrumentTypeEnum.AMMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.AMMETER, 
				IfcFlowInstrumentTypeEnum.COMBINED => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum>(), 
				IfcFlowInstrumentTypeEnum.FREQUENCYMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.FREQUENCYMETER, 
				IfcFlowInstrumentTypeEnum.PHASEANGLEMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PHASEANGLEMETER, 
				IfcFlowInstrumentTypeEnum.POWERFACTORMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.POWERFACTORMETER, 
				IfcFlowInstrumentTypeEnum.PRESSUREGAUGE => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PRESSUREGAUGE, 
				IfcFlowInstrumentTypeEnum.THERMOMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.THERMOMETER, 
				IfcFlowInstrumentTypeEnum.VOLTMETER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum>(), 
				IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK, 
				IfcFlowInstrumentTypeEnum.VOLTMETER_RMS => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_RMS, 
				IfcFlowInstrumentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.USERDEFINED, 
				IfcFlowInstrumentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PRESSUREGAUGE:
				PredefinedType = IfcFlowInstrumentTypeEnum.PRESSUREGAUGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.THERMOMETER:
				PredefinedType = IfcFlowInstrumentTypeEnum.THERMOMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.AMMETER:
				PredefinedType = IfcFlowInstrumentTypeEnum.AMMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.FREQUENCYMETER:
				PredefinedType = IfcFlowInstrumentTypeEnum.FREQUENCYMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.POWERFACTORMETER:
				PredefinedType = IfcFlowInstrumentTypeEnum.POWERFACTORMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PHASEANGLEMETER:
				PredefinedType = IfcFlowInstrumentTypeEnum.PHASEANGLEMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK:
				PredefinedType = IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_RMS:
				PredefinedType = IfcFlowInstrumentTypeEnum.VOLTMETER_RMS;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.USERDEFINED:
				PredefinedType = IfcFlowInstrumentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.NOTDEFINED:
				PredefinedType = IfcFlowInstrumentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFlowInstrument(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFlowInstrumentTypeEnum)Enum.Parse(typeof(IfcFlowInstrumentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFlowInstrument other)
	{
		return this == other;
	}
}
