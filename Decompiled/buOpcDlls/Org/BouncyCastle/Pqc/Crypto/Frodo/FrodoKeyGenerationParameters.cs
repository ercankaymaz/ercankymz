using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKeyGenerationParameters : KeyGenerationParameters
{
	private FrodoParameters parameters;

	public FrodoParameters Parameters => parameters;

	public FrodoKeyGenerationParameters(SecureRandom random, FrodoParameters frodoParameters)
		: base(random, 256)
	{
		parameters = frodoParameters;
	}
}
