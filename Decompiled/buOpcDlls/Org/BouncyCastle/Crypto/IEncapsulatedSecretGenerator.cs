namespace Org.BouncyCastle.Crypto;

public interface IEncapsulatedSecretGenerator
{
	ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey);
}
