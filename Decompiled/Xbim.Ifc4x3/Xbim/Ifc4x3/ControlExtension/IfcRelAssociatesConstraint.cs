using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ControlExtension;

[ExpressType("IfcRelAssociatesConstraint", 711)]
public class IfcRelAssociatesConstraint : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesConstraint>, IIfcRelAssociatesConstraint, IIfcRelAssociates, IIfcRelationship, IIfcRoot
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _intent;

	private IfcConstraint _relatingConstraint;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Intent
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesConstraint), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRelAssociatesConstraint.Intent
	{
		get
		{
			if (!Intent.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Intent.Value);
		}
		set
		{
			Intent = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesConstraint), 7)]
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
