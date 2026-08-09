using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WritePrcParams : WriteDatabaseParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzutzVWAVOzEFCnvtCmaP1fj8_003D;

	public bool SaveGeometry
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzutzVWAVOzEFCnvtCmaP1fj8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzutzVWAVOzEFCnvtCmaP1fj8_003D = value;
		}
	}

	public WritePrcParams(DesignDocument design, bool selectedOnly = false, bool openBlockOnly = false)
		: base(design, null, selectedOnly, openBlockOnly)
	{
	}

	public WritePrcParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, textStyles, lineTypes, units, selectedOnly, null, hatchPatterns)
	{
	}
}
