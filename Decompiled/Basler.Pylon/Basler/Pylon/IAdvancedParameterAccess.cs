using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IAdvancedParameterAccess
{
	[return: MarshalAs(UnmanagedType.U1)]
	bool ContainsProperty(string key);

	string GetProperty(string key);

	string GetPropertyOrDefault(string key, string defaultValue);

	void SetProperty(string key, string value);

	void Refresh();

	object GetLock();
}
