using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof(UserIdentityToken))]
[KnownType(typeof(AnonymousIdentityToken))]
[KnownType(typeof(X509IdentityToken))]
[KnownType(typeof(IssuedIdentityToken))]
[KnownType(typeof(UserIdentity))]
[ComVisible(true)]
public class SessionConfiguration
{
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

	[DataMember(IsRequired = true, Order = 80)]
	public byte[] ServerNonce { get; set; }

	internal SessionConfiguration(ISession session, byte[] serverNonce, NodeId authenthicationToken)
	{
		Timestamp = DateTime.UtcNow;
		SessionName = session.SessionName;
		SessionId = session.SessionId;
		AuthenticationToken = authenthicationToken;
		Identity = session.Identity;
		ConfiguredEndpoint = session.ConfiguredEndpoint;
		CheckDomain = session.CheckDomain;
		ServerNonce = serverNonce;
	}

	public static SessionConfiguration Create(Stream stream)
	{
		XmlReaderSettings settings = Utils.DefaultXmlReaderSettings();
		using XmlReader reader = XmlReader.Create(stream, settings);
		return (SessionConfiguration)new DataContractSerializer(typeof(SessionConfiguration)).ReadObject(reader);
	}
}
