using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassificationItem", 14)]
public class IfcClassificationItem : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcClassificationItem>, IIfcClassificationReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	private IfcClassificationNotationFacet _notation;

	private IfcClassification _itemOf;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _title;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcClassificationNotationFacet Notation
	{
		get
		{
			if (_activated)
			{
				return _notation;
			}
			Activate();
			return _notation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClassificationNotationFacet v)
			{
				_notation = v;
			}, _notation, value, "Notation", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcClassification ItemOf
	{
		get
		{
			if (_activated)
			{
				return _itemOf;
			}
			Activate();
			return _itemOf;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClassification v)
			{
				_itemOf = v;
			}, _itemOf, value, "ItemOf", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Title
	{
		get
		{
			if (_activated)
			{
				return _title;
			}
			Activate();
			return _title;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_title = v;
			}, _title, value, "Title", 3);
		}
	}

	[InverseProperty("RelatedItems")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcClassificationItemRelationship> IsClassifiedItemIn => base.Model.Instances.Where((IfcClassificationItemRelationship e) => e.RelatedItems != null && e.RelatedItems.Contains(this), "RelatedItems", this);

	[InverseProperty("RelatingItem")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcClassificationItemRelationship> IsClassifyingItemIn => base.Model.Instances.Where((IfcClassificationItemRelationship e) => Equals(e.RelatingItem), "RelatingItem", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Notation != null)
			{
				yield return Notation;
			}
			if (ItemOf != null)
			{
				yield return ItemOf;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ItemOf != null)
			{
				yield return ItemOf;
			}
		}
	}

	IIfcClassificationReferenceSelect IIfcClassificationReference.ReferencedSource
	{
		get
		{
			IfcClassificationItem ifcClassificationItem = IsClassifiedItemIn.Select((IfcClassificationItemRelationship i) => i.RelatingItem).FirstOrDefault();
			if (ifcClassificationItem != null)
			{
				return ifcClassificationItem;
			}
			return ItemOf;
		}
		set
		{
		}
	}

	Xbim.Ifc4.MeasureResource.IfcText? IIfcClassificationReference.Description
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcClassificationReference.Sort
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassificationReference.ClassificationRefForObjects
	{
		get
		{
			IEnumerable<IfcClassificationNotation> notations = base.Model.Instances.Where((IfcClassificationNotation n) => n.NotationFacets.Contains(Notation));
			return base.Model.Instances.Where((IfcRelAssociatesClassification r) => notations.Any((IfcClassificationNotation n) => n.Equals(r.RelatingClassification)));
		}
	}

	IEnumerable<IIfcClassificationReference> IIfcClassificationReference.HasReferences => IsClassifyingItemIn.SelectMany((IfcClassificationItemRelationship i) => i.RelatedItems);

	IfcURIReference? IIfcExternalReference.Location
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExternalReference.Identification
	{
		get
		{
			return (Notation != null) ? ((string)Notation.NotationValue) : null;
		}
		set
		{
			Notation = (value.HasValue ? base.Model.Instances.New(delegate(IfcClassificationNotationFacet f)
			{
				f.NotationValue = value.Value.ToString();
			}) : null);
		}
	}

	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcExternalReference.Name
	{
		get
		{
			return (string)Title;
		}
		set
		{
			Title = (value.HasValue ? value.Value.ToString() : null);
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcExternalReference.ExternalReferenceForResources
	{
		get
		{
			yield break;
		}
	}

	internal IfcClassificationItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_notation = (IfcClassificationNotationFacet)value.EntityVal;
			break;
		case 1:
			_itemOf = (IfcClassification)value.EntityVal;
			break;
		case 2:
			_title = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcClassificationItem other)
	{
		return this == other;
	}
}
