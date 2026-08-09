using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common;

public interface IEntityCollection : IReadOnlyEntityCollection, IEnumerable<IPersistEntity>, IEnumerable
{
	IPersistEntity this[int label] { get; }

	int LastLabel { get; }

	IPersistEntity New(Type t);

	T New<T>(Action<T> initPropertiesFunc) where T : IInstantiableEntity;

	T New<T>() where T : IInstantiableEntity;
}
