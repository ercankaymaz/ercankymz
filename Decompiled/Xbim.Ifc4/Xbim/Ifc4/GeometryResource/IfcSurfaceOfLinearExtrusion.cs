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

[ExpressType("IfcSurfaceOfLinearExtrusion", 256)]
public class IfcSurfaceOfLinearExtrusion : IfcSweptSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceOfLinearExtrusion, IIfcSweptSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcSurfaceOfLinearExtrusion>, IExpressValidatable
{
	public enum IfcSurfaceOfLinearExtrusionClause
	{
		DepthGreaterZero
	}

	private IfcDirection _extrudedDirection;

	private IfcLengthMeasure _depth;

	IIfcDirection IIfcSurfaceOfLinearExtrusion.ExtrudedDirection
	{
		get
		{
			return ExtrudedDirection;
		}
		set
		{
			ExtrudedDirection = value as IfcDirection;
		}
	}

	IfcLengthMeasure IIfcSurfaceOfLinearExtrusion.Depth
	{
		get
		{
			return Depth;
		}
		set
		{
			Depth = value;
		}
	}

	XbimVector3D IIfcSurfaceOfLinearExtrusion.ExtrusionAxis => ExtrusionAxis;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcDirection ExtrudedDirection
	{
		get
		{
			if (_activated)
			{
				return _extrudedDirection;
			}
			Activate();
			return _extrudedDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_extrudedDirection = v;
			}, _extrudedDirection, value, "ExtrudedDirection", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public XbimVector3D ExtrusionAxis => new XbimVector3D(_extrudedDirection.X * (double)_depth, _extrudedDirection.Y * (double)_depth, _extrudedDirection.Z * (double)_depth);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptCurve != null)
			{
				yield return base.SweptCurve;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (ExtrudedDirection != null)
			{
				yield return ExtrudedDirection;
			}
		}
	}

	internal IfcSurfaceOfLinearExtrusion(IModel model, int label, bool activated)
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
			_extrudedDirection = (IfcDirection)value.EntityVal;
			break;
		case 3:
			_depth = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceOfLinearExtrusion other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSurfaceOfLinearExtrusionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSurfaceOfLinearExtrusionClause.DepthGreaterZero)
			{
				result = (double)Depth > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSurfaceOfLinearExtrusion>()?.LogError($"Exception thrown evaluating where-clause 'IfcSurfaceOfLinearExtrusion.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSurfaceOfLinearExtrusionClause.DepthGreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceOfLinearExtrusion.DepthGreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
