using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class HatchPattern : IKeyedCollectionItem<HatchPattern>, INotifyKeyChanged, ICloneable, IEquatable<HatchPattern>
{
	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

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

	public HatchPatternLine[] Lines { get; }

	public string Description { get; set; }

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

	public HatchPattern(string name, HatchPatternLine[] lines, string description = null)
	{
		Name = name;
		Lines = lines;
		Description = description;
	}

	public HatchPattern(HatchPattern another)
	{
		Name = another.Name;
		if (another.Lines != null)
		{
			Lines = new HatchPatternLine[another.Lines.Length];
			for (int i = 0; i < another.Lines.Length; i++)
			{
				Lines[i] = (HatchPatternLine)another.Lines[i].Clone();
			}
		}
		Description = another.Description;
	}

	protected HatchPattern(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		Lines = (HatchPatternLine[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985943), typeof(HatchPatternLine[]));
		Description = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019));
	}

	protected internal HatchPattern(HatchPatternSurrogate surrogate)
		: this(surrogate.Name, surrogate.Lines, surrogate.Description)
	{
	}

	public override string ToString()
	{
		return Name;
	}

	public bool Equals(HatchPattern other)
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

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Name);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985943), Lines);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), Description);
	}

	public virtual object Clone()
	{
		return new HatchPattern(this);
	}

	public virtual HatchPatternSurrogate ConvertToSurrogate()
	{
		return new HatchPatternSurrogate(this);
	}

	internal bool _0023_003Dz3QLIG1l0mkXxlcWP0A_003D_003D(Hatch _0023_003Dz1L3TZOcNA99t, Point3D[][] _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, RegenParams _0023_003DzELu0Pss_003D, out List<Point3D> _0023_003DzNSmDw08N3j1d, out List<Point3D> _0023_003DzpvQNJPOeOqfy)
	{
		Plane plane = (Plane)_0023_003Dz1L3TZOcNA99t.Plane.Clone();
		plane.Origin = _0023_003Dz1L3TZOcNA99t.Plane.PointAt(_0023_003Dz1L3TZOcNA99t.Plane.Project(Point3D.Origin));
		List<Point2D> list = new List<Point2D>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length * 3);
		Polygon2D[] array = new Polygon2D[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length];
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length; i++)
		{
			List<Point2D> list2 = new List<Point2D>();
			for (int j = 0; j < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].Length; j++)
			{
				list2.Add(plane.Project(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i][j]));
			}
			Polygon2D polygon2D = new Polygon2D(list2);
			polygon2D.UpdateBoundingRect();
			array[i] = polygon2D;
			list.AddRange(list2);
		}
		Utility.ComputeBoundingRect(list, out var boxMin, out var boxMax);
		double num = new Size2D(boxMin, boxMax).Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		boxMin += new Point2D(0.0 - num, 0.0 - num);
		boxMax += new Point2D(num, num);
		_0023_003DzNSmDw08N3j1d = new List<Point3D>();
		_0023_003DzpvQNJPOeOqfy = new List<Point3D>();
		HatchPatternLine[] lines = Lines;
		foreach (HatchPatternLine hatchPatternLine in lines)
		{
			int _0023_003Dz43pxRC2Rpyg = _0023_003DzELu0Pss_003D.Document.MaxHatchPatternLines - (_0023_003DzNSmDw08N3j1d.Count / 2 + _0023_003DzpvQNJPOeOqfy.Count);
			if (!hatchPatternLine._0023_003Dz3QLIG1l0mkXxlcWP0A_003D_003D(_0023_003Dz1L3TZOcNA99t, plane, array, boxMin, boxMax, _0023_003Dz43pxRC2Rpyg, out var _0023_003DzyIUKu5w_003D, out var _0023_003DzrdSL0CI_003D))
			{
				return false;
			}
			_0023_003DzNSmDw08N3j1d.AddRange(_0023_003DzyIUKu5w_003D);
			_0023_003DzpvQNJPOeOqfy.AddRange(_0023_003DzrdSL0CI_003D);
		}
		return true;
	}
}
