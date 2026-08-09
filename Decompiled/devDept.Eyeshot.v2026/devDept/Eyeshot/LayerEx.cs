using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
[Obsolete("Deprecated in favor of Layer.")]
internal sealed class LayerEx : Layer, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	protected LayerEx(LayerEx _0023_003DzySgeilxprQOK)
		: base((Layer)_0023_003DzySgeilxprQOK)
	{
	}

	public LayerEx(string _0023_003DzS_00246o7tc_003D, Color _0023_003Dz1MMYB1g_003D, string _0023_003DzOC4z_gQgaVI0, float _0023_003DzxOQTW6c4mcu_0024, bool _0023_003DzkKqY0js_003D, bool _0023_003DzfuwWUlY_003D)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003Dz1MMYB1g_003D, _0023_003DzOC4z_gQgaVI0, _0023_003DzxOQTW6c4mcu_0024, _0023_003DzkKqY0js_003D, _0023_003DzfuwWUlY_003D)
	{
	}

	protected LayerEx(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
	}

	public override object Clone()
	{
		return new LayerEx(this);
	}

	public override LayerSurrogate ConvertToSurrogate()
	{
		return new LayerExSurrogate(this);
	}
}
