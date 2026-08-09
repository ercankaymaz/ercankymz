using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class Layer : IDisposable, ICloneable, IEquatable<Layer>, IKeyedCollectionDisposableItem<Layer>, IKeyedCollectionItem<Layer>, INotifyKeyChanged, INotifyVisibleChanged, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	internal static string DefaultLayerName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495);

	internal bool isDirtyForFlattenTree;

	private bool _exportable = true;

	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	private bool _visible;

	private Color _color;

	private string _materialName;

	private float _lineWeight;

	private string _lineTypeName;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private VisibleChangedEventHandler _0023_003Dz256ZxNw_003D;

	private string _xrefName = string.Empty;

	public bool Locked { get; set; }

	public bool Exportable
	{
		get
		{
			return _exportable;
		}
		set
		{
			_exportable = value;
		}
	}

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

	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			isDirtyForFlattenTree = true;
		}
	}

	public string MaterialName
	{
		get
		{
			return _materialName;
		}
		set
		{
			_materialName = value;
			isDirtyForFlattenTree = true;
		}
	}

	public virtual bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			bool num = _visible != value;
			_visible = value;
			if (num)
			{
				_0023_003DzoC5Ax2mpp_0024GS();
			}
		}
	}

	public float LineWeight
	{
		get
		{
			return _lineWeight;
		}
		set
		{
			_lineWeight = value;
			isDirtyForFlattenTree = true;
		}
	}

	public string LineTypeName
	{
		get
		{
			return _lineTypeName;
		}
		set
		{
			_lineTypeName = value;
			isDirtyForFlattenTree = true;
		}
	}

	public string XRefName
	{
		get
		{
			return _xrefName;
		}
		internal set
		{
			_xrefName = value;
		}
	}

	public List<KeyValuePair<short, object>> XData { get; set; }

	public string Description { get; set; }

	public string Identifier { get; set; }

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

	public event VisibleChangedEventHandler VisibleChanged
	{
		[CompilerGenerated]
		add
		{
			VisibleChangedEventHandler visibleChangedEventHandler = _0023_003Dz256ZxNw_003D;
			VisibleChangedEventHandler visibleChangedEventHandler2;
			do
			{
				visibleChangedEventHandler2 = visibleChangedEventHandler;
				VisibleChangedEventHandler value2 = (VisibleChangedEventHandler)Delegate.Combine(visibleChangedEventHandler2, value);
				visibleChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz256ZxNw_003D, value2, visibleChangedEventHandler2);
			}
			while ((object)visibleChangedEventHandler != visibleChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			VisibleChangedEventHandler visibleChangedEventHandler = _0023_003Dz256ZxNw_003D;
			VisibleChangedEventHandler visibleChangedEventHandler2;
			do
			{
				visibleChangedEventHandler2 = visibleChangedEventHandler;
				VisibleChangedEventHandler value2 = (VisibleChangedEventHandler)Delegate.Remove(visibleChangedEventHandler2, value);
				visibleChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz256ZxNw_003D, value2, visibleChangedEventHandler2);
			}
			while ((object)visibleChangedEventHandler != visibleChangedEventHandler2);
		}
	}

	public Layer(string name, Color color, string lineTypeName, float lineWeight, bool visible, bool locked = false)
	{
		Name = name;
		Color = color;
		LineWeight = lineWeight;
		Visible = visible;
		LineTypeName = lineTypeName;
		Locked = locked;
	}

	public Layer(string name)
		: this(name, Color.Black)
	{
	}

	public Layer(string name, Color color)
		: this(name, color, visible: true)
	{
	}

	public Layer(string name, Color color, bool visible)
		: this(name, color, null, 0.5f, visible)
	{
	}

	public Layer(string name, Color color, string lineTypeName)
		: this(name, color, null, 0.5f, visible: true)
	{
		LineTypeName = lineTypeName;
	}

	protected Layer(Layer another)
	{
		Name = another.Name;
		Visible = another.Visible;
		Color = another.Color;
		LineWeight = another.LineWeight;
		MaterialName = another.MaterialName;
		Exportable = another.Exportable;
		LineTypeName = another.LineTypeName;
		Locked = another.Locked;
		XRefName = another.XRefName;
		if (another.XData != null)
		{
			XData = new List<KeyValuePair<short, object>>();
			foreach (KeyValuePair<short, object> xDatum in another.XData)
			{
				if (xDatum.Value is ICloneable cloneable)
				{
					XData.Add(new KeyValuePair<short, object>(xDatum.Key, cloneable.Clone()));
				}
				else if (xDatum.Value is ValueType)
				{
					XData.Add(new KeyValuePair<short, object>(xDatum.Key, xDatum.Value));
				}
			}
		}
		Description = another.Description;
		Identifier = another.Identifier;
	}

	protected internal Layer(LayerSurrogate surrogate)
		: this(surrogate.Name)
	{
	}

	protected Layer(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		Color = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829), typeof(Color));
		MaterialName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957968), typeof(string));
		LineWeight = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967330));
		LineTypeName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967305), typeof(string));
		Visible = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510));
		Locked = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988042));
		Exportable = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988277));
		XRefName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), typeof(string));
		XData = (List<KeyValuePair<short, object>>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955705), typeof(List<KeyValuePair<short, object>>));
		Description = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), typeof(string));
		Identifier = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988248), typeof(string));
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

	internal void _0023_003DzoC5Ax2mpp_0024GS()
	{
		_0023_003Dz256ZxNw_003D?.Invoke(this, new VisibleChangedEventArgs());
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

	public virtual object Clone()
	{
		return new Layer(this);
	}

	public void Dispose()
	{
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (LineTypeName != null)
		{
			string lineTypeName = LineTypeName;
			for (int i = 0; i < lineTypeName.Length; i++)
			{
				text = text + (float)(int)lineTypeName[i] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108);
			}
		}
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988231), Name, Color, Visible, LineWeight, text);
	}

	public bool Equals(Layer other)
	{
		return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
	}

	public virtual LayerSurrogate ConvertToSurrogate()
	{
		return new LayerSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Name);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829), Color);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957968), MaterialName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967330), LineWeight);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967305), LineTypeName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510), Visible);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988042), Locked);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988277), Exportable);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), _xrefName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955705), XData, typeof(List<KeyValuePair<short, object>>));
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), Description);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988248), Identifier);
	}
}
