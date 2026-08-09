using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcOrientationExpression", 1352)]
public class IfcOrientationExpression : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcOrientationExpression, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcOrientationExpression>
{
	private IfcDirection _lateralAxisDirection;

	private IfcDirection _verticalAxisDirection;

	IIfcDirection IIfcOrientationExpression.LateralAxisDirection
	{
		get
		{
			return LateralAxisDirection;
		}
		set
		{
			LateralAxisDirection = value as IfcDirection;
		}
	}

	IIfcDirection IIfcOrientationExpression.VerticalAxisDirection
	{
		get
		{
			return VerticalAxisDirection;
		}
		set
		{
			VerticalAxisDirection = value as IfcDirection;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDirection LateralAxisDirection
	{
		get
		{
			if (_activated)
			{
				return _lateralAxisDirection;
			}
			Activate();
			return _lateralAxisDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_lateralAxisDirection = v;
			}, _lateralAxisDirection, value, "LateralAxisDirection", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDirection VerticalAxisDirection
	{
		get
		{
			if (_activated)
			{
				return _verticalAxisDirection;
			}
			Activate();
			return _verticalAxisDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_verticalAxisDirection = v;
			}, _verticalAxisDirection, value, "VerticalAxisDirection", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (LateralAxisDirection != null)
			{
				yield return LateralAxisDirection;
			}
			if (VerticalAxisDirection != null)
			{
				yield return VerticalAxisDirection;
			}
		}
	}

	internal IfcOrientationExpression(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_lateralAxisDirection = (IfcDirection)value.EntityVal;
			break;
		case 1:
			_verticalAxisDirection = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOrientationExpression other)
	{
		return this == other;
	}
}
