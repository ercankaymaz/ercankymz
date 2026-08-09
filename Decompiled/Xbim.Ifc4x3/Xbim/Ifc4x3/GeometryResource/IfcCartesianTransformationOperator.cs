using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator", 146)]
public abstract class IfcCartesianTransformationOperator : IfcGeometricRepresentationItem, IEquatable<IfcCartesianTransformationOperator>, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private IfcDirection _axis1;

	private IfcDirection _axis2;

	private IfcCartesianPoint _localOrigin;

	private Xbim.Ifc4x3.MeasureResource.IfcReal? _scale;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDirection Axis1
	{
		get
		{
			if (_activated)
			{
				return _axis1;
			}
			Activate();
			return _axis1;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis1 = v;
			}, _axis1, value, "Axis1", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDirection Axis2
	{
		get
		{
			if (_activated)
			{
				return _axis2;
			}
			Activate();
			return _axis2;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis2 = v;
			}, _axis2, value, "Axis2", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCartesianPoint LocalOrigin
	{
		get
		{
			if (_activated)
			{
				return _localOrigin;
			}
			Activate();
			return _localOrigin;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_localOrigin = v;
			}, _localOrigin, value, "LocalOrigin", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? Scale
	{
		get
		{
			if (_activated)
			{
				return _scale;
			}
			Activate();
			return _scale;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_scale = v;
			}, _scale, value, "Scale", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal Scl => Scale ?? ((Xbim.Ifc4x3.MeasureResource.IfcReal)1.0);

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => LocalOrigin.Dim;

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator), 1)]
	IIfcDirection IIfcCartesianTransformationOperator.Axis1
	{
		get
		{
			return Axis1;
		}
		set
		{
			Axis1 = value as IfcDirection;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator), 2)]
	IIfcDirection IIfcCartesianTransformationOperator.Axis2
	{
		get
		{
			return Axis2;
		}
		set
		{
			Axis2 = value as IfcDirection;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator), 3)]
	IIfcCartesianPoint IIfcCartesianTransformationOperator.LocalOrigin
	{
		get
		{
			return LocalOrigin;
		}
		set
		{
			LocalOrigin = value as IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator), 4)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcCartesianTransformationOperator.Scale
	{
		get
		{
			if (!Scale.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(Scale.Value);
		}
		set
		{
			Scale = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	Xbim.Ifc4.MeasureResource.IfcReal IIfcCartesianTransformationOperator.Scl => new Xbim.Ifc4.MeasureResource.IfcReal(Scl);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcCartesianTransformationOperator.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcCartesianTransformationOperator(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_axis1 = (IfcDirection)value.EntityVal;
			break;
		case 1:
			_axis2 = (IfcDirection)value.EntityVal;
			break;
		case 2:
			_localOrigin = (IfcCartesianPoint)value.EntityVal;
			break;
		case 3:
			_scale = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator other)
	{
		return this == other;
	}
}
