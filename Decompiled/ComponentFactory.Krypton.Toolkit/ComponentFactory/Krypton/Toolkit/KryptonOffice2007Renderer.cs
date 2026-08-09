using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonOffice2007Renderer : KryptonProfessionalRenderer
{
	private class GradientItemColors
	{
		public Color InsideTop1;

		public Color InsideTop2;

		public Color InsideBottom1;

		public Color InsideBottom2;

		public Color FillTop1;

		public Color FillTop2;

		public Color FillBottom1;

		public Color FillBottom2;

		public Color Border1;

		public Color Border2;

		public GradientItemColors()
		{
		}

		public GradientItemColors(Color insideTop1, Color insideTop2, Color insideBottom1, Color insideBottom2, Color fillTop1, Color fillTop2, Color fillBottom1, Color fillBottom2, Color border1, Color border2)
		{
			InsideTop1 = insideTop1;
			InsideTop2 = insideTop2;
			InsideBottom1 = insideBottom1;
			InsideBottom2 = insideBottom2;
			FillTop1 = fillTop1;
			FillTop2 = fillTop2;
			FillBottom1 = fillBottom1;
			FillBottom2 = fillBottom2;
			Border1 = border1;
			Border2 = border2;
		}
	}

	private class GradientItemColorsItem : GradientItemColors
	{
		public GradientItemColorsItem(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 1.17f, 1.11f, 0.99f);
			Border2 = CommonHelper.WhitenColor(border, 1.32f, 1.35f, 1.26f);
			FillTop1 = CommonHelper.WhitenColor(begin, 0.71f, 0.93f, 0.72f);
			FillTop2 = begin;
			FillBottom1 = end;
			FillBottom2 = CommonHelper.WhitenColor(end, 0.71f, 0.93f, 0.71f);
			begin = CommonHelper.WhitenColor(begin, 0.94f, 0.94f, 0.73f);
			end = CommonHelper.WhitenColor(end, 0.88f, 0.88f, 0.51f);
			InsideTop1 = CommonHelper.WhitenColor(begin, 0.71f, 0.93f, 0.9f);
			InsideTop2 = begin;
			InsideBottom1 = end;
			InsideBottom2 = CommonHelper.WhitenColor(end, 0.71f, 0.97f, 1.11f);
		}
	}

	private class GradientItemColorsTracking : GradientItemColors
	{
		public GradientItemColorsTracking(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 0.85f, 0.85f, 0.85f);
			Border2 = border;
			FillTop1 = CommonHelper.WhitenColor(begin, 0.71f, 0.93f, 0.72f);
			FillTop2 = begin;
			FillBottom1 = end;
			FillBottom2 = CommonHelper.WhitenColor(end, 0.71f, 0.93f, 0.71f);
			begin = CommonHelper.WhitenColor(begin, 0.94f, 0.94f, 0.73f);
			end = CommonHelper.WhitenColor(end, 0.88f, 0.88f, 0.51f);
			InsideTop1 = CommonHelper.WhitenColor(begin, 0.71f, 0.93f, 0.9f);
			InsideTop2 = begin;
			InsideBottom1 = end;
			InsideBottom2 = CommonHelper.WhitenColor(end, 0.71f, 0.97f, 1.11f);
		}
	}

	private class GradientItemColorsPressed : GradientItemColors
	{
		public GradientItemColorsPressed(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 0.85f, 0.85f, 0.85f);
			Border2 = border;
			FillTop1 = CommonHelper.WhitenColor(begin, 0.99f, 0.89f, 0.89f);
			FillTop2 = begin;
			FillBottom1 = end;
			FillBottom2 = CommonHelper.WhitenColor(end, 0.98f, 0.68f, 0.45f);
			begin = CommonHelper.WhitenColor(begin, 1.02f, 1f, 2.48f);
			end = CommonHelper.WhitenColor(end, 1.02f, 0.91f, 2.54f);
			InsideTop1 = CommonHelper.WhitenColor(begin, 1.06f, 0.97f, 0.4f);
			InsideTop2 = begin;
			InsideBottom1 = end;
			InsideBottom2 = CommonHelper.WhitenColor(end, 0.97f, 0.9f, 1.4f);
		}
	}

	private class GradientItemColorsChecked : GradientItemColors
	{
		public GradientItemColorsChecked(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 0.85f, 0.85f, 0.85f);
			Border2 = border;
			FillTop1 = CommonHelper.WhitenColor(begin, 0.99f, 0.84f, 0.59f);
			FillTop2 = begin;
			FillBottom1 = end;
			FillBottom2 = CommonHelper.WhitenColor(end, 0.99f, 0.67f, 0.31f);
			begin = CommonHelper.WhitenColor(begin, 1.01f, 0.92f, 1.07f);
			end = CommonHelper.WhitenColor(end, 1.01f, 0.84f, 0.66f);
			InsideTop1 = CommonHelper.WhitenColor(begin, 1f, 1.01f, 0.9f);
			InsideTop2 = begin;
			InsideBottom1 = end;
			InsideBottom2 = CommonHelper.WhitenColor(end, 0.97f, 0.91f, 1.65f);
		}
	}

	private class GradientItemColorsCheckedTracking : GradientItemColors
	{
		public GradientItemColorsCheckedTracking(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 0.85f, 0.85f, 0.85f);
			Border2 = border;
			FillTop1 = CommonHelper.WhitenColor(begin, 0.99f, 0.88f, 0.89f);
			FillTop2 = begin;
			FillBottom1 = end;
			FillBottom2 = CommonHelper.WhitenColor(end, 0.99f, 0.67f, 0.31f);
			begin = CommonHelper.WhitenColor(begin, 1.01f, 0.8f, 0.94f);
			end = CommonHelper.WhitenColor(end, 1.01f, 0.8f, 0.59f);
			InsideTop1 = CommonHelper.WhitenColor(begin, 1f, 1.01f, 0.91f);
			InsideTop2 = begin;
			InsideBottom1 = end;
			InsideBottom2 = CommonHelper.WhitenColor(end, 0.97f, 0.91f, 1.54f);
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

	private static readonly float _contextCheckTickThickness;

	private static readonly float _cutContextMenu;

	private static readonly float _cutMenuItemBack;

	private static readonly float _cutToolItemMenu;

	private static readonly Blend _statusStripBlend;

	private static readonly Color _disabled;

	private static GradientItemColors _disabledItem;

	private GradientItemColorsItem _gradientItem;

	private GradientItemColorsTracking _gradientTracking;

	private GradientItemColorsPressed _gradientPressed;

	private GradientItemColorsChecked _gradientChecked;

	private GradientItemColorsCheckedTracking _gradientCheckedTracking;

	static KryptonOffice2007Renderer()
	{
		_gripOffset = 1;
		_gripSquare = 2;
		_gripSize = 3;
		_gripMove = 4;
		_gripLines = 3;
		_marginInset = 2;
		_checkInset = 1;
		_separatorInset = 31;
		_contextCheckTickThickness = 1.6f;
		_cutContextMenu = 0f;
		_cutMenuItemBack = 1.2f;
		_cutToolItemMenu = 1f;
		_disabled = Color.FromArgb(167, 167, 167);
		_disabledItem = new GradientItemColors(Color.FromArgb(250, 250, 250), Color.FromArgb(243, 243, 243), Color.FromArgb(236, 236, 236), Color.FromArgb(230, 230, 230), Color.FromArgb(243, 243, 243), Color.FromArgb(224, 224, 224), Color.FromArgb(200, 200, 200), Color.FromArgb(210, 210, 210), Color.FromArgb(212, 212, 212), Color.FromArgb(195, 195, 195));
		_statusStripBlend = new Blend();
		_statusStripBlend.Positions = new float[6] { 0f, 0.25f, 0.25f, 0.57f, 0.86f, 1f };
		_statusStripBlend.Factors = new float[6] { 0.1f, 0.6f, 1f, 0.4f, 0f, 0.95f };
	}

	public KryptonOffice2007Renderer(KryptonColorTable kct)
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
		Color color = (e.Item.Enabled ? base.KCT.ToolStripText : _disabled);
		Color color2 = (e.Item.Enabled ? CommonHelper.WhitenColor(base.KCT.ToolStripText, 0.7f, 0.7f, 0.7f) : _disabled);
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
			using (SolidBrush brush = new SolidBrush(base.KCT.CheckBackground))
			{
				e.Graphics.FillPath(brush, path);
			}
			using (Pen pen = new Pen(CommonHelper.WhitenColor(base.KCT.CheckBackground, 1.05f, 1.52f, 2.75f)))
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
			switch (checkState)
			{
			case CheckState.Checked:
			{
				using GraphicsPath path3 = CreateTickPath(imageRectangle);
				using Pen pen2 = new Pen(CommonHelper.WhitenColor(base.KCT.CheckBackground, 3.86f, 3.02f, 1.07f), _contextCheckTickThickness);
				e.Graphics.DrawPath(pen2, path3);
				break;
			}
			case CheckState.Indeterminate:
			{
				using GraphicsPath path2 = CreateIndeterminatePath(imageRectangle);
				using SolidBrush brush2 = new SolidBrush(CommonHelper.WhitenColor(base.KCT.CheckBackground, 3.86f, 3.02f, 1.07f));
				e.Graphics.FillPath(brush2, path2);
				break;
			}
			}
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
			else if (e.ToolStrip is MenuStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuStripText;
			}
			else if (e.ToolStrip is StatusStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.StatusStripText;
			}
			else if (e.ToolStrip is ContextMenuStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip is ToolStripDropDownMenu && !e.Item.Pressed && !e.Item.Selected)
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
						DrawGradientContextMenuItem(e.Graphics, e.Item, _gradientItem);
					}
					return;
				}
				Point pt = e.ToolStrip.PointToClient(Control.MousePosition);
				if (!e.Item.Bounds.Contains(pt))
				{
					if (e.ToolStrip is MenuStrip)
					{
						DrawGradientToolItem(e.Graphics, e.Item, _disabledItem);
					}
					else
					{
						DrawGradientContextMenuItem(e.Graphics, e.Item, _disabledItem);
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
			using (Pen lightPen = new Pen(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.02f, 1.02f, 1.02f)))
			{
				using Pen darkPen = new Pen(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.26f, 1.26f, 1.26f));
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
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			if (e.ToolStrip.Font != base.KCT.MenuStripFont)
			{
				e.ToolStrip.Font = base.KCT.MenuStripFont;
			}
			using GraphicsPath path = CreateBorderPath(e.AffectedBounds, _cutContextMenu);
			using GraphicsPath path2 = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu);
			using (new Clipping(e.Graphics, path2))
			{
				using SolidBrush brush = new SolidBrush(base.KCT.ToolStripDropDownBackground);
				e.Graphics.FillPath(brush, path);
				return;
			}
		}
		if (e.ToolStrip is StatusStrip)
		{
			if (e.ToolStrip.Font != base.KCT.StatusStripFont)
			{
				e.ToolStrip.Font = base.KCT.StatusStripFont;
			}
			RectangleF rect = new RectangleF(0f, 1.5f, e.ToolStrip.Width, e.ToolStrip.Height - 2);
			Form form = e.ToolStrip.FindForm();
			if (form != null && form is KryptonForm && e.ToolStrip.Visible && e.ToolStrip.Dock == DockStyle.Bottom && e.ToolStrip.Bottom == form.ClientSize.Height && e.ToolStrip.RenderMode == ToolStripRenderMode.ManagerRenderMode && ToolStripManager.Renderer is KryptonOffice2007Renderer)
			{
				KryptonForm kryptonForm = (KryptonForm)form;
				if (kryptonForm.ApplyCustomChrome)
				{
					rect.Height += kryptonForm.RealWindowBorders.Bottom;
				}
			}
			if (rect.Width > 0f && rect.Height > 0f)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, base.KCT.StatusStripGradientBegin, base.KCT.StatusStripGradientEnd, 90f))
				{
					linearGradientBrush.Blend = _statusStripBlend;
					e.Graphics.FillRectangle(linearGradientBrush, rect);
					return;
				}
			}
			return;
		}
		if (e.ToolStrip is MenuStrip)
		{
			if (e.ToolStrip.Font != base.KCT.MenuStripFont)
			{
				e.ToolStrip.Font = base.KCT.MenuStripFont;
			}
		}
		else if (e.ToolStrip.Font != base.KCT.ToolStripFont)
		{
			e.ToolStrip.Font = base.KCT.ToolStripFont;
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
			using Pen pen = new Pen(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.02f, 1.02f, 1.02f));
			using Pen pen2 = new Pen(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.26f, 1.26f, 1.26f));
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
			using Pen pen2 = new Pen(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.02f, 1.02f, 1.02f));
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
		if (e.ToolStrip is StatusStrip)
		{
			using (Pen pen3 = new Pen(CommonHelper.WhitenColor(base.KCT.StatusStripGradientEnd, 1.6f, 1.6f, 1.6f)))
			{
				using Pen pen4 = new Pen(ControlPaint.LightLight(base.KCT.StatusStripGradientBegin));
				e.Graphics.DrawLine(pen3, 0, 0, e.ToolStrip.Width, 0);
				e.Graphics.DrawLine(pen4, 0, 1, e.ToolStrip.Width, 1);
				return;
			}
		}
		base.OnRenderToolStripBorder(e);
	}

	private void UpdateCache()
	{
		if (_gradientItem == null)
		{
			_gradientItem = new GradientItemColorsItem(base.KCT.CheckBackground, base.KCT.ButtonSelectedGradientBegin, base.KCT.ButtonSelectedGradientEnd);
			_gradientTracking = new GradientItemColorsTracking(base.KCT.ButtonSelectedBorder, base.KCT.ButtonSelectedGradientBegin, base.KCT.ButtonSelectedGradientEnd);
			_gradientPressed = new GradientItemColorsPressed(base.KCT.ButtonPressedBorder, base.KCT.ButtonPressedGradientBegin, base.KCT.ButtonPressedGradientEnd);
			_gradientChecked = new GradientItemColorsChecked(base.KCT.ButtonPressedBorder, base.KCT.ButtonCheckedGradientBegin, base.KCT.ButtonCheckedGradientEnd);
			_gradientCheckedTracking = new GradientItemColorsCheckedTracking(base.KCT.ButtonSelectedBorder, base.KCT.ButtonPressedGradientBegin, base.KCT.ButtonCheckedGradientEnd);
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
				DrawGradientToolItem(g, button, _disabledItem);
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
				DrawGradientToolItem(g, item, _disabledItem);
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
		Rectangle backRect = rectangle;
		int num;
		if (dropDownButtonBounds.X > 0)
		{
			backRect.Width = dropDownButtonBounds.Left;
			dropDownButtonBounds.X--;
			dropDownButtonBounds.Width++;
			num = dropDownButtonBounds.X;
		}
		else
		{
			backRect.Width -= dropDownButtonBounds.Width - 2;
			backRect.X = dropDownButtonBounds.Right - 1;
			dropDownButtonBounds.Width++;
			num = dropDownButtonBounds.Right - 1;
		}
		using (CreateBorderPath(rectangle, _cutMenuItemBack))
		{
			DrawGradientBack(g, backRect, colorsButton);
			DrawGradientBack(g, dropDownButtonBounds, colorsDrop);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(rectangle.X + num, rectangle.Top, 1, rectangle.Height + 1), colorsSplit.Border1, colorsSplit.Border2, 90f))
			{
				linearGradientBrush.SetSigmaBellShape(0.5f);
				using Pen pen = new Pen(linearGradientBrush);
				g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num, rectangle.Bottom - 1);
			}
			DrawGradientBorder(g, rectangle, colorsButton);
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
				using (SolidBrush brush = new SolidBrush(CommonHelper.WhitenColor(base.KCT.ToolStripDropDownBackground, 1.02f, 1.02f, 1.02f)))
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
				DrawGradientToolSplitItem(g, splitButton, _gradientPressed, _gradientTracking, _gradientItem);
			}
			else if (splitButton.Pressed && !splitButton.ButtonPressed)
			{
				DrawContextMenuHeader(g, splitButton);
			}
			else
			{
				DrawGradientToolSplitItem(g, splitButton, _gradientTracking, _gradientTracking, _gradientItem);
			}
		}
		else
		{
			Point pt = toolstrip.PointToClient(Control.MousePosition);
			if (!splitButton.Bounds.Contains(pt))
			{
				DrawGradientToolItem(g, splitButton, _disabledItem);
			}
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
			DrawGradientBorder(g, backRect, colors);
		}
	}

	private static void DrawGradientBack(Graphics g, Rectangle backRect, GradientItemColors colors)
	{
		backRect.Inflate(-1, -1);
		int num = backRect.Height / 2;
		Rectangle rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
		Rectangle rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
		Rectangle rect = rectangle;
		Rectangle rect2 = rectangle2;
		rect.Inflate(1, 1);
		rect2.Inflate(1, 1);
		using (LinearGradientBrush brush = new LinearGradientBrush(rect, colors.InsideTop1, colors.InsideTop2, 90f))
		{
			using LinearGradientBrush brush2 = new LinearGradientBrush(rect2, colors.InsideBottom1, colors.InsideBottom2, 90f);
			g.FillRectangle(brush, rectangle);
			g.FillRectangle(brush2, rectangle2);
		}
		num = backRect.Height / 2;
		rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
		rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
		rect = rectangle;
		rect2 = rectangle2;
		rect.Inflate(1, 1);
		rect2.Inflate(1, 1);
		using LinearGradientBrush brush3 = new LinearGradientBrush(rect, colors.FillTop1, colors.FillTop2, 90f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(rect2, colors.FillBottom1, colors.FillBottom2, 90f);
		backRect.Inflate(-1, -1);
		num = backRect.Height / 2;
		rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
		rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
		g.FillRectangle(brush3, rectangle);
		g.FillRectangle(brush4, rectangle2);
	}

	private static void DrawGradientBorder(Graphics g, Rectangle backRect, GradientItemColors colors)
	{
		using (new AntiAlias(g))
		{
			Rectangle rect = backRect;
			rect.Inflate(1, 1);
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colors.Border1, colors.Border2, 90f);
			linearGradientBrush.SetSigmaBellShape(0.5f);
			using Pen pen = new Pen(linearGradientBrush);
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

	private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
	{
		rect.Inflate(-1, -1);
		return CreateBorderPath(rect, cut);
	}

	private GraphicsPath CreateInsideBorderPath(Rectangle rect, Rectangle exclude, float cut)
	{
		rect.Inflate(-1, -1);
		return CreateBorderPath(rect, exclude, cut);
	}

	private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
	{
		rect.Width++;
		rect.Height++;
		return CreateBorderPath(rect, cut);
	}

	private GraphicsPath CreateClipBorderPath(Rectangle rect, Rectangle exclude, float cut)
	{
		rect.Width++;
		rect.Height++;
		return CreateBorderPath(rect, exclude, cut);
	}

	private GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
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

	private GraphicsPath CreateTickPath(Rectangle rect)
	{
		int num = rect.X + rect.Width / 2;
		int num2 = rect.Y + rect.Height / 2;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(num - 4, num2, num - 2, num2 + 4);
		graphicsPath.AddLine(num - 2, num2 + 4, num + 3, num2 - 5);
		return graphicsPath;
	}

	private GraphicsPath CreateIndeterminatePath(Rectangle rect)
	{
		int num = rect.X + rect.Width / 2;
		int num2 = rect.Y + rect.Height / 2;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(num - 3, num2, num, num2 - 3);
		graphicsPath.AddLine(num, num2 - 3, num + 3, num2);
		graphicsPath.AddLine(num + 3, num2, num, num2 + 3);
		graphicsPath.AddLine(num, num2 + 3, num - 3, num2);
		return graphicsPath;
	}
}
