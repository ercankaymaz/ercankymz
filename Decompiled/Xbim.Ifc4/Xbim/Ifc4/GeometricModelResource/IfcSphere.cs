using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSphere", 706)]
public class IfcSphere : IfcCsgPrimitive3D, IInstantiableEntity, IPersistEntity, IPersist, IIfcSphere, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcSphere>
{
	private IfcPositiveLengthMeasure _radius;

	IfcPositiveLengthMeasure IIfcSphere.Radius
	{
		get
		{
			return Radius;
		}
		set
		{
			Radius = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure Radius
	{
		get
		{
			if (_activated)
			{
				return _radius;
			}
			Activate();
			return _radius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcSphere(IModel model, int label, bool activated)
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
			_radius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSphere other)
	{
		return this == other;
	}
}
