using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcLibraryReference", 598)]
public class IfcLibraryReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IIfcLibraryReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcLibrarySelect, IIfcLibrarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLibraryReference>
{
	private IfcText? _description;

	private IfcLanguageId? _language;

	private IfcLibraryInformation _referencedLibrary;

	IfcText? IIfcLibraryReference.Description
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

	IfcLanguageId? IIfcLibraryReference.Language
	{
		get
		{
			return Language;
		}
		set
		{
			Language = value;
		}
	}

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

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryReference.LibraryRefForObjects => LibraryRefForObjects;

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
