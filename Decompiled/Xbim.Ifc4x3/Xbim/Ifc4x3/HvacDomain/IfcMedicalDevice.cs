using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcMedicalDevice", 1212)]
public class IfcMedicalDevice : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMedicalDevice>, IIfcMedicalDevice, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcMedicalDeviceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcMedicalDeviceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcMedicalDeviceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcMedicalDevice), 9)]
	Xbim.Ifc4.Interfaces.IfcMedicalDeviceTypeEnum? IIfcMedicalDevice.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcMedicalDevice(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMedicalDeviceTypeEnum)Enum.Parse(typeof(IfcMedicalDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMedicalDevice other)
	{
		return this == other;
	}
}
