using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassificationNotation", 13)]
public class IfcClassificationNotation : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcClassificationNotationSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcClassificationNotation>, IIfcClassificationReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	private readonly ItemSet<IfcClassificationNotationFacet> _notationFacets;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcClassificationNotationFacet> NotationFacets
	{
		get
		{
			if (_activated)
			{
				return _notationFacets;
			}
			Activate();
			return _notationFacets;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcClassificationNotationFacet notationFacet in NotationFacets)
			{
				yield return notationFacet;
			}
		}
	}

	IIfcClassificationReferenceSelect IIfcClassificationReference.ReferencedSource
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	IfcText? IIfcClassificationReference.Description
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	IfcIdentifier? IIfcClassificationReference.Sort
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassificationReference.ClassificationRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesClassification e) => Equals(e.RelatingClassification), "RelatingClassification", this);

	IEnumerable<IIfcClassificationReference> IIfcClassificationReference.HasReferences => base.Model.Instances.Where((IIfcClassificationReference e) => Equals(e.ReferencedSource), "ReferencedSource", this);

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

	IfcIdentifier? IIfcExternalReference.Identification
	{
		get
		{
			List<string> list = ((IEnumerable<IfcClassificationNotationFacet>)NotationFacets).Select((Func<IfcClassificationNotationFacet, string>)((IfcClassificationNotationFacet f) => f.NotationValue)).ToList();
			return (!list.Any()) ? null : string.Join("", list);
		}
		set
		{
			NotationFacets.Clear();
			if (value.HasValue)
			{
				NotationFacets.Add(base.Model.Instances.New(delegate(IfcClassificationNotationFacet f)
				{
					f.NotationValue = value.Value.ToString();
				}));
			}
		}
	}

	IfcLabel? IIfcExternalReference.Name
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcExternalReference.ExternalReferenceForResources
	{
		get
		{
			yield break;
		}
	}

	internal IfcClassificationNotation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_notationFacets = new ItemSet<IfcClassificationNotationFacet>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_notationFacets.InternalAdd((IfcClassificationNotationFacet)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcClassificationNotation other)
	{
		return this == other;
	}
}
