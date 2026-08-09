using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal static class _0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D
{
	private static class _0023_003DzQm9ltrs_003D
	{
		public static Func<string, int> _0023_003Dz1PTmWyOAgr7_0024;
	}

	public static Size3D _0023_003DzO8EKqG0_003D = new Size3D(350.0, 350.0, 350.0);

	public static void _0023_003DzqvY7kwQPqWGI82uuJKHwZYs_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D[] _0023_003DzztJY0_0024dXEFMk, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, PointF[] _0023_003DzvvQasot93J6ULaLy4w_003D_003D)
	{
		_0023_003Dz9vvXgv9dKrEuHtqlIg_003D_003D(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzvvQasot93J6ULaLy4w_003D_003D, _0023_003DzdL2aVS7MjFes: true);
	}

	public static void _0023_003Dzkyv9axSJ96BJ(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D[] _0023_003DzztJY0_0024dXEFMk, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, PointF[] _0023_003DzvvQasot93J6ULaLy4w_003D_003D)
	{
		_0023_003Dz9vvXgv9dKrEuHtqlIg_003D_003D(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzvvQasot93J6ULaLy4w_003D_003D, _0023_003DzdL2aVS7MjFes: false);
	}

	private static void _0023_003Dz9vvXgv9dKrEuHtqlIg_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D[] _0023_003DzztJY0_0024dXEFMk, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, PointF[] _0023_003DzvvQasot93J6ULaLy4w_003D_003D, bool _0023_003DzdL2aVS7MjFes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = new List<int>();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num = 0;
		StringBuilder stringBuilder3 = new StringBuilder();
		int num2 = 0;
		StringBuilder stringBuilder4 = new StringBuilder();
		int num3 = 0;
		StringBuilder stringBuilder5 = new StringBuilder();
		int num4 = 0;
		StringBuilder stringBuilder6 = new StringBuilder();
		int num5 = 0;
		int num6;
		if (_0023_003DzdL2aVS7MjFes)
		{
			num6 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
			for (int i = 0; i < num6; i++)
			{
				Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
				stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), point3D.X, point3D.Y, point3D.Z);
				num++;
				PointRGB pointRGB = point3D as PointRGB;
				if (pointRGB != null)
				{
					stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dz6rYa5HpnYZEd(pointRGB.R), _0023_003Dz6rYa5HpnYZEd(pointRGB.G), _0023_003Dz6rYa5HpnYZEd(pointRGB.B));
					num2++;
				}
			}
			num6 = _0023_003DzztJY0_0024dXEFMk.Length;
			for (int j = 0; j < num6; j++)
			{
				Vector3D vector3D = _0023_003DzztJY0_0024dXEFMk[j];
				stringBuilder5.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), vector3D.X, vector3D.Y, vector3D.Z);
				num4++;
			}
		}
		num6 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length;
		for (int k = 0; k < num6; k++)
		{
			IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[k];
			if (_0023_003DzdL2aVS7MjFes)
			{
				stringBuilder4.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				num3++;
			}
			else
			{
				Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1];
				Point3D point3D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2];
				Point3D point3D4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3];
				stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653798), point3D2.X, point3D2.Y, point3D2.Z, point3D3.X, point3D3.Y, point3D3.Z, point3D4.X, point3D4.Y, point3D4.Z);
				num += 3;
				PointRGB pointRGB2 = point3D2 as PointRGB;
				if (pointRGB2 != null)
				{
					PointRGB pointRGB3 = (PointRGB)point3D3;
					PointRGB pointRGB4 = (PointRGB)point3D4;
					stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653798), _0023_003Dz6rYa5HpnYZEd(pointRGB2.R), _0023_003Dz6rYa5HpnYZEd(pointRGB2.G), _0023_003Dz6rYa5HpnYZEd(pointRGB2.B), _0023_003Dz6rYa5HpnYZEd(pointRGB3.R), _0023_003Dz6rYa5HpnYZEd(pointRGB3.G), _0023_003Dz6rYa5HpnYZEd(pointRGB3.B), _0023_003Dz6rYa5HpnYZEd(pointRGB4.R), _0023_003Dz6rYa5HpnYZEd(pointRGB4.G), _0023_003Dz6rYa5HpnYZEd(pointRGB4.B));
					num2 += 3;
				}
				if (indexTriangle is ITriangleSupportsNormals)
				{
					ITriangleSupportsNormals triangleSupportsNormals = (ITriangleSupportsNormals)indexTriangle;
					Vector3D vector3D2 = _0023_003DzztJY0_0024dXEFMk[triangleSupportsNormals.N1];
					Vector3D vector3D3 = _0023_003DzztJY0_0024dXEFMk[triangleSupportsNormals.N2];
					Vector3D vector3D4 = _0023_003DzztJY0_0024dXEFMk[triangleSupportsNormals.N3];
					stringBuilder5.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653798), vector3D2.X, vector3D2.Y, vector3D2.Z, vector3D3.X, vector3D3.Y, vector3D3.Z, vector3D4.X, vector3D4.Y, vector3D4.Z);
				}
				else
				{
					Vector3D vector3D5 = _0023_003DzztJY0_0024dXEFMk[k];
					stringBuilder5.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653775), vector3D5.X, vector3D5.Y, vector3D5.Z);
				}
				num4 += 3;
			}
			if (_0023_003DzvvQasot93J6ULaLy4w_003D_003D != null && _0023_003DzvvQasot93J6ULaLy4w_003D_003D.Length != 0)
			{
				if (indexTriangle is ITriangleSupportsTextureCoords)
				{
					ITriangleSupportsTextureCoords triangleSupportsTextureCoords = (ITriangleSupportsTextureCoords)indexTriangle;
					PointF pointF = _0023_003DzvvQasot93J6ULaLy4w_003D_003D[triangleSupportsTextureCoords.T1];
					PointF pointF2 = _0023_003DzvvQasot93J6ULaLy4w_003D_003D[triangleSupportsTextureCoords.T2];
					PointF pointF3 = _0023_003DzvvQasot93J6ULaLy4w_003D_003D[triangleSupportsTextureCoords.T3];
					stringBuilder6.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653724), pointF.X, pointF.Y, pointF2.X, pointF2.Y, pointF3.X, pointF3.Y);
				}
				else
				{
					PointF pointF4 = _0023_003DzvvQasot93J6ULaLy4w_003D_003D[k];
					stringBuilder6.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653945), pointF4.X, pointF4.Y);
				}
				num5 += 3;
			}
		}
		if (num == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653914));
		}
		stringBuilder.Append(stringBuilder2);
		list.Add(num * 3);
		if (num2 > 0)
		{
			stringBuilder.Append(stringBuilder3);
			list.Add(num2 * 3);
		}
		else
		{
			list.Add(0);
		}
		if (_0023_003DzdL2aVS7MjFes)
		{
			stringBuilder.Append(stringBuilder4);
			list.Add(num3 * 3);
		}
		else
		{
			list.Add(0);
		}
		stringBuilder.Append(stringBuilder5);
		list.Add(num4 * 3);
		Color _0023_003Dz1MMYB1g_003D = _0023_003DzmPmPjCPqZ3T3._0023_003Dz_8C3BH8_003D();
		Material material = _0023_003DzmPmPjCPqZ3T3._0023_003Dzjl5IbJ4_003D();
		if (num5 == 0)
		{
			list.Add(0);
			_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653857));
		}
		else
		{
			stringBuilder.Append(stringBuilder6);
			list.Add(num5 * 2);
			_0023_003DzWfMsPtFP4L4teUoq4A_003D_003D(material, _0023_003DzmPmPjCPqZ3T3._0023_003DzCQx6woK2STqH2wgQXQ_003D_003D, _0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D);
		}
		if (material != null && material.AlphaMapImage != null)
		{
			string value = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653851) + _0023_003DzDgyZvti9A9vL(material.AlphaMapImage, null) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653555);
			_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(value);
		}
		else
		{
			_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653566));
		}
		stringBuilder.Append(_0023_003Dzgt6FfZvgxJft(_0023_003Dz1MMYB1g_003D, material, out var _0023_003DzXhkyOlA_003D));
		list.Add(_0023_003DzXhkyOlA_003D * 3);
		if (material == null)
		{
			list.Add(0);
		}
		else
		{
			stringBuilder.Append(material.Shininess.ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
			list.Add(1);
		}
		stringBuilder.Append(((float)(int)_0023_003Dz1MMYB1g_003D.A / 255f).ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
		list.Add(1);
		stringBuilder.Append(_0023_003Dz_00241B_00246ZX3Ynhi(_0023_003DzmPmPjCPqZ3T3.Transformation));
		list.Add(16);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653530), _0023_003Dzv3_7U5ut0aI_0024(stringBuilder.ToString())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653492), string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), list.ToArray())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653485));
	}

	private static void _0023_003DzWfMsPtFP4L4teUoq4A_003D_003D(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, Dictionary<Material, int> _0023_003DzCQx6woK2STqH2wgQXQ_003D_003D, StringBuilder _0023_003DzgyYoHow_003D)
	{
		if (!_0023_003DzCQx6woK2STqH2wgQXQ_003D_003D.TryGetValue(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, out var value))
		{
			value = _0023_003DzCQx6woK2STqH2wgQXQ_003D_003D.Keys.Count;
			string value2 = ((_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.TextureImage == null) ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653623), value) : (string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653657), value) + _0023_003DzDgyZvti9A9vL(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.TextureImage, null) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653555)));
			_0023_003DzgyYoHow_003D.AppendLine(value2);
			_0023_003DzCQx6woK2STqH2wgQXQ_003D_003D[_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D] = value;
		}
		_0023_003DzgyYoHow_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653593), value));
	}

	public static void _0023_003DzcWQwCzqUaihGvo7GI4WUJx8_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, float[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, float[] _0023_003DzztJY0_0024dXEFMk, int[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, byte[] _0023_003DzZQ2HyLn4R0pl)
	{
		_0023_003Dz14xDbHn_0024RZSc3HfYYg_003D_003D(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzZQ2HyLn4R0pl, _0023_003DzdL2aVS7MjFes: true);
	}

	public static void _0023_003DzNn5xfzPGwemnPlUh6w_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, float[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, float[] _0023_003DzztJY0_0024dXEFMk, int[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, byte[] _0023_003DzZQ2HyLn4R0pl)
	{
		_0023_003Dz14xDbHn_0024RZSc3HfYYg_003D_003D(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzZQ2HyLn4R0pl, _0023_003DzdL2aVS7MjFes: false);
	}

	private static void _0023_003Dz14xDbHn_0024RZSc3HfYYg_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, float[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, float[] _0023_003DzztJY0_0024dXEFMk, int[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, byte[] _0023_003DzZQ2HyLn4R0pl, bool _0023_003DzdL2aVS7MjFes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = new List<int>();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num = 0;
		StringBuilder stringBuilder3 = new StringBuilder();
		int num2 = 0;
		StringBuilder stringBuilder4 = new StringBuilder();
		int num3 = 0;
		StringBuilder stringBuilder5 = new StringBuilder();
		int num4 = 0;
		if (_0023_003DzdL2aVS7MjFes)
		{
			int num5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
			for (int i = 0; i < num5; i += 3)
			{
				stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2]);
				num++;
				if (_0023_003DzZQ2HyLn4R0pl != null)
				{
					stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[i]), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[i + 1]), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[i + 2]));
					num2++;
				}
			}
			num5 = _0023_003DzztJY0_0024dXEFMk.Length;
			for (int j = 0; j < num5; j += 3)
			{
				stringBuilder5.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003DzztJY0_0024dXEFMk[j], _0023_003DzztJY0_0024dXEFMk[j + 1], _0023_003DzztJY0_0024dXEFMk[j + 2]);
				num4++;
			}
		}
		if (_0023_003DzdL2aVS7MjFes)
		{
			int num5 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length;
			for (int k = 0; k < num5; k += 3)
			{
				stringBuilder4.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[k], _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[k + 1], _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[k + 2]);
				num3++;
			}
		}
		else
		{
			int num5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
			for (int l = 0; l < num5; l += 3)
			{
				stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l + 2]);
				num++;
				if (_0023_003DzZQ2HyLn4R0pl != null)
				{
					stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[l]), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[l + 1]), _0023_003Dz6rYa5HpnYZEd(_0023_003DzZQ2HyLn4R0pl[l + 2]));
					num2++;
				}
				stringBuilder5.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003DzztJY0_0024dXEFMk[l], _0023_003DzztJY0_0024dXEFMk[l + 1], _0023_003DzztJY0_0024dXEFMk[l + 2]);
				num4++;
			}
		}
		if (num == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653914));
		}
		stringBuilder.Append(stringBuilder2);
		list.Add(num * 3);
		if (num2 > 0)
		{
			stringBuilder.Append(stringBuilder3);
			list.Add(num2 * 3);
		}
		else
		{
			list.Add(0);
		}
		if (_0023_003DzdL2aVS7MjFes)
		{
			stringBuilder.Append(stringBuilder4);
			list.Add(num3 * 3);
		}
		else
		{
			list.Add(0);
		}
		stringBuilder.Append(stringBuilder5);
		list.Add(num4 * 3);
		Color _0023_003Dz1MMYB1g_003D = _0023_003DzmPmPjCPqZ3T3._0023_003Dz_8C3BH8_003D();
		Material material = _0023_003DzmPmPjCPqZ3T3._0023_003Dzjl5IbJ4_003D();
		list.Add(0);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653857));
		if (material != null && material.AlphaMapImage != null)
		{
			string value = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653851) + _0023_003DzDgyZvti9A9vL(material.AlphaMapImage, null) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653555);
			_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(value);
		}
		else
		{
			_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653566));
		}
		stringBuilder.Append(_0023_003Dzgt6FfZvgxJft(_0023_003Dz1MMYB1g_003D, material, out var _0023_003DzXhkyOlA_003D));
		list.Add(_0023_003DzXhkyOlA_003D * 3);
		if (material == null)
		{
			list.Add(0);
		}
		else
		{
			stringBuilder.Append(material.Shininess.ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
			list.Add(1);
		}
		stringBuilder.Append(((float)(int)_0023_003Dz1MMYB1g_003D.A / 255f).ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
		list.Add(1);
		stringBuilder.Append(_0023_003Dz_00241B_00246ZX3Ynhi(_0023_003DzmPmPjCPqZ3T3.Transformation));
		list.Add(16);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653530), _0023_003Dzv3_7U5ut0aI_0024(stringBuilder.ToString())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653492), string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), list.ToArray())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653485));
	}

	public static void _0023_003DzhQedXNzFzzR2(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Picture _0023_003DzWXcU6Os_003D)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = new List<int>();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930916), _0023_003DzWXcU6Os_003D.Width);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930916), _0023_003DzWXcU6Os_003D.Height);
		list.Add(2);
		Material material = _0023_003DzmPmPjCPqZ3T3._0023_003Dzjl5IbJ4_003D();
		stringBuilder.Append(_0023_003Dzgt6FfZvgxJft(_0023_003DzWXcU6Os_003D.Color, material, out var _0023_003DzXhkyOlA_003D));
		list.Add(_0023_003DzXhkyOlA_003D * 3);
		if (material == null)
		{
			list.Add(0);
		}
		else
		{
			stringBuilder.Append(material.Shininess.ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
			list.Add(1);
		}
		Transformation transformation = new Translation(_0023_003DzWXcU6Os_003D.Plane.AxisX * _0023_003DzWXcU6Os_003D.Width / 2.0) * new Translation(_0023_003DzWXcU6Os_003D.Plane.AxisY * _0023_003DzWXcU6Os_003D.Height / 2.0) * new Align3D(Plane.XY, _0023_003DzWXcU6Os_003D.Plane);
		stringBuilder.Append(_0023_003Dz_00241B_00246ZX3Ynhi(_0023_003DzmPmPjCPqZ3T3.Transformation * transformation));
		list.Add(16);
		string value = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654336) + _0023_003DzDgyZvti9A9vL(_0023_003DzWXcU6Os_003D.Image, null) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653555);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(value);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653530), _0023_003Dzv3_7U5ut0aI_0024(stringBuilder.ToString())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653492), string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), list.ToArray())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654293));
	}

	public static void _0023_003DzniXL2KDLitBX(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Entity _0023_003Dzs_0024uS8LA_003D)
	{
		Color color = _0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.Color;
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = new List<int>();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num = 0;
		int num2 = _0023_003Dzs_0024uS8LA_003D.Vertices.Length;
		for (int i = 0; i < num2; i++)
		{
			Point3D point3D = _0023_003Dzs_0024uS8LA_003D.Vertices[i];
			stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), point3D.X, point3D.Y, point3D.Z);
			num++;
		}
		stringBuilder.Append(stringBuilder2);
		list.Add(num * 3);
		stringBuilder.Append(_0023_003Dzgt6FfZvgxJft(color, out var _0023_003DzXhkyOlA_003D));
		list.Add(_0023_003DzXhkyOlA_003D * 3);
		stringBuilder.Append(_0023_003Dz_00241B_00246ZX3Ynhi(_0023_003DzmPmPjCPqZ3T3.Transformation));
		list.Add(16);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653530), _0023_003Dzv3_7U5ut0aI_0024(stringBuilder.ToString())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653492), string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), list.ToArray())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654229));
	}

	public static void _0023_003DzZ7IrhryCzDPgsLyK4A_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, float[] _0023_003DzrH1N0x4_003D, byte[] _0023_003Dz_0024YJVDoA_003D)
	{
		_0023_003Dza0GNh7ywHdAZzkJ_0024Xg_003D_003D(_0023_003DzmPmPjCPqZ3T3, null, _0023_003DzrH1N0x4_003D, _0023_003Dz_0024YJVDoA_003D);
	}

	public static void _0023_003DzZ7IrhryCzDPgsLyK4A_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003Dza0GNh7ywHdAZzkJ_0024Xg_003D_003D(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, null, null);
	}

	private static void _0023_003Dza0GNh7ywHdAZzkJ_0024Xg_003D_003D(_0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, float[] _0023_003DzrH1N0x4_003D, byte[] _0023_003Dz_0024YJVDoA_003D)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = new List<int>();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num = 0;
		StringBuilder stringBuilder3 = new StringBuilder();
		int num2 = 0;
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D != null)
		{
			num = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
			if (num > 0)
			{
				bool flag = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] is PointRGB;
				if (flag)
				{
					num2 = num;
				}
				for (int i = 0; i < num; i++)
				{
					Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
					stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), point3D.X, point3D.Y, point3D.Z);
					if (flag)
					{
						PointRGB pointRGB = (PointRGB)point3D;
						stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dz6rYa5HpnYZEd(pointRGB.R), _0023_003Dz6rYa5HpnYZEd(pointRGB.G), _0023_003Dz6rYa5HpnYZEd(pointRGB.B));
					}
				}
			}
		}
		else
		{
			num = _0023_003DzrH1N0x4_003D.Length / 3;
			foreach (float num3 in _0023_003DzrH1N0x4_003D)
			{
				stringBuilder2.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930916), num3);
			}
			if (_0023_003Dz_0024YJVDoA_003D != null && _0023_003Dz_0024YJVDoA_003D.Length != 0)
			{
				num2 = num;
				foreach (byte _0023_003DzCGvwRFi3tQgt in _0023_003Dz_0024YJVDoA_003D)
				{
					stringBuilder3.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930916), _0023_003Dz6rYa5HpnYZEd(_0023_003DzCGvwRFi3tQgt));
				}
			}
		}
		stringBuilder.Append(stringBuilder2);
		list.Add(num * 3);
		if (num2 > 0)
		{
			stringBuilder.Append(stringBuilder3);
			list.Add(num2 * 3);
		}
		else
		{
			list.Add(0);
		}
		stringBuilder.Append(_0023_003Dzgt6FfZvgxJft(_0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.GetColor(), out var _0023_003DzXhkyOlA_003D));
		list.Add(_0023_003DzXhkyOlA_003D * 3);
		stringBuilder.Append(_0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.LineWeight.ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
		list.Add(1);
		stringBuilder.Append(_0023_003Dz_00241B_00246ZX3Ynhi(_0023_003DzmPmPjCPqZ3T3.Transformation));
		list.Add(16);
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653530), _0023_003Dzv3_7U5ut0aI_0024(stringBuilder.ToString())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653492), string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), list.ToArray())));
		_0023_003DzmPmPjCPqZ3T3._0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654438));
	}

	private static string _0023_003Dzgt6FfZvgxJft(Color _0023_003Dz1MMYB1g_003D, out int _0023_003DzXhkyOlA_003D)
	{
		return _0023_003Dzgt6FfZvgxJft(_0023_003Dz1MMYB1g_003D, null, out _0023_003DzXhkyOlA_003D);
	}

	private static string _0023_003Dzgt6FfZvgxJft(Color _0023_003Dz1MMYB1g_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, out int _0023_003DzXhkyOlA_003D)
	{
		if (_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D == null)
		{
			_0023_003DzXhkyOlA_003D = 1;
			return string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653809), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.R), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.G), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.B));
		}
		Color ambient = _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Ambient;
		Color specular = _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Specular;
		_0023_003DzXhkyOlA_003D = 3;
		return string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653798), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.R), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.G), _0023_003Dz6rYa5HpnYZEd(_0023_003Dz1MMYB1g_003D.B), _0023_003Dz6rYa5HpnYZEd(ambient.R), _0023_003Dz6rYa5HpnYZEd(ambient.G), _0023_003Dz6rYa5HpnYZEd(ambient.B), _0023_003Dz6rYa5HpnYZEd(specular.R), _0023_003Dz6rYa5HpnYZEd(specular.G), _0023_003Dz6rYa5HpnYZEd(specular.B));
	}

	private static float _0023_003Dz6rYa5HpnYZEd(byte _0023_003DzCGvwRFi3tQgt)
	{
		return (float)(int)_0023_003DzCGvwRFi3tQgt / 255f;
	}

	private static string _0023_003Dz_00241B_00246ZX3Ynhi(Transformation _0023_003DzNDQ_E88_003D)
	{
		return string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654393), _0023_003DzNDQ_E88_003D.Matrix[0, 0], _0023_003DzNDQ_E88_003D.Matrix[0, 1], _0023_003DzNDQ_E88_003D.Matrix[0, 2], _0023_003DzNDQ_E88_003D.Matrix[0, 3], _0023_003DzNDQ_E88_003D.Matrix[1, 0], _0023_003DzNDQ_E88_003D.Matrix[1, 1], _0023_003DzNDQ_E88_003D.Matrix[1, 2], _0023_003DzNDQ_E88_003D.Matrix[1, 3], _0023_003DzNDQ_E88_003D.Matrix[2, 0], _0023_003DzNDQ_E88_003D.Matrix[2, 1], _0023_003DzNDQ_E88_003D.Matrix[2, 2], _0023_003DzNDQ_E88_003D.Matrix[2, 3], _0023_003DzNDQ_E88_003D.Matrix[3, 0], _0023_003DzNDQ_E88_003D.Matrix[3, 1], _0023_003DzNDQ_E88_003D.Matrix[3, 2], _0023_003DzNDQ_E88_003D.Matrix[3, 3]);
	}

	public static string _0023_003DzDgyZvti9A9vL(string _0023_003DzsGVhwNI_003D)
	{
		string _0023_003DzMGUyiVg_003D = Path.GetExtension(_0023_003DzsGVhwNI_003D).Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290), string.Empty);
		byte[] _0023_003DzlfGEbu0_003D = Array.Empty<byte>();
		Utility._0023_003DzIpZE2cw6usPZ(_0023_003DzsGVhwNI_003D);
		return _0023_003DzKY3eHj8_003D(_0023_003DzlfGEbu0_003D, _0023_003DzMGUyiVg_003D);
	}

	public static string _0023_003DzDgyZvti9A9vL(byte[] _0023_003DzF5zgtF4_003D, string _0023_003DzMGUyiVg_003D)
	{
		if (string.IsNullOrEmpty(_0023_003DzMGUyiVg_003D))
		{
			_0023_003DzMGUyiVg_003D = Utility._0023_003DzbVn8_FIsct0h(_0023_003DzF5zgtF4_003D);
		}
		return _0023_003DzKY3eHj8_003D(_0023_003DzF5zgtF4_003D, _0023_003DzMGUyiVg_003D);
	}

	private static string _0023_003DzKY3eHj8_003D(byte[] _0023_003DzlfGEbu0_003D, string _0023_003DzMGUyiVg_003D)
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654056) + _0023_003DzMGUyiVg_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654042) + Convert.ToBase64String(_0023_003DzlfGEbu0_003D);
	}

	private static int _0023_003DzzO2gi3iFLV_00241wBLnKQ_003D_003D(int _0023_003DzoMNiNRw_003D)
	{
		double y = Math.Floor(Math.Log(_0023_003DzoMNiNRw_003D, 2.0));
		return (int)Math.Pow(2.0, y);
	}

	private static string _0023_003Dzv3_7U5ut0aI_0024(string _0023_003Dzzg1saeM_003D)
	{
		_0023_003Dzzg1saeM_003D = _0023_003Dzzg1saeM_003D.TrimEnd(',');
		List<int> values = _0023_003DzBZsCn2M_003D(_0023_003Dzzg1saeM_003D);
		return string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), values);
	}

	public static List<int> _0023_003DzBZsCn2M_003D(string _0023_003Dz2Qh_0024DhAQ47Pv6eFOE2c5YP0_003D)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < 256; i++)
		{
			dictionary.Add(((char)i).ToString(CultureInfo.InvariantCulture), i);
		}
		string text = string.Empty;
		List<int> list = new List<int>();
		for (int j = 0; j < _0023_003Dz2Qh_0024DhAQ47Pv6eFOE2c5YP0_003D.Length; j++)
		{
			char c = _0023_003Dz2Qh_0024DhAQ47Pv6eFOE2c5YP0_003D[j];
			string text2 = text + c;
			if (dictionary.ContainsKey(text2))
			{
				text = text2;
				continue;
			}
			list.Add(dictionary[text]);
			dictionary.Add(text2, dictionary.Count);
			text = c.ToString(CultureInfo.InvariantCulture);
		}
		if (!string.IsNullOrEmpty(text))
		{
			list.Add(dictionary[text]);
		}
		return list;
	}

	public static string _0023_003DzFH071MCX8rC0yr3pgA_003D_003D(string _0023_003DzyP84EpA_003D, char _0023_003DzvcDZOW0_003D)
	{
		return _0023_003DzFH071MCX8rC0yr3pgA_003D_003D(_0023_003DzyP84EpA_003D.Split(_0023_003DzvcDZOW0_003D).Select(int.Parse).ToList());
	}

	public static string _0023_003DzFH071MCX8rC0yr3pgA_003D_003D(List<int> _0023_003DzyP84EpA_003D)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		for (int i = 0; i < 256; i++)
		{
			dictionary.Add(i, ((char)i).ToString());
		}
		string text = dictionary[_0023_003DzyP84EpA_003D[0]];
		_0023_003DzyP84EpA_003D.RemoveAt(0);
		StringBuilder stringBuilder = new StringBuilder(text);
		foreach (int item in _0023_003DzyP84EpA_003D)
		{
			string text2 = null;
			if (dictionary.ContainsKey(item))
			{
				text2 = dictionary[item];
			}
			else if (item == dictionary.Count)
			{
				text2 = text + text[0];
			}
			stringBuilder.Append(text2);
			dictionary.Add(dictionary.Count, text + text2[0]);
			text = text2;
		}
		return stringBuilder.ToString();
	}
}
