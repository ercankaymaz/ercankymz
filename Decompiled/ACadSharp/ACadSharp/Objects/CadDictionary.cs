using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using CSUtilities.Extensions;

namespace ACadSharp.Objects;

[DxfName("DICTIONARY")]
[DxfSubClass("AcDbDictionary")]
public class CadDictionary : NonGraphicalObject, IObservableCadCollection<NonGraphicalObject>, IEnumerable<NonGraphicalObject>, IEnumerable
{
	public const string AcadColor = "ACAD_COLOR";

	public const string AcadFieldList = "ACAD_FIELDLIST";

	public const string AcadGroup = "ACAD_GROUP";

	public const string AcadImageDict = "ACAD_IMAGE_DICT";

	public const string AcadLayout = "ACAD_LAYOUT";

	public const string AcadMaterial = "ACAD_MATERIAL";

	public const string AcadMLeaderStyle = "ACAD_MLEADERSTYLE";

	public const string AcadMLineStyle = "ACAD_MLINESTYLE";

	public const string AcadPdfDefinitions = "ACAD_PDFDEFINITIONS";

	public const string AcadPlotSettings = "ACAD_PLOTSETTINGS";

	public const string AcadPlotStyleName = "ACAD_PLOTSTYLENAME";

	public const string AcadScaleList = "ACAD_SCALELIST";

	public const string AcadSortEnts = "ACAD_SORTENTS";

	public const string AcadTableStyle = "ACAD_TABLESTYLE";

	public const string AcadVisualStyle = "ACAD_VISUALSTYLE";

	public const string GeographicData = "ACAD_GEOGRAPHICDATA";

	public const string Root = "ROOT";

	public const string VariableDictionary = "AcDbVariableDictionary";

	private Dictionary<string, NonGraphicalObject> _entries = new Dictionary<string, NonGraphicalObject>(StringComparer.OrdinalIgnoreCase);

	[DxfCodeValue(new int[] { 281 })]
	public DictionaryCloningFlags ClonningFlags { get; set; }

	[DxfCodeValue(new int[] { 350 })]
	public ulong[] EntryHandles => _entries.Values.Select((NonGraphicalObject c) => c.Handle).ToArray();

	[DxfCodeValue(new int[] { 3 })]
	public string[] EntryNames => _entries.Keys.ToArray();

	[DxfCodeValue(new int[] { 280 })]
	public bool HardOwnerFlag { get; set; }

	public override string ObjectName => "DICTIONARY";

	public override ObjectType ObjectType => ObjectType.DICTIONARY;

	public override string SubclassMarker => "AcDbDictionary";

	public CadObject this[string key] => _entries[key];

	public event EventHandler<CollectionChangedEventArgs> OnAdd;

	public event EventHandler<CollectionChangedEventArgs> OnRemove;

	public CadDictionary()
	{
	}

	public CadDictionary(string name)
	{
		Name = name;
	}

	public static void CreateDefaultEntries(CadDictionary root)
	{
		root.TryAdd(new CadDictionary("ACAD_COLOR"));
		root.TryAdd(new CadDictionary("ACAD_GROUP"));
		root.TryAdd(new CadDictionary("ACAD_LAYOUT"));
		root.TryAdd(new CadDictionary("ACAD_MATERIAL"));
		root.TryAdd(new CadDictionary("ACAD_SORTENTS"));
		root.TryAdd(new CadDictionary("ACAD_MLEADERSTYLE"));
		root.TryAdd(new CadDictionary("ACAD_MLINESTYLE"));
		root.TryAdd(new CadDictionary("ACAD_TABLESTYLE"));
		root.TryAdd(new CadDictionary("ACAD_PLOTSETTINGS"));
		root.TryAdd(new CadDictionary("AcDbVariableDictionary"));
		root.TryAdd(new CadDictionary("ACAD_SCALELIST"));
		root.TryAdd(new CadDictionary("ACAD_VISUALSTYLE"));
		root.TryAdd(new CadDictionary("ACAD_FIELDLIST"));
		root.TryAdd(new CadDictionary("ACAD_IMAGE_DICT"));
		root.TryAdd(new CadDictionary("ACAD_MATERIAL"));
	}

	public static CadDictionary CreateRoot()
	{
		CadDictionary cadDictionary = new CadDictionary("ROOT");
		CreateDefaultEntries(cadDictionary);
		return cadDictionary;
	}

	public void Add(string key, NonGraphicalObject value)
	{
		if (string.IsNullOrEmpty(key))
		{
			throw new ArgumentNullException("value", "NonGraphicalObject [" + GetType().FullName + "] must have a name");
		}
		_entries.Add(key, value);
		value.Owner = this;
		value.OnNameChanged += onEntryNameChanged;
		this.OnAdd?.Invoke(this, new CollectionChangedEventArgs(value));
	}

	public void Add(NonGraphicalObject value)
	{
		Add(value.Name, value);
	}

	public void Clear()
	{
		foreach (KeyValuePair<string, NonGraphicalObject> entry in _entries)
		{
			Remove(entry.Key, out var _);
		}
	}

	public override CadObject Clone()
	{
		CadDictionary cadDictionary = (CadDictionary)base.Clone();
		cadDictionary.OnAdd = null;
		cadDictionary.OnRemove = null;
		cadDictionary._entries = new Dictionary<string, NonGraphicalObject>();
		foreach (NonGraphicalObject value in _entries.Values)
		{
			cadDictionary.Add(value.CloneTyped());
		}
		return cadDictionary;
	}

	public bool ContainsKey(string key)
	{
		return _entries.ContainsKey(key);
	}

	public T GetEntry<T>(string name) where T : NonGraphicalObject
	{
		TryGetEntry<T>(name, out var value);
		return value;
	}

	public IEnumerator<NonGraphicalObject> GetEnumerator()
	{
		return _entries.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _entries.Values.GetEnumerator();
	}

	public bool Remove(string key, out NonGraphicalObject item)
	{
		if (_entries.Remove(key, out item))
		{
			item.Owner = null;
			this.OnRemove?.Invoke(this, new CollectionChangedEventArgs(item));
			item.OnNameChanged -= onEntryNameChanged;
			return true;
		}
		return false;
	}

	public bool Remove(string key)
	{
		NonGraphicalObject item;
		return Remove(key, out item);
	}

	public bool TryAdd(NonGraphicalObject value)
	{
		if (!_entries.ContainsKey(value.Name))
		{
			Add(value.Name, value);
			return true;
		}
		return false;
	}

	public bool TryGetEntry<T>(string name, out T value) where T : NonGraphicalObject
	{
		if (_entries.TryGetValue(name, out var value2) && value2 is T val)
		{
			value = val;
			return true;
		}
		value = null;
		return false;
	}

	private void onEntryNameChanged(object sender, OnNameChangedArgs e)
	{
		NonGraphicalObject value = _entries[e.OldName];
		_entries.Add(e.NewName, value);
		_entries.Remove(e.OldName);
	}
}
