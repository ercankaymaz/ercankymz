using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcDirectrixCurveSweptAreaSolid", 1430)]
public abstract class IfcDirectrixCurveSweptAreaSolid : IfcSweptAreaSolid, IEquatable<IfcDirectrixCurveSweptAreaSolid>
{
	private IfcCurve _directrix;

	private IfcCurveMeasureSelect _startParam;

	private IfcCurveMeasureSelect _endParam;

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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcCurveMeasureSelect StartParam
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
			SetValue(delegate(IfcCurveMeasureSelect v)
			{
				_startParam = v;
			}, _startParam, value, "StartParam", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcCurveMeasureSelect EndParam
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
			SetValue(delegate(IfcCurveMeasureSelect v)
			{
				_endParam = v;
			}, _endParam, value, "EndParam", 5);
		}
	}

	internal IfcDirectrixCurveSweptAreaSolid(IModel model, int label, bool activated)
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
			_startParam = (IfcCurveMeasureSelect)value.EntityVal;
			break;
		case 4:
			_endParam = (IfcCurveMeasureSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDirectrixCurveSweptAreaSolid other)
	{
		return this == other;
	}
}
