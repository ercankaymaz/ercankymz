using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Tables;

namespace ACadSharp.XData;

public class ExtendedDataDictionary : IEnumerable<KeyValuePair<AppId, ExtendedData>>, IEnumerable
{
	private Dictionary<AppId, ExtendedData> _data = new Dictionary<AppId, ExtendedData>();

	public CadDocument Document => Owner?.Document;

	public CadObject Owner { get; }

	public ExtendedDataDictionary(CadObject owner)
	{
		Owner = owner;
	}

	public void Add(AppId app)
	{
		Add(app, new ExtendedData());
	}

	public void Add(string appName)
	{
		Add(appName, new ExtendedData());
	}

	public void Add(string appName, ExtendedData extendedData)
	{
		Add(new AppId(appName), extendedData);
	}

	public void Add(AppId app, ExtendedData extendedData)
	{
		if (Document != null)
		{
			if (Document.AppIds.TryGetValue(app.Name, out var item))
			{
				_data.Add(item, extendedData);
				return;
			}
			Document.AppIds.Add(app);
			_data.Add(app, extendedData);
		}
		else
		{
			_data.Add(app, extendedData);
		}
	}

	public void Add(AppId app, IEnumerable<ExtendedDataRecord> records)
	{
		_data.Add(app, new ExtendedData(records));
	}

	public void Clear()
	{
		_data.Clear();
	}

	public bool ContainsKey(AppId app)
	{
		return _data.ContainsKey(app);
	}

	public bool ContainsKeyName(string name)
	{
		return _data.Keys.Select((AppId k) => k.Name).Contains(name);
	}

	public ExtendedData Get(string name)
	{
		return GetExtendedDataByName()[name];
	}

	public ExtendedData Get(AppId app)
	{
		return _data[app];
	}

	public IEnumerator<KeyValuePair<AppId, ExtendedData>> GetEnumerator()
	{
		return _data.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _data.GetEnumerator();
	}

	public IDictionary<string, ExtendedData> GetExtendedDataByName()
	{
		return _data.ToDictionary((KeyValuePair<AppId, ExtendedData> x) => x.Key.Name, (KeyValuePair<AppId, ExtendedData> x) => x.Value, StringComparer.OrdinalIgnoreCase);
	}

	public ExtendedData TryAdd(string appName, ExtendedData extendedData)
	{
		if (TryGet(appName, out var value))
		{
			return value;
		}
		Add(appName, extendedData);
		return extendedData;
	}

	public bool TryGet(AppId app, out ExtendedData value)
	{
		return _data.TryGetValue(app, out value);
	}

	public bool TryGet(string name, out ExtendedData value)
	{
		return GetExtendedDataByName().TryGetValue(name, out value);
	}
}
