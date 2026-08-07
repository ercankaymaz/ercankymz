// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.RectangleBorder
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DevAge.Drawing;

[Serializable]
public struct RectangleBorder : ICloneable, IBorder
{
  public static readonly RectangleBorder NoBorder = new RectangleBorder(BorderLine.NoBorder);
  public static readonly RectangleBorder RectangleBlack1Width = new RectangleBorder(new BorderLine(Color.Black, 1f));
  public BorderLine Top;
  public BorderLine Bottom;
  public BorderLine Left;
  public BorderLine Right;

  public RectangleBorder(BorderLine p_Border)
  {
    this.Top = p_Border;
    this.Bottom = p_Border;
    this.Left = p_Border;
    this.Right = p_Border;
  }

  public RectangleBorder(BorderLine p_Right, BorderLine p_Bottom)
  {
    this.Right = p_Right;
    this.Bottom = p_Bottom;
    this.Top = new BorderLine(Color.White, 0.0f);
    this.Left = new BorderLine(Color.White, 0.0f);
  }

  public RectangleBorder(
    BorderLine p_Top,
    BorderLine p_Bottom,
    BorderLine p_Left,
    BorderLine p_Right)
  {
    this.Top = p_Top;
    this.Bottom = p_Bottom;
    this.Left = p_Left;
    this.Right = p_Right;
  }

  public RectangleBorder SetColor(Color p_Color)
  {
    this.Top = new BorderLine(p_Color, this.Top.Width, this.Top.DashStyle, this.Top.Padding);
    this.Bottom = new BorderLine(p_Color, this.Bottom.Width, this.Bottom.DashStyle, this.Bottom.Padding);
    this.Left = new BorderLine(p_Color, this.Left.Width, this.Left.DashStyle, this.Left.Padding);
    this.Right = new BorderLine(p_Color, this.Right.Width, this.Right.DashStyle, this.Right.Padding);
    return this;
  }

  public RectangleBorder SetDashStyle(DashStyle dashStyle)
  {
    this.Top = new BorderLine(this.Top.Color, this.Top.Width, dashStyle, this.Top.Padding);
    this.Bottom = new BorderLine(this.Bottom.Color, this.Bottom.Width, dashStyle, this.Bottom.Padding);
    this.Left = new BorderLine(this.Left.Color, this.Left.Width, dashStyle, this.Left.Padding);
    this.Right = new BorderLine(this.Right.Color, this.Right.Width, dashStyle, this.Right.Padding);
    return this;
  }

  public RectangleBorder SetWidth(int p_Width)
  {
    this.Top = new BorderLine(this.Top.Color, (float) p_Width, this.Top.DashStyle, this.Top.Padding);
    this.Bottom = new BorderLine(this.Bottom.Color, (float) p_Width, this.Bottom.DashStyle, this.Bottom.Padding);
    this.Left = new BorderLine(this.Left.Color, (float) p_Width, this.Left.DashStyle, this.Left.Padding);
    this.Right = new BorderLine(this.Right.Color, (float) p_Width, this.Right.DashStyle, this.Right.Padding);
    return this;
  }

  public RectangleBorder SetPadding(int padding)
  {
    this.Top = new BorderLine(this.Top.Color, this.Top.Width, this.Top.DashStyle, (float) padding);
    this.Bottom = new BorderLine(this.Bottom.Color, this.Bottom.Width, this.Bottom.DashStyle, (float) padding);
    this.Left = new BorderLine(this.Left.Color, this.Left.Width, this.Left.DashStyle, (float) padding);
    this.Right = new BorderLine(this.Right.Color, this.Right.Width, this.Right.DashStyle, (float) padding);
    return this;
  }

  public override string ToString()
  {
    return $"Top:{this.Top.ToString()} Bottom:{this.Bottom.ToString()} Left:{this.Left.ToString()} Right:{this.Right.ToString()}";
  }

