using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcPointOnSurface", 65)]
public class IfcPointOnSurface : IfcPoint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPointOnSurface>, IIfcPointOnSurface, IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcPointOrVertexPoint, IIfcPointOrVertexPoint
{
	private IfcSurface _basisSurface;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _pointParameterU;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _pointParameterV;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BasisSurface
	{
		get
		{
			if (_activated)
			{
				return _basisSurface;
			}
			Activate();
			return _basisSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue PointParameterU
	{
		get
		{
			if (_activated)
			{
				return _pointParameterU;
			}
			Activate();
			return _pointParameterU;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_pointParameterU = v;
			}, _pointParameterU, value, "PointParameterU", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue PointParameterV
	{
		get
		{
			if (_activated)
			{
				return _pointParameterV;
			}
			Activate();
			return _pointParameterV;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_pointParameterV = v;
			}, _pointParameterV, value, "PointParameterV", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount Dim
	{
		get
		{
			if (!(BasisSurface != null))
			{
				return 0L;
			}
			return BasisSurface.Dim;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisSurface != null)
			{
				yield return BasisSurface;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPointOnSurface), 1)]
	IIfcSurface IIfcPointOnSurface.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPointOnSurface), 2)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcPointOnSurface.PointParameterU
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(PointParameterU);
		}
		set
		{
			PointParameterU = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPointOnSurface), 3)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcPointOnSurface.PointParameterV
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(PointParameterV);
		}
		set
		{
			PointParameterV = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IfcGeometricSetSelect.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcPointOnSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcSurface)value.EntityVal;
			break;
		case 1:
			_pointParameterU = value.RealVal;
			break;
		case 2:
			_pointParameterV = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPointOnSurface other)
	{
		return this == other;
	}
}
