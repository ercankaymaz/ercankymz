using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class RenderGlassHelpers
{
	private static readonly Color _glassColorTopL;

	private static readonly Color _glassColorBottomL;

	private static readonly Color _glassColorTopD;

	private static readonly Color _glassColorBottomD;

	private static readonly Color _glassColorLight;

	private static readonly Color _glassColorTopDD;

	private static readonly Color _glassColorBottomDD;

	private static readonly Blend _glassFadeBlend;

	private static readonly float _fullGlassLength;

	private static readonly float _stumpyGlassLength;

	static RenderGlassHelpers()
	{
		_glassColorTopL = Color.FromArgb(208, Color.White);
		_glassColorBottomL = Color.FromArgb(96, Color.White);
		_glassColorTopD = Color.FromArgb(164, Color.White);
		_glassColorBottomD = Color.FromArgb(64, Color.White);
		_glassColorLight = Color.FromArgb(96, Color.White);
		_glassColorTopDD = Color.FromArgb(128, Color.White);
		_glassColorBottomDD = Color.FromArgb(48, Color.White);
		_fullGlassLength = 0.45f;
		_stumpyGlassLength = 0.19f;
		_glassFadeBlend = new Blend();
		_glassFadeBlend.Positions = new float[4] { 0f, 0.33f, 0.66f, 1f };
		_glassFadeBlend.Factors = new float[4] { 0f, 0f, 0.8f, 1f };
	}

	public static IDisposable DrawBackGlassCenter(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			mementoDouble.first = DrawBackLinearRadial(rect, sigma: false, ControlPaint.LightLight(backColor2), ControlPaint.Light(backColor2), ControlPaint.LightLight(backColor2), orientation, context.Graphics, mementoDouble.first);
			rect.Inflate(-1, -1);
			mementoDouble.second = DrawBackGlassCenter(rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, 2f, 1f, orientation, context.Graphics, _fullGlassLength, mementoDouble.second);
		}
		return memento;
	}

	public static IDisposable DrawBackGlassBottom(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			mementoDouble.first = DrawBackLinear(rect, sigma: false, ControlPaint.Light(backColor1), ControlPaint.LightLight(backColor1), orientation, context.Graphics, mementoDouble.first);
			ModifyRectByEdges(ref rect, 1, 0, 1, 1, orientation);
			mementoDouble.second = DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopD, _glassColorBottomD, 3f, 1.1f, orientation, context.Graphics, _fullGlassLength, mementoDouble.second);
		}
		return memento;
	}

	public static IDisposable DrawBackGlassFade(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			mementoDouble.first = DrawBackGlassFade(rect, rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, orientation, context.Graphics, mementoDouble.first);
			mementoDouble.second = DrawBackDarkEdge(rect, ControlPaint.Dark(backColor1), 3, orientation, context.Graphics, mementoDouble.second);
		}
		return memento;
	}

	public static IDisposable DrawBackGlassSimpleFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassSimplePercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassNormalFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassNormalPercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassTrackingFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassTrackingPercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassCheckedFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassCheckedPercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassCheckedTrackingFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassCheckedTrackingPercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassPressedFull(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassPressedPercent(context, rect, backColor1, backColor2, orientation, path, _fullGlassLength, memento);
	}

	public static IDisposable DrawBackGlassNormalStump(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassNormalPercent(context, rect, backColor1, backColor2, orientation, path, _stumpyGlassLength, memento);
	}

	public static IDisposable DrawBackGlassTrackingStump(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassTrackingPercent(context, rect, backColor1, backColor2, orientation, path, _stumpyGlassLength, memento);
	}

	public static IDisposable DrawBackGlassPressedStump(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassPressedPercent(context, rect, backColor1, backColor2, orientation, path, _stumpyGlassLength, memento);
	}

	public static IDisposable DrawBackGlassCheckedStump(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassCheckedPercent(context, rect, backColor1, backColor2, orientation, path, _stumpyGlassLength, memento);
	}

	public static IDisposable DrawBackGlassCheckedTrackingStump(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		return DrawBackGlassCheckedTrackingPercent(context, rect, backColor1, backColor2, orientation, path, _stumpyGlassLength, memento);
	}

	public static IDisposable DrawBackGlassThreeEdge(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			bool flag = true;
			MementoBackGlassThreeEdge mementoBackGlassThreeEdge;
			if (memento == null || !(memento is MementoBackGlassThreeEdge))
			{
				memento?.Dispose();
				mementoBackGlassThreeEdge = new MementoBackGlassThreeEdge(rect, backColor1, backColor2, orientation);
				memento = mementoBackGlassThreeEdge;
			}
			else
			{
				mementoBackGlassThreeEdge = (MementoBackGlassThreeEdge)memento;
				flag = !mementoBackGlassThreeEdge.UseCachedValues(rect, backColor1, backColor2, orientation);
			}
			if (flag)
			{
				mementoBackGlassThreeEdge.Dispose();
				mementoBackGlassThreeEdge.colorA1L = CommonHelper.MergeColors(backColor1, 0.7f, Color.White, 0.3f);
				mementoBackGlassThreeEdge.colorA2L = CommonHelper.MergeColors(backColor2, 0.7f, Color.White, 0.3f);
				mementoBackGlassThreeEdge.colorA2LL = CommonHelper.MergeColors(mementoBackGlassThreeEdge.colorA2L, 0.8f, Color.White, 0.2f);
				mementoBackGlassThreeEdge.colorB2LL = CommonHelper.MergeColors(backColor2, 0.8f, Color.White, 0.2f);
				mementoBackGlassThreeEdge.rectB = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 1, rect.Height - 2);
			}
			mementoBackGlassThreeEdge.first = DrawBackGlassLinear(rect, rect, mementoBackGlassThreeEdge.colorA1L, _glassColorLight, mementoBackGlassThreeEdge.colorA2L, mementoBackGlassThreeEdge.colorA2LL, orientation, context.Graphics, _fullGlassLength, mementoBackGlassThreeEdge.first);
			mementoBackGlassThreeEdge.second = DrawBackGlassLinear(mementoBackGlassThreeEdge.rectB, mementoBackGlassThreeEdge.rectB, backColor1, _glassColorLight, backColor2, mementoBackGlassThreeEdge.colorB2LL, orientation, context.Graphics, _fullGlassLength, mementoBackGlassThreeEdge.second);
			return mementoBackGlassThreeEdge;
		}
	}

	public static IDisposable DrawBackGlassNormalSimple(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackGlassLinear(rect, rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, orientation, context.Graphics, _fullGlassLength, memento);
		}
	}

	public static IDisposable DrawBackGlassTrackingSimple(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, 2f, 1f, orientation, context.Graphics, _fullGlassLength, memento);
		}
	}

	public static IDisposable DrawBackGlassCheckedSimple(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, 6f, 1.2f, orientation, context.Graphics, _fullGlassLength, memento);
		}
	}

	public static IDisposable DrawBackGlassCheckedTrackingSimple(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopD, _glassColorBottomD, 5f, 1.2f, orientation, context.Graphics, _fullGlassLength, memento);
		}
	}

	public static IDisposable DrawBackGlassPressedSimple(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopD, _glassColorBottomD, 3f, 1.1f, orientation, context.Graphics, _fullGlassLength, memento);
		}
	}

	private static IDisposable DrawBackGlassSimplePercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
			mementoDouble.first = DrawBackGlassLinear(rectangleF, rectangleF, backColor2, backColor2, _glassColorBottomDD, _glassColorBottomDD, orientation, context.Graphics, 0f, mementoDouble.first);
			RectangleF drawRect = rectangleF;
			drawRect.Inflate(-1f, -1f);
			mementoDouble.second = DrawBackGlassLinear(drawRect, rectangleF, backColor1, CommonHelper.MergeColors(backColor1, 0.5f, backColor2, 0.5f), _glassColorTopDD, _glassColorBottomDD, orientation, context.Graphics, glassPercent, mementoDouble.second);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassNormalPercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
			mementoDouble.first = DrawBackGlassLinear(rectangleF, rectangleF, Color.White, Color.White, _glassColorTopL, _glassColorBottomL, orientation, context.Graphics, glassPercent, mementoDouble.first);
			RectangleF drawRect = rectangleF;
			drawRect.Inflate(-1f, -1f);
			mementoDouble.second = DrawBackGlassLinear(drawRect, rectangleF, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, orientation, context.Graphics, glassPercent, mementoDouble.second);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassTrackingPercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			mementoDouble.first = DrawBackLinearRadial(rect, sigma: false, ControlPaint.LightLight(backColor2), ControlPaint.Light(backColor2), ControlPaint.LightLight(backColor2), orientation, context.Graphics, mementoDouble.first);
			rect.Inflate(-1, -1);
			mementoDouble.second = DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, 2f, 1f, orientation, context.Graphics, glassPercent, mementoDouble.second);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassPressedPercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoTriple mementoTriple;
			if (memento == null || !(memento is MementoTriple))
			{
				memento?.Dispose();
				mementoTriple = new MementoTriple();
				memento = mementoTriple;
			}
			else
			{
				mementoTriple = (MementoTriple)memento;
			}
			mementoTriple.first = DrawBackLinear(rect, sigma: false, ControlPaint.Light(backColor1), ControlPaint.LightLight(backColor1), orientation, context.Graphics, mementoTriple.first);
			ModifyRectByEdges(ref rect, 1, 0, 1, 1, orientation);
			mementoTriple.second = DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopD, _glassColorBottomD, 3f, 1.1f, orientation, context.Graphics, glassPercent, mementoTriple.second);
			ModifyRectByEdges(ref rect, -1, 0, -1, 0, orientation);
			mementoTriple.third = DrawBackDarkEdge(rect, ControlPaint.Dark(backColor1), 3, orientation, context.Graphics, mementoTriple.third);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassCheckedPercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoTriple mementoTriple;
			if (memento == null || !(memento is MementoTriple))
			{
				memento?.Dispose();
				mementoTriple = new MementoTriple();
				memento = mementoTriple;
			}
			else
			{
				mementoTriple = (MementoTriple)memento;
			}
			mementoTriple.first = DrawBackLinearRadial(rect, sigma: false, ControlPaint.Light(backColor1), ControlPaint.LightLight(backColor1), ControlPaint.LightLight(backColor1), orientation, context.Graphics, mementoTriple.first);
			ModifyRectByEdges(ref rect, 1, 0, 1, 1, orientation);
			mementoTriple.second = DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopL, _glassColorBottomL, 6f, 1.2f, orientation, context.Graphics, glassPercent, mementoTriple.second);
			ModifyRectByEdges(ref rect, -1, 0, -1, 0, orientation);
			mementoTriple.third = DrawBackDarkEdge(rect, ControlPaint.Dark(backColor1), 3, orientation, context.Graphics, mementoTriple.third);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassCheckedTrackingPercent(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, float glassPercent, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			MementoTriple mementoTriple;
			if (memento == null || !(memento is MementoTriple))
			{
				memento?.Dispose();
				mementoTriple = new MementoTriple();
				memento = mementoTriple;
			}
			else
			{
				mementoTriple = (MementoTriple)memento;
			}
			mementoTriple.first = DrawBackLinear(rect, sigma: true, backColor2, ControlPaint.LightLight(backColor2), orientation, context.Graphics, mementoTriple.first);
			ModifyRectByEdges(ref rect, 1, 0, 1, 1, orientation);
			mementoTriple.second = DrawBackGlassRadial(rect, backColor1, backColor2, _glassColorTopD, _glassColorBottomD, 5f, 1.2f, orientation, context.Graphics, glassPercent, mementoTriple.second);
			ModifyRectByEdges(ref rect, -1, 0, -1, 0, orientation);
			mementoTriple.third = DrawBackDarkEdge(rect, ControlPaint.Dark(backColor1), 3, orientation, context.Graphics, mementoTriple.third);
		}
		return memento;
	}

	private static IDisposable DrawBackLinearRadial(RectangleF drawRect, bool sigma, Color color1, Color color2, Color color3, VisualOrientation orientation, Graphics g, IDisposable memento)
	{
		MementoDouble mementoDouble;
		if (memento == null || !(memento is MementoDouble))
		{
			memento?.Dispose();
			mementoDouble = new MementoDouble();
			memento = mementoDouble;
		}
		else
		{
			mementoDouble = (MementoDouble)memento;
		}
		mementoDouble.first = DrawBackLinear(drawRect, sigma, color1, color2, orientation, g, mementoDouble.first);
		bool flag = true;
		MementoBackLinearRadial mementoBackLinearRadial;
		if (mementoDouble.second == null || !(mementoDouble.second is MementoBackLinearRadial))
		{
			if (mementoDouble.second != null)
			{
				mementoDouble.second.Dispose();
			}
			mementoBackLinearRadial = (MementoBackLinearRadial)(mementoDouble.second = new MementoBackLinearRadial(drawRect, color2, color3, orientation));
		}
		else
		{
			mementoBackLinearRadial = (MementoBackLinearRadial)mementoDouble.second;
			flag = !mementoBackLinearRadial.UseCachedValues(drawRect, color2, color3, orientation);
		}
		if (flag)
		{
			mementoBackLinearRadial.Dispose();
			float num = ((!VerticalOrientation(orientation)) ? (drawRect.Width / 3f) : (drawRect.Height / 3f));
			RectangleF rectangleF;
			PointF centerPoint;
			switch (orientation)
			{
			case VisualOrientation.Left:
				rectangleF = new RectangleF(drawRect.Right - num, drawRect.Y + 1f, num, drawRect.Height - 2f);
				centerPoint = new PointF(rectangleF.Right, rectangleF.Y + rectangleF.Height / 2f);
				break;
			case VisualOrientation.Right:
				rectangleF = new RectangleF(drawRect.X - 1f, drawRect.Y + 1f, num, drawRect.Height - 2f);
				centerPoint = new PointF(rectangleF.Left, rectangleF.Y + rectangleF.Height / 2f);
				break;
			case VisualOrientation.Bottom:
				rectangleF = new RectangleF(drawRect.X + 1f, drawRect.Y - 1f, drawRect.Width - 2f, num);
				centerPoint = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Top);
				break;
			default:
				rectangleF = new RectangleF(drawRect.X + 1f, drawRect.Bottom - num, drawRect.Width - 2f, num);
				centerPoint = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Bottom);
				break;
			}
			mementoBackLinearRadial.ellipseRect = rectangleF;
			if (rectangleF.Width > 0f && rectangleF.Height > 0f)
			{
				mementoBackLinearRadial.path = new GraphicsPath();
				mementoBackLinearRadial.path.AddEllipse(rectangleF);
				mementoBackLinearRadial.bottomBrush = new PathGradientBrush(mementoBackLinearRadial.path);
				mementoBackLinearRadial.bottomBrush.CenterColor = ControlPaint.Light(color3);
				mementoBackLinearRadial.bottomBrush.CenterPoint = centerPoint;
				mementoBackLinearRadial.bottomBrush.SurroundColors = new Color[1] { color2 };
			}
		}
		if (mementoBackLinearRadial.bottomBrush != null)
		{
			g.FillRectangle(mementoBackLinearRadial.bottomBrush, mementoBackLinearRadial.ellipseRect);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassRadial(RectangleF drawRect, Color color1, Color color2, Color glassColor1, Color glassColor2, float factorX, float factorY, VisualOrientation orientation, Graphics g, float glassPercent, IDisposable memento)
	{
		MementoDouble mementoDouble;
		if (memento == null || !(memento is MementoDouble))
		{
			memento?.Dispose();
			mementoDouble = new MementoDouble();
			memento = mementoDouble;
		}
		else
		{
			mementoDouble = (MementoDouble)memento;
		}
		RectangleF rectangleF = DrawBackGlassBasic(drawRect, color1, color2, glassColor1, glassColor2, factorX, factorY, orientation, g, glassPercent, ref mementoDouble.first);
		bool flag = true;
		MementoBackGlassRadial mementoBackGlassRadial;
		if (mementoDouble.second == null || !(mementoDouble.second is MementoBackGlassRadial))
		{
			if (mementoDouble.second != null)
			{
				mementoDouble.second.Dispose();
			}
			mementoBackGlassRadial = (MementoBackGlassRadial)(mementoDouble.second = new MementoBackGlassRadial(drawRect, color1, color2, factorX, factorY, orientation));
		}
		else
		{
			mementoBackGlassRadial = (MementoBackGlassRadial)mementoDouble.second;
			flag = !mementoBackGlassRadial.UseCachedValues(drawRect, color1, color2, factorX, factorY, orientation);
		}
		if (flag)
		{
			mementoBackGlassRadial.Dispose();
			RectangleF mainRect = orientation switch
			{
				VisualOrientation.Right => new RectangleF(drawRect.X, drawRect.Y, drawRect.Width - rectangleF.Width - 1f, drawRect.Height), 
				VisualOrientation.Left => new RectangleF(rectangleF.Right + 1f, drawRect.Y, drawRect.Width - rectangleF.Width - 1f, drawRect.Height), 
				VisualOrientation.Bottom => new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height - rectangleF.Height - 1f), 
				_ => new RectangleF(drawRect.X, rectangleF.Bottom + 1f, drawRect.Width, drawRect.Height - rectangleF.Height - 1f), 
			};
			RectangleF rect;
			if (VerticalOrientation(orientation))
			{
				float num = mainRect.Width * factorX;
				float num2 = (num - mainRect.Width) / 2f;
				float num3 = mainRect.Height * factorY;
				float num4 = ((orientation != VisualOrientation.Top) ? (num3 + (num3 - mainRect.Height) / 2f) : ((num3 - mainRect.Height) / 2f));
				rect = new RectangleF(mainRect.X - num2, mainRect.Y - num4, num, num3 * 2f);
			}
			else
			{
				float num5 = mainRect.Height * factorX;
				float num6 = (num5 - mainRect.Height) / 2f;
				float num7 = mainRect.Width * factorY;
				float num8 = ((orientation != VisualOrientation.Left) ? (num7 + (num7 - mainRect.Width) / 2f) : ((num7 - mainRect.Width) / 2f));
				rect = new RectangleF(mainRect.X - num8, mainRect.Y - num6, num7 * 2f, num5);
			}
			if (rect.Width > 0f && rect.Height > 0f)
			{
				mementoBackGlassRadial.path = new GraphicsPath();
				mementoBackGlassRadial.path.AddEllipse(rect);
				mementoBackGlassRadial.bottomBrush = new PathGradientBrush(mementoBackGlassRadial.path);
				mementoBackGlassRadial.bottomBrush.CenterColor = color2;
				mementoBackGlassRadial.bottomBrush.CenterPoint = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
				mementoBackGlassRadial.bottomBrush.SurroundColors = new Color[1] { color1 };
				mementoBackGlassRadial.mainRect = mainRect;
			}
		}
		if (mementoBackGlassRadial.bottomBrush != null)
		{
			g.FillRectangle(mementoBackGlassRadial.bottomBrush, mementoBackGlassRadial.mainRect);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassCenter(RectangleF drawRect, Color color1, Color color2, Color glassColor1, Color glassColor2, float factorX, float factorY, VisualOrientation orientation, Graphics g, float glassPercent, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f)
		{
			MementoDouble mementoDouble;
			if (memento == null || !(memento is MementoDouble))
			{
				memento?.Dispose();
				mementoDouble = new MementoDouble();
				memento = mementoDouble;
			}
			else
			{
				mementoDouble = (MementoDouble)memento;
			}
			DrawBackGlassBasic(drawRect, color1, color2, glassColor1, glassColor2, factorX, factorY, orientation, g, glassPercent, ref mementoDouble.first);
			bool flag = true;
			MementoBackGlassCenter mementoBackGlassCenter;
			if (mementoDouble.second == null || !(mementoDouble.second is MementoBackGlassCenter))
			{
				if (mementoDouble.second != null)
				{
					mementoDouble.second.Dispose();
				}
				mementoBackGlassCenter = (MementoBackGlassCenter)(mementoDouble.second = new MementoBackGlassCenter(drawRect, color2));
			}
			else
			{
				mementoBackGlassCenter = (MementoBackGlassCenter)mementoDouble.second;
				flag = !mementoBackGlassCenter.UseCachedValues(drawRect, color2);
			}
			if (flag)
			{
				mementoBackGlassCenter.Dispose();
				mementoBackGlassCenter.path = new GraphicsPath();
				mementoBackGlassCenter.path.AddEllipse(drawRect);
				mementoBackGlassCenter.bottomBrush = new PathGradientBrush(mementoBackGlassCenter.path);
				mementoBackGlassCenter.bottomBrush.CenterColor = color2;
				mementoBackGlassCenter.bottomBrush.CenterPoint = new PointF(drawRect.X + drawRect.Width / 2f, drawRect.Y + drawRect.Height / 2f);
				mementoBackGlassCenter.bottomBrush.SurroundColors = new Color[1] { Color.Transparent };
			}
			g.FillRectangle(mementoBackGlassCenter.bottomBrush, drawRect);
		}
		return memento;
	}

	private static IDisposable DrawBackGlassFade(RectangleF drawRect, RectangleF outerRect, Color color1, Color color2, Color glassColor1, Color glassColor2, VisualOrientation orientation, Graphics g, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f && outerRect.Width > 0f && outerRect.Height > 0f)
		{
			bool flag = true;
			MementoBackGlassFade mementoBackGlassFade;
			if (memento == null || !(memento is MementoBackGlassFade))
			{
				memento?.Dispose();
				mementoBackGlassFade = new MementoBackGlassFade(drawRect, outerRect, color1, color2, glassColor1, glassColor2, orientation);
				memento = mementoBackGlassFade;
			}
			else
			{
				mementoBackGlassFade = (MementoBackGlassFade)memento;
				flag = !mementoBackGlassFade.UseCachedValues(drawRect, outerRect, color1, color2, glassColor1, glassColor2, orientation);
			}
			if (flag)
			{
				mementoBackGlassFade.Dispose();
				RectangleF rect = new RectangleF(drawRect.X - 1f, drawRect.Y - 1f, drawRect.Width + 2f, drawRect.Height + 2f);
				if (rect.Width > 0f && rect.Height > 0f)
				{
					mementoBackGlassFade.mainBrush = new LinearGradientBrush(rect, color1, color2, AngleFromOrientation(orientation));
					mementoBackGlassFade.mainBrush.Blend = _glassFadeBlend;
				}
				float num = ((!VerticalOrientation(orientation)) ? ((float)(int)(outerRect.Width * 0.33f) + outerRect.X - drawRect.X) : ((float)(int)(outerRect.Height * 0.33f) + outerRect.Y - drawRect.Y));
				RectangleF glassRect;
				switch (orientation)
				{
				case VisualOrientation.Left:
					glassRect = new RectangleF(drawRect.X, drawRect.Y, num, drawRect.Height);
					break;
				case VisualOrientation.Right:
					glassRect = new RectangleF(new RectangleF(drawRect.X, drawRect.Y, drawRect.Width - num, drawRect.Height).Right, drawRect.Y, num, drawRect.Height);
					break;
				default:
					glassRect = new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, num);
					break;
				case VisualOrientation.Bottom:
				{
					RectangleF rectangleF = new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height - num);
					glassRect = new RectangleF(drawRect.X, rectangleF.Bottom, drawRect.Width, num);
					break;
				}
				}
				RectangleF rect2 = new RectangleF(glassRect.X - 1f, glassRect.Y - 1f, glassRect.Width + 2f, glassRect.Height + 2f);
				if (glassRect.Width > 0f && glassRect.Height > 0f && rect2.Width > 0f && rect2.Height > 0f)
				{
					mementoBackGlassFade.topBrush = new LinearGradientBrush(rect2, glassColor1, glassColor2, AngleFromOrientation(orientation));
					mementoBackGlassFade.glassRect = glassRect;
				}
			}
			if (mementoBackGlassFade.mainBrush != null)
			{
				g.FillRectangle(mementoBackGlassFade.mainBrush, drawRect);
			}
			if (mementoBackGlassFade.topBrush != null)
			{
				g.FillRectangle(mementoBackGlassFade.topBrush, mementoBackGlassFade.glassRect);
			}
		}
		return memento;
	}

	private static IDisposable DrawBackGlassLinear(RectangleF drawRect, RectangleF outerRect, Color color1, Color color2, Color glassColor1, Color glassColor2, VisualOrientation orientation, Graphics g, float glassPercent, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f && outerRect.Width > 0f && outerRect.Height > 0f)
		{
			bool flag = true;
			MementoBackGlassLinear mementoBackGlassLinear;
			if (memento == null || !(memento is MementoBackGlassLinear))
			{
				memento?.Dispose();
				mementoBackGlassLinear = new MementoBackGlassLinear(drawRect, outerRect, color1, color2, glassColor1, glassColor2, orientation, glassPercent);
				memento = mementoBackGlassLinear;
			}
			else
			{
				mementoBackGlassLinear = (MementoBackGlassLinear)memento;
				flag = !mementoBackGlassLinear.UseCachedValues(drawRect, outerRect, color1, color2, glassColor1, glassColor2, orientation, glassPercent);
			}
			if (flag)
			{
				mementoBackGlassLinear.Dispose();
				float num = ((!VerticalOrientation(orientation)) ? ((float)(int)(outerRect.Width * glassPercent) + outerRect.X - drawRect.X) : ((float)(int)(outerRect.Height * glassPercent) + outerRect.Y - drawRect.Y));
				RectangleF glassRect;
				RectangleF mainRect;
				switch (orientation)
				{
				case VisualOrientation.Left:
					glassRect = new RectangleF(drawRect.X, drawRect.Y, num, drawRect.Height);
					mainRect = new RectangleF(glassRect.Right + 1f, drawRect.Y, drawRect.Width - glassRect.Width - 1f, drawRect.Height);
					break;
				case VisualOrientation.Right:
					mainRect = new RectangleF(drawRect.X, drawRect.Y, drawRect.Width - num, drawRect.Height);
					glassRect = new RectangleF(mainRect.Right, drawRect.Y, num, drawRect.Height);
					break;
				default:
					glassRect = new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, num);
					mainRect = new RectangleF(drawRect.X, glassRect.Bottom + 1f, drawRect.Width, drawRect.Height - glassRect.Height - 1f);
					break;
				case VisualOrientation.Bottom:
					mainRect = new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height - num);
					glassRect = new RectangleF(drawRect.X, mainRect.Bottom, drawRect.Width, num);
					break;
				}
				mementoBackGlassLinear.totalBrush = new SolidBrush(color1);
				mementoBackGlassLinear.glassRect = glassRect;
				mementoBackGlassLinear.mainRect = mainRect;
				RectangleF rect = new RectangleF(mementoBackGlassLinear.glassRect.X - 1f, mementoBackGlassLinear.glassRect.Y - 1f, mementoBackGlassLinear.glassRect.Width + 2f, mementoBackGlassLinear.glassRect.Height + 2f);
				RectangleF rect2 = new RectangleF(mementoBackGlassLinear.mainRect.X - 1f, mementoBackGlassLinear.mainRect.Y - 1f, mementoBackGlassLinear.mainRect.Width + 2f, mementoBackGlassLinear.mainRect.Height + 2f);
				if (mementoBackGlassLinear.glassRect.Width > 0f && mementoBackGlassLinear.glassRect.Height > 0f && mementoBackGlassLinear.mainRect.Width > 0f && mementoBackGlassLinear.mainRect.Height > 0f && rect.Width > 0f && rect.Height > 0f && rect2.Width > 0f && rect2.Height > 0f)
				{
					mementoBackGlassLinear.topBrush = new LinearGradientBrush(rect, glassColor1, glassColor2, AngleFromOrientation(orientation));
					mementoBackGlassLinear.bottomBrush = new LinearGradientBrush(rect2, color1, color2, AngleFromOrientation(orientation));
				}
			}
			g.FillRectangle(mementoBackGlassLinear.totalBrush, drawRect);
			if (mementoBackGlassLinear.topBrush != null && mementoBackGlassLinear.bottomBrush != null)
			{
				g.FillRectangle(mementoBackGlassLinear.topBrush, mementoBackGlassLinear.glassRect);
				g.FillRectangle(mementoBackGlassLinear.bottomBrush, mementoBackGlassLinear.mainRect);
			}
		}
		return memento;
	}

	private static RectangleF DrawBackGlassBasic(RectangleF drawRect, Color color1, Color color2, Color glassColor1, Color glassColor2, float factorX, float factorY, VisualOrientation orientation, Graphics g, float glassPercent, ref IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f)
		{
			bool flag = true;
			MementoBackGlassBasic mementoBackGlassBasic;
			if (memento == null || !(memento is MementoBackGlassBasic))
			{
				if (memento != null)
				{
					memento.Dispose();
				}
				mementoBackGlassBasic = (MementoBackGlassBasic)(memento = new MementoBackGlassBasic(drawRect, color1, color2, glassColor1, glassColor2, factorX, factorY, orientation, glassPercent));
			}
			else
			{
				mementoBackGlassBasic = (MementoBackGlassBasic)memento;
				flag = !mementoBackGlassBasic.UseCachedValues(drawRect, color1, color2, glassColor1, glassColor2, factorX, factorY, orientation, glassPercent);
			}
			if (flag)
			{
				mementoBackGlassBasic.Dispose();
				mementoBackGlassBasic.totalBrush = new SolidBrush(color1);
				int num = ((!VerticalOrientation(orientation)) ? ((int)(drawRect.Width * glassPercent)) : ((int)(drawRect.Height * glassPercent)));
				RectangleF glassRect = orientation switch
				{
					VisualOrientation.Left => new RectangleF(drawRect.X, drawRect.Y, num, drawRect.Height), 
					VisualOrientation.Right => new RectangleF(drawRect.Right - (float)num, drawRect.Y, num, drawRect.Height), 
					VisualOrientation.Bottom => new RectangleF(drawRect.X, drawRect.Bottom - (float)num, drawRect.Width, num), 
					_ => new RectangleF(drawRect.X, drawRect.Y, drawRect.Width, num), 
				};
				RectangleF rect = new RectangleF(glassRect.X - 1f, glassRect.Y - 1f, glassRect.Width + 2f, glassRect.Height + 2f);
				if (rect.Width > 0f && rect.Height > 0f)
				{
					mementoBackGlassBasic.glassBrush = new LinearGradientBrush(rect, glassColor1, glassColor2, AngleFromOrientation(orientation));
					mementoBackGlassBasic.glassRect = glassRect;
				}
			}
			g.FillRectangle(mementoBackGlassBasic.totalBrush, drawRect);
			if (mementoBackGlassBasic.glassBrush != null)
			{
				g.FillRectangle(mementoBackGlassBasic.glassBrush, mementoBackGlassBasic.glassRect);
				return mementoBackGlassBasic.glassRect;
			}
		}
		return RectangleF.Empty;
	}

	private static IDisposable DrawBackLinear(RectangleF drawRect, bool sigma, Color color1, Color color2, VisualOrientation orientation, Graphics g, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f)
		{
			bool flag = true;
			MementoBackLinear mementoBackLinear;
			if (memento == null || !(memento is MementoBackLinear))
			{
				memento?.Dispose();
				mementoBackLinear = new MementoBackLinear(drawRect, sigma, color1, color2, orientation);
				memento = mementoBackLinear;
			}
			else
			{
				mementoBackLinear = (MementoBackLinear)memento;
				flag = !mementoBackLinear.UseCachedValues(drawRect, sigma, color1, color2, orientation);
			}
			if (flag)
			{
				mementoBackLinear.Dispose();
				RectangleF rect = new RectangleF(drawRect.X - 1f, drawRect.Y - 1f, drawRect.Width + 2f, drawRect.Height + 2f);
				if (rect.Width > 0f && rect.Height > 0f)
				{
					mementoBackLinear.entireBrush = new LinearGradientBrush(rect, color1, color2, AngleFromOrientation(orientation));
					if (sigma)
					{
						mementoBackLinear.entireBrush.SetSigmaBellShape(0.5f);
					}
				}
			}
			if (mementoBackLinear.entireBrush != null)
			{
				g.FillRectangle(mementoBackLinear.entireBrush, drawRect);
			}
		}
		return memento;
	}

	private static IDisposable DrawBackDarkEdge(RectangleF drawRect, Color color1, int thickness, VisualOrientation orientation, Graphics g, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f)
		{
			bool flag = true;
			MementoBackDarkEdge mementoBackDarkEdge;
			if (memento == null || !(memento is MementoBackDarkEdge))
			{
				memento?.Dispose();
				mementoBackDarkEdge = new MementoBackDarkEdge(drawRect, color1, thickness, orientation);
				memento = mementoBackDarkEdge;
			}
			else
			{
				mementoBackDarkEdge = (MementoBackDarkEdge)memento;
				flag = !mementoBackDarkEdge.UseCachedValues(drawRect, color1, thickness, orientation);
			}
			if (flag)
			{
				mementoBackDarkEdge.Dispose();
				if (VerticalOrientation(orientation))
				{
					if (drawRect.Height < 30f)
					{
						thickness = (int)drawRect.Height / 10;
					}
				}
				else if (drawRect.Width < 30f)
				{
					thickness = (int)drawRect.Width / 10;
				}
				if (thickness >= 0)
				{
					switch (orientation)
					{
					case VisualOrientation.Top:
						drawRect.Height = thickness;
						break;
					case VisualOrientation.Left:
						drawRect.Width = thickness;
						break;
					case VisualOrientation.Bottom:
						drawRect.Y = drawRect.Bottom - (float)thickness - 1f;
						drawRect.Height = thickness + 1;
						break;
					case VisualOrientation.Right:
						drawRect.X = drawRect.Right - (float)thickness - 1f;
						drawRect.Width = thickness + 1;
						break;
					}
					RectangleF rect = new RectangleF(drawRect.X - 0.5f, drawRect.Y - 0.5f, drawRect.Width + 1f, drawRect.Height + 1f);
					if (rect.Width > 0f && rect.Height > 0f)
					{
						mementoBackDarkEdge.entireBrush = new LinearGradientBrush(rect, Color.FromArgb(64, color1), Color.Transparent, AngleFromOrientation(orientation));
						mementoBackDarkEdge.entireBrush.SetSigmaBellShape(1f);
						mementoBackDarkEdge.entireRect = drawRect;
					}
				}
			}
			if (mementoBackDarkEdge.entireBrush != null)
			{
				g.FillRectangle(mementoBackDarkEdge.entireBrush, mementoBackDarkEdge.entireRect);
			}
		}
		return memento;
	}

	private static bool VerticalOrientation(VisualOrientation orientation)
	{
		return orientation == VisualOrientation.Top || orientation == VisualOrientation.Bottom;
	}

	private static float AngleFromOrientation(VisualOrientation orientation)
	{
		return orientation switch
		{
			VisualOrientation.Bottom => 270f, 
			VisualOrientation.Left => 0f, 
			VisualOrientation.Right => 180f, 
			_ => 90f, 
		};
	}

	private static void ModifyRectByEdges(ref Rectangle rect, int left, int top, int right, int bottom, VisualOrientation orientation)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
			rect.X += left;
			rect.Width -= left + right;
			rect.Y += top;
			rect.Height -= top + bottom;
			break;
		case VisualOrientation.Bottom:
			rect.X += left;
			rect.Width -= left + right;
			rect.Y += bottom;
			rect.Height -= top + bottom;
			break;
		case VisualOrientation.Left:
			rect.X += top;
			rect.Width -= top + bottom;
			rect.Y += right;
			rect.Height -= left + right;
			break;
		case VisualOrientation.Right:
			rect.X += bottom;
			rect.Width -= top + bottom;
			rect.Y += left;
			rect.Height -= left + right;
			break;
		}
	}
}
