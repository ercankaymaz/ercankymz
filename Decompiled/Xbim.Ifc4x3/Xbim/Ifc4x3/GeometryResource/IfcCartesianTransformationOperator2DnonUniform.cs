using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator2DnonUniform", 147)]
public class IfcCartesianTransformationOperator2DnonUniform : IfcCartesianTransformationOperator2D, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator2DnonUniform>, IIfcCartesianTransformationOperator2DnonUniform, IIfcCartesianTransformationOperator2D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private Xbim.Ifc4x3.MeasureResource.IfcReal? _scale2;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? Scale2
	{
		get
		{
			if (_activated)
			{
				return _scale2;
			}
			Activate();
			return _scale2;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_scale2 = v;
			}, _scale2, value, "Scale2", 5);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal Scl2 => base.Scale ?? base.Scl;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Axis1 != null)
			{
				yield return base.Axis1;
			}
			if (base.Axis2 != null)
			{
				yield return base.Axis2;
			}
			if (base.LocalOrigin != null)
			{
				yield return base.LocalOrigin;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator2DnonUniform), 5)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcCartesianTransformationOperator2DnonUniform.Scale2
	{
		get
		{
			if (!Scale2.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(Scale2.Value);
		}
		set
		{
			Scale2 = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	Xbim.Ifc4.MeasureResource.IfcReal IIfcCartesianTransformationOperator2DnonUniform.Scl2 => new Xbim.Ifc4.MeasureResource.IfcReal(Scl2);

	internal IfcCartesianTransformationOperator2DnonUniform(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_scale2 = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator2DnonUniform other)
	{
		return this == other;
	}
}
