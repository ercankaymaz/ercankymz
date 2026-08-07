// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.Code3of9Standard
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public class Code3of9Standard : ThickThinBarCode
{
  private static readonly bool[][] Lines = new bool[44][]
  {
    new bool[9]
    {
      false,
      false,
      false,
      true,
      true,
      false,
      true,
      false,
      false
    },
    new bool[9]
    {
      true,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      false,
      false,
      true,
      true,
      false,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      true,
      true,
      false,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      true,
      true,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      true,
      true,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      true,
      true,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      true,
      false,
      false,
      true,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      true,
      false,
      false,
      true,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      true,
      false,
      false,
      true,
      false,
      false
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      false,
      true,
      false,
      false,
      true
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      false,
      true,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      true,
      false,
      false,
      true,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      true,
      true,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      true,
      true,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      true,
      true,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      false,
      true,
      true,
      false,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      false,
      true,
      true,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      false,
      true,
      true,
      false,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      true,
      true,
      true,
      false,
      false
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      true
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      true,
      true
    },
    new bool[9]
    {
      true,
      false,
      true,
      false,
      false,
      false,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      true,
      false,
      false,
      true,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      true,
      false,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      true,
      false,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      true,
      true
    },
    new bool[9]
    {
      true,
      false,
      false,
      false,
      false,
      false,
      true,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      true,
      false,
      false,
      false,
      true,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      true,
      false
    },
    new bool[9]
    {
      true,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      false,
      true,
      true,
      false,
      false,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      true,
      true,
      false,
      false,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      false,
      true,
      false,
      false,
      false,
      true
    },
    new bool[9]
    {
      true,
      true,
      false,
      false,
      true,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      true,
      false,
      true,
      false,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      false,
      false,
      false,
      true,
      false,
      true
    },
    new bool[9]
    {
      true,
      true,
      false,
      false,
      false,
      false,
      true,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      true,
      false,
      false,
      false,
      true,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      true,
      false,
      true,
      false,
      false,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      true,
      false,
      false,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      false,
      false,
      true,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      true,
      false
    },
    new bool[9]
    {
      false,
      true,
      false,
      false,
      true,
      false,
      true,
      false,
      false
    }
  };

  public Code3of9Standard()
    : base("", XSize.Empty, CodeDirection.LeftToRight)
  {
  }

  public Code3of9Standard(string code)
    : base(code, XSize.Empty, CodeDirection.LeftToRight)
  {
  }

  public Code3of9Standard(string code, XSize size)
    : base(code, size, CodeDirection.LeftToRight)
  {
  }

  public Code3of9Standard(string code, XSize size, CodeDirection direction)
    : base(code, size, direction)
  {
  }

  private static bool[] ThickThinLines(char ch)
  {
    return Code3of9Standard.Lines["0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*".IndexOf(ch)];
  }

  internal override void CalcThinBarWidth(BarCodeRenderInfo info)
  {
    double num = 13.0 + 6.0 * this.WideNarrowRatio + (3.0 * this.WideNarrowRatio + 7.0) * (double) this.Text.Length;
    info.ThinBarWidth = this.Size.Width / num;
  }

  protected override void CheckCode(string text)
  {
    switch (text)
    {
      case null:
        throw new ArgumentNullException(nameof (text));
      case "":
        throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
      default:
        foreach (char ch in text)
        {
          if ("0123456789ABCDEFGHIJKLMNOP'QRSTUVWXYZ-. $/+%*".IndexOf(ch) < 0)
            throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
        }
        break;
    }
  }

  protected internal override void Render(
    XGraphics gfx,
    XBrush brush,
    XFont font,
    XPoint position)
  {
    XGraphicsState state = gfx.Save();
    BarCodeRenderInfo info = new BarCodeRenderInfo(gfx, brush, font, position);
    this.InitRendering(info);
    info.CurrPosInString = 0;
    info.CurrPos = position - CodeBase.CalcDistance(AnchorType.TopLeft, this.Anchor, this.Size);
    if (this.TurboBit)
      this.RenderTurboBit(info, true);
    this.RenderStart(info);
    while (info.CurrPosInString < this.Text.Length)
    {
      this.RenderNextChar(info);
      this.RenderGap(info, false);
    }
    this.RenderStop(info);
    if (this.TurboBit)
      this.RenderTurboBit(info, false);
    if (this.TextLocation != 0)
      this.RenderText(info);
    gfx.Restore(state);
  }

  private void RenderNextChar(BarCodeRenderInfo info)
  {
    this.RenderChar(info, this.Text[info.CurrPosInString]);
    ++info.CurrPosInString;
  }

  private void RenderChar(BarCodeRenderInfo info, char ch)
  {
    bool[] flagArray = Code3of9Standard.ThickThinLines(ch);
    for (int index = 0; index < 9; index += 2)
    {
      this.RenderBar(info, flagArray[index]);
      if (index < 8)
        this.RenderGap(info, flagArray[index + 1]);
    }
  }

  private void RenderStart(BarCodeRenderInfo info)
  {
    this.RenderChar(info, '*');
    this.RenderGap(info, false);
  }

  private void RenderStop(BarCodeRenderInfo info) => this.RenderChar(info, '*');
}
