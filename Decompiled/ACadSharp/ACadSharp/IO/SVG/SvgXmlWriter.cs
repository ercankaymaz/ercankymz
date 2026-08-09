using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using ACadSharp.Entities;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.IO.SVG;

internal class SvgXmlWriter : XmlTextWriter
{
	public SvgConfiguration Configuration { get; } = new SvgConfiguration();

	public Layout Layout { get; set; }

	public UnitsType Units { get; protected set; }

	public event NotificationEventHandler OnNotification;

	public SvgXmlWriter(Stream stream, SvgConfiguration configuration)
		: this(stream, null, configuration)
	{
	}

	public SvgXmlWriter(Stream stream, Encoding? encoding, SvgConfiguration configuration)
		: base(stream, encoding)
	{
		Configuration = configuration;
	}

	public void WriteAttributeString(string localName, double value)
	{
		WriteAttributeString(localName, value, Units);
	}

	public void WriteAttributeString(string localName, double value, UnitsType units)
	{
		WriteAttributeString(localName, value.ToSvg(units));
	}

	public void WriteBlock(BlockRecord record)
	{
		Units = record.Units;
		BoundingBox boundingBox = record.GetBoundingBox();
		startDocument(boundingBox, boundingBox, Units);
		foreach (Entity entity in record.Entities)
		{
			writeEntity(entity);
		}
		endDocument();
	}

	public void WriteLayout(Layout layout)
	{
		Layout = layout;
		Units = layout.PaperUnits.ToUnits();
		double x = layout.PaperWidth;
		double y = layout.PaperHeight;
		PlotRotation paperRotation = layout.PaperRotation;
		if (paperRotation == PlotRotation.Degrees90 || paperRotation == PlotRotation.Degrees270)
		{
			x = layout.PaperHeight;
			y = layout.PaperWidth;
		}
		XYZ zero = XYZ.Zero;
		XYZ xYZ = new XYZ(x, y, 0.0);
		BoundingBox box = new BoundingBox(zero, xYZ);
		XYZ xYZ2 = layout.UnprintableMargin.BottomLeftCorner.Convert<XYZ>();
		XYZ max = xYZ - layout.UnprintableMargin.TopCorner.Convert<XYZ>();
		new BoundingBox(xYZ2, max);
		startDocument(box, null, UnitsType.Millimeters);
		Transform transform = new Transform(xYZ2.ToPixelSize(UnitsType.Millimeters), new XYZ(layout.PrintScale), XYZ.Zero);
		foreach (Entity entity in layout.AssociatedBlock.Entities)
		{
			writeEntity(entity, transform);
		}
		endDocument();
	}

	protected void notify(string message, NotificationType type, Exception ex = null)
	{
		this.OnNotification?.Invoke(this, new NotificationEventArgs(message, type, ex));
	}

	protected void triggerNotification(object sender, NotificationEventArgs e)
	{
		this.OnNotification?.Invoke(sender, e);
	}

	protected void writeEntity(Entity entity, Transform transform)
	{
		WriteComment($"{entity.ObjectName} | {entity.Handle}");
		if (!(entity is Arc arc))
		{
			if (!(entity is Line line))
			{
				if (!(entity is Point point))
				{
					if (!(entity is Circle circle))
					{
						if (!(entity is Ellipse ellipse))
						{
							if (!(entity is Hatch hatch))
							{
								if (!(entity is Insert insert))
								{
									if (!(entity is IPolyline polyline))
									{
										if (entity is IText text)
										{
											writeText(text, transform);
										}
										else
										{
											notify("[" + entity.ObjectName + "] Entity not implemented.", NotificationType.NotImplemented);
										}
									}
									else
									{
										writePolyline(polyline, transform);
									}
								}
								else
								{
									writeInsert(insert, transform);
								}
							}
							else
							{
								writeHatch(hatch, transform);
							}
						}
						else
						{
							writeEllipse(ellipse, transform);
						}
					}
					else
					{
						writeCircle(circle, transform);
					}
				}
				else
				{
					writePoint(point, transform);
				}
			}
			else
			{
				writeLine(line, transform);
			}
		}
		else
		{
			writeArc(arc, transform);
		}
	}

