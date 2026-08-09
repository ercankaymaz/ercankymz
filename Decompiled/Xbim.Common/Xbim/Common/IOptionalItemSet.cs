using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Xbim.Common;

public interface IOptionalItemSet<T> : IItemSet<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IOptionalItemSet
{
	void Initialize();

	void Uninitialize();
}
public interface IOptionalItemSet
{
	bool Initialized { get; }
}
