using System;
using System.Collections;
using System.Collections.Generic;

namespace ACadSharp;

public interface IObservableCadCollection<T> : IEnumerable<T>, IEnumerable where T : CadObject
{
	event EventHandler<CollectionChangedEventArgs> OnAdd;

	event EventHandler<CollectionChangedEventArgs> OnRemove;
}
