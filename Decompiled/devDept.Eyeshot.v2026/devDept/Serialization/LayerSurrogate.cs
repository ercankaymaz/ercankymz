using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot;

namespace devDept.Serialization;

public class LayerSurrogate : Surrogate<Layer>
{
	public string Name;

	public Color Color;

	public string MaterialName;

	public string LineTypeName;

	public float LineWeight;

	public bool Visible;

	public bool Locked;

	public bool Exportable;

	public string XRefName;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<KeyValuePair<short, ProtoObject>> _0023_003DzOzhO7BndYOCK414sYw_003D_003D;

	public string Description;

	public string Identifier;

	public List<KeyValuePair<short, ProtoObject>> XData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOzhO7BndYOCK414sYw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOzhO7BndYOCK414sYw_003D_003D = value;
		}
	}

	public LayerSurrogate(Layer layer)
		: base(layer)
	{
	}

	protected override Layer ConvertToObject()
	{
		Layer layer = new Layer(this);
		CopyDataToObject(layer);
		return layer;
	}

	protected override void CopyDataToObject(Layer layer)
	{
		layer.Name = Name;
		layer.Color = Color;
		layer.MaterialName = MaterialName;
		layer.LineTypeName = LineTypeName;
		layer.LineWeight = LineWeight;
		layer.Visible = Visible;
		layer.Locked = Locked;
		layer.Exportable = Exportable;
		layer.XRefName = XRefName;
		if (XData != null)
		{
			layer.XData = new List<KeyValuePair<short, object>>();
			foreach (KeyValuePair<short, ProtoObject> xDatum in XData)
			{
				ProtoObject value = xDatum.Value;
				layer.XData.Add(new KeyValuePair<short, object>(xDatum.Key, value?.Object));
			}
		}
		layer.Description = Description;
		layer.Identifier = Identifier;
	}

	protected override void CopyDataFromObject(Layer layer)
	{
		Name = layer.Name;
		Color = layer.Color;
		MaterialName = layer.MaterialName;
		LineTypeName = layer.LineTypeName;
		LineWeight = layer.LineWeight;
		Visible = layer.Visible;
		Locked = layer.Locked;
		Exportable = layer.Exportable;
		XRefName = layer.XRefName;
		if (layer.XData != null)
		{
			XData = new List<KeyValuePair<short, ProtoObject>>();
			foreach (KeyValuePair<short, object> xDatum in layer.XData)
			{
				XData.Add(new KeyValuePair<short, ProtoObject>(xDatum.Key, new ProtoObject(xDatum.Value)));
			}
		}
		Description = layer.Description;
		Identifier = layer.Identifier;
	}

	public static implicit operator Layer(LayerSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator LayerSurrogate(Layer source)
	{
		return source?.ConvertToSurrogate();
	}
}
