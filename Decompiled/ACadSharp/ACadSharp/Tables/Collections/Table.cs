using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using CSUtilities.Extensions;

namespace ACadSharp.Tables.Collections;

[DxfSubClass("AcDbSymbolTable")]
public abstract class Table<T> : CadObject, ITable, ICadCollection<T>, IEnumerable<T>, IEnumerable, IObservableCadCollection<T> where T : TableEntry
{
	protected readonly Dictionary<string, T> entries = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 70 })]
	public int Count => entries.Count;

	public override string ObjectName => "TABLE";

	public override string SubclassMarker => "AcDbSymbolTable";

	protected abstract string[] defaultEntries { get; }

	public T this[string name] => entries[name];

	public event EventHandler<CollectionChangedEventArgs> OnAdd;

	public event EventHandler<CollectionChangedEventArgs> OnRemove;

	protected Table()
	{
	}

	protected Table(CadDocument document)
	{
		base.Owner = document;
		document.RegisterCollection(this);
	}

	public virtual void Add(T item)
	{
		if (string.IsNullOrEmpty(item.Name))
		{
			item.Name = createName("unnamed");
		}
		add(item.Name, item);
	}

	public void AddRange(IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			Add(item);
		}
	}

	public T TryAdd(T item)
	{
		if (TryGetValue(item.Name, out var item2))
		{
			return item2;
		}
		Add(item);
		return item;
	}

	public bool Contains(string key)
	{
		return entries.ContainsKey(key);
	}

	public void CreateDefaultEntries()
	{
		string[] array = defaultEntries;
		foreach (string text in array)
		{
			if (!Contains(text))
			{
				Add((T)Activator.CreateInstance(typeof(T), text));
			}
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return entries.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return entries.Values.GetEnumerator();
	}

	public T Remove(string key)
	{
		if (defaultEntries.Contains(key))
		{
			return null;
		}
		if (entries.Remove(key, out var value))
		{
			value.Owner = null;
			this.OnRemove?.Invoke(this, new CollectionChangedEventArgs(value));
			value.OnNameChanged -= onEntryNameChanged;
			return value;
		}
		return null;
	}

	public bool TryGetValue(string key, out T item)
	{
		return entries.TryGetValue(key, out item);
	}

	protected void add(string key, T item)
	{
		entries.Add(key, item);
		item.Owner = this;
		item.OnNameChanged += onEntryNameChanged;
		this.OnAdd?.Invoke(this, new CollectionChangedEventArgs(item));
	}

	protected void addHandlePrefix(T item)
	{
		item.Owner = this;
		item.OnNameChanged += onEntryNameChanged;
		this.OnAdd?.Invoke(this, new CollectionChangedEventArgs(item));
		string key = $"{item.Handle}:{item.Name}";
		entries.Add(key, item);
	}

	protected string createName(string prefix)
	{
		int i;
		for (i = 0; entries.ContainsKey($"{prefix}{i}"); i++)
		{
		}
		return $"{prefix}{i}";
	}

	private void onEntryNameChanged(object sender, OnNameChangedArgs e)
	{
		if (defaultEntries.Contains(e.OldName, StringComparer.InvariantCultureIgnoreCase))
		{
			throw new ArgumentException("The name " + e.OldName + " belongs to a default entry.");
		}
		T value = entries[e.OldName];
		entries.Add(e.NewName, value);
		entries.Remove(e.OldName);
	}
}