	private string colorSvg(Color color)
	{
		if (Layout != null && color.Equals(Color.Default))
		{
			color = Color.Black;
		}
		return $"rgb({color.R},{color.G},{color.B})";
	}

	private string createPath(params IEnumerable<IPolyline> polylines)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (IPolyline polyline in polylines)
		{
			XY[] array = polyline.GetPoints<XY>().ToArray();
			if (array.Any())
			{
				XY value = array[0];
				stringBuilder.Append("M " + value.ToPixelSize(Units).ToSvg() + " ");
				for (int i = 1; i < array.Length; i++)
				{
					value = array[i];
					stringBuilder.Append("L " + value.ToPixelSize(Units).ToSvg() + " ");
				}
				if (polyline.IsClosed)
				{
					stringBuilder.Append("Z");
				}
			}
		}
		return stringBuilder.ToString();
	}

	private bool drawableLineType(LineType lineType)
	{
		if (lineType.IsComplex)
		{
			return !lineType.HasShapes;
		}
		return false;
	}

	private void endDocument()
	{
		WriteEndElement();
		WriteEndDocument();
		Close();
	}

	private double getPointSize(IEntity entity)
	{
		return entity.GetActiveLineWeightType().GetLineWeightValue().ToPixelSize(Units);
	}

	private void startDocument(BoundingBox box, BoundingBox? viewBox, UnitsType units)
	{
		WriteStartDocument();
		WriteStartElement("svg");
		WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
		WriteAttributeString("width", box.Max.X - box.Min.X, units);
		WriteAttributeString("height", box.Max.Y - box.Min.Y, units);
		if (viewBox.HasValue)
		{
			BoundingBox value = viewBox.Value;
			WriteStartAttribute("viewBox");
			WriteValue(value.Min.X.ToPixelSize(units));
			WriteValue(" ");
			WriteValue(value.Min.Y.ToPixelSize(units));
			WriteValue(" ");
			WriteValue(value.Width.ToPixelSize(units));
			WriteValue(" ");
			WriteValue(value.Height.ToPixelSize(units));
			WriteEndAttribute();
		}
		WriteAttributeString("transform", "scale(1,-1)");
		if (Layout != null)
		{
			WriteAttributeString("style", "background-color:white");
		}
	}

	private string svgPoints<T>(IEnumerable<T> points, Transform transform) where T : IVector, new()
	{
		if (!points.Any())
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(points.First().ToPixelSize(Units).ToSvg());
		foreach (T item in points.Skip(1))
		{
			stringBuilder.Append(' ');
			stringBuilder.Append(item.ToPixelSize(Units).ToSvg());
		}
		return stringBuilder.ToString();
	}

	private void writeArc(Arc arc, Transform transform)
	{
		WriteStartElement("path");
		writeEntityHeader(arc, transform);
		arc.GetEndVertices(out var start, out var end);
		int num = ((Math.Abs(arc.Sweep) > Math.PI) ? 1 : 0);
		WriteAttributeString("d", $"M {start.ToPixelSize(Units).ToSvg()} A {arc.Radius} {arc.Radius} {0} {num} {1} {end.ToPixelSize(Units).ToSvg()}");
		WriteAttributeString("fill", "none");
		WriteEndElement();
	}

	private void writeCircle(Circle circle, Transform transform)
	{
		XYZ xYZ = transform.ApplyTransform(circle.Center);
		WriteStartElement("circle");
		writeEntityHeader(circle, transform);
		WriteAttributeString("r", circle.Radius);
		WriteAttributeString("cx", xYZ.X);
		WriteAttributeString("cy", xYZ.Y);
		WriteAttributeString("fill", "none");
		WriteEndElement();
	}

	private void writeDashes(IEnumerable<double> dashes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (double dash in dashes)
		{
			stringBuilder.Append(Math.Abs(dash.ToPixelSize(Units)));
			stringBuilder.Append(' ');
		}
		WriteAttributeString("stroke-dasharray", stringBuilder.ToString().Trim());
	}

	private void writeDashes(LineType lineType, double pointSize)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (LineType.Segment segment in lineType.Segments)
		{
			if (segment.IsPoint)
			{
				stringBuilder.Append(pointSize.ToPixelSize(Units));
			}
			else
			{
				stringBuilder.Append(Math.Abs(segment.Length.ToPixelSize(Units)));
			}
			stringBuilder.Append(' ');
		}
		WriteAttributeString("stroke-dasharray", stringBuilder.ToString().Trim());
	}

	private void writeEllipse(Ellipse ellipse, Transform transform)
	{
		if (ellipse.IsFullEllipse)
		{
			WriteStartElement("path");
			writeEntityHeader(ellipse, transform);
			StringBuilder stringBuilder = new StringBuilder();
			XYZ value = ellipse.PolarCoordinateRelativeToCenter(0.0);
			XYZ value2 = ellipse.PolarCoordinateRelativeToCenter(Math.PI);
			stringBuilder.Append("M " + value.ToPixelSize(Units).ToSvg() + " ");
			stringBuilder.Append($"A {ellipse.MajorAxis / 2.0} {ellipse.MinorAxis / 2.0} {MathHelper.RadToDeg(ellipse.Rotation)} {0} {1} {value2.ToPixelSize(Units).ToSvg()} ");
			value = ellipse.PolarCoordinateRelativeToCenter(Math.PI);
			value2 = ellipse.PolarCoordinateRelativeToCenter(Math.PI * 2.0);
			stringBuilder.Append($"A {ellipse.MajorAxis / 2.0} {ellipse.MinorAxis / 2.0} {MathHelper.RadToDeg(ellipse.Rotation)} {0} {1} {value2.ToPixelSize(Units).ToSvg()}");
			WriteAttributeString("d", stringBuilder.ToString());
			WriteAttributeString("fill", "none");
			WriteEndElement();
		}
		else
		{
			WriteStartElement("polyline");
			writeEntityHeader(ellipse, transform);
			List<XYZ> points = ellipse.PolygonalVertexes(256);
			string value3 = svgPoints(points, transform);
			WriteAttributeString("points", value3);
			WriteAttributeString("fill", "none");
			WriteEndElement();
		}
	}

	private void writeEntity(Entity entity)
	{
		writeEntity(entity, new Transform());
	}

	private void writeEntityAsPath<T>(Entity entity, Transform transform, params IEnumerable<T> points) where T : IVector
	{
		double pointSize = getPointSize(entity);
		IEnumerable<Polyline3D> polylines = entity.GetActiveLineType().CreateLineTypeShape(pointSize, points);
		WriteStartElement("path");
		writeEntityHeader(entity, transform);
		WriteAttributeString("d", createPath(polylines));
		WriteEndElement();
	}

	private void writeEntityHeader(IEntity entity, Transform transform, bool drawStroke = true)
	{
		Color activeColor = entity.GetActiveColor();
		WriteAttributeString("vector-effect", "non-scaling-stroke");
		if (drawStroke)
		{
			WriteAttributeString("stroke", colorSvg(activeColor));
		}
		else
		{
			WriteAttributeString("stroke", "none");
		}
		LineWeightType activeLineWeightType = entity.GetActiveLineWeightType();
		WriteAttributeString("stroke-width", Configuration.GetLineWeightValue(activeLineWeightType, Units).ToSvg(UnitsType.Millimeters) ?? "");
		writeTransform(transform);
		LineType activeLineType = entity.GetActiveLineType();
		if (drawableLineType(activeLineType))
		{
			writeDashes(activeLineType, getPointSize(entity));
		}
	}

	private void writeHatch(Hatch hatch, Transform transform)
	{
		WriteStartElement("g");
		string text = writePattern(hatch);
		List<Polyline3D> list = new List<Polyline3D>();
		foreach (Hatch.BoundaryPath path in hatch.Paths)
		{
			Polyline3D item = new Polyline3D(path.GetPoints(Configuration.ArcPoints));
			list.Add(item);
		}
		WriteStartElement("path");
		writeEntityHeader(hatch, transform, drawStroke: false);
		WriteAttributeString("d", createPath(list));
		WriteAttributeString("fill", "url(#" + text + ")");
		WriteEndElement();
		WriteEndElement();
	}

	private void writePatternHeader(string id)
	{
		WriteStartElement("pattern");
		WriteAttributeString("id", id);
		WriteAttributeString("patternUnits", "userSpaceOnUse");
	}

	private string writePatternHeader(Hatch hatch)
	{
		string text = $"{hatch.Pattern.GetHashCode()}_{hatch.Pattern.Name}";
		WriteStartElement("pattern");
		WriteAttributeString("id", text);
		WriteAttributeString("patternUnits", "userSpaceOnUse");
		return text;
	}

	private string writeSolidPattern(Hatch hatch)
	{
		string result = writePatternHeader(hatch);
		WriteAttributeString("width", "100%");
		WriteAttributeString("height", "100%");
		WriteStartElement("rect");
		WriteAttributeString("width", "100%");
		WriteAttributeString("height", "100%");
		WriteAttributeString("fill", colorSvg(hatch.Color));
		WriteEndElement();
		WriteEndElement();
		return result;
	}

	private string writePattern(Hatch hatch)
	{
		if (hatch.IsSolid)
		{
			return writeSolidPattern(hatch);
		}
		Dictionary<string, BoundingBox> dictionary = new Dictionary<string, BoundingBox>();
		foreach (HatchPattern.Line line in hatch.Pattern.Lines)
		{
			string text = $"{line.GetHashCode()}_line";
			dictionary.Add(text, new BoundingBox(XYZ.Zero, new XYZ(line.LineOffset, line.LineOffset, 0.0)));
			writePatternHeader(text);
			WriteAttributeString("width", line.LineOffset.ToSvg(Units));
			WriteAttributeString("height", line.LineOffset.ToSvg(Units));
			writeTransform("patternTransform", line.BasePoint.Convert<XYZ>().ToPixelSize(Units));
			WriteStartElement("line");
			line.Offset.GetLength();
			double value = MathHelper.Cos(line.Angle) * 10.0;
			double value2 = MathHelper.Sin(line.Angle) * 10.0;
			WriteAttributeString("x1", 0.0.ToSvg(Units));
			WriteAttributeString("y1", 0.0.ToSvg(Units));
			WriteAttributeString("x2", value.ToSvg(Units));
			WriteAttributeString("y2", value2.ToSvg(Units));
			WriteAttributeString("stroke", colorSvg(hatch.GetActiveColor()));
			WriteAttributeString("stroke-width", Configuration.GetLineWeightValue(hatch.GetActiveLineWeightType(), Units).ToSvg(UnitsType.Millimeters) ?? "");
			if (line.DashLengths.Any())
			{
				writeDashes(line.DashLengths);
			}
			WriteEndElement();
			WriteEndElement();
		}
		string result = writePatternHeader(hatch);
		double value3 = dictionary.Values.Max((BoundingBox w) => w.Width);
		double value4 = dictionary.Values.Max((BoundingBox w) => w.Height);
		WriteAttributeString("width", value3.ToSvg(Units));
		WriteAttributeString("height", value4.ToSvg(Units));
		foreach (KeyValuePair<string, BoundingBox> item in dictionary)
		{
			WriteStartElement("rect");
			WriteAttributeString("width", item.Value.Width.ToSvg(Units));
			WriteAttributeString("height", item.Value.Height.ToSvg(Units));
			WriteAttributeString("fill", "url(#" + item.Key + ")");
			WriteEndElement();
		}
		WriteEndElement();
		return result;
	}

	private void writeInsert(Insert insert, Transform transform)
	{
		Transform transform2 = insert.GetTransform();
		Transform transform3 = new Transform(transform.Matrix * transform2.Matrix);
		WriteStartElement("g");
		writeTransform(transform3);
		foreach (Entity entity in insert.Block.Entities)
		{
			writeEntity(entity);
		}
		WriteEndElement();
	}

	private void writeLine(Line line, Transform transform)
	{
		WriteStartElement("line");
		writeEntityHeader(line, transform);
		WriteAttributeString("x1", line.StartPoint.X.ToSvg(Units));
		WriteAttributeString("y1", line.StartPoint.Y.ToSvg(Units));
		WriteAttributeString("x2", line.EndPoint.X.ToSvg(Units));
		WriteAttributeString("y2", line.EndPoint.Y.ToSvg(Units));
		WriteEndElement();
	}

	private void writePoint(Point point, Transform transform)
	{
		WriteStartElement("circle");
		writeEntityHeader(point, transform);
		WriteAttributeString("r", Configuration.PointRadius);
		WriteAttributeString("cx", point.Location.X);
		WriteAttributeString("cy", point.Location.Y);
		WriteAttributeString("fill", colorSvg(point.GetActiveColor()));
		WriteEndElement();
	}

	private void writePolyline(IPolyline polyline, Transform transform)
	{
		if (polyline.IsClosed)
		{
			WriteStartElement("polygon");
		}
		else
		{
			WriteStartElement("polyline");
		}
		writeEntityHeader(polyline, transform);
		string value = svgPoints(polyline.GetPoints<XY>(Configuration.ArcPoints), transform);
		WriteAttributeString("points", value);
		WriteAttributeString("fill", "none");
		WriteEndElement();
	}

	private void writeText(IText text, Transform transform)
	{
		XYZ value = ((!(text is TextEntity textEntity) || (textEntity.HorizontalAlignment == TextHorizontalAlignment.Left && textEntity.VerticalAlignment == TextVerticalAlignmentType.Baseline) || textEntity.HorizontalAlignment == TextHorizontalAlignment.Fit || textEntity.HorizontalAlignment == TextHorizontalAlignment.Aligned) ? text.InsertPoint : textEntity.AlignmentPoint);
		WriteStartElement("g");
		writeTransform(transform);
		WriteStartElement("text");
		writeTransform("transform", value.ToPixelSize(Units), new XYZ(1.0, -1.0, 0.0), (text.Rotation != 0.0) ? new double?(text.Rotation) : ((double?)null));
		WriteAttributeString("fill", colorSvg(text.GetActiveColor()));
		WriteStartAttribute("style");
		WriteValue("font:");
		WriteValue(text.Height.ToSvg(Units));
		if (Units == UnitsType.Unitless)
		{
			WriteValue("px");
		}
		if (text.Style.TrueType.HasFlag(FontFlags.Bold))
		{
			WriteValue("bold");
		}
		if (text.Style.TrueType.HasFlag(FontFlags.Italic))
		{
			WriteValue("italic");
		}
		WriteValue(" ");
		WriteValue(Path.GetFileNameWithoutExtension(text.Style.Filename));
		WriteEndAttribute();
		if (!(text is MText mText))
		{
			if (text is TextEntity textEntity2)
			{
				switch (textEntity2.HorizontalAlignment)
				{
				case TextHorizontalAlignment.Left:
					WriteAttributeString("text-anchor", "start");
					break;
				case TextHorizontalAlignment.Center:
				case TextHorizontalAlignment.Middle:
					WriteAttributeString("text-anchor", "middle");
					break;
				case TextHorizontalAlignment.Right:
					WriteAttributeString("text-anchor", "end");
					break;
				}
				switch (textEntity2.VerticalAlignment)
				{
				case TextVerticalAlignmentType.Baseline:
				case TextVerticalAlignmentType.Bottom:
					WriteAttributeString("alignment-baseline", "baseline");
					break;
				case TextVerticalAlignmentType.Middle:
					WriteAttributeString("alignment-baseline", "middle");
					break;
				case TextVerticalAlignmentType.Top:
					WriteAttributeString("alignment-baseline", "hanging");
					break;
				}
				WriteString(text.Value);
			}
		}
		else
		{
			switch (mText.AttachmentPoint)
			{
			case AttachmentPointType.TopLeft:
				WriteAttributeString("alignment-baseline", "hanging");
				WriteAttributeString("text-anchor", "start");
				break;
			case AttachmentPointType.TopCenter:
				WriteAttributeString("alignment-baseline", "hanging");
				WriteAttributeString("text-anchor", "middle");
				break;
			case AttachmentPointType.TopRight:
				WriteAttributeString("alignment-baseline", "hanging");
				WriteAttributeString("text-anchor", "end");
				break;
			case AttachmentPointType.MiddleLeft:
				WriteAttributeString("alignment-baseline", "middle");
				WriteAttributeString("text-anchor", "start");
				break;
			case AttachmentPointType.MiddleCenter:
				WriteAttributeString("alignment-baseline", "middle");
				WriteAttributeString("text-anchor", "middle");
				break;
			case AttachmentPointType.MiddleRight:
				WriteAttributeString("alignment-baseline", "middle");
				WriteAttributeString("text-anchor", "end");
				break;
			case AttachmentPointType.BottomLeft:
				WriteAttributeString("alignment-baseline", "baseline");
				WriteAttributeString("text-anchor", "start");
				break;
			case AttachmentPointType.BottomCenter:
				WriteAttributeString("alignment-baseline", "baseline");
				WriteAttributeString("text-anchor", "middle");
				break;
			case AttachmentPointType.BottomRight:
				WriteAttributeString("alignment-baseline", "baseline");
				WriteAttributeString("text-anchor", "end");
				break;
			}
			string[] textLines = mText.GetTextLines();
			foreach (string text2 in textLines)
			{
				WriteStartElement("tspan");
				WriteAttributeString("x", 0.0);
				WriteAttributeString("dy", "1em");
				WriteString(text2);
				WriteEndElement();
			}
			WriteStartElement("tspan");
			WriteAttributeString("x", 0.0);
			WriteAttributeString("dy", "1em");
			WriteAttributeString("visibility", "hidden");
			WriteString(".");
			WriteEndElement();
		}
		WriteEndElement();
		WriteEndElement();
	}

	private void writeSpline(Spline spline, Transform transform)
	{
		spline.UpdateFromFitPoints();
		writeEntityAsPath((Entity)spline, transform, (IEnumerable<XYZ>)spline.PolygonalVertexes(Configuration.ArcPoints));
	}

	private void writeTransform(Transform transform)
	{
		XYZ? translation = ((transform.Translation != XYZ.Zero) ? new XYZ?(transform.Translation) : ((XYZ?)null));
		XYZ? scale = ((transform.Scale != new XYZ(1.0)) ? new XYZ?(transform.Scale) : ((XYZ?)null));
		double? rotation = ((transform.EulerRotation.Z != 0.0) ? new double?(transform.EulerRotation.Z) : ((double?)null));
		writeTransform("transform", translation, scale, rotation);
	}

	private void writeTransform(string name = "transform", XYZ? translation = null, XYZ? scale = null, double? rotation = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (translation.HasValue)
		{
			XYZ value = translation.Value;
			stringBuilder.Append("translate(");
			stringBuilder.Append(value.X.ToString(CultureInfo.InvariantCulture) + ",");
			stringBuilder.Append(value.Y.ToString(CultureInfo.InvariantCulture) + ")");
		}
		if (scale.HasValue)
		{
			XYZ value2 = scale.Value;
			stringBuilder.Append("scale(");
			stringBuilder.Append(value2.X.ToString(CultureInfo.InvariantCulture) + ",");
			stringBuilder.Append(value2.Y.ToString(CultureInfo.InvariantCulture) + ")");
		}
		if (rotation.HasValue)
		{
			double num = 0.0 - MathHelper.RadToDeg(rotation.Value);
			stringBuilder.Append("rotate(");
			stringBuilder.Append(num.ToString(CultureInfo.InvariantCulture) + ")");
		}
		if (!stringBuilder.ToString().IsNullOrEmpty())
		{
			WriteAttributeString(name, stringBuilder.ToString());
		}
	}
}
