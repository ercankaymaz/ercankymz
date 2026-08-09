using System;
using DevAge.ComponentModel.Validator;

namespace DevAge.Text.FixedLength;

public class Field : IField
{
	private int index;

	private string name;

	private int int_0;

	private bool bool_0 = true;

	private IValidator ivalidator_0;

	public int Index => index;

	public string Name => name;

	public int Length
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value <= 0)
			{
				throw new InvalidFieldLengthException(value);
			}
			int_0 = value;
		}
	}

	public bool TrimBeforeParse
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public IValidator Validator
	{
		get
		{
			return ivalidator_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Validator");
			}
			ivalidator_0 = value;
		}
	}

	public virtual string RegularExpressionPattern
	{
		get
		{
			string format = "(?<{0}>.{{{1}}})";
			return string.Format(format, Name, Length.ToString());
		}
	}

	public Field(int index, string name, int length, Type type)
		: this(index, name, length, new ValidatorTypeConverter(type))
	{
	}

	public Field(int index, string name, int length, IValidator validator)
	{
		this.index = index;
		this.name = name;
		Length = length;
		Validator = validator;
	}

	public virtual string ValueToString(object val)
	{
		try
		{
			string text = Validator.ValueToString(val);
			if (text == null)
			{
				text = string.Empty;
			}
			if (text.Length <= Length)
			{
				if (text.Length < Length)
				{
					if (!Validator.AllowNull)
					{
						if (!(Validator.ValueType == typeof(string)))
						{
							if (!(Validator.ValueType == typeof(int)))
							{
								if (!(Validator.ValueType == typeof(double)))
								{
									if (!(Validator.ValueType == typeof(decimal)))
									{
										throw new ValueNotSupportedException(text, Validator.ValueType);
									}
									throw new ValueNotValidLengthException(text, Length);
								}
								throw new ValueNotValidLengthException(text, Length);
							}
							text = text.PadLeft(Length, '0');
						}
						else
						{
							text = text.PadRight(Length, ' ');
						}
					}
					else
					{
						text = text.PadRight(Length, ' ');
					}
				}
				return text;
			}
			throw new ValueNotValidLengthException(text, Length);
		}
		catch (Exception innerException)
		{
			throw new FieldStringConvertException(Name, val, innerException);
		}
	}

	public virtual object StringToValue(string str)
	{
		try
		{
			if (TrimBeforeParse && str != null)
			{
				str = str.Trim();
			}
			return Validator.StringToValue(str);
		}
		catch (Exception innerException)
		{
			throw new FieldParseException(Name, str, innerException);
		}
	}
}
