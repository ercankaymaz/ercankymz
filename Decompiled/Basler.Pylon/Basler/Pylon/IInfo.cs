using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IInfo : IEnumerable<KeyValuePair<string, string>>
{
	string this[string key] { get; }

	[return: MarshalAs(UnmanagedType.U1)]
	bool ContainsKey(string key);

	string GetValueOrDefault(string key, string defaultValue);
}
