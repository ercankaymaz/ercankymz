using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Core;

public readonly struct TransformationMatrix : IEquatable<TransformationMatrix>
{
	public static readonly TransformationMatrix Identity = new TransformationMatrix(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);

	private readonly double row1;

	private readonly double row2;

	private readonly double row3;

	public readonly double A;

	public readonly double B;

	public readonly double C;

	public readonly double D;

	public readonly double E;

	public readonly double F;

	public const int Rows = 3;

	public const int Columns = 3;

	public double this[int row, int col]
	{
		get
		{
			if (row >= 3)
			{
				throw new ArgumentOutOfRangeException("row", $"The transformation matrix only contains {3} rows and is zero indexed, you tried to access row {row}.");
			}
			if (row < 0)
			{
				throw new ArgumentOutOfRangeException("row", "Cannot access negative rows in a matrix.");
			}
			if (col >= 3)
			{
				throw new ArgumentOutOfRangeException("col", $"The transformation matrix only contains {3} columns and is zero indexed, you tried to access column {col}.");
			}
			if (col < 0)
			{
				throw new ArgumentOutOfRangeException("col", "Cannot access negative columns in a matrix.");
			}
			return row switch
			{
				0 => col switch
				{
					0 => A, 
					1 => B, 
					2 => row1, 
					_ => throw new ArgumentOutOfRangeException($"Trying to access {row}, {col} which was not in the value array."), 
				}, 
				1 => col switch
				{
					0 => C, 
					1 => D, 
					2 => row2, 
					_ => throw new ArgumentOutOfRangeException($"Trying to access {row}, {col} which was not in the value array."), 
				}, 
				2 => col switch
				{
					0 => E, 
					1 => F, 
					2 => row3, 
					_ => throw new ArgumentOutOfRangeException($"Trying to access {row}, {col} which was not in the value array."), 
				}, 
				_ => throw new ArgumentOutOfRangeException($"Trying to access {row}, {col} which was not in the value array."), 
			};
		}
	}

	public static TransformationMatrix GetTranslationMatrix(double x, double y)
	{
		return new TransformationMatrix(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, x, y, 1.0);
	}

	public static TransformationMatrix GetScaleMatrix(double scaleX, double scaleY)
	{
		return new TransformationMatrix(scaleX, 0.0, 0.0, 0.0, scaleY, 0.0, 0.0, 0.0, 1.0);
	}

	public static TransformationMatrix GetRotationMatrix(double degreesCounterclockwise)
	{
		double num = degreesCounterclockwise % 360.0;
		if (num < 0.0)
		{
			num += 360.0;
		}
		double num2;
		double num3;
		if (num != 0.0 && num != 360.0)
		{
			if (num != 90.0)
			{
				if (num != 180.0)
				{
					if (num == 270.0)
					{
						num2 = 0.0;
						num3 = -1.0;
					}
					else
					{
						num2 = Math.Cos(degreesCounterclockwise * (Math.PI / 180.0));
						num3 = Math.Sin(degreesCounterclockwise * (Math.PI / 180.0));
					}
				}
				else
				{
					num2 = -1.0;
					num3 = 0.0;
				}
			}
			else
			{
				num2 = 0.0;
				num3 = 1.0;
			}
		}
		else
		{
			num2 = 1.0;
			num3 = 0.0;
		}
		return new TransformationMatrix(num2, num3, 0.0, 0.0 - num3, num2, 0.0, 0.0, 0.0, 1.0);
	}

	public TransformationMatrix(ReadOnlySpan<double> value)
		: this(value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8])
	{
	}

	public TransformationMatrix(double a, double b, double r1, double c, double d, double r2, double e, double f, double r3)
	{
		A = a;
		B = b;
		row1 = r1;
		C = c;
		D = d;
		row2 = r2;
		E = e;
		F = f;
		row3 = r3;
	}

	public PdfPoint Transform(PdfPoint original)
	{
		(double, double) tuple = Transform(original.X, original.Y);
		return new PdfPoint(tuple.Item1, tuple.Item2);
	}

	public (double x, double y) Transform(double x, double y)
	{
		return (x: A * x + C * y + E, y: B * x + D * y + F);
	}

	public double TransformX(double x)
	{
		return A * x + E;
	}

	public double TransformY(double y)
	{
		return D * y + F;
	}

	public PdfRectangle Transform(PdfRectangle original)
	{
		return new PdfRectangle(Transform(original.TopLeft), Transform(original.TopRight), Transform(original.BottomLeft), Transform(original.BottomRight));
	}

	public PdfSubpath Transform(PdfSubpath subpath)
	{
		PdfSubpath pdfSubpath = new PdfSubpath();
		foreach (PdfSubpath.IPathCommand command in subpath.Commands)
		{
			if (command is PdfSubpath.Move move)
			{
				PdfPoint pdfPoint = Transform(move.Location);
				pdfSubpath.MoveTo(pdfPoint.X, pdfPoint.Y);
			}
			else if (command is PdfSubpath.Line line)
			{
				PdfPoint pdfPoint2 = Transform(line.To);
				pdfSubpath.LineTo(pdfPoint2.X, pdfPoint2.Y);
			}
			else if (command is PdfSubpath.CubicBezierCurve cubicBezierCurve)
			{
				PdfPoint pdfPoint3 = Transform(cubicBezierCurve.FirstControlPoint);
				PdfPoint pdfPoint4 = Transform(cubicBezierCurve.SecondControlPoint);
				PdfPoint pdfPoint5 = Transform(cubicBezierCurve.EndPoint);
				pdfSubpath.BezierCurveTo(pdfPoint3.X, pdfPoint3.Y, pdfPoint4.X, pdfPoint4.Y, pdfPoint5.X, pdfPoint5.Y);
			}
			else if (command is PdfSubpath.QuadraticBezierCurve quadraticBezierCurve)
			{
				PdfPoint pdfPoint6 = Transform(quadraticBezierCurve.ControlPoint);
				PdfPoint pdfPoint7 = Transform(quadraticBezierCurve.EndPoint);
				pdfSubpath.BezierCurveTo(pdfPoint6.X, pdfPoint6.Y, pdfPoint7.X, pdfPoint7.Y);
			}
			else
			{
				if (!(command is PdfSubpath.Close))
				{
					throw new Exception("Unknown PdfSubpath type");
				}
				pdfSubpath.CloseSubpath();
			}
		}
		return pdfSubpath;
	}

	public IEnumerable<PdfSubpath> Transform(IEnumerable<PdfSubpath> path)
	{
		foreach (PdfSubpath item in path)
		{
			yield return Transform(item);
		}
	}

	public TransformationMatrix Translate(double x, double y)
	{
		double a = A;
		double b = B;
		double r = row1;
		double c = C;
		double d = D;
		double r2 = row2;
		double e = x * A + y * C + E;
		double f = x * B + y * D + F;
		double r3 = x * row1 + y * row2 + row3;
		return new TransformationMatrix(a, b, r, c, d, r2, e, f, r3);
	}

	public static TransformationMatrix FromValues(double a, double b, double c, double d, double e, double f)
	{
		return new TransformationMatrix(a, b, 0.0, c, d, 0.0, e, f, 1.0);
	}

	public static TransformationMatrix FromValues(double a, double b, double c, double d)
	{
		return new TransformationMatrix(a, b, 0.0, c, d, 0.0, 0.0, 0.0, 1.0);
	}

	public static TransformationMatrix FromArray(ReadOnlySpan<double> values)
	{
		if (values.Length == 9)
		{
			return new TransformationMatrix(values);
		}
		if (values.Length == 6)
		{
			return new TransformationMatrix(values[0], values[1], 0.0, values[2], values[3], 0.0, values[4], values[5], 1.0);
		}
		if (values.Length == 4)
		{
			return new TransformationMatrix(values[0], values[1], 0.0, values[2], values[3], 0.0, 0.0, 0.0, 1.0);
		}
		throw new ArgumentException("The array must either define all 9 elements of the matrix or all 6 key elements. Instead array was: " + string.Join(", ", values.ToArray()));
	}

	public TransformationMatrix Multiply(in TransformationMatrix matrix)
	{
		double a = A * matrix.A + B * matrix.C + row1 * matrix.E;
		double b = A * matrix.B + B * matrix.D + row1 * matrix.F;
		double r = A * matrix.row1 + B * matrix.row2 + row1 * matrix.row3;
		double c = C * matrix.A + D * matrix.C + row2 * matrix.E;
		double d = C * matrix.B + D * matrix.D + row2 * matrix.F;
		double r2 = C * matrix.row1 + D * matrix.row2 + row2 * matrix.row3;
		double e = E * matrix.A + F * matrix.C + row3 * matrix.E;
		double f = E * matrix.B + F * matrix.D + row3 * matrix.F;
		double r3 = E * matrix.row1 + F * matrix.row2 + row3 * matrix.row3;
		return new TransformationMatrix(a, b, r, c, d, r2, e, f, r3);
	}

	public TransformationMatrix Multiply(double scalar)
	{
		return new TransformationMatrix(A * scalar, B * scalar, row1 * scalar, C * scalar, D * scalar, row2 * scalar, E * scalar, F * scalar, row3 * scalar);
	}

	public TransformationMatrix Inverse()
	{
		double num = D * row3 - row2 * F;
		double num2 = 0.0 - (C * row3 - row2 * E);
		double num3 = C * F - D * E;
		double num4 = 0.0 - (B * row3 - row1 * F);
		double num5 = A * row3 - row1 * E;
		double num6 = 0.0 - (A * F - B * E);
		double num7 = B * row2 - row1 * D;
		double num8 = 0.0 - (A * row2 - row1 * C);
		double num9 = A * D - B * C;
		double num10 = A * num + B * num2 + row1 * num3;
		return new TransformationMatrix(num / num10, num4 / num10, num7 / num10, num2 / num10, num5 / num10, num8 / num10, num3 / num10, num6 / num10, num9 / num10);
	}

	internal double GetScalingFactorX()
	{
		double result = A;
		if (B != 0.0 || C != 0.0)
		{
			result = Math.Sqrt(A * A + B * B);
		}
		return result;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TransformationMatrix other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TransformationMatrix other)
	{
		if (row1.Equals(other.row1) && row2.Equals(other.row2) && row3.Equals(other.row3) && A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D) && E.Equals(other.E))
		{
			return F.Equals(other.F);
		}
		return false;
	}

	public static bool Equals(TransformationMatrix a, TransformationMatrix b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(row1);
		hashCode.Add(row2);
		hashCode.Add(row3);
		hashCode.Add(A);
		hashCode.Add(B);
		hashCode.Add(C);
		hashCode.Add(D);
		hashCode.Add(E);
		hashCode.Add(F);
		return hashCode.ToHashCode();
	}

	public override string ToString()
	{
		return $"{A}, {B}, {row1}\r\n{C}, {D}, {row2}\r\n{E}, {F}, {row3}";
	}

	public static bool operator ==(TransformationMatrix left, TransformationMatrix right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(TransformationMatrix left, TransformationMatrix right)
	{
		return !(left == right);
	}
}
