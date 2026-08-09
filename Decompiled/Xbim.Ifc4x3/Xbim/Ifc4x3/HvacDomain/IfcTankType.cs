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

[ExpressType("IfcTankType", 619)]
public class IfcTankType : IfcFlowStorageDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTankType>, IIfcTankType, IIfcFlowStorageDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcTankTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTankTypeEnum PredefinedType
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
			SetValue(delegate(IfcTankTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcTankType), 10)]
	Xbim.Ifc4.Interfaces.IfcTankTypeEnum IIfcTankType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcTankType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTankTypeEnum)Enum.Parse(typeof(IfcTankTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTankType other)
	{
		return this == other;
	}
}
