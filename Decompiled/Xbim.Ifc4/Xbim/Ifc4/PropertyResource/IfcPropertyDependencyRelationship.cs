using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertyDependencyRelationship", 444)]
public class IfcPropertyDependencyRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyDependencyRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertyDependencyRelationship>, IExpressValidatable
{
	public enum IfcPropertyDependencyRelationshipClause
	{
		NoSelfReference
	}

	private IfcProperty _dependingProperty;

	private IfcProperty _dependantProperty;

	private IfcText? _expression;

	IIfcProperty IIfcPropertyDependencyRelationship.DependingProperty
	{
		get
		{
			return DependingProperty;
		}
		set
		{
			DependingProperty = value as IfcProperty;
		}
	}

	IIfcProperty IIfcPropertyDependencyRelationship.DependantProperty
	{
		get
		{
			return DependantProperty;
		}
		set
		{
			DependantProperty = value as IfcProperty;
		}
	}

	IfcText? IIfcPropertyDependencyRelationship.Expression
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

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProperty DependingProperty
	{
		get
		{
			if (_activated)
			{
				return _dependingProperty;
			}
			Activate();
			return _dependingProperty;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProperty v)
			{
				_dependingProperty = v;
			}, _dependingProperty, value, "DependingProperty", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcProperty DependantProperty
	{
		get
		{
			if (_activated)
			{
				return _dependantProperty;
			}
			Activate();
			return _dependantProperty;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProperty v)
			{
				_dependantProperty = v;
			}, _dependantProperty, value, "DependantProperty", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcText? Expression
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
			SetValue(delegate(IfcText? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DependingProperty != null)
			{
				yield return DependingProperty;
			}
			if (DependantProperty != null)
			{
				yield return DependantProperty;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (DependingProperty != null)
			{
				yield return DependingProperty;
			}
			if (DependantProperty != null)
			{
				yield return DependantProperty;
			}
		}
	}

	internal IfcPropertyDependencyRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_dependingProperty = (IfcProperty)value.EntityVal;
			break;
		case 3:
			_dependantProperty = (IfcProperty)value.EntityVal;
			break;
		case 4:
			_expression = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyDependencyRelationship other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyDependencyRelationshipClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPropertyDependencyRelationshipClause.NoSelfReference)
			{
				result = (object)DependingProperty != DependantProperty;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyDependencyRelationship>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyDependencyRelationship.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyDependencyRelationshipClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyDependencyRelationship.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
