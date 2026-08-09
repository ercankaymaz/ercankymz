using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcToroidalSurface", 1328)]
public class IfcToroidalSurface : IfcElementarySurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcToroidalSurface>, IIfcToroidalSurface, IIfcElementarySurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _majorRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _minorRadius;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure MajorRadius
	{
		get
		{
			if (_activated)
			{
				return _majorRadius;
			}
			Activate();
			return _majorRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_majorRadius = v;
			}, _majorRadius, value, "MajorRadius", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure MinorRadius
	{
		get
		{
			if (_activated)
			{
				return _minorRadius;
			}
			Activate();
			return _minorRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_minorRadius = v;
			}, _minorRadius, value, "MinorRadius", 3);
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

	[CrossSchemaAttribute(typeof(IIfcToroidalSurface), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcToroidalSurface.MajorRadius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(MajorRadius);
		}
		set
		{
			MajorRadius = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcToroidalSurface), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcToroidalSurface.MinorRadius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(MinorRadius);
		}
		set
		{
			MinorRadius = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	internal IfcToroidalSurface(IModel model, int label, bool activated)
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
			_majorRadius = value.RealVal;
			break;
		case 2:
			_minorRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcToroidalSurface other)
	{
		return this == other;
	}
}
