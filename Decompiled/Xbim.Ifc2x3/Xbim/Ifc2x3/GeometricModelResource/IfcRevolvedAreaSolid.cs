using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcRevolvedAreaSolid", 515)]
public class IfcRevolvedAreaSolid : IfcSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRevolvedAreaSolid>, IIfcRevolvedAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IExpressValidatable
{
	public enum IfcRevolvedAreaSolidClause
	{
		WR31,
		WR32
	}

	private IfcAxis1Placement _axis;

	private Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure _angle;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis1Placement Axis
	{
		get
		{
			if (_activated)
			{
				return _axis;
			}
			Activate();
			return _axis;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis1Placement v)
			{
				_axis = v;
			}, _axis, value, "Axis", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure Angle
	{
		get
		{
			if (_activated)
			{
				return _angle;
			}
			Activate();
			return _angle;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure v)
			{
				_angle = v;
			}, _angle, value, "Angle", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public XbimLine AxisLine
	{
		get
		{
			if (Axis != null)
			{
				return new XbimLine
				{
					Pnt = new XbimPoint3D(Axis.Location.X, Axis.Location.Y, Axis.Location.Z),
					Orientation = Axis.Z
				};
			}
			return null;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (Axis != null)
			{
				yield return Axis;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRevolvedAreaSolid), 3)]
	IIfcAxis1Placement IIfcRevolvedAreaSolid.Axis
	{
		get
		{
			return Axis;
		}
		set
		{
			Axis = value as IfcAxis1Placement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRevolvedAreaSolid), 4)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure IIfcRevolvedAreaSolid.Angle
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(Angle);
		}
		set
		{
			Angle = new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure(value);
		}
	}

	XbimLine IIfcRevolvedAreaSolid.AxisLine => AxisLine;

	internal IfcRevolvedAreaSolid(IModel model, int label, bool activated)
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
			_axis = (IfcAxis1Placement)value.EntityVal;
			break;
		case 3:
			_angle = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRevolvedAreaSolid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRevolvedAreaSolidClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRevolvedAreaSolidClause.WR31:
				result = Axis.Location.Coordinates.ItemAt(2L) == 0.0;
				break;
			case IfcRevolvedAreaSolidClause.WR32:
				result = Axis.Z.DirectionRatios().ItemAt(2L) == 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRevolvedAreaSolid>()?.LogError($"Exception thrown evaluating where-clause 'IfcRevolvedAreaSolid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRevolvedAreaSolidClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRevolvedAreaSolid.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRevolvedAreaSolidClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRevolvedAreaSolid.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
