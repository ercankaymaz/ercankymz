using System.IdentityModel;
using System.IdentityModel.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class TokenElement : ISecurityElement
{
	private SecurityStandardsManager _standardsManager;

	public bool HasId => true;

	public string Id => Token.Id;

	public SecurityToken Token { get; }

	public TokenElement(SecurityToken token, SecurityStandardsManager standardsManager)
	{
		Token = token;
		_standardsManager = standardsManager;
	}

	public override bool Equals(object item)
	{
		if (item is TokenElement tokenElement && Token == tokenElement.Token)
		{
			return _standardsManager == tokenElement._standardsManager;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Token.GetHashCode() ^ _standardsManager.GetHashCode();
	}

	public void WriteTo(XmlDictionaryWriter writer, DictionaryManager dictionaryManager)
	{
		_standardsManager.SecurityTokenSerializer.WriteToken(writer, Token);
	}
}
