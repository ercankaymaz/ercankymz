using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DevAge.ComponentModel.Validator;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeTextBoxButton : EditableControlBase
{
	internal Button button_0;

	internal TextBox textBox_0;

	private Container container_2 = null;

	private IValidator ivalidator_0 = null;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	private object object_0 = null;

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

	public Button Button => button_0;

	public TextBox TextBox => textBox_0;

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
					TextBox.Text = value.ToString();
				}
				else
				{
					TextBox.Text = "";
				}
			}
			else if (!Validator.IsStringConversionSupported())
			{
				TextBox.Text = Validator.ValueToDisplayString(value);
			}
			else
			{
				TextBox.Text = Validator.ValueToString(value);
			}
			object_0 = value;
		}
	}

	public event EventHandler DialogOpen
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler DialogClosed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DevAgeTextBoxButton()
	{
		Class76.smethod_393(this);
		button_0.BackColor = Color.FromKnownColor(KnownColor.Control);
		textBox_0.TextChanged += textBox_0_TextChanged;
		SetContentAndButtonLocation(textBox_0, button_0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_2 != null)
		{
			container_2.Dispose();
		}
		base.Dispose(disposing);
	}

	private void ivalidator_0_Changed(object sender, EventArgs e)
	{
		ApplyValidatorRules();
	}

	protected virtual void ApplyValidatorRules()
	{
	}

	public virtual void ShowDialog()
	{
		OnDialogOpen(EventArgs.Empty);
		OnDialogClosed(EventArgs.Empty);
	}

	internal void method_0(object sender, EventArgs e)
	{
		ShowDialog();
	}

	protected virtual void OnDialogOpen(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	protected virtual void OnDialogClosed(EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	protected override void OnBorderStyleChanged(EventArgs e)
	{
		base.OnBorderStyleChanged(e);
		SetContentAndButtonLocation(textBox_0, button_0);
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		base.OnBackColorChanged(e);
		if (textBox_0 != null)
		{
			if (!(base.BackColor == Color.Transparent))
			{
				textBox_0.BackColor = base.BackColor;
			}
			else
			{
				textBox_0.BackColor = Color.FromKnownColor(KnownColor.Window);
			}
		}
	}

	protected override void OnForeColorChanged(EventArgs e)
	{
		base.OnForeColorChanged(e);
		if (textBox_0 != null)
		{
			textBox_0.ForeColor = ForeColor;
		}
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
		if (!IsValidValue(out var _))
		{
			e.Cancel = true;
		}
	}

	public bool IsValidValue(out object convertedValue)
	{
		if (Validator == null)
		{
			convertedValue = textBox_0.Text;
			return true;
		}
		if (object_0 == null)
		{
			if (!Validator.IsValidObject(TextBox.Text, out object_0))
			{
				convertedValue = null;
				return false;
			}
			convertedValue = object_0;
			return true;
		}
		convertedValue = object_0;
		return true;
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		object_0 = null;
	}
}
