using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class PEMReader
{
	internal class Password : IPasswordFinder
	{
		private readonly char[] m_password;

		public Password(char[] word)
		{
			m_password = (char[])word.Clone();
		}

		public char[] GetPassword()
		{
			return (char[])m_password.Clone();
		}
	}

	public static RSA ImportPrivateKeyFromPEM(byte[] pemDataBlob, string password = null)
	{
		RSA rSA = null;
		using (StreamReader reader = new StreamReader(new MemoryStream(pemDataBlob), Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
		{
			PemReader pemReader;
			if (string.IsNullOrEmpty(password))
			{
				pemReader = new PemReader(reader);
			}
			else
			{
				Password pFinder = new Password(password.ToCharArray());
				pemReader = new PemReader(reader, pFinder);
			}
			try
			{
				for (object obj = pemReader.ReadObject(); obj != null; obj = pemReader.ReadObject())
				{
					RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters = null;
					if (obj is AsymmetricCipherKeyPair asymmetricCipherKeyPair)
					{
						rsaPrivateCrtKeyParameters = asymmetricCipherKeyPair.Private as RsaPrivateCrtKeyParameters;
					}
					if (rsaPrivateCrtKeyParameters == null)
					{
						rsaPrivateCrtKeyParameters = obj as RsaPrivateCrtKeyParameters;
					}
					if (rsaPrivateCrtKeyParameters != null)
					{
						rSA = RSA.Create();
						rSA.ImportParameters(DotNetUtilities.ToRSAParameters(rsaPrivateCrtKeyParameters));
						break;
					}
				}
			}
			finally
			{
				pemReader.Reader.Dispose();
			}
		}
		if (rSA == null)
		{
			throw new CryptographicException("PEM data blob does not contain a private key.");
		}
		return rSA;
	}
}
