// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.PolicyUrl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class PolicyUrl(bool critical, bool isLongLength, byte[] data) : SignatureSubpacket(SignatureSubpacketTag.PolicyUrl, critical, isLongLength, data)
{
  public PolicyUrl(bool critical, string url)
    : this(critical, false, Strings.ToUtf8ByteArray(url))
  {
  }

  public string Url => Strings.FromUtf8ByteArray(this.data);

  public byte[] GetRawUrl() => Arrays.Clone(this.data);
}
