// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Layout.XTextFormatter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Drawing.Layout;

public class XTextFormatter
{
  private readonly XGraphics _gfx;
  private string _text;
  private XFont _font;
  private double _lineSpace;
  private double _cyAscent;
  private double _cyDescent;
  private double _spaceWidth;
  private XRect _layoutRectangle;
  private XParagraphAlignment _alignment = XParagraphAlignment.Left;
  private readonly List<XTextFormatter.Block> _blocks = new List<XTextFormatter.Block>();

  public XTextFormatter(XGraphics gfx)
  {
    this._gfx = gfx != null ? gfx : throw new ArgumentNullException(nameof (gfx));
  }

  public string Text
  {
    get => this._text;
    set => this._text = value;
  }

  public XFont Font
  {
    get => this._font;
    set
    {
      this._font = value != null ? value : throw new ArgumentNullException(nameof (Font));
      this._lineSpace = this._font.GetHeight();
      this._cyAscent = this._lineSpace * (double) this._font.CellAscent / (double) this._font.CellSpace;
      this._cyDescent = this._lineSpace * (double) this._font.CellDescent / (double) this._font.CellSpace;
      this._spaceWidth = this._gfx.MeasureString("x x", value).Width;
      this._spaceWidth -= this._gfx.MeasureString("xx", value).Width;
    }
  }

  public XRect LayoutRectangle
  {
    get => this._layoutRectangle;
    set => this._layoutRectangle = value;
  }

  public XParagraphAlignment Alignment
  {
    get => this._alignment;
    set => this._alignment = value;
  }

