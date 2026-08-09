using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcRationalBSplineSurfaceWithKnots", 1242)]
public class IfcRationalBSplineSurfaceWithKnots : IfcBSplineSurfaceWithKnots, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRationalBSplineSurfaceWithKnots>, IIfcRationalBSplineSurfaceWithKnots, IIfcBSplineSurfaceWithKnots, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>> _weightsData;

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 2, 2 }, new int[] { -1, -1 }, 15)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>> WeightsData
	{
		get
		{
			if (_activated)
			{
				return _weightsData;
			}
			Activate();
			return _weightsData;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.Array, new int[] { 0, 0 }, new int[] { -1, -1 }, 0)]
	public List<List<Xbim.Ifc4x3.MeasureResource.IfcReal>> Weights => WeightsData.Select((IItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal> wd) => wd.ToList()).ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IItemSet<IfcCartesianPoint> controlPoints in base.ControlPointsList)
			{
				foreach (IfcCartesianPoint item in controlPoints)
				{
					yield return item;
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRationalBSplineSurfaceWithKnots), 13)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcReal>> IIfcRationalBSplineSurfaceWithKnots.WeightsData => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcReal, Xbim.Ifc4.MeasureResource.IfcReal>(WeightsData, (Xbim.Ifc4x3.MeasureResource.IfcReal s) => new Xbim.Ifc4.MeasureResource.IfcReal(s), (Xbim.Ifc4.MeasureResource.IfcReal t) => new Xbim.Ifc4x3.MeasureResource.IfcReal(t));

	List<List<Xbim.Ifc4.MeasureResource.IfcReal>> IIfcRationalBSplineSurfaceWithKnots.Weights
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal IfcRationalBSplineSurfaceWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_weightsData = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>>(this, 0, 13);
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
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 12:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>)_weightsData.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRationalBSplineSurfaceWithKnots other)
	{
		return this == other;
	}
}
