using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcAxis2Placement2D", 411)]
public class IfcAxis2Placement2D : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IfcAxis2Placement, IExpressSelectType, IIfcAxis2Placement, IContainsEntityReferences, IEquatable<IfcAxis2Placement2D>, IIfcAxis2Placement2D, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometryResource.IfcAxis2Placement, IExpressValidatable
{
	public enum IfcAxis2Placement2DClause
	{
		WR1,
		WR2
	}

	private IfcDirection _refDirection;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDirection RefDirection
	{
		get
		{
			if (_activated)
			{
				return _refDirection;
			}
			Activate();
			return _refDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_refDirection = v;
			}, _refDirection, value, "RefDirection", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { 2 }, 0)]
	public List<XbimVector3D> P
	{
		get
		{
			List<XbimVector3D> list = new List<XbimVector3D>(2);
			if (RefDirection == null)
			{
				list.Add(new XbimVector3D(1.0, 0.0, 0.0));
				list.Add(new XbimVector3D(0.0, 1.0, 0.0));
			}
			else
			{
				list.Add(new XbimVector3D(RefDirection.DirectionRatios[0], RefDirection.DirectionRatios[1], 0.0));
				list.Add(new XbimVector3D(0.0 - RefDirection.DirectionRatios[1], RefDirection.DirectionRatios[0], 0.0));
			}
			return list;
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
			if (RefDirection != null)
			{
				yield return RefDirection;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAxis2Placement2D), 2)]
	IIfcDirection IIfcAxis2Placement2D.RefDirection
	{
		get
		{
			return RefDirection;
		}
		set
		{
			RefDirection = value as IfcDirection;
		}
	}

	List<XbimVector3D> Xbim.Ifc4.GeometryResource.IfcAxis2Placement.P => P;

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometryResource.IfcAxis2Placement.Dim => ((IIfcPlacement)this).Dim;

	internal IfcAxis2Placement2D(IModel model, int label, bool activated)
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
			_refDirection = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAxis2Placement2D other)
	{
		return this == other;
	}

	public XbimMatrix3D ToMatrix3D(ConcurrentDictionary<int, object> maps = null)
	{
		if (maps != null && maps.TryGetValue(base.EntityLabel, out var value))
		{
			return (XbimMatrix3D)value;
		}
		if (RefDirection != null)
		{
			XbimVector3D xbimVector3D = RefDirection.XbimVector3D();
			xbimVector3D.Normalized();
			value = new XbimMatrix3D(xbimVector3D.X, xbimVector3D.Y, 0.0, 0.0, xbimVector3D.Y, xbimVector3D.X, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, base.Location.X, base.Location.Y, 0.0, 1.0);
		}
		else
		{
			value = new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, base.Location.X, base.Location.Y, base.Location.Z, 1.0);
		}
		maps?.TryAdd(base.EntityLabel, value);
		return (XbimMatrix3D)value;
	}

	public bool ValidateClause(IfcAxis2Placement2DClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAxis2Placement2DClause.WR1:
				result = !Functions.EXISTS(RefDirection) || RefDirection.Dim == 2L;
				break;
			case IfcAxis2Placement2DClause.WR2:
				result = base.Location.Dim == 2L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAxis2Placement2D>()?.LogError($"Exception thrown evaluating where-clause 'IfcAxis2Placement2D.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAxis2Placement2DClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement2D.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement2DClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement2D.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
