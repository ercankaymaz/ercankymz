using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcAxis1Placement", 280)]
public class IfcAxis1Placement : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcAxis1Placement>, IIfcAxis1Placement, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcAxis1PlacementClause
	{
		WR1,
		WR2
	}

	private IfcDirection _axis;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDirection Axis
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
			SetValue(delegate(IfcDirection v)
			{
				_axis = v;
			}, _axis, value, "Axis", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public XbimVector3D Z
	{
		get
		{
			if (!(_axis != null))
			{
				return new XbimVector3D(0.0, 0.0, 1.0);
			}
			return _axis.Normalise();
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Location != null)
			{
				yield return base.Location;
			}
			if (Axis != null)
			{
				yield return Axis;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAxis1Placement), 2)]
	IIfcDirection IIfcAxis1Placement.Axis
	{
		get
		{
			return Axis;
		}
		set
		{
			Axis = value as IfcDirection;
		}
	}

	XbimVector3D IIfcAxis1Placement.Z => Z;

	internal IfcAxis1Placement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_axis = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAxis1Placement other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAxis1PlacementClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAxis1PlacementClause.WR1:
				result = !Functions.EXISTS(Axis) || Axis.Dim == 3L;
				break;
			case IfcAxis1PlacementClause.WR2:
				result = base.Location.Dim == 3L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAxis1Placement>()?.LogError($"Exception thrown evaluating where-clause 'IfcAxis1Placement.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAxis1PlacementClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis1Placement.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis1PlacementClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis1Placement.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
