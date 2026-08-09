using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.SharedBldgServiceElements;

[ExpressType("IfcRelFlowControlElements", 360)]
public class IfcRelFlowControlElements : IfcRelConnects, IIfcRelFlowControlElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelFlowControlElements>
{
	private readonly ItemSet<IfcDistributionControlElement> _relatedControlElements;

	private IfcDistributionFlowElement _relatingFlowElement;

	[CrossSchemaAttribute(typeof(IIfcRelFlowControlElements), 5)]
	IItemSet<IIfcDistributionControlElement> IIfcRelFlowControlElements.RelatedControlElements => new ProxyItemSet<IfcDistributionControlElement, IIfcDistributionControlElement>(RelatedControlElements);

	[CrossSchemaAttribute(typeof(IIfcRelFlowControlElements), 6)]
	IIfcDistributionFlowElement IIfcRelFlowControlElements.RelatingFlowElement
	{
		get
		{
			return RelatingFlowElement;
		}
		set
		{
			RelatingFlowElement = value as IfcDistributionFlowElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcDistributionControlElement> RelatedControlElements
	{
		get
		{
			if (_activated)
			{
				return _relatedControlElements;
			}
			Activate();
			return _relatedControlElements;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDistributionFlowElement RelatingFlowElement
	{
		get
		{
			if (_activated)
			{
				return _relatingFlowElement;
			}
			Activate();
			return _relatingFlowElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDistributionFlowElement v)
			{
				_relatingFlowElement = v;
			}, _relatingFlowElement, value, "RelatingFlowElement", 6);
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
			foreach (IfcDistributionControlElement relatedControlElement in RelatedControlElements)
			{
				yield return relatedControlElement;
			}
			if (RelatingFlowElement != null)
			{
				yield return RelatingFlowElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDistributionControlElement relatedControlElement in RelatedControlElements)
			{
				yield return relatedControlElement;
			}
			if (RelatingFlowElement != null)
			{
				yield return RelatingFlowElement;
			}
		}
	}

	internal IfcRelFlowControlElements(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedControlElements = new ItemSet<IfcDistributionControlElement>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatedControlElements.InternalAdd((IfcDistributionControlElement)value.EntityVal);
			break;
		case 5:
			_relatingFlowElement = (IfcDistributionFlowElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelFlowControlElements other)
	{
		return this == other;
	}
}
