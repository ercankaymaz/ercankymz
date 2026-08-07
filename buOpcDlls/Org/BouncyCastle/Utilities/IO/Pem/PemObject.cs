// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Pem.PemObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Pem;

public class PemObject : PemObjectGenerator
{
  private readonly string m_type;
  private readonly IList<PemHeader> m_headers;
  private readonly byte[] m_content;

  public PemObject(string type, byte[] content)
    : this(type, (IList<PemHeader>) new List<PemHeader>(), content)
  {
  }

  public PemObject(string type, IList<PemHeader> headers, byte[] content)
  {
    this.m_type = type;
    this.m_headers = (IList<PemHeader>) new List<PemHeader>((IEnumerable<PemHeader>) headers);
    this.m_content = content;
  }

  public string Type => this.m_type;

  public IList<PemHeader> Headers => this.m_headers;

  public byte[] Content => this.m_content;

  public PemObject Generate() => this;
}
