using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcProtectiveDevice", 1235)]
public class IfcProtectiveDevice : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProtectiveDevice>, IIfcProtectiveDevice, IIfcFlowController, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcProtectiveDeviceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcProtectiveDeviceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcProtectiveDeviceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcProtectiveDevice), 9)]
	Xbim.Ifc4.Interfaces.IfcProtectiveDeviceTypeEnum? IIfcProtectiveDevice.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcProtectiveDevice(IModel model, int label, bool activated)
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
			_predefinedType = (IfcProtectiveDeviceTypeEnum)Enum.Parse(typeof(IfcProtectiveDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProtectiveDevice other)
	{
		return this == other;
	}
}
