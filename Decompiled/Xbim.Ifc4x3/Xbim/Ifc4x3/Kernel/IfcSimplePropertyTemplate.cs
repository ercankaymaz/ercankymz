using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PropertyResource;
using Xbim.Ifc4x3.UtilityResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcSimplePropertyTemplate", 1267)]
public class IfcSimplePropertyTemplate : IfcPropertyTemplate, IIfcSimplePropertyTemplate, IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcSimplePropertyTemplate>
{
	private IfcSimplePropertyTemplateTypeEnum? _templateType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _primaryMeasureType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _secondaryMeasureType;

	private IfcPropertyEnumeration _enumerators;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _primaryUnit;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _secondaryUnit;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _expression;

	private Xbim.Ifc4x3.UtilityResource.IfcStateEnum? _accessState;

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 5)]
	Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum? IIfcSimplePropertyTemplate.TemplateType
	{
		get
		{
			return TemplateType switch
			{
				IfcSimplePropertyTemplateTypeEnum.P_BOUNDEDVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_BOUNDEDVALUE, 
				IfcSimplePropertyTemplateTypeEnum.P_ENUMERATEDVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_ENUMERATEDVALUE, 
				IfcSimplePropertyTemplateTypeEnum.P_LISTVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_LISTVALUE, 
				IfcSimplePropertyTemplateTypeEnum.P_REFERENCEVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_REFERENCEVALUE, 
				IfcSimplePropertyTemplateTypeEnum.P_SINGLEVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_SINGLEVALUE, 
				IfcSimplePropertyTemplateTypeEnum.P_TABLEVALUE => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_TABLEVALUE, 
				IfcSimplePropertyTemplateTypeEnum.Q_AREA => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_AREA, 
				IfcSimplePropertyTemplateTypeEnum.Q_COUNT => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_COUNT, 
				IfcSimplePropertyTemplateTypeEnum.Q_LENGTH => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_LENGTH, 
				IfcSimplePropertyTemplateTypeEnum.Q_NUMBER => throw new NotImplementedException(), 
				IfcSimplePropertyTemplateTypeEnum.Q_TIME => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_TIME, 
				IfcSimplePropertyTemplateTypeEnum.Q_VOLUME => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_VOLUME, 
				IfcSimplePropertyTemplateTypeEnum.Q_WEIGHT => Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_WEIGHT, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_SINGLEVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_SINGLEVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_ENUMERATEDVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_ENUMERATEDVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_BOUNDEDVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_BOUNDEDVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_LISTVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_LISTVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_TABLEVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_TABLEVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.P_REFERENCEVALUE:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.P_REFERENCEVALUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_LENGTH:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_LENGTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_AREA:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_AREA;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_VOLUME:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_VOLUME;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_COUNT:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_COUNT;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_WEIGHT:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_WEIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcSimplePropertyTemplateTypeEnum.Q_TIME:
				TemplateType = IfcSimplePropertyTemplateTypeEnum.Q_TIME;
				break;
			case null:
				TemplateType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSimplePropertyTemplate.PrimaryMeasureType
	{
		get
		{
			if (!PrimaryMeasureType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(PrimaryMeasureType.Value);
		}
		set
		{
			PrimaryMeasureType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSimplePropertyTemplate.SecondaryMeasureType
	{
		get
		{
			if (!SecondaryMeasureType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(SecondaryMeasureType.Value);
		}
		set
		{
			SecondaryMeasureType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 8)]
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

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 9)]
	IIfcUnit IIfcSimplePropertyTemplate.PrimaryUnit
	{
		get
		{
			if (PrimaryUnit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = PrimaryUnit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = PrimaryUnit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = PrimaryUnit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PrimaryUnit = null;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				PrimaryUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				PrimaryUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				PrimaryUnit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 10)]
	IIfcUnit IIfcSimplePropertyTemplate.SecondaryUnit
	{
		get
		{
			if (SecondaryUnit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = SecondaryUnit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = SecondaryUnit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = SecondaryUnit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SecondaryUnit = null;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				SecondaryUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				SecondaryUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				SecondaryUnit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 11)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSimplePropertyTemplate.Expression
	{
		get
		{
			if (!Expression.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Expression.Value);
		}
		set
		{
			Expression = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSimplePropertyTemplate), 12)]
	Xbim.Ifc4.Interfaces.IfcStateEnum? IIfcSimplePropertyTemplate.AccessState
	{
		get
		{
			return AccessState switch
			{
				Xbim.Ifc4x3.UtilityResource.IfcStateEnum.LOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.LOCKED, 
				Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READONLY => Xbim.Ifc4.Interfaces.IfcStateEnum.READONLY, 
				Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READONLYLOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.READONLYLOCKED, 
				Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READWRITE => Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITE, 
				Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READWRITELOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITELOCKED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITE:
				AccessState = Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READWRITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READONLY:
				AccessState = Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READONLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.LOCKED:
				AccessState = Xbim.Ifc4x3.UtilityResource.IfcStateEnum.LOCKED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITELOCKED:
				AccessState = Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READWRITELOCKED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READONLYLOCKED:
				AccessState = Xbim.Ifc4x3.UtilityResource.IfcStateEnum.READONLYLOCKED;
				break;
			case null:
				AccessState = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? PrimaryMeasureType
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_primaryMeasureType = v;
			}, _primaryMeasureType, value, "PrimaryMeasureType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? SecondaryMeasureType
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcUnit PrimaryUnit
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_primaryUnit = v;
			}, _primaryUnit, value, "PrimaryUnit", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnit SecondaryUnit
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_secondaryUnit = v;
			}, _secondaryUnit, value, "SecondaryUnit", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Expression
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc4x3.UtilityResource.IfcStateEnum? AccessState
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
			SetValue(delegate(Xbim.Ifc4x3.UtilityResource.IfcStateEnum? v)
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
			_primaryUnit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 9:
			_secondaryUnit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 10:
			_expression = value.StringVal;
			break;
		case 11:
			_accessState = (Xbim.Ifc4x3.UtilityResource.IfcStateEnum)Enum.Parse(typeof(Xbim.Ifc4x3.UtilityResource.IfcStateEnum), value.EnumVal, ignoreCase: true);
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
