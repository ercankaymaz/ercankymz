using System.Diagnostics;
using System.IO;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class MultiFileItem
{
	public readonly string FullPath;

	public readonly fileType FileType;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly bool _0023_003DzcNcumvBppeDS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly Entity _0023_003Dz9j7EUB0_003D;

	public string BlockName => Path.GetFileNameWithoutExtension(FullPath);

	public MultiFileItem(string fullPath, fileType fileType)
		: this(null, fullPath, fileType)
	{
	}

	internal MultiFileItem(Entity _0023_003Dz9j7EUB0_003D, string _0023_003DzS5vi7RU_003D, fileType _0023_003Dz_0024QaoO_A_003D)
	{
		this._0023_003Dz9j7EUB0_003D = _0023_003Dz9j7EUB0_003D;
		FullPath = _0023_003DzS5vi7RU_003D;
		FileType = _0023_003Dz_0024QaoO_A_003D;
		_0023_003DzcNcumvBppeDS = File.Exists(FullPath);
	}

	internal string _0023_003DzL4vDcS6n01rR()
	{
		return Path.GetDirectoryName(FullPath);
	}

	internal string _0023_003DzGXbrah1QikDL()
	{
		return Path.GetFileName(FullPath);
	}

	internal string _0023_003Dz1HT_00242y8qARt9(string _0023_003DzL9kTxbo_003D)
	{
		return Path.Combine(_0023_003DzL9kTxbo_003D, _0023_003DzGXbrah1QikDL());
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982525), FileType, FullPath);
	}
}
