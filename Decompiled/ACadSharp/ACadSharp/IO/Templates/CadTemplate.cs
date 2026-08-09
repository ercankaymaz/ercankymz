using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.XData;

namespace ACadSharp.IO.Templates;

internal abstract class CadTemplate : ICadObjectTemplate, ICadTemplate
{
	public CadObject CadObject { get; set; }

	public Dictionary<ulong, List<ExtendedDataRecord>> EDataTemplate { get; set; } = new Dictionary<ulong, List<ExtendedDataRecord>>();

	public Dictionary<string, List<ExtendedDataRecord>> EDataTemplateByAppName { get; set; } = new Dictionary<string, List<ExtendedDataRecord>>();

	public bool HasBeenBuilt { get; private set; }

	public ulong? OwnerHandle { get; set; }

	public HashSet<ulong> ReactorsHandles { get; set; } = new HashSet<ulong>();

	public ulong? XDictHandle { get; set; }

	public CadTemplate(CadObject cadObject)
	{
		CadObject = cadObject;
	}

	public void Build(CadDocumentBuilder builder)
	{
		if (!HasBeenBuilt)
		{
			HasBeenBuilt = true;
			build(builder);
		}
	}

	public override string ToString()
	{
		return CadObject?.ToString() ?? "";
	}

	protected virtual void build(CadDocumentBuilder builder)
	{
		if (builder.TryGetCadObject<CadDictionary>(XDictHandle, out var value))
		{
			CadObject.XDictionary = value;
		}
		foreach (ulong reactorsHandle in ReactorsHandles)
		{
			if (builder.TryGetCadObject<CadObject>(reactorsHandle, out var value2))
			{
				CadObject.AddReactor(value2);
			}
			else
			{
				builder.Notify($"Reactor with handle {reactorsHandle} not found", NotificationType.Warning);
			}
		}
		foreach (KeyValuePair<ulong, List<ExtendedDataRecord>> item in EDataTemplate)
		{
			if (builder.TryGetCadObject<AppId>(item.Key, out var value3))
			{
				CadObject.ExtendedData.Add(value3, item.Value);
			}
			else
			{
				builder.Notify($"AppId in extended data with handle {item.Key} not found", NotificationType.Warning);
			}
		}
		foreach (KeyValuePair<string, List<ExtendedDataRecord>> item2 in EDataTemplateByAppName)
		{
			if (builder.TryGetTableEntry<AppId>(item2.Key, out var entry))
			{
				CadObject.ExtendedData.Add(entry, item2.Value);
			}
			else
			{
				builder.Notify("AppId in extended data with handle " + item2.Key + " not found", NotificationType.Warning);
			}
		}
	}

	protected IEnumerable<T> getEntitiesCollection<T>(CadDocumentBuilder builder, ulong firstHandle, ulong endHandle) where T : Entity
	{
		CadEntityTemplate template = builder.GetObjectTemplate<CadEntityTemplate>(firstHandle);
		if (template == null)
		{
			builder.Notify($"Leading entity with handle {firstHandle} not found.", NotificationType.Warning);
			template = builder.GetObjectTemplate<CadEntityTemplate>(endHandle);
		}
		while (template != null)
		{
			yield return (T)template.CadObject;
			if (template.CadObject.Handle == endHandle)
			{
				break;
			}
			template = ((!template.NextEntity.HasValue) ? builder.GetObjectTemplate<CadEntityTemplate>(template.CadObject.Handle + 1) : builder.GetObjectTemplate<CadEntityTemplate>(template.NextEntity.Value));
		}
	}

	protected bool getTableReference<T>(CadDocumentBuilder builder, ulong? handle, string name, out T reference) where T : TableEntry
	{
		if (builder.TryGetCadObject<T>(handle, out reference) || builder.TryGetTableEntry<T>(name, out reference))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(name) || (handle.HasValue && handle.Value != 0L))
		{
			builder.Notify($"{typeof(T).FullName} table reference with handle: {handle} | name: {name} not found for {CadObject.GetType().FullName} with handle {CadObject.Handle}", NotificationType.Warning);
		}
		return false;
	}
}
internal class CadTemplate<T> : CadTemplate where T : CadObject
{
	public new T CadObject
	{
		get
		{
			return (T)base.CadObject;
		}
		set
		{
			base.CadObject = value;
		}
	}

	public CadTemplate(T cadObject)
		: base(cadObject)
	{
	}
}
