using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcSimplePropertyTemplate", 1267)]
public class IfcSimplePropertyTemplate : IfcPropertyTemplate, IInstantiableEntity, IPersistEntity, IPersist, IIfcSimplePropertyTemplate, IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSimplePropertyTemplate>
{
	private IfcSimplePropertyTemplateTypeEnum? _templateType;

	private IfcLabel? _primaryMeasureType;

	private IfcLabel? _secondaryMeasureType;

	private IfcPropertyEnumeration _enumerators;

	private IfcUnit _primaryUnit;

	private IfcUnit _secondaryUnit;

	private IfcLabel? _expression;

	private IfcStateEnum? _accessState;

	IfcSimplePropertyTemplateTypeEnum? IIfcSimplePropertyTemplate.TemplateType
	{
		get
		{
			return TemplateType;
		}
		set
		{
			TemplateType = value;
		}
	}

	IfcLabel? IIfcSimplePropertyTemplate.PrimaryMeasureType
	{
		get
		{
			return PrimaryMeasureType;
		}
		set
		{
			PrimaryMeasureType = value;
		}
	}

	IfcLabel? IIfcSimplePropertyTemplate.SecondaryMeasureType
	{
		get
		{
			return SecondaryMeasureType;
		}
		set
		{
			SecondaryMeasureType = value;
		}
	}

	IIfcPropertyEnumeration IIfcSimplePropertyTemplate.Enumerators
	{
		get
		{
			return Enumerators;
		}
		set
		{
			Enumerators = value as IfcPropertyEnumeration;
		}
	}

	IIfcUnit IIfcSimplePropertyTemplate.PrimaryUnit
	{
		get
		{
			return PrimaryUnit;
		}
		set
		{
			PrimaryUnit = value as IfcUnit;
		}
	}

	IIfcUnit IIfcSimplePropertyTemplate.SecondaryUnit
	{
		get
		{
			return SecondaryUnit;
		}
		set
		{
			SecondaryUnit = value as IfcUnit;
		}
	}

	IfcLabel? IIfcSimplePropertyTemplate.Expression
	{
		get
		{
			return Expression;
		}
		set
		{
			Expression = value;
		}
	}

	IfcStateEnum? IIfcSimplePropertyTemplate.AccessState
	{
		get
		{
			return AccessState;
		}
		set
		{
			AccessState = value;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcSimplePropertyTemplateTypeEnum? TemplateType
	{
		get
		{
			if (_activated)
			{
				return _templateType;
			}
			Activate();
			return _templateType;
		}
		set
		{
			SetValue(delegate(IfcSimplePropertyTemplateTypeEnum? v)
			{
				_templateType = v;
			}, _templateType, value, "TemplateType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel? PrimaryMeasureType
	{
		get
		{
			if (_activated)
			{
				return _primaryMeasureType;
			}
			Activate();
			return _primaryMeasureType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_primaryMeasureType = v;
			}, _primaryMeasureType, value, "PrimaryMeasureType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcLabel? SecondaryMeasureType
	{
		get
		{
			if (_activated)
			{
				return _secondaryMeasureType;
			}
			Activate();
			return _secondaryMeasureType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_secondaryMeasureType = v;
			}, _secondaryMeasureType, value, "SecondaryMeasureType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcPropertyEnumeration Enumerators
	{
		get
		{
			if (_activated)
			{
				return _enumerators;
			}
			Activate();
			return _enumerators;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPropertyEnumeration v)
			{
				_enumerators = v;
			}, _enumerators, value, "Enumerators", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcUnit PrimaryUnit
	{
		get
		{
			if (_activated)
			{
				return _primaryUnit;
			}
			Activate();
			return _primaryUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_primaryUnit = v;
			}, _primaryUnit, value, "PrimaryUnit", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcUnit SecondaryUnit
	{
		get
		{
			if (_activated)
			{
				return _secondaryUnit;
			}
			Activate();
			return _secondaryUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_secondaryUnit = v;
			}, _secondaryUnit, value, "SecondaryUnit", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcLabel? Expression
	{
		get
		{
			if (_activated)
			{
				return _expression;
			}
			Activate();
			return _expression;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 16)]
	public IfcStateEnum? AccessState
	{
		get
		{
			if (_activated)
			{
				return _accessState;
			}
			Activate();
			return _accessState;
		}
		set
		{
			SetValue(delegate(IfcStateEnum? v)
			{
				_accessState = v;
			}, _accessState, value, "AccessState", 12);
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
			if (Enumerators != null)
			{
				yield return Enumerators;
			}
			if (PrimaryUnit != null)
			{
				yield return PrimaryUnit;
			}
			if (SecondaryUnit != null)
			{
				yield return SecondaryUnit;
			}
		}
	}

	internal IfcSimplePropertyTemplate(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_templateType = (IfcSimplePropertyTemplateTypeEnum)Enum.Parse(typeof(IfcSimplePropertyTemplateTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_primaryMeasureType = value.StringVal;
			break;
		case 6:
			_secondaryMeasureType = value.StringVal;
			break;
		case 7:
			_enumerators = (IfcPropertyEnumeration)value.EntityVal;
			break;
		case 8:
			_primaryUnit = (IfcUnit)value.EntityVal;
			break;
		case 9:
			_secondaryUnit = (IfcUnit)value.EntityVal;
			break;
		case 10:
			_expression = value.StringVal;
			break;
		case 11:
			_accessState = (IfcStateEnum)Enum.Parse(typeof(IfcStateEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSimplePropertyTemplate other)
	{
		return this == other;
	}
}
