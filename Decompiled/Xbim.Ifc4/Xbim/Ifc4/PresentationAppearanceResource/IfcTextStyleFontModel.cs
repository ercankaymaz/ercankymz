using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextStyleFontModel", 503)]
public class IfcTextStyleFontModel : IfcPreDefinedTextFont, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextStyleFontModel, IIfcPreDefinedTextFont, IIfcPreDefinedItem, IIfcPresentationItem, IfcTextFontSelect, IIfcTextFontSelect, IExpressSelectType, IEquatable<IfcTextStyleFontModel>, IExpressValidatable
{
	public enum IfcTextStyleFontModelClause
	{
		MeasureOfFontSize
	}

	private readonly ItemSet<IfcTextFontName> _fontFamily;

	private IfcFontStyle? _fontStyle;

	private IfcFontVariant? _fontVariant;

	private IfcFontWeight? _fontWeight;

	private IfcSizeSelect _fontSize;

	IItemSet<IfcTextFontName> IIfcTextStyleFontModel.FontFamily => FontFamily;

	IfcFontStyle? IIfcTextStyleFontModel.FontStyle
	{
		get
		{
			return FontStyle;
		}
		set
		{
			FontStyle = value;
		}
	}

	IfcFontVariant? IIfcTextStyleFontModel.FontVariant
	{
		get
		{
			return FontVariant;
		}
		set
		{
			FontVariant = value;
		}
	}

	IfcFontWeight? IIfcTextStyleFontModel.FontWeight
	{
		get
		{
			return FontWeight;
		}
		set
		{
			FontWeight = value;
		}
	}

	IIfcSizeSelect IIfcTextStyleFontModel.FontSize
	{
		get
		{
			return FontSize;
		}
		set
		{
			FontSize = value as IfcSizeSelect;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcTextFontName> FontFamily
	{
		get
		{
			if (_activated)
			{
				return _fontFamily;
			}
			Activate();
			return _fontFamily;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcFontStyle? FontStyle
	{
		get
		{
			if (_activated)
			{
				return _fontStyle;
			}
			Activate();
			return _fontStyle;
		}
		set
		{
			SetValue(delegate(IfcFontStyle? v)
			{
				_fontStyle = v;
			}, _fontStyle, value, "FontStyle", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcFontVariant? FontVariant
	{
		get
		{
			if (_activated)
			{
				return _fontVariant;
			}
			Activate();
			return _fontVariant;
		}
		set
		{
			SetValue(delegate(IfcFontVariant? v)
			{
				_fontVariant = v;
			}, _fontVariant, value, "FontVariant", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcFontWeight? FontWeight
	{
		get
		{
			if (_activated)
			{
				return _fontWeight;
			}
			Activate();
			return _fontWeight;
		}
		set
		{
			SetValue(delegate(IfcFontWeight? v)
			{
				_fontWeight = v;
			}, _fontWeight, value, "FontWeight", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcSizeSelect FontSize
	{
		get
		{
			if (_activated)
			{
				return _fontSize;
			}
			Activate();
			return _fontSize;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_fontSize = v;
			}, _fontSize, value, "FontSize", 6);
		}
	}

	internal IfcTextStyleFontModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_fontFamily = new ItemSet<IfcTextFontName>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_fontFamily.InternalAdd(value.StringVal);
			break;
		case 2:
			_fontStyle = value.StringVal;
			break;
		case 3:
			_fontVariant = value.StringVal;
			break;
		case 4:
			_fontWeight = value.StringVal;
			break;
		case 5:
			_fontSize = (IfcSizeSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextStyleFontModel other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTextStyleFontModelClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTextStyleFontModelClause.MeasureOfFontSize)
			{
				result = Functions.TYPEOF(FontSize).Contains("IFC4.IFCLENGTHMEASURE") && (double)FontSize.AsIfcLengthMeasure() > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTextStyleFontModel>()?.LogError($"Exception thrown evaluating where-clause 'IfcTextStyleFontModel.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTextStyleFontModelClause.MeasureOfFontSize))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTextStyleFontModel.MeasureOfFontSize",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
