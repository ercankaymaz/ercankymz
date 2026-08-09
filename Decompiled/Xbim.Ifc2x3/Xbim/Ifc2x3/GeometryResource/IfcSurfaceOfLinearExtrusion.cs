using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcSurfaceOfLinearExtrusion", 256)]
public class IfcSurfaceOfLinearExtrusion : IfcSweptSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSurfaceOfLinearExtrusion>, IIfcSurfaceOfLinearExtrusion, IIfcSweptSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IExpressValidatable
{
	public enum IfcSurfaceOfLinearExtrusionClause
	{
		WR41
	}

	private IfcDirection _extrudedDirection;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _depth;

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
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure Depth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
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

	[CrossSchemaAttribute(typeof(IIfcSurfaceOfLinearExtrusion), 3)]
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

	[CrossSchemaAttribute(typeof(IIfcSurfaceOfLinearExtrusion), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcSurfaceOfLinearExtrusion.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	XbimVector3D IIfcSurfaceOfLinearExtrusion.ExtrusionAxis => ExtrusionAxis;

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
			if (clause == IfcSurfaceOfLinearExtrusionClause.WR41)
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
		if (!ValidateClause(IfcSurfaceOfLinearExtrusionClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceOfLinearExtrusion.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
