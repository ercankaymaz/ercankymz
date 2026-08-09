using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewMaskedTextBoxCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonMaskedTextBox _paintingMaskedTextBox;

	private static readonly DataGridViewContentAlignment _anyRight = (DataGridViewContentAlignment)1092;

	private static readonly DataGridViewContentAlignment _anyCenter = (DataGridViewContentAlignment)546;

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewMaskedTextBoxEditingControl);

	private static readonly Type _defaultValueType = typeof(string);

	private static readonly Size _sizeLarge = new Size(10000, 10000);

	private char _promptChar;

	private bool _allowPromptAsInput;

	private bool _asciiOnly;

	private bool _beepOnError;

	private MaskFormat _cutCopyMaskFormat;

	private bool _hidePromptOnLeave;

	private bool _hideSelection;

	private InsertKeyMode _insertKeyMode;

	private string _mask;

	private char _passwordChar;

	private bool _rejectInputOnFirstFailure;

	private bool _resetOnPrompt;

	private bool _resetOnSpace;

	private bool _skipLiterals;

	private MaskFormat _textMaskFormat;

	private bool _useSystemPasswordChar;

	public override Type EditType => _defaultEditType;

	public override Type ValueType
	{
		get
		{
			Type valueType = base.ValueType;
			if (valueType != null)
			{
				return valueType;
			}
			return _defaultValueType;
		}
	}

	[DefaultValue('_')]
	public char PromptChar
	{
		get
		{
			return _promptChar;
		}
		set
		{
			if (_promptChar != value)
			{
				SetPromptChar(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool AllowPromptAsInput
	{
		get
		{
			return _allowPromptAsInput;
		}
		set
		{
			if (_allowPromptAsInput != value)
			{
				SetAllowPromptAsInput(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool AsciiOnly
	{
		get
		{
			return _asciiOnly;
		}
		set
		{
			if (_asciiOnly != value)
			{
				SetAsciiOnly(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool BeepOnError
	{
		get
		{
			return _beepOnError;
		}
		set
		{
			if (_beepOnError != value)
			{
				SetBeepOnError(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	public MaskFormat CutCopyMaskFormat
	{
		get
		{
			return _cutCopyMaskFormat;
		}
		set
		{
			if (_cutCopyMaskFormat != value)
			{
				SetCutCopyMaskFormat(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool HidePromptOnLeave
	{
		get
		{
			return _hidePromptOnLeave;
		}
		set
		{
			if (_hidePromptOnLeave != value)
			{
				SetHidePromptOnLeave(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			return _hideSelection;
		}
		set
		{
			if (_hideSelection != value)
			{
				SetHideSelection(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(InsertKeyMode), "Default")]
	public InsertKeyMode InsertKeyMode
	{
		get
		{
			return _insertKeyMode;
		}
		set
		{
			if (_insertKeyMode != value)
			{
				SetInsertKeyMode(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue("")]
	public string Mask
	{
		get
		{
			return _mask;
		}
		set
		{
			if (_mask != value)
			{
				SetMask(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue('\0')]
	public char PasswordChar
	{
		get
		{
			return _passwordChar;
		}
		set
		{
			if (_passwordChar != value)
			{
				SetPasswordChar(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool RejectInputOnFirstFailure
	{
		get
		{
			return _rejectInputOnFirstFailure;
		}
		set
		{
			if (_rejectInputOnFirstFailure != value)
			{
				SetRejectInputOnFirstFailure(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool ResetOnPrompt
	{
		get
		{
			return _resetOnPrompt;
		}
		set
		{
			if (_resetOnPrompt != value)
			{
				SetResetOnPrompt(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool ResetOnSpace
	{
		get
		{
			return _resetOnSpace;
		}
		set
		{
			if (_resetOnSpace != value)
			{
				SetResetOnSpace(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool SkipLiterals
	{
		get
		{
			return _skipLiterals;
		}
		set
		{
			if (_skipLiterals != value)
			{
				SetSkipLiterals(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	public MaskFormat TextMaskFormat
	{
		get
		{
			return _textMaskFormat;
		}
		set
		{
			if (_textMaskFormat != value)
			{
				SetTextMaskFormat(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool UseSystemPasswordChar
	{
		get
		{
			return _useSystemPasswordChar;
		}
		set
		{
			if (_useSystemPasswordChar != value)
			{
				SetUseSystemPasswordChar(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	private KryptonDataGridViewMaskedTextBoxEditingControl EditingMaskedTextBox => base.DataGridView.EditingControl as KryptonDataGridViewMaskedTextBoxEditingControl;

	public KryptonDataGridViewMaskedTextBoxCell()
	{
		if (_paintingMaskedTextBox == null)
		{
			_paintingMaskedTextBox = new KryptonMaskedTextBox();
			_paintingMaskedTextBox.SetLayoutDisplayPadding(new Padding(0, 0, 1, -1));
			_paintingMaskedTextBox.StateCommon.Border.Width = 0;
			_paintingMaskedTextBox.StateCommon.Border.Draw = InheritBool.False;
			_paintingMaskedTextBox.StateCommon.Back.Color1 = Color.Empty;
		}
		_promptChar = '_';
		_allowPromptAsInput = true;
		_asciiOnly = false;
		_beepOnError = false;
		_cutCopyMaskFormat = MaskFormat.IncludeLiterals;
		_hidePromptOnLeave = false;
		_hideSelection = true;
		_insertKeyMode = InsertKeyMode.Default;
		_mask = string.Empty;
		_passwordChar = '\0';
		_rejectInputOnFirstFailure = false;
		_resetOnPrompt = true;
		_resetOnSpace = true;
		_skipLiterals = true;
		_textMaskFormat = MaskFormat.IncludeLiterals;
		_useSystemPasswordChar = false;
	}

	public override string ToString()
	{
		return "DataGridViewMaskedTextBoxCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	public override object Clone()
	{
		KryptonDataGridViewMaskedTextBoxCell kryptonDataGridViewMaskedTextBoxCell = base.Clone() as KryptonDataGridViewMaskedTextBoxCell;
		if (kryptonDataGridViewMaskedTextBoxCell != null)
		{
			kryptonDataGridViewMaskedTextBoxCell.PromptChar = PromptChar;
			kryptonDataGridViewMaskedTextBoxCell.AllowPromptAsInput = AllowPromptAsInput;
			kryptonDataGridViewMaskedTextBoxCell.AsciiOnly = AsciiOnly;
			kryptonDataGridViewMaskedTextBoxCell.BeepOnError = BeepOnError;
			kryptonDataGridViewMaskedTextBoxCell.CutCopyMaskFormat = CutCopyMaskFormat;
			kryptonDataGridViewMaskedTextBoxCell.HidePromptOnLeave = HidePromptOnLeave;
			kryptonDataGridViewMaskedTextBoxCell.HideSelection = HideSelection;
			kryptonDataGridViewMaskedTextBoxCell.InsertKeyMode = InsertKeyMode;
			kryptonDataGridViewMaskedTextBoxCell.Mask = Mask;
			kryptonDataGridViewMaskedTextBoxCell.PasswordChar = PasswordChar;
			kryptonDataGridViewMaskedTextBoxCell.RejectInputOnFirstFailure = RejectInputOnFirstFailure;
			kryptonDataGridViewMaskedTextBoxCell.ResetOnPrompt = ResetOnPrompt;
			kryptonDataGridViewMaskedTextBoxCell.ResetOnSpace = ResetOnSpace;
			kryptonDataGridViewMaskedTextBoxCell.SkipLiterals = SkipLiterals;
			kryptonDataGridViewMaskedTextBoxCell.TextMaskFormat = TextMaskFormat;
			kryptonDataGridViewMaskedTextBoxCell.UseSystemPasswordChar = UseSystemPasswordChar;
		}
		return kryptonDataGridViewMaskedTextBoxCell;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonMaskedTextBox kryptonMaskedTextBox && base.OwningColumn is KryptonDataGridViewMaskedTextBoxColumn)
		{
			foreach (ButtonSpecAny buttonSpec in kryptonMaskedTextBox.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonMaskedTextBox.ButtonSpecs.Clear();
			if (kryptonMaskedTextBox.Controls[0] is TextBox textBox)
			{
				textBox.ClearUndo();
			}
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonMaskedTextBox kryptonMaskedTextBox))
		{
			return;
		}
		kryptonMaskedTextBox.PromptChar = PromptChar;
		kryptonMaskedTextBox.AllowPromptAsInput = AllowPromptAsInput;
		kryptonMaskedTextBox.AsciiOnly = AsciiOnly;
		kryptonMaskedTextBox.BeepOnError = BeepOnError;
		kryptonMaskedTextBox.CutCopyMaskFormat = CutCopyMaskFormat;
		kryptonMaskedTextBox.HidePromptOnLeave = HidePromptOnLeave;
		kryptonMaskedTextBox.HideSelection = HideSelection;
		kryptonMaskedTextBox.InsertKeyMode = InsertKeyMode;
		kryptonMaskedTextBox.Mask = Mask;
		kryptonMaskedTextBox.PasswordChar = PasswordChar;
		kryptonMaskedTextBox.RejectInputOnFirstFailure = RejectInputOnFirstFailure;
		kryptonMaskedTextBox.ResetOnPrompt = ResetOnPrompt;
		kryptonMaskedTextBox.ResetOnSpace = ResetOnSpace;
		kryptonMaskedTextBox.SkipLiterals = SkipLiterals;
		kryptonMaskedTextBox.TextMaskFormat = TextMaskFormat;
		kryptonMaskedTextBox.UseSystemPasswordChar = UseSystemPasswordChar;
		if (base.OwningColumn is KryptonDataGridViewMaskedTextBoxColumn kryptonDataGridViewMaskedTextBoxColumn)
		{
			kryptonMaskedTextBox.ButtonSpecs.Clear();
			kryptonMaskedTextBox.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewMaskedTextBoxColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonMaskedTextBox.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		if (!(initialFormattedValue is string text))
		{
			kryptonMaskedTextBox.Text = string.Empty;
		}
		else
		{
			kryptonMaskedTextBox.Text = text;
		}
	}

	public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
	{
		Rectangle editingControlBounds = PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
		editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
		base.DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
		base.DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
	}

	protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
	{
		Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
		if (base.DataGridView.RightToLeft == RightToLeft.Yes)
		{
			errorIconBounds.X = errorIconBounds.Left + 16;
		}
		else
		{
			errorIconBounds.X = errorIconBounds.Left - 16;
		}
		return errorIconBounds;
	}

	protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
	{
		if (base.DataGridView == null)
		{
			return new Size(-1, -1);
		}
		Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
		if (constraintSize.Width == 0)
		{
			preferredSize.Width += 24;
		}
		return preferredSize;
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
		KryptonDataGridViewMaskedTextBoxColumn kryptonDataGridViewMaskedTextBoxColumn = base.OwningColumn as KryptonDataGridViewMaskedTextBoxColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewMaskedTextBoxColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewMaskedTextBoxColumn.PerfomButtonSpecClick(args);
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int num = _paintingMaskedTextBox.GetPreferredSize(_sizeLarge).Height + 2;
		if (num < editingControlBounds.Height)
		{
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.MiddleLeft:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.MiddleRight:
				editingControlBounds.Y += (editingControlBounds.Height - num) / 2;
				break;
			case DataGridViewContentAlignment.BottomLeft:
			case DataGridViewContentAlignment.BottomCenter:
			case DataGridViewContentAlignment.BottomRight:
				editingControlBounds.Y += editingControlBounds.Height - num;
				break;
			}
		}
		return editingControlBounds;
	}

	private void OnCommonChange()
	{
		if (base.DataGridView != null && !base.DataGridView.IsDisposed && !base.DataGridView.Disposing)
		{
			if (base.RowIndex == -1)
			{
				base.DataGridView.InvalidateColumn(base.ColumnIndex);
			}
			else
			{
				base.DataGridView.UpdateCellValue(base.ColumnIndex, base.RowIndex);
			}
		}
	}

	private bool OwnsEditingMaskedTextBox(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewMaskedTextBoxEditingControl kryptonDataGridViewMaskedTextBoxEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewMaskedTextBoxEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}

	internal void SetPromptChar(int rowIndex, char value)
	{
		_promptChar = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.PromptChar = value;
		}
	}

	internal void SetAllowPromptAsInput(int rowIndex, bool value)
	{
		_allowPromptAsInput = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.AllowPromptAsInput = value;
		}
	}

	internal void SetAsciiOnly(int rowIndex, bool value)
	{
		_asciiOnly = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.AsciiOnly = value;
		}
	}

	internal void SetBeepOnError(int rowIndex, bool value)
	{
		_beepOnError = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.BeepOnError = value;
		}
	}

	internal void SetCutCopyMaskFormat(int rowIndex, MaskFormat value)
	{
		_cutCopyMaskFormat = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.CutCopyMaskFormat = value;
		}
	}

	internal void SetHidePromptOnLeave(int rowIndex, bool value)
	{
		_hidePromptOnLeave = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.HidePromptOnLeave = value;
		}
	}

	internal void SetHideSelection(int rowIndex, bool value)
	{
		_hideSelection = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.HideSelection = value;
		}
	}

	internal void SetInsertKeyMode(int rowIndex, InsertKeyMode value)
	{
		_insertKeyMode = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.InsertKeyMode = value;
		}
	}

	internal void SetMask(int rowIndex, string value)
	{
		_mask = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.Mask = value;
		}
	}

	internal void SetPasswordChar(int rowIndex, char value)
	{
		_passwordChar = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.PasswordChar = value;
		}
	}

	internal void SetRejectInputOnFirstFailure(int rowIndex, bool value)
	{
		_rejectInputOnFirstFailure = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.RejectInputOnFirstFailure = value;
		}
	}

	internal void SetResetOnPrompt(int rowIndex, bool value)
	{
		_resetOnPrompt = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.ResetOnPrompt = value;
		}
	}

	internal void SetResetOnSpace(int rowIndex, bool value)
	{
		_resetOnSpace = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.ResetOnSpace = value;
		}
	}

	internal void SetSkipLiterals(int rowIndex, bool value)
	{
		_skipLiterals = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.SkipLiterals = value;
		}
	}

	internal void SetTextMaskFormat(int rowIndex, MaskFormat value)
	{
		_textMaskFormat = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.TextMaskFormat = value;
		}
	}

	internal void SetUseSystemPasswordChar(int rowIndex, bool value)
	{
		_useSystemPasswordChar = value;
		if (OwnsEditingMaskedTextBox(rowIndex))
		{
			EditingMaskedTextBox.UseSystemPasswordChar = value;
		}
	}

	internal static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment align)
	{
		if ((align & _anyRight) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Right;
		}
		if ((align & _anyCenter) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Center;
		}
		return HorizontalAlignment.Left;
	}
}
