using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcPolygonalBoundedHalfSpace", 623)]
public class IfcPolygonalBoundedHalfSpace : IfcHalfSpaceSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcPolygonalBoundedHalfSpace, IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcPolygonalBoundedHalfSpace>, IExpressValidatable
{
	public enum IfcPolygonalBoundedHalfSpaceClause
	{
		BoundaryDim,
		BoundaryType
	}

	private IfcAxis2Placement3D _position;

	private IfcBoundedCurve _polygonalBoundary;

	IIfcAxis2Placement3D IIfcPolygonalBoundedHalfSpace.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcAxis2Placement3D;
		}
	}

	IIfcBoundedCurve IIfcPolygonalBoundedHalfSpace.PolygonalBoundary
	{
		get
		{
			return PolygonalBoundary;
		}
		set
		{
			PolygonalBoundary = value as IfcBoundedCurve;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis2Placement3D Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_position = v;
			}, _position, value, "Position", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcBoundedCurve PolygonalBoundary
	{
		get
		{
			if (_activated)
			{
				return _polygonalBoundary;
			}
			Activate();
			return _polygonalBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundedCurve v)
			{
				_polygonalBoundary = v;
			}, _polygonalBoundary, value, "PolygonalBoundary", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.BaseSurface != null)
			{
				yield return base.BaseSurface;
			}
			if (Position != null)
			{
				yield return Position;
			}
			if (PolygonalBoundary != null)
			{
				yield return PolygonalBoundary;
			}
		}
	}

	internal IfcPolygonalBoundedHalfSpace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		case 3:
			_polygonalBoundary = (IfcBoundedCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPolygonalBoundedHalfSpace other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPolygonalBoundedHalfSpaceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPolygonalBoundedHalfSpaceClause.BoundaryDim:
				result = PolygonalBoundary.Dim == 2L;
				break;
			case IfcPolygonalBoundedHalfSpaceClause.BoundaryType:
				result = Functions.SIZEOF(Functions.TYPEOF(PolygonalBoundary) * Functions.NewTypesArray("IFC4.IFCPOLYLINE", "IFC4.IFCCOMPOSITECURVE")) == 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPolygonalBoundedHalfSpace>()?.LogError($"Exception thrown evaluating where-clause 'IfcPolygonalBoundedHalfSpace.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPolygonalBoundedHalfSpaceClause.BoundaryDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPolygonalBoundedHalfSpace.BoundaryDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPolygonalBoundedHalfSpaceClause.BoundaryType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPolygonalBoundedHalfSpace.BoundaryType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
