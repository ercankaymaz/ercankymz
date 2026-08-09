using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcSurfaceOfRevolution", 109)]
public class IfcSurfaceOfRevolution : IfcSweptSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceOfRevolution, IIfcSweptSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcSurfaceOfRevolution>
{
	private IfcAxis1Placement _axisPosition;

	IIfcAxis1Placement IIfcSurfaceOfRevolution.AxisPosition
	{
		get
		{
			return AxisPosition;
		}
		set
		{
			AxisPosition = value as IfcAxis1Placement;
		}
	}

	XbimLine IIfcSurfaceOfRevolution.AxisLine => AxisLine;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis1Placement AxisPosition
	{
		get
		{
			if (_activated)
			{
				return _axisPosition;
			}
			Activate();
			return _axisPosition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis1Placement v)
			{
				_axisPosition = v;
			}, _axisPosition, value, "AxisPosition", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public XbimLine AxisLine
	{
		get
		{
			if (AxisPosition != null)
			{
				return new XbimLine
				{
					Pnt = new XbimPoint3D(AxisPosition.Location.X, AxisPosition.Location.Y, AxisPosition.Location.Z),
					Orientation = AxisPosition.Z
				};
			}
			return null;
		}
	}

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
			if (AxisPosition != null)
			{
				yield return AxisPosition;
			}
		}
	}

	internal IfcSurfaceOfRevolution(IModel model, int label, bool activated)
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
			_axisPosition = (IfcAxis1Placement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceOfRevolution other)
	{
		return this == other;
	}
}
