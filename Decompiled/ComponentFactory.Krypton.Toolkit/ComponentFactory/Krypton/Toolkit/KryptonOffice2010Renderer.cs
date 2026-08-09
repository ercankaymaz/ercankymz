using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonOffice2010Renderer : KryptonProfessionalRenderer
{
	private abstract class GradientItemColors
	{
		public Color Border1;

		public Color Border2;

		public Color Back1;

		public Color Back2;

		public GradientItemColors()
		{
		}

		public GradientItemColors(Color border1, Color border2, Color back1, Color back2)
		{
			Border1 = border1;
			Border2 = border2;
			Back1 = back1;
			Back2 = back2;
		}

		public virtual void DrawItem(Graphics g, Rectangle rect)
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				DrawBack(g, rect);
				DrawBorder(g, rect);
			}
		}

		public virtual void DrawBorder(Graphics g, Rectangle rect)
		{
			using (new AntiAlias(g))
			{
				Rectangle rect2 = rect;
				rect2.Inflate(1, 1);
				using LinearGradientBrush brush = new LinearGradientBrush(rect2, Border1, Border2, 90f);
				using Pen pen = new Pen(brush);
				using GraphicsPath path = CreateBorderPath(rect, _cutItemMenu);
				g.DrawPath(pen, path);
			}
		}

		public abstract void DrawBack(Graphics g, Rectangle rect);
	}

	private class GradientItemColorsSplit : GradientItemColors
	{
		public GradientItemColorsSplit(Color border, Color begin, Color end)
		{
			Border1 = border;
			Border2 = CommonHelper.WhitenColor(border, 0.979f, 0.943f, 1.2f);
		}

		public override void DrawBack(Graphics g, Rectangle rect)
		{
		}
	}

	private class GradientItemColorsTracking : GradientItemColors
	{
		public Color Back1B;

		public Color Back2B;

		public GradientItemColorsTracking(Color border, Color begin, Color end)
		{
			Border1 = border;
			Border2 = CommonHelper.WhitenColor(border, 0.979f, 0.943f, 1.2f);
			Back1 = begin;
			Back1B = CommonHelper.WhitenColor(begin, 1f, 0.975f, 0.93f);
			Back2 = end;
			Back2B = CommonHelper.WhitenColor(end, 1f, 0.953f, 0.758f);
		}

		public override void DrawBack(Graphics g, Rectangle rect)
		{
			Rectangle rect2 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
			Rectangle rect3 = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 3, rect.Height - 3);
			Rectangle rect4 = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Back1B, Back1, 90f);
			using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect3, Back2B, Back2, 90f);
			linearGradientBrush.SetSigmaBellShape(0.5f);
			linearGradientBrush2.SetSigmaBellShape(0.5f);
			g.FillRectangle(linearGradientBrush, rect2);
			using GraphicsPath path = CreateBorderPath(rect4, _cutInnerItemMenu);
			using GraphicsPath path2 = CreateBorderPath(rect3, _cutInnerItemMenu);
			using (Pen pen = new Pen(linearGradientBrush2))
			{
				g.DrawPath(pen, path);
			}
			g.FillPath(linearGradientBrush2, path);
			using (new Clipping(g, path2))
			{
				using GraphicsPath graphicsPath = new GraphicsPath();
				RectangleF rect5 = new RectangleF(-(rect.Width / 2), rect.Bottom - 9, rect.Width * 2, 18f);
				PointF centerPoint = new PointF(rect5.Left + rect5.Width / 2f, rect5.Top + rect5.Height / 2f);
				graphicsPath.AddEllipse(rect5);
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.CenterPoint = centerPoint;
				pathGradientBrush.CenterColor = Color.White;
				pathGradientBrush.SurroundColors = new Color[1] { Color.Transparent };
				g.FillPath(pathGradientBrush, graphicsPath);
			}
		}
	}

	private class GradientItemColorsDisabled : GradientItemColorsTracking
	{
		public GradientItemColorsDisabled(Color border, Color begin, Color end)
			: base(border, begin, end)
		{
			Border1 = CommonHelper.ColorToBlackAndWhite(Border1);
			Border2 = CommonHelper.ColorToBlackAndWhite(Border2);
			Back1 = CommonHelper.ColorToBlackAndWhite(Back1);
			Back1B = CommonHelper.ColorToBlackAndWhite(Back1B);
			Back2 = CommonHelper.ColorToBlackAndWhite(Back2);
			Back2B = CommonHelper.ColorToBlackAndWhite(Back2B);
		}
	}

	private class GradientItemColorsPressed : GradientItemColors
	{
		public GradientItemColorsPressed(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 1.21f, 1.68f, 2.02f);
			Border2 = CommonHelper.WhitenColor(border, 1.21f, 1.25f, 1.22f);
			Back1 = begin;
		}

		public override void DrawBack(Graphics g, Rectangle rect)
		{
			Rectangle rect2 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 1);
			Rectangle rect3 = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 3);
			using (new AntiAlias(g))
			{
				using GraphicsPath path = CreateBorderPath(rect, _cutItemMenu);
				using GraphicsPath path2 = CreateBorderPath(rect2, _cutItemMenu);
				using GraphicsPath path3 = CreateBorderPath(rect3, _cutItemMenu);
				using SolidBrush brush = new SolidBrush(CommonHelper.MergeColors(Border1, 0.4f, Back1, 0.6f));
				using SolidBrush brush2 = new SolidBrush(CommonHelper.MergeColors(Border1, 0.2f, Back1, 0.8f));
				using SolidBrush brush3 = new SolidBrush(Back1);
				g.FillPath(brush, path);
				g.FillPath(brush2, path2);
				g.FillPath(brush3, path3);
			}
		}
	}

	private class GradientItemColorsChecked : GradientItemColors
	{
		public GradientItemColorsChecked(Color border, Color begin, Color end)
		{
			Border1 = CommonHelper.WhitenColor(border, 1.21f, 1.44f, 1.81f);
			Border2 = CommonHelper.WhitenColor(border, 1.21f, 1.21f, 1.12f);
			Back1 = begin;
			Back2 = CommonHelper.WhitenColor(begin, 1f, 0.943f, 0.914f);
		}

		public override void DrawBack(Graphics g, Rectangle rect)
		{
			Rectangle rect2 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
			Rectangle rectangle = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 3, rect.Height - 3);
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Back2, Back1, 90f);
			linearGradientBrush.SetSigmaBellShape(0.5f);
			g.FillRectangle(linearGradientBrush, rect2);
			using (CreateBorderPath(rect2, _cutInnerItemMenu))
			{
				using GraphicsPath graphicsPath = new GraphicsPath();
				RectangleF rect3 = new RectangleF(rect.Left, rect.Bottom - 8, rect.Width, 8f);
				PointF centerPoint = new PointF(rect3.Left + rect3.Width / 2f, rect3.Top + rect3.Height / 2f);
				graphicsPath.AddEllipse(rect3);
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.CenterPoint = centerPoint;
				pathGradientBrush.CenterColor = Color.FromArgb(96, Color.White);
				pathGradientBrush.SurroundColors = new Color[1] { Color.Transparent };
				g.FillPath(pathGradientBrush, graphicsPath);
			}
		}
	}

	private class GradientItemColorsCheckedTracking : GradientItemColorsTracking
	{
		public GradientItemColorsCheckedTracking(Color border, Color begin, Color end)
			: base(border, begin, end)
		{
			Border1 = CommonHelper.WhitenColor(border, 1.21f, 1.44f, 1.81f);
			Border2 = CommonHelper.WhitenColor(border, 1.21f, 1.21f, 1.12f);
			Back1 = CommonHelper.WhitenColor(begin, 1f, 0.953f, 0.822f);
			Back1B = CommonHelper.WhitenColor(begin, 1f, 0.923f, 0.669f);
			Back2 = CommonHelper.WhitenColor(end, 1f, 0.964f, 1.06f);
			Back2B = CommonHelper.WhitenColor(end, 1f, 0.911f, 0.685f);
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

	private static readonly float _cutItemMenu;

	private static readonly float _cutInnerItemMenu;

	private static readonly float _cutHeaderMenu;

	private static readonly Blend _stripBlend;

	private static readonly Blend _separatorLightBlend;

	private static readonly Blend _separatorDarkBlend;

	private static readonly Color _disabled;

	private static GradientItemColors _disabledItem;

	private GradientItemColorsSplit _gradientSplit;

	private GradientItemColorsTracking _gradientTracking;

	private GradientItemColorsPressed _gradientPressed;

	private GradientItemColorsChecked _gradientChecked;

	private GradientItemColorsCheckedTracking _gradientCheckedTracking;

	static KryptonOffice2010Renderer()
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
		_cutItemMenu = 1.7f;
		_cutInnerItemMenu = 1f;
		_cutHeaderMenu = 1f;
		_disabled = Color.FromArgb(167, 167, 167);
		_disabledItem = new GradientItemColorsDisabled(Color.FromArgb(236, 199, 87), Color.FromArgb(251, 242, 215), Color.FromArgb(247, 224, 137));
		_stripBlend = new Blend();
		_stripBlend.Positions = new float[4] { 0f, 0.33f, 0.66f, 1f };
		_stripBlend.Factors = new float[4] { 0f, 0.5f, 0.8f, 1f };
		_separatorDarkBlend = new Blend();
		_separatorDarkBlend.Positions = new float[3] { 0f, 0.5f, 1f };
		_separatorDarkBlend.Factors = new float[3] { 0.2f, 1f, 0.2f };
		_separatorLightBlend = new Blend();
		_separatorLightBlend.Positions = new float[3] { 0f, 0.5f, 1f };
		_separatorLightBlend.Factors = new float[3] { 0.1f, 0.6f, 0.1f };
	}

	public KryptonOffice2010Renderer(KryptonColorTable kct)
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
		Color color;
		Color color2;
		if (!e.Item.Enabled)
		{
			color = _disabled;
			color2 = _disabled;
		}
		else
		{
			color = ((!e.Item.Pressed && !e.Item.Selected && !(e.Item is ToolStripMenuItem)) ? base.KCT.ToolStripText : base.KCT.MenuItemText);
			color2 = CommonHelper.WhitenColor(color, 0.7f, 0.7f, 0.7f);
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
			using GraphicsPath path = CreateBorderPath(imageRectangle, _cutItemMenu);
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
			else if (e.ToolStrip is MenuStrip)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip is StatusStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.StatusStripText;
			}
			else if (e.ToolStrip is StatusStrip && !e.Item.Pressed && e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip != null && !e.Item.Pressed && e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip is ContextMenuStrip && !e.Item.Pressed && !e.Item.Selected)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.ToolStrip is ToolStripDropDownMenu)
			{
				e.TextColor = base.KCT.MenuItemText;
			}
			else if (e.Item is ToolStripButton && ((ToolStripButton)e.Item).Checked)
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
						DrawGradientContextMenuItem(e.Graphics, e.Item, _gradientTracking);
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

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		if (e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu)
		{
			DrawContextMenuSeparator(e.Graphics, e.Vertical, e.Item.Bounds, _separatorInset, e.ToolStrip.RightToLeft == RightToLeft.Yes);
		}
		else
		{
			DrawToolStripSeparator(e.Graphics, e.Vertical, e.Item.Bounds, base.KCT.SeparatorLight, base.KCT.SeparatorDark, 0, rtl: false);
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
		int num = e.AffectedBounds.Bottom - _gripSize * 2;
		for (int num2 = _gripLines; num2 >= 1; num2--)
		{
			int num3 = (flag ? (e.AffectedBounds.Left + 1) : (e.AffectedBounds.Right - _gripSize * 2));
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
			if (rect.Width > 0f && rect.Height > 0f)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, base.KCT.StatusStripGradientBegin, base.KCT.StatusStripGradientEnd, 90f))
				{
					linearGradientBrush.Blend = _stripBlend;
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
			base.OnRenderToolStripBackground(e);
			return;
		}
		if (e.ToolStrip.Font != base.KCT.ToolStripFont)
		{
			e.ToolStrip.Font = base.KCT.ToolStripFont;
		}
		RectangleF rect2 = new RectangleF(0f, 0f, e.ToolStrip.Width, e.ToolStrip.Height);
		if (!(rect2.Width > 0f) || !(rect2.Height > 0f))
		{
			return;
		}
		if (e.ToolStrip.Orientation == Orientation.Horizontal)
		{
			using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect2, base.KCT.ToolStripGradientBegin, base.KCT.ToolStripGradientEnd, 90f))
			{
				linearGradientBrush2.Blend = _stripBlend;
				e.Graphics.FillRectangle(linearGradientBrush2, rect2);
			}
			using Pen pen = new Pen(base.KCT.ToolStripBorder);
			using Pen pen2 = new Pen(base.KCT.ToolStripGradientBegin);
			e.Graphics.DrawLine(pen2, 0, 2, 0, e.ToolStrip.Height - 2);
			e.Graphics.DrawLine(pen2, e.ToolStrip.Width - 2, 0, e.ToolStrip.Width - 2, e.ToolStrip.Height - 2);
			e.Graphics.DrawLine(pen, e.ToolStrip.Width - 1, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
			return;
		}
		using (LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rect2, base.KCT.ToolStripGradientBegin, base.KCT.ToolStripGradientEnd, 0f))
		{
			linearGradientBrush3.Blend = _stripBlend;
			e.Graphics.FillRectangle(linearGradientBrush3, rect2);
		}
		using Pen pen3 = new Pen(base.KCT.ToolStripBorder);
		using Pen pen4 = new Pen(base.KCT.ToolStripGradientBegin);
		e.Graphics.DrawLine(pen4, 1, 0, e.ToolStrip.Width - 2, 0);
		e.Graphics.DrawLine(pen4, 1, e.ToolStrip.Height - 2, e.ToolStrip.Width - 2, e.ToolStrip.Height - 2);
		e.Graphics.DrawLine(pen3, e.ToolStrip.Width - 1, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
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
		if (e.ToolStrip is StatusStrip)
		{
			using (Pen pen3 = new Pen(base.KCT.ToolStripBorder))
			{
				using Pen pen4 = new Pen(base.KCT.SeparatorLight);
				e.Graphics.DrawLine(pen3, 0, 0, e.ToolStrip.Width - 1, 0);
				e.Graphics.DrawLine(pen4, 0, 1, e.ToolStrip.Width - 1, 1);
				return;
			}
		}
		base.OnRenderToolStripBorder(e);
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
			using Pen pen = new Pen(Color.FromArgb(80, base.KCT.MenuBorder));
			if (!flag)
			{
				e.Graphics.DrawLine(pen, affectedBounds.Right, affectedBounds.Top, affectedBounds.Right, affectedBounds.Bottom);
			}
			else
			{
				e.Graphics.DrawLine(pen, affectedBounds.Left - 1, affectedBounds.Top, affectedBounds.Left - 1, affectedBounds.Bottom);
			}
			return;
		}
		base.OnRenderImageMargin(e);
	}

	private void UpdateCache()
	{
		if (_gradientSplit == null)
		{
			_gradientSplit = new GradientItemColorsSplit(base.KCT.ButtonSelectedBorder, base.KCT.ButtonSelectedGradientBegin, base.KCT.ButtonSelectedGradientEnd);
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
		Rectangle rect = rectangle;
		int num;
		if (dropDownButtonBounds.X > 0)
		{
			rect.Width = dropDownButtonBounds.Left;
			dropDownButtonBounds.X--;
			dropDownButtonBounds.Width++;
			num = dropDownButtonBounds.X;
		}
		else
		{
			rect.Width -= dropDownButtonBounds.Width - 2;
			rect.X = dropDownButtonBounds.Right - 1;
			dropDownButtonBounds.Width++;
			num = dropDownButtonBounds.Right - 1;
		}
		using (CreateBorderPath(rectangle, _cutItemMenu))
		{
			colorsButton.DrawBack(g, rect);
			colorsDrop.DrawBack(g, dropDownButtonBounds);
			using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(rectangle.X + num, rectangle.Top, 1, rectangle.Height + 1), colorsSplit.Border1, colorsSplit.Border2, 90f))
			{
				using Pen pen = new Pen(brush);
				g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num, rectangle.Bottom - 1);
			}
			colorsButton.DrawBorder(g, rectangle);
		}
	}

	private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
	{
		Rectangle rect = new Rectangle(Point.Empty, item.Bounds.Size);
		using GraphicsPath path = CreateBorderPath(rect, _cutHeaderMenu);
		using (CreateInsideBorderPath(rect, _cutHeaderMenu))
		{
			using GraphicsPath path2 = CreateClipBorderPath(rect, _cutHeaderMenu);
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
		colors.DrawItem(g, new Rectangle(Point.Empty, item.Bounds.Size));
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
				DrawGradientToolSplitItem(g, splitButton, _gradientPressed, _gradientTracking, _gradientSplit);
			}
			else if (splitButton.Pressed && !splitButton.ButtonPressed)
			{
				DrawContextMenuHeader(g, splitButton);
			}
			else
			{
				DrawGradientToolSplitItem(g, splitButton, _gradientTracking, _gradientTracking, _gradientSplit);
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
		Rectangle rect = new Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height);
		colors.DrawItem(g, rect);
	}

	private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
	{
		g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare);
		g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare);
	}

	private void DrawContextMenuSeparator(Graphics g, bool vertical, Rectangle rect, int horizontalInset, bool rtl)
	{
		if (vertical)
		{
			int num = rect.Width / 2;
			int y = rect.Y;
			int bottom = rect.Bottom;
			using Pen pen = new Pen(Color.FromArgb(80, base.KCT.MenuBorder));
			pen.DashPattern = new float[2] { 2f, 2f };
			g.DrawLine(pen, num, y, num, bottom);
			return;
		}
		int num2 = rect.Height / 2;
		int x = rect.X + ((!rtl) ? horizontalInset : 0);
		int x2 = rect.Right - (rtl ? horizontalInset : 0);
		using Pen pen2 = new Pen(Color.FromArgb(80, base.KCT.MenuBorder));
		pen2.DashPattern = new float[2] { 2f, 2f };
		g.DrawLine(pen2, x, num2, x2, num2);
	}

	private void DrawToolStripSeparator(Graphics g, bool vertical, Rectangle rect, Color lightColor, Color darkColor, int horizontalInset, bool rtl)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		if (vertical)
		{
			int num = rect.Width / 2;
			int y = rect.Y;
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, Color.Transparent, lightColor, 90f);
			using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect2, Color.Transparent, darkColor, 90f);
			linearGradientBrush.Blend = _separatorLightBlend;
			linearGradientBrush2.Blend = _separatorDarkBlend;
			g.FillRectangle(linearGradientBrush, num - 1, y, 3, rect.Height);
			g.FillRectangle(linearGradientBrush2, num, y, 1, rect.Height);
			return;
		}
		int x = rect.X;
		int num2 = rect.Height / 2;
		using LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rect2, Color.Transparent, lightColor, 0f);
		using LinearGradientBrush linearGradientBrush4 = new LinearGradientBrush(rect2, Color.Transparent, darkColor, 0f);
		linearGradientBrush3.Blend = _separatorLightBlend;
		linearGradientBrush4.Blend = _separatorDarkBlend;
		g.FillRectangle(linearGradientBrush3, x, num2 - 1, rect.Width, 3);
		g.FillRectangle(linearGradientBrush4, x, num2, rect.Width, 1);
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
