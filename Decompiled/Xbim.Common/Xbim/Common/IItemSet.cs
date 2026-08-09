using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Xbim.Common;

public interface IItemSet
{
	IPersistEntity OwningEntity { get; }
}
public interface IItemSet<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet
{
	T GetAt(int index);

	void AddRange(IEnumerable<T> values);

	T FirstOrDefault(Func<T, bool> predicate);

	TF FirstOrDefault<TF>(Func<TF, bool> predicate) where TF : T;

	IEnumerable<TW> Where<TW>(Func<TW, bool> predicate) where TW : T;
}
