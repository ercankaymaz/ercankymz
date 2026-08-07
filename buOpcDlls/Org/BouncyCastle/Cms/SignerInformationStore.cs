// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.SignerInformationStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class SignerInformationStore
{
  private readonly IList<SignerInformation> m_all;
  private readonly IDictionary<SignerID, IList<SignerInformation>> m_table = (IDictionary<SignerID, IList<SignerInformation>>) new Dictionary<SignerID, IList<SignerInformation>>();

  public SignerInformationStore(SignerInformation signerInfo)
  {
    this.m_all = (IList<SignerInformation>) new List<SignerInformation>(1);
    this.m_all.Add(signerInfo);
    this.m_table[signerInfo.SignerID] = this.m_all;
  }

  public SignerInformationStore(IEnumerable<SignerInformation> signerInfos)
  {
    this.m_all = (IList<SignerInformation>) new List<SignerInformation>(signerInfos);
    foreach (SignerInformation signerInfo in signerInfos)
    {
      SignerID signerId = signerInfo.SignerID;
      IList<SignerInformation> signerInformationList;
      if (!this.m_table.TryGetValue(signerId, out signerInformationList))
      {
        signerInformationList = (IList<SignerInformation>) new List<SignerInformation>(1);
        this.m_table[signerId] = signerInformationList;
      }
      signerInformationList.Add(signerInfo);
    }
  }

  public SignerInformation GetFirstSigner(SignerID selector)
  {
    IList<SignerInformation> signerInformationList;
    return this.m_table.TryGetValue(selector, out signerInformationList) ? signerInformationList[0] : (SignerInformation) null;
  }

  public int Count => this.m_all.Count;

  public IList<SignerInformation> GetSigners()
  {
    return (IList<SignerInformation>) new List<SignerInformation>((IEnumerable<SignerInformation>) this.m_all);
  }

  public IList<SignerInformation> GetSigners(SignerID selector)
  {
    IList<SignerInformation> collection;
    return this.m_table.TryGetValue(selector, out collection) ? (IList<SignerInformation>) new List<SignerInformation>((IEnumerable<SignerInformation>) collection) : (IList<SignerInformation>) new List<SignerInformation>(0);
  }
}
