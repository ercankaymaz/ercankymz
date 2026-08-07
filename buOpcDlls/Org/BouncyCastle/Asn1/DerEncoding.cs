// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal abstract class DerEncoding : IAsn1Encoding, IComparable<DerEncoding>
{
  protected internal readonly int m_tagClass;
  protected internal readonly int m_tagNo;

  protected internal DerEncoding(int tagClass, int tagNo)
  {
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
  }

  protected internal abstract int CompareLengthAndContents(DerEncoding other);

  public int CompareTo(DerEncoding other)
  {
    if (other == null)
      return 1;
    if (this.m_tagClass != other.m_tagClass)
      return this.m_tagClass - other.m_tagClass;
    return this.m_tagNo != other.m_tagNo ? this.m_tagNo - other.m_tagNo : this.CompareLengthAndContents(other);
  }

  public abstract void Encode(Asn1OutputStream asn1Out);

  public abstract int GetLength();
}
