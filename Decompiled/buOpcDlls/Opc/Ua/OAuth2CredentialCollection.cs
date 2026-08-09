using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfOAuth2Credential", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "OAuth2Credential")]
[ComVisible(true)]
public class OAuth2CredentialCollection : List<OAuth2Credential>
{
	public static OAuth2CredentialCollection Load(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		OAuth2CredentialCollection oAuth2CredentialCollection = null;
		lock (configuration.PropertiesLock)
		{
			object value = null;
			if (configuration.Properties.TryGetValue("OAuth2Credentials", out value))
			{
				oAuth2CredentialCollection = value as OAuth2CredentialCollection;
			}
			if (oAuth2CredentialCollection == null)
			{
				oAuth2CredentialCollection = configuration.ParseExtension<OAuth2CredentialCollection>();
				if (oAuth2CredentialCollection == null)
				{
					oAuth2CredentialCollection = new OAuth2CredentialCollection();
				}
				configuration.Properties["OAuth2Credentials"] = oAuth2CredentialCollection;
			}
		}
		return oAuth2CredentialCollection;
	}

	public static OAuth2Credential FindByServerUri(ApplicationConfiguration configuration, string serverApplicationUri)
	{
		if (serverApplicationUri == null || !Uri.IsWellFormedUriString(serverApplicationUri, UriKind.Absolute))
		{
			throw new ArgumentException("Invalid application Uri specified.", "serverApplicationUri");
		}
		OAuth2CredentialCollection oAuth2CredentialCollection = Load(configuration);
		if (oAuth2CredentialCollection != null)
		{
			foreach (OAuth2Credential item in oAuth2CredentialCollection)
			{
				if (item.Servers == null || item.Servers.Count <= 0)
				{
					continue;
				}
				foreach (OAuth2ServerSettings server in item.Servers)
				{
					if (server.ApplicationUri.Replace("localhost", Dns.GetHostName().ToLowerInvariant()) == serverApplicationUri)
					{
						return new OAuth2Credential
						{
							AuthorityUrl = item.AuthorityUrl,
							GrantType = item.GrantType,
							ClientId = item.ClientId,
							ClientSecret = item.ClientSecret,
							RedirectUrl = item.RedirectUrl,
							TokenEndpoint = item.TokenEndpoint,
							AuthorizationEndpoint = item.AuthorizationEndpoint,
							SelectedServer = server
						};
					}
				}
			}
		}
		return null;
	}

	public static OAuth2Credential FindByAuthorityUrl(ApplicationConfiguration configuration, string authorityUrl)
	{
		if (authorityUrl == null || !Uri.IsWellFormedUriString(authorityUrl, UriKind.Absolute))
		{
			throw new ArgumentException("The authority Url is invalid.", "authorityUrl");
		}
		if (!authorityUrl.EndsWith("/"))
		{
			authorityUrl += "/";
		}
		OAuth2CredentialCollection oAuth2CredentialCollection = Load(configuration);
		if (oAuth2CredentialCollection != null)
		{
			foreach (OAuth2Credential item in oAuth2CredentialCollection)
			{
				string text = item.AuthorityUrl.Replace("localhost", Dns.GetHostName().ToLowerInvariant());
				if (!text.EndsWith("/", StringComparison.Ordinal))
				{
					text += "/";
				}
				if (string.Equals(text, authorityUrl, StringComparison.OrdinalIgnoreCase))
				{
					return new OAuth2Credential
					{
						AuthorityUrl = authorityUrl,
						GrantType = item.GrantType,
						ClientId = item.ClientId,
						ClientSecret = item.ClientSecret,
						RedirectUrl = item.RedirectUrl,
						TokenEndpoint = item.TokenEndpoint,
						AuthorizationEndpoint = item.AuthorizationEndpoint
					};
				}
			}
		}
		return null;
	}
}
