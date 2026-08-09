using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewButtonCell : DataGridViewButtonCell
{
	private static PropertyInfo _piButtonState;

	private static PropertyInfo _piMouseEnteredCellAddress;

	private static FieldInfo _fiMouseInContentBounds;

	private bool _styleSet;

	private ButtonStyle _buttonStyle;

	private PaletteTripleToPalette _palette;

	private ShortTextValue _shortTextValue;

	private ViewDrawButton _viewButton;

	private Rectangle _contentBounds;

	[Category("Appearance")]
	[DefaultValue(typeof(ButtonStyle), "Standalone")]
	public ButtonStyle ButtonStyle
	{
		get
		{
			return _buttonStyle;
		}
		set
		{
			_buttonStyle = value;
			_styleSet = true;
			base.DataGridView.InvalidateCell(this);
		}
	}

	internal ButtonStyle ButtonStyleInternal
	{
		set
		{
			if (!_styleSet)
			{
				_buttonStyle = value;
			}
		}
	}

	private ButtonState ButtonStateInternal
	{
		get
		{
			if (_piButtonState == null)
			{
				_piButtonState = typeof(DataGridViewButtonCell).GetProperty("ButtonState", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (ButtonState)_piButtonState.GetValue(this, null);
		}
	}

	private bool MouseInContentBoundsInternal
	{
		get
		{
			if (_fiMouseInContentBounds == null)
			{
				_fiMouseInContentBounds = typeof(DataGridViewButtonCell).GetField("mouseInContentBounds", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (bool)_fiMouseInContentBounds.GetValue(this);
		}
	}

	private Point MouseEnteredCellAddressInternal
	{
		get
		{
			if (_piMouseEnteredCellAddress == null)
			{
				_piMouseEnteredCellAddress = typeof(DataGridView).GetProperty("MouseEnteredCellAddress", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (Point)_piMouseEnteredCellAddress.GetValue(base.DataGridView, null);
		}
	}

	public KryptonDataGridViewButtonCell()
	{
		_buttonStyle = ButtonStyle.Standalone;
	}

	public override object Clone()
	{
		KryptonDataGridViewButtonCell kryptonDataGridViewButtonCell = base.Clone() as KryptonDataGridViewButtonCell;
		if (kryptonDataGridViewButtonCell != null)
		{
			kryptonDataGridViewButtonCell._styleSet = _styleSet;
			kryptonDataGridViewButtonCell._shortTextValue = _shortTextValue;
			kryptonDataGridViewButtonCell._buttonStyle = _buttonStyle;
		}
		return kryptonDataGridViewButtonCell;
	}

	protected override Rectangle GetContentBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
	{
		return _contentBounds;
	}

	protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
	{
		try
		{
			KryptonDataGridView kryptonDataGridView = (KryptonDataGridView)base.DataGridView;
			CreateViewAndPalettes(kryptonDataGridView);
			bool flag = rowIndex == base.DataGridView.CurrentCellAddress.Y && base.ColumnIndex == base.DataGridView.CurrentCellAddress.X;
			Point mouseEnteredCellAddressInternal = MouseEnteredCellAddressInternal;
			bool flag2 = rowIndex == mouseEnteredCellAddressInternal.Y && base.ColumnIndex == mouseEnteredCellAddressInternal.X && MouseInContentBoundsInternal;
			if (flag && (ButtonStateInternal & ButtonState.Pushed) == ButtonState.Pushed)
			{
				_viewButton.ElementState = PaletteState.Pressed;
			}
			else if (flag2)
			{
				_viewButton.ElementState = PaletteState.Tracking;
			}
			else
			{
				_viewButton.ElementState = PaletteState.Normal;
			}
			if (kryptonDataGridView.Columns[base.ColumnIndex] is KryptonDataGridViewButtonColumn { UseColumnTextForButtonValue: not false } kryptonDataGridViewButtonColumn && !kryptonDataGridView.Rows[rowIndex].IsNewRow)
			{
				_shortTextValue.ShortText = kryptonDataGridViewButtonColumn.Text;
			}
			else if (base.FormattedValue != null && !string.IsNullOrEmpty(base.FormattedValue.ToString()))
			{
				_shortTextValue.ShortText = base.FormattedValue.ToString();
			}
			else
			{
				_shortTextValue.ShortText = string.Empty;
			}
			using ViewLayoutContext viewLayoutContext = new ViewLayoutContext(kryptonDataGridView, kryptonDataGridView.Renderer);
			viewLayoutContext.DisplayRectangle = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
			Size preferredSize = _viewButton.GetPreferredSize(viewLayoutContext);
			preferredSize.Width += cellStyle.Padding.Horizontal + 1;
			preferredSize.Height += cellStyle.Padding.Vertical + 1;
			return preferredSize;
		}
		catch
		{
			return Size.Empty;
		}
	}

	protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
	{
		if (base.DataGridView != null && base.DataGridView is KryptonDataGridView)
		{
			KryptonDataGridView kryptonDataGridView = (KryptonDataGridView)base.DataGridView;
			if ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.ContentForeground)
			{
				return;
			}
			using RenderContext context = new RenderContext(kryptonDataGridView, graphics, cellBounds, kryptonDataGridView.Renderer);
			CreateViewAndPalettes(kryptonDataGridView);
			Rectangle rectangle = cellBounds;
			bool flag = rowIndex == base.DataGridView.CurrentCellAddress.Y && base.ColumnIndex == base.DataGridView.CurrentCellAddress.X;
			Point mouseEnteredCellAddressInternal = MouseEnteredCellAddressInternal;
			bool flag2 = rowIndex == mouseEnteredCellAddressInternal.Y && base.ColumnIndex == mouseEnteredCellAddressInternal.X && MouseInContentBoundsInternal;
			if (flag && (ButtonStateInternal & ButtonState.Pushed) == ButtonState.Pushed)
			{
				_viewButton.ElementState = PaletteState.Pressed;
			}
			else if (flag2)
			{
				_viewButton.ElementState = PaletteState.Tracking;
			}
			else
			{
				_viewButton.ElementState = PaletteState.Normal;
			}
			if (kryptonDataGridView.Columns[base.ColumnIndex] is KryptonDataGridViewButtonColumn { UseColumnTextForButtonValue: not false } kryptonDataGridViewButtonColumn && !kryptonDataGridView.Rows[rowIndex].IsNewRow)
			{
				_shortTextValue.ShortText = kryptonDataGridViewButtonColumn.Text;
			}
			else if (base.FormattedValue != null && !string.IsNullOrEmpty(base.FormattedValue.ToString()))
			{
				_shortTextValue.ShortText = base.FormattedValue.ToString();
			}
			else
			{
				_shortTextValue.ShortText = string.Empty;
			}
			cellBounds.Width--;
			cellBounds.Height--;
			if (kryptonDataGridView.RightToLeftInternal)
			{
				cellBounds.Offset(cellStyle.Padding.Right, cellStyle.Padding.Bottom);
			}
			else
			{
				cellBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
			}
			cellBounds.Width -= cellStyle.Padding.Horizontal;
			cellBounds.Height -= cellStyle.Padding.Vertical;
			using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(kryptonDataGridView, kryptonDataGridView.Renderer))
			{
				viewLayoutContext.DisplayRectangle = cellBounds;
				_viewButton.Layout(viewLayoutContext);
			}
			_viewButton.Render(context);
			_contentBounds = new Rectangle(cellBounds.X - rectangle.X, cellBounds.Y - rectangle.Y, cellBounds.Width, cellBounds.Height);
			return;
		}
		base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
	}

	private void CreateViewAndPalettes(KryptonDataGridView kDGV)
	{
		if (_viewButton == null)
		{
			_palette = new PaletteTripleToPalette(kDGV.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
			_shortTextValue = new ShortTextValue();
			_viewButton = new ViewDrawButton(_palette, _palette, _palette, _palette, _palette, _palette, _palette, new PaletteMetricRedirect(kDGV.Redirector), _shortTextValue, VisualOrientation.Top, useMnemonic: false);
		}
		_palette.SetStyles(_buttonStyle);
	}
}
