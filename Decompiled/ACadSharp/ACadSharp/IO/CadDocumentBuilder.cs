using System;
using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;

namespace ACadSharp.IO;

internal abstract class CadDocumentBuilder
{
	protected Dictionary<ulong, CadObject> cadObjects = new Dictionary<ulong, CadObject>();

	protected Dictionary<ulong, ICadObjectTemplate> cadObjectsTemplates = new Dictionary<ulong, ICadObjectTemplate>();

	protected Dictionary<ulong, ICadDictionaryTemplate> dictionaryTemplates = new Dictionary<ulong, ICadDictionaryTemplate>();

	protected Dictionary<ulong, ICadTableEntryTemplate> tableEntryTemplates = new Dictionary<ulong, ICadTableEntryTemplate>();

	protected Dictionary<ulong, ICadTableTemplate> tableTemplates = new Dictionary<ulong, ICadTableTemplate>();

	protected Dictionary<ulong, ICadObjectTemplate> templatesMap = new Dictionary<ulong, ICadObjectTemplate>();

	protected List<ICadObjectTemplate> unassignedObjects = new List<ICadObjectTemplate>();

	public AppIdsTable AppIds { get; set; } = new AppIdsTable();

	public BlockRecordsTable BlockRecords { get; set; } = new BlockRecordsTable();

	public DimensionStylesTable DimensionStyles { get; set; } = new DimensionStylesTable();

	public CadDocument DocumentToBuild { get; }

	public ulong InitialHandSeed { get; set; }

	public abstract bool KeepUnknownEntities { get; }

	public abstract bool KeepUnknownNonGraphicalObjects { get; }

	public LayersTable Layers { get; set; } = new LayersTable();

	public LineTypesTable LineTypesTable { get; set; } = new LineTypesTable();

	public TextStylesTable TextStyles { get; set; } = new TextStylesTable();

	public UCSTable UCSs { get; set; } = new UCSTable();

	public ACadVersion Version { get; }

	public ViewsTable Views { get; set; } = new ViewsTable();

	public VPortsTable VPorts { get; set; } = new VPortsTable();

	public event NotificationEventHandler OnNotification;

	public CadDocumentBuilder(ACadVersion version, CadDocument document)
	{
		Version = version;
		DocumentToBuild = document;
	}

	public void AddTemplate(ICadObjectTemplate template)
	{
		if (!addToMap(template))
		{
			return;
		}
		if (!(template is ICadDictionaryTemplate cadDictionaryTemplate))
		{
			if (!(template is ICadTableTemplate cadTableTemplate))
			{
				if (template is ICadTableEntryTemplate cadTableEntryTemplate)
				{
					tableEntryTemplates.Add(cadTableEntryTemplate.CadObject.Handle, cadTableEntryTemplate);
				}
				else
				{
					cadObjectsTemplates.Add(template.CadObject.Handle, template);
				}
			}
			else
			{
				tableTemplates.Add(cadTableTemplate.CadObject.Handle, cadTableTemplate);
			}
		}
		else
		{
			dictionaryTemplates.Add(cadDictionaryTemplate.CadObject.Handle, cadDictionaryTemplate);
		}
	}

	public virtual void BuildDocument()
	{
		foreach (ICadTableEntryTemplate value in tableEntryTemplates.Values)
		{
			value.Build(this);
		}
		foreach (CadTemplate value2 in cadObjectsTemplates.Values)
		{
			value2.Build(this);
		}
	}

	public void BuildTable<T>(Table<T> table) where T : TableEntry
	{
		if (tableTemplates.TryGetValue(table.Handle, out var value))
		{
			value.Build(this);
		}
		else
		{
			Notify("Table " + table.ObjectName + " not found in the document", NotificationType.Warning);
		}
	}

	public void BuildTables()
	{
		BuildTable(AppIds);
		BuildTable(TextStyles);
		BuildTable(LineTypesTable);
		BuildTable(Layers);
		BuildTable(UCSs);
		BuildTable(Views);
		BuildTable(BlockRecords);
		BuildTable(DimensionStyles);
		BuildTable(VPorts);
	}

	public T GetObjectTemplate<T>(ulong handle) where T : CadTemplate
	{
		if (templatesMap.TryGetValue(handle, out var value))
		{
			return (T)value;
		}
		return null;
	}

	public void Notify(string message, NotificationType notificationType = NotificationType.None, Exception exception = null)
	{
		this.OnNotification?.Invoke(this, new NotificationEventArgs(message, notificationType, exception));
	}

