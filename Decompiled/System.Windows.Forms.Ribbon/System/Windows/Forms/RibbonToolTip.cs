#define TRACE
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms;

public class RibbonToolTip : ToolTip
{
	private const int DEFAULT_WIDTH = 200;

	private readonly IRibbonElement _RibbonElement;

	private static Color _BorderColor = Color.Red;

	private readonly Font _Font = new Font("Segoe UI", 8f);

	private readonly Padding TipPadding = new Padding(5, 5, 5, 5);

	private Rectangle _ImageRectangle;

	private Rectangle _TitleRectangle;

	private Rectangle _TextRectangle;

	private Rectangle _ToolTipRectangle;

	private Size _Size = new Size(200, 60);

	private int _ImageWidth = 15;

	private bool _AutoSize = true;

	private Ribbon Owner => _RibbonElement.Owner;

	[Category("Custom Settings")]
	[Description("Gets or sets a value indicating whether the ToolTip is drawn by the operating system or by code that you provide. If true, the properties 'ToolTipIcon' and 'ToolTipTitle' will set to their default values and the image will display in ToolTip otherwise only text will display.")]
	public new bool OwnerDraw
	{
		get
		{
			return base.OwnerDraw;
		}
		set
		{
			if (value)
			{
				ToolTipIcon = ToolTipIcon.None;
				ToolTipTitle = string.Empty;
			}
			base.OwnerDraw = value;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text. Cannot set if the property 'OwnerDraw' is true.")]
	public new ToolTipIcon ToolTipIcon
	{
		get
		{
			return base.ToolTipIcon;
		}
		set
		{
			base.ToolTipIcon = value;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets a title for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
	public new string ToolTipTitle
	{
		get
		{
			return base.ToolTipTitle;
		}
		set
		{
			base.ToolTipTitle = value;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets an Image for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
	public Image ToolTipImage { get; set; }

	[Category("Custom Settings")]
	[Description("Gets or sets the background color for the ToolTip.")]
	public new Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets the foreground color for the ToolTip.")]
	public new Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets a value that indicates whether the ToolTip resizes based on its text. true if the ToolTip automatically resizes based on its text; otherwise, false. The default is true.")]
	public bool AutoSize
	{
		get
		{
			return _AutoSize;
		}
		set
		{
			_AutoSize = value;
			_ = _AutoSize;
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets the size of the ToolTip. Valid only if the Property 'AutoSize' is false.")]
	public Size Size
	{
		get
		{
			return _Size;
		}
		set
		{
			if (!_AutoSize)
			{
				_Size = value;
				_ToolTipRectangle.Size = _Size;
			}
		}
	}

	[Category("Custom Settings")]
	[Description("Gets or sets the border color for the ToolTip.")]
	public Color BorderColor
	{
		get
		{
			return _BorderColor;
		}
		set
		{
			_BorderColor = value;
		}
	}

	public new event PopupEventHandler Popup;

	public RibbonToolTip(IRibbonElement ribbonElement)
	{
		try
		{
			_RibbonElement = ribbonElement;
			OwnerDraw = true;
			AutoSize = false;
			base.Popup += ToolTip_Popup;
			base.Draw += ToolTip_Draw;
		}
		catch (Exception ex)
		{
			Trace.TraceError("Exception in RibbonToolTip.RibbonToolTip() " + ex);
			throw;
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			try
			{
				if (disposing)
				{
					if (_Font != null)
					{
						_Font.Dispose();
					}
					base.Popup -= ToolTip_Popup;
					base.Draw -= ToolTip_Draw;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		catch (Exception ex)
		{
			Trace.TraceError("Exception in CustomizedToolTip.Dispose (bool) " + ex);
			throw;
		}
	}

	private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
	{
		try
		{
			e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
			string toolTip = GetToolTip(e.AssociatedControl);
			RibbonToolTipRenderEventArgs e2 = new RibbonToolTipRenderEventArgs(Owner, e.Graphics, e.Bounds, toolTip)
			{
				Color = Color.Black,
				Font = _Font
			};
			Owner.Renderer.OnRenderToolTipBackground(e2);
			StringFormat stringFormat = (e2.Format = new StringFormat
			{
				Trimming = StringTrimming.None
			});
			if (_ImageRectangle.Width > 0 && _ImageRectangle.Height > 0)
			{
				e.Graphics.DrawImage(ToolTipImage, _ImageRectangle);
			}
			if (_TextRectangle.Width > 0 && _TextRectangle.Height > 0)
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Near;
				e2.ClipRectangle = _TextRectangle;
				e2.Text = toolTip;
				Owner.Renderer.OnRenderToolTipText(e2);
			}
			if (_TitleRectangle.Width > 0 && _TitleRectangle.Height > 0)
			{
				Font font = new Font(_Font, FontStyle.Bold);
				e2.ClipRectangle = _TitleRectangle;
				e2.Text = ToolTipTitle;
				e2.Font = font;
				Owner.Renderer.OnRenderToolTipText(e2);
				font.Dispose();
			}
		}
		catch (Exception ex)
		{
			Trace.TraceError("Exception in RibbonToolTip_Draw (object, DrawToolTipEventArgs) " + ex);
			throw;
		}
	}

	private void ToolTip_Popup(object sender, PopupEventArgs e)
	{
		if (this.Popup != null)
		{
			this.Popup(sender, e);
			if (e.Cancel)
			{
				return;
			}
		}
		try
		{
			if (!OwnerDraw)
			{
				return;
			}
			if (!_AutoSize)
			{
				Graphics graphics = e.AssociatedControl.CreateGraphics();
				int num = TipPadding.Left;
				int num2 = TipPadding.Top;
				Size size;
				if (!string.IsNullOrEmpty(base.ToolTipTitle))
				{
					Font font = new Font(_Font, FontStyle.Bold);
					size = graphics.MeasureString(base.ToolTipTitle, font, 200).ToSize();
					size.Width = Math.Max(size.Width + 5, 200);
					_TitleRectangle = new Rectangle(num, num2, size.Width, size.Height);
					num2 = _TitleRectangle.Bottom + 5;
					font.Dispose();
				}
				if (ToolTipImage != null)
				{
					_ImageRectangle = new Rectangle(num, num2, ToolTipImage.Width + 2, ToolTipImage.Height + 2);
					num = _ImageRectangle.Right + 10;
				}
				else if (!string.IsNullOrEmpty(base.ToolTipTitle))
				{
					num += 15;
				}
				size = graphics.MeasureString(GetToolTip(e.AssociatedControl), _Font, 200).ToSize();
				_TextRectangle = Rectangle.FromLTRB(num, num2, size.Width + num + 4, num2 + size.Height);
				num = _TextRectangle.Right;
				Size toolTipSize = new Size(Math.Max(_TextRectangle.Right, _TitleRectangle.Right) + TipPadding.Right, Math.Max(_TextRectangle.Bottom, _ImageRectangle.Bottom) + TipPadding.Bottom);
				e.ToolTipSize = toolTipSize;
			}
			else
			{
				Size toolTipSize2 = e.ToolTipSize;
				if (e.AssociatedControl.Tag is Image)
				{
					_ImageWidth = toolTipSize2.Height;
					toolTipSize2.Width += _ImageWidth + TipPadding.Left;
				}
				else
				{
					toolTipSize2.Width += TipPadding.Left;
				}
				e.ToolTipSize = toolTipSize2;
			}
		}
		catch (Exception ex)
		{
			Trace.TraceError("Exception in RibbonToolTip_Popup (object, PopupEventArgs) " + ex);
			throw;
		}
	}
}
