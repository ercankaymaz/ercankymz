// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XStringFormats
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing;

public static class XStringFormats
{
  public static XStringFormat Default => XStringFormats.BaseLineLeft;

  public static XStringFormat BaseLineLeft
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.BaseLine
      };
    }
  }

  public static XStringFormat TopLeft
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.Near
      };
    }
  }

  public static XStringFormat CenterLeft
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.Center
      };
    }
  }

  public static XStringFormat BottomLeft
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.Far
      };
    }
  }

  public static XStringFormat BaseLineCenter
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Center,
        LineAlignment = XLineAlignment.BaseLine
      };
    }
  }

  public static XStringFormat TopCenter
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Center,
        LineAlignment = XLineAlignment.Near
      };
    }
  }

  public static XStringFormat Center
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Center,
        LineAlignment = XLineAlignment.Center
      };
    }
  }

  public static XStringFormat BottomCenter
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Center,
        LineAlignment = XLineAlignment.Far
      };
    }
  }

  public static XStringFormat BaseLineRight
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Far,
        LineAlignment = XLineAlignment.BaseLine
      };
    }
  }

  public static XStringFormat TopRight
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Far,
        LineAlignment = XLineAlignment.Near
      };
    }
  }

  public static XStringFormat CenterRight
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Far,
        LineAlignment = XLineAlignment.Center
      };
    }
  }

  public static XStringFormat BottomRight
  {
    get
    {
      return new XStringFormat()
      {
        Alignment = XStringAlignment.Far,
        LineAlignment = XLineAlignment.Far
      };
    }
  }
}
