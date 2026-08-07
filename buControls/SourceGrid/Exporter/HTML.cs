// Decompiled with JetBrains decompiler
// Type: SourceGrid.Exporter.HTML
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using SourceGrid.Cells;
using SourceGrid.Cells.Models;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml;

#nullable disable
namespace SourceGrid.Exporter;

public class HTML
{
  protected ExportHTMLMode m_Mode = ExportHTMLMode.Default;
  protected Stream m_Stream;
  protected string m_ImageFullPath;
  protected string m_ImageRelativePath;
  protected Hashtable m_EmbeddedImagesPath = new Hashtable();

  public HTML(
    ExportHTMLMode p_Mode,
    string p_ImageFullPath,
    string p_ImageRelativePath,
    Stream p_HtmlStream)
  {
    this.m_Mode = p_Mode;
    this.m_Stream = p_HtmlStream;
    this.m_ImageFullPath = p_ImageFullPath;
    this.m_ImageRelativePath = p_ImageRelativePath;
  }

  public virtual ExportHTMLMode Mode
  {
    get => this.m_Mode;
    set => this.m_Mode = value;
  }

  public virtual string[] EmbeddedImagesPath
  {
    get
    {
      string[] embeddedImagesPath = new string[this.m_EmbeddedImagesPath.Count];
      this.m_EmbeddedImagesPath.Values.CopyTo((Array) embeddedImagesPath, 0);
      return embeddedImagesPath;
    }
  }

  public virtual void ClearEmbeddedImages() => this.m_EmbeddedImagesPath.Clear();

  public virtual Stream Stream => this.m_Stream;

  public virtual string ExportImage(System.Drawing.Image p_Image)
  {
    string filename;
    if (this.m_EmbeddedImagesPath.ContainsKey((object) p_Image))
    {
      filename = (string) this.m_EmbeddedImagesPath[(object) p_Image];
    }
    else
    {
      filename = Path.Combine(this.m_ImageFullPath, Path.GetTempFileName() + ".jpg");
      p_Image.Save(filename, ImageFormat.Jpeg);
      this.m_EmbeddedImagesPath.Add((object) p_Image, (object) filename);
    }
    return filename.Replace(this.m_ImageFullPath, this.m_ImageRelativePath);
  }

  public static string ColorToHTML(Color p_Color)
  {
    return ColorTranslator.ToHtml(Color.FromArgb((int) p_Color.A, (int) p_Color.R, (int) p_Color.G, (int) p_Color.B));
  }

  public static string BorderToHTMLStyle(BorderLine p_Border)
  {
    return (double) p_Border.Width <= 0.0 ? "none" : $"{p_Border.Width.ToString()}px solid {HTML.ColorToHTML(p_Border.Color)}";
  }

  public static string BorderToHTMLStyle(IBorder border)
  {
    string htmlStyle;
    if (border is RectangleBorder rectangleBorder)
      htmlStyle = $"border-top:{HTML.BorderToHTMLStyle(rectangleBorder.Top)};border-right:{HTML.BorderToHTMLStyle(rectangleBorder.Right)};border-bottom:{HTML.BorderToHTMLStyle(rectangleBorder.Bottom)};border-left:{HTML.BorderToHTMLStyle(rectangleBorder.Left)};";
    else
      htmlStyle = string.Empty;
    return htmlStyle;
  }

  public static void ExportHTML_Element_Font(
    XmlTextWriter p_Writer,
    string p_DisplayText,
    Font p_Font)
  {
    if (p_Font != null)
    {
      p_Writer.WriteAttributeString("style", $"font-size:{p_Font.SizeInPoints.ToString()}pt");
      if (p_Font.Bold)
        p_Writer.WriteStartElement("b");
      if (p_Font.Underline)
        p_Writer.WriteStartElement("u");
      if (p_Font.Italic)
        p_Writer.WriteStartElement("i");
    }
    if ((p_DisplayText == null ? 1 : (p_DisplayText.Trim().Length <= 0 ? 1 : 0)) != 0)
      p_Writer.WriteRaw("&nbsp;");
    else
      p_Writer.WriteString(p_DisplayText);
    if (p_Font == null)
      return;
    if (p_Font.Italic)
      p_Writer.WriteEndElement();
    if (p_Font.Underline)
      p_Writer.WriteEndElement();
    if (!p_Font.Bold)
      return;
    p_Writer.WriteEndElement();
  }

