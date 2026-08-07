// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1RelativeOid
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1RelativeOid : Asn1Object
{
  private const long LongLimit = 72057594037927808;
  private readonly string identifier;
  private byte[] contents;

  public static Asn1RelativeOid FromContents(byte[] contents)
  {
    return Asn1RelativeOid.CreatePrimitive(contents, true);
  }

  public static Asn1RelativeOid GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1RelativeOid) null;
      case Asn1RelativeOid instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1RelativeOid asn1Object)
          return asn1Object;
        break;
      case byte[] data:
        try
        {
          return (Asn1RelativeOid) Asn1Object.FromByteArray(data);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct relative OID from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1RelativeOid GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1RelativeOid) Asn1RelativeOid.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public Asn1RelativeOid(string identifier)
  {
    if (identifier == null)
      throw new ArgumentNullException(nameof (identifier));
    this.identifier = Asn1RelativeOid.IsValidIdentifier(identifier, 0) ? identifier : throw new FormatException($"string {identifier} not a relative OID");
  }

  private Asn1RelativeOid(Asn1RelativeOid oid, string branchID)
  {
    if (!Asn1RelativeOid.IsValidIdentifier(branchID, 0))
      throw new FormatException($"string {branchID} not a valid relative OID branch");
    this.identifier = $"{oid.Id}.{branchID}";
  }

  private Asn1RelativeOid(byte[] contents, bool clone)
  {
    this.identifier = Asn1RelativeOid.ParseContents(contents);
    this.contents = clone ? Arrays.Clone(contents) : contents;
  }

  public virtual Asn1RelativeOid Branch(string branchID) => new Asn1RelativeOid(this, branchID);

  public string Id => this.identifier;

  public override string ToString() => this.identifier;

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is Asn1RelativeOid asn1RelativeOid && this.identifier == asn1RelativeOid.identifier;
  }

  protected override int Asn1GetHashCode() => this.identifier.GetHashCode();

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 13, this.GetContents());
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 13, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents());
  }

  private void DoOutput(MemoryStream bOut)
  {
    OidTokenizer oidTokenizer = new OidTokenizer(this.identifier);
    while (oidTokenizer.HasMoreTokens)
    {
      string s = oidTokenizer.NextToken();
      if (s.Length <= 18)
        Asn1RelativeOid.WriteField((Stream) bOut, long.Parse(s));
      else
        Asn1RelativeOid.WriteField((Stream) bOut, new BigInteger(s));
    }
  }

  private byte[] GetContents()
  {
    lock (this)
    {
      if (this.contents == null)
      {
        MemoryStream bOut = new MemoryStream();
        this.DoOutput(bOut);
        this.contents = bOut.ToArray();
      }
      return this.contents;
    }
  }

  internal static Asn1RelativeOid CreatePrimitive(byte[] contents, bool clone)
  {
    return new Asn1RelativeOid(contents, clone);
  }

  internal static bool IsValidIdentifier(string identifier, int from)
  {
    int num = 0;
    int length = identifier.Length;
    while (--length >= from)
    {
      char ch = identifier[length];
      if (ch == '.')
      {
        if (num == 0 || num > 1 && identifier[length + 1] == '0')
          return false;
        num = 0;
      }
      else
      {
        if ('0' > ch || ch > '9')
          return false;
        ++num;
      }
    }
    return num != 0 && (num <= 1 || identifier[length + 1] != '0');
  }

  internal static void WriteField(Stream outputStream, long fieldValue)
  {
    byte[] buffer = new byte[9];
    int offset = 8;
    buffer[8] = (byte) ((uint) (int) fieldValue & (uint) sbyte.MaxValue);
    while (fieldValue >= 128L /*0x80*/)
    {
      fieldValue >>= 7;
      buffer[--offset] = (byte) ((uint) (int) fieldValue | 128U /*0x80*/);
    }
    outputStream.Write(buffer, offset, 9 - offset);
  }

  internal static void WriteField(Stream outputStream, BigInteger fieldValue)
  {
    int length = (fieldValue.BitLength + 6) / 7;
    if (length == 0)
    {
      outputStream.WriteByte((byte) 0);
    }
    else
    {
      BigInteger bigInteger = fieldValue;
      byte[] buffer = new byte[length];
      for (int index = length - 1; index >= 0; --index)
      {
        buffer[index] = (byte) (bigInteger.IntValue | 128 /*0x80*/);
        bigInteger = bigInteger.ShiftRight(7);
      }
      buffer[length - 1] &= (byte) 127 /*0x7F*/;
      outputStream.Write(buffer, 0, buffer.Length);
    }
  }

  private static string ParseContents(byte[] contents)
  {
    StringBuilder stringBuilder = new StringBuilder();
    long num1 = 0;
    BigInteger bigInteger1 = (BigInteger) null;
    bool flag = true;
    for (int index = 0; index != contents.Length; ++index)
    {
      int content = (int) contents[index];
      if (num1 <= 72057594037927808L)
      {
        long num2 = num1 + (long) (content & (int) sbyte.MaxValue);
        if ((content & 128 /*0x80*/) == 0)
        {
          if (flag)
            flag = false;
          else
            stringBuilder.Append('.');
          stringBuilder.Append(num2);
          num1 = 0L;
        }
        else
          num1 = num2 << 7;
      }
      else
      {
        if (bigInteger1 == null)
          bigInteger1 = BigInteger.ValueOf(num1);
        BigInteger bigInteger2 = bigInteger1.Or(BigInteger.ValueOf((long) (content & (int) sbyte.MaxValue)));
        if ((content & 128 /*0x80*/) == 0)
        {
          if (flag)
            flag = false;
          else
            stringBuilder.Append('.');
          stringBuilder.Append((object) bigInteger2);
          bigInteger1 = (BigInteger) null;
          num1 = 0L;
        }
        else
          bigInteger1 = bigInteger2.ShiftLeft(7);
      }
    }
    return stringBuilder.ToString();
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1RelativeOid.Meta();

    private Meta()
      : base(typeof (Asn1RelativeOid), 13)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) Asn1RelativeOid.CreatePrimitive(octetString.GetOctets(), false);
    }
  }
}
