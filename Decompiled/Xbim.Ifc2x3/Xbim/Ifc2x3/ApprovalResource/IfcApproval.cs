using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ApprovalResource;

[ExpressType("IfcApproval", 626)]
public class IfcApproval : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcApproval>, IIfcApproval, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private IfcDateTimeSelect _approvalDateTime;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _approvalStatus;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _approvalLevel;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _approvalQualifier;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _identifier;

	private IIfcActorSelect _requestingApproval;

	private IIfcActorSelect _givingApproval;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
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
			}, _description, value, "Description", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcDateTimeSelect ApprovalDateTime
	{
		get
		{
			if (_activated)
			{
				return _approvalDateTime;
			}
			Activate();
			return _approvalDateTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_approvalDateTime = v;
			}, _approvalDateTime, value, "ApprovalDateTime", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ApprovalStatus
	{
		get
		{
			if (_activated)
			{
				return _approvalStatus;
			}
			Activate();
			return _approvalStatus;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_approvalStatus = v;
			}, _approvalStatus, value, "ApprovalStatus", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ApprovalLevel
	{
		get
		{
			if (_activated)
			{
				return _approvalLevel;
			}
			Activate();
			return _approvalLevel;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_approvalLevel = v;
			}, _approvalLevel, value, "ApprovalLevel", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? ApprovalQualifier
	{
		get
		{
			if (_activated)
			{
				return _approvalQualifier;
			}
			Activate();
			return _approvalQualifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_approvalQualifier = v;
			}, _approvalQualifier, value, "ApprovalQualifier", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _name, value, "Name", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier Identifier
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 7);
		}
	}

	[InverseProperty("Approval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcApprovalActorRelationship> Actors => base.Model.Instances.Where((IfcApprovalActorRelationship e) => Equals(e.Approval), "Approval", this);

	[InverseProperty("RelatedApproval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcApprovalRelationship> IsRelatedWith => base.Model.Instances.Where((IfcApprovalRelationship e) => Equals(e.RelatedApproval), "RelatedApproval", this);

	[InverseProperty("RelatingApproval")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 10)]
	public IEnumerable<IfcApprovalRelationship> Relates => base.Model.Instances.Where((IfcApprovalRelationship e) => Equals(e.RelatingApproval), "RelatingApproval", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ApprovalDateTime != null)
			{
				yield return ApprovalDateTime;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcApproval.Identifier
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identifier);
		}
		set
		{
			Identifier = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcIdentifier));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcLabel));
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
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 4)]
	IfcDateTime? IIfcApproval.TimeOfApproval
	{
		get
		{
			return (ApprovalDateTime != null) ? new IfcDateTime(ApprovalDateTime.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				ApprovalDateTime = null;
				return;
			}
			DateTime d = value.Value;
			ApprovalDateTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
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
			NotifyPropertyChanged("TimeOfApproval");
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Status
	{
		get
		{
			if (!ApprovalStatus.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ApprovalStatus.Value);
		}
		set
		{
			ApprovalStatus = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcApproval.Level
	{
		get
		{
			if (!ApprovalLevel.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ApprovalLevel.Value);
		}
		set
		{
			ApprovalLevel = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 7)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcApproval.Qualifier
	{
		get
		{
			if (!ApprovalQualifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(ApprovalQualifier.Value);
		}
		set
		{
			ApprovalQualifier = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 8)]
	IIfcActorSelect IIfcApproval.RequestingApproval
	{
		get
		{
			return _requestingApproval;
		}
		set
		{
			SetValue(delegate(IIfcActorSelect v)
			{
				_requestingApproval = v;
			}, _requestingApproval, value, "RequestingApproval", -8);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApproval), 9)]
	IIfcActorSelect IIfcApproval.GivingApproval
	{
		get
		{
			return _givingApproval;
		}
		set
		{
			SetValue(delegate(IIfcActorSelect v)
			{
				_givingApproval = v;
			}, _givingApproval, value, "GivingApproval", -9);
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
			_description = value.StringVal;
			break;
		case 1:
			_approvalDateTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 2:
			_approvalStatus = value.StringVal;
			break;
		case 3:
			_approvalLevel = value.StringVal;
			break;
		case 4:
			_approvalQualifier = value.StringVal;
			break;
		case 5:
			_name = value.StringVal;
			break;
		case 6:
			_identifier = value.StringVal;
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
