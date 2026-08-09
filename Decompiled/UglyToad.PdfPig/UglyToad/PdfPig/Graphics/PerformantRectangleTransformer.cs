using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics;

public static class PerformantRectangleTransformer
{
	public static PdfRectangle Transform(in TransformationMatrix first, in TransformationMatrix second, in TransformationMatrix third, PdfRectangle rectangle)
	{
		PdfPoint topLeft = rectangle.TopLeft;
		PdfPoint topRight = rectangle.TopRight;
		PdfPoint bottomLeft = rectangle.BottomLeft;
		PdfPoint bottomRight = rectangle.BottomRight;
		double x = topLeft.X;
		double y = topLeft.Y;
		double x2 = topRight.X;
		double y2 = topRight.Y;
		double x3 = bottomLeft.X;
		double y3 = bottomLeft.Y;
		double x4 = bottomRight.X;
		double y4 = bottomRight.Y;
		double num = first.A * x + first.C * y + first.E;
		double num2 = first.B * x + first.D * y + first.F;
		x = num;
		y = num2;
		num = first.A * x2 + first.C * y2 + first.E;
		double num3 = first.B * x2 + first.D * y2 + first.F;
		x2 = num;
		y2 = num3;
		num = first.A * x3 + first.C * y3 + first.E;
		double num4 = first.B * x3 + first.D * y3 + first.F;
		x3 = num;
		y3 = num4;
		num = first.A * x4 + first.C * y4 + first.E;
		double num5 = first.B * x4 + first.D * y4 + first.F;
		x4 = num;
		y4 = num5;
		num = second.A * x + second.C * y + second.E;
		double num6 = second.B * x + second.D * y + second.F;
		x = num;
		y = num6;
		num = second.A * x2 + second.C * y2 + second.E;
		double num7 = second.B * x2 + second.D * y2 + second.F;
		x2 = num;
		y2 = num7;
		num = second.A * x3 + second.C * y3 + second.E;
		double num8 = second.B * x3 + second.D * y3 + second.F;
		x3 = num;
		y3 = num8;
		num = second.A * x4 + second.C * y4 + second.E;
		double num9 = second.B * x4 + second.D * y4 + second.F;
		x4 = num;
		y4 = num9;
		num = third.A * x + third.C * y + third.E;
		double num10 = third.B * x + third.D * y + third.F;
		x = num;
		y = num10;
		num = third.A * x2 + third.C * y2 + third.E;
		double num11 = third.B * x2 + third.D * y2 + third.F;
		x2 = num;
		y2 = num11;
		num = third.A * x3 + third.C * y3 + third.E;
		double num12 = third.B * x3 + third.D * y3 + third.F;
		x3 = num;
		y3 = num12;
		num = third.A * x4 + third.C * y4 + third.E;
		double num13 = third.B * x4 + third.D * y4 + third.F;
		x4 = num;
		y4 = num13;
		return new PdfRectangle(new PdfPoint(x, y), new PdfPoint(x2, y2), new PdfPoint(x3, y3), new PdfPoint(x4, y4));
	}
}
