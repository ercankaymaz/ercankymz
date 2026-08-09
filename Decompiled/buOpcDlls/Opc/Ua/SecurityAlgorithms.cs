using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class SecurityAlgorithms
{
	public const string HmacSha1 = "http://www.w3.org/2000/09/xmldsig#hmac-sha1";

	public const string HmacSha256 = "http://www.w3.org/2000/09/xmldsig#hmac-sha256";

	public const string RsaSha1 = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

	public const string RsaSha256 = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

	public const string RsaPssSha256 = "http://opcfoundation.org/UA/security/rsa-pss-sha2-256";

	public const string Aes128 = "http://www.w3.org/2001/04/xmlenc#aes128-cbc";

	public const string Aes256 = "http://www.w3.org/2001/04/xmlenc#aes256-cbc";

	public const string RsaOaep = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";

	public const string RsaOaepSha256 = "http://opcfoundation.org/UA/security/rsa-oaep-sha2-256";

	public const string Rsa15 = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";

	public const string Rsa15Sha256 = "http://www.w3.org/2001/04/xmlenc#rsa-1_5-sha2-256";

	public const string KwRsaOaep = "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p";

	public const string KwRsa15 = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";

	public const string PSha1 = "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1";

	public const string PSha256 = "http://opcfoundation.org/ua/security/p_sha2-256";
}
