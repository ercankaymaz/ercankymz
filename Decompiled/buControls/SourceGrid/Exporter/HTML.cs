using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml;
using DevAge.Drawing;
using DevAge.Windows.Forms;
using SourceGrid.Cells;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Exporter;

public class HTML
{
	protected ExportHTMLMode m_Mode = ExportHTMLMode.Default;

	protected Stream m_Stream;

	protected string m_ImageFullPath;

	protected string m_ImageRelativePath;

	protected Hashtable m_EmbeddedImagesPath = new Hashtable();

	public virtual ExportHTMLMode Mode
	{
		get
		{
			return m_Mode;
		}
		set
		{
			m_Mode = value;
		}
	}

	public virtual string[] EmbeddedImagesPath
	{
		get
		{
			string[] array = new string[m_EmbeddedImagesPath.Count];
			m_EmbeddedImagesPath.Values.CopyTo(array, 0);
			return array;
		}
	}

	public virtual Stream Stream => m_Stream;

	public HTML(ExportHTMLMode p_Mode, string p_ImageFullPath, string p_ImageRelativePath, Stream p_HtmlStream)
	{
		m_Mode = p_Mode;
		m_Stream = p_HtmlStream;
		m_ImageFullPath = p_ImageFullPath;
		m_ImageRelativePath = p_ImageRelativePath;
	}

	public virtual void ClearEmbeddedImages()
	{
		m_EmbeddedImagesPath.Clear();
	}

	public virtual string ExportImage(System.Drawing.Image p_Image)
	{
		string text;
		if (!m_EmbeddedImagesPath.ContainsKey(p_Image))
		{
			text = Path.Combine(m_ImageFullPath, Path.GetTempFileName() + ".jpg");
			p_Image.Save(text, ImageFormat.Jpeg);
			m_EmbeddedImagesPath.Add(p_Image, text);
		}
		else
		{
			text = (string)m_EmbeddedImagesPath[p_Image];
		}
		return text.Replace(m_ImageFullPath, m_ImageRelativePath);
	}

	public static string ColorToHTML(Color p_Color)
	{
		return ColorTranslator.ToHtml(Color.FromArgb(p_Color.A, p_Color.R, p_Color.G, p_Color.B));
	}

	public static string BorderToHTMLStyle(BorderLine p_Border)
	{
		if (!(p_Border.Width > 0f))
		{
			return "none";
		}
		return p_Border.Width + "px solid " + ColorToHTML(p_Border.Color);
	}

	public static string BorderToHTMLStyle(IBorder border)
	{
		if (!(border is RectangleBorder rectangleBorder))
		{
			return string.Empty;
		}
		return "border-top:" + BorderToHTMLStyle(rectangleBorder.Top) + ";border-right:" + BorderToHTMLStyle(rectangleBorder.Right) + ";border-bottom:" + BorderToHTMLStyle(rectangleBorder.Bottom) + ";border-left:" + BorderToHTMLStyle(rectangleBorder.Left) + ";";
	}

	public static void ExportHTML_Element_Font(XmlTextWriter p_Writer, string p_DisplayText, Font p_Font)
	{
		if (p_Font != null)
		{
			p_Writer.WriteAttributeString("style", "font-size:" + p_Font.SizeInPoints + "pt");
			if (p_Font.Bold)
			{
				p_Writer.WriteStartElement("b");
			}
			if (p_Font.Underline)
			{
				p_Writer.WriteStartElement("u");
			}
			if (p_Font.Italic)
			{
				p_Writer.WriteStartElement("i");
			}
		}
		if (p_DisplayText != null && p_DisplayText.Trim().Length > 0)
		{
			p_Writer.WriteString(p_DisplayText);
		}
		else
		{
			p_Writer.WriteRaw("&nbsp;");
		}
		if (p_Font != null)
		{
			if (p_Font.Italic)
			{
				p_Writer.WriteEndElement();
			}
			if (p_Font.Underline)
			{
				p_Writer.WriteEndElement();
			}
			if (p_Font.Bold)
			{
				p_Writer.WriteEndElement();
			}
		}
	}

