using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcDocumentInformationRelationship", 491)]
public class IfcDocumentInformationRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDocumentInformationRelationship>, IIfcDocumentInformationRelationship, IIfcResourceLevelRelationship
{
	private IfcDocumentInformation _relatingDocument;

	private readonly ItemSet<IfcDocumentInformation> _relatedDocuments;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _relationshipType;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
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
			}, _relatingDocument, value, "RelatingDocument", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? RelationshipType
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_relationshipType = v;
			}, _relationshipType, value, "RelationshipType", 3);
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

	[CrossSchemaAttribute(typeof(IIfcDocumentInformationRelationship), 3)]
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

	[CrossSchemaAttribute(typeof(IIfcDocumentInformationRelationship), 4)]
	IItemSet<IIfcDocumentInformation> IIfcDocumentInformationRelationship.RelatedDocuments => new ProxyItemSet<IfcDocumentInformation, IIfcDocumentInformation>(RelatedDocuments);

	[CrossSchemaAttribute(typeof(IIfcDocumentInformationRelationship), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDocumentInformationRelationship.RelationshipType
	{
		get
		{
			if (!RelationshipType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(RelationshipType.Value);
		}
		set
		{
			RelationshipType = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformationRelationship), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceLevelRelationship.Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", -1);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformationRelationship), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcResourceLevelRelationship.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -2);
		}
	}

	internal IfcDocumentInformationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedDocuments = new ItemSet<IfcDocumentInformation>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relatingDocument = (IfcDocumentInformation)value.EntityVal;
			break;
		case 1:
			_relatedDocuments.InternalAdd((IfcDocumentInformation)value.EntityVal);
			break;
		case 2:
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
