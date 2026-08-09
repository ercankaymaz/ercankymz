using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelReferencedInSpatialStructure", 455)]
public class IfcRelReferencedInSpatialStructure : IfcRelConnects, IIfcRelReferencedInSpatialStructure, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelReferencedInSpatialStructure>
{
	private readonly ItemSet<IfcSpatialReferenceSelect> _relatedElements;

	private IfcSpatialElement _relatingStructure;

	[CrossSchemaAttribute(typeof(IIfcRelReferencedInSpatialStructure), 5)]
	IItemSet<IIfcProduct> IIfcRelReferencedInSpatialStructure.RelatedElements
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelReferencedInSpatialStructure), 6)]
	IIfcSpatialElement IIfcRelReferencedInSpatialStructure.RelatingStructure
	{
		get
		{
			return RelatingStructure;
		}
		set
		{
			RelatingStructure = value as IfcSpatialElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcSpatialReferenceSelect> RelatedElements
	{
		get
		{
			if (_activated)
			{
				return _relatedElements;
			}
			Activate();
			return _relatedElements;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcSpatialElement RelatingStructure
	{
		get
		{
			if (_activated)
			{
				return _relatingStructure;
			}
			Activate();
			return _relatingStructure;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialElement v)
			{
				_relatingStructure = v;
			}, _relatingStructure, value, "RelatingStructure", 6);
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
			foreach (IfcSpatialReferenceSelect relatedElement in RelatedElements)
			{
				yield return relatedElement;
			}
			if (RelatingStructure != null)
			{
				yield return RelatingStructure;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSpatialReferenceSelect relatedElement in RelatedElements)
			{
				yield return relatedElement;
			}
			if (RelatingStructure != null)
			{
				yield return RelatingStructure;
			}
		}
	}

	internal IfcRelReferencedInSpatialStructure(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedElements = new ItemSet<IfcSpatialReferenceSelect>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatedElements.InternalAdd((IfcSpatialReferenceSelect)value.EntityVal);
			break;
		case 5:
			_relatingStructure = (IfcSpatialElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelReferencedInSpatialStructure other)
	{
		return this == other;
	}
}
