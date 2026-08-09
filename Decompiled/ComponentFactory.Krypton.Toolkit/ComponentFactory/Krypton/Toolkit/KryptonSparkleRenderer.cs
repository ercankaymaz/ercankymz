using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSparkleRenderer : KryptonProfessionalRenderer
{
	private class LinearItemColors
	{
		public Color Fill1;

		public Color Fill2;

		public Color Border;

		public LinearItemColors()
		{
		}

		public LinearItemColors(Color fill1, Color fill2, Color border)
		{
			Fill1 = fill1;
			Fill2 = fill2;
			Border = border;
		}
	}

	private class GradientItemColors
	{
		public Color Border;

		public Color Begin;

		public Color End;

		public GradientItemColors()
		{
		}

		public GradientItemColors(Color border, Color begin, Color end)
		{
			Border = border;
			Begin = begin;
			End = end;
		}
	}

	private static readonly int _gripOffset;

	private static readonly int _gripSquare;

	private static readonly int _gripSize;

	private static readonly int _gripMove;

	private static readonly int _gripLines;

	private static readonly int _marginInset;

	private static readonly int _checkInset;

	private static readonly int _separatorInset;

	private static readonly float _cutContextMenu;

	private static readonly float _cutMenuItemBack;

	private static readonly float _cutToolItemMenu;

	private static readonly Blend _statusStripBlend;

	private static readonly Color _disabled;

	private static readonly LinearItemColors _disabledLinearItem;

	private static readonly GradientItemColors _disabledGradientItem;

	private static readonly Image _contextMenuChecked;

	private static readonly Image _contextMenuIndeterminate;

	private LinearItemColors _linearItem;

	private GradientItemColors _gradientItem;

	private GradientItemColors _gradientTracking;

	private GradientItemColors _gradientPressed;

	private GradientItemColors _gradientChecked;

	private GradientItemColors _gradientCheckedTracking;

	static KryptonSparkleRenderer()
	{
		_gripOffset = 1;
		_gripSquare = 2;
		_gripSize = 3;
		_gripMove = 4;
		_gripLines = 3;
		_marginInset = 2;
		_checkInset = 1;
		_separatorInset = 24;
		_cutContextMenu = 0f;
		_cutMenuItemBack = 1.2f;
		_cutToolItemMenu = 1f;
		_disabled = Color.FromArgb(167, 167, 167);
		_disabledLinearItem = new LinearItemColors(Color.FromArgb(128, 220, 220, 220), Color.FromArgb(128, 190, 190, 190), Color.FromArgb(128, 172, 172, 172));
		_disabledGradientItem = new GradientItemColors(Color.FromArgb(212, 212, 212), Color.FromArgb(235, 235, 235), Color.FromArgb(235, 235, 235));
		_contextMenuChecked = Resources.SparkleGrayChecked;
		_contextMenuIndeterminate = Resources.SparkleGrayIndeterminate;
		_statusStripBlend = new Blend();
		_statusStripBlend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_statusStripBlend.Positions = new float[4] { 0f, 0.33f, 0.33f, 1f };
	}

	public KryptonSparkleRenderer(KryptonColorTable kct)
		: base(kct)
	{
	}

	protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
	{
		if (e.ArrowRectangle.Width <= 0 || e.ArrowRectangle.Height <= 0)
		{
			return;
		}
		using GraphicsPath graphicsPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction);
		RectangleF bounds = graphicsPath.GetBounds();
		bounds.Inflate(1f, 1f);
		Color color = _disabled;
		Color color2 = _disabled;
		if (e.Item.Enabled)
		{
			if (e.Item.Owner is ContextMenuStrip || e.Item.Owner is ToolStripDropDownMenu || e.Item.OwnerItem is ToolStripOverflowButton)
			{
				color = ((!(e.Item.Owner is ContextMenuStrip) && !(e.Item.Owner is ToolStripDropDownMenu) && (!(e.Item.OwnerItem is ToolStripOverflowButton) || (!(e.Item is ToolStripSplitButton) && !(e.Item is ToolStripDropDownButton)) || (e.Item.Selected && !e.Item.Pressed))) ? base.KCT.ToolStripText : base.KCT.MenuItemText);
				color2 = color;
			}
			else if (e.Item.Owner != null || e.Item.Owner is StatusStrip)
			{
				color = (((!(e.Item is ToolStripSplitButton) && !(e.Item is ToolStripDropDownButton)) || !e.Item.Pressed) ? base.KCT.ToolStripText : base.KCT.MenuItemText);
				color2 = color;
			}
		}
		float angle = 0f;
		switch (e.Direction)
		{
		case ArrowDirection.Right:
			angle = 0f;
			break;
		case ArrowDirection.Left:
			angle = 180f;
			break;
		case ArrowDirection.Down:
			angle = 90f;
			break;
		case ArrowDirection.Up:
			angle = 270f;
			break;
		}
		using LinearGradientBrush brush = new LinearGradientBrush(bounds, color, color2, angle);
		e.Graphics.FillPath(brush, graphicsPath);
	}

	protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)e.Item;
		if (toolStripButton.Selected || toolStripButton.Pressed || toolStripButton.Checked)
		{
			RenderToolButtonBackground(e.Graphics, toolStripButton, e.ToolStrip);
		}
	}

	protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
	{
		if (e.Item.Selected || e.Item.Pressed)
		{
			RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip);
		}
	}

	protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
	{
		Rectangle imageRectangle = e.ImageRectangle;
		imageRectangle.Inflate(1, 1);
		if (imageRectangle.Top > _checkInset)
		{
			int num = imageRectangle.Top - _checkInset;
			imageRectangle.Y -= num;
			imageRectangle.Height += num;
		}
		if (imageRectangle.Height <= e.Item.Bounds.Height - _checkInset * 2)
		{
			int num2 = e.Item.Bounds.Height - _checkInset * 2 - imageRectangle.Height;
			imageRectangle.Height += num2;
		}
		using (new AntiAlias(e.Graphics))
		{
			using GraphicsPath path = CreateBorderPath(imageRectangle, _cutMenuItemBack);
			Color color = base.KCT.CheckBackground;
			Color color2 = CommonHelper.BlackenColor(base.KCT.CheckBackground, 0.89f, 0.88f, 0.98f);
			if (!e.Item.Enabled)
			{
				color = CommonHelper.ColorToBlackAndWhite(color);
				color2 = CommonHelper.ColorToBlackAndWhite(color2);
			}
			using (SolidBrush brush = new SolidBrush(color))
			{
				e.Graphics.FillPath(brush, path);
			}
			using (Pen pen = new Pen(color2))
			{
				e.Graphics.DrawPath(pen, path);
			}
			if (e.Item.Image != null)
			{
				return;
			}
			CheckState checkState = CheckState.Unchecked;
			if (e.Item is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.Item;
				checkState = toolStripMenuItem.CheckState;
			}
			Image image = null;
			switch (checkState)
			{
			case CheckState.Checked:
				image = _contextMenuChecked;
				break;
			case CheckState.Indeterminate:
				image = _contextMenuIndeterminate;
				break;
			}
			if (image == null)
			{
				return;
			}
			int num3 = e.ImageRectangle.Width - image.Width;
			int num4 = e.ImageRectangle.Height - image.Height;
			Rectangle rectangle = new Rectangle(e.ImageRectangle.X + num3, e.ImageRectangle.Y + num4, image.Width, image.Height);
			if (e.Item.Enabled)
			{
				e.Graphics.DrawImage(image, e.ImageRectangle);
				return;
			}
			using ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(CommonHelper.MatrixDisabled);
			e.Graphics.DrawImage(image, e.ImageRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
		}
	}

	protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
	{
		if (e.ToolStrip != null || e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			if (!e.Item.Enabled)
			{
				e.TextColor = _disabled;
			}
			else if (e.ToolStrip is MenuStrip && !e.Item.Pressed)
			{
				e.TextColor = base.KCT.MenuStripText;
			}
			else if (e.ToolStrip is MenuStrip && (e.Item.Pressed || e.Item.Selected))
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip is StatusStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.StatusStripText;
			}
			else if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if ((e.ToolStrip is ToolStripDropDownMenu || e.ToolStrip is ToolStripOverflow) && !e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip != null && (e.Item is ToolStripSplitButton || e.Item is ToolStripDropDownButton) && e.Item.Pressed)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else
			{
				e.TextColor = base.KCT.ToolStripText;
			}
			if (!(e.ToolStrip is StatusStrip) || Environment.OSVersion.Version.Major >= 6)
			{
				using (new GraphicsTextHint(e.Graphics, TextRenderingHint.ClearTypeGridFit))
				{
					base.OnRenderItemText(e);
					return;
				}
			}
			base.OnRenderItemText(e);
		}
		else
		{
			base.OnRenderItemText(e);
		}
	}

	protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
	{
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			if (e.Image == null)
			{
				return;
			}
			if (!e.Item.Enabled)
			{
				using (ImageAttributes imageAttributes = new ImageAttributes())
				{
					imageAttributes.SetColorMatrix(CommonHelper.MatrixDisabled);
					e.Graphics.DrawImage(e.Image, e.ImageRectangle, 0, 0, e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, imageAttributes);
					return;
				}
			}
			e.Graphics.DrawImage(e.Image, e.ImageRectangle);
		}
		else
		{
			base.OnRenderItemImage(e);
		}
	}

	protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
	{
		if (e.ToolStrip is MenuStrip || e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			if (e.Item.Pressed && e.ToolStrip is MenuStrip)
			{
				DrawContextMenuHeader(e.Graphics, e.Item);
			}
			else
			{
				if (!e.Item.Selected)
				{
					return;
				}
				if (e.Item.Enabled)
				{
					UpdateCache();
					if (e.ToolStrip is MenuStrip)
					{
						DrawGradientToolItem(e.Graphics, e.Item, _gradientTracking);
					}
					else
					{
						DrawLinearContextMenuItem(e.Graphics, e.Item, _linearItem);
					}
				}
				else
				{
					Point pt = e.ToolStrip.PointToClient(Control.MousePosition);
					if (!e.Item.Bounds.Contains(pt))
					{
						DrawLinearContextMenuItem(e.Graphics, e.Item, _disabledLinearItem);
					}
				}
			}
		}
		else
		{
			base.OnRenderMenuItemBackground(e);
		}
	}

	protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
	{
		if (e.Item.Selected || e.Item.Pressed)
		{
			ToolStripSplitButton toolStripSplitButton = (ToolStripSplitButton)e.Item;
			RenderToolSplitButtonBackground(e.Graphics, toolStripSplitButton, e.ToolStrip);
			Rectangle dropDownButtonBounds = toolStripSplitButton.DropDownButtonBounds;
			OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, toolStripSplitButton, dropDownButtonBounds, SystemColors.ControlText, ArrowDirection.Down));
		}
		else
		{
			base.OnRenderSplitButtonBackground(e);
		}
	}

	protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
	{
		using SolidBrush darkBrush = new SolidBrush(base.KCT.GripDark);
		using SolidBrush lightBrush = new SolidBrush(base.KCT.GripLight);
		bool flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
		int num = e.AffectedBounds.Bottom - _gripSize * 2 + 1;
		for (int num2 = _gripLines; num2 >= 1; num2--)
		{
			int num3 = (flag ? (e.AffectedBounds.Left + 1) : (e.AffectedBounds.Right - _gripSize * 2 + 1));
			for (int i = 0; i < num2; i++)
			{
				DrawGripGlyph(e.Graphics, num3, num, darkBrush, lightBrush);
				num3 -= (flag ? (-_gripMove) : _gripMove);
			}
			num -= _gripMove;
		}
	}

	protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
	{
		base.OnRenderToolStripContentPanelBackground(e);
		if (e.ToolStripContentPanel.Width > 0 && e.ToolStripContentPanel.Height > 0)
		{
			using (LinearGradientBrush brush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, base.KCT.ToolStripContentPanelGradientEnd, base.KCT.ToolStripContentPanelGradientBegin, 90f))
			{
				e.Graphics.FillRectangle(brush, e.ToolStripContentPanel.ClientRectangle);
			}
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			using (Pen lightPen = new Pen(base.KCT.ImageMarginGradientEnd))
			{
				using Pen darkPen = new Pen(base.KCT.ImageMarginGradientMiddle);
				DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, _separatorInset, e.ToolStrip.RightToLeft == RightToLeft.Yes);
				return;
			}
		}
		if (e.ToolStrip is StatusStrip)
		{
			using (Pen lightPen2 = new Pen(base.KCT.SeparatorLight))
			{
				using Pen darkPen2 = new Pen(base.KCT.SeparatorDark);
				DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen2, darkPen2, 0, rtl: false);
				return;
			}
		}
		base.OnRenderSeparator(e);
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip.Font != base.KCT.MenuStripFont)
		{
			e.ToolStrip.Font = base.KCT.MenuStripFont;
		}
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			using (GraphicsPath path = CreateBorderPath(e.AffectedBounds, _cutContextMenu))
			{
				using GraphicsPath path2 = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu);
				using (new Clipping(e.Graphics, path2))
				{
					using SolidBrush brush = new SolidBrush(base.KCT.ToolStripDropDownBackground);
					e.Graphics.FillPath(brush, path);
					return;
				}
			}
		}
		if (e.ToolStrip is StatusStrip)
		{
			RectangleF rect = new RectangleF(0f, 0f, e.ToolStrip.Width, e.ToolStrip.Height);
			Form form = e.ToolStrip.FindForm();
			if (form != null && form is KryptonForm && e.ToolStrip.Visible && e.ToolStrip.Dock == DockStyle.Bottom && e.ToolStrip.Bottom == form.ClientSize.Height && e.ToolStrip.RenderMode == ToolStripRenderMode.ManagerRenderMode && ToolStripManager.Renderer is KryptonSparkleRenderer)
			{
				KryptonForm kryptonForm = (KryptonForm)form;
				if (kryptonForm.ApplyCustomChrome)
				{
					Padding realWindowBorders = kryptonForm.RealWindowBorders;
					rect.Height += realWindowBorders.Bottom;
					rect.Width += realWindowBorders.Horizontal;
					rect.X -= realWindowBorders.Left;
				}
			}
			if (!(rect.Width > 0f) || !(rect.Height > 0f))
			{
				return;
			}
			using (SolidBrush brush2 = new SolidBrush(base.KCT.MenuStripGradientBegin))
			{
				e.Graphics.FillRectangle(brush2, rect);
			}
			using GraphicsPath graphicsPath = new GraphicsPath();
			RectangleF rectangleF = new RectangleF(rect.X + 2f, rect.Y, rect.Width - 4f, rect.Height - 2f);
			graphicsPath.AddLine(rectangleF.Right - 1f, rectangleF.Top, rectangleF.Right - 1f, rectangleF.Bottom - 7f);
			graphicsPath.AddArc(rectangleF.Right - 7f, rectangleF.Bottom - 7f, 6f, 6f, 0f, 90f);
			graphicsPath.AddArc(rectangleF.Left, rectangleF.Bottom - 7f, 6f, 6f, 90f, 90f);
			graphicsPath.AddLine(rectangleF.Left, rectangleF.Bottom - 7f, rectangleF.Left, rectangleF.Top);
			graphicsPath.CloseFigure();
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle((int)rect.X - 1, (int)rect.Y - 1, (int)rect.Width + 2, (int)rect.Height + 1), base.KCT.StatusStripGradientBegin, base.KCT.StatusStripGradientEnd, 90f);
			linearGradientBrush.Blend = _statusStripBlend;
			using (new AntiAlias(e.Graphics))
			{
				e.Graphics.FillPath(linearGradientBrush, graphicsPath);
				return;
			}
		}
		base.OnRenderToolStripBackground(e);
	}

	protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			Rectangle affectedBounds = e.AffectedBounds;
			bool flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
			affectedBounds.Y += _marginInset;
			affectedBounds.Height -= _marginInset * 2;
			if (!flag)
			{
				affectedBounds.X += _marginInset;
			}
			else
			{
				affectedBounds.X += _marginInset / 2;
			}
			using (SolidBrush brush = new SolidBrush(base.KCT.ImageMarginGradientBegin))
			{
				e.Graphics.FillRectangle(brush, affectedBounds);
			}
			using Pen pen = new Pen(base.KCT.ImageMarginGradientEnd);
			using Pen pen2 = new Pen(base.KCT.ImageMarginGradientMiddle);
			if (!flag)
			{
				e.Graphics.DrawLine(pen, affectedBounds.Right, affectedBounds.Top, affectedBounds.Right, affectedBounds.Bottom);
				e.Graphics.DrawLine(pen2, affectedBounds.Right - 1, affectedBounds.Top, affectedBounds.Right - 1, affectedBounds.Bottom);
			}
			else
			{
				e.Graphics.DrawLine(pen, affectedBounds.Left - 1, affectedBounds.Top, affectedBounds.Left - 1, affectedBounds.Bottom);
				e.Graphics.DrawLine(pen2, affectedBounds.Left, affectedBounds.Top, affectedBounds.Left, affectedBounds.Bottom);
			}
			return;
		}
		base.OnRenderImageMargin(e);
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			if (!e.ConnectedArea.IsEmpty)
			{
				using SolidBrush brush = new SolidBrush(base.KCT.ToolStripDropDownBackground);
				e.Graphics.FillRectangle(brush, e.ConnectedArea);
			}
			using GraphicsPath path = CreateBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu);
			using GraphicsPath path2 = CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu);
			using GraphicsPath path3 = CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu);
			using Pen pen = new Pen(base.KCT.MenuBorder);
			using Pen pen2 = new Pen(base.KCT.ToolStripDropDownBackground);
			using (new Clipping(e.Graphics, path3))
			{
				using (new AntiAlias(e.Graphics))
				{
					e.Graphics.DrawPath(pen2, path2);
					e.Graphics.DrawPath(pen, path);
				}
				e.Graphics.DrawLine(pen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1);
				return;
			}
		}
		if (!(e.ToolStrip is StatusStrip))
		{
			base.OnRenderToolStripBorder(e);
		}
	}

	private void UpdateCache()
	{
		if (_gradientItem == null)
		{
			_linearItem = new LinearItemColors(base.KCT.ButtonSelectedGradientMiddle, CommonHelper.BlackenColor(base.KCT.ButtonSelectedGradientMiddle, 0.91f, 0.91f, 0.91f), CommonHelper.BlackenColor(base.KCT.ButtonSelectedGradientMiddle, 0.75f, 0.75f, 0.75f));
			_gradientItem = new GradientItemColors(base.KCT.CheckBackground, base.KCT.ButtonSelectedGradientBegin, base.KCT.ButtonSelectedGradientBegin);
			_gradientTracking = new GradientItemColors(base.KCT.ButtonSelectedBorder, base.KCT.ButtonSelectedGradientBegin, base.KCT.ButtonSelectedGradientEnd);
			_gradientPressed = new GradientItemColors(base.KCT.ButtonPressedBorder, base.KCT.ButtonPressedGradientBegin, base.KCT.ButtonPressedGradientEnd);
			_gradientChecked = new GradientItemColors(base.KCT.ButtonPressedBorder, base.KCT.ButtonCheckedGradientBegin, base.KCT.ButtonCheckedGradientEnd);
			_gradientCheckedTracking = new GradientItemColors(base.KCT.ButtonSelectedBorder, base.KCT.ButtonPressedGradientBegin, base.KCT.ButtonCheckedGradientEnd);
		}
	}

	private void RenderToolButtonBackground(Graphics g, ToolStripButton button, ToolStrip toolstrip)
	{
		if (button.Enabled)
		{
			UpdateCache();
			if (button.Checked)
			{
				if (button.Pressed)
				{
					DrawGradientToolItem(g, button, _gradientPressed);
				}
				else if (button.Selected)
				{
					DrawGradientToolItem(g, button, _gradientCheckedTracking);
				}
				else
				{
					DrawGradientToolItem(g, button, _gradientChecked);
				}
			}
			else if (button.Pressed)
			{
				DrawGradientToolItem(g, button, _gradientPressed);
			}
			else if (button.Selected)
			{
				DrawGradientToolItem(g, button, _gradientTracking);
			}
		}
		else if (button.Selected)
		{
			Point pt = toolstrip.PointToClient(Control.MousePosition);
			if (!button.Bounds.Contains(pt))
			{
				DrawGradientToolItem(g, button, _disabledGradientItem);
			}
		}
	}

	private void RenderToolDropButtonBackground(Graphics g, ToolStripItem item, ToolStrip toolstrip)
	{
		if (!item.Selected && !item.Pressed)
		{
			return;
		}
		if (item.Enabled)
		{
			if (item.Pressed)
			{
				DrawContextMenuHeader(g, item);
				return;
			}
			UpdateCache();
			DrawGradientToolItem(g, item, _gradientTracking);
		}
		else
		{
			Point pt = toolstrip.PointToClient(Control.MousePosition);
			if (!item.Bounds.Contains(pt))
			{
				DrawGradientToolItem(g, item, _disabledGradientItem);
			}
		}
	}

	private void DrawGradientToolSplitItem(Graphics g, ToolStripSplitButton splitButton, GradientItemColors colorsButton, GradientItemColors colorsDrop, GradientItemColors colorsSplit)
	{
		Rectangle rectangle = new Rectangle(Point.Empty, splitButton.Bounds.Size);
		Rectangle dropDownButtonBounds = splitButton.DropDownButtonBounds;
		if (rectangle.Width <= 0 || dropDownButtonBounds.Width <= 0 || rectangle.Height <= 0 || dropDownButtonBounds.Height <= 0)
		{
			return;
		}
		Rectangle rectangle2 = rectangle;
		int num = ((dropDownButtonBounds.X <= 0) ? (dropDownButtonBounds.Right - 1) : dropDownButtonBounds.X);
		using (CreateBorderPath(rectangle, _cutMenuItemBack))
		{
			DrawGradientBack(g, rectangle, colorsButton);
			using (Pen pen = new Pen(colorsSplit.Border))
			{
				g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num, rectangle.Bottom - 1);
			}
			DrawSolidBorder(g, rectangle, colorsButton);
		}
	}

	private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
	{
		Rectangle rect = new Rectangle(Point.Empty, item.Bounds.Size);
		using GraphicsPath path = CreateBorderPath(rect, _cutToolItemMenu);
		using (CreateInsideBorderPath(rect, _cutToolItemMenu))
		{
			using GraphicsPath path2 = CreateClipBorderPath(rect, _cutToolItemMenu);
			using (new Clipping(g, path2))
			{
				using (SolidBrush brush = new SolidBrush(base.KCT.ToolStripDropDownBackground))
				{
					g.FillPath(brush, path);
				}
				using Pen pen = new Pen(base.KCT.MenuBorder);
				g.DrawPath(pen, path);
			}
		}
	}

	private void DrawGradientToolItem(Graphics g, ToolStripItem item, GradientItemColors colors)
	{
		DrawGradientItem(g, new Rectangle(Point.Empty, item.Bounds.Size), colors);
	}

	private void RenderToolSplitButtonBackground(Graphics g, ToolStripSplitButton splitButton, ToolStrip toolstrip)
	{
		if (!splitButton.Selected && !splitButton.Pressed)
		{
			return;
		}
		if (splitButton.Enabled)
		{
			UpdateCache();
			if (!splitButton.Pressed && splitButton.ButtonPressed)
			{
				DrawGradientToolSplitItem(g, splitButton, _gradientPressed, _gradientPressed, _gradientPressed);
			}
			else if (splitButton.Pressed && !splitButton.ButtonPressed)
			{
				DrawContextMenuHeader(g, splitButton);
			}
			else
			{
				DrawGradientToolSplitItem(g, splitButton, _gradientTracking, _gradientTracking, _gradientTracking);
			}
		}
		else
		{
			Point pt = toolstrip.PointToClient(Control.MousePosition);
			if (!splitButton.Bounds.Contains(pt))
			{
				DrawGradientToolItem(g, splitButton, _disabledGradientItem);
			}
		}
	}

	private void DrawLinearContextMenuItem(Graphics g, ToolStripItem item, LinearItemColors colors)
	{
		Rectangle backRect = new Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height);
		DrawLinearGradientItem(g, backRect, colors);
	}

	private static void DrawLinearGradientItem(Graphics g, Rectangle backRect, LinearItemColors colors)
	{
		if (backRect.Width > 0 && backRect.Height > 0)
		{
			DrawLinearGradientBack(g, backRect, colors);
			DrawLinearGradientBorder(g, backRect, colors);
		}
	}

	private static void DrawLinearGradientBack(Graphics g, Rectangle backRect, LinearItemColors colors)
	{
		backRect.Inflate(-1, -1);
		using LinearGradientBrush brush = new LinearGradientBrush(backRect, colors.Fill1, colors.Fill2, 90f);
		g.FillRectangle(brush, backRect);
	}

	private static void DrawLinearGradientBorder(Graphics g, Rectangle backRect, LinearItemColors colors)
	{
		using (new AntiAlias(g))
		{
			using Pen pen = new Pen(colors.Border);
			using GraphicsPath path = CreateBorderPath(backRect, _cutMenuItemBack);
			g.DrawPath(pen, path);
		}
	}

	private void DrawGradientContextMenuItem(Graphics g, ToolStripItem item, GradientItemColors colors)
	{
		Rectangle backRect = new Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height);
		DrawGradientItem(g, backRect, colors);
	}

	private static void DrawGradientItem(Graphics g, Rectangle backRect, GradientItemColors colors)
	{
		if (backRect.Width > 0 && backRect.Height > 0)
		{
			DrawGradientBack(g, backRect, colors);
			DrawSolidBorder(g, backRect, colors);
		}
	}

	private static void DrawGradientBack(Graphics g, Rectangle backRect, GradientItemColors colors)
	{
		backRect.X++;
		backRect.Width--;
		using RenderContext context = new RenderContext(null, g, backRect, null);
		using GraphicsPath path = CreateBorderPath(backRect, _cutMenuItemBack);
		backRect.Width--;
		backRect.Height--;
		RenderGlassHelpers.DrawBackGlassBottom(context, backRect, colors.Begin, colors.End, VisualOrientation.Top, path, null);
	}

	private static void DrawSolidBorder(Graphics g, Rectangle backRect, GradientItemColors colors)
	{
		using (new AntiAlias(g))
		{
			Rectangle rectangle = backRect;
			rectangle.Inflate(1, 1);
			using Pen pen = new Pen(colors.Border);
			using GraphicsPath path = CreateBorderPath(backRect, _cutMenuItemBack);
			g.DrawPath(pen, path);
		}
	}

	private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
	{
		g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare);
		g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare);
	}

	private void DrawSeparator(Graphics g, bool vertical, Rectangle rect, Pen lightPen, Pen darkPen, int horizontalInset, bool rtl)
	{
		if (vertical)
		{
			int num = rect.Width / 2;
			int y = rect.Y;
			int bottom = rect.Bottom;
			g.DrawLine(darkPen, num, y, num, bottom);
			g.DrawLine(lightPen, num + 1, y, num + 1, bottom);
		}
		else
		{
			int num2 = rect.Height / 2;
			int x = rect.X + ((!rtl) ? horizontalInset : 0);
			int x2 = rect.Right - (rtl ? horizontalInset : 0);
			g.DrawLine(darkPen, x, num2, x2, num2);
			g.DrawLine(lightPen, x, num2 + 1, x2, num2 + 1);
		}
	}

	private static GraphicsPath CreateBorderPath(Rectangle rect, Rectangle exclude, float cut)
	{
		if (exclude.IsEmpty)
		{
			return CreateBorderPath(rect, cut);
		}
		rect.Width--;
		rect.Height--;
		List<PointF> list = new List<PointF>();
		float x = rect.X;
		float num = rect.Y;
		float x2 = rect.Right;
		float y = rect.Bottom;
		float num2 = (float)rect.X + cut;
		float num3 = (float)rect.Right - cut;
		float y2 = (float)rect.Y + cut;
		float y3 = (float)rect.Bottom - cut;
		float num4 = ((cut == 0f) ? 1f : cut);
		if (rect.Y >= exclude.Top && rect.Y <= exclude.Bottom)
		{
			float num5 = (float)(exclude.X - 1) - cut;
			float num6 = (float)exclude.Right + cut;
			if (num2 <= num5)
			{
				list.Add(new PointF(num2, num));
				list.Add(new PointF(num5, num));
				list.Add(new PointF(num5 + cut, num - num4));
			}
			else
			{
				num5 = exclude.X - 1;
				list.Add(new PointF(num5, num));
				list.Add(new PointF(num5, num - num4));
			}
			if (num3 > num6)
			{
				list.Add(new PointF(num6 - cut, num - num4));
				list.Add(new PointF(num6, num));
				list.Add(new PointF(num3, num));
			}
			else
			{
				num6 = exclude.Right;
				list.Add(new PointF(num6, num - num4));
				list.Add(new PointF(num6, num));
			}
		}
		else
		{
			list.Add(new PointF(num2, num));
			list.Add(new PointF(num3, num));
		}
		list.Add(new PointF(x2, y2));
		list.Add(new PointF(x2, y3));
		list.Add(new PointF(num3, y));
		list.Add(new PointF(num2, y));
		list.Add(new PointF(x, y3));
		list.Add(new PointF(x, y2));
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int i = 1; i < list.Count; i++)
		{
			graphicsPath.AddLine(list[i - 1], list[i]);
		}
		graphicsPath.AddLine(list[list.Count - 1], list[0]);
		return graphicsPath;
	}

	private static GraphicsPath CreateBorderPath(Rectangle rect, float cut)
	{
		rect.Width--;
		rect.Height--;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine((float)rect.Left + cut, rect.Top, (float)rect.Right - cut, rect.Top);
		graphicsPath.AddLine((float)rect.Right - cut, rect.Top, rect.Right, (float)rect.Top + cut);
		graphicsPath.AddLine(rect.Right, (float)rect.Top + cut, rect.Right, (float)rect.Bottom - cut);
		graphicsPath.AddLine(rect.Right, (float)rect.Bottom - cut, (float)rect.Right - cut, rect.Bottom);
		graphicsPath.AddLine((float)rect.Right - cut, rect.Bottom, (float)rect.Left + cut, rect.Bottom);
		graphicsPath.AddLine((float)rect.Left + cut, rect.Bottom, rect.Left, (float)rect.Bottom - cut);
		graphicsPath.AddLine(rect.Left, (float)rect.Bottom - cut, rect.Left, (float)rect.Top + cut);
		graphicsPath.AddLine(rect.Left, (float)rect.Top + cut, (float)rect.Left + cut, rect.Top);
		return graphicsPath;
	}

	private static GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
	{
		rect.Inflate(-1, -1);
		return CreateBorderPath(rect, cut);
	}

	private static GraphicsPath CreateInsideBorderPath(Rectangle rect, Rectangle exclude, float cut)
	{
		rect.Inflate(-1, -1);
		return CreateBorderPath(rect, exclude, cut);
	}

	private static GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
	{
		rect.Width++;
		rect.Height++;
		return CreateBorderPath(rect, cut);
	}

	private static GraphicsPath CreateClipBorderPath(Rectangle rect, Rectangle exclude, float cut)
	{
		rect.Width++;
		rect.Height++;
		return CreateBorderPath(rect, exclude, cut);
	}

	private static GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
	{
		int num;
		int num2;
		if (direction == ArrowDirection.Left || direction == ArrowDirection.Right)
		{
			num = rect.Right - (rect.Width - 4) / 2;
			num2 = rect.Y + rect.Height / 2;
		}
		else
		{
			num = rect.X + rect.Width / 2;
			num2 = rect.Bottom - (rect.Height - 3) / 2;
			if (item is ToolStripDropDownButton && item.RightToLeft == RightToLeft.Yes)
			{
				num++;
			}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (direction)
		{
		case ArrowDirection.Right:
			graphicsPath.AddLine(num, num2, num - 4, num2 - 4);
			graphicsPath.AddLine(num - 4, num2 - 4, num - 4, num2 + 4);
			graphicsPath.AddLine(num - 4, num2 + 4, num, num2);
			break;
		case ArrowDirection.Left:
			graphicsPath.AddLine(num - 4, num2, num, num2 - 4);
			graphicsPath.AddLine(num, num2 - 4, num, num2 + 4);
			graphicsPath.AddLine(num, num2 + 4, num - 4, num2);
			break;
		case ArrowDirection.Down:
			graphicsPath.AddLine((float)num + 3f, (float)num2 - 3f, (float)num - 2f, (float)num2 - 3f);
			graphicsPath.AddLine((float)num - 2f, (float)num2 - 3f, num, num2);
			graphicsPath.AddLine(num, num2, (float)num + 3f, (float)num2 - 3f);
			break;
		case ArrowDirection.Up:
			graphicsPath.AddLine((float)num + 3f, num2, (float)num - 3f, num2);
			graphicsPath.AddLine((float)num - 3f, num2, num, (float)num2 - 4f);
			graphicsPath.AddLine(num, (float)num2 - 4f, (float)num + 3f, num2);
			break;
		}
		return graphicsPath;
	}

	private static GraphicsPath CreateTickPath(Rectangle rect)
	{
		int num = rect.X + rect.Width / 2;
		int num2 = rect.Y + rect.Height / 2;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(num - 5, num2 - 1, num - 2, num2 + 4);
		graphicsPath.AddLine(num - 2, num2 + 4, num + 3, num2 - 5);
		return graphicsPath;
	}

	private static GraphicsPath CreateIndeterminatePath(Rectangle rect)
	{
		float x = (float)rect.X + ((float)rect.Width - 6f) / 2f;
		float y = (float)rect.Y + ((float)rect.Height - 6f) / 2f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(x, y, 6f, 6f);
		return graphicsPath;
	}
}
