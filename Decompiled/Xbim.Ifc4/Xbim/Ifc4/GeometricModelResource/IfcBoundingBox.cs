using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcBoundingBox", 151)]
public class IfcBoundingBox : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundingBox, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcBoundingBox>
{
	private IfcCartesianPoint _corner;

	private IfcPositiveLengthMeasure _xDim;

	private IfcPositiveLengthMeasure _yDim;

	private IfcPositiveLengthMeasure _zDim;

	IIfcCartesianPoint IIfcBoundingBox.Corner
	{
		get
		{
			return Corner;
		}
		set
		{
			Corner = value as IfcCartesianPoint;
		}
	}

	IfcPositiveLengthMeasure IIfcBoundingBox.XDim
	{
		get
		{
			return XDim;
		}
		set
		{
			XDim = value;
		}
	}

	IfcPositiveLengthMeasure IIfcBoundingBox.YDim
	{
		get
		{
			return YDim;
		}
		set
		{
			YDim = value;
		}
	}

	IfcPositiveLengthMeasure IIfcBoundingBox.ZDim
	{
		get
		{
			return ZDim;
		}
		set
		{
			ZDim = value;
		}
	}

	IfcDimensionCount IIfcBoundingBox.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint Corner
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
			SetValue(delegate(IfcCartesianPoint v)
			{
				_corner = v;
			}, _corner, value, "Corner", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure XDim
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_xDim = v;
			}, _xDim, value, "XDim", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure YDim
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_yDim = v;
			}, _yDim, value, "YDim", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure ZDim
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_zDim = v;
			}, _zDim, value, "ZDim", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => 3L;

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

	internal IfcBoundingBox(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_corner = (IfcCartesianPoint)value.EntityVal;
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
