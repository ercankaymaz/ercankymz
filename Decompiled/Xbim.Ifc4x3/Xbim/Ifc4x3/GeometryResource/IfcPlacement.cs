using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPlacement", 281)]
public abstract class IfcPlacement : IfcGeometricRepresentationItem, IEquatable<IfcPlacement>, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private IfcPoint _location;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcPoint Location
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
			SetValue(delegate(IfcPoint v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => Location?.Dimension ?? ((IfcDimensionCount)0L);

	[CrossSchemaAttribute(typeof(IIfcPlacement), 1)]
	IIfcCartesianPoint IIfcPlacement.Location
	{
		get
		{
			if (Location == null)
			{
				return null;
			}
			if (Location is IfcCartesianPoint result)
			{
				return result;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Location = null;
			}
			else if (value is IfcCartesianPoint location)
			{
				Location = location;
			}
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcPlacement.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_location = (IfcPoint)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPlacement other)
	{
		return this == other;
	}
}
