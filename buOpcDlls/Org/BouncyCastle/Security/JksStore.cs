// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.JksStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Date;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Security;

public class JksStore
{
  private static readonly int Magic = -17957139 /*0xFEEDFEED*/;
  private static readonly AlgorithmIdentifier JksObfuscationAlg = new AlgorithmIdentifier(new DerObjectIdentifier("1.3.6.1.4.1.42.2.17.1.1"), (Asn1Encodable) DerNull.Instance);
  private readonly Dictionary<string, JksStore.JksTrustedCertEntry> m_certificateEntries = new Dictionary<string, JksStore.JksTrustedCertEntry>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private readonly Dictionary<string, JksStore.JksKeyEntry> m_keyEntries = new Dictionary<string, JksStore.JksKeyEntry>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  public bool Probe(Stream stream)
  {
    using (BinaryReader binaryReader = new BinaryReader(stream))
    {
      try
      {
        return JksStore.Magic == BinaryReaders.ReadInt32BigEndian(binaryReader);
      }
      catch (EndOfStreamException ex)
      {
        return false;
      }
    }
  }

  public AsymmetricKeyParameter GetKey(string alias, char[] password)
  {
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    if (alias == null)
      throw new ArgumentNullException(nameof (alias));
    JksStore.JksKeyEntry jksKeyEntry;
    if (!this.m_keyEntries.TryGetValue(alias, out jksKeyEntry))
      return (AsymmetricKeyParameter) null;
    if (!JksStore.JksObfuscationAlg.Equals((object) jksKeyEntry.keyData.EncryptionAlgorithm))
      throw new IOException("unknown encryption algorithm");
    byte[] encryptedData = jksKeyEntry.keyData.GetEncryptedData();
    int count = encryptedData.Length - 40;
    IDigest digest = DigestUtilities.GetDigest("SHA-1");
    byte[] keyStream = this.CalculateKeyStream(digest, password, encryptedData, count);
    byte[] numArray = new byte[count];
    for (int index = 0; index < count; ++index)
      numArray[index] = (byte) ((uint) encryptedData[20 + index] ^ (uint) keyStream[index]);
    Array.Clear((Array) keyStream, 0, keyStream.Length);
    byte[] keyChecksum = this.GetKeyChecksum(digest, password, numArray);
    if (!Arrays.FixedTimeEquals(20, encryptedData, count + 20, keyChecksum, 0))
      throw new IOException("cannot recover key");
    return PrivateKeyFactory.CreateKey(numArray);
  }

  private byte[] GetKeyChecksum(IDigest digest, char[] password, byte[] pkcs8Key)
  {
    JksStore.AddPassword(digest, password);
    return DigestUtilities.DoFinal(digest, pkcs8Key);
  }

  private byte[] CalculateKeyStream(IDigest digest, char[] password, byte[] salt, int count)
  {
    byte[] destinationArray = new byte[count];
    byte[] numArray = Arrays.CopyOf(salt, 20);
    int length;
    for (int destinationIndex = 0; destinationIndex < count; destinationIndex += length)
    {
      JksStore.AddPassword(digest, password);
      digest.BlockUpdate(numArray, 0, numArray.Length);
      digest.DoFinal(numArray, 0);
      length = Math.Min(numArray.Length, destinationArray.Length - destinationIndex);
      Array.Copy((Array) numArray, 0, (Array) destinationArray, destinationIndex, length);
    }
    return destinationArray;
  }

  public X509Certificate[] GetCertificateChain(string alias)
  {
    JksStore.JksKeyEntry jksKeyEntry;
    return this.m_keyEntries.TryGetValue(alias, out jksKeyEntry) ? JksStore.CloneChain(jksKeyEntry.chain) : (X509Certificate[]) null;
  }

  public X509Certificate GetCertificate(string alias)
  {
    JksStore.JksTrustedCertEntry trustedCertEntry;
    if (this.m_certificateEntries.TryGetValue(alias, out trustedCertEntry))
      return trustedCertEntry.cert;
    JksStore.JksKeyEntry jksKeyEntry;
    if (!this.m_keyEntries.TryGetValue(alias, out jksKeyEntry))
      return (X509Certificate) null;
    X509Certificate[] chain = jksKeyEntry.chain;
    return chain != null && chain.Length != 0 ? chain[0] : (X509Certificate) null;
  }

  public DateTime? GetCreationDate(string alias)
  {
    JksStore.JksTrustedCertEntry trustedCertEntry;
    if (this.m_certificateEntries.TryGetValue(alias, out trustedCertEntry))
      return new DateTime?(trustedCertEntry.date);
    JksStore.JksKeyEntry jksKeyEntry;
    return this.m_keyEntries.TryGetValue(alias, out jksKeyEntry) ? new DateTime?(jksKeyEntry.date) : new DateTime?();
  }

