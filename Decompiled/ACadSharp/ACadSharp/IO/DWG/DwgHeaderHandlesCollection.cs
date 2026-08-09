using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ACadSharp.Header;
using ACadSharp.Tables;

namespace ACadSharp.IO.DWG;

internal class DwgHeaderHandlesCollection
{
	private Dictionary<string, ulong?> _handles = new Dictionary<string, ulong?>();

	public ulong? CMATERIAL
	{
		get
		{
			return getHandle("CMATERIAL");
		}
		set
		{
			setHandle("CMATERIAL", value);
		}
	}

	public ulong? CLAYER
	{
		get
		{
			return getHandle("CLAYER");
		}
		set
		{
			setHandle("CLAYER", value);
		}
	}

	public ulong? TEXTSTYLE
	{
		get
		{
			return getHandle("TEXTSTYLE");
		}
		set
		{
			setHandle("TEXTSTYLE", value);
		}
	}

	public ulong? CELTYPE
	{
		get
		{
			return getHandle("CELTYPE");
		}
		set
		{
			setHandle("CELTYPE", value);
		}
	}

	public ulong? DIMSTYLE
	{
		get
		{
			return getHandle("DIMSTYLE");
		}
		set
		{
			setHandle("DIMSTYLE", value);
		}
	}

	public ulong? CMLSTYLE
	{
		get
		{
			return getHandle("CMLSTYLE");
		}
		set
		{
			setHandle("CMLSTYLE", value);
		}
	}

	public ulong? UCSNAME_PSPACE
	{
		get
		{
			return getHandle("UCSNAME_PSPACE");
		}
		set
		{
			setHandle("UCSNAME_PSPACE", value);
		}
	}

	public ulong? UCSNAME_MSPACE
	{
		get
		{
			return getHandle("UCSNAME_MSPACE");
		}
		set
		{
			setHandle("UCSNAME_MSPACE", value);
		}
	}

	public ulong? PUCSORTHOREF
	{
		get
		{
			return getHandle("PUCSORTHOREF");
		}
		set
		{
			setHandle("PUCSORTHOREF", value);
		}
	}

	public ulong? PUCSBASE
	{
		get
		{
			return getHandle("PUCSBASE");
		}
		set
		{
			setHandle("PUCSBASE", value);
		}
	}

	public ulong? UCSORTHOREF
	{
		get
		{
			return getHandle("UCSORTHOREF");
		}
		set
		{
			setHandle("UCSORTHOREF", value);
		}
	}

	public ulong? DIMTXSTY
	{
		get
		{
			return getHandle("DIMTXSTY");
		}
		set
		{
			setHandle("DIMTXSTY", value);
		}
	}

	public ulong? DIMLDRBLK
	{
		get
		{
			return getHandle("DIMLDRBLK");
		}
		set
		{
			setHandle("DIMLDRBLK", value);
		}
	}

	public ulong? DIMBLK
	{
		get
		{
			return getHandle("DIMBLK");
		}
		set
		{
			setHandle("DIMBLK", value);
		}
	}

	public ulong? DIMBLK1
	{
		get
		{
			return getHandle("DIMBLK1");
		}
		set
		{
			setHandle("DIMBLK1", value);
		}
	}

	public ulong? DIMBLK2
	{
		get
		{
			return getHandle("DIMBLK2");
		}
		set
		{
			setHandle("DIMBLK2", value);
		}
	}

	public ulong? DICTIONARY_LAYOUTS
	{
		get
		{
			return getHandle("DICTIONARY_LAYOUTS");
		}
		set
		{
			setHandle("DICTIONARY_LAYOUTS", value);
		}
	}

	public ulong? DICTIONARY_PLOTSETTINGS
	{
		get
		{
			return getHandle("DICTIONARY_PLOTSETTINGS");
		}
		set
		{
			setHandle("DICTIONARY_PLOTSETTINGS", value);
		}
	}

	public ulong? DICTIONARY_PLOTSTYLES
	{
		get
		{
			return getHandle("DICTIONARY_PLOTSTYLES");
		}
		set
		{
			setHandle("DICTIONARY_PLOTSTYLES", value);
		}
	}

	public ulong? CPSNID
	{
		get
		{
			return getHandle("CPSNID");
		}
		set
		{
			setHandle("CPSNID", value);
		}
	}

