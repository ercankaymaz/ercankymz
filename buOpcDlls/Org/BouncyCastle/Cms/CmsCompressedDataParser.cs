// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsCompressedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.IO.Compression;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsCompressedDataParser(Stream compressedData) : CmsContentInfoParser(compressedData)
{
  public CmsCompressedDataParser(byte[] compressedData)
    : this((Stream) new MemoryStream(compressedData, false))
  {
  }

  public CmsTypedStream GetContent()
  {
    try
    {
      ContentInfoParser encapContentInfo = new CompressedDataParser((Asn1SequenceParser) this.contentInfo.GetContent(16 /*0x10*/)).GetEncapContentInfo();
      return new CmsTypedStream(encapContentInfo.ContentType.Id, ZLib.DecompressInput(((Asn1OctetStringParser) encapContentInfo.GetContent(4)).GetOctetStream()));
    }
    catch (IOException ex)
    {
      throw new CmsException("IOException reading compressed content.", (Exception) ex);
    }
  }
}
