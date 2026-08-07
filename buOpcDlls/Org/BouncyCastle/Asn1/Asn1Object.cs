// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Object
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Object : Asn1Encodable
{
  public override void EncodeTo(Stream output)
  {
    using (Asn1OutputStream asn1Out = Asn1OutputStream.Create(output, "BER", true))
      this.GetEncoding(asn1Out.Encoding).Encode(asn1Out);
  }

  public override void EncodeTo(Stream output, string encoding)
  {
    using (Asn1OutputStream asn1Out = Asn1OutputStream.Create(output, encoding, true))
      this.GetEncoding(asn1Out.Encoding).Encode(asn1Out);
  }

  internal virtual byte[] InternalGetEncoded(string encoding)
  {
    IAsn1Encoding encoding1 = this.GetEncoding(Asn1OutputStream.GetEncodingType(encoding));
    byte[] buffer = new byte[encoding1.GetLength()];
    using (Asn1OutputStream asn1Out = Asn1OutputStream.Create((Stream) new MemoryStream(buffer, true), encoding))
      encoding1.Encode(asn1Out);
    return buffer;
  }

  public bool Equals(Asn1Object other) => this == other || this.Asn1Equals(other);

  public static Asn1Object FromByteArray(byte[] data)
  {
    try
    {
      using (Asn1InputStream asn1InputStream = new Asn1InputStream((Stream) new MemoryStream(data, false), data.Length))
      {
        Asn1Object asn1Object = asn1InputStream.ReadObject();
        if ((long) data.Length != asn1InputStream.Position)
          throw new IOException("extra data found after object");
        return asn1Object;
      }
    }
    catch (InvalidCastException ex)
    {
      throw new IOException("cannot recognise object in byte array");
    }
  }

  public static Asn1Object FromStream(Stream inStr)
  {
    try
    {
      using (Asn1InputStream asn1InputStream = new Asn1InputStream(inStr, int.MaxValue, true))
        return asn1InputStream.ReadObject();
    }
    catch (InvalidCastException ex)
    {
      throw new IOException("cannot recognise object in stream");
    }
  }

  public sealed override Asn1Object ToAsn1Object() => this;

  internal abstract IAsn1Encoding GetEncoding(int encoding);

  internal abstract IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo);

  internal abstract DerEncoding GetEncodingDer();

  internal abstract DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo);

  protected abstract bool Asn1Equals(Asn1Object asn1Object);

  protected abstract int Asn1GetHashCode();

  internal bool CallAsn1Equals(Asn1Object obj) => this.Asn1Equals(obj);

  internal int CallAsn1GetHashCode() => this.Asn1GetHashCode();
}
