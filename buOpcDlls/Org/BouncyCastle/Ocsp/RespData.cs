// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.RespData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class RespData : X509ExtensionBase
{
  internal readonly ResponseData data;

  public RespData(ResponseData data) => this.data = data;

  public int Version => this.data.Version.IntValueExact + 1;

  public RespID GetResponderId() => new RespID(this.data.ResponderID);

  public DateTime ProducedAt => this.data.ProducedAt.ToDateTime();

  public SingleResp[] GetResponses()
  {
    Asn1Sequence responses1 = this.data.Responses;
    SingleResp[] responses2 = new SingleResp[responses1.Count];
    for (int index = 0; index != responses2.Length; ++index)
      responses2[index] = new SingleResp(SingleResponse.GetInstance((object) responses1[index]));
    return responses2;
  }

  public X509Extensions ResponseExtensions => this.data.ResponseExtensions;

  protected override X509Extensions GetX509Extensions() => this.ResponseExtensions;
}
