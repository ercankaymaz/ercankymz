using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PropertyResource;

namespace Xbim.Ifc2x3.ApprovalResource;

[ExpressType("IfcApprovalPropertyRelationship", 376)]
public class IfcApprovalPropertyRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcApprovalPropertyRelationship>
{
	private readonly ItemSet<IfcProperty> _approvedProperties;

	private IfcApproval _approval;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcProperty> ApprovedProperties
	{
		get
		{
			if (_activated)
			{
				return _approvedProperties;
			}
			Activate();
			return _approvedProperties;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcApproval Approval
	{
		get
		{
			if (_activated)
			{
				return _approval;
			}
			Activate();
			return _approval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApproval v)
			{
				_approval = v;
			}, _approval, value, "Approval", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcProperty approvedProperty in ApprovedProperties)
			{
				yield return approvedProperty;
			}
			if (Approval != null)
			{
				yield return Approval;
			}
		}
	}

	internal IfcApprovalPropertyRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_approvedProperties = new ItemSet<IfcProperty>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_approvedProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		case 1:
			_approval = (IfcApproval)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcApprovalPropertyRelationship other)
	{
		return this == other;
	}
}
