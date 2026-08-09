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

[ExpressType("IfcWindowStyle", 345)]
public class IfcWindowStyle : Xbim.Ifc2x3.Kernel.IfcTypeProduct, IIfcWindowStyle, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindowStyle>
{
	private IfcWindowStyleConstructionEnum _constructionType;

	private IfcWindowStyleOperationEnum _operationType;

	private bool _parameterTakesPrecedence;

	private bool _sizeable;

	[CrossSchemaAttribute(typeof(IIfcWindowStyle), 9)]
	Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum IIfcWindowStyle.ConstructionType
	{
		get
		{
			return ConstructionType switch
			{
				IfcWindowStyleConstructionEnum.ALUMINIUM => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.ALUMINIUM, 
				IfcWindowStyleConstructionEnum.HIGH_GRADE_STEEL => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.HIGH_GRADE_STEEL, 
				IfcWindowStyleConstructionEnum.STEEL => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.STEEL, 
				IfcWindowStyleConstructionEnum.WOOD => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.WOOD, 
				IfcWindowStyleConstructionEnum.ALUMINIUM_WOOD => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.ALUMINIUM_WOOD, 
				IfcWindowStyleConstructionEnum.PLASTIC => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.PLASTIC, 
				IfcWindowStyleConstructionEnum.OTHER_CONSTRUCTION => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.OTHER_CONSTRUCTION, 
				IfcWindowStyleConstructionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.ALUMINIUM:
				ConstructionType = IfcWindowStyleConstructionEnum.ALUMINIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.HIGH_GRADE_STEEL:
				ConstructionType = IfcWindowStyleConstructionEnum.HIGH_GRADE_STEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.STEEL:
				ConstructionType = IfcWindowStyleConstructionEnum.STEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.WOOD:
				ConstructionType = IfcWindowStyleConstructionEnum.WOOD;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.ALUMINIUM_WOOD:
				ConstructionType = IfcWindowStyleConstructionEnum.ALUMINIUM_WOOD;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.PLASTIC:
				ConstructionType = IfcWindowStyleConstructionEnum.PLASTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.OTHER_CONSTRUCTION:
				ConstructionType = IfcWindowStyleConstructionEnum.OTHER_CONSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleConstructionEnum.NOTDEFINED:
				ConstructionType = IfcWindowStyleConstructionEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowStyle), 10)]
	Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum IIfcWindowStyle.OperationType
	{
		get
		{
			return OperationType switch
			{
				IfcWindowStyleOperationEnum.SINGLE_PANEL => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.SINGLE_PANEL, 
				IfcWindowStyleOperationEnum.DOUBLE_PANEL_VERTICAL => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.DOUBLE_PANEL_VERTICAL, 
				IfcWindowStyleOperationEnum.DOUBLE_PANEL_HORIZONTAL => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.DOUBLE_PANEL_HORIZONTAL, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_VERTICAL => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_VERTICAL, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_BOTTOM => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_BOTTOM, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_TOP => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_TOP, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_LEFT => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_LEFT, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_RIGHT => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_RIGHT, 
				IfcWindowStyleOperationEnum.TRIPLE_PANEL_HORIZONTAL => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_HORIZONTAL, 
				IfcWindowStyleOperationEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.USERDEFINED, 
				IfcWindowStyleOperationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.SINGLE_PANEL:
				OperationType = IfcWindowStyleOperationEnum.SINGLE_PANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.DOUBLE_PANEL_VERTICAL:
				OperationType = IfcWindowStyleOperationEnum.DOUBLE_PANEL_VERTICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.DOUBLE_PANEL_HORIZONTAL:
				OperationType = IfcWindowStyleOperationEnum.DOUBLE_PANEL_HORIZONTAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_VERTICAL:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_VERTICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_BOTTOM:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_BOTTOM;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_TOP:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_TOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_LEFT:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_RIGHT:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.TRIPLE_PANEL_HORIZONTAL:
				OperationType = IfcWindowStyleOperationEnum.TRIPLE_PANEL_HORIZONTAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.USERDEFINED:
				OperationType = IfcWindowStyleOperationEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowStyleOperationEnum.NOTDEFINED:
				OperationType = IfcWindowStyleOperationEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowStyle), 11)]
	IfcBoolean IIfcWindowStyle.ParameterTakesPrecedence
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

	[CrossSchemaAttribute(typeof(IIfcWindowStyle), 12)]
	IfcBoolean IIfcWindowStyle.Sizeable
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
	public IfcWindowStyleConstructionEnum ConstructionType
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
			SetValue(delegate(IfcWindowStyleConstructionEnum v)
			{
				_constructionType = v;
			}, _constructionType, value, "ConstructionType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcWindowStyleOperationEnum OperationType
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
			SetValue(delegate(IfcWindowStyleOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 10);
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

	internal IfcWindowStyle(IModel model, int label, bool activated)
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
			_constructionType = (IfcWindowStyleConstructionEnum)Enum.Parse(typeof(IfcWindowStyleConstructionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_operationType = (IfcWindowStyleOperationEnum)Enum.Parse(typeof(IfcWindowStyleOperationEnum), value.EnumVal, ignoreCase: true);
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

	public bool Equals(IfcWindowStyle other)
	{
		return this == other;
	}
}