  public void SetKeyEntry(
    string alias,
    AsymmetricKeyParameter key,
    char[] password,
    X509Certificate[] chain)
  {
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    alias = JksStore.ConvertAlias(alias);
    if (this.ContainsAlias(alias))
      throw new IOException($"alias [{alias}] already in use");
    byte[] encoded = PrivateKeyInfoFactory.CreatePrivateKeyInfo(key).GetEncoded();
    byte[] numArray = new byte[encoded.Length + 40];
    CryptoServicesRegistrar.GetSecureRandom().NextBytes(numArray, 0, 20);
    IDigest digest = DigestUtilities.GetDigest("SHA-1");
    Array.Copy((Array) this.GetKeyChecksum(digest, password, encoded), 0, (Array) numArray, 20 + encoded.Length, 20);
    byte[] keyStream = this.CalculateKeyStream(digest, password, numArray, encoded.Length);
    for (int index = 0; index != keyStream.Length; ++index)
      numArray[20 + index] = (byte) ((uint) encoded[index] ^ (uint) keyStream[index]);
    Array.Clear((Array) keyStream, 0, keyStream.Length);
    try
    {
      EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = new EncryptedPrivateKeyInfo(JksStore.JksObfuscationAlg, numArray);
      this.m_keyEntries.Add(alias, new JksStore.JksKeyEntry(DateTime.UtcNow, encryptedPrivateKeyInfo.GetEncoded(), JksStore.CloneChain(chain)));
    }
    catch (Exception ex)
    {
      throw new IOException("unable to encode encrypted private key", ex);
    }
  }

  public void SetKeyEntry(string alias, byte[] key, X509Certificate[] chain)
  {
    alias = JksStore.ConvertAlias(alias);
    if (this.ContainsAlias(alias))
      throw new IOException($"alias [{alias}] already in use");
    this.m_keyEntries.Add(alias, new JksStore.JksKeyEntry(DateTime.UtcNow, key, JksStore.CloneChain(chain)));
  }

  public void SetCertificateEntry(string alias, X509Certificate cert)
  {
    alias = JksStore.ConvertAlias(alias);
    if (this.ContainsAlias(alias))
      throw new IOException($"alias [{alias}] already in use");
    this.m_certificateEntries.Add(alias, new JksStore.JksTrustedCertEntry(DateTime.UtcNow, cert));
  }

  public void DeleteEntry(string alias)
  {
    if (this.m_keyEntries.Remove(alias))
      return;
    this.m_certificateEntries.Remove(alias);
  }

  public IEnumerable<string> Aliases
  {
    get
    {
      HashSet<string> e = new HashSet<string>((IEnumerable<string>) this.m_certificateEntries.Keys);
      e.UnionWith((IEnumerable<string>) this.m_keyEntries.Keys);
      return CollectionUtilities.Proxy<string>((IEnumerable<string>) e);
    }
  }

  public bool ContainsAlias(string alias)
  {
    return this.IsCertificateEntry(alias) || this.IsKeyEntry(alias);
  }

  public int Count => this.m_certificateEntries.Count + this.m_keyEntries.Count;

  public bool IsKeyEntry(string alias) => this.m_keyEntries.ContainsKey(alias);

  public bool IsCertificateEntry(string alias) => this.m_certificateEntries.ContainsKey(alias);

  public string GetCertificateAlias(X509Certificate cert)
  {
    foreach (KeyValuePair<string, JksStore.JksTrustedCertEntry> certificateEntry in this.m_certificateEntries)
    {
      if (certificateEntry.Value.cert.Equals((object) cert))
        return certificateEntry.Key;
    }
    return (string) null;
  }

  public void Save(Stream stream, char[] password)
  {
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    IDigest checksumDigest = JksStore.CreateChecksumDigest(password);
    this.SaveStream(stream, checksumDigest);
  }

