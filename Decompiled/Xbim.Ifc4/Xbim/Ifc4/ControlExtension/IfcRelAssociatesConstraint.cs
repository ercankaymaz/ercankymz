using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ControlExtension;

[ExpressType("IfcRelAssociatesConstraint", 711)]
public class IfcRelAssociatesConstraint : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssociatesConstraint, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesConstraint>
{
	private IfcLabel? _intent;

	private IfcConstraint _relatingConstraint;

	IfcLabel? IIfcRelAssociatesConstraint.Intent
	{
		get
		{
			return Intent;
		}
		set
		{
			Intent = value;
		}
	}

	IIfcConstraint IIfcRelAssociatesConstraint.RelatingConstraint
	{
		get
		{
			return RelatingConstraint;
		}
		set
		{
			RelatingConstraint = value as IfcConstraint;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLabel? Intent
	{
		get
		{
			if (_activated)
			{
				return _intent;
			}
			Activate();
			return _intent;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_intent = v;
			}, _intent, value, "Intent", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
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
			}, _relatingConstraint, value, "RelatingConstraint", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingConstraint != null)
			{
				yield return RelatingConstraint;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAssociatesConstraint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_intent = value.StringVal;
			break;
		case 6:
			_relatingConstraint = (IfcConstraint)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesConstraint other)
	{
		return this == other;
	}
}
