using System;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
[Obsolete("Deprecated in favor of Sheet.")]
internal sealed class SheetEx : Sheet
{
	public SheetEx(Sheet _0023_003DzySgeilxprQOK, bool _0023_003Dzu9oxwJ_zKlMt = false)
		: base(_0023_003DzySgeilxprQOK, _0023_003Dzu9oxwJ_zKlMt)
	{
	}

	protected SheetEx(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
	}

	public override object Clone()
	{
		return new SheetEx(this);
	}

	public override object CloneWithTessellation()
	{
		return new SheetEx(this, _0023_003Dzu9oxwJ_zKlMt: true);
	}

	public override SheetSurrogate ConvertToSurrogate()
	{
		return new SheetExSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		base.GetObjectData(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D);
	}
}
