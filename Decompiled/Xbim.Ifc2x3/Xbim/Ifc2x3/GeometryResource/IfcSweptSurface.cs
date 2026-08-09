using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcSweptSurface", 110)]
public abstract class IfcSweptSurface : IfcSurface, IEquatable<IfcSweptSurface>, IIfcSweptSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IExpressValidatable
{
	public enum IfcSweptSurfaceClause
	{
		WR1,
		WR2
	}

	private IfcProfileDef _sweptCurve;

	private IfcAxis2Placement3D _position;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProfileDef SweptCurve
	{
		get
		{
			if (_activated)
			{
				return _sweptCurve;
			}
			Activate();
			return _sweptCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_sweptCurve = v;
			}, _sweptCurve, value, "SweptCurve", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			}, _position, value, "Position", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount Dim => Position.Dim;

	[CrossSchemaAttribute(typeof(IIfcSweptSurface), 1)]
	IIfcProfileDef IIfcSweptSurface.SweptCurve
	{
		get
		{
			return SweptCurve;
		}
		set
		{
			SweptCurve = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptSurface), 2)]
	IIfcAxis2Placement3D IIfcSweptSurface.Position
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

	internal IfcSweptSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sweptCurve = (IfcProfileDef)value.EntityVal;
			break;
		case 1:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptSurface other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSweptSurfaceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSweptSurfaceClause.WR1:
				result = !Functions.TYPEOF(SweptCurve).Contains("IFC2X3.IFCDERIVEDPROFILEDEF");
				break;
			case IfcSweptSurfaceClause.WR2:
				result = SweptCurve.ProfileType == Xbim.Ifc2x3.ProfileResource.IfcProfileTypeEnum.CURVE;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSweptSurface>()?.LogError($"Exception thrown evaluating where-clause 'IfcSweptSurface.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSweptSurfaceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptSurface.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSweptSurfaceClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptSurface.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
