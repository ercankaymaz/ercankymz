using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class MultiFileData
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<MultiFileItem, Entity> _0023_003DzzXfVjLO8QehtBZRX_0024A_003D_003D;

		internal Entity _0023_003DzGhGlp2mgROxohs8aoQ_003D_003D(MultiFileItem _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D._0023_003Dz9j7EUB0_003D;
		}
	}

	public readonly string FullPath;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly bool _0023_003DzcNcumvBppeDS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly bool _0023_003Dz2mBCSlg_003D;

	public readonly fileType FileType;

	public readonly MultiFileItem[] Items;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly string _0023_003DzZ9xh1dFMrWh_0024;

	public string BlockName => Path.GetFileNameWithoutExtension(FullPath);

	public MultiFileData(string fullPath, fileType fileType, MultiFileItem[] items)
	{
		FullPath = fullPath;
		_0023_003DzcNcumvBppeDS = File.Exists(FullPath);
		FileType = fileType;
		Items = items;
		_0023_003Dz2mBCSlg_003D = Block.IsLeaf(items.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzGhGlp2mgROxohs8aoQ_003D_003D).ToList());
	}

	internal string _0023_003DzL4vDcS6n01rR()
	{
		return Path.GetDirectoryName(FullPath);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982525), FileType, FullPath);
	}
}
