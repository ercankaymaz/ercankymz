using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteParamsWithDrawing : WriteParamsWithTextStyles
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DrawingDocument _0023_003DzfkTArhfcCzQ_0024oVMoZQ_003D_003D;

	public DrawingDocument Drawing
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfkTArhfcCzQ_0024oVMoZQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfkTArhfcCzQ_0024oVMoZQ_003D_003D = value;
		}
	}

	public WriteParamsWithDrawing(Document document, DrawingDocument drawing, bool selectedOnly = false, bool openBlockOnly = false)
		: base(document, selectedOnly, openBlockOnly)
	{
		Drawing = drawing;
	}

	public WriteParamsWithDrawing(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, DrawingDocument drawing = null, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, textStyles, lineTypes, units, selectedOnly, hatchPatterns)
	{
		Drawing = drawing;
	}
}
