using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextStyleTextModel", 581)]
public class IfcTextStyleTextModel : IfcPresentationItem, IIfcTextStyleTextModel, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcTextStyleTextModel>
{
	private IfcSizeSelect _textIndent;

	private IfcTextAlignment? _textAlign;

	private IfcTextDecoration? _textDecoration;

	private IfcSizeSelect _letterSpacing;

	private IfcSizeSelect _wordSpacing;

	private IfcTextTransformation? _textTransform;

	private IfcSizeSelect _lineHeight;

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 1)]
	IIfcSizeSelect IIfcTextStyleTextModel.TextIndent
	{
		get
		{
			if (TextIndent == null)
			{
				return null;
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)TextIndent);
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)TextIndent);
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)TextIndent);
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)TextIndent);
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)TextIndent);
			}
			if (TextIndent is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)TextIndent);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TextIndent = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				TextIndent = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 2)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcTextAlignment? IIfcTextStyleTextModel.TextAlign
	{
		get
		{
			if (!TextAlign.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcTextAlignment(TextAlign.Value);
		}
		set
		{
			TextAlign = (value.HasValue ? new IfcTextAlignment?(new IfcTextAlignment(value.Value)) : ((IfcTextAlignment?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 3)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcTextDecoration? IIfcTextStyleTextModel.TextDecoration
	{
		get
		{
			if (!TextDecoration.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcTextDecoration(TextDecoration.Value);
		}
		set
		{
			TextDecoration = (value.HasValue ? new IfcTextDecoration?(new IfcTextDecoration(value.Value)) : ((IfcTextDecoration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 4)]
	IIfcSizeSelect IIfcTextStyleTextModel.LetterSpacing
	{
		get
		{
			if (LetterSpacing == null)
			{
				return null;
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)LetterSpacing);
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)LetterSpacing);
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)LetterSpacing);
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)LetterSpacing);
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)LetterSpacing);
			}
			if (LetterSpacing is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)LetterSpacing);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				LetterSpacing = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				LetterSpacing = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 5)]
	IIfcSizeSelect IIfcTextStyleTextModel.WordSpacing
	{
		get
		{
			if (WordSpacing == null)
			{
				return null;
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)WordSpacing);
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)WordSpacing);
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)WordSpacing);
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)WordSpacing);
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)WordSpacing);
			}
			if (WordSpacing is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)WordSpacing);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				WordSpacing = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				WordSpacing = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 6)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcTextTransformation? IIfcTextStyleTextModel.TextTransform
	{
		get
		{
			if (!TextTransform.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcTextTransformation(TextTransform.Value);
		}
		set
		{
			TextTransform = (value.HasValue ? new IfcTextTransformation?(new IfcTextTransformation(value.Value)) : ((IfcTextTransformation?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleTextModel), 7)]
	IIfcSizeSelect IIfcTextStyleTextModel.LineHeight
	{
		get
		{
			if (LineHeight == null)
			{
				return null;
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)LineHeight);
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)LineHeight);
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)LineHeight);
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)LineHeight);
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)LineHeight);
			}
			if (LineHeight is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)LineHeight);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				LineHeight = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				LineHeight = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
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
