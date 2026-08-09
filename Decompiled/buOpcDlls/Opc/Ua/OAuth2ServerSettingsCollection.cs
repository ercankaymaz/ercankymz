using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfOAuth2ServerSettings", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "OAuth2ServerSettings")]
[ComVisible(true)]
public class OAuth2ServerSettingsCollection : List<OAuth2ServerSettings>
{
}
