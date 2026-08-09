using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class LineType : ICloneable, IKeyedCollectionItem<LineType>, INotifyKeyChanged, IEquatable<LineType>, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz5KguOoA_003D = 1;

	public string XRefName { get; internal set; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!string.Equals(_name, value, StringComparison.OrdinalIgnoreCase))
			{
				OnKeyChanged(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
				_name = value;
			}
		}
	}

	public float[] Pattern { get; }

	public string Description { get; set; }

	[XmlIgnore]
	public float Length { get; }

	public event KeyChangedEventHandler KeyChanged
	{
		[CompilerGenerated]
		add
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Combine(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Remove(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
	}

	public LineType(string name, float[] pattern, string description = null)
	{
		CheckPattern(pattern, throwEx: true, out var sum);
		Name = name;
		_0023_003DzXpSP_0024o4OOYZB(pattern);
		_0023_003Dzz7VuV7VFyvdX(sum);
		Description = description;
	}

	public LineType(LineType another)
	{
		Name = another.Name;
		if (another.Pattern != null)
		{
			_0023_003DzXpSP_0024o4OOYZB(new float[another.Pattern.Length]);
			for (int i = 0; i < another.Pattern.Length; i++)
			{
				Pattern[i] = another.Pattern[i];
			}
		}
		_0023_003Dzz7VuV7VFyvdX(another.Length);
		Description = another.Description;
		XRefName = another.XRefName;
	}

	protected LineType(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		Description = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019));
		_0023_003DzXpSP_0024o4OOYZB((float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985900), typeof(float[])));
		_0023_003Dzz7VuV7VFyvdX((float)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985882), typeof(float)));
		XRefName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264));
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public LineType(float[] pattern, string description = null)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988559), _0023_003Dz5KguOoA_003D++), pattern, description)
	{
	}

	protected internal LineType(LineTypeSurrogate surrogate)
		: this(surrogate.Name, surrogate.Pattern)
	{
	}

	private void _0023_003DzaFFNyIFrZikPLuTPQK7cutgtnC4anl_0024Xk1MOG4s_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		XRefName = _0023_003DzPzO_0024GUk_003D;
	}

	void IWriteDataEx.set_XRefName(string _0023_003DzPzO_0024GUk_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zaFFNyIFrZikPLuTPQK7cutgtnC4anl$Xk1MOG4s=
		this._0023_003DzaFFNyIFrZikPLuTPQK7cutgtnC4anl_0024Xk1MOG4s_003D(_0023_003DzPzO_0024GUk_003D);
	}

	public override string ToString()
	{
		return Name;
	}

	public bool Equals(LineType other)
	{
		return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
	}

	protected virtual void OnKeyChanged(string newKey, [CallerMemberName] string propertyName = null)
	{
		_0023_003Dzs0Yhv2U_003D?.Invoke(this, new KeyChangedEventArgs(propertyName, newKey));
	}

	public string GetKey()
	{
		return Name;
	}

	public void SetKey(string value)
	{
		Name = value;
	}

	private void _0023_003DzXpSP_0024o4OOYZB(float[] _0023_003DzPzO_0024GUk_003D)
	{
		Pattern = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dzz7VuV7VFyvdX(float _0023_003DzPzO_0024GUk_003D)
	{
		Length = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Description);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), Description);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985900), Pattern);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985882), Length);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), XRefName);
	}

	public static bool CheckPattern(float[] pattern, bool throwEx, out float sum)
	{
		sum = 0f;
		if (pattern != null && pattern.Length != 0)
		{
			bool flag = false;
			if (pattern.Length > 1)
			{
				flag = true;
			}
			int num = Math.Sign(pattern[0]);
			sum = Math.Abs(pattern[0]);
			bool flag2 = true;
			for (int i = 1; i < pattern.Length; i++)
			{
				int num2 = Math.Sign(pattern[i]);
				if (pattern[i] != 0f && num2 == num)
				{
					flag = false;
				}
				num = num2;
				if (pattern[i] != 0f)
				{
					flag2 = false;
				}
				sum += Math.Abs(pattern[i]);
			}
			if (flag2 || !flag)
			{
				if (throwEx)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988778));
				}
				return false;
			}
		}
		return true;
	}

	protected internal static void GetPenDowns(Segment3D seg, float[] pattern, float scale, out Segment3D[] penDownList, ref int index, ref double excess)
	{
		List<Segment3D> list = new List<Segment3D>();
		if (pattern == null || pattern.Length == 0)
		{
			penDownList = list.ToArray();
			return;
		}
		int num = index;
		double num2 = ((excess != 0.0) ? (excess - (double)Math.Abs(pattern[num] * scale)) : 0.0);
		double length = seg.Length;
		do
		{
			Point3D point3D = seg.PointAt((num2 > 0.0) ? (num2 / length) : 0.0);
			double num3 = pattern[num] * scale;
			int num4 = Math.Sign(num3);
			num2 += Math.Abs(num3);
			Point3D p = (Point3D)point3D.Clone();
			if (num3 == 0.0)
			{
				num4 = 1;
			}
			else
			{
				p = seg.PointAt((num2 < length) ? (num2 / length) : 1.0);
			}
			if (num4 == 1)
			{
				list.Add(new Segment3D(point3D, p));
			}
			num++;
			if (num > pattern.Length - 1)
			{
				num = 0;
			}
		}
		while (num2 < length);
		penDownList = list.ToArray();
		excess = num2 - length;
		if (excess > 0.0)
		{
			index = num - 1;
		}
		if (index < 0)
		{
			index = pattern.Length - 1;
		}
	}

	public virtual void GetPatternVertices(int maxPatternRepetitions, Point3D[] vertices, float scale, out List<Point3D> lines, out List<Point3D> points, Transformation transformation = null)
	{
		int index = 0;
		double excess = 0.0;
		lines = new List<Point3D>();
		points = new List<Point3D>();
		for (int i = 0; i < vertices.Length - 1; i++)
		{
			Point3D point3D = vertices[i];
			Point3D point3D2 = vertices[i + 1];
			Segment3D segment3D = new Segment3D(point3D, point3D2);
			if (segment3D.Length == 0.0)
			{
				continue;
			}
			Vector3D vector3D = Vector3D.Subtract(segment3D.P1, segment3D.P0);
			vector3D.Normalize();
			float num = 1f;
			float num2 = (float)_0023_003DzH7YMRMzBkreM(transformation, point3D, point3D2);
			num = scale / num2;
			if (segment3D.Length / (double)(Length * num) > (double)maxPatternRepetitions)
			{
				lines.Add(point3D);
				lines.Add(point3D2);
				continue;
			}
			GetPenDowns(segment3D, Pattern, num, out var penDownList, ref index, ref excess);
			Segment3D[] array = penDownList;
			foreach (Segment3D segment3D2 in array)
			{
				if (segment3D2.LengthSquared > 0.0)
				{
					lines.Add(segment3D2.P0);
					lines.Add(segment3D2.P1);
				}
				else
				{
					points.Add(new PointTangent(segment3D2.P0.X, segment3D2.P0.Y, segment3D2.P0.Z, vector3D.X, vector3D.Y, vector3D.Z));
				}
			}
		}
	}

	private double _0023_003DzH7YMRMzBkreM(Transformation _0023_003Dz63vmKM0_003D, Point3D _0023_003DzAqOpw0w_003D, Point3D _0023_003Dzk64JNOo_003D)
	{
		if (_0023_003Dz63vmKM0_003D == null)
		{
			return 1.0;
		}
		if (_0023_003Dz63vmKM0_003D.IsScaleFactorUniform())
		{
			return Math.Abs(_0023_003Dz63vmKM0_003D.ScaleFactorX);
		}
		double scaleFactorX = _0023_003Dz63vmKM0_003D.ScaleFactorX;
		double scaleFactorY = _0023_003Dz63vmKM0_003D.ScaleFactorY;
		double scaleFactorZ = _0023_003Dz63vmKM0_003D.ScaleFactorZ;
		double num = _0023_003Dzk64JNOo_003D.X - _0023_003DzAqOpw0w_003D.X;
		double num2 = _0023_003Dzk64JNOo_003D.Y - _0023_003DzAqOpw0w_003D.Y;
		double num3 = _0023_003Dzk64JNOo_003D.Z - _0023_003DzAqOpw0w_003D.Z;
		double num4 = num * num + num2 * num2 + num3 * num3;
		return Math.Sqrt((scaleFactorX * scaleFactorX * num * num + scaleFactorY * scaleFactorY * num2 * num2 + scaleFactorZ * scaleFactorZ * num3 * num3) / num4);
	}

	public virtual object Clone()
	{
		return new LineType(this);
	}

	public virtual LineTypeSurrogate ConvertToSurrogate()
	{
		return new LineTypeSurrogate(this);
	}
}
