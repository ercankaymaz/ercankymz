using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteParamsWithMaterials : WriteParamsWithUnits
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = new MaterialKeyedCollection();

	public MaterialKeyedCollection Materials
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = value;
		}
	}

	public WriteParamsWithMaterials(IWorkspace workspace, bool selectedOnly = false, bool openBlockOnly = false)
		: this(workspace.Document, selectedOnly, openBlockOnly)
	{
	}

	public WriteParamsWithMaterials(Document document, bool selectedOnly = false, bool openBlockOnly = false)
		: base(document, selectedOnly, openBlockOnly)
	{
		if (document.Materials != null)
		{
			Materials = document.Materials;
		}
	}

	public WriteParamsWithMaterials(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false)
		: base(entities, layers, blocks, units, selectedOnly)
	{
		if (materials != null)
		{
			Materials = materials;
		}
	}
}
