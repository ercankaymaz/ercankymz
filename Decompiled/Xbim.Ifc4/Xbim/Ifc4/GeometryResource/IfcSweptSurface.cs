using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcSweptSurface", 110)]
public abstract class IfcSweptSurface : IfcSurface, IIfcSweptSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IEquatable<IfcSweptSurface>, IExpressValidatable
{
	public enum IfcSweptSurfaceClause
	{
		SweptCurveType
	}

	private IfcProfileDef _sweptCurve;

	private IfcAxis2Placement3D _position;

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

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			if (clause == IfcSweptSurfaceClause.SweptCurveType)
			{
				result = SweptCurve.ProfileType == IfcProfileTypeEnum.CURVE;
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
		if (!ValidateClause(IfcSweptSurfaceClause.SweptCurveType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptSurface.SweptCurveType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
