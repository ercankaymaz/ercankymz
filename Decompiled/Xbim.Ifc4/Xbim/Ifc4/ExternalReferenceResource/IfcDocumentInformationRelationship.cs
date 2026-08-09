using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcDocumentInformationRelationship", 491)]
public class IfcDocumentInformationRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcDocumentInformationRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDocumentInformationRelationship>
{
	private IfcDocumentInformation _relatingDocument;

	private readonly ItemSet<IfcDocumentInformation> _relatedDocuments;

	private IfcLabel? _relationshipType;

	IIfcDocumentInformation IIfcDocumentInformationRelationship.RelatingDocument
	{
		get
		{
			return RelatingDocument;
		}
		set
		{
			RelatingDocument = value as IfcDocumentInformation;
		}
	}

	IItemSet<IIfcDocumentInformation> IIfcDocumentInformationRelationship.RelatedDocuments => new ProxyItemSet<IfcDocumentInformation, IIfcDocumentInformation>(RelatedDocuments);

	IfcLabel? IIfcDocumentInformationRelationship.RelationshipType
	{
		get
		{
			return RelationshipType;
		}
		set
		{
			RelationshipType = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDocumentInformation RelatingDocument
	{
		get
		{
			if (_activated)
			{
				return _relatingDocument;
			}
			Activate();
			return _relatingDocument;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDocumentInformation v)
			{
				_relatingDocument = v;
			}, _relatingDocument, value, "RelatingDocument", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcDocumentInformation> RelatedDocuments
	{
		get
		{
			if (_activated)
			{
				return _relatedDocuments;
			}
			Activate();
			return _relatedDocuments;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? RelationshipType
	{
		get
		{
			if (_activated)
			{
				return _relationshipType;
			}
			Activate();
			return _relationshipType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_relationshipType = v;
			}, _relationshipType, value, "RelationshipType", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingDocument != null)
			{
				yield return RelatingDocument;
			}
			foreach (IfcDocumentInformation relatedDocument in RelatedDocuments)
			{
				yield return relatedDocument;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingDocument != null)
			{
				yield return RelatingDocument;
			}
			foreach (IfcDocumentInformation relatedDocument in RelatedDocuments)
			{
				yield return relatedDocument;
			}
		}
	}

	internal IfcDocumentInformationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedDocuments = new ItemSet<IfcDocumentInformation>(this, 0, 4);
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
			_relatingDocument = (IfcDocumentInformation)value.EntityVal;
			break;
		case 3:
			_relatedDocuments.InternalAdd((IfcDocumentInformation)value.EntityVal);
			break;
		case 4:
			_relationshipType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDocumentInformationRelationship other)
	{
		return this == other;
	}
}
