using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcEdgeLoop", 302)]
public class IfcEdgeLoop : IfcLoop, IIfcEdgeLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcEdgeLoop>
{
	private readonly ItemSet<IfcOrientedEdge> _edgeList;

	[CrossSchemaAttribute(typeof(IIfcEdgeLoop), 1)]
	IItemSet<IIfcOrientedEdge> IIfcEdgeLoop.EdgeList => new ProxyItemSet<IfcOrientedEdge, IIfcOrientedEdge>(EdgeList);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcEdgeLoop.Ne => new Xbim.Ifc4.MeasureResource.IfcInteger(Ne);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcOrientedEdge> EdgeList
	{
		get
		{
			if (_activated)
			{
				return _edgeList;
			}
			Activate();
			return _edgeList;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger Ne => EdgeList.Count;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcOrientedEdge edge in EdgeList)
			{
				yield return edge;
			}
		}
	}

	internal IfcEdgeLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_edgeList = new ItemSet<IfcOrientedEdge>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_edgeList.InternalAdd((IfcOrientedEdge)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcEdgeLoop other)
	{
		return this == other;
	}
}
