using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCooledBeam", 1141)]
public class IfcCooledBeam : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCooledBeam>, IIfcCooledBeam, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCooledBeamTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCooledBeamTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCooledBeamTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCooledBeam), 9)]
	Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum? IIfcCooledBeam.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCooledBeamTypeEnum.ACTIVE => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.ACTIVE, 
				IfcCooledBeamTypeEnum.PASSIVE => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.PASSIVE, 
				IfcCooledBeamTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.USERDEFINED, 
				IfcCooledBeamTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCooledBeamTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCooledBeam(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCooledBeamTypeEnum)Enum.Parse(typeof(IfcCooledBeamTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCooledBeam other)
	{
		return this == other;
	}
}
