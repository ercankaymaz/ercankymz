using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcConstraintClassificationRelationship", 274)]
public class IfcConstraintClassificationRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstraintClassificationRelationship>
{
	private IfcConstraint _classifiedConstraint;

	private readonly ItemSet<IfcClassificationNotationSelect> _relatedClassifications;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcConstraint ClassifiedConstraint
	{
		get
		{
			if (_activated)
			{
				return _classifiedConstraint;
			}
			Activate();
			return _classifiedConstraint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConstraint v)
			{
				_classifiedConstraint = v;
			}, _classifiedConstraint, value, "ClassifiedConstraint", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcClassificationNotationSelect> RelatedClassifications
	{
		get
		{
			if (_activated)
			{
				return _relatedClassifications;
			}
			Activate();
			return _relatedClassifications;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ClassifiedConstraint != null)
			{
				yield return ClassifiedConstraint;
			}
			foreach (IfcClassificationNotationSelect relatedClassification in RelatedClassifications)
			{
				yield return relatedClassification;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ClassifiedConstraint != null)
			{
				yield return ClassifiedConstraint;
			}
		}
	}

	internal IfcConstraintClassificationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedClassifications = new ItemSet<IfcClassificationNotationSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_classifiedConstraint = (IfcConstraint)value.EntityVal;
			break;
		case 1:
			_relatedClassifications.InternalAdd((IfcClassificationNotationSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstraintClassificationRelationship other)
	{
		return this == other;
	}
}
