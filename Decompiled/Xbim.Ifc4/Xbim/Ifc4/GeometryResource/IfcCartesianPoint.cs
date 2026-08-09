using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCartesianPoint", 410)]
public class IfcCartesianPoint : IfcPoint, IInstantiableEntity, IPersistEntity, IPersist, IIfcCartesianPoint, IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcPointOrVertexPoint, IIfcPointOrVertexPoint, IfcTrimmingSelect, IIfcTrimmingSelect, IEquatable<IfcCartesianPoint>, IExpressValidatable
{
	public enum IfcCartesianPointClause
	{
		CP2Dor3D
	}

	private readonly ItemSet<IfcLengthMeasure> _coordinates;

	IItemSet<IfcLengthMeasure> IIfcCartesianPoint.Coordinates => Coordinates;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { 3 }, 3)]
	public IItemSet<IfcLengthMeasure> Coordinates
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

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => Coordinates.Count;

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

	internal IfcCartesianPoint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordinates = new ItemSet<IfcLengthMeasure>(this, 3, 1);
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
		if (Dim == 3L)
		{
			x = Coordinates[0];
			y = Coordinates[1];
			z = Coordinates[2];
		}
		else if (Dim == 2L)
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

	public bool ValidateClause(IfcCartesianPointClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCartesianPointClause.CP2Dor3D)
			{
				result = Functions.HIINDEX(Coordinates) >= 2;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianPoint>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianPoint.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCartesianPointClause.CP2Dor3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianPoint.CP2Dor3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
