using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.ComponentModel.Validator;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeTextBox : TextBox
{
	private bool bool_0 = false;

	private IValidator ivalidator_0 = null;

	[DefaultValue(false)]
	public bool FormatValue
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

	[DefaultValue(null)]
	public IValidator Validator
	{
		get
		{
			return ivalidator_0;
		}
		set
		{
			if (ivalidator_0 != value)
			{
				if (ivalidator_0 != null)
				{
					ivalidator_0.Changed -= ivalidator_0_Changed;
				}
				ivalidator_0 = value;
				ivalidator_0.Changed += ivalidator_0_Changed;
				ApplyValidatorRules();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object Value
	{
		get
		{
			if (!IsValidValue(out var convertedValue))
			{
				throw new ArgumentOutOfRangeException("Text");
			}
			return convertedValue;
		}
		set
		{
			if (Validator == null)
			{
				if (value != null)
				{
					Text = value.ToString();
				}
				else
				{
					Text = "";
				}
			}
			else if (!Validator.IsStringConversionSupported())
			{
				Text = Validator.ValueToDisplayString(value);
			}
			else
			{
				Text = Validator.ValueToString(value);
			}
		}
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
		if (IsValidValue(out var convertedValue))
		{
			if (FormatValue && Validator != null)
			{
				if (!Validator.IsStringConversionSupported())
				{
					Text = Validator.ValueToDisplayString(convertedValue);
				}
				else
				{
					Text = Validator.ValueToString(convertedValue);
				}
			}
		}
		else
		{
			e.Cancel = true;
		}
	}

	private void ivalidator_0_Changed(object sender, EventArgs e)
	{
		ApplyValidatorRules();
	}

	protected virtual void ApplyValidatorRules()
	{
	}

	public bool IsValidValue(out object convertedValue)
	{
		if (Validator == null)
		{
			convertedValue = Text;
			return true;
		}
		if (!Validator.IsValidObject(Text, out convertedValue))
		{
			return false;
		}
		return true;
	}
}
