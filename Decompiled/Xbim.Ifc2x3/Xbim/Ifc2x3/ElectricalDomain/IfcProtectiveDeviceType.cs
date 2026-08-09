using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcProtectiveDeviceType", 550)]
public class IfcProtectiveDeviceType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProtectiveDeviceType>, IIfcProtectiveDeviceType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcProtectiveDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcProtectiveDeviceTypeEnum PredefinedType
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
			SetValue(delegate(IfcProtectiveDeviceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcProtectiveDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum IIfcProtectiveDeviceType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR;
			case IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER;
			case IfcProtectiveDeviceTypeEnum.EARTHFAILUREDEVICE:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER;
			case IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER;
			case IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH;
			case IfcProtectiveDeviceTypeEnum.VARISTOR:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.VARISTOR;
			case IfcProtectiveDeviceTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.USERDEFINED;
			}
			case IfcProtectiveDeviceTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER:
				PredefinedType = IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER:
				base.ElementType = value.ToString();
				PredefinedType = IfcProtectiveDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHINGSWITCH:
				base.ElementType = value.ToString();
				PredefinedType = IfcProtectiveDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR:
				PredefinedType = IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER:
				PredefinedType = IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH:
				PredefinedType = IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.VARISTOR:
				PredefinedType = IfcProtectiveDeviceTypeEnum.VARISTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcProtectiveDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcProtectiveDeviceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcProtectiveDeviceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcProtectiveDeviceTypeEnum)Enum.Parse(typeof(IfcProtectiveDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProtectiveDeviceType other)
	{
		return this == other;
	}
}
