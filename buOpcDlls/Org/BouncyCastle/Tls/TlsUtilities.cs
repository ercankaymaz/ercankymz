// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Bsi;
using Org.BouncyCastle.Asn1.Eac;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Date;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsUtilities
{
  private static readonly byte[] DowngradeTlsV11 = Hex.DecodeStrict("444F574E47524400");
  private static readonly byte[] DowngradeTlsV12 = Hex.DecodeStrict("444F574E47524401");
  private static readonly IDictionary<string, SignatureAndHashAlgorithm> CertSigAlgOids = TlsUtilities.CreateCertSigAlgOids();
  private static readonly IList<SignatureAndHashAlgorithm> DefaultSupportedSigAlgs = TlsUtilities.CreateDefaultSupportedSigAlgs();
  public static readonly byte[] EmptyBytes = new byte[0];
  public static readonly short[] EmptyShorts = new short[0];
  public static readonly int[] EmptyInts = new int[0];
  public static readonly long[] EmptyLongs = new long[0];
  public static readonly string[] EmptyStrings = new string[0];
  internal static short MinimumHashStrict = 2;
  internal static short MinimumHashPreferred = 4;

  private static void AddCertSigAlgOid(
    IDictionary<string, SignatureAndHashAlgorithm> d,
    DerObjectIdentifier oid,
    SignatureAndHashAlgorithm sigAndHash)
  {
    d[oid.Id] = sigAndHash;
  }

  private static void AddCertSigAlgOid(
    IDictionary<string, SignatureAndHashAlgorithm> d,
    DerObjectIdentifier oid,
    short hashAlgorithm,
    short signatureAlgorithm)
  {
    TlsUtilities.AddCertSigAlgOid(d, oid, SignatureAndHashAlgorithm.GetInstance(hashAlgorithm, signatureAlgorithm));
  }

  private static IDictionary<string, SignatureAndHashAlgorithm> CreateCertSigAlgOids()
  {
    Dictionary<string, SignatureAndHashAlgorithm> d = new Dictionary<string, SignatureAndHashAlgorithm>();
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, NistObjectIdentifiers.DsaWithSha224, (short) 3, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, NistObjectIdentifiers.DsaWithSha256, (short) 4, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, NistObjectIdentifiers.DsaWithSha384, (short) 5, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, NistObjectIdentifiers.DsaWithSha512, (short) 6, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, OiwObjectIdentifiers.DsaWithSha1, (short) 2, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, OiwObjectIdentifiers.Sha1WithRsa, (short) 2, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, PkcsObjectIdentifiers.Sha1WithRsaEncryption, (short) 2, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, PkcsObjectIdentifiers.Sha224WithRsaEncryption, (short) 3, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, PkcsObjectIdentifiers.Sha256WithRsaEncryption, (short) 4, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, PkcsObjectIdentifiers.Sha384WithRsaEncryption, (short) 5, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, PkcsObjectIdentifiers.Sha512WithRsaEncryption, (short) 6, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.ECDsaWithSha1, (short) 2, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.ECDsaWithSha224, (short) 3, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.ECDsaWithSha256, (short) 4, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.ECDsaWithSha384, (short) 5, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.ECDsaWithSha512, (short) 6, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, X9ObjectIdentifiers.IdDsaWithSha1, (short) 2, (short) 2);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_ECDSA_SHA_1, (short) 2, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_ECDSA_SHA_224, (short) 3, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_ECDSA_SHA_256, (short) 4, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_ECDSA_SHA_384, (short) 5, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_ECDSA_SHA_512, (short) 6, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_1, (short) 2, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_256, (short) 4, (short) 1);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, BsiObjectIdentifiers.ecdsa_plain_SHA1, (short) 2, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, BsiObjectIdentifiers.ecdsa_plain_SHA224, (short) 3, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, BsiObjectIdentifiers.ecdsa_plain_SHA256, (short) 4, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, BsiObjectIdentifiers.ecdsa_plain_SHA384, (short) 5, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, BsiObjectIdentifiers.ecdsa_plain_SHA512, (short) 6, (short) 3);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EdECObjectIdentifiers.id_Ed25519, SignatureAndHashAlgorithm.ed25519);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, EdECObjectIdentifiers.id_Ed448, SignatureAndHashAlgorithm.ed448);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256, SignatureAndHashAlgorithm.gostr34102012_256);
    TlsUtilities.AddCertSigAlgOid((IDictionary<string, SignatureAndHashAlgorithm>) d, RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512, SignatureAndHashAlgorithm.gostr34102012_512);
    return (IDictionary<string, SignatureAndHashAlgorithm>) d;
  }

  private static IList<SignatureAndHashAlgorithm> CreateDefaultSupportedSigAlgs()
  {
    return (IList<SignatureAndHashAlgorithm>) new List<SignatureAndHashAlgorithm>()
    {
      SignatureAndHashAlgorithm.ed25519,
      SignatureAndHashAlgorithm.ed448,
      SignatureAndHashAlgorithm.GetInstance((short) 4, (short) 3),
      SignatureAndHashAlgorithm.GetInstance((short) 5, (short) 3),
      SignatureAndHashAlgorithm.GetInstance((short) 6, (short) 3),
      SignatureAndHashAlgorithm.rsa_pss_rsae_sha256,
      SignatureAndHashAlgorithm.rsa_pss_rsae_sha384,
      SignatureAndHashAlgorithm.rsa_pss_rsae_sha512,
      SignatureAndHashAlgorithm.rsa_pss_pss_sha256,
      SignatureAndHashAlgorithm.rsa_pss_pss_sha384,
      SignatureAndHashAlgorithm.rsa_pss_pss_sha512,
      SignatureAndHashAlgorithm.GetInstance((short) 4, (short) 1),
      SignatureAndHashAlgorithm.GetInstance((short) 5, (short) 1),
      SignatureAndHashAlgorithm.GetInstance((short) 6, (short) 1),
      SignatureAndHashAlgorithm.GetInstance((short) 4, (short) 2),
      SignatureAndHashAlgorithm.GetInstance((short) 5, (short) 2),
      SignatureAndHashAlgorithm.GetInstance((short) 6, (short) 2),
      SignatureAndHashAlgorithm.GetInstance((short) 3, (short) 3),
      SignatureAndHashAlgorithm.GetInstance((short) 3, (short) 1),
      SignatureAndHashAlgorithm.GetInstance((short) 3, (short) 2),
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 3),
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 1),
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 2)
    };
  }

  public static void CheckUint8(short i)
  {
    if (!TlsUtilities.IsValidUint8(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint8(int i)
  {
    if (!TlsUtilities.IsValidUint8(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint8(long i)
  {
    if (!TlsUtilities.IsValidUint8(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint16(int i)
  {
    if (!TlsUtilities.IsValidUint16(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint16(long i)
  {
    if (!TlsUtilities.IsValidUint16(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint24(int i)
  {
    if (!TlsUtilities.IsValidUint24(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint24(long i)
  {
    if (!TlsUtilities.IsValidUint24(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint32(long i)
  {
    if (!TlsUtilities.IsValidUint32(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint48(long i)
  {
    if (!TlsUtilities.IsValidUint48(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static void CheckUint64(long i)
  {
    if (!TlsUtilities.IsValidUint64(i))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static bool IsValidUint8(short i) => ((int) i & (int) byte.MaxValue) == (int) i;

  public static bool IsValidUint8(int i) => (i & (int) byte.MaxValue) == i;

  public static bool IsValidUint8(long i) => (i & (long) byte.MaxValue) == i;

  public static bool IsValidUint16(int i) => (i & (int) ushort.MaxValue) == i;

  public static bool IsValidUint16(long i) => (i & (long) ushort.MaxValue) == i;

  public static bool IsValidUint24(int i) => (i & 16777215 /*0xFFFFFF*/) == i;

  public static bool IsValidUint24(long i) => (i & 16777215L /*0xFFFFFF*/) == i;

  public static bool IsValidUint32(long i) => (i & (long) uint.MaxValue) == i;

  public static bool IsValidUint48(long i) => (i & 281474976710655L /*0xFFFFFFFFFFFF*/) == i;

  public static bool IsValidUint64(long i) => true;

  public static bool IsSsl(TlsContext context) => context.ServerVersion.IsSsl;

  public static bool IsTlsV10(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv10.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV10(TlsContext context) => TlsUtilities.IsTlsV10(context.ServerVersion);

  public static bool IsTlsV11(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv11.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV11(TlsContext context) => TlsUtilities.IsTlsV11(context.ServerVersion);

  public static bool IsTlsV12(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv12.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV12(TlsContext context) => TlsUtilities.IsTlsV12(context.ServerVersion);

  public static bool IsTlsV13(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV13(TlsContext context) => TlsUtilities.IsTlsV13(context.ServerVersion);

  public static void WriteUint8(short i, Stream output) => output.WriteByte((byte) i);

  public static void WriteUint8(int i, Stream output) => output.WriteByte((byte) i);

  public static void WriteUint8(short i, byte[] buf, int offset) => buf[offset] = (byte) i;

  public static void WriteUint8(int i, byte[] buf, int offset) => buf[offset] = (byte) i;

  public static void WriteUint16(int i, Stream output)
  {
    output.WriteByte((byte) (i >> 8));
    output.WriteByte((byte) i);
  }

  public static void WriteUint16(int i, byte[] buf, int offset)
  {
    buf[offset] = (byte) (i >> 8);
    buf[offset + 1] = (byte) i;
  }

  public static void WriteUint24(int i, Stream output)
  {
    output.WriteByte((byte) (i >> 16 /*0x10*/));
    output.WriteByte((byte) (i >> 8));
    output.WriteByte((byte) i);
  }

  public static void WriteUint24(int i, byte[] buf, int offset)
  {
    buf[offset] = (byte) (i >> 16 /*0x10*/);
    buf[offset + 1] = (byte) (i >> 8);
    buf[offset + 2] = (byte) i;
  }

  public static void WriteUint32(long i, Stream output)
  {
    output.WriteByte((byte) (i >> 24));
    output.WriteByte((byte) (i >> 16 /*0x10*/));
    output.WriteByte((byte) (i >> 8));
    output.WriteByte((byte) i);
  }

  public static void WriteUint32(long i, byte[] buf, int offset)
  {
    buf[offset] = (byte) (i >> 24);
    buf[offset + 1] = (byte) (i >> 16 /*0x10*/);
    buf[offset + 2] = (byte) (i >> 8);
    buf[offset + 3] = (byte) i;
  }

  public static void WriteUint48(long i, Stream output)
  {
    output.WriteByte((byte) (i >> 40));
    output.WriteByte((byte) (i >> 32 /*0x20*/));
    output.WriteByte((byte) (i >> 24));
    output.WriteByte((byte) (i >> 16 /*0x10*/));
    output.WriteByte((byte) (i >> 8));
    output.WriteByte((byte) i);
  }

  public static void WriteUint48(long i, byte[] buf, int offset)
  {
    buf[offset] = (byte) (i >> 40);
    buf[offset + 1] = (byte) (i >> 32 /*0x20*/);
    buf[offset + 2] = (byte) (i >> 24);
    buf[offset + 3] = (byte) (i >> 16 /*0x10*/);
    buf[offset + 4] = (byte) (i >> 8);
    buf[offset + 5] = (byte) i;
  }

  public static void WriteUint64(long i, Stream output)
  {
    output.WriteByte((byte) (i >> 56));
    output.WriteByte((byte) (i >> 48 /*0x30*/));
    output.WriteByte((byte) (i >> 40));
    output.WriteByte((byte) (i >> 32 /*0x20*/));
    output.WriteByte((byte) (i >> 24));
    output.WriteByte((byte) (i >> 16 /*0x10*/));
    output.WriteByte((byte) (i >> 8));
    output.WriteByte((byte) i);
  }

  public static void WriteUint64(long i, byte[] buf, int offset)
  {
    buf[offset] = (byte) (i >> 56);
    buf[offset + 1] = (byte) (i >> 48 /*0x30*/);
    buf[offset + 2] = (byte) (i >> 40);
    buf[offset + 3] = (byte) (i >> 32 /*0x20*/);
    buf[offset + 4] = (byte) (i >> 24);
    buf[offset + 5] = (byte) (i >> 16 /*0x10*/);
    buf[offset + 6] = (byte) (i >> 8);
    buf[offset + 7] = (byte) i;
  }

  public static void WriteOpaque8(byte[] buf, Stream output)
  {
    TlsUtilities.CheckUint8(buf.Length);
    TlsUtilities.WriteUint8(buf.Length, output);
    output.Write(buf, 0, buf.Length);
  }

  public static void WriteOpaque8(byte[] data, byte[] buf, int off)
  {
    TlsUtilities.CheckUint8(data.Length);
    TlsUtilities.WriteUint8(data.Length, buf, off);
    Array.Copy((Array) data, 0, (Array) buf, off + 1, data.Length);
  }

  public static void WriteOpaque16(byte[] buf, Stream output)
  {
    TlsUtilities.CheckUint16(buf.Length);
    TlsUtilities.WriteUint16(buf.Length, output);
    output.Write(buf, 0, buf.Length);
  }

  public static void WriteOpaque16(byte[] data, byte[] buf, int off)
  {
    TlsUtilities.CheckUint16(data.Length);
    TlsUtilities.WriteUint16(data.Length, buf, off);
    Array.Copy((Array) data, 0, (Array) buf, off + 2, data.Length);
  }

  public static void WriteOpaque24(byte[] buf, Stream output)
  {
    TlsUtilities.CheckUint24(buf.Length);
    TlsUtilities.WriteUint24(buf.Length, output);
    output.Write(buf, 0, buf.Length);
  }

  public static void WriteOpaque24(byte[] data, byte[] buf, int off)
  {
    TlsUtilities.CheckUint24(data.Length);
    TlsUtilities.WriteUint24(data.Length, buf, off);
    Array.Copy((Array) data, 0, (Array) buf, off + 3, data.Length);
  }

  public static void WriteUint8Array(short[] u8s, Stream output)
  {
    for (int index = 0; index < u8s.Length; ++index)
      TlsUtilities.WriteUint8(u8s[index], output);
  }

  public static void WriteUint8Array(short[] u8s, byte[] buf, int offset)
  {
    for (int index = 0; index < u8s.Length; ++index)
    {
      TlsUtilities.WriteUint8(u8s[index], buf, offset);
      ++offset;
    }
  }

  public static void WriteUint8ArrayWithUint8Length(short[] u8s, Stream output)
  {
    TlsUtilities.CheckUint8(u8s.Length);
    TlsUtilities.WriteUint8(u8s.Length, output);
    TlsUtilities.WriteUint8Array(u8s, output);
  }

  public static void WriteUint8ArrayWithUint8Length(short[] u8s, byte[] buf, int offset)
  {
    TlsUtilities.CheckUint8(u8s.Length);
    TlsUtilities.WriteUint8(u8s.Length, buf, offset);
    TlsUtilities.WriteUint8Array(u8s, buf, offset + 1);
  }

  public static void WriteUint16Array(int[] u16s, Stream output)
  {
    for (int index = 0; index < u16s.Length; ++index)
      TlsUtilities.WriteUint16(u16s[index], output);
  }

  public static void WriteUint16Array(int[] u16s, byte[] buf, int offset)
  {
    for (int index = 0; index < u16s.Length; ++index)
    {
      TlsUtilities.WriteUint16(u16s[index], buf, offset);
      offset += 2;
    }
  }

  public static void WriteUint16ArrayWithUint8Length(int[] u16s, byte[] buf, int offset)
  {
    int i = 2 * u16s.Length;
    TlsUtilities.CheckUint8(i);
    TlsUtilities.WriteUint8(i, buf, offset);
    TlsUtilities.WriteUint16Array(u16s, buf, offset + 1);
  }

  public static void WriteUint16ArrayWithUint16Length(int[] u16s, Stream output)
  {
    int i = 2 * u16s.Length;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, output);
    TlsUtilities.WriteUint16Array(u16s, output);
  }

  public static void WriteUint16ArrayWithUint16Length(int[] u16s, byte[] buf, int offset)
  {
    int i = 2 * u16s.Length;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, buf, offset);
    TlsUtilities.WriteUint16Array(u16s, buf, offset + 2);
  }

  public static byte[] DecodeOpaque8(byte[] buf) => TlsUtilities.DecodeOpaque8(buf, 0);

  public static byte[] DecodeOpaque8(byte[] buf, int minLength)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    short num = buf.Length >= 1 ? TlsUtilities.ReadUint8(buf, 0) : throw new TlsFatalAlert((short) 50);
    if (buf.Length != (int) num + 1 || (int) num < minLength)
      throw new TlsFatalAlert((short) 50);
    return TlsUtilities.CopyOfRangeExact(buf, 1, buf.Length);
  }

  public static byte[] DecodeOpaque16(byte[] buf) => TlsUtilities.DecodeOpaque16(buf, 0);

  public static byte[] DecodeOpaque16(byte[] buf, int minLength)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    int num = buf.Length >= 2 ? TlsUtilities.ReadUint16(buf, 0) : throw new TlsFatalAlert((short) 50);
    if (buf.Length != num + 2 || num < minLength)
      throw new TlsFatalAlert((short) 50);
    return TlsUtilities.CopyOfRangeExact(buf, 2, buf.Length);
  }

  public static short DecodeUint8(byte[] buf)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    return buf.Length == 1 ? TlsUtilities.ReadUint8(buf, 0) : throw new TlsFatalAlert((short) 50);
  }

  public static short[] DecodeUint8ArrayWithUint8Length(byte[] buf)
  {
    int length = buf != null ? (int) TlsUtilities.ReadUint8(buf, 0) : throw new ArgumentNullException(nameof (buf));
    if (buf.Length != length + 1)
      throw new TlsFatalAlert((short) 50);
    short[] numArray = new short[length];
    for (int index = 0; index < length; ++index)
      numArray[index] = TlsUtilities.ReadUint8(buf, index + 1);
    return numArray;
  }

  public static int DecodeUint16(byte[] buf)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    return buf.Length == 2 ? TlsUtilities.ReadUint16(buf, 0) : throw new TlsFatalAlert((short) 50);
  }

  public static int[] DecodeUint16ArrayWithUint8Length(byte[] buf)
  {
    int num = buf != null ? (int) TlsUtilities.ReadUint8(buf, 0) : throw new ArgumentNullException(nameof (buf));
    if (buf.Length != num + 1 || (num & 1) != 0)
      throw new TlsFatalAlert((short) 50);
    int length = num / 2;
    int offset = 1;
    int[] numArray = new int[length];
    for (int index = 0; index < length; ++index)
    {
      numArray[index] = TlsUtilities.ReadUint16(buf, offset);
      offset += 2;
    }
    return numArray;
  }

  public static long DecodeUint32(byte[] buf)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    return buf.Length == 4 ? TlsUtilities.ReadUint32(buf, 0) : throw new TlsFatalAlert((short) 50);
  }

  public static byte[] EncodeOpaque8(byte[] buf)
  {
    TlsUtilities.CheckUint8(buf.Length);
    return Arrays.Prepend(buf, (byte) buf.Length);
  }

  public static byte[] EncodeOpaque16(byte[] buf)
  {
    TlsUtilities.CheckUint16(buf.Length);
    byte[] numArray = new byte[2 + buf.Length];
    TlsUtilities.WriteUint16(buf.Length, numArray, 0);
    Array.Copy((Array) buf, 0, (Array) numArray, 2, buf.Length);
    return numArray;
  }

  public static byte[] EncodeOpaque24(byte[] buf)
  {
    TlsUtilities.CheckUint24(buf.Length);
    byte[] numArray = new byte[3 + buf.Length];
    TlsUtilities.WriteUint24(buf.Length, numArray, 0);
    Array.Copy((Array) buf, 0, (Array) numArray, 3, buf.Length);
    return numArray;
  }

  public static byte[] EncodeUint8(short u8)
  {
    TlsUtilities.CheckUint8(u8);
    byte[] buf = new byte[1];
    TlsUtilities.WriteUint8(u8, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint8ArrayWithUint8Length(short[] u8s)
  {
    byte[] buf = new byte[1 + u8s.Length];
    TlsUtilities.WriteUint8ArrayWithUint8Length(u8s, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint16(int u16)
  {
    TlsUtilities.CheckUint16(u16);
    byte[] buf = new byte[2];
    TlsUtilities.WriteUint16(u16, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint16ArrayWithUint8Length(int[] u16s)
  {
    byte[] buf = new byte[1 + 2 * u16s.Length];
    TlsUtilities.WriteUint16ArrayWithUint8Length(u16s, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint16ArrayWithUint16Length(int[] u16s)
  {
    byte[] buf = new byte[2 + 2 * u16s.Length];
    TlsUtilities.WriteUint16ArrayWithUint16Length(u16s, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint24(int u24)
  {
    TlsUtilities.CheckUint24(u24);
    byte[] buf = new byte[3];
    TlsUtilities.WriteUint24(u24, buf, 0);
    return buf;
  }

  public static byte[] EncodeUint32(long u32)
  {
    TlsUtilities.CheckUint32(u32);
    byte[] buf = new byte[4];
    TlsUtilities.WriteUint32(u32, buf, 0);
    return buf;
  }

  public static byte[] EncodeVersion(ProtocolVersion version)
  {
    return new byte[2]
    {
      (byte) version.MajorVersion,
      (byte) version.MinorVersion
    };
  }

  public static int ReadInt32(byte[] buf, int offset)
  {
    return (int) buf[offset] << 24 | ((int) buf[++offset] & (int) byte.MaxValue) << 16 /*0x10*/ | ((int) buf[++offset] & (int) byte.MaxValue) << 8 | (int) buf[++offset] & (int) byte.MaxValue;
  }

  public static short ReadUint8(Stream input)
  {
    int num = input.ReadByte();
    return num >= 0 ? (short) num : throw new EndOfStreamException();
  }

  public static short ReadUint8(byte[] buf, int offset) => (short) buf[offset];

  public static int ReadUint16(Stream input)
  {
    int num1 = input.ReadByte();
    int num2 = input.ReadByte();
    if (num2 < 0)
      throw new EndOfStreamException();
    return num1 << 8 | num2;
  }

  public static int ReadUint16(byte[] buf, int offset)
  {
    return ((int) buf[offset] & (int) byte.MaxValue) << 8 | (int) buf[++offset] & (int) byte.MaxValue;
  }

  public static int ReadUint24(Stream input)
  {
    int num1 = input.ReadByte();
    int num2 = input.ReadByte();
    int num3 = input.ReadByte();
    if (num3 < 0)
      throw new EndOfStreamException();
    return num1 << 16 /*0x10*/ | num2 << 8 | num3;
  }

  public static int ReadUint24(byte[] buf, int offset)
  {
    return ((int) buf[offset] & (int) byte.MaxValue) << 16 /*0x10*/ | ((int) buf[++offset] & (int) byte.MaxValue) << 8 | (int) buf[++offset] & (int) byte.MaxValue;
  }

  public static long ReadUint32(Stream input)
  {
    int num1 = input.ReadByte();
    int num2 = input.ReadByte();
    int num3 = input.ReadByte();
    int num4 = input.ReadByte();
    if (num4 < 0)
      throw new EndOfStreamException();
    return (long) (num1 << 24 | num2 << 16 /*0x10*/ | num3 << 8 | num4) & (long) uint.MaxValue;
  }

  public static long ReadUint32(byte[] buf, int offset)
  {
    return (long) (((int) buf[offset] & (int) byte.MaxValue) << 24 | ((int) buf[++offset] & (int) byte.MaxValue) << 16 /*0x10*/ | ((int) buf[++offset] & (int) byte.MaxValue) << 8 | (int) buf[++offset] & (int) byte.MaxValue) & (long) uint.MaxValue;
  }

  public static long ReadUint48(Stream input)
  {
    return ((long) TlsUtilities.ReadUint24(input) & (long) uint.MaxValue) << 24 | (long) TlsUtilities.ReadUint24(input) & (long) uint.MaxValue;
  }

  public static long ReadUint48(byte[] buf, int offset)
  {
    return ((long) TlsUtilities.ReadUint24(buf, offset) & (long) uint.MaxValue) << 24 | (long) TlsUtilities.ReadUint24(buf, offset + 3) & (long) uint.MaxValue;
  }

  public static byte[] ReadAllOrNothing(int length, Stream input)
  {
    if (length < 1)
      return TlsUtilities.EmptyBytes;
    byte[] buf = new byte[length];
    int num = Streams.ReadFully(input, buf);
    if (num == 0)
      return (byte[]) null;
    if (num != length)
      throw new EndOfStreamException();
    return buf;
  }

  public static byte[] ReadFully(int length, Stream input)
  {
    if (length < 1)
      return TlsUtilities.EmptyBytes;
    byte[] buf = new byte[length];
    if (length != Streams.ReadFully(input, buf))
      throw new EndOfStreamException();
    return buf;
  }

  public static void ReadFully(byte[] buf, Stream input)
  {
    int length = buf.Length;
    if (length > 0 && length != Streams.ReadFully(input, buf))
      throw new EndOfStreamException();
  }

  public static byte[] ReadOpaque8(Stream input)
  {
    return TlsUtilities.ReadFully((int) TlsUtilities.ReadUint8(input), input);
  }

  public static byte[] ReadOpaque8(Stream input, int minLength)
  {
    int length = (int) TlsUtilities.ReadUint8(input);
    return length >= minLength ? TlsUtilities.ReadFully(length, input) : throw new TlsFatalAlert((short) 50);
  }

  public static byte[] ReadOpaque8(Stream input, int minLength, int maxLength)
  {
    short length = TlsUtilities.ReadUint8(input);
    if ((int) length < minLength || maxLength < (int) length)
      throw new TlsFatalAlert((short) 50);
    return TlsUtilities.ReadFully((int) length, input);
  }

  public static byte[] ReadOpaque16(Stream input)
  {
    return TlsUtilities.ReadFully(TlsUtilities.ReadUint16(input), input);
  }

  public static byte[] ReadOpaque16(Stream input, int minLength)
  {
    int length = TlsUtilities.ReadUint16(input);
    return length >= minLength ? TlsUtilities.ReadFully(length, input) : throw new TlsFatalAlert((short) 50);
  }

  public static byte[] ReadOpaque24(Stream input)
  {
    return TlsUtilities.ReadFully(TlsUtilities.ReadUint24(input), input);
  }

  public static byte[] ReadOpaque24(Stream input, int minLength)
  {
    int length = TlsUtilities.ReadUint24(input);
    return length >= minLength ? TlsUtilities.ReadFully(length, input) : throw new TlsFatalAlert((short) 50);
  }

  public static short[] ReadUint8Array(int count, Stream input)
  {
    short[] numArray = new short[count];
    for (int index = 0; index < count; ++index)
      numArray[index] = TlsUtilities.ReadUint8(input);
    return numArray;
  }

  public static short[] ReadUint8ArrayWithUint8Length(Stream input, int minLength)
  {
    int count = (int) TlsUtilities.ReadUint8(input);
    return count >= minLength ? TlsUtilities.ReadUint8Array(count, input) : throw new TlsFatalAlert((short) 50);
  }

  public static int[] ReadUint16Array(int count, Stream input)
  {
    int[] numArray = new int[count];
    for (int index = 0; index < count; ++index)
      numArray[index] = TlsUtilities.ReadUint16(input);
    return numArray;
  }

  public static ProtocolVersion ReadVersion(byte[] buf, int offset)
  {
    return ProtocolVersion.Get((int) buf[offset], (int) buf[offset + 1]);
  }

  public static ProtocolVersion ReadVersion(Stream input)
  {
    int major = input.ReadByte();
    int num = input.ReadByte();
    int minor = num >= 0 ? num : throw new EndOfStreamException();
    return ProtocolVersion.Get(major, minor);
  }

  public static Asn1Object ReadAsn1Object(byte[] encoding)
  {
    using (Asn1InputStream asn1InputStream = new Asn1InputStream(encoding))
    {
      Asn1Object asn1Object = asn1InputStream.ReadObject();
      if (asn1Object == null)
        throw new TlsFatalAlert((short) 50);
      if ((long) encoding.Length != asn1InputStream.Position)
        throw new TlsFatalAlert((short) 50);
      return asn1Object;
    }
  }

  public static void RequireDerEncoding(Asn1Encodable asn1, byte[] encoding)
  {
    if (!Arrays.AreEqual(asn1.GetEncoded("DER"), encoding))
      throw new TlsFatalAlert((short) 50);
  }

  public static void WriteGmtUnixTime(byte[] buf, int offset)
  {
    int num = (int) (DateTimeUtilities.CurrentUnixMs() / 1000L);
    buf[offset] = (byte) (num >> 24);
    buf[offset + 1] = (byte) (num >> 16 /*0x10*/);
    buf[offset + 2] = (byte) (num >> 8);
    buf[offset + 3] = (byte) num;
  }

  public static void WriteVersion(ProtocolVersion version, Stream output)
  {
    output.WriteByte((byte) version.MajorVersion);
    output.WriteByte((byte) version.MinorVersion);
  }

  public static void WriteVersion(ProtocolVersion version, byte[] buf, int offset)
  {
    buf[offset] = (byte) version.MajorVersion;
    buf[offset + 1] = (byte) version.MinorVersion;
  }

  public static void AddIfSupported(
    IList<SignatureAndHashAlgorithm> supportedAlgs,
    TlsCrypto crypto,
    SignatureAndHashAlgorithm alg)
  {
    if (!crypto.HasSignatureAndHashAlgorithm(alg))
      return;
    supportedAlgs.Add(alg);
  }

  public static void AddIfSupported(IList<int> supportedGroups, TlsCrypto crypto, int namedGroup)
  {
    if (!crypto.HasNamedGroup(namedGroup))
      return;
    supportedGroups.Add(namedGroup);
  }

  public static void AddIfSupported(
    IList<int> supportedGroups,
    TlsCrypto crypto,
    int[] namedGroups)
  {
    for (int index = 0; index < namedGroups.Length; ++index)
      TlsUtilities.AddIfSupported(supportedGroups, crypto, namedGroups[index]);
  }

  public static bool AddToSet<T>(IList<T> s, T i)
  {
    int num = !s.Contains(i) ? 1 : 0;
    if (num == 0)
      return num != 0;
    s.Add(i);
    return num != 0;
  }

  public static IList<SignatureAndHashAlgorithm> GetDefaultDssSignatureAlgorithms()
  {
    return TlsUtilities.GetDefaultSignatureAlgorithms((short) 2);
  }

  public static IList<SignatureAndHashAlgorithm> GetDefaultECDsaSignatureAlgorithms()
  {
    return TlsUtilities.GetDefaultSignatureAlgorithms((short) 3);
  }

  public static IList<SignatureAndHashAlgorithm> GetDefaultRsaSignatureAlgorithms()
  {
    return TlsUtilities.GetDefaultSignatureAlgorithms((short) 1);
  }

  public static SignatureAndHashAlgorithm GetDefaultSignatureAlgorithm(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 1:
      case 2:
      case 3:
        return SignatureAndHashAlgorithm.GetInstance((short) 2, signatureAlgorithm);
      default:
        return (SignatureAndHashAlgorithm) null;
    }
  }

  public static IList<SignatureAndHashAlgorithm> GetDefaultSignatureAlgorithms(
    short signatureAlgorithm)
  {
    SignatureAndHashAlgorithm signatureAlgorithm1 = TlsUtilities.GetDefaultSignatureAlgorithm(signatureAlgorithm);
    return signatureAlgorithm1 != null ? TlsUtilities.VectorOfOne<SignatureAndHashAlgorithm>(signatureAlgorithm1) : (IList<SignatureAndHashAlgorithm>) new List<SignatureAndHashAlgorithm>();
  }

  public static IList<SignatureAndHashAlgorithm> GetDefaultSupportedSignatureAlgorithms(
    TlsContext context)
  {
    return TlsUtilities.GetSupportedSignatureAlgorithms(context, TlsUtilities.DefaultSupportedSigAlgs);
  }

  public static IList<SignatureAndHashAlgorithm> GetSupportedSignatureAlgorithms(
    TlsContext context,
    IList<SignatureAndHashAlgorithm> candidates)
  {
    TlsCrypto crypto = context.Crypto;
    List<SignatureAndHashAlgorithm> supportedAlgs = new List<SignatureAndHashAlgorithm>(candidates.Count);
    foreach (SignatureAndHashAlgorithm candidate in (IEnumerable<SignatureAndHashAlgorithm>) candidates)
      TlsUtilities.AddIfSupported((IList<SignatureAndHashAlgorithm>) supportedAlgs, crypto, candidate);
    return (IList<SignatureAndHashAlgorithm>) supportedAlgs;
  }

  internal static SignatureAndHashAlgorithm GetSignatureAndHashAlgorithm(
    ProtocolVersion negotiatedVersion,
    TlsCredentialedSigner credentialedSigner)
  {
    SignatureAndHashAlgorithm andHashAlgorithm = (SignatureAndHashAlgorithm) null;
    if (TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(negotiatedVersion))
    {
      andHashAlgorithm = credentialedSigner.SignatureAndHashAlgorithm;
      if (andHashAlgorithm == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
    return andHashAlgorithm;
  }

  public static byte[] GetExtensionData(IDictionary<int, byte[]> extensions, int extensionType)
  {
    byte[] numArray;
    return extensions != null && extensions.TryGetValue(extensionType, out numArray) ? numArray : (byte[]) null;
  }

  public static bool HasExpectedEmptyExtensionData(
    IDictionary<int, byte[]> extensions,
    int extensionType,
    short alertDescription)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, extensionType);
    if (extensionData == null)
      return false;
    if (extensionData.Length != 0)
      throw new TlsFatalAlert(alertDescription);
    return true;
  }

  public static TlsSession ImportSession(byte[] sessionID, SessionParameters sessionParameters)
  {
    return (TlsSession) new TlsSessionImpl(sessionID, sessionParameters);
  }

  internal static bool IsExtendedMasterSecretOptionalDtls(ProtocolVersion[] activeProtocolVersions)
  {
    return ProtocolVersion.Contains(activeProtocolVersions, ProtocolVersion.DTLSv12) || ProtocolVersion.Contains(activeProtocolVersions, ProtocolVersion.DTLSv10);
  }

  internal static bool IsExtendedMasterSecretOptionalTls(ProtocolVersion[] activeProtocolVersions)
  {
    return ProtocolVersion.Contains(activeProtocolVersions, ProtocolVersion.TLSv12) || ProtocolVersion.Contains(activeProtocolVersions, ProtocolVersion.TLSv11) || ProtocolVersion.Contains(activeProtocolVersions, ProtocolVersion.TLSv10);
  }

  public static bool IsNullOrContainsNull(object[] array)
  {
    if (array == null)
      return true;
    int length = array.Length;
    for (int index = 0; index < length; ++index)
    {
      if (array[index] == null)
        return true;
    }
    return false;
  }

  public static bool IsNullOrEmpty<T>(T[] array) => array == null || array.Length < 1;

  public static bool IsNullOrEmpty(string s) => s == null || s.Length < 1;

  public static bool IsNullOrEmpty<T>(IList<T> v) => v == null || v.Count < 1;

  public static bool IsSignatureAlgorithmsExtensionAllowed(ProtocolVersion version)
  {
    return version != null && ProtocolVersion.TLSv12.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static short GetLegacyClientCertType(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 1:
        return 1;
      case 2:
        return 2;
      case 3:
        return 64 /*0x40*/;
      default:
        return -1;
    }
  }

  public static short GetLegacySignatureAlgorithmClient(short clientCertificateType)
  {
    switch (clientCertificateType)
    {
      case 1:
        return 1;
      case 2:
        return 2;
      case 64 /*0x40*/:
        return 3;
      default:
        return -1;
    }
  }

  public static short GetLegacySignatureAlgorithmClientCert(short clientCertificateType)
  {
    switch (clientCertificateType)
    {
      case 1:
      case 3:
      case 65:
        return 1;
      case 2:
      case 4:
        return 2;
      case 64 /*0x40*/:
      case 66:
        return 3;
      default:
        return -1;
    }
  }

  public static short GetLegacySignatureAlgorithmServer(int keyExchangeAlgorithm)
  {
    switch (keyExchangeAlgorithm)
    {
      case 3:
      case 22:
        return 2;
      case 5:
      case 19:
      case 23:
        return 1;
      case 17:
        return 3;
      default:
        return -1;
    }
  }

  public static short GetLegacySignatureAlgorithmServerCert(int keyExchangeAlgorithm)
  {
    switch (keyExchangeAlgorithm)
    {
      case 1:
      case 5:
      case 9:
      case 15:
      case 18:
      case 19:
      case 23:
        return 1;
      case 3:
      case 7:
      case 22:
        return 2;
      case 16 /*0x10*/:
      case 17:
        return 3;
      default:
        return -1;
    }
  }

  public static IList<SignatureAndHashAlgorithm> GetLegacySupportedSignatureAlgorithms()
  {
    return (IList<SignatureAndHashAlgorithm>) new List<SignatureAndHashAlgorithm>(3)
    {
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 2),
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 3),
      SignatureAndHashAlgorithm.GetInstance((short) 2, (short) 1)
    };
  }

  public static void EncodeSupportedSignatureAlgorithms(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    Stream output)
  {
    if (supportedSignatureAlgorithms == null || supportedSignatureAlgorithms.Count < 1 || supportedSignatureAlgorithms.Count >= 32768 /*0x8000*/)
      throw new ArgumentException("must have length from 1 to (2^15 - 1)", nameof (supportedSignatureAlgorithms));
    int i = 2 * supportedSignatureAlgorithms.Count;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, output);
    foreach (SignatureAndHashAlgorithm signatureAlgorithm in (IEnumerable<SignatureAndHashAlgorithm>) supportedSignatureAlgorithms)
    {
      if (signatureAlgorithm.Signature == (short) 0)
        throw new ArgumentException("SignatureAlgorithm.anonymous MUST NOT appear in the signature_algorithms extension");
      signatureAlgorithm.Encode(output);
    }
  }

  public static IList<SignatureAndHashAlgorithm> ParseSupportedSignatureAlgorithms(Stream input)
  {
    int num = TlsUtilities.ReadUint16(input);
    if (num < 2 || (num & 1) != 0)
      throw new TlsFatalAlert((short) 50);
    int capacity = num / 2;
    List<SignatureAndHashAlgorithm> signatureAlgorithms = new List<SignatureAndHashAlgorithm>(capacity);
    for (int index = 0; index < capacity; ++index)
    {
      SignatureAndHashAlgorithm andHashAlgorithm = SignatureAndHashAlgorithm.Parse(input);
      if (andHashAlgorithm.Signature != (short) 0)
        signatureAlgorithms.Add(andHashAlgorithm);
    }
    return (IList<SignatureAndHashAlgorithm>) signatureAlgorithms;
  }

  public static void VerifySupportedSignatureAlgorithm(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    SignatureAndHashAlgorithm signatureAlgorithm)
  {
    TlsUtilities.VerifySupportedSignatureAlgorithm(supportedSignatureAlgorithms, signatureAlgorithm, (short) 47);
  }

  internal static void VerifySupportedSignatureAlgorithm(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    SignatureAndHashAlgorithm signatureAlgorithm,
    short alertDescription)
  {
    if (supportedSignatureAlgorithms == null || supportedSignatureAlgorithms.Count < 1 || supportedSignatureAlgorithms.Count >= 32768 /*0x8000*/)
      throw new ArgumentException("must have length from 1 to (2^15 - 1)", nameof (supportedSignatureAlgorithms));
    if (signatureAlgorithm == null)
      throw new ArgumentNullException(nameof (signatureAlgorithm));
    if (signatureAlgorithm.Signature == (short) 0 || !TlsUtilities.ContainsSignatureAlgorithm(supportedSignatureAlgorithms, signatureAlgorithm))
      throw new TlsFatalAlert(alertDescription);
  }

  public static bool ContainsSignatureAlgorithm(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    SignatureAndHashAlgorithm signatureAlgorithm)
  {
    foreach (object signatureAlgorithm1 in (IEnumerable<SignatureAndHashAlgorithm>) supportedSignatureAlgorithms)
    {
      if (signatureAlgorithm1.Equals((object) signatureAlgorithm))
        return true;
    }
    return false;
  }

  public static bool ContainsAnySignatureAlgorithm(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    short signatureAlgorithm)
  {
    foreach (SignatureAndHashAlgorithm signatureAlgorithm1 in (IEnumerable<SignatureAndHashAlgorithm>) supportedSignatureAlgorithms)
    {
      if ((int) signatureAlgorithm1.Signature == (int) signatureAlgorithm)
        return true;
    }
    return false;
  }

  public static TlsSecret Prf(
    SecurityParameters securityParameters,
    TlsSecret secret,
    string asciiLabel,
    byte[] seed,
    int length)
  {
    return secret.DeriveUsingPrf(securityParameters.PrfAlgorithm, asciiLabel, seed, length);
  }

  public static byte[] Clone(byte[] data)
  {
    if (data == null)
      return (byte[]) null;
    return data.Length != 0 ? (byte[]) data.Clone() : TlsUtilities.EmptyBytes;
  }

  public static string[] Clone(string[] s)
  {
    if (s == null)
      return (string[]) null;
    return s.Length >= 1 ? (string[]) s.Clone() : TlsUtilities.EmptyStrings;
  }

  public static bool ConstantTimeAreEqual(int len, byte[] a, int aOff, byte[] b, int bOff)
  {
    int num = 0;
    for (int index = 0; index < len; ++index)
      num |= (int) a[aOff + index] ^ (int) b[bOff + index];
    return num == 0;
  }

  public static byte[] CopyOfRangeExact(byte[] original, int from, int to)
  {
    int length = to - from;
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) original, from, (Array) destinationArray, 0, length);
    return destinationArray;
  }

  internal static byte[] Concat(byte[] a, byte[] b)
  {
    byte[] destinationArray = new byte[a.Length + b.Length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    Array.Copy((Array) b, 0, (Array) destinationArray, a.Length, b.Length);
    return destinationArray;
  }

  internal static byte[] CalculateEndPointHash(
    TlsContext context,
    TlsCertificate certificate,
    byte[] enc)
  {
    return TlsUtilities.CalculateEndPointHash(context, certificate, enc, 0, enc.Length);
  }

  internal static byte[] CalculateEndPointHash(
    TlsContext context,
    TlsCertificate certificate,
    byte[] enc,
    int encOff,
    int encLen)
  {
    short hashAlgorithm = 0;
    string sigAlgOid = certificate.SigAlgOid;
    if (sigAlgOid != null)
    {
      if (PkcsObjectIdentifiers.IdRsassaPss.Id.Equals(sigAlgOid))
      {
        RsassaPssParameters instance = RsassaPssParameters.GetInstance((object) certificate.GetSigAlgParams());
        if (instance != null)
        {
          DerObjectIdentifier algorithm = instance.HashAlgorithm.Algorithm;
          if (NistObjectIdentifiers.IdSha256.Equals((Asn1Object) algorithm))
            hashAlgorithm = (short) 4;
          else if (NistObjectIdentifiers.IdSha384.Equals((Asn1Object) algorithm))
            hashAlgorithm = (short) 5;
          else if (NistObjectIdentifiers.IdSha512.Equals((Asn1Object) algorithm))
            hashAlgorithm = (short) 6;
        }
      }
      else
      {
        SignatureAndHashAlgorithm andHashAlgorithm;
        if (TlsUtilities.CertSigAlgOids.TryGetValue(sigAlgOid, out andHashAlgorithm))
          hashAlgorithm = andHashAlgorithm.Hash;
      }
    }
    if ((uint) hashAlgorithm - 1U > 1U)
    {
      if (hashAlgorithm == (short) 8)
        hashAlgorithm = (short) 0;
    }
    else
      hashAlgorithm = (short) 4;
    if (hashAlgorithm != (short) 0)
    {
      TlsHash hash = TlsUtilities.CreateHash(context.Crypto, hashAlgorithm);
      if (hash != null)
      {
        hash.Update(enc, encOff, encLen);
        return hash.CalculateHash();
      }
    }
    return TlsUtilities.EmptyBytes;
  }

  public static byte[] CalculateExporterSeed(SecurityParameters securityParameters, byte[] context)
  {
    byte[] clientRandom = securityParameters.ClientRandom;
    byte[] serverRandom = securityParameters.ServerRandom;
    if (context == null)
      return Arrays.Concatenate(clientRandom, serverRandom);
    if (!TlsUtilities.IsValidUint16(context.Length))
      throw new ArgumentException("must have length less than 2^16 (or be null)", nameof (context));
    byte[] buf = new byte[2];
    TlsUtilities.WriteUint16(context.Length, buf, 0);
    return Arrays.ConcatenateAll(clientRandom, serverRandom, buf, context);
  }

  private static byte[] CalculateFinishedHmac(
    SecurityParameters securityParameters,
    TlsSecret baseKey,
    byte[] transcriptHash)
  {
    return TlsUtilities.CalculateFinishedHmac(securityParameters.PrfCryptoHashAlgorithm, securityParameters.PrfHashLength, baseKey, transcriptHash);
  }

  private static byte[] CalculateFinishedHmac(
    int prfCryptoHashAlgorithm,
    int prfHashLength,
    TlsSecret baseKey,
    byte[] transcriptHash)
  {
    TlsSecret tlsSecret = TlsCryptoUtilities.HkdfExpandLabel(baseKey, prfCryptoHashAlgorithm, "finished", TlsUtilities.EmptyBytes, prfHashLength);
    try
    {
      return tlsSecret.CalculateHmac(prfCryptoHashAlgorithm, transcriptHash, 0, transcriptHash.Length);
    }
    finally
    {
      tlsSecret.Destroy();
    }
  }

  internal static TlsSecret CalculateMasterSecret(TlsContext context, TlsSecret preMasterSecret)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    string asciiLabel;
    byte[] seed;
    if (securityParameters.IsExtendedMasterSecret)
    {
      asciiLabel = "extended master secret";
      seed = securityParameters.SessionHash;
    }
    else
    {
      asciiLabel = "master secret";
      seed = TlsUtilities.Concat(securityParameters.ClientRandom, securityParameters.ServerRandom);
    }
    return TlsUtilities.Prf(securityParameters, preMasterSecret, asciiLabel, seed, 48 /*0x30*/);
  }

  internal static byte[] CalculatePskBinder(
    TlsCrypto crypto,
    bool isExternalPsk,
    int pskCryptoHashAlgorithm,
    TlsSecret earlySecret,
    byte[] transcriptHash)
  {
    int hashOutputSize = TlsCryptoUtilities.GetHashOutputSize(pskCryptoHashAlgorithm);
    string label = isExternalPsk ? "ext binder" : "res binder";
    byte[] hash = crypto.CreateHash(pskCryptoHashAlgorithm).CalculateHash();
    TlsSecret baseKey = TlsUtilities.DeriveSecret(pskCryptoHashAlgorithm, hashOutputSize, earlySecret, label, hash);
    try
    {
      return TlsUtilities.CalculateFinishedHmac(pskCryptoHashAlgorithm, hashOutputSize, baseKey, transcriptHash);
    }
    finally
    {
      baseKey.Destroy();
    }
  }

  internal static byte[] CalculateVerifyData(
    TlsContext context,
    TlsHandshakeHash handshakeHash,
    bool isServer)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (TlsUtilities.IsTlsV13(negotiatedVersion))
    {
      TlsSecret baseKey = isServer ? securityParameters.BaseKeyServer : securityParameters.BaseKeyClient;
      byte[] currentPrfHash = TlsUtilities.GetCurrentPrfHash(handshakeHash);
      return TlsUtilities.CalculateFinishedHmac(securityParameters, baseKey, currentPrfHash);
    }
    if (negotiatedVersion.IsSsl)
      return Ssl3Utilities.CalculateVerifyData(handshakeHash, isServer);
    string asciiLabel = isServer ? "server finished" : "client finished";
    byte[] currentPrfHash1 = TlsUtilities.GetCurrentPrfHash(handshakeHash);
    TlsSecret masterSecret = securityParameters.MasterSecret;
    int verifyDataLength = securityParameters.VerifyDataLength;
    return TlsUtilities.Prf(securityParameters, masterSecret, asciiLabel, currentPrfHash1, verifyDataLength).Extract();
  }

  internal static void Establish13PhaseSecrets(
    TlsContext context,
    TlsSecret pskEarlySecret,
    TlsSecret sharedSecret)
  {
    TlsCrypto crypto = context.Crypto;
    SecurityParameters securityParameters = context.SecurityParameters;
    int cryptoHashAlgorithm = securityParameters.PrfCryptoHashAlgorithm;
    TlsSecret ikm = crypto.HkdfInit(cryptoHashAlgorithm);
    byte[] hash = crypto.CreateHash(cryptoHashAlgorithm).CalculateHash();
    TlsSecret secret1 = pskEarlySecret ?? crypto.HkdfInit(cryptoHashAlgorithm).HkdfExtract(cryptoHashAlgorithm, ikm);
    if (sharedSecret == null)
      sharedSecret = ikm;
    TlsSecret secret2 = TlsUtilities.DeriveSecret(securityParameters, secret1, "derived", hash).HkdfExtract(cryptoHashAlgorithm, sharedSecret);
    if (sharedSecret != ikm)
      sharedSecret.Destroy();
    TlsSecret tlsSecret = TlsUtilities.DeriveSecret(securityParameters, secret2, "derived", hash).HkdfExtract(cryptoHashAlgorithm, ikm);
    securityParameters.m_earlySecret = secret1;
    securityParameters.m_handshakeSecret = secret2;
    securityParameters.m_masterSecret = tlsSecret;
  }

  private static void Establish13TrafficSecrets(
    TlsContext context,
    byte[] transcriptHash,
    TlsSecret phaseSecret,
    string clientLabel,
    string serverLabel,
    RecordStream recordStream)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    securityParameters.m_trafficSecretClient = TlsUtilities.DeriveSecret(securityParameters, phaseSecret, clientLabel, transcriptHash);
    if (serverLabel != null)
      securityParameters.m_trafficSecretServer = TlsUtilities.DeriveSecret(securityParameters, phaseSecret, serverLabel, transcriptHash);
    recordStream.SetPendingCipher(TlsUtilities.InitCipher(context));
  }

  internal static void Establish13PhaseApplication(
    TlsContext context,
    byte[] serverFinishedTranscriptHash,
    RecordStream recordStream)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    TlsSecret masterSecret = securityParameters.MasterSecret;
    TlsUtilities.Establish13TrafficSecrets(context, serverFinishedTranscriptHash, masterSecret, "c ap traffic", "s ap traffic", recordStream);
    securityParameters.m_exporterMasterSecret = TlsUtilities.DeriveSecret(securityParameters, masterSecret, "exp master", serverFinishedTranscriptHash);
  }

  internal static void Establish13PhaseEarly(
    TlsContext context,
    byte[] clientHelloTranscriptHash,
    RecordStream recordStream)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    TlsSecret earlySecret = securityParameters.EarlySecret;
    if (recordStream != null)
      TlsUtilities.Establish13TrafficSecrets(context, clientHelloTranscriptHash, earlySecret, "c e traffic", (string) null, recordStream);
    securityParameters.m_earlyExporterMasterSecret = TlsUtilities.DeriveSecret(securityParameters, earlySecret, "e exp master", clientHelloTranscriptHash);
  }

  internal static void Establish13PhaseHandshake(
    TlsContext context,
    byte[] serverHelloTranscriptHash,
    RecordStream recordStream)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    TlsSecret handshakeSecret = securityParameters.HandshakeSecret;
    TlsUtilities.Establish13TrafficSecrets(context, serverHelloTranscriptHash, handshakeSecret, "c hs traffic", "s hs traffic", recordStream);
    securityParameters.m_baseKeyClient = securityParameters.TrafficSecretClient;
    securityParameters.m_baseKeyServer = securityParameters.TrafficSecretServer;
  }

  internal static void Update13TrafficSecretLocal(TlsContext context)
  {
    TlsUtilities.Update13TrafficSecret(context, context.IsServer);
  }

  internal static void Update13TrafficSecretPeer(TlsContext context)
  {
    TlsUtilities.Update13TrafficSecret(context, !context.IsServer);
  }

  private static void Update13TrafficSecret(TlsContext context, bool forServer)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    TlsSecret secret;
    if (forServer)
    {
      secret = securityParameters.TrafficSecretServer;
      securityParameters.m_trafficSecretServer = TlsUtilities.Update13TrafficSecret(securityParameters, secret);
    }
    else
    {
      secret = securityParameters.TrafficSecretClient;
      securityParameters.m_trafficSecretClient = TlsUtilities.Update13TrafficSecret(securityParameters, secret);
    }
    secret?.Destroy();
  }

  private static TlsSecret Update13TrafficSecret(
    SecurityParameters securityParameters,
    TlsSecret secret)
  {
    return TlsCryptoUtilities.HkdfExpandLabel(secret, securityParameters.PrfCryptoHashAlgorithm, "traffic upd", TlsUtilities.EmptyBytes, securityParameters.PrfHashLength);
  }

  public static DerObjectIdentifier GetOidForHashAlgorithm(short hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case 1:
        return PkcsObjectIdentifiers.MD5;
      case 2:
        return X509ObjectIdentifiers.IdSha1;
      case 3:
        return NistObjectIdentifiers.IdSha224;
      case 4:
        return NistObjectIdentifiers.IdSha256;
      case 5:
        return NistObjectIdentifiers.IdSha384;
      case 6:
        return NistObjectIdentifiers.IdSha512;
      default:
        throw new ArgumentException("invalid HashAlgorithm: " + HashAlgorithm.GetText(hashAlgorithm));
    }
  }

  internal static int GetPrfAlgorithm(SecurityParameters securityParameters, int cipherSuite)
  {
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    bool flag1;
    bool flag2 = !(flag1 = TlsUtilities.IsTlsV13(negotiatedVersion)) && TlsUtilities.IsTlsV12(negotiatedVersion);
    bool isSsl = negotiatedVersion.IsSsl;
    switch (cipherSuite)
    {
      case 59:
      case 60:
      case 61:
      case 62:
      case 63 /*0x3F*/:
      case 64 /*0x40*/:
      case 103:
      case 104:
      case 105:
      case 106:
      case 107:
      case 108:
      case 109:
      case 156:
      case 158:
      case 160 /*0xA0*/:
      case 162:
      case 164:
      case 166:
      case 168:
      case 170:
      case 172:
      case 186:
      case 187:
      case 188:
      case 189:
      case 190:
      case 191:
      case 192 /*0xC0*/:
      case 193:
      case 194:
      case 195:
      case 196:
      case 197:
      case 49187:
      case 49189:
      case 49191:
      case 49193:
      case 49195:
      case 49197:
      case 49199:
      case 49201:
      case 49212:
      case 49214:
      case 49216:
      case 49218:
      case 49220:
      case 49222:
      case 49224:
      case 49226:
      case 49228:
      case 49230:
      case 49232:
      case 49234:
      case 49236:
      case 49238:
      case 49240:
      case 49242:
      case 49244:
      case 49246:
      case 49248:
      case 49250:
      case 49252:
      case 49254:
      case 49256:
      case 49258:
      case 49260:
      case 49262:
      case 49264:
      case 49266:
      case 49268:
      case 49270:
      case 49272:
      case 49274:
      case 49276:
      case 49278:
      case 49280:
      case 49282:
      case 49284:
      case 49286:
      case 49288:
      case 49290:
      case 49292:
      case 49294:
      case 49296:
      case 49298:
      case 49308:
      case 49309:
      case 49310:
      case 49311:
      case 49312:
      case 49313:
      case 49314:
      case 49315:
      case 49316:
      case 49317:
      case 49318:
      case 49319:
      case 49320:
      case 49321:
      case 49322:
      case 49323:
      case 49324:
      case 49325:
      case 49326:
      case 49327:
      case 52392:
      case 52393:
      case 52394:
      case 52395:
      case 52396:
      case 52397:
      case 52398:
      case 53249:
      case 53251:
      case 53253:
        if (!flag2)
          throw new TlsFatalAlert((short) 47);
        return 2;
      case 157:
      case 159:
      case 161:
      case 163:
      case 165:
      case 167:
      case 169:
      case 171:
      case 173:
      case 49188:
      case 49190:
      case 49192:
      case 49194:
      case 49196:
      case 49198:
      case 49200:
      case 49202:
      case 49213:
      case 49215:
      case 49217:
      case 49219:
      case 49221:
      case 49223:
      case 49225:
      case 49227:
      case 49229:
      case 49231:
      case 49233:
      case 49235:
      case 49237:
      case 49239:
      case 49241:
      case 49243:
      case 49245:
      case 49247:
      case 49249:
      case 49251:
      case 49253:
      case 49255:
      case 49257:
      case 49259:
      case 49261:
      case 49263:
      case 49265:
      case 49267:
      case 49269:
      case 49271:
      case 49273:
      case 49275:
      case 49277:
      case 49279:
      case 49281:
      case 49283:
      case 49285:
      case 49287:
      case 49289:
      case 49291:
      case 49293:
      case 49295:
      case 49297:
      case 49299:
      case 53250:
        if (flag2)
          return 3;
        throw new TlsFatalAlert((short) 47);
      case 175:
      case 177:
      case 179:
      case 181:
      case 183:
      case 185:
      case 49208:
      case 49211:
      case 49301:
      case 49303:
      case 49305:
      case 49307:
        if (flag1)
          throw new TlsFatalAlert((short) 47);
        if (flag2)
          return 3;
        return isSsl ? 0 : 1;
      case 198:
      case 199:
        if (flag1)
          return 7;
        throw new TlsFatalAlert((short) 47);
      case 4865:
      case 4867:
      case 4868:
      case 4869:
        if (flag1)
          return 4;
        throw new TlsFatalAlert((short) 47);
      case 4866:
        if (flag1)
          return 5;
        throw new TlsFatalAlert((short) 47);
      default:
        if (flag1)
          throw new TlsFatalAlert((short) 47);
        if (flag2)
          return 2;
        return isSsl ? 0 : 1;
    }
  }

  internal static int GetPrfAlgorithm13(int cipherSuite)
  {
    switch (cipherSuite)
    {
      case 198:
      case 199:
        return 7;
      case 4865:
      case 4867:
      case 4868:
      case 4869:
        return 4;
      case 4866:
        return 5;
      default:
        return -1;
    }
  }

  internal static int[] GetPrfAlgorithms13(int[] cipherSuites)
  {
    int[] a = new int[System.Math.Min(3, cipherSuites.Length)];
    int n = 0;
    for (int index = 0; index < cipherSuites.Length; ++index)
    {
      int prfAlgorithm13 = TlsUtilities.GetPrfAlgorithm13(cipherSuites[index]);
      if (prfAlgorithm13 >= 0 && !Arrays.Contains(a, prfAlgorithm13))
        a[n++] = prfAlgorithm13;
    }
    return TlsUtilities.Truncate(a, n);
  }

  internal static byte[] CalculateSignatureHash(
    TlsContext context,
    SignatureAndHashAlgorithm algorithm,
    byte[] extraSignatureInput,
    DigestInputBuffer buf)
  {
    TlsCrypto crypto = context.Crypto;
    TlsHash hash = algorithm == null ? (TlsHash) new CombinedHash(crypto) : TlsUtilities.CreateHash(crypto, algorithm);
    SecurityParameters securityParameters = context.SecurityParameters;
    byte[] input = Arrays.Concatenate(securityParameters.ClientRandom, securityParameters.ServerRandom);
    hash.Update(input, 0, input.Length);
    if (extraSignatureInput != null)
      hash.Update(extraSignatureInput, 0, extraSignatureInput.Length);
    buf.UpdateDigest(hash);
    return hash.CalculateHash();
  }

  internal static void SendSignatureInput(
    TlsContext context,
    byte[] extraSignatureInput,
    DigestInputBuffer buf,
    Stream output)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    byte[] buffer = Arrays.Concatenate(securityParameters.ClientRandom, securityParameters.ServerRandom);
    output.Write(buffer, 0, buffer.Length);
    if (extraSignatureInput != null)
      output.Write(extraSignatureInput, 0, extraSignatureInput.Length);
    buf.CopyInputTo(output);
  }

  internal static DigitallySigned GenerateCertificateVerifyClient(
    TlsClientContext clientContext,
    TlsCredentialedSigner clientAuthSigner,
    SignatureAndHashAlgorithm clientAuthAlgorithm,
    TlsStreamSigner clientAuthStreamSigner,
    TlsHandshakeHash handshakeHash)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    byte[] signature;
    if (clientAuthStreamSigner != null)
    {
      handshakeHash.CopyBufferTo(clientAuthStreamSigner.Stream);
      signature = clientAuthStreamSigner.GetSignature();
    }
    else
    {
      byte[] hash = clientAuthAlgorithm != null ? handshakeHash.GetFinalHash(SignatureScheme.GetCryptoHashAlgorithm(clientAuthAlgorithm)) : securityParameters.SessionHash;
      signature = clientAuthSigner.GenerateRawSignature(hash);
    }
    return new DigitallySigned(clientAuthAlgorithm, signature);
  }

  internal static DigitallySigned Generate13CertificateVerify(
    TlsContext context,
    TlsCredentialedSigner credentialedSigner,
    TlsHandshakeHash handshakeHash)
  {
    SignatureAndHashAlgorithm andHashAlgorithm = credentialedSigner.SignatureAndHashAlgorithm;
    if (andHashAlgorithm == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    string contextString = context.IsServer ? "TLS 1.3, server CertificateVerify" : "TLS 1.3, client CertificateVerify";
    byte[] signature = TlsUtilities.Generate13CertificateVerify(context.Crypto, credentialedSigner, contextString, handshakeHash, andHashAlgorithm);
    return new DigitallySigned(andHashAlgorithm, signature);
  }

  private static byte[] Generate13CertificateVerify(
    TlsCrypto crypto,
    TlsCredentialedSigner credentialedSigner,
    string contextString,
    TlsHandshakeHash handshakeHash,
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    TlsStreamSigner streamSigner = credentialedSigner.GetStreamSigner();
    byte[] certificateVerifyHeader = TlsUtilities.GetCertificateVerifyHeader(contextString);
    byte[] currentPrfHash = TlsUtilities.GetCurrentPrfHash(handshakeHash);
    if (streamSigner != null)
    {
      Stream stream = streamSigner.Stream;
      stream.Write(certificateVerifyHeader, 0, certificateVerifyHeader.Length);
      stream.Write(currentPrfHash, 0, currentPrfHash.Length);
      return streamSigner.GetSignature();
    }
    TlsHash hash1 = TlsUtilities.CreateHash(crypto, signatureAndHashAlgorithm);
    hash1.Update(certificateVerifyHeader, 0, certificateVerifyHeader.Length);
    hash1.Update(currentPrfHash, 0, currentPrfHash.Length);
    byte[] hash2 = hash1.CalculateHash();
    return credentialedSigner.GenerateRawSignature(hash2);
  }

  internal static void VerifyCertificateVerifyClient(
    TlsServerContext serverContext,
    CertificateRequest certificateRequest,
    DigitallySigned certificateVerify,
    TlsHandshakeHash handshakeHash)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    TlsCertificate certificateAt = securityParameters.PeerCertificate.GetCertificateAt(0);
    SignatureAndHashAlgorithm algorithm = certificateVerify.Algorithm;
    short signatureAlgorithm;
    if (algorithm == null)
    {
      signatureAlgorithm = certificateAt.GetLegacySignatureAlgorithm();
      TlsUtilities.CheckClientCertificateType(certificateRequest, TlsUtilities.GetLegacyClientCertType(signatureAlgorithm), (short) 43);
    }
    else
    {
      TlsUtilities.VerifySupportedSignatureAlgorithm(securityParameters.ServerSigAlgs, algorithm);
      signatureAlgorithm = algorithm.Signature;
      TlsUtilities.CheckClientCertificateType(certificateRequest, SignatureAlgorithm.GetClientCertificateType(signatureAlgorithm), (short) 47);
    }
    bool flag;
    try
    {
      TlsVerifier verifier = certificateAt.CreateVerifier(signatureAlgorithm);
      TlsStreamVerifier streamVerifier = verifier.GetStreamVerifier(certificateVerify);
      if (streamVerifier != null)
      {
        handshakeHash.CopyBufferTo(streamVerifier.Stream);
        flag = streamVerifier.IsVerified();
      }
      else
      {
        byte[] hash = !TlsUtilities.IsTlsV12((TlsContext) serverContext) ? securityParameters.SessionHash : handshakeHash.GetFinalHash(SignatureScheme.GetCryptoHashAlgorithm(algorithm));
        flag = verifier.VerifyRawSignature(certificateVerify, hash);
      }
    }
    catch (TlsFatalAlert ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 51, ex);
    }
    if (!flag)
      throw new TlsFatalAlert((short) 51);
  }

  internal static void Verify13CertificateVerifyClient(
    TlsServerContext serverContext,
    TlsHandshakeHash handshakeHash,
    CertificateVerify certificateVerify)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    IList<SignatureAndHashAlgorithm> serverSigAlgs = securityParameters.ServerSigAlgs;
    TlsCertificate certificateAt = securityParameters.PeerCertificate.GetCertificateAt(0);
    TlsUtilities.Verify13CertificateVerify(serverSigAlgs, "TLS 1.3, client CertificateVerify", handshakeHash, certificateAt, certificateVerify);
  }

  internal static void Verify13CertificateVerifyServer(
    TlsClientContext clientContext,
    TlsHandshakeHash handshakeHash,
    CertificateVerify certificateVerify)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    IList<SignatureAndHashAlgorithm> clientSigAlgs = securityParameters.ClientSigAlgs;
    TlsCertificate certificateAt = securityParameters.PeerCertificate.GetCertificateAt(0);
    TlsUtilities.Verify13CertificateVerify(clientSigAlgs, "TLS 1.3, server CertificateVerify", handshakeHash, certificateAt, certificateVerify);
  }

  private static void Verify13CertificateVerify(
    IList<SignatureAndHashAlgorithm> supportedAlgorithms,
    string contextString,
    TlsHandshakeHash handshakeHash,
    TlsCertificate certificate,
    CertificateVerify certificateVerify)
  {
    bool flag;
    try
    {
      int algorithm = certificateVerify.Algorithm;
      SignatureAndHashAlgorithm andHashAlgorithm = SignatureScheme.GetSignatureAndHashAlgorithm(algorithm);
      TlsUtilities.VerifySupportedSignatureAlgorithm(supportedAlgorithms, andHashAlgorithm);
      Tls13Verifier verifier = certificate.CreateVerifier(algorithm);
      byte[] certificateVerifyHeader = TlsUtilities.GetCertificateVerifyHeader(contextString);
      byte[] currentPrfHash = TlsUtilities.GetCurrentPrfHash(handshakeHash);
      Stream stream = verifier.Stream;
      stream.Write(certificateVerifyHeader, 0, certificateVerifyHeader.Length);
      stream.Write(currentPrfHash, 0, currentPrfHash.Length);
      flag = verifier.VerifySignature(certificateVerify.Signature);
    }
    catch (TlsFatalAlert ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 51, ex);
    }
    if (!flag)
      throw new TlsFatalAlert((short) 51);
  }

  private static byte[] GetCertificateVerifyHeader(string contextString)
  {
    int length = contextString.Length;
    byte[] certificateVerifyHeader = new byte[64 /*0x40*/ + length + 1];
    for (int index = 0; index < 64 /*0x40*/; ++index)
      certificateVerifyHeader[index] = (byte) 32 /*0x20*/;
    for (int index = 0; index < length; ++index)
    {
      char ch = contextString[index];
      certificateVerifyHeader[64 /*0x40*/ + index] = (byte) ch;
    }
    certificateVerifyHeader[64 /*0x40*/ + length] = (byte) 0;
    return certificateVerifyHeader;
  }

  internal static void GenerateServerKeyExchangeSignature(
    TlsContext context,
    TlsCredentialedSigner credentials,
    byte[] extraSignatureInput,
    DigestInputBuffer digestBuffer)
  {
    SignatureAndHashAlgorithm andHashAlgorithm = TlsUtilities.GetSignatureAndHashAlgorithm(context.ServerVersion, credentials);
    TlsStreamSigner streamSigner = credentials.GetStreamSigner();
    byte[] signature;
    if (streamSigner != null)
    {
      using (Stream stream = streamSigner.Stream)
        TlsUtilities.SendSignatureInput(context, extraSignatureInput, digestBuffer, stream);
      signature = streamSigner.GetSignature();
    }
    else
    {
      byte[] signatureHash = TlsUtilities.CalculateSignatureHash(context, andHashAlgorithm, extraSignatureInput, digestBuffer);
      signature = credentials.GenerateRawSignature(signatureHash);
    }
    new DigitallySigned(andHashAlgorithm, signature).Encode((Stream) digestBuffer);
  }

  internal static void VerifyServerKeyExchangeSignature(
    TlsContext context,
    Stream signatureInput,
    TlsCertificate serverCertificate,
    byte[] extraSignatureInput,
    DigestInputBuffer digestBuffer)
  {
    DigitallySigned digitallySigned = DigitallySigned.Parse(context, signatureInput);
    SecurityParameters securityParameters = context.SecurityParameters;
    int exchangeAlgorithm = securityParameters.KeyExchangeAlgorithm;
    SignatureAndHashAlgorithm algorithm = digitallySigned.Algorithm;
    short signatureAlgorithm;
    if (algorithm == null)
    {
      signatureAlgorithm = TlsUtilities.GetLegacySignatureAlgorithmServer(exchangeAlgorithm);
    }
    else
    {
      signatureAlgorithm = algorithm.Signature;
      if (!TlsUtilities.IsValidSignatureAlgorithmForServerKeyExchange(signatureAlgorithm, exchangeAlgorithm))
        throw new TlsFatalAlert((short) 47);
      TlsUtilities.VerifySupportedSignatureAlgorithm(securityParameters.ClientSigAlgs, algorithm);
    }
    TlsVerifier verifier = serverCertificate.CreateVerifier(signatureAlgorithm);
    TlsStreamVerifier streamVerifier = verifier.GetStreamVerifier(digitallySigned);
    bool flag;
    if (streamVerifier != null)
    {
      using (Stream stream = streamVerifier.Stream)
        TlsUtilities.SendSignatureInput(context, (byte[]) null, digestBuffer, stream);
      flag = streamVerifier.IsVerified();
    }
    else
    {
      byte[] signatureHash = TlsUtilities.CalculateSignatureHash(context, algorithm, (byte[]) null, digestBuffer);
      flag = verifier.VerifyRawSignature(digitallySigned, signatureHash);
    }
    if (!flag)
      throw new TlsFatalAlert((short) 51);
  }

  internal static void TrackHashAlgorithmClient(
    TlsHandshakeHash handshakeHash,
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    int cryptoHashAlgorithm = SignatureScheme.GetCryptoHashAlgorithm(signatureAndHashAlgorithm);
    if (cryptoHashAlgorithm < 0)
      return;
    handshakeHash.TrackHashAlgorithm(cryptoHashAlgorithm);
  }

  internal static void TrackHashAlgorithms(
    TlsHandshakeHash handshakeHash,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms)
  {
    foreach (SignatureAndHashAlgorithm signatureAlgorithm in (IEnumerable<SignatureAndHashAlgorithm>) supportedSignatureAlgorithms)
    {
      int cryptoHashAlgorithm = SignatureScheme.GetCryptoHashAlgorithm(signatureAlgorithm);
      if (cryptoHashAlgorithm >= 0)
        handshakeHash.TrackHashAlgorithm(cryptoHashAlgorithm);
      else if ((short) 8 == signatureAlgorithm.Hash)
        handshakeHash.ForceBuffering();
    }
  }

  public static bool HasSigningCapability(short clientCertificateType)
  {
    switch (clientCertificateType)
    {
      case 1:
      case 2:
      case 64 /*0x40*/:
        return true;
      default:
        return false;
    }
  }

  public static IList<T> VectorOfOne<T>(T obj)
  {
    return (IList<T>) new List<T>(1) { obj };
  }

  public static int GetCipherType(int cipherSuite)
  {
    return TlsUtilities.GetEncryptionAlgorithmType(TlsUtilities.GetEncryptionAlgorithm(cipherSuite));
  }

  public static int GetEncryptionAlgorithm(int cipherSuite)
  {
    switch (cipherSuite)
    {
      case 2:
      case 44:
      case 45:
      case 46:
      case 49153:
      case 49158:
      case 49163:
      case 49168:
      case 49173:
      case 49209:
        return 0;
      case 4:
      case 5:
        return 2;
      case 10:
      case 13:
      case 16 /*0x10*/:
      case 19:
      case 22:
      case 27:
      case 139:
      case 143:
      case 147:
      case 49155:
      case 49160:
      case 49165:
      case 49170:
      case 49175:
      case 49178:
      case 49179:
      case 49180:
      case 49204:
        return 7;
      case 47:
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 60:
      case 62:
      case 63 /*0x3F*/:
      case 64 /*0x40*/:
      case 103:
      case 108:
      case 140:
      case 144 /*0x90*/:
      case 148:
      case 174:
      case 178:
      case 182:
      case 49156:
      case 49161:
      case 49166:
      case 49171:
      case 49176:
      case 49181:
      case 49182:
      case 49183:
      case 49187:
      case 49189:
      case 49191:
      case 49193:
      case 49205:
      case 49207:
        return 8;
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
      case 58:
      case 61:
      case 104:
      case 105:
      case 106:
      case 107:
      case 109:
      case 141:
      case 145:
      case 149:
      case 175:
      case 179:
      case 183:
      case 49157:
      case 49162:
      case 49167:
      case 49172:
      case 49177:
      case 49184:
      case 49185:
      case 49186:
      case 49188:
      case 49190:
      case 49192:
      case 49194:
      case 49206:
      case 49208:
        return 9;
      case 59:
      case 176 /*0xB0*/:
      case 180:
      case 184:
      case 49210:
        return 0;
      case 65:
      case 66:
      case 67:
      case 68:
      case 69:
      case 70:
      case 186:
      case 187:
      case 188:
      case 189:
      case 190:
      case 191:
      case 49266:
      case 49268:
      case 49270:
      case 49272:
      case 49300:
      case 49302:
      case 49304:
      case 49306:
        return 12;
      case 132:
      case 133:
      case 134:
      case 135:
      case 136:
      case 137:
      case 192 /*0xC0*/:
      case 193:
      case 194:
      case 195:
      case 196:
      case 197:
      case 49267:
      case 49269:
      case 49271:
      case 49273:
      case 49301:
      case 49303:
      case 49305:
      case 49307:
        return 13;
      case 150:
      case 151:
      case 152:
      case 153:
      case 154:
      case 155:
        return 14;
      case 156:
      case 158:
      case 160 /*0xA0*/:
      case 162:
      case 164:
      case 166:
      case 168:
      case 170:
      case 172:
      case 4865:
      case 49195:
      case 49197:
      case 49199:
      case 49201:
      case 53249:
        return 10;
      case 157:
      case 159:
      case 161:
      case 163:
      case 165:
      case 167:
      case 169:
      case 171:
      case 173:
      case 4866:
      case 49196:
      case 49198:
      case 49200:
      case 49202:
      case 53250:
        return 11;
      case 177:
      case 181:
      case 185:
      case 49211:
        return 0;
      case 198:
        return 27;
      case 199:
        return 26;
      case 4867:
      case 52392:
      case 52393:
      case 52394:
      case 52395:
      case 52396:
      case 52397:
      case 52398:
        return 21;
      case 4868:
      case 49308:
      case 49310:
      case 49316:
      case 49318:
      case 49324:
      case 53253:
        return 15;
      case 4869:
      case 49312:
      case 49314:
      case 49320:
      case 49322:
      case 49326:
      case 53251:
        return 16 /*0x10*/;
      case 49212:
      case 49214:
      case 49216:
      case 49218:
      case 49220:
      case 49222:
      case 49224:
      case 49226:
      case 49228:
      case 49230:
      case 49252:
      case 49254:
      case 49256:
      case 49264:
        return 22;
      case 49213:
      case 49215:
      case 49217:
      case 49219:
      case 49221:
      case 49223:
      case 49225:
      case 49227:
      case 49229:
      case 49231:
      case 49253:
      case 49255:
      case 49257:
      case 49265:
        return 23;
      case 49232:
      case 49234:
      case 49236:
      case 49238:
      case 49240:
      case 49242:
      case 49244:
      case 49246:
      case 49248:
      case 49250:
      case 49258:
      case 49260:
      case 49262:
        return 24;
      case 49233:
      case 49235:
      case 49237:
      case 49239:
      case 49241:
      case 49243:
      case 49245:
      case 49247:
      case 49249:
      case 49251:
      case 49259:
      case 49261:
      case 49263:
        return 25;
      case 49274:
      case 49276:
      case 49278:
      case 49280:
      case 49282:
      case 49284:
      case 49286:
      case 49288:
      case 49290:
      case 49292:
      case 49294:
      case 49296:
      case 49298:
        return 19;
      case 49275:
      case 49277:
      case 49279:
      case 49281:
      case 49283:
      case 49285:
      case 49287:
      case 49289:
      case 49291:
      case 49293:
      case 49295:
      case 49297:
      case 49299:
        return 20;
      case 49309:
      case 49311:
      case 49317:
      case 49319:
      case 49325:
        return 17;
      case 49313:
      case 49315:
      case 49321:
      case 49323:
      case 49327:
        return 18;
      default:
        return -1;
    }
  }

  public static int GetEncryptionAlgorithmType(int encryptionAlgorithm)
  {
    switch (encryptionAlgorithm)
    {
      case 0:
      case 1:
      case 2:
        return 0;
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 12:
      case 13:
      case 14:
      case 22:
      case 23:
      case 28:
        return 1;
      case 10:
      case 11:
      case 15:
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
      case 20:
      case 21:
      case 24:
      case 25:
      case 26:
      case 27:
        return 2;
      default:
        return -1;
    }
  }

  public static int GetKeyExchangeAlgorithm(int cipherSuite)
  {
    switch (cipherSuite)
    {
      case 2:
      case 4:
      case 5:
      case 10:
      case 47:
      case 53:
      case 59:
      case 60:
      case 61:
      case 65:
      case 132:
      case 150:
      case 156:
      case 157:
      case 186:
      case 192 /*0xC0*/:
      case 49212:
      case 49213:
      case 49232:
      case 49233:
      case 49274:
      case 49275:
      case 49308:
      case 49309:
      case 49312:
      case 49313:
        return 1;
      case 13:
      case 48 /*0x30*/:
      case 54:
      case 62:
      case 66:
      case 104:
      case 133:
      case 151:
      case 164:
      case 165:
      case 187:
      case 193:
      case 49214:
      case 49215:
      case 49240:
      case 49241:
      case 49282:
      case 49283:
        return 7;
      case 16 /*0x10*/:
      case 49:
      case 55:
      case 63 /*0x3F*/:
      case 67:
      case 105:
      case 134:
      case 152:
      case 160 /*0xA0*/:
      case 161:
      case 188:
      case 194:
      case 49216:
      case 49217:
      case 49236:
      case 49237:
      case 49278:
      case 49279:
        return 9;
      case 19:
      case 50:
      case 56:
      case 64 /*0x40*/:
      case 68:
      case 106:
      case 135:
      case 153:
      case 162:
      case 163:
      case 189:
      case 195:
      case 49218:
      case 49219:
      case 49238:
      case 49239:
      case 49280:
      case 49281:
        return 3;
      case 22:
      case 51:
      case 57:
      case 69:
      case 103:
      case 107:
      case 136:
      case 154:
      case 158:
      case 159:
      case 190:
      case 196:
      case 49220:
      case 49221:
      case 49234:
      case 49235:
      case 49276:
      case 49277:
      case 49310:
      case 49311:
      case 49314:
      case 49315:
      case 52394:
        return 5;
      case 27:
      case 52:
      case 58:
      case 70:
      case 108:
      case 109:
      case 137:
      case 155:
      case 166:
      case 167:
      case 191:
      case 197:
      case 49222:
      case 49223:
      case 49242:
      case 49243:
      case 49284:
      case 49285:
        return 11;
      case 44:
      case 139:
      case 140:
      case 141:
      case 168:
      case 169:
      case 174:
      case 175:
      case 176 /*0xB0*/:
      case 177:
      case 49252:
      case 49253:
      case 49258:
      case 49259:
      case 49294:
      case 49295:
      case 49300:
      case 49301:
      case 49316:
      case 49317:
      case 49320:
      case 49321:
      case 52395:
        return 13;
      case 45:
      case 143:
      case 144 /*0x90*/:
      case 145:
      case 170:
      case 171:
      case 178:
      case 179:
      case 180:
      case 181:
      case 49254:
      case 49255:
      case 49260:
      case 49261:
      case 49296:
      case 49297:
      case 49302:
      case 49303:
      case 49318:
      case 49319:
      case 49322:
      case 49323:
      case 52397:
        return 14;
      case 46:
      case 147:
      case 148:
      case 149:
      case 172:
      case 173:
      case 182:
      case 183:
      case 184:
      case 185:
      case 49256:
      case 49257:
      case 49262:
      case 49263:
      case 49298:
      case 49299:
      case 49304:
      case 49305:
      case 52398:
        return 15;
      case 198:
      case 199:
      case 4865:
      case 4866:
      case 4867:
      case 4868:
      case 4869:
        return 0;
      case 49153:
      case 49155:
      case 49156:
      case 49157:
      case 49189:
      case 49190:
      case 49197:
      case 49198:
      case 49226:
      case 49227:
      case 49246:
      case 49247:
      case 49268:
      case 49269:
      case 49288:
      case 49289:
        return 16 /*0x10*/;
      case 49158:
      case 49160:
      case 49161:
      case 49162:
      case 49187:
      case 49188:
      case 49195:
      case 49196:
      case 49224:
      case 49225:
      case 49244:
      case 49245:
      case 49266:
      case 49267:
      case 49286:
      case 49287:
      case 49324:
      case 49325:
      case 49326:
      case 49327:
      case 52393:
        return 17;
      case 49163:
      case 49165:
      case 49166:
      case 49167:
      case 49193:
      case 49194:
      case 49201:
      case 49202:
      case 49230:
      case 49231:
      case 49250:
      case 49251:
      case 49272:
      case 49273:
      case 49292:
      case 49293:
        return 18;
      case 49168:
      case 49170:
      case 49171:
      case 49172:
      case 49191:
      case 49192:
      case 49199:
      case 49200:
      case 49228:
      case 49229:
      case 49248:
      case 49249:
      case 49270:
      case 49271:
      case 49290:
      case 49291:
      case 52392:
        return 19;
      case 49173:
      case 49175:
      case 49176:
      case 49177:
        return 20;
      case 49178:
      case 49181:
      case 49184:
        return 21;
      case 49179:
      case 49182:
      case 49185:
        return 23;
      case 49180:
      case 49183:
      case 49186:
        return 22;
      case 49204:
      case 49205:
      case 49206:
      case 49207:
      case 49208:
      case 49209:
      case 49210:
      case 49211:
      case 49264:
      case 49265:
      case 49306:
      case 49307:
      case 52396:
      case 53249:
      case 53250:
      case 53251:
      case 53253:
        return 24;
      default:
        return -1;
    }
  }

  public static IList<int> GetKeyExchangeAlgorithms(int[] cipherSuites)
  {
    List<int> s = new List<int>();
    if (cipherSuites != null)
    {
      for (int index = 0; index < cipherSuites.Length; ++index)
        TlsUtilities.AddToSet<int>((IList<int>) s, TlsUtilities.GetKeyExchangeAlgorithm(cipherSuites[index]));
      s.Remove(-1);
    }
    return (IList<int>) s;
  }

  public static int GetMacAlgorithm(int cipherSuite)
  {
    switch (cipherSuite)
    {
      case 2:
      case 5:
      case 10:
      case 13:
      case 16 /*0x10*/:
      case 19:
      case 22:
      case 27:
      case 44:
      case 45:
      case 46:
      case 47:
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
      case 58:
      case 65:
      case 66:
      case 67:
      case 68:
      case 69:
      case 70:
      case 132:
      case 133:
      case 134:
      case 135:
      case 136:
      case 137:
      case 139:
      case 140:
      case 141:
      case 143:
      case 144 /*0x90*/:
      case 145:
      case 147:
      case 148:
      case 149:
      case 150:
      case 151:
      case 152:
      case 153:
      case 154:
      case 155:
      case 49153:
      case 49155:
      case 49156:
      case 49157:
      case 49158:
      case 49160:
      case 49161:
      case 49162:
      case 49163:
      case 49165:
      case 49166:
      case 49167:
      case 49168:
      case 49170:
      case 49171:
      case 49172:
      case 49173:
      case 49175:
      case 49176:
      case 49177:
      case 49178:
      case 49179:
      case 49180:
      case 49181:
      case 49182:
      case 49183:
      case 49184:
      case 49185:
      case 49186:
      case 49204:
      case 49205:
      case 49206:
      case 49209:
        return 2;
      case 4:
        return 1;
      case 59:
      case 60:
      case 61:
      case 62:
      case 63 /*0x3F*/:
      case 64 /*0x40*/:
      case 103:
      case 104:
      case 105:
      case 106:
      case 107:
      case 108:
      case 109:
      case 174:
      case 176 /*0xB0*/:
      case 178:
      case 180:
      case 182:
      case 184:
      case 186:
      case 187:
      case 188:
      case 189:
      case 190:
      case 191:
      case 192 /*0xC0*/:
      case 193:
      case 194:
      case 195:
      case 196:
      case 197:
      case 49187:
      case 49189:
      case 49191:
      case 49193:
      case 49207:
      case 49210:
      case 49212:
      case 49214:
      case 49216:
      case 49218:
      case 49220:
      case 49222:
      case 49224:
      case 49226:
      case 49228:
      case 49230:
      case 49252:
      case 49254:
      case 49256:
      case 49264:
      case 49266:
      case 49268:
      case 49270:
      case 49272:
      case 49300:
      case 49302:
      case 49304:
      case 49306:
        return 3;
      case 156:
      case 157:
      case 158:
      case 159:
      case 160 /*0xA0*/:
      case 161:
      case 162:
      case 163:
      case 164:
      case 165:
      case 166:
      case 167:
      case 168:
      case 169:
      case 170:
      case 171:
      case 172:
      case 173:
      case 198:
      case 199:
      case 4865:
      case 4866:
      case 4867:
      case 4868:
      case 4869:
      case 49195:
      case 49196:
      case 49197:
      case 49198:
      case 49199:
      case 49200:
      case 49201:
      case 49202:
      case 49232:
      case 49233:
      case 49234:
      case 49235:
      case 49236:
      case 49237:
      case 49238:
      case 49239:
      case 49240:
      case 49241:
      case 49242:
      case 49243:
      case 49244:
      case 49245:
      case 49246:
      case 49247:
      case 49248:
      case 49249:
      case 49250:
      case 49251:
      case 49258:
      case 49259:
      case 49260:
      case 49261:
      case 49262:
      case 49263:
      case 49274:
      case 49275:
      case 49276:
      case 49277:
      case 49278:
      case 49279:
      case 49280:
      case 49281:
      case 49282:
      case 49283:
      case 49284:
      case 49285:
      case 49286:
      case 49287:
      case 49288:
      case 49289:
      case 49290:
      case 49291:
      case 49292:
      case 49293:
      case 49294:
      case 49295:
      case 49296:
      case 49297:
      case 49298:
      case 49299:
      case 49308:
      case 49309:
      case 49310:
      case 49311:
      case 49312:
      case 49313:
      case 49314:
      case 49315:
      case 49316:
      case 49317:
      case 49318:
      case 49319:
      case 49320:
      case 49321:
      case 49322:
      case 49323:
      case 49324:
      case 49325:
      case 49326:
      case 49327:
      case 52392:
      case 52393:
      case 52394:
      case 52395:
      case 52396:
      case 52397:
      case 52398:
      case 53249:
      case 53250:
      case 53251:
      case 53253:
        return 0;
      case 175:
      case 177:
      case 179:
      case 181:
      case 183:
      case 185:
      case 49188:
      case 49190:
      case 49192:
      case 49194:
      case 49208:
      case 49211:
      case 49213:
      case 49215:
      case 49217:
      case 49219:
      case 49221:
      case 49223:
      case 49225:
      case 49227:
      case 49229:
      case 49231:
      case 49253:
      case 49255:
      case 49257:
      case 49265:
      case 49267:
      case 49269:
      case 49271:
      case 49273:
      case 49301:
      case 49303:
      case 49305:
      case 49307:
        return 4;
      default:
        return -1;
    }
  }

  public static ProtocolVersion GetMinimumVersion(int cipherSuite)
  {
    switch (cipherSuite)
    {
      case 59:
      case 60:
      case 61:
      case 62:
      case 63 /*0x3F*/:
      case 64 /*0x40*/:
      case 103:
      case 104:
      case 105:
      case 106:
      case 107:
      case 108:
      case 109:
      case 156:
      case 157:
      case 158:
      case 159:
      case 160 /*0xA0*/:
      case 161:
      case 162:
      case 163:
      case 164:
      case 165:
      case 166:
      case 167:
      case 168:
      case 169:
      case 170:
      case 171:
      case 172:
      case 173:
      case 186:
      case 187:
      case 188:
      case 189:
      case 190:
      case 191:
      case 192 /*0xC0*/:
      case 193:
      case 194:
      case 195:
      case 196:
      case 197:
      case 49187:
      case 49188:
      case 49189:
      case 49190:
      case 49191:
      case 49192:
      case 49193:
      case 49194:
      case 49195:
      case 49196:
      case 49197:
      case 49198:
      case 49199:
      case 49200:
      case 49201:
      case 49202:
      case 49212:
      case 49213:
      case 49214:
      case 49215:
      case 49216:
      case 49217:
      case 49218:
      case 49219:
      case 49220:
      case 49221:
      case 49222:
      case 49223:
      case 49224:
      case 49225:
      case 49226:
      case 49227:
      case 49228:
      case 49229:
      case 49230:
      case 49231:
      case 49232:
      case 49233:
      case 49234:
      case 49235:
      case 49236:
      case 49237:
      case 49238:
      case 49239:
      case 49240:
      case 49241:
      case 49242:
      case 49243:
      case 49244:
      case 49245:
      case 49246:
      case 49247:
      case 49248:
      case 49249:
      case 49250:
      case 49251:
      case 49252:
      case 49253:
      case 49254:
      case 49255:
      case 49256:
      case 49257:
      case 49258:
      case 49259:
      case 49260:
      case 49261:
      case 49262:
      case 49263:
      case 49264:
      case 49265:
      case 49266:
      case 49267:
      case 49268:
      case 49269:
      case 49270:
      case 49271:
      case 49272:
      case 49273:
      case 49274:
      case 49275:
      case 49276:
      case 49277:
      case 49278:
      case 49279:
      case 49280:
      case 49281:
      case 49282:
      case 49283:
      case 49284:
      case 49285:
      case 49286:
      case 49287:
      case 49288:
      case 49289:
      case 49290:
      case 49291:
      case 49292:
      case 49293:
      case 49294:
      case 49295:
      case 49296:
      case 49297:
      case 49298:
      case 49299:
      case 49308:
      case 49309:
      case 49310:
      case 49311:
      case 49312:
      case 49313:
      case 49314:
      case 49315:
      case 49316:
      case 49317:
      case 49318:
      case 49319:
      case 49320:
      case 49321:
      case 49322:
      case 49323:
      case 49324:
      case 49325:
      case 49326:
      case 49327:
      case 52392:
      case 52393:
      case 52394:
      case 52395:
      case 52396:
      case 52397:
      case 52398:
      case 53249:
      case 53250:
      case 53251:
      case 53253:
        return ProtocolVersion.TLSv12;
      case 198:
      case 199:
      case 4865:
      case 4866:
      case 4867:
      case 4868:
      case 4869:
        return ProtocolVersion.TLSv13;
      default:
        return ProtocolVersion.SSLv3;
    }
  }

  public static IList<int> GetNamedGroupRoles(int[] cipherSuites)
  {
    return TlsUtilities.GetNamedGroupRoles(TlsUtilities.GetKeyExchangeAlgorithms(cipherSuites));
  }

  public static IList<int> GetNamedGroupRoles(IList<int> keyExchangeAlgorithms)
  {
    List<int> s = new List<int>();
    foreach (int exchangeAlgorithm in (IEnumerable<int>) keyExchangeAlgorithms)
    {
      switch (exchangeAlgorithm)
      {
        case 0:
          TlsUtilities.AddToSet<int>((IList<int>) s, 1);
          TlsUtilities.AddToSet<int>((IList<int>) s, 2);
          continue;
        case 3:
        case 5:
        case 7:
        case 9:
        case 11:
        case 14:
          TlsUtilities.AddToSet<int>((IList<int>) s, 1);
          continue;
        case 16 /*0x10*/:
        case 17:
          TlsUtilities.AddToSet<int>((IList<int>) s, 2);
          TlsUtilities.AddToSet<int>((IList<int>) s, 3);
          continue;
        case 18:
        case 19:
        case 20:
        case 24:
          TlsUtilities.AddToSet<int>((IList<int>) s, 2);
          continue;
        default:
          continue;
      }
    }
    return (IList<int>) s;
  }

  public static bool IsAeadCipherSuite(int cipherSuite)
  {
    return 2 == TlsUtilities.GetCipherType(cipherSuite);
  }

  public static bool IsBlockCipherSuite(int cipherSuite)
  {
    return 1 == TlsUtilities.GetCipherType(cipherSuite);
  }

  public static bool IsStreamCipherSuite(int cipherSuite)
  {
    return TlsUtilities.GetCipherType(cipherSuite) == 0;
  }

  public static bool IsValidCipherSuiteForSignatureAlgorithms(int cipherSuite, IList<short> sigAlgs)
  {
    int exchangeAlgorithm = TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite);
    switch (exchangeAlgorithm)
    {
      case 0:
      case 3:
      case 5:
      case 17:
      case 19:
      case 22:
      case 23:
        foreach (short sigAlg in (IEnumerable<short>) sigAlgs)
        {
          if (TlsUtilities.IsValidSignatureAlgorithmForServerKeyExchange(sigAlg, exchangeAlgorithm))
            return true;
        }
        return false;
      default:
        return true;
    }
  }

  internal static bool IsValidCipherSuiteSelection(int[] offeredCipherSuites, int cipherSuite)
  {
    return offeredCipherSuites != null && Arrays.Contains(offeredCipherSuites, cipherSuite) && cipherSuite != 0 && !CipherSuite.IsScsv(cipherSuite);
  }

  internal static bool IsValidKeyShareSelection(
    ProtocolVersion negotiatedVersion,
    int[] clientSupportedGroups,
    IDictionary<int, TlsAgreement> clientAgreements,
    int keyShareGroup)
  {
    return clientSupportedGroups != null && Arrays.Contains(clientSupportedGroups, keyShareGroup) && !clientAgreements.ContainsKey(keyShareGroup) && NamedGroup.CanBeNegotiated(keyShareGroup, negotiatedVersion);
  }

  internal static bool IsValidSignatureAlgorithmForServerKeyExchange(
    short signatureAlgorithm,
    int keyExchangeAlgorithm)
  {
    switch (keyExchangeAlgorithm)
    {
      case 0:
        return signatureAlgorithm != (short) 0;
      case 3:
      case 22:
        return (short) 2 == signatureAlgorithm;
      case 5:
      case 19:
      case 23:
        switch (signatureAlgorithm)
        {
          case 1:
          case 4:
          case 5:
          case 6:
          case 9:
          case 10:
          case 11:
            return true;
          default:
            return false;
        }
      case 17:
        switch (signatureAlgorithm)
        {
          case 3:
          case 7:
          case 8:
            return true;
          default:
            return false;
        }
      default:
        return false;
    }
  }

  public static bool IsValidSignatureSchemeForServerKeyExchange(
    int signatureScheme,
    int keyExchangeAlgorithm)
  {
    return TlsUtilities.IsValidSignatureAlgorithmForServerKeyExchange(SignatureScheme.GetSignatureAlgorithm(signatureScheme), keyExchangeAlgorithm);
  }

  public static bool IsValidVersionForCipherSuite(int cipherSuite, ProtocolVersion version)
  {
    version = version.GetEquivalentTlsVersion();
    ProtocolVersion minimumVersion = TlsUtilities.GetMinimumVersion(cipherSuite);
    if (minimumVersion == version)
      return true;
    if (!minimumVersion.IsEarlierVersionOf(version))
      return false;
    return ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(minimumVersion) || ProtocolVersion.TLSv13.IsLaterVersionOf(version);
  }

  public static SignatureAndHashAlgorithm ChooseSignatureAndHashAlgorithm(
    TlsContext context,
    IList<SignatureAndHashAlgorithm> sigHashAlgs,
    short signatureAlgorithm)
  {
    return TlsUtilities.ChooseSignatureAndHashAlgorithm(context.ServerVersion, sigHashAlgs, signatureAlgorithm);
  }

  public static SignatureAndHashAlgorithm ChooseSignatureAndHashAlgorithm(
    ProtocolVersion negotiatedVersion,
    IList<SignatureAndHashAlgorithm> sigHashAlgs,
    short signatureAlgorithm)
  {
    if (!TlsUtilities.IsTlsV12(negotiatedVersion))
      return (SignatureAndHashAlgorithm) null;
    if (sigHashAlgs == null)
      sigHashAlgs = TlsUtilities.GetDefaultSignatureAlgorithms(signatureAlgorithm);
    SignatureAndHashAlgorithm andHashAlgorithm = (SignatureAndHashAlgorithm) null;
    foreach (SignatureAndHashAlgorithm sigHashAlg in (IEnumerable<SignatureAndHashAlgorithm>) sigHashAlgs)
    {
      if ((int) sigHashAlg.Signature == (int) signatureAlgorithm)
      {
        short hash1 = sigHashAlg.Hash;
        if ((int) hash1 >= (int) TlsUtilities.MinimumHashStrict)
        {
          if (andHashAlgorithm == null)
          {
            andHashAlgorithm = sigHashAlg;
          }
          else
          {
            short hash2 = andHashAlgorithm.Hash;
            if ((int) hash2 < (int) TlsUtilities.MinimumHashPreferred)
            {
              if ((int) hash1 > (int) hash2)
                andHashAlgorithm = sigHashAlg;
            }
            else if ((int) hash1 >= (int) TlsUtilities.MinimumHashPreferred && (int) hash1 < (int) hash2)
              andHashAlgorithm = sigHashAlg;
          }
        }
      }
    }
    return andHashAlgorithm != null ? andHashAlgorithm : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static IList<short> GetUsableSignatureAlgorithms(
    IList<SignatureAndHashAlgorithm> sigHashAlgs)
  {
    if (sigHashAlgs == null)
      return (IList<short>) new List<short>()
      {
        (short) 1,
        (short) 2,
        (short) 3
      };
    List<short> signatureAlgorithms = new List<short>();
    foreach (SignatureAndHashAlgorithm sigHashAlg in (IEnumerable<SignatureAndHashAlgorithm>) sigHashAlgs)
    {
      if ((int) sigHashAlg.Hash >= (int) TlsUtilities.MinimumHashStrict)
      {
        short signature = sigHashAlg.Signature;
        if (!signatureAlgorithms.Contains(signature))
          signatureAlgorithms.Add(signature);
      }
    }
    return (IList<short>) signatureAlgorithms;
  }

  public static int GetCommonCipherSuite13(
    ProtocolVersion negotiatedVersion,
    int[] peerCipherSuites,
    int[] localCipherSuites,
    bool useLocalOrder)
  {
    int[] numArray = peerCipherSuites;
    int[] a = localCipherSuites;
    if (useLocalOrder)
    {
      numArray = localCipherSuites;
      a = peerCipherSuites;
    }
    for (int index = 0; index < numArray.Length; ++index)
    {
      int commonCipherSuite13 = numArray[index];
      if (Arrays.Contains(a, commonCipherSuite13) && TlsUtilities.IsValidVersionForCipherSuite(commonCipherSuite13, negotiatedVersion))
        return commonCipherSuite13;
    }
    return -1;
  }

  public static int[] GetCommonCipherSuites(
    int[] peerCipherSuites,
    int[] localCipherSuites,
    bool useLocalOrder)
  {
    int[] numArray = peerCipherSuites;
    int[] a = localCipherSuites;
    if (useLocalOrder)
    {
      numArray = localCipherSuites;
      a = peerCipherSuites;
    }
    int num = 0;
    int length = System.Math.Min(numArray.Length, a.Length);
    int[] commonCipherSuites = new int[length];
    for (int index = 0; index < numArray.Length; ++index)
    {
      int n = numArray[index];
      if (!TlsUtilities.Contains(commonCipherSuites, 0, num, n) && Arrays.Contains(a, n))
        commonCipherSuites[num++] = n;
    }
    if (num < length)
      commonCipherSuites = Arrays.CopyOf(commonCipherSuites, num);
    return commonCipherSuites;
  }

  public static int[] GetSupportedCipherSuites(TlsCrypto crypto, int[] suites)
  {
    return TlsUtilities.GetSupportedCipherSuites(crypto, suites, 0, suites.Length);
  }

  public static int[] GetSupportedCipherSuites(
    TlsCrypto crypto,
    int[] suites,
    int suitesOff,
    int suitesCount)
  {
    int[] data = new int[suitesCount];
    int newLength = 0;
    for (int index = 0; index < suitesCount; ++index)
    {
      int suite = suites[suitesOff + index];
      if (TlsUtilities.IsSupportedCipherSuite(crypto, suite))
        data[newLength++] = suite;
    }
    if (newLength < suitesCount)
      data = Arrays.CopyOf(data, newLength);
    return data;
  }

  public static bool IsSupportedCipherSuite(TlsCrypto crypto, int cipherSuite)
  {
    int exchangeAlgorithm = TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite);
    if (!TlsUtilities.IsSupportedKeyExchange(crypto, exchangeAlgorithm))
      return false;
    int encryptionAlgorithm = TlsUtilities.GetEncryptionAlgorithm(cipherSuite);
    if (encryptionAlgorithm < 0 || !crypto.HasEncryptionAlgorithm(encryptionAlgorithm))
      return false;
    int macAlgorithm = TlsUtilities.GetMacAlgorithm(cipherSuite);
    return macAlgorithm == 0 || macAlgorithm >= 0 && crypto.HasMacAlgorithm(macAlgorithm);
  }

  public static bool IsSupportedKeyExchange(TlsCrypto crypto, int keyExchangeAlgorithm)
  {
    switch (keyExchangeAlgorithm)
    {
      case 0:
      case 13:
        return true;
      case 1:
      case 15:
        return crypto.HasRsaEncryption();
      case 3:
        return crypto.HasDHAgreement() && crypto.HasSignatureAlgorithm((short) 2);
      case 5:
        return crypto.HasDHAgreement() && TlsUtilities.HasAnyRsaSigAlgs(crypto);
      case 7:
      case 9:
      case 11:
      case 14:
        return crypto.HasDHAgreement();
      case 16 /*0x10*/:
      case 18:
      case 20:
      case 24:
        return crypto.HasECDHAgreement();
      case 17:
        if (!crypto.HasECDHAgreement())
          return false;
        return crypto.HasSignatureAlgorithm((short) 3) || crypto.HasSignatureAlgorithm((short) 7) || crypto.HasSignatureAlgorithm((short) 8);
      case 19:
        return crypto.HasECDHAgreement() && TlsUtilities.HasAnyRsaSigAlgs(crypto);
      case 21:
        return crypto.HasSrpAuthentication();
      case 22:
        return crypto.HasSrpAuthentication() && crypto.HasSignatureAlgorithm((short) 2);
      case 23:
        return crypto.HasSrpAuthentication() && TlsUtilities.HasAnyRsaSigAlgs(crypto);
      default:
        return false;
    }
  }

  internal static bool HasAnyRsaSigAlgs(TlsCrypto crypto)
  {
    return crypto.HasSignatureAlgorithm((short) 1) || crypto.HasSignatureAlgorithm((short) 4) || crypto.HasSignatureAlgorithm((short) 5) || crypto.HasSignatureAlgorithm((short) 6) || crypto.HasSignatureAlgorithm((short) 9) || crypto.HasSignatureAlgorithm((short) 10) || crypto.HasSignatureAlgorithm((short) 11);
  }

  internal static byte[] GetCurrentPrfHash(TlsHandshakeHash handshakeHash)
  {
    return handshakeHash.ForkPrfHash().CalculateHash();
  }

  private static TlsHash CreateHash(TlsCrypto crypto, short hashAlgorithm)
  {
    return crypto.CreateHash(TlsCryptoUtilities.GetHash(hashAlgorithm));
  }

  private static TlsHash CreateHash(
    TlsCrypto crypto,
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    return crypto.CreateHash(SignatureScheme.GetCryptoHashAlgorithm(signatureAndHashAlgorithm));
  }

  private static TlsKeyExchange CreateKeyExchangeClient(TlsClient client, int keyExchange)
  {
    TlsKeyExchangeFactory keyExchangeFactory = client.GetKeyExchangeFactory();
    switch (keyExchange)
    {
      case 1:
        return keyExchangeFactory.CreateRsaKeyExchange(keyExchange);
      case 3:
      case 5:
        return keyExchangeFactory.CreateDheKeyExchangeClient(keyExchange, client.GetDHGroupVerifier());
      case 7:
      case 9:
        return keyExchangeFactory.CreateDHKeyExchange(keyExchange);
      case 11:
        return keyExchangeFactory.CreateDHanonKeyExchangeClient(keyExchange, client.GetDHGroupVerifier());
      case 13:
      case 15:
      case 24:
        return keyExchangeFactory.CreatePskKeyExchangeClient(keyExchange, client.GetPskIdentity(), (TlsDHGroupVerifier) null);
      case 14:
        return keyExchangeFactory.CreatePskKeyExchangeClient(keyExchange, client.GetPskIdentity(), client.GetDHGroupVerifier());
      case 16 /*0x10*/:
      case 18:
        return keyExchangeFactory.CreateECDHKeyExchange(keyExchange);
      case 17:
      case 19:
        return keyExchangeFactory.CreateECDheKeyExchangeClient(keyExchange);
      case 20:
        return keyExchangeFactory.CreateECDHanonKeyExchangeClient(keyExchange);
      case 21:
      case 22:
      case 23:
        return keyExchangeFactory.CreateSrpKeyExchangeClient(keyExchange, client.GetSrpIdentity(), client.GetSrpConfigVerifier());
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  private static TlsKeyExchange CreateKeyExchangeServer(TlsServer server, int keyExchange)
  {
    TlsKeyExchangeFactory keyExchangeFactory = server.GetKeyExchangeFactory();
    switch (keyExchange)
    {
      case 1:
        return keyExchangeFactory.CreateRsaKeyExchange(keyExchange);
      case 3:
      case 5:
        return keyExchangeFactory.CreateDheKeyExchangeServer(keyExchange, server.GetDHConfig());
      case 7:
      case 9:
        return keyExchangeFactory.CreateDHKeyExchange(keyExchange);
      case 11:
        return keyExchangeFactory.CreateDHanonKeyExchangeServer(keyExchange, server.GetDHConfig());
      case 13:
      case 15:
        return keyExchangeFactory.CreatePskKeyExchangeServer(keyExchange, server.GetPskIdentityManager(), (TlsDHConfig) null, (TlsECConfig) null);
      case 14:
        return keyExchangeFactory.CreatePskKeyExchangeServer(keyExchange, server.GetPskIdentityManager(), server.GetDHConfig(), (TlsECConfig) null);
      case 16 /*0x10*/:
      case 18:
        return keyExchangeFactory.CreateECDHKeyExchange(keyExchange);
      case 17:
      case 19:
        return keyExchangeFactory.CreateECDheKeyExchangeServer(keyExchange, server.GetECDHConfig());
      case 20:
        return keyExchangeFactory.CreateECDHanonKeyExchangeServer(keyExchange, server.GetECDHConfig());
      case 21:
      case 22:
      case 23:
        return keyExchangeFactory.CreateSrpKeyExchangeServer(keyExchange, server.GetSrpLoginParameters());
      case 24:
        return keyExchangeFactory.CreatePskKeyExchangeServer(keyExchange, server.GetPskIdentityManager(), (TlsDHConfig) null, server.GetECDHConfig());
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  internal static TlsKeyExchange InitKeyExchangeClient(
    TlsClientContext clientContext,
    TlsClient client)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    TlsKeyExchange keyExchangeClient = TlsUtilities.CreateKeyExchangeClient(client, securityParameters.KeyExchangeAlgorithm);
    keyExchangeClient.Init((TlsContext) clientContext);
    return keyExchangeClient;
  }

  internal static TlsKeyExchange InitKeyExchangeServer(
    TlsServerContext serverContext,
    TlsServer server)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    TlsKeyExchange keyExchangeServer = TlsUtilities.CreateKeyExchangeServer(server, securityParameters.KeyExchangeAlgorithm);
    keyExchangeServer.Init((TlsContext) serverContext);
    return keyExchangeServer;
  }

  internal static TlsCipher InitCipher(TlsContext context)
  {
    int cipherSuite = context.SecurityParameters.CipherSuite;
    int encryptionAlgorithm = TlsUtilities.GetEncryptionAlgorithm(cipherSuite);
    int macAlgorithm = TlsUtilities.GetMacAlgorithm(cipherSuite);
    if (encryptionAlgorithm < 0 || macAlgorithm < 0)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return context.Crypto.CreateCipher(new TlsCryptoParameters(context), encryptionAlgorithm, macAlgorithm);
  }

  public static void CheckPeerSigAlgs(TlsContext context, TlsCertificate[] peerCertPath)
  {
    if (context.IsServer)
      TlsUtilities.CheckSigAlgOfClientCerts(context, peerCertPath);
    else
      TlsUtilities.CheckSigAlgOfServerCerts(context, peerCertPath);
  }

  private static void CheckSigAlgOfClientCerts(TlsContext context, TlsCertificate[] clientCertPath)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    short[] clientCertTypes = securityParameters.ClientCertTypes;
    IList<SignatureAndHashAlgorithm> serverSigAlgsCert = securityParameters.ServerSigAlgsCert;
    int num = clientCertPath.Length - 1;
    for (int index1 = 0; index1 < num; ++index1)
    {
      SignatureAndHashAlgorithm certSigAndHashAlg = TlsUtilities.GetCertSigAndHashAlg(clientCertPath[index1], clientCertPath[index1 + 1]);
      bool flag = false;
      if (certSigAndHashAlg != null)
      {
        if (serverSigAlgsCert == null)
        {
          if (clientCertTypes != null)
          {
            for (int index2 = 0; index2 < clientCertTypes.Length; ++index2)
            {
              short algorithmClientCert = TlsUtilities.GetLegacySignatureAlgorithmClientCert(clientCertTypes[index2]);
              if ((int) certSigAndHashAlg.Signature == (int) algorithmClientCert)
              {
                flag = true;
                break;
              }
            }
          }
        }
        else
          flag = TlsUtilities.ContainsSignatureAlgorithm(serverSigAlgsCert, certSigAndHashAlg);
      }
      if (!flag)
        throw new TlsFatalAlert((short) 42);
    }
  }

  private static void CheckSigAlgOfServerCerts(TlsContext context, TlsCertificate[] serverCertPath)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    IList<SignatureAndHashAlgorithm> clientSigAlgsCert = securityParameters.ClientSigAlgsCert;
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms = securityParameters.ClientSigAlgs;
    if (supportedSignatureAlgorithms == clientSigAlgsCert || TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
      supportedSignatureAlgorithms = (IList<SignatureAndHashAlgorithm>) null;
    int num = serverCertPath.Length - 1;
    for (int index = 0; index < num; ++index)
    {
      SignatureAndHashAlgorithm certSigAndHashAlg = TlsUtilities.GetCertSigAndHashAlg(serverCertPath[index], serverCertPath[index + 1]);
      bool flag = false;
      if (certSigAndHashAlg != null)
        flag = clientSigAlgsCert != null ? TlsUtilities.ContainsSignatureAlgorithm(clientSigAlgsCert, certSigAndHashAlg) || supportedSignatureAlgorithms != null && TlsUtilities.ContainsSignatureAlgorithm(supportedSignatureAlgorithms, certSigAndHashAlg) : (int) TlsUtilities.GetLegacySignatureAlgorithmServerCert(securityParameters.KeyExchangeAlgorithm) == (int) certSigAndHashAlg.Signature;
      if (!flag)
        throw new TlsFatalAlert((short) 42);
    }
  }

  internal static void CheckTlsFeatures(
    Certificate serverCertificate,
    IDictionary<int, byte[]> clientExtensions,
    IDictionary<int, byte[]> serverExtensions)
  {
    byte[] extension = serverCertificate.GetCertificateAt(0).GetExtension(TlsObjectIdentifiers.id_pe_tlsfeature);
    if (extension == null)
      return;
    Asn1Sequence asn1 = (Asn1Sequence) TlsUtilities.ReadAsn1Object(extension);
    for (int index = 0; index < asn1.Count; ++index)
    {
      if (!(asn1[index] is DerInteger))
        throw new TlsFatalAlert((short) 42);
    }
    TlsUtilities.RequireDerEncoding((Asn1Encodable) asn1, extension);
    foreach (DerInteger derInteger in asn1)
    {
      BigInteger positiveValue = derInteger.PositiveValue;
      if (positiveValue.BitLength <= 16 /*0x10*/)
      {
        int intValueExact = positiveValue.IntValueExact;
        if (clientExtensions.ContainsKey(intValueExact) && !serverExtensions.ContainsKey(intValueExact))
          throw new TlsFatalAlert((short) 46);
      }
    }
  }

  internal static void ProcessClientCertificate(
    TlsServerContext serverContext,
    Certificate clientCertificate,
    TlsKeyExchange keyExchange,
    TlsServer server)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    if (securityParameters.PeerCertificate != null)
      throw new TlsFatalAlert((short) 10);
    if (!TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
    {
      if (clientCertificate.IsEmpty)
        keyExchange.SkipClientCredentials();
      else
        keyExchange.ProcessClientCertificate(clientCertificate);
    }
    securityParameters.m_peerCertificate = clientCertificate;
    server.NotifyClientCertificate(clientCertificate);
  }

  internal static void ProcessServerCertificate(
    TlsClientContext clientContext,
    CertificateStatus serverCertificateStatus,
    TlsKeyExchange keyExchange,
    TlsAuthentication clientAuthentication,
    IDictionary<int, byte[]> clientExtensions,
    IDictionary<int, byte[]> serverExtensions)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    bool flag = TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion);
    if (clientAuthentication == null)
    {
      if (flag)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      keyExchange.SkipServerCredentials();
      securityParameters.m_tlsServerEndPoint = TlsUtilities.EmptyBytes;
    }
    else
    {
      Certificate peerCertificate = securityParameters.PeerCertificate;
      TlsUtilities.CheckTlsFeatures(peerCertificate, clientExtensions, serverExtensions);
      if (!flag)
        keyExchange.ProcessServerCertificate(peerCertificate);
      clientAuthentication.NotifyServerCertificate((TlsServerCertificate) new TlsServerCertificateImpl(peerCertificate, serverCertificateStatus));
    }
  }

  internal static SignatureAndHashAlgorithm GetCertSigAndHashAlg(
    TlsCertificate subjectCert,
    TlsCertificate issuerCert)
  {
    string sigAlgOid = subjectCert.SigAlgOid;
    if (sigAlgOid != null)
    {
      if (!PkcsObjectIdentifiers.IdRsassaPss.Id.Equals(sigAlgOid))
        return CollectionUtilities.GetValueOrNull<string, SignatureAndHashAlgorithm>(TlsUtilities.CertSigAlgOids, sigAlgOid);
      RsassaPssParameters instance = RsassaPssParameters.GetInstance((object) subjectCert.GetSigAlgParams());
      if (instance != null)
      {
        DerObjectIdentifier algorithm = instance.HashAlgorithm.Algorithm;
        if (NistObjectIdentifiers.IdSha256.Equals((Asn1Object) algorithm))
        {
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 9))
            return SignatureAndHashAlgorithm.rsa_pss_pss_sha256;
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 4))
            return SignatureAndHashAlgorithm.rsa_pss_rsae_sha256;
        }
        else if (NistObjectIdentifiers.IdSha384.Equals((Asn1Object) algorithm))
        {
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 10))
            return SignatureAndHashAlgorithm.rsa_pss_pss_sha384;
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 5))
            return SignatureAndHashAlgorithm.rsa_pss_rsae_sha384;
        }
        else if (NistObjectIdentifiers.IdSha512.Equals((Asn1Object) algorithm))
        {
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 11))
            return SignatureAndHashAlgorithm.rsa_pss_pss_sha512;
          if (issuerCert.SupportsSignatureAlgorithmCA((short) 6))
            return SignatureAndHashAlgorithm.rsa_pss_rsae_sha512;
        }
      }
    }
    return (SignatureAndHashAlgorithm) null;
  }

  internal static CertificateRequest ValidateCertificateRequest(
    CertificateRequest certificateRequest,
    TlsKeyExchange keyExchange)
  {
    short[] certificateTypes = keyExchange.GetClientCertificateTypes();
    certificateRequest = !TlsUtilities.IsNullOrEmpty<short>(certificateTypes) ? TlsUtilities.NormalizeCertificateRequest(certificateRequest, certificateTypes) : throw new TlsFatalAlert((short) 10);
    return certificateRequest != null ? certificateRequest : throw new TlsFatalAlert((short) 47);
  }

  internal static CertificateRequest NormalizeCertificateRequest(
    CertificateRequest certificateRequest,
    short[] validClientCertificateTypes)
  {
    if (TlsUtilities.ContainsAll(validClientCertificateTypes, certificateRequest.CertificateTypes))
      return certificateRequest;
    short[] certificateTypes = TlsUtilities.RetainAll(certificateRequest.CertificateTypes, validClientCertificateTypes);
    return certificateTypes.Length < 1 ? (CertificateRequest) null : new CertificateRequest(certificateTypes, certificateRequest.SupportedSignatureAlgorithms, certificateRequest.CertificateAuthorities);
  }

  internal static bool Contains(int[] buf, int off, int len, int value)
  {
    for (int index = 0; index < len; ++index)
    {
      if (value == buf[off + index])
        return true;
    }
    return false;
  }

  internal static bool ContainsAll(short[] container, short[] elements)
  {
    for (int index = 0; index < elements.Length; ++index)
    {
      if (!Arrays.Contains(container, elements[index]))
        return false;
    }
    return true;
  }

  internal static short[] RetainAll(short[] retainer, short[] elements)
  {
    short[] a = new short[System.Math.Min(retainer.Length, elements.Length)];
    int n = 0;
    for (int index = 0; index < elements.Length; ++index)
    {
      if (Arrays.Contains(retainer, elements[index]))
        a[n++] = elements[index];
    }
    return TlsUtilities.Truncate(a, n);
  }

  internal static short[] Truncate(short[] a, int n)
  {
    if (n >= a.Length)
      return a;
    short[] destinationArray = new short[n];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, n);
    return destinationArray;
  }

  internal static int[] Truncate(int[] a, int n)
  {
    if (n >= a.Length)
      return a;
    int[] destinationArray = new int[n];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, n);
    return destinationArray;
  }

  internal static TlsCredentialedAgreement RequireAgreementCredentials(TlsCredentials credentials)
  {
    return credentials is TlsCredentialedAgreement ? (TlsCredentialedAgreement) credentials : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static TlsCredentialedDecryptor RequireDecryptorCredentials(TlsCredentials credentials)
  {
    return credentials is TlsCredentialedDecryptor ? (TlsCredentialedDecryptor) credentials : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static TlsCredentialedSigner RequireSignerCredentials(TlsCredentials credentials)
  {
    return credentials is TlsCredentialedSigner ? (TlsCredentialedSigner) credentials : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  private static void CheckClientCertificateType(
    CertificateRequest certificateRequest,
    short clientCertificateType,
    short alertDescription)
  {
    if (clientCertificateType < (short) 0 || !Arrays.Contains(certificateRequest.CertificateTypes, clientCertificateType))
      throw new TlsFatalAlert(alertDescription);
  }

  private static void CheckDowngradeMarker(byte[] randomBlock, byte[] downgradeMarker)
  {
    int length = downgradeMarker.Length;
    if (TlsUtilities.ConstantTimeAreEqual(length, downgradeMarker, 0, randomBlock, randomBlock.Length - length))
      throw new TlsFatalAlert((short) 47);
  }

  internal static void CheckDowngradeMarker(ProtocolVersion version, byte[] randomBlock)
  {
    version = version.GetEquivalentTlsVersion();
    if (version.IsEqualOrEarlierVersionOf(ProtocolVersion.TLSv11))
      TlsUtilities.CheckDowngradeMarker(randomBlock, TlsUtilities.DowngradeTlsV11);
    if (!version.IsEqualOrEarlierVersionOf(ProtocolVersion.TLSv12))
      return;
    TlsUtilities.CheckDowngradeMarker(randomBlock, TlsUtilities.DowngradeTlsV12);
  }

  internal static void WriteDowngradeMarker(ProtocolVersion version, byte[] randomBlock)
  {
    version = version.GetEquivalentTlsVersion();
    byte[] sourceArray;
    if (ProtocolVersion.TLSv12 == version)
    {
      sourceArray = TlsUtilities.DowngradeTlsV12;
    }
    else
    {
      if (!version.IsEqualOrEarlierVersionOf(ProtocolVersion.TLSv11))
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      sourceArray = TlsUtilities.DowngradeTlsV11;
    }
    Array.Copy((Array) sourceArray, 0, (Array) randomBlock, randomBlock.Length - sourceArray.Length, sourceArray.Length);
  }

  internal static TlsAuthentication ReceiveServerCertificate(
    TlsClientContext clientContext,
    TlsClient client,
    MemoryStream buf,
    IDictionary<int, byte[]> serverExtensions)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    if (KeyExchangeAlgorithm.IsAnonymous(securityParameters.KeyExchangeAlgorithm) || securityParameters.PeerCertificate != null)
      throw new TlsFatalAlert((short) 10);
    MemoryStream endPointHashOutput = new MemoryStream();
    Certificate certificate = Certificate.Parse(new Certificate.ParseOptions()
    {
      CertificateType = TlsExtensionsUtilities.GetServerCertificateTypeExtensionServer(serverExtensions, (short) 0),
      MaxChainLength = client.GetMaxCertificateChainLength()
    }, (TlsContext) clientContext, (Stream) buf, (Stream) endPointHashOutput);
    TlsProtocol.AssertEmpty(buf);
    securityParameters.m_peerCertificate = !certificate.IsEmpty ? certificate : throw new TlsFatalAlert((short) 50);
    securityParameters.m_tlsServerEndPoint = endPointHashOutput.ToArray();
    return client.GetAuthentication() ?? throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static TlsAuthentication Receive13ServerCertificate(
    TlsClientContext clientContext,
    TlsClient client,
    MemoryStream buf,
    IDictionary<int, byte[]> serverExtensions)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    if (securityParameters.PeerCertificate != null)
      throw new TlsFatalAlert((short) 10);
    Certificate certificate = Certificate.Parse(new Certificate.ParseOptions()
    {
      CertificateType = TlsExtensionsUtilities.GetServerCertificateTypeExtensionServer(serverExtensions, (short) 0),
      MaxChainLength = client.GetMaxCertificateChainLength()
    }, (TlsContext) clientContext, (Stream) buf, (Stream) null);
    TlsProtocol.AssertEmpty(buf);
    if (certificate.GetCertificateRequestContext().Length != 0)
      throw new TlsFatalAlert((short) 47);
    securityParameters.m_peerCertificate = !certificate.IsEmpty ? certificate : throw new TlsFatalAlert((short) 50);
    securityParameters.m_tlsServerEndPoint = (byte[]) null;
    return client.GetAuthentication() ?? throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static TlsAuthentication Skip13ServerCertificate(TlsClientContext clientContext)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    if (securityParameters.PeerCertificate != null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    securityParameters.m_peerCertificate = (Certificate) null;
    securityParameters.m_tlsServerEndPoint = (byte[]) null;
    return (TlsAuthentication) null;
  }

  public static bool ContainsNonAscii(byte[] bs)
  {
    for (int index = 0; index < bs.Length; ++index)
    {
      if (bs[index] >= (byte) 128 /*0x80*/)
        return true;
    }
    return false;
  }

  public static bool ContainsNonAscii(string s)
  {
    for (int index = 0; index < s.Length; ++index)
    {
      if (s[index] >= '\u0080')
        return true;
    }
    return false;
  }

  internal static IDictionary<int, TlsAgreement> AddKeyShareToClientHello(
    TlsClientContext clientContext,
    TlsClient client,
    IDictionary<int, byte[]> clientExtensions)
  {
    if (!TlsUtilities.IsTlsV13(clientContext.ClientVersion) || !clientExtensions.ContainsKey(10))
      return (IDictionary<int, TlsAgreement>) null;
    int[] supportedGroupsExtension = TlsExtensionsUtilities.GetSupportedGroupsExtension(clientExtensions);
    IList<int> earlyKeyShareGroups = client.GetEarlyKeyShareGroups();
    Dictionary<int, TlsAgreement> clientAgreements = new Dictionary<int, TlsAgreement>(3);
    List<KeyShareEntry> clientShares = new List<KeyShareEntry>(2);
    TlsUtilities.CollectKeyShares(clientContext.Crypto, supportedGroupsExtension, earlyKeyShareGroups, (IDictionary<int, TlsAgreement>) clientAgreements, (IList<KeyShareEntry>) clientShares);
    TlsExtensionsUtilities.AddKeyShareClientHello(clientExtensions, (IList<KeyShareEntry>) clientShares);
    return (IDictionary<int, TlsAgreement>) clientAgreements;
  }

  internal static IDictionary<int, TlsAgreement> AddKeyShareToClientHelloRetry(
    TlsClientContext clientContext,
    IDictionary<int, byte[]> clientExtensions,
    int keyShareGroup)
  {
    int[] supportedGroups = new int[1]{ keyShareGroup };
    IList<int> keyShareGroups = TlsUtilities.VectorOfOne<int>(keyShareGroup);
    Dictionary<int, TlsAgreement> clientAgreements = new Dictionary<int, TlsAgreement>(1);
    List<KeyShareEntry> clientShares = new List<KeyShareEntry>(1);
    TlsUtilities.CollectKeyShares(clientContext.Crypto, supportedGroups, keyShareGroups, (IDictionary<int, TlsAgreement>) clientAgreements, (IList<KeyShareEntry>) clientShares);
    TlsExtensionsUtilities.AddKeyShareClientHello(clientExtensions, (IList<KeyShareEntry>) clientShares);
    if (clientAgreements.Count < 1 || clientShares.Count < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return (IDictionary<int, TlsAgreement>) clientAgreements;
  }

  private static void CollectKeyShares(
    TlsCrypto crypto,
    int[] supportedGroups,
    IList<int> keyShareGroups,
    IDictionary<int, TlsAgreement> clientAgreements,
    IList<KeyShareEntry> clientShares)
  {
    if (TlsUtilities.IsNullOrEmpty<int>(supportedGroups) || keyShareGroups == null || keyShareGroups.Count < 1)
      return;
    for (int index = 0; index < supportedGroups.Length; ++index)
    {
      int supportedGroup = supportedGroups[index];
      if (keyShareGroups.Contains(supportedGroup) && !clientAgreements.ContainsKey(supportedGroup) && crypto.HasNamedGroup(supportedGroup))
      {
        TlsAgreement tlsAgreement = (TlsAgreement) null;
        if (NamedGroup.RefersToASpecificCurve(supportedGroup))
        {
          if (crypto.HasECDHAgreement())
            tlsAgreement = crypto.CreateECDomain(new TlsECConfig(supportedGroup)).CreateECDH();
        }
        else if (NamedGroup.RefersToASpecificFiniteField(supportedGroup) && crypto.HasDHAgreement())
          tlsAgreement = crypto.CreateDHDomain(new TlsDHConfig(supportedGroup, true)).CreateDH();
        if (tlsAgreement != null)
        {
          byte[] ephemeral = tlsAgreement.GenerateEphemeral();
          KeyShareEntry keyShareEntry = new KeyShareEntry(supportedGroup, ephemeral);
          clientShares.Add(keyShareEntry);
          clientAgreements[supportedGroup] = tlsAgreement;
        }
      }
    }
  }

  internal static KeyShareEntry SelectKeyShare(IList<KeyShareEntry> clientShares, int keyShareGroup)
  {
    if (clientShares != null && 1 == clientShares.Count)
    {
      KeyShareEntry clientShare = clientShares[0];
      if (clientShare != null && clientShare.NamedGroup == keyShareGroup)
        return clientShare;
    }
    return (KeyShareEntry) null;
  }

  internal static KeyShareEntry SelectKeyShare(
    TlsCrypto crypto,
    ProtocolVersion negotiatedVersion,
    IList<KeyShareEntry> clientShares,
    int[] clientSupportedGroups,
    int[] serverSupportedGroups)
  {
    if (clientShares != null && !TlsUtilities.IsNullOrEmpty<int>(clientSupportedGroups) && !TlsUtilities.IsNullOrEmpty<int>(serverSupportedGroups))
    {
      foreach (KeyShareEntry clientShare in (IEnumerable<KeyShareEntry>) clientShares)
      {
        int namedGroup = clientShare.NamedGroup;
        if (NamedGroup.CanBeNegotiated(namedGroup, negotiatedVersion) && Arrays.Contains(serverSupportedGroups, namedGroup) && Arrays.Contains(clientSupportedGroups, namedGroup) && crypto.HasNamedGroup(namedGroup) && (!NamedGroup.RefersToASpecificCurve(namedGroup) || crypto.HasECDHAgreement()) && (!NamedGroup.RefersToASpecificFiniteField(namedGroup) || crypto.HasDHAgreement()))
          return clientShare;
      }
    }
    return (KeyShareEntry) null;
  }

  internal static int SelectKeyShareGroup(
    TlsCrypto crypto,
    ProtocolVersion negotiatedVersion,
    int[] clientSupportedGroups,
    int[] serverSupportedGroups)
  {
    if (!TlsUtilities.IsNullOrEmpty<int>(clientSupportedGroups) && !TlsUtilities.IsNullOrEmpty<int>(serverSupportedGroups))
    {
      foreach (int clientSupportedGroup in clientSupportedGroups)
      {
        if (NamedGroup.CanBeNegotiated(clientSupportedGroup, negotiatedVersion) && Arrays.Contains(serverSupportedGroups, clientSupportedGroup) && crypto.HasNamedGroup(clientSupportedGroup) && (!NamedGroup.RefersToASpecificCurve(clientSupportedGroup) || crypto.HasECDHAgreement()) && (!NamedGroup.RefersToASpecificFiniteField(clientSupportedGroup) || crypto.HasDHAgreement()))
          return clientSupportedGroup;
      }
    }
    return -1;
  }

  internal static byte[] ReadEncryptedPms(TlsContext context, Stream input)
  {
    return TlsUtilities.IsSsl(context) ? Ssl3Utilities.ReadEncryptedPms(input) : TlsUtilities.ReadOpaque16(input);
  }

  internal static void WriteEncryptedPms(TlsContext context, byte[] encryptedPms, Stream output)
  {
    if (TlsUtilities.IsSsl(context))
      Ssl3Utilities.WriteEncryptedPms(encryptedPms, output);
    else
      TlsUtilities.WriteOpaque16(encryptedPms, output);
  }

  internal static byte[] GetSessionID(TlsSession tlsSession)
  {
    if (tlsSession != null)
    {
      byte[] sessionId = tlsSession.SessionID;
      if (sessionId != null && sessionId.Length != 0 && sessionId.Length <= 32 /*0x20*/)
        return sessionId;
    }
    return TlsUtilities.EmptyBytes;
  }

  internal static void AdjustTranscriptForRetry(TlsHandshakeHash handshakeHash)
  {
    byte[] currentPrfHash = TlsUtilities.GetCurrentPrfHash(handshakeHash);
    handshakeHash.Reset();
    int length = currentPrfHash.Length;
    TlsUtilities.CheckUint8(length);
    byte[] numArray = new byte[4 + length];
    TlsUtilities.WriteUint8((short) 254, numArray, 0);
    TlsUtilities.WriteUint24(length, numArray, 1);
    Array.Copy((Array) currentPrfHash, 0, (Array) numArray, 4, length);
    handshakeHash.Update(numArray, 0, numArray.Length);
  }

  internal static TlsCredentials EstablishClientCredentials(
    TlsAuthentication clientAuthentication,
    CertificateRequest certificateRequest)
  {
    return TlsUtilities.ValidateCredentials(clientAuthentication.GetClientCredentials(certificateRequest));
  }

  internal static TlsCredentialedSigner Establish13ClientCredentials(
    TlsAuthentication clientAuthentication,
    CertificateRequest certificateRequest)
  {
    return TlsUtilities.Validate13Credentials(clientAuthentication.GetClientCredentials(certificateRequest));
  }

  internal static void EstablishClientSigAlgs(
    SecurityParameters securityParameters,
    IDictionary<int, byte[]> clientExtensions)
  {
    securityParameters.m_clientSigAlgs = TlsExtensionsUtilities.GetSignatureAlgorithmsExtension(clientExtensions);
    securityParameters.m_clientSigAlgsCert = TlsExtensionsUtilities.GetSignatureAlgorithmsCertExtension(clientExtensions);
  }

  internal static TlsCredentials EstablishServerCredentials(TlsServer server)
  {
    return TlsUtilities.ValidateCredentials(server.GetCredentials());
  }

  internal static TlsCredentialedSigner Establish13ServerCredentials(TlsServer server)
  {
    return TlsUtilities.Validate13Credentials(server.GetCredentials());
  }

  internal static void EstablishServerSigAlgs(
    SecurityParameters securityParameters,
    CertificateRequest certificateRequest)
  {
    securityParameters.m_clientCertTypes = certificateRequest.CertificateTypes;
    securityParameters.m_serverSigAlgs = certificateRequest.SupportedSignatureAlgorithms;
    securityParameters.m_serverSigAlgsCert = certificateRequest.SupportedSignatureAlgorithmsCert;
    if (securityParameters.ServerSigAlgsCert != null)
      return;
    securityParameters.m_serverSigAlgsCert = securityParameters.ServerSigAlgs;
  }

  internal static TlsCredentials ValidateCredentials(TlsCredentials credentials)
  {
    return credentials == null || 0 + (credentials is TlsCredentialedAgreement ? 1 : 0) + (credentials is TlsCredentialedDecryptor ? 1 : 0) + (credentials is TlsCredentialedSigner ? 1 : 0) == 1 ? credentials : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static TlsCredentialedSigner Validate13Credentials(TlsCredentials credentials)
  {
    if (credentials == null)
      return (TlsCredentialedSigner) null;
    return credentials is TlsCredentialedSigner ? (TlsCredentialedSigner) credentials : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static void NegotiatedCipherSuite(SecurityParameters securityParameters, int cipherSuite)
  {
    securityParameters.m_cipherSuite = cipherSuite;
    securityParameters.m_keyExchangeAlgorithm = TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite);
    int prfAlgorithm = TlsUtilities.GetPrfAlgorithm(securityParameters, cipherSuite);
    securityParameters.m_prfAlgorithm = prfAlgorithm;
    switch (prfAlgorithm)
    {
      case 0:
      case 1:
        securityParameters.m_prfCryptoHashAlgorithm = -1;
        securityParameters.m_prfHashLength = -1;
        break;
      default:
        int hashForPrf = TlsCryptoUtilities.GetHashForPrf(prfAlgorithm);
        securityParameters.m_prfCryptoHashAlgorithm = hashForPrf;
        securityParameters.m_prfHashLength = TlsCryptoUtilities.GetHashOutputSize(hashForPrf);
        break;
    }
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (TlsUtilities.IsTlsV13(negotiatedVersion))
      securityParameters.m_verifyDataLength = securityParameters.PrfHashLength;
    else
      securityParameters.m_verifyDataLength = negotiatedVersion.IsSsl ? 36 : 12;
  }

  internal static void NegotiatedVersion(SecurityParameters securityParameters)
  {
    if (!TlsUtilities.IsSignatureAlgorithmsExtensionAllowed(securityParameters.NegotiatedVersion))
    {
      securityParameters.m_clientSigAlgs = (IList<SignatureAndHashAlgorithm>) null;
      securityParameters.m_clientSigAlgsCert = (IList<SignatureAndHashAlgorithm>) null;
    }
    else
    {
      if (securityParameters.ClientSigAlgs == null)
        securityParameters.m_clientSigAlgs = TlsUtilities.GetLegacySupportedSignatureAlgorithms();
      if (securityParameters.ClientSigAlgsCert != null)
        return;
      securityParameters.m_clientSigAlgsCert = securityParameters.ClientSigAlgs;
    }
  }

  internal static void NegotiatedVersionDtlsClient(TlsClientContext clientContext, TlsClient client)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (!ProtocolVersion.IsSupportedDtlsVersionClient(negotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedVersion(securityParameters);
    client.NotifyServerVersion(negotiatedVersion);
  }

  internal static void NegotiatedVersionDtlsServer(TlsServerContext serverContext)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    if (!ProtocolVersion.IsSupportedDtlsVersionServer(securityParameters.NegotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedVersion(securityParameters);
  }

  internal static void NegotiatedVersionTlsClient(TlsClientContext clientContext, TlsClient client)
  {
    SecurityParameters securityParameters = clientContext.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (!ProtocolVersion.IsSupportedTlsVersionClient(negotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedVersion(securityParameters);
    client.NotifyServerVersion(negotiatedVersion);
  }

  internal static void NegotiatedVersionTlsServer(TlsServerContext serverContext)
  {
    SecurityParameters securityParameters = serverContext.SecurityParameters;
    if (!ProtocolVersion.IsSupportedTlsVersionServer(securityParameters.NegotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.NegotiatedVersion(securityParameters);
  }

  internal static TlsSecret DeriveSecret(
    SecurityParameters securityParameters,
    TlsSecret secret,
    string label,
    byte[] transcriptHash)
  {
    return TlsUtilities.DeriveSecret(securityParameters.PrfCryptoHashAlgorithm, securityParameters.PrfHashLength, secret, label, transcriptHash);
  }

  internal static TlsSecret DeriveSecret(
    int prfCryptoHashAlgorithm,
    int prfHashLength,
    TlsSecret secret,
    string label,
    byte[] transcriptHash)
  {
    if (transcriptHash.Length != prfHashLength)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return TlsCryptoUtilities.HkdfExpandLabel(secret, prfCryptoHashAlgorithm, label, transcriptHash, prfHashLength);
  }

  internal static TlsSecret GetSessionMasterSecret(TlsCrypto crypto, TlsSecret masterSecret)
  {
    if (masterSecret != null)
    {
      lock (masterSecret)
      {
        if (masterSecret.IsAlive())
          return crypto.AdoptSecret(masterSecret);
      }
    }
    return (TlsSecret) null;
  }

  internal static bool IsPermittedExtensionType13(int handshakeType, int extensionType)
  {
    switch (extensionType)
    {
      case 0:
      case 1:
      case 10:
      case 14:
      case 15:
      case 16 /*0x10*/:
      case 19:
      case 20:
        return handshakeType == 1 || handshakeType == 8;
      case 5:
      case 18:
        return handshakeType == 1 || handshakeType == 11 || handshakeType == 13;
      case 13:
      case 27:
      case 47:
      case 50:
        return handshakeType == 1 || handshakeType == 13;
      case 21:
      case 45:
      case 49:
        return handshakeType == 1;
      case 41:
        switch (handshakeType)
        {
          case 1:
          case 2:
            return true;
          default:
            return false;
        }
      case 42:
        return handshakeType == 1 || handshakeType == 4 || handshakeType == 8;
      case 43:
      case 51:
        switch (handshakeType)
        {
          case 1:
          case 2:
          case 6:
            return true;
          default:
            return false;
        }
      case 44:
        return handshakeType == 1 || handshakeType == 6;
      case 48 /*0x30*/:
        return handshakeType == 13;
      default:
        return !ExtensionType.IsRecognized(extensionType);
    }
  }

  internal static void CheckExtensionData13(
    IDictionary<int, byte[]> extensions,
    int handshakeType,
    short alertDescription)
  {
    foreach (int key in (IEnumerable<int>) extensions.Keys)
    {
      if (!TlsUtilities.IsPermittedExtensionType13(handshakeType, key))
        throw new TlsFatalAlert(alertDescription, "Invalid extension: " + ExtensionType.GetText(key));
    }
  }

  public static TlsSecret GenerateEncryptedPreMasterSecret(
    TlsContext context,
    TlsEncryptor encryptor,
    Stream output)
  {
    ProtocolVersion masterSecretVersion = context.RsaPreMasterSecretVersion;
    TlsSecret rsaPreMasterSecret = context.Crypto.GenerateRsaPreMasterSecret(masterSecretVersion);
    byte[] encryptedPms = rsaPreMasterSecret.Encrypt(encryptor);
    TlsUtilities.WriteEncryptedPms(context, encryptedPms, output);
    return rsaPreMasterSecret;
  }

  public static bool IsTimeout(SocketException e) => SocketError.TimedOut == e.SocketErrorCode;

  internal static void AddPreSharedKeyToClientExtensions(
    TlsPsk[] psks,
    IDictionary<int, byte[]> clientExtensions)
  {
    List<PskIdentity> identities = new List<PskIdentity>(psks.Length);
    for (int index = 0; index < psks.Length; ++index)
    {
      TlsPsk psk = psks[index];
      identities.Add(new PskIdentity(psk.Identity, 0L));
    }
    TlsExtensionsUtilities.AddPreSharedKeyClientHello(clientExtensions, new OfferedPsks((IList<PskIdentity>) identities));
  }

  internal static OfferedPsks.BindersConfig AddPreSharedKeyToClientHello(
    TlsClientContext clientContext,
    TlsClient client,
    IDictionary<int, byte[]> clientExtensions,
    int[] offeredCipherSuites)
  {
    if (!TlsUtilities.IsTlsV13(clientContext.ClientVersion))
      return (OfferedPsks.BindersConfig) null;
    TlsPskExternal[] pskExternalsClient = TlsUtilities.GetPskExternalsClient(client, offeredCipherSuites);
    if (pskExternalsClient == null)
      return (OfferedPsks.BindersConfig) null;
    short[] keyExchangeModes = client.GetPskKeyExchangeModes();
    if (TlsUtilities.IsNullOrEmpty<short>(keyExchangeModes))
      throw new TlsFatalAlert((short) 80 /*0x50*/, "External PSKs configured but no PskKeyExchangeMode available");
    TlsSecret[] pskEarlySecrets = TlsUtilities.GetPskEarlySecrets(clientContext.Crypto, (TlsPsk[]) pskExternalsClient);
    int bindersSize = OfferedPsks.GetBindersSize((TlsPsk[]) pskExternalsClient);
    TlsUtilities.AddPreSharedKeyToClientExtensions((TlsPsk[]) pskExternalsClient, clientExtensions);
    TlsExtensionsUtilities.AddPskKeyExchangeModesExtension(clientExtensions, keyExchangeModes);
    return new OfferedPsks.BindersConfig((TlsPsk[]) pskExternalsClient, keyExchangeModes, pskEarlySecrets, bindersSize);
  }

  internal static OfferedPsks.BindersConfig AddPreSharedKeyToClientHelloRetry(
    TlsClientContext clientContext,
    OfferedPsks.BindersConfig clientBinders,
    IDictionary<int, byte[]> clientExtensions)
  {
    int prfAlgorithm13 = TlsUtilities.GetPrfAlgorithm13(clientContext.SecurityParameters.CipherSuite);
    IList<int> pskIndices = TlsUtilities.GetPskIndices(clientBinders.m_psks, prfAlgorithm13);
    if (pskIndices.Count < 1)
      return (OfferedPsks.BindersConfig) null;
    OfferedPsks.BindersConfig clientHelloRetry = clientBinders;
    int count = pskIndices.Count;
    if (count < clientBinders.m_psks.Length)
    {
      TlsPsk[] psks = new TlsPsk[count];
      TlsSecret[] earlySecrets = new TlsSecret[count];
      for (int index1 = 0; index1 < count; ++index1)
      {
        int index2 = pskIndices[index1];
        psks[index1] = clientBinders.m_psks[index2];
        earlySecrets[index1] = clientBinders.m_earlySecrets[index2];
      }
      int bindersSize = OfferedPsks.GetBindersSize(psks);
      clientHelloRetry = new OfferedPsks.BindersConfig(psks, clientBinders.m_pskKeyExchangeModes, earlySecrets, bindersSize);
    }
    TlsUtilities.AddPreSharedKeyToClientExtensions(clientHelloRetry.m_psks, clientExtensions);
    return clientHelloRetry;
  }

  internal static OfferedPsks.SelectedConfig SelectPreSharedKey(
    TlsServerContext serverContext,
    TlsServer server,
    IDictionary<int, byte[]> clientHelloExtensions,
    HandshakeMessageInput clientHelloMessage,
    TlsHandshakeHash handshakeHash,
    bool afterHelloRetryRequest)
  {
    bool flag = false;
    OfferedPsks sharedKeyClientHello = TlsExtensionsUtilities.GetPreSharedKeyClientHello(clientHelloExtensions);
    if (sharedKeyClientHello != null)
    {
      short[] exchangeModesExtension = TlsExtensionsUtilities.GetPskKeyExchangeModesExtension(clientHelloExtensions);
      if (TlsUtilities.IsNullOrEmpty<short>(exchangeModesExtension))
        throw new TlsFatalAlert((short) 109);
      if (Arrays.Contains(exchangeModesExtension, (short) 1))
      {
        TlsPskExternal externalPsk = server.GetExternalPsk(sharedKeyClientHello.Identities);
        if (externalPsk != null)
        {
          int indexOfIdentity = sharedKeyClientHello.GetIndexOfIdentity(new PskIdentity(externalPsk.Identity, 0L));
          if (indexOfIdentity >= 0)
          {
            byte[] binder = sharedKeyClientHello.Binders[indexOfIdentity];
            TlsCrypto crypto = serverContext.Crypto;
            TlsSecret pskEarlySecret = TlsUtilities.GetPskEarlySecret(crypto, (TlsPsk) externalPsk);
            bool isExternalPsk = true;
            int hashForPrf = TlsCryptoUtilities.GetHashForPrf(externalPsk.PrfAlgorithm);
            flag = true;
            int bindersSize = sharedKeyClientHello.BindersSize;
            clientHelloMessage.UpdateHashPrefix((TlsHash) handshakeHash, bindersSize);
            byte[] transcriptHash;
            if (afterHelloRetryRequest)
            {
              transcriptHash = handshakeHash.GetFinalHash(hashForPrf);
            }
            else
            {
              TlsHash hash = crypto.CreateHash(hashForPrf);
              handshakeHash.CopyBufferTo((Stream) new TlsHashSink(hash));
              transcriptHash = hash.CalculateHash();
            }
            clientHelloMessage.UpdateHashSuffix((TlsHash) handshakeHash, bindersSize);
            if (Arrays.FixedTimeEquals(TlsUtilities.CalculatePskBinder(crypto, isExternalPsk, hashForPrf, pskEarlySecret, transcriptHash), binder))
              return new OfferedPsks.SelectedConfig(indexOfIdentity, (TlsPsk) externalPsk, exchangeModesExtension, pskEarlySecret);
          }
        }
      }
    }
    if (!flag)
      clientHelloMessage.UpdateHash((TlsHash) handshakeHash);
    return (OfferedPsks.SelectedConfig) null;
  }

  internal static TlsSecret GetPskEarlySecret(TlsCrypto crypto, TlsPsk psk)
  {
    int hashForPrf = TlsCryptoUtilities.GetHashForPrf(psk.PrfAlgorithm);
    return crypto.HkdfInit(hashForPrf).HkdfExtract(hashForPrf, psk.Key);
  }

  internal static TlsSecret[] GetPskEarlySecrets(TlsCrypto crypto, TlsPsk[] psks)
  {
    int length = psks.Length;
    TlsSecret[] pskEarlySecrets = new TlsSecret[length];
    for (int index = 0; index < length; ++index)
      pskEarlySecrets[index] = TlsUtilities.GetPskEarlySecret(crypto, psks[index]);
    return pskEarlySecrets;
  }

  internal static TlsPskExternal[] GetPskExternalsClient(
    TlsClient client,
    int[] offeredCipherSuites)
  {
    IList<TlsPskExternal> externalPsks = client.GetExternalPsks();
    if (TlsUtilities.IsNullOrEmpty<TlsPskExternal>(externalPsks))
      return (TlsPskExternal[]) null;
    int[] prfAlgorithms13 = TlsUtilities.GetPrfAlgorithms13(offeredCipherSuites);
    int count = externalPsks.Count;
    TlsPskExternal[] pskExternalsClient = new TlsPskExternal[count];
    for (int index = 0; index < count; ++index)
    {
      TlsPskExternal tlsPskExternal = externalPsks[index];
      if (tlsPskExternal == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/, "External PSKs element is not a TlsPSKExternal");
      if (!Arrays.Contains(prfAlgorithms13, tlsPskExternal.PrfAlgorithm))
        throw new TlsFatalAlert((short) 80 /*0x50*/, "External PSK incompatible with offered cipher suites");
      pskExternalsClient[index] = tlsPskExternal;
    }
    return pskExternalsClient;
  }

  internal static IList<int> GetPskIndices(TlsPsk[] psks, int prfAlgorithm)
  {
    List<int> pskIndices = new List<int>(psks.Length);
    for (int index = 0; index < psks.Length; ++index)
    {
      if (psks[index].PrfAlgorithm == prfAlgorithm)
        pskIndices.Add(index);
    }
    return (IList<int>) pskIndices;
  }

  internal static int GetHandshakeResendTimeMillis(TlsPeer tlsPeer)
  {
    return tlsPeer is AbstractTlsPeer abstractTlsPeer ? abstractTlsPeer.GetHandshakeResendTimeMillis() : 1000;
  }
}
