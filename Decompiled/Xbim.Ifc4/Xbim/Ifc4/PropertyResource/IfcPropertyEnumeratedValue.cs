using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertyEnumeratedValue", 629)]
public class IfcPropertyEnumeratedValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyEnumeratedValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyEnumeratedValue>, IExpressValidatable
{
	public enum IfcPropertyEnumeratedValueClause
	{
		WR21
	}

	private readonly OptionalItemSet<IfcValue> _enumerationValues;

	private IfcPropertyEnumeration _enumerationReference;

	IItemSet<IIfcValue> IIfcPropertyEnumeratedValue.EnumerationValues => new ProxyItemSet<IfcValue, IIfcValue>(EnumerationValues);

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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcValue> EnumerationValues
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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
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
		_enumerationValues = new OptionalItemSet<IfcValue>(this, 0, 3);
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
			if (clause == IfcPropertyEnumeratedValueClause.WR21)
			{
				result = !Functions.EXISTS(EnumerationReference) || !Functions.EXISTS(EnumerationValues) || Functions.SIZEOF(Enumerable.Where(EnumerationValues, (IfcValue temp) => EnumerationReference.EnumerationValues.Contains(temp))) == Functions.SIZEOF(EnumerationValues);
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
		if (!ValidateClause(IfcPropertyEnumeratedValueClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyEnumeratedValue.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
