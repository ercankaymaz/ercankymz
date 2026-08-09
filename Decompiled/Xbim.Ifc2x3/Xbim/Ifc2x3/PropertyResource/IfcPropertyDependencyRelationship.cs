using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcPropertyDependencyRelationship", 444)]
public class IfcPropertyDependencyRelationship : PersistEntity, IIfcPropertyDependencyRelationship, IIfcResourceLevelRelationship, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertyDependencyRelationship>, IExpressValidatable
{
	public enum IfcPropertyDependencyRelationshipClause
	{
		WR1
	}

	private IfcProperty _dependingProperty;

	private IfcProperty _dependantProperty;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _expression;

	[CrossSchemaAttribute(typeof(IIfcPropertyDependencyRelationship), 3)]
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

	[CrossSchemaAttribute(typeof(IIfcPropertyDependencyRelationship), 4)]
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

	[CrossSchemaAttribute(typeof(IIfcPropertyDependencyRelationship), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcPropertyDependencyRelationship.Expression
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

	[CrossSchemaAttribute(typeof(IIfcPropertyDependencyRelationship), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceLevelRelationship.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyDependencyRelationship), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcResourceLevelRelationship.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
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
			}, _dependingProperty, value, "DependingProperty", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
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
			}, _dependantProperty, value, "DependantProperty", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
			_dependingProperty = (IfcProperty)value.EntityVal;
			break;
		case 1:
			_dependantProperty = (IfcProperty)value.EntityVal;
			break;
		case 2:
			_name = value.StringVal;
			break;
		case 3:
			_description = value.StringVal;
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
			if (clause == IfcPropertyDependencyRelationshipClause.WR1)
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
		if (!ValidateClause(IfcPropertyDependencyRelationshipClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyDependencyRelationship.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
