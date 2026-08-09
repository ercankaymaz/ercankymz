using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightSourceDirectional", 757)]
public class IfcLightSourceDirectional : IfcLightSource, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightSourceDirectional, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLightSourceDirectional>
{
	private IfcDirection _orientation;

	IIfcDirection IIfcLightSourceDirectional.Orientation
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

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
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
			}, _orientation, value, "Orientation", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.LightColour != null)
			{
				yield return base.LightColour;
			}
			if (Orientation != null)
			{
				yield return Orientation;
			}
		}
	}

	internal IfcLightSourceDirectional(IModel model, int label, bool activated)
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
			_orientation = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightSourceDirectional other)
	{
		return this == other;
	}
}
