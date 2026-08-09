using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRamp", 414)]
public class IfcRamp : IfcBuiltElement, IIfcRamp, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRamp>
{
	private IfcRampTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRamp), 9)]
	Xbim.Ifc4.Interfaces.IfcRampTypeEnum? IIfcRamp.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRampTypeEnum.HALF_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP, 
				IfcRampTypeEnum.QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.SPIRAL_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP, 
				IfcRampTypeEnum.STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED, 
				IfcRampTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP:
				PredefinedType = IfcRampTypeEnum.STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP:
				PredefinedType = IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.HALF_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP:
				PredefinedType = IfcRampTypeEnum.SPIRAL_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED:
				PredefinedType = IfcRampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED:
				PredefinedType = IfcRampTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcRampTypeEnum? PredefinedType
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
			SetValue(delegate(IfcRampTypeEnum? v)
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

	internal IfcRamp(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRampTypeEnum)Enum.Parse(typeof(IfcRampTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRamp other)
	{
		return this == other;
	}
}
