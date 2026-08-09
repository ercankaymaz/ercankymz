using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewCheckBoxCell : DataGridViewCheckBoxCell
{
	private static PropertyInfo _piButtonState;

	private static PropertyInfo _piMouseEnteredCellAddress;

	private static FieldInfo _fiMouseInContentBounds;

	private Rectangle _contentBounds;

	private ButtonState ButtonStateInternal
	{
		get
		{
			if (_piButtonState == null)
			{
				_piButtonState = typeof(DataGridViewCheckBoxCell).GetProperty("ButtonState", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
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
				_fiMouseInContentBounds = typeof(DataGridViewCheckBoxCell).GetField("mouseInContentBounds", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
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

	public KryptonDataGridViewCheckBoxCell()
		: this(threeState: false)
	{
	}

	public KryptonDataGridViewCheckBoxCell(bool threeState)
		: base(threeState)
	{
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
			bool flag = rowIndex == base.DataGridView.CurrentCellAddress.Y && base.ColumnIndex == base.DataGridView.CurrentCellAddress.X;
			Point mouseEnteredCellAddressInternal = MouseEnteredCellAddressInternal;
			bool tracking = rowIndex == mouseEnteredCellAddressInternal.Y && base.ColumnIndex == mouseEnteredCellAddressInternal.X && MouseInContentBoundsInternal;
			bool pressed = flag && (ButtonStateInternal & ButtonState.Pushed) == ButtonState.Pushed;
			using ViewLayoutContext context = new ViewLayoutContext(kryptonDataGridView, kryptonDataGridView.Renderer);
			Size checkBoxPreferredSize = kryptonDataGridView.Renderer.RenderGlyph.GetCheckBoxPreferredSize(context, kryptonDataGridView.Redirector, kryptonDataGridView.Enabled, CheckState.Unchecked, tracking, pressed);
			checkBoxPreferredSize.Width += cellStyle.Padding.Horizontal + 1;
			checkBoxPreferredSize.Height += cellStyle.Padding.Vertical + 1;
			return checkBoxPreferredSize;
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
			CheckState checkState = CheckState.Unchecked;
			if (formattedValue != null && formattedValue is CheckState)
			{
				checkState = (CheckState)formattedValue;
			}
			else if (formattedValue != null && formattedValue is bool)
			{
				checkState = (((bool)formattedValue) ? CheckState.Checked : CheckState.Unchecked);
			}
			bool flag = rowIndex == base.DataGridView.CurrentCellAddress.Y && base.ColumnIndex == base.DataGridView.CurrentCellAddress.X;
			Point mouseEnteredCellAddressInternal = MouseEnteredCellAddressInternal;
			bool tracking = rowIndex == mouseEnteredCellAddressInternal.Y && base.ColumnIndex == mouseEnteredCellAddressInternal.X && MouseInContentBoundsInternal;
			bool pressed = flag && (ButtonStateInternal & ButtonState.Pushed) == ButtonState.Pushed;
			using RenderContext renderContext = new RenderContext(kryptonDataGridView, graphics, cellBounds, kryptonDataGridView.Renderer);
			Size size = Size.Empty;
			using (ViewLayoutContext context = new ViewLayoutContext(kryptonDataGridView, kryptonDataGridView.Renderer))
			{
				size = renderContext.Renderer.RenderGlyph.GetCheckBoxPreferredSize(context, kryptonDataGridView.Redirector, kryptonDataGridView.Enabled, checkState, tracking, pressed);
			}
			Rectangle rectangle = cellBounds;
			cellBounds.Width--;
			cellBounds.Height--;
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.NotSet:
			case DataGridViewContentAlignment.TopCenter:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.BottomCenter:
				cellBounds.X += (cellBounds.Width - size.Width) / 2;
				break;
			case DataGridViewContentAlignment.TopRight:
			case DataGridViewContentAlignment.MiddleRight:
			case DataGridViewContentAlignment.BottomRight:
				cellBounds.X = cellBounds.Right - size.Width;
				break;
			}
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.NotSet:
			case DataGridViewContentAlignment.MiddleLeft:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.MiddleRight:
				cellBounds.Y += (cellBounds.Height - size.Height) / 2;
				break;
			case DataGridViewContentAlignment.BottomLeft:
			case DataGridViewContentAlignment.BottomCenter:
			case DataGridViewContentAlignment.BottomRight:
				cellBounds.Y = cellBounds.Bottom - size.Height;
				break;
			}
			cellBounds.Width = size.Width;
			cellBounds.Height = size.Height;
			_contentBounds = new Rectangle(cellBounds.X - rectangle.X, cellBounds.Y - rectangle.Y, cellBounds.Width, cellBounds.Height);
			renderContext.Renderer.RenderGlyph.DrawCheckBox(renderContext, cellBounds, kryptonDataGridView.Redirector, kryptonDataGridView.Enabled, checkState, tracking, pressed);
			return;
		}
		base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
	}
}
