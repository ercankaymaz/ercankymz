// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.SessionConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof (UserIdentityToken))]
[KnownType(typeof (AnonymousIdentityToken))]
[KnownType(typeof (X509IdentityToken))]
[KnownType(typeof (IssuedIdentityToken))]
[KnownType(typeof (UserIdentity))]
[ComVisible(true)]
public class SessionConfiguration
{
  internal SessionConfiguration(ISession session, byte[] serverNonce, NodeId authenthicationToken)
  {
    this.Timestamp = DateTime.UtcNow;
    this.SessionName = session.SessionName;
    this.SessionId = session.SessionId;
    this.AuthenticationToken = authenthicationToken;
    this.Identity = session.Identity;
    this.ConfiguredEndpoint = session.ConfiguredEndpoint;
    this.CheckDomain = session.CheckDomain;
    this.ServerNonce = serverNonce;
  }

  public static SessionConfiguration Create(Stream stream)
  {
    XmlReaderSettings settings = Utils.DefaultXmlReaderSettings();
    using (XmlReader reader = XmlReader.Create(stream, settings))
      return (SessionConfiguration) new DataContractSerializer(typeof (SessionConfiguration)).ReadObject(reader);
  }

  [DataMember(IsRequired = true, Order = 10)]
  public DateTime Timestamp { get; set; }

  [DataMember(IsRequired = true, Order = 20)]
  public string SessionName { get; set; }

  [DataMember(IsRequired = true, Order = 30)]
  public NodeId SessionId { get; set; }

  [DataMember(IsRequired = true, Order = 40)]
  public NodeId AuthenticationToken { get; set; }

  [DataMember(IsRequired = true, Order = 50)]
  public IUserIdentity Identity { get; set; }

  [DataMember(IsRequired = true, Order = 60)]
  public ConfiguredEndpoint ConfiguredEndpoint { get; set; }

  [DataMember(IsRequired = false, Order = 70)]
  public bool CheckDomain { get; set; }

  [DataMember(IsRequired = true, Order = 80 /*0x50*/)]
  public byte[] ServerNonce { get; set; }
}
