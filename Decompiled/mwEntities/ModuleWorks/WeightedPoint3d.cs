using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class WeightedPoint3d<T> : Point3d<T>
{
	public T W { get; set; }

	public WeightedPoint3d(T x, T y, T z, T w)
		: base(x, y, z)
	{
		W = w;
	}

	public WeightedPoint3d()
		: this(default(T), default(T), default(T), (T)Convert.ChangeType(1.0, typeof(T)))
	{
	}

	public WeightedPoint3d(T x, T y, T z)
		: this(x, y, z, (T)Convert.ChangeType(1.0, typeof(T)))
	{
	}

	public override string ToString()
	{
		bool flag = true;
		if (typeof(T) == typeof(float))
		{
			flag = (float)(object)W != float.MinValue;
		}
		else if (typeof(T) == typeof(double))
		{
			flag = (double)(object)W != double.MinValue;
		}
		if (flag)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0.000}; {1:0.000}; {2:0.000}; W = {3:0.000}", base.X, base.Y, base.Z, W);
		}
		return string.Format(CultureInfo.InvariantCulture, "{0:0.000}; {1:0.000}; {2:0.000}; (No Weight)", base.X, base.Y, base.Z);
	}
}
