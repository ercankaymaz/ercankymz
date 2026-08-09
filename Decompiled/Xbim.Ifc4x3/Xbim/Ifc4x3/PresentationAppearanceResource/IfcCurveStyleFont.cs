using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcCurveStyleFont", 223)]
public class IfcCurveStyleFont : IfcPresentationItem, IIfcCurveStyleFont, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveStyleFontSelect, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IIfcCurveStyleFontSelect, IInstantiableEntity, IfcCurveStyleFontSelect, IfcCurveFontOrScaledCurveFontSelect, IContainsEntityReferences, IEquatable<IfcCurveStyleFont>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private readonly ItemSet<IfcCurveStyleFontPattern> _patternList;

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFont), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcCurveStyleFont.Name
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
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFont), 2)]
	IItemSet<IIfcCurveStyleFontPattern> IIfcCurveStyleFont.PatternList => new ProxyItemSet<IfcCurveStyleFontPattern, IIfcCurveStyleFontPattern>(PatternList);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcCurveStyleFontPattern> PatternList
	{
		get
		{
			if (_activated)
			{
				return _patternList;
			}
			Activate();
			return _patternList;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCurveStyleFontPattern pattern in PatternList)
			{
				yield return pattern;
			}
		}
	}

	internal IfcCurveStyleFont(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_patternList = new ItemSet<IfcCurveStyleFontPattern>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_patternList.InternalAdd((IfcCurveStyleFontPattern)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveStyleFont other)
	{
		return this == other;
	}
}
