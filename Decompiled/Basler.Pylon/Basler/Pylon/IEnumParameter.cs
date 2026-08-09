using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IEnumParameter : IParameter, IEnumerable<string>
{
	[return: MarshalAs(UnmanagedType.U1)]
	bool CanSetValue(string value);

	void SetValue(string value);

	IEnumerable<string> GetAllValues();

	string GetValue();

	IAdvancedParameterAccess GetAdvancedValueProperties(string value);
}
