using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcAxis2Placement3D", 448)]
public class IfcAxis2Placement3D : IfcPlacement, IInstantiableEntity, IPersistEntity, IPersist, IfcAxis2Placement, IExpressSelectType, IIfcAxis2Placement, IContainsEntityReferences, IEquatable<IfcAxis2Placement3D>, IIfcAxis2Placement3D, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometryResource.IfcAxis2Placement
{
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
}
