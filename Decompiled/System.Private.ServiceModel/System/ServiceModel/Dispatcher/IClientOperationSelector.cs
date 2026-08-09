using System.Reflection;

namespace System.ServiceModel.Dispatcher;

public interface IClientOperationSelector
{
	bool AreParametersRequiredForSelection { get; }

	string SelectOperation(MethodBase method, object[] parameters);
}
