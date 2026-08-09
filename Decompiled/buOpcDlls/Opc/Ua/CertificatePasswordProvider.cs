using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class CertificatePasswordProvider : ICertificatePasswordProvider
{
	private string m_password;

	public CertificatePasswordProvider(string password)
	{
		m_password = password;
	}

	public string GetPassword(CertificateIdentifier certificateIdentifier)
	{
		return m_password;
	}
}
