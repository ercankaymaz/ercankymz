using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ACadSharp.Entities;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.IO.SVG;

[Obsolete("is it needed? defs block? styles?")]
internal class SvgDocumentBuilder : SvgXmlWriter
{
	public SvgXmlWriter EntitiesWriter { get; set; }

	public Dictionary<string, SvgXmlWriter> LineTypeWriters { get; } = new Dictionary<string, SvgXmlWriter>();

	public SvgDocumentBuilder(Stream stream, Encoding encoding, SvgConfiguration configuration)
		: base(stream, encoding, configuration)
	{
	}

	public new void WriteLayout(Layout layout)
	{
		base.Units = layout.PaperUnits.ToUnits();
		double x = layout.PaperWidth;
		double y = layout.PaperHeight;
		PlotRotation paperRotation = layout.PaperRotation;
		if (paperRotation == PlotRotation.Degrees90 || paperRotation == PlotRotation.Degrees270)
		{
			x = layout.PaperHeight;
			y = layout.PaperWidth;
		}
		XYZ zero = XYZ.Zero;
		XYZ max = new XYZ(x, y, 0.0);
		BoundingBox box = new BoundingBox(zero, max);
		XYZ xYZ = base.Layout.UnprintableMargin.BottomLeftCorner.Convert<XYZ>();
		new BoundingBox(xYZ, base.Layout.UnprintableMargin.TopCorner.Convert<XYZ>());
		startDocument(box);
		Transform transform = new Transform(xYZ.ToPixelSize(base.Units), new XYZ(layout.PrintScale), XYZ.Zero);
		foreach (Entity entity in layout.AssociatedBlock.Entities)
		{
			writeEntity(entity, transform);
		}
		endDocument();
	}

	private void writeLineType(LineType lineType)
	{
		if (!LineTypeWriters.TryGetValue(lineType.Name, out var value))
		{
			value = createWriter();
			LineTypeWriters.Add(lineType.Name, value);
			value.WriteStartElement("defs");
			value.WriteEndElement();
		}
	}

	private SvgXmlWriter createWriter()
	{
		SvgXmlWriter svgXmlWriter = new SvgXmlWriter(new MemoryStream(), base.Configuration);
		svgXmlWriter.Formatting = Formatting.Indented;
		svgXmlWriter.OnNotification += base.triggerNotification;
		return svgXmlWriter;
	}

	private void startDocument(BoundingBox box)
	{
		WriteStartDocument();
		WriteStartElement("svg");
		WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
		WriteAttributeString("width", box.Max.X - box.Min.X);
		WriteAttributeString("height", box.Max.Y - box.Min.Y);
		WriteStartAttribute("viewBox");
		WriteValue(box.Min.X.ToSvg(base.Units));
		WriteValue(" ");
		WriteValue(box.Min.Y.ToSvg(base.Units));
		WriteValue(" ");
		WriteValue((box.Max.X - box.Min.X).ToSvg(base.Units));
		WriteValue(" ");
		WriteValue((box.Max.Y - box.Min.Y).ToSvg(base.Units));
		WriteEndAttribute();
		WriteAttributeString("transform", "scale(1,-1)");
		if (base.Layout != null)
		{
			WriteAttributeString("style", "background-color:white");
		}
	}

	private void endDocument()
	{
		WriteEndElement();
		WriteEndDocument();
		Close();
	}
}
