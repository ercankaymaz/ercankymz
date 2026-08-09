using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcSurfaceCurveSweptAreaSolid", 480)]
public class IfcSurfaceCurveSweptAreaSolid : IfcSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSurfaceCurveSweptAreaSolid>, IIfcSurfaceCurveSweptAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcCurve _directrix;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _startParam;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _endParam;

	private IfcSurface _referenceSurface;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCurve Directrix
	{
		get
		{
			if (_activated)
			{
				return _directrix;
			}
			Activate();
			return _directrix;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_directrix = v;
			}, _directrix, value, "Directrix", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue StartParam
	{
		get
		{
			if (_activated)
			{
				return _startParam;
			}
			Activate();
			return _startParam;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_startParam = v;
			}, _startParam, value, "StartParam", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue EndParam
	{
		get
		{
			if (_activated)
			{
				return _endParam;
			}
			Activate();
			return _endParam;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_endParam = v;
			}, _endParam, value, "EndParam", 5);
		}
	}

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
			if (Directrix != null)
			{
				yield return Directrix;
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
			return Directrix;
		}
		set
		{
			Directrix = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 4)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.StartParam
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(StartParam);
		}
		set
		{
			StartParam = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcParameterValue));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceCurveSweptAreaSolid), 5)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.EndParam
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(EndParam);
		}
		set
		{
			EndParam = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcParameterValue));
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 3:
			_startParam = value.RealVal;
			break;
		case 4:
			_endParam = value.RealVal;
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
