using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;

namespace devDept.Serialization;

public class CurveExSurrogate : CurveSurrogate
{
	public CurveExSurrogate(CurveEx curveEx)
		: base(curveEx)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			if (CheckSurrogateData(string.Empty))
			{
				LinearPathEx linearPathEx = new LinearPathEx(Vertices);
				CopyDataToObject(linearPathEx);
				return linearPathEx;
			}
			WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670092));
			return CreateGhostEntity(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670262));
		}
		CurveEx curveEx = new CurveEx(this);
		CopyDataToObject(curveEx);
		return curveEx;
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670230));
			return false;
		}
		return true;
	}
}
