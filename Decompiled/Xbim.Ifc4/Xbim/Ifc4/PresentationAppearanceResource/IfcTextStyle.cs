using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextStyle", 427)]
public class IfcTextStyle : IfcPresentationStyle, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextStyle, IIfcPresentationStyle, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcTextStyle>
{
	private IfcTextStyleForDefinedFont _textCharacterAppearance;

	private IfcTextStyleTextModel _textStyle;

	private IfcTextFontSelect _textFontStyle;

	private IfcBoolean? _modelOrDraughting;

	IIfcTextStyleForDefinedFont IIfcTextStyle.TextCharacterAppearance
	{
		get
		{
			return TextCharacterAppearance;
		}
		set
		{
			TextCharacterAppearance = value as IfcTextStyleForDefinedFont;
		}
	}

	IIfcTextStyleTextModel IIfcTextStyle.TextStyle
	{
		get
		{
			return TextStyle;
		}
		set
		{
			TextStyle = value as IfcTextStyleTextModel;
		}
	}

	IIfcTextFontSelect IIfcTextStyle.TextFontStyle
	{
		get
		{
			return TextFontStyle;
		}
		set
		{
			TextFontStyle = value as IfcTextFontSelect;
		}
	}

	IfcBoolean? IIfcTextStyle.ModelOrDraughting
	{
		get
		{
			return ModelOrDraughting;
		}
		set
		{
			ModelOrDraughting = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcTextStyleForDefinedFont TextCharacterAppearance
	{
		get
		{
			if (_activated)
			{
				return _textCharacterAppearance;
			}
			Activate();
			return _textCharacterAppearance;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTextStyleForDefinedFont v)
			{
				_textCharacterAppearance = v;
			}, _textCharacterAppearance, value, "TextCharacterAppearance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcTextStyleTextModel TextStyle
	{
		get
		{
			if (_activated)
			{
				return _textStyle;
			}
			Activate();
			return _textStyle;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTextStyleTextModel v)
			{
				_textStyle = v;
			}, _textStyle, value, "TextStyle", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcTextFontSelect TextFontStyle
	{
		get
		{
			if (_activated)
			{
				return _textFontStyle;
			}
			Activate();
			return _textFontStyle;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTextFontSelect v)
			{
				_textFontStyle = v;
			}, _textFontStyle, value, "TextFontStyle", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcBoolean? ModelOrDraughting
	{
		get
		{
			if (_activated)
			{
				return _modelOrDraughting;
			}
			Activate();
			return _modelOrDraughting;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_modelOrDraughting = v;
			}, _modelOrDraughting, value, "ModelOrDraughting", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (TextCharacterAppearance != null)
			{
				yield return TextCharacterAppearance;
			}
			if (TextStyle != null)
			{
				yield return TextStyle;
			}
			if (TextFontStyle != null)
			{
				yield return TextFontStyle;
			}
		}
	}

	internal IfcTextStyle(IModel model, int label, bool activated)
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
			_textCharacterAppearance = (IfcTextStyleForDefinedFont)value.EntityVal;
			break;
		case 2:
			_textStyle = (IfcTextStyleTextModel)value.EntityVal;
			break;
		case 3:
			_textFontStyle = (IfcTextFontSelect)value.EntityVal;
			break;
		case 4:
			_modelOrDraughting = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextStyle other)
	{
		return this == other;
	}
}
