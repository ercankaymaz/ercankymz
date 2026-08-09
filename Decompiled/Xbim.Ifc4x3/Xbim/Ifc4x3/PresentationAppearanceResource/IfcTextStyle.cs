using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextStyle", 427)]
public class IfcTextStyle : IfcPresentationStyle, IIfcTextStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTextStyle>
{
	private IfcTextStyleForDefinedFont _textCharacterAppearance;

	private IfcTextStyleTextModel _textStyle;

	private IfcTextFontSelect _textFontStyle;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _modelOrDraughting;

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 2)]
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

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 3)]
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

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 4)]
	IIfcTextFontSelect IIfcTextStyle.TextFontStyle
	{
		get
		{
			if (TextFontStyle == null)
			{
				return null;
			}
			IfcExternallyDefinedTextFont ifcExternallyDefinedTextFont = TextFontStyle as IfcExternallyDefinedTextFont;
			if (ifcExternallyDefinedTextFont != null)
			{
				return ifcExternallyDefinedTextFont;
			}
			IfcPreDefinedTextFont ifcPreDefinedTextFont = TextFontStyle as IfcPreDefinedTextFont;
			if (ifcPreDefinedTextFont != null)
			{
				return ifcPreDefinedTextFont;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TextFontStyle = null;
				return;
			}
			IfcExternallyDefinedTextFont ifcExternallyDefinedTextFont = value as IfcExternallyDefinedTextFont;
			if (ifcExternallyDefinedTextFont != null)
			{
				TextFontStyle = ifcExternallyDefinedTextFont;
				return;
			}
			IfcPreDefinedTextFont ifcPreDefinedTextFont = value as IfcPreDefinedTextFont;
			if (ifcPreDefinedTextFont != null)
			{
				TextFontStyle = ifcPreDefinedTextFont;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 5)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcTextStyle.ModelOrDraughting
	{
		get
		{
			if (!ModelOrDraughting.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(ModelOrDraughting.Value);
		}
		set
		{
			ModelOrDraughting = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
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
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? ModelOrDraughting
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
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
