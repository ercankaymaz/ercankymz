using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcDoorStyle", 492)]
public class IfcDoorStyle : Xbim.Ifc2x3.Kernel.IfcTypeProduct, IIfcDoorStyle, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDoorStyle>
{
	private IfcDoorStyleOperationEnum _operationType;

	private IfcDoorStyleConstructionEnum _constructionType;

	private bool _parameterTakesPrecedence;

	private bool _sizeable;

	[CrossSchemaAttribute(typeof(IIfcDoorStyle), 9)]
	Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum IIfcDoorStyle.OperationType
	{
		get
		{
			return OperationType switch
			{
				IfcDoorStyleOperationEnum.SINGLE_SWING_LEFT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SINGLE_SWING_LEFT, 
				IfcDoorStyleOperationEnum.SINGLE_SWING_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SINGLE_SWING_RIGHT, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT, 
				IfcDoorStyleOperationEnum.DOUBLE_SWING_LEFT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_SWING_LEFT, 
				IfcDoorStyleOperationEnum.DOUBLE_SWING_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_SWING_RIGHT, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_DOUBLE_SWING => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_DOUBLE_SWING, 
				IfcDoorStyleOperationEnum.SLIDING_TO_LEFT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SLIDING_TO_LEFT, 
				IfcDoorStyleOperationEnum.SLIDING_TO_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SLIDING_TO_RIGHT, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_SLIDING => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SLIDING, 
				IfcDoorStyleOperationEnum.FOLDING_TO_LEFT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.FOLDING_TO_LEFT, 
				IfcDoorStyleOperationEnum.FOLDING_TO_RIGHT => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.FOLDING_TO_RIGHT, 
				IfcDoorStyleOperationEnum.DOUBLE_DOOR_FOLDING => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_FOLDING, 
				IfcDoorStyleOperationEnum.REVOLVING => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.REVOLVING, 
				IfcDoorStyleOperationEnum.ROLLINGUP => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.ROLLINGUP, 
				IfcDoorStyleOperationEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.USERDEFINED, 
				IfcDoorStyleOperationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SINGLE_SWING_LEFT:
				OperationType = IfcDoorStyleOperationEnum.SINGLE_SWING_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SINGLE_SWING_RIGHT:
				OperationType = IfcDoorStyleOperationEnum.SINGLE_SWING_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_SWING_LEFT:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_SWING_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_SWING_RIGHT:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_SWING_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_DOUBLE_SWING:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_DOUBLE_SWING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SLIDING_TO_LEFT:
				OperationType = IfcDoorStyleOperationEnum.SLIDING_TO_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.SLIDING_TO_RIGHT:
				OperationType = IfcDoorStyleOperationEnum.SLIDING_TO_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_SLIDING:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_SLIDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.FOLDING_TO_LEFT:
				OperationType = IfcDoorStyleOperationEnum.FOLDING_TO_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.FOLDING_TO_RIGHT:
				OperationType = IfcDoorStyleOperationEnum.FOLDING_TO_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.DOUBLE_DOOR_FOLDING:
				OperationType = IfcDoorStyleOperationEnum.DOUBLE_DOOR_FOLDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.REVOLVING:
				OperationType = IfcDoorStyleOperationEnum.REVOLVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.ROLLINGUP:
				OperationType = IfcDoorStyleOperationEnum.ROLLINGUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.USERDEFINED:
				OperationType = IfcDoorStyleOperationEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleOperationEnum.NOTDEFINED:
				OperationType = IfcDoorStyleOperationEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorStyle), 10)]
	Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum IIfcDoorStyle.ConstructionType
	{
		get
		{
			return ConstructionType switch
			{
				IfcDoorStyleConstructionEnum.ALUMINIUM => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM, 
				IfcDoorStyleConstructionEnum.HIGH_GRADE_STEEL => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.HIGH_GRADE_STEEL, 
				IfcDoorStyleConstructionEnum.STEEL => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.STEEL, 
				IfcDoorStyleConstructionEnum.WOOD => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.WOOD, 
				IfcDoorStyleConstructionEnum.ALUMINIUM_WOOD => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM_WOOD, 
				IfcDoorStyleConstructionEnum.ALUMINIUM_PLASTIC => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM_PLASTIC, 
				IfcDoorStyleConstructionEnum.PLASTIC => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.PLASTIC, 
				IfcDoorStyleConstructionEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.USERDEFINED, 
				IfcDoorStyleConstructionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM:
				ConstructionType = IfcDoorStyleConstructionEnum.ALUMINIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.HIGH_GRADE_STEEL:
				ConstructionType = IfcDoorStyleConstructionEnum.HIGH_GRADE_STEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.STEEL:
				ConstructionType = IfcDoorStyleConstructionEnum.STEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.WOOD:
				ConstructionType = IfcDoorStyleConstructionEnum.WOOD;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM_WOOD:
				ConstructionType = IfcDoorStyleConstructionEnum.ALUMINIUM_WOOD;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.ALUMINIUM_PLASTIC:
				ConstructionType = IfcDoorStyleConstructionEnum.ALUMINIUM_PLASTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.PLASTIC:
				ConstructionType = IfcDoorStyleConstructionEnum.PLASTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.USERDEFINED:
				ConstructionType = IfcDoorStyleConstructionEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorStyleConstructionEnum.NOTDEFINED:
				ConstructionType = IfcDoorStyleConstructionEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorStyle), 11)]
	IfcBoolean IIfcDoorStyle.ParameterTakesPrecedence
	{
		get
		{
			return new IfcBoolean(ParameterTakesPrecedence);
		}
		set
		{
			ParameterTakesPrecedence = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorStyle), 12)]
	IfcBoolean IIfcDoorStyle.Sizeable
	{
		get
		{
			return new IfcBoolean(Sizeable);
		}
		set
		{
			Sizeable = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 14)]
	public IfcDoorStyleOperationEnum OperationType
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
			SetValue(delegate(IfcDoorStyleOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcDoorStyleConstructionEnum ConstructionType
	{
		get
		{
			if (_activated)
			{
				return _constructionType;
			}
			Activate();
			return _constructionType;
		}
		set
		{
			SetValue(delegate(IfcDoorStyleConstructionEnum v)
			{
				_constructionType = v;
			}, _constructionType, value, "ConstructionType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public bool ParameterTakesPrecedence
	{
		get
		{
			if (_activated)
			{
				return _parameterTakesPrecedence;
			}
			Activate();
			return _parameterTakesPrecedence;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_parameterTakesPrecedence = v;
			}, _parameterTakesPrecedence, value, "ParameterTakesPrecedence", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public bool Sizeable
	{
		get
		{
			if (_activated)
			{
				return _sizeable;
			}
			Activate();
			return _sizeable;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_sizeable = v;
			}, _sizeable, value, "Sizeable", 12);
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

	internal IfcDoorStyle(IModel model, int label, bool activated)
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
			_operationType = (IfcDoorStyleOperationEnum)Enum.Parse(typeof(IfcDoorStyleOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_constructionType = (IfcDoorStyleConstructionEnum)Enum.Parse(typeof(IfcDoorStyleConstructionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_parameterTakesPrecedence = value.BooleanVal;
			break;
		case 11:
			_sizeable = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoorStyle other)
	{
		return this == other;
	}
}
