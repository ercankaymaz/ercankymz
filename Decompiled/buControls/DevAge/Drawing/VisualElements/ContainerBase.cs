using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class ContainerBase : VisualElementBase, ICloneable, IVisualElement, IContainer
{
	private ElementsDrawMode mDrawMode = ElementsDrawMode.Covering;

	private IVisualElement mBackground = null;

	private Padding mPadding = Padding.Empty;

	private IBorder mBorder = null;

	protected ElementsDrawMode ElementsDrawMode
	{
		get
		{
			return mDrawMode;
		}
		set
		{
			mDrawMode = value;
		}
	}

	protected IVisualElement Background
	{
		get
		{
			return mBackground;
		}
		set
		{
			mBackground = value;
		}
	}

	protected Padding Padding
	{
		get
		{
			return mPadding;
		}
		set
		{
			mPadding = value;
		}
	}

	protected IBorder Border
	{
		get
		{
			return mBorder;
		}
		set
		{
			mBorder = value;
		}
	}

	public ContainerBase()
	{
	}

	public ContainerBase(ContainerBase other)
		: base(other)
	{
		if (other.Background == null)
		{
			Background = null;
		}
		else
		{
			Background = (IVisualElement)other.Background.Clone();
		}
		ElementsDrawMode = other.ElementsDrawMode;
		Padding = other.Padding;
		if (other.Border == null)
		{
			Border = null;
		}
		else
		{
			Border = (IBorder)other.Border.Clone();
		}
	}

	protected abstract IEnumerable<IVisualElement> GetElements();

	protected virtual bool ShouldSerializeElementsDrawMode()
	{
		return ElementsDrawMode != ElementsDrawMode.Covering;
	}

	protected virtual bool ShouldSerializeBackground()
	{
		return Background != null;
	}

	protected virtual bool ShouldSerializePadding()
	{
		return Padding != Padding.Empty;
	}

	protected virtual bool ShouldSerializeBorder()
	{
		return Border != null;
	}

	public RectangleF GetContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		if (Border != null)
		{
			backGroundArea = Border.GetContentRectangle(backGroundArea);
		}
		if (!Padding.IsEmpty)
		{
			backGroundArea = Padding.GetContentRectangle(backGroundArea);
		}
		if (Background is IBackground)
		{
			backGroundArea = ((IBackground)Background).GetBackgroundContentRectangle(measure, backGroundArea);
		}
		return backGroundArea;
	}

	public SizeF GetExtent(MeasureHelper measure, SizeF contentSize)
	{
		if (Background is IBackground)
		{
			contentSize = ((IBackground)Background).GetBackgroundExtent(measure, contentSize);
		}
		if (!Padding.IsEmpty)
		{
			contentSize = Padding.GetExtent(contentSize);
		}
		if (Border != null)
		{
			contentSize = Border.GetExtent(contentSize);
		}
		return contentSize;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		OnDrawBackground(graphics, area);
		using MeasureHelper measure = new MeasureHelper(graphics);
		RectangleF contentRectangle = GetContentRectangle(measure, area);
		OnDrawContent(graphics, contentRectangle);
	}

	protected virtual void OnDrawBackground(GraphicsCache graphics, RectangleF area)
	{
		if (Border != null)
		{
			Border.Draw(graphics, area);
			area = Border.GetContentRectangle(area);
		}
		if (Background != null)
		{
			Background.Draw(graphics, area);
		}
	}

	protected virtual void OnDrawContent(GraphicsCache graphics, RectangleF area)
	{
		if (ElementsDrawMode != ElementsDrawMode.Covering)
		{
			if (ElementsDrawMode != ElementsDrawMode.Align)
			{
				throw new ApplicationException("DrawMode not supported");
			}
			using (new MeasureHelper(graphics))
			{
				foreach (IVisualElement element in GetElements())
				{
					element.Draw(graphics, area, out var drawingArea);
					area = CalculateRemainingArea(area, element.AnchorArea, drawingArea);
				}
				return;
			}
		}
		foreach (IVisualElement element2 in GetElements())
		{
			element2.Draw(graphics, area);
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		SizeF sizeF = new SizeF(0f, 0f);
		if (ElementsDrawMode != ElementsDrawMode.Covering)
		{
			if (ElementsDrawMode != ElementsDrawMode.Align)
			{
				throw new ApplicationException("DrawMode not supported");
			}
			AnchorArea contentAnchor = null;
			foreach (IVisualElement element in GetElements())
			{
				SizeF contentSize = element.Measure(measure, Size.Empty, maxSize);
				contentSize = CalculateSizeWithAnchor(contentSize, element.AnchorArea, maxSize);
				sizeF = CalculateSizeWithContent(sizeF, contentAnchor, contentSize);
				contentAnchor = element.AnchorArea;
			}
		}
		else
		{
			foreach (IVisualElement element2 in GetElements())
			{
				SizeF contentSize2 = element2.Measure(measure, Size.Empty, maxSize);
				contentSize2 = CalculateSizeWithAnchor(contentSize2, element2.AnchorArea, maxSize);
				if (contentSize2.Width > sizeF.Width)
				{
					sizeF.Width = contentSize2.Width;
				}
				if (contentSize2.Height > sizeF.Height)
				{
					sizeF.Height = contentSize2.Height;
				}
			}
		}
		return GetExtent(measure, sizeF);
	}

	public override VisualElementList GetElementsAtPoint(MeasureHelper measure, RectangleF area, PointF point)
	{
		VisualElementList elementsAtPoint = base.GetElementsAtPoint(measure, area, point);
		area = GetContentRectangle(measure, area);
		if (ElementsDrawMode != ElementsDrawMode.Covering)
		{
			if (ElementsDrawMode != ElementsDrawMode.Align)
			{
				throw new ApplicationException("DrawMode not supported");
			}
			foreach (IVisualElement element in GetElements())
			{
				elementsAtPoint.AddRange(element.GetElementsAtPoint(measure, area, point));
				RectangleF drawingArea = element.GetDrawingArea(measure, area);
				area = CalculateRemainingArea(area, element.AnchorArea, drawingArea);
			}
		}
		else
		{
			foreach (IVisualElement element2 in GetElements())
			{
				elementsAtPoint.AddRange(element2.GetElementsAtPoint(measure, area, point));
			}
		}
		return elementsAtPoint;
	}

	public static RectangleF CalculateRemainingArea(RectangleF parentArea, AnchorArea contentAnchor, RectangleF contentArea)
	{
		if (!(contentAnchor != null))
		{
			return parentArea;
		}
		float y;
		float height;
		if (!contentAnchor.HasTop || contentAnchor.HasBottom)
		{
			if (!contentAnchor.HasBottom || contentAnchor.HasTop)
			{
				y = parentArea.Top;
				height = parentArea.Height;
			}
			else
			{
				y = parentArea.Top;
				height = parentArea.Height - contentArea.Height;
			}
		}
		else
		{
			y = contentArea.Bottom;
			height = parentArea.Height - contentArea.Height;
		}
		float x;
		float width;
		if (!contentAnchor.HasLeft || contentAnchor.HasRight)
		{
			if (!contentAnchor.HasRight || contentAnchor.HasLeft)
			{
				x = parentArea.Left;
				width = parentArea.Width;
			}
			else
			{
				x = parentArea.Left;
				width = parentArea.Width - contentArea.Width;
			}
		}
		else
		{
			x = contentArea.Right;
			width = parentArea.Width - contentArea.Width;
		}
		RectangleF result = new RectangleF(x, y, width, height);
		result.Intersect(parentArea);
		return result;
	}

	public static SizeF CalculateSizeWithContent(SizeF currentSize, AnchorArea contentAnchor, SizeF contentSize)
	{
		if (!(contentAnchor != null) || (!contentAnchor.HasLeft && !contentAnchor.HasRight))
		{
			if (contentSize.Width > currentSize.Width)
			{
				currentSize.Width = contentSize.Width;
			}
		}
		else
		{
			currentSize.Width += contentSize.Width;
		}
		if (!(contentAnchor != null) || (!contentAnchor.HasTop && !contentAnchor.HasBottom))
		{
			if (contentSize.Height > currentSize.Height)
			{
				currentSize.Height = contentSize.Height;
			}
		}
		else
		{
			currentSize.Height += contentSize.Height;
		}
		return currentSize;
	}

	public static SizeF CalculateSizeWithAnchor(SizeF contentSize, AnchorArea contentAnchor, SizeF clientSize)
	{
		if (!(contentAnchor == null))
		{
			if (!contentAnchor.HasLeft || !contentAnchor.HasRight)
			{
				if (!contentAnchor.HasLeft)
				{
					if (contentAnchor.HasRight)
					{
						contentSize.Width += contentAnchor.Right;
					}
				}
				else
				{
					contentSize.Width += contentAnchor.Left;
				}
			}
			else if (!clientSize.IsEmpty)
			{
				contentSize.Width = clientSize.Width - (contentAnchor.Left + contentAnchor.Right);
			}
			if (contentSize.Width < 0f)
			{
				contentSize.Width = 0f;
			}
			if (!contentAnchor.HasTop || !contentAnchor.HasBottom)
			{
				if (!contentAnchor.HasTop)
				{
					if (contentAnchor.HasBottom)
					{
						contentSize.Height += contentAnchor.Bottom;
					}
				}
				else
				{
					contentSize.Height += contentAnchor.Top;
				}
			}
			else if (!clientSize.IsEmpty)
			{
				contentSize.Height = clientSize.Height - (contentAnchor.Top + contentAnchor.Bottom);
			}
			if (contentSize.Height < 0f)
			{
				contentSize.Height = 0f;
			}
			return contentSize;
		}
		return contentSize;
	}
}
