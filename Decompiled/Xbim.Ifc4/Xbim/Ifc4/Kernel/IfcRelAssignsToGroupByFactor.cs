using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssignsToGroupByFactor", 1248)]
public class IfcRelAssignsToGroupByFactor : IfcRelAssignsToGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssignsToGroupByFactor, IIfcRelAssignsToGroup, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToGroupByFactor>
{
	private IfcRatioMeasure _factor;

	IfcRatioMeasure IIfcRelAssignsToGroupByFactor.Factor
	{
		get
		{
			return Factor;
		}
		set
		{
			Factor = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcRatioMeasure Factor
	{
		get
		{
			if (_activated)
			{
				return _factor;
			}
			Activate();
			return _factor;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure v)
			{
				_factor = v;
			}, _factor, value, "Factor", 8);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingGroup != null)
			{
				yield return base.RelatingGroup;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingGroup != null)
			{
				yield return base.RelatingGroup;
			}
		}
	}

	internal IfcRelAssignsToGroupByFactor(IModel model, int label, bool activated)
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
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_factor = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToGroupByFactor other)
	{
		return this == other;
	}
}
