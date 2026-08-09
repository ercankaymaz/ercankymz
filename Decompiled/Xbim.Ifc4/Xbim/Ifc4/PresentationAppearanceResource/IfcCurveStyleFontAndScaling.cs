using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcCurveStyleFontAndScaling", 569)]
public class IfcCurveStyleFontAndScaling : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurveStyleFontAndScaling, IIfcPresentationItem, IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCurveStyleFontAndScaling>
{
	private IfcLabel? _name;

	private IfcCurveStyleFontSelect _curveFont;

	private IfcPositiveRatioMeasure _curveFontScaling;

	IfcLabel? IIfcCurveStyleFontAndScaling.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IIfcCurveStyleFontSelect IIfcCurveStyleFontAndScaling.CurveFont
	{
		get
		{
			return CurveFont;
		}
		set
		{
			CurveFont = value as IfcCurveStyleFontSelect;
		}
	}

	IfcPositiveRatioMeasure IIfcCurveStyleFontAndScaling.CurveFontScaling
	{
		get
		{
			return CurveFontScaling;
		}
		set
		{
			CurveFontScaling = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCurveStyleFontSelect CurveFont
	{
		get
		{
			if (_activated)
			{
				return _curveFont;
			}
			Activate();
			return _curveFont;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveStyleFontSelect v)
			{
				_curveFont = v;
			}, _curveFont, value, "CurveFont", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPositiveRatioMeasure CurveFontScaling
	{
		get
		{
			if (_activated)
			{
				return _curveFontScaling;
			}
			Activate();
			return _curveFontScaling;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure v)
			{
				_curveFontScaling = v;
			}, _curveFontScaling, value, "CurveFontScaling", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (CurveFont != null)
			{
				yield return CurveFont;
			}
		}
	}

	internal IfcCurveStyleFontAndScaling(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_curveFont = (IfcCurveStyleFontSelect)value.EntityVal;
			break;
		case 2:
			_curveFontScaling = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveStyleFontAndScaling other)
	{
		return this == other;
	}
}
