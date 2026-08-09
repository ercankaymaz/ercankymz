using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcProtectiveDeviceType", 550)]
public class IfcProtectiveDeviceType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProtectiveDeviceType>, IIfcProtectiveDeviceType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcProtectiveDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
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

	[CrossSchemaAttribute(typeof(IIfcProtectiveDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum IIfcProtectiveDeviceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcProtectiveDeviceTypeEnum.ANTI_ARCING_DEVICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum>(), 
				IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER, 
				IfcProtectiveDeviceTypeEnum.EARTHINGSWITCH => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHINGSWITCH, 
				IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER, 
				IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.FUSEDISCONNECTOR, 
				IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTCIRCUITBREAKER, 
				IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.RESIDUALCURRENTSWITCH, 
				IfcProtectiveDeviceTypeEnum.SPARKGAP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum>(), 
				IfcProtectiveDeviceTypeEnum.VARISTOR => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.VARISTOR, 
				IfcProtectiveDeviceTypeEnum.VOLTAGELIMITER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum>(), 
				IfcProtectiveDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.USERDEFINED, 
				IfcProtectiveDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER:
				PredefinedType = IfcProtectiveDeviceTypeEnum.CIRCUITBREAKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER:
				PredefinedType = IfcProtectiveDeviceTypeEnum.EARTHLEAKAGECIRCUITBREAKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum.EARTHINGSWITCH:
				PredefinedType = IfcProtectiveDeviceTypeEnum.EARTHINGSWITCH;
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
