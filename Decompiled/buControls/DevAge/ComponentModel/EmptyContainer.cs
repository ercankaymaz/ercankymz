using System;
using System.ComponentModel;

namespace DevAge.ComponentModel;

public class EmptyContainer : IDisposable, IContainer
{
	public ComponentCollection Components => new ComponentCollection(null);

	public void Add(IComponent component, string name)
	{
		throw new NotImplementedException();
	}

	public void Add(IComponent component)
	{
		throw new NotImplementedException();
	}

	public void Remove(IComponent component)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
	}
}
