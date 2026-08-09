using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003DzLQX3FCEcKYExLk_0024XPw_003D_003D : IDisposable
{
	public _0023_003DzLQX3FCEcKYExLk_0024XPw_003D_003D()
	{
	}

	public _0023_003DzLQX3FCEcKYExLk_0024XPw_003D_003D(string _0023_003Dzs8RBkmU_003D, _0023_003DzDS4a8SQ0SZSap4ac3A_003D_003D _0023_003DzF7GfYSI_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DznmtGQqbIOMZhwIuA2g_003D_003D(_0023_003Dzs8RBkmU_003D, _0023_003DzF7GfYSI_003D);
	}

	public virtual void Dispose()
	{
	}

	private Point3D[] _0023_003DznmtGQqbIOMZhwIuA2g_003D_003D(string _0023_003Dzs8RBkmU_003D, _0023_003DzDS4a8SQ0SZSap4ac3A_003D_003D _0023_003DzF7GfYSI_003D)
	{
		int num = 0;
		int num2 = 0;
		float[] array = new float[3];
		float[,] array2 = new float[3, 3];
		new CultureInfo(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747141));
		int num3 = 0;
		StreamReader streamReader = null;
		try
		{
			streamReader = new StreamReader(new FileStream(_0023_003Dzs8RBkmU_003D, FileMode.Open, FileAccess.Read));
		}
		catch (Exception)
		{
			return null;
		}
		List<Point3D> list = new List<Point3D>();
		while (!streamReader.EndOfStream)
		{
			string[] array3 = streamReader.ReadLine().TrimStart(' ').Split(' ');
			switch (num)
			{
			case 0:
				if (array3[0].Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011837)))
				{
					num = 1;
				}
				break;
			case 1:
				if (array3[0].Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011817)))
				{
					array[0] = (float)Convert.ToDouble(array3[2]);
					array[1] = (float)Convert.ToDouble(array3[3]);
					array[2] = (float)Convert.ToDouble(array3[4]);
					num2 = 0;
					num = 2;
				}
				break;
			case 2:
				if (array3[0].Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011762)))
				{
					if (num2 <= 2)
					{
						array2[num2, 0] = (float)Convert.ToDouble(array3[1]);
						array2[num2, 1] = (float)Convert.ToDouble(array3[2]);
						array2[num2, 2] = (float)Convert.ToDouble(array3[3]);
						num2++;
					}
				}
				else if (array3[0].Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015891)))
				{
					if (num2 == 3)
					{
						double x = array2[0, 0];
						double y = array2[0, 1];
						double z = array2[0, 2];
						Point3D item = new Point3D(x, y, z);
						x = array2[1, 0];
						y = array2[1, 1];
						z = array2[1, 2];
						Point3D item2 = new Point3D(x, y, z);
						x = array2[2, 0];
						y = array2[2, 1];
						z = array2[2, 2];
						Point3D item3 = new Point3D(x, y, z);
						int count = list.Count;
						list.Add(item);
						list.Add(item2);
						list.Add(item3);
						_0023_003DzJSv_IuScKRfn _0023_003DzNDQ_E88_003D = new _0023_003DzJSv_IuScKRfn(count, count + 1, count + 2, list);
						_0023_003DzF7GfYSI_003D._0023_003DzIhSuV5Y_003D(_0023_003DzNDQ_E88_003D, list);
						num3++;
					}
					num = 1;
				}
				break;
			}
		}
		streamReader.Close();
		return list.ToArray();
	}
}
