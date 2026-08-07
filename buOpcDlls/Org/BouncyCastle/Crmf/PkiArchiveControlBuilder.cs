// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.PkiArchiveControlBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class PkiArchiveControlBuilder
{
  private CmsEnvelopedDataGenerator envGen;
  private CmsProcessableByteArray keyContent;

  public PkiArchiveControlBuilder(PrivateKeyInfo privateKeyInfo, GeneralName generalName)
  {
    EncKeyWithID encKeyWithId = new EncKeyWithID(privateKeyInfo, generalName);
    try
    {
      this.keyContent = new CmsProcessableByteArray(CrmfObjectIdentifiers.id_ct_encKeyWithID, encKeyWithId.GetEncoded());
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException("unable to encode key and general name info", (Exception) ex);
    }
    this.envGen = new CmsEnvelopedDataGenerator();
  }

  public PkiArchiveControlBuilder AddRecipientGenerator(RecipientInfoGenerator recipientGen)
  {
    this.envGen.AddRecipientInfoGenerator(recipientGen);
    return this;
  }

  public PkiArchiveControl Build(ICipherBuilderWithKey contentEncryptor)
  {
    return new PkiArchiveControl(new PkiArchiveOptions(new EncryptedKey(EnvelopedData.GetInstance((object) this.envGen.Generate((CmsProcessable) this.keyContent, contentEncryptor).ContentInfo.Content))));
  }
}
