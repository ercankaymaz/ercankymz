using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcTextStyleFontModel", 503)]
public class IfcTextStyleFontModel : IfcPreDefinedTextFont, IIfcTextStyleFontModel, IIfcPreDefinedTextFont, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontSelect, IIfcTextFontSelect, IExpressSelectType, IInstantiableEntity, IEquatable<IfcTextStyleFontModel>, IExpressValidatable
{
	public enum IfcTextStyleFontModelClause
	{
		WR31
	}

	private readonly OptionalItemSet<IfcTextFontName> _fontFamily;

	private IfcFontStyle? _fontStyle;

	private IfcFontVariant? _fontVariant;

	private IfcFontWeight? _fontWeight;

	private Xbim.Ifc2x3.PresentationAppearanceResource.IfcSizeSelect _fontSize;

	[CrossSchemaAttribute(typeof(IIfcTextStyleFontModel), 2)]
	IItemSet<Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontName> IIfcTextStyleFontModel.FontFamily => new ProxyValueSet<IfcTextFontName, Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontName>(FontFamily, (IfcTextFontName s) => new Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontName(s), (Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontName t) => new IfcTextFontName(t));

	[CrossSchemaAttribute(typeof(IIfcTextStyleFontModel), 3)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcFontStyle? IIfcTextStyleFontModel.FontStyle
	{
		get
		{
			if (!FontStyle.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcFontStyle(FontStyle.Value);
		}
		set
		{
			FontStyle = (value.HasValue ? new IfcFontStyle?(new IfcFontStyle(value.Value)) : ((IfcFontStyle?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleFontModel), 4)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcFontVariant? IIfcTextStyleFontModel.FontVariant
	{
		get
		{
			if (!FontVariant.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcFontVariant(FontVariant.Value);
		}
		set
		{
			FontVariant = (value.HasValue ? new IfcFontVariant?(new IfcFontVariant(value.Value)) : ((IfcFontVariant?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleFontModel), 5)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcFontWeight? IIfcTextStyleFontModel.FontWeight
	{
		get
		{
			if (!FontWeight.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcFontWeight(FontWeight.Value);
		}
		set
		{
			FontWeight = (value.HasValue ? new IfcFontWeight?(new IfcFontWeight(value.Value)) : ((IfcFontWeight?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleFontModel), 6)]
	IIfcSizeSelect IIfcTextStyleFontModel.FontSize
	{
		get
		{
			if (FontSize == null)
			{
				return null;
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)(object)FontSize);
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)(object)FontSize);
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)(object)FontSize);
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)(object)FontSize);
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)FontSize);
			}
			if (FontSize is Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)(object)FontSize);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				FontSize = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				FontSize = new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 2)]
	public IOptionalItemSet<IfcTextFontName> FontFamily
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
	public Xbim.Ifc2x3.PresentationAppearanceResource.IfcSizeSelect FontSize
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
			SetValue(delegate(Xbim.Ifc2x3.PresentationAppearanceResource.IfcSizeSelect v)
			{
				_fontSize = v;
			}, _fontSize, value, "FontSize", 6);
		}
	}

	internal IfcTextStyleFontModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_fontFamily = new OptionalItemSet<IfcTextFontName>(this, 0, 2);
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
			_fontSize = (Xbim.Ifc2x3.PresentationAppearanceResource.IfcSizeSelect)value.EntityVal;
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
			if (clause == IfcTextStyleFontModelClause.WR31)
			{
				result = Functions.TYPEOF(FontSize).Contains("IFC2X3.IFCLENGTHMEASURE") && (double)FontSize.AsIfcLengthMeasure() > 0.0;
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
		if (!ValidateClause(IfcTextStyleFontModelClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTextStyleFontModel.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
