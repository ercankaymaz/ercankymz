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

[ExpressType("IfcMedicalDeviceType", 1213)]
public class IfcMedicalDeviceType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMedicalDeviceType>, IIfcMedicalDeviceType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcMedicalDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcMedicalDeviceTypeEnum PredefinedType
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
			SetValue(delegate(IfcMedicalDeviceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcMedicalDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum IIfcMedicalDeviceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcMedicalDeviceTypeEnum.AIRSTATION => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.AIRSTATION, 
				IfcMedicalDeviceTypeEnum.FEEDAIRUNIT => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.FEEDAIRUNIT, 
				IfcMedicalDeviceTypeEnum.OXYGENGENERATOR => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.OXYGENGENERATOR, 
				IfcMedicalDeviceTypeEnum.OXYGENPLANT => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.OXYGENPLANT, 
				IfcMedicalDeviceTypeEnum.VACUUMSTATION => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.VACUUMSTATION, 
				IfcMedicalDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.USERDEFINED, 
				IfcMedicalDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.AIRSTATION:
				PredefinedType = IfcMedicalDeviceTypeEnum.AIRSTATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.FEEDAIRUNIT:
				PredefinedType = IfcMedicalDeviceTypeEnum.FEEDAIRUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.OXYGENGENERATOR:
				PredefinedType = IfcMedicalDeviceTypeEnum.OXYGENGENERATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.OXYGENPLANT:
				PredefinedType = IfcMedicalDeviceTypeEnum.OXYGENPLANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.VACUUMSTATION:
				PredefinedType = IfcMedicalDeviceTypeEnum.VACUUMSTATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcMedicalDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcMedicalDeviceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcMedicalDeviceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMedicalDeviceTypeEnum)Enum.Parse(typeof(IfcMedicalDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMedicalDeviceType other)
	{
		return this == other;
	}
}
