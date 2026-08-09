using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcDocumentInformation", 208)]
public class IfcDocumentInformation : IfcExternalInformation, IInstantiableEntity, IPersistEntity, IPersist, IIfcDocumentInformation, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcDocumentSelect, IIfcDocumentSelect, IContainsEntityReferences, IEquatable<IfcDocumentInformation>
{
	private IfcIdentifier _identification;

	private IfcLabel _name;

	private IfcText? _description;

	private IfcURIReference? _location;

	private IfcText? _purpose;

	private IfcText? _intendedUse;

	private IfcText? _scope;

	private IfcLabel? _revision;

	private IfcActorSelect _documentOwner;

	private readonly OptionalItemSet<IfcActorSelect> _editors;

	private IfcDateTime? _creationTime;

	private IfcDateTime? _lastRevisionTime;

	private IfcIdentifier? _electronicFormat;

	private IfcDate? _validFrom;

	private IfcDate? _validUntil;

	private IfcDocumentConfidentialityEnum? _confidentiality;

	private IfcDocumentStatusEnum? _status;

	IfcIdentifier IIfcDocumentInformation.Identification
	{
		get
		{
			return Identification;
		}
		set
		{
			Identification = value;
		}
	}

	IfcLabel IIfcDocumentInformation.Name
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

	IfcText? IIfcDocumentInformation.Description
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

	IfcURIReference? IIfcDocumentInformation.Location
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

	IfcText? IIfcDocumentInformation.Purpose
	{
		get
		{
			return Purpose;
		}
		set
		{
			Purpose = value;
		}
	}

	IfcText? IIfcDocumentInformation.IntendedUse
	{
		get
		{
			return IntendedUse;
		}
		set
		{
			IntendedUse = value;
		}
	}

	IfcText? IIfcDocumentInformation.Scope
	{
		get
		{
			return Scope;
		}
		set
		{
			Scope = value;
		}
	}

	IfcLabel? IIfcDocumentInformation.Revision
	{
		get
		{
			return Revision;
		}
		set
		{
			Revision = value;
		}
	}

	IIfcActorSelect IIfcDocumentInformation.DocumentOwner
	{
		get
		{
			return DocumentOwner;
		}
		set
		{
			DocumentOwner = value as IfcActorSelect;
		}
	}

	IItemSet<IIfcActorSelect> IIfcDocumentInformation.Editors => new ProxyItemSet<IfcActorSelect, IIfcActorSelect>(Editors);

	IfcDateTime? IIfcDocumentInformation.CreationTime
	{
		get
		{
			return CreationTime;
		}
		set
		{
			CreationTime = value;
		}
	}

	IfcDateTime? IIfcDocumentInformation.LastRevisionTime
	{
		get
		{
			return LastRevisionTime;
		}
		set
		{
			LastRevisionTime = value;
		}
	}

	IfcIdentifier? IIfcDocumentInformation.ElectronicFormat
	{
		get
		{
			return ElectronicFormat;
		}
		set
		{
			ElectronicFormat = value;
		}
	}

	IfcDate? IIfcDocumentInformation.ValidFrom
	{
		get
		{
			return ValidFrom;
		}
		set
		{
			ValidFrom = value;
		}
	}

	IfcDate? IIfcDocumentInformation.ValidUntil
	{
		get
		{
			return ValidUntil;
		}
		set
		{
			ValidUntil = value;
		}
	}

	IfcDocumentConfidentialityEnum? IIfcDocumentInformation.Confidentiality
	{
		get
		{
			return Confidentiality;
		}
		set
		{
			Confidentiality = value;
		}
	}

	IfcDocumentStatusEnum? IIfcDocumentInformation.Status
	{
		get
		{
			return Status;
		}
		set
		{
			Status = value;
		}
	}

	IEnumerable<IIfcRelAssociatesDocument> IIfcDocumentInformation.DocumentInfoForObjects => DocumentInfoForObjects;

	IEnumerable<IIfcDocumentReference> IIfcDocumentInformation.HasDocumentReferences => HasDocumentReferences;

	IEnumerable<IIfcDocumentInformationRelationship> IIfcDocumentInformation.IsPointedTo => IsPointedTo;

	IEnumerable<IIfcDocumentInformationRelationship> IIfcDocumentInformation.IsPointer => IsPointer;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcIdentifier Identification
	{
		get
		{
			if (_activated)
			{
				return _identification;
			}
			Activate();
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_identification = v;
			}, _identification, value, "Identification", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _location, value, "Location", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcText? Purpose
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
			SetValue(delegate(IfcText? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcText? IntendedUse
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
			SetValue(delegate(IfcText? v)
			{
				_intendedUse = v;
			}, _intendedUse, value, "IntendedUse", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcText? Scope
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
			SetValue(delegate(IfcText? v)
			{
				_scope = v;
			}, _scope, value, "Scope", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLabel? Revision
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
			SetValue(delegate(IfcLabel? v)
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcDateTime? CreationTime
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
			SetValue(delegate(IfcDateTime? v)
			{
				_creationTime = v;
			}, _creationTime, value, "CreationTime", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcDateTime? LastRevisionTime
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
			SetValue(delegate(IfcDateTime? v)
			{
				_lastRevisionTime = v;
			}, _lastRevisionTime, value, "LastRevisionTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcIdentifier? ElectronicFormat
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_electronicFormat = v;
			}, _electronicFormat, value, "ElectronicFormat", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcDate? ValidFrom
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
			SetValue(delegate(IfcDate? v)
			{
				_validFrom = v;
			}, _validFrom, value, "ValidFrom", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcDate? ValidUntil
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
			SetValue(delegate(IfcDate? v)
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

	[InverseProperty("RelatingDocument")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelAssociatesDocument> DocumentInfoForObjects => base.Model.Instances.Where((IfcRelAssociatesDocument e) => Equals(e.RelatingDocument), "RelatingDocument", this);

	[InverseProperty("ReferencedDocument")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 19)]
	public IEnumerable<IfcDocumentReference> HasDocumentReferences => base.Model.Instances.Where((IfcDocumentReference e) => Equals(e.ReferencedDocument), "ReferencedDocument", this);

	[InverseProperty("RelatedDocuments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 20)]
	public IEnumerable<IfcDocumentInformationRelationship> IsPointedTo => base.Model.Instances.Where((IfcDocumentInformationRelationship e) => e.RelatedDocuments != null && e.RelatedDocuments.Contains(this), "RelatedDocuments", this);

	[InverseProperty("RelatingDocument")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 21)]
	public IEnumerable<IfcDocumentInformationRelationship> IsPointer => base.Model.Instances.Where((IfcDocumentInformationRelationship e) => Equals(e.RelatingDocument), "RelatingDocument", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DocumentOwner != null)
			{
				yield return DocumentOwner;
			}
			foreach (IfcActorSelect editor in Editors)
			{
				yield return editor;
			}
		}
	}

	internal IfcDocumentInformation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_editors = new OptionalItemSet<IfcActorSelect>(this, 0, 10);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_identification = value.StringVal;
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_location = value.StringVal;
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
			_creationTime = value.StringVal;
			break;
		case 11:
			_lastRevisionTime = value.StringVal;
			break;
		case 12:
			_electronicFormat = value.StringVal;
			break;
		case 13:
			_validFrom = value.StringVal;
			break;
		case 14:
			_validUntil = value.StringVal;
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
