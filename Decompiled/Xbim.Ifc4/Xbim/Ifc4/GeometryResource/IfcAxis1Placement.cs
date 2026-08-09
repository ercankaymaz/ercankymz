using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcAxis1Placement", 280)]
public class IfcAxis1Placement : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcAxis1Placement, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcAxis1Placement>, IExpressValidatable
{
	public enum IfcAxis1PlacementClause
	{
		AxisIs3D,
		LocationIs3D
	}

	private IfcDirection _axis;

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
			case IfcAxis1PlacementClause.AxisIs3D:
				result = !Functions.EXISTS(Axis) || Axis.Dim == 3L;
				break;
			case IfcAxis1PlacementClause.LocationIs3D:
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
		if (!ValidateClause(IfcAxis1PlacementClause.AxisIs3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis1Placement.AxisIs3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis1PlacementClause.LocationIs3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis1Placement.LocationIs3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
