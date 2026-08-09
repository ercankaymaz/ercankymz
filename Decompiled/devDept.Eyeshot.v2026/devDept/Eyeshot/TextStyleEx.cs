using System;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
[Obsolete("Deprecated in favor of TextStyle.")]
internal sealed class TextStyleEx : TextStyle, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	public TextStyleEx(string _0023_003DzS_00246o7tc_003D, string _0023_003Dz3BH4yh6JQ_tc, fontStyle _0023_003Dz_0024wQZnFQ_003D, double _0023_003DzwzMn4TDvq4kF = 1.0, string _0023_003Dz_HZ81V0_003D = null)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003Dz3BH4yh6JQ_tc, _0023_003Dz_0024wQZnFQ_003D, _0023_003DzwzMn4TDvq4kF)
	{
		base.FileName = _0023_003Dz_HZ81V0_003D;
	}

	public TextStyleEx(TextStyleEx _0023_003DzySgeilxprQOK)
		: base((TextStyle)_0023_003DzySgeilxprQOK)
	{
		base.XRefName = _0023_003DzySgeilxprQOK.XRefName;
	}

	protected TextStyleEx(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
		base.XRefName = _0023_003Dz9lrNnXY_003D.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264));
	}

	public override object Clone()
	{
		return new TextStyleEx(this);
	}

	public override void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		base.GetObjectData(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), base.XRefName);
	}

	public override TextStyleSurrogate ConvertToSurrogate()
	{
		return new TextStyleExSurrogate(this);
	}
}