  public override bool Equals(object obj)
  {
    bool flag;
    if (obj == null)
      flag = false;
    else if (obj.GetType() != this.GetType())
    {
      flag = false;
    }
    else
    {
      RectangleBorder rectangleBorder = (RectangleBorder) obj;
      flag = (!(rectangleBorder.Left == this.Left) || !(rectangleBorder.Bottom == this.Bottom) || !(rectangleBorder.Top == this.Top) ? 0 : (rectangleBorder.Right == this.Right ? 1 : 0)) != 0;
    }
    return flag;
  }

  public override int GetHashCode() => this.Left.GetHashCode();

  public static bool operator ==(RectangleBorder a, RectangleBorder b) => a.Equals((object) b);

  public static bool operator !=(RectangleBorder a, RectangleBorder b) => !a.Equals((object) b);

  public static RectangleBorder CreateInsetBorder(
    int p_width,
    Color p_ShadowColor,
    Color p_LightColor)
  {
    return new RectangleBorder(new BorderLine(Color.White))
    {
      Top = new BorderLine(p_ShadowColor, (float) p_width),
      Left = new BorderLine(p_ShadowColor, (float) p_width),
      Bottom = new BorderLine(p_LightColor, (float) p_width),
      Right = new BorderLine(p_LightColor, (float) p_width)
    };
  }

  public static RectangleBorder CreateRaisedBorder(
    int p_width,
    Color p_ShadowColor,
    Color p_LightColor)
  {
    return new RectangleBorder(new BorderLine(Color.White))
    {
      Top = new BorderLine(p_LightColor, (float) p_width),
      Left = new BorderLine(p_LightColor, (float) p_width),
      Bottom = new BorderLine(p_ShadowColor, (float) p_width),
      Right = new BorderLine(p_ShadowColor, (float) p_width)
    };
  }

  public RectangleF GetContentRectangle(RectangleF backGroundArea)
  {
    backGroundArea.Y += this.Top.Width + this.Top.Padding;
    backGroundArea.X += this.Left.Width + this.Left.Padding;
    backGroundArea.Width -= this.Left.Width + this.Right.Width + this.Left.Padding + this.Right.Padding;
    backGroundArea.Height -= this.Top.Width + this.Bottom.Width + this.Top.Padding + this.Bottom.Padding;
    return backGroundArea;
  }

  public SizeF GetExtent(SizeF contentSize)
  {
    contentSize.Width += this.Left.Width + this.Right.Width + this.Left.Padding + this.Right.Padding;
    contentSize.Height += this.Top.Width + this.Bottom.Width + this.Top.Padding + this.Bottom.Padding;
    return contentSize;
  }

