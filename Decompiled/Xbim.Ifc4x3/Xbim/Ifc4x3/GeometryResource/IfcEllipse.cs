using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcEllipse", 298)]
public class IfcEllipse : IfcConic, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcEllipse>, IIfcEllipse, IIfcConic, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _semiAxis1;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _semiAxis2;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure SemiAxis1
	{
		get
		{
			if (_activated)
			{
				return _semiAxis1;
			}
			Activate();
			return _semiAxis1;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_semiAxis1 = v;
			}, _semiAxis1, value, "SemiAxis1", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure SemiAxis2
	{
		get
		{
			if (_activated)
			{
				return _semiAxis2;
			}
			Activate();
			return _semiAxis2;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_semiAxis2 = v;
			}, _semiAxis2, value, "SemiAxis2", 3);
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

	[CrossSchemaAttribute(typeof(IIfcEllipse), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcEllipse.SemiAxis1
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(SemiAxis1);
		}
		set
		{
			SemiAxis1 = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEllipse), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcEllipse.SemiAxis2
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(SemiAxis2);
		}
		set
		{
			SemiAxis2 = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	internal IfcEllipse(IModel model, int label, bool activated)
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
			_semiAxis1 = value.RealVal;
			break;
		case 2:
			_semiAxis2 = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEllipse other)
	{
		return this == other;
	}
}
