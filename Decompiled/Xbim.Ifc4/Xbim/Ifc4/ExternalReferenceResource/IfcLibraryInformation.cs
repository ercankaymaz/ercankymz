using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcLibraryInformation", 449)]
public class IfcLibraryInformation : IfcExternalInformation, IInstantiableEntity, IPersistEntity, IPersist, IIfcLibraryInformation, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcLibrarySelect, IIfcLibrarySelect, IContainsEntityReferences, IEquatable<IfcLibraryInformation>
{
	private IfcLabel _name;

	private IfcLabel? _version;

	private IfcActorSelect _publisher;

	private IfcDateTime? _versionDate;

	private IfcURIReference? _location;

	private IfcText? _description;

	IfcLabel IIfcLibraryInformation.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcLabel? IIfcLibraryInformation.Version
	{
		get
		{
			return Version;
		}
		set
		{
			Version = value;
		}
	}

	IIfcActorSelect IIfcLibraryInformation.Publisher
	{
		get
		{
			return Publisher;
		}
		set
		{
			Publisher = value as IfcActorSelect;
		}
	}

	IfcDateTime? IIfcLibraryInformation.VersionDate
	{
		get
		{
			return VersionDate;
		}
		set
		{
			VersionDate = value;
		}
	}

	IfcURIReference? IIfcLibraryInformation.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value;
		}
	}

	IfcText? IIfcLibraryInformation.Description
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

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryInformation.LibraryInfoForObjects => LibraryInfoForObjects;

	IEnumerable<IIfcLibraryReference> IIfcLibraryInformation.HasLibraryReferences => HasLibraryReferences;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? Version
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
			SetValue(delegate(IfcLabel? v)
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
	public IfcDateTime? VersionDate
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
			SetValue(delegate(IfcDateTime? v)
			{
				_versionDate = v;
			}, _versionDate, value, "VersionDate", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcURIReference? Location
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
			SetValue(delegate(IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