  public void Draw(GraphicsCache graphics, RectangleF rectangle)
  {
    RectangleBorder rectangleBorder = this;
    rectangle = new RectangleF(rectangle.X + this.Left.Padding, rectangle.Y + this.Top.Padding, rectangle.Width - (this.Left.Padding + this.Right.Padding), rectangle.Height - (this.Top.Padding + this.Bottom.Padding));
    if (((double) rectangle.Width <= 0.0 ? 1 : ((double) rectangle.Height <= 0.0 ? 1 : 0)) != 0)
      return;
    PensCache pensCache = graphics.PensCache;
    if ((double) rectangleBorder.Left.Width > 0.0)
    {
      Pen pen = pensCache.GetPen(rectangleBorder.Left.Color, rectangleBorder.Left.Width, rectangleBorder.Left.DashStyle);
      float x;
      float y;
      if ((double) rectangleBorder.Left.Width > 1.0)
      {
        x = rectangle.X + rectangleBorder.Left.Width / 2f;
        y = rectangle.Bottom;
      }
      else
      {
        x = rectangle.X;
        y = rectangle.Bottom - 1f;
      }
      graphics.Graphics.DrawLine(pen, new PointF(x, rectangle.Y), new PointF(x, y));
    }
    if ((double) rectangleBorder.Right.Width > 0.0)
    {
      Pen pen = pensCache.GetPen(rectangleBorder.Right.Color, rectangleBorder.Right.Width, rectangleBorder.Right.DashStyle);
      float x;
      float y;
      if ((double) rectangleBorder.Right.Width > 1.0)
      {
        x = rectangle.Right - rectangleBorder.Right.Width / 2f;
        y = rectangle.Bottom;
      }
      else
      {
        x = rectangle.Right - 1f;
        y = rectangle.Bottom - 1f;
      }
      graphics.Graphics.DrawLine(pen, new PointF(x, rectangle.Y), new PointF(x, y));
    }
    if ((double) rectangleBorder.Top.Width > 0.0)
    {
      Pen pen = pensCache.GetPen(rectangleBorder.Top.Color, rectangleBorder.Top.Width, rectangleBorder.Top.DashStyle);
      float y;
      float x;
      if ((double) rectangleBorder.Top.Width > 1.0)
      {
        y = rectangle.Y + rectangleBorder.Top.Width / 2f;
        x = rectangle.Right;
      }
      else
      {
        y = rectangle.Y;
        x = rectangle.Right - 1f;
      }
      graphics.Graphics.DrawLine(pen, new PointF(rectangle.X, y), new PointF(x, y));
    }
    if ((double) rectangleBorder.Bottom.Width <= 0.0)
      return;
    Pen pen1 = pensCache.GetPen(rectangleBorder.Bottom.Color, rectangleBorder.Bottom.Width, rectangleBorder.Bottom.DashStyle);
    float y1;
    float x1;
    if ((double) rectangleBorder.Bottom.Width > 1.0)
    {
      y1 = rectangle.Bottom - rectangleBorder.Bottom.Width / 2f;
      x1 = rectangle.Right;
    }
    else
    {
      y1 = rectangle.Bottom - 1f;
      x1 = rectangle.Right - 1f;
    }
    graphics.Graphics.DrawLine(pen1, new PointF(rectangle.X, y1), new PointF(x1, y1));
  }

  public RectanglePartType GetPointPartType(
    RectangleF area,
    PointF point,
    out float distanceFromBorder)
  {
    RectanglePartType pointPartType;
    if (!area.Contains(point))
    {
      distanceFromBorder = -1f;
      pointPartType = RectanglePartType.None;
    }
    else
    {
      RectangleF contentRectangle = this.GetContentRectangle(area);
      if (contentRectangle.Contains(point))
      {
        distanceFromBorder = -1f;
        pointPartType = RectanglePartType.ContentArea;
      }
      else if (((double) point.X < (double) area.Left ? 0 : ((double) point.X < (double) contentRectangle.Left ? 1 : 0)) != 0)
      {
        distanceFromBorder = point.X - area.Left;
        pointPartType = RectanglePartType.LeftBorder;
      }
      else if (((double) point.X >= (double) area.Right ? 0 : ((double) point.X >= (double) contentRectangle.Right ? 1 : 0)) != 0)
      {
        distanceFromBorder = area.Right - point.X;
        pointPartType = RectanglePartType.RightBorder;
      }
      else if (((double) point.Y < (double) area.Top ? 0 : ((double) point.Y < (double) contentRectangle.Top ? 1 : 0)) != 0)
      {
        distanceFromBorder = point.Y - area.Top;
        pointPartType = RectanglePartType.TopBorder;
      }
      else if (((double) point.Y >= (double) area.Bottom ? 0 : ((double) point.Y >= (double) contentRectangle.Bottom ? 1 : 0)) != 0)
      {
        distanceFromBorder = area.Bottom - point.Y;
        pointPartType = RectanglePartType.BottomBorder;
      }
      else
      {
        distanceFromBorder = -1f;
        pointPartType = RectanglePartType.None;
      }
    }
    return pointPartType;
  }

  public object Clone() => this.MemberwiseClone();
}
