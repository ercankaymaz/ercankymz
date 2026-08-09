using System;
using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzR8aYWyXm6crFsaZUZBMtoMwCrSnf
{
	private static readonly double[] _0023_003DzUwI14FDarzRt = new double[16]
	{
		1.0, 1.0, 1.0, 0.5, 0.0, -0.5, -1.0, -1.0, -1.0, -1.0,
		-1.0, -0.5, 0.0, 0.5, 1.0, 1.0
	};

	private static readonly double[] _0023_003DzMkQvzBg5A7KA = new double[16]
	{
		0.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.0, -0.5,
		-1.0, -1.0, -1.0, -1.0, -1.0, -0.5
	};

	private static readonly double[] _0023_003DzPmMX3DQk1Mt3GgSpuA_003D_003D = new double[8] { 1.0, 1.0, 0.0, -1.0, -1.0, -1.0, 0.0, 1.0 };

	private static readonly double[] _0023_003DziT2z9AEBuqgRkErsBA_003D_003D = new double[8] { 0.0, 1.0, 1.0, 1.0, 0.0, -1.0, -1.0, -1.0 };

	public static void _0023_003Dzd_0024POhtlm_0024NUA(ShapeSymbol _0023_003DzZpv8eJs_003D, Point3D _0023_003DzsDtOqZU_003D, double _0023_003DzuNPc2ZU_003D, double _0023_003DzQsByFeA_003D, out IEnumerable<Entity> _0023_003DzXcLkCuQ_003D, out double _0023_003DzGTN79r_0024F30Xo, out double _0023_003DzNbj8rYZeWiA5, out Point2D _0023_003DzyxnDTtrmIGfX, out Point2D _0023_003Dz1WsMKJau85vH)
	{
		Stack<Point3D> stack = new Stack<Point3D>();
		List<Entity> list = new List<Entity>();
		double _0023_003DzGTN79r_0024F30Xo2 = _0023_003DzsDtOqZU_003D.X;
		double _0023_003DzNbj8rYZeWiA6 = _0023_003DzsDtOqZU_003D.Y;
		double num = _0023_003DzGTN79r_0024F30Xo2;
		double num2 = _0023_003DzNbj8rYZeWiA6;
		bool flag = true;
		bool flag2 = false;
		_0023_003Dz1WsMKJau85vH = new Point2D(0.0, 0.0);
		_0023_003DzyxnDTtrmIGfX = new Point2D(0.0, 0.0);
		foreach (ShapeSymbolComponent item5 in _0023_003DzZpv8eJs_003D.Items)
		{
			if (flag2)
			{
				flag2 = false;
				continue;
			}
			ShapeSymbolComponentWithParams shapeSymbolComponentWithParams = item5 as ShapeSymbolComponentWithParams;
			switch (item5.Command)
			{
			case ShapeCommand.ProcessNextCommandOnlyIfVerticalText:
				flag2 = true;
				break;
			case ShapeCommand.PenDown:
				flag = true;
				break;
			case ShapeCommand.PenUp:
				flag = false;
				break;
			case ShapeCommand.PushCurrentLocationOntoStack:
				stack.Push(new Point3D(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6));
				break;
			case ShapeCommand.PopCurrentLocationFromStack:
			{
				Point3D point3D3 = stack.Pop();
				_0023_003DzGTN79r_0024F30Xo2 = (num = point3D3.X);
				_0023_003DzNbj8rYZeWiA6 = (num2 = point3D3.Y);
				break;
			}
			case ShapeCommand.MultiplyVectorLengths:
				_0023_003DzuNPc2ZU_003D *= (double)shapeSymbolComponentWithParams.Params[0];
				break;
			case ShapeCommand.DivideVectorLengths:
				_0023_003DzuNPc2ZU_003D /= (double)shapeSymbolComponentWithParams.Params[0];
				break;
			case ShapeCommand.XYDisplacement:
				num = _0023_003DzGTN79r_0024F30Xo2 + (double)shapeSymbolComponentWithParams.Params[0] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				num2 = _0023_003DzNbj8rYZeWiA6 + (double)shapeSymbolComponentWithParams.Params[1] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				if (flag)
				{
					list.Add(new Line(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6, num, num2));
				}
				_0023_003DzGTN79r_0024F30Xo2 = num;
				_0023_003DzNbj8rYZeWiA6 = num2;
				break;
			case ShapeCommand.MultipleXYDisplacements:
			{
				int i = 0;
				for (int num13 = shapeSymbolComponentWithParams.Params.Length; i < num13; i += 2)
				{
					num = _0023_003DzGTN79r_0024F30Xo2 + (double)shapeSymbolComponentWithParams.Params[i] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
					num2 = _0023_003DzNbj8rYZeWiA6 + (double)shapeSymbolComponentWithParams.Params[i + 1] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
					if (flag)
					{
						list.Add(new Line(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6, num, num2));
					}
					_0023_003DzGTN79r_0024F30Xo2 = num;
					_0023_003DzNbj8rYZeWiA6 = num2;
				}
				break;
			}
			case ShapeCommand.RegularLine:
			{
				ShapeSymbolRegularLine shapeSymbolRegularLine = (ShapeSymbolRegularLine)item5;
				num = _0023_003DzGTN79r_0024F30Xo2 + (double)shapeSymbolRegularLine.Length * _0023_003DzUwI14FDarzRt[shapeSymbolRegularLine.Direction] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				num2 = _0023_003DzNbj8rYZeWiA6 + (double)shapeSymbolRegularLine.Length * _0023_003DzMkQvzBg5A7KA[shapeSymbolRegularLine.Direction] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				if (flag)
				{
					list.Add(new Line(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6, num, num2));
				}
				_0023_003DzGTN79r_0024F30Xo2 = num;
				_0023_003DzNbj8rYZeWiA6 = num2;
				break;
			}
			case ShapeCommand.ArcDefinedByXYDisplacementAndBulge:
			{
				num = _0023_003DzGTN79r_0024F30Xo2 + (double)shapeSymbolComponentWithParams.Params[0] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				num2 = _0023_003DzNbj8rYZeWiA6 + (double)shapeSymbolComponentWithParams.Params[1] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				double num16 = (double)shapeSymbolComponentWithParams.Params[2] / 127.0;
				Vector3D vector3D3 = new Vector3D(num - _0023_003DzGTN79r_0024F30Xo2, num2 - _0023_003DzNbj8rYZeWiA6);
				Vector3D vector3D4 = Vector3D.Cross(vector3D3, Vector3D.AxisZ);
				if (flag)
				{
					Point3D point3D2 = new Point3D(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6);
					Arc item4 = new Arc(point3D2, point3D2 + vector3D3 / 2.0 + vector3D4 * num16 / 2.0, new Point3D(num, num2), flip: false);
					list.Add(item4);
				}
				_0023_003DzGTN79r_0024F30Xo2 = num;
				_0023_003DzNbj8rYZeWiA6 = num2;
				break;
			}
			case ShapeCommand.MultipleBulgeSpecifiedArcs:
			{
				int j = 0;
				for (int num14 = shapeSymbolComponentWithParams.Params.Length; j < num14; j += 3)
				{
					num = _0023_003DzGTN79r_0024F30Xo2 + (double)shapeSymbolComponentWithParams.Params[j] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
					num2 = _0023_003DzNbj8rYZeWiA6 + (double)shapeSymbolComponentWithParams.Params[j + 1] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
					double num15 = (double)shapeSymbolComponentWithParams.Params[j + 2] * _0023_003DzuNPc2ZU_003D / 127.0;
					Vector3D vector3D = new Vector3D(num - _0023_003DzGTN79r_0024F30Xo2, num2 - _0023_003DzNbj8rYZeWiA6);
					Vector3D vector3D2 = Vector3D.Cross(vector3D, Vector3D.AxisZ);
					if (flag)
					{
						Point3D point3D = new Point3D(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6);
						try
						{
							if (!new Vector3D(point3D, point3D + vector3D / 2.0 + vector3D2 * num15 / 2.0, new Point3D(num, num2)).IsZero)
							{
								Arc item = new Arc(point3D, point3D + vector3D / 2.0 + vector3D2 * num15 / 2.0, new Point3D(num, num2), flip: false);
								list.Add(item);
							}
							else
							{
								LinearPath item2 = new LinearPath(point3D, point3D + vector3D / 2.0 + vector3D2 * num15 / 2.0, new Point3D(num, num2));
								list.Add(item2);
							}
						}
						catch (Exception)
						{
							LinearPath item3 = new LinearPath(point3D, point3D + vector3D / 2.0 + vector3D2 * num15 / 2.0, new Point3D(num, num2));
							list.Add(item3);
						}
					}
					_0023_003DzGTN79r_0024F30Xo2 = num;
					_0023_003DzNbj8rYZeWiA6 = num2;
				}
				break;
			}
			case ShapeCommand.OctantArc:
			{
				int num17 = shapeSymbolComponentWithParams.Params[1];
				int num18 = ((num17 >= 0) ? 1 : (-1));
				byte b2 = (byte)((num17 & 0x70) >> 4);
				byte num19 = (byte)(num17 & 0xF);
				double num20 = Utility.DegToRad(45 * b2);
				int num21 = num19;
				double num22 = Utility.DegToRad(45 * num21);
				if (num22 == 0.0)
				{
					num22 = 360.0;
				}
				double endAngleInRadians = num20 + num22 * (double)num18;
				double num23 = (double)shapeSymbolComponentWithParams.Params[0] * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				Arc arc2 = new Arc(new Point3D(_0023_003DzGTN79r_0024F30Xo2 - Math.Cos(num20) * num23, _0023_003DzNbj8rYZeWiA6 - Math.Sin(num20) * num23, 0.0), num23, num20, endAngleInRadians);
				if (flag)
				{
					list.Add(arc2);
				}
				_0023_003DzGTN79r_0024F30Xo2 = arc2.EndPoint.X;
				_0023_003DzNbj8rYZeWiA6 = arc2.EndPoint.Y;
				break;
			}
			case ShapeCommand.DrawSubshapeNumberGiven:
			{
				_0023_003DzZpv8eJs_003D.Owner.Shapes.TryGetValue((char)shapeSymbolComponentWithParams.Params[0], out var value);
				if (value != null)
				{
					_0023_003Dzd_0024POhtlm_0024NUA(value, new Point3D(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6), _0023_003DzuNPc2ZU_003D, _0023_003DzQsByFeA_003D, out var _0023_003DzXcLkCuQ_003D2, out _0023_003DzGTN79r_0024F30Xo2, out _0023_003DzNbj8rYZeWiA6, out _0023_003DzyxnDTtrmIGfX, out _0023_003Dz1WsMKJau85vH);
					list.AddRange(_0023_003DzXcLkCuQ_003D2);
				}
				break;
			}
			case ShapeCommand.FractionalArc:
			{
				double num3 = shapeSymbolComponentWithParams.Params[0];
				double num4 = shapeSymbolComponentWithParams.Params[1];
				double num5 = shapeSymbolComponentWithParams.Params[2];
				double num6 = ((double)shapeSymbolComponentWithParams.Params[3] + 256.0 * num5) * _0023_003DzuNPc2ZU_003D * _0023_003DzQsByFeA_003D;
				int num7 = shapeSymbolComponentWithParams.Params[4];
				int num8 = ((num7 >= 0) ? 1 : (-1));
				byte b = (byte)((num7 & 0x70) >> 4);
				byte num9 = (byte)(num7 & 0xF);
				double num10 = (double)num8 * 45.0 * (double)(int)b;
				int num11 = num9;
				if (num4 != 0.0)
				{
					num11--;
				}
				if ((double)num11 == 0.0)
				{
					num11 = 8;
				}
				double num12 = num10 + (double)(num8 * num11 * 45);
				num10 = Utility.DegToRad(num3 * (45.0 / 256.0) + num10);
				num12 = Utility.DegToRad(num4 * (45.0 / 256.0) + num12);
				Arc arc = new Arc(new Point3D(_0023_003DzGTN79r_0024F30Xo2 - Math.Cos(num10) * num6, _0023_003DzNbj8rYZeWiA6 - Math.Sin(num10) * num6, 0.0), num6, num10, num12);
				if (flag)
				{
					list.Add(arc);
				}
				_0023_003DzGTN79r_0024F30Xo2 = arc.EndPoint.X;
				_0023_003DzNbj8rYZeWiA6 = arc.EndPoint.Y;
				break;
			}
			default:
				throw new NotSupportedException();
			}
		}
		_0023_003DzXcLkCuQ_003D = list;
		_0023_003DzGTN79r_0024F30Xo = num;
		_0023_003DzNbj8rYZeWiA5 = num2;
		if (list.Count > 0)
		{
			Point2D startPoint = ((ICurve)list[0]).StartPoint;
			Point2D endPoint = ((ICurve)list[0]).EndPoint;
			_0023_003DzyxnDTtrmIGfX = new Point2D(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y));
			_0023_003Dz1WsMKJau85vH = new Point2D(Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y));
			for (int k = 1; k < list.Count; k++)
			{
				startPoint = ((ICurve)list[k]).StartPoint;
				endPoint = ((ICurve)list[k]).EndPoint;
				if (startPoint.X > _0023_003Dz1WsMKJau85vH.X)
				{
					_0023_003Dz1WsMKJau85vH.X = startPoint.X;
				}
				if (startPoint.Y > _0023_003Dz1WsMKJau85vH.Y)
				{
					_0023_003Dz1WsMKJau85vH.Y = startPoint.Y;
				}
				if (startPoint.X < _0023_003DzyxnDTtrmIGfX.X)
				{
					_0023_003DzyxnDTtrmIGfX.X = startPoint.X;
				}
				if (startPoint.Y < _0023_003DzyxnDTtrmIGfX.Y)
				{
					_0023_003DzyxnDTtrmIGfX.Y = startPoint.Y;
				}
				if (endPoint.X > _0023_003Dz1WsMKJau85vH.X)
				{
					_0023_003Dz1WsMKJau85vH.X = endPoint.X;
				}
				if (endPoint.Y > _0023_003Dz1WsMKJau85vH.Y)
				{
					_0023_003Dz1WsMKJau85vH.Y = endPoint.Y;
				}
				if (endPoint.X < _0023_003DzyxnDTtrmIGfX.X)
				{
					_0023_003DzyxnDTtrmIGfX.X = endPoint.X;
				}
				if (endPoint.Y < _0023_003DzyxnDTtrmIGfX.Y)
				{
					_0023_003DzyxnDTtrmIGfX.Y = endPoint.Y;
				}
			}
		}
		else
		{
			_0023_003DzyxnDTtrmIGfX = new Point2D(0.0, 0.0);
			_0023_003Dz1WsMKJau85vH = new Point2D(_0023_003DzGTN79r_0024F30Xo2, _0023_003DzNbj8rYZeWiA6);
		}
	}
}
