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

[ExpressType("IfcPropertyListValue", 489)]
public class IfcPropertyListValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyListValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyListValue>, IExpressValidatable
{
	public enum IfcPropertyListValueClause
	{
		WR31
	}

	private readonly OptionalItemSet<IfcValue> _listValues;

	private IfcUnit _unit;

	IItemSet<IIfcValue> IIfcPropertyListValue.ListValues => new ProxyItemSet<IfcValue, IIfcValue>(ListValues);

	IIfcUnit IIfcPropertyListValue.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcUnit;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcValue> ListValues
	{
		get
		{
			if (_activated)
			{
				return _listValues;
			}
			Activate();
			return _listValues;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcUnit Unit
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
			SetValue(delegate(IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 4);
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

	internal IfcPropertyListValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listValues = new OptionalItemSet<IfcValue>(this, 0, 3);
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
			_listValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 3:
			_unit = (IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyListValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyListValueClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPropertyListValueClause.WR31)
			{
				result = Functions.SIZEOF(Enumerable.Where(ListValues, (IfcValue temp) => !(Functions.TYPEOF(ListValues.ItemAt(0L)) == Functions.TYPEOF(temp)))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyListValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyListValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyListValueClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyListValue.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
