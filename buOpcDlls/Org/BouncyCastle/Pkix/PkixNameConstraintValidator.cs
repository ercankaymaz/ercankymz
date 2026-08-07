// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixNameConstraintValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Asn1.X500.Style;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixNameConstraintValidator
{
  private static readonly DerObjectIdentifier SerialNumberOid = X509Name.SerialNumber;
  private HashSet<Asn1Sequence> excludedSubtreesDN = new HashSet<Asn1Sequence>();
  private HashSet<string> excludedSubtreesDns = new HashSet<string>();
  private HashSet<string> excludedSubtreesEmail = new HashSet<string>();
  private HashSet<string> excludedSubtreesUri = new HashSet<string>();
  private HashSet<byte[]> excludedSubtreesIP = new HashSet<byte[]>();
  private HashSet<OtherName> excludedSubtreesOtherName = new HashSet<OtherName>();
  private HashSet<Asn1Sequence> permittedSubtreesDN;
  private HashSet<string> permittedSubtreesDns;
  private HashSet<string> permittedSubtreesEmail;
  private HashSet<string> permittedSubtreesUri;
  private HashSet<byte[]> permittedSubtreesIP;
  private HashSet<OtherName> permittedSubtreesOtherName;

  private static bool WithinDNSubtree(Asn1Sequence dns, Asn1Sequence subtree)
  {
    if (subtree.Count < 1 || subtree.Count > dns.Count)
      return false;
    int num = 0;
    Rdn instance1 = Rdn.GetInstance((object) subtree[0]);
    for (int index = 0; index < dns.Count; ++index)
    {
      num = index;
      Rdn instance2 = Rdn.GetInstance((object) dns[index]);
      if (IetfUtilities.RdnAreEqual(instance1, instance2))
        break;
    }
    if (subtree.Count > dns.Count - num)
      return false;
    for (int index = 0; index < subtree.Count; ++index)
    {
      Rdn instance3 = Rdn.GetInstance((object) subtree[index]);
      Rdn instance4 = Rdn.GetInstance((object) dns[num + index]);
      if (instance3.Count == 1 && instance4.Count == 1 && PkixNameConstraintValidator.SerialNumberOid.Equals((Asn1Object) instance3.GetFirst().Type) && PkixNameConstraintValidator.SerialNumberOid.Equals((Asn1Object) instance4.GetFirst().Type))
      {
        if (!Platform.StartsWith(instance4.GetFirst().Value.ToString(), instance3.GetFirst().Value.ToString()))
          return false;
      }
      else if (!IetfUtilities.RdnAreEqual(instance3, instance4))
        return false;
    }
    return true;
  }

  public void CheckExcludedDN(Asn1Sequence dn) => this.CheckExcludedDN(this.excludedSubtreesDN, dn);

  public void CheckPermittedDN(Asn1Sequence dn)
  {
    this.CheckPermittedDN(this.permittedSubtreesDN, dn);
  }

  private void CheckExcludedDN(HashSet<Asn1Sequence> excluded, Asn1Sequence directory)
  {
    if (this.IsDNConstrained(excluded, directory))
      throw new PkixNameConstraintValidatorException("Subject distinguished name is from an excluded subtree");
  }

  private void CheckPermittedDN(HashSet<Asn1Sequence> permitted, Asn1Sequence directory)
  {
    if (permitted != null && (directory.Count != 0 || permitted.Count >= 1) && !this.IsDNConstrained(permitted, directory))
      throw new PkixNameConstraintValidatorException("Subject distinguished name is not from a permitted subtree");
  }

  private bool IsDNConstrained(HashSet<Asn1Sequence> constraints, Asn1Sequence directory)
  {
    foreach (Asn1Sequence constraint in constraints)
    {
      if (PkixNameConstraintValidator.WithinDNSubtree(directory, constraint))
        return true;
    }
    return false;
  }

  private HashSet<Asn1Sequence> IntersectDN(
    HashSet<Asn1Sequence> permitted,
    HashSet<GeneralSubtree> dns)
  {
    HashSet<Asn1Sequence> asn1SequenceSet = new HashSet<Asn1Sequence>();
    foreach (GeneralSubtree dn in dns)
    {
      Asn1Sequence instance = Asn1Sequence.GetInstance((object) dn.Base.Name);
      if (permitted == null)
      {
        if (instance != null)
          asn1SequenceSet.Add(instance);
      }
      else
      {
        foreach (Asn1Sequence asn1Sequence in permitted)
        {
          if (PkixNameConstraintValidator.WithinDNSubtree(instance, asn1Sequence))
            asn1SequenceSet.Add(instance);
          else if (PkixNameConstraintValidator.WithinDNSubtree(asn1Sequence, instance))
            asn1SequenceSet.Add(asn1Sequence);
        }
      }
    }
    return asn1SequenceSet;
  }

  private HashSet<Asn1Sequence> UnionDN(HashSet<Asn1Sequence> excluded, Asn1Sequence dn)
  {
    if (excluded.Count < 1)
    {
      if (dn == null)
        return excluded;
      excluded.Add(dn);
      return excluded;
    }
    HashSet<Asn1Sequence> asn1SequenceSet = new HashSet<Asn1Sequence>();
    foreach (Asn1Sequence asn1Sequence in excluded)
    {
      if (PkixNameConstraintValidator.WithinDNSubtree(dn, asn1Sequence))
        asn1SequenceSet.Add(asn1Sequence);
      else if (PkixNameConstraintValidator.WithinDNSubtree(asn1Sequence, dn))
      {
        asn1SequenceSet.Add(dn);
      }
      else
      {
        asn1SequenceSet.Add(asn1Sequence);
        asn1SequenceSet.Add(dn);
      }
    }
    return asn1SequenceSet;
  }

  private void CheckExcludedOtherName(HashSet<OtherName> excluded, OtherName name)
  {
    if (this.IsOtherNameConstrained(excluded, name))
      throw new PkixNameConstraintValidatorException("OtherName is from an excluded subtree.");
  }

  private void CheckPermittedOtherName(HashSet<OtherName> permitted, OtherName name)
  {
    if (permitted != null && !this.IsOtherNameConstrained(permitted, name))
      throw new PkixNameConstraintValidatorException("Subject OtherName is not from a permitted subtree.");
  }

  private bool IsOtherNameConstrained(HashSet<OtherName> constraints, OtherName otherName)
  {
    foreach (OtherName constraint in constraints)
    {
      if (this.IsOtherNameConstrained(constraint, otherName))
        return true;
    }
    return false;
  }

  private bool IsOtherNameConstrained(OtherName constraint, OtherName otherName)
  {
    return constraint.Equals((object) otherName);
  }

  private HashSet<OtherName> IntersectOtherName(
    HashSet<OtherName> permitted,
    HashSet<GeneralSubtree> otherNames)
  {
    HashSet<OtherName> intersect = new HashSet<OtherName>();
    foreach (GeneralSubtree otherName in otherNames)
    {
      OtherName instance = OtherName.GetInstance((object) otherName.Base.Name);
      if (instance != null)
      {
        if (permitted == null)
        {
          intersect.Add(instance);
        }
        else
        {
          foreach (OtherName otherName2 in permitted)
            this.IntersectOtherName(instance, otherName2, intersect);
        }
      }
    }
    return intersect;
  }

  private void IntersectOtherName(
    OtherName otherName1,
    OtherName otherName2,
    HashSet<OtherName> intersect)
  {
    if (!otherName1.Equals((object) otherName2))
      return;
    intersect.Add(otherName1);
  }

  private HashSet<OtherName> UnionOtherName(HashSet<OtherName> permitted, OtherName otherName)
  {
    HashSet<OtherName> otherNameSet = permitted != null ? new HashSet<OtherName>((IEnumerable<OtherName>) permitted) : new HashSet<OtherName>();
    otherNameSet.Add(otherName);
    return otherNameSet;
  }

  private void CheckExcludedEmail(HashSet<string> excluded, string email)
  {
    if (this.IsEmailConstrained(excluded, email))
      throw new PkixNameConstraintValidatorException("Email address is from an excluded subtree.");
  }

  private void CheckPermittedEmail(HashSet<string> permitted, string email)
  {
    if (permitted != null && (email.Length != 0 || permitted.Count >= 1) && !this.IsEmailConstrained(permitted, email))
      throw new PkixNameConstraintValidatorException("Subject email address is not from a permitted subtree.");
  }

  private bool IsEmailConstrained(HashSet<string> constraints, string email)
  {
    foreach (string constraint in constraints)
    {
      if (this.IsEmailConstrained(constraint, email))
        return true;
    }
    return false;
  }

  private bool IsEmailConstrained(string constraint, string email)
  {
    string str = email.Substring(email.IndexOf('@') + 1);
    if (constraint.IndexOf('@') != -1)
    {
      if (string.Equals(email, constraint, StringComparison.OrdinalIgnoreCase))
        return true;
    }
    else if (constraint[0] != '.')
    {
      if (string.Equals(str, constraint, StringComparison.OrdinalIgnoreCase))
        return true;
    }
    else if (this.WithinDomain(str, constraint))
      return true;
    return false;
  }

  private HashSet<string> IntersectEmail(HashSet<string> permitted, HashSet<GeneralSubtree> emails)
  {
    HashSet<string> intersect = new HashSet<string>();
    foreach (GeneralSubtree email in emails)
    {
      string nameAsString = this.ExtractNameAsString(email.Base);
      if (permitted == null)
      {
        if (nameAsString != null)
          intersect.Add(nameAsString);
      }
      else
      {
        foreach (string email2 in permitted)
          this.IntersectEmail(nameAsString, email2, intersect);
      }
    }
    return intersect;
  }

  private void IntersectEmail(string email1, string email2, HashSet<string> intersect)
  {
    if (email1.IndexOf('@') != -1)
    {
      string str = email1.Substring(email1.IndexOf('@') + 1);
      if (email2.IndexOf('@') != -1)
      {
        if (!Platform.EqualsIgnoreCase(email1, email2))
          return;
        intersect.Add(email1);
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(str, email2))
          return;
        intersect.Add(email1);
      }
      else
      {
        if (!Platform.EqualsIgnoreCase(str, email2))
          return;
        intersect.Add(email1);
      }
    }
    else if (Platform.StartsWith(email1, "."))
    {
      if (email2.IndexOf('@') != -1)
      {
        if (!this.WithinDomain(email2.Substring(email1.IndexOf('@') + 1), email1))
          return;
        intersect.Add(email2);
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(email1, email2) && !Platform.EqualsIgnoreCase(email1, email2))
        {
          if (!this.WithinDomain(email2, email1))
            return;
          intersect.Add(email2);
        }
        else
          intersect.Add(email1);
      }
      else
      {
        if (!this.WithinDomain(email2, email1))
          return;
        intersect.Add(email2);
      }
    }
    else if (email2.IndexOf('@') != -1)
    {
      if (!Platform.EqualsIgnoreCase(email2.Substring(email2.IndexOf('@') + 1), email1))
        return;
      intersect.Add(email2);
    }
    else if (Platform.StartsWith(email2, "."))
    {
      if (!this.WithinDomain(email1, email2))
        return;
      intersect.Add(email1);
    }
    else
    {
      if (!Platform.EqualsIgnoreCase(email1, email2))
        return;
      intersect.Add(email1);
    }
  }

  private HashSet<string> UnionEmail(HashSet<string> excluded, string email)
  {
    if (excluded.Count < 1)
    {
      if (email == null)
        return excluded;
      excluded.Add(email);
      return excluded;
    }
    HashSet<string> union = new HashSet<string>();
    foreach (string email1 in excluded)
      this.UnionEmail(email1, email, union);
    return union;
  }

  private void UnionEmail(string email1, string email2, HashSet<string> union)
  {
    if (email1.IndexOf('@') != -1)
    {
      string str = email1.Substring(email1.IndexOf('@') + 1);
      if (email2.IndexOf('@') != -1)
      {
        if (Platform.EqualsIgnoreCase(email1, email2))
        {
          union.Add(email1);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (this.WithinDomain(str, email2))
        {
          union.Add(email2);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.EqualsIgnoreCase(str, email2))
      {
        union.Add(email2);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.StartsWith(email1, "."))
    {
      if (email2.IndexOf('@') != -1)
      {
        if (this.WithinDomain(email2.Substring(email1.IndexOf('@') + 1), email1))
        {
          union.Add(email1);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(email1, email2) && !Platform.EqualsIgnoreCase(email1, email2))
        {
          if (this.WithinDomain(email2, email1))
          {
            union.Add(email1);
          }
          else
          {
            union.Add(email1);
            union.Add(email2);
          }
        }
        else
          union.Add(email2);
      }
      else if (this.WithinDomain(email2, email1))
      {
        union.Add(email1);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (email2.IndexOf('@') != -1)
    {
      if (Platform.EqualsIgnoreCase(email2.Substring(email1.IndexOf('@') + 1), email1))
      {
        union.Add(email1);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.StartsWith(email2, "."))
    {
      if (this.WithinDomain(email1, email2))
      {
        union.Add(email2);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.EqualsIgnoreCase(email1, email2))
    {
      union.Add(email1);
    }
    else
    {
      union.Add(email1);
      union.Add(email2);
    }
  }

  private void CheckExcludedIP(HashSet<byte[]> excluded, byte[] ip)
  {
    if (this.IsIPConstrained(excluded, ip))
      throw new PkixNameConstraintValidatorException("IP is from an excluded subtree.");
  }

  private void CheckPermittedIP(HashSet<byte[]> permitted, byte[] ip)
  {
    if (permitted != null && (ip.Length != 0 || permitted.Count >= 1) && !this.IsIPConstrained(permitted, ip))
      throw new PkixNameConstraintValidatorException("IP is not from a permitted subtree.");
  }

  private bool IsIPConstrained(HashSet<byte[]> constraints, byte[] ip)
  {
    foreach (byte[] constraint in constraints)
    {
      if (this.IsIPConstrained(constraint, ip))
        return true;
    }
    return false;
  }

  private bool IsIPConstrained(byte[] constraint, byte[] ip)
  {
    int length = ip.Length;
    if (length != constraint.Length / 2)
      return false;
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) constraint, length, (Array) destinationArray, 0, length);
    byte[] a = new byte[length];
    byte[] b = new byte[length];
    for (int index = 0; index < length; ++index)
    {
      a[index] = (byte) ((uint) constraint[index] & (uint) destinationArray[index]);
      b[index] = (byte) ((uint) ip[index] & (uint) destinationArray[index]);
    }
    return Arrays.AreEqual(a, b);
  }

  private HashSet<byte[]> IntersectIP(HashSet<byte[]> permitted, HashSet<GeneralSubtree> ips)
  {
    HashSet<byte[]> numArraySet = new HashSet<byte[]>();
    foreach (GeneralSubtree ip in ips)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) ip.Base.Name).GetOctets();
      if (permitted == null)
      {
        if (octets != null)
          numArraySet.Add(octets);
      }
      else
      {
        foreach (byte[] ipWithSubmask1 in permitted)
          numArraySet.UnionWith((IEnumerable<byte[]>) this.IntersectIPRange(ipWithSubmask1, octets));
      }
    }
    return numArraySet;
  }

  private HashSet<byte[]> IntersectIPRange(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
  {
    if (ipWithSubmask1.Length != ipWithSubmask2.Length)
      return new HashSet<byte[]>();
    byte[][] ipsAndSubnetMasks = this.ExtractIPsAndSubnetMasks(ipWithSubmask1, ipWithSubmask2);
    byte[] ip1 = ipsAndSubnetMasks[0];
    byte[] numArray1 = ipsAndSubnetMasks[1];
    byte[] ip2_1 = ipsAndSubnetMasks[2];
    byte[] numArray2 = ipsAndSubnetMasks[3];
    byte[][] numArray3 = this.MinMaxIPs(ip1, numArray1, ip2_1, numArray2);
    byte[] ip2_2 = PkixNameConstraintValidator.Min(numArray3[1], numArray3[3]);
    if (PkixNameConstraintValidator.CompareTo(PkixNameConstraintValidator.Max(numArray3[0], numArray3[2]), ip2_2) == 1)
      return new HashSet<byte[]>();
    return new HashSet<byte[]>()
    {
      this.IpWithSubnetMask(PkixNameConstraintValidator.Or(numArray3[0], numArray3[2]), PkixNameConstraintValidator.Or(numArray1, numArray2))
    };
  }

  private HashSet<byte[]> UnionIP(HashSet<byte[]> excluded, byte[] ip)
  {
    if (excluded.Count < 1)
    {
      if (ip == null)
        return excluded;
      excluded.Add(ip);
      return excluded;
    }
    HashSet<byte[]> numArraySet = new HashSet<byte[]>();
    foreach (byte[] ipWithSubmask1 in excluded)
      numArraySet.UnionWith((IEnumerable<byte[]>) this.UnionIPRange(ipWithSubmask1, ip));
    return numArraySet;
  }

  private HashSet<byte[]> UnionIPRange(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
  {
    HashSet<byte[]> numArraySet = new HashSet<byte[]>();
    if (Arrays.AreEqual(ipWithSubmask1, ipWithSubmask2))
    {
      numArraySet.Add(ipWithSubmask1);
    }
    else
    {
      numArraySet.Add(ipWithSubmask1);
      numArraySet.Add(ipWithSubmask2);
    }
    return numArraySet;
  }

  private byte[] IpWithSubnetMask(byte[] ip, byte[] subnetMask)
  {
    int length = ip.Length;
    byte[] destinationArray = new byte[length * 2];
    Array.Copy((Array) ip, 0, (Array) destinationArray, 0, length);
    Array.Copy((Array) subnetMask, 0, (Array) destinationArray, length, length);
    return destinationArray;
  }

  private byte[][] ExtractIPsAndSubnetMasks(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
  {
    int length = ipWithSubmask1.Length / 2;
    byte[] destinationArray1 = new byte[length];
    byte[] destinationArray2 = new byte[length];
    Array.Copy((Array) ipWithSubmask1, 0, (Array) destinationArray1, 0, length);
    Array.Copy((Array) ipWithSubmask1, length, (Array) destinationArray2, 0, length);
    byte[] destinationArray3 = new byte[length];
    byte[] destinationArray4 = new byte[length];
    Array.Copy((Array) ipWithSubmask2, 0, (Array) destinationArray3, 0, length);
    Array.Copy((Array) ipWithSubmask2, length, (Array) destinationArray4, 0, length);
    return new byte[4][]
    {
      destinationArray1,
      destinationArray2,
      destinationArray3,
      destinationArray4
    };
  }

  private byte[][] MinMaxIPs(byte[] ip1, byte[] subnetmask1, byte[] ip2, byte[] subnetmask2)
  {
    int length = ip1.Length;
    byte[] numArray1 = new byte[length];
    byte[] numArray2 = new byte[length];
    byte[] numArray3 = new byte[length];
    byte[] numArray4 = new byte[length];
    for (int index = 0; index < length; ++index)
    {
      numArray1[index] = (byte) ((uint) ip1[index] & (uint) subnetmask1[index]);
      numArray2[index] = (byte) ((uint) ip1[index] & (uint) subnetmask1[index] | (uint) ~subnetmask1[index]);
      numArray3[index] = (byte) ((uint) ip2[index] & (uint) subnetmask2[index]);
      numArray4[index] = (byte) ((uint) ip2[index] & (uint) subnetmask2[index] | (uint) ~subnetmask2[index]);
    }
    return new byte[4][]
    {
      numArray1,
      numArray2,
      numArray3,
      numArray4
    };
  }

  private static byte[] Max(byte[] ip1, byte[] ip2)
  {
    for (int index = 0; index < ip1.Length; ++index)
    {
      if ((int) ip1[index] > (int) ip2[index])
        return ip1;
    }
    return ip2;
  }

  private static byte[] Min(byte[] ip1, byte[] ip2)
  {
    for (int index = 0; index < ip1.Length; ++index)
    {
      if ((int) ip1[index] < (int) ip2[index])
        return ip1;
    }
    return ip2;
  }

  private static int CompareTo(byte[] ip1, byte[] ip2)
  {
    if (Arrays.AreEqual(ip1, ip2))
      return 0;
    return Arrays.AreEqual(PkixNameConstraintValidator.Max(ip1, ip2), ip1) ? 1 : -1;
  }

  private static byte[] Or(byte[] ip1, byte[] ip2)
  {
    byte[] numArray = new byte[ip1.Length];
    for (int index = 0; index < ip1.Length; ++index)
      numArray[index] = (byte) ((uint) ip1[index] | (uint) ip2[index]);
    return numArray;
  }

  private void CheckExcludedDns(HashSet<string> excluded, string dns)
  {
    if (this.IsDnsConstrained(excluded, dns))
      throw new PkixNameConstraintValidatorException("DNS is from an excluded subtree.");
  }

  private void CheckPermittedDns(HashSet<string> permitted, string dns)
  {
    if (permitted != null && (dns.Length != 0 || permitted.Count >= 1) && !this.IsDnsConstrained(permitted, dns))
      throw new PkixNameConstraintValidatorException("DNS is not from a permitted subtree.");
  }

  private bool IsDnsConstrained(HashSet<string> constraints, string dns)
  {
    foreach (string constraint in constraints)
    {
      if (this.IsDnsConstrained(constraint, dns))
        return true;
    }
    return false;
  }

  private bool IsDnsConstrained(string constraint, string dns)
  {
    return this.WithinDomain(dns, constraint) || Platform.EqualsIgnoreCase(dns, constraint);
  }

  private HashSet<string> IntersectDns(HashSet<string> permitted, HashSet<GeneralSubtree> dnss)
  {
    HashSet<string> stringSet = new HashSet<string>();
    foreach (GeneralSubtree generalSubtree in dnss)
    {
      string nameAsString = this.ExtractNameAsString(generalSubtree.Base);
      if (permitted == null)
      {
        if (nameAsString != null)
          stringSet.Add(nameAsString);
      }
      else
      {
        foreach (string str in permitted)
        {
          if (this.WithinDomain(str, nameAsString))
            stringSet.Add(str);
          else if (this.WithinDomain(nameAsString, str))
            stringSet.Add(nameAsString);
        }
      }
    }
    return stringSet;
  }

  private HashSet<string> UnionDns(HashSet<string> excluded, string dns)
  {
    if (excluded.Count < 1)
    {
      if (dns == null)
        return excluded;
      excluded.Add(dns);
      return excluded;
    }
    HashSet<string> stringSet = new HashSet<string>();
    foreach (string str in excluded)
    {
      if (this.WithinDomain(str, dns))
        stringSet.Add(dns);
      else if (this.WithinDomain(dns, str))
      {
        stringSet.Add(str);
      }
      else
      {
        stringSet.Add(str);
        stringSet.Add(dns);
      }
    }
    return stringSet;
  }

  private void CheckExcludedUri(HashSet<string> excluded, string uri)
  {
    if (this.IsUriConstrained(excluded, uri))
      throw new PkixNameConstraintValidatorException("URI is from an excluded subtree.");
  }

  private void CheckPermittedUri(HashSet<string> permitted, string uri)
  {
    if (permitted != null && (uri.Length != 0 || permitted.Count >= 1) && !this.IsUriConstrained(permitted, uri))
      throw new PkixNameConstraintValidatorException("URI is not from a permitted subtree.");
  }

  private bool IsUriConstrained(HashSet<string> constraints, string uri)
  {
    foreach (string constraint in constraints)
    {
      if (this.IsUriConstrained(constraint, uri))
        return true;
    }
    return false;
  }

  private bool IsUriConstrained(string constraint, string uri)
  {
    string hostFromUrl = PkixNameConstraintValidator.ExtractHostFromURL(uri);
    return Platform.StartsWith(constraint, ".") ? this.WithinDomain(hostFromUrl, constraint) : Platform.EqualsIgnoreCase(hostFromUrl, constraint);
  }

  private HashSet<string> IntersectUri(HashSet<string> permitted, HashSet<GeneralSubtree> uris)
  {
    HashSet<string> intersect = new HashSet<string>();
    foreach (GeneralSubtree uri in uris)
    {
      string nameAsString = this.ExtractNameAsString(uri.Base);
      if (permitted == null)
      {
        if (nameAsString != null)
          intersect.Add(nameAsString);
      }
      else
      {
        foreach (string email1 in permitted)
          this.IntersectUri(email1, nameAsString, intersect);
      }
    }
    return intersect;
  }

  private void IntersectUri(string email1, string email2, HashSet<string> intersect)
  {
    if (email1.IndexOf('@') != -1)
    {
      string str = email1.Substring(email1.IndexOf('@') + 1);
      if (email2.IndexOf('@') != -1)
      {
        if (!Platform.EqualsIgnoreCase(email1, email2))
          return;
        intersect.Add(email1);
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(str, email2))
          return;
        intersect.Add(email1);
      }
      else
      {
        if (!Platform.EqualsIgnoreCase(str, email2))
          return;
        intersect.Add(email1);
      }
    }
    else if (Platform.StartsWith(email1, "."))
    {
      if (email2.IndexOf('@') != -1)
      {
        if (!this.WithinDomain(email2.Substring(email1.IndexOf('@') + 1), email1))
          return;
        intersect.Add(email2);
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(email1, email2) && !Platform.EqualsIgnoreCase(email1, email2))
        {
          if (!this.WithinDomain(email2, email1))
            return;
          intersect.Add(email2);
        }
        else
          intersect.Add(email1);
      }
      else
      {
        if (!this.WithinDomain(email2, email1))
          return;
        intersect.Add(email2);
      }
    }
    else if (email2.IndexOf('@') != -1)
    {
      if (!Platform.EqualsIgnoreCase(email2.Substring(email2.IndexOf('@') + 1), email1))
        return;
      intersect.Add(email2);
    }
    else if (Platform.StartsWith(email2, "."))
    {
      if (!this.WithinDomain(email1, email2))
        return;
      intersect.Add(email1);
    }
    else
    {
      if (!Platform.EqualsIgnoreCase(email1, email2))
        return;
      intersect.Add(email1);
    }
  }

  private HashSet<string> UnionUri(HashSet<string> excluded, string uri)
  {
    if (excluded.Count < 1)
    {
      if (uri == null)
        return excluded;
      excluded.Add(uri);
      return excluded;
    }
    HashSet<string> union = new HashSet<string>();
    foreach (string email1 in excluded)
      this.UnionUri(email1, uri, union);
    return union;
  }

  private void UnionUri(string email1, string email2, HashSet<string> union)
  {
    if (email1.IndexOf('@') != -1)
    {
      string str = email1.Substring(email1.IndexOf('@') + 1);
      if (email2.IndexOf('@') != -1)
      {
        if (Platform.EqualsIgnoreCase(email1, email2))
        {
          union.Add(email1);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (this.WithinDomain(str, email2))
        {
          union.Add(email2);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.EqualsIgnoreCase(str, email2))
      {
        union.Add(email2);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.StartsWith(email1, "."))
    {
      if (email2.IndexOf('@') != -1)
      {
        if (this.WithinDomain(email2.Substring(email1.IndexOf('@') + 1), email1))
        {
          union.Add(email1);
        }
        else
        {
          union.Add(email1);
          union.Add(email2);
        }
      }
      else if (Platform.StartsWith(email2, "."))
      {
        if (!this.WithinDomain(email1, email2) && !Platform.EqualsIgnoreCase(email1, email2))
        {
          if (this.WithinDomain(email2, email1))
          {
            union.Add(email1);
          }
          else
          {
            union.Add(email1);
            union.Add(email2);
          }
        }
        else
          union.Add(email2);
      }
      else if (this.WithinDomain(email2, email1))
      {
        union.Add(email1);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (email2.IndexOf('@') != -1)
    {
      if (Platform.EqualsIgnoreCase(email2.Substring(email1.IndexOf('@') + 1), email1))
      {
        union.Add(email1);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.StartsWith(email2, "."))
    {
      if (this.WithinDomain(email1, email2))
      {
        union.Add(email2);
      }
      else
      {
        union.Add(email1);
        union.Add(email2);
      }
    }
    else if (Platform.EqualsIgnoreCase(email1, email2))
    {
      union.Add(email1);
    }
    else
    {
      union.Add(email1);
      union.Add(email2);
    }
  }

  private static string ExtractHostFromURL(string url)
  {
    string source = url.Substring(url.IndexOf(':') + 1);
    int num = Platform.IndexOf(source, "//");
    if (num != -1)
      source = source.Substring(num + 2);
    if (source.LastIndexOf(':') != -1)
      source = source.Substring(0, source.LastIndexOf(':'));
    string str = source.Substring(source.IndexOf(':') + 1);
    string hostFromUrl = str.Substring(str.IndexOf('@') + 1);
    if (hostFromUrl.IndexOf('/') != -1)
      hostFromUrl = hostFromUrl.Substring(0, hostFromUrl.IndexOf('/'));
    return hostFromUrl;
  }

  private bool WithinDomain(string testDomain, string domain)
  {
    string source = domain;
    if (Platform.StartsWith(source, "."))
      source = source.Substring(1);
    string[] strArray1 = source.Split('.');
    string[] strArray2 = testDomain.Split('.');
    if (strArray2.Length <= strArray1.Length)
      return false;
    int num = strArray2.Length - strArray1.Length;
    for (int index = -1; index < strArray1.Length; ++index)
    {
      if (index == -1)
      {
        if (strArray2[index + num].Length < 1)
          return false;
      }
      else if (!Platform.EqualsIgnoreCase(strArray2[index + num], strArray1[index]))
        return false;
    }
    return true;
  }

  [Obsolete("Use 'CheckPermittedName' instead")]
  public void checkPermitted(GeneralName name) => this.CheckPermittedName(name);

  public void CheckPermittedName(GeneralName name)
  {
    switch (name.TagNo)
    {
      case 0:
        this.CheckPermittedOtherName(this.permittedSubtreesOtherName, OtherName.GetInstance((object) name.Name));
        break;
      case 1:
        this.CheckPermittedEmail(this.permittedSubtreesEmail, this.ExtractNameAsString(name));
        break;
      case 2:
        this.CheckPermittedDns(this.permittedSubtreesDns, this.ExtractNameAsString(name));
        break;
      case 4:
        this.CheckPermittedDN(Asn1Sequence.GetInstance((object) name.Name.ToAsn1Object()));
        break;
      case 6:
        this.CheckPermittedUri(this.permittedSubtreesUri, this.ExtractNameAsString(name));
        break;
      case 7:
        this.CheckPermittedIP(this.permittedSubtreesIP, Asn1OctetString.GetInstance((object) name.Name).GetOctets());
        break;
    }
  }

  [Obsolete("Use 'CheckExcludedName' instead")]
  public void checkExcluded(GeneralName name) => this.CheckExcludedName(name);

  public void CheckExcludedName(GeneralName name)
  {
    switch (name.TagNo)
    {
      case 0:
        this.CheckExcludedOtherName(this.excludedSubtreesOtherName, OtherName.GetInstance((object) name.Name));
        break;
      case 1:
        this.CheckExcludedEmail(this.excludedSubtreesEmail, this.ExtractNameAsString(name));
        break;
      case 2:
        this.CheckExcludedDns(this.excludedSubtreesDns, this.ExtractNameAsString(name));
        break;
      case 4:
        this.CheckExcludedDN(Asn1Sequence.GetInstance((object) name.Name.ToAsn1Object()));
        break;
      case 6:
        this.CheckExcludedUri(this.excludedSubtreesUri, this.ExtractNameAsString(name));
        break;
      case 7:
        this.CheckExcludedIP(this.excludedSubtreesIP, Asn1OctetString.GetInstance((object) name.Name).GetOctets());
        break;
    }
  }

  public void IntersectPermittedSubtree(Asn1Sequence permitted)
  {
    Dictionary<int, HashSet<GeneralSubtree>> dictionary = new Dictionary<int, HashSet<GeneralSubtree>>();
    foreach (object obj in permitted)
    {
      GeneralSubtree instance = GeneralSubtree.GetInstance(obj);
      int tagNo = instance.Base.TagNo;
      HashSet<GeneralSubtree> generalSubtreeSet;
      if (!dictionary.TryGetValue(tagNo, out generalSubtreeSet))
      {
        generalSubtreeSet = new HashSet<GeneralSubtree>();
        dictionary[tagNo] = generalSubtreeSet;
      }
      generalSubtreeSet.Add(instance);
    }
    foreach (KeyValuePair<int, HashSet<GeneralSubtree>> keyValuePair in dictionary)
    {
      switch (keyValuePair.Key)
      {
        case 0:
          this.permittedSubtreesOtherName = this.IntersectOtherName(this.permittedSubtreesOtherName, keyValuePair.Value);
          continue;
        case 1:
          this.permittedSubtreesEmail = this.IntersectEmail(this.permittedSubtreesEmail, keyValuePair.Value);
          continue;
        case 2:
          this.permittedSubtreesDns = this.IntersectDns(this.permittedSubtreesDns, keyValuePair.Value);
          continue;
        case 4:
          this.permittedSubtreesDN = this.IntersectDN(this.permittedSubtreesDN, keyValuePair.Value);
          continue;
        case 6:
          this.permittedSubtreesUri = this.IntersectUri(this.permittedSubtreesUri, keyValuePair.Value);
          continue;
        case 7:
          this.permittedSubtreesIP = this.IntersectIP(this.permittedSubtreesIP, keyValuePair.Value);
          continue;
        default:
          continue;
      }
    }
  }

  private string ExtractNameAsString(GeneralName name)
  {
    return DerIA5String.GetInstance((object) name.Name).GetString();
  }

  public void IntersectEmptyPermittedSubtree(int nameType)
  {
    switch (nameType)
    {
      case 0:
        this.permittedSubtreesOtherName = new HashSet<OtherName>();
        break;
      case 1:
        this.permittedSubtreesEmail = new HashSet<string>();
        break;
      case 2:
        this.permittedSubtreesDns = new HashSet<string>();
        break;
      case 4:
        this.permittedSubtreesDN = new HashSet<Asn1Sequence>();
        break;
      case 6:
        this.permittedSubtreesUri = new HashSet<string>();
        break;
      case 7:
        this.permittedSubtreesIP = new HashSet<byte[]>();
        break;
    }
  }

  public void AddExcludedSubtree(GeneralSubtree subtree)
  {
    GeneralName name = subtree.Base;
    switch (name.TagNo)
    {
      case 0:
        this.excludedSubtreesOtherName = this.UnionOtherName(this.excludedSubtreesOtherName, OtherName.GetInstance((object) name.Name));
        break;
      case 1:
        this.excludedSubtreesEmail = this.UnionEmail(this.excludedSubtreesEmail, this.ExtractNameAsString(name));
        break;
      case 2:
        this.excludedSubtreesDns = this.UnionDns(this.excludedSubtreesDns, this.ExtractNameAsString(name));
        break;
      case 4:
        this.excludedSubtreesDN = this.UnionDN(this.excludedSubtreesDN, (Asn1Sequence) name.Name.ToAsn1Object());
        break;
      case 6:
        this.excludedSubtreesUri = this.UnionUri(this.excludedSubtreesUri, this.ExtractNameAsString(name));
        break;
      case 7:
        this.excludedSubtreesIP = this.UnionIP(this.excludedSubtreesIP, Asn1OctetString.GetInstance((object) name.Name).GetOctets());
        break;
    }
  }

  public override int GetHashCode()
  {
    return this.HashCollection<Asn1Sequence>(this.excludedSubtreesDN) + this.HashCollection<string>(this.excludedSubtreesDns) + this.HashCollection<string>(this.excludedSubtreesEmail) + this.HashCollection(this.excludedSubtreesIP) + this.HashCollection<string>(this.excludedSubtreesUri) + this.HashCollection<OtherName>(this.excludedSubtreesOtherName) + this.HashCollection<Asn1Sequence>(this.permittedSubtreesDN) + this.HashCollection<string>(this.permittedSubtreesDns) + this.HashCollection<string>(this.permittedSubtreesEmail) + this.HashCollection(this.permittedSubtreesIP) + this.HashCollection<string>(this.permittedSubtreesUri) + this.HashCollection<OtherName>(this.permittedSubtreesOtherName);
  }

  private int HashCollection(HashSet<byte[]> c)
  {
    int num = 0;
    if (c != null)
    {
      foreach (byte[] data in c)
        num += Arrays.GetHashCode(data);
    }
    return num;
  }

  private int HashCollection<T>(HashSet<T> c)
  {
    int num = 0;
    if (c != null)
    {
      foreach (T obj in c)
        num += obj.GetHashCode();
    }
    return num;
  }

  public override bool Equals(object o)
  {
    return o is PkixNameConstraintValidator constraintValidator && this.AreEqualSets<Asn1Sequence>(constraintValidator.excludedSubtreesDN, this.excludedSubtreesDN) && this.AreEqualSets<string>(constraintValidator.excludedSubtreesDns, this.excludedSubtreesDns) && this.AreEqualSets<string>(constraintValidator.excludedSubtreesEmail, this.excludedSubtreesEmail) && this.AreEqualSets(constraintValidator.excludedSubtreesIP, this.excludedSubtreesIP) && this.AreEqualSets<string>(constraintValidator.excludedSubtreesUri, this.excludedSubtreesUri) && this.AreEqualSets<OtherName>(constraintValidator.excludedSubtreesOtherName, this.excludedSubtreesOtherName) && this.AreEqualSets<Asn1Sequence>(constraintValidator.permittedSubtreesDN, this.permittedSubtreesDN) && this.AreEqualSets<string>(constraintValidator.permittedSubtreesDns, this.permittedSubtreesDns) && this.AreEqualSets<string>(constraintValidator.permittedSubtreesEmail, this.permittedSubtreesEmail) && this.AreEqualSets(constraintValidator.permittedSubtreesIP, this.permittedSubtreesIP) && this.AreEqualSets<string>(constraintValidator.permittedSubtreesUri, this.permittedSubtreesUri) && this.AreEqualSets<OtherName>(constraintValidator.permittedSubtreesOtherName, this.permittedSubtreesOtherName);
  }

  private bool AreEqualSets(HashSet<byte[]> set1, HashSet<byte[]> set2)
  {
    if (set1 == set2)
      return true;
    if (set1 == null || set2 == null || set1.Count != set2.Count)
      return false;
    foreach (byte[] a in set1)
    {
      bool flag = false;
      foreach (byte[] b in set2)
      {
        if (Arrays.AreEqual(a, b))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return false;
    }
    return true;
  }

  private bool AreEqualSets<T>(HashSet<T> set1, HashSet<T> set2)
  {
    if (set1 == set2)
      return true;
    if (set1 == null || set2 == null || set1.Count != set2.Count)
      return false;
    foreach (T obj in set1)
    {
      if (!set2.Contains(obj))
        return false;
    }
    return true;
  }

  private string StringifyIP(byte[] ip)
  {
    string str1 = "";
    for (int index = 0; index < ip.Length / 2; ++index)
      str1 = $"{str1}{((int) ip[index] & (int) byte.MaxValue).ToString()}.";
    string str2 = str1.Substring(0, str1.Length - 1) + "/";
    for (int index = ip.Length / 2; index < ip.Length; ++index)
      str2 = $"{str2}{((int) ip[index] & (int) byte.MaxValue).ToString()}.";
    return str2.Substring(0, str2.Length - 1);
  }

  private string StringifyIPCollection(HashSet<byte[]> ips)
  {
    string str = "" + "[";
    foreach (byte[] ip in ips)
      str = $"{str}{this.StringifyIP(ip)},";
    if (str.Length > 1)
      str = str.Substring(0, str.Length - 1);
    return str + "]";
  }

  private string StringifyOtherNameCollection(HashSet<OtherName> otherNames)
  {
    StringBuilder stringBuilder = new StringBuilder(91);
    foreach (OtherName otherName in otherNames)
    {
      if (stringBuilder.Length > 1)
        stringBuilder.Append(',');
      stringBuilder.Append(otherName.TypeID.Id);
      stringBuilder.Append(':');
      stringBuilder.Append(Hex.ToHexString(otherName.Value.GetEncoded()));
    }
    stringBuilder.Append(']');
    return stringBuilder.ToString();
  }

  public override string ToString()
  {
    StringBuilder sb = new StringBuilder("permitted:");
    sb.AppendLine();
    if (this.permittedSubtreesDN != null)
      PkixNameConstraintValidator.Append(sb, "DN", (object) this.permittedSubtreesDN);
    if (this.permittedSubtreesDns != null)
      PkixNameConstraintValidator.Append(sb, "DNS", (object) this.permittedSubtreesDns);
    if (this.permittedSubtreesEmail != null)
      PkixNameConstraintValidator.Append(sb, "Email", (object) this.permittedSubtreesEmail);
    if (this.permittedSubtreesUri != null)
      PkixNameConstraintValidator.Append(sb, "URI", (object) this.permittedSubtreesUri);
    if (this.permittedSubtreesIP != null)
      PkixNameConstraintValidator.Append(sb, "IP", (object) this.StringifyIPCollection(this.permittedSubtreesIP));
    if (this.permittedSubtreesOtherName != null)
      PkixNameConstraintValidator.Append(sb, "OtherName", (object) this.StringifyOtherNameCollection(this.permittedSubtreesOtherName));
    sb.AppendLine("excluded:");
    if (this.excludedSubtreesDN.Count > 0)
      PkixNameConstraintValidator.Append(sb, "DN", (object) this.excludedSubtreesDN);
    if (this.excludedSubtreesDns.Count > 0)
      PkixNameConstraintValidator.Append(sb, "DNS", (object) this.excludedSubtreesDns);
    if (this.excludedSubtreesEmail.Count > 0)
      PkixNameConstraintValidator.Append(sb, "Email", (object) this.excludedSubtreesEmail);
    if (this.excludedSubtreesUri.Count > 0)
      PkixNameConstraintValidator.Append(sb, "URI", (object) this.excludedSubtreesUri);
    if (this.excludedSubtreesIP.Count > 0)
      PkixNameConstraintValidator.Append(sb, "IP", (object) this.StringifyIPCollection(this.excludedSubtreesIP));
    if (this.excludedSubtreesOtherName.Count > 0)
      PkixNameConstraintValidator.Append(sb, "OtherName", (object) this.StringifyOtherNameCollection(this.excludedSubtreesOtherName));
    return sb.ToString();
  }

  private static void Append(StringBuilder sb, string name, object value)
  {
    sb.Append(name);
    sb.AppendLine(":");
    sb.Append(value);
    sb.AppendLine();
  }
}
