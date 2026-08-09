using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcDocumentReference", 450)]
public class IfcDocumentReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcDocumentSelect, IExpressSelectType, IIfcDocumentSelect, IEquatable<IfcDocumentReference>, IIfcDocumentReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcDocumentSelect, IExpressValidatable
{
	public enum IfcDocumentReferenceClause
	{
		WR1
	}

	private IfcText? _description;

	[InverseProperty("DocumentReferences")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcDocumentInformation> ReferenceToDocument => base.Model.Instances.Where((IfcDocumentInformation e) => e.DocumentReferences != null && e.DocumentReferences.Contains(this), "DocumentReferences", this);

	[CrossSchemaAttribute(typeof(IIfcDocumentReference), 4)]
	IfcText? IIfcDocumentReference.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -4);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentReference), 5)]
	IIfcDocumentInformation IIfcDocumentReference.ReferencedDocument
	{
		get
		{
			return ReferenceToDocument.FirstOrDefault();
		}
		set
		{
			if (value == null)
			{
				ReferenceToDocument.ToList().ForEach(delegate(IfcDocumentInformation d)
				{
					d.DocumentReferences.Remove(this);
				});
			}
			else
			{
				IfcDocumentInformation ifcDocumentInformation = value as IfcDocumentInformation;
				if (ifcDocumentInformation != null && !ifcDocumentInformation.DocumentReferences.Contains(this))
				{
					ifcDocumentInformation.DocumentReferences.Add(this);
				}
			}
			NotifyPropertyChanged("ReferencedDocument");
		}
	}

	IEnumerable<IIfcRelAssociatesDocument> IIfcDocumentReference.DocumentRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesDocument e) => e.RelatingDocument as IfcDocumentReference == this, "RelatingDocument", this);

	internal IfcDocumentReference(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
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
				result = Functions.EXISTS(base.Name) ^ Functions.EXISTS(ReferenceToDocument.ItemAt(0L));
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
