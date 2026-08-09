using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcTextStyle", 427)]
public class IfcTextStyle : IfcPresentationStyle, IIfcTextStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcTextStyle>
{
	private IfcBoolean? _modelOrDraughting;

	private IfcCharacterStyleSelect _textCharacterAppearance;

	private IfcTextStyleSelect _textStyle;

	private Xbim.Ifc2x3.PresentationResource.IfcTextFontSelect _textFontStyle;

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 2)]
	IIfcTextStyleForDefinedFont IIfcTextStyle.TextCharacterAppearance
	{
		get
		{
			return TextCharacterAppearance as IIfcTextStyleForDefinedFont;
		}
		set
		{
			TextCharacterAppearance = value as IfcCharacterStyleSelect;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 3)]
	IIfcTextStyleTextModel IIfcTextStyle.TextStyle
	{
		get
		{
			return TextStyle as IIfcTextStyleTextModel;
		}
		set
		{
			TextStyle = value as IfcTextStyleSelect;
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
			Xbim.Ifc2x3.PresentationResource.IfcPreDefinedTextFont ifcPreDefinedTextFont = TextFontStyle as Xbim.Ifc2x3.PresentationResource.IfcPreDefinedTextFont;
			if (ifcPreDefinedTextFont != null)
			{
				return ifcPreDefinedTextFont;
			}
			Xbim.Ifc2x3.PresentationResource.IfcExternallyDefinedTextFont ifcExternallyDefinedTextFont = TextFontStyle as Xbim.Ifc2x3.PresentationResource.IfcExternallyDefinedTextFont;
			if (ifcExternallyDefinedTextFont != null)
			{
				return ifcExternallyDefinedTextFont;
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
			Xbim.Ifc2x3.PresentationResource.IfcExternallyDefinedTextFont ifcExternallyDefinedTextFont = value as Xbim.Ifc2x3.PresentationResource.IfcExternallyDefinedTextFont;
			if (ifcExternallyDefinedTextFont != null)
			{
				TextFontStyle = ifcExternallyDefinedTextFont;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcPreDefinedTextFont ifcPreDefinedTextFont = value as Xbim.Ifc2x3.PresentationResource.IfcPreDefinedTextFont;
			if (ifcPreDefinedTextFont != null)
			{
				TextFontStyle = ifcPreDefinedTextFont;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyle), 5)]
	IfcBoolean? IIfcTextStyle.ModelOrDraughting
	{
		get
		{
			return _modelOrDraughting;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_modelOrDraughting = v;
			}, _modelOrDraughting, value, "ModelOrDraughting", -5);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCharacterStyleSelect TextCharacterAppearance
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
			SetValue(delegate(IfcCharacterStyleSelect v)
			{
				_textCharacterAppearance = v;
			}, _textCharacterAppearance, value, "TextCharacterAppearance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcTextStyleSelect TextStyle
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
			SetValue(delegate(IfcTextStyleSelect v)
			{
				_textStyle = v;
			}, _textStyle, value, "TextStyle", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.PresentationResource.IfcTextFontSelect TextFontStyle
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
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcTextFontSelect v)
			{
				_textFontStyle = v;
			}, _textFontStyle, value, "TextFontStyle", 4);
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
			_textCharacterAppearance = (IfcCharacterStyleSelect)value.EntityVal;
			break;
		case 2:
			_textStyle = (IfcTextStyleSelect)value.EntityVal;
			break;
		case 3:
			_textFontStyle = (Xbim.Ifc2x3.PresentationResource.IfcTextFontSelect)value.EntityVal;
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
