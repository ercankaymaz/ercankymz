using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common;

public interface IReadOnlyEntityCollection : IEnumerable<IPersistEntity>, IEnumerable
{
	long Count { get; }

	IEnumerable<T> Where<T>(Func<T, bool> condition) where T : IPersistEntity;

	IEnumerable<T> Where<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity;

	T FirstOrDefault<T>() where T : IPersistEntity;

	T FirstOrDefault<T>(Func<T, bool> condition) where T : IPersistEntity;

	T FirstOrDefault<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity;

	IEnumerable<T> OfType<T>() where T : IPersistEntity;

	IEnumerable<T> OfType<T>(bool activate) where T : IPersistEntity;

	IEnumerable<IPersistEntity> OfType(string stringType, bool activate);

	long CountOf<T>() where T : IPersistEntity;
}
