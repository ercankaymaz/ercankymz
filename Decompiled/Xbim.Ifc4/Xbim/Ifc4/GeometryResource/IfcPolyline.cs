using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcPolyline", 500)]
public class IfcPolyline : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcPolyline, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcPolyline>, IExpressValidatable
{
	public enum IfcPolylineClause
	{
		SameDim
	}

	private readonly ItemSet<IfcCartesianPoint> _points;

	IItemSet<IIfcCartesianPoint> IIfcPolyline.Points => new ProxyItemSet<IfcCartesianPoint, IIfcCartesianPoint>(Points);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 3)]
	public IItemSet<IfcCartesianPoint> Points
	{
		get
		{
			if (_activated)
			{
				return _points;
			}
			Activate();
			return _points;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint point in Points)
			{
				yield return point;
			}
		}
	}

	internal IfcPolyline(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_points = new ItemSet<IfcCartesianPoint>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_points.InternalAdd((IfcCartesianPoint)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPolyline other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPolylineClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPolylineClause.SameDim)
			{
				result = Functions.SIZEOF(Enumerable.Where(Points, (IfcCartesianPoint Temp) => Temp.Dim != Points.ItemAt(0L).Dim)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPolyline>()?.LogError($"Exception thrown evaluating where-clause 'IfcPolyline.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPolylineClause.SameDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPolyline.SameDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
