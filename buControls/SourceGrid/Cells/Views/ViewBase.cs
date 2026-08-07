// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.ViewBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public abstract class ViewBase : ContainerBase, ICloneable, IView
{
  public static RectangleBorder DefaultBorder = new RectangleBorder(new BorderLine(Color.LightGray, 1f), new BorderLine(Color.LightGray, 1f));
  public static DevAge.Drawing.Padding DefaultPadding = new DevAge.Drawing.Padding(2f);
  public static Color DefaultBackColor = Color.FromKnownColor(KnownColor.Window);
  public static Color DefaultForeColor = Color.FromKnownColor(KnownColor.WindowText);
  public static DevAge.Drawing.ContentAlignment DefaultAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
  private bool m_ImageStretch = false;
  private DevAge.Drawing.ContentAlignment m_ImageAlignment;
  private Font m_Font = (Font) null;
  private Color m_ForeColor;
  private bool mWordWrap = false;
  private TrimmingMode mTrimmingMode = TrimmingMode.Char;
  private DevAge.Drawing.ContentAlignment mTextAlignment;

  public ViewBase()
  {
    this.Background = (IVisualElement) new BackgroundSolid();
    this.Padding = ViewBase.DefaultPadding;
    this.ForeColor = ViewBase.DefaultForeColor;
    this.BackColor = ViewBase.DefaultBackColor;
    this.Border = (IBorder) ViewBase.DefaultBorder;
    this.TextAlignment = ViewBase.DefaultAlignment;
    this.ImageAlignment = ViewBase.DefaultAlignment;
  }

  public ViewBase(ViewBase p_Source)
    : base((ContainerBase) p_Source)
  {
    this.ForeColor = p_Source.ForeColor;
    this.BackColor = p_Source.BackColor;
    this.Border = p_Source.Border;
    this.Padding = p_Source.Padding;
    Font font = (Font) null;
    if (p_Source.Font != null)
      font = (Font) p_Source.Font.Clone();
    this.Font = font;
    this.WordWrap = p_Source.WordWrap;
    this.TextAlignment = p_Source.TextAlignment;
    this.TrimmingMode = p_Source.TrimmingMode;
    this.ImageAlignment = p_Source.ImageAlignment;
    this.ImageStretch = p_Source.ImageStretch;
  }

  public bool ImageStretch
  {
    get => this.m_ImageStretch;
    set => this.m_ImageStretch = value;
  }

  public DevAge.Drawing.ContentAlignment ImageAlignment
  {
    get => this.m_ImageAlignment;
    set => this.m_ImageAlignment = value;
  }

  public Font Font
  {
    get => this.m_Font;
    set => this.m_Font = value;
  }

  public Color ForeColor
  {
    get => this.m_ForeColor;
    set => this.m_ForeColor = value;
  }

  public bool WordWrap
  {
    get => this.mWordWrap;
    set => this.mWordWrap = value;
  }

  public TrimmingMode TrimmingMode
  {
    get => this.mTrimmingMode;
    set => this.mTrimmingMode = value;
  }

  public DevAge.Drawing.ContentAlignment TextAlignment
  {
    get => this.mTextAlignment;
    set => this.mTextAlignment = value;
  }

  public virtual Font GetDrawingFont(GridVirtual grid) => this.Font != null ? this.Font : grid.Font;

  public Color BackColor
  {
    get
    {
      return !(this.Background is BackgroundSolid) ? ViewBase.DefaultBackColor : ((BackgroundSolid) this.Background).BackColor;
    }
    set
    {
      if (!(this.Background is BackgroundSolid))
        return;
      ((BackgroundSolid) this.Background).BackColor = value;
    }
  }

  public new IBorder Border
  {
    get => base.Border;
    set => base.Border = value;
  }

  public new DevAge.Drawing.Padding Padding
  {
    get => base.Padding;
    set => base.Padding = value;
  }

  public new ElementsDrawMode ElementsDrawMode
  {
    get => base.ElementsDrawMode;
    set => base.ElementsDrawMode = value;
  }

  public void DrawCell(CellContext cellContext, GraphicsCache graphics, RectangleF rectangle)
  {
    this.PrepareView(cellContext);
    this.Draw(graphics, rectangle);
  }

  protected virtual void PrepareView(CellContext context)
  {
  }

  public Size Measure(CellContext cellContext, Size maxLayoutArea)
  {
    using (MeasureHelper measure = new MeasureHelper((Control) cellContext.Grid))
    {
      this.PrepareView(cellContext);
      return Size.Ceiling(this.Measure(measure, SizeF.Empty, (SizeF) maxLayoutArea));
    }
  }

  public new IVisualElement Background
  {
    get => base.Background;
    set => base.Background = value;
  }
}
