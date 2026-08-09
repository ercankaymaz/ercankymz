#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public abstract class RenderBase : Component, IRenderer, IRenderBorder, IRenderBack, IRenderContent, IRenderTabBorder, IRenderRibbon, IRenderGlyph
{
	private static object _threadLock = new object();

	private static readonly ColorMatrix _matrixGrayScale = new ColorMatrix(new float[5][]
	{
		new float[5] { 0.3f, 0.3f, 0.3f, 0f, 0f },
		new float[5] { 0.59f, 0.59f, 0.59f, 0f, 0f },
		new float[5] { 0.11f, 0.11f, 0.11f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0f, 0f, 0f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixGrayScaleRed = new ColorMatrix(new float[5][]
	{
		new float[5] { 1f, 0f, 0f, 0f, 0f },
		new float[5] { 0f, 0.59f, 0.59f, 0f, 0f },
		new float[5] { 0f, 0.11f, 0.11f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0f, 0f, 0f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixGrayScaleGreen = new ColorMatrix(new float[5][]
	{
		new float[5] { 0.3f, 0f, 0.3f, 0f, 0f },
		new float[5] { 0f, 1f, 0f, 0f, 0f },
		new float[5] { 0.11f, 0f, 0.11f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0f, 0f, 0f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixGrayScaleBlue = new ColorMatrix(new float[5][]
	{
		new float[5] { 0.3f, 0.3f, 0f, 0f, 0f },
		new float[5] { 0.59f, 0.59f, 0f, 0f, 0f },
		new float[5] { 0f, 0f, 1f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0f, 0f, 0f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixLight = new ColorMatrix(new float[5][]
	{
		new float[5] { 1f, 0f, 0f, 0f, 0f },
		new float[5] { 0f, 1f, 0f, 0f, 0f },
		new float[5] { 0f, 0f, 1f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0.1f, 0.1f, 0.1f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixLightLight = new ColorMatrix(new float[5][]
	{
		new float[5] { 1f, 0f, 0f, 0f, 0f },
		new float[5] { 0f, 1f, 0f, 0f, 0f },
		new float[5] { 0f, 0f, 1f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { 0.2f, 0.2f, 0.2f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixDark = new ColorMatrix(new float[5][]
	{
		new float[5] { 1f, 0f, 0f, 0f, 0f },
		new float[5] { 0f, 1f, 0f, 0f, 0f },
		new float[5] { 0f, 0f, 1f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { -0.1f, -0.1f, -0.1f, 0f, 1f }
	});

	private static readonly ColorMatrix _matrixDarkDark = new ColorMatrix(new float[5][]
	{
		new float[5] { 1f, 0f, 0f, 0f, 0f },
		new float[5] { 0f, 1f, 0f, 0f, 0f },
		new float[5] { 0f, 0f, 1f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 1f, 0f },
		new float[5] { -0.25f, -0.25f, -0.25f, 0f, 1f }
	});

	public IRenderBorder RenderStandardBorder
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public IRenderBack RenderStandardBack
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public IRenderContent RenderStandardContent
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public IRenderTabBorder RenderTabBorder
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public IRenderRibbon RenderRibbon
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public IRenderGlyph RenderGlyph
	{
		[DebuggerStepThrough]
		get
		{
			return this;
		}
	}

	public abstract ToolStripRenderer RenderToolStrip(IPalette colorPalette);

	public abstract Padding GetBorderRawPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation);

	public abstract Padding GetBorderDisplayPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation);

	public abstract GraphicsPath GetOutsideBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	public abstract GraphicsPath GetBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	public abstract GraphicsPath GetBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	public abstract void DrawBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	public abstract IDisposable DrawBack(RenderContext context, Rectangle rect, GraphicsPath path, IPaletteBack palette, VisualOrientation orientation, PaletteState state, IDisposable memento);

	public abstract Size GetContentPreferredSize(ViewLayoutContext context, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition);

	public abstract IDisposable LayoutContent(ViewLayoutContext context, Rectangle availableRect, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition);

	public abstract void DrawContent(RenderContext context, Rectangle displayRect, IPaletteContent palette, IDisposable memento, VisualOrientation orientation, PaletteState state, bool composition, bool allowFocusRect);

	public abstract bool GetContentImageDisplayed(IDisposable memento);

	public abstract Rectangle GetContentImageRectangle(IDisposable memento);

	public abstract bool GetContentShortTextDisplayed(IDisposable memento);

	public abstract Rectangle GetContentShortTextRectangle(IDisposable memento);

	public abstract bool GetContentLongTextDisplayed(IDisposable memento);

	public abstract Rectangle GetContentLongTextRectangle(IDisposable memento);

	public abstract bool GetTabBorderLeftDrawing(TabBorderStyle tabBorderStyle);

	public abstract int GetTabBorderSpacingGap(TabBorderStyle tabBorderStyle);

	public abstract Padding GetTabBorderDisplayPadding(ViewLayoutContext context, IPaletteBorder palette, PaletteState state, VisualOrientation orientation, TabBorderStyle tabBorderStyle);

	public abstract GraphicsPath GetTabBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);

	public abstract GraphicsPath GetTabBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);

	public abstract void DrawTabBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);

	public abstract IDisposable DrawRibbonBack(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, bool composition, IDisposable memento);

	public abstract IDisposable DrawRibbonTabContextTitle(PaletteRibbonShape shape, RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento);

	public abstract IDisposable DrawRibbonApplicationButton(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento);

	public abstract IDisposable DrawRibbonApplicationTab(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, Color baseColor1, Color baseColor2, IDisposable memento);

	public abstract void DrawRibbonClusterEdge(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, PaletteState state);

	public abstract void DrawSeparator(RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, IPaletteBorder paletteBorder, Orientation orientation, PaletteState state, bool canMove);

	public abstract Size GetCheckBoxPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed);

	public abstract void DrawCheckBox(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed);

	public abstract Size GetRadioButtonPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed);

	public abstract void DrawRadioButton(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed);

	public abstract Size GetDropDownButtonPreferredSize(ViewLayoutContext context, IPalette palette, PaletteState state, VisualOrientation orientation);

	public abstract void DrawDropDownButton(RenderContext context, Rectangle displayRect, IPalette palette, PaletteState state, VisualOrientation orientation);

	public abstract void DrawInputControlNumericUpGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	public abstract void DrawInputControlNumericDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	public abstract void DrawInputControlDropDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	public abstract void DrawRibbonDialogBoxLauncher(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	public abstract void DrawRibbonDropArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	public abstract void DrawRibbonContextArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	public abstract void DrawRibbonOverflow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	public abstract void DrawRibbonGroupSeparator(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	public abstract Rectangle DrawGridSortGlyph(RenderContext context, SortOrder sortOrder, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl);

	public abstract Rectangle DrawGridRowGlyph(RenderContext context, GridRowGlyph rowGlyph, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl);

	public abstract Rectangle DrawGridErrorGlyph(RenderContext context, Rectangle cellRect, PaletteState state, bool rtl);

	public abstract void DrawDragDropSolidGlyph(RenderContext context, Rectangle drawRect, IPaletteDragDrop dragDropPalette);

	public abstract void MeasureDragDropDockingGlyph(RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback);

	public abstract void DrawDragDropDockingGlyph(RenderContext context, RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback);

	public abstract void DrawTrackTicksGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool topRight, Size positionSize, int minimum, int maximum, int frequency);

	public abstract void DrawTrackGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool volumeControl);

	public abstract void DrawTrackPositionGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, TickStyle tickStyle);

	public abstract bool EvalTransparentPaint(IPaletteBack paletteBack, PaletteState state);

	public abstract bool EvalTransparentPaint(IPaletteBack paletteBack, IPaletteBorder paletteBorder, PaletteState state);

	protected static void DrawIconHelper(ViewContext context, Icon icon, Rectangle iconRect, VisualOrientation orientation)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		try
		{
			context.Graphics.DrawIcon(icon, iconRect);
		}
		finally
		{
		}
	}

	protected static void DrawImageHelper(ViewContext context, Image image, Color remapTransparent, Rectangle imageRect, VisualOrientation orientation, PaletteImageEffect effect, Color remapColor, Color remapNew)
	{
		Debug.Assert(context != null);
		lock (_threadLock)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			ImageAttributes imageAttributes = new ImageAttributes();
			switch (effect)
			{
			case PaletteImageEffect.Disabled:
				imageAttributes.SetColorMatrix(CommonHelper.MatrixDisabled);
				break;
			case PaletteImageEffect.GrayScale:
				imageAttributes.SetColorMatrix(_matrixGrayScale, ColorMatrixFlag.SkipGrays);
				break;
			case PaletteImageEffect.GrayScaleRed:
				imageAttributes.SetColorMatrix(_matrixGrayScaleRed, ColorMatrixFlag.SkipGrays);
				break;
			case PaletteImageEffect.GrayScaleGreen:
				imageAttributes.SetColorMatrix(_matrixGrayScaleGreen, ColorMatrixFlag.SkipGrays);
				break;
			case PaletteImageEffect.GrayScaleBlue:
				imageAttributes.SetColorMatrix(_matrixGrayScaleBlue, ColorMatrixFlag.SkipGrays);
				break;
			case PaletteImageEffect.Light:
				imageAttributes.SetColorMatrix(_matrixLight);
				break;
			case PaletteImageEffect.LightLight:
				imageAttributes.SetColorMatrix(_matrixLightLight);
				break;
			case PaletteImageEffect.Dark:
				imageAttributes.SetColorMatrix(_matrixDark);
				break;
			case PaletteImageEffect.DarkDark:
				imageAttributes.SetColorMatrix(_matrixDarkDark);
				break;
			case PaletteImageEffect.Inherit:
				Debug.Assert(condition: false);
				break;
			}
			if (remapTransparent != Color.Empty || (remapColor != Color.Empty && remapNew != Color.Empty))
			{
				List<ColorMap> list = new List<ColorMap>();
				if (remapTransparent != Color.Empty)
				{
					ColorMap colorMap = new ColorMap();
					colorMap.OldColor = remapTransparent;
					colorMap.NewColor = Color.Transparent;
					list.Add(colorMap);
				}
				if (remapColor != Color.Empty && remapNew != Color.Empty)
				{
					ColorMap colorMap2 = new ColorMap();
					colorMap2.OldColor = remapColor;
					colorMap2.NewColor = remapNew;
					list.Add(colorMap2);
				}
				imageAttributes.SetRemapTable(list.ToArray(), ColorAdjustType.Bitmap);
			}
			int num = 0;
			int num2 = 0;
			float num3 = 0f;
			switch (orientation)
			{
			case VisualOrientation.Bottom:
				num = imageRect.X * 2 + imageRect.Width;
				num2 = imageRect.Y * 2 + imageRect.Height;
				num3 = 180f;
				break;
			case VisualOrientation.Left:
				imageRect = new Rectangle(imageRect.X, imageRect.Y, imageRect.Height, imageRect.Width);
				num = imageRect.X - imageRect.Y;
				num2 = imageRect.X + imageRect.Y + imageRect.Width;
				num3 = -90f;
				break;
			case VisualOrientation.Right:
				imageRect = new Rectangle(imageRect.X, imageRect.Y, imageRect.Height, imageRect.Width);
				num = imageRect.X + imageRect.Y + imageRect.Height;
				num2 = -(imageRect.X - imageRect.Y);
				num3 = 90f;
				break;
			}
			if (num != 0 || num2 != 0)
			{
				context.Graphics.TranslateTransform(num, num2);
			}
			if (num3 != 0f)
			{
				context.Graphics.RotateTransform(num3);
			}
			try
			{
				context.Graphics.DrawImage(image, imageRect, 0, 0, imageRect.Width, imageRect.Height, GraphicsUnit.Pixel, imageAttributes);
			}
			catch (ArgumentException)
			{
			}
			finally
			{
				if (num3 != 0f)
				{
					context.Graphics.RotateTransform(0f - num3);
				}
				if (num != 0 || num2 != 0)
				{
					context.Graphics.TranslateTransform(-num, -num2);
				}
			}
		}
	}
}
