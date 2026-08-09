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

[ExpressType("IfcLibraryReference", 598)]
public class IfcLibraryReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcLibrarySelect, IExpressSelectType, IIfcLibrarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLibraryReference>, IIfcLibraryReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcLibrarySelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private IfcLanguageId? _language;

	private IfcLibraryInformation _referencedLibrary;

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

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLanguageId? Language
	{
		get
		{
			if (_activated)
			{
				return _language;
			}
			Activate();
			return _language;
		}
		set
		{
			SetValue(delegate(IfcLanguageId? v)
			{
				_language = v;
			}, _language, value, "Language", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcLibraryInformation ReferencedLibrary
	{
		get
		{
			if (_activated)
			{
				return _referencedLibrary;
			}
			Activate();
			return _referencedLibrary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLibraryInformation v)
			{
				_referencedLibrary = v;
			}, _referencedLibrary, value, "ReferencedLibrary", 6);
		}
	}

	[InverseProperty("RelatingLibrary")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcRelAssociatesLibrary> LibraryRefForObjects => base.Model.Instances.Where((IfcRelAssociatesLibrary e) => Equals(e.RelatingLibrary), "RelatingLibrary", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ReferencedLibrary != null)
			{
				yield return ReferencedLibrary;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ReferencedLibrary != null)
			{
				yield return ReferencedLibrary;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 4)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcLibraryReference.Description
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

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 5)]
	Xbim.Ifc4.ExternalReferenceResource.IfcLanguageId? IIfcLibraryReference.Language
	{
		get
		{
			if (!Language.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.ExternalReferenceResource.IfcLanguageId(Language.Value);
		}
		set
		{
			Language = (value.HasValue ? new IfcLanguageId?(new IfcLanguageId(value.Value)) : ((IfcLanguageId?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryReference), 6)]
	IIfcLibraryInformation IIfcLibraryReference.ReferencedLibrary
	{
		get
		{
			return ReferencedLibrary;
		}
		set
		{
			ReferencedLibrary = value as IfcLibraryInformation;
		}
	}

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryReference.LibraryRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesLibrary e) => e.RelatingLibrary as IfcLibraryReference == this, "RelatingLibrary", this);

	internal IfcLibraryReference(IModel model, int label, bool activated)
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
			_language = value.StringVal;
			break;
		case 5:
			_referencedLibrary = (IfcLibraryInformation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLibraryReference other)
	{
		return this == other;
	}
}
