using System.IO;

namespace devDept.Eyeshot.Translators;

public abstract class WriteFileAsyncWithDrawings : WriteFileAsyncWithTextStyles
{
	protected DrawingDocument Drawing;

	protected WriteFileAsyncWithDrawings(WriteParamsWithDrawing writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	protected WriteFileAsyncWithDrawings(WriteParamsWithDrawing writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	private void _0023_003DzVnfAoovaoMa7(WriteParamsWithDrawing _0023_003Dza_0024OnOAIpLFp9)
	{
		if (_0023_003Dza_0024OnOAIpLFp9 != null)
		{
			Drawing = _0023_003Dza_0024OnOAIpLFp9.Drawing;
		}
	}
}
