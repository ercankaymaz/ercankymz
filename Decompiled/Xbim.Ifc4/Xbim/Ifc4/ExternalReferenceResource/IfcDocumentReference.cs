using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcDocumentReference", 450)]
public class IfcDocumentReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IIfcDocumentReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcDocumentSelect, IIfcDocumentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDocumentReference>, IExpressValidatable
{
	public enum IfcDocumentReferenceClause
	{
		WR1
	}

	private IfcText? _description;

	private IfcDocumentInformation _referencedDocument;

	IfcText? IIfcDocumentReference.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

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

	IEnumerable<IIfcRelAssociatesDocument> IIfcDocumentReference.DocumentRefForObjects => DocumentRefForObjects;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcText? Description
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
			SetValue(delegate(IfcText? v)
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

	public bool ValidateClause(IfcDocumentReferenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDocumentReferenceClause.WR1)
			{
				result = Functions.EXISTS(base.Name) ^ Functions.EXISTS(ReferencedDocument);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDocumentReference>()?.LogError($"Exception thrown evaluating where-clause 'IfcDocumentReference.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDocumentReferenceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDocumentReference.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
