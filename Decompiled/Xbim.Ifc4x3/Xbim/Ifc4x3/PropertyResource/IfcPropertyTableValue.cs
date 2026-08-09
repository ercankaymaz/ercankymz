using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyTableValue", 557)]
public class IfcPropertyTableValue : IfcSimpleProperty, IIfcPropertyTableValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyTableValue>
{
	private IItemSet<IIfcValue> _definingValuesIfc4;

	private IItemSet<IIfcValue> _definedValuesIfc4;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> _definingValues;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> _definedValues;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _expression;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _definingUnit;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _definedUnit;

	private IfcCurveInterpolationEnum? _curveInterpolation;

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 3)]
	IItemSet<IIfcValue> IIfcPropertyTableValue.DefiningValues => _definingValuesIfc4 ?? (_definingValuesIfc4 = new ExtendedItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue, IIfcValue>(DefiningValues, new ItemSet<IIfcValue>(this, 0, -3), (Xbim.Ifc4x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 4)]
	IItemSet<IIfcValue> IIfcPropertyTableValue.DefinedValues => _definedValuesIfc4 ?? (_definedValuesIfc4 = new ExtendedItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue, IIfcValue>(DefinedValues, new ItemSet<IIfcValue>(this, 0, -4), (Xbim.Ifc4x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcPropertyTableValue.Expression
	{
		get
		{
			if (!Expression.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Expression.Value);
		}
		set
		{
			Expression = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 6)]
	IIfcUnit IIfcPropertyTableValue.DefiningUnit
	{
		get
		{
			if (DefiningUnit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = DefiningUnit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = DefiningUnit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = DefiningUnit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
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
				DefiningUnit = null;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				DefiningUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				DefiningUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				DefiningUnit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 7)]
	IIfcUnit IIfcPropertyTableValue.DefinedUnit
	{
		get
		{
			if (DefinedUnit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = DefinedUnit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = DefinedUnit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = DefinedUnit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
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
				DefinedUnit = null;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				DefinedUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				DefinedUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				DefinedUnit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 8)]
	Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum? IIfcPropertyTableValue.CurveInterpolation
	{
		get
		{
			return CurveInterpolation switch
			{
				IfcCurveInterpolationEnum.LINEAR => Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LINEAR, 
				IfcCurveInterpolationEnum.LOG_LINEAR => Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LOG_LINEAR, 
				IfcCurveInterpolationEnum.LOG_LOG => Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LOG_LOG, 
				IfcCurveInterpolationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LINEAR:
				CurveInterpolation = IfcCurveInterpolationEnum.LINEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LOG_LINEAR:
				CurveInterpolation = IfcCurveInterpolationEnum.LOG_LINEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.LOG_LOG:
				CurveInterpolation = IfcCurveInterpolationEnum.LOG_LOG;
				break;
			case Xbim.Ifc4.Interfaces.IfcCurveInterpolationEnum.NOTDEFINED:
				CurveInterpolation = IfcCurveInterpolationEnum.NOTDEFINED;
				break;
			case null:
				CurveInterpolation = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> DefiningValues
	{
		get
		{
			if (_activated)
			{
				return _definingValues;
			}
			Activate();
			return _definingValues;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> DefinedValues
	{
		get
		{
			if (_activated)
			{
				return _definedValues;
			}
			Activate();
			return _definedValues;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Expression
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnit DefiningUnit
	{
		get
		{
			if (_activated)
			{
				return _definingUnit;
			}
			Activate();
			return _definingUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_definingUnit = v;
			}, _definingUnit, value, "DefiningUnit", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnit DefinedUnit
	{
		get
		{
			if (_activated)
			{
				return _definedUnit;
			}
			Activate();
			return _definedUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_definedUnit = v;
			}, _definedUnit, value, "DefinedUnit", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCurveInterpolationEnum? CurveInterpolation
	{
		get
		{
			if (_activated)
			{
				return _curveInterpolation;
			}
			Activate();
			return _curveInterpolation;
		}
		set
		{
			SetValue(delegate(IfcCurveInterpolationEnum? v)
			{
				_curveInterpolation = v;
			}, _curveInterpolation, value, "CurveInterpolation", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DefiningUnit != null)
			{
				yield return DefiningUnit;
			}
			if (DefinedUnit != null)
			{
				yield return DefinedUnit;
			}
		}
	}

	internal IfcPropertyTableValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_definingValues = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue>(this, 0, 3);
		_definedValues = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_definingValues.InternalAdd((Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 3:
			_definedValues.InternalAdd((Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 4:
			_expression = value.StringVal;
			break;
		case 5:
			_definingUnit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 6:
			_definedUnit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 7:
			_curveInterpolation = (IfcCurveInterpolationEnum)Enum.Parse(typeof(IfcCurveInterpolationEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyTableValue other)
	{
		return this == other;
	}
}
