// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerObjectIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;
using System.Threading;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerObjectIdentifier : Asn1Object
{
  private const long LongLimit = 72057594037927808;
  private static readonly DerObjectIdentifier[] Cache = new DerObjectIdentifier[1024 /*0x0400*/];
  private readonly string identifier;
  private byte[] contents;

  public static DerObjectIdentifier FromContents(byte[] contents)
  {
    return DerObjectIdentifier.CreatePrimitive(contents, true);
  }

  public static DerObjectIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerObjectIdentifier) null;
      case DerObjectIdentifier instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerObjectIdentifier asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerObjectIdentifier) DerObjectIdentifier.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct object identifier from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static DerObjectIdentifier GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    if (!declaredExplicit && !taggedObject.IsParsed())
    {
      Asn1Object asn1Object = taggedObject.GetObject();
      if (!(asn1Object is DerObjectIdentifier))
        return DerObjectIdentifier.FromContents(Asn1OctetString.GetInstance((object) asn1Object).GetOctets());
    }
    return (DerObjectIdentifier) DerObjectIdentifier.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerObjectIdentifier(string identifier)
  {
    if (identifier == null)
      throw new ArgumentNullException(nameof (identifier));
    this.identifier = DerObjectIdentifier.IsValidIdentifier(identifier) ? identifier : throw new FormatException($"string {identifier} not an OID");
  }

  private DerObjectIdentifier(DerObjectIdentifier oid, string branchID)
  {
    if (!Asn1RelativeOid.IsValidIdentifier(branchID, 0))
      throw new ArgumentException($"string {branchID} not a valid OID branch", nameof (branchID));
    this.identifier = $"{oid.Id}.{branchID}";
  }

  private DerObjectIdentifier(byte[] contents, bool clone)
  {
    this.identifier = DerObjectIdentifier.ParseContents(contents);
    this.contents = clone ? Arrays.Clone(contents) : contents;
  }

  public virtual DerObjectIdentifier Branch(string branchID)
  {
    return new DerObjectIdentifier(this, branchID);
  }

  public string Id => this.identifier;

  public virtual bool On(DerObjectIdentifier stem)
  {
    string id1 = this.Id;
    string id2 = stem.Id;
    return id1.Length > id2.Length && id1[id2.Length] == '.' && Platform.StartsWith(id1, id2);
  }

  public override string ToString() => this.identifier;

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerObjectIdentifier objectIdentifier && this.identifier == objectIdentifier.identifier;
  }

  protected override int Asn1GetHashCode() => this.identifier.GetHashCode();

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 6, this.GetContents());
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 6, this.GetContents());
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents());
  }

  private void DoOutput(MemoryStream bOut)
  {
    OidTokenizer oidTokenizer = new OidTokenizer(this.identifier);
    int num = int.Parse(oidTokenizer.NextToken()) * 40;
    string s1 = oidTokenizer.NextToken();
    if (s1.Length <= 18)
      Asn1RelativeOid.WriteField((Stream) bOut, (long) num + long.Parse(s1));
    else
      Asn1RelativeOid.WriteField((Stream) bOut, new BigInteger(s1).Add(BigInteger.ValueOf((long) num)));
    while (oidTokenizer.HasMoreTokens)
    {
      string s2 = oidTokenizer.NextToken();
      if (s2.Length <= 18)
        Asn1RelativeOid.WriteField((Stream) bOut, long.Parse(s2));
      else
        Asn1RelativeOid.WriteField((Stream) bOut, new BigInteger(s2));
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

  internal static DerObjectIdentifier CreatePrimitive(byte[] contents, bool clone)
  {
    int hashCode = Arrays.GetHashCode(contents);
    int num = hashCode ^ hashCode >> 20;
    int index = (num ^ num >> 10) & 1023 /*0x03FF*/;
    DerObjectIdentifier comparand = Volatile.Read<DerObjectIdentifier>(ref DerObjectIdentifier.Cache[index]);
    if (comparand != null && Arrays.AreEqual(contents, comparand.GetContents()))
      return comparand;
    DerObjectIdentifier objectIdentifier1 = new DerObjectIdentifier(contents, clone);
    DerObjectIdentifier objectIdentifier2 = Interlocked.CompareExchange<DerObjectIdentifier>(ref DerObjectIdentifier.Cache[index], objectIdentifier1, comparand);
    return objectIdentifier2 != comparand && objectIdentifier2 != null && Arrays.AreEqual(contents, objectIdentifier2.GetContents()) ? objectIdentifier2 : objectIdentifier1;
  }

  private static bool IsValidIdentifier(string identifier)
  {
    if (identifier.Length < 3 || identifier[1] != '.')
      return false;
    switch (identifier[0])
    {
      case '0':
      case '1':
      case '2':
        return Asn1RelativeOid.IsValidIdentifier(identifier, 2);
      default:
        return false;
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
          {
            if (num2 < 40L)
              stringBuilder.Append('0');
            else if (num2 < 80L /*0x50*/)
            {
              stringBuilder.Append('1');
              num2 -= 40L;
            }
            else
            {
              stringBuilder.Append('2');
              num2 -= 80L /*0x50*/;
            }
            flag = false;
          }
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
          {
            stringBuilder.Append('2');
            bigInteger2 = bigInteger2.Subtract(BigInteger.ValueOf(80L /*0x50*/));
            flag = false;
          }
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
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerObjectIdentifier.Meta();

    private Meta()
      : base(typeof (DerObjectIdentifier), 6)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerObjectIdentifier.CreatePrimitive(octetString.GetOctets(), false);
    }
  }
}
