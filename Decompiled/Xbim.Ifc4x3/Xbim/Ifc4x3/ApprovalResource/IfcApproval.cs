using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.ControlExtension;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ApprovalResource;

[ExpressType("IfcApproval", 626)]
public class IfcApproval : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IExpressSelectType, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcApproval>, IIfcApproval, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identifier;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _timeOfApproval;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _level;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _qualifier;

	private IfcActorSelect _requestingApproval;

	private IfcActorSelect _givingApproval;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Identifier
	{
		get
		{
			if (_activated)
			{
				return _identifier;
			}
			Activate();
			return _identifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? TimeOfApproval
	{
		get
		{
			if (_activated)
			{
				return _timeOfApproval;
			}
			Activate();
			return _timeOfApproval;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
			{
				_timeOfApproval = v;
			}, _timeOfApproval, value, "TimeOfApproval", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Status
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Level
	{
		get
		{
			if (_activated)
			{
				return _level;
			}
			Activate();
			return _level;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_level = v;
			}, _level, value, "Level", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Qualifier
	{
		get
		{
			if (_activated)
			{
				return _qualifier;
			}
			Activate();
			return _qualifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_qualifier = v;
			}, _qualifier, value, "Qualifier", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcActorSelect RequestingApproval
	{
		get
		{
			if (_activated)
			{
				return _requestingApproval;
			}
			Activate();
			return _requestingApproval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_requestingApproval = v;
			}, _requestingApproval, value, "RequestingApproval", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public IfcActorSelect GivingApproval
	{
		get
		{
			if (_activated)
			{
				return _givingApproval;
			}
			Activate();
			return _givingApproval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_givingApproval = v;
			}, _givingApproval, value, "GivingApproval", 9);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 10)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("RelatingApproval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelAssociatesApproval> ApprovedObjects => base.Model.Instances.Where((IfcRelAssociatesApproval e) => Equals(e.RelatingApproval), "RelatingApproval", this);

	[InverseProperty("RelatingApproval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 12)]
	public IEnumerable<IfcResourceApprovalRelationship> ApprovedResources => base.Model.Instances.Where((IfcResourceApprovalRelationship e) => Equals(e.RelatingApproval), "RelatingApproval", this);

	[InverseProperty("RelatedApprovals")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 13)]
	public IEnumerable<IfcApprovalRelationship> IsRelatedWith => base.Model.Instances.Where((IfcApprovalRelationship e) => e.RelatedApprovals != null && e.RelatedApprovals.Contains(this), "RelatedApprovals", this);

	[InverseProperty("RelatingApproval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 14)]
	public IEnumerable<IfcApprovalRelationship> Relates => base.Model.Instances.Where((IfcApprovalRelationship e) => Equals(e.RelatingApproval), "RelatingApproval", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RequestingApproval != null)
			{
				yield return RequestingApproval;
			}
			if (GivingApproval != null)
			{
				yield return GivingApproval;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcApproval.Identifier
	{
		get
		{
			if (!Identifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identifier.Value);
		}
		set
		{
			Identifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcApproval.Description
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

	[CrossSchemaAttribute(typeof(IIfcApproval), 4)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcApproval.TimeOfApproval
	{
		get
		{
			if (!TimeOfApproval.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(TimeOfApproval.Value);
		}
		set
		{
			TimeOfApproval = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Status
	{
		get
		{
			if (!Status.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Status.Value);
		}
		set
		{
			Status = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Level
	{
		get
		{
			if (!Level.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Level.Value);
		}
		set
		{
			Level = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 7)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcApproval.Qualifier
	{
		get
		{
			if (!Qualifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Qualifier.Value);
		}
		set
		{
			Qualifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 8)]
	IIfcActorSelect IIfcApproval.RequestingApproval
	{
		get
		{
			if (RequestingApproval == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = RequestingApproval as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = RequestingApproval as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = RequestingApproval as IfcPersonAndOrganization;
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
				RequestingApproval = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				RequestingApproval = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				RequestingApproval = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				RequestingApproval = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 9)]
	IIfcActorSelect IIfcApproval.GivingApproval
	{
		get
		{
			if (GivingApproval == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = GivingApproval as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = GivingApproval as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = GivingApproval as IfcPersonAndOrganization;
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
				GivingApproval = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				GivingApproval = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				GivingApproval = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				GivingApproval = ifcPersonAndOrganization;
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcApproval.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcRelAssociatesApproval> IIfcApproval.ApprovedObjects => base.Model.Instances.Where((IIfcRelAssociatesApproval e) => e.RelatingApproval as IfcApproval == this, "RelatingApproval", this);

	IEnumerable<IIfcResourceApprovalRelationship> IIfcApproval.ApprovedResources => base.Model.Instances.Where((IIfcResourceApprovalRelationship e) => e.RelatingApproval as IfcApproval == this, "RelatingApproval", this);

	IEnumerable<IIfcApprovalRelationship> IIfcApproval.IsRelatedWith => base.Model.Instances.Where((IIfcApprovalRelationship e) => e.RelatedApprovals != null && e.RelatedApprovals.Contains(this), "RelatedApprovals", this);

	IEnumerable<IIfcApprovalRelationship> IIfcApproval.Relates => base.Model.Instances.Where((IIfcApprovalRelationship e) => e.RelatingApproval as IfcApproval == this, "RelatingApproval", this);

	internal IfcApproval(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_identifier = value.StringVal;
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_timeOfApproval = value.StringVal;
			break;
		case 4:
			_status = value.StringVal;
			break;
		case 5:
			_level = value.StringVal;
			break;
		case 6:
			_qualifier = value.StringVal;
			break;
		case 7:
			_requestingApproval = (IfcActorSelect)value.EntityVal;
			break;
		case 8:
			_givingApproval = (IfcActorSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcApproval other)
	{
		return this == other;
	}
}
