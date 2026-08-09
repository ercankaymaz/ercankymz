using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.XData;

namespace ACadSharp;

public abstract class CadObject : IHandledCadObject
{
	private List<CadObject> _reactors = new List<CadObject>();

	private CadDictionary _xdictionary;

	public CadDocument Document { get; private set; }

	public ExtendedDataDictionary ExtendedData { get; private set; }

	[DxfCodeValue(new int[] { 5 })]
	public ulong Handle { get; internal set; }

	public virtual bool HasDynamicSubclass => false;

	public virtual string ObjectName { get; }

	public abstract ObjectType ObjectType { get; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 330 })]
	public IHandledCadObject Owner { get; internal set; }

	public IEnumerable<CadObject> Reactors => _reactors;

	public abstract string SubclassMarker { get; }

	public CadDictionary XDictionary
	{
		get
		{
			return _xdictionary;
		}
		internal set
		{
			if (value != null)
			{
				_xdictionary = value;
				_xdictionary.Owner = this;
				if (Document != null)
				{
					Document.RegisterCollection(_xdictionary);
				}
			}
		}
	}

	public CadObject()
	{
		ExtendedData = new ExtendedDataDictionary(this);
	}

	public void AddReactor(CadObject reactor)
	{
		_reactors.Add(reactor);
	}

	public void CleanReactors()
	{
		CadObject[] array = _reactors.ToArray();
		foreach (CadObject cadObject in array)
		{
			if (cadObject.Document != Document)
			{
				_reactors.Remove(cadObject);
			}
		}
	}

	public virtual CadObject Clone()
	{
		CadObject obj = (CadObject)MemberwiseClone();
		obj.Handle = 0uL;
		obj.Document = null;
		obj.Owner = null;
		obj._reactors = new List<CadObject>();
		obj.ExtendedData = new ExtendedDataDictionary(obj);
		obj.XDictionary = _xdictionary?.CloneTyped();
		return obj;
	}

	public CadDictionary CreateExtendedDictionary()
	{
		if (_xdictionary == null)
		{
			XDictionary = new CadDictionary();
		}
		return _xdictionary;
	}

	public bool RemoveReactor(CadObject reactor)
	{
		return _reactors.Remove(reactor);
	}

	public override string ToString()
	{
		return $"{ObjectName}:{Handle}";
	}

	internal virtual void AssignDocument(CadDocument doc)
	{
		Document = doc;
		if (XDictionary != null)
		{
			doc.RegisterCollection(XDictionary);
		}
		if (ExtendedData.Any())
		{
			KeyValuePair<AppId, ExtendedData>[] array = ExtendedData.ToArray();
			ExtendedData.Clear();
			KeyValuePair<AppId, ExtendedData>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				KeyValuePair<AppId, ExtendedData> keyValuePair = array2[i];
				ExtendedData.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
	}

	internal virtual void UnassignDocument()
	{
		if (XDictionary != null)
		{
			Document.UnregisterCollection(XDictionary);
		}
		Handle = 0uL;
		Document = null;
		if (ExtendedData.Any())
		{
			KeyValuePair<AppId, ExtendedData>[] array = ExtendedData.ToArray();
			ExtendedData.Clear();
			KeyValuePair<AppId, ExtendedData>[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				KeyValuePair<AppId, ExtendedData> keyValuePair = array2[i];
				ExtendedData.Add(keyValuePair.Key.Clone() as AppId, keyValuePair.Value);
			}
		}
		_reactors.Clear();
	}

	protected static T updateCollection<T>(T entry, ICadCollection<T> table) where T : CadObject, INamedCadObject
	{
		if (table == null || entry == null)
		{
			return entry;
		}
		return table.TryAdd(entry);
	}
}
