using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.ComponentModel.Validator;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeComboBox : ComboBox
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
			else
			{
				Text = Validator.ValueToDisplayString(value);
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
				Text = Validator.ValueToDisplayString(convertedValue);
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

	public bool IsValidValue(out object convertedValue)
	{
		object obj = ((base.SelectedValue != null) ? base.SelectedValue : ((base.SelectedItem != null) ? base.SelectedItem : Text));
		if (Validator == null)
		{
			convertedValue = obj;
			return true;
		}
		if (!Validator.IsValidObject(obj, out convertedValue))
		{
			return false;
		}
		return true;
	}

	protected virtual void ApplyValidatorRules()
	{
		base.Items.Clear();
		if (Validator == null || Validator.StandardValues == null)
		{
			return;
		}
		foreach (object standardValue in Validator.StandardValues)
		{
			base.Items.Add(standardValue);
		}
		if (!Validator.IsStringConversionSupported())
		{
			base.DropDownStyle = ComboBoxStyle.DropDownList;
		}
		else
		{
			base.DropDownStyle = ComboBoxStyle.DropDown;
		}
	}

	protected override void OnFormat(ListControlConvertEventArgs e)
	{
		base.OnFormat(e);
		if (!(e.DesiredType != typeof(string)) && Validator != null)
		{
			e.Value = Validator.ValueToDisplayString(e.ListItem);
		}
	}
}
