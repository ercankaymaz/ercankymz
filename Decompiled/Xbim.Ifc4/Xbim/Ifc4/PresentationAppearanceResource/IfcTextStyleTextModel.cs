using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextStyleTextModel", 581)]
public class IfcTextStyleTextModel : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextStyleTextModel, IIfcPresentationItem, IEquatable<IfcTextStyleTextModel>
{
	private IfcSizeSelect _textIndent;

	private IfcTextAlignment? _textAlign;

	private IfcTextDecoration? _textDecoration;

	private IfcSizeSelect _letterSpacing;

	private IfcSizeSelect _wordSpacing;

	private IfcTextTransformation? _textTransform;

	private IfcSizeSelect _lineHeight;

	IIfcSizeSelect IIfcTextStyleTextModel.TextIndent
	{
		get
		{
			return TextIndent;
		}
		set
		{
			TextIndent = value as IfcSizeSelect;
		}
	}

	IfcTextAlignment? IIfcTextStyleTextModel.TextAlign
	{
		get
		{
			return TextAlign;
		}
		set
		{
			TextAlign = value;
		}
	}

	IfcTextDecoration? IIfcTextStyleTextModel.TextDecoration
	{
		get
		{
			return TextDecoration;
		}
		set
		{
			TextDecoration = value;
		}
	}

	IIfcSizeSelect IIfcTextStyleTextModel.LetterSpacing
	{
		get
		{
			return LetterSpacing;
		}
		set
		{
			LetterSpacing = value as IfcSizeSelect;
		}
	}

	IIfcSizeSelect IIfcTextStyleTextModel.WordSpacing
	{
		get
		{
			return WordSpacing;
		}
		set
		{
			WordSpacing = value as IfcSizeSelect;
		}
	}

	IfcTextTransformation? IIfcTextStyleTextModel.TextTransform
	{
		get
		{
			return TextTransform;
		}
		set
		{
			TextTransform = value;
		}
	}

	IIfcSizeSelect IIfcTextStyleTextModel.LineHeight
	{
		get
		{
			return LineHeight;
		}
		set
		{
			LineHeight = value as IfcSizeSelect;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcSizeSelect TextIndent
	{
		get
		{
			if (_activated)
			{
				return _textIndent;
			}
			Activate();
			return _textIndent;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_textIndent = v;
			}, _textIndent, value, "TextIndent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcTextAlignment? TextAlign
	{
		get
		{
			if (_activated)
			{
				return _textAlign;
			}
			Activate();
			return _textAlign;
		}
		set
		{
			SetValue(delegate(IfcTextAlignment? v)
			{
				_textAlign = v;
			}, _textAlign, value, "TextAlign", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcTextDecoration? TextDecoration
	{
		get
		{
			if (_activated)
			{
				return _textDecoration;
			}
			Activate();
			return _textDecoration;
		}
		set
		{
			SetValue(delegate(IfcTextDecoration? v)
			{
				_textDecoration = v;
			}, _textDecoration, value, "TextDecoration", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcSizeSelect LetterSpacing
	{
		get
		{
			if (_activated)
			{
				return _letterSpacing;
			}
			Activate();
			return _letterSpacing;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_letterSpacing = v;
			}, _letterSpacing, value, "LetterSpacing", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSizeSelect WordSpacing
	{
		get
		{
			if (_activated)
			{
				return _wordSpacing;
			}
			Activate();
			return _wordSpacing;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_wordSpacing = v;
			}, _wordSpacing, value, "WordSpacing", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcTextTransformation? TextTransform
	{
		get
		{
			if (_activated)
			{
				return _textTransform;
			}
			Activate();
			return _textTransform;
		}
		set
		{
			SetValue(delegate(IfcTextTransformation? v)
			{
				_textTransform = v;
			}, _textTransform, value, "TextTransform", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcSizeSelect LineHeight
	{
		get
		{
			if (_activated)
			{
				return _lineHeight;
			}
			Activate();
			return _lineHeight;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_lineHeight = v;
			}, _lineHeight, value, "LineHeight", 7);
		}
	}

	internal IfcTextStyleTextModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_textIndent = (IfcSizeSelect)value.EntityVal;
			break;
		case 1:
			_textAlign = value.StringVal;
			break;
		case 2:
			_textDecoration = value.StringVal;
			break;
		case 3:
			_letterSpacing = (IfcSizeSelect)value.EntityVal;
			break;
		case 4:
			_wordSpacing = (IfcSizeSelect)value.EntityVal;
			break;
		case 5:
			_textTransform = value.StringVal;
			break;
		case 6:
			_lineHeight = (IfcSizeSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextStyleTextModel other)
	{
		return this == other;
	}
}
