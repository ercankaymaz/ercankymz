using System.IdentityModel;
using System.Xml;

namespace System.ServiceModel.Security;

internal class SignatureConfirmationElement : ISignatureValueSecurityElement, ISecurityElement
{
	private SecurityVersion _version;

	private byte[] _signatureValue;

	public bool HasId => true;

	public string Id { get; }

	public SignatureConfirmationElement(string id, byte[] signatureValue, SecurityVersion version)
	{
		Id = id ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("id");
		_signatureValue = signatureValue ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("signatureValue");
		_version = version;
	}

	public byte[] GetSignatureValue()
	{
		return _signatureValue;
	}

	public void WriteTo(XmlDictionaryWriter writer, DictionaryManager dictionaryManager)
	{
		_version.WriteSignatureConfirmation(writer, Id, _signatureValue);
	}
}
