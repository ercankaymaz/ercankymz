using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Xbim.Common;

namespace Xbim.Ifc4;

public class OptionalItemSet<T> : ItemSet<T>, IOptionalItemSet<T>, IItemSet<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IOptionalItemSet
{
	private bool _initialized;

	public bool Initialized
	{
		get
		{
			if (!_initialized)
			{
				return base.Count > 0;
			}
			return true;
		}
	}

	internal OptionalItemSet(IPersistEntity entity, int capacity, int property)
		: base(entity, capacity, property)
	{
	}

	public void Initialize()
	{
		_initialized = true;
	}

	public void Uninitialize()
	{
		Clear();
		_initialized = false;
	}
}
