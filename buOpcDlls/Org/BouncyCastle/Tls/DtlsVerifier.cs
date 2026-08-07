// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DtlsVerifier
{
  private readonly TlsMac m_cookieMac;
  private readonly TlsMacSink m_cookieMacSink;

  private static TlsMac CreateCookieMac(TlsCrypto crypto)
  {
    TlsHmac hmac = crypto.CreateHmac(3);
    byte[] numArray = new byte[hmac.MacLength];
    crypto.SecureRandom.NextBytes(numArray);
    hmac.SetKey(numArray, 0, numArray.Length);
    return (TlsMac) hmac;
  }

  public DtlsVerifier(TlsCrypto crypto)
  {
    this.m_cookieMac = DtlsVerifier.CreateCookieMac(crypto);
    this.m_cookieMacSink = new TlsMacSink(this.m_cookieMac);
  }

  public virtual DtlsRequest VerifyRequest(
    byte[] clientID,
    byte[] data,
    int dataOff,
    int dataLen,
    DatagramSender sender)
  {
    lock (this)
    {
      bool flag = true;
      try
      {
        this.m_cookieMac.Update(clientID, 0, clientID.Length);
        DtlsRequest dtlsRequest = DtlsReliableHandshake.ReadClientRequest(data, dataOff, dataLen, (Stream) this.m_cookieMacSink);
        if (dtlsRequest != null)
        {
          byte[] mac = this.m_cookieMac.CalculateMac();
          flag = false;
          if (Arrays.FixedTimeEquals(mac, dtlsRequest.ClientHello.Cookie))
            return dtlsRequest;
          DtlsReliableHandshake.SendHelloVerifyRequest(sender, dtlsRequest.RecordSeq, mac);
        }
      }
      catch (IOException ex)
      {
      }
      finally
      {
        if (flag)
          this.m_cookieMac.Reset();
      }
      return (DtlsRequest) null;
    }
  }
}
