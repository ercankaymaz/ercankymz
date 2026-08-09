using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509Defaults
{
	public static readonly ushort RSAKeySize = 2048;

	public static readonly ushort RSAKeySizeMin = 1024;

	public static readonly ushort RSAKeySizeMax = 4096;

	public static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;

	public static readonly ushort LifeTime = 24;

	public static readonly int SerialNumberLengthMin = 10;

	public static readonly int SerialNumberLengthMax = 20;
}
