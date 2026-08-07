// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OAuth2CredentialCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfOAuth2Credential", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "OAuth2Credential")]
[ComVisible(true)]
public class OAuth2CredentialCollection : List<OAuth2Credential>
{
  public static OAuth2CredentialCollection Load(ApplicationConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    OAuth2CredentialCollection credentialCollection = (OAuth2CredentialCollection) null;
    lock (configuration.PropertiesLock)
    {
      object obj = (object) null;
      if (configuration.Properties.TryGetValue("OAuth2Credentials", out obj))
        credentialCollection = obj as OAuth2CredentialCollection;
      if (credentialCollection == null)
      {
        credentialCollection = configuration.ParseExtension<OAuth2CredentialCollection>() ?? new OAuth2CredentialCollection();
        configuration.Properties["OAuth2Credentials"] = (object) credentialCollection;
      }
    }
    return credentialCollection;
  }

  public static OAuth2Credential FindByServerUri(
    ApplicationConfiguration configuration,
    string serverApplicationUri)
  {
    if (serverApplicationUri == null || !Uri.IsWellFormedUriString(serverApplicationUri, UriKind.Absolute))
      throw new ArgumentException("Invalid application Uri specified.", nameof (serverApplicationUri));
    OAuth2CredentialCollection credentialCollection = OAuth2CredentialCollection.Load(configuration);
    if (credentialCollection != null)
    {
      foreach (OAuth2Credential oauth2Credential in (List<OAuth2Credential>) credentialCollection)
      {
        if (oauth2Credential.Servers != null && oauth2Credential.Servers.Count > 0)
        {
          foreach (OAuth2ServerSettings server in (List<OAuth2ServerSettings>) oauth2Credential.Servers)
          {
            if (server.ApplicationUri.Replace("localhost", Dns.GetHostName().ToLowerInvariant()) == serverApplicationUri)
              return new OAuth2Credential()
              {
                AuthorityUrl = oauth2Credential.AuthorityUrl,
                GrantType = oauth2Credential.GrantType,
                ClientId = oauth2Credential.ClientId,
                ClientSecret = oauth2Credential.ClientSecret,
                RedirectUrl = oauth2Credential.RedirectUrl,
                TokenEndpoint = oauth2Credential.TokenEndpoint,
                AuthorizationEndpoint = oauth2Credential.AuthorizationEndpoint,
                SelectedServer = server
              };
          }
        }
      }
    }
    return (OAuth2Credential) null;
  }

  public static OAuth2Credential FindByAuthorityUrl(
    ApplicationConfiguration configuration,
    string authorityUrl)
  {
    if (authorityUrl == null || !Uri.IsWellFormedUriString(authorityUrl, UriKind.Absolute))
      throw new ArgumentException("The authority Url is invalid.", nameof (authorityUrl));
    if (!authorityUrl.EndsWith("/"))
      authorityUrl += "/";
    OAuth2CredentialCollection credentialCollection = OAuth2CredentialCollection.Load(configuration);
    if (credentialCollection != null)
    {
      foreach (OAuth2Credential oauth2Credential in (List<OAuth2Credential>) credentialCollection)
      {
        string a = oauth2Credential.AuthorityUrl.Replace("localhost", Dns.GetHostName().ToLowerInvariant());
        if (!a.EndsWith("/", StringComparison.Ordinal))
          a += "/";
        if (string.Equals(a, authorityUrl, StringComparison.OrdinalIgnoreCase))
          return new OAuth2Credential()
          {
            AuthorityUrl = authorityUrl,
            GrantType = oauth2Credential.GrantType,
            ClientId = oauth2Credential.ClientId,
            ClientSecret = oauth2Credential.ClientSecret,
            RedirectUrl = oauth2Credential.RedirectUrl,
            TokenEndpoint = oauth2Credential.TokenEndpoint,
            AuthorizationEndpoint = oauth2Credential.AuthorizationEndpoint
          };
      }
    }
    return (OAuth2Credential) null;
  }
}
