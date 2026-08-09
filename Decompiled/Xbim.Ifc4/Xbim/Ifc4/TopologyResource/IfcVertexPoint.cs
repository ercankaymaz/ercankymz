using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcVertexPoint", 521)]
public class IfcVertexPoint : IfcVertex, IInstantiableEntity, IPersistEntity, IPersist, IIfcVertexPoint, IIfcVertex, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcPointOrVertexPoint, IIfcPointOrVertexPoint, IContainsEntityReferences, IEquatable<IfcVertexPoint>
{
	private IfcPoint _vertexGeometry;

	IIfcPoint IIfcVertexPoint.VertexGeometry
	{
		get
		{
			return VertexGeometry;
		}
		set
		{
			VertexGeometry = value as IfcPoint;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcPoint VertexGeometry
	{
		get
		{
			if (_activated)
			{
				return _vertexGeometry;
			}
			Activate();
			return _vertexGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPoint v)
			{
				_vertexGeometry = v;
			}, _vertexGeometry, value, "VertexGeometry", 1);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (VertexGeometry != null)
			{
				yield return VertexGeometry;
			}
		}
	}

	internal IfcVertexPoint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_vertexGeometry = (IfcPoint)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcVertexPoint other)
	{
		return this == other;
	}
}
