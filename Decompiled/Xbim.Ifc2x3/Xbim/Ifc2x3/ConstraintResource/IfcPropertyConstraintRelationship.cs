using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcPropertyConstraintRelationship", 625)]
public class IfcPropertyConstraintRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertyConstraintRelationship>
{
	private IfcConstraint _relatingConstraint;

	private readonly ItemSet<IfcProperty> _relatedProperties;

	private IfcLabel? _name;

	private IfcText? _description;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
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
			}, _relatingConstraint, value, "RelatingConstraint", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcProperty> RelatedProperties
	{
		get
		{
			if (_activated)
			{
				return _relatedProperties;
			}
			Activate();
			return _relatedProperties;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _description, value, "Description", 4);
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
			foreach (IfcProperty relatedProperty in RelatedProperties)
			{
				yield return relatedProperty;
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
		}
	}

	internal IfcPropertyConstraintRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedProperties = new ItemSet<IfcProperty>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relatingConstraint = (IfcConstraint)value.EntityVal;
			break;
		case 1:
			_relatedProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		case 2:
			_name = value.StringVal;
			break;
		case 3:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyConstraintRelationship other)
	{
		return this == other;
	}
}
