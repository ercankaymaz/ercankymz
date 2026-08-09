using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssociatesDocument", 307)]
public class IfcRelAssociatesDocument : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssociatesDocument, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesDocument>
{
	private IfcDocumentSelect _relatingDocument;

	IIfcDocumentSelect IIfcRelAssociatesDocument.RelatingDocument
	{
		get
		{
			return RelatingDocument;
		}
		set
		{
			RelatingDocument = value as IfcDocumentSelect;
		}
	}

	[IndexedProperty]
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingDocument != null)
			{
				yield return RelatingDocument;
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
