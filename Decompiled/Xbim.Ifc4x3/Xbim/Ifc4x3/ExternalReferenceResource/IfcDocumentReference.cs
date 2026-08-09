using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcDocumentReference", 450)]
public class IfcDocumentReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcDocumentSelect, IExpressSelectType, IIfcDocumentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDocumentReference>, IIfcDocumentReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcDocumentSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private IfcDocumentInformation _referencedDocument;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 4);
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDocumentInformation ReferencedDocument
	{
		get
		{
			if (_activated)
			{
				return _referencedDocument;
			}
			Activate();
			return _referencedDocument;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDocumentInformation v)
			{
				_referencedDocument = v;
			}, _referencedDocument, value, "ReferencedDocument", 5);
		}
	}

	[InverseProperty("RelatingDocument")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcRelAssociatesDocument> DocumentRefForObjects => base.Model.Instances.Where((IfcRelAssociatesDocument e) => Equals(e.RelatingDocument), "RelatingDocument", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ReferencedDocument != null)
			{
				yield return ReferencedDocument;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ReferencedDocument != null)
			{
				yield return ReferencedDocument;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentReference), 4)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcDocumentReference.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentReference), 5)]
	IIfcDocumentInformation IIfcDocumentReference.ReferencedDocument
	{
		get
		{
			return ReferencedDocument;
		}
		set
		{
			ReferencedDocument = value as IfcDocumentInformation;
		}
	}

	IEnumerable<IIfcRelAssociatesDocument> IIfcDocumentReference.DocumentRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesDocument e) => e.RelatingDocument as IfcDocumentReference == this, "RelatingDocument", this);

	internal IfcDocumentReference(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_description = value.StringVal;
			break;
		case 4:
			_referencedDocument = (IfcDocumentInformation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDocumentReference other)
	{
		return this == other;
	}
}
