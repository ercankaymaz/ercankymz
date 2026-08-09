using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class TextStyle : ICloneable, IKeyedCollectionItem<TextStyle>, INotifyKeyChanged, IEquatable<TextStyle>, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static string _0023_003Dz4zXHKUEM3ZZu = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495);

	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	private double _widthFactor = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz5KguOoA_003D = 1;

	internal ShapeFile shapeFile;

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

	public string FontFamilyName { get; set; }

	public fontStyle Style { get; set; }

	public double WidthFactor
	{
		get
		{
			return _widthFactor;
		}
		set
		{
			_widthFactor = value;
		}
	}

	public string FileName { get; set; }

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

	public TextStyle(string name, string fontFamilyName, fontStyle style, double widthFactor = 1.0)
		: this(name)
	{
		FontFamilyName = fontFamilyName;
		Style = style;
		WidthFactor = widthFactor;
	}

	protected TextStyle(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		FileName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998524));
		FontFamilyName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998505));
		Style = (fontStyle)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998496), typeof(fontStyle));
		WidthFactor = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998480));
		XRefName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264));
	}

	public TextStyle(TextStyle another)
	{
		Name = another.Name;
		FontFamilyName = another.FontFamilyName;
		Style = another.Style;
		WidthFactor = another.WidthFactor;
		FileName = another.FileName;
		shapeFile = (ShapeFile)(another.shapeFile?.Clone());
		XRefName = another.XRefName;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public TextStyle()
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998434), _0023_003Dz5KguOoA_003D++))
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public TextStyle(string fontFamilyName, fontStyle style, double widthFactor = 1.0)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998434), _0023_003Dz5KguOoA_003D++), fontFamilyName, style, widthFactor)
	{
	}

	internal TextStyle(string _0023_003DzS_00246o7tc_003D)
	{
		Name = _0023_003DzS_00246o7tc_003D;
	}

	internal TextStyle(string _0023_003DzS_00246o7tc_003D, string _0023_003Dz_HZ81V0_003D)
		: this(_0023_003DzS_00246o7tc_003D)
	{
		_0023_003Dzl2Uiu_0024M_003D(_0023_003Dz_HZ81V0_003D);
	}

	protected internal TextStyle(TextStyleSurrogate surrogate)
		: this(surrogate.Name, surrogate.FontFamilyName, surrogate.Style)
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

	public bool Equals(TextStyle other)
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
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998524), FileName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998505), FontFamilyName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998496), Style);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998480), WidthFactor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), XRefName);
	}

	public virtual object Clone()
	{
		return new TextStyle(this);
	}

	internal void _0023_003Dzl2Uiu_0024M_003D(string _0023_003Dzg5oC_Hs_003D)
	{
		try
		{
			FileName = Path.GetFileName(_0023_003Dzg5oC_Hs_003D);
			FileStream fileStream = new FileStream(_0023_003Dzg5oC_Hs_003D, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				shapeFile = _0023_003DzGiJuRymRy3WyGr7bXnnIqH3Q2C1m9f5QCQ_003D_003D._0023_003DztXxuGPV1ZW2Y(Path.GetFileName(_0023_003Dzg5oC_Hs_003D), fileStream);
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998427) + _0023_003Dzg5oC_Hs_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
		}
	}

	public bool IsSHX()
	{
		return shapeFile != null;
	}

	public virtual TextStyleSurrogate ConvertToSurrogate()
	{
		return new TextStyleSurrogate(this);
	}
}
