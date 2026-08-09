using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ExternalReferenceResource;

namespace Xbim.Ifc4x3.ApprovalResource;

[ExpressType("IfcApprovalRelationship", 552)]
public class IfcApprovalRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcApprovalRelationship>, IIfcApprovalRelationship, IIfcResourceLevelRelationship
{
	private IfcApproval _relatingApproval;

	private readonly ItemSet<IfcApproval> _relatedApprovals;

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _relatingApproval, value, "RelatingApproval", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcApproval> RelatedApprovals
	{
		get
		{
			if (_activated)
			{
				return _relatedApprovals;
			}
			Activate();
			return _relatedApprovals;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
			foreach (IfcApproval relatedApproval in RelatedApprovals)
			{
				yield return relatedApproval;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
			foreach (IfcApproval relatedApproval in RelatedApprovals)
			{
				yield return relatedApproval;
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
	IItemSet<IIfcApproval> IIfcApprovalRelationship.RelatedApprovals => new ProxyItemSet<IfcApproval, IIfcApproval>(RelatedApprovals);

	internal IfcApprovalRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedApprovals = new ItemSet<IfcApproval>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_relatingApproval = (IfcApproval)value.EntityVal;
			break;
		case 3:
			_relatedApprovals.InternalAdd((IfcApproval)value.EntityVal);
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
