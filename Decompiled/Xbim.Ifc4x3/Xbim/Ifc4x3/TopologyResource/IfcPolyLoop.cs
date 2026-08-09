using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcPolyLoop", 200)]
public class IfcPolyLoop : IfcLoop, IIfcPolyLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPolyLoop>
{
	private readonly ItemSet<IfcCartesianPoint> _polygon;

	[CrossSchemaAttribute(typeof(IIfcPolyLoop), 1)]
	IItemSet<IIfcCartesianPoint> IIfcPolyLoop.Polygon => new ProxyItemSet<IfcCartesianPoint, IIfcCartesianPoint>(Polygon);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 3)]
	public IItemSet<IfcCartesianPoint> Polygon
	{
		get
		{
			if (_activated)
			{
				return _polygon;
			}
			Activate();
			return _polygon;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint item in Polygon)
			{
				yield return item;
			}
		}
	}

	internal IfcPolyLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_polygon = new ItemSet<IfcCartesianPoint>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_polygon.InternalAdd((IfcCartesianPoint)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPolyLoop other)
	{
		return this == other;
	}
}
