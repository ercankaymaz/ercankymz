// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509Name
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509Name : Asn1Encodable
{
  public static readonly DerObjectIdentifier C = new DerObjectIdentifier("2.5.4.6");
  public static readonly DerObjectIdentifier O = new DerObjectIdentifier("2.5.4.10");
  public static readonly DerObjectIdentifier OU = new DerObjectIdentifier("2.5.4.11");
  public static readonly DerObjectIdentifier T = new DerObjectIdentifier("2.5.4.12");
  public static readonly DerObjectIdentifier CN = new DerObjectIdentifier("2.5.4.3");
  public static readonly DerObjectIdentifier Street = new DerObjectIdentifier("2.5.4.9");
  public static readonly DerObjectIdentifier SerialNumber = new DerObjectIdentifier("2.5.4.5");
  public static readonly DerObjectIdentifier L = new DerObjectIdentifier("2.5.4.7");
  public static readonly DerObjectIdentifier ST = new DerObjectIdentifier("2.5.4.8");
  public static readonly DerObjectIdentifier Surname = new DerObjectIdentifier("2.5.4.4");
  public static readonly DerObjectIdentifier GivenName = new DerObjectIdentifier("2.5.4.42");
  public static readonly DerObjectIdentifier Initials = new DerObjectIdentifier("2.5.4.43");
  public static readonly DerObjectIdentifier Generation = new DerObjectIdentifier("2.5.4.44");
  public static readonly DerObjectIdentifier UniqueIdentifier = new DerObjectIdentifier("2.5.4.45");
  public static readonly DerObjectIdentifier BusinessCategory = new DerObjectIdentifier("2.5.4.15");
  public static readonly DerObjectIdentifier PostalCode = new DerObjectIdentifier("2.5.4.17");
  public static readonly DerObjectIdentifier DnQualifier = new DerObjectIdentifier("2.5.4.46");
  public static readonly DerObjectIdentifier Pseudonym = new DerObjectIdentifier("2.5.4.65");
  public static readonly DerObjectIdentifier DateOfBirth = new DerObjectIdentifier("1.3.6.1.5.5.7.9.1");
  public static readonly DerObjectIdentifier PlaceOfBirth = new DerObjectIdentifier("1.3.6.1.5.5.7.9.2");
  public static readonly DerObjectIdentifier Gender = new DerObjectIdentifier("1.3.6.1.5.5.7.9.3");
  public static readonly DerObjectIdentifier CountryOfCitizenship = new DerObjectIdentifier("1.3.6.1.5.5.7.9.4");
  public static readonly DerObjectIdentifier CountryOfResidence = new DerObjectIdentifier("1.3.6.1.5.5.7.9.5");
  public static readonly DerObjectIdentifier NameAtBirth = new DerObjectIdentifier("1.3.36.8.3.14");
  public static readonly DerObjectIdentifier PostalAddress = new DerObjectIdentifier("2.5.4.16");
  public static readonly DerObjectIdentifier DmdName = new DerObjectIdentifier("2.5.4.54");
  public static readonly DerObjectIdentifier TelephoneNumber = X509ObjectIdentifiers.id_at_telephoneNumber;
  public static readonly DerObjectIdentifier OrganizationIdentifier = X509ObjectIdentifiers.id_at_organizationIdentifier;
  public static readonly DerObjectIdentifier Name = X509ObjectIdentifiers.id_at_name;
  public static readonly DerObjectIdentifier EmailAddress = PkcsObjectIdentifiers.Pkcs9AtEmailAddress;
  public static readonly DerObjectIdentifier UnstructuredName = PkcsObjectIdentifiers.Pkcs9AtUnstructuredName;
  public static readonly DerObjectIdentifier UnstructuredAddress = PkcsObjectIdentifiers.Pkcs9AtUnstructuredAddress;
  public static readonly DerObjectIdentifier E = X509Name.EmailAddress;
  public static readonly DerObjectIdentifier DC = new DerObjectIdentifier("0.9.2342.19200300.100.1.25");
  public static readonly DerObjectIdentifier UID = new DerObjectIdentifier("0.9.2342.19200300.100.1.1");
  private static readonly bool[] defaultReverse = new bool[1];
  private static readonly IDictionary<DerObjectIdentifier, string> DefaultSymbolsInternal = (IDictionary<DerObjectIdentifier, string>) new Dictionary<DerObjectIdentifier, string>();
  public static readonly IDictionary<DerObjectIdentifier, string> DefaultSymbols = CollectionUtilities.ReadOnly<DerObjectIdentifier, string>(X509Name.DefaultSymbolsInternal);
  private static readonly IDictionary<DerObjectIdentifier, string> RFC2253SymbolsInternal = (IDictionary<DerObjectIdentifier, string>) new Dictionary<DerObjectIdentifier, string>();
  public static readonly IDictionary<DerObjectIdentifier, string> RFC2253Symbols = CollectionUtilities.ReadOnly<DerObjectIdentifier, string>(X509Name.RFC2253SymbolsInternal);
  private static readonly IDictionary<DerObjectIdentifier, string> RFC1779SymbolsInternal = (IDictionary<DerObjectIdentifier, string>) new Dictionary<DerObjectIdentifier, string>();
  public static readonly IDictionary<DerObjectIdentifier, string> RFC1779Symbols = CollectionUtilities.ReadOnly<DerObjectIdentifier, string>(X509Name.RFC1779SymbolsInternal);
  private static readonly IDictionary<string, DerObjectIdentifier> DefaultLookupInternal = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  public static readonly IDictionary<string, DerObjectIdentifier> DefaultLookup = CollectionUtilities.ReadOnly<string, DerObjectIdentifier>(X509Name.DefaultLookupInternal);
  private readonly List<DerObjectIdentifier> ordering = new List<DerObjectIdentifier>();
  private readonly X509NameEntryConverter converter;
  private IList<string> values = (IList<string>) new List<string>();
  private IList<bool> added = (IList<bool>) new List<bool>();
  private Asn1Sequence seq;

  public static bool DefaultReverse
  {
    get
    {
      lock (X509Name.defaultReverse)
        return X509Name.defaultReverse[0];
    }
    set
    {
      lock (X509Name.defaultReverse)
        X509Name.defaultReverse[0] = value;
    }
  }

  static X509Name()
  {
    X509Name.DefaultSymbolsInternal.Add(X509Name.C, nameof (C));
    X509Name.DefaultSymbolsInternal.Add(X509Name.O, nameof (O));
    X509Name.DefaultSymbolsInternal.Add(X509Name.T, nameof (T));
    X509Name.DefaultSymbolsInternal.Add(X509Name.OU, nameof (OU));
    X509Name.DefaultSymbolsInternal.Add(X509Name.CN, nameof (CN));
    X509Name.DefaultSymbolsInternal.Add(X509Name.L, nameof (L));
    X509Name.DefaultSymbolsInternal.Add(X509Name.ST, nameof (ST));
    X509Name.DefaultSymbolsInternal.Add(X509Name.SerialNumber, "SERIALNUMBER");
    X509Name.DefaultSymbolsInternal.Add(X509Name.EmailAddress, nameof (E));
    X509Name.DefaultSymbolsInternal.Add(X509Name.DC, nameof (DC));
    X509Name.DefaultSymbolsInternal.Add(X509Name.UID, nameof (UID));
    X509Name.DefaultSymbolsInternal.Add(X509Name.Street, "STREET");
    X509Name.DefaultSymbolsInternal.Add(X509Name.Surname, "SURNAME");
    X509Name.DefaultSymbolsInternal.Add(X509Name.GivenName, "GIVENNAME");
    X509Name.DefaultSymbolsInternal.Add(X509Name.Initials, "INITIALS");
    X509Name.DefaultSymbolsInternal.Add(X509Name.Generation, "GENERATION");
    X509Name.DefaultSymbolsInternal.Add(X509Name.UnstructuredAddress, "unstructuredAddress");
    X509Name.DefaultSymbolsInternal.Add(X509Name.UnstructuredName, "unstructuredName");
    X509Name.DefaultSymbolsInternal.Add(X509Name.UniqueIdentifier, nameof (UniqueIdentifier));
    X509Name.DefaultSymbolsInternal.Add(X509Name.DnQualifier, "DN");
    X509Name.DefaultSymbolsInternal.Add(X509Name.Pseudonym, nameof (Pseudonym));
    X509Name.DefaultSymbolsInternal.Add(X509Name.PostalAddress, nameof (PostalAddress));
    X509Name.DefaultSymbolsInternal.Add(X509Name.NameAtBirth, nameof (NameAtBirth));
    X509Name.DefaultSymbolsInternal.Add(X509Name.CountryOfCitizenship, nameof (CountryOfCitizenship));
    X509Name.DefaultSymbolsInternal.Add(X509Name.CountryOfResidence, nameof (CountryOfResidence));
    X509Name.DefaultSymbolsInternal.Add(X509Name.Gender, nameof (Gender));
    X509Name.DefaultSymbolsInternal.Add(X509Name.PlaceOfBirth, nameof (PlaceOfBirth));
    X509Name.DefaultSymbolsInternal.Add(X509Name.DateOfBirth, nameof (DateOfBirth));
    X509Name.DefaultSymbolsInternal.Add(X509Name.PostalCode, nameof (PostalCode));
    X509Name.DefaultSymbolsInternal.Add(X509Name.BusinessCategory, nameof (BusinessCategory));
    X509Name.DefaultSymbolsInternal.Add(X509Name.TelephoneNumber, nameof (TelephoneNumber));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.C, nameof (C));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.O, nameof (O));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.OU, nameof (OU));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.CN, nameof (CN));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.L, nameof (L));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.ST, nameof (ST));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.Street, "STREET");
    X509Name.RFC2253SymbolsInternal.Add(X509Name.DC, nameof (DC));
    X509Name.RFC2253SymbolsInternal.Add(X509Name.UID, nameof (UID));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.C, nameof (C));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.O, nameof (O));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.OU, nameof (OU));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.CN, nameof (CN));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.L, nameof (L));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.ST, nameof (ST));
    X509Name.RFC1779SymbolsInternal.Add(X509Name.Street, "STREET");
    X509Name.DefaultLookupInternal.Add("c", X509Name.C);
    X509Name.DefaultLookupInternal.Add("o", X509Name.O);
    X509Name.DefaultLookupInternal.Add("t", X509Name.T);
    X509Name.DefaultLookupInternal.Add("ou", X509Name.OU);
    X509Name.DefaultLookupInternal.Add("cn", X509Name.CN);
    X509Name.DefaultLookupInternal.Add("l", X509Name.L);
    X509Name.DefaultLookupInternal.Add("st", X509Name.ST);
    X509Name.DefaultLookupInternal.Add("serialnumber", X509Name.SerialNumber);
    X509Name.DefaultLookupInternal.Add("street", X509Name.Street);
    X509Name.DefaultLookupInternal.Add("emailaddress", X509Name.E);
    X509Name.DefaultLookupInternal.Add("dc", X509Name.DC);
    X509Name.DefaultLookupInternal.Add("e", X509Name.E);
    X509Name.DefaultLookupInternal.Add("uid", X509Name.UID);
    X509Name.DefaultLookupInternal.Add("surname", X509Name.Surname);
    X509Name.DefaultLookupInternal.Add("givenname", X509Name.GivenName);
    X509Name.DefaultLookupInternal.Add("initials", X509Name.Initials);
    X509Name.DefaultLookupInternal.Add("generation", X509Name.Generation);
    X509Name.DefaultLookupInternal.Add("unstructuredaddress", X509Name.UnstructuredAddress);
    X509Name.DefaultLookupInternal.Add("unstructuredname", X509Name.UnstructuredName);
    X509Name.DefaultLookupInternal.Add("uniqueidentifier", X509Name.UniqueIdentifier);
    X509Name.DefaultLookupInternal.Add("dn", X509Name.DnQualifier);
    X509Name.DefaultLookupInternal.Add("pseudonym", X509Name.Pseudonym);
    X509Name.DefaultLookupInternal.Add("postaladdress", X509Name.PostalAddress);
    X509Name.DefaultLookupInternal.Add("nameofbirth", X509Name.NameAtBirth);
    X509Name.DefaultLookupInternal.Add("countryofcitizenship", X509Name.CountryOfCitizenship);
    X509Name.DefaultLookupInternal.Add("countryofresidence", X509Name.CountryOfResidence);
    X509Name.DefaultLookupInternal.Add("gender", X509Name.Gender);
    X509Name.DefaultLookupInternal.Add("placeofbirth", X509Name.PlaceOfBirth);
    X509Name.DefaultLookupInternal.Add("dateofbirth", X509Name.DateOfBirth);
    X509Name.DefaultLookupInternal.Add("postalcode", X509Name.PostalCode);
    X509Name.DefaultLookupInternal.Add("businesscategory", X509Name.BusinessCategory);
    X509Name.DefaultLookupInternal.Add("telephonenumber", X509Name.TelephoneNumber);
  }

  public static X509Name GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return X509Name.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static X509Name GetInstance(object obj)
  {
    if (obj is X509Name)
      return (X509Name) obj;
    return obj == null ? (X509Name) null : new X509Name(Asn1Sequence.GetInstance(obj));
  }

  protected X509Name()
  {
  }

  protected X509Name(Asn1Sequence seq)
  {
    this.seq = seq;
    foreach (Asn1Encodable asn1Encodable in seq)
    {
      Asn1Set instance1 = Asn1Set.GetInstance((object) asn1Encodable.ToAsn1Object());
      for (int index = 0; index < instance1.Count; ++index)
      {
        Asn1Sequence instance2 = Asn1Sequence.GetInstance((object) instance1[index].ToAsn1Object());
        if (instance2.Count != 2)
          throw new ArgumentException("badly sized pair");
        this.ordering.Add(DerObjectIdentifier.GetInstance((object) instance2[0].ToAsn1Object()));
        Asn1Object asn1Object = instance2[1].ToAsn1Object();
        if (asn1Object is IAsn1String && !(asn1Object is DerUniversalString))
        {
          string str = ((IAsn1String) asn1Object).GetString();
          if (str.StartsWith("#"))
            str = "\\" + str;
          this.values.Add(str);
        }
        else
          this.values.Add("#" + Hex.ToHexString(asn1Object.GetEncoded()));
        this.added.Add(index != 0);
      }
    }
  }

  public X509Name(
    IList<DerObjectIdentifier> ordering,
    IDictionary<DerObjectIdentifier, string> attributes)
    : this(ordering, attributes, (X509NameEntryConverter) new X509DefaultEntryConverter())
  {
  }

  public X509Name(
    IList<DerObjectIdentifier> ordering,
    IDictionary<DerObjectIdentifier, string> attributes,
    X509NameEntryConverter converter)
  {
    this.converter = converter;
    foreach (DerObjectIdentifier key in (IEnumerable<DerObjectIdentifier>) ordering)
    {
      string str;
      if (!attributes.TryGetValue(key, out str))
        throw new ArgumentException($"No attribute for object id - {key?.ToString()} - passed to distinguished name");
      this.ordering.Add(key);
      this.added.Add(false);
      this.values.Add(str);
    }
  }

  public X509Name(IList<DerObjectIdentifier> oids, IList<string> values)
    : this(oids, values, (X509NameEntryConverter) new X509DefaultEntryConverter())
  {
  }

  public X509Name(
    IList<DerObjectIdentifier> oids,
    IList<string> values,
    X509NameEntryConverter converter)
  {
    this.converter = converter;
    if (oids.Count != values.Count)
      throw new ArgumentException("'oids' must be same length as 'values'.");
    for (int index = 0; index < oids.Count; ++index)
    {
      this.ordering.Add(oids[index]);
      this.values.Add(values[index]);
      this.added.Add(false);
    }
  }

  public X509Name(string dirName)
    : this(X509Name.DefaultReverse, X509Name.DefaultLookup, dirName)
  {
  }

  public X509Name(string dirName, X509NameEntryConverter converter)
    : this(X509Name.DefaultReverse, X509Name.DefaultLookup, dirName, converter)
  {
  }

  public X509Name(bool reverse, string dirName)
    : this(reverse, X509Name.DefaultLookup, dirName)
  {
  }

  public X509Name(bool reverse, string dirName, X509NameEntryConverter converter)
    : this(reverse, X509Name.DefaultLookup, dirName, converter)
  {
  }

  public X509Name(bool reverse, IDictionary<string, DerObjectIdentifier> lookup, string dirName)
    : this(reverse, lookup, dirName, (X509NameEntryConverter) new X509DefaultEntryConverter())
  {
  }

  private DerObjectIdentifier DecodeOid(
    string name,
    IDictionary<string, DerObjectIdentifier> lookup)
  {
    if (name.StartsWith("OID.", StringComparison.OrdinalIgnoreCase))
      return new DerObjectIdentifier(name.Substring("OID.".Length));
    if (name[0] >= '0' && name[0] <= '9')
      return new DerObjectIdentifier(name);
    DerObjectIdentifier objectIdentifier;
    if (!lookup.TryGetValue(name, out objectIdentifier))
      throw new ArgumentException($"Unknown object id - {name} - passed to distinguished name");
    return objectIdentifier;
  }

  public X509Name(
    bool reverse,
    IDictionary<string, DerObjectIdentifier> lookup,
    string dirName,
    X509NameEntryConverter converter)
  {
    this.converter = converter;
    X509NameTokenizer x509NameTokenizer1 = new X509NameTokenizer(dirName);
    while (x509NameTokenizer1.HasMoreTokens())
    {
      string str1 = x509NameTokenizer1.NextToken();
      int length1 = str1.IndexOf('=');
      string name1 = length1 != -1 ? str1.Substring(0, length1) : throw new ArgumentException("badly formated directory string");
      string oid = str1.Substring(length1 + 1);
      DerObjectIdentifier objectIdentifier = this.DecodeOid(name1, lookup);
      if (oid.IndexOf('+') > 0)
      {
        X509NameTokenizer x509NameTokenizer2 = new X509NameTokenizer(oid, '+');
        string str2 = x509NameTokenizer2.NextToken();
        this.ordering.Add(objectIdentifier);
        this.values.Add(str2);
        this.added.Add(false);
        while (x509NameTokenizer2.HasMoreTokens())
        {
          string str3 = x509NameTokenizer2.NextToken();
          int length2 = str3.IndexOf('=');
          string name2 = str3.Substring(0, length2);
          string str4 = str3.Substring(length2 + 1);
          this.ordering.Add(this.DecodeOid(name2, lookup));
          this.values.Add(str4);
          this.added.Add(true);
        }
      }
      else
      {
        this.ordering.Add(objectIdentifier);
        this.values.Add(oid);
        this.added.Add(false);
      }
    }
    if (!reverse)
      return;
    List<DerObjectIdentifier> objectIdentifierList = new List<DerObjectIdentifier>();
    List<string> stringList = new List<string>();
    List<bool> boolList = new List<bool>();
    int num = 1;
    for (int index1 = 0; index1 < this.ordering.Count; ++index1)
    {
      if (!this.added[index1])
        num = 0;
      int index2 = num++;
      objectIdentifierList.Insert(index2, this.ordering[index1]);
      stringList.Insert(index2, this.values[index1]);
      boolList.Insert(index2, this.added[index1]);
    }
    this.ordering = objectIdentifierList;
    this.values = (IList<string>) stringList;
    this.added = (IList<bool>) boolList;
  }

  public IList<DerObjectIdentifier> GetOidList()
  {
    return (IList<DerObjectIdentifier>) new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) this.ordering);
  }

  public IList<string> GetValueList() => this.GetValueList((DerObjectIdentifier) null);

  public IList<string> GetValueList(DerObjectIdentifier oid)
  {
    List<string> valueList = new List<string>();
    for (int index = 0; index != this.values.Count; ++index)
    {
      if (oid == null || oid.Equals((Asn1Object) this.ordering[index]))
      {
        string str = this.values[index];
        if (str.StartsWith("\\#"))
          str = str.Substring(1);
        valueList.Add(str);
      }
    }
    return (IList<string>) valueList;
  }

  public override Asn1Object ToAsn1Object()
  {
    if (this.seq == null)
    {
      Asn1EncodableVector elementVector1 = new Asn1EncodableVector();
      Asn1EncodableVector elementVector2 = new Asn1EncodableVector();
      DerObjectIdentifier objectIdentifier1 = (DerObjectIdentifier) null;
      for (int index = 0; index != this.ordering.Count; ++index)
      {
        DerObjectIdentifier objectIdentifier2 = this.ordering[index];
        string str = this.values[index];
        if (objectIdentifier1 != null && !this.added[index])
        {
          elementVector1.Add((Asn1Encodable) new DerSet(elementVector2));
          elementVector2 = new Asn1EncodableVector();
        }
        elementVector2.Add((Asn1Encodable) new DerSequence((Asn1Encodable) objectIdentifier2, (Asn1Encodable) this.converter.GetConvertedValue(objectIdentifier2, str)));
        objectIdentifier1 = objectIdentifier2;
      }
      elementVector1.Add((Asn1Encodable) new DerSet(elementVector2));
      this.seq = (Asn1Sequence) new DerSequence(elementVector1);
    }
    return (Asn1Object) this.seq;
  }

  public bool Equivalent(X509Name other, bool inOrder)
  {
    if (!inOrder)
      return this.Equivalent(other);
    if (other == null)
      return false;
    if (other == this)
      return true;
    int count = this.ordering.Count;
    if (count != other.ordering.Count)
      return false;
    for (int index = 0; index < count; ++index)
    {
      if (!this.ordering[index].Equals((Asn1Object) other.ordering[index]) || !X509Name.EquivalentStrings(this.values[index], other.values[index]))
        return false;
    }
    return true;
  }

  public bool Equivalent(X509Name other)
  {
    if (other == null)
      return false;
    if (other == this)
      return true;
    int count = this.ordering.Count;
    if (count != other.ordering.Count)
      return false;
    bool[] flagArray = new bool[count];
    int num1;
    int num2;
    int num3;
    if (this.ordering[0].Equals((Asn1Object) other.ordering[0]))
    {
      num1 = 0;
      num2 = count;
      num3 = 1;
    }
    else
    {
      num1 = count - 1;
      num2 = -1;
      num3 = -1;
    }
    for (int index1 = num1; index1 != num2; index1 += num3)
    {
      bool flag = false;
      DerObjectIdentifier objectIdentifier = this.ordering[index1];
      string s1 = this.values[index1];
      for (int index2 = 0; index2 < count; ++index2)
      {
        if (!flagArray[index2])
        {
          DerObjectIdentifier other1 = other.ordering[index2];
          if (objectIdentifier.Equals((Asn1Object) other1))
          {
            string s2 = other.values[index2];
            if (X509Name.EquivalentStrings(s1, s2))
            {
              flagArray[index2] = true;
              flag = true;
              break;
            }
          }
        }
      }
      if (!flag)
        return false;
    }
    return true;
  }

  private static bool EquivalentStrings(string s1, string s2)
  {
    string str1 = X509Name.Canonicalize(s1);
    string str2 = X509Name.Canonicalize(s2);
    return str1.Equals(str2) || X509Name.StripInternalSpaces(str1).Equals(X509Name.StripInternalSpaces(str2));
  }

  private static string Canonicalize(string s)
  {
    string v = s.ToLowerInvariant().Trim();
    if (v.StartsWith("#") && X509Name.DecodeObject(v) is IAsn1String asn1String)
      v = asn1String.GetString().ToLowerInvariant().Trim();
    return v;
  }

  private static Asn1Object DecodeObject(string v)
  {
    try
    {
      return Asn1Object.FromByteArray(Hex.DecodeStrict(v, 1, v.Length - 1));
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException("unknown encoding in name: " + ex.Message, (Exception) ex);
    }
  }

  private static string StripInternalSpaces(string str)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (str.Length != 0)
    {
      char ch1 = str[0];
      stringBuilder.Append(ch1);
      for (int index = 1; index < str.Length; ++index)
      {
        char ch2 = str[index];
        if (ch1 != ' ' || ch2 != ' ')
          stringBuilder.Append(ch2);
        ch1 = ch2;
      }
    }
    return stringBuilder.ToString();
  }

  private void AppendValue(
    StringBuilder buf,
    IDictionary<DerObjectIdentifier, string> oidSymbols,
    DerObjectIdentifier oid,
    string val)
  {
    string str;
    if (oidSymbols.TryGetValue(oid, out str))
      buf.Append(str);
    else
      buf.Append(oid.Id);
    buf.Append('=');
    int length1 = buf.Length;
    buf.Append(val);
    int length2 = buf.Length;
    if (val.StartsWith("\\#"))
      length1 += 2;
    for (; length1 != length2; ++length1)
    {
      if (buf[length1] == ',' || buf[length1] == '"' || buf[length1] == '\\' || buf[length1] == '+' || buf[length1] == '=' || buf[length1] == '<' || buf[length1] == '>' || buf[length1] == ';')
      {
        buf.Insert(length1++, "\\");
        ++length2;
      }
    }
  }

  public string ToString(
    bool reverse,
    IDictionary<DerObjectIdentifier, string> oidSymbols)
  {
    List<StringBuilder> stringBuilderList = new List<StringBuilder>();
    StringBuilder buf = (StringBuilder) null;
    for (int index = 0; index < this.ordering.Count; ++index)
    {
      if (this.added[index])
      {
        buf.Append('+');
        this.AppendValue(buf, oidSymbols, this.ordering[index], this.values[index]);
      }
      else
      {
        buf = new StringBuilder();
        this.AppendValue(buf, oidSymbols, this.ordering[index], this.values[index]);
        stringBuilderList.Add(buf);
      }
    }
    if (reverse)
      stringBuilderList.Reverse();
    StringBuilder stringBuilder = new StringBuilder();
    if (stringBuilderList.Count > 0)
    {
      stringBuilder.Append(stringBuilderList[0].ToString());
      for (int index = 1; index < stringBuilderList.Count; ++index)
      {
        stringBuilder.Append(',');
        stringBuilder.Append(stringBuilderList[index].ToString());
      }
    }
    return stringBuilder.ToString();
  }

  public override string ToString()
  {
    return this.ToString(X509Name.DefaultReverse, X509Name.DefaultSymbols);
  }
}