  private void SaveStream(Stream stream, IDigest checksumDigest)
  {
    BinaryWriter binaryWriter = new BinaryWriter((Stream) new DigestStream(stream, (IDigest) null, checksumDigest));
    BinaryWriters.WriteInt32BigEndian(binaryWriter, JksStore.Magic);
    BinaryWriters.WriteInt32BigEndian(binaryWriter, 2);
    BinaryWriters.WriteInt32BigEndian(binaryWriter, this.Count);
    foreach (KeyValuePair<string, JksStore.JksKeyEntry> keyEntry in this.m_keyEntries)
    {
      string key = keyEntry.Key;
      JksStore.JksKeyEntry jksKeyEntry = keyEntry.Value;
      BinaryWriters.WriteInt32BigEndian(binaryWriter, 1);
      JksStore.WriteUtf(binaryWriter, key);
      JksStore.WriteDateTime(binaryWriter, jksKeyEntry.date);
      JksStore.WriteBufferWithInt32Length(binaryWriter, jksKeyEntry.keyData.GetEncoded());
      X509Certificate[] chain = jksKeyEntry.chain;
      int length = chain == null ? 0 : chain.Length;
      BinaryWriters.WriteInt32BigEndian(binaryWriter, length);
      for (int index = 0; index < length; ++index)
        JksStore.WriteTypedCertificate(binaryWriter, chain[index]);
    }
    foreach (KeyValuePair<string, JksStore.JksTrustedCertEntry> certificateEntry in this.m_certificateEntries)
    {
      string key = certificateEntry.Key;
      JksStore.JksTrustedCertEntry trustedCertEntry = certificateEntry.Value;
      BinaryWriters.WriteInt32BigEndian(binaryWriter, 2);
      JksStore.WriteUtf(binaryWriter, key);
      JksStore.WriteDateTime(binaryWriter, trustedCertEntry.date);
      JksStore.WriteTypedCertificate(binaryWriter, trustedCertEntry.cert);
    }
    byte[] buffer = DigestUtilities.DoFinal(checksumDigest);
    binaryWriter.Write(buffer);
    binaryWriter.Flush();
  }

  public void Load(Stream stream, char[] password)
  {
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    using (JksStore.ErasableByteStream storeStream = this.ValidateStream(stream, password))
      this.LoadStream(storeStream);
  }

  public void LoadUnchecked(Stream stream) => this.Load(stream, (char[]) null);

  private void LoadStream(JksStore.ErasableByteStream storeStream)
  {
    this.m_certificateEntries.Clear();
    this.m_keyEntries.Clear();
    BinaryReader binaryReader = new BinaryReader((Stream) storeStream);
    int num1 = BinaryReaders.ReadInt32BigEndian(binaryReader);
    int storeVersion = BinaryReaders.ReadInt32BigEndian(binaryReader);
    int magic = JksStore.Magic;
    if (num1 != magic || storeVersion != 1 && storeVersion != 2)
      throw new IOException("Invalid keystore format");
    int num2 = BinaryReaders.ReadInt32BigEndian(binaryReader);
    for (int index1 = 0; index1 < num2; ++index1)
    {
      switch (BinaryReaders.ReadInt32BigEndian(binaryReader))
      {
        case 1:
          string key = JksStore.ReadUtf(binaryReader);
          DateTime date = JksStore.ReadDateTime(binaryReader);
          byte[] keyData = JksStore.ReadBufferWithInt32Length(binaryReader);
          int val2 = BinaryReaders.ReadInt32BigEndian(binaryReader);
          X509Certificate[] chain = (X509Certificate[]) null;
          if (val2 > 0)
          {
            List<X509Certificate> x509CertificateList = new List<X509Certificate>(Math.Min(10, val2));
            for (int index2 = 0; index2 != val2; ++index2)
              x509CertificateList.Add(JksStore.ReadTypedCertificate(binaryReader, storeVersion));
            chain = x509CertificateList.ToArray();
          }
          this.m_keyEntries.Add(key, new JksStore.JksKeyEntry(date, keyData, chain));
          break;
        case 2:
          this.m_certificateEntries.Add(JksStore.ReadUtf(binaryReader), new JksStore.JksTrustedCertEntry(JksStore.ReadDateTime(binaryReader), JksStore.ReadTypedCertificate(binaryReader, storeVersion)));
          break;
        default:
          throw new IOException("unable to discern entry type");
      }
    }
    if (storeStream.Position != storeStream.Length)
      throw new IOException("password incorrect or store tampered with");
  }

  private JksStore.ErasableByteStream ValidateStream(Stream inputStream, char[] password)
  {
    byte[] numArray = Streams.ReadAll(inputStream);
    int num = numArray.Length - 20;
    if (password != null && !Arrays.FixedTimeEquals(20, JksStore.CalculateChecksum(password, numArray, 0, num), 0, numArray, num))
    {
      Array.Clear((Array) numArray, 0, numArray.Length);
      throw new IOException("password incorrect or store tampered with");
    }
    return new JksStore.ErasableByteStream(numArray, 0, num);
  }

  private static void AddPassword(IDigest digest, char[] password)
  {
    for (int index = 0; index < password.Length; ++index)
    {
      digest.Update((byte) ((uint) password[index] >> 8));
      digest.Update((byte) password[index]);
    }
  }

  private static byte[] CalculateChecksum(char[] password, byte[] buffer, int offset, int length)
  {
    IDigest checksumDigest = JksStore.CreateChecksumDigest(password);
    checksumDigest.BlockUpdate(buffer, offset, length);
    return DigestUtilities.DoFinal(checksumDigest);
  }

