using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcDocumentInformation", 208)]
public class IfcDocumentInformation : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcDocumentSelect, IExpressSelectType, IIfcDocumentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDocumentInformation>, IIfcDocumentInformation, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcDocumentSelect
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _documentId;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private readonly OptionalItemSet<IfcDocumentReference> _documentReferences;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _purpose;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _intendedUse;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _scope;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _revision;

	private IfcActorSelect _documentOwner;

	private readonly OptionalItemSet<IfcActorSelect> _editors;

	private IfcDateAndTime _creationTime;

	private IfcDateAndTime _lastRevisionTime;

	private IfcDocumentElectronicFormat _electronicFormat;

	private IfcCalendarDate _validFrom;

	private IfcCalendarDate _validUntil;

	private IfcDocumentConfidentialityEnum? _confidentiality;

	private IfcDocumentStatusEnum? _status;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier DocumentId
	{
		get
		{
			if (_activated)
			{
				return _documentId;
			}
			Activate();
			return _documentId;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_documentId = v;
			}, _documentId, value, "DocumentId", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcDocumentReference> DocumentReferences
	{
		get
		{
			if (_activated)
			{
				return _documentReferences;
			}
			Activate();
			return _documentReferences;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Purpose
	{
		get
		{
			if (_activated)
			{
				return _purpose;
			}
			Activate();
			return _purpose;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? IntendedUse
	{
		get
		{
			if (_activated)
			{
				return _intendedUse;
			}
			Activate();
			return _intendedUse;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_intendedUse = v;
			}, _intendedUse, value, "IntendedUse", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Scope
	{
		get
		{
			if (_activated)
			{
				return _scope;
			}
			Activate();
			return _scope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_scope = v;
			}, _scope, value, "Scope", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Revision
	{
		get
		{
			if (_activated)
			{
				return _revision;
			}
			Activate();
			return _revision;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_revision = v;
			}, _revision, value, "Revision", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public IfcActorSelect DocumentOwner
	{
		get
		{
			if (_activated)
			{
				return _documentOwner;
			}
			Activate();
			return _documentOwner;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_documentOwner = v;
			}, _documentOwner, value, "DocumentOwner", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcActorSelect> Editors
	{
		get
		{
			if (_activated)
			{
				return _editors;
			}
			Activate();
			return _editors;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcDateAndTime CreationTime
	{
		get
		{
			if (_activated)
			{
				return _creationTime;
			}
			Activate();
			return _creationTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateAndTime v)
			{
				_creationTime = v;
			}, _creationTime, value, "CreationTime", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcDateAndTime LastRevisionTime
	{
		get
		{
			if (_activated)
			{
				return _lastRevisionTime;
			}
			Activate();
			return _lastRevisionTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateAndTime v)
			{
				_lastRevisionTime = v;
			}, _lastRevisionTime, value, "LastRevisionTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcDocumentElectronicFormat ElectronicFormat
	{
		get
		{
			if (_activated)
			{
				return _electronicFormat;
			}
			Activate();
			return _electronicFormat;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDocumentElectronicFormat v)
			{
				_electronicFormat = v;
			}, _electronicFormat, value, "ElectronicFormat", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcCalendarDate ValidFrom
	{
		get
		{
			if (_activated)
			{
				return _validFrom;
			}
			Activate();
			return _validFrom;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_validFrom = v;
			}, _validFrom, value, "ValidFrom", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcCalendarDate ValidUntil
	{
		get
		{
			if (_activated)
			{
				return _validUntil;
			}
			Activate();
			return _validUntil;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_validUntil = v;
			}, _validUntil, value, "ValidUntil", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 16)]
	public IfcDocumentConfidentialityEnum? Confidentiality
	{
		get
		{
			if (_activated)
			{
				return _confidentiality;
			}
			Activate();
			return _confidentiality;
		}
		set
		{
			SetValue(delegate(IfcDocumentConfidentialityEnum? v)
			{
				_confidentiality = v;
			}, _confidentiality, value, "Confidentiality", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 17)]
	public IfcDocumentStatusEnum? Status
	{
		get
		{
			if (_activated)
			{
				return _status;
			}
			Activate();
			return _status;
		}
		set
		{
			SetValue(delegate(IfcDocumentStatusEnum? v)
			{
				_status = v;
			}, _status, value, "Status", 17);
		}
	}

	[InverseProperty("RelatedDocuments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcDocumentInformationRelationship> IsPointedTo => base.Model.Instances.Where((IfcDocumentInformationRelationship e) => e.RelatedDocuments != null && e.RelatedDocuments.Contains(this), "RelatedDocuments", this);

	[InverseProperty("RelatingDocument")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 19)]
	public IEnumerable<IfcDocumentInformationRelationship> IsPointer => base.Model.Instances.Where((IfcDocumentInformationRelationship e) => Equals(e.RelatingDocument), "RelatingDocument", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDocumentReference documentReference in DocumentReferences)
			{
				yield return documentReference;
			}
			if (DocumentOwner != null)
			{
				yield return DocumentOwner;
			}
			foreach (IfcActorSelect editor in Editors)
			{
				yield return editor;
			}
			if (CreationTime != null)
			{
				yield return CreationTime;
			}
			if (LastRevisionTime != null)
			{
				yield return LastRevisionTime;
			}
			if (ElectronicFormat != null)
			{
				yield return ElectronicFormat;
			}
			if (ValidFrom != null)
			{
				yield return ValidFrom;
			}
			if (ValidUntil != null)
			{
				yield return ValidUntil;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDocumentReference documentReference in DocumentReferences)
			{
				yield return documentReference;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier IIfcDocumentInformation.Identification
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(DocumentId);
		}
		set
		{
			DocumentId = new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value);
			NotifyPropertyChanged("Identification");
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcDocumentInformation.Name
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

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcDocumentInformation.Description
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
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 4)]
	IfcURIReference? IIfcDocumentInformation.Location
	{
		get
		{
			IfcDocumentReference ifcDocumentReference = DocumentReferences.FirstOrDefault((IfcDocumentReference r) => r.Location.HasValue);
			IfcURIReference value;
			if (!(ifcDocumentReference != null))
			{
				value = null;
			}
			else
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel? location = ifcDocumentReference.Location;
				value = new IfcURIReference(location.HasValue ? ((string)location.GetValueOrDefault()) : null);
			}
			return value;
		}
		set
		{
			IfcDocumentReference ifcDocumentReference = DocumentReferences.FirstOrDefault((IfcDocumentReference r) => r.Location.HasValue);
			if (!value.HasValue)
			{
				if (ifcDocumentReference != null)
				{
					ifcDocumentReference.Location = null;
				}
			}
			else
			{
				if (ifcDocumentReference == null)
				{
					ifcDocumentReference = base.Model.Instances.New<IfcDocumentReference>();
					DocumentReferences.Add(ifcDocumentReference);
				}
				ifcDocumentReference.Location = value.Value.ToString();
			}
			NotifyPropertyChanged("Location");
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcDocumentInformation.Purpose
	{
		get
		{
			if (!Purpose.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Purpose.Value);
		}
		set
		{
			Purpose = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 6)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcDocumentInformation.IntendedUse
	{
		get
		{
			if (!IntendedUse.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(IntendedUse.Value);
		}
		set
		{
			IntendedUse = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 7)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcDocumentInformation.Scope
	{
		get
		{
			if (!Scope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Scope.Value);
		}
		set
		{
			Scope = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDocumentInformation.Revision
	{
		get
		{
			if (!Revision.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Revision.Value);
		}
		set
		{
			Revision = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 9)]
	IIfcActorSelect IIfcDocumentInformation.DocumentOwner
	{
		get
		{
			if (DocumentOwner == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = DocumentOwner as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = DocumentOwner as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = DocumentOwner as IfcPersonAndOrganization;
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
				DocumentOwner = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				DocumentOwner = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				DocumentOwner = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				DocumentOwner = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 10)]
	IItemSet<IIfcActorSelect> IIfcDocumentInformation.Editors => new ProxyItemSet<IfcActorSelect, IIfcActorSelect>(Editors);

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 11)]
	IfcDateTime? IIfcDocumentInformation.CreationTime
	{
		get
		{
			return (CreationTime != null) ? new IfcDateTime(CreationTime.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				CreationTime = null;
				return;
			}
			DateTime d = value.Value;
			CreationTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 12)]
	IfcDateTime? IIfcDocumentInformation.LastRevisionTime
	{
		get
		{
			return (LastRevisionTime != null) ? new IfcDateTime(LastRevisionTime.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				LastRevisionTime = null;
				return;
			}
			DateTime d = value.Value;
			LastRevisionTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 13)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcDocumentInformation.ElectronicFormat
	{
		get
		{
			if (ElectronicFormat == null)
			{
				return null;
			}
			if (ElectronicFormat.MimeContentType.HasValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier(ElectronicFormat.MimeContentType.Value);
			}
			if (!ElectronicFormat.FileExtension.HasValue)
			{
				return null;
			}
			string text = ElectronicFormat.FileExtension.Value;
			text = text.Trim(new char[1] { '.' }).ToLowerInvariant();
			string value;
			return MimeTypeLookUp.Types.TryGetValue(text, out value) ? value : null;
		}
		set
		{
			if (!value.HasValue)
			{
				if (!(ElectronicFormat == null))
				{
					ElectronicFormat.MimeContentType = null;
				}
				return;
			}
			if (ElectronicFormat == null)
			{
				ElectronicFormat = base.Model.Instances.New<IfcDocumentElectronicFormat>();
			}
			ElectronicFormat.MimeContentType = value.Value.ToString();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 14)]
	IfcDate? IIfcDocumentInformation.ValidFrom
	{
		get
		{
			return (ValidFrom != null) ? new IfcDate(ValidFrom.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				ValidFrom = null;
				return;
			}
			DateTime date = value.Value;
			ValidFrom = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 15)]
	IfcDate? IIfcDocumentInformation.ValidUntil
	{
		get
		{
			return (ValidUntil != null) ? new IfcDate(ValidUntil.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				ValidUntil = null;
				return;
			}
			DateTime date = value.Value;
			ValidUntil = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 16)]
	Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum? IIfcDocumentInformation.Confidentiality
	{
		get
		{
			return Confidentiality switch
			{
				IfcDocumentConfidentialityEnum.PUBLIC => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.PUBLIC, 
				IfcDocumentConfidentialityEnum.RESTRICTED => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.RESTRICTED, 
				IfcDocumentConfidentialityEnum.CONFIDENTIAL => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.CONFIDENTIAL, 
				IfcDocumentConfidentialityEnum.PERSONAL => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.PERSONAL, 
				IfcDocumentConfidentialityEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.USERDEFINED, 
				IfcDocumentConfidentialityEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.PUBLIC:
				Confidentiality = IfcDocumentConfidentialityEnum.PUBLIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.RESTRICTED:
				Confidentiality = IfcDocumentConfidentialityEnum.RESTRICTED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.CONFIDENTIAL:
				Confidentiality = IfcDocumentConfidentialityEnum.CONFIDENTIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.PERSONAL:
				Confidentiality = IfcDocumentConfidentialityEnum.PERSONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.USERDEFINED:
				Confidentiality = IfcDocumentConfidentialityEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentConfidentialityEnum.NOTDEFINED:
				Confidentiality = IfcDocumentConfidentialityEnum.NOTDEFINED;
				break;
			case null:
				Confidentiality = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDocumentInformation), 17)]
	Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum? IIfcDocumentInformation.Status
	{
		get
		{
			return Status switch
			{
				IfcDocumentStatusEnum.DRAFT => Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.DRAFT, 
				IfcDocumentStatusEnum.FINALDRAFT => Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.FINALDRAFT, 
				IfcDocumentStatusEnum.FINAL => Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.FINAL, 
				IfcDocumentStatusEnum.REVISION => Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.REVISION, 
				IfcDocumentStatusEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.DRAFT:
				Status = IfcDocumentStatusEnum.DRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.FINALDRAFT:
				Status = IfcDocumentStatusEnum.FINALDRAFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.FINAL:
				Status = IfcDocumentStatusEnum.FINAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.REVISION:
				Status = IfcDocumentStatusEnum.REVISION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDocumentStatusEnum.NOTDEFINED:
				Status = IfcDocumentStatusEnum.NOTDEFINED;
				break;
			case null:
				Status = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelAssociatesDocument> IIfcDocumentInformation.DocumentInfoForObjects => base.Model.Instances.Where((IIfcRelAssociatesDocument e) => e.RelatingDocument as IfcDocumentInformation == this, "RelatingDocument", this);

	IEnumerable<IIfcDocumentReference> IIfcDocumentInformation.HasDocumentReferences => base.Model.Instances.Where((IIfcDocumentReference e) => e.ReferencedDocument as IfcDocumentInformation == this, "ReferencedDocument", this);

	IEnumerable<IIfcDocumentInformationRelationship> IIfcDocumentInformation.IsPointedTo => base.Model.Instances.Where((IIfcDocumentInformationRelationship e) => e.RelatedDocuments != null && e.RelatedDocuments.Contains(this), "RelatedDocuments", this);

	IEnumerable<IIfcDocumentInformationRelationship> IIfcDocumentInformation.IsPointer => base.Model.Instances.Where((IIfcDocumentInformationRelationship e) => e.RelatingDocument as IfcDocumentInformation == this, "RelatingDocument", this);

	internal IfcDocumentInformation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_documentReferences = new OptionalItemSet<IfcDocumentReference>(this, 0, 4);
		_editors = new OptionalItemSet<IfcActorSelect>(this, 0, 10);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_documentId = value.StringVal;
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_documentReferences.InternalAdd((IfcDocumentReference)value.EntityVal);
			break;
		case 4:
			_purpose = value.StringVal;
			break;
		case 5:
			_intendedUse = value.StringVal;
			break;
		case 6:
			_scope = value.StringVal;
			break;
		case 7:
			_revision = value.StringVal;
			break;
		case 8:
			_documentOwner = (IfcActorSelect)value.EntityVal;
			break;
		case 9:
			_editors.InternalAdd((IfcActorSelect)value.EntityVal);
			break;
		case 10:
			_creationTime = (IfcDateAndTime)value.EntityVal;
			break;
		case 11:
			_lastRevisionTime = (IfcDateAndTime)value.EntityVal;
			break;
		case 12:
			_electronicFormat = (IfcDocumentElectronicFormat)value.EntityVal;
			break;
		case 13:
			_validFrom = (IfcCalendarDate)value.EntityVal;
			break;
		case 14:
			_validUntil = (IfcCalendarDate)value.EntityVal;
			break;
		case 15:
			_confidentiality = (IfcDocumentConfidentialityEnum)Enum.Parse(typeof(IfcDocumentConfidentialityEnum), value.EnumVal, ignoreCase: true);
			break;
		case 16:
			_status = (IfcDocumentStatusEnum)Enum.Parse(typeof(IfcDocumentStatusEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDocumentInformation other)
	{
		return this == other;
	}
}
