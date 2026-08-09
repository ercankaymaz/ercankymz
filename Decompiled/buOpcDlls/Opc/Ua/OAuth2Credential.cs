using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OAuth2Credential
{
	[DataMember(Order = 1)]
	public string AuthorityUrl { get; set; }

	[DataMember(Order = 2)]
	public string GrantType { get; set; }

	[DataMember(Order = 3)]
	public string ClientId { get; set; }

	[DataMember(Order = 4)]
	public string ClientSecret { get; set; }

	[DataMember(Order = 5)]
	public string RedirectUrl { get; set; }

	[DataMember(Order = 6)]
	public string TokenEndpoint { get; set; }

	[DataMember(Order = 7)]
	public string AuthorizationEndpoint { get; set; }

	[DataMember(Order = 8)]
	public OAuth2ServerSettingsCollection Servers { get; set; }

	public OAuth2ServerSettings SelectedServer { get; set; }

	public OAuth2Credential()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
	}
}
