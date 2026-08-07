// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.RevocationReason
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class RevocationReason : SignatureSubpacket
{
  public RevocationReason(bool isCritical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.RevocationReason, isCritical, isLongLength, data)
  {
  }

  public RevocationReason(bool isCritical, RevocationReasonTag reason, string description)
    : base(SignatureSubpacketTag.RevocationReason, isCritical, false, RevocationReason.CreateData(reason, description))
  {
  }

  private static byte[] CreateData(RevocationReasonTag reason, string description)
  {
    byte[] utf8ByteArray = Strings.ToUtf8ByteArray(description);
    byte[] destinationArray = new byte[1 + utf8ByteArray.Length];
    destinationArray[0] = (byte) reason;
    Array.Copy((Array) utf8ByteArray, 0, (Array) destinationArray, 1, utf8ByteArray.Length);
    return destinationArray;
  }

  public virtual RevocationReasonTag GetRevocationReason()
  {
    return (RevocationReasonTag) this.GetData()[0];
  }

  public virtual string GetRevocationDescription()
  {
    byte[] data = this.GetData();
    if (data.Length == 1)
      return string.Empty;
    byte[] numArray = new byte[data.Length - 1];
    Array.Copy((Array) data, 1, (Array) numArray, 0, numArray.Length);
    return Strings.FromUtf8ByteArray(numArray);
  }
}
