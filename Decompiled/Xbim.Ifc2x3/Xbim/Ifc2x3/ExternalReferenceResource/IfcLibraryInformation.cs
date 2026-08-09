using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcLibraryInformation", 449)]
public class IfcLibraryInformation : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcLibrarySelect, IExpressSelectType, IIfcLibrarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLibraryInformation>, IIfcLibraryInformation, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcLibrarySelect
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _version;

	private IfcOrganization _publisher;

	private IfcCalendarDate _versionDate;

	private readonly OptionalItemSet<IfcLibraryReference> _libraryReference;

	private IIfcActorSelect _publisher4;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Version
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_version = v;
			}, _version, value, "Version", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcOrganization Publisher
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
			SetValue(delegate(IfcOrganization v)
			{
				_publisher = v;
			}, _publisher, value, "Publisher", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCalendarDate VersionDate
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_versionDate = v;
			}, _versionDate, value, "VersionDate", 4);
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IOptionalItemSet<IfcLibraryReference> LibraryReference
	{
		get
		{
			if (_activated)
			{
				return _libraryReference;
			}
			Activate();
			return _libraryReference;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Publisher != null)
			{
				yield return Publisher;
			}
			if (VersionDate != null)
			{
				yield return VersionDate;
			}
			foreach (IfcLibraryReference item in LibraryReference)
			{
				yield return item;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcLibraryReference item in LibraryReference)
			{
				yield return item;
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
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
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
			Version = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 3)]
	IIfcActorSelect IIfcLibraryInformation.Publisher
	{
		get
		{
			return _publisher4 ?? Publisher;
		}
		set
		{
			if (value == null)
			{
				Publisher = null;
				if (_publisher4 != null)
				{
					SetValue(delegate(IIfcActorSelect v)
					{
						_publisher4 = v;
					}, _publisher4, null, "Publisher", -3);
				}
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				Publisher = ifcOrganization;
				if (_publisher4 != null)
				{
					SetValue(delegate(IIfcActorSelect v)
					{
						_publisher4 = v;
					}, _publisher4, null, "Publisher", -3);
				}
			}
			else
			{
				if (Publisher != null)
				{
					Publisher = null;
				}
				SetValue(delegate(IIfcActorSelect v)
				{
					_publisher4 = v;
				}, _publisher4, value, "Publisher", -3);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 4)]
	IfcDateTime? IIfcLibraryInformation.VersionDate
	{
		get
		{
			return (VersionDate != null) ? new IfcDateTime(VersionDate.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				VersionDate = null;
				return;
			}
			DateTime d = value.Value;
			VersionDate = base.Model.Instances.New(delegate(IfcCalendarDate date)
			{
				date.YearComponent = d.Year;
				date.MonthComponent = d.Month;
				date.DayComponent = d.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 5)]
	IfcURIReference? IIfcLibraryInformation.Location
	{
		get
		{
			IfcLibraryReference ifcLibraryReference = LibraryReference.FirstOrDefault((IfcLibraryReference r) => r.Location.HasValue);
			return (ifcLibraryReference != null) ? new IfcURIReference(ifcLibraryReference.Location.Value) : ((IfcURIReference)null);
		}
		set
		{
			IfcLibraryReference ifcLibraryReference = LibraryReference.FirstOrDefault((IfcLibraryReference r) => r.Location.HasValue);
			if (!value.HasValue)
			{
				if (ifcLibraryReference != null)
				{
					ifcLibraryReference.Location = null;
				}
			}
			else
			{
				if (ifcLibraryReference == null)
				{
					ifcLibraryReference = base.Model.Instances.New<IfcLibraryReference>();
				}
				ifcLibraryReference.Location = value.Value.ToString();
			}
			NotifyPropertyChanged("Location");
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLibraryInformation), 6)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcLibraryInformation.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -6);
		}
	}

	IEnumerable<IIfcRelAssociatesLibrary> IIfcLibraryInformation.LibraryInfoForObjects => base.Model.Instances.Where((IIfcRelAssociatesLibrary e) => e.RelatingLibrary as IfcLibraryInformation == this, "RelatingLibrary", this);

	IEnumerable<IIfcLibraryReference> IIfcLibraryInformation.HasLibraryReferences => base.Model.Instances.Where((IIfcLibraryReference e) => e.ReferencedLibrary as IfcLibraryInformation == this, "ReferencedLibrary", this);

	internal IfcLibraryInformation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_libraryReference = new OptionalItemSet<IfcLibraryReference>(this, 0, 5);
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
			_publisher = (IfcOrganization)value.EntityVal;
			break;
		case 3:
			_versionDate = (IfcCalendarDate)value.EntityVal;
			break;
		case 4:
			_libraryReference.InternalAdd((IfcLibraryReference)value.EntityVal);
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
