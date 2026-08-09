using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssociatesDocument", 307)]
public class IfcRelAssociatesDocument : IfcRelAssociates, IIfcRelAssociatesDocument, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesDocument>
{
	private IfcDocumentSelect _relatingDocument;

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesDocument), 6)]
	IIfcDocumentSelect IIfcRelAssociatesDocument.RelatingDocument
	{
		get
		{
			if (RelatingDocument == null)
			{
				return null;
			}
			IfcDocumentReference ifcDocumentReference = RelatingDocument as IfcDocumentReference;
			if (ifcDocumentReference != null)
			{
				return ifcDocumentReference;
			}
			IfcDocumentInformation ifcDocumentInformation = RelatingDocument as IfcDocumentInformation;
			if (ifcDocumentInformation != null)
			{
				return ifcDocumentInformation;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingDocument = null;
				return;
			}
			IfcDocumentInformation ifcDocumentInformation = value as IfcDocumentInformation;
			if (ifcDocumentInformation != null)
			{
				RelatingDocument = ifcDocumentInformation;
				return;
			}
			IfcDocumentReference ifcDocumentReference = value as IfcDocumentReference;
			if (ifcDocumentReference != null)
			{
				RelatingDocument = ifcDocumentReference;
			}
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDocumentSelect RelatingDocument
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
			SetValue(delegate(IfcDocumentSelect v)
			{
				_relatingDocument = v;
			}, _relatingDocument, value, "RelatingDocument", 6);
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingDocument != null)
			{
				yield return RelatingDocument;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAssociatesDocument(IModel model, int label, bool activated)
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
			_relatingDocument = (IfcDocumentSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesDocument other)
	{
		return this == other;
	}
}
