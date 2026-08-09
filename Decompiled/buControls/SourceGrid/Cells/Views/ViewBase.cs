using System;
using System.Drawing;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;

namespace SourceGrid.Cells.Views;

[Serializable]
public abstract class ViewBase : ContainerBase, ICloneable, IView
{
	public static RectangleBorder DefaultBorder = new RectangleBorder(new BorderLine(Color.LightGray, 1f), new BorderLine(Color.LightGray, 1f));

	public static Padding DefaultPadding = new Padding(2f);

	public static Color DefaultBackColor = Color.FromKnownColor(KnownColor.Window);

	public static Color DefaultForeColor = Color.FromKnownColor(KnownColor.WindowText);

	public static DevAge.Drawing.ContentAlignment DefaultAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

	private bool m_ImageStretch = false;

	private DevAge.Drawing.ContentAlignment m_ImageAlignment;

	private Font m_Font = null;

	private Color m_ForeColor;

	private bool mWordWrap = false;

	private TrimmingMode mTrimmingMode = TrimmingMode.Char;

	private DevAge.Drawing.ContentAlignment mTextAlignment;

	public bool ImageStretch
	{
		get
		{
			return m_ImageStretch;
		}
		set
		{
			m_ImageStretch = value;
		}
	}

	public DevAge.Drawing.ContentAlignment ImageAlignment
	{
		get
		{
			return m_ImageAlignment;
		}
		set
		{
			m_ImageAlignment = value;
		}
	}

	public Font Font
	{
		get
		{
			return m_Font;
		}
		set
		{
			m_Font = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return m_ForeColor;
		}
		set
		{
			m_ForeColor = value;
		}
	}

	public bool WordWrap
	{
		get
		{
			return mWordWrap;
		}
		set
		{
			mWordWrap = value;
		}
	}

	public TrimmingMode TrimmingMode
	{
		get
		{
			return mTrimmingMode;
		}
		set
		{
			mTrimmingMode = value;
		}
	}

	public DevAge.Drawing.ContentAlignment TextAlignment
	{
		get
		{
			return mTextAlignment;
		}
		set
		{
			mTextAlignment = value;
		}
	}

	public Color BackColor
	{
		get
		{
			if (!(Background is BackgroundSolid))
			{
				return DefaultBackColor;
			}
			return ((BackgroundSolid)Background).BackColor;
		}
		set
		{
			if (Background is BackgroundSolid)
			{
				((BackgroundSolid)Background).BackColor = value;
			}
		}
	}

	public new IBorder Border
	{
		get
		{
			return base.Border;
		}
		set
		{
			base.Border = value;
		}
	}

	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	public new ElementsDrawMode ElementsDrawMode
	{
		get
		{
			return base.ElementsDrawMode;
		}
		set
		{
			base.ElementsDrawMode = value;
		}
	}

	public new IVisualElement Background
	{
		get
		{
			return base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	public ViewBase()
	{
		Background = new BackgroundSolid();
		Padding = DefaultPadding;
		ForeColor = DefaultForeColor;
		BackColor = DefaultBackColor;
		Border = DefaultBorder;
		TextAlignment = DefaultAlignment;
		ImageAlignment = DefaultAlignment;
	}

	public ViewBase(ViewBase p_Source)
		: base(p_Source)
	{
		ForeColor = p_Source.ForeColor;
		BackColor = p_Source.BackColor;
		Border = p_Source.Border;
		Padding = p_Source.Padding;
		Font font = null;
		if (p_Source.Font != null)
		{
			font = (Font)p_Source.Font.Clone();
		}
		Font = font;
		WordWrap = p_Source.WordWrap;
		TextAlignment = p_Source.TextAlignment;
		TrimmingMode = p_Source.TrimmingMode;
		ImageAlignment = p_Source.ImageAlignment;
		ImageStretch = p_Source.ImageStretch;
	}

	public virtual Font GetDrawingFont(GridVirtual grid)
	{
		if (Font != null)
		{
			return Font;
		}
		return grid.Font;
	}

	public void DrawCell(CellContext cellContext, GraphicsCache graphics, RectangleF rectangle)
	{
		PrepareView(cellContext);
		Draw(graphics, rectangle);
	}

	protected virtual void PrepareView(CellContext context)
	{
	}

	public Size Measure(CellContext cellContext, Size maxLayoutArea)
	{
		using MeasureHelper measure = new MeasureHelper(cellContext.Grid);
		PrepareView(cellContext);
		SizeF value = Measure(measure, SizeF.Empty, maxLayoutArea);
		return Size.Ceiling(value);
	}
}
