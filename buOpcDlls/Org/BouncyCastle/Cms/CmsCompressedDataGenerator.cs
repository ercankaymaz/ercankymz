// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsCompressedDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsCompressedDataGenerator
{
  public static readonly string ZLib = CmsObjectIdentifiers.ZlibCompress.Id;

  public CmsCompressedData Generate(CmsProcessable content, string compressionOid)
  {
    if (CmsCompressedDataGenerator.ZLib != compressionOid)
      throw new ArgumentException("Unsupported compression algorithm: " + compressionOid, nameof (compressionOid));
    AlgorithmIdentifier compressionAlgorithm;
    Asn1OctetString content1;
    try
    {
      MemoryStream memoryStream = new MemoryStream();
      using (Stream outStream = Org.BouncyCastle.Utilities.IO.Compression.ZLib.CompressOutput((Stream) memoryStream, -1))
        content.Write(outStream);
      compressionAlgorithm = new AlgorithmIdentifier(CmsObjectIdentifiers.ZlibCompress);
      content1 = (Asn1OctetString) new BerOctetString(memoryStream.ToArray());
    }
    catch (IOException ex)
    {
      throw new CmsException("exception encoding data.", (Exception) ex);
    }
    ContentInfo encapContentInfo = new ContentInfo(CmsObjectIdentifiers.Data, (Asn1Encodable) content1);
    return new CmsCompressedData(new ContentInfo(CmsObjectIdentifiers.CompressedData, (Asn1Encodable) new CompressedData(compressionAlgorithm, encapContentInfo)));
  }
}