	public ulong? PAPER_SPACE
	{
		get
		{
			return getHandle("PAPER_SPACE");
		}
		set
		{
			setHandle("PAPER_SPACE", value);
		}
	}

	public ulong? MODEL_SPACE
	{
		get
		{
			return getHandle("MODEL_SPACE");
		}
		set
		{
			setHandle("MODEL_SPACE", value);
		}
	}

	public ulong? BYLAYER
	{
		get
		{
			return getHandle("BYLAYER");
		}
		set
		{
			setHandle("BYLAYER", value);
		}
	}

	public ulong? BYBLOCK
	{
		get
		{
			return getHandle("BYBLOCK");
		}
		set
		{
			setHandle("BYBLOCK", value);
		}
	}

	public ulong? CONTINUOUS
	{
		get
		{
			return getHandle("CONTINUOUS");
		}
		set
		{
			setHandle("CONTINUOUS", value);
		}
	}

	public ulong? DIMLTYPE
	{
		get
		{
			return getHandle("DIMLTYPE");
		}
		set
		{
			setHandle("DIMLTYPE", value);
		}
	}

	public ulong? DIMLTEX1
	{
		get
		{
			return getHandle("DIMLTEX1");
		}
		set
		{
			setHandle("DIMLTEX1", value);
		}
	}

	public ulong? DIMLTEX2
	{
		get
		{
			return getHandle("DIMLTEX2");
		}
		set
		{
			setHandle("DIMLTEX2", value);
		}
	}

	public ulong? VIEWPORT_ENTITY_HEADER_CONTROL_OBJECT
	{
		get
		{
			return getHandle("VIEWPORT_ENTITY_HEADER_CONTROL_OBJECT");
		}
		set
		{
			setHandle("VIEWPORT_ENTITY_HEADER_CONTROL_OBJECT", value);
		}
	}

	public ulong? DICTIONARY_ACAD_GROUP
	{
		get
		{
			return getHandle("DICTIONARY_ACAD_GROUP");
		}
		set
		{
			setHandle("DICTIONARY_ACAD_GROUP", value);
		}
	}

	public ulong? DICTIONARY_ACAD_MLINESTYLE
	{
		get
		{
			return getHandle("DICTIONARY_ACAD_MLINESTYLE");
		}
		set
		{
			setHandle("DICTIONARY_ACAD_MLINESTYLE", value);
		}
	}

	public ulong? DICTIONARY_NAMED_OBJECTS
	{
		get
		{
			return getHandle("DICTIONARY_NAMED_OBJECTS");
		}
		set
		{
			setHandle("DICTIONARY_NAMED_OBJECTS", value);
		}
	}

	public ulong? BLOCK_CONTROL_OBJECT
	{
		get
		{
			return getHandle("BLOCK_CONTROL_OBJECT");
		}
		set
		{
			setHandle("BLOCK_CONTROL_OBJECT", value);
		}
	}

	public ulong? LAYER_CONTROL_OBJECT
	{
		get
		{
			return getHandle("LAYER_CONTROL_OBJECT");
		}
		set
		{
			setHandle("LAYER_CONTROL_OBJECT", value);
		}
	}

	public ulong? STYLE_CONTROL_OBJECT
	{
		get
		{
			return getHandle("STYLE_CONTROL_OBJECT");
		}
		set
		{
			setHandle("STYLE_CONTROL_OBJECT", value);
		}
	}

	public ulong? LINETYPE_CONTROL_OBJECT
	{
		get
		{
			return getHandle("LINETYPE_CONTROL_OBJECT");
		}
		set
		{
			setHandle("LINETYPE_CONTROL_OBJECT", value);
		}
	}

	public ulong? VIEW_CONTROL_OBJECT
	{
		get
		{
			return getHandle("VIEW_CONTROL_OBJECT");
		}
		set
		{
			setHandle("VIEW_CONTROL_OBJECT", value);
		}
	}

	public ulong? UCS_CONTROL_OBJECT
	{
		get
		{
			return getHandle("UCS_CONTROL_OBJECT");
		}
		set
		{
			setHandle("UCS_CONTROL_OBJECT", value);
		}
	}

	public ulong? VPORT_CONTROL_OBJECT
	{
		get
		{
			return getHandle("VPORT_CONTROL_OBJECT");
		}
		set
		{
			setHandle("VPORT_CONTROL_OBJECT", value);
		}
	}

