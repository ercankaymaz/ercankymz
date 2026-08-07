// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsProcessableByteArray
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsProcessableByteArray : CmsProcessable, CmsReadable
{
  private readonly DerObjectIdentifier type;
  private readonly byte[] bytes;

  public CmsProcessableByteArray(byte[] bytes)
  {
    this.type = CmsObjectIdentifiers.Data;
    this.bytes = bytes;
  }

  public CmsProcessableByteArray(DerObjectIdentifier type, byte[] bytes)
  {
    this.bytes = bytes;
    this.type = type;
  }

  public DerObjectIdentifier Type => this.type;

  public virtual Stream GetInputStream() => (Stream) new MemoryStream(this.bytes, false);

  public virtual void Write(Stream zOut) => zOut.Write(this.bytes, 0, this.bytes.Length);
}
