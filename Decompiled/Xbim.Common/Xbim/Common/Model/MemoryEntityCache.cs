using System;
using System.Linq;

namespace Xbim.Common.Model;

internal class MemoryEntityCache : IEntityCache, IDisposable
{
	private StepModel _model;

	public int Size => _model.Instances.Count();

	public bool IsActive => true;

	public MemoryEntityCache(StepModel model)
	{
		_model = model;
	}

	public void Clear()
	{
	}

	public void Dispose()
	{
		if (_model != null)
		{
			_model.EntityCacheReference = null;
			_model = null;
		}
	}

	public void Start()
	{
	}

	public void Stop()
	{
	}
}