	public void RegisterTables()
	{
		DocumentToBuild.RegisterCollection(AppIds);
		DocumentToBuild.RegisterCollection(TextStyles);
		DocumentToBuild.RegisterCollection(LineTypesTable);
		DocumentToBuild.RegisterCollection(Layers);
		DocumentToBuild.RegisterCollection(UCSs);
		DocumentToBuild.RegisterCollection(Views);
		DocumentToBuild.RegisterCollection(BlockRecords);
		DocumentToBuild.RegisterCollection(DimensionStyles);
		DocumentToBuild.RegisterCollection(VPorts);
	}

	public bool TryGetCadObject<T>(ulong? handle, out T value) where T : CadObject
	{
		if (!handle.HasValue || handle == 0)
		{
			value = null;
			return false;
		}
		if (cadObjects.TryGetValue(handle.Value, out var value2))
		{
			if (value2 is UnknownEntity && !KeepUnknownEntities)
			{
				value = null;
				return false;
			}
			if (value2 is UnknownNonGraphicalObject && !KeepUnknownNonGraphicalObjects)
			{
				value = null;
				return false;
			}
			if (value2 is T)
			{
				value = (T)value2;
				return true;
			}
		}
		value = null;
		return false;
	}

	public bool TryGetObjectTemplate<T>(ulong? handle, out T value) where T : ICadObjectTemplate
	{
		if (!handle.HasValue || handle == 0)
		{
			value = default(T);
			return false;
		}
		if (templatesMap.TryGetValue(handle.Value, out var value2) && value2 is T)
		{
			value = (T)value2;
			return true;
		}
		value = default(T);
		return false;
	}

	public bool TryGetTableEntry<T>(string name, out T entry) where T : TableEntry
	{
		if (string.IsNullOrEmpty(name))
		{
			entry = null;
			return false;
		}
		Table<T> table = null;
		if (typeof(T) == typeof(AppId))
		{
			table = AppIds as Table<T>;
		}
		else if (typeof(T) == typeof(Layer))
		{
			table = Layers as Table<T>;
		}
		else if (typeof(T) == typeof(LineType))
		{
			table = LineTypesTable as Table<T>;
		}
		else if (typeof(T) == typeof(UCS))
		{
			table = UCSs as Table<T>;
		}
		else if (typeof(T) == typeof(View))
		{
			table = Views as Table<T>;
		}
		else if (typeof(T) == typeof(DimensionStyle))
		{
			table = DimensionStyles as Table<T>;
		}
		else if (typeof(T) == typeof(TextStyle))
		{
			table = TextStyles as Table<T>;
		}
		else if (typeof(T) == typeof(VPortsTable))
		{
			table = VPorts as Table<T>;
		}
		else if (typeof(T) == typeof(BlockRecord))
		{
			table = BlockRecords as Table<T>;
		}
		if (table == null)
		{
			entry = null;
			return false;
		}
		return table.TryGetValue(name, out entry);
	}

	protected void buildDictionaries()
	{
		foreach (ICadDictionaryTemplate value in dictionaryTemplates.Values)
		{
			value.Build(this);
		}
		DocumentToBuild.UpdateCollections(createDictionaries: true, createDefaults: false);
	}

	protected void createMissingHandles()
	{
		foreach (ICadObjectTemplate unassignedObject in unassignedObjects)
		{
			unassignedObject.CadObject.Handle = InitialHandSeed + 1;
			AddTemplate(unassignedObject);
		}
		unassignedObjects.Clear();
	}

	protected void registerTable<T, R>(T table) where T : Table<R> where R : TableEntry
	{
		if (table == null)
		{
			DocumentToBuild.RegisterCollection((T)Activator.CreateInstance(typeof(T)));
		}
		else
		{
			DocumentToBuild.RegisterCollection(table);
		}
	}

	private bool addToMap(ICadObjectTemplate template)
	{
		if (template.CadObject.Handle == 0L)
		{
			unassignedObjects.Add(template);
			return false;
		}
		if (templatesMap.ContainsKey(template.CadObject.Handle))
		{
			Notify($"Repeated handle found {template.CadObject.Handle}.", NotificationType.Warning);
			template.CadObject.Handle = 0uL;
			unassignedObjects.Add(template);
			return false;
		}
		if (template.CadObject.Handle > InitialHandSeed)
		{
			InitialHandSeed = template.CadObject.Handle;
		}
		templatesMap.Add(template.CadObject.Handle, template);
		cadObjects.Add(template.CadObject.Handle, template.CadObject);
		return true;
	}
}
