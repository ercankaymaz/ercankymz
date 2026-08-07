// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.OcspStatusRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class OcspStatusRequest
{
  private readonly IList<ResponderID> m_responderIDList;
  private readonly X509Extensions m_requestExtensions;

  public OcspStatusRequest(IList<ResponderID> responderIDList, X509Extensions requestExtensions)
  {
    this.m_responderIDList = responderIDList;
    this.m_requestExtensions = requestExtensions;
  }

  public IList<ResponderID> ResponderIDList => this.m_responderIDList;

  public X509Extensions RequestExtensions => this.m_requestExtensions;

  public void Encode(Stream output)
  {
    if (this.m_responderIDList != null && this.m_responderIDList.Count >= 1)
    {
      MemoryStream output1 = new MemoryStream();
      foreach (Asn1Encodable responderId in (IEnumerable<ResponderID>) this.m_responderIDList)
        TlsUtilities.WriteOpaque16(responderId.GetEncoded("DER"), (Stream) output1);
      TlsUtilities.CheckUint16(output1.Length);
      TlsUtilities.WriteUint16(Convert.ToInt32(output1.Length), output);
      output1.WriteTo(output);
    }
    else
      TlsUtilities.WriteUint16(0, output);
    if (this.m_requestExtensions == null)
    {
      TlsUtilities.WriteUint16(0, output);
    }
    else
    {
      byte[] encoded = this.m_requestExtensions.GetEncoded("DER");
      TlsUtilities.CheckUint16(encoded.Length);
      TlsUtilities.WriteUint16(encoded.Length, output);
      output.Write(encoded, 0, encoded.Length);
    }
  }

  public static OcspStatusRequest Parse(Stream input)
  {
    List<ResponderID> responderIDList = new List<ResponderID>();
    byte[] buffer = TlsUtilities.ReadOpaque16(input);
    if (buffer.Length != 0)
    {
      MemoryStream input1 = new MemoryStream(buffer, false);
      do
      {
        byte[] encoding = TlsUtilities.ReadOpaque16((Stream) input1, 1);
        ResponderID instance = ResponderID.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
        TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding);
        responderIDList.Add(instance);
      }
      while (input1.Position < input1.Length);
    }
    X509Extensions requestExtensions = (X509Extensions) null;
    byte[] encoding1 = TlsUtilities.ReadOpaque16(input);
    if (encoding1.Length != 0)
    {
      X509Extensions instance = X509Extensions.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding1));
      TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding1);
      requestExtensions = instance;
    }
    return new OcspStatusRequest((IList<ResponderID>) responderIDList, requestExtensions);
  }
}
