using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Attributes;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

public class HatchPattern
{
	public class Line
	{
		[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 53 })]
		public double Angle { get; set; }

		[DxfCodeValue(new int[] { 43, 44 })]
		public XY BasePoint { get; set; }

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 79 })]
		[DxfCollectionCodeValue(new int[] { 49 })]
		public List<double> DashLengths { get; set; } = new List<double>();

		public double LineOffset
		{
			get
			{
				double num = Math.Cos(0.0 - Angle);
				double num2 = Math.Sin(0.0 - Angle);
				return Offset.X * num2 + Offset.Y * num;
			}
		}

		[DxfCodeValue(new int[] { 45, 46 })]
		public XY Offset { get; set; }

		public double Shift
		{
			get
			{
				double num = Math.Cos(0.0 - Angle);
				double num2 = Math.Sin(0.0 - Angle);
				return Offset.X * num - Offset.Y * num2;
			}
		}

		public Line Clone()
		{
			Line obj = (Line)MemberwiseClone();
			obj.DashLengths = new List<double>(DashLengths);
			return obj;
		}
	}

	public static HatchPattern Solid => new HatchPattern("SOLID");

	public string Description { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 79 })]
	public List<Line> Lines { get; set; } = new List<Line>();

	[DxfCodeValue(new int[] { 2 })]
	public string Name { get; set; }

	public HatchPattern(string name)
	{
		Name = name;
	}

	public static IEnumerable<HatchPattern> LoadFrom(string path)
	{
		List<HatchPattern> list = new List<HatchPattern>();
		HatchPattern hatchPattern = null;
		Queue<string> queue = (from text2 in File.ReadLines(path)
			select text2.Trim() into text2
			where !string.IsNullOrWhiteSpace(text2) && !text2.StartsWith(";")
			select text2).ToQueue();
		(from t in queue.Select((string item, int i) => (line: item, i: i))
			where t.line.StartsWith("*")
			select t.i into i
			orderby i
			select i).ToList().Add(queue.Count);
		string element;
		while (queue.TryDequeue(out element))
		{
			if (element.StartsWith("*"))
			{
				int num = element.IndexOf(',');
				string text = element.Remove(0, 1);
				hatchPattern = new HatchPattern(text.Substring(0, num - 1));
				hatchPattern.Description = new string(text.Skip(num).ToArray()).Trim();
				list.Add(hatchPattern);
				continue;
			}
			string[] array = element.Split(',');
			Line line = new Line();
			line.Angle = MathHelper.DegToRad(double.Parse(array[0], CultureInfo.InvariantCulture));
			line.BasePoint = new XY(double.Parse(array[1], CultureInfo.InvariantCulture), double.Parse(array[2], CultureInfo.InvariantCulture));
			double x = double.Parse(array[3], CultureInfo.InvariantCulture);
			double y = double.Parse(array[4], CultureInfo.InvariantCulture);
			XY xY = new XY(x, y);
			double num2 = Math.Cos(line.Angle);
			double num3 = Math.Sin(line.Angle);
			line.Offset = new XY(xY.X * num2 - xY.Y * num3, xY.X * num3 + xY.Y * num2);
			IEnumerable<string> source = array.Skip(5);
			if (source.Any())
			{
				line.DashLengths.AddRange(source.Select((string d) => double.Parse(d, CultureInfo.InvariantCulture)));
			}
			hatchPattern.Lines.Add(line);
		}
		return list;
	}

	public static void SavePatterns(string filename, params HatchPattern[] patterns)
	{
		using StreamWriter streamWriter = File.CreateText(filename);
		foreach (HatchPattern hatchPattern in patterns)
		{
			streamWriter.Write("*" + hatchPattern.Name);
			if (!hatchPattern.Description.IsNullOrEmpty())
			{
				streamWriter.Write("," + hatchPattern.Description);
			}
			streamWriter.WriteLine();
			foreach (Line line in hatchPattern.Lines)
			{
				StringBuilder stringBuilder = new StringBuilder();
				double num = MathHelper.DegToRad(line.Angle);
				double num2 = Math.Cos(0.0 - line.Angle);
				double num3 = Math.Sin(0.0 - line.Angle);
				XY xY = new XY(line.Offset.X * num2 - line.Offset.Y * num3, line.Offset.X * num3 + line.Offset.Y * num2);
				stringBuilder.Append(num.ToString(CultureInfo.InvariantCulture));
				stringBuilder.Append(",");
				stringBuilder.Append(line.BasePoint.ToString(CultureInfo.InvariantCulture));
				stringBuilder.Append(",");
				stringBuilder.Append(xY.ToString(CultureInfo.InvariantCulture));
				if (line.DashLengths.Count > 0)
				{
					stringBuilder.Append(",");
					stringBuilder.Append(line.DashLengths[0].ToString(CultureInfo.InvariantCulture));
					for (int j = 1; j < line.DashLengths.Count; j++)
					{
						stringBuilder.Append(",");
						stringBuilder.Append(line.DashLengths[j].ToString(CultureInfo.InvariantCulture));
					}
				}
				streamWriter.WriteLine(stringBuilder.ToString());
			}
		}
	}

	public HatchPattern Clone()
	{
		HatchPattern hatchPattern = (HatchPattern)MemberwiseClone();
		hatchPattern.Lines = new List<Line>();
		foreach (Line line in Lines)
		{
			hatchPattern.Lines.Add(line.Clone());
		}
		return hatchPattern;
	}

	public override string ToString()
	{
		return Name ?? "";
	}

	public void Update(XY translation, double rotation, double scale)
	{
		Transform transform = Transform.CreateTranslation(translation.Convert<XYZ>());
		Transform transform2 = Transform.CreateScaling(new XYZ(scale));
		Transform transform3 = Transform.CreateRotation(XYZ.AxisZ, rotation);
		Transform transform4 = new Transform(transform.Matrix * transform2.Matrix * transform3.Matrix);
		foreach (Line line in Lines)
		{
			line.Angle += rotation;
			line.BasePoint = transform4.ApplyTransform(line.BasePoint.Convert<XYZ>()).Convert<XY>();
			line.Offset = transform4.ApplyTransform(line.Offset.Convert<XYZ>()).Convert<XY>();
			line.DashLengths = line.DashLengths.Select((double d) => d * scale).ToList();
		}
	}
}
