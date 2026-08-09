using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewLinkCell : DataGridViewLinkCell
{
	private static PropertyInfo _piLinkState;

	private bool _linkDefined;

	private bool _labelStyleDefined;

	private LabelStyle _labelStyle;

	private PaletteContentToPalette _palette;

	private LinkLabelBehaviorInherit _inheritBehavior;

	private PaletteContentInheritOverride _overrideVisited;

	private PaletteContentInheritOverride _overridePressed;

	private ShortTextValue _shortTextValue;

	private ViewDrawContent _viewLabel;

	private Rectangle _contentBounds;

	[Category("Behavior")]
	[DefaultValue(typeof(LinkBehavior), "AlwaysUnderline")]
	public new LinkBehavior LinkBehavior
	{
		get
		{
			return base.LinkBehavior;
		}
		set
		{
			if (value != base.LinkBehavior)
			{
				base.LinkBehavior = value;
				_linkDefined = true;
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(LabelStyle), "NormalControl")]
	public LabelStyle LabelStyle
	{
		get
		{
			return _labelStyle;
		}
		set
		{
			if (value != _labelStyle)
			{
				_labelStyle = value;
				_labelStyleDefined = true;
				base.DataGridView.InvalidateCell(this);
			}
		}
	}

	internal LinkBehavior LinkBehaviorInternal
	{
		set
		{
			if (!_linkDefined)
			{
				base.LinkBehavior = value;
			}
		}
	}

	internal LabelStyle LabelStyleInternal
	{
		set
		{
			if (!_labelStyleDefined)
			{
				_labelStyle = value;
			}
		}
	}

	private LinkState LinkStateInternal
	{
		get
		{
			if (_piLinkState == null)
			{
				_piLinkState = typeof(DataGridViewLinkCell).GetProperty("LinkState", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (LinkState)_piLinkState.GetValue(this, null);
		}
	}

	public KryptonDataGridViewLinkCell()
	{
		_labelStyle = LabelStyle.NormalControl;
		base.LinkBehavior = LinkBehavior.AlwaysUnderline;
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
			SetElementStateAndPalette();
			if (rowIndex >= 0 && base.FormattedValue != null && !string.IsNullOrEmpty(base.FormattedValue.ToString()))
			{
				_shortTextValue.ShortText = base.FormattedValue.ToString();
			}
			else if (kryptonDataGridView.Columns[base.ColumnIndex] is KryptonDataGridViewButtonColumn { UseColumnTextForButtonValue: not false } kryptonDataGridViewButtonColumn && !kryptonDataGridView.Rows[rowIndex].IsNewRow)
			{
				_shortTextValue.ShortText = kryptonDataGridViewButtonColumn.Text;
			}
			else
			{
				_shortTextValue.ShortText = string.Empty;
			}
			using ViewLayoutContext viewLayoutContext = new ViewLayoutContext(kryptonDataGridView, kryptonDataGridView.Renderer);
			viewLayoutContext.DisplayRectangle = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
			Size preferredSize = _viewLabel.GetPreferredSize(viewLayoutContext);
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
			Rectangle rectangle = cellBounds;
			CreateViewAndPalettes(kryptonDataGridView);
			SetElementStateAndPalette();
			if (formattedValue != null && !string.IsNullOrEmpty(formattedValue.ToString()))
			{
				_shortTextValue.ShortText = formattedValue.ToString();
			}
			else if (kryptonDataGridView.Columns[base.ColumnIndex] is KryptonDataGridViewButtonColumn { UseColumnTextForButtonValue: not false } kryptonDataGridViewButtonColumn && !kryptonDataGridView.Rows[rowIndex].IsNewRow)
			{
				_shortTextValue.ShortText = kryptonDataGridViewButtonColumn.Text;
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
				Size preferredSize = _viewLabel.GetPreferredSize(viewLayoutContext);
				switch (cellStyle.Alignment)
				{
				case DataGridViewContentAlignment.NotSet:
				case DataGridViewContentAlignment.TopCenter:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.BottomCenter:
					cellBounds.X += (cellBounds.Width - preferredSize.Width) / 2;
					break;
				case DataGridViewContentAlignment.TopRight:
				case DataGridViewContentAlignment.MiddleRight:
				case DataGridViewContentAlignment.BottomRight:
					cellBounds.X = cellBounds.Right - preferredSize.Width;
					break;
				}
				switch (cellStyle.Alignment)
				{
				case DataGridViewContentAlignment.NotSet:
				case DataGridViewContentAlignment.MiddleLeft:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.MiddleRight:
					cellBounds.Y += (cellBounds.Height - preferredSize.Height) / 2;
					break;
				case DataGridViewContentAlignment.BottomLeft:
				case DataGridViewContentAlignment.BottomCenter:
				case DataGridViewContentAlignment.BottomRight:
					cellBounds.Y = cellBounds.Bottom - preferredSize.Height;
					break;
				}
				cellBounds.Width = Math.Min(preferredSize.Width, cellBounds.Width);
				cellBounds.Height = Math.Min(preferredSize.Height, cellBounds.Height);
				viewLayoutContext.DisplayRectangle = cellBounds;
				_viewLabel.Layout(viewLayoutContext);
			}
			_viewLabel.Render(context);
			_contentBounds = new Rectangle(cellBounds.X - rectangle.X, cellBounds.Y - rectangle.Y, cellBounds.Width, cellBounds.Height);
			return;
		}
		base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
	}

	private void CreateViewAndPalettes(KryptonDataGridView kDGV)
	{
		if (_viewLabel == null)
		{
			_palette = new PaletteContentToPalette(kDGV.Redirector, PaletteContentStyle.LabelNormalControl);
			_inheritBehavior = new LinkLabelBehaviorInherit(_palette, KryptonLinkBehavior.AlwaysUnderline);
			_overrideVisited = new PaletteContentInheritOverride(_palette, _inheritBehavior, PaletteState.LinkNotVisitedOverride, apply: true);
			_overridePressed = new PaletteContentInheritOverride(_palette, _overrideVisited, PaletteState.LinkPressedOverride, apply: false);
			_shortTextValue = new ShortTextValue();
			_viewLabel = new ViewDrawContent(_overridePressed, _shortTextValue, VisualOrientation.Top);
		}
	}

	private void SetElementStateAndPalette()
	{
		LinkState linkStateInternal = LinkStateInternal;
		if (base.LinkVisited)
		{
			_overrideVisited.OverrideState = PaletteState.LinkVisitedOverride;
		}
		else
		{
			_overrideVisited.OverrideState = PaletteState.LinkNotVisitedOverride;
		}
		_overridePressed.Apply = (linkStateInternal & LinkState.Active) == LinkState.Active;
		if ((linkStateInternal & LinkState.Hover) == LinkState.Hover)
		{
			_viewLabel.ElementState = PaletteState.Tracking;
		}
		else
		{
			_viewLabel.ElementState = PaletteState.Normal;
		}
		switch (base.LinkBehavior)
		{
		default:
			_inheritBehavior.LinkBehavior = KryptonLinkBehavior.AlwaysUnderline;
			break;
		case LinkBehavior.HoverUnderline:
			_inheritBehavior.LinkBehavior = KryptonLinkBehavior.HoverUnderline;
			break;
		case LinkBehavior.NeverUnderline:
			_inheritBehavior.LinkBehavior = KryptonLinkBehavior.NeverUnderline;
			break;
		}
		_palette.ContentStyle = CommonHelper.ContentStyleFromLabelStyle(_labelStyle);
	}
}
