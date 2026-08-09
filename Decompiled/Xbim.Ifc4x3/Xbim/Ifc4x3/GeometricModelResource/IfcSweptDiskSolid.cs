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

[ExpressType("IfcSweptDiskSolid", 547)]
public class IfcSweptDiskSolid : IfcSolidModel, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSweptDiskSolid>, IIfcSweptDiskSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcCurve _directrix;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _radius;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _innerRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcParameterValue? _startParam;

	private Xbim.Ifc4x3.MeasureResource.IfcParameterValue? _endParam;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _directrix, value, "Directrix", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Radius
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? InnerRadius
	{
		get
		{
			if (_activated)
			{
				return _innerRadius;
			}
			Activate();
			return _innerRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_innerRadius = v;
			}, _innerRadius, value, "InnerRadius", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcParameterValue? StartParam
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcParameterValue? v)
			{
				_startParam = v;
			}, _startParam, value, "StartParam", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcParameterValue? EndParam
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcParameterValue? v)
			{
				_endParam = v;
			}, _endParam, value, "EndParam", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Directrix != null)
			{
				yield return Directrix;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolid), 1)]
	IIfcCurve IIfcSweptDiskSolid.Directrix
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

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolid), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcSweptDiskSolid.Radius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Radius);
		}
		set
		{
			Radius = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolid), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcSweptDiskSolid.InnerRadius
	{
		get
		{
			if (!InnerRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(InnerRadius.Value);
		}
		set
		{
			InnerRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolid), 4)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSweptDiskSolid.StartParam
	{
		get
		{
			if (!StartParam.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(StartParam.Value);
		}
		set
		{
			StartParam = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcParameterValue?(new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcParameterValue?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolid), 5)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSweptDiskSolid.EndParam
	{
		get
		{
			if (!EndParam.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(EndParam.Value);
		}
		set
		{
			EndParam = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcParameterValue?(new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcParameterValue?)null));
		}
	}

	internal IfcSweptDiskSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_radius = value.RealVal;
			break;
		case 2:
			_innerRadius = value.RealVal;
			break;
		case 3:
			_startParam = value.RealVal;
			break;
		case 4:
			_endParam = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptDiskSolid other)
	{
		return this == other;
	}
}
