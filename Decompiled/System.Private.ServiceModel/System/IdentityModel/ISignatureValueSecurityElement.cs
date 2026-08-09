namespace System.IdentityModel;

internal interface ISignatureValueSecurityElement : ISecurityElement
{
	byte[] GetSignatureValue();
}
