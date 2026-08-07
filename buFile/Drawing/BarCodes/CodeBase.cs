// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.CodeBase
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public abstract class CodeBase
{
  private XSize _size;
  private string _text;
  private AnchorType _anchor;
  private CodeDirection _direction;
  private static readonly CodeBase.Delta[,] Deltas = new CodeBase.Delta[9, 9]
  {
    {
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0),
      new CodeBase.Delta(2, 0),
      new CodeBase.Delta(0, 1),
      new CodeBase.Delta(1, 1),
      new CodeBase.Delta(2, 1),
      new CodeBase.Delta(0, 2),
      new CodeBase.Delta(1, 2),
      new CodeBase.Delta(2, 2)
    },
    {
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0),
      new CodeBase.Delta(-1, 1),
      new CodeBase.Delta(0, 1),
      new CodeBase.Delta(1, 1),
      new CodeBase.Delta(-1, 2),
      new CodeBase.Delta(0, 2),
      new CodeBase.Delta(1, 2)
    },
    {
      new CodeBase.Delta(-2, 0),
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(-2, 1),
      new CodeBase.Delta(-1, 1),
      new CodeBase.Delta(0, 1),
      new CodeBase.Delta(-2, 2),
      new CodeBase.Delta(-1, 2),
      new CodeBase.Delta(0, 2)
    },
    {
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(1, -1),
      new CodeBase.Delta(2, -1),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0),
      new CodeBase.Delta(2, 0),
      new CodeBase.Delta(0, 1),
      new CodeBase.Delta(1, 1),
      new CodeBase.Delta(2, 1)
    },
    {
      new CodeBase.Delta(-1, -1),
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(1, -1),
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0),
      new CodeBase.Delta(-1, 1),
      new CodeBase.Delta(0, 1),
      new CodeBase.Delta(1, 1)
    },
    {
      new CodeBase.Delta(-2, -1),
      new CodeBase.Delta(-1, -1),
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(-2, 0),
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(-2, 1),
      new CodeBase.Delta(-1, 1),
      new CodeBase.Delta(0, 1)
    },
    {
      new CodeBase.Delta(0, -2),
      new CodeBase.Delta(1, -2),
      new CodeBase.Delta(2, -2),
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(1, -1),
      new CodeBase.Delta(2, -1),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0),
      new CodeBase.Delta(2, 0)
    },
    {
      new CodeBase.Delta(-1, -2),
      new CodeBase.Delta(0, -2),
      new CodeBase.Delta(1, -2),
      new CodeBase.Delta(-1, -1),
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(1, -1),
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0),
      new CodeBase.Delta(1, 0)
    },
    {
      new CodeBase.Delta(-2, -2),
      new CodeBase.Delta(-1, -2),
      new CodeBase.Delta(0, -2),
      new CodeBase.Delta(-2, -1),
      new CodeBase.Delta(-1, -1),
      new CodeBase.Delta(0, -1),
      new CodeBase.Delta(-2, 0),
      new CodeBase.Delta(-1, 0),
      new CodeBase.Delta(0, 0)
    }
  };

  public CodeBase(string text, XSize size, CodeDirection direction)
  {
    this._text = text;
    this._size = size;
    this._direction = direction;
  }

  public XSize Size
  {
    get => this._size;
    set => this._size = value;
  }

  public string Text
  {
    get => this._text;
    set
    {
      this.CheckCode(value);
      this._text = value;
    }
  }

  public AnchorType Anchor
  {
    get => this._anchor;
    set => this._anchor = value;
  }

  public CodeDirection Direction
  {
    get => this._direction;
    set => this._direction = value;
  }

  protected abstract void CheckCode(string text);

  public static XVector CalcDistance(AnchorType oldType, AnchorType newType, XSize size)
  {
    XVector xvector;
    if (oldType == newType)
    {
      xvector = new XVector();
    }
    else
    {
      CodeBase.Delta delta = CodeBase.Deltas[(int) oldType, (int) newType];
      xvector = new XVector(size.Width / 2.0 * (double) delta.X, size.Height / 2.0 * (double) delta.Y);
    }
    return xvector;
  }

  private struct Delta(int x, int y)
  {
    public readonly int X = x;
    public readonly int Y = y;
  }
}