  public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle)
  {
    this.DrawString(text, font, brush, layoutRectangle, XStringFormats.TopLeft);
  }

  public void DrawString(
    string text,
    XFont font,
    XBrush brush,
    XRect layoutRectangle,
    XStringFormat format)
  {
    if (text == null)
      throw new ArgumentNullException(nameof (text));
    if (font == null)
      throw new ArgumentNullException(nameof (font));
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    if ((format.Alignment != XStringAlignment.Near ? 1 : (format.LineAlignment != 0 ? 1 : 0)) != 0)
      throw new ArgumentException("Only TopLeft alignment is currently implemented.");
    this.Text = text;
    this.Font = font;
    this.LayoutRectangle = layoutRectangle;
    if (text.Length == 0)
      return;
    this.CreateBlocks();
    this.CreateLayout();
    double x = layoutRectangle.Location.X;
    double num = layoutRectangle.Location.Y + this._cyAscent;
    int count = this._blocks.Count;
    for (int index = 0; index < count; ++index)
    {
      XTextFormatter.Block block = this._blocks[index];
      if (block.Stop)
        break;
      if (block.Type != XTextFormatter.BlockType.LineBreak)
        this._gfx.DrawString(block.Text, font, brush, x + block.Location.X, num + block.Location.Y);
    }
  }

  private void CreateBlocks()
  {
    this._blocks.Clear();
    int length1 = this._text.Length;
    bool flag = false;
    int startIndex = 0;
    int length2 = 0;
    for (int index = 0; index < length1; ++index)
    {
      char c = this._text[index];
      if (c == '\r')
      {
        if ((index >= length1 - 1 ? 0 : (this._text[index + 1] == '\n' ? 1 : 0)) != 0)
          ++index;
        c = '\n';
      }
      if (c == '\n')
      {
        if (length2 != 0)
        {
          string text = this._text.Substring(startIndex, length2);
          this._blocks.Add(new XTextFormatter.Block(text, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text, this._font).Width));
        }
        startIndex = index + 1;
        length2 = 0;
        this._blocks.Add(new XTextFormatter.Block(XTextFormatter.BlockType.LineBreak));
      }
      else if (char.IsWhiteSpace(c))
      {
        if (flag)
        {
          string text = this._text.Substring(startIndex, length2);
          this._blocks.Add(new XTextFormatter.Block(text, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text, this._font).Width));
          startIndex = index + 1;
          length2 = 0;
        }
        else
          ++length2;
      }
      else
      {
        flag = true;
        ++length2;
      }
    }
    if (length2 == 0)
      return;
    string text1 = this._text.Substring(startIndex, length2);
    this._blocks.Add(new XTextFormatter.Block(text1, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text1, this._font).Width));
  }

  private void CreateLayout()
  {
    double width1 = this._layoutRectangle.Width;
    double num1 = this._layoutRectangle.Height - this._cyAscent - this._cyDescent;
    int num2 = 0;
    double x = 0.0;
    double y = 0.0;
    int count = this._blocks.Count;
    for (int index = 0; index < count; ++index)
    {
      XTextFormatter.Block block = this._blocks[index];
      if (block.Type == XTextFormatter.BlockType.LineBreak)
      {
        if (this.Alignment == XParagraphAlignment.Justify)
          this._blocks[num2].Alignment = XParagraphAlignment.Left;
        this.AlignLine(num2, index - 1, width1);
        num2 = index + 1;
        x = 0.0;
        y += this._lineSpace;
        if (y > num1)
        {
          block.Stop = true;
          break;
        }
      }
      else
      {
        double width2 = block.Width;
        if ((x + width2 <= width1 || x == 0.0 ? (block.Type != XTextFormatter.BlockType.LineBreak ? 1 : 0) : 0) != 0)
        {
          block.Location = new XPoint(x, y);
          x += width2 + this._spaceWidth;
        }
        else
        {
          this.AlignLine(num2, index - 1, width1);
          num2 = index;
          y += this._lineSpace;
          if (y <= num1)
          {
            block.Location = new XPoint(0.0, y);
            x = width2 + this._spaceWidth;
          }
          else
          {
            block.Stop = true;
            break;
          }
        }
      }
    }
    if ((num2 >= count ? 0 : (this.Alignment != XParagraphAlignment.Justify ? 1 : 0)) == 0)
      return;
    this.AlignLine(num2, count - 1, width1);
  }

  private void AlignLine(int firstIndex, int lastIndex, double layoutWidth)
  {
    XParagraphAlignment alignment = this._blocks[firstIndex].Alignment;
    if ((this._alignment == XParagraphAlignment.Left ? 1 : (alignment == XParagraphAlignment.Left ? 1 : 0)) != 0)
      return;
    int num1 = lastIndex - firstIndex + 1;
    if (num1 == 0)
      return;
    double num2 = -this._spaceWidth;
    for (int index = firstIndex; index <= lastIndex; ++index)
      num2 += this._blocks[index].Width + this._spaceWidth;
    double width = Math.Max(layoutWidth - num2, 0.0);
    if (this._alignment != XParagraphAlignment.Justify)
    {
      if (this._alignment == XParagraphAlignment.Center)
        width /= 2.0;
      for (int index = firstIndex; index <= lastIndex; ++index)
        this._blocks[index].Location += new XSize(width, 0.0);
    }
    else
    {
      if (num1 <= 1)
        return;
      double num3 = width / (double) (num1 - 1);
      int index = firstIndex + 1;
      int num4 = 1;
      while (index <= lastIndex)
      {
        this._blocks[index].Location += new XSize(num3 * (double) num4, 0.0);
        ++index;
        ++num4;
      }
    }
  }

  private enum BlockType
  {
    Text,
    Space,
    Hyphen,
    LineBreak,
  }

  private class Block
  {
    public readonly string Text;
    public readonly XTextFormatter.BlockType Type;
    public readonly double Width;
    public XPoint Location;
    public XParagraphAlignment Alignment;
    public bool Stop;

    public Block(string text, XTextFormatter.BlockType type, double width)
    {
      this.Text = text;
      this.Type = type;
      this.Width = width;
    }

    public Block(XTextFormatter.BlockType type) => this.Type = type;
  }
}
