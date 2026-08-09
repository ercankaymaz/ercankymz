using System.IO;

namespace devDept.Eyeshot.Translators;

public abstract class WriteFileAsyncWithTextStyles : WriteFileAsyncWithUnits
{
	protected LineTypeKeyedCollection lineTypes;

	protected HatchPatternKeyedCollection hatchPatterns;

	protected TextStyleKeyedCollection textStyles;

	protected WriteFileAsyncWithTextStyles(WriteParamsWithTextStyles writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	protected WriteFileAsyncWithTextStyles(WriteParamsWithTextStyles writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	private void _0023_003DzVnfAoovaoMa7(WriteParamsWithTextStyles _0023_003Dzz5FOJ4bXstHvhUSVig_003D_003D)
	{
		if (_0023_003Dzz5FOJ4bXstHvhUSVig_003D_003D != null)
		{
			lineTypes = new LineTypeKeyedCollection(_0023_003Dzz5FOJ4bXstHvhUSVig_003D_003D.LineTypes);
			hatchPatterns = new HatchPatternKeyedCollection(_0023_003Dzz5FOJ4bXstHvhUSVig_003D_003D.HatchPatterns);
			textStyles = new TextStyleKeyedCollection();
			textStyles.AddRange(_0023_003Dzz5FOJ4bXstHvhUSVig_003D_003D.TextStyles);
		}
	}
}
