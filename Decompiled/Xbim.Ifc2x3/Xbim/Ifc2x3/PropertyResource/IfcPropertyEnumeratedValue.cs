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

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcPropertyEnumeratedValue", 629)]
public class IfcPropertyEnumeratedValue : IfcSimpleProperty, IIfcPropertyEnumeratedValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyEnumeratedValue>, IExpressValidatable
{
	public enum IfcPropertyEnumeratedValueClause
	{
		WR1
	}

	private IItemSet<IIfcValue> _enumerationValuesIfc4;

	private readonly ItemSet<IfcValue> _enumerationValues;

	private IfcPropertyEnumeration _enumerationReference;

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeratedValue), 3)]
	IItemSet<IIfcValue> IIfcPropertyEnumeratedValue.EnumerationValues => _enumerationValuesIfc4 ?? (_enumerationValuesIfc4 = new ExtendedItemSet<IfcValue, IIfcValue>(EnumerationValues, new ItemSet<IIfcValue>(this, 0, -3), (IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeratedValue), 4)]
	IIfcPropertyEnumeration IIfcPropertyEnumeratedValue.EnumerationReference
	{
		get
		{
			return EnumerationReference;
		}
		set
		{
			EnumerationReference = value as IfcPropertyEnumeration;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcValue> EnumerationValues
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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcPropertyEnumeration EnumerationReference
	{
		get
		{
			if (_activated)
			{
				return _enumerationReference;
			}
			Activate();
			return _enumerationReference;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPropertyEnumeration v)
			{
				_enumerationReference = v;
			}, _enumerationReference, value, "EnumerationReference", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (EnumerationReference != null)
			{
				yield return EnumerationReference;
			}
		}
	}

	internal IfcPropertyEnumeratedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_enumerationValues = new ItemSet<IfcValue>(this, 0, 3);
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
			_enumerationValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 3:
			_enumerationReference = (IfcPropertyEnumeration)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyEnumeratedValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyEnumeratedValueClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPropertyEnumeratedValueClause.WR1)
			{
				result = !Functions.EXISTS(EnumerationReference) || Functions.SIZEOF(Enumerable.Where(EnumerationValues, (IfcValue temp) => EnumerationReference.EnumerationValues.Contains(temp))) == Functions.SIZEOF(EnumerationValues);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyEnumeratedValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyEnumeratedValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyEnumeratedValueClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyEnumeratedValue.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
