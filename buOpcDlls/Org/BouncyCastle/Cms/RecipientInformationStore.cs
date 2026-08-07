// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.RecipientInformationStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class RecipientInformationStore
{
  private readonly IList<RecipientInformation> m_all;
  private readonly IDictionary<RecipientID, IList<RecipientInformation>> m_table = (IDictionary<RecipientID, IList<RecipientInformation>>) new Dictionary<RecipientID, IList<RecipientInformation>>();

  public RecipientInformationStore(IEnumerable<RecipientInformation> recipientInfos)
  {
    foreach (RecipientInformation recipientInfo in recipientInfos)
    {
      RecipientID recipientId = recipientInfo.RecipientID;
      IList<RecipientInformation> recipientInformationList;
      if (!this.m_table.TryGetValue(recipientId, out recipientInformationList))
        this.m_table[recipientId] = recipientInformationList = (IList<RecipientInformation>) new List<RecipientInformation>(1);
      recipientInformationList.Add(recipientInfo);
    }
    this.m_all = (IList<RecipientInformation>) new List<RecipientInformation>(recipientInfos);
  }

  public RecipientInformation this[RecipientID selector] => this.GetFirstRecipient(selector);

  public RecipientInformation GetFirstRecipient(RecipientID selector)
  {
    IList<RecipientInformation> recipientInformationList;
    return !this.m_table.TryGetValue(selector, out recipientInformationList) ? (RecipientInformation) null : recipientInformationList[0];
  }

  public int Count => this.m_all.Count;

  public IList<RecipientInformation> GetRecipients()
  {
    return (IList<RecipientInformation>) new List<RecipientInformation>((IEnumerable<RecipientInformation>) this.m_all);
  }

  public IList<RecipientInformation> GetRecipients(RecipientID selector)
  {
    IList<RecipientInformation> collection;
    return !this.m_table.TryGetValue(selector, out collection) ? (IList<RecipientInformation>) new List<RecipientInformation>(0) : (IList<RecipientInformation>) new List<RecipientInformation>((IEnumerable<RecipientInformation>) collection);
  }
}
