using System;

namespace Xbim.IO;

public interface IModelProviderFactory
{
	IModelProvider CreateProvider();

	[Obsolete("Replaced by dependency injection. Use XbimServices.ServiceCollection.AddXbimToolkit(opt=> opt.UseModelProvider<T>() instead")]
	void Use(Func<IModelProvider> providerFn);
}