	public ulong? APPID_CONTROL_OBJECT
	{
		get
		{
			return getHandle("APPID_CONTROL_OBJECT");
		}
		set
		{
			setHandle("APPID_CONTROL_OBJECT", value);
		}
	}

	public ulong? DIMSTYLE_CONTROL_OBJECT
	{
		get
		{
			return getHandle("DIMSTYLE_CONTROL_OBJECT");
		}
		set
		{
			setHandle("DIMSTYLE_CONTROL_OBJECT", value);
		}
	}

	public ulong? DICTIONARY_MATERIALS
	{
		get
		{
			return getHandle("DICTIONARY_MATERIALS");
		}
		set
		{
			setHandle("DICTIONARY_MATERIALS", value);
		}
	}

	public ulong? DICTIONARY_COLORS
	{
		get
		{
			return getHandle("DICTIONARY_COLORS");
		}
		set
		{
			setHandle("DICTIONARY_COLORS", value);
		}
	}

	public ulong? DICTIONARY_VISUALSTYLE
	{
		get
		{
			return getHandle("DICTIONARY_VISUALSTYLE");
		}
		set
		{
			setHandle("DICTIONARY_VISUALSTYLE", value);
		}
	}

	public ulong? INTERFEREOBJVS
	{
		get
		{
			return getHandle("INTERFEREOBJVS");
		}
		set
		{
			setHandle("INTERFEREOBJVS", value);
		}
	}

	public ulong? INTERFEREVPVS
	{
		get
		{
			return getHandle("INTERFEREVPVS");
		}
		set
		{
			setHandle("INTERFEREVPVS", value);
		}
	}

	public ulong? DRAGVS
	{
		get
		{
			return getHandle("DRAGVS");
		}
		set
		{
			setHandle("DRAGVS", value);
		}
	}

	public ulong? UCSBASE
	{
		get
		{
			return getHandle("UCSBASE");
		}
		set
		{
			setHandle("UCSBASE", value);
		}
	}

	public ulong? GetHandle(string name)
	{
		_handles.TryGetValue(name, out var value);
		return value;
	}

	public void SetHandle(string name, ulong? value)
	{
		_handles[name] = value;
	}

	public List<ulong?> GetHandles()
	{
		return new List<ulong?>(_handles.Values);
	}

	public void UpdateHeader(CadHeader header, DwgDocumentBuilder builder)
	{
		if (builder.TryGetCadObject<TableEntry>(CLAYER, out var value))
		{
			header.CurrentLayerName = value.Name;
		}
		if (builder.TryGetCadObject<TableEntry>(CELTYPE, out value))
		{
			header.CurrentLineTypeName = value.Name;
		}
		if (builder.TryGetCadObject<TableEntry>(CMLSTYLE, out value))
		{
			header.CurrentMLineStyleName = value.Name;
		}
		if (builder.TryGetCadObject<TableEntry>(TEXTSTYLE, out value))
		{
			header.CurrentTextStyleName = value.Name;
		}
		if (builder.TryGetCadObject<TableEntry>(DIMTXSTY, out value))
		{
			header.DimensionTextStyleName = value.Name;
		}
		if (builder.TryGetCadObject<TableEntry>(DIMSTYLE, out value))
		{
			header.CurrentDimensionStyleName = value.Name;
		}
		if (builder.TryGetCadObject<BlockRecord>(DIMBLK, out var value2))
		{
			header.DimensionBlockName = value2.Name;
		}
		if (builder.TryGetCadObject<BlockRecord>(DIMLDRBLK, out value2))
		{
			header.DimensionBlockName = value2.Name;
		}
		if (builder.TryGetCadObject<BlockRecord>(DIMBLK1, out value2))
		{
			header.DimensionBlockNameFirst = value2.Name;
		}
		if (builder.TryGetCadObject<BlockRecord>(DIMBLK2, out value2))
		{
			header.DimensionBlockNameSecond = value2.Name;
		}
	}

	private ulong? getHandle([CallerMemberName] string name = null)
	{
		return GetHandle(name);
	}

	private void setHandle([CallerMemberName] string name = null, ulong? value = 0uL)
	{
		SetHandle(name, value);
	}
}
