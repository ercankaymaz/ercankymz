using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Extensions.Logging;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;

namespace Xbim.Common.Model;

internal class EntityCollection : IEntityCollection, IReadOnlyEntityCollection, IEnumerable<IPersistEntity>, IEnumerable, IDisposable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct EntityLabelComparer : IEqualityComparer<IPersistEntity>
	{
		public bool Equals(IPersistEntity x, IPersistEntity y)
		{
			return x.EntityLabel == y.EntityLabel;
		}

		public int GetHashCode(IPersistEntity obj)
		{
			return obj.EntityLabel;
		}
	}

	private class NaturalOrderEnumerator : IEnumerator<IPersistEntity>, IEnumerator, IDisposable
	{
		private readonly Dictionary<int, IPersistEntity> _entities;

		private readonly List<int> _naturalOrder;

		private int _current;

		private IPersistEntity _currentEntity;

		public IPersistEntity Current => _currentEntity;

		object IEnumerator.Current => _currentEntity;

		public NaturalOrderEnumerator(List<int> naturalOrder, Dictionary<int, IPersistEntity> entities)
		{
			_naturalOrder = naturalOrder;
			_entities = entities;
			Reset();
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			while (++_current < _naturalOrder.Count)
			{
				if (_entities.TryGetValue(_naturalOrder[_current], out _currentEntity))
				{
					return true;
				}
			}
			_currentEntity = null;
			return false;
		}

		public void Reset()
		{
			_current = -1;
			_currentEntity = null;
		}
	}

	private readonly ILogger _logger;

	private readonly StepModel _model;

	private readonly XbimMultiValueDictionary<Type, IPersistEntity> _internal;

	private readonly Dictionary<int, IPersistEntity> _collection = new Dictionary<int, IPersistEntity>(489335);

	private List<int> _naturalOrder = new List<int>(489335);

	internal int CurrentLabel;

	public int LastLabel => CurrentLabel;

	internal IEntityFactory Factory => _model.EntityFactory;

	public IPersistEntity this[int label]
	{
		get
		{
			if (_collection.TryGetValue(label, out var value))
			{
				return value;
			}
			return null;
		}
	}

	public long Count => _collection.Count;

	internal void DiscardNaturalOrder()
	{
		_naturalOrder = null;
	}

	public EntityCollection(StepModel model, int labelFrom = 0)
	{
		CurrentLabel = Math.Max(CurrentLabel, labelFrom);
		_model = model;
		_internal = XbimMultiValueDictionary<Type, IPersistEntity>.Create(() => new HashSet<IPersistEntity>(default(EntityLabelComparer)));
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		_logger = loggerFactory.CreateLogger<EntityCollection>();
	}

	private IEnumerable<Type> GetQueryTypes(Type type)
	{
		ExpressType expressType = _model.Metadata.ExpressType(type);
		if (expressType != null)
		{
			return expressType.NonAbstractSubTypes.Select((ExpressType t) => t.Type);
		}
		if (!type.GetTypeInfo().IsInterface)
		{
			return new List<Type>();
		}
		return from e in _model.Metadata.ExpressTypesImplementing(type)
			where !e.Type.GetTypeInfo().IsAbstract
			select e.Type;
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		if (!(_model.InverseCache is MemoryInverseCache { IsDisposed: false } memoryInverseCache))
		{
			return Where(condition);
		}
		if (memoryInverseCache.TryGet(inverseProperty, inverseArgument, out IEnumerable<T> entities))
		{
			return entities.Where(condition);
		}
		return Enumerable.Empty<T>();
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition) where T : IPersistEntity
	{
		Type typeFromHandle = typeof(T);
		IEnumerable<Type> queryTypes = GetQueryTypes(typeFromHandle);
		if (condition != null)
		{
			foreach (Type item in queryTypes)
			{
				if (!_internal.TryGetValue(item, out var value))
				{
					continue;
				}
				foreach (IPersistEntity item2 in value.Where((IPersistEntity c) => condition((T)c)))
				{
					yield return (T)item2;
				}
			}
			yield break;
		}
		foreach (Type item3 in queryTypes)
		{
			if (!_internal.TryGetValue(item3, out var value2))
			{
				continue;
			}
			foreach (IPersistEntity item4 in value2)
			{
				yield return (T)item4;
			}
		}
	}

	public T FirstOrDefault<T>() where T : IPersistEntity
	{
		return OfType<T>().FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> condition) where T : IPersistEntity
	{
		return Where(condition).FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		return Where(condition, inverseProperty, inverseArgument).FirstOrDefault();
	}

	public IEnumerable<T> OfType<T>() where T : IPersistEntity
	{
		Type typeFromHandle = typeof(T);
		IEnumerable<Type> queryTypes = GetQueryTypes(typeFromHandle);
		foreach (Type item in queryTypes)
		{
			if (!_internal.TryGetValue(item, out var value))
			{
				continue;
			}
			foreach (IPersistEntity item2 in value)
			{
				yield return (T)item2;
			}
		}
	}

	public IEnumerable<IPersistEntity> OfType(Type queryType)
	{
		IEnumerable<Type> queryTypes = GetQueryTypes(queryType);
		foreach (Type item in queryTypes)
		{
			if (!_internal.TryGetValue(item, out var value))
			{
				continue;
			}
			foreach (IPersistEntity item2 in value)
			{
				yield return item2;
			}
		}
	}

	public IEnumerable<T> OfType<T>(bool activate) where T : IPersistEntity
	{
		return OfType<T>();
	}

	public IEnumerable<IPersistEntity> OfType(string stringType, bool activate)
	{
		ExpressType expressType = _model.Metadata.ExpressType(stringType.ToUpperInvariant());
		if (expressType == null)
		{
			throw new ArgumentException("StringType must be a name of the existing persist entity type");
		}
		foreach (IPersistEntity item in OfType(expressType.Type))
		{
			yield return item;
		}
	}

	public IPersistEntity New(Type t)
	{
		IInstantiableEntity instantiableEntity = Factory.New(_model, t, Interlocked.Increment(ref CurrentLabel), activated: true);
		AddReversible(instantiableEntity);
		return instantiableEntity;
	}

	internal IPersistEntity New(Type t, int label)
	{
		IInstantiableEntity instantiableEntity = Factory.New(_model, t, label, activated: true);
		Interlocked.Exchange(ref CurrentLabel, (label >= CurrentLabel) ? label : CurrentLabel);
		AddReversible(instantiableEntity);
		return instantiableEntity;
	}

	public T New<T>(Action<T> initPropertiesFunc) where T : IInstantiableEntity
	{
		T val = Factory.New<T>(_model, Interlocked.Increment(ref CurrentLabel), activated: true);
		AddReversible(val);
		initPropertiesFunc?.Invoke(val);
		return val;
	}

	public T New<T>() where T : IInstantiableEntity
	{
		T val = Factory.New<T>(_model, Interlocked.Increment(ref CurrentLabel), activated: true);
		AddReversible(val);
		return val;
	}

	public long CountOf<T>() where T : IPersistEntity
	{
		return OfType<T>().Count();
	}

	internal void InternalAdd(IPersistEntity entity)
	{
		if (entity == null)
		{
			return;
		}
		Type type = entity.GetType();
		_internal.Add(type, entity);
		try
		{
			_collection.Add(entity.EntityLabel, entity);
			if (_naturalOrder != null)
			{
				_naturalOrder.Add(entity.EntityLabel);
			}
		}
		catch (Exception ex)
		{
			IPersistEntity persistEntity = _collection[entity.EntityLabel];
			if (entity.ExpressType != persistEntity.ExpressType)
			{
				_logger?.LogError($"Duplicate entity #{entity.EntityLabel} with different data type ({persistEntity.ExpressType.Name}/{entity.ExpressType.Name})", ex);
			}
			else
			{
				_logger?.LogWarning($"Duplicate entity #{entity.EntityLabel}", ex);
			}
		}
	}

	private void AddReversible(IPersistEntity entity)
	{
		if (_model.IsTransactional && _model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		Type key = entity.GetType();
		Action undoAction = delegate
		{
			_internal.Remove(key, entity);
			_collection.Remove(entity.EntityLabel);
			if (_naturalOrder != null)
			{
				_naturalOrder.Remove(entity.EntityLabel);
			}
		};
		Action action = delegate
		{
			_internal.Add(key, entity);
			_collection.Add(entity.EntityLabel, entity);
			if (_naturalOrder != null)
			{
				_naturalOrder.Add(entity.EntityLabel);
			}
		};
		if (!_model.IsTransactional)
		{
			action();
		}
		else
		{
			_model.CurrentTransaction.DoReversibleAction(action, undoAction, entity, ChangeType.New, 0);
		}
	}

	public bool Contains(IPersistEntity entity)
	{
		return Enumerable.Contains(_collection.Keys, entity.EntityLabel);
	}

	internal bool RemoveReversible(IPersistEntity entity)
	{
		if (_model.IsTransactional && _model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		Type key = entity.GetType();
		bool removed = false;
		int? index = null;
		Action action = delegate
		{
			_internal.Remove(key, entity);
			removed = _collection.Remove(entity.EntityLabel);
			index = _naturalOrder?.IndexOf(entity.EntityLabel);
			_naturalOrder?.RemoveAt(index.Value);
		};
		Action undoAction = delegate
		{
			_internal.Add(key, entity);
			_collection.Add(entity.EntityLabel, entity);
			_naturalOrder?.Insert(index.Value, entity.EntityLabel);
		};
		if (!_model.IsTransactional)
		{
			action();
			return removed;
		}
		_model.CurrentTransaction.DoReversibleAction(action, undoAction, entity, ChangeType.Deleted, 0);
		return removed;
	}

	internal void RemoveReversible(IPersistEntity[] entities)
	{
		if (_model.IsTransactional && _model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		Dictionary<Type, HashSet<IPersistEntity>> toDelete = new Dictionary<Type, HashSet<IPersistEntity>>();
		IPersistEntity[] array = entities;
		foreach (IPersistEntity persistEntity in array)
		{
			Type type = persistEntity.GetType();
			if (!toDelete.TryGetValue(type, out var value))
			{
				value = new HashSet<IPersistEntity>();
				toDelete.Add(type, value);
			}
			value.Add(persistEntity);
		}
		List<int> originalOrder = null;
		if (!_model.IsTransactional)
		{
			doAction();
			return;
		}
		if (_model.CurrentTransaction is Transaction transaction)
		{
			transaction.DoReversibleAction(doAction, undo, entities, ChangeType.Deleted, 0);
			return;
		}
		throw new XbimException("Batch delete not supported in this transaction type: " + _model.CurrentTransaction.GetType().Name);
		void doAction()
		{
			foreach (KeyValuePair<Type, HashSet<IPersistEntity>> kvp in toDelete)
			{
				ICollection<IPersistEntity> source = _internal[kvp.Key];
				_internal.Remove(kvp.Key);
				_internal.AddRange(kvp.Key, source.Where((IPersistEntity e) => !kvp.Value.Contains(e)));
			}
			HashSet<int> hashSet = new HashSet<int>(entities.Select((IPersistEntity e) => e.EntityLabel));
			foreach (int item in hashSet)
			{
				_collection.Remove(item);
			}
			if (_naturalOrder != null)
			{
				originalOrder = _naturalOrder;
				_naturalOrder = new List<int>(originalOrder.Count - entities.Length);
				foreach (int item2 in originalOrder)
				{
					if (!hashSet.Contains(item2))
					{
						_naturalOrder.Add(item2);
					}
				}
			}
		}
		void undo()
		{
			foreach (KeyValuePair<Type, HashSet<IPersistEntity>> item3 in toDelete)
			{
				_internal.AddRange(item3.Key, item3.Value);
			}
			IPersistEntity[] array2 = entities;
			foreach (IPersistEntity persistEntity2 in array2)
			{
				_collection.Add(persistEntity2.EntityLabel, persistEntity2);
			}
			_naturalOrder = originalOrder;
		}
	}

	public IEnumerator<IPersistEntity> GetEnumerator()
	{
		if (_naturalOrder != null)
		{
			return new NaturalOrderEnumerator(_naturalOrder, _collection);
		}
		return _collection.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _collection.GetEnumerator();
	}

	public void Dispose()
	{
		_internal.Clear();
		_collection.Clear();
		if (_naturalOrder != null)
		{
			_naturalOrder.Clear();
		}
	}
}
