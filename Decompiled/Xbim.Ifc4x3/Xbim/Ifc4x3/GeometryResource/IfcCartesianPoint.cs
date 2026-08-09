using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCartesianPoint", 410)]
public class IfcCartesianPoint : IfcPoint, IInstantiableEntity, IPersistEntity, IPersist, IfcTrimmingSelect, IExpressSelectType, IEquatable<IfcCartesianPoint>, IIfcCartesianPoint, IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcPointOrVertexPoint, IIfcPointOrVertexPoint, Xbim.Ifc4.GeometryResource.IfcTrimmingSelect, IIfcTrimmingSelect
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> _coordinates;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { 3 }, 3)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> Coordinates
	{
		get
		{
			if (_activated)
			{
				return _coordinates;
			}
			Activate();
			return _coordinates;
		}
	}

	public double X
	{
		get
		{
			if (Coordinates.Count != 0)
			{
				return Coordinates[0];
			}
			return double.NaN;
		}
		set
		{
			if (Coordinates.Count == 0)
			{
				Coordinates.Add(value);
			}
			else
			{
				Coordinates[0] = value;
			}
		}
	}

	public double Y
	{
		get
		{
			if (Coordinates.Count >= 2)
			{
				return Coordinates[1];
			}
			return double.NaN;
		}
		set
		{
			if (Coordinates.Count < 2)
			{
				if (Coordinates.Count == 0)
				{
					Coordinates.Add(double.NaN);
				}
				Coordinates.Add(value);
			}
			else
			{
				Coordinates[1] = value;
			}
		}
	}

	public double Z
	{
		get
		{
			if (Coordinates.Count >= 3)
			{
				return Coordinates[2];
			}
			return double.NaN;
		}
		set
		{
			if (Coordinates.Count < 3)
			{
				if (Coordinates.Count == 0)
				{
					Coordinates.Add(double.NaN);
				}
				if (Coordinates.Count == 1)
				{
					Coordinates.Add(double.NaN);
				}
				Coordinates.Add(value);
			}
			else
			{
				Coordinates[2] = value;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianPoint), 1)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> IIfcCartesianPoint.Coordinates => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(Coordinates, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IfcGeometricSetSelect.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(base.Dim);

	internal IfcCartesianPoint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordinates = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>(this, 3, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_coordinates.InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCartesianPoint other)
	{
		return this == other;
	}

	public void SetXY(double x, double y)
	{
		Coordinates.Clear();
		Coordinates.Add(x);
		Coordinates.Add(y);
	}

	public void SetXYZ(double x, double y, double z)
	{
		Coordinates.Clear();
		Coordinates.Add(x);
		Coordinates.Add(y);
		Coordinates.Add(z);
	}

	public XbimPoint3D XbimPoint3D()
	{
		return new XbimPoint3D(X, Y, Z);
	}

	public bool IsEqual(IfcCartesianPoint p, double tolerance)
	{
		return DistanceSquared(p) <= tolerance * tolerance;
	}

	public double DistanceSquared(IfcCartesianPoint p)
	{
		XYZ(out var x, out var y, out var z);
		p.XYZ(out var x2, out var y2, out var z2);
		double num = x;
		num -= x2;
		num *= num;
		double num2 = 0.0 + num;
		num = y;
		num -= y2;
		num *= num;
		double num3 = num2 + num;
		num = z;
		num -= z2;
		num *= num;
		return num3 + num;
	}

	public void XYZ(out double x, out double y, out double z)
	{
		if (base.Dim == 3L)
		{
			x = Coordinates[0];
			y = Coordinates[1];
			z = Coordinates[2];
		}
		else if (base.Dim == 2L)
		{
			x = Coordinates[0];
			y = Coordinates[1];
			z = 0.0;
		}
		else
		{
			z = (y = (x = double.NaN));
		}
	}
}
