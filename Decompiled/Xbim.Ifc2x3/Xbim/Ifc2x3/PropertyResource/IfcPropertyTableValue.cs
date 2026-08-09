using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcPropertyTableValue", 557)]
public class IfcPropertyTableValue : IfcSimpleProperty, IIfcPropertyTableValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyTableValue>, IExpressValidatable
{
	public enum IfcPropertyTableValueClause
	{
		WR1,
		WR2,
		WR3
	}

	private IItemSet<IIfcValue> _definingValuesIfc4;

	private IItemSet<IIfcValue> _definedValuesIfc4;

	private IfcCurveInterpolationEnum? _curveInterpolation;

	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> _definingValues;

	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> _definedValues;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _expression;

	private Xbim.Ifc2x3.MeasureResource.IfcUnit _definingUnit;

	private Xbim.Ifc2x3.MeasureResource.IfcUnit _definedUnit;

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 3)]
	IItemSet<IIfcValue> IIfcPropertyTableValue.DefiningValues => _definingValuesIfc4 ?? (_definingValuesIfc4 = new ExtendedItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue, IIfcValue>(DefiningValues, new ItemSet<IIfcValue>(this, 0, -3), (Xbim.Ifc2x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 4)]
	IItemSet<IIfcValue> IIfcPropertyTableValue.DefinedValues => _definedValuesIfc4 ?? (_definedValuesIfc4 = new ExtendedItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue, IIfcValue>(DefinedValues, new ItemSet<IIfcValue>(this, 0, -4), (Xbim.Ifc2x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

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
			Expression = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
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
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = DefiningUnit as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = DefiningUnit as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = DefiningUnit as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
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
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				DefiningUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				DefiningUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
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
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = DefinedUnit as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = DefinedUnit as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = DefinedUnit as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
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
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				DefinedUnit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				DefinedUnit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				DefinedUnit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyTableValue), 8)]
	IfcCurveInterpolationEnum? IIfcPropertyTableValue.CurveInterpolation
	{
		get
		{
			return _curveInterpolation;
		}
		set
		{
			SetValue(delegate(IfcCurveInterpolationEnum? v)
			{
				_curveInterpolation = v;
			}, _curveInterpolation, value, "CurveInterpolation", -8);
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> DefiningValues
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

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> DefinedValues
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

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Expression
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnit DefiningUnit
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnit v)
			{
				_definingUnit = v;
			}, _definingUnit, value, "DefiningUnit", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnit DefinedUnit
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnit v)
			{
				_definedUnit = v;
			}, _definedUnit, value, "DefinedUnit", 7);
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
		_definingValues = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue>(this, 0, 3);
		_definedValues = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue>(this, 0, 4);
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
			_definingValues.InternalAdd((Xbim.Ifc2x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 3:
			_definedValues.InternalAdd((Xbim.Ifc2x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 4:
			_expression = value.StringVal;
			break;
		case 5:
			_definingUnit = (Xbim.Ifc2x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 6:
			_definedUnit = (Xbim.Ifc2x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyTableValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyTableValueClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPropertyTableValueClause.WR1:
				result = Functions.SIZEOF(DefiningValues) == Functions.SIZEOF(DefinedValues);
				break;
			case IfcPropertyTableValueClause.WR2:
				result = Functions.SIZEOF(Enumerable.Where(DefiningValues, (Xbim.Ifc2x3.MeasureResource.IfcValue temp) => Functions.TYPEOF(temp) != Functions.TYPEOF(DefiningValues.ItemAt(0L)))) == 0;
				break;
			case IfcPropertyTableValueClause.WR3:
				result = Functions.SIZEOF(Enumerable.Where(DefinedValues, (Xbim.Ifc2x3.MeasureResource.IfcValue temp) => Functions.TYPEOF(temp) != Functions.TYPEOF(DefinedValues.ItemAt(0L)))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyTableValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyTableValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyTableValueClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyTableValueClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyTableValueClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
