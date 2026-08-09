using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ControlExtension;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ApprovalResource;

[ExpressType("IfcApproval", 626)]
public class IfcApproval : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcApproval, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcApproval>, IExpressValidatable
{
	public enum IfcApprovalClause
	{
		HasIdentifierOrName
	}

	private IfcIdentifier? _identifier;

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcDateTime? _timeOfApproval;

	private IfcLabel? _status;

	private IfcLabel? _level;

	private IfcText? _qualifier;

	private IfcActorSelect _requestingApproval;

	private IfcActorSelect _givingApproval;

	IfcIdentifier? IIfcApproval.Identifier
	{
		get
		{
			return Identifier;
		}
		set
		{
			Identifier = value;
		}
	}

	IfcLabel? IIfcApproval.Name
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

	IfcText? IIfcApproval.Description
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

	IfcDateTime? IIfcApproval.TimeOfApproval
	{
		get
		{
			return TimeOfApproval;
		}
		set
		{
			TimeOfApproval = value;
		}
	}

	IfcLabel? IIfcApproval.Status
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

	IfcLabel? IIfcApproval.Level
	{
		get
		{
			return Level;
		}
		set
		{
			Level = value;
		}
	}

	IfcText? IIfcApproval.Qualifier
	{
		get
		{
			return Qualifier;
		}
		set
		{
			Qualifier = value;
		}
	}

	IIfcActorSelect IIfcApproval.RequestingApproval
	{
		get
		{
			return RequestingApproval;
		}
		set
		{
			RequestingApproval = value as IfcActorSelect;
		}
	}

	IIfcActorSelect IIfcApproval.GivingApproval
	{
		get
		{
			return GivingApproval;
		}
		set
		{
			GivingApproval = value as IfcActorSelect;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcApproval.HasExternalReferences => HasExternalReferences;

	IEnumerable<IIfcRelAssociatesApproval> IIfcApproval.ApprovedObjects => ApprovedObjects;

	IEnumerable<IIfcResourceApprovalRelationship> IIfcApproval.ApprovedResources => ApprovedResources;

	IEnumerable<IIfcApprovalRelationship> IIfcApproval.IsRelatedWith => IsRelatedWith;

	IEnumerable<IIfcApprovalRelationship> IIfcApproval.Relates => Relates;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcIdentifier? Identifier
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
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
	public IfcDateTime? TimeOfApproval
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
			SetValue(delegate(IfcDateTime? v)
			{
				_timeOfApproval = v;
			}, _timeOfApproval, value, "TimeOfApproval", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? Status
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
			SetValue(delegate(IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLabel? Level
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
			SetValue(delegate(IfcLabel? v)
			{
				_level = v;
			}, _level, value, "Level", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcText? Qualifier
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
			SetValue(delegate(IfcText? v)
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
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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

	public bool ValidateClause(IfcApprovalClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcApprovalClause.HasIdentifierOrName)
			{
				result = Functions.EXISTS(Identifier) || Functions.EXISTS(Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcApproval>()?.LogError($"Exception thrown evaluating where-clause 'IfcApproval.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcApprovalClause.HasIdentifierOrName))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcApproval.HasIdentifierOrName",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
