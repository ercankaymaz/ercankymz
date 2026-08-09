using System;
using System.ComponentModel;

namespace DevAge.ComponentModel;

public class EmptyTypeDescriptorContext : IServiceProvider, ITypeDescriptorContext
{
	public static readonly EmptyTypeDescriptorContext Empty;

	private EmptyContainer emptyContainer_0 = new EmptyContainer();

	public IContainer Container => emptyContainer_0;

	public object Instance => null;

	public PropertyDescriptor PropertyDescriptor => null;

	public void OnComponentChanged()
	{
	}

	public bool OnComponentChanging()
	{
		return true;
	}

	public object GetService(Type serviceType)
	{
		return null;
	}
}