  private static X509Certificate[] CloneChain(X509Certificate[] chain)
  {
    return (X509Certificate[]) chain?.Clone();
  }

  private static string ConvertAlias(string alias) => alias.ToLowerInvariant();

  private static IDigest CreateChecksumDigest(char[] password)
  {
    IDigest digest = DigestUtilities.GetDigest("SHA-1");
    JksStore.AddPassword(digest, password);
    byte[] bytes = Encoding.UTF8.GetBytes("Mighty Aphrodite");
    digest.BlockUpdate(bytes, 0, bytes.Length);
    return digest;
  }

  private static byte[] ReadBufferWithInt16Length(BinaryReader br)
  {
    int count = (int) BinaryReaders.ReadInt16BigEndian(br);
    return BinaryReaders.ReadBytesFully(br, count);
  }

  private static byte[] ReadBufferWithInt32Length(BinaryReader br)
  {
    int count = BinaryReaders.ReadInt32BigEndian(br);
    return BinaryReaders.ReadBytesFully(br, count);
  }

  private static DateTime ReadDateTime(BinaryReader br)
  {
    return DateTimeUtilities.UnixMsToDateTime(BinaryReaders.ReadInt64BigEndian(br));
  }

  private static X509Certificate ReadTypedCertificate(BinaryReader br, int storeVersion)
  {
    if (storeVersion == 2)
    {
      string str = JksStore.ReadUtf(br);
      if ("X.509" != str)
        throw new IOException("Unsupported certificate format: " + str);
    }
    byte[] certData = JksStore.ReadBufferWithInt32Length(br);
    try
    {
      return new X509Certificate(certData);
    }
    finally
    {
      Array.Clear((Array) certData, 0, certData.Length);
    }
  }

  private static string ReadUtf(BinaryReader br)
  {
    byte[] bytes = JksStore.ReadBufferWithInt16Length(br);
    for (int index = 0; index < bytes.Length; ++index)
    {
      byte num = bytes[index];
      if (num == (byte) 0 || ((int) num & 128 /*0x80*/) != 0)
        throw new NotSupportedException("Currently missing support for modified UTF-8 encoding in JKS");
    }
    return Encoding.UTF8.GetString(bytes);
  }

  private static void WriteBufferWithInt16Length(BinaryWriter bw, byte[] buffer)
  {
    BinaryWriters.WriteInt16BigEndian(bw, Convert.ToInt16(buffer.Length));
    bw.Write(buffer);
  }

  private static void WriteBufferWithInt32Length(BinaryWriter bw, byte[] buffer)
  {
    BinaryWriters.WriteInt32BigEndian(bw, buffer.Length);
    bw.Write(buffer);
  }

  private static void WriteDateTime(BinaryWriter bw, DateTime dateTime)
  {
    long unixMs = DateTimeUtilities.DateTimeToUnixMs(dateTime);
    BinaryWriters.WriteInt64BigEndian(bw, unixMs);
  }

  private static void WriteTypedCertificate(BinaryWriter bw, X509Certificate cert)
  {
    JksStore.WriteUtf(bw, "X.509");
    JksStore.WriteBufferWithInt32Length(bw, cert.GetEncoded());
  }

  private static void WriteUtf(BinaryWriter bw, string s)
  {
    byte[] bytes = Encoding.UTF8.GetBytes(s);
    for (int index = 0; index < bytes.Length; ++index)
    {
      byte num = bytes[index];
      if (num == (byte) 0 || ((int) num & 128 /*0x80*/) != 0)
        throw new NotSupportedException("Currently missing support for modified UTF-8 encoding in JKS");
    }
    JksStore.WriteBufferWithInt16Length(bw, bytes);
  }

  private sealed class JksTrustedCertEntry
  {
    internal readonly DateTime date;
    internal readonly X509Certificate cert;

    internal JksTrustedCertEntry(DateTime date, X509Certificate cert)
    {
      this.date = date;
      this.cert = cert;
    }
  }

  private sealed class JksKeyEntry
  {
    internal readonly DateTime date;
    internal readonly EncryptedPrivateKeyInfo keyData;
    internal readonly X509Certificate[] chain;

    internal JksKeyEntry(DateTime date, byte[] keyData, X509Certificate[] chain)
    {
      this.date = date;
      this.keyData = EncryptedPrivateKeyInfo.GetInstance((object) Asn1Sequence.GetInstance((object) keyData));
      this.chain = chain;
    }
  }

  private sealed class ErasableByteStream : MemoryStream
  {
    internal ErasableByteStream(byte[] buffer, int index, int count)
      : base(buffer, index, count, false, true)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.Position = 0L;
        byte[] buffer = this.GetBuffer();
        Array.Clear((Array) buffer, 0, buffer.Length);
      }
      base.Dispose(disposing);
    }
  }
}
