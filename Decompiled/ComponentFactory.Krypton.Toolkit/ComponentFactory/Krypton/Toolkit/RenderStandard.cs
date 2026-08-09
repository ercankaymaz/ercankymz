#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderStandard : RenderBase
{
	private class StandardContentMemento : IDisposable
	{
		public bool DrawImage;

		public bool DrawShortText;

		public bool DrawLongText;

		public Image Image;

		public Color ImageTransparentColor;

		public Rectangle ImageRect;

		public PaletteTextTrim ShortTextTrimming;

		public AccurateTextMemento ShortTextMemento;

		public Rectangle ShortTextRect;

		public TextRenderingHint ShortTextHint;

		public PaletteTextTrim LongTextTrimming;

		public AccurateTextMemento LongTextMemento;

		public Rectangle LongTextRect;

		public TextRenderingHint LongTextHint;

		public VisualOrientation Orientation;

		public StandardContentMemento()
		{
			LongTextTrimming = PaletteTextTrim.EllipsisCharacter;
			ShortTextTrimming = PaletteTextTrim.EllipsisCharacter;
			Orientation = VisualOrientation.Top;
		}

		public void Dispose()
		{
			if (ShortTextMemento != null)
			{
				ShortTextMemento.Dispose();
				ShortTextMemento = null;
			}
			if (LongTextMemento != null)
			{
				LongTextMemento.Dispose();
				LongTextMemento = null;
			}
		}

		public void AdjustForOrientation(VisualOrientation orientation, Rectangle displayRect)
		{
			switch (orientation)
			{
			case VisualOrientation.Top:
				break;
			case VisualOrientation.Bottom:
				Orientation = VisualOrientation.Bottom;
				if (DrawImage)
				{
					ImageRect.X = displayRect.Right - ImageRect.Width - (ImageRect.X - displayRect.Left);
					ImageRect.Y = displayRect.Bottom - ImageRect.Height - (ImageRect.Y - displayRect.Top);
				}
				if (DrawShortText)
				{
					ShortTextRect.X = displayRect.Right - ShortTextRect.Width - (ShortTextRect.X - displayRect.Left);
					ShortTextRect.Y = displayRect.Bottom - ShortTextRect.Height - (ShortTextRect.Y - displayRect.Top);
				}
				if (DrawLongText)
				{
					LongTextRect.X = displayRect.Right - LongTextRect.Width - (LongTextRect.X - displayRect.Left);
					LongTextRect.Y = displayRect.Bottom - LongTextRect.Height - (LongTextRect.Y - displayRect.Top);
				}
				break;
			case VisualOrientation.Left:
				Orientation = VisualOrientation.Left;
				if (DrawImage)
				{
					int num4 = ImageRect.Y - displayRect.Top;
					ImageRect.Y = displayRect.Top + displayRect.Width - ImageRect.Width - (ImageRect.X - displayRect.X);
					ImageRect.X = num4 + displayRect.Left;
				}
				if (DrawShortText)
				{
					int num5 = ShortTextRect.Y - displayRect.Top;
					ShortTextRect.Y = displayRect.Top + displayRect.Width - ShortTextRect.Width - (ShortTextRect.X - displayRect.X);
					ShortTextRect.X = num5 + displayRect.Left;
					SwapRectangleSizes(ref ShortTextRect);
				}
				if (DrawLongText)
				{
					int num6 = LongTextRect.Y - displayRect.Top;
					LongTextRect.Y = displayRect.Top + displayRect.Width - LongTextRect.Width - (LongTextRect.X - displayRect.X);
					LongTextRect.X = num6 + displayRect.Left;
					SwapRectangleSizes(ref LongTextRect);
				}
				break;
			case VisualOrientation.Right:
				Orientation = VisualOrientation.Right;
				if (DrawImage)
				{
					int num = ImageRect.X - displayRect.Left;
					ImageRect.X = displayRect.Left + displayRect.Bottom - ImageRect.Bottom;
					ImageRect.Y = num + displayRect.Top;
				}
				if (DrawShortText)
				{
					int num2 = ShortTextRect.X - displayRect.Left;
					ShortTextRect.X = displayRect.Left + displayRect.Bottom - ShortTextRect.Bottom;
					ShortTextRect.Y = num2 + displayRect.Top;
					SwapRectangleSizes(ref ShortTextRect);
				}
				if (DrawLongText)
				{
					int num3 = LongTextRect.X - displayRect.Left;
					LongTextRect.X = displayRect.Left + displayRect.Bottom - LongTextRect.Bottom;
					LongTextRect.Y = num3 + displayRect.Top;
					SwapRectangleSizes(ref LongTextRect);
				}
				break;
			}
		}

		private static void SwapRectangleSizes(ref Rectangle rect)
		{
			int width = rect.Width;
			rect.Width = rect.Height;
			rect.Height = width;
		}
	}

	private static readonly int _dragArrowWidth;

	private static readonly int _dragArrowHeight;

	private static readonly int _dragArrowGap;

	private static readonly int _spacingTabDockOutsize;

	private static readonly int _spacingTabOutsizePadding;

	private static readonly int _spacingTabSquareEqualSmall;

	private static readonly int _spacingTabSquareEqualMedium;

	private static readonly int _spacingTabSquareEqualLarge;

	private static readonly int _spacingTabSquareOutsizeSmall;

	private static readonly int _spacingTabSquareOutsizeMedium;

	private static readonly int _spacingTabSquareOutsizeLarge;

	private static readonly int _spacingTabRoundedEqualSmall;

	private static readonly int _spacingTabRoundedEqualMedium;

	private static readonly int _spacingTabRoundedEqualLarge;

	private static readonly int _spacingTabRoundedOutsizeSmall;

	private static readonly int _spacingTabRoundedOutsizeMedium;

	private static readonly int _spacingTabRoundedOutsizeLarge;

	private static readonly int _spacingTabRoundedCorner;

	private static readonly int _spacingTabSlantEqual;

	private static readonly int _spacingTabSlantEqualBoth;

	private static readonly int _spacingTabSlantOutsize;

	private static readonly int _spacingTabSlantPadding;

	private static readonly int _spacingTabOneNote;

	private static readonly int _spacingTabOneNoteLPI;

	private static readonly int _spacingTabOneNoteRPI;

	private static readonly int _spacingTabOneNoteTPI;

	private static readonly int _spacingTabOneNoteBPI;

	private static readonly int _spacingTabOneNoteLPS;

	private static readonly int _spacingTabOneNoteRPS;

	private static readonly int _spacingTabOneNoteTPS;

	private static readonly int _spacingTabOneNoteBPS;

	private static readonly int _spacingTabSmoothE;

	private static readonly int _spacingTabSmoothO;

	private static readonly int _spacingTabSmoothLRE;

	private static readonly int _spacingTabSmoothTE;

	private static readonly int _spacingTabSmoothLRO;

	private static readonly int _spacingTabSmoothTO;

	private static readonly int _groupFrameTitleHeight;

	private static readonly float _groupGradientTwo;

	private static readonly float _groupGradientFrame;

	private static readonly Color _darken5;

	private static readonly Color _darken8;

	private static readonly Color _darken12;

	private static readonly Color _darken16;

	private static readonly Color _darken18;

	private static readonly Color _darken38;

	private static readonly Color _whiten200;

	private static readonly Color _whiten160;

	private static readonly Color _whiten128;

	private static readonly Color _whiten120;

	private static readonly Color _whiten92;

	private static readonly Color _whiten80;

	private static readonly Color _whiten64;

	private static readonly Color _whiten60;

	private static readonly Color _whiten50;

	private static readonly Color _whiten45;

	private static readonly Color _whiten32;

	private static readonly Color _whiten30;

	private static readonly Color _whiten10;

	private static readonly Color _whiten5;

	private static readonly Color _242;

	private static readonly Color _218;

	private static readonly Color _190;

	private static readonly Blend _linear25Blend;

	private static readonly Blend _linear33Blend;

	private static readonly Blend _linear40Blend;

	private static readonly Blend _linear50Blend;

	private static readonly Blend _switch25Blend;

	private static readonly Blend _switch33Blend;

	private static readonly Blend _switch50Blend;

	private static readonly Blend _switch90Blend;

	private static readonly Blend _halfCutBlend;

	private static readonly Blend _quarterPhaseBlend;

	private static readonly Blend _oneNoteBlend;

	private static readonly Blend _linearShadowBlend;

	private static readonly Blend _rounding2Blend;

	private static readonly Blend _rounding3Blend;

	private static readonly Blend _rounding4Blend;

	private static readonly Blend _rounding5Blend;

	private static readonly Blend _ribbonInBlend;

	private static readonly Blend _ribbonOutBlend;

	private static readonly Blend _ribbonTopBlend;

	private static readonly Blend _ribbonGroupArea3;

	private static readonly Blend _ribbonTabSelected1Blend;

	private static readonly Blend _ribbonTabSelected2Blend;

	private static readonly Blend _ribbonGroup1Blend;

	private static readonly Blend _ribbonGroup2Blend;

	private static readonly Blend _ribbonGroup3Blend;

	private static readonly Blend _ribbonGroup4Blend;

	private static readonly Blend _ribbonGroup5Blend;

	private static readonly Blend _ribbonGroup6Blend;

	private static readonly Blend _ribbonGroup7Blend;

	private static readonly Blend _ribbonGroup8Blend;

	private static readonly Blend _ribbonGroup9Blend;

	private static readonly Blend _ribbonTabTopBlend;

	private static readonly Blend _ribbonAppButtonBlend;

	private static readonly Blend _dragRoundedInsideBlend;

	private static readonly Pen _paleShadowPen;

	private static readonly Pen _lightShadowPen;

	private static readonly Pen _mediumShadowPen;

	private static readonly Pen _medium2ShadowPen;

	private static readonly Pen _darkShadowPen;

	private static readonly Pen _light1Pen;

	private static readonly Pen _light2Pen;

	private static readonly Pen _whitenMediumPen;

	private static readonly Pen _buttonShadowPen;

	private static readonly Pen _compositionPen;

	private static readonly SolidBrush _whitenLightBrush;

	private static readonly SolidBrush _whitenLightLBrush;

	private static readonly SolidBrush _compositionBrush;

	private static readonly SolidBrush _buttonBorder1Brush;

	private static readonly SolidBrush _buttonBorder2Brush;

	private static readonly ImageList _gridSortOrder;

	private static readonly ImageList _gridRowIndicators;

	private static readonly ImageList _gridErrorIcon;

	static RenderStandard()
	{
		_dragArrowWidth = 13;
		_dragArrowHeight = 7;
		_dragArrowGap = 4;
		_spacingTabDockOutsize = 3;
		_spacingTabOutsizePadding = 1;
		_spacingTabSquareEqualSmall = -1;
		_spacingTabSquareEqualMedium = 2;
		_spacingTabSquareEqualLarge = 5;
		_spacingTabSquareOutsizeSmall = -5;
		_spacingTabSquareOutsizeMedium = -3;
		_spacingTabSquareOutsizeLarge = 2;
		_spacingTabRoundedEqualSmall = -1;
		_spacingTabRoundedEqualMedium = 2;
		_spacingTabRoundedEqualLarge = 5;
		_spacingTabRoundedOutsizeSmall = -5;
		_spacingTabRoundedOutsizeMedium = -3;
		_spacingTabRoundedOutsizeLarge = 2;
		_spacingTabRoundedCorner = 2;
		_spacingTabSlantEqual = -7;
		_spacingTabSlantEqualBoth = -17;
		_spacingTabSlantOutsize = -11;
		_spacingTabSlantPadding = 12;
		_spacingTabOneNote = -14;
		_spacingTabOneNoteLPI = 12;
		_spacingTabOneNoteRPI = 19;
		_spacingTabOneNoteTPI = 5;
		_spacingTabOneNoteBPI = 0;
		_spacingTabOneNoteLPS = 4;
		_spacingTabOneNoteRPS = 24;
		_spacingTabOneNoteTPS = 3;
		_spacingTabOneNoteBPS = 2;
		_spacingTabSmoothE = -6;
		_spacingTabSmoothO = -14;
		_spacingTabSmoothLRE = 5;
		_spacingTabSmoothTE = 3;
		_spacingTabSmoothLRO = 9;
		_spacingTabSmoothTO = 7;
		_groupFrameTitleHeight = 8;
		_groupGradientTwo = 0.16f;
		_groupGradientFrame = 0.32f;
		_darken5 = Color.FromArgb(5, Color.Black);
		_darken8 = Color.FromArgb(8, Color.Black);
		_darken12 = Color.FromArgb(12, Color.Black);
		_darken16 = Color.FromArgb(16, Color.Black);
		_darken18 = Color.FromArgb(18, Color.Black);
		_darken38 = Color.FromArgb(38, Color.Black);
		_whiten200 = Color.FromArgb(200, Color.White);
		_whiten160 = Color.FromArgb(160, Color.White);
		_whiten128 = Color.FromArgb(128, Color.White);
		_whiten120 = Color.FromArgb(120, Color.White);
		_whiten92 = Color.FromArgb(92, Color.White);
		_whiten80 = Color.FromArgb(80, Color.White);
		_whiten64 = Color.FromArgb(64, Color.White);
		_whiten60 = Color.FromArgb(60, Color.White);
		_whiten50 = Color.FromArgb(50, Color.White);
		_whiten45 = Color.FromArgb(45, Color.White);
		_whiten32 = Color.FromArgb(32, Color.White);
		_whiten30 = Color.FromArgb(30, Color.White);
		_whiten10 = Color.FromArgb(10, Color.White);
		_whiten5 = Color.FromArgb(5, Color.White);
		_242 = Color.FromArgb(242, 242, 242);
		_218 = Color.FromArgb(218, 218, 218);
		_190 = Color.FromArgb(190, 190, 190);
		_linear25Blend = new Blend();
		_linear25Blend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_linear25Blend.Positions = new float[4] { 0f, 0.25f, 0.25f, 1f };
		_linear33Blend = new Blend();
		_linear33Blend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_linear33Blend.Positions = new float[4] { 0f, 0.33f, 0.33f, 1f };
		_linear40Blend = new Blend();
		_linear40Blend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_linear40Blend.Positions = new float[4] { 0f, 0.4f, 0.4f, 1f };
		_linear50Blend = new Blend();
		_linear50Blend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_linear50Blend.Positions = new float[4] { 0f, 0.5f, 0.5f, 1f };
		_linearShadowBlend = new Blend();
		_linearShadowBlend.Factors = new float[3] { 0f, 1f, 1f };
		_linearShadowBlend.Positions = new float[3] { 0f, 0.3f, 1f };
		_switch25Blend = new Blend();
		_switch25Blend.Factors = new float[4] { 0f, 0f, 1f, 1f };
		_switch25Blend.Positions = new float[4] { 0f, 0.25f, 0.25f, 1f };
		_switch33Blend = new Blend();
		_switch33Blend.Factors = new float[4] { 0f, 0f, 1f, 1f };
		_switch33Blend.Positions = new float[4] { 0f, 0.33f, 0.33f, 1f };
		_switch50Blend = new Blend();
		_switch50Blend.Factors = new float[4] { 0f, 0f, 1f, 1f };
		_switch50Blend.Positions = new float[4] { 0f, 0.5f, 0.5f, 1f };
		_switch90Blend = new Blend();
		_switch90Blend.Factors = new float[4] { 0f, 0f, 0f, 1f };
		_switch90Blend.Positions = new float[4] { 0f, 0.9f, 0.9f, 1f };
		_halfCutBlend = new Blend();
		_halfCutBlend.Factors = new float[4] { 0f, 0.5f, 1f, 0.05f };
		_halfCutBlend.Positions = new float[4] { 0f, 0.45f, 0.45f, 1f };
		_quarterPhaseBlend = new Blend();
		_quarterPhaseBlend.Factors = new float[6] { 0f, 0f, 0.25f, 0.7f, 1f, 1f };
		_quarterPhaseBlend.Positions = new float[6] { 0f, 0.1f, 0.2f, 0.3f, 0.5f, 1f };
		_oneNoteBlend = new Blend();
		_oneNoteBlend.Factors = new float[4] { 0.15f, 0.75f, 1f, 1f };
		_oneNoteBlend.Positions = new float[4] { 0f, 0.45f, 0.45f, 1f };
		_rounding2Blend = new Blend();
		_rounding2Blend.Factors = new float[5] { 0.8f, 0.2f, 0f, 0.07f, 1f };
		_rounding2Blend.Positions = new float[5] { 0f, 0.33f, 0.33f, 0.43f, 1f };
		_rounding3Blend = new Blend();
		_rounding3Blend.Factors = new float[8] { 1f, 0.7f, 0.7f, 0f, 0.1f, 0.55f, 1f, 1f };
		_rounding3Blend.Positions = new float[8] { 0f, 0.16f, 0.33f, 0.35f, 0.51f, 0.85f, 0.85f, 1f };
		_rounding4Blend = new Blend();
		_rounding4Blend.Factors = new float[5] { 1f, 0.78f, 0.48f, 1f, 1f };
		_rounding4Blend.Positions = new float[5] { 0f, 0.33f, 0.33f, 0.9f, 1f };
		_rounding5Blend = new Blend();
		_rounding5Blend.Factors = new float[4] { 0f, 0f, 1f, 1f };
		_rounding5Blend.Positions = new float[4] { 0f, 0.2f, 0.84f, 1f };
		_ribbonInBlend = new Blend();
		_ribbonInBlend.Factors = new float[3] { 0.66f, 1f, 0f };
		_ribbonInBlend.Positions = new float[3] { 0f, 0.5f, 1f };
		_ribbonOutBlend = new Blend();
		_ribbonOutBlend.Factors = new float[3] { 0.2f, 1f, 0f };
		_ribbonOutBlend.Positions = new float[3] { 0f, 0.5f, 1f };
		_ribbonTopBlend = new Blend();
		_ribbonTopBlend.Factors = new float[4] { 0f, 1f, 1f, 0f };
		_ribbonTopBlend.Positions = new float[4] { 0f, 0.2f, 0.8f, 1f };
		_ribbonGroup1Blend = new Blend();
		_ribbonGroup1Blend.Factors = new float[4] { 0f, 0f, 0.6f, 1f };
		_ribbonGroup1Blend.Positions = new float[4] { 0f, 0.18f, 0.75f, 1f };
		_ribbonGroup2Blend = new Blend();
		_ribbonGroup2Blend.Factors = new float[4] { 0f, 0.5f, 1f, 1f };
		_ribbonGroup2Blend.Positions = new float[4] { 0f, 0.18f, 0.2f, 1f };
		_ribbonGroup3Blend = new Blend();
		_ribbonGroup3Blend.Factors = new float[5] { 0f, 0f, 1f, 0f, 0f };
		_ribbonGroup3Blend.Positions = new float[5] { 0f, 0.9f, 0.97f, 0.97f, 1f };
		_ribbonGroup4Blend = new Blend();
		_ribbonGroup4Blend.Factors = new float[4] { 0f, 0.4f, 1f, 1f };
		_ribbonGroup4Blend.Positions = new float[4] { 0f, 0.045f, 0.33f, 1f };
		_ribbonGroup5Blend = new Blend();
		_ribbonGroup5Blend.Factors = new float[3] { 0f, 0f, 1f };
		_ribbonGroup5Blend.Positions = new float[3] { 0f, 0.5f, 1f };
		_ribbonGroup6Blend = new Blend();
		_ribbonGroup6Blend.Factors = new float[3] { 0f, 0f, 1f };
		_ribbonGroup6Blend.Positions = new float[3] { 0f, 0.4f, 1f };
		_ribbonGroup7Blend = new Blend();
		_ribbonGroup7Blend.Factors = new float[4] { 0f, 1f, 1f, 0f };
		_ribbonGroup7Blend.Positions = new float[4] { 0f, 0.15f, 0.85f, 1f };
		_ribbonGroup8Blend = new Blend();
		_ribbonGroup8Blend.Factors = new float[3] { 0f, 0f, 1f };
		_ribbonGroup8Blend.Positions = new float[3] { 0f, 0.85f, 1f };
		_ribbonGroup9Blend = new Blend();
		_ribbonGroup9Blend.Factors = new float[5] { 0f, 0.5f, 0.75f, 0.9f, 1f };
		_ribbonGroup9Blend.Positions = new float[5] { 0f, 0.25f, 0.5f, 0.75f, 1f };
		_ribbonGroupArea3 = new Blend();
		_ribbonGroupArea3.Factors = new float[4] { 1f, 0f, 0f, 1f };
		_ribbonGroupArea3.Positions = new float[4] { 0f, 0.1f, 0.85f, 1f };
		_ribbonTabSelected1Blend = new Blend();
		_ribbonTabSelected1Blend.Factors = new float[5] { 0f, 0f, 0f, 1f, 1f };
		_ribbonTabSelected1Blend.Positions = new float[5] { 0f, 0.5f, 0.5f, 0.9f, 1f };
		_ribbonTabSelected2Blend = new Blend();
		_ribbonTabSelected2Blend.Factors = new float[3] { 0f, 1f, 1f };
		_ribbonTabSelected2Blend.Positions = new float[3] { 0f, 0.75f, 1f };
		_ribbonTabTopBlend = new Blend();
		_ribbonTabTopBlend.Factors = new float[3] { 0f, 1f, 1f };
		_ribbonTabTopBlend.Positions = new float[3] { 0f, 0.2f, 1f };
		_ribbonAppButtonBlend = new Blend();
		_ribbonAppButtonBlend.Factors = new float[5] { 0f, 0f, 0.5f, 1f, 1f };
		_ribbonAppButtonBlend.Positions = new float[5] { 0f, 0.1f, 0.5f, 0.5f, 1f };
		_dragRoundedInsideBlend = new Blend();
		_dragRoundedInsideBlend.Factors = new float[4] { 0.05f, 0.2f, 0.5f, 1f };
		_dragRoundedInsideBlend.Positions = new float[4] { 0f, 0.5f, 0.5f, 1f };
		_paleShadowPen = new Pen(Color.FromArgb(6, Color.Black));
		_lightShadowPen = new Pen(Color.FromArgb(8, Color.Black));
		_mediumShadowPen = new Pen(Color.FromArgb(10, Color.Black));
		_medium2ShadowPen = new Pen(Color.FromArgb(12, Color.Black));
		_darkShadowPen = new Pen(Color.FromArgb(18, Color.Black));
		_light1Pen = new Pen(Color.FromArgb(150, Color.White));
		_light2Pen = new Pen(Color.FromArgb(100, Color.White));
		_whitenMediumPen = new Pen(_whiten128);
		_buttonShadowPen = new Pen(Color.FromArgb(48, Color.Black));
		_compositionPen = new Pen(Color.FromArgb(96, Color.Black));
		_whitenLightBrush = new SolidBrush(_whiten30);
		_whitenLightLBrush = new SolidBrush(_whiten64);
		_compositionBrush = new SolidBrush(Color.FromArgb(32, Color.White));
		_buttonBorder1Brush = new SolidBrush(Color.FromArgb(20, 52, 59, 64));
		_buttonBorder2Brush = new SolidBrush(Color.FromArgb(70, 52, 59, 64));
		_gridSortOrder = new ImageList();
		_gridSortOrder.TransparentColor = Color.Magenta;
		_gridSortOrder.ImageSize = new Size(17, 11);
		_gridSortOrder.Images.AddStrip(Resources.GridSortOrder);
		_gridRowIndicators = new ImageList();
		_gridRowIndicators.TransparentColor = Color.Magenta;
		_gridRowIndicators.ImageSize = new Size(19, 13);
		_gridRowIndicators.Images.AddStrip(Resources.GridRowIndicators);
		_gridErrorIcon = new ImageList();
		_gridErrorIcon.TransparentColor = Color.Magenta;
		_gridErrorIcon.ImageSize = new Size(18, 17);
		_gridErrorIcon.Images.AddStrip(Resources.GridErrorIcon);
	}

	public override ToolStripRenderer RenderToolStrip(IPalette colorPalette)
	{
		Debug.Assert(colorPalette != null);
		if (colorPalette == null)
		{
			throw new ArgumentNullException("colorPalette");
		}
		KryptonStandardRenderer kryptonStandardRenderer = new KryptonStandardRenderer(colorPalette.ColorTable);
		kryptonStandardRenderer.RoundedEdges = colorPalette.ColorTable.UseRoundedEdges != InheritBool.False;
		return kryptonStandardRenderer;
	}

	public override Padding GetBorderRawPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation)
	{
		Debug.Assert(palette != null);
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		PaletteDrawBorders borderDrawBorders = palette.GetBorderDrawBorders(state);
		if (CommonHelper.HasABorder(borderDrawBorders))
		{
			int borderWidth = palette.GetBorderWidth(state);
			switch (borderDrawBorders)
			{
			case PaletteDrawBorders.Bottom:
				return new Padding(0, 0, 0, borderWidth);
			case PaletteDrawBorders.BottomLeft:
				return new Padding(borderWidth, 0, 0, borderWidth);
			case PaletteDrawBorders.BottomLeftRight:
				return new Padding(borderWidth, 0, borderWidth, borderWidth);
			case PaletteDrawBorders.BottomRight:
				return new Padding(0, 0, borderWidth, borderWidth);
			case PaletteDrawBorders.Left:
				return new Padding(borderWidth, 0, 0, 0);
			case PaletteDrawBorders.LeftRight:
				return new Padding(borderWidth, 0, borderWidth, 0);
			case PaletteDrawBorders.Top:
				return new Padding(0, borderWidth, 0, 0);
			case PaletteDrawBorders.Right:
				return new Padding(0, 0, borderWidth, 0);
			case PaletteDrawBorders.TopBottom:
				return new Padding(0, borderWidth, 0, borderWidth);
			case PaletteDrawBorders.TopBottomLeft:
				return new Padding(borderWidth, borderWidth, 0, borderWidth);
			case PaletteDrawBorders.TopBottomRight:
				return new Padding(0, borderWidth, borderWidth, borderWidth);
			case PaletteDrawBorders.TopLeft:
				return new Padding(borderWidth, borderWidth, 0, 0);
			case PaletteDrawBorders.TopLeftRight:
				return new Padding(borderWidth, borderWidth, borderWidth, 0);
			case PaletteDrawBorders.TopRight:
				return new Padding(0, borderWidth, borderWidth, 0);
			case PaletteDrawBorders.All:
				return new Padding(borderWidth);
			default:
				Debug.Assert(condition: false);
				return Padding.Empty;
			}
		}
		return Padding.Empty;
	}

	public override Padding GetBorderDisplayPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation)
	{
		Debug.Assert(palette != null);
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		PaletteDrawBorders borderDrawBorders = palette.GetBorderDrawBorders(state);
		if (CommonHelper.HasABorder(borderDrawBorders))
		{
			int borderWidth = palette.GetBorderWidth(state);
			int num = Convert.ToInt16((double)(palette.GetBorderRounding(state) + borderWidth + 2) / Math.PI);
			int num2 = borderWidth;
			if (borderWidth > 1)
			{
				int num3 = borderWidth / 2;
				num += num3;
			}
			if (num < borderWidth)
			{
				num = borderWidth;
			}
			switch (borderDrawBorders)
			{
			case PaletteDrawBorders.Bottom:
				return new Padding(0, 0, 0, num2);
			case PaletteDrawBorders.BottomLeft:
				return new Padding(num, 0, 0, num);
			case PaletteDrawBorders.BottomLeftRight:
				return new Padding(num, 0, num, num);
			case PaletteDrawBorders.BottomRight:
				return new Padding(0, 0, num, num);
			case PaletteDrawBorders.Left:
				return new Padding(num2, 0, 0, 0);
			case PaletteDrawBorders.LeftRight:
				return new Padding(num2, 0, num2, 0);
			case PaletteDrawBorders.Top:
				return new Padding(0, num2, 0, 0);
			case PaletteDrawBorders.Right:
				return new Padding(0, 0, num2, 0);
			case PaletteDrawBorders.TopBottom:
				return new Padding(0, num2, 0, num2);
			case PaletteDrawBorders.TopBottomLeft:
				return new Padding(num, num, 0, num);
			case PaletteDrawBorders.TopBottomRight:
				return new Padding(0, num, num, num);
			case PaletteDrawBorders.TopLeft:
				return new Padding(num, num, 0, 0);
			case PaletteDrawBorders.TopLeftRight:
				return new Padding(num, num, num, 0);
			case PaletteDrawBorders.TopRight:
				return new Padding(0, num, num, 0);
			case PaletteDrawBorders.All:
				return new Padding(num);
			default:
				Debug.Assert(condition: false);
				return Padding.Empty;
			}
		}
		return Padding.Empty;
	}

	public override GraphicsPath GetOutsideBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		return CreateBorderBackPath(forBorder: true, middle: false, rect, CommonHelper.OrientateDrawBorders(palette.GetBorderDrawBorders(state), orientation), palette.GetBorderWidth(state), palette.GetBorderRounding(state), palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias, 0);
	}

	public override GraphicsPath GetBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		return CreateBorderBackPath(forBorder: false, middle: true, rect, CommonHelper.OrientateDrawBorders(palette.GetBorderDrawBorders(state), orientation), palette.GetBorderWidth(state), palette.GetBorderRounding(state), palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias, 0);
	}

	public override GraphicsPath GetBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		return CreateBorderBackPath(forBorder: false, middle: true, rect, CommonHelper.OrientateDrawBorders(palette.GetBorderDrawBorders(state), orientation), palette.GetBorderWidth(state), palette.GetBorderRounding(state), palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias, 0);
	}

	public override void DrawBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		PaletteDrawBorders borderDrawBorders = palette.GetBorderDrawBorders(state);
		if (rect.Width <= 0 || rect.Height <= 0 || !CommonHelper.HasABorder(borderDrawBorders))
		{
			return;
		}
		SmoothingMode smoothingMode = ((palette.GetBorderRounding(state) > 0) ? SmoothingMode.AntiAlias : SmoothingMode.Default);
		using (new GraphicsHint(context.Graphics, palette.GetBorderGraphicsHint(state)))
		{
			int borderWidth = palette.GetBorderWidth(state);
			borderDrawBorders = CommonHelper.OrientateDrawBorders(borderDrawBorders, orientation);
			if (borderWidth <= 0)
			{
				return;
			}
			using (new Clipping(context.Graphics, rect))
			{
				GraphicsPath graphicsPath = CreateBorderBackPath(forBorder: true, middle: true, rect, borderDrawBorders, borderWidth, palette.GetBorderRounding(state), smoothingMode == SmoothingMode.AntiAlias, 0);
				GraphicsPath graphicsPath2 = null;
				if (borderDrawBorders == PaletteDrawBorders.TopBottom || borderDrawBorders == PaletteDrawBorders.LeftRight)
				{
					graphicsPath2 = CreateBorderBackPath(forBorder: true, middle: true, rect, borderDrawBorders, borderWidth, palette.GetBorderRounding(state), smoothingMode == SmoothingMode.AntiAlias, 1);
				}
				Rectangle alignedRectangle = context.GetAlignedRectangle(palette.GetBorderColorAlign(state), rect);
				PaletteColorStyle borderColorStyle = palette.GetBorderColorStyle(state);
				using (Pen pen = new Pen(CreateColorBrush(alignedRectangle, palette.GetBorderColor1(state), palette.GetBorderColor2(state), borderColorStyle, palette.GetBorderColorAngle(state), orientation), borderWidth))
				{
					if (borderColorStyle == PaletteColorStyle.Dashed)
					{
						pen.DashPattern = new float[2] { 2f, 2f };
					}
					context.Graphics.DrawPath(pen, graphicsPath);
					if (graphicsPath2 != null)
					{
						context.Graphics.DrawPath(pen, graphicsPath2);
					}
				}
				Image borderImage = palette.GetBorderImage(state);
				PaletteImageStyle borderImageStyle = palette.GetBorderImageStyle(state);
				if (ShouldDrawImage(borderImage))
				{
					Rectangle alignedRectangle2 = context.GetAlignedRectangle(palette.GetBorderImageAlign(state), rect);
					using Pen pen2 = new Pen(CreateImageBrush(alignedRectangle2, borderImage, borderImageStyle), borderWidth);
					context.Graphics.DrawPath(pen2, graphicsPath);
					if (graphicsPath2 != null)
					{
						context.Graphics.DrawPath(pen2, graphicsPath2);
					}
				}
				graphicsPath.Dispose();
				graphicsPath2?.Dispose();
			}
		}
	}

	public override IDisposable DrawBack(RenderContext context, Rectangle rect, GraphicsPath path, IPaletteBack palette, VisualOrientation orientation, PaletteState state, IDisposable memento)
	{
		Debug.Assert(context != null);
		Debug.Assert(path != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		if (rect.Width > 0 && rect.Height > 0)
		{
			using (new GraphicsHint(context.Graphics, palette.GetBackGraphicsHint(state)))
			{
				Image backImage = palette.GetBackImage(state);
				PaletteImageStyle backImageStyle = palette.GetBackImageStyle(state);
				PaletteColorStyle backColorStyle = palette.GetBackColorStyle(state);
				Color backColor = palette.GetBackColor1(state);
				Color backColor2 = palette.GetBackColor2(state);
				float backColorAngle = palette.GetBackColorAngle(state);
				Rectangle alignedRectangle = context.GetAlignedRectangle(palette.GetBackColorAlign(state), rect);
				switch (backColorStyle)
				{
				case PaletteColorStyle.GlassSimpleFull:
					memento = RenderGlassHelpers.DrawBackGlassSimpleFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassNormalFull:
					memento = RenderGlassHelpers.DrawBackGlassNormalFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassTrackingFull:
					memento = RenderGlassHelpers.DrawBackGlassTrackingFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassPressedFull:
					memento = RenderGlassHelpers.DrawBackGlassPressedFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedFull:
					memento = RenderGlassHelpers.DrawBackGlassCheckedFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedTrackingFull:
					memento = RenderGlassHelpers.DrawBackGlassCheckedTrackingFull(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassNormalStump:
					memento = RenderGlassHelpers.DrawBackGlassNormalStump(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassTrackingStump:
					memento = RenderGlassHelpers.DrawBackGlassTrackingStump(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassPressedStump:
					memento = RenderGlassHelpers.DrawBackGlassPressedStump(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedStump:
					memento = RenderGlassHelpers.DrawBackGlassCheckedStump(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedTrackingStump:
					memento = RenderGlassHelpers.DrawBackGlassCheckedTrackingStump(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassThreeEdge:
					memento = RenderGlassHelpers.DrawBackGlassThreeEdge(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassNormalSimple:
					memento = RenderGlassHelpers.DrawBackGlassNormalSimple(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassTrackingSimple:
					memento = RenderGlassHelpers.DrawBackGlassTrackingSimple(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassPressedSimple:
					memento = RenderGlassHelpers.DrawBackGlassPressedSimple(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedSimple:
					memento = RenderGlassHelpers.DrawBackGlassCheckedSimple(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCheckedTrackingSimple:
					memento = RenderGlassHelpers.DrawBackGlassCheckedTrackingSimple(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassCenter:
					memento = RenderGlassHelpers.DrawBackGlassCenter(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassBottom:
					memento = RenderGlassHelpers.DrawBackGlassBottom(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.GlassFade:
					memento = RenderGlassHelpers.DrawBackGlassFade(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.ExpertTracking:
					memento = RenderExpertHelpers.DrawBackExpertTracking(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.ExpertPressed:
					memento = RenderExpertHelpers.DrawBackExpertPressed(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.ExpertChecked:
					memento = RenderExpertHelpers.DrawBackExpertChecked(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.ExpertCheckedTracking:
					memento = RenderExpertHelpers.DrawBackExpertCheckedTracking(context, rect, backColor, backColor2, orientation, path, memento);
					break;
				case PaletteColorStyle.ExpertSquareHighlight:
					memento = RenderExpertHelpers.DrawBackExpertSquareHighlight(context, rect, backColor, backColor2, orientation, path, memento, light: false);
					break;
				case PaletteColorStyle.ExpertSquareHighlight2:
					memento = RenderExpertHelpers.DrawBackExpertSquareHighlight(context, rect, backColor, backColor2, orientation, path, memento, light: true);
					break;
				case PaletteColorStyle.SolidInside:
					DrawBackSolidInside(context, alignedRectangle, backColor, backColor2, path);
					break;
				case PaletteColorStyle.SolidRightLine:
				case PaletteColorStyle.SolidLeftLine:
				case PaletteColorStyle.SolidTopLine:
				case PaletteColorStyle.SolidBottomLine:
				case PaletteColorStyle.SolidAllLine:
					DrawBackSolidLine(context, rect, backColor, backColor2, backColorStyle, path);
					break;
				case PaletteColorStyle.OneNote:
					DrawBackOneNote(context, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				case PaletteColorStyle.RoundedTopLeftWhite:
					DrawBackRoundedTopLeftWhite(context, rect, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				case PaletteColorStyle.RoundedTopLight:
					DrawBackRoundedTopLight(context, rect, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				case PaletteColorStyle.Rounding4:
					DrawBackRounded4(context, rect, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				case PaletteColorStyle.Rounding5:
					DrawBackRounding5(context, rect, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				case PaletteColorStyle.LinearShadow:
					DrawBackLinearShadow(context, rect, alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation, path);
					break;
				default:
				{
					using (Brush brush = CreateColorBrush(alignedRectangle, backColor, backColor2, backColorStyle, backColorAngle, orientation))
					{
						context.Graphics.FillPath(brush, path);
					}
					break;
				}
				}
				if (ShouldDrawImage(backImage))
				{
					Rectangle alignedRectangle2 = context.GetAlignedRectangle(palette.GetBackImageAlign(state), rect);
					using Brush brush2 = CreateImageBrush(alignedRectangle2, backImage, backImageStyle);
					context.Graphics.FillPath(brush2, path);
				}
			}
		}
		return memento;
	}

	public override Size GetContentPreferredSize(ViewLayoutContext context, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		Debug.Assert(values != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		Rectangle displayRect = new Rectangle(Point.Empty, new Size(int.MaxValue, int.MaxValue));
		Size[,] allocation = new Size[3, 3]
		{
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			},
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			},
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			}
		};
		using StandardContentMemento memento = new StandardContentMemento();
		int contentAdjacentGap = palette.GetContentAdjacentGap(state);
		RightToLeft rtl = ((orientation != VisualOrientation.Left && orientation != VisualOrientation.Right) ? context.Control.RightToLeft : RightToLeft.No);
		AllocateImageSpace(memento, palette, values, state, displayRect, rtl, ref allocation);
		AllocateShortTextSpace(context, context.Graphics, memento, palette, values, state, displayRect, rtl, contentAdjacentGap, ref allocation, composition);
		AllocateLongTextSpace(context, context.Graphics, memento, palette, values, state, displayRect, rtl, contentAdjacentGap, ref allocation, composition);
		int num = AllocatedTotalWidth(allocation, -1, -1, contentAdjacentGap);
		int num2 = AllocatedTotalHeight(allocation);
		Padding original = palette.GetContentPadding(state);
		PaletteContentStyle contentStyle = palette.GetContentStyle();
		if (contentStyle == PaletteContentStyle.ButtonForm || contentStyle == PaletteContentStyle.ButtonFormClose)
		{
			original = ContentPaddingForButtonForm(original, context, num2);
		}
		switch (orientation)
		{
		case VisualOrientation.Top:
		case VisualOrientation.Bottom:
			return new Size(num + original.Horizontal, num2 + original.Vertical);
		case VisualOrientation.Left:
		case VisualOrientation.Right:
			return new Size(num2 + original.Vertical, num + original.Horizontal);
		default:
			Debug.Assert(condition: false);
			return Size.Empty;
		}
	}

	public override IDisposable LayoutContent(ViewLayoutContext context, Rectangle availableRect, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		Debug.Assert(values != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		Rectangle displayRect = availableRect;
		Padding contentPadding = palette.GetContentPadding(state);
		bool flag = orientation == VisualOrientation.Left || orientation == VisualOrientation.Right;
		if (flag)
		{
			int width = availableRect.Width;
			availableRect.Width = availableRect.Height;
			availableRect.Height = width;
		}
		availableRect.X += contentPadding.Left;
		availableRect.Y += contentPadding.Top;
		availableRect.Width -= contentPadding.Horizontal;
		availableRect.Height -= contentPadding.Vertical;
		if (flag)
		{
			int width2 = displayRect.Width;
			displayRect.Width = displayRect.Height;
			displayRect.Height = width2;
		}
		Size[,] allocation = new Size[3, 3]
		{
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			},
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			},
			{
				Size.Empty,
				Size.Empty,
				Size.Empty
			}
		};
		StandardContentMemento standardContentMemento = new StandardContentMemento();
		int contentAdjacentGap = palette.GetContentAdjacentGap(state);
		RightToLeft rightToLeft = ((!flag) ? context.Control.RightToLeft : RightToLeft.No);
		AllocateImageSpace(standardContentMemento, palette, values, state, availableRect, rightToLeft, ref allocation);
		AllocateShortTextSpace(context, context.Graphics, standardContentMemento, palette, values, state, availableRect, rightToLeft, contentAdjacentGap, ref allocation, composition);
		AllocateLongTextSpace(context, context.Graphics, standardContentMemento, palette, values, state, availableRect, rightToLeft, contentAdjacentGap, ref allocation, composition);
		int[] cells = AllocatedColumnWidths(allocation, -1);
		int[] array = AllocatedRowHeights(allocation);
		int num = AllocatedTotalWidth(allocation, -1, -1, contentAdjacentGap);
		int num2 = AllocatedTotalHeight(allocation);
		if (num < availableRect.Width)
		{
			ApplyExcessSpace(availableRect.Width - num, ref cells);
		}
		if (num2 < availableRect.Height)
		{
			array[1] += availableRect.Height - num2;
		}
		int left = availableRect.Left;
		int num3 = left + cells[0];
		if ((cells[0] > 0 && cells[1] > 0) || (cells[0] > 0 && cells[1] == 0 && cells[2] > 0))
		{
			num3 += contentAdjacentGap;
		}
		int num4 = num3 + cells[1];
		if (cells[1] > 0 && cells[2] > 0)
		{
			num4 += contentAdjacentGap;
		}
		int top = availableRect.Top;
		int num5 = top + array[0];
		int cellY = num5 + array[1];
		PaletteRelativeAlign alignH = ((rightToLeft == RightToLeft.Yes) ? PaletteRelativeAlign.Far : PaletteRelativeAlign.Near);
		PaletteRelativeAlign alignH2 = PaletteRelativeAlign.Center;
		PaletteRelativeAlign alignH3 = ((rightToLeft != RightToLeft.Yes) ? PaletteRelativeAlign.Far : PaletteRelativeAlign.Near);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH, PaletteRelativeAlign.Near, left, top, cells[0], array[0], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH, PaletteRelativeAlign.Center, left, num5, cells[0], array[1], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH, PaletteRelativeAlign.Far, left, cellY, cells[0], array[2], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH2, PaletteRelativeAlign.Near, num3, top, cells[1], array[0], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH2, PaletteRelativeAlign.Center, num3, num5, cells[1], array[1], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH2, PaletteRelativeAlign.Far, num3, cellY, cells[1], array[2], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH3, PaletteRelativeAlign.Near, num4, top, cells[2], array[0], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH3, PaletteRelativeAlign.Center, num4, num5, cells[2], array[1], contentAdjacentGap);
		PositionAlignContent(standardContentMemento, palette, state, rightToLeft, alignH3, PaletteRelativeAlign.Far, num4, cellY, cells[2], array[2], contentAdjacentGap);
		standardContentMemento.AdjustForOrientation(orientation, displayRect);
		return standardContentMemento;
	}

	public override void DrawContent(RenderContext context, Rectangle displayRect, IPaletteContent palette, IDisposable memento, VisualOrientation orientation, PaletteState state, bool composition, bool allowFocusRect)
	{
		Debug.Assert(context != null);
		Debug.Assert(memento != null);
		Debug.Assert(memento is StandardContentMemento);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
		if (standardContentMemento.DrawImage)
		{
			RenderBase.DrawImageHelper(context, standardContentMemento.Image, standardContentMemento.ImageTransparentColor, standardContentMemento.ImageRect, orientation, palette.GetContentImageEffect(state), palette.GetContentImageColorMap(state), palette.GetContentImageColorTo(state));
		}
		if (standardContentMemento.DrawShortText)
		{
			using (new GraphicsTextHint(context.Graphics, standardContentMemento.ShortTextHint))
			{
				Rectangle alignedRectangle = context.GetAlignedRectangle(palette.GetContentShortTextColorAlign(state), standardContentMemento.ShortTextRect);
				Color contentShortTextColor = palette.GetContentShortTextColor1(state);
				PaletteColorStyle contentShortTextColorStyle = palette.GetContentShortTextColorStyle(state);
				using (Brush brush = CreateColorBrush(alignedRectangle, contentShortTextColor, palette.GetContentShortTextColor2(state), contentShortTextColorStyle, palette.GetContentShortTextColorAngle(state), orientation))
				{
					if (!AccurateText.DrawString(context.Graphics, brush, standardContentMemento.ShortTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.ShortTextMemento))
					{
						standardContentMemento.ShortTextMemento.Font = palette.GetContentShortTextNewFont(state);
						AccurateText.DrawString(context.Graphics, brush, standardContentMemento.ShortTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.ShortTextMemento);
					}
				}
				Image contentShortTextImage = palette.GetContentShortTextImage(state);
				PaletteImageStyle contentShortTextImageStyle = palette.GetContentShortTextImageStyle(state);
				if (ShouldDrawImage(contentShortTextImage))
				{
					Rectangle alignedRectangle2 = context.GetAlignedRectangle(palette.GetContentShortTextImageAlign(state), standardContentMemento.ShortTextRect);
					using Brush brush2 = CreateImageBrush(alignedRectangle2, contentShortTextImage, contentShortTextImageStyle);
					if (!AccurateText.DrawString(context.Graphics, brush2, standardContentMemento.ShortTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.ShortTextMemento))
					{
						standardContentMemento.ShortTextMemento.Font = palette.GetContentShortTextNewFont(state);
						AccurateText.DrawString(context.Graphics, brush2, standardContentMemento.ShortTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.ShortTextMemento);
					}
				}
			}
		}
		if (standardContentMemento.DrawLongText)
		{
			using (new GraphicsTextHint(context.Graphics, standardContentMemento.LongTextHint))
			{
				Rectangle alignedRectangle3 = context.GetAlignedRectangle(palette.GetContentLongTextColorAlign(state), standardContentMemento.LongTextRect);
				Color contentLongTextColor = palette.GetContentLongTextColor1(state);
				PaletteColorStyle contentLongTextColorStyle = palette.GetContentLongTextColorStyle(state);
				using (Brush brush3 = CreateColorBrush(alignedRectangle3, contentLongTextColor, palette.GetContentLongTextColor2(state), contentLongTextColorStyle, palette.GetContentLongTextColorAngle(state), orientation))
				{
					if (!AccurateText.DrawString(context.Graphics, brush3, standardContentMemento.LongTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.LongTextMemento))
					{
						standardContentMemento.LongTextMemento.Font = palette.GetContentLongTextNewFont(state);
						AccurateText.DrawString(context.Graphics, brush3, standardContentMemento.LongTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.LongTextMemento);
					}
				}
				Image contentLongTextImage = palette.GetContentLongTextImage(state);
				PaletteImageStyle contentLongTextImageStyle = palette.GetContentLongTextImageStyle(state);
				if (ShouldDrawImage(contentLongTextImage))
				{
					Rectangle alignedRectangle4 = context.GetAlignedRectangle(palette.GetContentLongTextImageAlign(state), standardContentMemento.LongTextRect);
					using Brush brush4 = CreateImageBrush(alignedRectangle4, contentLongTextImage, contentLongTextImageStyle);
					if (!AccurateText.DrawString(context.Graphics, brush4, standardContentMemento.LongTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.LongTextMemento))
					{
						standardContentMemento.LongTextMemento.Font = palette.GetContentLongTextNewFont(state);
						AccurateText.DrawString(context.Graphics, brush4, standardContentMemento.LongTextRect, context.Control.RightToLeft, standardContentMemento.Orientation, composition, state, standardContentMemento.LongTextMemento);
					}
				}
			}
		}
		if (allowFocusRect && palette.GetContentDrawFocus(state) == InheritBool.True)
		{
			displayRect.Inflate(-1, -1);
			ControlPaint.DrawFocusRectangle(context.Graphics, displayRect);
		}
	}

	public override bool GetContentImageDisplayed(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.DrawImage;
		}
		return false;
	}

	public override Rectangle GetContentImageRectangle(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.ImageRect;
		}
		return Rectangle.Empty;
	}

	public override bool GetContentShortTextDisplayed(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.DrawShortText;
		}
		return false;
	}

	public override Rectangle GetContentShortTextRectangle(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.ShortTextRect;
		}
		return Rectangle.Empty;
	}

	public override bool GetContentLongTextDisplayed(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.DrawLongText;
		}
		return false;
	}

	public override Rectangle GetContentLongTextRectangle(IDisposable memento)
	{
		if (memento != null)
		{
			StandardContentMemento standardContentMemento = (StandardContentMemento)memento;
			return standardContentMemento.LongTextRect;
		}
		return Rectangle.Empty;
	}

	public override bool GetTabBorderLeftDrawing(TabBorderStyle tabBorderStyle)
	{
		if (tabBorderStyle == TabBorderStyle.OneNote)
		{
			return false;
		}
		return true;
	}

	public override int GetTabBorderSpacingGap(TabBorderStyle tabBorderStyle)
	{
		switch (tabBorderStyle)
		{
		case TabBorderStyle.SquareEqualSmall:
		case TabBorderStyle.DockEqual:
			return _spacingTabSquareEqualSmall;
		case TabBorderStyle.SquareEqualMedium:
			return _spacingTabSquareEqualMedium;
		case TabBorderStyle.SquareEqualLarge:
			return _spacingTabSquareEqualLarge;
		case TabBorderStyle.SquareOutsizeSmall:
		case TabBorderStyle.DockOutsize:
			return _spacingTabSquareOutsizeSmall;
		case TabBorderStyle.SquareOutsizeMedium:
			return _spacingTabSquareOutsizeMedium;
		case TabBorderStyle.SquareOutsizeLarge:
			return _spacingTabSquareOutsizeLarge;
		case TabBorderStyle.RoundedEqualSmall:
			return _spacingTabRoundedEqualSmall;
		case TabBorderStyle.RoundedEqualMedium:
			return _spacingTabRoundedEqualMedium;
		case TabBorderStyle.RoundedEqualLarge:
			return _spacingTabRoundedEqualLarge;
		case TabBorderStyle.RoundedOutsizeSmall:
			return _spacingTabRoundedOutsizeSmall;
		case TabBorderStyle.RoundedOutsizeMedium:
			return _spacingTabRoundedOutsizeMedium;
		case TabBorderStyle.RoundedOutsizeLarge:
			return _spacingTabRoundedOutsizeLarge;
		case TabBorderStyle.SlantEqualNear:
		case TabBorderStyle.SlantEqualFar:
			return _spacingTabSlantEqual;
		case TabBorderStyle.SlantOutsizeNear:
		case TabBorderStyle.SlantOutsizeFar:
			return _spacingTabSlantOutsize;
		case TabBorderStyle.SlantEqualBoth:
			return _spacingTabSlantEqualBoth;
		case TabBorderStyle.SlantOutsizeBoth:
			return _spacingTabSlantOutsize * 2;
		case TabBorderStyle.OneNote:
			return _spacingTabOneNote;
		case TabBorderStyle.SmoothEqual:
			return _spacingTabSmoothE;
		case TabBorderStyle.SmoothOutsize:
			return _spacingTabSmoothO;
		default:
			Debug.Assert(condition: false);
			return 1;
		}
	}

	public override Padding GetTabBorderDisplayPadding(ViewLayoutContext context, IPaletteBorder palette, PaletteState state, VisualOrientation orientation, TabBorderStyle tabBorderStyle)
	{
		Debug.Assert(palette != null);
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		int borderWidth = palette.GetBorderWidth(state);
		bool flag = context.Control.RightToLeft == RightToLeft.Yes;
		Padding result = Padding.Empty;
		int num4;
		int num7;
		int num5;
		int num6;
		int num8;
		int num9;
		switch (tabBorderStyle)
		{
		case TabBorderStyle.SquareEqualSmall:
		case TabBorderStyle.SquareEqualMedium:
		case TabBorderStyle.SquareEqualLarge:
		case TabBorderStyle.RoundedEqualSmall:
		case TabBorderStyle.RoundedEqualMedium:
		case TabBorderStyle.RoundedEqualLarge:
		case TabBorderStyle.DockEqual:
			result = new Padding(borderWidth, borderWidth, borderWidth, 0);
			break;
		case TabBorderStyle.DockOutsize:
			result = new Padding(borderWidth + _spacingTabDockOutsize, borderWidth + _spacingTabSquareOutsizeLarge, borderWidth + _spacingTabDockOutsize, 0);
			break;
		case TabBorderStyle.SquareOutsizeSmall:
		case TabBorderStyle.SquareOutsizeMedium:
		case TabBorderStyle.SquareOutsizeLarge:
		case TabBorderStyle.RoundedOutsizeSmall:
		case TabBorderStyle.RoundedOutsizeMedium:
		case TabBorderStyle.RoundedOutsizeLarge:
			result = new Padding(borderWidth + _spacingTabOutsizePadding, borderWidth + _spacingTabOutsizePadding, borderWidth + _spacingTabOutsizePadding, 0);
			break;
		case TabBorderStyle.SlantEqualNear:
			num4 = 0;
			goto IL_010d;
		case TabBorderStyle.SlantOutsizeNear:
			num4 = _spacingTabOutsizePadding;
			goto IL_010d;
		case TabBorderStyle.SlantEqualFar:
			num7 = 0;
			goto IL_0208;
		case TabBorderStyle.SlantOutsizeFar:
			num7 = _spacingTabOutsizePadding;
			goto IL_0208;
		case TabBorderStyle.SlantEqualBoth:
			num5 = 0;
			goto IL_0303;
		case TabBorderStyle.SlantOutsizeBoth:
			num5 = _spacingTabOutsizePadding;
			goto IL_0303;
		case TabBorderStyle.OneNote:
		{
			bool flag2 = state == PaletteState.CheckedNormal || state == PaletteState.CheckedPressed || state == PaletteState.CheckedTracking;
			int num = (flag2 ? _spacingTabOneNoteLPS : _spacingTabOneNoteLPI);
			int num2 = (flag2 ? _spacingTabOneNoteTPS : _spacingTabOneNoteTPI);
			int bottom = (flag2 ? _spacingTabOneNoteBPS : _spacingTabOneNoteBPI);
			int num3 = (flag2 ? _spacingTabOneNoteRPS : _spacingTabOneNoteRPI);
			switch (orientation)
			{
			case VisualOrientation.Top:
				result = ((!flag) ? new Padding(borderWidth + num, borderWidth + num2, borderWidth + num3, bottom) : new Padding(borderWidth + num3, borderWidth + num2, borderWidth + num, bottom));
				break;
			case VisualOrientation.Left:
				result = new Padding(borderWidth + num3, borderWidth + num2, borderWidth + num, bottom);
				break;
			case VisualOrientation.Right:
				result = new Padding(borderWidth + num, borderWidth + num2, borderWidth + num3, bottom);
				break;
			case VisualOrientation.Bottom:
				result = ((!flag) ? new Padding(borderWidth + num3, borderWidth + num2, borderWidth + num, bottom) : new Padding(borderWidth + num, borderWidth + num2, borderWidth + num3, bottom));
				break;
			}
			break;
		}
		case TabBorderStyle.SmoothEqual:
			result = new Padding(borderWidth + _spacingTabSmoothLRE, borderWidth + _spacingTabSmoothTE, borderWidth + _spacingTabSmoothLRE, 0);
			break;
		case TabBorderStyle.SmoothOutsize:
			result = new Padding(borderWidth + _spacingTabSmoothLRO, borderWidth + _spacingTabSmoothTO, borderWidth + _spacingTabSmoothLRO, 0);
			break;
		default:
			{
				Debug.Assert(condition: false);
				break;
			}
			IL_0303:
			num6 = num5;
			result = new Padding(borderWidth + num6 + _spacingTabSlantPadding - 1, borderWidth + num6, borderWidth + num6 + _spacingTabSlantPadding - 1, 0);
			break;
			IL_0208:
			num8 = num7;
			switch (orientation)
			{
			case VisualOrientation.Top:
				result = ((!flag) ? new Padding(borderWidth + num8, borderWidth + num8, borderWidth + num8 + _spacingTabSlantPadding - 1, 0) : new Padding(borderWidth + num8 + _spacingTabSlantPadding - 1, borderWidth + num8, borderWidth + num8, 0));
				break;
			case VisualOrientation.Left:
				result = new Padding(borderWidth + num8, borderWidth + num8, borderWidth + num8 + _spacingTabSlantPadding - 1, 0);
				break;
			case VisualOrientation.Right:
				result = new Padding(borderWidth + num8 + _spacingTabSlantPadding - 1, borderWidth + num8, borderWidth + num8, 0);
				break;
			case VisualOrientation.Bottom:
				result = ((!flag) ? new Padding(borderWidth + num8 + _spacingTabSlantPadding - 1, borderWidth + num8, borderWidth + num8, 0) : new Padding(borderWidth + num8, borderWidth + num8, borderWidth + num8 + _spacingTabSlantPadding - 1, 0));
				break;
			}
			break;
			IL_010d:
			num9 = num4;
			switch (orientation)
			{
			case VisualOrientation.Top:
				result = ((!flag) ? new Padding(borderWidth + num9 + _spacingTabSlantPadding - 1, borderWidth + num9, borderWidth + num9, 0) : new Padding(borderWidth + num9, borderWidth + num9, borderWidth + num9 + _spacingTabSlantPadding - 1, 0));
				break;
			case VisualOrientation.Left:
				result = new Padding(borderWidth + num9 + _spacingTabSlantPadding - 1, borderWidth + num9, borderWidth + num9, 0);
				break;
			case VisualOrientation.Right:
				result = new Padding(borderWidth + num9, borderWidth + num9, borderWidth + num9 + _spacingTabSlantPadding - 1, 0);
				break;
			case VisualOrientation.Bottom:
				result = ((!flag) ? new Padding(borderWidth + num9, borderWidth + num9, borderWidth + num9 + _spacingTabSlantPadding - 1, 0) : new Padding(borderWidth + num9 + _spacingTabSlantPadding - 1, borderWidth + num9, borderWidth + num9, 0));
				break;
			}
			break;
		}
		return result;
	}

	public override GraphicsPath GetTabBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		return CreateTabBorderBackPath(context.Control.RightToLeft, state, forBorder: false, rect, palette.GetBorderWidth(state), tabBorderStyle, orientation, palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias);
	}

	public override GraphicsPath GetTabBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		return CreateTabBorderBackPath(context.Control.RightToLeft, state, forBorder: false, rect, palette.GetBorderWidth(state), tabBorderStyle, orientation, palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias);
	}

	public override void DrawTabBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		if (rect.Width <= 0 || rect.Height <= 0)
		{
			return;
		}
		using (new GraphicsHint(context.Graphics, palette.GetBorderGraphicsHint(state)))
		{
			int borderWidth = palette.GetBorderWidth(state);
			if (borderWidth <= 0)
			{
				return;
			}
			using GraphicsPath path = CreateTabBorderBackPath(context.Control.RightToLeft, state, forBorder: true, rect, borderWidth, tabBorderStyle, orientation, palette.GetBorderGraphicsHint(state) == PaletteGraphicsHint.AntiAlias);
			Rectangle alignedRectangle = context.GetAlignedRectangle(palette.GetBorderColorAlign(state), rect);
			using (Brush brush = CreateColorBrush(alignedRectangle, palette.GetBorderColor1(state), palette.GetBorderColor2(state), palette.GetBorderColorStyle(state), palette.GetBorderColorAngle(state), orientation))
			{
				using Pen pen = new Pen(brush, borderWidth);
				context.Graphics.DrawPath(pen, path);
			}
			Image borderImage = palette.GetBorderImage(state);
			if (ShouldDrawImage(borderImage))
			{
				Rectangle alignedRectangle2 = context.GetAlignedRectangle(palette.GetBorderImageAlign(state), rect);
				PaletteImageStyle borderImageStyle = palette.GetBorderImageStyle(state);
				using Pen pen2 = new Pen(CreateImageBrush(alignedRectangle2, borderImage, borderImageStyle), borderWidth);
				context.Graphics.DrawPath(pen2, path);
				return;
			}
		}
	}

	public override IDisposable DrawRibbonBack(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, bool composition, IDisposable memento)
	{
		bool flag = (state & PaletteState.FocusOverride) == PaletteState.FocusOverride;
		if (flag)
		{
			state &= ~PaletteState.FocusOverride;
		}
		switch (palette.GetRibbonBackColorStyle(state))
		{
		case PaletteRibbonColorStyle.Solid:
		{
			using (SolidBrush brush = new SolidBrush(palette.GetRibbonBackColor1(state)))
			{
				context.Graphics.FillRectangle(brush, rect);
			}
			break;
		}
		case PaletteRibbonColorStyle.Linear:
			return DrawRibbonLinear(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.LinearBorder:
			return DrawRibbonLinearBorder(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonAppMenuInner:
			return DrawRibbonAppMenuInner(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonAppMenuOuter:
			return DrawRibbonAppMenuOuter(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonQATFullbarRound:
			return DrawRibbonQATFullbarRound(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonQATFullbarSquare:
			return DrawRibbonQATFullbarSquare(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonQATMinibarSingle:
			return DrawRibbonQATMinibarSingle(context, rect, state, palette, composition, memento);
		case PaletteRibbonColorStyle.RibbonQATMinibarDouble:
			return DrawRibbonQATMinibarDouble(context, rect, state, palette, composition, memento);
		case PaletteRibbonColorStyle.RibbonQATOverflow:
			return DrawRibbonQATOverflow(shape, context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonGroupGradientOne:
			return DrawRibbonGroupGradientOne(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonGroupGradientTwo:
			return DrawRibbonGroupGradientTwo(context, rect, state, palette, _groupGradientTwo, memento);
		case PaletteRibbonColorStyle.RibbonGroupCollapsedBorder:
			return DrawRibbonGroupCollapsedBorder(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonGroupCollapsedFrameBorder:
			return DrawRibbonGroupCollapsedFrameBorder(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonGroupCollapsedFrameBack:
			return DrawRibbonGroupGradientTwo(context, rect, state, palette, _groupGradientFrame, memento);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorder:
			return DrawRibbonGroupNormalBorder(context, rect, state, palette, tracking: false, lightInside: false, memento);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderSep:
			return DrawRibbonGroupNormalBorderSep(flag, context, rect, state, palette, memento, pressed: false, tracking: false, dark: false);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderSepPressedLight:
			return DrawRibbonGroupNormalBorderSep(flag, context, rect, state, palette, memento, pressed: true, tracking: false, dark: false);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderSepPressedDark:
			return DrawRibbonGroupNormalBorderSep(flag, context, rect, state, palette, memento, pressed: true, tracking: false, dark: true);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderSepTrackingLight:
			return DrawRibbonGroupNormalBorderSep(flag, context, rect, state, palette, memento, pressed: false, tracking: true, dark: false);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderSepTrackingDark:
			return DrawRibbonGroupNormalBorderSep(flag, context, rect, state, palette, memento, pressed: false, tracking: true, dark: true);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderTracking:
			return DrawRibbonGroupNormalBorder(context, rect, state, palette, tracking: true, lightInside: false, memento);
		case PaletteRibbonColorStyle.RibbonGroupNormalBorderTrackingLight:
			return DrawRibbonGroupNormalBorder(context, rect, state, palette, tracking: true, lightInside: true, memento);
		case PaletteRibbonColorStyle.RibbonGroupNormalTitle:
			return DrawRibbonGroupNormalTitle(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonGroupAreaBorder:
			return DrawRibbonGroupAreaBorder1And2(context, rect, state, palette, limited: false, fading: false, memento);
		case PaletteRibbonColorStyle.RibbonGroupAreaBorder2:
			return DrawRibbonGroupAreaBorder1And2(context, rect, state, palette, limited: true, fading: false, memento);
		case PaletteRibbonColorStyle.RibbonGroupAreaBorder3:
			return DrawRibbonGroupAreaBorder3And4(context, rect, state, palette, memento, gradientTop: true);
		case PaletteRibbonColorStyle.RibbonGroupAreaBorder4:
			return DrawRibbonGroupAreaBorder3And4(context, rect, state, palette, memento, gradientTop: false);
		case PaletteRibbonColorStyle.RibbonGroupAreaBorderContext:
			return DrawRibbonGroupAreaBorderContext(context, rect, state, palette, memento);
		case PaletteRibbonColorStyle.RibbonTabTracking2007:
			return DrawRibbonTabTracking2007(shape, context, rect, state, palette, orientation, memento);
		case PaletteRibbonColorStyle.RibbonTabFocus2010:
			return DrawRibbonTabFocus2010(shape, context, rect, state, palette, orientation, memento);
		case PaletteRibbonColorStyle.RibbonTabTracking2010:
			return DrawRibbonTabTracking2010(shape, context, rect, state, palette, orientation, memento, standard: true);
		case PaletteRibbonColorStyle.RibbonTabTracking2010Alt:
			return DrawRibbonTabTracking2010(shape, context, rect, state, palette, orientation, memento, standard: false);
		case PaletteRibbonColorStyle.RibbonTabGlowing:
			return DrawRibbonTabGlowing(shape, context, rect, state, palette, orientation, memento);
		case PaletteRibbonColorStyle.RibbonTabHighlight:
			return DrawRibbonTabHighlight(shape, context, rect, state, palette, orientation, memento, alternate: false);
		case PaletteRibbonColorStyle.RibbonTabHighlight2:
			return DrawRibbonTabHighlight(shape, context, rect, state, palette, orientation, memento, alternate: true);
		case PaletteRibbonColorStyle.RibbonTabSelected2007:
			return DrawRibbonTabSelected2007(context, rect, state, palette, orientation, memento);
		case PaletteRibbonColorStyle.RibbonTabSelected2010:
			return DrawRibbonTabSelected2010(context, rect, state, palette, orientation, memento, standard: true);
		case PaletteRibbonColorStyle.RibbonTabSelected2010Alt:
			return DrawRibbonTabSelected2010(context, rect, state, palette, orientation, memento, standard: false);
		case PaletteRibbonColorStyle.RibbonTabContextSelected:
			return DrawRibbonTabContextSelected(shape, context, rect, state, palette, orientation, memento);
		default:
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonColorStyle.Empty:
			break;
		}
		return null;
	}

	public override IDisposable DrawRibbonTabContextTitle(PaletteRibbonShape shape, RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento)
	{
		return DrawRibbonTabContext(context, rect, paletteGeneral, paletteBack, memento);
	}

	public override IDisposable DrawRibbonApplicationButton(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		return DrawRibbonAppButton(shape, context, rect, state, palette, trackBorderAsPressed: false, memento);
	}

	public override IDisposable DrawRibbonApplicationTab(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, Color baseColor1, Color baseColor2, IDisposable memento)
	{
		return DrawRibbonAppTab(shape, context, rect, state, baseColor1, baseColor2, memento);
	}

	public override void DrawRibbonClusterEdge(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteBack != null);
		using SolidBrush brush = new SolidBrush(paletteBack.GetBackColor1(state));
		context.Graphics.FillRectangle(brush, displayRect);
	}

	public override void DrawSeparator(RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, IPaletteBorder paletteBorder, Orientation orientation, PaletteState state, bool canMove)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteBack != null);
		Debug.Assert(paletteBorder != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteBack == null)
		{
			throw new ArgumentNullException("paletteBack");
		}
		if (paletteBorder == null)
		{
			throw new ArgumentNullException("paletteBorder");
		}
		Debug.Assert(context.Control != null);
		Debug.Assert(!context.Control.IsDisposed);
		if (paletteBack.GetBackDraw(state) == InheritBool.True)
		{
			VisualOrientation orientation2 = ((orientation != Orientation.Horizontal) ? VisualOrientation.Left : VisualOrientation.Top);
			using GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, displayRect, paletteBorder, orientation2, state);
			Padding borderRawPadding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(paletteBorder, state, orientation2);
			Rectangle rect = CommonHelper.ApplyPadding(orientation2, displayRect, borderRawPadding);
			VisualOrientation orientation3 = ((orientation != Orientation.Horizontal) ? VisualOrientation.Left : VisualOrientation.Top);
			context.Renderer.RenderStandardBack.DrawBack(context, rect, path, paletteBack, orientation3, state, null);
		}
		if (paletteBorder.GetBorderDraw(state) == InheritBool.True)
		{
			VisualOrientation orientation4 = ((orientation != Orientation.Horizontal) ? VisualOrientation.Left : VisualOrientation.Top);
			context.Renderer.RenderStandardBorder.DrawBorder(context, displayRect, paletteBorder, orientation4, state);
		}
	}

	public override Size GetCheckBoxPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Image checkBoxImage = palette.GetCheckBoxImage(enabled, checkState, tracking, pressed);
		if (checkBoxImage == null)
		{
			CheckBoxState state = DiscoverCheckBoxState(enabled, checkState, tracking, pressed);
			return CheckBoxRenderer.GetGlyphSize(context.Graphics, state);
		}
		return checkBoxImage.Size;
	}

	public override void DrawCheckBox(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Image checkBoxImage = palette.GetCheckBoxImage(enabled, checkState, tracking, pressed);
		if (checkBoxImage == null)
		{
			CheckBoxState state = DiscoverCheckBoxState(enabled, checkState, tracking, pressed);
			CheckBoxRenderer.DrawCheckBox(context.Graphics, displayRect.Location, state);
		}
		else
		{
			int num = (displayRect.Width - checkBoxImage.Width) / 2;
			int num2 = (displayRect.Height - checkBoxImage.Height) / 2;
			context.Graphics.DrawImage(checkBoxImage, displayRect.X + num, displayRect.Y + num2, checkBoxImage.Width, checkBoxImage.Height);
		}
	}

	public override Size GetRadioButtonPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed)
	{
		Image radioButtonImage = palette.GetRadioButtonImage(enabled, checkState, tracking, pressed);
		if (radioButtonImage == null)
		{
			RadioButtonState state = DiscoverRadioButtonState(enabled, checkState, tracking, pressed);
			return RadioButtonRenderer.GetGlyphSize(context.Graphics, state);
		}
		return radioButtonImage.Size;
	}

	public override void DrawRadioButton(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Image radioButtonImage = palette.GetRadioButtonImage(enabled, checkState, tracking, pressed);
		if (radioButtonImage == null)
		{
			RadioButtonState state = DiscoverRadioButtonState(enabled, checkState, tracking, pressed);
			RadioButtonRenderer.DrawRadioButton(context.Graphics, displayRect.Location, state);
		}
		else
		{
			int num = (displayRect.Width - radioButtonImage.Width) / 2;
			int num2 = (displayRect.Height - radioButtonImage.Height) / 2;
			context.Graphics.DrawImage(radioButtonImage, displayRect.X + num, displayRect.Y + num2, radioButtonImage.Width, radioButtonImage.Height);
		}
	}

	public override Size GetDropDownButtonPreferredSize(ViewLayoutContext context, IPalette palette, PaletteState state, VisualOrientation orientation)
	{
		Image dropDownButtonImage = palette.GetDropDownButtonImage(state);
		Size result = Size.Empty;
		if (dropDownButtonImage != null)
		{
			result = dropDownButtonImage.Size;
		}
		if (orientation == VisualOrientation.Left || orientation == VisualOrientation.Right)
		{
			result = new Size(result.Height, result.Width);
		}
		return result;
	}

	public override void DrawDropDownButton(RenderContext context, Rectangle displayRect, IPalette palette, PaletteState state, VisualOrientation orientation)
	{
		Debug.Assert(context != null);
		Debug.Assert(palette != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Image dropDownButtonImage = palette.GetDropDownButtonImage(state);
		if (dropDownButtonImage != null)
		{
			RenderBase.DrawImageHelper(context, dropDownButtonImage, Color.Empty, displayRect, orientation, PaletteImageEffect.Normal, Color.Empty, Color.Empty);
		}
	}

	public override void DrawInputControlNumericUpGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		Color contentShortTextColor2 = paletteContent.GetContentShortTextColor2(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		using Pen pen2 = new Pen(contentShortTextColor2);
		context.Graphics.DrawLine(pen, num, num2 + 3, num + 4, num2 + 3);
		context.Graphics.DrawLine(pen, num + 1, num2 + 2, num + 3, num2 + 2);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
		context.Graphics.DrawLine(pen2, num + 2, num2, num + 4, num2 + 2);
		context.Graphics.DrawLine(pen2, num + 2, num2, num, num2 + 2);
	}

	public override void DrawInputControlNumericDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		Color contentShortTextColor2 = paletteContent.GetContentShortTextColor2(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		using Pen pen2 = new Pen(contentShortTextColor2);
		context.Graphics.DrawLine(pen, num, num2, num + 4, num2);
		context.Graphics.DrawLine(pen, num + 1, num2 + 1, num + 3, num2 + 1);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
		context.Graphics.DrawLine(pen2, num, num2 + 1, num + 2, num2 + 3);
		context.Graphics.DrawLine(pen2, num + 2, num2 + 3, num + 4, num2 + 1);
	}

	public override void DrawInputControlDropDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		Color contentShortTextColor2 = paletteContent.GetContentShortTextColor2(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		using Pen pen2 = new Pen(contentShortTextColor2);
		context.Graphics.DrawLine(pen, num, num2, num + 4, num2);
		context.Graphics.DrawLine(pen, num + 1, num2 + 1, num + 3, num2 + 1);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
		context.Graphics.DrawLine(pen2, num, num2 + 1, num + 2, num2 + 3);
		context.Graphics.DrawLine(pen2, num + 2, num2 + 3, num + 4, num2 + 1);
	}

	public override void DrawRibbonDialogBoxLauncher(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		if (shape == PaletteRibbonShape.Office2007 || shape != PaletteRibbonShape.Office2010)
		{
			using (Pen pen = new Pen(paletteGeneral.GetRibbonGroupDialogDark(state)))
			{
				using Pen pen2 = new Pen(paletteGeneral.GetRibbonGroupDialogLight(state));
				context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top + 5, displayRect.Left, displayRect.Top);
				context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top, displayRect.Left + 5, displayRect.Top);
				context.Graphics.DrawLine(pen2, displayRect.Left + 1, displayRect.Top + 5, displayRect.Left + 1, displayRect.Top + 1);
				context.Graphics.DrawLine(pen2, displayRect.Left + 1, displayRect.Top + 1, displayRect.Left + 5, displayRect.Top + 1);
				context.Graphics.DrawLine(pen2, displayRect.Right - 1, displayRect.Bottom - 5, displayRect.Right - 1, displayRect.Bottom - 1);
				context.Graphics.DrawLine(pen2, displayRect.Right - 1, displayRect.Bottom - 1, displayRect.Right - 4, displayRect.Bottom - 1);
				context.Graphics.DrawLine(pen2, displayRect.Right - 1, displayRect.Bottom - 1, displayRect.Right - 4, displayRect.Bottom - 5);
				context.Graphics.DrawLine(pen, displayRect.Right - 5, displayRect.Bottom - 2, displayRect.Right - 2, displayRect.Bottom - 2);
				context.Graphics.DrawLine(pen, displayRect.Right - 4, displayRect.Bottom - 3, displayRect.Right - 3, displayRect.Bottom - 3);
				context.Graphics.DrawLine(pen, displayRect.Right - 2, displayRect.Bottom - 2, displayRect.Right - 2, displayRect.Bottom - 5);
				context.Graphics.DrawLine(pen, displayRect.Right - 3, displayRect.Bottom - 3, displayRect.Right - 3, displayRect.Bottom - 4);
				context.Graphics.DrawLine(pen, displayRect.Right - 5, displayRect.Bottom - 5, displayRect.Right - 3, displayRect.Bottom - 3);
				return;
			}
		}
		LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(displayRect.X - 1, displayRect.Y - 1, displayRect.Width + 2, displayRect.Height + 2), paletteGeneral.GetRibbonGroupDialogLight(state), paletteGeneral.GetRibbonGroupDialogDark(state), 45f);
		using Pen pen3 = new Pen(brush);
		context.Graphics.DrawLine(pen3, displayRect.Left, displayRect.Top + 5, displayRect.Left, displayRect.Top);
		context.Graphics.DrawLine(pen3, displayRect.Left, displayRect.Top, displayRect.Left + 5, displayRect.Top);
		context.Graphics.DrawLine(pen3, displayRect.Right - 5, displayRect.Bottom - 2, displayRect.Right - 2, displayRect.Bottom - 2);
		context.Graphics.DrawLine(pen3, displayRect.Right - 4, displayRect.Bottom - 3, displayRect.Right - 3, displayRect.Bottom - 3);
		context.Graphics.DrawLine(pen3, displayRect.Right - 2, displayRect.Bottom - 2, displayRect.Right - 2, displayRect.Bottom - 5);
		context.Graphics.DrawLine(pen3, displayRect.Right - 3, displayRect.Bottom - 3, displayRect.Right - 3, displayRect.Bottom - 4);
		context.Graphics.DrawLine(pen3, displayRect.Right - 5, displayRect.Bottom - 5, displayRect.Right - 3, displayRect.Bottom - 3);
	}

	public override void DrawRibbonDropArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		Color color = ((state == PaletteState.Disabled) ? paletteGeneral.GetRibbonDisabledDark(state) : paletteGeneral.GetRibbonDropArrowDark(state));
		Color color2 = ((state == PaletteState.Disabled) ? paletteGeneral.GetRibbonDisabledLight(state) : paletteGeneral.GetRibbonDropArrowLight(state));
		if (shape == PaletteRibbonShape.Office2007 || shape != PaletteRibbonShape.Office2010)
		{
			using (Pen pen = new Pen(color))
			{
				using Pen pen2 = new Pen(color2);
				context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top, displayRect.Left + 4, displayRect.Top);
				context.Graphics.DrawLine(pen, displayRect.Left + 1, displayRect.Top + 1, displayRect.Left + 3, displayRect.Top + 1);
				context.Graphics.DrawLine(pen, displayRect.Left + 2, displayRect.Top + 1, displayRect.Left + 2, displayRect.Top + 2);
				context.Graphics.DrawLine(pen2, displayRect.Left, displayRect.Top + 1, displayRect.Left + 2, displayRect.Top + 3);
				context.Graphics.DrawLine(pen2, displayRect.Left + 2, displayRect.Top + 3, displayRect.Left + 4, displayRect.Top + 1);
				return;
			}
		}
		using LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(displayRect.X - 1, displayRect.Y - 1, displayRect.Width + 2, displayRect.Height + 2), color2, color, 45f);
		context.Graphics.FillPolygon(brush, new Point[3]
		{
			new Point(displayRect.Left - 1, displayRect.Top - 1),
			new Point(displayRect.Left + 2, displayRect.Top + 3),
			new Point(displayRect.Left + 5, displayRect.Top)
		});
	}

	public override void DrawRibbonContextArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		Color color = paletteGeneral.GetRibbonQATButtonDark(state);
		Color color2 = paletteGeneral.GetRibbonQATButtonLight(state);
		if (state == PaletteState.Disabled)
		{
			color = CommonHelper.ColorToBlackAndWhite(color);
			color2 = CommonHelper.ColorToBlackAndWhite(color2);
		}
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color2);
		if (shape == PaletteRibbonShape.Office2010)
		{
			context.Graphics.DrawLine(pen, displayRect.Left - 1, displayRect.Top, displayRect.Left + 5, displayRect.Top);
			context.Graphics.DrawLine(pen2, displayRect.Left - 1, displayRect.Top + 1, displayRect.Left + 5, displayRect.Top + 1);
		}
		else
		{
			context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top, displayRect.Left + 4, displayRect.Top);
			context.Graphics.DrawLine(pen2, displayRect.Left, displayRect.Top + 1, displayRect.Left + 4, displayRect.Top + 1);
		}
		context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top + 3, displayRect.Left + 4, displayRect.Top + 3);
		context.Graphics.DrawLine(pen, displayRect.Left + 1, displayRect.Top + 4, displayRect.Left + 3, displayRect.Top + 4);
		context.Graphics.DrawLine(pen, displayRect.Left + 2, displayRect.Top + 4, displayRect.Left + 2, displayRect.Top + 5);
		context.Graphics.DrawLine(pen2, displayRect.Left, displayRect.Top + 4, displayRect.Left + 2, displayRect.Top + 6);
		context.Graphics.DrawLine(pen2, displayRect.Left + 2, displayRect.Top + 6, displayRect.Left + 4, displayRect.Top + 4);
	}

	public override void DrawRibbonOverflow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		Color color = paletteGeneral.GetRibbonQATButtonDark(state);
		Color color2 = paletteGeneral.GetRibbonQATButtonLight(state);
		if (shape == PaletteRibbonShape.Office2010)
		{
			color2 = color;
		}
		if (state == PaletteState.Disabled)
		{
			color = CommonHelper.ColorToBlackAndWhite(color);
			color2 = CommonHelper.ColorToBlackAndWhite(color2);
		}
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color2);
		context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top + 1, displayRect.Left, displayRect.Top + 3);
		context.Graphics.DrawLine(pen, displayRect.Left + 1, displayRect.Top + 2, displayRect.Left, displayRect.Top + 3);
		context.Graphics.DrawLine(pen2, displayRect.Left, displayRect.Top, displayRect.Left + 2, displayRect.Top + 2);
		context.Graphics.DrawLine(pen2, displayRect.Left + 1, displayRect.Top + 3, displayRect.Left, displayRect.Top + 4);
		context.Graphics.DrawLine(pen, displayRect.Left + 4, displayRect.Top + 1, displayRect.Left + 4, displayRect.Top + 3);
		context.Graphics.DrawLine(pen, displayRect.Left + 5, displayRect.Top + 2, displayRect.Left + 4, displayRect.Top + 3);
		context.Graphics.DrawLine(pen2, displayRect.Left + 4, displayRect.Top, displayRect.Left + 6, displayRect.Top + 2);
		context.Graphics.DrawLine(pen2, displayRect.Left + 5, displayRect.Top + 3, displayRect.Left + 4, displayRect.Top + 4);
	}

	public override void DrawRibbonGroupSeparator(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		int num = displayRect.X + (displayRect.Width - 2) / 2;
		Color ribbonGroupSeparatorDark = paletteGeneral.GetRibbonGroupSeparatorDark(state);
		Color ribbonGroupSeparatorLight = paletteGeneral.GetRibbonGroupSeparatorLight(state);
		if (shape == PaletteRibbonShape.Office2007 || shape != PaletteRibbonShape.Office2010)
		{
			using (Pen pen = new Pen(ribbonGroupSeparatorDark))
			{
				using Pen pen2 = new Pen(ribbonGroupSeparatorLight);
				context.Graphics.DrawLine(pen2, num, displayRect.Top + 2, num, displayRect.Bottom - 3);
				context.Graphics.DrawLine(pen, num + 1, displayRect.Top + 2, num + 1, displayRect.Bottom - 3);
				return;
			}
		}
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new RectangleF(displayRect.X, displayRect.Y - 1, displayRect.Width, displayRect.Height + 2), Color.FromArgb(72, ribbonGroupSeparatorDark), ribbonGroupSeparatorDark, 90f);
		using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new RectangleF(displayRect.X - 1, displayRect.Y - 1, displayRect.Width + 2, displayRect.Height + 2), Color.FromArgb(128, ribbonGroupSeparatorLight), ribbonGroupSeparatorLight, 90f);
		linearGradientBrush.SetSigmaBellShape(0.5f);
		linearGradientBrush2.SetSigmaBellShape(0.5f);
		using Pen pen3 = new Pen(linearGradientBrush);
		context.Graphics.FillRectangle(linearGradientBrush2, num, displayRect.Top, 3, displayRect.Height);
		context.Graphics.DrawLine(pen3, num + 1, displayRect.Top, num + 1, displayRect.Bottom - 1);
	}

	public override Rectangle DrawGridSortGlyph(RenderContext context, SortOrder sortOrder, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		Image image = _gridSortOrder.Images[(sortOrder != SortOrder.Ascending) ? 1 : 0];
		if (image.Width < cellRect.Width && image.Height < cellRect.Height)
		{
			int y = cellRect.Top + (cellRect.Height - image.Height) / 2;
			int x = (rtl ? cellRect.X : (cellRect.Right - image.Width));
			Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
			using (ImageAttributes imageAttributes = new ImageAttributes())
			{
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = Color.Black;
				colorMap.NewColor = CommonHelper.MergeColors(contentShortTextColor, 0.75f, Color.Transparent, 0.25f);
				imageAttributes.SetRemapTable(new ColorMap[1] { colorMap }, ColorAdjustType.Bitmap);
				context.Graphics.DrawImage(image, new Rectangle(x, y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
			}
			cellRect.Width -= image.Width;
			if (rtl)
			{
				cellRect.X += image.Width;
			}
		}
		return cellRect;
	}

	public override Rectangle DrawGridRowGlyph(RenderContext context, GridRowGlyph rowGlyph, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		Image image = null;
		switch (rowGlyph)
		{
		case GridRowGlyph.ArrowStar:
			image = _gridRowIndicators.Images[rtl ? 4 : 0];
			break;
		case GridRowGlyph.Star:
			image = _gridRowIndicators.Images[(!rtl) ? 1 : 5];
			break;
		case GridRowGlyph.Pencil:
			image = _gridRowIndicators.Images[rtl ? 6 : 2];
			break;
		case GridRowGlyph.Arrow:
			image = _gridRowIndicators.Images[rtl ? 7 : 3];
			break;
		}
		if (image != null && image.Width < cellRect.Width && image.Height < cellRect.Height)
		{
			int y = cellRect.Top + (cellRect.Height - image.Height) / 2;
			int x = (rtl ? (cellRect.Right - image.Width) : cellRect.Left);
			Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
			using (ImageAttributes imageAttributes = new ImageAttributes())
			{
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = Color.Black;
				colorMap.NewColor = CommonHelper.MergeColors(contentShortTextColor, 0.75f, Color.Transparent, 0.25f);
				imageAttributes.SetRemapTable(new ColorMap[1] { colorMap }, ColorAdjustType.Bitmap);
				context.Graphics.DrawImage(image, new Rectangle(x, y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
			}
			cellRect.Width -= image.Width;
			if (!rtl)
			{
				cellRect.X += image.Width;
			}
		}
		return cellRect;
	}

	public override Rectangle DrawGridErrorGlyph(RenderContext context, Rectangle cellRect, PaletteState state, bool rtl)
	{
		Debug.Assert(context != null);
		Image image = _gridErrorIcon.Images[0];
		if (image.Width < cellRect.Width && image.Height < cellRect.Height)
		{
			int y = cellRect.Top + (cellRect.Height - image.Height) / 2;
			int x = (rtl ? cellRect.Left : (cellRect.Right - image.Width));
			if (state == PaletteState.Disabled)
			{
				ControlPaint.DrawImageDisabled(context.Graphics, image, x, y, Color.Empty);
			}
			else
			{
				context.Graphics.DrawImage(image, x, y);
			}
			cellRect.Width -= image.Width;
			if (rtl)
			{
				cellRect.X += image.Width;
			}
		}
		return cellRect;
	}

	public override void DrawDragDropSolidGlyph(RenderContext context, Rectangle drawRect, IPaletteDragDrop dragDropPalette)
	{
		Debug.Assert(context != null);
		Debug.Assert(dragDropPalette != null);
		using (SolidBrush brush = new SolidBrush(dragDropPalette.GetDragDropSolidBack()))
		{
			context.Graphics.FillRectangle(brush, drawRect);
		}
		using Pen pen = new Pen(dragDropPalette.GetDragDropSolidBorder());
		context.Graphics.DrawRectangle(pen, drawRect);
	}

	public override void MeasureDragDropDockingGlyph(RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback)
	{
		Debug.Assert(dragData != null);
		Debug.Assert(dragDropPalette != null);
		if (feedback == PaletteDragFeedback.Rounded)
		{
			MeasureDragDockingRounded(dragData, dragDropPalette);
		}
		else
		{
			MeasureDragDockingSquares(dragData, dragDropPalette);
		}
	}

	public override void DrawDragDropDockingGlyph(RenderContext context, RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback)
	{
		Debug.Assert(context != null);
		Debug.Assert(dragData != null);
		Debug.Assert(dragDropPalette != null);
		if (feedback == PaletteDragFeedback.Rounded)
		{
			DrawDragDockingRounded(context, dragData, dragDropPalette);
		}
		else
		{
			DrawDragDockingSquares(context, dragData, dragDropPalette);
		}
	}

	public override bool EvalTransparentPaint(IPaletteBack paletteBack, PaletteState state)
	{
		if (paletteBack.GetBackDraw(state) == InheritBool.False)
		{
			return true;
		}
		if (paletteBack.GetBackColor1(state).A < byte.MaxValue)
		{
			return true;
		}
		if (paletteBack.GetBackColorStyle(state) != PaletteColorStyle.Solid && paletteBack.GetBackColor2(state).A < byte.MaxValue)
		{
			return true;
		}
		return false;
	}

	public override bool EvalTransparentPaint(IPaletteBack paletteBack, IPaletteBorder paletteBorder, PaletteState state)
	{
		int borderRounding = paletteBorder.GetBorderRounding(state);
		if (paletteBorder.GetBorderWidth(state) > 0)
		{
			if (paletteBorder.GetBorderDraw(state) == InheritBool.False)
			{
				return true;
			}
			if (paletteBorder.GetBorderRounding(state) > 0)
			{
				return true;
			}
			if (paletteBorder.GetBorderColor1(state).A < byte.MaxValue)
			{
				return true;
			}
			if (paletteBorder.GetBorderColorStyle(state) != PaletteColorStyle.Solid && paletteBorder.GetBorderColor2(state).A < byte.MaxValue)
			{
				return true;
			}
		}
		return EvalTransparentPaint(paletteBack, state);
	}

	public override void DrawTrackTicksGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool topRight, Size positionSize, int minimum, int maximum, int frequency)
	{
		if (frequency <= 0)
		{
			frequency = 1;
		}
		float num = maximum - minimum;
		using Pen pen = new Pen(elementPalette.GetElementColor1(state));
		if (orientation == Orientation.Horizontal)
		{
			int num2 = positionSize.Width / 2;
			drawRect.X += num2;
			drawRect.Width -= positionSize.Width;
			float num3 = ((num == 0f) ? float.MinValue : ((float)drawRect.Width / num));
			float num4 = drawRect.Y + 1;
			float num5 = drawRect.Bottom - 2;
			int num6 = minimum;
			int num7 = 0;
			while (num6 <= maximum)
			{
				float num8 = (float)drawRect.X + num3 * (float)num7;
				if (!topRight)
				{
					num4 = drawRect.Y + 2;
					num5 = drawRect.Bottom - 2;
					if (num6 == minimum || num6 == maximum)
					{
						num4 -= 1f;
					}
				}
				else
				{
					num4 = drawRect.Y + 1;
					num5 = drawRect.Bottom - 3;
					if (num6 == minimum || num6 == maximum)
					{
						num5 += 1f;
					}
				}
				context.Graphics.DrawLine(pen, num8, num4, num8, num5);
				num6 += frequency;
				num7 += frequency;
			}
			return;
		}
		int num9 = positionSize.Height / 2;
		drawRect.Y += num9;
		drawRect.Height -= positionSize.Height;
		float num10 = ((num == 0f) ? float.MinValue : ((float)drawRect.Height / num));
		float num11 = drawRect.X + 1;
		float num12 = drawRect.Right - 2;
		int num13 = minimum;
		int num14 = 0;
		while (num13 <= maximum)
		{
			float num15 = (float)drawRect.Y + num10 * (float)num14;
			if (topRight)
			{
				num11 = drawRect.X + 2;
				num12 = drawRect.Right - 2;
				if (num13 == minimum || num13 == maximum)
				{
					num11 -= 1f;
				}
			}
			else
			{
				num11 = drawRect.X + 1;
				num12 = drawRect.Right - 3;
				if (num13 == minimum || num13 == maximum)
				{
					num12 += 1f;
				}
			}
			context.Graphics.DrawLine(pen, num11, num15, num12, num15);
			num13 += frequency;
			num14 += frequency;
		}
	}

	public override void DrawTrackGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool volumeControl)
	{
		if (orientation == Orientation.Horizontal)
		{
			drawRect.Inflate(-1, 0);
		}
		else
		{
			drawRect.Inflate(0, -1);
		}
		using Pen pen = new Pen(elementPalette.GetElementColor1(state));
		using Pen pen2 = new Pen(elementPalette.GetElementColor2(state));
		using SolidBrush brush = new SolidBrush(elementPalette.GetElementColor3(state));
		if (!volumeControl)
		{
			context.Graphics.FillRectangle(brush, drawRect.X + 1, drawRect.Y + 1, drawRect.Width - 2, drawRect.Height - 2);
			context.Graphics.DrawLines(pen, new Point[3]
			{
				new Point(drawRect.Right - 1, drawRect.Y),
				new Point(drawRect.X, drawRect.Y),
				new Point(drawRect.X, drawRect.Bottom - 1)
			});
			context.Graphics.DrawLines(pen2, new Point[3]
			{
				new Point(drawRect.Right - 1, drawRect.Y + 1),
				new Point(drawRect.Right - 1, drawRect.Bottom - 1),
				new Point(drawRect.X + 1, drawRect.Bottom - 1)
			});
			return;
		}
		if (orientation == Orientation.Horizontal)
		{
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.FillPolygon(brush, new Point[5]
				{
					new Point(drawRect.X, drawRect.Bottom - 2),
					new Point(drawRect.Right - 1, drawRect.Y),
					new Point(drawRect.Right - 1, drawRect.Bottom - 1),
					new Point(drawRect.X, drawRect.Bottom - 1),
					new Point(drawRect.X, drawRect.Bottom - 2)
				});
				context.Graphics.DrawLines(pen, new Point[5]
				{
					new Point(drawRect.Right - 1, drawRect.Y),
					new Point(drawRect.Right - 1, drawRect.Bottom - 1),
					new Point(drawRect.X, drawRect.Bottom - 1),
					new Point(drawRect.X, drawRect.Bottom - 2),
					new Point(drawRect.Right - 1, drawRect.Y)
				});
				return;
			}
		}
		using (new AntiAlias(context.Graphics))
		{
			context.Graphics.FillPolygon(brush, new Point[5]
			{
				new Point(drawRect.X + 1, drawRect.Bottom - 1),
				new Point(drawRect.Right - 1, drawRect.Y + 1),
				new Point(drawRect.X, drawRect.Y + 1),
				new Point(drawRect.X, drawRect.Bottom - 1),
				new Point(drawRect.X + 1, drawRect.Bottom - 1)
			});
			context.Graphics.DrawLines(pen, new Point[5]
			{
				new Point(drawRect.Right - 1, drawRect.Y + 1),
				new Point(drawRect.X, drawRect.Y + 1),
				new Point(drawRect.X, drawRect.Bottom - 1),
				new Point(drawRect.X + 1, drawRect.Bottom - 1),
				new Point(drawRect.Right - 1, drawRect.Y + 1)
			});
		}
	}

	public override void DrawTrackPositionGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, TickStyle tickStyle)
	{
		GraphicsPath outside = null;
		GraphicsPath border = null;
		GraphicsPath inside = null;
		if (orientation == Orientation.Horizontal)
		{
			switch (tickStyle)
			{
			case TickStyle.None:
			case TickStyle.Both:
				CreatePositionPathsBoth(drawRect, ref outside, ref border, ref inside);
				break;
			case TickStyle.TopLeft:
				CreatePositionPathsTop(drawRect, ref outside, ref border, ref inside);
				break;
			case TickStyle.BottomRight:
				CreatePositionPathsBottom(drawRect, ref outside, ref border, ref inside);
				break;
			}
		}
		else
		{
			switch (tickStyle)
			{
			case TickStyle.None:
			case TickStyle.Both:
				CreatePositionPathsBoth(drawRect, ref outside, ref border, ref inside);
				break;
			case TickStyle.TopLeft:
				CreatePositionPathsLeft(drawRect, ref outside, ref border, ref inside);
				break;
			case TickStyle.BottomRight:
				CreatePositionPathsRight(drawRect, ref outside, ref border, ref inside);
				break;
			}
		}
		if (outside == null || border == null || inside == null)
		{
			return;
		}
		using (new AntiAlias(context.Graphics))
		{
			using Pen pen = new Pen(elementPalette.GetElementColor1(state));
			using Pen pen2 = new Pen(elementPalette.GetElementColor2(state));
			context.Graphics.DrawPath(pen, outside);
			using (SolidBrush brush = new SolidBrush(elementPalette.GetElementColor3(state)))
			{
				context.Graphics.FillPath(brush, border);
			}
			context.Graphics.DrawPath(pen2, border);
			using LinearGradientBrush brush2 = new LinearGradientBrush(inside.GetBounds(), elementPalette.GetElementColor4(state), elementPalette.GetElementColor5(state), 90f);
			context.Graphics.FillPath(brush2, inside);
		}
		outside.Dispose();
		border.Dispose();
		inside.Dispose();
	}

	private void CreatePositionPathsBoth(Rectangle drawRect, ref GraphicsPath outside, ref GraphicsPath border, ref GraphicsPath inside)
	{
		outside = CreatePositionPathsBoth(drawRect);
		drawRect.Inflate(-1, -1);
		border = CreatePositionPathsBoth(drawRect);
		inside = new GraphicsPath();
		inside.AddRectangle(new Rectangle(drawRect.X + 2, drawRect.Y + 2, drawRect.Width - 5, drawRect.Height - 5));
	}

	private GraphicsPath CreatePositionPathsBoth(Rectangle drawRect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(new PointF[9]
		{
			new PointF((float)drawRect.X + 0.75f, drawRect.Y),
			new PointF((float)drawRect.Right - 1.75f, drawRect.Y),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Bottom - 2f),
			new PointF((float)drawRect.Right - 2f, (float)drawRect.Bottom - 1f),
			new PointF((float)drawRect.X + 1f, (float)drawRect.Bottom - 1f),
			new PointF(drawRect.X, (float)drawRect.Bottom - 2f),
			new PointF(drawRect.X, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.X + 0.75f, drawRect.Y)
		});
		return graphicsPath;
	}

	private void CreatePositionPathsBottom(Rectangle drawRect, ref GraphicsPath outside, ref GraphicsPath border, ref GraphicsPath inside)
	{
		outside = CreatePositionPathsBottom(drawRect);
		drawRect.Inflate(-1, -1);
		border = CreatePositionPathsBottom(drawRect);
		drawRect.Inflate(-2, -2);
		drawRect.Y++;
		drawRect.Height--;
		inside = CreatePositionPathsBottom(drawRect);
	}

	private GraphicsPath CreatePositionPathsBottom(Rectangle drawRect)
	{
		float num = (float)drawRect.Width / 2f - 0.5f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(new PointF[8]
		{
			new PointF((float)drawRect.X + num, drawRect.Y),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Y + num),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Bottom - 2f),
			new PointF((float)drawRect.Right - 2f, (float)drawRect.Bottom - 1f),
			new PointF((float)drawRect.X + 1f, (float)drawRect.Bottom - 1f),
			new PointF(drawRect.X, (float)drawRect.Bottom - 2f),
			new PointF(drawRect.X, (float)drawRect.Y + num),
			new PointF((float)drawRect.X + num, drawRect.Y)
		});
		return graphicsPath;
	}

	private void CreatePositionPathsTop(Rectangle drawRect, ref GraphicsPath outside, ref GraphicsPath border, ref GraphicsPath inside)
	{
		outside = CreatePositionPathsTop(drawRect);
		drawRect.Inflate(-1, -1);
		border = CreatePositionPathsTop(drawRect);
		drawRect.Inflate(-2, -2);
		drawRect.Height--;
		inside = CreatePositionPathsTop(drawRect);
	}

	private GraphicsPath CreatePositionPathsTop(Rectangle drawRect)
	{
		float num = (float)drawRect.Width / 2f - 0.5f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(new PointF[8]
		{
			new PointF((float)drawRect.X + 0.75f, drawRect.Y),
			new PointF((float)drawRect.Right - 1.75f, drawRect.Y),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Bottom - num - 1f),
			new PointF((float)drawRect.X + num, (float)drawRect.Bottom - 1f),
			new PointF(drawRect.X, (float)drawRect.Bottom - num - 1f),
			new PointF(drawRect.X, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.X + 0.75f, drawRect.Y)
		});
		return graphicsPath;
	}

	private void CreatePositionPathsRight(Rectangle drawRect, ref GraphicsPath outside, ref GraphicsPath border, ref GraphicsPath inside)
	{
		outside = CreatePositionPathsRight(drawRect);
		drawRect.Inflate(-1, -1);
		border = CreatePositionPathsRight(drawRect);
		drawRect.Inflate(-2, -2);
		drawRect.Width--;
		inside = CreatePositionPathsRight(drawRect);
	}

	private GraphicsPath CreatePositionPathsRight(Rectangle drawRect)
	{
		float num = (float)drawRect.Height / 2f - 0.5f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(new PointF[8]
		{
			new PointF((float)drawRect.X + 0.75f, drawRect.Y),
			new PointF((float)drawRect.Right - num - 1f, drawRect.Y),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Y + num),
			new PointF((float)drawRect.Right - num - 1f, (float)drawRect.Bottom - 1f),
			new PointF((float)drawRect.X + 1f, (float)drawRect.Bottom - 1f),
			new PointF(drawRect.X, (float)drawRect.Bottom - 2f),
			new PointF(drawRect.X, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.X + 0.75f, drawRect.Y)
		});
		return graphicsPath;
	}

	private void CreatePositionPathsLeft(Rectangle drawRect, ref GraphicsPath outside, ref GraphicsPath border, ref GraphicsPath inside)
	{
		outside = CreatePositionPathsLeft(drawRect);
		drawRect.Inflate(-1, -1);
		border = CreatePositionPathsLeft(drawRect);
		drawRect.Inflate(-2, -2);
		drawRect.X++;
		drawRect.Width--;
		inside = CreatePositionPathsLeft(drawRect);
	}

	private GraphicsPath CreatePositionPathsLeft(Rectangle drawRect)
	{
		float num = (float)drawRect.Height / 2f - 0.5f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(new PointF[8]
		{
			new PointF((float)drawRect.Right - 1.75f, drawRect.Y),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Y + 0.75f),
			new PointF((float)drawRect.Right - 1f, (float)drawRect.Bottom - 2f),
			new PointF((float)drawRect.Right - 2f, (float)drawRect.Bottom - 1f),
			new PointF((float)drawRect.X + num, (float)drawRect.Bottom - 1f),
			new PointF(drawRect.X, (float)drawRect.Bottom - num - 1f),
			new PointF((float)drawRect.X + num, drawRect.Y),
			new PointF((float)drawRect.Right - 1.75f, drawRect.Y)
		});
		return graphicsPath;
	}

	private static GraphicsPath CreateBorderBackPath(bool forBorder, bool middle, Rectangle rect, PaletteDrawBorders borders, int borderWidth, int borderRounding, bool smoothing, int variant)
	{
		Rectangle rectangle = rect;
		GraphicsPath graphicsPath = new GraphicsPath();
		if (rect.Width > 0 && rect.Height > 0)
		{
			int num = Math.Min(borderRounding, Math.Min(rect.Width / 2, rect.Height / 2) - borderWidth);
			int num2 = (middle ? (borderWidth / 2) : 0);
			if (CommonHelper.HasTopBorder(borders))
			{
				rect.Y += num2;
				rect.Height -= num2;
			}
			if (CommonHelper.HasLeftBorder(borders))
			{
				rect.X += num2;
				rect.Width -= num2;
			}
			if (CommonHelper.HasBottomBorder(borders))
			{
				rect.Height -= num2;
			}
			if (CommonHelper.HasRightBorder(borders))
			{
				rect.Width -= num2;
			}
			int num3 = num * 2;
			int arcLength = num3 + 1;
			if (CommonHelper.HasAllBorders(borders))
			{
				CreateAllBorderBackPath(middle, graphicsPath, rect, borderWidth, num, forBorder, num3, arcLength);
			}
			else if (forBorder)
			{
				if (!middle)
				{
					if (num > 0)
					{
						CreateBorderBackPathOnlyClosed(middle, borders, graphicsPath, rect, num3, variant);
					}
					else
					{
						graphicsPath.AddRectangle(rect);
					}
				}
				else if (num > 0)
				{
					CreateBorderBackPathOnly(middle, borders, graphicsPath, rect, num3, variant);
				}
				else
				{
					CreateBorderBackPathOnly(borders, graphicsPath, rect, variant);
				}
			}
			else if (num > 0)
			{
				CreateBorderBackPathComplete(middle, borders, graphicsPath, rect, num3);
			}
			else
			{
				graphicsPath.AddRectangle(rect);
			}
		}
		return graphicsPath;
	}

	private static void CreateAllBorderBackPath(bool middle, GraphicsPath borderPath, Rectangle rect, int width, int rounding, bool forBorder, int arcLength, int arcLength1)
	{
		if (rounding <= 0)
		{
			if (forBorder && middle && width % 2 == 1)
			{
				rect.Width--;
				rect.Height--;
			}
			borderPath.AddRectangle(rect);
			return;
		}
		RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		if (!middle && width % 2 == 1)
		{
			rectangleF.X -= 0.25f;
			rectangleF.Y -= 0.25f;
			rectangleF.Width += 0.75f;
			rectangleF.Height += 0.75f;
		}
		borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
		borderPath.AddArc(rectangleF.Right - (float)arcLength1, rectangleF.Top, arcLength, arcLength, 270f, 90f);
		borderPath.AddArc(rectangleF.Right - (float)arcLength1, rectangleF.Bottom - (float)arcLength1, arcLength, arcLength, 0f, 90f);
		borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength1, arcLength, arcLength, 90f, 90f);
		borderPath.CloseFigure();
	}

	private static void CreateBorderBackPathOnly(PaletteDrawBorders borders, GraphicsPath borderPath, Rectangle rect, int variant)
	{
		rect.Width--;
		rect.Height--;
		switch (borders)
		{
		case PaletteDrawBorders.None:
			break;
		case PaletteDrawBorders.Top:
			borderPath.AddLine(rect.Left - 1, rect.Top, rect.Right + 1, rect.Top);
			break;
		case PaletteDrawBorders.Bottom:
			borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Right + 1, rect.Bottom);
			break;
		case PaletteDrawBorders.Left:
			borderPath.AddLine(rect.Left, rect.Top - 1, rect.Left, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.Right:
			borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.TopBottom:
			if (variant == 0)
			{
				borderPath.AddLine(rect.Left - 1, rect.Top, rect.Right + 1, rect.Top);
			}
			else
			{
				borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Right + 1, rect.Bottom);
			}
			break;
		case PaletteDrawBorders.LeftRight:
			if (variant == 0)
			{
				borderPath.AddLine(rect.Left, rect.Top - 1, rect.Left, rect.Bottom + 1);
			}
			else
			{
				borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom + 1);
			}
			break;
		case PaletteDrawBorders.TopLeft:
			borderPath.AddLine(rect.Left, rect.Bottom + 1, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right + 1, rect.Top);
			break;
		case PaletteDrawBorders.TopRight:
			borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.BottomRight:
			borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left - 1, rect.Bottom);
			break;
		case PaletteDrawBorders.BottomLeft:
			borderPath.AddLine(rect.Right + 1, rect.Bottom, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top - 1);
			break;
		case PaletteDrawBorders.TopBottomLeft:
			borderPath.AddLine(rect.Right + 1, rect.Bottom, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right + 1, rect.Top);
			break;
		case PaletteDrawBorders.TopBottomRight:
			borderPath.AddLine(rect.Left - 1, rect.Top, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left - 1, rect.Bottom);
			break;
		case PaletteDrawBorders.TopLeftRight:
			borderPath.AddLine(rect.Left, rect.Bottom + 1, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.BottomLeftRight:
			borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top - 1);
			break;
		}
	}

	private static void CreateBorderBackPathOnly(bool middle, PaletteDrawBorders borders, GraphicsPath borderPath, Rectangle rect, int arcLength, int variant)
	{
		rect.Width--;
		rect.Height--;
		RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		if (!middle)
		{
			rectangleF.X -= 0.25f;
			rectangleF.Y -= 0.25f;
			rectangleF.Width += 0.75f;
			rectangleF.Height += 0.75f;
		}
		switch (borders)
		{
		case PaletteDrawBorders.None:
			break;
		case PaletteDrawBorders.Top:
			borderPath.AddLine(rect.Left - 1, rect.Top, rect.Right + 1, rect.Top);
			break;
		case PaletteDrawBorders.Bottom:
			borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Right + 1, rect.Bottom);
			break;
		case PaletteDrawBorders.Left:
			borderPath.AddLine(rect.Left, rect.Top - 1, rect.Left, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.Right:
			borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom + 1);
			break;
		case PaletteDrawBorders.TopBottom:
			if (variant == 0)
			{
				borderPath.AddLine(rect.Left - 1, rect.Top, rect.Right + 1, rect.Top);
			}
			else
			{
				borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Right + 1, rect.Bottom);
			}
			break;
		case PaletteDrawBorders.LeftRight:
			if (variant == 0)
			{
				borderPath.AddLine(rect.Left, rect.Top - 1, rect.Left, rect.Bottom + 1);
			}
			else
			{
				borderPath.AddLine(rect.Right, rect.Top - 1, rect.Right, rect.Bottom + 1);
			}
			break;
		case PaletteDrawBorders.TopLeft:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom + 1f, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right + 1f, rectangleF.Top);
			break;
		case PaletteDrawBorders.TopRight:
			borderPath.AddLine(rectangleF.Left - 1f, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom + 1f);
			break;
		case PaletteDrawBorders.BottomRight:
			borderPath.AddLine(rectangleF.Right, rectangleF.Top - 1f, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left - 1f, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.BottomLeft:
			borderPath.AddLine(rectangleF.Right + 1f, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom - (float)arcLength, rectangleF.Left, rectangleF.Top - 1f);
			break;
		case PaletteDrawBorders.TopBottomLeft:
			borderPath.AddLine(rectangleF.Right + 1f, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right + 1f, rectangleF.Top);
			break;
		case PaletteDrawBorders.TopBottomRight:
			borderPath.AddLine(rectangleF.Left - 1f, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left - 1f, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopLeftRight:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom + 1f, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom + 1f);
			break;
		case PaletteDrawBorders.BottomLeftRight:
			borderPath.AddLine(rectangleF.Right, rectangleF.Top - 1f, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom - (float)arcLength, rectangleF.Left, rectangleF.Top - 1f);
			break;
		}
	}

	private static void CreateBorderBackPathOnlyClosed(bool middle, PaletteDrawBorders borders, GraphicsPath borderPath, Rectangle rect, int arcLength, int variant)
	{
		rect.Width--;
		rect.Height--;
		RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		if (!middle)
		{
			rectangleF.X -= 0.25f;
			rectangleF.Y -= 0.25f;
			rectangleF.Width += 0.75f;
			rectangleF.Height += 0.75f;
		}
		switch (borders)
		{
		case PaletteDrawBorders.None:
			break;
		case PaletteDrawBorders.Top:
		case PaletteDrawBorders.Bottom:
		case PaletteDrawBorders.TopBottom:
		case PaletteDrawBorders.Left:
		case PaletteDrawBorders.Right:
		case PaletteDrawBorders.LeftRight:
			rect.Width++;
			rect.Height++;
			borderPath.AddRectangle(rect);
			break;
		case PaletteDrawBorders.TopLeft:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom + 1f, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right + 1f, rectangleF.Top);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopRight:
			borderPath.AddLine(rectangleF.Left - 1f, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom + 1f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.BottomRight:
			borderPath.AddLine(rectangleF.Right, rectangleF.Top - 1f, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left - 1f, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top);
			break;
		case PaletteDrawBorders.BottomLeft:
			borderPath.AddLine(rectangleF.Right + 1f, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom - (float)arcLength, rectangleF.Left, rectangleF.Top - 1f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			break;
		case PaletteDrawBorders.TopBottomLeft:
			borderPath.AddLine(rectangleF.Right + 1f, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right + 1f, rectangleF.Top);
			break;
		case PaletteDrawBorders.TopBottomRight:
			borderPath.AddLine(rectangleF.Left - 1f, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left - 1f, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopLeftRight:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom + 1f, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom + 1f);
			break;
		case PaletteDrawBorders.BottomLeftRight:
			borderPath.AddLine(rectangleF.Right, rectangleF.Top - 1f, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom - (float)arcLength, rectangleF.Left, rectangleF.Top - 1f);
			break;
		}
	}

	private static void CreateBorderBackPathComplete(bool middle, PaletteDrawBorders borders, GraphicsPath borderPath, Rectangle rect, int arcLength)
	{
		RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		if (!middle)
		{
			rectangleF.X -= 0.25f;
			rectangleF.Y -= 0.25f;
			rectangleF.Width += 0.75f;
			rectangleF.Height += 0.75f;
		}
		switch (borders)
		{
		case PaletteDrawBorders.None:
		case PaletteDrawBorders.Top:
		case PaletteDrawBorders.Bottom:
		case PaletteDrawBorders.TopBottom:
		case PaletteDrawBorders.Left:
		case PaletteDrawBorders.Right:
		case PaletteDrawBorders.LeftRight:
			borderPath.AddRectangle(rect);
			break;
		case PaletteDrawBorders.TopLeft:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopRight:
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top);
			break;
		case PaletteDrawBorders.BottomRight:
			rectangleF.Width -= 1f;
			rectangleF.Height -= 1f;
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top);
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			break;
		case PaletteDrawBorders.BottomLeft:
			rectangleF.X++;
			rectangleF.Width -= 1f;
			rectangleF.Height -= 1f;
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom - (float)arcLength, rectangleF.Left, rectangleF.Top);
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopBottomLeft:
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left + (float)arcLength, rectangleF.Bottom);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddLine(rectangleF.Left + (float)arcLength, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.TopBottomRight:
			rectangleF.Width -= 1f;
			rectangleF.Height -= 1f;
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right - (float)arcLength, rectangleF.Top);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddLine(rectangleF.Right - (float)arcLength, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top);
			break;
		case PaletteDrawBorders.TopLeftRight:
			borderPath.AddLine(rectangleF.Left, rectangleF.Bottom, rectangleF.Left, rectangleF.Top + (float)arcLength);
			borderPath.AddArc(rectangleF.Left, rectangleF.Top, arcLength, arcLength, 180f, 90f);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Top, arcLength, arcLength, -90f, 90f);
			borderPath.AddLine(rectangleF.Right, rectangleF.Top + (float)arcLength, rectangleF.Right, rectangleF.Bottom);
			borderPath.AddLine(rectangleF.Right, rectangleF.Bottom, rectangleF.Left, rectangleF.Bottom);
			break;
		case PaletteDrawBorders.BottomLeftRight:
			rectangleF.X++;
			rectangleF.Width -= 1f;
			rectangleF.Height -= 1f;
			borderPath.AddLine(rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom - (float)arcLength);
			borderPath.AddArc(rectangleF.Right - (float)arcLength, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 0f, 90f);
			borderPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)arcLength, arcLength, arcLength, 90f, 90f);
			borderPath.AddLine(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Top);
			break;
		}
	}

	private static GraphicsPath CreateTabBorderBackPath(RightToLeft rtl, PaletteState state, bool forBorder, Rectangle rect, int borderWidth, TabBorderStyle tabBorderStyle, VisualOrientation orientation, bool smoothing)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (rect.Width > 0 && rect.Height > 0)
		{
			int num = borderWidth / 2;
			rect.Width -= num * 2;
			rect.Height -= num;
			rect.X += num;
			rect.Y += num;
			CreateTabBorderPath(rtl == RightToLeft.Yes, state, forBorder, graphicsPath, rect, tabBorderStyle, orientation);
		}
		return graphicsPath;
	}

	private static void CreateTabBorderPath(bool rtl, PaletteState state, bool forBorder, GraphicsPath borderPath, Rectangle rect, TabBorderStyle tabBorderStyle, VisualOrientation orientation)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
			rect.Width--;
			break;
		case VisualOrientation.Bottom:
			rect.Y--;
			rect.Width--;
			break;
		case VisualOrientation.Left:
			rect.Height--;
			break;
		case VisualOrientation.Right:
			rect.X--;
			rect.Height--;
			break;
		}
		switch (tabBorderStyle)
		{
		case TabBorderStyle.SquareEqualSmall:
		case TabBorderStyle.SquareEqualMedium:
		case TabBorderStyle.SquareEqualLarge:
		case TabBorderStyle.DockEqual:
			AddSquarePath(borderPath, orientation, rect, forBorder);
			break;
		case TabBorderStyle.SquareOutsizeSmall:
		case TabBorderStyle.SquareOutsizeMedium:
		case TabBorderStyle.SquareOutsizeLarge:
		case TabBorderStyle.DockOutsize:
			rect = AdjustOutsizeTab(state, rect, orientation);
			AddSquarePath(borderPath, orientation, rect, forBorder);
			break;
		case TabBorderStyle.RoundedEqualSmall:
		case TabBorderStyle.RoundedEqualMedium:
		case TabBorderStyle.RoundedEqualLarge:
			AddRoundedPath(borderPath, orientation, rect, forBorder);
			break;
		case TabBorderStyle.RoundedOutsizeSmall:
		case TabBorderStyle.RoundedOutsizeMedium:
		case TabBorderStyle.RoundedOutsizeLarge:
			rect = AdjustOutsizeTab(state, rect, orientation);
			AddRoundedPath(borderPath, orientation, rect, forBorder);
			break;
		case TabBorderStyle.SlantOutsizeNear:
			rect = AdjustOutsizeTab(state, rect, orientation);
			goto case TabBorderStyle.SlantEqualNear;
		case TabBorderStyle.SlantEqualNear:
			if (rtl && (orientation == VisualOrientation.Top || orientation == VisualOrientation.Bottom))
			{
				AddSlantFarPath(borderPath, orientation, rect, forBorder);
			}
			else
			{
				AddSlantNearPath(borderPath, orientation, rect, forBorder);
			}
			break;
		case TabBorderStyle.SlantOutsizeFar:
			rect = AdjustOutsizeTab(state, rect, orientation);
			goto case TabBorderStyle.SlantEqualFar;
		case TabBorderStyle.SlantEqualFar:
			if (rtl && (orientation == VisualOrientation.Top || orientation == VisualOrientation.Bottom))
			{
				AddSlantNearPath(borderPath, orientation, rect, forBorder);
			}
			else
			{
				AddSlantFarPath(borderPath, orientation, rect, forBorder);
			}
			break;
		case TabBorderStyle.SlantOutsizeBoth:
			rect = AdjustOutsizeTab(state, rect, orientation);
			goto case TabBorderStyle.SlantEqualBoth;
		case TabBorderStyle.SlantEqualBoth:
			AddSlantBothPath(borderPath, orientation, rect, forBorder);
			break;
		case TabBorderStyle.OneNote:
		{
			bool flag = state == PaletteState.CheckedNormal || state == PaletteState.CheckedPressed || state == PaletteState.CheckedTracking;
			int rp = (flag ? _spacingTabOneNoteRPS : _spacingTabOneNoteRPI);
			if (!flag)
			{
				rect = AdjustOneNoteTab(rect, orientation);
			}
			if (rtl && (orientation == VisualOrientation.Top || orientation == VisualOrientation.Bottom))
			{
				AddOneNoteReversePath(borderPath, orientation, rect, forBorder, rp);
			}
			else
			{
				AddOneNotePath(borderPath, orientation, rect, forBorder, rp);
			}
			break;
		}
		case TabBorderStyle.SmoothOutsize:
			rect = AdjustSmoothTab(state, rect, orientation);
			goto case TabBorderStyle.SmoothEqual;
		case TabBorderStyle.SmoothEqual:
			AddSmoothPath(borderPath, orientation, rect, forBorder);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private static Rectangle AdjustOutsizeTab(PaletteState state, Rectangle rect, VisualOrientation orientation)
	{
		if (state != PaletteState.CheckedNormal && state != PaletteState.CheckedTracking && state != PaletteState.CheckedPressed)
		{
			switch (orientation)
			{
			case VisualOrientation.Top:
				rect.Height -= 2;
				rect.Width -= 4;
				rect.X += 2;
				rect.Y += 2;
				break;
			case VisualOrientation.Bottom:
				rect.Height -= 2;
				rect.Width -= 4;
				rect.X += 2;
				break;
			case VisualOrientation.Left:
				rect.Height -= 4;
				rect.Width -= 2;
				rect.X += 2;
				rect.Y += 2;
				break;
			case VisualOrientation.Right:
				rect.Height -= 4;
				rect.Width -= 2;
				rect.Y += 2;
				break;
			}
		}
		return rect;
	}

	private static Rectangle AdjustOneNoteTab(Rectangle rect, VisualOrientation orientation)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
			rect.Height -= _spacingTabOneNoteTPI;
			rect.Y += _spacingTabOneNoteTPI;
			break;
		case VisualOrientation.Bottom:
			rect.Height -= _spacingTabOneNoteTPI;
			break;
		case VisualOrientation.Left:
			rect.Width -= _spacingTabOneNoteTPI;
			rect.X += _spacingTabOneNoteTPI;
			break;
		case VisualOrientation.Right:
			rect.Width -= _spacingTabOneNoteTPI;
			break;
		}
		return rect;
	}

	private static Rectangle AdjustSmoothTab(PaletteState state, Rectangle rect, VisualOrientation orientation)
	{
		if (state != PaletteState.CheckedNormal && state != PaletteState.CheckedTracking && state != PaletteState.CheckedPressed)
		{
			switch (orientation)
			{
			case VisualOrientation.Top:
				rect.Height -= 4;
				rect.Width -= 8;
				rect.X += 4;
				rect.Y += 4;
				break;
			case VisualOrientation.Bottom:
				rect.Height -= 4;
				rect.Width -= 8;
				rect.X += 4;
				break;
			case VisualOrientation.Left:
				rect.Height -= 8;
				rect.Width -= 4;
				rect.X += 4;
				rect.Y += 4;
				break;
			case VisualOrientation.Right:
				rect.Height -= 8;
				rect.Width -= 4;
				rect.Y += 4;
				break;
			}
		}
		return rect;
	}

	private static void AddSquarePath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			break;
		}
	}

	private static void AddRoundedPath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		int spacingTabRoundedCorner = _spacingTabRoundedCorner;
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + spacingTabRoundedCorner);
			borderPath.AddLine(rect.Left, rect.Top + spacingTabRoundedCorner, rect.Left + spacingTabRoundedCorner, rect.Top);
			borderPath.AddLine(rect.Left + spacingTabRoundedCorner, rect.Top, rect.Right - spacingTabRoundedCorner, rect.Top);
			borderPath.AddLine(rect.Right - spacingTabRoundedCorner, rect.Top, rect.Right, rect.Top + spacingTabRoundedCorner);
			borderPath.AddLine(rect.Right, rect.Top + spacingTabRoundedCorner, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom - spacingTabRoundedCorner);
			borderPath.AddLine(rect.Left, rect.Bottom - spacingTabRoundedCorner, rect.Left + spacingTabRoundedCorner, rect.Bottom);
			borderPath.AddLine(rect.Left + spacingTabRoundedCorner, rect.Bottom, rect.Right - spacingTabRoundedCorner, rect.Bottom);
			borderPath.AddLine(rect.Right - spacingTabRoundedCorner, rect.Bottom, rect.Right, rect.Bottom - spacingTabRoundedCorner);
			borderPath.AddLine(rect.Right, rect.Bottom - spacingTabRoundedCorner, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left + spacingTabRoundedCorner, rect.Bottom);
			borderPath.AddLine(rect.Left + spacingTabRoundedCorner, rect.Bottom, rect.Left, rect.Bottom - spacingTabRoundedCorner);
			borderPath.AddLine(rect.Left, rect.Bottom - spacingTabRoundedCorner, rect.Left, rect.Top + spacingTabRoundedCorner);
			borderPath.AddLine(rect.Left, rect.Top + spacingTabRoundedCorner, rect.Left + spacingTabRoundedCorner, rect.Top);
			borderPath.AddLine(rect.Left + spacingTabRoundedCorner, rect.Top, rect.Right, rect.Top);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right - spacingTabRoundedCorner, rect.Bottom);
			borderPath.AddLine(rect.Right - spacingTabRoundedCorner, rect.Bottom, rect.Right, rect.Bottom - spacingTabRoundedCorner);
			borderPath.AddLine(rect.Right, rect.Bottom - spacingTabRoundedCorner, rect.Right, rect.Top + spacingTabRoundedCorner);
			borderPath.AddLine(rect.Right, rect.Top + spacingTabRoundedCorner, rect.Right - spacingTabRoundedCorner, rect.Top);
			borderPath.AddLine(rect.Right - spacingTabRoundedCorner, rect.Top, rect.Left, rect.Top);
			break;
		}
	}

	private static void AddSlantNearPath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		int spacingTabSlantPadding = _spacingTabSlantPadding;
		int num = Math.Min(spacingTabSlantPadding, rect.Width);
		int num2 = Math.Min(spacingTabSlantPadding, rect.Height);
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Left + num, rect.Top);
			borderPath.AddLine(rect.Left + num, rect.Top, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left - 1, rect.Top, rect.Left + num, rect.Bottom);
			borderPath.AddLine(rect.Left + num, rect.Bottom, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom - num2);
			borderPath.AddLine(rect.Left, rect.Bottom - num2, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom - num2);
			borderPath.AddLine(rect.Right, rect.Bottom - num2, rect.Right, rect.Top);
			borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			break;
		}
	}

	private static void AddSlantFarPath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		int spacingTabSlantPadding = _spacingTabSlantPadding;
		int num = Math.Min(spacingTabSlantPadding, rect.Width);
		int num2 = Math.Min(spacingTabSlantPadding, rect.Height);
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			borderPath.AddLine(rect.Left, rect.Top, rect.Right - num, rect.Top);
			borderPath.AddLine(rect.Right - num, rect.Top, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right - num, rect.Bottom);
			borderPath.AddLine(rect.Right - num, rect.Bottom, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + num2);
			borderPath.AddLine(rect.Left, rect.Top + num2, rect.Right, rect.Top - 1);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Top + num2);
			borderPath.AddLine(rect.Right, rect.Top + num2, rect.Left, rect.Top - 1);
			break;
		}
	}

	private static void AddSlantBothPath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		int spacingTabSlantPadding = _spacingTabSlantPadding;
		int num = Math.Min(spacingTabSlantPadding, rect.Width / 2);
		int num2 = Math.Min(spacingTabSlantPadding, rect.Height / 2);
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left - 1, rect.Bottom, rect.Left + num, rect.Top);
			borderPath.AddLine(rect.Left + num, rect.Top, rect.Right - num, rect.Top);
			borderPath.AddLine(rect.Right - num, rect.Top, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left - 1, rect.Top, rect.Left + num, rect.Bottom);
			borderPath.AddLine(rect.Left + num, rect.Bottom, rect.Right - num, rect.Bottom);
			borderPath.AddLine(rect.Right - num, rect.Bottom, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom - num2);
			borderPath.AddLine(rect.Left, rect.Bottom - num2, rect.Left, rect.Top + num2);
			borderPath.AddLine(rect.Left, rect.Top + num2, rect.Right, rect.Top - 1);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom - num2);
			borderPath.AddLine(rect.Right, rect.Bottom - num2, rect.Right, rect.Top + num2);
			borderPath.AddLine(rect.Right, rect.Top + num2, rect.Left, rect.Top - 1);
			break;
		}
	}

	private static void AddOneNotePath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder, int rp)
	{
		int num = Math.Min(Math.Min(9, rect.Width / 2), rect.Height / 2);
		int num2 = Math.Min(rp, rect.Width / 2);
		int num3 = Math.Min(rp, rect.Height / 2);
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Bottom - 1);
			borderPath.AddArc(rect.Left, rect.Top, num, num, 180f, 90f);
			borderPath.AddLine(rect.Right - num2, rect.Top, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Top + 1);
			borderPath.AddArc(rect.Left, rect.Bottom - num, num, num, 180f, -90f);
			borderPath.AddLine(rect.Right - num2, rect.Bottom, rect.Right, rect.Top);
			break;
		case VisualOrientation.Left:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Top);
			}
			borderPath.AddLine(rect.Right, rect.Top, rect.Right - 1, rect.Top);
			borderPath.AddArc(rect.Left, rect.Top, num, num, -90f, -90f);
			borderPath.AddLine(rect.Left, rect.Bottom - num3, rect.Right, rect.Bottom);
			break;
		case VisualOrientation.Right:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
			}
			borderPath.AddLine(rect.Left, rect.Top, rect.Left + 1, rect.Top);
			borderPath.AddArc(rect.Right - num, rect.Top, num, num, -90f, 90f);
			borderPath.AddLine(rect.Right, rect.Bottom - num3, rect.Left, rect.Bottom);
			break;
		}
	}

	private static void AddOneNoteReversePath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder, int rp)
	{
		int num = Math.Min(Math.Min(9, rect.Width / 2), rect.Height / 2);
		int num2 = Math.Min(rp, rect.Width / 2);
		switch (orientation)
		{
		case VisualOrientation.Top:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			}
			borderPath.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom - 1);
			borderPath.AddArc(rect.Right - num, rect.Top, num, num, 0f, -90f);
			borderPath.AddLine(rect.Left + num2, rect.Top, rect.Left, rect.Bottom);
			break;
		case VisualOrientation.Bottom:
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			}
			borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Top + 1);
			borderPath.AddArc(rect.Right - num, rect.Bottom - num, num, num, 0f, 90f);
			borderPath.AddLine(rect.Left + num2, rect.Bottom, rect.Left, rect.Top);
			break;
		}
	}

	private static void AddSmoothPath(GraphicsPath borderPath, VisualOrientation orientation, Rectangle rect, bool forBorder)
	{
		int val = Math.Min(rect.Width, rect.Height);
		int num = Math.Min(val, 50);
		float tension = Math.Max(0.5f - 0.01f * (float)num, 0.05f);
		int num2 = Math.Min(5, rect.Width / 10);
		int num3 = Math.Min(5, rect.Height / 10);
		switch (orientation)
		{
		case VisualOrientation.Top:
		{
			if (rect.Width < 14)
			{
				AddRoundedPath(borderPath, orientation, rect, forBorder);
				break;
			}
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			}
			int num6 = rect.Width / 2;
			int num7 = rect.Width / 6;
			borderPath.AddCurve(new Point[7]
			{
				new Point(rect.Left, rect.Bottom),
				new Point(rect.Left + num2, rect.Top + 5),
				new Point(rect.Left + num7, rect.Top + 2),
				new Point(rect.Left + num6, rect.Top),
				new Point(rect.Right - num7, rect.Top + 2),
				new Point(rect.Right - num2, rect.Top + 5),
				new Point(rect.Right, rect.Bottom)
			}, tension);
			break;
		}
		case VisualOrientation.Bottom:
		{
			if (rect.Width < 14)
			{
				AddRoundedPath(borderPath, orientation, rect, forBorder);
				break;
			}
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
			}
			int num10 = rect.Width / 2;
			int num11 = rect.Width / 6;
			borderPath.AddCurve(new Point[7]
			{
				new Point(rect.Left, rect.Top),
				new Point(rect.Left + num2, rect.Bottom - 5),
				new Point(rect.Left + num11, rect.Bottom - 2),
				new Point(rect.Left + num10, rect.Bottom),
				new Point(rect.Right - num11, rect.Bottom - 2),
				new Point(rect.Right - num2, rect.Bottom - 5),
				new Point(rect.Right, rect.Top)
			}, tension);
			break;
		}
		case VisualOrientation.Left:
		{
			if (rect.Height < 14)
			{
				AddRoundedPath(borderPath, orientation, rect, forBorder);
				break;
			}
			if (!forBorder)
			{
				borderPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			int num8 = rect.Height / 2;
			int num9 = rect.Height / 6;
			borderPath.AddCurve(new Point[7]
			{
				new Point(rect.Right, rect.Bottom),
				new Point(rect.Left + 5, rect.Bottom - num3),
				new Point(rect.Left + 2, rect.Bottom - num9),
				new Point(rect.Left, rect.Bottom - num8),
				new Point(rect.Left + 2, rect.Top + num9),
				new Point(rect.Left + 5, rect.Top + num3),
				new Point(rect.Right, rect.Top)
			}, tension);
			break;
		}
		case VisualOrientation.Right:
		{
			if (rect.Height < 14)
			{
				AddRoundedPath(borderPath, orientation, rect, forBorder);
				break;
			}
			if (!forBorder)
			{
				borderPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom);
			}
			int num4 = rect.Height / 2;
			int num5 = rect.Height / 6;
			borderPath.AddCurve(new Point[7]
			{
				new Point(rect.Left, rect.Bottom),
				new Point(rect.Right - 5, rect.Bottom - num3),
				new Point(rect.Right - 2, rect.Bottom - num5),
				new Point(rect.Right, rect.Bottom - num4),
				new Point(rect.Right - 2, rect.Top + num5),
				new Point(rect.Right - 5, rect.Top + num3),
				new Point(rect.Left, rect.Top)
			}, tension);
			break;
		}
		}
	}

	private static bool ShouldDrawImage(Image image)
	{
		return image != null;
	}

	private static Brush CreateColorBrush(Rectangle rect, Color color1, Color color2, PaletteColorStyle gradientStyle, float angle, VisualOrientation orientation)
	{
		Debug.Assert(gradientStyle != PaletteColorStyle.Inherit);
		if (gradientStyle == PaletteColorStyle.Solid)
		{
			return new SolidBrush(color1);
		}
		switch (orientation)
		{
		case VisualOrientation.Left:
			angle -= 90f;
			break;
		case VisualOrientation.Right:
			angle += 90f;
			break;
		case VisualOrientation.Bottom:
			angle += 180f;
			break;
		}
		if (gradientStyle == PaletteColorStyle.OneNote)
		{
			color1 = Color.White;
		}
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color1, color2, angle);
		switch (gradientStyle)
		{
		case PaletteColorStyle.Sigma:
			linearGradientBrush.SetSigmaBellShape(0.5f);
			break;
		case PaletteColorStyle.Rounded:
			linearGradientBrush.SetSigmaBellShape(1f, 1f);
			break;
		case PaletteColorStyle.Switch25:
			linearGradientBrush.Blend = _switch25Blend;
			break;
		case PaletteColorStyle.Switch33:
			linearGradientBrush.Blend = _switch33Blend;
			break;
		case PaletteColorStyle.Switch50:
			linearGradientBrush.Blend = _switch50Blend;
			break;
		case PaletteColorStyle.Switch90:
			linearGradientBrush.Blend = _switch90Blend;
			break;
		case PaletteColorStyle.Linear25:
			linearGradientBrush.Blend = _linear25Blend;
			break;
		case PaletteColorStyle.Linear33:
			linearGradientBrush.Blend = _linear33Blend;
			break;
		case PaletteColorStyle.Linear40:
			linearGradientBrush.Blend = _linear40Blend;
			break;
		case PaletteColorStyle.Linear50:
			linearGradientBrush.Blend = _linear50Blend;
			break;
		case PaletteColorStyle.HalfCut:
			linearGradientBrush.Blend = _halfCutBlend;
			break;
		case PaletteColorStyle.QuarterPhase:
			linearGradientBrush.Blend = _quarterPhaseBlend;
			break;
		case PaletteColorStyle.OneNote:
			linearGradientBrush.Blend = _oneNoteBlend;
			break;
		case PaletteColorStyle.Rounding2:
			linearGradientBrush.Blend = _rounding2Blend;
			break;
		case PaletteColorStyle.Rounding3:
			linearGradientBrush.Blend = _rounding3Blend;
			break;
		case PaletteColorStyle.Rounding4:
			linearGradientBrush.Blend = _rounding4Blend;
			break;
		case PaletteColorStyle.Rounding5:
			linearGradientBrush.Blend = _rounding5Blend;
			break;
		}
		return linearGradientBrush;
	}

	private static Brush CreateImageBrush(Rectangle rect, Image image, PaletteImageStyle imageStyle)
	{
		TextureBrush textureBrush = new TextureBrush(image);
		switch (imageStyle)
		{
		case PaletteImageStyle.TopLeft:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			break;
		case PaletteImageStyle.TopMiddle:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left + (rect.Width - image.Width) / 2, rect.Top);
			break;
		case PaletteImageStyle.TopRight:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Right - image.Width, rect.Top);
			break;
		case PaletteImageStyle.CenterLeft:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left, rect.Top + (rect.Height - image.Height) / 2);
			break;
		case PaletteImageStyle.CenterMiddle:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left + (rect.Width - image.Width) / 2, rect.Top + (rect.Height - image.Height) / 2);
			break;
		case PaletteImageStyle.CenterRight:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Right - image.Width, rect.Top + (rect.Height - image.Height) / 2);
			break;
		case PaletteImageStyle.BottomLeft:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left, rect.Bottom - image.Height);
			break;
		case PaletteImageStyle.BottomMiddle:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left + (rect.Width - image.Width) / 2, rect.Bottom - image.Height);
			break;
		case PaletteImageStyle.BottomRight:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Right - image.Width, rect.Bottom - image.Height);
			break;
		case PaletteImageStyle.Stretch:
			textureBrush.WrapMode = WrapMode.Clamp;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			textureBrush.ScaleTransform((float)rect.Width / (float)image.Width, (float)rect.Height / (float)image.Height);
			break;
		case PaletteImageStyle.Tile:
			textureBrush.WrapMode = WrapMode.Tile;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			break;
		case PaletteImageStyle.TileFlipX:
			textureBrush.WrapMode = WrapMode.TileFlipX;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			break;
		case PaletteImageStyle.TileFlipY:
			textureBrush.WrapMode = WrapMode.TileFlipY;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			break;
		case PaletteImageStyle.TileFlipXY:
			textureBrush.WrapMode = WrapMode.TileFlipXY;
			textureBrush.TranslateTransform(rect.Left, rect.Top);
			break;
		default:
			Debug.Assert(condition: false);
			throw new ArgumentOutOfRangeException("imageStyle");
		}
		return textureBrush;
	}

	private void DrawBackSolidInside(RenderContext context, Rectangle gradientRect, Color backColor1, Color backColor2, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, path))
		{
			RectangleF bounds = path.GetBounds();
			Rectangle rect;
			if (Math.Round(bounds.X) != (double)bounds.X || Math.Round(bounds.Y) != (double)bounds.Y || Math.Round(bounds.Width) != (double)bounds.Width || Math.Round(bounds.Height) != (double)bounds.Height)
			{
				int num = (int)Math.Round(bounds.X);
				int num2 = (int)Math.Round(bounds.Y);
				int width = (int)Math.Round(bounds.Width + 1f + (bounds.X - (float)num));
				int height = (int)Math.Round(bounds.Height + 1f + (bounds.Y - (float)num2));
				rect = new Rectangle(num, num2, width, height);
			}
			else
			{
				rect = new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
			}
			using Brush brush = CreateColorBrush(gradientRect, backColor1, backColor1, PaletteColorStyle.Solid, 0f, VisualOrientation.Top);
			using Brush brush2 = CreateColorBrush(gradientRect, backColor2, backColor2, PaletteColorStyle.Solid, 0f, VisualOrientation.Top);
			context.Graphics.FillRectangle(brush, rect);
			rect.Inflate(-2, -2);
			context.Graphics.FillRectangle(brush2, rect);
			rect.Inflate(-1, -1);
			context.Graphics.FillRectangle(brush, rect);
		}
	}

	private void DrawBackOneNote(RenderContext context, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		using (Brush brush = CreateColorBrush(gradientRect, backColor1, backColor1, backColorStyle, backColorAngle, orientation))
		{
			context.Graphics.FillPath(brush, path);
		}
		GraphicsPath graphicsPath = (GraphicsPath)path.Clone();
		switch (orientation)
		{
		case VisualOrientation.Top:
			graphicsPath.Transform(new Matrix(1f, 0f, 0f, 1f, 1.5f, 1.5f));
			break;
		case VisualOrientation.Bottom:
		case VisualOrientation.Left:
			graphicsPath.Transform(new Matrix(1f, 0f, 0f, 1f, 1.5f, -1.5f));
			break;
		case VisualOrientation.Right:
			graphicsPath.Transform(new Matrix(1f, 0f, 0f, 1f, -1.5f, 1.5f));
			break;
		}
		using (new Clipping(context.Graphics, path))
		{
			using Brush brush2 = CreateColorBrush(gradientRect, backColor2, backColor2, backColorStyle, backColorAngle, orientation);
			context.Graphics.FillPath(brush2, graphicsPath);
		}
		graphicsPath.Dispose();
	}

	private void DrawBackSolidLine(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, PaletteColorStyle style, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, path))
		{
			using (SolidBrush brush = new SolidBrush(backColor2))
			{
				context.Graphics.FillRectangle(brush, rect);
			}
			switch (style)
			{
			case PaletteColorStyle.SolidTopLine:
				rect.Y++;
				rect.Height--;
				break;
			case PaletteColorStyle.SolidBottomLine:
				rect.Height--;
				break;
			case PaletteColorStyle.SolidLeftLine:
				rect.X++;
				rect.Width--;
				break;
			case PaletteColorStyle.SolidRightLine:
				rect.Width--;
				break;
			case PaletteColorStyle.SolidAllLine:
				rect.X++;
				rect.Y++;
				rect.Width -= 2;
				rect.Height -= 2;
				break;
			}
			using SolidBrush brush2 = new SolidBrush(backColor1);
			context.Graphics.FillRectangle(brush2, rect);
		}
	}

	private void DrawBackRoundedTopLeftWhite(RenderContext context, Rectangle rect, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, path))
		{
			context.Graphics.FillRectangle(Brushes.White, rect);
			rect.X++;
			rect.Y++;
			rect.Width--;
			rect.Height--;
			using Brush brush = CreateColorBrush(gradientRect, backColor1, backColor2, PaletteColorStyle.Rounded, backColorAngle, orientation);
			context.Graphics.FillRectangle(brush, rect);
		}
	}

	private void DrawBackRoundedTopLight(RenderContext context, Rectangle rect, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, path))
		{
			using (SolidBrush brush = new SolidBrush(ControlPaint.LightLight(backColor1)))
			{
				context.Graphics.FillRectangle(brush, rect);
			}
			switch (orientation)
			{
			case VisualOrientation.Top:
				rect.Y++;
				rect.Height--;
				break;
			case VisualOrientation.Bottom:
				rect.Height--;
				break;
			case VisualOrientation.Left:
				rect.X++;
				rect.Width--;
				break;
			case VisualOrientation.Right:
				rect.Width--;
				break;
			}
			using Brush brush2 = CreateColorBrush(gradientRect, backColor1, backColor2, PaletteColorStyle.Rounded, backColorAngle, orientation);
			context.Graphics.FillRectangle(brush2, rect);
		}
	}

	private void DrawBackRounded4(RenderContext context, Rectangle rect, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, path))
		{
			using (Brush brush = CreateColorBrush(gradientRect, backColor1, backColor2, backColorStyle, backColorAngle, orientation))
			{
				context.Graphics.FillPath(brush, path);
			}
			using Pen pen = new Pen(backColor1);
			switch (orientation)
			{
			case VisualOrientation.Left:
				context.Graphics.DrawLine(pen, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom - 1);
				break;
			case VisualOrientation.Right:
				context.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom - 1);
				break;
			case VisualOrientation.Bottom:
				context.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right - 1, rect.Top);
				break;
			case VisualOrientation.Top:
				context.Graphics.DrawLine(pen, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
				break;
			}
		}
	}

	private void DrawBackRounding5(RenderContext context, Rectangle rect, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		rect.Inflate(-1, -1);
		using (new Clipping(context.Graphics, rect))
		{
			using Brush brush = CreateColorBrush(gradientRect, backColor1, backColor2, PaletteColorStyle.Rounding5, backColorAngle, orientation);
			context.Graphics.FillPath(brush, path);
		}
	}

	private void DrawBackLinearShadow(RenderContext context, Rectangle rect, Rectangle gradientRect, Color backColor1, Color backColor2, PaletteColorStyle backColorStyle, float backColorAngle, VisualOrientation orientation, GraphicsPath path)
	{
		using (new Clipping(context.Graphics, rect))
		{
			using (Brush brush = CreateColorBrush(gradientRect, backColor1, backColor2, PaletteColorStyle.Linear, backColorAngle, orientation))
			{
				context.Graphics.FillPath(brush, path);
			}
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
			pathGradientBrush.Blend = _linearShadowBlend;
			pathGradientBrush.CenterColor = backColor1;
			pathGradientBrush.SurroundColors = new Color[1] { backColor2 };
			context.Graphics.FillPath(pathGradientBrush, path);
		}
	}

	private static Padding ContentPaddingForButtonForm(Padding original, ViewLayoutContext context, int allocatedHeight)
	{
		KryptonForm kryptonForm = OwningKryptonForm(context.TopControl);
		if (kryptonForm != null)
		{
			int num = (kryptonForm.RealWindowBorders.Top - allocatedHeight - 10) / 2;
			if (num > 0)
			{
				return new Padding(num);
			}
			return Padding.Empty;
		}
		return original;
	}

	private static Font ContentFontForButtonForm(ViewLayoutContext context, Font font)
	{
		KryptonForm kryptonForm = OwningKryptonForm(context.TopControl);
		if (kryptonForm != null)
		{
			int num = kryptonForm.RealWindowBorders.Top - 6;
			if (font.Height > num && num > 5)
			{
				float num2 = 72f / context.Graphics.DpiY * ((float)num / 1.333f);
				if (num2 > 3f)
				{
					font = new Font(font.FontFamily, num2, font.Style);
				}
			}
		}
		return font;
	}

	private static KryptonForm OwningKryptonForm(Control c)
	{
		while (c != null && !(c is KryptonForm))
		{
			c = c.Parent;
		}
		return c as KryptonForm;
	}

	private static void AllocateImageSpace(StandardContentMemento memento, IPaletteContent paletteContent, IContentValues contentValues, PaletteState state, Rectangle displayRect, RightToLeft rtl, ref Size[,] allocation)
	{
		memento.DrawImage = false;
		memento.Image = contentValues.GetImage(state);
		memento.ImageTransparentColor = contentValues.GetImageTransparentColor(state);
		if (memento.Image == null)
		{
			return;
		}
		try
		{
			memento.ImageRect.Size = memento.Image.Size;
			if (displayRect.Width >= memento.ImageRect.Width && displayRect.Height >= memento.ImageRect.Height)
			{
				int num = RightToLeftIndex(rtl, paletteContent.GetContentImageH(state));
				int contentImageV = (int)paletteContent.GetContentImageV(state);
				allocation[num, contentImageV].Width += memento.ImageRect.Width;
				allocation[num, contentImageV].Height += memento.ImageRect.Height;
				memento.DrawImage = true;
			}
		}
		catch
		{
			memento.Image = null;
			memento.DrawImage = false;
		}
	}

	private static void AllocateShortTextSpace(ViewLayoutContext context, Graphics g, StandardContentMemento memento, IPaletteContent paletteContent, IContentValues contentValues, PaletteState state, Rectangle displayRect, RightToLeft rtl, int spacingGap, ref Size[,] allocation, bool composition)
	{
		memento.DrawShortText = false;
		string text = contentValues.GetShortText();
		if (text != null && text.Length > 0)
		{
			if (paletteContent.GetContentShortTextMultiLine(state) == InheritBool.False)
			{
				text = text.Replace("\r\n", " ");
				text = text.Replace("\n", " ");
				text = text.Replace("\r", " ");
			}
			int alignHIndex = RightToLeftIndex(rtl, paletteContent.GetContentShortTextH(state));
			int contentShortTextV = (int)paletteContent.GetContentShortTextV(state);
			memento.ShortTextHint = CommonHelper.PaletteTextHintToRenderingHint(paletteContent.GetContentShortTextHint(state));
			memento.ShortTextTrimming = paletteContent.GetContentShortTextTrim(state);
			bool disposeFont = false;
			Font font = paletteContent.GetContentShortTextFont(state);
			if (paletteContent.GetContentStyle() == PaletteContentStyle.HeaderForm)
			{
				Font font2 = ContentFontForButtonForm(context, font);
				disposeFont = font2 != font;
				font = font2;
			}
			memento.ShortTextMemento = AccurateText.MeasureString(g, rtl, text, font, memento.ShortTextTrimming, paletteContent.GetContentShortTextMultiLineH(state), paletteContent.GetContentShortTextPrefix(state), memento.ShortTextHint, composition, disposeFont);
			Size requiredSize = memento.ShortTextMemento.Size;
			if (AllocateAlignmentSpace(alignHIndex, contentShortTextV, allocation, displayRect, spacingGap, memento.ShortTextTrimming, ref requiredSize))
			{
				memento.ShortTextRect.Size = requiredSize;
				memento.DrawShortText = true;
			}
		}
	}

	private static void AllocateLongTextSpace(ViewLayoutContext context, Graphics g, StandardContentMemento memento, IPaletteContent paletteContent, IContentValues contentValues, PaletteState state, Rectangle displayRect, RightToLeft rtl, int spacingGap, ref Size[,] allocation, bool composition)
	{
		memento.DrawLongText = false;
		string text = contentValues.GetLongText();
		if (text != null && text.Length > 0)
		{
			if (paletteContent.GetContentLongTextMultiLine(state) == InheritBool.False)
			{
				text = text.Replace("\r\n", " ");
				text = text.Replace("\n", " ");
				text = text.Replace("\r", " ");
			}
			int alignHIndex = RightToLeftIndex(rtl, paletteContent.GetContentLongTextH(state));
			int contentLongTextV = (int)paletteContent.GetContentLongTextV(state);
			memento.LongTextHint = CommonHelper.PaletteTextHintToRenderingHint(paletteContent.GetContentLongTextHint(state));
			memento.LongTextTrimming = paletteContent.GetContentLongTextTrim(state);
			bool disposeFont = false;
			Font font = paletteContent.GetContentLongTextFont(state);
			if (paletteContent.GetContentStyle() == PaletteContentStyle.HeaderForm)
			{
				Font font2 = ContentFontForButtonForm(context, font);
				disposeFont = font2 != font;
				font = font2;
			}
			memento.LongTextMemento = AccurateText.MeasureString(g, rtl, text, font, memento.LongTextTrimming, paletteContent.GetContentLongTextMultiLineH(state), paletteContent.GetContentLongTextPrefix(state), memento.LongTextHint, composition, disposeFont);
			Size requiredSize = memento.LongTextMemento.Size;
			if (AllocateAlignmentSpace(alignHIndex, contentLongTextV, allocation, displayRect, spacingGap, memento.LongTextTrimming, ref requiredSize))
			{
				memento.LongTextRect.Size = requiredSize;
				memento.DrawLongText = true;
			}
		}
	}

	private static int RightToLeftIndex(RightToLeft rtl, PaletteRelativeAlign align)
	{
		switch (align)
		{
		case PaletteRelativeAlign.Near:
			return (rtl == RightToLeft.Yes) ? 2 : 0;
		case PaletteRelativeAlign.Center:
			return 1;
		case PaletteRelativeAlign.Far:
			return (rtl != RightToLeft.Yes) ? 2 : 0;
		default:
			Debug.Assert(condition: false);
			throw new ArgumentOutOfRangeException("align");
		}
	}

	private static int AllocatedTotalWidth(Size[,] allocation, int colIndex, int rowIndex, int spacingGap)
	{
		int[] array = AllocatedColumnWidths(allocation, rowIndex);
		int num = array[0] + array[1] + array[2];
		if (num > 0 && colIndex >= 0 && array[colIndex] == 0)
		{
			num += spacingGap;
		}
		if (array[0] > 0 && array[1] > 0)
		{
			num += spacingGap;
		}
		if (array[1] > 0 && array[2] > 0)
		{
			num += spacingGap;
		}
		if (array[0] > 0 && array[1] == 0 && array[2] > 0)
		{
			num += spacingGap;
		}
		return num;
	}

	private static int AllocatedTotalHeight(Size[,] allocation)
	{
		int[] array = AllocatedRowHeights(allocation);
		return array[0] + array[1] + array[2];
	}

	private static int[] AllocatedColumnWidths(Size[,] allocation, int rowIndex)
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			if (rowIndex == -1)
			{
				for (int j = 0; j < 3; j++)
				{
					if (allocation[i, j].Width > array[i])
					{
						array[i] = allocation[i, j].Width;
					}
				}
			}
			else if (allocation[i, rowIndex].Width > array[i])
			{
				array[i] = allocation[i, rowIndex].Width;
			}
		}
		return array;
	}

	private static int[] AllocatedRowHeights(Size[,] allocation)
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (allocation[j, i].Height > array[i])
				{
					array[i] = allocation[j, i].Height;
				}
			}
		}
		return array;
	}

	private static bool AllocateAlignmentSpace(int alignHIndex, int alignVIndex, Size[,] allocation, Rectangle displayRect, int spacingGap, PaletteTextTrim trim, ref Size requiredSize)
	{
		Size size = allocation[alignHIndex, alignVIndex];
		bool flag = false;
		int num = requiredSize.Width;
		if (allocation[alignHIndex, alignVIndex].Width > 0)
		{
			num += spacingGap;
			flag = true;
		}
		int num2 = AllocatedTotalWidth(allocation, alignHIndex, alignVIndex, spacingGap);
		int num3 = displayRect.Width - num2;
		if (num3 < num)
		{
			if (trim == PaletteTextTrim.Hide)
			{
				return false;
			}
			if (num != requiredSize.Width && !(num > requiredSize.Width && flag))
			{
				return false;
			}
			num = num3;
			if (flag)
			{
				requiredSize.Width = num - spacingGap;
			}
			else
			{
				requiredSize.Width = num;
			}
		}
		allocation[alignHIndex, alignVIndex].Width += num;
		if (requiredSize.Height > allocation[alignHIndex, alignVIndex].Height)
		{
			allocation[alignHIndex, alignVIndex].Height = requiredSize.Height;
		}
		int num4 = AllocatedTotalHeight(allocation);
		if (num4 > displayRect.Height)
		{
			allocation[alignHIndex, alignVIndex] = size;
			return false;
		}
		return true;
	}

	private static void ApplyExcessSpace(int excess, ref int[] cells)
	{
		if (cells[1] > 0)
		{
			cells[1] += excess;
			return;
		}
		if (cells[2] == 0)
		{
			cells[0] += excess;
			return;
		}
		if (cells[0] == 0)
		{
			cells[2] += excess;
			return;
		}
		int num = excess / 2;
		cells[0] += num;
		cells[2] += excess - num;
	}

	private static void PositionAlignContent(StandardContentMemento memento, IPaletteContent paletteContent, PaletteState state, RightToLeft rtl, PaletteRelativeAlign alignH, PaletteRelativeAlign alignV, int cellX, int cellY, int cellWidth, int cellHeight, int spacingGap)
	{
		Rectangle cellRect = new Rectangle(cellX, cellY, cellWidth, cellHeight);
		PaletteRelativeAlign contentImageH = paletteContent.GetContentImageH(state);
		PaletteRelativeAlign contentImageV = paletteContent.GetContentImageV(state);
		PaletteRelativeAlign contentShortTextH = paletteContent.GetContentShortTextH(state);
		PaletteRelativeAlign contentShortTextV = paletteContent.GetContentShortTextV(state);
		PaletteRelativeAlign contentLongTextH = paletteContent.GetContentLongTextH(state);
		PaletteRelativeAlign contentLongTextV = paletteContent.GetContentLongTextV(state);
		PaletteRelativeAlign drawH = contentImageH;
		PaletteRelativeAlign drawH2 = contentShortTextH;
		PaletteRelativeAlign drawH3 = contentLongTextH;
		if (alignH == PaletteRelativeAlign.Center)
		{
			int num = 0;
			int num2 = 0;
			if (memento.DrawImage && contentImageH == alignH && contentImageV == alignV)
			{
				num += memento.ImageRect.Width;
				num2++;
			}
			if (memento.DrawShortText && contentShortTextH == alignH && contentShortTextV == alignV)
			{
				num += memento.ShortTextRect.Width;
				num2++;
			}
			if (memento.DrawLongText && contentLongTextH == alignH && contentLongTextV == alignV)
			{
				num += memento.LongTextRect.Width;
				num2++;
			}
			if (num2 > 1)
			{
				num += (num2 - 1) * spacingGap;
				int num3 = (cellRect.Width - num) / 2;
				cellRect.Width -= num3 * 2;
				cellRect.X += num3;
				drawH = (drawH2 = (drawH3 = PaletteRelativeAlign.Near));
			}
		}
		if (memento.DrawImage && contentImageH == alignH && contentImageV == alignV)
		{
			memento.ImageRect.Location = PositionCellContent(rtl, drawH, contentImageV, memento.ImageRect.Size, spacingGap, ref cellRect);
		}
		if (memento.DrawShortText && contentShortTextH == alignH && contentShortTextV == alignV)
		{
			memento.ShortTextRect.Location = PositionCellContent(rtl, drawH2, contentShortTextV, memento.ShortTextRect.Size, spacingGap, ref cellRect);
		}
		if (memento.DrawLongText && contentLongTextH == alignH && contentLongTextV == alignV)
		{
			memento.LongTextRect.Location = PositionCellContent(rtl, drawH3, contentLongTextV, memento.LongTextRect.Size, spacingGap, ref cellRect);
		}
	}

	private static Point PositionCellContent(RightToLeft rtl, PaletteRelativeAlign drawH, PaletteRelativeAlign drawV, Size contentSize, int spacingGap, ref Rectangle cellRect)
	{
		Point empty = Point.Empty;
		if (rtl == RightToLeft.Yes)
		{
			switch (drawH)
			{
			case PaletteRelativeAlign.Near:
				drawH = PaletteRelativeAlign.Far;
				break;
			case PaletteRelativeAlign.Far:
				drawH = PaletteRelativeAlign.Near;
				break;
			}
		}
		switch (drawH)
		{
		case PaletteRelativeAlign.Near:
			empty.X = cellRect.Left;
			cellRect.X += contentSize.Width + spacingGap;
			cellRect.Width -= contentSize.Width + spacingGap;
			break;
		case PaletteRelativeAlign.Center:
		{
			int num = (cellRect.Width - contentSize.Width) / 2;
			empty.X = cellRect.Left + num;
			break;
		}
		case PaletteRelativeAlign.Far:
			empty.X = cellRect.Right - contentSize.Width;
			cellRect.Width -= contentSize.Width + spacingGap;
			break;
		}
		switch (drawV)
		{
		case PaletteRelativeAlign.Near:
			empty.Y = cellRect.Top;
			break;
		case PaletteRelativeAlign.Center:
		{
			int num2 = (cellRect.Height - contentSize.Height) / 2;
			empty.Y = cellRect.Top + num2;
			break;
		}
		case PaletteRelativeAlign.Far:
			empty.Y = cellRect.Bottom - contentSize.Height;
			break;
		}
		return empty;
	}

	private static CheckBoxState DiscoverCheckBoxState(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		switch (checkState)
		{
		default:
			if (!enabled)
			{
				return CheckBoxState.UncheckedDisabled;
			}
			if (pressed)
			{
				return CheckBoxState.UncheckedPressed;
			}
			if (tracking)
			{
				return CheckBoxState.UncheckedHot;
			}
			return CheckBoxState.UncheckedNormal;
		case CheckState.Checked:
			if (!enabled)
			{
				return CheckBoxState.CheckedDisabled;
			}
			if (pressed)
			{
				return CheckBoxState.CheckedPressed;
			}
			if (tracking)
			{
				return CheckBoxState.CheckedHot;
			}
			return CheckBoxState.CheckedNormal;
		case CheckState.Indeterminate:
			if (!enabled)
			{
				return CheckBoxState.MixedDisabled;
			}
			if (pressed)
			{
				return CheckBoxState.MixedPressed;
			}
			if (tracking)
			{
				return CheckBoxState.MixedHot;
			}
			return CheckBoxState.MixedNormal;
		}
	}

	private RadioButtonState DiscoverRadioButtonState(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		if (checkState)
		{
			if (!enabled)
			{
				return RadioButtonState.CheckedDisabled;
			}
			if (pressed)
			{
				return RadioButtonState.CheckedPressed;
			}
			if (tracking)
			{
				return RadioButtonState.CheckedHot;
			}
			return RadioButtonState.CheckedNormal;
		}
		if (!enabled)
		{
			return RadioButtonState.UncheckedDisabled;
		}
		if (pressed)
		{
			return RadioButtonState.UncheckedPressed;
		}
		if (tracking)
		{
			return RadioButtonState.UncheckedHot;
		}
		return RadioButtonState.UncheckedNormal;
	}

	private void MeasureDragDockingSquares(RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette)
	{
		dragData.DockWindowSize = new Size(88, 88);
		if (dragData.ShowMiddle)
		{
			dragData.RectLeft = new Rectangle(0, 29, 29, 29);
			dragData.RectRight = new Rectangle(59, 29, 29, 29);
			dragData.RectTop = new Rectangle(29, 0, 29, 29);
			dragData.RectBottom = new Rectangle(29, 59, 29, 29);
			dragData.RectMiddle = new Rectangle(23, 23, 40, 40);
		}
		else
		{
			dragData.RectLeft = new Rectangle(0, 29, 32, 29);
			dragData.RectRight = new Rectangle(56, 29, 32, 29);
			dragData.RectTop = new Rectangle(29, 0, 29, 32);
			dragData.RectBottom = new Rectangle(29, 56, 29, 31);
		}
	}

	private void MeasureDragDockingRounded(RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette)
	{
		dragData.DockWindowSize = new Size(103, 103);
		dragData.RectLeft = new Rectangle(0, 36, 32, 31);
		dragData.RectRight = new Rectangle(71, 36, 32, 31);
		dragData.RectTop = new Rectangle(36, 0, 31, 32);
		dragData.RectBottom = new Rectangle(36, 71, 31, 32);
		dragData.RectMiddle = new Rectangle(36, 36, 31, 31);
	}

	private void DrawDragDockingRounded(RenderContext context, RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette)
	{
		Color dragDropDockBack = dragDropPalette.GetDragDropDockBack();
		Color dragDropDockBorder = dragDropPalette.GetDragDropDockBorder();
		Color dragDropDockActive = dragDropPalette.GetDragDropDockActive();
		Color dragDropDockInactive = dragDropPalette.GetDragDropDockInactive();
		DrawDragDockingRoundedBackground(context, dragDropDockBack, dragDropDockBorder, dragData);
		if (dragData.ShowLeft)
		{
			DrawDragDockingRoundedLeft(context, dragDropDockBack, dragDropDockBorder, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowRight)
		{
			DrawDragDockingRoundedRight(context, dragDropDockBack, dragDropDockBorder, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowTop)
		{
			DrawDragDockingRoundedTop(context, dragDropDockBack, dragDropDockBorder, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowBottom)
		{
			DrawDragDockingRoundedBottom(context, dragDropDockBack, dragDropDockBorder, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowMiddle)
		{
			DrawDragDockingRoundedMiddle(context, dragDropDockBack, dragDropDockBorder, dragDropDockActive, dragDropDockInactive, dragData);
		}
	}

	private void DrawDragDockingRoundedBackground(RenderContext context, Color inside, Color border, RenderDragDockingData dragData)
	{
		if (dragData.ShowBack)
		{
			DrawDragDockingRoundedRect(context, inside, border, new Rectangle(16, 16, 73, 73), 11);
		}
	}

	private void DrawDragDockingRoundedLeft(RenderContext context, Color inside, Color border, Color active, Color inactive, RenderDragDockingData dragData)
	{
		DrawDragDockingRoundedRect(context, dragData.ActiveLeft ? active : inside, dragData.ActiveLeft ? active : border, dragData.RectLeft, 3);
		DrawDragDockingArrow(context, active, dragData.RectLeft, VisualOrientation.Left);
	}

	private void DrawDragDockingRoundedRight(RenderContext context, Color inside, Color border, Color active, Color inactive, RenderDragDockingData dragData)
	{
		DrawDragDockingRoundedRect(context, dragData.ActiveRight ? active : inside, dragData.ActiveRight ? active : border, dragData.RectRight, 3);
		DrawDragDockingArrow(context, active, dragData.RectRight, VisualOrientation.Right);
	}

	private void DrawDragDockingRoundedTop(RenderContext context, Color inside, Color border, Color active, Color inactive, RenderDragDockingData dragData)
	{
		DrawDragDockingRoundedRect(context, dragData.ActiveTop ? active : inside, dragData.ActiveTop ? active : border, dragData.RectTop, 3);
		DrawDragDockingArrow(context, active, dragData.RectTop, VisualOrientation.Top);
	}

	private void DrawDragDockingRoundedBottom(RenderContext context, Color inside, Color border, Color active, Color inactive, RenderDragDockingData dragData)
	{
		DrawDragDockingRoundedRect(context, dragData.ActiveBottom ? active : inside, dragData.ActiveBottom ? active : border, dragData.RectBottom, 3);
		DrawDragDockingArrow(context, active, dragData.RectBottom, VisualOrientation.Bottom);
	}

	private void DrawDragDockingRoundedMiddle(RenderContext context, Color inside, Color border, Color active, Color inactive, RenderDragDockingData dragData)
	{
		Color color = (dragData.ActiveMiddle ? active : border);
		Color color2 = (dragData.ActiveMiddle ? active : inside);
		using (new AntiAlias(context.Graphics))
		{
			using GraphicsPath path = new GraphicsPath();
			using GraphicsPath path2 = new GraphicsPath();
			Rectangle rectMiddle = dragData.RectMiddle;
			Rectangle rect = new Rectangle(rectMiddle.X + 2, rectMiddle.Y + 2, rectMiddle.Width - 4, rectMiddle.Height - 4);
			DrawDragDockingMiddleLines(path, dragData.RectMiddle, 13);
			DrawDragDockingMiddleLines(path2, rect, 9);
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(196, Color.White)))
			{
				context.Graphics.FillPath(brush, path);
			}
			RectangleF rect2 = new RectangleF(rectMiddle.X - 1, rectMiddle.Y - 1, rectMiddle.Width + 2, rectMiddle.Height + 2);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, Color.FromArgb(196, Color.White), color2, 90f))
			{
				linearGradientBrush.Blend = _dragRoundedInsideBlend;
				context.Graphics.FillPath(linearGradientBrush, path2);
			}
			using Pen pen = new Pen(color);
			context.Graphics.DrawPath(pen, path);
			context.Graphics.DrawLine(pen, new Point(rectMiddle.Right - 2, rectMiddle.Bottom - 3), new Point(rectMiddle.Right - 2, rectMiddle.Bottom - 2));
			context.Graphics.DrawLine(pen, new Point(rectMiddle.Right - 10, rectMiddle.Bottom - 3), new Point(rectMiddle.Right - 10, rectMiddle.Bottom - 2));
			context.Graphics.DrawLine(pen, new Point(rectMiddle.Right - 3, rectMiddle.Bottom - 1), new Point(rectMiddle.X + 9, rectMiddle.Bottom - 1));
		}
	}

	private void DrawDragDockingMiddleLines(GraphicsPath path, Rectangle rect, int tabExtend)
	{
		path.AddLines(new Point[12]
		{
			new Point(rect.X, rect.Bottom - 2),
			new Point(rect.X, rect.Y + 1),
			new Point(rect.X + 1, rect.Y),
			new Point(rect.Right - 1, rect.Y),
			new Point(rect.Right, rect.Y + 1),
			new Point(rect.Right, rect.Bottom - 6),
			new Point(rect.Right - 2, rect.Bottom - 4),
			new Point(rect.X + tabExtend, rect.Bottom - 4),
			new Point(rect.X + tabExtend, rect.Bottom - 2),
			new Point(rect.X + tabExtend - 1, rect.Bottom - 1),
			new Point(rect.X + 1, rect.Bottom - 1),
			new Point(rect.X, rect.Bottom - 2)
		});
	}

	private void DrawDragDockingRoundedRect(RenderContext context, Color inside, Color border, Rectangle drawRect, int rounding)
	{
		using (new AntiAlias(context.Graphics))
		{
			RectangleF rect = new RectangleF(drawRect.X - 1, drawRect.Y - 1, drawRect.Width + 2, drawRect.Height + 1);
			Rectangle rect2 = new Rectangle(drawRect.X + 2, drawRect.Y + 2, drawRect.Width - 4, drawRect.Height - 4);
			using GraphicsPath path = CreateBorderBackPath(forBorder: true, middle: true, drawRect, PaletteDrawBorders.All, 1, rounding, smoothing: true, 0);
			using GraphicsPath path2 = CreateBorderBackPath(forBorder: true, middle: true, rect2, PaletteDrawBorders.All, 1, rounding - 1, smoothing: true, 0);
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(196, Color.White)))
			{
				context.Graphics.FillPath(brush, path);
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(196, Color.White), inside, 90f))
			{
				linearGradientBrush.Blend = _dragRoundedInsideBlend;
				context.Graphics.FillPath(linearGradientBrush, path2);
			}
			using Pen pen = new Pen(border);
			context.Graphics.DrawPath(pen, path);
		}
	}

	private void DrawDragDockingArrow(RenderContext context, Color active, Rectangle rect, VisualOrientation orientation)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		float angle = 0f;
		switch (orientation)
		{
		case VisualOrientation.Left:
			rect = new Rectangle(rect.Right - _dragArrowHeight - _dragArrowGap, rect.Y + (rect.Height - _dragArrowWidth) / 2, _dragArrowHeight, _dragArrowWidth);
			graphicsPath.AddLines(new Point[3]
			{
				new Point(rect.X + 1, rect.Top + 6),
				new Point(rect.Right - 1, rect.Top + 1),
				new Point(rect.Right - 1, rect.Bottom - 2)
			});
			break;
		case VisualOrientation.Right:
			rect = new Rectangle(rect.Left + _dragArrowGap, rect.Y + (rect.Height - _dragArrowWidth) / 2, _dragArrowHeight, _dragArrowWidth);
			graphicsPath.AddLines(new Point[3]
			{
				new Point(rect.X + 1, rect.Top + 1),
				new Point(rect.X + 1, rect.Bottom - 2),
				new Point(rect.Right - 1, rect.Top + 6)
			});
			angle = 180f;
			break;
		case VisualOrientation.Top:
			rect = new Rectangle(rect.X + (rect.Width - _dragArrowWidth) / 2, rect.Bottom - _dragArrowHeight - _dragArrowGap - 1, _dragArrowWidth, _dragArrowHeight);
			graphicsPath.AddLines(new Point[3]
			{
				new Point(rect.X + 1, rect.Bottom),
				new Point(rect.Right - 1, rect.Bottom),
				new Point(rect.X + 6, rect.Top + 1)
			});
			angle = 90f;
			break;
		case VisualOrientation.Bottom:
			rect = new Rectangle(rect.X + (rect.Width - _dragArrowWidth) / 2, rect.Top + _dragArrowGap, _dragArrowWidth, _dragArrowHeight);
			graphicsPath.AddLines(new Point[3]
			{
				new Point(rect.X + 2, rect.Top + 1),
				new Point(rect.Right - 2, rect.Top + 1),
				new Point(rect.X + 6, rect.Bottom - 1)
			});
			angle = 270f;
			break;
		}
		using (new AntiAlias(context.Graphics))
		{
			context.Graphics.FillPath(Brushes.White, graphicsPath);
		}
		using LinearGradientBrush brush = new LinearGradientBrush(rect, ControlPaint.Dark(active), ControlPaint.Light(active), angle);
		context.Graphics.FillPath(brush, graphicsPath);
	}

	private void DrawDragDockingSquares(RenderContext context, RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette)
	{
		Color dragDropDockBack = dragDropPalette.GetDragDropDockBack();
		Color dragDropDockBorder = dragDropPalette.GetDragDropDockBorder();
		Color dragDropDockActive = dragDropPalette.GetDragDropDockActive();
		Color dragDropDockInactive = dragDropPalette.GetDragDropDockInactive();
		DrawDragDockingSquaresBackground(context.Graphics, dragDropDockBack, dragDropDockBorder, dragData);
		if (dragData.ShowLeft)
		{
			DrawDragDockingSquaresLeft(context.Graphics, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowRight)
		{
			DrawDragDockingSquaresRight(context.Graphics, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowTop)
		{
			DrawDragDockingSquaresTop(context.Graphics, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowBottom)
		{
			DrawDragDockingSquaresBottom(context.Graphics, dragDropDockActive, dragDropDockInactive, dragData);
		}
		if (dragData.ShowMiddle)
		{
			DrawDragDockingSquaresMiddle(context.Graphics, dragDropDockActive, dragDropDockInactive, dragData);
		}
	}

	private void DrawDragDockingSquaresBackground(Graphics g, Color inside, Color border, RenderDragDockingData dragData)
	{
		Color color = Color.FromArgb(190, 190, 190);
		using Pen pen = new Pen(border);
		using SolidBrush brush = new SolidBrush(inside);
		using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(-1, -1, 5, 5), color, inside, 0f);
		using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(-1, 23, 5, 5), color, inside, 90f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(24, 25, 5, 5), color, inside, 45f);
		using LinearGradientBrush brush5 = new LinearGradientBrush(new Rectangle(28, -1, 5, 5), color, inside, 0f);
		using LinearGradientBrush brush6 = new LinearGradientBrush(new Rectangle(22, -1, 5, 5), color, inside, 0f);
		using LinearGradientBrush brush7 = new LinearGradientBrush(new Rectangle(-1, 22, 5, 5), color, inside, 90f);
		using LinearGradientBrush brush8 = new LinearGradientBrush(new Rectangle(-1, -1, 5, 5), color, inside, 90f);
		if (dragData.ShowBack)
		{
			Point[] points = new Point[16]
			{
				new Point(0, 29),
				new Point(23, 29),
				new Point(29, 23),
				new Point(29, 0),
				new Point(57, 0),
				new Point(57, 23),
				new Point(63, 29),
				new Point(87, 29),
				new Point(87, 57),
				new Point(63, 57),
				new Point(57, 63),
				new Point(57, 87),
				new Point(29, 87),
				new Point(29, 63),
				new Point(23, 57),
				new Point(0, 57)
			};
			g.FillPolygon(brush, points);
			g.FillPolygon(brush2, new Point[4]
			{
				new Point(1, 57),
				new Point(1, 30),
				new Point(4, 33),
				new Point(4, 57)
			});
			g.FillPolygon(brush3, new Point[4]
			{
				new Point(1, 30),
				new Point(25, 30),
				new Point(27, 33),
				new Point(3, 33)
			});
			g.FillPolygon(brush4, new Point[4]
			{
				new Point(23, 30),
				new Point(30, 23),
				new Point(33, 26),
				new Point(26, 33)
			});
			g.FillPolygon(brush5, new Point[4]
			{
				new Point(30, 1),
				new Point(30, 24),
				new Point(33, 26),
				new Point(33, 4)
			});
			g.FillPolygon(brush8, new Point[4]
			{
				new Point(30, 1),
				new Point(57, 1),
				new Point(57, 4),
				new Point(33, 4)
			});
			g.FillPolygon(brush5, new Point[4]
			{
				new Point(30, 63),
				new Point(30, 87),
				new Point(33, 87),
				new Point(33, 66)
			});
			g.FillPolygon(brush3, new Point[4]
			{
				new Point(63, 30),
				new Point(87, 30),
				new Point(87, 33),
				new Point(66, 33)
			});
			g.DrawPolygon(pen, points);
		}
		else if (dragData.ShowLeft && dragData.ShowRight)
		{
			Point[] points2 = new Point[12]
			{
				new Point(0, 29),
				new Point(23, 29),
				new Point(29, 23),
				new Point(57, 23),
				new Point(63, 29),
				new Point(87, 29),
				new Point(87, 57),
				new Point(63, 57),
				new Point(57, 63),
				new Point(29, 63),
				new Point(23, 57),
				new Point(0, 57)
			};
			g.FillPolygon(brush, points2);
			g.FillPolygon(brush2, new Point[4]
			{
				new Point(1, 57),
				new Point(1, 30),
				new Point(4, 33),
				new Point(4, 57)
			});
			g.FillPolygon(brush3, new Point[4]
			{
				new Point(1, 30),
				new Point(25, 30),
				new Point(27, 33),
				new Point(3, 33)
			});
			g.FillPolygon(brush4, new Point[4]
			{
				new Point(23, 30),
				new Point(30, 23),
				new Point(33, 26),
				new Point(26, 33)
			});
			g.FillPolygon(brush7, new Point[4]
			{
				new Point(30, 24),
				new Point(57, 24),
				new Point(60, 27),
				new Point(33, 27)
			});
			g.FillPolygon(brush3, new Point[4]
			{
				new Point(63, 30),
				new Point(87, 30),
				new Point(87, 33),
				new Point(66, 33)
			});
			g.DrawPolygon(pen, points2);
		}
		else if (dragData.ShowLeft)
		{
			g.FillRectangle(brush, 0, 29, 31, 28);
			g.DrawRectangle(pen, 0, 29, 31, 28);
		}
		else if (dragData.ShowRight)
		{
			g.FillRectangle(brush, 56, 29, 31, 28);
			g.DrawRectangle(pen, 56, 29, 31, 28);
		}
		else if (dragData.ShowTop && dragData.ShowBottom)
		{
			Point[] points3 = new Point[12]
			{
				new Point(23, 29),
				new Point(29, 23),
				new Point(29, 0),
				new Point(57, 0),
				new Point(57, 23),
				new Point(63, 29),
				new Point(63, 57),
				new Point(57, 63),
				new Point(57, 87),
				new Point(29, 87),
				new Point(29, 63),
				new Point(23, 57)
			};
			g.FillPolygon(brush, points3);
			g.FillPolygon(brush5, new Point[4]
			{
				new Point(30, 1),
				new Point(30, 24),
				new Point(33, 26),
				new Point(33, 4)
			});
			g.FillPolygon(brush8, new Point[4]
			{
				new Point(30, 1),
				new Point(57, 1),
				new Point(57, 4),
				new Point(33, 4)
			});
			g.FillPolygon(brush4, new Point[4]
			{
				new Point(23, 30),
				new Point(30, 23),
				new Point(33, 26),
				new Point(26, 33)
			});
			g.FillPolygon(brush6, new Point[4]
			{
				new Point(24, 57),
				new Point(24, 30),
				new Point(27, 33),
				new Point(27, 60)
			});
			g.FillPolygon(brush5, new Point[4]
			{
				new Point(30, 63),
				new Point(30, 87),
				new Point(33, 87),
				new Point(33, 66)
			});
			g.DrawPolygon(pen, points3);
		}
		else if (dragData.ShowTop)
		{
			g.FillRectangle(brush, 29, 0, 28, 31);
			g.DrawRectangle(pen, 29, 0, 28, 31);
		}
		else if (dragData.ShowBottom)
		{
			g.FillRectangle(brush, 29, 56, 28, 31);
			g.DrawRectangle(pen, 29, 56, 28, 31);
		}
		else if (dragData.ShowMiddle)
		{
			Point[] points4 = new Point[8]
			{
				new Point(23, 29),
				new Point(29, 23),
				new Point(57, 23),
				new Point(63, 29),
				new Point(63, 57),
				new Point(57, 63),
				new Point(29, 63),
				new Point(23, 57)
			};
			g.FillPolygon(brush, points4);
			g.DrawPolygon(pen, points4);
		}
	}

	private void DrawDragDockingSquaresLeft(Graphics g, Color activeColor, Color inactiveColor, RenderDragDockingData dragData)
	{
		Color color = ControlPaint.Dark(activeColor);
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color);
		using Pen pen3 = new Pen(_190);
		using Pen pen4 = new Pen(_218);
		using LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(4, 33, 23, 1), ControlPaint.LightLight(inactiveColor), activeColor, 0f);
		using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(4, 34, 23, 1), ControlPaint.Light(activeColor), activeColor, 0f);
		using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(4, 35, 11, 1), Color.FromArgb(160, inactiveColor), Color.FromArgb(64, inactiveColor), 0f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(18, 40, 5, 8), color, Color.FromArgb(175, color), 0f);
		g.DrawLine(pen, 4, 33, 4, 53);
		g.DrawLine(pen, 27, 33, 27, 53);
		g.DrawLine(pen, 4, 53, 27, 53);
		g.DrawLine(pen, 4, 33, 27, 33);
		g.DrawLine(pen3, 5, 54, 28, 54);
		g.DrawLine(pen3, 28, 34, 28, 54);
		g.DrawLine(pen4, 6, 55, 29, 55);
		g.DrawLine(pen4, 29, 35, 29, 55);
		g.FillRectangle(brush, 5, 34, 22, 1);
		g.FillRectangle(brush2, 5, 35, 22, 1);
		g.FillRectangle(SystemBrushes.Window, 5, 36, 22, 17);
		g.FillRectangle(brush3, 5, 36, 11, 17);
		pen2.DashStyle = DashStyle.Dot;
		g.DrawLine(pen2, 15, 37, 15, 52);
		g.FillPolygon(brush4, new Point[4]
		{
			new Point(19, 44),
			new Point(23, 40),
			new Point(23, 48),
			new Point(19, 44)
		});
		if (dragData.ActiveLeft)
		{
			g.DrawLine(pen, 0, 29, 23, 29);
			g.DrawLine(pen, 0, 57, 23, 57);
			g.DrawLine(pen, 0, 29, 0, 57);
		}
	}

	private void DrawDragDockingSquaresRight(Graphics g, Color activeColor, Color inactiveColor, RenderDragDockingData dragData)
	{
		Color color = ControlPaint.Dark(activeColor);
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color);
		using Pen pen3 = new Pen(_190);
		using Pen pen4 = new Pen(_218);
		using LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(60, 33, 23, 1), ControlPaint.LightLight(inactiveColor), activeColor, 0f);
		using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(60, 34, 23, 1), ControlPaint.Light(activeColor), activeColor, 0f);
		using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(71, 35, 11, 1), Color.FromArgb(160, inactiveColor), Color.FromArgb(64, inactiveColor), 180f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(68, 40, 5, 8), color, Color.FromArgb(175, color), 180f);
		g.DrawLine(pen, 60, 33, 60, 53);
		g.DrawLine(pen, 83, 33, 83, 53);
		g.DrawLine(pen, 60, 53, 83, 53);
		g.DrawLine(pen, 60, 33, 83, 33);
		g.DrawLine(pen3, 61, 54, 84, 54);
		g.DrawLine(pen3, 84, 34, 84, 54);
		g.DrawLine(pen4, 62, 55, 85, 55);
		g.DrawLine(pen4, 85, 35, 85, 55);
		g.FillRectangle(brush, 61, 34, 22, 1);
		g.FillRectangle(brush2, 61, 35, 22, 1);
		g.FillRectangle(SystemBrushes.Window, 61, 36, 22, 17);
		g.FillRectangle(brush3, 72, 36, 11, 17);
		pen2.DashStyle = DashStyle.Dot;
		g.DrawLine(pen2, 72, 37, 72, 52);
		g.FillPolygon(brush4, new Point[4]
		{
			new Point(69, 44),
			new Point(65, 40),
			new Point(65, 48),
			new Point(69, 44)
		});
		if (dragData.ActiveRight)
		{
			g.DrawLine(pen, 87, 29, 63, 29);
			g.DrawLine(pen, 87, 57, 63, 57);
			g.DrawLine(pen, 87, 29, 87, 57);
		}
	}

	private void DrawDragDockingSquaresTop(Graphics g, Color activeColor, Color inactiveColor, RenderDragDockingData dragData)
	{
		Color color = ControlPaint.Dark(activeColor);
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color);
		using Pen pen3 = new Pen(_190);
		using Pen pen4 = new Pen(_218);
		using LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(33, 5, 20, 1), ControlPaint.LightLight(inactiveColor), activeColor, 0f);
		using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(33, 6, 20, 1), ControlPaint.Light(activeColor), activeColor, 0f);
		using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(34, 6, 19, 10), Color.FromArgb(160, inactiveColor), Color.FromArgb(64, inactiveColor), 90f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(39, 40, 8, 4), color, Color.FromArgb(175, color), 90f);
		g.DrawLine(pen, 33, 4, 53, 4);
		g.DrawLine(pen, 53, 4, 53, 27);
		g.DrawLine(pen, 53, 27, 33, 27);
		g.DrawLine(pen, 33, 27, 33, 4);
		g.DrawLine(pen3, 34, 28, 54, 28);
		g.DrawLine(pen3, 54, 5, 54, 28);
		g.DrawLine(pen4, 35, 29, 55, 29);
		g.DrawLine(pen4, 55, 6, 55, 29);
		g.FillRectangle(brush, 34, 5, 19, 1);
		g.FillRectangle(brush2, 34, 6, 19, 1);
		g.FillRectangle(SystemBrushes.Window, 34, 7, 19, 20);
		g.FillRectangle(brush3, 34, 7, 19, 9);
		pen2.DashStyle = DashStyle.Dot;
		g.DrawLine(pen2, 35, 15, 53, 15);
		g.FillPolygon(brush4, new Point[4]
		{
			new Point(43, 18),
			new Point(47, 23),
			new Point(39, 23),
			new Point(43, 18)
		});
		if (dragData.ActiveTop)
		{
			g.DrawLine(pen, 29, 0, 29, 23);
			g.DrawLine(pen, 57, 0, 57, 23);
			g.DrawLine(pen, 29, 0, 57, 0);
		}
	}

	private void DrawDragDockingSquaresBottom(Graphics g, Color activeColor, Color inactiveColor, RenderDragDockingData dragData)
	{
		Color color = ControlPaint.Dark(activeColor);
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color);
		using Pen pen3 = new Pen(_190);
		using Pen pen4 = new Pen(_218);
		using LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(33, 61, 20, 1), ControlPaint.LightLight(inactiveColor), activeColor, 0f);
		using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(33, 62, 20, 1), ControlPaint.Light(activeColor), activeColor, 0f);
		using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(34, 72, 19, 11), Color.FromArgb(160, inactiveColor), Color.FromArgb(64, inactiveColor), 270f);
		using LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(39, 66, 8, 4), color, Color.FromArgb(175, color), 270f);
		g.DrawLine(pen, 33, 60, 53, 60);
		g.DrawLine(pen, 53, 60, 53, 83);
		g.DrawLine(pen, 53, 83, 33, 83);
		g.DrawLine(pen, 33, 83, 33, 60);
		g.DrawLine(pen3, 34, 84, 54, 84);
		g.DrawLine(pen3, 54, 61, 54, 84);
		g.DrawLine(pen4, 35, 85, 55, 85);
		g.DrawLine(pen4, 55, 61, 55, 85);
		g.FillRectangle(brush, 34, 61, 19, 1);
		g.FillRectangle(brush2, 34, 62, 19, 1);
		g.FillRectangle(SystemBrushes.Window, 34, 63, 19, 20);
		g.FillRectangle(brush3, 34, 73, 19, 10);
		pen2.DashStyle = DashStyle.Dot;
		g.DrawLine(pen2, 35, 73, 53, 73);
		g.FillPolygon(brush4, new Point[4]
		{
			new Point(43, 71),
			new Point(47, 67),
			new Point(40, 67),
			new Point(43, 71)
		});
		if (dragData.ActiveBottom)
		{
			g.DrawLine(pen, 29, 63, 29, 87);
			g.DrawLine(pen, 57, 63, 57, 87);
			g.DrawLine(pen, 29, 87, 57, 87);
		}
	}

	private void DrawDragDockingSquaresMiddle(Graphics g, Color activeColor, Color inactiveColor, RenderDragDockingData dragData)
	{
		Color color = ControlPaint.Dark(activeColor);
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color);
		using Pen pen3 = new Pen(_190);
		using Pen pen4 = new Pen(_218);
		using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(32, 34, 21, 1), ControlPaint.LightLight(inactiveColor), activeColor, 0f))
		{
			using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(32, 35, 21, 1), ControlPaint.Light(activeColor), activeColor, 0f);
			g.DrawLine(pen, 32, 32, 54, 32);
			g.DrawLine(pen, 32, 32, 32, 53);
			g.DrawLine(pen, 32, 53, 33, 54);
			g.DrawLine(pen, 33, 54, 41, 54);
			g.DrawLine(pen, 41, 54, 42, 52);
			g.DrawLine(pen, 42, 52, 42, 50);
			g.DrawLine(pen, 42, 50, 54, 50);
			g.DrawLine(pen, 54, 32, 54, 53);
			g.DrawLine(pen, 54, 53, 53, 54);
			g.DrawLine(pen, 53, 54, 49, 54);
			g.DrawLine(pen, 49, 54, 48, 53);
			g.DrawLine(pen, 48, 53, 48, 50);
			g.DrawLine(pen, 48, 53, 47, 54);
			g.DrawLine(pen, 47, 54, 43, 54);
			g.DrawLine(pen, 43, 54, 42, 53);
			g.FillRectangle(brush, 33, 33, 21, 1);
			g.FillRectangle(brush2, 33, 34, 21, 1);
			g.FillRectangle(SystemBrushes.Window, 33, 35, 21, 15);
			g.FillRectangle(SystemBrushes.Window, 33, 50, 9, 3);
			g.FillRectangle(SystemBrushes.Window, 33, 53, 9, 1);
			g.FillRectangle(SystemBrushes.Window, 43, 51, 5, 3);
			g.FillRectangle(SystemBrushes.Window, 49, 51, 5, 3);
			using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(64, inactiveColor)))
			{
				g.FillRectangle(brush3, 34, 36, 19, 13);
				g.FillRectangle(brush3, 34, 49, 7, 3);
				g.FillRectangle(brush3, 35, 52, 5, 1);
			}
			pen2.DashStyle = DashStyle.Dot;
			g.DrawLine(pen2, 34, 37, 34, 52);
			g.DrawLine(pen2, 35, 52, 40, 52);
			g.DrawLine(pen2, 40, 51, 40, 49);
			g.DrawLine(pen2, 40, 51, 40, 48);
			g.DrawLine(pen2, 41, 48, 53, 48);
			g.DrawLine(pen2, 52, 47, 52, 36);
			g.DrawLine(pen2, 35, 36, 52, 36);
			g.DrawLine(pen3, 55, 33, 55, 53);
			g.DrawLine(pen4, 56, 34, 56, 53);
			g.DrawLine(pen3, 33, 55, 53, 55);
			g.DrawLine(pen3, 53, 55, 55, 53);
			g.DrawLine(pen4, 34, 56, 53, 56);
			g.DrawLine(pen4, 53, 56, 56, 53);
		}
		if (dragData.ActiveMiddle)
		{
			g.DrawLine(pen, 23, 29, 29, 23);
			g.DrawLine(pen, 57, 23, 63, 29);
			g.DrawLine(pen, 63, 57, 57, 63);
			g.DrawLine(pen, 23, 57, 29, 63);
		}
	}

	protected virtual IDisposable DrawRibbonGroupAreaBorder1And2(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, bool limited, bool fading, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color color = palette.GetRibbonBackColor5(state);
			if (fading)
			{
				color = Color.FromArgb(146, color);
			}
			bool flag = true;
			MementoRibbonGroupAreaBorder mementoRibbonGroupAreaBorder;
			if (memento == null || !(memento is MementoRibbonGroupAreaBorder))
			{
				memento?.Dispose();
				mementoRibbonGroupAreaBorder = new MementoRibbonGroupAreaBorder(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, color);
				memento = mementoRibbonGroupAreaBorder;
			}
			else
			{
				mementoRibbonGroupAreaBorder = (MementoRibbonGroupAreaBorder)memento;
				flag = !mementoRibbonGroupAreaBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, color);
			}
			if (flag)
			{
				mementoRibbonGroupAreaBorder.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
				graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 2);
				graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
				graphicsPath3.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Left + 1, rect.Top + 3, rect.Left + 1, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Right - 3, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 3);
				graphicsPath4.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 2, rect.Bottom);
				graphicsPath4.AddLine(rect.Left + 2, rect.Bottom, rect.Right - 3, rect.Bottom);
				graphicsPath4.AddLine(rect.Right - 4, rect.Bottom, rect.Right, rect.Bottom - 3);
				graphicsPath4.AddLine(rect.Right, rect.Bottom - 3, rect.Right, rect.Top + 3);
				LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, ribbonBackColor2, 95f);
				mementoRibbonGroupAreaBorder.insidePen = new Pen(brush);
				Rectangle rect2 = new Rectangle(rect.Left - 1, rect.Top, rect.Width + 2, rect.Height + 1);
				LinearGradientBrush brush2 = new LinearGradientBrush(rect2, _darken8, _darken38, 90f);
				LinearGradientBrush brush3 = new LinearGradientBrush(rect2, _darken8, _darken18, 90f);
				mementoRibbonGroupAreaBorder.shadowPenN = new Pen(brush2);
				mementoRibbonGroupAreaBorder.shadowPenL = new Pen(brush3);
				mementoRibbonGroupAreaBorder.insidePathN = graphicsPath2;
				mementoRibbonGroupAreaBorder.insidePathL = graphicsPath3;
				mementoRibbonGroupAreaBorder.fillBrush = new LinearGradientBrush(rect, ribbonBackColor3, ribbonBackColor4, 90f);
				mementoRibbonGroupAreaBorder.fillBrush.Blend = _ribbonGroup1Blend;
				mementoRibbonGroupAreaBorder.fillTopBrush = new LinearGradientBrush(rect, color, Color.Transparent, 90f);
				mementoRibbonGroupAreaBorder.fillTopBrush.Blend = _ribbonGroup2Blend;
				mementoRibbonGroupAreaBorder.outsidePath = graphicsPath;
				mementoRibbonGroupAreaBorder.shadowPath = graphicsPath4;
				mementoRibbonGroupAreaBorder.outsidePen = new Pen(ribbonBackColor);
			}
			context.Graphics.FillPath(mementoRibbonGroupAreaBorder.fillBrush, mementoRibbonGroupAreaBorder.outsidePath);
			using (new Clipping(context.Graphics, mementoRibbonGroupAreaBorder.outsidePath))
			{
				context.Graphics.FillPath(mementoRibbonGroupAreaBorder.fillTopBrush, mementoRibbonGroupAreaBorder.outsidePath);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonGroupAreaBorder.outsidePen, mementoRibbonGroupAreaBorder.outsidePath);
				context.Graphics.DrawPath(mementoRibbonGroupAreaBorder.insidePen, limited ? mementoRibbonGroupAreaBorder.insidePathL : mementoRibbonGroupAreaBorder.insidePathN);
			}
			Pen pen = (limited ? _lightShadowPen : _medium2ShadowPen);
			Pen pen2 = (limited ? _medium2ShadowPen : _darkShadowPen);
			context.Graphics.DrawPath(limited ? mementoRibbonGroupAreaBorder.shadowPenL : mementoRibbonGroupAreaBorder.shadowPenN, mementoRibbonGroupAreaBorder.shadowPath);
			context.Graphics.DrawLine(pen, rect.Left, rect.Bottom, rect.Left, rect.Bottom - 1);
			context.Graphics.DrawLine(pen, rect.Left, rect.Bottom - 1, rect.Left + 1, rect.Bottom);
			context.Graphics.DrawLine(pen2, rect.Right, rect.Bottom - 2, rect.Right - 2, rect.Bottom);
			context.Graphics.DrawLine(pen, rect.Right, rect.Bottom - 1, rect.Right - 1, rect.Bottom);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupAreaBorder3And4(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento, bool gradientTop)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonGroupAreaBorder3 mementoRibbonGroupAreaBorder;
			if (memento == null || !(memento is MementoRibbonGroupAreaBorder3))
			{
				memento?.Dispose();
				mementoRibbonGroupAreaBorder = new MementoRibbonGroupAreaBorder3(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
				memento = mementoRibbonGroupAreaBorder;
			}
			else
			{
				mementoRibbonGroupAreaBorder = (MementoRibbonGroupAreaBorder3)memento;
				flag = !mementoRibbonGroupAreaBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
			}
			if (flag)
			{
				mementoRibbonGroupAreaBorder.Dispose();
				Rectangle borderRect = rect;
				borderRect.Height -= 3;
				int num = borderRect.Height / 2;
				mementoRibbonGroupAreaBorder.borderRect = borderRect;
				mementoRibbonGroupAreaBorder.borderPoints = new Point[4]
				{
					new Point(borderRect.X, rect.Y),
					new Point(borderRect.X, borderRect.Bottom),
					new Point(borderRect.Right, borderRect.Bottom),
					new Point(borderRect.Right, borderRect.Top)
				};
				mementoRibbonGroupAreaBorder.backRect1 = new Rectangle(borderRect.X, borderRect.Y, rect.Width, num);
				mementoRibbonGroupAreaBorder.backRect2 = new Rectangle(borderRect.X, borderRect.Y + num, borderRect.Width, borderRect.Height - num);
				mementoRibbonGroupAreaBorder.backBrush1 = new LinearGradientBrush(new RectangleF(mementoRibbonGroupAreaBorder.backRect1.X - 1, mementoRibbonGroupAreaBorder.backRect1.Y - 1, mementoRibbonGroupAreaBorder.backRect1.Width + 2, mementoRibbonGroupAreaBorder.backRect1.Height + 1), ribbonBackColor3, ribbonBackColor4, 90f);
				mementoRibbonGroupAreaBorder.backBrush2 = new LinearGradientBrush(new RectangleF(mementoRibbonGroupAreaBorder.backRect2.X - 1, mementoRibbonGroupAreaBorder.backRect2.Y - 1, mementoRibbonGroupAreaBorder.backRect2.Width + 2, mementoRibbonGroupAreaBorder.backRect2.Height + 1), ribbonBackColor4, ribbonBackColor5, 90f);
				mementoRibbonGroupAreaBorder.backBrush3 = new SolidBrush(ribbonBackColor5);
				mementoRibbonGroupAreaBorder.gradientBorderBrush = new LinearGradientBrush(new RectangleF(mementoRibbonGroupAreaBorder.backRect1.X - 1, mementoRibbonGroupAreaBorder.backRect1.Y - 1, mementoRibbonGroupAreaBorder.backRect1.Width + 2, 3f), ribbonBackColor, ribbonBackColor2, 0f);
				mementoRibbonGroupAreaBorder.gradientBorderBrush.Blend = _ribbonGroupArea3;
				mementoRibbonGroupAreaBorder.gradientBorderPen = (gradientTop ? new Pen(mementoRibbonGroupAreaBorder.gradientBorderBrush) : new Pen(ribbonBackColor));
				mementoRibbonGroupAreaBorder.solidBorderPen = new Pen(ribbonBackColor2);
				mementoRibbonGroupAreaBorder.shadowPen1 = new Pen(CommonHelper.MergeColors(ribbonBackColor5, 0.4f, ribbonBackColor, 0.6f));
				mementoRibbonGroupAreaBorder.shadowPen2 = new Pen(CommonHelper.MergeColors(ribbonBackColor5, 0.25f, ribbonBackColor, 0.75f));
				mementoRibbonGroupAreaBorder.shadowPen3 = new Pen(CommonHelper.MergeColors(ribbonBackColor5, 0.1f, ribbonBackColor, 0.9f));
			}
			context.Graphics.FillRectangle(mementoRibbonGroupAreaBorder.backBrush3, rect);
			context.Graphics.FillRectangle(mementoRibbonGroupAreaBorder.backBrush1, mementoRibbonGroupAreaBorder.backRect1);
			context.Graphics.FillRectangle(mementoRibbonGroupAreaBorder.backBrush2, mementoRibbonGroupAreaBorder.backRect2);
			context.Graphics.DrawLine(mementoRibbonGroupAreaBorder.gradientBorderPen, mementoRibbonGroupAreaBorder.borderRect.X, mementoRibbonGroupAreaBorder.borderRect.Y, mementoRibbonGroupAreaBorder.borderRect.Right, mementoRibbonGroupAreaBorder.borderRect.Y);
			context.Graphics.DrawLines(mementoRibbonGroupAreaBorder.solidBorderPen, mementoRibbonGroupAreaBorder.borderPoints);
			context.Graphics.DrawLine(mementoRibbonGroupAreaBorder.shadowPen3, rect.X, rect.Bottom - 2, rect.Right, rect.Bottom - 2);
			context.Graphics.DrawLine(mementoRibbonGroupAreaBorder.shadowPen2, rect.X, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
			context.Graphics.DrawLine(mementoRibbonGroupAreaBorder.shadowPen1, rect.X, rect.Bottom, rect.Right, rect.Bottom);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupAreaBorderContext(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			bool flag = true;
			MementoRibbonGroupAreaBorderContext mementoRibbonGroupAreaBorderContext;
			if (memento == null || !(memento is MementoRibbonGroupAreaBorderContext))
			{
				memento?.Dispose();
				mementoRibbonGroupAreaBorderContext = new MementoRibbonGroupAreaBorderContext(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
				memento = mementoRibbonGroupAreaBorderContext;
			}
			else
			{
				mementoRibbonGroupAreaBorderContext = (MementoRibbonGroupAreaBorderContext)memento;
				flag = !mementoRibbonGroupAreaBorderContext.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
			}
			if (flag)
			{
				mementoRibbonGroupAreaBorderContext.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
				graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 2);
				graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
				graphicsPath2.AddLine(rect.Left + 1, rect.Top + 3, rect.Left + 1, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Right - 3, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 3);
				graphicsPath3.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 2, rect.Bottom);
				graphicsPath3.AddLine(rect.Left + 2, rect.Bottom, rect.Right - 3, rect.Bottom);
				graphicsPath3.AddLine(rect.Right - 4, rect.Bottom, rect.Right, rect.Bottom - 3);
				graphicsPath3.AddLine(rect.Right, rect.Bottom - 3, rect.Right, rect.Top + 3);
				LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, ribbonBackColor2, 95f);
				mementoRibbonGroupAreaBorderContext.insidePen = new Pen(brush);
				Rectangle rect2 = new Rectangle(rect.Left - 1, rect.Top, rect.Width + 2, rect.Height + 1);
				LinearGradientBrush brush2 = new LinearGradientBrush(rect2, _darken8, _darken38, 90f);
				mementoRibbonGroupAreaBorderContext.shadowPen = new Pen(brush2);
				mementoRibbonGroupAreaBorderContext.fillBrush = new LinearGradientBrush(rect, Color.White, _242, 90f);
				mementoRibbonGroupAreaBorderContext.fillBrush.Blend = _ribbonGroup3Blend;
				mementoRibbonGroupAreaBorderContext.fillTopBrush = new LinearGradientBrush(rect, Color.FromArgb(75, ribbonBackColor3), Color.Transparent, 90f);
				mementoRibbonGroupAreaBorderContext.fillTopBrush.Blend = _ribbonGroup4Blend;
				mementoRibbonGroupAreaBorderContext.outsidePath = graphicsPath;
				mementoRibbonGroupAreaBorderContext.insidePath = graphicsPath2;
				mementoRibbonGroupAreaBorderContext.shadowPath = graphicsPath3;
				mementoRibbonGroupAreaBorderContext.outsidePen = new Pen(ribbonBackColor);
			}
			context.Graphics.FillPath(mementoRibbonGroupAreaBorderContext.fillBrush, mementoRibbonGroupAreaBorderContext.outsidePath);
			using (new Clipping(context.Graphics, mementoRibbonGroupAreaBorderContext.outsidePath))
			{
				context.Graphics.FillPath(mementoRibbonGroupAreaBorderContext.fillTopBrush, mementoRibbonGroupAreaBorderContext.outsidePath);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonGroupAreaBorderContext.outsidePen, mementoRibbonGroupAreaBorderContext.outsidePath);
				context.Graphics.DrawPath(mementoRibbonGroupAreaBorderContext.insidePen, mementoRibbonGroupAreaBorderContext.insidePath);
			}
			context.Graphics.DrawPath(mementoRibbonGroupAreaBorderContext.shadowPen, mementoRibbonGroupAreaBorderContext.shadowPath);
			context.Graphics.DrawLine(_medium2ShadowPen, rect.Left, rect.Bottom, rect.Left, rect.Bottom - 1);
			context.Graphics.DrawLine(_medium2ShadowPen, rect.Left, rect.Bottom - 1, rect.Left + 1, rect.Bottom);
			context.Graphics.DrawLine(_darkShadowPen, rect.Right, rect.Bottom - 2, rect.Right - 2, rect.Bottom);
			context.Graphics.DrawLine(_medium2ShadowPen, rect.Right, rect.Bottom - 1, rect.Right - 1, rect.Bottom);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonTabTracking2007(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonTabTracking2007 mementoRibbonTabTracking;
			if (memento == null || !(memento is MementoRibbonTabTracking2007))
			{
				memento?.Dispose();
				mementoRibbonTabTracking = new MementoRibbonTabTracking2007(rect, ribbonBackColor, ribbonBackColor2, orientation);
				memento = mementoRibbonTabTracking;
			}
			else
			{
				mementoRibbonTabTracking = (MementoRibbonTabTracking2007)memento;
				flag = !mementoRibbonTabTracking.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, orientation);
			}
			if (flag)
			{
				mementoRibbonTabTracking.Dispose();
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabTrackingTop2007(rect, ribbonBackColor, ribbonBackColor2, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabTrackingLeft2007(rect, ribbonBackColor, ribbonBackColor2, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabTrackingRight2007(rect, ribbonBackColor, ribbonBackColor2, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabTrackingBottom2007(rect, ribbonBackColor, ribbonBackColor2, mementoRibbonTabTracking);
					break;
				}
			}
			context.Graphics.FillRectangle(mementoRibbonTabTracking.half1LeftBrush, mementoRibbonTabTracking.half1Rect);
			context.Graphics.FillRectangle(mementoRibbonTabTracking.half1RightBrush, mementoRibbonTabTracking.half1Rect);
			context.Graphics.FillRectangle(mementoRibbonTabTracking.half1LightBrush, mementoRibbonTabTracking.half1Rect);
			context.Graphics.FillRectangle(mementoRibbonTabTracking.half2Brush, mementoRibbonTabTracking.half2Rect);
			if (mementoRibbonTabTracking.ellipseRect.Width > 0f && mementoRibbonTabTracking.ellipseRect.Height > 0f)
			{
				context.Graphics.FillRectangle(mementoRibbonTabTracking.ellipseBrush, mementoRibbonTabTracking.half2RectF);
				context.Graphics.FillRectangle(mementoRibbonTabTracking.ellipseBrush, mementoRibbonTabTracking.half2RectF);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabTracking.outsidePen, mementoRibbonTabTracking.outsidePath);
			}
			switch (orientation)
			{
			case VisualOrientation.Top:
				DrawRibbonTabTrackingTopDraw2007(rect, mementoRibbonTabTracking, context.Graphics);
				break;
			case VisualOrientation.Left:
				DrawRibbonTabTrackingLeftDraw2007(rect, mementoRibbonTabTracking, context.Graphics);
				break;
			case VisualOrientation.Right:
				DrawRibbonTabTrackingRightDraw2007(rect, mementoRibbonTabTracking, context.Graphics);
				break;
			case VisualOrientation.Bottom:
				DrawRibbonTabTrackingBottomDraw2007(rect, mementoRibbonTabTracking, context.Graphics);
				break;
			}
			context.Graphics.DrawPath(mementoRibbonTabTracking.topPen, mementoRibbonTabTracking.topPath);
		}
		return memento;
	}

	protected virtual void DrawRibbonTabTrackingTop2007(Rectangle rect, Color c1, Color c2, MementoRibbonTabTracking2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 1, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Top + 1.5f, rect.Left + 3, rect.Top);
		graphicsPath.AddLine(rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Top + 1.5f, rect.Right - 2, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left + 3, rect.Top + 2, rect.Left + 4, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 4, rect.Top + 1, rect.Right - 5, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 5, rect.Top + 1, rect.Right - 4, rect.Top + 2);
		int num = rect.Height - 3;
		int num2 = num / 2;
		int num3 = num - num2;
		cache.half1Rect = new Rectangle(rect.Left + 3, rect.Top + 2, rect.Width - 6, num2);
		cache.half2Rect = new Rectangle(rect.Left + 3, rect.Top + 2 + num2, rect.Width - 6, num3);
		Rectangle rectangle = new Rectangle(rect.Left + 3, rect.Top + 2, rect.Width - 6, num2 + num3);
		RectangleF rect2 = new RectangleF(cache.half1Rect.Left - 1, (float)cache.half1Rect.Top - 0.5f, cache.half1Rect.Width + 2, cache.half1Rect.Height + 1);
		cache.half2RectF = new RectangleF(cache.half2Rect.Left - 1, (float)cache.half2Rect.Top - 0.5f, cache.half2Rect.Width + 2, cache.half2Rect.Height + 1);
		cache.half1LeftBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 0f);
		cache.half1LeftBrush.Blend = _ribbonTabTopBlend;
		cache.half1RightBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 180f);
		cache.half1RightBrush.Blend = _ribbonTabTopBlend;
		cache.half1LightBrush = new LinearGradientBrush(rect2, Color.FromArgb(28, Color.White), Color.FromArgb(125, Color.White), 90f);
		cache.half2Brush = new SolidBrush(Color.FromArgb(85, c2));
		cache.ellipseRect = new RectangleF(rectangle.Left - rectangle.Width / 8, rectangle.Top, (float)rectangle.Width * 1.25f, rectangle.Height);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = Color.FromArgb(92, Color.White);
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top + 2, rect.Width + 2, rect.Height - 2);
		RectangleF rect4 = new RectangleF(rect.Left + 1, rect.Top, rect.Width - 2, rect.Height);
		cache.outsideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten128, 90f);
		cache.outsideBrush.Blend = _ribbonOutBlend;
		cache.insideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten200, 90f);
		cache.insideBrush.Blend = _ribbonInBlend;
		cache.topBrush = new LinearGradientBrush(rect4, _whiten92, _whiten128, 0f);
		cache.topBrush.Blend = _ribbonTopBlend;
		cache.topPen = new Pen(cache.topBrush);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabTrackingTopDraw2007(Rectangle rect, MementoRibbonTabTracking2007 cache, Graphics g)
	{
		g.FillRectangle(cache.outsideBrush, rect.Left, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.insideBrush, rect.Left + 2, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideBrush, rect.Right - 1, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.insideBrush, rect.Right - 3, rect.Top + 3, 1, rect.Height - 4);
	}

	protected virtual void DrawRibbonTabTrackingLeft2007(Rectangle rect, Color c1, Color c2, MementoRibbonTabTracking2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 2, (float)rect.Left + 1.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		graphicsPath.AddLine(rect.Left, rect.Top + 3, (float)rect.Left + 1.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Top + 1, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 4, rect.Left + 1, rect.Bottom - 5);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 5, rect.Left + 1, rect.Top + 4);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 4, rect.Left + 2, rect.Top + 3);
		int num = rect.Width - 3;
		int num2 = num / 2;
		int num3 = num - num2;
		cache.half1Rect = new Rectangle(rect.Left + 2, rect.Top + 3, num2, rect.Height - 6);
		cache.half2Rect = new Rectangle(rect.Left + 2 + num2, rect.Top + 3, num3, rect.Height - 6);
		Rectangle rectangle = new Rectangle(rect.Left + 2, rect.Top + 3, num2 + num3, rect.Height - 6);
		RectangleF rect2 = new RectangleF((float)cache.half1Rect.Left - 0.5f, (float)cache.half1Rect.Top - 1f, cache.half1Rect.Width + 1, cache.half1Rect.Height + 2);
		cache.half2RectF = new RectangleF((float)cache.half2Rect.Left - 0.5f, (float)cache.half2Rect.Top - 1f, cache.half2Rect.Width + 1, cache.half2Rect.Height + 2);
		cache.half1LeftBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 90f);
		cache.half1LeftBrush.Blend = _ribbonTabTopBlend;
		cache.half1RightBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 270f);
		cache.half1RightBrush.Blend = _ribbonTabTopBlend;
		cache.half1LightBrush = new LinearGradientBrush(rect2, Color.FromArgb(28, Color.White), Color.FromArgb(125, Color.White), 180f);
		cache.half2Brush = new SolidBrush(Color.FromArgb(85, c2));
		cache.ellipseRect = new RectangleF(rectangle.Left, rectangle.Top - rectangle.Width / 8, rectangle.Width, (float)rectangle.Height * 1.25f);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = Color.FromArgb(48, Color.White);
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		RectangleF rect3 = new RectangleF(rect.Left + 2, rect.Top - 1, rect.Width - 2, rect.Height + 2);
		RectangleF rect4 = new RectangleF(rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
		cache.outsideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten128, 180f);
		cache.outsideBrush.Blend = _ribbonOutBlend;
		cache.insideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten200, 180f);
		cache.insideBrush.Blend = _ribbonInBlend;
		cache.topBrush = new LinearGradientBrush(rect4, _whiten92, _whiten128, 90f);
		cache.topBrush.Blend = _ribbonTopBlend;
		cache.topPen = new Pen(cache.topBrush);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabTrackingLeftDraw2007(Rectangle rect, MementoRibbonTabTracking2007 cache, Graphics g)
	{
		g.FillRectangle(cache.outsideBrush, rect.Left + 3, rect.Top, rect.Width - 4, 1);
		g.FillRectangle(cache.insideBrush, rect.Left + 3, rect.Top + 2, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideBrush, rect.Left + 3, rect.Bottom - 1, rect.Width - 4, 1);
		g.FillRectangle(cache.insideBrush, rect.Left + 3, rect.Bottom - 3, rect.Width - 4, 1);
	}

	protected virtual void DrawRibbonTabTrackingRight2007(Rectangle rect, Color c1, Color c2, MementoRibbonTabTracking2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, (float)rect.Right - 2.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 3, (float)rect.Right - 2.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 3, rect.Bottom - 4, rect.Right - 2, rect.Bottom - 5);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 5, rect.Right - 2, rect.Top + 4);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 4, rect.Right - 3, rect.Top + 3);
		int num = rect.Width - 3;
		int num2 = num / 2;
		int num3 = num - num2;
		cache.half1Rect = new Rectangle(rect.Right - 2 - num2, rect.Top + 3, num2, rect.Height - 6);
		cache.half2Rect = new Rectangle(rect.Right - 2 - num2 - num3, rect.Top + 3, num3, rect.Height - 6);
		Rectangle rectangle = new Rectangle(rect.Right - 2 - num2 - num3, rect.Top + 3, num2 + num3, rect.Height - 6);
		RectangleF rect2 = new RectangleF((float)cache.half1Rect.Left - 0.5f, (float)cache.half1Rect.Top - 1f, cache.half1Rect.Width + 1, cache.half1Rect.Height + 2);
		cache.half2RectF = new RectangleF((float)cache.half2Rect.Left - 0.5f, (float)cache.half2Rect.Top - 1f, cache.half2Rect.Width + 1, cache.half2Rect.Height + 2);
		cache.half1LeftBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 270f);
		cache.half1LeftBrush.Blend = _ribbonTabTopBlend;
		cache.half1RightBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 90f);
		cache.half1RightBrush.Blend = _ribbonTabTopBlend;
		cache.half1LightBrush = new LinearGradientBrush(rect2, Color.FromArgb(28, Color.White), Color.FromArgb(125, Color.White), 0f);
		cache.half2Brush = new SolidBrush(Color.FromArgb(85, c2));
		cache.ellipseRect = new RectangleF(rectangle.Left, rectangle.Top - rectangle.Width / 8, rectangle.Width, (float)rectangle.Height * 1.25f);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = Color.FromArgb(48, Color.White);
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		RectangleF rect3 = new RectangleF(rect.Left, rect.Top - 1, rect.Width - 2, rect.Height + 2);
		RectangleF rect4 = new RectangleF(rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
		cache.outsideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten128, 0f);
		cache.outsideBrush.Blend = _ribbonOutBlend;
		cache.insideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten200, 0f);
		cache.insideBrush.Blend = _ribbonInBlend;
		cache.topBrush = new LinearGradientBrush(rect4, _whiten92, _whiten128, 270f);
		cache.topBrush.Blend = _ribbonTopBlend;
		cache.topPen = new Pen(cache.topBrush);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabTrackingRightDraw2007(Rectangle rect, MementoRibbonTabTracking2007 cache, Graphics g)
	{
		g.FillRectangle(cache.outsideBrush, rect.Left + 1, rect.Top, rect.Width - 4, 1);
		g.FillRectangle(cache.insideBrush, rect.Left + 1, rect.Top + 2, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideBrush, rect.Left + 1, rect.Bottom - 1, rect.Width - 4, 1);
		g.FillRectangle(cache.insideBrush, rect.Left + 1, rect.Bottom - 3, rect.Width - 4, 1);
	}

	protected virtual void DrawRibbonTabTrackingBottom2007(Rectangle rect, Color c1, Color c2, MementoRibbonTabTracking2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Bottom - 2.5f, rect.Left + 3, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 2.5f, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 3, rect.Bottom - 3, rect.Left + 4, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left + 4, rect.Bottom - 2, rect.Right - 5, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Right - 5, rect.Bottom - 2, rect.Right - 4, rect.Bottom - 3);
		int num = rect.Height - 3;
		int num2 = num / 2;
		int num3 = num - num2;
		cache.half1Rect = new Rectangle(rect.Left + 3, rect.Bottom - 2 - num2, rect.Width - 6, num2);
		cache.half2Rect = new Rectangle(rect.Left + 3, rect.Bottom - 2 - num2 - num3, rect.Width - 6, num3);
		Rectangle rectangle = new Rectangle(rect.Left + 3, rect.Bottom - 2 - num2 - num3, rect.Width - 6, num2 + num3);
		RectangleF rect2 = new RectangleF(cache.half1Rect.Left - 1, (float)cache.half1Rect.Top - 0.5f, cache.half1Rect.Width + 2, cache.half1Rect.Height + 1);
		cache.half2RectF = new RectangleF(cache.half2Rect.Left - 1, (float)cache.half2Rect.Top - 0.5f, cache.half2Rect.Width + 2, cache.half2Rect.Height + 1);
		cache.half1LeftBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 180f);
		cache.half1LeftBrush.Blend = _ribbonTabTopBlend;
		cache.half1RightBrush = new LinearGradientBrush(rect2, Color.FromArgb(85, c2), Color.Transparent, 0f);
		cache.half1RightBrush.Blend = _ribbonTabTopBlend;
		cache.half1LightBrush = new LinearGradientBrush(rect2, Color.FromArgb(28, Color.White), Color.FromArgb(125, Color.White), 270f);
		cache.half2Brush = new SolidBrush(Color.FromArgb(85, c2));
		cache.ellipseRect = new RectangleF(rectangle.Left - rectangle.Width / 8, rectangle.Top, (float)rectangle.Width * 1.25f, rectangle.Height);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = Color.FromArgb(92, Color.White);
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Bottom - cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top, rect.Width + 2, rect.Height - 2);
		RectangleF rect4 = new RectangleF(rect.Left + 1, rect.Top, rect.Width - 2, rect.Height);
		cache.outsideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten128, 270f);
		cache.outsideBrush.Blend = _ribbonOutBlend;
		cache.insideBrush = new LinearGradientBrush(rect3, Color.Transparent, _whiten200, 270f);
		cache.insideBrush.Blend = _ribbonInBlend;
		cache.topBrush = new LinearGradientBrush(rect4, _whiten92, _whiten128, 180f);
		cache.topBrush.Blend = _ribbonTopBlend;
		cache.topPen = new Pen(cache.topBrush);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabTrackingBottomDraw2007(Rectangle rect, MementoRibbonTabTracking2007 cache, Graphics g)
	{
		g.FillRectangle(cache.outsideBrush, rect.Left, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.insideBrush, rect.Left + 2, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideBrush, rect.Right - 1, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.insideBrush, rect.Right - 3, rect.Top + 1, 1, rect.Height - 4);
	}

	protected virtual IDisposable DrawRibbonTabTracking2010(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento, bool standard)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color color = palette.GetRibbonBackColor1(state);
			Color color2 = palette.GetRibbonBackColor2(state);
			Color color3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor = palette.GetRibbonBackColor4(state);
			Color color4 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonTabTracking2010 mementoRibbonTabTracking;
			if (memento == null || !(memento is MementoRibbonTabTracking2010))
			{
				memento?.Dispose();
				mementoRibbonTabTracking = new MementoRibbonTabTracking2010(rect, color, color2, color3, ribbonBackColor, orientation);
				memento = mementoRibbonTabTracking;
			}
			else
			{
				mementoRibbonTabTracking = (MementoRibbonTabTracking2010)memento;
				flag = !mementoRibbonTabTracking.UseCachedValues(rect, color, color2, color3, ribbonBackColor, orientation);
			}
			if (flag)
			{
				mementoRibbonTabTracking.Dispose();
				if (color4 != Color.Empty)
				{
					if (!standard)
					{
						color4 = CommonHelper.MergeColors(color4, 0.65f, Color.Black, 0.35f);
					}
					color = color4;
					color2 = CommonHelper.MergeColors(color2, 0.8f, ControlPaint.Light(color4), 0.2f);
					color3 = CommonHelper.MergeColors(color3, 0.7f, color4, 0.3f);
				}
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabTrackingTop2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabTrackingLeft2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabTrackingRight2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabTrackingBottom2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				}
				mementoRibbonTabTracking.outsidePen = new Pen(color);
				mementoRibbonTabTracking.outsideBrush = new SolidBrush(color2);
			}
			context.Graphics.FillPath(mementoRibbonTabTracking.outsideBrush, mementoRibbonTabTracking.outsidePath);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabTracking.outsidePen, mementoRibbonTabTracking.borderPath);
			}
			context.Graphics.FillPath(mementoRibbonTabTracking.insideBrush, mementoRibbonTabTracking.insidePath);
		}
		return memento;
	}

	protected virtual void DrawRibbonTabTrackingTop2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left, (float)rect.Top + 1.75f);
		graphicsPath.AddLine(rect.Left, (float)rect.Top + 1.75f, rect.Left + 1, rect.Top);
		graphicsPath.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		graphicsPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1.75f);
		graphicsPath.AddLine(rect.Right - 1, (float)rect.Top + 1.75f, rect.Right - 1, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left, rect.Bottom - 1, rect.Left, (float)rect.Top + 1.5f);
		graphicsPath2.AddLine(rect.Left, (float)rect.Top + 1.5f, rect.Left + 1, rect.Top);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1.5f);
		graphicsPath2.AddLine(rect.Right - 1, (float)rect.Top + 1.5f, rect.Right - 1, rect.Bottom - 1);
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		graphicsPath3.AddLine(rect.Left, rect.Bottom - 1, rect.Left, (float)rect.Top + 1f);
		graphicsPath3.AddLine(rect.Left, (float)rect.Top + 1f, rect.Left + 1, rect.Top);
		graphicsPath3.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		graphicsPath3.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1f);
		graphicsPath3.AddLine(rect.Right - 1, (float)rect.Top + 1f, rect.Right - 1, rect.Bottom - 1);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 270f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabTrackingBottom2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top, rect.Left, (float)rect.Bottom - 2.75f);
		graphicsPath.AddLine(rect.Left, (float)rect.Bottom - 2.75f, rect.Left + 1, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 1, (float)rect.Bottom - 2.75f);
		graphicsPath.AddLine(rect.Right - 1, (float)rect.Bottom - 2.75f, rect.Right - 1, rect.Top);
		graphicsPath2.AddLine(rect.Left, rect.Top, rect.Left, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Left, (float)rect.Bottom - 2.5f, rect.Left + 1, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 1, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Right - 1, (float)rect.Bottom - 2.5f, rect.Right - 1, rect.Top);
		rect.X += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		graphicsPath3.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 2, rect.Bottom);
		graphicsPath3.AddLine(rect.Left + 2, rect.Bottom, rect.Right - 3, rect.Bottom);
		graphicsPath3.AddLine(rect.Right - 3, rect.Bottom, rect.Right - 1, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right - 1, rect.Top);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 90f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabTrackingLeft2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 1, rect.Top, (float)rect.Left + 1.75f, rect.Top);
		graphicsPath.AddLine((float)rect.Left + 1.75f, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath.AddLine(rect.Left, rect.Top + 1, rect.Left, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Left, (float)rect.Bottom - 2.5f, (float)rect.Left + 1.75f, rect.Bottom - 1);
		graphicsPath.AddLine((float)rect.Left + 1.75f, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 1, rect.Top, (float)rect.Left + 1.75f, rect.Top);
		graphicsPath2.AddLine((float)rect.Left + 1.75f, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left, rect.Top + 1, rect.Left, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Left, (float)rect.Bottom - 2.5f, (float)rect.Left + 1.75f, rect.Bottom - 1);
		graphicsPath2.AddLine((float)rect.Left + 1.75f, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 2;
		rect.Height -= 3;
		graphicsPath3.AddLine(rect.Right - 1, rect.Top, rect.Left + 1, rect.Top);
		graphicsPath3.AddLine(rect.Left + 1, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath3.AddLine(rect.Left, rect.Top + 1, rect.Left, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left, (float)rect.Bottom - 2.5f, (float)rect.Left + 1.5f, rect.Bottom - 1);
		graphicsPath3.AddLine((float)rect.Left + 1.5f, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 180f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabTrackingRight2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top, (float)rect.Right - 2.75f, rect.Top);
		graphicsPath.AddLine((float)rect.Right - 2.75f, rect.Top, rect.Right - 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 1, rect.Right - 1, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Right - 1, (float)rect.Bottom - 2.5f, (float)rect.Right - 2.75f, rect.Bottom - 1);
		graphicsPath.AddLine((float)rect.Right - 2.75f, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left, rect.Top, (float)rect.Right - 2.75f, rect.Top);
		graphicsPath2.AddLine((float)rect.Right - 2.75f, rect.Top, rect.Right - 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 1, rect.Top + 1, rect.Right - 1, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Right - 1, (float)rect.Bottom - 2.5f, (float)rect.Right - 2.75f, rect.Bottom - 1);
		graphicsPath2.AddLine((float)rect.Right - 2.75f, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
		rect.Y += 2;
		rect.Width -= 2;
		rect.Height -= 3;
		graphicsPath3.AddLine(rect.Left, rect.Top, rect.Right - 1, rect.Top);
		graphicsPath3.AddLine(rect.Right - 1, rect.Top, rect.Right, rect.Top + 1);
		graphicsPath3.AddLine(rect.Right, rect.Top + 1, rect.Right, (float)rect.Bottom - 2.5f);
		graphicsPath3.AddLine(rect.Right, (float)rect.Bottom - 2.5f, (float)rect.Right - 3.5f, rect.Bottom - 1);
		graphicsPath3.AddLine((float)rect.Right - 3.5f, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 2, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 0f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual IDisposable DrawRibbonTabFocus2010(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color color = palette.GetRibbonBackColor1(state);
			Color color2 = palette.GetRibbonBackColor2(state);
			Color color3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonTabTracking2010 mementoRibbonTabTracking;
			if (memento == null || !(memento is MementoRibbonTabTracking2010))
			{
				memento?.Dispose();
				mementoRibbonTabTracking = new MementoRibbonTabTracking2010(rect, color, color2, color3, ribbonBackColor, orientation);
				memento = mementoRibbonTabTracking;
			}
			else
			{
				mementoRibbonTabTracking = (MementoRibbonTabTracking2010)memento;
				flag = !mementoRibbonTabTracking.UseCachedValues(rect, color, color2, color3, ribbonBackColor, orientation);
			}
			if (flag)
			{
				mementoRibbonTabTracking.Dispose();
				if (ribbonBackColor2 != Color.Empty)
				{
					color = ribbonBackColor2;
					color2 = CommonHelper.MergeColors(color2, 0.8f, ControlPaint.Light(ribbonBackColor2), 0.2f);
					color3 = CommonHelper.MergeColors(color3, 0.7f, ribbonBackColor2, 0.3f);
				}
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabFocusTop2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabFocusLeft2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabFocusRight2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabFocusBottom2010(rect, color3, ribbonBackColor, mementoRibbonTabTracking);
					break;
				}
				mementoRibbonTabTracking.outsidePen = new Pen(color);
				mementoRibbonTabTracking.outsideBrush = new SolidBrush(color2);
			}
			context.Graphics.FillPath(mementoRibbonTabTracking.outsideBrush, mementoRibbonTabTracking.outsidePath);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabTracking.outsidePen, mementoRibbonTabTracking.borderPath);
			}
			context.Graphics.FillPath(mementoRibbonTabTracking.insideBrush, mementoRibbonTabTracking.insidePath);
		}
		return memento;
	}

	protected virtual void DrawRibbonTabFocusTop2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 1, (float)rect.Top + 1.75f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Top + 1.75f, rect.Left + 2, rect.Top);
		graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
		graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 2, (float)rect.Top + 1.75f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Top + 1.75f, rect.Right - 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left, rect.Bottom, rect.Left + 1, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Left + 1, (float)rect.Top + 1.5f);
		graphicsPath2.AddLine(rect.Left + 1, (float)rect.Top + 1.5f, rect.Left + 2, rect.Top);
		graphicsPath2.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
		graphicsPath2.AddLine(rect.Right - 3, rect.Top, rect.Right - 2, (float)rect.Top + 1.5f);
		graphicsPath2.AddLine(rect.Right - 2, (float)rect.Top + 1.5f, rect.Right - 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		graphicsPath3.AddLine(rect.Left - 2, rect.Bottom, rect.Left + 1, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 1, (float)rect.Top + 1f);
		graphicsPath3.AddLine(rect.Left + 1, (float)rect.Top + 1f, rect.Left + 2, rect.Top);
		graphicsPath3.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
		graphicsPath3.AddLine(rect.Right - 3, rect.Top, rect.Right - 2, (float)rect.Top + 1f);
		graphicsPath3.AddLine(rect.Right - 2, (float)rect.Top + 1f, rect.Right - 2, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 270f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabFocusBottom2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top, rect.Left + 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, (float)rect.Bottom - 2.75f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Bottom - 2.75f, rect.Left + 2, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Right - 2, (float)rect.Bottom - 2.75f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 2.75f, rect.Right - 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
		graphicsPath2.AddLine(rect.Left, rect.Top, rect.Left + 1, rect.Top);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top, rect.Left + 1, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Left + 1, (float)rect.Bottom - 2.5f, rect.Left + 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 1, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Right - 1, (float)rect.Bottom - 2.5f, rect.Right - 1, rect.Top);
		graphicsPath2.AddLine(rect.Right - 1, rect.Top, rect.Right, rect.Top);
		rect.X += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		graphicsPath3.AddLine(rect.Left - 2, rect.Top - 1, rect.Left + 1, rect.Top + 1);
		graphicsPath3.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 3, rect.Bottom);
		graphicsPath3.AddLine(rect.Left + 3, rect.Bottom, rect.Right - 4, rect.Bottom);
		graphicsPath3.AddLine(rect.Right - 4, rect.Bottom, rect.Right - 3, rect.Bottom - 1);
		graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 2, rect.Top + 1);
		graphicsPath3.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 90f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabFocusLeft2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 1, rect.Top - 1, rect.Right - 2, rect.Top);
		graphicsPath.AddLine(rect.Right - 2, rect.Top, (float)rect.Left + 1.75f, rect.Top);
		graphicsPath.AddLine((float)rect.Left + 1.75f, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left, (float)rect.Bottom - 3.5f);
		graphicsPath.AddLine(rect.Left, (float)rect.Bottom - 3.5f, (float)rect.Left + 1.75f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Left + 1.75f, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right, rect.Top, (float)rect.Left + 1.75f, rect.Top);
		graphicsPath2.AddLine((float)rect.Left + 1.75f, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left, rect.Top + 1, rect.Left, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Left, (float)rect.Bottom - 2.5f, (float)rect.Left + 1.75f, rect.Bottom - 1);
		graphicsPath2.AddLine((float)rect.Left + 1.75f, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 2;
		rect.Height -= 3;
		graphicsPath3.AddLine(rect.Right - 1, rect.Top - 2, rect.Right - 1, rect.Top);
		graphicsPath3.AddLine(rect.Right - 1, rect.Top, rect.Left + 1, rect.Top);
		graphicsPath3.AddLine(rect.Left + 1, rect.Top, rect.Left, rect.Top + 1);
		graphicsPath3.AddLine(rect.Left, rect.Top + 1, rect.Left, rect.Bottom - 4);
		graphicsPath3.AddLine(rect.Left, rect.Bottom - 4, rect.Left + 2, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right, rect.Bottom);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 180f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual void DrawRibbonTabFocusRight2010(Rectangle rect, Color c3, Color c4, MementoRibbonTabTracking2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top - 1, rect.Left + 1, rect.Top);
		graphicsPath.AddLine(rect.Left + 1, rect.Top, (float)rect.Right - 2.75f, rect.Top);
		graphicsPath.AddLine((float)rect.Right - 2.75f, rect.Top, rect.Right - 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, (float)rect.Bottom - 3.5f);
		graphicsPath.AddLine(rect.Right - 1, (float)rect.Bottom - 3.5f, (float)rect.Right - 2.75f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Right - 2.75f, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left, rect.Top, (float)rect.Right - 2.75f, rect.Top);
		graphicsPath2.AddLine((float)rect.Right - 2.75f, rect.Top, rect.Right - 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 1, rect.Top + 1, rect.Right - 1, (float)rect.Bottom - 2.5f);
		graphicsPath2.AddLine(rect.Right - 1, (float)rect.Bottom - 2.5f, (float)rect.Right - 2.75f, rect.Bottom - 1);
		graphicsPath2.AddLine((float)rect.Right - 2.75f, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
		rect.Y += 2;
		rect.Width -= 2;
		rect.Height -= 3;
		graphicsPath3.AddLine(rect.Left, rect.Top - 2, rect.Left + 1, rect.Top);
		graphicsPath3.AddLine(rect.Left + 1, rect.Top, rect.Right - 1, rect.Top);
		graphicsPath3.AddLine(rect.Right - 1, rect.Top, rect.Right, rect.Top + 1);
		graphicsPath3.AddLine(rect.Right, rect.Top + 1, rect.Right, rect.Bottom - 4);
		graphicsPath3.AddLine(rect.Right, rect.Bottom - 4, rect.Right - 2, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 2);
		graphicsPath3.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		cache.borderPath = graphicsPath;
		cache.outsidePath = graphicsPath2;
		cache.insidePath = graphicsPath3;
		cache.insideBrush = new LinearGradientBrush(new RectangleF(rect.X - 2, rect.Y - 1, rect.Width + 2, rect.Height + 2), c4, c3, 0f);
		cache.insideBrush.Blend = _linear50Blend;
	}

	protected virtual IDisposable DrawRibbonTabGlowing(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color color = Color.FromArgb(36, ribbonBackColor2);
			bool flag = true;
			MementoRibbonTabGlowing mementoRibbonTabGlowing;
			if (memento == null || !(memento is MementoRibbonTabGlowing))
			{
				memento?.Dispose();
				mementoRibbonTabGlowing = new MementoRibbonTabGlowing(rect, ribbonBackColor, ribbonBackColor2, color, orientation);
				memento = mementoRibbonTabGlowing;
			}
			else
			{
				mementoRibbonTabGlowing = (MementoRibbonTabGlowing)memento;
				flag = !mementoRibbonTabGlowing.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, color, orientation);
			}
			if (flag)
			{
				mementoRibbonTabGlowing.Dispose();
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabGlowingTop(rect, ribbonBackColor, ribbonBackColor2, color, mementoRibbonTabGlowing);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabGlowingLeft(rect, ribbonBackColor, ribbonBackColor2, color, mementoRibbonTabGlowing);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabGlowingRight(rect, ribbonBackColor, ribbonBackColor2, color, mementoRibbonTabGlowing);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabGlowingBottom(rect, ribbonBackColor, ribbonBackColor2, color, mementoRibbonTabGlowing);
					break;
				}
			}
			context.Graphics.FillPath(mementoRibbonTabGlowing.insideBrush, mementoRibbonTabGlowing.outsidePath);
			switch (orientation)
			{
			case VisualOrientation.Top:
				context.Graphics.DrawLine(mementoRibbonTabGlowing.insidePen, rect.Left + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
				break;
			case VisualOrientation.Left:
				context.Graphics.DrawLine(mementoRibbonTabGlowing.insidePen, rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Bottom - 2);
				break;
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabGlowing.outsidePen, mementoRibbonTabGlowing.outsidePath);
			}
			context.Graphics.FillPath(mementoRibbonTabGlowing.topBrush, mementoRibbonTabGlowing.topPath);
			if (mementoRibbonTabGlowing.ellipseRect.Width > 0f && mementoRibbonTabGlowing.ellipseRect.Height > 0f)
			{
				context.Graphics.FillRectangle(mementoRibbonTabGlowing.ellipseBrush, mementoRibbonTabGlowing.fullRect);
			}
		}
		return memento;
	}

	protected virtual void DrawRibbonTabGlowingTop(Rectangle rect, Color c1, Color c2, Color insideColor, MementoRibbonTabGlowing cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Left, (float)rect.Top + 1.5f, rect.Left + 2, rect.Top);
		graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 4, rect.Top);
		graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Top + 1.5f, rect.Right - 2, rect.Bottom - 2);
		int num = rect.Height / 4;
		graphicsPath2.AddLine(rect.Left + 2, rect.Top + 1, rect.Left + 1, rect.Top + 2);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 1, rect.Top + 2 + num);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 2 + num, rect.Left + 4, rect.Top + 5 + num);
		graphicsPath2.AddLine(rect.Left + 4, rect.Top + 5 + num, rect.Right - 5, rect.Top + 5 + num);
		graphicsPath2.AddLine(rect.Right - 5, rect.Top + 5 + num, rect.Right - 2, rect.Top + 2 + num);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 2 + num, rect.Right - 2, rect.Top + 2);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 3, rect.Top + 1);
		RectangleF rect2 = new RectangleF(rect.Left, rect.Top, rect.Width, num + 5);
		cache.topBrush = new LinearGradientBrush(rect2, c1, Color.Transparent, 90f);
		int num2 = (int)((float)rect.Width * 1.2f);
		int num3 = (int)((float)rect.Height * 0.4f);
		cache.fullRect = new RectangleF(rect.Left + 1, rect.Top + 1, rect.Width - 3, rect.Height - 2);
		cache.ellipseRect = new RectangleF(rect.Left - (num2 - rect.Width) / 2, rect.Bottom - num3, num2, num3 * 2);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = c2;
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		cache.insideBrush = new SolidBrush(insideColor);
		cache.insidePen = new Pen(insideColor);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabGlowingLeft(Rectangle rect, Color c1, Color c2, Color insideColor, MementoRibbonTabGlowing cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, (float)rect.Left + 1.5f, rect.Bottom - 1);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 3);
		graphicsPath.AddLine(rect.Left, rect.Top + 3, (float)rect.Left + 1.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Top + 1, rect.Right - 2, rect.Top + 1);
		int num = rect.Height / 4;
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left + 2 + num, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 2 + num, rect.Bottom - 1, rect.Left + 5 + num, rect.Bottom - 4);
		graphicsPath2.AddLine(rect.Left + 5 + num, rect.Bottom - 4, rect.Left + 5 + num, rect.Top + 4);
		graphicsPath2.AddLine(rect.Left + 5 + num, rect.Top + 4, rect.Left + 2 + num, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 2 + num, rect.Top + 1, rect.Left + 2, rect.Top + 2);
		graphicsPath2.AddLine(rect.Left + 2, rect.Top + 2, rect.Left + 1, rect.Top + 2);
		RectangleF rect2 = new RectangleF(rect.Left, rect.Top, num + 5, rect.Height);
		cache.topBrush = new LinearGradientBrush(rect2, c1, Color.Transparent, 0f);
		int num2 = (int)((float)rect.Width * 0.4f);
		int num3 = (int)((float)rect.Height * 1.2f);
		cache.fullRect = new RectangleF(rect.Left + 1, rect.Top + 2, rect.Width - 2, rect.Height - 3);
		cache.ellipseRect = new RectangleF(rect.Right - num2, rect.Top - (num3 - rect.Height) / 2, num2 * 2, num3);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = c2;
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		cache.insideBrush = new SolidBrush(insideColor);
		cache.insidePen = new Pen(insideColor);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabGlowingRight(Rectangle rect, Color c1, Color c2, Color insideColor, MementoRibbonTabGlowing cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 1, (float)rect.Right - 2.5f, rect.Bottom - 1);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 1, rect.Top + 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 3, (float)rect.Right - 2.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		int num = rect.Height / 4;
		graphicsPath2.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 2 - num, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 2 - num, rect.Bottom - 1, rect.Right - 5 - num, rect.Bottom - 4);
		graphicsPath2.AddLine(rect.Right - 5 - num, rect.Bottom - 4, rect.Right - 5 - num, rect.Top + 4);
		graphicsPath2.AddLine(rect.Right - 5 - num, rect.Top + 4, rect.Right - 2 - num, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 2 - num, rect.Top + 1, rect.Right - 2, rect.Top + 2);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 1, rect.Top + 2);
		RectangleF rect2 = new RectangleF(rect.Right - num - 5, rect.Top, num + 5, rect.Height);
		cache.topBrush = new LinearGradientBrush(rect2, c1, Color.Transparent, 180f);
		int num2 = (int)((float)rect.Width * 0.4f);
		int num3 = (int)((float)rect.Height * 1.2f);
		cache.fullRect = new RectangleF(rect.Left + 1, rect.Top + 2, rect.Width - 2, rect.Height - 3);
		cache.ellipseRect = new RectangleF(rect.Left - num2, rect.Top - (num3 - rect.Height) / 2, num2 * 2, num3);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = c2;
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Top + cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		cache.insideBrush = new SolidBrush(insideColor);
		cache.insidePen = new Pen(insideColor);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual void DrawRibbonTabGlowingBottom(Rectangle rect, Color c1, Color c2, Color insideColor, MementoRibbonTabGlowing cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top + 1, rect.Left, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Left, (float)rect.Bottom - 2.5f, rect.Left + 2, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 2.5f, rect.Right - 2, rect.Top + 1);
		int num = rect.Height / 4;
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 2 - num);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 2 - num, rect.Left + 4, rect.Bottom - 5 - num);
		graphicsPath2.AddLine(rect.Left + 4, rect.Bottom - 5 - num, rect.Right - 5, rect.Bottom - 5 - num);
		graphicsPath2.AddLine(rect.Right - 5, rect.Bottom - 5 - num, rect.Right - 2, rect.Bottom - 2 - num);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 2 - num, rect.Right - 2, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 1);
		RectangleF rect2 = new RectangleF(rect.Left, rect.Bottom - 6 - num, rect.Width, num + 5);
		cache.topBrush = new LinearGradientBrush(rect2, c1, Color.Transparent, 270f);
		int num2 = (int)((float)rect.Width * 1.2f);
		int num3 = (int)((float)rect.Height * 0.4f);
		cache.fullRect = new RectangleF(rect.Left + 1, rect.Top + 1, rect.Width - 3, rect.Height - 2);
		cache.ellipseRect = new RectangleF(rect.Left - (num2 - rect.Width) / 2, rect.Top - num3, num2, num3 * 2);
		if (cache.ellipseRect.Width > 0f && cache.ellipseRect.Height > 0f)
		{
			graphicsPath3.AddEllipse(cache.ellipseRect);
			cache.ellipseBrush = new PathGradientBrush(graphicsPath3);
			cache.ellipseBrush.CenterColor = c2;
			PointF centerPoint = new PointF(cache.ellipseRect.Left + cache.ellipseRect.Width / 2f, cache.ellipseRect.Bottom - 1f - cache.ellipseRect.Height / 2f);
			cache.ellipseBrush.CenterPoint = centerPoint;
			cache.ellipseBrush.SurroundColors = new Color[1] { Color.Transparent };
		}
		cache.insideBrush = new SolidBrush(insideColor);
		cache.insidePen = new Pen(insideColor);
		cache.outsidePen = new Pen(c1);
		cache.outsidePath = graphicsPath;
		cache.topPath = graphicsPath2;
		cache.ellipsePath = graphicsPath3;
	}

	protected virtual IDisposable DrawRibbonTabSelected2007(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonTabSelected2007 mementoRibbonTabSelected;
			if (memento == null || !(memento is MementoRibbonTabSelected2007))
			{
				memento?.Dispose();
				mementoRibbonTabSelected = new MementoRibbonTabSelected2007(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, orientation);
				memento = mementoRibbonTabSelected;
			}
			else
			{
				mementoRibbonTabSelected = (MementoRibbonTabSelected2007)memento;
				flag = !mementoRibbonTabSelected.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, orientation);
			}
			if (flag)
			{
				mementoRibbonTabSelected.Dispose();
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabSelectedTop2007(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabSelectedLeft2007(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabSelectedRight2007(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabSelectedBottom2007(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabSelected);
					break;
				}
				mementoRibbonTabSelected.insideBrush = new SolidBrush(ribbonBackColor3);
				mementoRibbonTabSelected.outsidePen = new Pen(ribbonBackColor);
				mementoRibbonTabSelected.middlePen = new Pen(ribbonBackColor2);
				mementoRibbonTabSelected.insidePen = new Pen(ribbonBackColor3);
				mementoRibbonTabSelected.centerPen = new Pen(ribbonBackColor5);
			}
			context.Graphics.FillPath(mementoRibbonTabSelected.insideBrush, mementoRibbonTabSelected.outsidePath);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabSelected.outsidePen, mementoRibbonTabSelected.outsidePath);
			}
			switch (orientation)
			{
			case VisualOrientation.Top:
				DrawRibbonTabSelectedTopDraw2007(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Left:
				DrawRibbonTabSelectedLeftDraw2007(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Right:
				DrawRibbonTabSelectedRightDraw2007(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Bottom:
				DrawRibbonTabSelectedBottomDraw2007(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			}
			context.Graphics.FillRectangle(mementoRibbonTabSelected.centerBrush, mementoRibbonTabSelected.centerRect);
		}
		return memento;
	}

	protected virtual void DrawRibbonTabSelectedTop2007(Rectangle rect, Color c4, Color c5, MementoRibbonTabSelected2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 1, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Top + 1.5f, rect.Left + 3, rect.Top);
		graphicsPath.AddLine(rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Top + 1.5f, rect.Right - 2, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		cache.centerRect = new Rectangle(rect.Left + 4, rect.Top + 4, rect.Width - 8, rect.Height - 4);
		RectangleF rect2 = new RectangleF(cache.centerRect.Left - 1, cache.centerRect.Top - 1, cache.centerRect.Width + 2, cache.centerRect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c4, c5, 90f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabSelectedTopDraw2007(Rectangle rect, MementoRibbonTabSelected2007 cache, Graphics g)
	{
		g.DrawLine(cache.insidePen, rect.Left + 1, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		g.DrawLine(cache.insidePen, rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
		g.DrawLine(cache.centerPen, rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		using (new AntiAlias(g))
		{
			g.DrawLine(cache.middlePen, (float)rect.Left + 0.5f, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Left + 2, rect.Bottom - 3, rect.Left + 2, rect.Top + 2);
			g.DrawLine(cache.middlePen, (float)rect.Right - 1.5f, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Right - 3, rect.Bottom - 3, rect.Right - 3, rect.Top + 2);
			g.DrawLine(_paleShadowPen, rect.Left - 1, rect.Bottom - 2, rect.Left - 1, rect.Top + 8);
			g.DrawLine(_lightShadowPen, rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 5);
			g.DrawLine(_darkShadowPen, rect.Right - 1, rect.Bottom - 3, rect.Right - 1, rect.Top + 3);
			g.DrawLine(_mediumShadowPen, rect.Right, rect.Bottom - 2, rect.Right, rect.Top + 7);
		}
	}

	protected virtual void DrawRibbonTabSelectedLeft2007(Rectangle rect, Color c4, Color c5, MementoRibbonTabSelected2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 2, (float)rect.Left + 1.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		graphicsPath.AddLine(rect.Left, rect.Top + 3, (float)rect.Left + 1.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Top + 1, rect.Right - 3, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 3, rect.Top + 1, rect.Right - 1, rect.Top);
		cache.centerRect = new Rectangle(rect.Left + 4, rect.Top + 4, rect.Width - 4, rect.Height - 8);
		RectangleF rect2 = new RectangleF(cache.centerRect.Left - 1, cache.centerRect.Top - 1, cache.centerRect.Width + 2, cache.centerRect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c4, c5, 0f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabSelectedLeftDraw2007(Rectangle rect, MementoRibbonTabSelected2007 cache, Graphics g)
	{
		g.DrawLine(cache.insidePen, rect.Right - 1, rect.Bottom - 2, rect.Right - 1, rect.Top + 1);
		g.DrawLine(cache.insidePen, rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 2);
		g.DrawLine(cache.centerPen, rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		using (new AntiAlias(g))
		{
			g.DrawLine(cache.middlePen, rect.Right - 1, (float)rect.Bottom - 1.5f, rect.Right - 3, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Right - 3, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Right - 1, (float)rect.Top + 0.5f, rect.Right - 3, rect.Top + 2);
			g.DrawLine(cache.middlePen, rect.Right - 3, rect.Top + 2, rect.Left + 2, rect.Top + 2);
			g.DrawLine(_paleShadowPen, rect.Right - 2, rect.Bottom, rect.Left + 8, rect.Bottom);
			g.DrawLine(_lightShadowPen, rect.Right - 3, rect.Bottom - 1, rect.Left + 5, rect.Bottom - 1);
			g.DrawLine(_darkShadowPen, rect.Right - 3, rect.Top, rect.Left + 3, rect.Top);
			g.DrawLine(_mediumShadowPen, rect.Right - 2, rect.Top - 1, rect.Left + 7, rect.Top - 1);
		}
	}

	protected virtual void DrawRibbonTabSelectedRight2007(Rectangle rect, Color c4, Color c5, MementoRibbonTabSelected2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 2, (float)rect.Right - 2.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 3, (float)rect.Right - 2.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Top + 1, rect.Left + 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 2, rect.Top + 1, rect.Left, rect.Top);
		cache.centerRect = new Rectangle(rect.Left, rect.Top + 4, rect.Width - 4, rect.Height - 8);
		RectangleF rect2 = new RectangleF(cache.centerRect.Left - 1, cache.centerRect.Top - 1, cache.centerRect.Width + 2, cache.centerRect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c4, c5, 180f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabSelectedRightDraw2007(Rectangle rect, MementoRibbonTabSelected2007 cache, Graphics g)
	{
		g.DrawLine(cache.insidePen, rect.Left, rect.Bottom - 2, rect.Left, rect.Top + 1);
		g.DrawLine(cache.insidePen, rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 2);
		g.DrawLine(cache.centerPen, rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		using (new AntiAlias(g))
		{
			g.DrawLine(cache.middlePen, rect.Left, (float)rect.Bottom - 1.5f, rect.Left + 2, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Left + 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, rect.Left, (float)rect.Top + 0.5f, rect.Left + 2, rect.Top + 2);
			g.DrawLine(cache.middlePen, rect.Left + 2, rect.Top + 2, rect.Right - 3, rect.Top + 2);
			g.DrawLine(_paleShadowPen, rect.Left + 1, rect.Bottom, rect.Right - 9, rect.Bottom);
			g.DrawLine(_lightShadowPen, rect.Left + 2, rect.Bottom - 1, rect.Right - 6, rect.Bottom - 1);
			g.DrawLine(_darkShadowPen, rect.Left + 2, rect.Top, rect.Right - 4, rect.Top);
			g.DrawLine(_mediumShadowPen, rect.Left + 1, rect.Top - 1, rect.Right - 8, rect.Top - 1);
		}
	}

	protected virtual void DrawRibbonTabSelectedBottom2007(Rectangle rect, Color c4, Color c5, MementoRibbonTabSelected2007 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top + 1, rect.Left + 1, rect.Top + 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 1, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Bottom - 2.5f, rect.Left + 3, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 2.5f, rect.Right - 2, rect.Top + 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 1, rect.Top + 1);
		cache.centerRect = new Rectangle(rect.Left + 4, rect.Top, rect.Width - 8, rect.Height - 4);
		RectangleF rect2 = new RectangleF(cache.centerRect.Left - 1, cache.centerRect.Top - 1, cache.centerRect.Width + 2, cache.centerRect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c4, c5, 270f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabSelectedBottomDraw2007(Rectangle rect, MementoRibbonTabSelected2007 cache, Graphics g)
	{
		g.DrawLine(cache.insidePen, rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		g.DrawLine(cache.insidePen, rect.Left + 2, rect.Top + 1, rect.Right - 3, rect.Top + 1);
		g.DrawLine(cache.centerPen, rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		using (new AntiAlias(g))
		{
			g.DrawLine(cache.middlePen, (float)rect.Left + 0.5f, rect.Top, rect.Left + 2, rect.Top + 2);
			g.DrawLine(cache.middlePen, rect.Left + 2, rect.Top + 2, rect.Left + 2, rect.Bottom - 3);
			g.DrawLine(cache.middlePen, (float)rect.Right - 1.5f, rect.Top, rect.Right - 3, rect.Top + 2);
			g.DrawLine(cache.middlePen, rect.Right - 3, rect.Top + 2, rect.Right - 3, rect.Bottom - 3);
			g.DrawLine(_paleShadowPen, rect.Left - 1, rect.Top + 1, rect.Left - 1, rect.Bottom - 9);
			g.DrawLine(_lightShadowPen, rect.Left, rect.Top + 2, rect.Left, rect.Bottom - 6);
			g.DrawLine(_darkShadowPen, rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 4);
			g.DrawLine(_mediumShadowPen, rect.Right, rect.Top + 1, rect.Right, rect.Bottom - 8);
		}
	}

	protected virtual IDisposable DrawRibbonTabSelected2010(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento, bool standard)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color color = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor4(state);
			Color color2 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonTabSelected2010 mementoRibbonTabSelected;
			if (memento == null || !(memento is MementoRibbonTabSelected2010))
			{
				memento?.Dispose();
				mementoRibbonTabSelected = new MementoRibbonTabSelected2010(rect, color, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, color2, orientation);
				memento = mementoRibbonTabSelected;
			}
			else
			{
				mementoRibbonTabSelected = (MementoRibbonTabSelected2010)memento;
				flag = !mementoRibbonTabSelected.UseCachedValues(rect, color, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, color2, orientation);
			}
			if (flag)
			{
				mementoRibbonTabSelected.Dispose();
				if (color2 != Color.Empty)
				{
					if (!standard)
					{
						color2 = CommonHelper.MergeColors(color2, 0.65f, Color.Black, 0.35f);
					}
					color = Color.FromArgb(196, color2);
				}
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabSelectedTop2010(rect, ribbonBackColor, ribbonBackColor2, color2, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabSelectedLeft2010(rect, ribbonBackColor, ribbonBackColor2, color2, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabSelectedRight2010(rect, ribbonBackColor, ribbonBackColor2, color2, mementoRibbonTabSelected);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabSelectedBottom2010(rect, ribbonBackColor, ribbonBackColor2, color2, mementoRibbonTabSelected);
					break;
				}
				mementoRibbonTabSelected.outsidePen = new Pen(color);
				mementoRibbonTabSelected.centerPen = new Pen(ribbonBackColor3);
			}
			context.Graphics.FillPath(mementoRibbonTabSelected.centerBrush, mementoRibbonTabSelected.outsidePath);
			if (color2 != Color.Empty)
			{
				context.Graphics.FillPath(mementoRibbonTabSelected.insideBrush, mementoRibbonTabSelected.insidePath);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabSelected.outsidePen, mementoRibbonTabSelected.outsidePath);
			}
			switch (orientation)
			{
			case VisualOrientation.Top:
				DrawRibbonTabSelectedTopDraw2010(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Left:
				DrawRibbonTabSelectedLeftDraw2010(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Right:
				DrawRibbonTabSelectedRightDraw2010(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			case VisualOrientation.Bottom:
				DrawRibbonTabSelectedBottomDraw2010(rect, mementoRibbonTabSelected, context.Graphics);
				break;
			}
		}
		return memento;
	}

	protected virtual void DrawRibbonTabSelectedTop2010(Rectangle rect, Color c2, Color c3, Color c5, MementoRibbonTabSelected2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 3, rect.Top);
		graphicsPath.AddLine(rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c2, c3, 90f);
		cache.centerBrush.Blend = _ribbonTabSelected1Blend;
		cache.outsidePath = graphicsPath;
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		graphicsPath2.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 3);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 2, rect.Top);
		graphicsPath2.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
		graphicsPath2.AddLine(rect.Right - 3, rect.Top, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Bottom - 3);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.insideBrush = new LinearGradientBrush(rect3, Color.FromArgb(32, c5), Color.Transparent, 90f);
		cache.insideBrush.Blend = _ribbonTabSelected2Blend;
		cache.insidePath = graphicsPath2;
	}

	protected virtual void DrawRibbonTabSelectedTopDraw2010(Rectangle rect, MementoRibbonTabSelected2010 cache, Graphics g)
	{
		g.DrawLine(cache.centerPen, rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
		g.DrawLine(cache.centerPen, rect.Left + 1, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		using (new AntiAlias(g))
		{
			g.DrawLine(_mediumShadowPen, rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 2);
			g.DrawLine(_mediumShadowPen, rect.Right - 1, rect.Bottom - 3, rect.Right - 1, rect.Top + 2);
		}
	}

	protected virtual void DrawRibbonTabSelectedLeft2010(Rectangle rect, Color c2, Color c3, Color c5, MementoRibbonTabSelected2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		graphicsPath.AddLine(rect.Left, rect.Top + 3, rect.Left + 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Right - 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Top);
		RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c2, c3, 0f);
		cache.centerBrush.Blend = _ribbonTabSelected1Blend;
		cache.outsidePath = graphicsPath;
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 2;
		rect.Height -= 3;
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
		graphicsPath2.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 2);
		graphicsPath2.AddLine(rect.Left, rect.Top + 2, rect.Left + 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 1, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Top);
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.insideBrush = new LinearGradientBrush(rect3, Color.FromArgb(32, c5), Color.Transparent, 0f);
		cache.insideBrush.Blend = _ribbonTabSelected2Blend;
		cache.insidePath = graphicsPath2;
	}

	protected virtual void DrawRibbonTabSelectedLeftDraw2010(Rectangle rect, MementoRibbonTabSelected2010 cache, Graphics g)
	{
		g.DrawLine(cache.centerPen, rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 2);
		g.DrawLine(cache.centerPen, rect.Right - 1, rect.Bottom - 2, rect.Right - 1, rect.Top + 1);
		using (new AntiAlias(g))
		{
			g.DrawLine(_mediumShadowPen, rect.Right - 3, rect.Bottom - 1, rect.Left + 3, rect.Bottom - 1);
			g.DrawLine(_mediumShadowPen, rect.Right - 3, rect.Top, rect.Left + 3, rect.Top);
		}
	}

	protected virtual void DrawRibbonTabSelectedRight2010(Rectangle rect, Color c2, Color c3, Color c5, MementoRibbonTabSelected2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 3, rect.Right - 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Top);
		RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c2, c3, 180f);
		cache.centerBrush.Blend = _ribbonTabSelected1Blend;
		cache.outsidePath = graphicsPath;
		rect.Y += 2;
		rect.Width--;
		rect.Height -= 3;
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
		graphicsPath2.AddLine(rect.Right - 3, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 4);
		graphicsPath2.AddLine(rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		graphicsPath2.AddLine(rect.Right - 1, rect.Top + 3, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Top);
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.insideBrush = new LinearGradientBrush(rect3, Color.FromArgb(32, c5), Color.Transparent, 180f);
		cache.insideBrush.Blend = _ribbonTabSelected2Blend;
		cache.insidePath = graphicsPath2;
	}

	protected virtual void DrawRibbonTabSelectedRightDraw2010(Rectangle rect, MementoRibbonTabSelected2010 cache, Graphics g)
	{
		g.DrawLine(cache.centerPen, rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 2);
		g.DrawLine(cache.centerPen, rect.Left, rect.Bottom - 2, rect.Left, rect.Top + 1);
		using (new AntiAlias(g))
		{
			g.DrawLine(_mediumShadowPen, rect.Left + 2, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
			g.DrawLine(_mediumShadowPen, rect.Left + 2, rect.Top, rect.Right - 4, rect.Top);
		}
	}

	protected virtual void DrawRibbonTabSelectedBottom2010(Rectangle rect, Color c2, Color c3, Color c5, MementoRibbonTabSelected2010 cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 2, rect.Left + 3, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top + 1);
		RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.centerBrush = new LinearGradientBrush(rect2, c2, c3, 270f);
		cache.centerBrush.Blend = _ribbonTabSelected1Blend;
		cache.outsidePath = graphicsPath;
		rect.X += 2;
		rect.Width -= 3;
		rect.Height--;
		graphicsPath2.AddLine(rect.Left, rect.Top + 1, rect.Left + 1, rect.Top + 1);
		graphicsPath2.AddLine(rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Bottom - 3);
		graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath2.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 3);
		graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 1);
		graphicsPath2.AddLine(rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top + 1);
		RectangleF rect3 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
		cache.insideBrush = new LinearGradientBrush(rect3, Color.FromArgb(32, c5), Color.Transparent, 270f);
		cache.insideBrush.Blend = _ribbonTabSelected2Blend;
		cache.insidePath = graphicsPath2;
	}

	protected virtual void DrawRibbonTabSelectedBottomDraw2010(Rectangle rect, MementoRibbonTabSelected2010 cache, Graphics g)
	{
		g.DrawLine(cache.centerPen, rect.Left + 2, rect.Top + 1, rect.Right - 3, rect.Top + 1);
		g.DrawLine(cache.centerPen, rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		using (new AntiAlias(g))
		{
			g.DrawLine(_mediumShadowPen, rect.Left, rect.Top + 2, rect.Left, rect.Bottom - 4);
			g.DrawLine(_mediumShadowPen, rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 4);
		}
	}

	protected virtual IDisposable DrawRibbonTabContextSelected(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonTabContextSelected mementoRibbonTabContextSelected;
			if (memento == null || !(memento is MementoRibbonTabContextSelected))
			{
				memento?.Dispose();
				mementoRibbonTabContextSelected = new MementoRibbonTabContextSelected(rect, ribbonBackColor, ribbonBackColor2, orientation);
				memento = mementoRibbonTabContextSelected;
			}
			else
			{
				mementoRibbonTabContextSelected = (MementoRibbonTabContextSelected)memento;
				flag = !mementoRibbonTabContextSelected.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, orientation);
			}
			if (flag)
			{
				mementoRibbonTabContextSelected.Dispose();
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabContextSelectedTop(rect, ribbonBackColor2, mementoRibbonTabContextSelected);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabContextSelectedLeft(rect, ribbonBackColor2, mementoRibbonTabContextSelected);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabContextSelectedRight(rect, ribbonBackColor2, mementoRibbonTabContextSelected);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabContextSelectedBottom(rect, ribbonBackColor2, mementoRibbonTabContextSelected);
					break;
				}
				mementoRibbonTabContextSelected.outsidePen = new Pen(ribbonBackColor);
				mementoRibbonTabContextSelected.l1 = new Pen(Color.FromArgb(100, ribbonBackColor2));
				mementoRibbonTabContextSelected.l2 = new Pen(Color.FromArgb(75, ribbonBackColor2));
				mementoRibbonTabContextSelected.l3 = new Pen(Color.FromArgb(48, ribbonBackColor2));
				mementoRibbonTabContextSelected.bottomInnerPen = new Pen(Color.FromArgb(70, ribbonBackColor2));
				mementoRibbonTabContextSelected.bottomOuterPen = new Pen(Color.FromArgb(100, ribbonBackColor2));
			}
			context.Graphics.FillRectangle(Brushes.White, mementoRibbonTabContextSelected.interiorRect);
			context.Graphics.FillRectangle(mementoRibbonTabContextSelected.insideBrush, mementoRibbonTabContextSelected.interiorRect);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonTabContextSelected.outsidePen, mementoRibbonTabContextSelected.outsidePath);
			}
			switch (orientation)
			{
			case VisualOrientation.Top:
				DrawRibbonTabContextSelectedTopDraw(rect, mementoRibbonTabContextSelected, context.Graphics);
				break;
			case VisualOrientation.Left:
				DrawRibbonTabContextSelectedLeftDraw(rect, mementoRibbonTabContextSelected, context.Graphics);
				break;
			case VisualOrientation.Right:
				DrawRibbonTabContextSelectedRightDraw(rect, mementoRibbonTabContextSelected, context.Graphics);
				break;
			case VisualOrientation.Bottom:
				DrawRibbonTabContextSelectedBottomDraw(rect, mementoRibbonTabContextSelected, context.Graphics);
				break;
			}
		}
		return memento;
	}

	protected virtual void DrawRibbonTabContextSelectedTop(Rectangle rect, Color c2, MementoRibbonTabContextSelected cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 1, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Top + 1.5f, rect.Left + 3, rect.Top);
		graphicsPath.AddLine(rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, (float)rect.Top + 1.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Top + 1.5f, rect.Right - 2, rect.Bottom - 3);
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(125, c2), Color.FromArgb(67, c2), 90f);
		LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(16, c2), Color.FromArgb(67, c2), 90f);
		cache.leftPen = new Pen(brush);
		cache.rightPen = new Pen(brush2);
		cache.interiorRect = new Rectangle(rect.Left + 2, rect.Top + 3, rect.Width - 4, rect.Height - 3);
		cache.insideBrush = new LinearGradientBrush(rect, Color.FromArgb(134, c2), Color.FromArgb(50, c2), 90f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabContextSelectedTopDraw(Rectangle rect, MementoRibbonTabContextSelected cache, Graphics g)
	{
		g.DrawLine(Pens.White, rect.Left + 2, rect.Top + 3, rect.Right - 3, rect.Top + 3);
		g.DrawLine(cache.l3, rect.Left + 2, rect.Top + 3, rect.Right - 3, rect.Top + 3);
		g.DrawLine(Pens.White, rect.Left + 2, rect.Top + 2, rect.Right - 3, rect.Top + 2);
		g.DrawLine(cache.l2, rect.Left + 2, rect.Top + 2, rect.Right - 3, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Left + 3, rect.Top + 1, rect.Right - 4, rect.Top + 1);
		g.DrawLine(cache.l1, rect.Left + 3, rect.Top + 1, rect.Right - 4, rect.Top + 1);
		g.DrawLine(cache.leftPen, rect.Left + 2, rect.Top + 4, rect.Left + 2, rect.Bottom - 3);
		g.DrawLine(cache.rightPen, rect.Right - 3, rect.Top + 2, rect.Right - 3, rect.Bottom - 3);
		g.DrawLine(Pens.White, rect.Left + 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 1);
		g.DrawLine(cache.bottomInnerPen, rect.Left + 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 1);
		g.DrawLine(Pens.White, rect.Right - 3, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 1);
		g.DrawLine(cache.bottomInnerPen, rect.Right - 3, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 1);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		g.DrawLine(cache.bottomOuterPen, rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		g.DrawLine(cache.bottomOuterPen, rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
	}

	protected virtual void DrawRibbonTabContextSelectedLeft(Rectangle rect, Color c2, MementoRibbonTabContextSelected cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 2, (float)rect.Left + 1.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		graphicsPath.AddLine(rect.Left, rect.Top + 3, (float)rect.Left + 1.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Left + 1.5f, rect.Top + 1, rect.Right - 3, rect.Top + 1);
		graphicsPath.AddLine(rect.Right - 3, rect.Top + 1, rect.Right - 2, rect.Top);
		LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(125, c2), Color.FromArgb(67, c2), 0f);
		LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(16, c2), Color.FromArgb(67, c2), 0f);
		cache.leftPen = new Pen(brush);
		cache.rightPen = new Pen(brush2);
		cache.interiorRect = new Rectangle(rect.Left + 3, rect.Top + 2, rect.Width - 3, rect.Height - 4);
		cache.insideBrush = new LinearGradientBrush(rect, Color.FromArgb(134, c2), Color.FromArgb(50, c2), 0f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabContextSelectedLeftDraw(Rectangle rect, MementoRibbonTabContextSelected cache, Graphics g)
	{
		g.DrawLine(Pens.White, rect.Left + 3, rect.Bottom - 3, rect.Left + 3, rect.Top + 2);
		g.DrawLine(cache.l3, rect.Left + 3, rect.Bottom - 3, rect.Left + 3, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Left + 2, rect.Bottom - 3, rect.Left + 2, rect.Top + 2);
		g.DrawLine(cache.l2, rect.Left + 2, rect.Bottom - 3, rect.Left + 2, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Bottom - 4, rect.Left + 1, rect.Top + 3);
		g.DrawLine(cache.l1, rect.Left + 1, rect.Bottom - 4, rect.Left + 1, rect.Top + 3);
		g.DrawLine(cache.leftPen, rect.Left + 4, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
		g.DrawLine(cache.rightPen, rect.Left + 2, rect.Top + 2, rect.Right - 3, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		g.DrawLine(cache.bottomInnerPen, rect.Right - 2, rect.Bottom - 3, rect.Right - 1, rect.Bottom - 2);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Top + 2, rect.Right - 1, rect.Top + 1);
		g.DrawLine(cache.bottomInnerPen, rect.Right - 2, rect.Top + 2, rect.Right - 1, rect.Top + 1);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		g.DrawLine(cache.bottomOuterPen, rect.Right - 2, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 1);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
		g.DrawLine(cache.bottomOuterPen, rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
	}

	protected virtual void DrawRibbonTabContextSelectedRight(Rectangle rect, Color c2, MementoRibbonTabContextSelected cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left + 1, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 2);
		graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 2, (float)rect.Right - 2.5f, rect.Bottom - 2);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 4);
		graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		graphicsPath.AddLine(rect.Right - 1, rect.Top + 3, (float)rect.Right - 2.5f, rect.Top + 1);
		graphicsPath.AddLine((float)rect.Right - 2.5f, rect.Top + 1, rect.Left + 2, rect.Top + 1);
		graphicsPath.AddLine(rect.Left + 2, rect.Top + 1, rect.Left + 1, rect.Top);
		LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(125, c2), Color.FromArgb(67, c2), 180f);
		LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(16, c2), Color.FromArgb(67, c2), 180f);
		cache.leftPen = new Pen(brush);
		cache.rightPen = new Pen(brush2);
		cache.interiorRect = new Rectangle(rect.Left, rect.Top + 2, rect.Width - 3, rect.Height - 4);
		cache.insideBrush = new LinearGradientBrush(rect, Color.FromArgb(134, c2), Color.FromArgb(50, c2), 180f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabContextSelectedRightDraw(Rectangle rect, MementoRibbonTabContextSelected cache, Graphics g)
	{
		g.DrawLine(Pens.White, rect.Right - 4, rect.Bottom - 3, rect.Right - 4, rect.Top + 2);
		g.DrawLine(cache.l3, rect.Right - 4, rect.Bottom - 3, rect.Right - 4, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Right - 3, rect.Bottom - 3, rect.Right - 3, rect.Top + 2);
		g.DrawLine(cache.l2, rect.Right - 3, rect.Bottom - 3, rect.Right - 3, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Bottom - 4, rect.Right - 2, rect.Top + 3);
		g.DrawLine(cache.l1, rect.Right - 2, rect.Bottom - 4, rect.Right - 2, rect.Top + 3);
		g.DrawLine(cache.leftPen, rect.Right - 5, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 3);
		g.DrawLine(cache.rightPen, rect.Right - 3, rect.Top + 2, rect.Left + 2, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Bottom - 3, rect.Left, rect.Bottom - 2);
		g.DrawLine(cache.bottomInnerPen, rect.Left + 1, rect.Bottom - 3, rect.Left, rect.Bottom - 2);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Top + 2, rect.Left, rect.Top + 1);
		g.DrawLine(cache.bottomInnerPen, rect.Left + 1, rect.Top + 2, rect.Left, rect.Top + 1);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		g.DrawLine(cache.bottomOuterPen, rect.Left + 1, rect.Bottom - 2, rect.Left, rect.Bottom - 1);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Top + 1, rect.Left, rect.Top);
		g.DrawLine(cache.bottomOuterPen, rect.Left + 1, rect.Top + 1, rect.Left, rect.Top);
	}

	protected virtual void DrawRibbonTabContextSelectedBottom(Rectangle rect, Color c2, MementoRibbonTabContextSelected cache)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rect.Left, rect.Top + 1, rect.Left + 1, rect.Top + 2);
		graphicsPath.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 1, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Left + 1, (float)rect.Bottom - 2.5f, rect.Left + 3, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 1, rect.Right - 2, (float)rect.Bottom - 2.5f);
		graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 2.5f, rect.Right - 2, rect.Top + 2);
		graphicsPath.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 1, rect.Top + 1);
		LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(125, c2), Color.FromArgb(67, c2), 270f);
		LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(16, c2), Color.FromArgb(67, c2), 270f);
		cache.leftPen = new Pen(brush);
		cache.rightPen = new Pen(brush2);
		cache.interiorRect = new Rectangle(rect.Left + 2, rect.Top, rect.Width - 4, rect.Height - 3);
		cache.insideBrush = new LinearGradientBrush(rect, Color.FromArgb(134, c2), Color.FromArgb(50, c2), 270f);
		cache.outsidePath = graphicsPath;
	}

	protected virtual void DrawRibbonTabContextSelectedBottomDraw(Rectangle rect, MementoRibbonTabContextSelected cache, Graphics g)
	{
		g.DrawLine(Pens.White, rect.Left + 2, rect.Bottom - 4, rect.Right - 3, rect.Bottom - 4);
		g.DrawLine(cache.l3, rect.Left + 2, rect.Bottom - 4, rect.Right - 3, rect.Bottom - 4);
		g.DrawLine(Pens.White, rect.Left + 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
		g.DrawLine(cache.l2, rect.Left + 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
		g.DrawLine(Pens.White, rect.Left + 3, rect.Bottom - 2, rect.Right - 4, rect.Bottom - 2);
		g.DrawLine(cache.l1, rect.Left + 3, rect.Bottom - 2, rect.Right - 4, rect.Bottom - 2);
		g.DrawLine(cache.leftPen, rect.Left + 2, rect.Bottom - 5, rect.Left + 2, rect.Top + 2);
		g.DrawLine(cache.rightPen, rect.Right - 3, rect.Bottom - 3, rect.Right - 3, rect.Top + 2);
		g.DrawLine(Pens.White, rect.Left + 2, rect.Top + 1, rect.Left + 1, rect.Top);
		g.DrawLine(cache.bottomInnerPen, rect.Left + 2, rect.Top + 1, rect.Left + 1, rect.Top);
		g.DrawLine(Pens.White, rect.Right - 3, rect.Top + 1, rect.Right - 2, rect.Top);
		g.DrawLine(cache.bottomInnerPen, rect.Right - 3, rect.Top + 1, rect.Right - 2, rect.Top);
		g.DrawLine(Pens.White, rect.Left + 1, rect.Top + 1, rect.Left, rect.Top);
		g.DrawLine(cache.bottomOuterPen, rect.Left + 1, rect.Top + 1, rect.Left, rect.Top);
		g.DrawLine(Pens.White, rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
		g.DrawLine(cache.bottomOuterPen, rect.Right - 2, rect.Top + 1, rect.Right - 1, rect.Top);
	}

	protected virtual IDisposable DrawRibbonTabHighlight(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, IDisposable memento, bool alternate)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonTabHighlight mementoRibbonTabHighlight;
			if (memento == null || !(memento is MementoRibbonTabHighlight))
			{
				memento?.Dispose();
				mementoRibbonTabHighlight = new MementoRibbonTabHighlight(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, orientation);
				memento = mementoRibbonTabHighlight;
			}
			else
			{
				mementoRibbonTabHighlight = (MementoRibbonTabHighlight)memento;
				flag = !mementoRibbonTabHighlight.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, orientation);
			}
			if (flag)
			{
				mementoRibbonTabHighlight.Dispose();
				switch (orientation)
				{
				case VisualOrientation.Top:
					DrawRibbonTabHighlightTop(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight);
					break;
				case VisualOrientation.Left:
					DrawRibbonTabHighlightLeft(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight);
					break;
				case VisualOrientation.Right:
					DrawRibbonTabHighlightRight(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight);
					break;
				case VisualOrientation.Bottom:
					DrawRibbonTabHighlightBottom(rect, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight);
					break;
				}
				mementoRibbonTabHighlight.innerVertPen = new Pen(ribbonBackColor);
				mementoRibbonTabHighlight.innerHorzPen = new Pen(ribbonBackColor2);
				mementoRibbonTabHighlight.borderHorzPen = new Pen(ribbonBackColor3);
			}
			mementoRibbonTabHighlight.selectedMemento = (MementoRibbonTabSelected2007)DrawRibbonTabSelected2007(context, rect, PaletteState.CheckedNormal, palette, orientation, mementoRibbonTabHighlight.selectedMemento);
			switch (orientation)
			{
			case VisualOrientation.Top:
				DrawRibbonTabHighlightTopDraw(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight, context.Graphics, alternate);
				break;
			case VisualOrientation.Left:
				DrawRibbonTabHighlightLeftDraw(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight, context.Graphics, alternate);
				break;
			case VisualOrientation.Right:
				DrawRibbonTabHighlightRightDraw(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight, context.Graphics, alternate);
				break;
			case VisualOrientation.Bottom:
				DrawRibbonTabHighlightBottomDraw(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, mementoRibbonTabHighlight, context.Graphics, alternate);
				break;
			}
		}
		return memento;
	}

	protected virtual void DrawRibbonTabHighlightTop(Rectangle rect, Color c4, Color c5, MementoRibbonTabHighlight cache)
	{
		RectangleF rect2 = new RectangleF(rect.Left - 2, rect.Top - 1, rect.Width + 4, 6f);
		RectangleF rect3 = new RectangleF(rect.Left - 2, rect.Top + 1, rect.Width + 4, rect.Height - 1);
		cache.topBorderBrush = new LinearGradientBrush(rect2, Color.FromArgb(48, c5), Color.FromArgb(64, c5), 90f);
		cache.borderVertBrush = new LinearGradientBrush(rect3, c5, c4, 90f);
		cache.outsideVertBrush = new LinearGradientBrush(rect3, Color.FromArgb(48, c5), c5, 90f);
	}

	protected virtual void DrawRibbonTabHighlightTopDraw(Rectangle rect, Color c1, Color c2, Color c3, Color c4, Color c5, MementoRibbonTabHighlight cache, Graphics g, bool alternate)
	{
		g.FillRectangle(cache.topBorderBrush, rect.Left - 1, rect.Top - 1, rect.Width + 2, 4);
		g.DrawLine(cache.innerVertPen, rect.Left + 2, rect.Bottom - 2, rect.Left + 2, rect.Top + 3);
		g.DrawLine(cache.innerVertPen, rect.Right - 3, rect.Bottom - 2, rect.Right - 3, rect.Top + 3);
		g.DrawLine(cache.innerHorzPen, rect.Left + 2, rect.Top + 2, rect.Right - 3, rect.Top + 2);
		if (alternate)
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 2, rect.Top + 1, rect.Right - 3, rect.Top + 1);
			g.DrawLine(cache.borderHorzPen, rect.Left + 3, rect.Top, rect.Right - 4, rect.Top);
		}
		else
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 3, rect.Top + 1, rect.Right - 4, rect.Top + 1);
			g.DrawLine(cache.borderHorzPen, rect.Left + 4, rect.Top, rect.Right - 5, rect.Top);
		}
		g.FillRectangle(cache.borderVertBrush, rect.Left + 1, rect.Top + 2, 1, rect.Height - 3);
		g.FillRectangle(cache.borderVertBrush, rect.Right - 2, rect.Top + 2, 1, rect.Height - 3);
		g.FillRectangle(cache.outsideVertBrush, rect.Left, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Left - 1, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Right - 1, rect.Top + 3, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Right, rect.Top + 3, 1, rect.Height - 4);
	}

	protected virtual void DrawRibbonTabHighlightLeft(Rectangle rect, Color c4, Color c5, MementoRibbonTabHighlight cache)
	{
		RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 2, 6f, rect.Height - 4);
		RectangleF rect3 = new RectangleF(rect.Left + 1, rect.Top - 2, rect.Width - 1, rect.Height - 4);
		cache.topBorderBrush = new LinearGradientBrush(rect2, Color.FromArgb(48, c5), Color.FromArgb(64, c5), 0f);
		cache.borderVertBrush = new LinearGradientBrush(rect3, c5, c4, 0f);
		cache.outsideVertBrush = new LinearGradientBrush(rect3, Color.FromArgb(48, c5), c5, 0f);
	}

	protected virtual void DrawRibbonTabHighlightLeftDraw(Rectangle rect, Color c1, Color c2, Color c3, Color c4, Color c5, MementoRibbonTabHighlight cache, Graphics g, bool alternate)
	{
		g.FillRectangle(cache.topBorderBrush, rect.Left - 1, rect.Top - 1, 4, rect.Height + 2);
		g.DrawLine(cache.innerVertPen, rect.Right - 2, rect.Bottom - 3, rect.Left + 3, rect.Bottom - 3);
		g.DrawLine(cache.innerVertPen, rect.Right - 2, rect.Top + 2, rect.Left + 3, rect.Top + 2);
		g.DrawLine(cache.innerHorzPen, rect.Left + 2, rect.Bottom - 3, rect.Left + 2, rect.Top + 2);
		if (alternate)
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 2);
			g.DrawLine(cache.borderHorzPen, rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 3);
		}
		else
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 1, rect.Bottom - 4, rect.Left + 1, rect.Top + 3);
			g.DrawLine(cache.borderHorzPen, rect.Left, rect.Bottom - 5, rect.Left, rect.Top + 4);
		}
		g.FillRectangle(cache.borderVertBrush, rect.Left + 2, rect.Bottom - 2, rect.Width - 3, 1);
		g.FillRectangle(cache.borderVertBrush, rect.Left + 2, rect.Top + 1, rect.Width - 3, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 3, rect.Bottom - 1, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 3, rect.Bottom, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 3, rect.Top, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 3, rect.Top - 1, rect.Width - 4, 1);
	}

	protected virtual void DrawRibbonTabHighlightRight(Rectangle rect, Color c4, Color c5, MementoRibbonTabHighlight cache)
	{
		RectangleF rect2 = new RectangleF(rect.Right - 6, rect.Top - 2, 6f, rect.Height - 4);
		RectangleF rect3 = new RectangleF(rect.Left, rect.Top - 2, rect.Width - 1, rect.Height - 4);
		cache.topBorderBrush = new LinearGradientBrush(rect2, Color.FromArgb(48, c5), Color.FromArgb(64, c5), 180f);
		cache.borderVertBrush = new LinearGradientBrush(rect3, c5, c4, 180f);
		cache.outsideVertBrush = new LinearGradientBrush(rect3, Color.FromArgb(48, c5), c5, 180f);
	}

	protected virtual void DrawRibbonTabHighlightRightDraw(Rectangle rect, Color c1, Color c2, Color c3, Color c4, Color c5, MementoRibbonTabHighlight cache, Graphics g, bool alternate)
	{
		g.FillRectangle(cache.topBorderBrush, rect.Right - 4, rect.Top - 1, 4, rect.Height + 2);
		g.DrawLine(cache.innerVertPen, rect.Left + 1, rect.Bottom - 3, rect.Right - 4, rect.Bottom - 3);
		g.DrawLine(cache.innerVertPen, rect.Left + 1, rect.Top + 2, rect.Right - 4, rect.Top + 2);
		g.DrawLine(cache.innerHorzPen, rect.Right - 3, rect.Bottom - 3, rect.Right - 3, rect.Top + 2);
		if (alternate)
		{
			g.DrawLine(cache.innerHorzPen, rect.Right - 2, rect.Bottom - 3, rect.Right - 2, rect.Top + 2);
			g.DrawLine(cache.borderHorzPen, rect.Right - 1, rect.Bottom - 4, rect.Right - 1, rect.Top + 3);
		}
		else
		{
			g.DrawLine(cache.innerHorzPen, rect.Right - 2, rect.Bottom - 4, rect.Right - 2, rect.Top + 3);
			g.DrawLine(cache.borderHorzPen, rect.Right - 1, rect.Bottom - 5, rect.Right - 1, rect.Top + 4);
		}
		g.FillRectangle(cache.borderVertBrush, rect.Left + 1, rect.Bottom - 2, rect.Width - 3, 1);
		g.FillRectangle(cache.borderVertBrush, rect.Left + 1, rect.Top + 1, rect.Width - 3, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 1, rect.Bottom - 1, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 1, rect.Bottom, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 1, rect.Top, rect.Width - 4, 1);
		g.FillRectangle(cache.outsideVertBrush, rect.Left + 1, rect.Top - 1, rect.Width - 4, 1);
	}

	protected virtual void DrawRibbonTabHighlightBottom(Rectangle rect, Color c4, Color c5, MementoRibbonTabHighlight cache)
	{
		RectangleF rect2 = new RectangleF(rect.Left - 2, rect.Bottom - 6, rect.Width + 4, 6f);
		RectangleF rect3 = new RectangleF(rect.Left - 2, rect.Top, rect.Width + 4, rect.Height - 1);
		cache.topBorderBrush = new LinearGradientBrush(rect2, Color.FromArgb(48, c5), Color.FromArgb(64, c5), 270f);
		cache.borderVertBrush = new LinearGradientBrush(rect3, c5, c4, 270f);
		cache.outsideVertBrush = new LinearGradientBrush(rect3, Color.FromArgb(48, c5), c5, 270f);
	}

	protected virtual void DrawRibbonTabHighlightBottomDraw(Rectangle rect, Color c1, Color c2, Color c3, Color c4, Color c5, MementoRibbonTabHighlight cache, Graphics g, bool alternate)
	{
		g.FillRectangle(cache.topBorderBrush, rect.Left - 1, rect.Bottom - 3, rect.Width + 2, 4);
		g.DrawLine(cache.innerVertPen, rect.Left + 2, rect.Top + 1, rect.Left + 2, rect.Bottom - 4);
		g.DrawLine(cache.innerVertPen, rect.Right - 3, rect.Top + 1, rect.Right - 3, rect.Bottom - 4);
		g.DrawLine(cache.innerHorzPen, rect.Left + 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
		if (alternate)
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 2, rect.Bottom - 2, rect.Right - 3, rect.Bottom - 2);
			g.DrawLine(cache.borderHorzPen, rect.Left + 3, rect.Bottom - 1, rect.Right - 4, rect.Bottom - 1);
		}
		else
		{
			g.DrawLine(cache.innerHorzPen, rect.Left + 3, rect.Bottom - 2, rect.Right - 4, rect.Bottom - 2);
			g.DrawLine(cache.borderHorzPen, rect.Left + 4, rect.Bottom - 1, rect.Right - 5, rect.Bottom - 1);
		}
		g.FillRectangle(cache.borderVertBrush, rect.Left + 1, rect.Top + 1, 1, rect.Height - 3);
		g.FillRectangle(cache.borderVertBrush, rect.Right - 2, rect.Top + 1, 1, rect.Height - 3);
		g.FillRectangle(cache.outsideVertBrush, rect.Left, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Left - 1, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Right - 1, rect.Top + 1, 1, rect.Height - 4);
		g.FillRectangle(cache.outsideVertBrush, rect.Right, rect.Top + 1, 1, rect.Height - 4);
	}

	protected virtual IDisposable DrawRibbonTabContext(RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonTabSeparatorContextColor = paletteGeneral.GetRibbonTabSeparatorContextColor(PaletteState.Normal);
			Color ribbonBackColor = paletteBack.GetRibbonBackColor5(PaletteState.ContextCheckedNormal);
			bool flag = true;
			MementoRibbonTabContext mementoRibbonTabContext;
			if (memento == null || !(memento is MementoRibbonTabContext))
			{
				memento?.Dispose();
				mementoRibbonTabContext = new MementoRibbonTabContext(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
				memento = mementoRibbonTabContext;
			}
			else
			{
				mementoRibbonTabContext = (MementoRibbonTabContext)memento;
				flag = !mementoRibbonTabContext.UseCachedValues(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
			}
			if (flag)
			{
				mementoRibbonTabContext.Dispose();
				Rectangle rect2 = new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2);
				mementoRibbonTabContext.fillRect = new Rectangle(rect.X + 1, rect.Y, rect.Width - 2, rect.Height - 1);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, ribbonTabSeparatorContextColor, Color.Transparent, 270f);
				linearGradientBrush.Blend = _ribbonGroup5Blend;
				mementoRibbonTabContext.borderPen = new Pen(linearGradientBrush);
				LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect2, Color.Transparent, Color.FromArgb(200, ribbonBackColor), 0f);
				linearGradientBrush2.Blend = _ribbonGroup7Blend;
				mementoRibbonTabContext.underlinePen = new Pen(linearGradientBrush2);
				mementoRibbonTabContext.fillBrush = new LinearGradientBrush(rect2, Color.FromArgb(196, ribbonBackColor), Color.Transparent, 270f);
				mementoRibbonTabContext.fillBrush.Blend = _ribbonGroup6Blend;
			}
			context.Graphics.DrawLine(mementoRibbonTabContext.borderPen, rect.X, rect.Y, rect.X, rect.Bottom - 1);
			context.Graphics.DrawLine(mementoRibbonTabContext.borderPen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
			context.Graphics.FillRectangle(mementoRibbonTabContext.fillBrush, mementoRibbonTabContext.fillRect);
			context.Graphics.DrawLine(mementoRibbonTabContext.underlinePen, rect.X + 1, rect.Bottom - 1, rect.Right - 2, rect.Bottom - 1);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonAppButton(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, bool trackBorderAsPressed, IDisposable memento)
	{
		rect.Width -= 3;
		rect.Height -= 3;
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			Color bottomDark = CommonHelper.MergeColors(ribbonBackColor3, 0.78f, Color.Empty, 0.22f);
			bool flag = true;
			MementoRibbonAppButton mementoRibbonAppButton;
			if (memento == null || !(memento is MementoRibbonAppButton))
			{
				memento?.Dispose();
				mementoRibbonAppButton = new MementoRibbonAppButton(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
				memento = mementoRibbonAppButton;
			}
			else
			{
				mementoRibbonAppButton = (MementoRibbonAppButton)memento;
				flag = !mementoRibbonAppButton.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
			}
			if (flag)
			{
				mementoRibbonAppButton.Dispose();
				mementoRibbonAppButton.borderShadow1 = new RectangleF(rect.X, rect.Y, rect.Width + 2, rect.Height + 2);
				mementoRibbonAppButton.borderShadow2 = new RectangleF(rect.X, rect.Y, rect.Width + 1, rect.Height + 1);
				mementoRibbonAppButton.borderMain1 = new RectangleF(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
				mementoRibbonAppButton.borderMain2 = new RectangleF(mementoRibbonAppButton.borderMain1.X + 1f, mementoRibbonAppButton.borderMain1.Y + 1f, mementoRibbonAppButton.borderMain1.Width - 2f, mementoRibbonAppButton.borderMain1.Height - 2f);
				mementoRibbonAppButton.borderMain3 = new RectangleF(mementoRibbonAppButton.borderMain1.X + 1f, mementoRibbonAppButton.borderMain1.Y + 1f, mementoRibbonAppButton.borderMain1.Width - 2f, mementoRibbonAppButton.borderMain1.Height - 2f);
				mementoRibbonAppButton.borderMain4 = new RectangleF(mementoRibbonAppButton.borderMain2.X, mementoRibbonAppButton.borderMain2.Y + 1f, mementoRibbonAppButton.borderMain2.Width, mementoRibbonAppButton.borderMain2.Height - 2f);
				mementoRibbonAppButton.rectBottomGlow = new RectangleF(0f, 0f, (float)rect.Width * 0.75f, (float)rect.Height * 0.75f);
				mementoRibbonAppButton.rectLower = new RectangleF(rect.X, rect.Y - 1, rect.Width, rect.Height + 1);
				mementoRibbonAppButton.rectUpperGlow = default(RectangleF);
				mementoRibbonAppButton.rectUpperGlow.Width = rect.Width - 4;
				mementoRibbonAppButton.rectUpperGlow.Height = rect.Height / 8;
				mementoRibbonAppButton.rectUpperGlow.Y = (float)rect.Y + ((float)rect.Height - mementoRibbonAppButton.rectUpperGlow.Height) / 2f;
				mementoRibbonAppButton.rectUpperGlow.X = (float)rect.X + ((float)rect.Width - mementoRibbonAppButton.rectUpperGlow.Width) / 2f;
				mementoRibbonAppButton.brushUpper1 = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, LinearGradientMode.Horizontal);
				mementoRibbonAppButton.brushLower = new LinearGradientBrush(mementoRibbonAppButton.rectLower, Color.Transparent, Color.Transparent, LinearGradientMode.Horizontal);
			}
			using (new AntiAlias(context.Graphics))
			{
				DrawRibbonAppButtonBorder1(context.Graphics, mementoRibbonAppButton);
				DrawRibbonAppButtonUpperHalf(context.Graphics, mementoRibbonAppButton, state, ribbonBackColor3, bottomDark, ribbonBackColor, ribbonBackColor2, trackBorderAsPressed);
				DrawRibbonAppButtonLowerHalf(context.Graphics, mementoRibbonAppButton, state, bottomDark, ribbonBackColor4, ribbonBackColor5);
				DrawRibbonAppButtonGlowCenter(context.Graphics, mementoRibbonAppButton, state, ribbonBackColor, ribbonBackColor4);
				DrawRibbonAppButtonGlowUpperBottom(context.Graphics, mementoRibbonAppButton, state, ribbonBackColor4, ribbonBackColor5, bottomDark);
				DrawRibbonAppButtonBorder2(context.Graphics, mementoRibbonAppButton, state, ribbonBackColor4, trackBorderAsPressed);
			}
		}
		return memento;
	}

	protected virtual void DrawRibbonAppButtonBorder1(Graphics g, MementoRibbonAppButton memento)
	{
		g.FillEllipse(_buttonBorder1Brush, memento.borderShadow1);
		g.FillEllipse(_buttonBorder2Brush, memento.borderShadow2);
	}

	protected virtual void DrawRibbonAppButtonUpperHalf(Graphics g, MementoRibbonAppButton memento, PaletteState state, Color topDark, Color bottomDark, Color topLight, Color topMedium, bool trackBorderAsPressed)
	{
		bool flag = state == PaletteState.Pressed;
		bool flag2 = state == PaletteState.Tracking;
		if (flag2 && trackBorderAsPressed)
		{
			flag = true;
			flag2 = false;
		}
		if (!flag)
		{
			Color[] colors = new Color[6] { topDark, topMedium, topLight, topLight, topMedium, topDark };
			float[] positions = new float[6] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = colors;
			colorBlend.Positions = positions;
			memento.brushUpper1.InterpolationColors = colorBlend;
			g.FillPie(memento.brushUpper1, memento.rect.X, memento.rect.Y, memento.rect.Width, memento.rect.Height, 180, 180);
		}
		Color color = _whiten10;
		Color color2 = Color.FromArgb(100, topDark);
		if (flag2)
		{
			color = _whiten200;
			color2 = Color.FromArgb(200, bottomDark);
		}
		if (flag)
		{
			color = Color.White;
			color2 = topDark;
		}
		using LinearGradientBrush brush = new LinearGradientBrush(memento.rect, color, color2, LinearGradientMode.Vertical);
		g.FillPie(brush, memento.rect.X, memento.rect.Y, memento.rect.Width, memento.rect.Height, 180, 180);
	}

	protected virtual void DrawRibbonAppButtonLowerHalf(Graphics g, MementoRibbonAppButton memento, PaletteState state, Color bottomDark, Color bottomLight, Color bottomMedium)
	{
		Color[] colors = new Color[6] { bottomDark, bottomMedium, bottomLight, bottomLight, bottomMedium, bottomDark };
		float[] positions = ((state != PaletteState.Pressed) ? new float[6] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f } : new float[6] { 0f, 0.3f, 0.5f, 0.5f, 0.7f, 1f });
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = colors;
		colorBlend.Positions = positions;
		memento.brushLower.InterpolationColors = colorBlend;
		g.FillPie(memento.brushLower, memento.rectLower.X, memento.rectLower.Y, memento.rectLower.Width, memento.rectLower.Height, 0f, 180f);
	}

	protected virtual void DrawRibbonAppButtonGlowCenter(Graphics g, MementoRibbonAppButton memento, PaletteState state, Color topLight, Color bottomLight)
	{
		using LinearGradientBrush brush = new LinearGradientBrush(memento.rectBottomGlow, Color.FromArgb(50, Color.White), Color.FromArgb(30, Color.White), LinearGradientMode.Vertical);
		RectangleF rectBottomGlow = memento.rectBottomGlow;
		rectBottomGlow.X = (float)memento.rect.X + ((float)memento.rect.Width - rectBottomGlow.Width) / 2f;
		rectBottomGlow.Y = (float)memento.rect.Y + ((float)memento.rect.Height - rectBottomGlow.Height - 2f);
		if (state != PaletteState.Pressed)
		{
			g.FillPie(brush, rectBottomGlow.X, rectBottomGlow.Y, rectBottomGlow.Width, rectBottomGlow.Height, 0f, 360f);
		}
		if (state != PaletteState.Pressed)
		{
			return;
		}
		rectBottomGlow.Height = (float)memento.rect.Height * 0.2f;
		rectBottomGlow.Width = (float)memento.rect.Width * 0.4f;
		rectBottomGlow.X = (float)memento.rect.X + ((float)memento.rect.Width - rectBottomGlow.Width) / 2f;
		rectBottomGlow.Y = (float)memento.rect.Y + ((float)memento.rect.Height - rectBottomGlow.Height);
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectBottomGlow);
		using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
		pathGradientBrush.CenterColor = topLight;
		pathGradientBrush.SurroundColors = new Color[1] { Color.FromArgb(100, bottomLight) };
		g.FillEllipse(pathGradientBrush, rectBottomGlow);
	}

	protected virtual void DrawRibbonAppButtonGlowUpperBottom(Graphics g, MementoRibbonAppButton memento, PaletteState state, Color bottomLight, Color bottomMedium, Color bottomDark)
	{
		int alpha = 50;
		int alpha2 = 50;
		if (state == PaletteState.Pressed || state == PaletteState.Tracking)
		{
			alpha = 200;
			alpha2 = 200;
		}
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(memento.rectUpperGlow, Color.Transparent, Color.Transparent, LinearGradientMode.Horizontal);
		Color[] colors = new Color[6]
		{
			Color.FromArgb(180, bottomDark),
			Color.FromArgb(alpha2, bottomMedium),
			Color.FromArgb(alpha, bottomLight),
			Color.FromArgb(alpha, bottomLight),
			Color.FromArgb(alpha2, bottomMedium),
			Color.FromArgb(180, bottomDark)
		};
		float[] positions = new float[6] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = colors;
		colorBlend.Positions = positions;
		linearGradientBrush.InterpolationColors = colorBlend;
		g.FillPie(linearGradientBrush, memento.rectUpperGlow.X, memento.rectUpperGlow.Y, memento.rectUpperGlow.Width, memento.rectUpperGlow.Height, 180f, 180f);
	}

	protected virtual void DrawRibbonAppButtonBorder2(Graphics g, MementoRibbonAppButton memento, PaletteState state, Color bottomLight, bool trackBorderAsPressed)
	{
		bool flag = state == PaletteState.Pressed;
		bool flag2 = state == PaletteState.Tracking;
		if (flag2 && trackBorderAsPressed)
		{
			flag = true;
			flag2 = false;
		}
		Color color = (flag ? _whiten80 : ((!flag2 || flag) ? _whiten120 : Color.FromArgb(200, bottomLight)));
		using (Pen pen = new Pen(color))
		{
			g.DrawEllipse(pen, memento.borderMain1);
		}
		using (Pen pen2 = new Pen(Color.FromArgb(100, 52, 59, 64)))
		{
			g.DrawEllipse(pen2, memento.rect);
		}
		if (flag)
		{
			color = _whiten60;
			using Pen pen3 = new Pen(color);
			g.DrawEllipse(pen3, memento.borderMain3);
		}
		color = (flag ? _whiten50 : _whiten80);
		using (Pen pen4 = new Pen(color))
		{
			g.DrawArc(pen4, memento.borderMain2, 180f, 180f);
		}
		if (!flag)
		{
			color = _whiten30;
			using Pen pen5 = new Pen(color);
			g.DrawArc(pen5, memento.borderMain4, 180f, 180f);
		}
		if (flag2 && !flag)
		{
			using (Pen pen6 = new Pen(Color.FromArgb(100, color)))
			{
				g.DrawEllipse(pen6, memento.rect);
			}
		}
	}

	protected virtual IDisposable DrawRibbonAppTab(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, Color baseColor1, Color baseColor2, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			bool flag = true;
			MementoRibbonAppTab mementoRibbonAppTab;
			if (memento == null || !(memento is MementoRibbonAppTab))
			{
				memento?.Dispose();
				mementoRibbonAppTab = new MementoRibbonAppTab(rect, baseColor1, baseColor2);
				memento = mementoRibbonAppTab;
			}
			else
			{
				mementoRibbonAppTab = (MementoRibbonAppTab)memento;
				flag = !mementoRibbonAppTab.UseCachedValues(rect, baseColor1, baseColor2);
			}
			if (flag)
			{
				mementoRibbonAppTab.Dispose();
				mementoRibbonAppTab.GeneratePaths(rect, state);
				mementoRibbonAppTab.borderPen = new Pen(baseColor1);
				switch (state)
				{
				case PaletteState.Normal:
					mementoRibbonAppTab.borderBrush = new SolidBrush(CommonHelper.MergeColors(baseColor1, 0.2f, baseColor2, 0.8f));
					mementoRibbonAppTab.insideFillBrush = new LinearGradientBrush(new RectangleF(rect.X, rect.Y + 1, rect.Width, rect.Height), CommonHelper.MergeColors(baseColor1, 0.3f, baseColor2, 0.7f), CommonHelper.MergeColors(baseColor1, 0.6f, baseColor2, 0.4f), 90f);
					mementoRibbonAppTab.insideFillBrush.SetSigmaBellShape(0.33f);
					mementoRibbonAppTab.highlightBrush.CenterColor = Color.FromArgb(64, Color.White);
					break;
				case PaletteState.Tracking:
					mementoRibbonAppTab.borderBrush = new SolidBrush(baseColor2);
					mementoRibbonAppTab.insideFillBrush = new LinearGradientBrush(new RectangleF(rect.X, rect.Y + 1, rect.Width, rect.Height), CommonHelper.MergeColors(baseColor1, 0.3f, baseColor2, 0.7f), CommonHelper.MergeColors(baseColor1, 0.6f, baseColor2, 0.4f), 90f);
					mementoRibbonAppTab.insideFillBrush.SetSigmaBellShape(0.33f);
					mementoRibbonAppTab.highlightBrush.CenterColor = Color.FromArgb(100, Color.White);
					break;
				case PaletteState.FocusOverride | PaletteState.Tracking:
					mementoRibbonAppTab.borderBrush = new SolidBrush(ControlPaint.LightLight(baseColor2));
					mementoRibbonAppTab.insideFillBrush = new LinearGradientBrush(new RectangleF(rect.X, rect.Y + 1, rect.Width, rect.Height), CommonHelper.MergeColors(baseColor1, 0.3f, baseColor2, 0.7f), CommonHelper.MergeColors(baseColor1, 0.6f, baseColor2, 0.4f), 90f);
					mementoRibbonAppTab.insideFillBrush.SetSigmaBellShape(0.33f);
					mementoRibbonAppTab.highlightBrush.CenterColor = ControlPaint.LightLight(baseColor2);
					break;
				case PaletteState.Pressed:
					mementoRibbonAppTab.borderBrush = new SolidBrush(CommonHelper.MergeColors(baseColor1, 0.5f, baseColor2, 0.5f));
					mementoRibbonAppTab.insideFillBrush = new LinearGradientBrush(new RectangleF(rect.X, rect.Y + 1, rect.Width, rect.Height), CommonHelper.MergeColors(baseColor1, 0.3f, baseColor2, 0.7f), CommonHelper.MergeColors(baseColor1, 0.75f, baseColor2, 0.25f), 90f);
					mementoRibbonAppTab.insideFillBrush.SetSigmaBellShape(0f);
					mementoRibbonAppTab.highlightBrush.CenterColor = Color.FromArgb(90, Color.White);
					break;
				}
			}
			context.Graphics.FillPath(mementoRibbonAppTab.borderBrush, mementoRibbonAppTab.borderFillPath);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonAppTab.borderPen, mementoRibbonAppTab.borderPath);
			}
			context.Graphics.FillPath(mementoRibbonAppTab.insideFillBrush, mementoRibbonAppTab.insideFillPath);
			using (new Clipping(context.Graphics, mementoRibbonAppTab.insideFillPath))
			{
				context.Graphics.FillPath(mementoRibbonAppTab.highlightBrush, mementoRibbonAppTab.highlightPath);
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupNormalBorder(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, bool tracking, bool lightInside, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonGroupNormalBorder mementoRibbonGroupNormalBorder;
			if (memento == null || !(memento is MementoRibbonGroupNormalBorder))
			{
				memento?.Dispose();
				mementoRibbonGroupNormalBorder = new MementoRibbonGroupNormalBorder(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonGroupNormalBorder;
			}
			else
			{
				mementoRibbonGroupNormalBorder = (MementoRibbonGroupNormalBorder)memento;
				flag = !mementoRibbonGroupNormalBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonGroupNormalBorder.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 4, rect.Top);
				graphicsPath.AddLine(rect.Right - 4, rect.Top, rect.Right - 2, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 2, rect.Bottom - 4);
				graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 4, rect.Right - 4, rect.Bottom - 2);
				graphicsPath.AddLine(rect.Right - 4, rect.Bottom - 2, rect.Left + 2, rect.Bottom - 2);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Left, rect.Bottom - 4);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 4, rect.Left, rect.Top + 2);
				graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
				graphicsPath2.AddLine(rect.Right - 4, rect.Top + 1, rect.Left + 2, rect.Top + 1);
				graphicsPath2.AddLine(rect.Left + 2, rect.Top + 1, rect.Left + 1, rect.Top + 2);
				graphicsPath2.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 1, rect.Bottom - 4);
				graphicsPath3.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath3.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath3.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 3, rect.Bottom - 1);
				graphicsPath4.AddLine(rect.Left + 2, rect.Top + 1, rect.Right - 4, rect.Top + 1);
				graphicsPath4.AddLine(rect.Right - 4, rect.Top + 1, rect.Right - 3, rect.Top + 2);
				graphicsPath4.AddLine(rect.Right - 3, rect.Top + 2, rect.Right - 3, rect.Bottom - 4);
				graphicsPath4.AddLine(rect.Right - 3, rect.Bottom - 4, rect.Right - 4, rect.Bottom - 3);
				graphicsPath4.AddLine(rect.Right - 4, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 3);
				graphicsPath4.AddLine(rect.Left + 2, rect.Bottom - 3, rect.Left + 1, rect.Bottom - 4);
				graphicsPath4.AddLine(rect.Left + 1, rect.Bottom - 4, rect.Left + 1, rect.Top + 2);
				graphicsPath4.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 2, rect.Top + 1);
				RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
				LinearGradientBrush brush = new LinearGradientBrush(rect2, ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonGroupNormalBorder.solidPen = new Pen(brush);
				mementoRibbonGroupNormalBorder.backRect = new Rectangle(rect.Left + 2, rect.Top + 1, rect.Width - 4, rect.Height - 4);
				mementoRibbonGroupNormalBorder.solidPath = graphicsPath;
				mementoRibbonGroupNormalBorder.insidePath = graphicsPath2;
				mementoRibbonGroupNormalBorder.outsidePath = graphicsPath3;
				mementoRibbonGroupNormalBorder.lightPath = graphicsPath4;
			}
			if (tracking)
			{
				context.Graphics.FillRectangle(lightInside ? _whitenLightLBrush : _whitenLightBrush, mementoRibbonGroupNormalBorder.backRect);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonGroupNormalBorder.solidPen, mementoRibbonGroupNormalBorder.solidPath);
				if (!lightInside)
				{
					context.Graphics.DrawPath(_whitenMediumPen, mementoRibbonGroupNormalBorder.insidePath);
					context.Graphics.DrawPath(_whitenMediumPen, mementoRibbonGroupNormalBorder.outsidePath);
				}
			}
			if (lightInside)
			{
				context.Graphics.DrawPath(Pens.White, mementoRibbonGroupNormalBorder.lightPath);
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupNormalBorderSep(bool showingInPopup, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento, bool pressed, bool tracking, bool dark)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonGroupNormalBorderSep mementoRibbonGroupNormalBorderSep;
			if (memento == null || !(memento is MementoRibbonGroupNormalBorderSep))
			{
				memento?.Dispose();
				mementoRibbonGroupNormalBorderSep = new MementoRibbonGroupNormalBorderSep(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, tracking, dark);
				memento = mementoRibbonGroupNormalBorderSep;
			}
			else
			{
				mementoRibbonGroupNormalBorderSep = (MementoRibbonGroupNormalBorderSep)memento;
				flag = !mementoRibbonGroupNormalBorderSep.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5, tracking, dark);
			}
			if (flag)
			{
				mementoRibbonGroupNormalBorderSep.Dispose();
				RectangleF rect2 = new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2);
				mementoRibbonGroupNormalBorderSep.totalBrush = new LinearGradientBrush(rect2, ribbonBackColor2, ribbonBackColor, 90f);
				mementoRibbonGroupNormalBorderSep.innerBrush = new LinearGradientBrush(rect2, ribbonBackColor4, ribbonBackColor3, 90f);
				mementoRibbonGroupNormalBorderSep.trackSepBrush = new LinearGradientBrush(rect2, ribbonBackColor5, ribbonBackColor2, 90f);
				mementoRibbonGroupNormalBorderSep.totalBrush.Blend = _ribbonGroup9Blend;
				mementoRibbonGroupNormalBorderSep.innerBrush.Blend = _ribbonGroup9Blend;
				mementoRibbonGroupNormalBorderSep.trackSepBrush.Blend = _ribbonGroup9Blend;
				mementoRibbonGroupNormalBorderSep.innerPen = new Pen(mementoRibbonGroupNormalBorderSep.innerBrush);
				mementoRibbonGroupNormalBorderSep.trackSepPen = new Pen(mementoRibbonGroupNormalBorderSep.trackSepBrush);
				mementoRibbonGroupNormalBorderSep.trackBottomPen = new Pen(ribbonBackColor5);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(new Rectangle(rect.X, rect.Y + rect.Height / 2, rect.Width - 3, rect.Height));
				mementoRibbonGroupNormalBorderSep.trackHighlightBrush = new PathGradientBrush(graphicsPath);
				mementoRibbonGroupNormalBorderSep.trackHighlightBrush.SurroundColors = new Color[1] { Color.Transparent };
				mementoRibbonGroupNormalBorderSep.trackHighlightBrush.CenterColor = ((!dark) ? _whiten160 : ((rect.Width > 50) ? _whiten60 : _whiten45));
				mementoRibbonGroupNormalBorderSep.trackHighlightBrush.CenterPoint = new PointF(rect.X + (rect.Width - 3) / 2, rect.Height);
				mementoRibbonGroupNormalBorderSep.trackFillBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 1), dark ? _whiten5 : _whiten10, dark ? _whiten5 : _darken5, 90f);
				mementoRibbonGroupNormalBorderSep.pressedFillBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), dark ? Color.Empty : _whiten10, dark ? _darken38 : _darken16, 90f);
				mementoRibbonGroupNormalBorderSep.trackFillBrush.Blend = _linear50Blend;
			}
			if (!showingInPopup)
			{
				context.Graphics.FillRectangle(mementoRibbonGroupNormalBorderSep.totalBrush, rect.Right - 3, rect.Top, 3, rect.Height);
				context.Graphics.DrawLine(mementoRibbonGroupNormalBorderSep.innerPen, rect.Right - 2, rect.Top, rect.Right - 2, rect.Bottom - 1);
			}
			if (tracking || pressed)
			{
				if (pressed)
				{
					context.Graphics.FillRectangle(mementoRibbonGroupNormalBorderSep.pressedFillBrush, rect.X, rect.Y, rect.Width - 2, rect.Height);
				}
				else if (tracking)
				{
					context.Graphics.FillRectangle(mementoRibbonGroupNormalBorderSep.trackFillBrush, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
					context.Graphics.FillRectangle(mementoRibbonGroupNormalBorderSep.trackHighlightBrush, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
				}
				if (!showingInPopup && !pressed && !dark)
				{
					context.Graphics.DrawLine(mementoRibbonGroupNormalBorderSep.trackSepPen, rect.Right - 3, rect.Top, rect.Right - 3, rect.Bottom - 1);
				}
				if (!showingInPopup && tracking)
				{
					context.Graphics.DrawLine(mementoRibbonGroupNormalBorderSep.trackBottomPen, rect.Right - 3, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
				}
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupNormalTitle(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonGroupNormalTitle mementoRibbonGroupNormalTitle;
			if (memento == null || !(memento is MementoRibbonGroupNormalTitle))
			{
				memento?.Dispose();
				mementoRibbonGroupNormalTitle = new MementoRibbonGroupNormalTitle(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonGroupNormalTitle;
			}
			else
			{
				mementoRibbonGroupNormalTitle = (MementoRibbonGroupNormalTitle)memento;
				flag = !mementoRibbonGroupNormalTitle.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonGroupNormalTitle.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddLine(rect.Left, rect.Top, rect.Right - 1, rect.Top);
				graphicsPath.AddLine(rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top);
				RectangleF rect2 = new RectangleF((float)rect.Left - 0.5f, (float)rect.Top - 0.5f, rect.Width + 1, rect.Height + 1);
				mementoRibbonGroupNormalTitle.titleBrush = new LinearGradientBrush(rect2, ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonGroupNormalTitle.titlePath = graphicsPath;
			}
			context.Graphics.FillPath(mementoRibbonGroupNormalTitle.titleBrush, mementoRibbonGroupNormalTitle.titlePath);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupCollapsedBorder(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			bool flag = true;
			MementoRibbonGroupCollapsedBorder mementoRibbonGroupCollapsedBorder;
			if (memento == null || !(memento is MementoRibbonGroupCollapsedBorder))
			{
				memento?.Dispose();
				mementoRibbonGroupCollapsedBorder = new MementoRibbonGroupCollapsedBorder(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4);
				memento = mementoRibbonGroupCollapsedBorder;
			}
			else
			{
				mementoRibbonGroupCollapsedBorder = (MementoRibbonGroupCollapsedBorder)memento;
				flag = !mementoRibbonGroupCollapsedBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4);
			}
			if (flag)
			{
				mementoRibbonGroupCollapsedBorder.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath.AddLine((float)rect.Left + 1.25f, rect.Top, rect.Right - 2, rect.Top);
				graphicsPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, (float)rect.Top + 1.25f);
				graphicsPath.AddLine(rect.Left, (float)rect.Top + 1.25f, (float)rect.Left + 1.25f, rect.Top);
				graphicsPath2.AddLine(rect.Left + 2, rect.Top + 1, rect.Right - 3, rect.Top + 1);
				graphicsPath2.AddLine(rect.Right - 3, rect.Top + 1, rect.Right - 2, rect.Top + 2);
				graphicsPath2.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 2, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Right - 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Right - 3, rect.Bottom - 2, rect.Left + 2, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Left + 2, rect.Bottom - 2, rect.Left + 1, rect.Bottom - 3);
				graphicsPath2.AddLine(rect.Left + 1, rect.Bottom - 3, rect.Left + 1, rect.Top + 2);
				graphicsPath2.AddLine(rect.Left + 1, rect.Top + 2, rect.Left + 2, rect.Top + 1);
				RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
				RectangleF rect3 = new RectangleF(rect.Left, rect.Top, rect.Width, rect.Height);
				LinearGradientBrush brush = new LinearGradientBrush(rect2, ribbonBackColor, ribbonBackColor2, 90f);
				LinearGradientBrush brush2 = new LinearGradientBrush(rect3, ribbonBackColor3, ribbonBackColor4, 90f);
				mementoRibbonGroupCollapsedBorder.solidPath = graphicsPath;
				mementoRibbonGroupCollapsedBorder.insidePath = graphicsPath2;
				mementoRibbonGroupCollapsedBorder.solidPen = new Pen(brush);
				mementoRibbonGroupCollapsedBorder.insidePen = new Pen(brush2);
			}
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonGroupCollapsedBorder.solidPen, mementoRibbonGroupCollapsedBorder.solidPath);
				context.Graphics.DrawPath(mementoRibbonGroupCollapsedBorder.insidePen, mementoRibbonGroupCollapsedBorder.insidePath);
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupCollapsedFrameBorder(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonGroupCollapsedFrameBorder mementoRibbonGroupCollapsedFrameBorder;
			if (memento == null || !(memento is MementoRibbonGroupCollapsedFrameBorder))
			{
				memento?.Dispose();
				mementoRibbonGroupCollapsedFrameBorder = new MementoRibbonGroupCollapsedFrameBorder(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonGroupCollapsedFrameBorder;
			}
			else
			{
				mementoRibbonGroupCollapsedFrameBorder = (MementoRibbonGroupCollapsedFrameBorder)memento;
				flag = !mementoRibbonGroupCollapsedFrameBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonGroupCollapsedFrameBorder.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
				graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 2);
				graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
				mementoRibbonGroupCollapsedFrameBorder.solidPath = graphicsPath;
				mementoRibbonGroupCollapsedFrameBorder.titleBrush = new SolidBrush(ribbonBackColor2);
				mementoRibbonGroupCollapsedFrameBorder.solidPen = new Pen(ribbonBackColor);
			}
			Rectangle rect2 = new Rectangle(rect.Left + 1, rect.Bottom - _groupFrameTitleHeight, rect.Width - 2, _groupFrameTitleHeight - 1);
			context.Graphics.FillRectangle(mementoRibbonGroupCollapsedFrameBorder.titleBrush, rect2);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonGroupCollapsedFrameBorder.solidPen, mementoRibbonGroupCollapsedFrameBorder.solidPath);
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupGradientOne(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonGroupGradientOne mementoRibbonGroupGradientOne;
			if (memento == null || !(memento is MementoRibbonGroupGradientOne))
			{
				memento?.Dispose();
				mementoRibbonGroupGradientOne = new MementoRibbonGroupGradientOne(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonGroupGradientOne;
			}
			else
			{
				mementoRibbonGroupGradientOne = (MementoRibbonGroupGradientOne)memento;
				flag = !mementoRibbonGroupGradientOne.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonGroupGradientOne.Dispose();
				RectangleF rect2 = new RectangleF(rect.Left - 1, rect.Top - 1, rect.Width + 2, rect.Height + 2);
				mementoRibbonGroupGradientOne.brush = new LinearGradientBrush(rect2, ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonGroupGradientOne.brush.Blend = _ribbonGroup8Blend;
			}
			context.Graphics.FillRectangle(mementoRibbonGroupGradientOne.brush, rect);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonGroupGradientTwo(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, float percent, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			bool flag = true;
			MementoRibbonGroupGradientTwo mementoRibbonGroupGradientTwo;
			if (memento == null || !(memento is MementoRibbonGroupGradientTwo))
			{
				memento?.Dispose();
				mementoRibbonGroupGradientTwo = new MementoRibbonGroupGradientTwo(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4);
				memento = mementoRibbonGroupGradientTwo;
			}
			else
			{
				mementoRibbonGroupGradientTwo = (MementoRibbonGroupGradientTwo)memento;
				flag = !mementoRibbonGroupGradientTwo.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4);
			}
			if (flag)
			{
				mementoRibbonGroupGradientTwo.Dispose();
				int num = (int)((float)rect.Height * percent);
				Rectangle topRect = new Rectangle(rect.Left, rect.Top, rect.Width, num);
				Rectangle bottomRect = new Rectangle(rect.Left, topRect.Bottom, rect.Width, rect.Height - num);
				RectangleF rect2 = new RectangleF(topRect.Left - 1, topRect.Top - 1, topRect.Width + 2, topRect.Height + 2);
				RectangleF rect3 = new RectangleF(bottomRect.Left - 1, bottomRect.Top - 1, bottomRect.Width + 2, bottomRect.Height + 2);
				mementoRibbonGroupGradientTwo.topBrush = new LinearGradientBrush(rect2, ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonGroupGradientTwo.bottomBrush = new LinearGradientBrush(rect3, ribbonBackColor3, ribbonBackColor4, 90f);
				mementoRibbonGroupGradientTwo.topRect = topRect;
				mementoRibbonGroupGradientTwo.bottomRect = bottomRect;
			}
			context.Graphics.FillRectangle(mementoRibbonGroupGradientTwo.topBrush, mementoRibbonGroupGradientTwo.topRect);
			context.Graphics.FillRectangle(mementoRibbonGroupGradientTwo.bottomBrush, mementoRibbonGroupGradientTwo.bottomRect);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonQATMinibarSingle(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, bool composition, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonQATMinibar mementoRibbonQATMinibar;
			if (memento == null || !(memento is MementoRibbonQATMinibar))
			{
				memento?.Dispose();
				mementoRibbonQATMinibar = new MementoRibbonQATMinibar(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
				memento = mementoRibbonQATMinibar;
			}
			else
			{
				mementoRibbonQATMinibar = (MementoRibbonQATMinibar)memento;
				flag = !mementoRibbonQATMinibar.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
			}
			if (flag)
			{
				mementoRibbonQATMinibar.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				int num = rect.X + 1;
				int num2 = rect.Right - 3;
				int num3 = rect.Y + 2;
				int num4 = rect.Bottom - 3;
				int num5 = num3 + (num4 - num3) / 2;
				graphicsPath.AddLine(num2 - 8, num4, (float)num + 10.75f, num4);
				graphicsPath.AddLine((float)num + 10.75f, num4, num + 10, (float)num4 - 8f);
				graphicsPath.AddLine(num + 10, (float)num4 - 8f, num + 9, (float)num4 - 11f);
				graphicsPath.AddLine(num + 9, (float)num4 - 11f, num + 8, (float)num4 - 13f);
				graphicsPath.AddLine(num + 8, (float)num4 - 13f, num + 7, (float)num4 - 15f);
				graphicsPath.AddLine(num + 7, (float)num4 - 15f, num + 1, (float)num3 + 0.25f);
				graphicsPath.AddLine(num + 1, (float)num3 + 0.25f, num - 1, (float)num3 + 0.25f);
				graphicsPath.AddLine(num - 1, (float)num3 + 0.25f, num2 - 8, (float)num3 + 0.25f);
				graphicsPath.AddLine(num2 - 8, (float)num3 + 0.25f, num2 - 5, num3 + 1);
				graphicsPath.AddLine(num2 - 5, num3 + 1, num2 - 1, num3 + 5);
				graphicsPath.AddLine(num2 - 1, num3 + 5, num2, num3 + 8);
				graphicsPath.AddLine(num2, num3 + 8, (float)num2 + 0.4f, num5);
				graphicsPath.AddLine((float)num2 + 0.4f, num5, num2, (float)num4 - 8.25f);
				graphicsPath.AddLine(num2, (float)num4 - 8.25f, num2 - 1, (float)num4 - 5.25f);
				graphicsPath.AddLine(num2 - 1, (float)num4 - 5.25f, num2 - 5, (float)num4 - 1.25f);
				graphicsPath.AddLine(num2 - 5, (float)num4 - 1.25f, num2 - 8, num4);
				graphicsPath2.AddLine(rect.Left - 1, (float)rect.Top + 1.25f, rect.Right - 11, (float)rect.Top + 1.25f);
				graphicsPath2.AddLine(rect.Right - 11, (float)rect.Top + 1.5f, rect.Right - 8, (float)rect.Top + 2.25f);
				graphicsPath2.AddLine(rect.Right - 8, (float)rect.Top + 2.25f, rect.Right - 5, (float)rect.Top + 5.75f);
				graphicsPath3.AddLine((float)rect.Left + 10.75f, rect.Bottom - 11, (float)rect.Left + 10.75f, rect.Bottom - 5);
				graphicsPath3.AddLine((float)rect.Left + 10.75f, rect.Bottom - 5, rect.Left + 13, rect.Bottom - 2);
				graphicsPath3.AddLine(rect.Left + 13, rect.Bottom - 2, rect.Right - 11, rect.Bottom - 2);
				graphicsPath3.AddLine(rect.Right - 11, rect.Bottom - 2, (float)rect.Right - 8.5f, rect.Bottom - 3);
				graphicsPath3.AddLine((float)rect.Right - 8.5f, rect.Bottom - 3, (float)rect.Right - 4.5f, rect.Bottom - 7);
				graphicsPath3.AddLine((float)rect.Right - 4.5f, rect.Bottom - 7, (float)rect.Right - 2.5f, rect.Bottom - 9);
				graphicsPath3.AddLine((float)rect.Right - 2.5f, rect.Bottom - 9, rect.Right - 2, rect.Bottom - 11);
				graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 11, rect.Right - 2, rect.Bottom - 15);
				RectangleF rect2 = rect;
				rect2.Y += 1.5f;
				rect2.Height *= 1.25f;
				mementoRibbonQATMinibar.innerBrush = new LinearGradientBrush(rect2, ribbonBackColor2, ribbonBackColor3, 90f);
				mementoRibbonQATMinibar.innerBrush.SetSigmaBellShape(0.5f);
				mementoRibbonQATMinibar.borderPath = graphicsPath;
				mementoRibbonQATMinibar.topRight1 = graphicsPath2;
				mementoRibbonQATMinibar.bottomLeft1 = graphicsPath3;
				mementoRibbonQATMinibar.lightPen = new Pen(ribbonBackColor4, 2f);
				mementoRibbonQATMinibar.borderPen = new Pen(ribbonBackColor);
				mementoRibbonQATMinibar.whitenPen = new Pen(ribbonBackColor5);
			}
			using (new AntiAlias(context.Graphics))
			{
				if (!composition)
				{
					context.Graphics.DrawPath(mementoRibbonQATMinibar.lightPen, mementoRibbonQATMinibar.topRight1);
					context.Graphics.DrawPath(mementoRibbonQATMinibar.lightPen, mementoRibbonQATMinibar.bottomLeft1);
					context.Graphics.FillPath(mementoRibbonQATMinibar.innerBrush, mementoRibbonQATMinibar.borderPath);
					context.Graphics.DrawPath(mementoRibbonQATMinibar.borderPen, mementoRibbonQATMinibar.borderPath);
					context.Graphics.DrawLine(mementoRibbonQATMinibar.whitenPen, rect.Left + 10, rect.Top + 2, rect.Right - 10, rect.Top + 2);
					context.Graphics.DrawLine(mementoRibbonQATMinibar.whitenPen, rect.Left + 12, rect.Top + 3, rect.Right - 8, rect.Top + 3);
					context.Graphics.DrawLine(mementoRibbonQATMinibar.whitenPen, rect.Left + 14, rect.Top + 4, rect.Right - 7, rect.Top + 4);
				}
				else
				{
					context.Graphics.FillPath(_compositionBrush, mementoRibbonQATMinibar.borderPath);
					context.Graphics.DrawPath(_compositionPen, mementoRibbonQATMinibar.borderPath);
				}
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonQATMinibarDouble(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, bool composition, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			Color ribbonBackColor4 = palette.GetRibbonBackColor4(state);
			Color ribbonBackColor5 = palette.GetRibbonBackColor5(state);
			bool flag = true;
			MementoRibbonQATMinibar mementoRibbonQATMinibar;
			if (memento == null || !(memento is MementoRibbonQATMinibar))
			{
				memento?.Dispose();
				mementoRibbonQATMinibar = new MementoRibbonQATMinibar(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
				memento = mementoRibbonQATMinibar;
			}
			else
			{
				mementoRibbonQATMinibar = (MementoRibbonQATMinibar)memento;
				flag = !mementoRibbonQATMinibar.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3, ribbonBackColor4, ribbonBackColor5);
			}
			if (flag)
			{
				mementoRibbonQATMinibar.Dispose();
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				int num = rect.X + 1;
				int num2 = rect.Right - 3;
				int num3 = rect.Y + 2;
				int num4 = rect.Bottom - 3;
				int num5 = num3 + (num4 - num3) / 2;
				graphicsPath.AddLine(num2 - 8, (float)num3 + 0.25f, num2 - 5, num3 + 1);
				graphicsPath.AddLine(num2 - 5, num3 + 1, num2 - 1, num3 + 5);
				graphicsPath.AddLine(num2 - 1, num3 + 5, num2, num3 + 8);
				graphicsPath.AddLine(num2, num3 + 8, (float)num2 + 0.4f, num5);
				graphicsPath.AddLine((float)num2 + 0.4f, num5, num2, (float)num4 - 8.25f);
				graphicsPath.AddLine(num2, (float)num4 - 8.25f, num2 - 1, (float)num4 - 5.25f);
				graphicsPath.AddLine(num2 - 1, (float)num4 - 5.25f, num2 - 5, (float)num4 - 1.25f);
				graphicsPath.AddLine(num2 - 5, (float)num4 - 1.25f, num2 - 8, num4);
				graphicsPath.AddLine(num2 - 8, num4, num + 9, num4);
				graphicsPath.AddLine(num + 9, num4, num + 6, (float)num4 - 1.25f);
				graphicsPath.AddLine(num + 6, (float)num4 - 1.25f, num + 2, (float)num4 - 5.25f);
				graphicsPath.AddLine(num + 2, (float)num4 - 5.25f, num + 1, (float)num4 - 8.25f);
				graphicsPath.AddLine(num + 1, (float)num4 - 8.25f, (float)num + 0.4f, num5);
				graphicsPath.AddLine((float)num + 0.4f, num5, num + 1, num3 + 8);
				graphicsPath.AddLine(num + 1, num3 + 8, num + 2, num3 + 5);
				graphicsPath.AddLine(num + 2, num3 + 5, num + 6, num3 + 1);
				graphicsPath.AddLine(num + 6, num3 + 1, num + 9, (float)num3 + 0.25f);
				graphicsPath.AddLine(num + 9, (float)num3 + 0.25f, num2 - 8, (float)num3 + 0.25f);
				graphicsPath2.AddLine(rect.Left + 8, (float)rect.Top + 3.25f, rect.Left + 10, (float)rect.Top + 1.25f);
				graphicsPath2.AddLine(rect.Left + 10, (float)rect.Top + 1.25f, rect.Right - 11, (float)rect.Top + 1.25f);
				graphicsPath2.AddLine(rect.Right - 11, (float)rect.Top + 1.5f, rect.Right - 8, (float)rect.Top + 2.25f);
				graphicsPath2.AddLine(rect.Right - 8, (float)rect.Top + 2.25f, rect.Right - 5, (float)rect.Top + 5.75f);
				graphicsPath3.AddLine(rect.Left + 13, rect.Bottom - 2, rect.Right - 11, rect.Bottom - 2);
				graphicsPath3.AddLine(rect.Right - 11, rect.Bottom - 2, (float)rect.Right - 8.5f, rect.Bottom - 3);
				graphicsPath3.AddLine((float)rect.Right - 8.5f, rect.Bottom - 3, (float)rect.Right - 4.5f, rect.Bottom - 7);
				graphicsPath3.AddLine((float)rect.Right - 4.5f, rect.Bottom - 7, (float)rect.Right - 2.5f, rect.Bottom - 9);
				graphicsPath3.AddLine((float)rect.Right - 2.5f, rect.Bottom - 9, rect.Right - 2, rect.Bottom - 11);
				graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 11, rect.Right - 2, rect.Bottom - 15);
				RectangleF rect2 = rect;
				rect2.Y += 1.5f;
				rect2.Height *= 1.25f;
				mementoRibbonQATMinibar.innerBrush = new LinearGradientBrush(rect2, ribbonBackColor2, ribbonBackColor3, 90f);
				mementoRibbonQATMinibar.innerBrush.SetSigmaBellShape(0.5f);
				mementoRibbonQATMinibar.borderPath = graphicsPath;
				mementoRibbonQATMinibar.topRight1 = graphicsPath2;
				mementoRibbonQATMinibar.bottomLeft1 = graphicsPath3;
				mementoRibbonQATMinibar.lightPen = new Pen(ribbonBackColor4, 2f);
				mementoRibbonQATMinibar.borderPen = new Pen(ribbonBackColor);
				mementoRibbonQATMinibar.whitenPen = new Pen(ribbonBackColor5);
			}
			using (new AntiAlias(context.Graphics))
			{
				if (!composition)
				{
					context.Graphics.DrawPath(mementoRibbonQATMinibar.lightPen, mementoRibbonQATMinibar.topRight1);
					context.Graphics.DrawPath(mementoRibbonQATMinibar.lightPen, mementoRibbonQATMinibar.bottomLeft1);
					context.Graphics.FillPath(mementoRibbonQATMinibar.innerBrush, mementoRibbonQATMinibar.borderPath);
					context.Graphics.DrawPath(mementoRibbonQATMinibar.borderPen, mementoRibbonQATMinibar.borderPath);
				}
				else
				{
					context.Graphics.FillPath(_compositionBrush, mementoRibbonQATMinibar.borderPath);
					context.Graphics.DrawPath(_compositionPen, mementoRibbonQATMinibar.borderPath);
				}
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonLinear(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonLinear mementoRibbonLinear;
			if (memento == null || !(memento is MementoRibbonLinear))
			{
				memento?.Dispose();
				mementoRibbonLinear = new MementoRibbonLinear(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonLinear;
			}
			else
			{
				mementoRibbonLinear = (MementoRibbonLinear)memento;
				flag = !mementoRibbonLinear.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonLinear.Dispose();
				mementoRibbonLinear.linearBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), ribbonBackColor, ribbonBackColor2, 90f);
			}
			context.Graphics.FillRectangle(mementoRibbonLinear.linearBrush, rect);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonLinearBorder(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonLinearBorder mementoRibbonLinearBorder;
			if (memento == null || !(memento is MementoRibbonLinearBorder))
			{
				memento?.Dispose();
				mementoRibbonLinearBorder = new MementoRibbonLinearBorder(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonLinearBorder;
			}
			else
			{
				mementoRibbonLinearBorder = (MementoRibbonLinearBorder)memento;
				flag = !mementoRibbonLinearBorder.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonLinearBorder.Dispose();
				mementoRibbonLinearBorder.linearBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2), ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonLinearBorder.linearPen = new Pen(mementoRibbonLinearBorder.linearBrush);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
				graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left + 2, rect.Bottom - 1);
				graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Left, rect.Bottom - 3);
				graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left, rect.Top + 2);
				graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
				mementoRibbonLinearBorder.borderPath = graphicsPath;
			}
			context.Graphics.DrawPath(mementoRibbonLinearBorder.linearPen, mementoRibbonLinearBorder.borderPath);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonAppMenuInner(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonAppButtonInner mementoRibbonAppButtonInner;
			if (memento == null || !(memento is MementoRibbonAppButtonInner))
			{
				memento?.Dispose();
				mementoRibbonAppButtonInner = new MementoRibbonAppButtonInner(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonAppButtonInner;
			}
			else
			{
				mementoRibbonAppButtonInner = (MementoRibbonAppButtonInner)memento;
				flag = !mementoRibbonAppButtonInner.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonAppButtonInner.Dispose();
				mementoRibbonAppButtonInner.outsideBrush = new SolidBrush(ribbonBackColor);
				mementoRibbonAppButtonInner.insideBrush = new SolidBrush(ribbonBackColor2);
			}
			context.Graphics.FillRectangle(mementoRibbonAppButtonInner.outsideBrush, rect);
			rect.Inflate(-1, -1);
			context.Graphics.FillRectangle(mementoRibbonAppButtonInner.insideBrush, rect);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonAppMenuOuter(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			bool flag = true;
			MementoRibbonAppButtonOuter mementoRibbonAppButtonOuter;
			if (memento == null || !(memento is MementoRibbonAppButtonOuter))
			{
				memento?.Dispose();
				mementoRibbonAppButtonOuter = new MementoRibbonAppButtonOuter(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
				memento = mementoRibbonAppButtonOuter;
			}
			else
			{
				mementoRibbonAppButtonOuter = (MementoRibbonAppButtonOuter)memento;
				flag = !mementoRibbonAppButtonOuter.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
			}
			if (flag)
			{
				mementoRibbonAppButtonOuter.Dispose();
				mementoRibbonAppButtonOuter.wholeBrush = new SolidBrush(ribbonBackColor);
				mementoRibbonAppButtonOuter.backPath = new GraphicsPath();
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.X + 1, rect.Y, rect.Right - 1, rect.Y);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.Right - 1, rect.Y, rect.Right, rect.Y + 1);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.Right, rect.Y + 1, rect.Right, rect.Bottom - 2);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.Right, rect.Bottom - 2, rect.Right - 2, rect.Bottom);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.Right - 2, rect.Bottom, rect.X + 1, rect.Bottom);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.X + 2, rect.Bottom, rect.X, rect.Bottom - 2);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.X, rect.Bottom - 2, rect.X, rect.Y + 1);
				mementoRibbonAppButtonOuter.backPath.AddLine(rect.X, rect.Y + 1, rect.X + 1, rect.Y);
				mementoRibbonAppButtonOuter.bottomDarkGradient = new LinearGradientBrush(new Point(rect.X, rect.Bottom - 15), new Point(rect.X, rect.Bottom), ribbonBackColor2, ribbonBackColor3);
				mementoRibbonAppButtonOuter.topLightenGradient = new LinearGradientBrush(new Point(rect.X, rect.Y - 1), new Point(rect.X, rect.Y + 7), _whiten64, _whiten32);
			}
			context.Graphics.FillPath(mementoRibbonAppButtonOuter.wholeBrush, mementoRibbonAppButtonOuter.backPath);
			context.Graphics.FillRectangle(mementoRibbonAppButtonOuter.bottomDarkGradient, new Rectangle(rect.X, rect.Bottom - 14, rect.Width, 13));
			context.Graphics.FillRectangle(mementoRibbonAppButtonOuter.topLightenGradient, new Rectangle(rect.X, rect.Y, rect.Width, 6));
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonQATFullbarRound(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		rect.Y++;
		rect.Height--;
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			bool flag = true;
			MementoRibbonQATFullbarRound mementoRibbonQATFullbarRound;
			if (memento == null || !(memento is MementoRibbonQATFullbarRound))
			{
				memento?.Dispose();
				mementoRibbonQATFullbarRound = new MementoRibbonQATFullbarRound(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
				memento = mementoRibbonQATFullbarRound;
			}
			else
			{
				mementoRibbonQATFullbarRound = (MementoRibbonQATFullbarRound)memento;
				flag = !mementoRibbonQATFullbarRound.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
			}
			if (flag)
			{
				mementoRibbonQATFullbarRound.Dispose();
				mementoRibbonQATFullbarRound.innerRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
				mementoRibbonQATFullbarRound.innerBrush = new LinearGradientBrush(rect, ribbonBackColor, ribbonBackColor2, 90f);
				mementoRibbonQATFullbarRound.darkPen = new Pen(ribbonBackColor3);
				GraphicsPath graphicsPath = new GraphicsPath();
				GraphicsPath graphicsPath2 = new GraphicsPath();
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath.AddLine(rect.Left, (float)rect.Top + 0.75f, rect.Left + 1, rect.Top);
				graphicsPath.AddLine(rect.Left + 1, rect.Top, (float)rect.Right - 3.5f, rect.Top);
				graphicsPath.AddLine((float)rect.Right - 3.5f, rect.Top, rect.Right - 2, rect.Top + 2);
				graphicsPath.AddLine(rect.Right - 2, rect.Top + 2, rect.Right - 2, (float)rect.Bottom - 3.25f);
				graphicsPath.AddLine(rect.Right - 2, (float)rect.Bottom - 3.25f, (float)rect.Right - 3.25f, rect.Bottom - 2);
				graphicsPath.AddLine((float)rect.Right - 3.25f, rect.Bottom - 2, rect.Left, rect.Bottom - 2);
				graphicsPath2.AddLine(rect.Left, rect.Bottom - 3, rect.Left, (float)rect.Top + 2.5f);
				graphicsPath2.AddLine(rect.Left, (float)rect.Top + 2.5f, rect.Left + 1, rect.Top + 1);
				graphicsPath2.AddLine(rect.Left + 1, rect.Top + 1, rect.Right - 4, rect.Top + 1);
				graphicsPath3.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 2);
				graphicsPath3.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 1);
				graphicsPath3.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Left + 1, rect.Bottom - 1);
				mementoRibbonQATFullbarRound.darkPath = graphicsPath;
				mementoRibbonQATFullbarRound.lightPath1 = graphicsPath2;
				mementoRibbonQATFullbarRound.lightPath2 = graphicsPath3;
			}
			context.Graphics.FillRectangle(mementoRibbonQATFullbarRound.innerBrush, mementoRibbonQATFullbarRound.innerRect);
			using (new AntiAlias(context.Graphics))
			{
				context.Graphics.DrawPath(mementoRibbonQATFullbarRound.darkPen, mementoRibbonQATFullbarRound.darkPath);
				context.Graphics.DrawPath(_light1Pen, mementoRibbonQATFullbarRound.lightPath1);
				context.Graphics.DrawPath(_light2Pen, mementoRibbonQATFullbarRound.lightPath2);
			}
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonQATFullbarSquare(RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			Color ribbonBackColor3 = palette.GetRibbonBackColor3(state);
			bool flag = true;
			MementoRibbonQATFullbarSquare mementoRibbonQATFullbarSquare;
			if (memento == null || !(memento is MementoRibbonQATFullbarSquare))
			{
				memento?.Dispose();
				mementoRibbonQATFullbarSquare = new MementoRibbonQATFullbarSquare(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
				memento = mementoRibbonQATFullbarSquare;
			}
			else
			{
				mementoRibbonQATFullbarSquare = (MementoRibbonQATFullbarSquare)memento;
				flag = !mementoRibbonQATFullbarSquare.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2, ribbonBackColor3);
			}
			if (flag)
			{
				mementoRibbonQATFullbarSquare.Dispose();
				mementoRibbonQATFullbarSquare.lightPen = new Pen(ribbonBackColor);
				mementoRibbonQATFullbarSquare.mediumBrush = new SolidBrush(ribbonBackColor2);
				mementoRibbonQATFullbarSquare.darkPen = new Pen(ribbonBackColor3);
			}
			context.Graphics.FillRectangle(mementoRibbonQATFullbarSquare.mediumBrush, rect);
			context.Graphics.DrawRectangle(mementoRibbonQATFullbarSquare.darkPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
			context.Graphics.DrawLine(mementoRibbonQATFullbarSquare.lightPen, rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Y + 1);
			context.Graphics.DrawLine(mementoRibbonQATFullbarSquare.lightPen, rect.X + 1, rect.Bottom - 2, rect.Width - 2, rect.Bottom - 2);
		}
		return memento;
	}

	protected virtual IDisposable DrawRibbonQATOverflow(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonBackColor = palette.GetRibbonBackColor1(state);
			Color ribbonBackColor2 = palette.GetRibbonBackColor2(state);
			bool flag = true;
			MementoRibbonQATOverflow mementoRibbonQATOverflow;
			if (memento == null || !(memento is MementoRibbonQATOverflow))
			{
				memento?.Dispose();
				mementoRibbonQATOverflow = new MementoRibbonQATOverflow(rect, ribbonBackColor, ribbonBackColor2);
				memento = mementoRibbonQATOverflow;
			}
			else
			{
				mementoRibbonQATOverflow = (MementoRibbonQATOverflow)memento;
				flag = !mementoRibbonQATOverflow.UseCachedValues(rect, ribbonBackColor, ribbonBackColor2);
			}
			if (flag)
			{
				mementoRibbonQATOverflow.Dispose();
				mementoRibbonQATOverflow.backBrush = new SolidBrush(ribbonBackColor);
				mementoRibbonQATOverflow.borderPen = new Pen(ribbonBackColor2);
			}
			context.Graphics.FillRectangle(mementoRibbonQATOverflow.backBrush, rect);
			using (new AntiAlias(context.Graphics))
			{
				if (shape == PaletteRibbonShape.Office2010)
				{
					context.Graphics.DrawPolygon(mementoRibbonQATOverflow.borderPen, new Point[8]
					{
						new Point(rect.Left + 1, rect.Top),
						new Point(rect.Right - 2, rect.Top),
						new Point(rect.Right - 1, rect.Top + 1),
						new Point(rect.Right - 1, rect.Bottom - 2),
						new Point(rect.Right - 2, rect.Bottom - 1),
						new Point(rect.Left + 1, rect.Bottom - 1),
						new Point(rect.Left, rect.Bottom - 2),
						new Point(rect.Left, rect.Top + 1)
					});
				}
				else
				{
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Left + 1f, rect.Top, (float)rect.Right - 2f, rect.Top);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Right - 2f, rect.Top, (float)rect.Right - 1f, (float)rect.Top + 2f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Right - 1f, (float)rect.Top + 2f, (float)rect.Right - 1f, (float)rect.Bottom - 2f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Right - 1f, (float)rect.Bottom - 2f, (float)rect.Right - 2f, (float)rect.Bottom - 1f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Right - 2f, (float)rect.Bottom - 1f, (float)rect.Left + 1f, (float)rect.Bottom - 1f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, (float)rect.Left + 1f, (float)rect.Bottom - 1f, rect.Left, (float)rect.Bottom - 2f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, rect.Left, (float)rect.Bottom - 2f, rect.Left, (float)rect.Top + 1f);
					context.Graphics.DrawLine(mementoRibbonQATOverflow.borderPen, rect.Left, (float)rect.Top + 1f, (float)rect.Left + 1f, rect.Top);
				}
			}
		}
		return memento;
	}
}
