using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyDependencyRelationship", 444)]
public class IfcPropertyDependencyRelationship : IfcResourceLevelRelationship, IIfcPropertyDependencyRelationship, IIfcResourceLevelRelationship, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertyDependencyRelationship>
{
	private IfcProperty _dependingProperty;

	private IfcProperty _dependantProperty;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _expression;

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
			Expression = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
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
}
