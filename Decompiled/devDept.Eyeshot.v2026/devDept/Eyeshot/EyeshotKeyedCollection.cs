using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

[Serializable]
public abstract class EyeshotKeyedCollection<T> : KeyedCollection<string, T> where T : IKeyedCollectionItem<T>
{
	private sealed class _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D
	{
		public EyeshotKeyedCollection<T> _0023_003DzopRx0_MBcTQs;

		public string _0023_003DzdC_0024yD99foo4s;

		internal bool _0023_003DzmV0vacYDNs_X36EtAw_003D_003D(T _0023_003DzwMq3T_0024U_003D)
		{
			return _0023_003DzopRx0_MBcTQs.GetKeyForItem(_0023_003DzwMq3T_0024U_003D).Equals(_0023_003DzdC_0024yD99foo4s, StringComparison.OrdinalIgnoreCase);
		}
	}

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Document _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;

	private protected bool _skipRemovingChecks;

	protected internal Document Document
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;
		}
	}

	internal Dictionary<string, T> BaseDictionary => base.Dictionary as Dictionary<string, T>;

	public new virtual T this[string name]
	{
		get
		{
			if (name == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984554) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984529));
			}
			if (!Contains(name))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984554) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983930) + name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984499));
			}
			return base[name];
		}
	}

	public new virtual T this[int index]
	{
		get
		{
			if (index < 0 || index >= base.Count)
			{
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984492), index, typeof(T).Name));
			}
			return base[index];
		}
		set
		{
			SetItem(index, value);
		}
	}

	protected EyeshotKeyedCollection()
		: base((IEqualityComparer<string>)null, 0)
	{
	}

	protected EyeshotKeyedCollection(IEqualityComparer<string> comparer)
		: base(comparer, 0)
	{
	}

	protected EyeshotKeyedCollection(IEqualityComparer<string> comparer, int dictionaryCreationThreshold)
		: base(comparer, dictionaryCreationThreshold)
	{
	}

	protected EyeshotKeyedCollection(IEnumerable<T> collection, IEqualityComparer<string> comparer)
		: base(comparer, 0)
	{
		AddRange(collection);
	}

	private void _0023_003DzSrVa3io_003D(Document _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal IWorkspaceInternal _0023_003Dzo60vEkkaRGxX()
	{
		return Document?.workspace;
	}

	internal virtual void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		_0023_003DzSrVa3io_003D(_0023_003DzoPlwCJA_003D);
	}

	internal List<T> _0023_003Dz7GC5mgNtxbGh()
	{
		return base.Items as List<T>;
	}

	protected override void InsertItem(int index, T item)
	{
		base.InsertItem(index, item);
		_0023_003DzXV3ITe3Ls_W9(item);
	}

	private void _0023_003DzuviSgEaHyyzo(object _0023_003Dz9VjL5i0_003D, KeyChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		T _0023_003DzUBZd570_003D = (T)_0023_003Dz9VjL5i0_003D;
		_0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003DzbfrNXYE_003D.NewKey);
	}

	private protected virtual void _0023_003DzXV3ITe3Ls_W9(T _0023_003DzUBZd570_003D)
	{
		ref T reference = ref _0023_003DzUBZd570_003D;
		T val = default(T);
		if (val == null)
		{
			val = reference;
			reference = ref val;
		}
		KeyChangedEventHandler value = _0023_003DzuviSgEaHyyzo;
		reference.KeyChanged -= value;
		ref T reference2 = ref _0023_003DzUBZd570_003D;
		val = default(T);
		if (val == null)
		{
			val = reference2;
			reference2 = ref val;
		}
		KeyChangedEventHandler value2 = _0023_003DzuviSgEaHyyzo;
		reference2.KeyChanged += value2;
	}

	private protected virtual void _0023_003Dzbvv_0024NENySF38(T _0023_003DzUBZd570_003D)
	{
		_0023_003DzUBZd570_003D.KeyChanged -= _0023_003DzuviSgEaHyyzo;
	}

	private void _0023_003DzoHeLgXXPaLwn()
	{
		foreach (T item in base.Items)
		{
			_0023_003Dzbvv_0024NENySF38(item);
		}
	}

	internal void _0023_003Dz_hpEX5QR2_0024km()
	{
		foreach (T item in base.Items)
		{
			_0023_003DzXV3ITe3Ls_W9(item);
		}
	}

	protected override void SetItem(int index, T item)
	{
		T _0023_003DzUBZd570_003D = base.Items[index];
		base.SetItem(index, item);
		_0023_003DzXV3ITe3Ls_W9(item);
		_0023_003Dzbvv_0024NENySF38(_0023_003DzUBZd570_003D);
	}

	public virtual void Remove(IEnumerable<T> items)
	{
		_skipRemovingChecks = true;
		bool flag = true;
		HashSet<string> hashSet = new HashSet<string>();
		foreach (T item in items)
		{
			string key = item.GetKey();
			if (!Contains(key))
			{
				flag = false;
				break;
			}
			hashSet.Add(key);
		}
		if (AreEntitiesWith(hashSet))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983787));
		}
		if (flag)
		{
			foreach (T item2 in items)
			{
				_0023_003Dzbvv_0024NENySF38(item2);
				Remove(item2);
			}
		}
		_skipRemovingChecks = false;
	}

	protected override void RemoveItem(int index)
	{
		T _0023_003DzUBZd570_003D = base.Items[index];
		_0023_003Dzbvv_0024NENySF38(_0023_003DzUBZd570_003D);
		base.RemoveItem(index);
	}

	public bool TryRemove(T item)
	{
		string key = item.GetKey();
		if (Contains(key))
		{
			Remove(key);
			return true;
		}
		return false;
	}

	public bool TryRemove(string key)
	{
		if (TryGetValue(key, out var value))
		{
			Remove(value);
			return true;
		}
		return false;
	}

	internal int _0023_003Dzjl3pzGA_003D(T _0023_003DznubWD4pT7a7c)
	{
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2 = new _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D();
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003DzdC_0024yD99foo4s = GetKeyForItem(_0023_003DznubWD4pT7a7c);
		return _0023_003Dz7GC5mgNtxbGh().FindIndex(_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003DzmV0vacYDNs_X36EtAw_003D_003D);
	}

	internal virtual bool _0023_003DzKDPkfqhjl63a(T _0023_003DzAhotMQs_003D, bool _0023_003Dzmyw8uNw_003D)
	{
		int num = _0023_003Dzjl3pzGA_003D(_0023_003DzAhotMQs_003D);
		if (num != -1)
		{
			SetItem(num, _0023_003DzAhotMQs_003D);
			return true;
		}
		if (_0023_003Dzmyw8uNw_003D)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983683) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983930) + _0023_003DzAhotMQs_003D.GetKey() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983916));
		}
		return false;
	}

	public virtual bool ReplaceItem(T newItem)
	{
		_0023_003DzKDPkfqhjl63a(newItem, _0023_003Dzmyw8uNw_003D: true);
		return ChangeEntitiesRegenMode(newItem.GetKey());
	}

	public virtual bool AddOrReplace(T newItem)
	{
		if (_0023_003DzKDPkfqhjl63a(newItem, _0023_003Dzmyw8uNw_003D: false))
		{
			return ChangeEntitiesRegenMode(newItem.GetKey());
		}
		Add(newItem);
		return false;
	}

	public bool TryAdd(T item)
	{
		if (!Contains(item.GetKey()))
		{
			Add(item);
			return true;
		}
		return false;
	}

	protected bool ItemCanBeRemoved(T item, string defaultValueKey = null)
	{
		if (_skipRemovingChecks)
		{
			return true;
		}
		string key = item.GetKey();
		if (!Contains(key))
		{
			return false;
		}
		if (Document != null)
		{
			if (defaultValueKey != null && AreEqualStrings(key, defaultValueKey))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983864));
			}
			if (AreEntitiesWith(key))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983831) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983930) + key + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983819));
			}
		}
		return true;
	}

	internal T GetItemFast(string _0023_003DzS_00246o7tc_003D)
	{
		return base[_0023_003DzS_00246o7tc_003D];
	}

	internal void AddItemFast(T _0023_003DzUBZd570_003D)
	{
		base.Add(_0023_003DzUBZd570_003D);
	}

	public new virtual int Add(T item)
	{
		string key = item.GetKey();
		if (Contains(key))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984554) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983930) + key + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984689));
		}
		int count = base.Count;
		base.Add(item);
		return count;
	}

	public void AddRange(IEnumerable<T> collection)
	{
		if (collection == null)
		{
			return;
		}
		foreach (T item in collection)
		{
			Add(item);
		}
	}

	protected override void ClearItems()
	{
		_0023_003DzoHeLgXXPaLwn();
		base.ClearItems();
	}

	internal virtual void _0023_003DzTwVWSL0_003D(T _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		ChangeItemKey(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
	}

	protected internal virtual bool ChangeEntitiesRegenMode(string key)
	{
		bool result = false;
		if (Document != null)
		{
			foreach (Block block in Document.Blocks)
			{
				if (ChangeEntitiesRegenMode(block.Entities, key))
				{
					result = true;
				}
			}
			if (_0023_003Dzo60vEkkaRGxX()?.ParentBlocks != null)
			{
				foreach (Block parentBlock in _0023_003Dzo60vEkkaRGxX().ParentBlocks)
				{
					if (ChangeEntitiesRegenMode(parentBlock.Entities, key))
					{
						result = true;
					}
				}
			}
		}
		return result;
	}

	protected internal virtual bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string key)
	{
		return false;
	}

	public bool TryGetValue(string key, out T value)
	{
		value = default(T);
		if (base.Count == 0 || key == null)
		{
			return false;
		}
		return base.Dictionary.TryGetValue(key, out value);
	}

	protected internal static bool AreEqualStrings(string s1, string s2)
	{
		return string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase) == 0;
	}

	protected bool AreEntitiesWith(string name)
	{
		return AreEntitiesWith(new HashSet<string> { name });
	}

	protected bool AreEntitiesWith(HashSet<string> names)
	{
		if (Document == null)
		{
			return false;
		}
		foreach (Block block in Document.Blocks)
		{
			if (AreEntitiesWith(names, block.Entities))
			{
				return true;
			}
		}
		if (_0023_003Dzo60vEkkaRGxX()?.ParentBlocks != null)
		{
			foreach (Block parentBlock in _0023_003Dzo60vEkkaRGxX().ParentBlocks)
			{
				if (AreEntitiesWith(names, parentBlock.Entities))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected abstract bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities);

	protected internal bool CheckItemKey(string key, bool throwEx = false)
	{
		bool flag = Contains(key);
		if (throwEx && !flag)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984682) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984499));
		}
		return flag;
	}

	protected internal bool CheckItemIndex(int index, bool throwEx = false)
	{
		bool flag = index >= 0 && index < base.Count;
		if (throwEx && !flag)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984682) + typeof(T).Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984499));
		}
		return flag;
	}
}
