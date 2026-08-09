using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRelCoversBldgElements", 24)]
public class IfcRelCoversBldgElements : IfcRelConnects, IIfcRelCoversBldgElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelCoversBldgElements>
{
	private IfcElement _relatingBuildingElement;

	private readonly ItemSet<IfcCovering> _relatedCoverings;

	[CrossSchemaAttribute(typeof(IIfcRelCoversBldgElements), 5)]
	IIfcElement IIfcRelCoversBldgElements.RelatingBuildingElement
	{
		get
		{
			return RelatingBuildingElement;
		}
		set
		{
			RelatingBuildingElement = value as IfcElement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelCoversBldgElements), 6)]
	IItemSet<IIfcCovering> IIfcRelCoversBldgElements.RelatedCoverings => new ProxyItemSet<IfcCovering, IIfcCovering>(RelatedCoverings);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcElement RelatingBuildingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingBuildingElement;
			}
			Activate();
			return _relatingBuildingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatingBuildingElement = v;
			}, _relatingBuildingElement, value, "RelatingBuildingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcCovering> RelatedCoverings
	{
		get
		{
			if (_activated)
			{
				return _relatedCoverings;
			}
			Activate();
			return _relatedCoverings;
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
			if (RelatingBuildingElement != null)
			{
				yield return RelatingBuildingElement;
			}
			foreach (IfcCovering relatedCovering in RelatedCoverings)
			{
				yield return relatedCovering;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingBuildingElement != null)
			{
				yield return RelatingBuildingElement;
			}
			foreach (IfcCovering relatedCovering in RelatedCoverings)
			{
				yield return relatedCovering;
			}
		}
	}

	internal IfcRelCoversBldgElements(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedCoverings = new ItemSet<IfcCovering>(this, 0, 6);
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
			_relatingBuildingElement = (IfcElement)value.EntityVal;
			break;
		case 5:
			_relatedCoverings.InternalAdd((IfcCovering)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelCoversBldgElements other)
	{
		return this == other;
	}
}
