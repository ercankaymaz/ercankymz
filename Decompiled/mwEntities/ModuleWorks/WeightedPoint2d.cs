using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class WeightedPoint2d<T> : Point2d<T>
{
	public T W { get; set; }

	public WeightedPoint2d(T x, T y, T w)
		: base(x, y)
	{
		W = w;
	}

	public WeightedPoint2d()
		: this(default(T), default(T), (T)Convert.ChangeType(1.0, typeof(T)))
	{
	}

	public WeightedPoint2d(T x, T y)
		: this(x, y, (T)Convert.ChangeType(1.0, typeof(T)))
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
			return string.Format(CultureInfo.InvariantCulture, "{0:0.000}; {1:0.000}; W = {2:0.000}", base.X, base.Y, W);
		}
		return string.Format(CultureInfo.InvariantCulture, "{0:0.000}; {1:0.000}; (No Weight)", base.X, base.Y);
	}
}
