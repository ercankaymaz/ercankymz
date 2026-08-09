using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing.Layout;

public class XTextFormatter
{
	private enum BlockType
	{
		Text,
		Space,
		Hyphen,
		LineBreak
	}

	private class Block
	{
		public readonly string Text;

		public readonly BlockType Type;

		public readonly double Width;

		public XPoint Location;

		public XParagraphAlignment Alignment;

		public bool Stop;

		public Block(string text, BlockType type, double width)
		{
			Text = text;
			Type = type;
			Width = width;
		}

		public Block(BlockType type)
		{
			Type = type;
		}
	}

	private readonly XGraphics _gfx;

	private string _text;

	private XFont _font;

	private double _lineSpace;

	private double _cyAscent;

	private double _cyDescent;

	private double _spaceWidth;

	private XRect _layoutRectangle;

	private XParagraphAlignment _alignment = XParagraphAlignment.Left;

	private readonly List<Block> _blocks = new List<Block>();

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
		}
	}

	public XFont Font
	{
		get
		{
			return _font;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Font");
			}
			_font = value;
			_lineSpace = _font.GetHeight();
			_cyAscent = _lineSpace * (double)_font.CellAscent / (double)_font.CellSpace;
			_cyDescent = _lineSpace * (double)_font.CellDescent / (double)_font.CellSpace;
			_spaceWidth = _gfx.MeasureString("x\u00a0x", value).Width;
			_spaceWidth -= _gfx.MeasureString("xx", value).Width;
		}
	}

	public XRect LayoutRectangle
	{
		get
		{
			return _layoutRectangle;
		}
		set
		{
			_layoutRectangle = value;
		}
	}

	public XParagraphAlignment Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			_alignment = value;
		}
	}

	public XTextFormatter(XGraphics gfx)
	{
		if (gfx == null)
		{
			throw new ArgumentNullException("gfx");
		}
		_gfx = gfx;
	}

	public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle)
	{
		DrawString(text, font, brush, layoutRectangle, XStringFormats.TopLeft);
	}

	public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle, XStringFormat format)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (brush == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (format.Alignment != XStringAlignment.Near || format.LineAlignment != XLineAlignment.Near)
		{
			throw new ArgumentException("Only TopLeft alignment is currently implemented.");
		}
		Text = text;
		Font = font;
		LayoutRectangle = layoutRectangle;
		if (text.Length == 0)
		{
			return;
		}
		CreateBlocks();
		CreateLayout();
		double x = layoutRectangle.Location.X;
		double num = layoutRectangle.Location.Y + _cyAscent;
		int count = _blocks.Count;
		for (int i = 0; i < count; i++)
		{
			Block block = _blocks[i];
			if (block.Stop)
			{
				break;
			}
			if (block.Type != BlockType.LineBreak)
			{
				_gfx.DrawString(block.Text, font, brush, x + block.Location.X, num + block.Location.Y);
			}
		}
	}

	private void CreateBlocks()
	{
		_blocks.Clear();
		int length = _text.Length;
		bool flag = false;
		int startIndex = 0;
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			char c = _text[i];
			if (c == '\r')
			{
				if (i < length - 1 && _text[i + 1] == '\n')
				{
					i++;
				}
				c = '\n';
			}
			if (c == '\n')
			{
				if (num != 0)
				{
					string text = _text.Substring(startIndex, num);
					_blocks.Add(new Block(text, BlockType.Text, _gfx.MeasureString(text, _font).Width));
				}
				startIndex = i + 1;
				num = 0;
				_blocks.Add(new Block(BlockType.LineBreak));
			}
			else if (char.IsWhiteSpace(c))
			{
				if (flag)
				{
					string text2 = _text.Substring(startIndex, num);
					_blocks.Add(new Block(text2, BlockType.Text, _gfx.MeasureString(text2, _font).Width));
					startIndex = i + 1;
					num = 0;
				}
				else
				{
					num++;
				}
			}
			else
			{
				flag = true;
				num++;
			}
		}
		if (num != 0)
		{
			string text3 = _text.Substring(startIndex, num);
			_blocks.Add(new Block(text3, BlockType.Text, _gfx.MeasureString(text3, _font).Width));
		}
	}

	private void CreateLayout()
	{
		double width = _layoutRectangle.Width;
		double num = _layoutRectangle.Height - _cyAscent - _cyDescent;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		int count = _blocks.Count;
		for (int i = 0; i < count; i++)
		{
			Block block = _blocks[i];
			if (block.Type == BlockType.LineBreak)
			{
				if (Alignment == XParagraphAlignment.Justify)
				{
					_blocks[num2].Alignment = XParagraphAlignment.Left;
				}
				AlignLine(num2, i - 1, width);
				num2 = i + 1;
				num3 = 0.0;
				num4 += _lineSpace;
				if (num4 > num)
				{
					block.Stop = true;
					break;
				}
				continue;
			}
			double width2 = block.Width;
			if ((num3 + width2 <= width || num3 == 0.0) && block.Type != BlockType.LineBreak)
			{
				block.Location = new XPoint(num3, num4);
				num3 += width2 + _spaceWidth;
				continue;
			}
			AlignLine(num2, i - 1, width);
			num2 = i;
			num4 += _lineSpace;
			if (num4 > num)
			{
				block.Stop = true;
				break;
			}
			block.Location = new XPoint(0.0, num4);
			num3 = width2 + _spaceWidth;
		}
		if (num2 < count && Alignment != XParagraphAlignment.Justify)
		{
			AlignLine(num2, count - 1, width);
		}
	}

	private void AlignLine(int firstIndex, int lastIndex, double layoutWidth)
	{
		XParagraphAlignment alignment = _blocks[firstIndex].Alignment;
		if (_alignment == XParagraphAlignment.Left || alignment == XParagraphAlignment.Left)
		{
			return;
		}
		int num = lastIndex - firstIndex + 1;
		if (num == 0)
		{
			return;
		}
		double num2 = 0.0 - _spaceWidth;
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			num2 += _blocks[i].Width + _spaceWidth;
		}
		double num3 = Math.Max(layoutWidth - num2, 0.0);
		if (_alignment != XParagraphAlignment.Justify)
		{
			if (_alignment == XParagraphAlignment.Center)
			{
				num3 /= 2.0;
			}
			for (int j = firstIndex; j <= lastIndex; j++)
			{
				Block block = _blocks[j];
				block.Location += new XSize(num3, 0.0);
			}
		}
		else if (num > 1)
		{
			num3 /= (double)(num - 1);
			int num4 = firstIndex + 1;
			int num5 = 1;
			while (num4 <= lastIndex)
			{
				Block block2 = _blocks[num4];
				block2.Location += new XSize(num3 * (double)num5, 0.0);
				num4++;
				num5++;
			}
		}
	}
}
