// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.PEMReader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class PEMReader
{
  public static RSA ImportPrivateKeyFromPEM(byte[] pemDataBlob, string password = null)
  {
    RSA rsa = (RSA) null;
    using (StreamReader reader = new StreamReader((Stream) new MemoryStream(pemDataBlob), Encoding.UTF8, true))
    {
      PemReader pemReader;
      if (string.IsNullOrEmpty(password))
      {
        pemReader = new PemReader((TextReader) reader);
      }
      else
      {
        PEMReader.Password pFinder = new PEMReader.Password(password.ToCharArray());
        pemReader = new PemReader((TextReader) reader, (IPasswordFinder) pFinder);
      }
      try
      {
        for (object obj = pemReader.ReadObject(); obj != null; obj = pemReader.ReadObject())
        {
          RsaPrivateCrtKeyParameters privKey = (RsaPrivateCrtKeyParameters) null;
          if (obj is AsymmetricCipherKeyPair asymmetricCipherKeyPair)
            privKey = asymmetricCipherKeyPair.Private as RsaPrivateCrtKeyParameters;
          if (privKey == null)
            privKey = obj as RsaPrivateCrtKeyParameters;
          if (privKey != null)
          {
            rsa = RSA.Create();
            rsa.ImportParameters(DotNetUtilities.ToRSAParameters(privKey));
            break;
          }
        }
      }
      finally
      {
        pemReader.Reader.Dispose();
      }
    }
    return rsa != null ? rsa : throw new CryptographicException("PEM data blob does not contain a private key.");
  }

  internal class Password : IPasswordFinder
  {
    private readonly char[] m_password;

    public Password(char[] word) => this.m_password = (char[]) word.Clone();

    public char[] GetPassword() => (char[]) this.m_password.Clone();
  }
}
