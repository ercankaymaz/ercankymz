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

[ExpressType("IfcPropertyEnumeration", 597)]
public class IfcPropertyEnumeration : IfcPropertyAbstraction, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyEnumeration, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyEnumeration>, IExpressValidatable
{
	public enum IfcPropertyEnumerationClause
	{
		WR01
	}

	private IfcLabel _name;

	private readonly ItemSet<IfcValue> _enumerationValues;

	private IfcUnit _unit;

	IfcLabel IIfcPropertyEnumeration.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IItemSet<IIfcValue> IIfcPropertyEnumeration.EnumerationValues => new ProxyItemSet<IfcValue, IIfcValue>(EnumerationValues);

	IIfcUnit IIfcPropertyEnumeration.Unit
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

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
		_enumerationValues = new ItemSet<IfcValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_enumerationValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 2:
			_unit = (IfcUnit)value.EntityVal;
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
				result = Functions.SIZEOF(Enumerable.Where(EnumerationValues, (IfcValue temp) => !(Functions.TYPEOF(EnumerationValues.ItemAt(0L)) == Functions.TYPEOF(temp)))) == 0;
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
