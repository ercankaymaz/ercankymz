namespace System.IdentityModel.Tokens;

public static class SecurityTokenTypes
{
	private const string Namespace = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens";

	private const string userName = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/UserName";

	private const string x509Certificate = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/X509Certificate";

	private const string kerberos = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Kerberos";

	private const string saml = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Saml";

	private const string rsa = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Rsa";

	internal const string SamlTokenProfile11 = "urn:oasis:names:tc:SAML:1.0:assertion";

	internal const string Saml2TokenProfile11 = "urn:oasis:names:tc:SAML:2.0:assertion";

	internal const string OasisWssSamlTokenProfile11 = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

	internal const string OasisWssSaml2TokenProfile11 = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0";

	public static string UserName => "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/UserName";

	public static string X509Certificate => "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/X509Certificate";

	public static string Kerberos => "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Kerberos";

	public static string Saml => "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Saml";

	public static string Rsa => "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/Rsa";
}
