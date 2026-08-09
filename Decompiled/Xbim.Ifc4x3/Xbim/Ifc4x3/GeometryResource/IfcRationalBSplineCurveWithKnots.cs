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

[ExpressType("IfcRationalBSplineCurveWithKnots", 1241)]
public class IfcRationalBSplineCurveWithKnots : IfcBSplineCurveWithKnots, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRationalBSplineCurveWithKnots>, IIfcRationalBSplineCurveWithKnots, IIfcBSplineCurveWithKnots, IIfcBSplineCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal> _weightsData;

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 11)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal> WeightsData
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

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 0)]
	public List<Xbim.Ifc4x3.MeasureResource.IfcReal> Weights => WeightsData.ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint controlPoints in base.ControlPointsList)
			{
				yield return controlPoints;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRationalBSplineCurveWithKnots), 9)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcReal> IIfcRationalBSplineCurveWithKnots.WeightsData => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcReal, Xbim.Ifc4.MeasureResource.IfcReal>(WeightsData, (Xbim.Ifc4x3.MeasureResource.IfcReal s) => new Xbim.Ifc4.MeasureResource.IfcReal(s), (Xbim.Ifc4.MeasureResource.IfcReal t) => new Xbim.Ifc4x3.MeasureResource.IfcReal(t));

	List<Xbim.Ifc4.MeasureResource.IfcReal> IIfcRationalBSplineCurveWithKnots.Weights
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal IfcRationalBSplineCurveWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_weightsData = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>(this, 0, 9);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_weightsData.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRationalBSplineCurveWithKnots other)
	{
		return this == other;
	}
}