	public void Export(GridVirtual grid)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(Stream, Encoding.UTF8);
		if ((Mode & ExportHTMLMode.HTMLAndBody) == ExportHTMLMode.HTMLAndBody)
		{
			xmlTextWriter.WriteStartElement("html");
			xmlTextWriter.WriteStartElement("body");
		}
		xmlTextWriter.WriteStartElement("table");
		xmlTextWriter.WriteAttributeString("cellspacing", "0");
		xmlTextWriter.WriteAttributeString("cellpadding", "0");
		for (int i = 0; i < grid.Rows.Count; i++)
		{
			xmlTextWriter.WriteStartElement("tr");
			for (int j = 0; j < grid.Columns.Count; j++)
			{
				ICellVirtual cell = grid.GetCell(i, j);
				Position pPosition = new Position(i, j);
				CellContext context = new CellContext(grid, pPosition, cell);
				ExportHTMLCell(context, xmlTextWriter);
			}
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.WriteEndElement();
		if ((Mode & ExportHTMLMode.HTMLAndBody) == ExportHTMLMode.HTMLAndBody)
		{
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.Flush();
	}

	protected virtual void ExportHTMLCell(CellContext context, XmlTextWriter writer)
	{
		if (context.Cell != null)
		{
			Range range = context.Grid.PositionToCellRange(context.Position);
			if (range.Start != context.Position)
			{
				return;
			}
			writer.WriteStartElement("td");
			if (range.ColumnsCount > 1 || range.RowsCount > 1)
			{
				writer.WriteAttributeString("colspan", range.ColumnsCount.ToString());
				writer.WriteAttributeString("rowspan", range.RowsCount.ToString());
			}
			if (context.Cell.View is SourceGrid.Cells.Views.Cell)
			{
				SourceGrid.Cells.Views.Cell cell = (SourceGrid.Cells.Views.Cell)context.Cell.View;
				if ((Mode & ExportHTMLMode.CellBackColor) == ExportHTMLMode.CellBackColor)
				{
					writer.WriteAttributeString("bgcolor", ColorToHTML(context.Cell.View.BackColor));
				}
				string text = "";
				text = BorderToHTMLStyle(cell.Border);
				writer.WriteAttributeString("style", text);
				writer.WriteAttributeString("align", DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(cell.TextAlignment).ToString().ToLower());
				if (!DevAge.Drawing.Utilities.IsBottom(cell.TextAlignment))
				{
					if (!DevAge.Drawing.Utilities.IsTop(cell.TextAlignment))
					{
						if (DevAge.Drawing.Utilities.IsMiddle(cell.TextAlignment))
						{
							writer.WriteAttributeString("valign", "middle");
						}
					}
					else
					{
						writer.WriteAttributeString("valign", "top");
					}
				}
				else
				{
					writer.WriteAttributeString("valign", "bottom");
				}
			}
			if (context.Cell.View is SourceGrid.Cells.Views.CheckBox)
			{
				ICheckBox checkBox = (ICheckBox)context.Cell.Model.FindModel(typeof(ICheckBox));
				if (checkBox.GetCheckBoxStatus(context).Checked != true)
				{
					writer.WriteRaw("<input type=\"checkbox\">");
				}
				else
				{
					writer.WriteRaw("<input type=\"checkbox\" checked>");
				}
			}
			if (!(context.Cell.View is SourceGrid.Cells.Views.Cell))
			{
				ExportHTMLCellContent(context, writer);
			}
			else
			{
				System.Drawing.Image image = null;
				IImage image2 = (IImage)context.Cell.Model.FindModel(typeof(IImage));
				if (image2 != null)
				{
					image = image2.GetImage(context);
				}
				SourceGrid.Cells.Views.Cell cell2 = (SourceGrid.Cells.Views.Cell)context.Cell.View;
				if (image != null)
				{
					writer.WriteStartElement("img");
					writer.WriteAttributeString("align", DevAge.Windows.Forms.Utilities.ContentToHorizontalAlignment(cell2.ImageAlignment).ToString().ToLower());
					writer.WriteAttributeString("src", ExportImage(image));
					writer.WriteEndElement();
				}
				writer.WriteStartElement("font");
				writer.WriteAttributeString("color", ColorToHTML(cell2.ForeColor));
				ExportHTMLCellContent(context, writer);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		else
		{
			writer.WriteStartElement("td");
			writer.WriteRaw("&nbsp;");
		}
	}

	protected virtual void ExportHTMLCellContent(CellContext context, XmlTextWriter writer)
	{
		if (!(context.Cell.View is SourceGrid.Cells.Views.CheckBox))
		{
			ExportHTML_Element_Font(writer, context.DisplayText, context.Cell.View.GetDrawingFont(context.Grid));
			return;
		}
		ICheckBox checkBox = (ICheckBox)context.Cell.Model.FindModel(typeof(ICheckBox));
		ExportHTML_Element_Font(writer, checkBox.GetCheckBoxStatus(context).Caption, context.Cell.View.GetDrawingFont(context.Grid));
	}
}
