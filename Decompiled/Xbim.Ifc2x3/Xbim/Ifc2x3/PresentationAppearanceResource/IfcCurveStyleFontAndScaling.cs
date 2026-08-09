using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcCurveStyleFontAndScaling", 569)]
public class IfcCurveStyleFontAndScaling : PersistEntity, IIfcCurveStyleFontAndScaling, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IInstantiableEntity, IfcCurveFontOrScaledCurveFontSelect, IContainsEntityReferences, IEquatable<IfcCurveStyleFontAndScaling>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	private IfcCurveStyleFontSelect _curveFont;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure _curveFontScaling;

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFontAndScaling), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcCurveStyleFontAndScaling.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFontAndScaling), 2)]
	IIfcCurveStyleFontSelect IIfcCurveStyleFontAndScaling.CurveFont
	{
		get
		{
			if (CurveFont == null)
			{
				return null;
			}
			IfcPreDefinedCurveFont ifcPreDefinedCurveFont = CurveFont as IfcPreDefinedCurveFont;
			if (ifcPreDefinedCurveFont != null)
			{
				return ifcPreDefinedCurveFont;
			}
			IfcCurveStyleFont ifcCurveStyleFont = CurveFont as IfcCurveStyleFont;
			if (ifcCurveStyleFont != null)
			{
				return ifcCurveStyleFont;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveFont = null;
				return;
			}
			IfcCurveStyleFont ifcCurveStyleFont = value as IfcCurveStyleFont;
			if (ifcCurveStyleFont != null)
			{
				CurveFont = ifcCurveStyleFont;
				return;
			}
			IfcPreDefinedCurveFont ifcPreDefinedCurveFont = value as IfcPreDefinedCurveFont;
			if (ifcPreDefinedCurveFont != null)
			{
				CurveFont = ifcPreDefinedCurveFont;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFontAndScaling), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure IIfcCurveStyleFontAndScaling.CurveFontScaling
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(CurveFontScaling);
		}
		set
		{
			CurveFontScaling = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure(value);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
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
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure CurveFontScaling
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure v)
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
