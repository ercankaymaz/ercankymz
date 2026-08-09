using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

internal class RenderExpertHelpers
{
	private static readonly Blend _rounded1Blend;

	private static readonly Blend _rounded2Blend;

	private static readonly float _itemCut;

	static RenderExpertHelpers()
	{
		_itemCut = 1.7f;
		_rounded1Blend = new Blend();
		_rounded1Blend.Positions = new float[3] { 0f, 0.1f, 1f };
		_rounded1Blend.Factors = new float[3] { 0f, 1f, 1f };
		_rounded2Blend = new Blend();
		_rounded2Blend.Positions = new float[4] { 0f, 0.5f, 0.75f, 1f };
		_rounded2Blend.Factors = new float[4] { 0f, 1f, 1f, 1f };
	}

	public static IDisposable DrawBackExpertTracking(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
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
			mementoDouble.first = DrawBackExpert(rect, CommonHelper.MergeColors(backColor1, 0.35f, Color.White, 0.65f), CommonHelper.MergeColors(backColor2, 0.53f, Color.White, 0.65f), orientation, context.Graphics, memento, total: true, tracking: true);
			mementoDouble.second = DrawBackExpert(rect, backColor1, backColor2, orientation, context.Graphics, memento, total: false, tracking: true);
			return mementoDouble;
		}
	}

	public static IDisposable DrawBackExpertPressed(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				bool flag = true;
				MementoBackExpertShadow mementoBackExpertShadow;
				if (memento == null || !(memento is MementoBackExpertShadow))
				{
					memento?.Dispose();
					mementoBackExpertShadow = new MementoBackExpertShadow(rect, backColor1, backColor2);
					memento = mementoBackExpertShadow;
				}
				else
				{
					mementoBackExpertShadow = (MementoBackExpertShadow)memento;
					flag = !mementoBackExpertShadow.UseCachedValues(rect, backColor1, backColor2);
				}
				if (flag)
				{
					rect.X--;
					rect.Y--;
					rect.Width += 2;
					rect.Height += 2;
					mementoBackExpertShadow.Dispose();
					mementoBackExpertShadow.path1 = CreateBorderPath(rect, _itemCut);
					mementoBackExpertShadow.path2 = CreateBorderPath(new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2), _itemCut);
					mementoBackExpertShadow.path3 = CreateBorderPath(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4), _itemCut);
					mementoBackExpertShadow.brush1 = new SolidBrush(CommonHelper.MergeColors(backColor2, 0.4f, backColor1, 0.6f));
					mementoBackExpertShadow.brush2 = new SolidBrush(CommonHelper.MergeColors(backColor2, 0.2f, backColor1, 0.8f));
					mementoBackExpertShadow.brush3 = new SolidBrush(backColor1);
				}
				using (new AntiAlias(context.Graphics))
				{
					context.Graphics.FillRectangle(mementoBackExpertShadow.brush3, rect);
					context.Graphics.FillPath(mementoBackExpertShadow.brush1, mementoBackExpertShadow.path1);
					context.Graphics.FillPath(mementoBackExpertShadow.brush2, mementoBackExpertShadow.path2);
					context.Graphics.FillPath(mementoBackExpertShadow.brush3, mementoBackExpertShadow.path3);
				}
			}
			return memento;
		}
	}

	public static IDisposable DrawBackExpertChecked(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
	{
		using (new Clipping(context.Graphics, path))
		{
			return DrawBackExpert(rect, backColor1, backColor2, orientation, context.Graphics, memento, total: true, tracking: false);
		}
	}

	public static IDisposable DrawBackExpertCheckedTracking(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento)
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
			mementoDouble.first = DrawBackExpert(rect, CommonHelper.MergeColors(backColor1, 0.5f, Color.White, 0.5f), CommonHelper.MergeColors(backColor2, 0.5f, Color.White, 0.5f), orientation, context.Graphics, memento, total: true, tracking: false);
			mementoDouble.second = DrawBackExpert(rect, backColor1, backColor2, orientation, context.Graphics, memento, total: false, tracking: false);
			return mementoDouble;
		}
	}

	public static IDisposable DrawBackExpertSquareHighlight(RenderContext context, Rectangle rect, Color backColor1, Color backColor2, VisualOrientation orientation, GraphicsPath path, IDisposable memento, bool light)
	{
		using (new Clipping(context.Graphics, path))
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				bool flag = true;
				MementoBackExpertSquareHighlight mementoBackExpertSquareHighlight;
				if (memento == null || !(memento is MementoBackExpertSquareHighlight))
				{
					memento?.Dispose();
					mementoBackExpertSquareHighlight = new MementoBackExpertSquareHighlight(rect, backColor1, backColor2, orientation);
					memento = mementoBackExpertSquareHighlight;
				}
				else
				{
					mementoBackExpertSquareHighlight = (MementoBackExpertSquareHighlight)memento;
					flag = !mementoBackExpertSquareHighlight.UseCachedValues(rect, backColor1, backColor2, orientation);
				}
				if (flag)
				{
					mementoBackExpertSquareHighlight.Dispose();
					mementoBackExpertSquareHighlight.backBrush = new SolidBrush(CommonHelper.WhitenColor(backColor1, 0.8f, 0.8f, 0.8f));
					mementoBackExpertSquareHighlight.innerRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
					int num = Math.Max(1, rect.Width / 8);
					int num2 = Math.Max(1, rect.Height / 8);
					RectangleF rect2;
					PointF centerPoint;
					switch (orientation)
					{
					default:
						mementoBackExpertSquareHighlight.innerBrush = new LinearGradientBrush(mementoBackExpertSquareHighlight.innerRect, backColor1, backColor2, 90f);
						rect2 = new RectangleF(rect.Left, rect.Top + num2 * 2, rect.Width, num2 * 12);
						centerPoint = new PointF(rect2.Left + rect2.Width / 2f, rect2.Bottom);
						break;
					case VisualOrientation.Bottom:
						mementoBackExpertSquareHighlight.innerBrush = new LinearGradientBrush(mementoBackExpertSquareHighlight.innerRect, backColor1, backColor2, 270f);
						rect2 = new RectangleF(rect.Left, rect.Top - num2 * 6, rect.Width, num2 * 12);
						centerPoint = new PointF(rect2.Left + rect2.Width / 2f, rect2.Top);
						break;
					case VisualOrientation.Left:
						mementoBackExpertSquareHighlight.innerBrush = new LinearGradientBrush(mementoBackExpertSquareHighlight.innerRect, backColor1, backColor2, 180f);
						rect2 = new RectangleF(rect.Left + num2 * 2, rect.Top, num * 12, rect.Height);
						centerPoint = new PointF(rect2.Right, rect2.Top + rect2.Height / 2f);
						break;
					case VisualOrientation.Right:
						mementoBackExpertSquareHighlight.innerBrush = new LinearGradientBrush(rect, backColor1, backColor2, 0f);
						rect2 = new RectangleF(rect.Left - num2 * 6, rect.Top, num * 12, rect.Height);
						centerPoint = new PointF(rect2.Left, rect2.Top + rect2.Height / 2f);
						break;
					}
					mementoBackExpertSquareHighlight.innerBrush.SetSigmaBellShape(0.5f);
					mementoBackExpertSquareHighlight.ellipsePath = new GraphicsPath();
					mementoBackExpertSquareHighlight.ellipsePath.AddEllipse(rect2);
					mementoBackExpertSquareHighlight.insideLighten = new PathGradientBrush(mementoBackExpertSquareHighlight.ellipsePath);
					mementoBackExpertSquareHighlight.insideLighten.CenterPoint = centerPoint;
					mementoBackExpertSquareHighlight.insideLighten.CenterColor = (light ? Color.FromArgb(64, Color.White) : Color.FromArgb(128, Color.White));
					mementoBackExpertSquareHighlight.insideLighten.Blend = _rounded2Blend;
					mementoBackExpertSquareHighlight.insideLighten.SurroundColors = new Color[1] { Color.Transparent };
				}
				context.Graphics.FillRectangle(mementoBackExpertSquareHighlight.backBrush, rect);
				context.Graphics.FillRectangle(mementoBackExpertSquareHighlight.innerBrush, mementoBackExpertSquareHighlight.innerRect);
				context.Graphics.FillRectangle(mementoBackExpertSquareHighlight.insideLighten, mementoBackExpertSquareHighlight.innerRect);
			}
			return memento;
		}
	}

	private static IDisposable DrawBackSolid(RectangleF drawRect, Color color1, Graphics g, IDisposable memento)
	{
		if (drawRect.Width > 0f && drawRect.Height > 0f)
		{
			bool flag = true;
			MementoBackSolid mementoBackSolid;
			if (memento == null || !(memento is MementoBackSolid))
			{
				memento?.Dispose();
				mementoBackSolid = new MementoBackSolid(drawRect, color1);
				memento = mementoBackSolid;
			}
			else
			{
				mementoBackSolid = (MementoBackSolid)memento;
				flag = !mementoBackSolid.UseCachedValues(drawRect, color1);
			}
			if (flag)
			{
				mementoBackSolid.Dispose();
				mementoBackSolid.solidBrush = new SolidBrush(color1);
			}
			if (mementoBackSolid.solidBrush != null)
			{
				g.FillRectangle(mementoBackSolid.solidBrush, drawRect);
			}
		}
		return memento;
	}

	private static IDisposable DrawBackExpert(Rectangle drawRect, Color color1, Color color2, VisualOrientation orientation, Graphics g, IDisposable memento, bool total, bool tracking)
	{
		if (drawRect.Width > 0 && drawRect.Height > 0)
		{
			bool flag = true;
			MementoBackExpertChecked mementoBackExpertChecked;
			if (memento == null || !(memento is MementoBackExpertChecked))
			{
				memento?.Dispose();
				mementoBackExpertChecked = new MementoBackExpertChecked(drawRect, color1, color2, orientation);
				memento = mementoBackExpertChecked;
			}
			else
			{
				mementoBackExpertChecked = (MementoBackExpertChecked)memento;
				flag = !mementoBackExpertChecked.UseCachedValues(drawRect, color1, color2, orientation);
			}
			if (flag)
			{
				mementoBackExpertChecked.Dispose();
				if (!total)
				{
					drawRect.Inflate(-1, -1);
					mementoBackExpertChecked.drawRect = drawRect;
					mementoBackExpertChecked.clipPath = new GraphicsPath();
					mementoBackExpertChecked.clipPath.AddLine(drawRect.X + 1, drawRect.Y, drawRect.Right - 1, drawRect.Y);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Right - 1, drawRect.Y, drawRect.Right, drawRect.Y + 1);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Right, drawRect.Y + 1, drawRect.Right, drawRect.Bottom - 2);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Right, drawRect.Bottom - 2, drawRect.Right - 2, drawRect.Bottom);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Right - 2, drawRect.Bottom, drawRect.Left + 1, drawRect.Bottom);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Left + 1, drawRect.Bottom, drawRect.Left, drawRect.Bottom - 2);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Left, drawRect.Bottom - 2, drawRect.Left, drawRect.Y + 1);
					mementoBackExpertChecked.clipPath.AddLine(drawRect.Left, drawRect.Y + 1, drawRect.X + 1, drawRect.Y);
				}
				else
				{
					mementoBackExpertChecked.clipPath = new GraphicsPath();
					mementoBackExpertChecked.clipPath.AddRectangle(drawRect);
				}
				RectangleF rect = new RectangleF(drawRect.X - 1, drawRect.Y - 1, drawRect.Width + 2, drawRect.Height + 2);
				if (rect.Width > 0f && rect.Height > 0f)
				{
					mementoBackExpertChecked.entireBrush = new LinearGradientBrush(rect, CommonHelper.WhitenColor(color1, 0.92f, 0.92f, 0.92f), color1, AngleFromOrientation(orientation));
					mementoBackExpertChecked.entireBrush.Blend = _rounded1Blend;
				}
				int num = Math.Max(1, drawRect.Height / 4);
				int num2 = Math.Max(1, tracking ? drawRect.Width : (drawRect.Width / 4));
				RectangleF rect2;
				PointF centerPoint;
				switch (orientation)
				{
				default:
					rect2 = new RectangleF(drawRect.Left - num2, drawRect.Bottom - num, drawRect.Width + num2 * 2, num * 2);
					centerPoint = new PointF(rect2.Left + rect2.Width / 2f, rect2.Bottom);
					break;
				case VisualOrientation.Bottom:
					rect2 = new RectangleF(drawRect.Left - num2, drawRect.Top - num, drawRect.Width + num2 * 2, num * 2);
					centerPoint = new PointF(rect2.Left + rect2.Width / 2f, rect2.Top);
					break;
				case VisualOrientation.Left:
					rect2 = new RectangleF(drawRect.Right - num2, drawRect.Top - num, num2 * 2, drawRect.Height + num * 2);
					centerPoint = new PointF(rect2.Right, rect2.Top + rect2.Height / 2f);
					break;
				case VisualOrientation.Right:
					rect2 = new RectangleF(drawRect.Left - num2, drawRect.Top - num, num2 * 2, drawRect.Height + num * 2);
					centerPoint = new PointF(rect2.Left, rect2.Top + rect2.Height / 2f);
					break;
				}
				mementoBackExpertChecked.ellipsePath = new GraphicsPath();
				mementoBackExpertChecked.ellipsePath.AddEllipse(rect2);
				mementoBackExpertChecked.insideLighten = new PathGradientBrush(mementoBackExpertChecked.ellipsePath);
				mementoBackExpertChecked.insideLighten.CenterPoint = centerPoint;
				mementoBackExpertChecked.insideLighten.CenterColor = color2;
				mementoBackExpertChecked.insideLighten.Blend = _rounded2Blend;
				mementoBackExpertChecked.insideLighten.SurroundColors = new Color[1] { Color.Transparent };
			}
			if (mementoBackExpertChecked.entireBrush != null)
			{
				using (new Clipping(g, mementoBackExpertChecked.clipPath))
				{
					g.FillRectangle(mementoBackExpertChecked.entireBrush, mementoBackExpertChecked.drawRect);
					g.FillPath(mementoBackExpertChecked.insideLighten, mementoBackExpertChecked.ellipsePath);
				}
			}
		}
		return memento;
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
}
