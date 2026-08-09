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

[ExpressType("IfcPropertyEnumeration", 597)]
public class IfcPropertyEnumeration : PersistEntity, IIfcPropertyEnumeration, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyEnumeration>, IExpressValidatable
{
	public enum IfcPropertyEnumerationClause
	{
		WR01
	}

	private IItemSet<IIfcValue> _enumerationValuesIfc4;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> _enumerationValues;

	private Xbim.Ifc2x3.MeasureResource.IfcUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcPropertyEnumeration.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 2)]
	IItemSet<IIfcValue> IIfcPropertyEnumeration.EnumerationValues => _enumerationValuesIfc4 ?? (_enumerationValuesIfc4 = new ExtendedItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue, IIfcValue>(EnumerationValues, new ItemSet<IIfcValue>(this, 0, -2), (Xbim.Ifc2x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 3)]
	IIfcUnit IIfcPropertyEnumeration.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
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
				Unit = null;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> EnumerationValues
	{
		get
		{
			if (_activated)
			{
				return _enumerationValues;
			}
			Activate();
			return _enumerationValues;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Unit != null)
			{
				yield return Unit;
			}
		}
	}

	internal IfcPropertyEnumeration(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_enumerationValues = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_enumerationValues.InternalAdd((Xbim.Ifc2x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 2:
			_unit = (Xbim.Ifc2x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyEnumeration other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyEnumerationClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPropertyEnumerationClause.WR01)
			{
				result = Functions.SIZEOF(Enumerable.Where(EnumerationValues, (Xbim.Ifc2x3.MeasureResource.IfcValue temp) => Functions.TYPEOF(EnumerationValues.ItemAt(0L)) != Functions.TYPEOF(temp))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyEnumeration>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyEnumeration.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyEnumerationClause.WR01))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyEnumeration.WR01",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
