// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.PkiArchiveControl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Cms;
using System;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class PkiArchiveControl : IControl
{
  public static readonly int encryptedPrivKey = 0;
  public static readonly int keyGenParameters = 1;
  public static readonly int archiveRemGenPrivKey = 2;
  private static readonly DerObjectIdentifier type = CrmfObjectIdentifiers.id_regCtrl_pkiArchiveOptions;
  private readonly PkiArchiveOptions pkiArchiveOptions;

  public PkiArchiveControl(PkiArchiveOptions pkiArchiveOptions)
  {
    this.pkiArchiveOptions = pkiArchiveOptions;
  }

  public DerObjectIdentifier Type => PkiArchiveControl.type;

  public Asn1Encodable Value => (Asn1Encodable) this.pkiArchiveOptions;

  public int ArchiveType => this.pkiArchiveOptions.Type;

  public bool EnvelopedData
  {
    get => !EncryptedKey.GetInstance((object) this.pkiArchiveOptions.Value).IsEncryptedValue;
  }

  public CmsEnvelopedData GetEnvelopedData()
  {
    try
    {
      Org.BouncyCastle.Asn1.Cms.EnvelopedData instance = Org.BouncyCastle.Asn1.Cms.EnvelopedData.GetInstance((object) EncryptedKey.GetInstance((object) this.pkiArchiveOptions.Value).Value);
      return new CmsEnvelopedData(new ContentInfo(CmsObjectIdentifiers.EnvelopedData, (Asn1Encodable) instance));
    }
    catch (CmsException ex)
    {
      throw new CrmfException("CMS parsing error: " + ex.Message, (Exception) ex);
    }
    catch (Exception ex)
    {
      throw new CrmfException("CRMF parsing error: " + ex.Message, ex);
    }
  }
}
