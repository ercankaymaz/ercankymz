using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class WriteMultiFileParams : WriteFileParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzxWQfFUV5KlC_b3eitIP9stw2p_6e;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzrnXHwt9KWMFU9kwpqfYLMKc_003D = DefaultStandardExtension;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz8JMYw4KCpq3YvNNYZQ_003D_003D = DefaultAssemblyExtension;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003Dz5Y6A2dDcZZpp8d4A38JUHNE_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012933);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzSBKjveqbIrFLU59bmgfRTCU_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012914);

	public bool UpdateThumbnails
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzxWQfFUV5KlC_b3eitIP9stw2p_6e;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzxWQfFUV5KlC_b3eitIP9stw2p_6e = value;
		}
	}

	public bool Parallel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D = value;
		}
	}

	public string BlockName
	{
		get
		{
			return _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;
		}
		set
		{
			if (value != null && !_0023_003DzcoG1S4w_003D.Blocks.Contains(value))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012928) + value + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012883));
			}
			_0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D = value;
		}
	}

	public string StandardExtension
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzrnXHwt9KWMFU9kwpqfYLMKc_003D;
		}
		set
		{
			_0023_003DzrnXHwt9KWMFU9kwpqfYLMKc_003D = _0023_003DzytqH8yULiyVp(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013101));
		}
	}

	public string AssemblyExtension
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz8JMYw4KCpq3YvNNYZQ_003D_003D;
		}
		set
		{
			_0023_003Dz8JMYw4KCpq3YvNNYZQ_003D_003D = _0023_003DzytqH8yULiyVp(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013061));
		}
	}

	public static string DefaultStandardExtension
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5Y6A2dDcZZpp8d4A38JUHNE_003D;
		}
		set
		{
			_0023_003Dz5Y6A2dDcZZpp8d4A38JUHNE_003D = _0023_003DzytqH8yULiyVp(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013053));
		}
	}

	public static string DefaultAssemblyExtension
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSBKjveqbIrFLU59bmgfRTCU_003D;
		}
		set
		{
			_0023_003DzSBKjveqbIrFLU59bmgfRTCU_003D = _0023_003DzytqH8yULiyVp(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013022));
		}
	}

	public WriteMultiFileParams(DesignDocument designDocument, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, bool selectedOnly = false, bool saveThumbnail = true)
		: base(designDocument, contentType, serializationType, selectedOnly, saveThumbnail)
	{
	}

	public WriteMultiFileParams(BlockKeyedCollection blocks, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, HatchPatternKeyedCollection hatchPatterns = null, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed)
		: base(null, layers, blocks, materials, textStyles, lineTypes, contentType, serializationType, Block.DefaultUnits, selectedOnly: false, null, hatchPatterns)
	{
		if (blocks == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013267));
		}
		if (!blocks.hasRootBlock || !blocks.Contains(blocks.RootBlockName))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012987));
		}
		base.Units = blocks.RootBlock.Units;
	}

	private static string _0023_003DzytqH8yULiyVp(string _0023_003DzPzO_0024GUk_003D, string _0023_003DzaE4ynZQ_003D)
	{
		if (string.IsNullOrWhiteSpace(_0023_003DzPzO_0024GUk_003D))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013755), _0023_003DzaE4ynZQ_003D);
		}
		string text = _0023_003DzPzO_0024GUk_003D.Trim();
		if (!text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)))
		{
			text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + text;
		}
		if (text.Length <= 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013681), _0023_003DzaE4ynZQ_003D);
		}
		if (text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || text.Contains(Path.DirectorySeparatorChar) || text.Contains(Path.AltDirectorySeparatorChar))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013642), _0023_003DzaE4ynZQ_003D);
		}
		return text;
	}
}
