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

[ExpressType("IfcAxis2Placement2D", 411)]
public class IfcAxis2Placement2D : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcAxis2Placement2D, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcAxis2Placement, IIfcAxis2Placement, IContainsEntityReferences, IEquatable<IfcAxis2Placement2D>, IExpressValidatable
{
	public enum IfcAxis2Placement2DClause
	{
		RefDirIs2D,
		LocationIs2D
	}

	private IfcDirection _refDirection;

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
				list.Add(new XbimVector3D(0.0 - (double)RefDirection.DirectionRatios[1], RefDirection.DirectionRatios[0], 0.0));
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

	public bool ValidateClause(IfcAxis2Placement2DClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAxis2Placement2DClause.RefDirIs2D:
				result = !Functions.EXISTS(RefDirection) || RefDirection.Dim == 2L;
				break;
			case IfcAxis2Placement2DClause.LocationIs2D:
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
		if (!ValidateClause(IfcAxis2Placement2DClause.RefDirIs2D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement2D.RefDirIs2D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement2DClause.LocationIs2D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement2D.LocationIs2D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
