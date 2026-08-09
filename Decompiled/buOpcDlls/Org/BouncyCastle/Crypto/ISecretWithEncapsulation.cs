using System;

namespace Org.BouncyCastle.Crypto;

public interface ISecretWithEncapsulation : IDisposable
{
	byte[] GetSecret();

	byte[] GetEncapsulation();
}
