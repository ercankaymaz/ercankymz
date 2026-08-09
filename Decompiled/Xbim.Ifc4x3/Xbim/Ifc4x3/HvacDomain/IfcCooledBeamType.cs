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

[ExpressType("IfcCooledBeamType", 367)]
public class IfcCooledBeamType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCooledBeamType>, IIfcCooledBeamType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcCooledBeamTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCooledBeamTypeEnum PredefinedType
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
			SetValue(delegate(IfcCooledBeamTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCooledBeamType), 10)]
	Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum IIfcCooledBeamType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCooledBeamTypeEnum.ACTIVE => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.ACTIVE, 
				IfcCooledBeamTypeEnum.PASSIVE => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.PASSIVE, 
				IfcCooledBeamTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.USERDEFINED, 
				IfcCooledBeamTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.ACTIVE:
				PredefinedType = IfcCooledBeamTypeEnum.ACTIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.PASSIVE:
				PredefinedType = IfcCooledBeamTypeEnum.PASSIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.USERDEFINED:
				PredefinedType = IfcCooledBeamTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.NOTDEFINED:
				PredefinedType = IfcCooledBeamTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCooledBeamType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCooledBeamTypeEnum)Enum.Parse(typeof(IfcCooledBeamTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCooledBeamType other)
	{
		return this == other;
	}
}
