using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcFlowMeterType", 366)]
public class IfcFlowMeterType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFlowMeterType>, IIfcFlowMeterType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcFlowMeterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcFlowMeterTypeEnum PredefinedType
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
			SetValue(delegate(IfcFlowMeterTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcFlowMeterType), 10)]
	Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum IIfcFlowMeterType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFlowMeterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFlowMeterTypeEnum)Enum.Parse(typeof(IfcFlowMeterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFlowMeterType other)
	{
		return this == other;
	}
}
