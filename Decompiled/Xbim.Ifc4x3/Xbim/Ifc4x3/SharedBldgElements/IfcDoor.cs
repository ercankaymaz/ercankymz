using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcDoor", 213)]
public class IfcDoor : IfcBuiltElement, IIfcDoor, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDoor>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _overallHeight;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _overallWidth;

	private IfcDoorTypeEnum? _predefinedType;

	private IfcDoorTypeOperationEnum? _operationType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedOperationType;

	[CrossSchemaAttribute(typeof(IIfcDoor), 9)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoor.OverallHeight
	{
		get
		{
			if (!OverallHeight.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallHeight.Value);
		}
		set
		{
			OverallHeight = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoor), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoor.OverallWidth
	{
		get
		{
			if (!OverallWidth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallWidth.Value);
		}
		set
		{
			OverallWidth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoor), 11)]
	Xbim.Ifc4.Interfaces.IfcDoorTypeEnum? IIfcDoor.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDoorTypeEnum.BOOM_BARRIER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeEnum>(), 
				IfcDoorTypeEnum.DOOR => Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.DOOR, 
				IfcDoorTypeEnum.GATE => Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.GATE, 
				IfcDoorTypeEnum.TRAPDOOR => Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.TRAPDOOR, 
				IfcDoorTypeEnum.TURNSTILE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeEnum>(), 
				IfcDoorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.USERDEFINED, 
				IfcDoorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.DOOR:
				PredefinedType = IfcDoorTypeEnum.DOOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.GATE:
				PredefinedType = IfcDoorTypeEnum.GATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.TRAPDOOR:
				PredefinedType = IfcDoorTypeEnum.TRAPDOOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.USERDEFINED:
				PredefinedType = IfcDoorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeEnum.NOTDEFINED:
				PredefinedType = IfcDoorTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoor), 12)]
	Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum? IIfcDoor.OperationType
	{
		get
		{
			return OperationType switch
			{
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_DOUBLE_SWING => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_DOUBLE_SWING, 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_FOLDING => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_FOLDING, 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_LIFTING_VERTICAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum>(), 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING, 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT, 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT, 
				IfcDoorTypeOperationEnum.DOUBLE_DOOR_SLIDING => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SLIDING, 
				IfcDoorTypeOperationEnum.DOUBLE_SWING_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_SWING_LEFT, 
				IfcDoorTypeOperationEnum.DOUBLE_SWING_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_SWING_RIGHT, 
				IfcDoorTypeOperationEnum.FOLDING_TO_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.FOLDING_TO_LEFT, 
				IfcDoorTypeOperationEnum.FOLDING_TO_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.FOLDING_TO_RIGHT, 
				IfcDoorTypeOperationEnum.LIFTING_HORIZONTAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum>(), 
				IfcDoorTypeOperationEnum.LIFTING_VERTICAL_LEFT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum>(), 
				IfcDoorTypeOperationEnum.LIFTING_VERTICAL_RIGHT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum>(), 
				IfcDoorTypeOperationEnum.REVOLVING => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.REVOLVING, 
				IfcDoorTypeOperationEnum.REVOLVING_VERTICAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum>(), 
				IfcDoorTypeOperationEnum.ROLLINGUP => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.ROLLINGUP, 
				IfcDoorTypeOperationEnum.SINGLE_SWING_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SINGLE_SWING_LEFT, 
				IfcDoorTypeOperationEnum.SINGLE_SWING_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SINGLE_SWING_RIGHT, 
				IfcDoorTypeOperationEnum.SLIDING_TO_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SLIDING_TO_LEFT, 
				IfcDoorTypeOperationEnum.SLIDING_TO_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SLIDING_TO_RIGHT, 
				IfcDoorTypeOperationEnum.SWING_FIXED_LEFT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SWING_FIXED_LEFT, 
				IfcDoorTypeOperationEnum.SWING_FIXED_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SWING_FIXED_RIGHT, 
				IfcDoorTypeOperationEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.USERDEFINED, 
				IfcDoorTypeOperationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SINGLE_SWING_LEFT:
				OperationType = IfcDoorTypeOperationEnum.SINGLE_SWING_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SINGLE_SWING_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.SINGLE_SWING_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_SWING_LEFT:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_SWING_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_SWING_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_SWING_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_DOUBLE_SWING:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_DOUBLE_SWING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SLIDING_TO_LEFT:
				OperationType = IfcDoorTypeOperationEnum.SLIDING_TO_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SLIDING_TO_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.SLIDING_TO_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_SLIDING:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_SLIDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.FOLDING_TO_LEFT:
				OperationType = IfcDoorTypeOperationEnum.FOLDING_TO_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.FOLDING_TO_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.FOLDING_TO_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.DOUBLE_DOOR_FOLDING:
				OperationType = IfcDoorTypeOperationEnum.DOUBLE_DOOR_FOLDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.REVOLVING:
				OperationType = IfcDoorTypeOperationEnum.REVOLVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.ROLLINGUP:
				OperationType = IfcDoorTypeOperationEnum.ROLLINGUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SWING_FIXED_LEFT:
				OperationType = IfcDoorTypeOperationEnum.SWING_FIXED_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.SWING_FIXED_RIGHT:
				OperationType = IfcDoorTypeOperationEnum.SWING_FIXED_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.USERDEFINED:
				OperationType = IfcDoorTypeOperationEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorTypeOperationEnum.NOTDEFINED:
				OperationType = IfcDoorTypeOperationEnum.NOTDEFINED;
				break;
			case null:
				OperationType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoor), 13)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDoor.UserDefinedOperationType
	{
		get
		{
			if (!UserDefinedOperationType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedOperationType.Value);
		}
		set
		{
			UserDefinedOperationType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? OverallHeight
	{
		get
		{
			if (_activated)
			{
				return _overallHeight;
			}
			Activate();
			return _overallHeight;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? OverallWidth
	{
		get
		{
			if (_activated)
			{
				return _overallWidth;
			}
			Activate();
			return _overallWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDoorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDoorTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 38)]
	public IfcDoorTypeOperationEnum? OperationType
	{
		get
		{
			if (_activated)
			{
				return _operationType;
			}
			Activate();
			return _operationType;
		}
		set
		{
			SetValue(delegate(IfcDoorTypeOperationEnum? v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 39)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedOperationType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedOperationType;
			}
			Activate();
			return _userDefinedOperationType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedOperationType = v;
			}, _userDefinedOperationType, value, "UserDefinedOperationType", 13);
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

	internal IfcDoor(IModel model, int label, bool activated)
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
			_overallHeight = value.RealVal;
			break;
		case 9:
			_overallWidth = value.RealVal;
			break;
		case 10:
			_predefinedType = (IfcDoorTypeEnum)Enum.Parse(typeof(IfcDoorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_operationType = (IfcDoorTypeOperationEnum)Enum.Parse(typeof(IfcDoorTypeOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 12:
			_userDefinedOperationType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoor other)
	{
		return this == other;
	}
}
