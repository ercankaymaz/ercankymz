// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsProtocol
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class DtlsProtocol
{
  internal DtlsProtocol()
  {
  }

  internal virtual void ProcessFinished(byte[] body, byte[] expected_verify_data)
  {
    MemoryStream memoryStream = new MemoryStream(body, false);
    byte[] b = TlsUtilities.ReadFully(expected_verify_data.Length, (Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    if (!Arrays.FixedTimeEquals(expected_verify_data, b))
      throw new TlsFatalAlert((short) 40);
  }

  internal static void ApplyMaxFragmentLengthExtension(
    DtlsRecordLayer recordLayer,
    short maxFragmentLength)
  {
    if (maxFragmentLength < (short) 0)
      return;
    if (!MaxFragmentLength.IsValid(maxFragmentLength))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    int plaintextLimit = 1 << 8 + (int) maxFragmentLength;
    recordLayer.SetPlaintextLimit(plaintextLimit);
  }

  internal static short EvaluateMaxFragmentLengthExtension(
    bool resumedSession,
    IDictionary<int, byte[]> clientExtensions,
    IDictionary<int, byte[]> serverExtensions,
    short alertDescription)
  {
    short fragmentLengthExtension = TlsExtensionsUtilities.GetMaxFragmentLengthExtension(serverExtensions);
    if (fragmentLengthExtension >= (short) 0 && (!MaxFragmentLength.IsValid(fragmentLengthExtension) || !resumedSession && (int) fragmentLengthExtension != (int) TlsExtensionsUtilities.GetMaxFragmentLengthExtension(clientExtensions)))
      throw new TlsFatalAlert(alertDescription);
    return fragmentLengthExtension;
  }

  internal static byte[] GenerateCertificate(
    TlsContext context,
    Certificate certificate,
    Stream endPointHash)
  {
    MemoryStream messageOutput = new MemoryStream();
    certificate.Encode(context, (Stream) messageOutput, endPointHash);
    return messageOutput.ToArray();
  }

  internal static byte[] GenerateSupplementalData(IList<SupplementalDataEntry> supplementalData)
  {
    MemoryStream output = new MemoryStream();
    TlsProtocol.WriteSupplementalData((Stream) output, supplementalData);
    return output.ToArray();
  }

  internal static void SendCertificateMessage(
    TlsContext context,
    DtlsReliableHandshake handshake,
    Certificate certificate,
    Stream endPointHash)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    if (securityParameters.LocalCertificate != null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (certificate == null)
      certificate = Certificate.EmptyChain;
    byte[] certificate1 = DtlsProtocol.GenerateCertificate(context, certificate, endPointHash);
    handshake.SendMessage((short) 11, certificate1);
    securityParameters.m_localCertificate = certificate;
  }

  internal static int ValidateSelectedCipherSuite(int selectedCipherSuite, short alertDescription)
  {
    switch (TlsUtilities.GetEncryptionAlgorithm(selectedCipherSuite))
    {
      case -1:
      case 1:
      case 2:
        throw new TlsFatalAlert(alertDescription);
      default:
        return selectedCipherSuite;
    }
  }
}
