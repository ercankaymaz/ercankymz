using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyToad.PdfPig.Core;

public sealed class PdfSubpath
{
	public interface IPathCommand
	{
		PdfRectangle? GetBoundingRectangle();

		void WriteSvg(StringBuilder builder, double height);
	}

	public sealed class Close : IPathCommand
	{
		private static readonly int _hash = typeof(Close).GetHashCode();

		public PdfRectangle? GetBoundingRectangle()
		{
			return null;
		}

		public void WriteSvg(StringBuilder builder, double height)
		{
			builder.Append("Z ");
		}

		public override bool Equals(object? obj)
		{
			return obj is Close;
		}

		public override int GetHashCode()
		{
			return _hash;
		}
	}

	public sealed class Move : IPathCommand
	{
		public PdfPoint Location { get; }

		public Move(PdfPoint location)
		{
			Location = location;
		}

		public PdfRectangle? GetBoundingRectangle()
		{
			return null;
		}

		public void WriteSvg(StringBuilder builder, double height)
		{
			builder.Append($"M {Location.X} {height - Location.Y} ");
		}

		public override bool Equals(object? obj)
		{
			if (obj is Move move)
			{
				return Location.Equals(move.Location);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Location.GetHashCode();
		}
	}

	public sealed class Line : IPathCommand
	{
		public PdfPoint From { get; }

		public PdfPoint To { get; }

		public double Length
		{
			get
			{
				double num = From.X - To.X;
				double num2 = From.Y - To.Y;
				return Math.Sqrt(num * num + num2 * num2);
			}
		}

		public Line(PdfPoint from, PdfPoint to)
		{
			From = from;
			To = to;
		}

		public PdfRectangle? GetBoundingRectangle()
		{
			return new PdfRectangle(From, To);
		}

		public void WriteSvg(StringBuilder builder, double height)
		{
			builder.Append($"L {To.X} {height - To.Y} ");
		}

