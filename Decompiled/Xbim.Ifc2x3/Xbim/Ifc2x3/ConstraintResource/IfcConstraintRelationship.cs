using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcConstraintRelationship", 374)]
public class IfcConstraintRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstraintRelationship>, IExpressValidatable
{
	public enum IfcConstraintRelationshipClause
	{
		WR11
	}

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcConstraint _relatingConstraint;

	private readonly ItemSet<IfcConstraint> _relatedConstraints;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcConstraint RelatingConstraint
	{
		get
		{
			if (_activated)
			{
				return _relatingConstraint;
			}
			Activate();
			return _relatingConstraint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConstraint v)
			{
				_relatingConstraint = v;
			}, _relatingConstraint, value, "RelatingConstraint", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcConstraint> RelatedConstraints
	{
		get
		{
			if (_activated)
			{
				return _relatedConstraints;
			}
			Activate();
			return _relatedConstraints;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingConstraint != null)
			{
				yield return RelatingConstraint;
			}
			foreach (IfcConstraint relatedConstraint in RelatedConstraints)
			{
				yield return relatedConstraint;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingConstraint != null)
			{
				yield return RelatingConstraint;
			}
			foreach (IfcConstraint relatedConstraint in RelatedConstraints)
			{
				yield return relatedConstraint;
			}
		}
	}

	internal IfcConstraintRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedConstraints = new ItemSet<IfcConstraint>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_relatingConstraint = (IfcConstraint)value.EntityVal;
			break;
		case 3:
			_relatedConstraints.InternalAdd((IfcConstraint)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstraintRelationship other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstraintRelationshipClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcConstraintRelationshipClause.WR11)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedConstraints, (IfcConstraint temp) => (object)temp == RelatingConstraint)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstraintRelationship>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstraintRelationship.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcConstraintRelationshipClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstraintRelationship.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
