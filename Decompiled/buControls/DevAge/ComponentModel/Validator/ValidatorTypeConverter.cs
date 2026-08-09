using System;
using System.ComponentModel;
using SourceGrid.Utils;

namespace DevAge.ComponentModel.Validator;

[ToolboxItem(false)]
public class ValidatorTypeConverter : ValidatorBase
{
	private TypeConverter typeConverter_0;

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TypeConverter TypeConverter
	{
		get
		{
			return typeConverter_0;
		}
		set
		{
			if (typeConverter_0 != value)
			{
				typeConverter_0 = value;
				method_0();
				OnChanged(EventArgs.Empty);
			}
		}
	}

	public ValidatorTypeConverter()
	{
		typeConverter_0 = null;
	}

	public ValidatorTypeConverter(Type p_Type)
		: base(p_Type)
	{
	}

	public ValidatorTypeConverter(Type p_Type, TypeConverter p_TypeConverter)
		: base(p_Type)
	{
		TypeConverter = p_TypeConverter;
	}

	public override bool IsStringConversionSupported()
	{
		if (!typeof(string).IsAssignableFrom(base.ValueType))
		{
			if (typeConverter_0 == null)
			{
				return base.AllowStringConversion;
			}
			return base.AllowStringConversion && typeConverter_0.CanConvertFrom(typeof(string)) && typeConverter_0.CanConvertTo(typeof(string));
		}
		return base.AllowStringConversion;
	}

	protected override void OnConvertingObjectToValue(ConvertingObjectEventArgs e)
	{
		base.OnConvertingObjectToValue(e);
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.ConvertingStatus == ConvertingStatus.Completed || e.Value == null)
			{
				return;
			}
			if (!(e.Value is string))
			{
				if (!e.DestinationType.IsAssignableFrom(e.Value.GetType()) && typeConverter_0 != null)
				{
					if (!(typeConverter_0 is StringConverter))
					{
						e.Value = typeConverter_0.ConvertFrom(EmptyTypeDescriptorContext.Empty, base.CultureInfo, e.Value);
					}
					else
					{
						e.Value = SourceGridConvert.To<string>(e.Value);
					}
				}
				return;
			}
			string text = (string)e.Value;
			if (!IsNullString(text))
			{
				if (!e.DestinationType.IsAssignableFrom(e.Value.GetType()))
				{
					if (!IsStringConversionSupported())
					{
						throw new ApplicationException("String conversion not supported for this type of Validator.");
					}
					e.Value = typeConverter_0.ConvertFromString(EmptyTypeDescriptorContext.Empty, base.CultureInfo, text);
				}
			}
			else
			{
				e.Value = null;
			}
			return;
		}
		throw new ApplicationException("Invalid conversion");
	}

	protected override void OnConvertingValueToObject(ConvertingObjectEventArgs e)
	{
		base.OnConvertingValueToObject(e);
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.ConvertingStatus != ConvertingStatus.Completed && e.Value != null && !e.DestinationType.IsAssignableFrom(e.Value.GetType()))
			{
				if (e.DestinationType == typeof(string) && !IsStringConversionSupported())
				{
					throw new ApplicationException("String conversion not supported for this type of Validator.");
				}
				if (typeConverter_0 != null)
				{
					e.Value = typeConverter_0.ConvertTo(EmptyTypeDescriptorContext.Empty, base.CultureInfo, e.Value, e.DestinationType);
				}
			}
			return;
		}
		throw new ApplicationException("Invalid conversion");
	}

	private void method_0()
	{
		base.StandardValues = null;
		base.StandardValuesExclusive = false;
		if (typeConverter_0 != null)
		{
			base.StandardValues = typeConverter_0.GetStandardValues();
			if (base.StandardValues == null || base.StandardValues.Count <= 0)
			{
				base.StandardValuesExclusive = false;
			}
			else
			{
				base.StandardValuesExclusive = typeConverter_0.GetStandardValuesExclusive();
			}
		}
	}

	protected override void OnLoadingValueType()
	{
		base.OnLoadingValueType();
		if (!(base.ValueType != null))
		{
			TypeConverter = null;
		}
		else
		{
			TypeConverter = TypeDescriptor.GetConverter(base.ValueType);
		}
	}
}