		public override bool Equals(object? obj)
		{
			if (obj is Line line)
			{
				if (From.Equals(line.From))
				{
					return To.Equals(line.To);
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(From, To);
		}
	}

	public sealed class QuadraticBezierCurve : BezierCurve
	{
		public PdfPoint ControlPoint { get; }

		public QuadraticBezierCurve(PdfPoint startPoint, PdfPoint controlPoint, PdfPoint endPoint)
			: base(startPoint, endPoint)
		{
			ControlPoint = controlPoint;
		}

		public override void WriteSvg(StringBuilder builder, double height)
		{
			builder.Append($"C {ControlPoint.X} {height - ControlPoint.Y}, {base.EndPoint.X} {height - base.EndPoint.Y} ");
		}

		protected internal override bool TrySolve(bool isX, double currentMin, double currentMax, out (double min, double max) solutions)
		{
			solutions = default((double, double));
			double num = (isX ? base.StartPoint.X : base.StartPoint.Y);
			double num2 = (isX ? ControlPoint.X : ControlPoint.Y);
			double num3 = (isX ? base.EndPoint.X : base.EndPoint.Y);
			double num4 = (num - num2) / (num - 2.0 * num2 + num3);
			if (num4 >= 0.0 && num4 <= 1.0)
			{
				double num5 = BezierCurve.ValueWithT(num, num2, num3, num4);
				if (num5 < currentMin)
				{
					currentMin = num5;
				}
				if (num5 > currentMax)
				{
					currentMax = num5;
				}
			}
			solutions = (min: currentMin, max: currentMax);
			return true;
		}

		public override IReadOnlyList<Line> ToLines(int n)
		{
			if (n < 1)
			{
				throw new ArgumentException("BezierCurve.ToLines(): n must be greater than 0.");
			}
			Line[] array = new Line[n];
			PdfPoint pdfPoint = base.StartPoint;
			for (int i = 1; i <= n; i++)
			{
				double t = (double)i / (double)n;
				PdfPoint pdfPoint2 = new PdfPoint(BezierCurve.ValueWithT(base.StartPoint.X, ControlPoint.X, base.EndPoint.X, t), BezierCurve.ValueWithT(base.StartPoint.Y, ControlPoint.Y, base.EndPoint.Y, t));
				array[i - 1] = new Line(pdfPoint, pdfPoint2);
				pdfPoint = pdfPoint2;
			}
			return array;
		}

		public override bool Equals(object? obj)
		{
			if (obj is QuadraticBezierCurve quadraticBezierCurve)
			{
				if (base.StartPoint.Equals(quadraticBezierCurve.StartPoint) && ControlPoint.Equals(quadraticBezierCurve.ControlPoint))
				{
					return base.EndPoint.Equals(quadraticBezierCurve.EndPoint);
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.StartPoint, ControlPoint, base.EndPoint);
		}
	}

	public sealed class CubicBezierCurve : BezierCurve
	{
		public PdfPoint FirstControlPoint { get; }

		public PdfPoint SecondControlPoint { get; }

		public CubicBezierCurve(PdfPoint startPoint, PdfPoint firstControlPoint, PdfPoint secondControlPoint, PdfPoint endPoint)
			: base(startPoint, endPoint)
		{
			FirstControlPoint = firstControlPoint;
			SecondControlPoint = secondControlPoint;
		}

		public override void WriteSvg(StringBuilder builder, double height)
		{
			builder.Append($"C {FirstControlPoint.X} {height - FirstControlPoint.Y}, {SecondControlPoint.X} {height - SecondControlPoint.Y}, {base.EndPoint.X} {height - base.EndPoint.Y} ");
		}

		protected internal override bool TrySolve(bool isX, double currentMin, double currentMax, out (double min, double max) solutions)
		{
			return TrySolveQuadratic(isX, currentMin, currentMax, out solutions);
		}

		private bool TrySolveQuadratic(bool isX, double currentMin, double currentMax, out (double min, double max) solutions)
		{
			solutions = default((double, double));
			double num = (isX ? base.StartPoint.X : base.StartPoint.Y);
			double num2 = (isX ? FirstControlPoint.X : FirstControlPoint.Y);
			double num3 = (isX ? SecondControlPoint.X : SecondControlPoint.Y);
			double num4 = (isX ? base.EndPoint.X : base.EndPoint.Y);
			double num5 = 3.0 * (num2 - num);
			double num6 = 6.0 * (num3 - num2);
			double num7 = 3.0 * (num4 - num3);
			double num8 = num5 - num6 + num7;
			double num9 = num6 - num5 - num5;
			double num10 = num5;
			double num11 = num9 * num9 - 4.0 * num8 * num10;
			if (num11 < 0.0)
			{
				return false;
			}
			double num12 = Math.Sqrt(num11);
			double num13 = 2.0 * num8;
			double num14 = (0.0 - num9 + num12) / num13;
			double num15 = (0.0 - num9 - num12) / num13;
			if (num14 >= 0.0 && num14 <= 1.0)
			{
				double num16 = BezierCurve.ValueWithT(num, num2, num3, num4, num14);
				if (num16 < currentMin)
				{
					currentMin = num16;
				}
				if (num16 > currentMax)
				{
					currentMax = num16;
				}
			}
			if (num15 >= 0.0 && num15 <= 1.0)
			{
				double num17 = BezierCurve.ValueWithT(num, num2, num3, num4, num15);
				if (num17 < currentMin)
				{
					currentMin = num17;
				}
				if (num17 > currentMax)
				{
					currentMax = num17;
				}
			}
			solutions = (min: currentMin, max: currentMax);
			return true;
		}

		public override IReadOnlyList<Line> ToLines(int n)
		{
			if (n < 1)
			{
				throw new ArgumentException("BezierCurve.ToLines(): n must be greater than 0.");
			}
			Line[] array = new Line[n];
			PdfPoint pdfPoint = base.StartPoint;
			for (int i = 1; i <= n; i++)
			{
				double t = (double)i / (double)n;
				PdfPoint pdfPoint2 = new PdfPoint(BezierCurve.ValueWithT(base.StartPoint.X, FirstControlPoint.X, SecondControlPoint.X, base.EndPoint.X, t), BezierCurve.ValueWithT(base.StartPoint.Y, FirstControlPoint.Y, SecondControlPoint.Y, base.EndPoint.Y, t));
				array[i - 1] = new Line(pdfPoint, pdfPoint2);
				pdfPoint = pdfPoint2;
			}
			return array;
		}

		public override bool Equals(object? obj)
		{
			if (obj is CubicBezierCurve cubicBezierCurve)
			{
				if (base.StartPoint.Equals(cubicBezierCurve.StartPoint) && FirstControlPoint.Equals(cubicBezierCurve.FirstControlPoint) && SecondControlPoint.Equals(cubicBezierCurve.SecondControlPoint))
				{
					return base.EndPoint.Equals(cubicBezierCurve.EndPoint);
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.StartPoint, FirstControlPoint, SecondControlPoint, base.EndPoint);
		}
	}

	public abstract class BezierCurve : IPathCommand
	{
		public PdfPoint StartPoint { get; }

		public PdfPoint EndPoint { get; }

		protected BezierCurve(PdfPoint startPoint, PdfPoint endPoint)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}

		public PdfRectangle? GetBoundingRectangle()
		{
			double num;
			double num2;
			if (StartPoint.X <= EndPoint.X)
			{
				num = StartPoint.X;
				num2 = EndPoint.X;
			}
			else
			{
				num = EndPoint.X;
				num2 = StartPoint.X;
			}
			double num3;
			double num4;
			if (StartPoint.Y <= EndPoint.Y)
			{
				num3 = StartPoint.Y;
				num4 = EndPoint.Y;
			}
			else
			{
				num3 = EndPoint.Y;
				num4 = StartPoint.Y;
			}
			if (TrySolve(isX: true, num, num2, out (double, double) solutions))
			{
				(num, num2) = solutions;
			}
			if (TrySolve(isX: false, num3, num4, out (double, double) solutions2))
			{
				(num3, num4) = solutions2;
			}
			return new PdfRectangle(num, num3, num2, num4);
		}

		public abstract void WriteSvg(StringBuilder builder, double height);

		protected internal abstract bool TrySolve(bool isX, double currentMin, double currentMax, out (double min, double max) solutions);

		public static double ValueWithT(double p1, double p2, double p3, double t)
		{
			double num = 1.0 - t;
			return num * num * p1 + 2.0 * num * t * p2 + t * t * p3;
		}

		public static double ValueWithT(double p1, double p2, double p3, double p4, double t)
		{
			double num = 1.0 - t;
			return num * num * num * p1 + 3.0 * (num * num) * t * p2 + 3.0 * num * (t * t) * p3 + t * t * t * p4;
		}

		public abstract IReadOnlyList<Line> ToLines(int n);
	}

	private readonly List<IPathCommand> commands = new List<IPathCommand>();

	private PdfPoint? currentPosition;

	private double shoeLaceSum;

	public IReadOnlyList<IPathCommand> Commands => commands;

	public bool IsDrawnAsRectangle { get; internal set; }

	public bool IsClockwise
	{
		get
		{
			if (IsClosed())
			{
				return shoeLaceSum > 0.0;
			}
			return false;
		}
	}

	public bool IsCounterClockwise
	{
		get
		{
			if (IsClosed())
			{
				return shoeLaceSum < 0.0;
			}
			return false;
		}
	}

	public PdfPoint GetCentroid()
	{
		List<IPathCommand> list = commands.Where((IPathCommand c) => c is Line || c is BezierCurve).ToList();
		if (list.Count == 0)
		{
			return default(PdfPoint);
		}
		List<PdfPoint> list2 = list.Select(GetStartPoint).ToList();
		list2.AddRange(list.Select(GetEndPoint));
		return new PdfPoint(list2.Average((PdfPoint p) => p.X), list2.Average((PdfPoint p) => p.Y));
	}

	internal static PdfPoint GetStartPoint(IPathCommand command)
	{
		if (command is Line line)
		{
			return line.From;
		}
		if (command is BezierCurve bezierCurve)
		{
			return bezierCurve.StartPoint;
		}
		if (command is Move move)
		{
			return move.Location;
		}
		throw new ArgumentException();
	}

	internal static PdfPoint GetEndPoint(IPathCommand command)
	{
		if (command is Line line)
		{
			return line.To;
		}
		if (command is BezierCurve bezierCurve)
		{
			return bezierCurve.EndPoint;
		}
		if (command is Move move)
		{
			return move.Location;
		}
		throw new ArgumentException();
	}

	internal PdfSubpath Simplify(int n = 4)
	{
		PdfSubpath pdfSubpath = new PdfSubpath();
		PdfPoint startPoint = GetStartPoint(Commands.First());
		pdfSubpath.MoveTo(startPoint.X, startPoint.Y);
		foreach (IPathCommand command in Commands)
		{
			if (command is Line line)
			{
				pdfSubpath.LineTo(line.To.X, line.To.Y);
			}
			else
			{
				if (!(command is BezierCurve bezierCurve))
				{
					continue;
				}
				foreach (Line item in bezierCurve.ToLines(n))
				{
					pdfSubpath.LineTo(item.To.X, item.To.Y);
				}
			}
		}
		if (IsClosed())
		{
			PdfPoint startPoint2 = GetStartPoint(pdfSubpath.Commands.First());
			if (!startPoint2.Equals(GetEndPoint(pdfSubpath.Commands.Last())))
			{
				pdfSubpath.LineTo(startPoint2.X, startPoint2.Y);
			}
		}
		return pdfSubpath;
	}

	public void MoveTo(double x, double y)
	{
		currentPosition = new PdfPoint(x, y);
		commands.Add(new Move(currentPosition.Value));
	}

	public void LineTo(double x, double y)
	{
		if (currentPosition.HasValue)
		{
			shoeLaceSum += (x - currentPosition.Value.X) * (y + currentPosition.Value.Y);
			PdfPoint pdfPoint = new PdfPoint(x, y);
			commands.Add(new Line(currentPosition.Value, pdfPoint));
			currentPosition = pdfPoint;
			return;
		}
		throw new ArgumentNullException("LineTo(): currentPosition is null.");
	}

	public void Rectangle(double x, double y, double width, double height)
	{
		MoveTo(x, y);
		LineTo(x + width, y);
		LineTo(x + width, y + height);
		LineTo(x, y + height);
		CloseSubpath();
		IsDrawnAsRectangle = true;
	}

	public void BezierCurveTo(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		if (currentPosition.HasValue)
		{
			shoeLaceSum += (x1 - currentPosition.Value.X) * (y1 + currentPosition.Value.Y);
			shoeLaceSum += (x2 - x1) * (y2 + y1);
			shoeLaceSum += (x3 - x2) * (y3 + y2);
			PdfPoint pdfPoint = new PdfPoint(x3, y3);
			commands.Add(new CubicBezierCurve(currentPosition.Value, new PdfPoint(x1, y1), new PdfPoint(x2, y2), pdfPoint));
			currentPosition = pdfPoint;
			return;
		}
		throw new ArgumentNullException("BezierCurveTo(): currentPosition is null.");
	}

	public void BezierCurveTo(double x1, double y1, double x2, double y2)
	{
		if (currentPosition.HasValue)
		{
			shoeLaceSum += (x1 - currentPosition.Value.X) * (y1 + currentPosition.Value.Y);
			shoeLaceSum += (x2 - x1) * (y2 + y1);
			PdfPoint pdfPoint = new PdfPoint(x2, y2);
			commands.Add(new QuadraticBezierCurve(currentPosition.Value, new PdfPoint(x1, y1), pdfPoint));
			currentPosition = pdfPoint;
			return;
		}
		throw new ArgumentNullException("BezierCurveTo(): currentPosition is null.");
	}

	public void CloseSubpath()
	{
		if (currentPosition.HasValue)
		{
			PdfPoint startPoint = GetStartPoint(commands.First());
			if (!startPoint.Equals(currentPosition.Value))
			{
				shoeLaceSum += (startPoint.X - currentPosition.Value.X) * (startPoint.Y + currentPosition.Value.Y);
			}
		}
		commands.Add(new Close());
	}

	public bool IsClosed()
	{
		int num = 0;
		IPathCommand pathCommand = null;
		IPathCommand pathCommand2 = null;
		for (int num2 = Commands.Count - 1; num2 >= 0; num2--)
		{
			IPathCommand pathCommand3 = Commands[num2];
			if (pathCommand3 is Close)
			{
				return true;
			}
			if (pathCommand3 is Line || pathCommand3 is BezierCurve || pathCommand3 is Move)
			{
				if (pathCommand == null)
				{
					pathCommand = pathCommand3;
				}
				pathCommand2 = pathCommand3;
				num++;
			}
		}
		if (num < 2 || pathCommand == null || pathCommand2 == null)
		{
			return false;
		}
		if (!GetStartPoint(pathCommand2).Equals(GetEndPoint(pathCommand)))
		{
			return false;
		}
		return true;
	}

	public PdfRectangle? GetBoundingRectangle()
	{
		if (commands.Count == 0)
		{
			return null;
		}
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		foreach (IPathCommand command in commands)
		{
			PdfRectangle? boundingRectangle = command.GetBoundingRectangle();
			if (boundingRectangle.HasValue)
			{
				if (boundingRectangle.Value.Left < num)
				{
					num = boundingRectangle.Value.Left;
				}
				if (boundingRectangle.Value.Right > num2)
				{
					num2 = boundingRectangle.Value.Right;
				}
				if (boundingRectangle.Value.Bottom < num3)
				{
					num3 = boundingRectangle.Value.Bottom;
				}
				if (boundingRectangle.Value.Top > num4)
				{
					num4 = boundingRectangle.Value.Top;
				}
			}
		}
		if (num == double.MaxValue || num2 == double.MinValue || num3 == double.MaxValue || num4 == double.MinValue)
		{
			return null;
		}
		return new PdfRectangle(num, num3, num2, num4);
	}

	public PdfRectangle? GetDrawnRectangle()
	{
		if (!IsDrawnAsRectangle || Commands.Count != 5)
		{
			return null;
		}
		if (!(Commands[0] is Move move) || !(Commands[1] is Line line) || !(Commands[2] is Line line2) || !(Commands[3] is Line) || !(Commands[4] is Close))
		{
			return null;
		}
		if (!line.From.Equals(move.Location) || line.To.Y != move.Location.Y)
		{
			return null;
		}
		double num = line.To.X - move.Location.X;
		if (!line2.From.Equals(line.To) || line2.To.X != line.To.X)
		{
			return null;
		}
		double num2 = line2.To.Y - line.To.Y;
		return new PdfRectangle(move.Location, new PdfPoint(move.Location.X + num, move.Location.Y + num2));
	}

	public static PdfRectangle? GetBoundingRectangle(IReadOnlyList<PdfSubpath>? path)
	{
		if (path == null || path.Count == 0)
		{
			return null;
		}
		List<PdfRectangle> list = (from pdfSubpath in path
			select pdfSubpath.GetBoundingRectangle() into pdfRectangle
			where pdfRectangle.HasValue
			select pdfRectangle.Value).ToList();
		if (list.Count == 0)
		{
			return null;
		}
		double x = list.Min((PdfRectangle pdfRectangle) => pdfRectangle.Left);
		double y = list.Min((PdfRectangle pdfRectangle) => pdfRectangle.Bottom);
		double x2 = list.Max((PdfRectangle pdfRectangle) => pdfRectangle.Right);
		double y2 = list.Max((PdfRectangle pdfRectangle) => pdfRectangle.Top);
		return new PdfRectangle(x, y, x2, y2);
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is PdfSubpath pdfSubpath) || Commands.Count != pdfSubpath.Commands.Count)
		{
			return false;
		}
		for (int i = 0; i < Commands.Count; i++)
		{
			if (!Commands[i].Equals(pdfSubpath.Commands[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = Commands.Count + 1;
		for (int i = 0; i < Commands.Count; i++)
		{
			num = num * (i + 1) * 17 + Commands[i].GetHashCode();
		}
		return num;
	}
}
