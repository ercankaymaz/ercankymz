using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Federation;

public class FederatedModelInstances : IReadOnlyEntityCollection, IEnumerable<IPersistEntity>, IEnumerable
{
	private readonly IFederatedModel _model;

	public IPersistEntity this[XbimInstanceHandle handle] => handle.GetEntity();

	public long Count => _model.ReferencingModel.Instances.Count + _model.ReferencedModels.Sum((IReferencedModel refModel) => refModel.Model.Instances.Count);

	public IEnumerable<IPersistEntity> OfType(string stringType, bool activate)
	{
		foreach (IPersistEntity item in _model.ReferencingModel.Instances.OfType(stringType, activate))
		{
			yield return item;
		}
		foreach (IReferencedModel referencedModel in _model.ReferencedModels)
		{
			foreach (IPersistEntity item2 in referencedModel.Model.Instances.OfType(stringType, activate))
			{
				yield return item2;
			}
		}
	}

	public FederatedModelInstances(IFederatedModel model)
	{
		_model = model;
	}

	public IEnumerable<T> Where<T>(Func<T, bool> expr) where T : IPersistEntity
	{
		foreach (T item in _model.ReferencingModel.Instances.Where(expr))
		{
			yield return item;
		}
		foreach (IReferencedModel referencedModel in _model.ReferencedModels)
		{
			foreach (T item2 in referencedModel.Model.Instances.Where(expr))
			{
				yield return item2;
			}
		}
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		foreach (T item in _model.ReferencingModel.Instances.Where(condition, inverseProperty, inverseArgument))
		{
			yield return item;
		}
		foreach (IReferencedModel referencedModel in _model.ReferencedModels)
		{
			foreach (T item2 in referencedModel.Model.Instances.Where(condition, inverseProperty, inverseArgument))
			{
				yield return item2;
			}
		}
	}

	public T FirstOrDefault<T>() where T : IPersistEntity
	{
		return OfType<T>().FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> expr) where T : IPersistEntity
	{
		return Where(expr).FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		throw new NotImplementedException();
	}

	public IEnumerable<T> OfType<T>() where T : IPersistEntity
	{
		foreach (T item in _model.ReferencingModel.Instances.OfType<T>())
		{
			yield return item;
		}
		foreach (IReferencedModel referencedModel in _model.ReferencedModels)
		{
			foreach (T item2 in referencedModel.Model.Instances.OfType<T>())
			{
				yield return item2;
			}
		}
	}

	public IEnumerable<T> OfType<T>(bool activate) where T : IPersistEntity
	{
		foreach (T item in _model.ReferencingModel.Instances.OfType<T>(activate))
		{
			yield return item;
		}
		foreach (IReferencedModel referencedModel in _model.ReferencedModels)
		{
			foreach (T item2 in referencedModel.Model.Instances.OfType<T>(activate))
			{
				yield return item2;
			}
		}
	}

	public long CountOf<T>() where T : IPersistEntity
	{
		return _model.ReferencingModel.Instances.CountOf<T>() + _model.ReferencedModels.Sum((IReferencedModel refModel) => refModel.Model.Instances.CountOf<T>());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<IPersistEntity> GetEnumerator()
	{
		return _model.ReferencingModel.Instances.Concat(_model.ReferencedModels.SelectMany((IReferencedModel rm) => rm.Model.Instances)).GetEnumerator();
	}
}
