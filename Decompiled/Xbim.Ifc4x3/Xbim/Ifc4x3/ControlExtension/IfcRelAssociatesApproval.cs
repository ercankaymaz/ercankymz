using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ApprovalResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ControlExtension;

[ExpressType("IfcRelAssociatesApproval", 342)]
public class IfcRelAssociatesApproval : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesApproval>, IIfcRelAssociatesApproval, IIfcRelAssociates, IIfcRelationship, IIfcRoot
{
	private IfcApproval _relatingApproval;

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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
			}, _relatingApproval, value, "RelatingApproval", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingApproval != null)
			{
				yield return RelatingApproval;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesApproval), 6)]
	IIfcApproval IIfcRelAssociatesApproval.RelatingApproval
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

	internal IfcRelAssociatesApproval(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingApproval = (IfcApproval)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesApproval other)
	{
		return this == other;
	}
}
