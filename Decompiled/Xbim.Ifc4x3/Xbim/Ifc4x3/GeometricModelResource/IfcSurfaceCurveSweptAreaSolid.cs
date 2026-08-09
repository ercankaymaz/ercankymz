using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSurfaceCurveSweptAreaSolid", 480)]
public class IfcSurfaceCurveSweptAreaSolid : IfcDirectrixCurveSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSurfaceCurveSweptAreaSolid>, IIfcSurfaceCurveSweptAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcSurface _referenceSurface;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcSurface ReferenceSurface
	{
		get
		{
			if (_activated)
			{
				return _referenceSurface;
			}
			Activate();
			return _referenceSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_referenceSurface = v;
			}, _referenceSurface, value, "ReferenceSurface", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
			if (ReferenceSurface != null)
			{
				yield return ReferenceSurface;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 3)]
	IIfcCurve IIfcSurfaceCurveSweptAreaSolid.Directrix
	{
		get
		{
			return base.Directrix;
		}
		set
		{
			base.Directrix = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 4)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.StartParam
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)base.StartParam);
		}
		set
		{
			base.StartParam = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(value.Value) : default(Xbim.Ifc4x3.MeasureResource.IfcParameterValue));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 5)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.EndParam
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)base.EndParam);
		}
		set
		{
			base.EndParam = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(value.Value) : default(Xbim.Ifc4x3.MeasureResource.IfcParameterValue));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 6)]
	IIfcSurface IIfcSurfaceCurveSweptAreaSolid.ReferenceSurface
	{
		get
		{
			return ReferenceSurface;
		}
		set
		{
			ReferenceSurface = value as IfcSurface;
		}
	}

	internal IfcSurfaceCurveSweptAreaSolid(IModel model, int label, bool activated)
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
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_referenceSurface = (IfcSurface)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceCurveSweptAreaSolid other)
	{
		return this == other;
	}
}
