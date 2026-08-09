using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ApprovalResource;

[ExpressType("IfcApprovalRelationship", 552)]
public class IfcApprovalRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcApprovalRelationship>, IIfcApprovalRelationship, IIfcResourceLevelRelationship
{
	private IfcApproval _relatedApproval;

	private IfcApproval _relatingApproval;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private IItemSet<IIfcApproval> _relatedApprovals;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcApproval RelatedApproval
	{
		get
		{
			if (_activated)
			{
				return _relatedApproval;
			}
			Activate();
			return _relatedApproval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApproval v)
			{
				_relatedApproval = v;
			}, _relatedApproval, value, "RelatedApproval", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcApproval RelatingApproval
	{
		get
		{
			if (_activated)
			{
				return _relatingApproval;
			}
			Activate();
			return _relatingApproval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApproval v)
			{
				_relatingApproval = v;
			}, _relatingApproval, value, "RelatingApproval", 2);
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

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _name, value, "Name", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatedApproval != null)
			{
				yield return RelatedApproval;
			}
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatedApproval != null)
			{
				yield return RelatedApproval;
			}
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApprovalRelationship), 3)]
	IIfcApproval IIfcApprovalRelationship.RelatingApproval
	{
		get
		{
			return RelatingApproval;
		}
		set
		{
			RelatingApproval = value as IfcApproval;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcApprovalRelationship), 4)]
	IItemSet<IIfcApproval> IIfcApprovalRelationship.RelatedApprovals => _relatedApprovals ?? (_relatedApprovals = new ExtendedSingleSet<IfcApproval, IIfcApproval>(() => RelatedApproval, delegate(IfcApproval approval)
	{
		RelatedApproval = approval;
	}, new ItemSet<IIfcApproval>(this, 0, -4), (IfcApproval s) => s, (IIfcApproval t) => t as IfcApproval));

	[CrossSchemaAttribute(typeof(IIfcApprovalRelationship), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceLevelRelationship.Name
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

	[CrossSchemaAttribute(typeof(IIfcApprovalRelationship), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcResourceLevelRelationship.Description
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

	internal IfcApprovalRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relatedApproval = (IfcApproval)value.EntityVal;
			break;
		case 1:
			_relatingApproval = (IfcApproval)value.EntityVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcApprovalRelationship other)
	{
		return this == other;
	}
}
