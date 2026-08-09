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

[ExpressType("IfcAxis2Placement3D", 448)]
public class IfcAxis2Placement3D : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IfcAxis2Placement, IExpressSelectType, IIfcAxis2Placement, IContainsEntityReferences, IEquatable<IfcAxis2Placement3D>, IIfcAxis2Placement3D, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometryResource.IfcAxis2Placement, IExpressValidatable
{
	public enum IfcAxis2Placement3DClause
	{
		WR1,
		WR2,
		WR3,
		WR4,
		WR5
	}

	private IfcDirection _axis;

	private IfcDirection _refDirection;

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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
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
			}, _refDirection, value, "RefDirection", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { 3 }, 0)]
	public List<XbimVector3D> P
	{
		get
		{
			List<XbimVector3D> list = new List<XbimVector3D>(3);
			if (RefDirection == null && Axis == null)
			{
				list.Add(new XbimVector3D(1.0, 0.0, 0.0));
				list.Add(new XbimVector3D(0.0, 1.0, 0.0));
				list.Add(new XbimVector3D(0.0, 0.0, 1.0));
			}
			else
			{
				if (!(RefDirection != null) || !(Axis != null))
				{
					throw new ArgumentException("RefDirection and Axis must be noth either null or both defined");
				}
				XbimVector3D xbimVector3D = _axis.XbimVector3D();
				xbimVector3D.Normalized();
				XbimVector3D xbimVector3D2 = _refDirection.XbimVector3D();
				xbimVector3D2.Normalized();
				XbimVector3D item = XbimVector3D.CrossProduct(xbimVector3D, xbimVector3D2);
				item.Normalized();
				list.Add(xbimVector3D2);
				list.Add(item);
				list.Add(xbimVector3D);
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
			if (Axis != null)
			{
				yield return Axis;
			}
			if (RefDirection != null)
			{
				yield return RefDirection;
			}
		}
	}

	public new IfcDimensionCount Dim => (int)(long)base.Dim;

	List<XbimVector3D> IfcAxis2Placement.P
	{
		get
		{
			XbimVector3D item = new XbimVector3D(P[0].X, P[0].Y, P[0].Z);
			XbimVector3D item2 = new XbimVector3D(P[1].X, P[1].Y, P[1].Z);
			XbimVector3D item3 = new XbimVector3D(P[2].X, P[2].Y, P[2].Z);
			return new List<XbimVector3D> { item, item2, item3 };
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAxis2Placement3D), 2)]
	IIfcDirection IIfcAxis2Placement3D.Axis
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

	[CrossSchemaAttribute(typeof(IIfcAxis2Placement3D), 3)]
	IIfcDirection IIfcAxis2Placement3D.RefDirection
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

	internal IfcAxis2Placement3D(IModel model, int label, bool activated)
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
		case 2:
			_refDirection = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAxis2Placement3D other)
	{
		return this == other;
	}

	public XbimMatrix3D ToMatrix3D(ConcurrentDictionary<int, object> maps = null)
	{
		if (maps == null)
		{
			return ConvertAxis3D();
		}
		if (maps.TryGetValue(base.EntityLabel, out var value))
		{
			return (XbimMatrix3D)value;
		}
		value = ConvertAxis3D();
		maps.TryAdd(base.EntityLabel, value);
		return (XbimMatrix3D)value;
	}

	private XbimMatrix3D ConvertAxis3D()
	{
		if (RefDirection == null || Axis == null)
		{
			return new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, base.Location.X, base.Location.Y, base.Location.Z, 1.0);
		}
		XbimVector3D v = Axis.XbimVector3D();
		v.Normalized();
		XbimVector3D v2 = RefDirection.XbimVector3D();
		v2.Normalized();
		XbimVector3D xbimVector3D = XbimVector3D.CrossProduct(v, v2);
		xbimVector3D.Normalized();
		return new XbimMatrix3D(v2.X, v2.Y, v2.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, v.X, v.Y, v.Z, 0.0, base.Location.X, base.Location.Y, base.Location.Z, 1.0);
	}

	public bool ValidateClause(IfcAxis2Placement3DClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAxis2Placement3DClause.WR1:
				result = base.Location.Dim == 3L;
				break;
			case IfcAxis2Placement3DClause.WR2:
				result = !Functions.EXISTS(Axis) || Axis.Dim == 3L;
				break;
			case IfcAxis2Placement3DClause.WR3:
				result = !Functions.EXISTS(RefDirection) || RefDirection.Dim == 3L;
				break;
			case IfcAxis2Placement3DClause.WR4:
				result = !Functions.EXISTS(Axis) || !Functions.EXISTS(RefDirection) || Functions.IfcCrossProduct(Axis, RefDirection).Magnitude > 0.0;
				break;
			case IfcAxis2Placement3DClause.WR5:
				result = Functions.EXISTS(Axis) == Functions.EXISTS(RefDirection);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAxis2Placement3D>()?.LogError($"Exception thrown evaluating where-clause 'IfcAxis2Placement3D.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAxis2Placement3DClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement3D.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement3DClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement3D.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement3DClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement3D.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement3DClause.WR4))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement3D.WR4",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAxis2Placement3DClause.WR5))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAxis2Placement3D.WR5",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
