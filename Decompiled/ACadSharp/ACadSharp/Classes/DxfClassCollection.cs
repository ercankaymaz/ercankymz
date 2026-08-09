using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACadSharp.Classes;

public class DxfClassCollection : ICollection<DxfClass>, IEnumerable<DxfClass>, IEnumerable
{
	public Dictionary<string, DxfClass> _entries = new Dictionary<string, DxfClass>(StringComparer.OrdinalIgnoreCase);

	public int Count => _entries.Count;

	public bool IsReadOnly => false;

	public static void UpdateDxfClasses(CadDocument doc)
	{
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbDictionaryWithDefault",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)22,
			DxfName = "ACDBDICTIONARYWDFLT",
			ItemClassId = 499,
			MaintenanceVersion = 42,
			ProxyFlags = ProxyFlags.R13FormatProxy,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbPlaceHolder",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "ACDBPLACEHOLDER",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbLayout",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "LAYOUT",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbDictionaryVar",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "DICTIONARYVAR",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbTableStyle",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1018,
			DxfName = "TABLESTYLE",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags)4095,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbMaterial",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "MATERIAL",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbVisualStyle",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1021,
			DxfName = "VISUALSTYLE",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags)4095,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbScale",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1021,
			DxfName = "SCALE",
			ItemClassId = 499,
			MaintenanceVersion = 1,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbMLeaderStyle",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1021,
			DxfName = "MLEADERSTYLE",
			ItemClassId = 499,
			MaintenanceVersion = 25,
			ProxyFlags = (ProxyFlags)4095,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbCellStyleMap",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1021,
			DxfName = "CELLSTYLEMAP",
			ItemClassId = 499,
			MaintenanceVersion = 25,
			ProxyFlags = (ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "ExAcXREFPanelObject",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "EXACXREFPANELOBJECT",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbImpNonPersistentObjectsCollection",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "NPOCOLLECTION",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbLayerIndex",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "LAYER_INDEX",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbSpatialIndex",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "SPATIAL_INDEX",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbIdBuffer",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1014,
			DxfName = "IDBUFFER",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.R13FormatProxy,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbSectionViewStyle",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "ACDBSECTIONVIEWSTYLE",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbDetailViewStyle",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "ACDBDETAILVIEWSTYLE",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbSubDMesh",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "MESH",
			ItemClassId = 498,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbSortentsTable",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1014,
			DxfName = "SORTENTSTABLE",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbTextObjectContextData",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "ACDB_TEXTOBJECTCONTEXTDATA_CLASS",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "WipeOut",
			CppClassName = "AcDbWipeout",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1015,
			DxfName = "WIPEOUT",
			ItemClassId = 498,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.TransformAllowed | ProxyFlags.ColorChangeAllowed | ProxyFlags.LayerChangeAllowed | ProxyFlags.LinetypeChangeAllowed | ProxyFlags.LinetypeScaleChangeAllowed | ProxyFlags.VisibilityChangeAllowed | ProxyFlags.R13FormatProxy),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "WipeOut",
			CppClassName = "AcDbWipeoutVariables",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1015,
			DxfName = "WIPEOUTVARIABLES",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.R13FormatProxy,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "AcDbDimAssoc",
			CppClassName = "AcDbDimAssoc",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "DIMASSOC",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbTable",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1018,
			DxfName = "ACAD_TABLE",
			ItemClassId = 498,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbTableContent",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1018,
			DxfName = "TABLECONTENT",
			ItemClassId = 499,
			MaintenanceVersion = 21,
			ProxyFlags = (ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbTableGeometry",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "TABLEGEOMETRY",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "ISM",
			CppClassName = "AcDbRasterImage",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "IMAGE",
			ItemClassId = 498,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.TransformAllowed | ProxyFlags.ColorChangeAllowed | ProxyFlags.LayerChangeAllowed | ProxyFlags.LinetypeChangeAllowed | ProxyFlags.LinetypeScaleChangeAllowed | ProxyFlags.VisibilityChangeAllowed | ProxyFlags.R13FormatProxy),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "ISM",
			CppClassName = "AcDbRasterImageDef",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "IMAGEDEF",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "ISM",
			CppClassName = "AcDbRasterImageDefReactor",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "IMAGEDEF_REACTOR",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.EraseAllowed,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbColor",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1015,
			DxfName = "DBCOLOR",
			ItemClassId = 499,
			MaintenanceVersion = 14,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbGeoData",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1021,
			DxfName = "GEODATA",
			ItemClassId = 499,
			MaintenanceVersion = 45,
			ProxyFlags = (ProxyFlags)4095,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbMLeader",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "MULTILEADER",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbPdfReference",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)26,
			DxfName = "PDFUNDERLAY",
			ItemClassId = 498,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags)4095,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbPdfDefinition",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)26,
			DxfName = "PDFDEFINITION",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			ApplicationName = "ISM",
			CppClassName = "AcDbRasterVariables",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "RASTERVARIABLES",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbSpatialFilter",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = (ACadVersion)20,
			DxfName = "SPATIAL_FILTER",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false,
			IsAnEntity = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbMLeaderObjectContextData",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.MC0_0,
			DxfName = "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS",
			ItemClassId = 499,
			MaintenanceVersion = 0,
			ProxyFlags = (ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog),
			WasZombie = false
		});
		doc.Classes.AddOrUpdate(new DxfClass
		{
			CppClassName = "AcDbPlotSettings",
			ClassNumber = (short)(500 + doc.Classes.Count),
			DwgVersion = ACadVersion.AC1015,
			DxfName = "PLOTSETTINGS",
			ItemClassId = 499,
			MaintenanceVersion = 42,
			ProxyFlags = ProxyFlags.None,
			WasZombie = false
		});
	}

	public void Add(DxfClass item)
	{
		_entries.Add(item.DxfName, item);
	}

	public void AddOrUpdate(DxfClass item)
	{
		if (_entries.TryGetValue(item.DxfName, out var value))
		{
			value.InstanceCount = item.InstanceCount;
		}
		else
		{
			_entries.Add(item.DxfName, item);
		}
	}

	public void Clear()
	{
		_entries.Clear();
	}

	public bool Contains(string dxfname)
	{
		return _entries.ContainsKey(dxfname);
	}

	public bool Contains(DxfClass item)
	{
		return _entries.Values.Contains(item);
	}

	public void CopyTo(DxfClass[] array, int arrayIndex)
	{
		_entries.Values.CopyTo(array, arrayIndex);
	}

	public DxfClass GetByClassNumber(short id)
	{
		return _entries.Values.FirstOrDefault((DxfClass c) => c.ClassNumber == id);
	}

	public DxfClass GetByName(string dxfname)
	{
		if (_entries.TryGetValue(dxfname, out var value))
		{
			return value;
		}
		return null;
	}

	public IEnumerator<DxfClass> GetEnumerator()
	{
		return _entries.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _entries.Values.GetEnumerator();
	}

	public bool Remove(DxfClass item)
	{
		return _entries.Remove(item.DxfName);
	}

	public bool TryGetByClassNumber(short id, out DxfClass result)
	{
		result = _entries.Values.FirstOrDefault((DxfClass c) => c.ClassNumber == id);
		return result != null;
	}

	public bool TryGetByName(string dxfname, out DxfClass result)
	{
		return _entries.TryGetValue(dxfname, out result);
	}
}
