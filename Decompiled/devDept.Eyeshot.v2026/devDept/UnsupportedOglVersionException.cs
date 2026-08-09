using System;

namespace devDept;

[Serializable]
public class UnsupportedOglVersionException : GraphicsException
{
	public UnsupportedOglVersionException(Version actualVersion)
		: base(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673891), actualVersion))
	{
	}
}
