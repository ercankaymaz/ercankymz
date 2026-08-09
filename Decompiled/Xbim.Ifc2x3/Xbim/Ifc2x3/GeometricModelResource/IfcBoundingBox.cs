using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcBoundingBox", 151)]
public class IfcBoundingBox : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBoundingBox>, IIfcBoundingBox, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint _corner;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _xDim;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _yDim;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _zDim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint Corner
	{
		get
		{
			if (_activated)
			{
				return _corner;
			}
			Activate();
			return _corner;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint v)
			{
				_corner = v;
			}, _corner, value, "Corner", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure XDim
	{
		get
		{
			if (_activated)
			{
				return _xDim;
			}
			Activate();
			return _xDim;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_xDim = v;
			}, _xDim, value, "XDim", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure YDim
	{
		get
		{
			if (_activated)
			{
				return _yDim;
			}
			Activate();
			return _yDim;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_yDim = v;
			}, _yDim, value, "YDim", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure ZDim
	{
		get
		{
			if (_activated)
			{
				return _zDim;
			}
			Activate();
			return _zDim;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_zDim = v;
			}, _zDim, value, "ZDim", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Corner != null)
			{
				yield return Corner;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundingBox), 1)]
	IIfcCartesianPoint IIfcBoundingBox.Corner
	{
		get
		{
			return Corner;
		}
		set
		{
			Corner = value as Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundingBox), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBoundingBox.XDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(XDim);
		}
		set
		{
			XDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundingBox), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBoundingBox.YDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(YDim);
		}
		set
		{
			YDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundingBox), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBoundingBox.ZDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(ZDim);
		}
		set
		{
			ZDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcBoundingBox.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcBoundingBox(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_corner = (Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint)value.EntityVal;
			break;
		case 1:
			_xDim = value.RealVal;
			break;
		case 2:
			_yDim = value.RealVal;
			break;
		case 3:
			_zDim = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoundingBox other)
	{
		return this == other;
	}
}
