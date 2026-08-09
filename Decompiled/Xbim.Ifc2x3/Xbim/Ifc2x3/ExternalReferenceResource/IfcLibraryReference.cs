using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcLibraryReference", 598)]
public class IfcLibraryReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcLibrarySelect, IExpressSelectType, IIfcLibrarySelect, IEquatable<IfcLibraryReference>, IIfcLibraryReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcLibrarySelect
{
	private IfcText? _description;

	private IfcLanguageId? _language;

	private IIfcLibraryInformation _referencedLibrary;

	[InverseProperty("LibraryReference")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcLibraryInformation> ReferenceIntoLibrary => base.Model.Instances.Where((IfcLibraryInformation e) => e.LibraryReference != null && e.LibraryReference.Contains(this), "LibraryReference", this);

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 4)]
	IfcText? IIfcLibraryReference.Description
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

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 5)]
	IfcLanguageId? IIfcLibraryReference.Language
	{
		get
		{
			return _language;
		}
		set
		{
			SetValue(delegate(IfcLanguageId? v)
			{
				_language = v;
			}, _language, value, "Language", -5);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 6)]
	IIfcLibraryInformation IIfcLibraryReference.ReferencedLibrary
	{
		get
		{
			return _referencedLibrary;
		}
		set
		{
			SetValue(delegate(IIfcLibraryInformation v)
			{
				_referencedLibrary = v;
			}, _referencedLibrary, value, "ReferencedLibrary", -6);
		}
	}

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryReference.LibraryRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesLibrary e) => e.RelatingLibrary as IfcLibraryReference == this, "RelatingLibrary", this);

	internal IfcLibraryReference(IModel model, int label, bool activated)
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

	public bool Equals(IfcLibraryReference other)
	{
		return this == other;
	}
}
