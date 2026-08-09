using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.BuildingcontrolsDomain;

[ExpressType("IfcFlowInstrumentType", 196)]
public class IfcFlowInstrumentType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFlowInstrumentType>, IIfcFlowInstrumentType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcFlowInstrumentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcFlowInstrumentTypeEnum PredefinedType
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
			SetValue(delegate(IfcFlowInstrumentTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFlowInstrumentType), 10)]
	Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum IIfcFlowInstrumentType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFlowInstrumentTypeEnum.PRESSUREGAUGE => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PRESSUREGAUGE, 
				IfcFlowInstrumentTypeEnum.THERMOMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.THERMOMETER, 
				IfcFlowInstrumentTypeEnum.AMMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.AMMETER, 
				IfcFlowInstrumentTypeEnum.FREQUENCYMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.FREQUENCYMETER, 
				IfcFlowInstrumentTypeEnum.POWERFACTORMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.POWERFACTORMETER, 
				IfcFlowInstrumentTypeEnum.PHASEANGLEMETER => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.PHASEANGLEMETER, 
				IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_PEAK, 
				IfcFlowInstrumentTypeEnum.VOLTMETER_RMS => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.VOLTMETER_RMS, 
				IfcFlowInstrumentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.USERDEFINED, 
				IfcFlowInstrumentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowInstrumentTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFlowInstrumentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFlowInstrumentTypeEnum)Enum.Parse(typeof(IfcFlowInstrumentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFlowInstrumentType other)
	{
		return this == other;
	}
}
