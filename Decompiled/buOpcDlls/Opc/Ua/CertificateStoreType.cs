using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class CertificateStoreType
{
	public const string X509Store = "X509Store";

	public const string Directory = "Directory";

	private static readonly Dictionary<string, ICertificateStoreType> s_registeredStoreTypes;

	public static IReadOnlyCollection<string> RegisteredStoreTypeNames => s_registeredStoreTypes.Keys;

	static CertificateStoreType()
	{
		s_registeredStoreTypes = new Dictionary<string, ICertificateStoreType>();
	}

	public static void RegisterCertificateStoreType(string storeTypeName, ICertificateStoreType storeType)
	{
		s_registeredStoreTypes.Add(storeTypeName, storeType);
	}

	public static ICertificateStoreType GetCertificateStoreTypeByName(string storeTypeName)
	{
		s_registeredStoreTypes.TryGetValue(storeTypeName, out var value);
		return value;
	}
}
