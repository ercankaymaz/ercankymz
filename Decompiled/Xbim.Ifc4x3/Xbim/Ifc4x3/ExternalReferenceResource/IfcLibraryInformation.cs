using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcLibraryInformation", 449)]
public class IfcLibraryInformation : IfcExternalInformation, IInstantiableEntity, IPersistEntity, IPersist, IfcLibrarySelect, IExpressSelectType, IIfcLibrarySelect, IContainsEntityReferences, IEquatable<IfcLibraryInformation>, IIfcLibraryInformation, IIfcExternalInformation, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcLibrarySelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _version;

	private IfcActorSelect _publisher;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _versionDate;

	private Xbim.Ifc4x3.MeasureResource.IfcURIReference? _location;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Version
	{
		get
		{
			if (_activated)
			{
				return _version;
			}
			Activate();
			return _version;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_version = v;
			}, _version, value, "Version", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcActorSelect Publisher
	{
		get
		{
			if (_activated)
			{
				return _publisher;
			}
			Activate();
			return _publisher;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_publisher = v;
			}, _publisher, value, "Publisher", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? VersionDate
	{
		get
		{
			if (_activated)
			{
				return _versionDate;
			}
			Activate();
			return _versionDate;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
			{
				_versionDate = v;
			}, _versionDate, value, "VersionDate", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcURIReference? Location
	{
		get
		{
			if (_activated)
			{
				return _location;
			}
			Activate();
			return _location;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _description, value, "Description", 6);
		}
	}

	[InverseProperty("RelatingLibrary")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcRelAssociatesLibrary> LibraryInfoForObjects => base.Model.Instances.Where((IfcRelAssociatesLibrary e) => Equals(e.RelatingLibrary), "RelatingLibrary", this);

	[InverseProperty("ReferencedLibrary")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcLibraryReference> HasLibraryReferences => base.Model.Instances.Where((IfcLibraryReference e) => Equals(e.ReferencedLibrary), "ReferencedLibrary", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Publisher != null)
			{
				yield return Publisher;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcLibraryInformation.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcLibraryInformation.Version
	{
		get
		{
			if (!Version.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Version.Value);
		}
		set
		{
			Version = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 3)]
	IIfcActorSelect IIfcLibraryInformation.Publisher
	{
		get
		{
			if (Publisher == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = Publisher as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = Publisher as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = Publisher as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				return ifcPersonAndOrganization;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Publisher = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				Publisher = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				Publisher = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				Publisher = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 4)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcLibraryInformation.VersionDate
	{
		get
		{
			if (!VersionDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(VersionDate.Value);
		}
		set
		{
			VersionDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 5)]
	Xbim.Ifc4.ExternalReferenceResource.IfcURIReference? IIfcLibraryInformation.Location
	{
		get
		{
			if (!Location.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.ExternalReferenceResource.IfcURIReference(Location.Value);
		}
		set
		{
			Location = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcURIReference?(new Xbim.Ifc4x3.MeasureResource.IfcURIReference(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcURIReference?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 6)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcLibraryInformation.Description
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

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryInformation.LibraryInfoForObjects => base.Model.Instances.Where((IIfcRelAssociatesLibrary e) => e.RelatingLibrary as IfcLibraryInformation == this, "RelatingLibrary", this);

	IEnumerable<IIfcLibraryReference> IIfcLibraryInformation.HasLibraryReferences => base.Model.Instances.Where((IIfcLibraryReference e) => e.ReferencedLibrary as IfcLibraryInformation == this, "ReferencedLibrary", this);

	internal IfcLibraryInformation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_version = value.StringVal;
			break;
		case 2:
			_publisher = (IfcActorSelect)value.EntityVal;
			break;
		case 3:
			_versionDate = value.StringVal;
			break;
		case 4:
			_location = value.StringVal;
			break;
		case 5:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLibraryInformation other)
	{
		return this == other;
	}
}
