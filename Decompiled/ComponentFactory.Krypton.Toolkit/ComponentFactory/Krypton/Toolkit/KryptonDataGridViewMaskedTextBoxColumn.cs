using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBoxColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewMaskedTextBoxColumn), "ToolboxBitmaps.KryptonMaskedTextBox.bmp")]
public class KryptonDataGridViewMaskedTextBoxColumn : DataGridViewColumn
{
	private DataGridViewColumnSpecCollection _buttonSpecs;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell = value as KryptonDataGridViewMaskedTextBoxCell;
			if (value != null && kryptonDataGridViewMaskedTextBoxCell == null)
			{
				throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewMaskedTextBoxCell or derive from it.");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Appearance")]
	[Description("Indicates the character used as the placeholder.")]
	[DefaultValue('_')]
	public char PromptChar
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.PromptChar;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.PromptChar = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetPromptChar(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the prompt character is valid as input.")]
	[DefaultValue(true)]
	public bool AllowPromptAsInput
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.AllowPromptAsInput;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.AllowPromptAsInput = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetAllowPromptAsInput(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether only Ascii characters are valid as input.")]
	[DefaultValue(false)]
	public bool AsciiOnly
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.AsciiOnly;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.AsciiOnly = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetAsciiOnly(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the control will beep when an invalid character is typed.")]
	[DefaultValue(false)]
	public bool BeepOnError
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.BeepOnError;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.BeepOnError = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetBeepOnError(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the text to be copied to the clipboard includes literals and/or prompt characters.")]
	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	public MaskFormat CutCopyMaskFormat
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.CutCopyMaskFormat;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.CutCopyMaskFormat = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetCutCopyMaskFormat(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether prompt characters are displayed when the control does not have focus.")]
	[DefaultValue(false)]
	public bool HidePromptOnLeave
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.HidePromptOnLeave;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.HidePromptOnLeave = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetHidePromptOnLeave(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates that the selection should be hidden when the edit control loses focus.")]
	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.HideSelection;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.HideSelection = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetHideSelection(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates the masked text box input character typing mode.")]
	[DefaultValue(typeof(InsertKeyMode), "Default")]
	public InsertKeyMode InsertKeyMode
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.InsertKeyMode;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.InsertKeyMode = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetInsertKeyMode(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Sets the string governing the input allowed for the control.")]
	[DefaultValue("")]
	public string Mask
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.Mask;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.Mask = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetMask(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates the character to display for password input for single-line edit controls.")]
	[DefaultValue('\0')]
	public char PasswordChar
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.PasswordChar;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.PasswordChar = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetPasswordChar(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("If true, the input is rejected whenever a character fails to comply with the mask; otherwise, characters in the text area are processed one by one as individual inputs.")]
	[DefaultValue(false)]
	public bool RejectInputOnFirstFailure
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.RejectInputOnFirstFailure;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.RejectInputOnFirstFailure = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetRejectInputOnFirstFailure(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to reset and skip the current position if editable, when the input characters has the same value as the prompt.")]
	[DefaultValue(true)]
	public bool ResetOnPrompt
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.ResetOnPrompt;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.ResetOnPrompt = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetResetOnPrompt(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to reset and skip the current position if editable, when the input is the space character.")]
	[DefaultValue(true)]
	public bool ResetOnSpace
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.ResetOnSpace;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.ResetOnSpace = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetResetOnSpace(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to skip the current position if non-editable and the input character has the same value as the literal at that position.")]
	[DefaultValue(true)]
	public bool SkipLiterals
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.SkipLiterals;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.SkipLiterals = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetSkipLiterals(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the string returned from the Text property includes literal and/or prompt characters.")]
	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	public MaskFormat TextMaskFormat
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.TextMaskFormat;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.TextMaskFormat = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetTextMaskFormat(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the text in the edit control should appear as the default password character.")]
	[DefaultValue(false)]
	public bool UseSystemPasswordChar
	{
		get
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return MaskedTextBoxCellTemplate.UseSystemPasswordChar;
		}
		set
		{
			if (MaskedTextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			MaskedTextBoxCellTemplate.UseSystemPasswordChar = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell)
				{
					kryptonDataGridViewMaskedTextBoxCell.SetUseSystemPasswordChar(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	private KryptonDataGridViewMaskedTextBoxCell MaskedTextBoxCellTemplate => (KryptonDataGridViewMaskedTextBoxCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewMaskedTextBoxColumn()
		: base(new KryptonDataGridViewMaskedTextBoxCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewMaskedTextBoxColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewMaskedTextBoxColumn kryptonDataGridViewMaskedTextBoxColumn = base.Clone() as KryptonDataGridViewMaskedTextBoxColumn;
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewMaskedTextBoxColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewMaskedTextBoxColumn;
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
