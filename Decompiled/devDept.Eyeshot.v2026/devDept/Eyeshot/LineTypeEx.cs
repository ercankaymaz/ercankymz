using System;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
[Obsolete("Deprecated in favor of LineType.")]
internal sealed class LineTypeEx : LineType, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	public LineTypeEx(string _0023_003DzS_00246o7tc_003D, float[] _0023_003Dz9OkmiQc_003D, string _0023_003DzUPTg1DPlXSwL, string _0023_003DzmAgXdRQ_003D = null)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003Dz9OkmiQc_003D, _0023_003DzmAgXdRQ_003D)
	{
		base.XRefName = _0023_003DzUPTg1DPlXSwL;
	}

	public LineTypeEx(LineTypeEx _0023_003DzySgeilxprQOK)
		: base((LineType)_0023_003DzySgeilxprQOK)
	{
		base.XRefName = _0023_003DzySgeilxprQOK.XRefName;
	}

	protected LineTypeEx(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
		base.XRefName = _0023_003Dz9lrNnXY_003D.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264));
	}

	public override void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		base.GetObjectData(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988264), base.XRefName);
	}

	public override object Clone()
	{
		return new LineTypeEx(this);
	}

	public override LineTypeSurrogate ConvertToSurrogate()
	{
		return new LineTypeExSurrogate(this);
	}
}
