using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.Kernel;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcRelAssociatesAppliedValue", 699)]
public class IfcRelAssociatesAppliedValue : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesAppliedValue>
{
	private IfcAppliedValue _relatingAppliedValue;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcAppliedValue RelatingAppliedValue
	{
		get
		{
			if (_activated)
			{
				return _relatingAppliedValue;
			}
			Activate();
			return _relatingAppliedValue;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAppliedValue v)
			{
				_relatingAppliedValue = v;
			}, _relatingAppliedValue, value, "RelatingAppliedValue", 6);
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingAppliedValue != null)
			{
				yield return RelatingAppliedValue;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAssociatesAppliedValue(IModel model, int label, bool activated)
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
			_relatingAppliedValue = (IfcAppliedValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesAppliedValue other)
	{
		return this == other;
	}
}