  public void Export(GridVirtual grid)
  {
    XmlTextWriter writer = new XmlTextWriter(this.Stream, Encoding.UTF8);
    if ((this.Mode & ExportHTMLMode.HTMLAndBody) == ExportHTMLMode.HTMLAndBody)
    {
      writer.WriteStartElement("html");
      writer.WriteStartElement("body");
    }
    writer.WriteStartElement("table");
    writer.WriteAttributeString("cellspacing", "0");
    writer.WriteAttributeString("cellpadding", "0");
    for (int index1 = 0; index1 < grid.Rows.Count; ++index1)
    {
      writer.WriteStartElement("tr");
      for (int index2 = 0; index2 < grid.Columns.Count; ++index2)
      {
        ICellVirtual cell = grid.GetCell(index1, index2);
        Position pPosition = new Position(index1, index2);
        this.ExportHTMLCell(new CellContext(grid, pPosition, cell), writer);
      }
      writer.WriteEndElement();
    }
    writer.WriteEndElement();
    if ((this.Mode & ExportHTMLMode.HTMLAndBody) == ExportHTMLMode.HTMLAndBody)
    {
      writer.WriteEndElement();
      writer.WriteEndElement();
    }
    writer.Flush();
  }

  protected virtual void ExportHTMLCell(CellContext context, XmlTextWriter writer)
  {
    if (context.Cell == null)
    {
      writer.WriteStartElement("td");
      writer.WriteRaw("&nbsp;");
    }
    else
    {
      SourceGrid.Range cellRange = context.Grid.PositionToCellRange(context.Position);
      if (cellRange.Start != context.Position)
        return;
      writer.WriteStartElement("td");
      if ((cellRange.ColumnsCount > 1 ? 1 : (cellRange.RowsCount > 1 ? 1 : 0)) != 0)
      {
        writer.WriteAttributeString("colspan", cellRange.ColumnsCount.ToString());
        writer.WriteAttributeString("rowspan", cellRange.RowsCount.ToString());
      }
      if (context.Cell.View is SourceGrid.Cells.Views.Cell)
      {
        SourceGrid.Cells.Views.Cell view = (SourceGrid.Cells.Views.Cell) context.Cell.View;
        if ((this.Mode & ExportHTMLMode.CellBackColor) == ExportHTMLMode.CellBackColor)
          writer.WriteAttributeString("bgcolor", HTML.ColorToHTML(context.Cell.View.BackColor));
        string htmlStyle = HTML.BorderToHTMLStyle(view.Border);
        writer.WriteAttributeString("style", htmlStyle);
        writer.WriteAttributeString("align", DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(view.TextAlignment).ToString().ToLower());
        if (DevAge.Drawing.Utilities.IsBottom(view.TextAlignment))
          writer.WriteAttributeString("valign", "bottom");
        else if (DevAge.Drawing.Utilities.IsTop(view.TextAlignment))
          writer.WriteAttributeString("valign", "top");
        else if (DevAge.Drawing.Utilities.IsMiddle(view.TextAlignment))
          writer.WriteAttributeString("valign", "middle");
      }
      if (context.Cell.View is SourceGrid.Cells.Views.CheckBox)
      {
        if (((ICheckBox) context.Cell.Model.FindModel(typeof (ICheckBox))).GetCheckBoxStatus(context).Checked.GetValueOrDefault())
          writer.WriteRaw("<input type=\"checkbox\" checked>");
        else
          writer.WriteRaw("<input type=\"checkbox\">");
      }
      if (context.Cell.View is SourceGrid.Cells.Views.Cell)
      {
        System.Drawing.Image p_Image = (System.Drawing.Image) null;
        IImage model = (IImage) context.Cell.Model.FindModel(typeof (IImage));
        if (model != null)
          p_Image = model.GetImage(context);
        SourceGrid.Cells.Views.Cell view = (SourceGrid.Cells.Views.Cell) context.Cell.View;
        if (p_Image != null)
        {
          writer.WriteStartElement("img");
          writer.WriteAttributeString("align", DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(view.ImageAlignment).ToString().ToLower());
          writer.WriteAttributeString("src", this.ExportImage(p_Image));
          writer.WriteEndElement();
        }
        writer.WriteStartElement("font");
        writer.WriteAttributeString("color", HTML.ColorToHTML(view.ForeColor));
        this.ExportHTMLCellContent(context, writer);
        writer.WriteEndElement();
      }
      else
        this.ExportHTMLCellContent(context, writer);
      writer.WriteEndElement();
    }
  }

  protected virtual void ExportHTMLCellContent(CellContext context, XmlTextWriter writer)
  {
    if (context.Cell.View is SourceGrid.Cells.Views.CheckBox)
    {
      CheckBoxStatus checkBoxStatus = ((ICheckBox) context.Cell.Model.FindModel(typeof (ICheckBox))).GetCheckBoxStatus(context);
      HTML.ExportHTML_Element_Font(writer, checkBoxStatus.Caption, context.Cell.View.GetDrawingFont(context.Grid));
    }
    else
      HTML.ExportHTML_Element_Font(writer, context.DisplayText, context.Cell.View.GetDrawingFont(context.Grid));
  }
}
