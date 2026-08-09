using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcPlacement", 281)]
public abstract class IfcPlacement : IfcGeometricRepresentationItem, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcPlacement>
{
	private IfcCartesianPoint _location;

	IIfcCartesianPoint IIfcPlacement.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value as IfcCartesianPoint;
		}
	}

	IfcDimensionCount IIfcPlacement.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint Location
	{
		get
		{
			if (_activated)
			{
				return _location;
			}
			Activate();
			return _location;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (!(Location == null))
			{
				return Location.Dim;
			}
			return 0L;
		}
	}

	internal IfcPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_location = (IfcCartesianPoint)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPlacement other)
	{
		return this == other;
	}
}
