// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DerOutputStream : Asn1OutputStream
{
  internal DerOutputStream(Stream os, bool leaveOpen)
    : base(os, leaveOpen)
  {
  }

  internal override int Encoding => 2;
}
