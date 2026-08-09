using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcVector", 652)]
public class IfcVector : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc4x3.PresentationAppearanceResource.IfcHatchLineDistanceSelect, IExpressSelectType, IfcVectorOrDirection, IIfcVectorOrDirection, IContainsEntityReferences, IEquatable<IfcVector>, IIfcVector, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.PresentationAppearanceResource.IfcHatchLineDistanceSelect, IIfcHatchLineDistanceSelect, Xbim.Ifc4.GeometryResource.IfcVectorOrDirection
{
	private IfcDirection _orientation;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure _magnitude;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDirection Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure Magnitude
	{
		get
		{
			if (_activated)
			{
				return _magnitude;
			}
			Activate();
			return _magnitude;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure v)
			{
				_magnitude = v;
			}, _magnitude, value, "Magnitude", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => Orientation.Dim;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Orientation != null)
			{
				yield return Orientation;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcVector), 1)]
	IIfcDirection IIfcVector.Orientation
	{
		get
		{
			return Orientation;
		}
		set
		{
			Orientation = value as IfcDirection;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcVector), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcVector.Magnitude
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Magnitude);
		}
		set
		{
			Magnitude = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcVector.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcVector(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_orientation = (IfcDirection)value.EntityVal;
			break;
		case 1:
			_magnitude = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVector other)
	{
		return this == other;
	}
}
