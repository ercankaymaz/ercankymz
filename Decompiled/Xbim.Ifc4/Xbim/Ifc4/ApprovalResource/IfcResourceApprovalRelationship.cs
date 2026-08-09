using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ApprovalResource;

[ExpressType("IfcResourceApprovalRelationship", 1256)]
public class IfcResourceApprovalRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcResourceApprovalRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcResourceApprovalRelationship>
{
	private readonly ItemSet<IfcResourceObjectSelect> _relatedResourceObjects;

	private IfcApproval _relatingApproval;

	IItemSet<IIfcResourceObjectSelect> IIfcResourceApprovalRelationship.RelatedResourceObjects => new ProxyItemSet<IfcResourceObjectSelect, IIfcResourceObjectSelect>(RelatedResourceObjects);

	IIfcApproval IIfcResourceApprovalRelationship.RelatingApproval
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

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcResourceObjectSelect> RelatedResourceObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedResourceObjects;
			}
			Activate();
			return _relatedResourceObjects;
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			}, _relatingApproval, value, "RelatingApproval", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcResourceObjectSelect relatedResourceObject in RelatedResourceObjects)
			{
				yield return relatedResourceObject;
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
			foreach (IfcResourceObjectSelect relatedResourceObject in RelatedResourceObjects)
			{
				yield return relatedResourceObject;
			}
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
		}
	}

	internal IfcResourceApprovalRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedResourceObjects = new ItemSet<IfcResourceObjectSelect>(this, 0, 3);
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
			_relatedResourceObjects.InternalAdd((IfcResourceObjectSelect)value.EntityVal);
			break;
		case 3:
			_relatingApproval = (IfcApproval)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcResourceApprovalRelationship other)
	{
		return this == other;
	}
}
