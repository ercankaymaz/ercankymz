using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class ColumnHeader : ColumnHeaderBase
{
	private Header mBackground = new Header(90f);

	public override ControlDrawStyle Style
	{
		get
		{
			return base.Style;
		}
		set
		{
			base.Style = value;
			mBackground.Style = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return mBackground.BackColor;
		}
		set
		{
			mBackground.BackColor = value;
		}
	}

	public BackgroundColorStyle BackgroundColorStyle
	{
		get
		{
			return mBackground.BackgroundColorStyle;
		}
		set
		{
			mBackground.BackgroundColorStyle = value;
		}
	}

	public RectangleBorder Border
	{
		get
		{
			return mBackground.Border;
		}
		set
		{
			mBackground.Border = value;
		}
	}

	public ColumnHeader()
	{
	}

	public ColumnHeader(ColumnHeader other)
		: base(other)
	{
		mBackground = (Header)other.mBackground.Clone();
	}

	public override object Clone()
	{
		return new ColumnHeader(this);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		base.OnDraw(graphics, area);
		mBackground.Draw(graphics, area);
	}

	public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
		return mBackground.GetBackgroundContentRectangle(measure, backGroundArea);
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		contentSize = mBackground.GetBackgroundExtent(measure, contentSize);
		return base.GetBackgroundExtent(measure, contentSize);
	}
}
