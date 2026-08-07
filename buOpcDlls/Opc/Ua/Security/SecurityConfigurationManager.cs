// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.SecurityConfigurationManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua.Security;

[ComVisible(true)]
public class SecurityConfigurationManager : ISecurityConfigurationManager
{
  public SecuredApplication ReadConfiguration(string filePath)
  {
    string path = filePath != null ? filePath : throw new ArgumentNullException(nameof (filePath));
    string str = (string) null;
    if (!File.Exists(filePath))
      throw ServiceResultException.Create(2151284736U /*0x803A0000*/, "Cannot find the executable or configuration file: {0}", (object) filePath);
    if (filePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
    {
      str = filePath;
      try
      {
        FileInfo fileInfo = new FileInfo(filePath);
        string name = fileInfo.Name;
        path = ApplicationConfiguration.GetFilePathFromAppConfig(name.Substring(0, name.Length - fileInfo.Extension.Length)) ?? filePath + ".config";
      }
      catch (Exception ex)
      {
        throw ServiceResultException.Create(2151284736U /*0x803A0000*/, ex, "Cannot find the configuration file for the executable: {0}", (object) filePath);
      }
      if (!File.Exists(path))
        throw ServiceResultException.Create(2151284736U /*0x803A0000*/, "Cannot find the configuration file: {0}", (object) path);
    }
    SecuredApplication securedApplication1 = (SecuredApplication) null;
    ApplicationConfiguration applicationConfiguration = (ApplicationConfiguration) null;
    try
    {
      FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      try
      {
        byte[] buffer = new byte[fileStream.Length];
        fileStream.Read(buffer, 0, (int) fileStream.Length);
        if (buffer.ToString().Contains("SecuredApplication"))
        {
          securedApplication1 = new DataContractSerializer(typeof (SecuredApplication)).ReadObject((Stream) fileStream) as SecuredApplication;
          securedApplication1.ConfigurationFile = path;
          securedApplication1.ExecutableFile = str;
        }
        else
        {
          fileStream.Dispose();
          fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
          applicationConfiguration = new DataContractSerializer(typeof (ApplicationConfiguration)).ReadObject((Stream) fileStream) as ApplicationConfiguration;
        }
      }
      finally
      {
        fileStream.Dispose();
      }
    }
    catch (Exception ex)
    {
      throw ServiceResultException.Create(2151284736U /*0x803A0000*/, ex, "Cannot load the configuration file: {0}", (object) filePath);
    }
    if (securedApplication1 != null)
      return securedApplication1;
    SecuredApplication securedApplication2 = new SecuredApplication();
    securedApplication2.ApplicationName = applicationConfiguration.ApplicationName;
    securedApplication2.ApplicationUri = applicationConfiguration.ApplicationUri;
    securedApplication2.ProductName = applicationConfiguration.ProductUri;
    securedApplication2.ApplicationType = (ApplicationType) applicationConfiguration.ApplicationType;
    securedApplication2.ConfigurationFile = path;
    securedApplication2.ExecutableFile = str;
    securedApplication2.ConfigurationMode = "http://opcfoundation.org/UASDK/ConfigurationTool";
    securedApplication2.LastExportTime = DateTime.UtcNow;
    if (applicationConfiguration.SecurityConfiguration != null)
    {
      securedApplication2.ApplicationCertificate = SecuredApplication.ToCertificateIdentifier(applicationConfiguration.SecurityConfiguration.ApplicationCertificate);
      if (applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates != null)
      {
        securedApplication2.IssuerCertificateStore = SecuredApplication.ToCertificateStoreIdentifier((Opc.Ua.CertificateStoreIdentifier) applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates);
        if (applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates != null)
          securedApplication2.IssuerCertificates = SecuredApplication.ToCertificateList(applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates);
      }
      if (applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates != null)
      {
        securedApplication2.TrustedCertificateStore = SecuredApplication.ToCertificateStoreIdentifier((Opc.Ua.CertificateStoreIdentifier) applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates);
        if (applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates != null)
          securedApplication2.TrustedCertificates = SecuredApplication.ToCertificateList(applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates);
      }
      if (applicationConfiguration.SecurityConfiguration.RejectedCertificateStore != null)
        securedApplication2.RejectedCertificatesStore = SecuredApplication.ToCertificateStoreIdentifier(applicationConfiguration.SecurityConfiguration.RejectedCertificateStore);
    }
    ServerBaseConfiguration configuration = (ServerBaseConfiguration) null;
    if (applicationConfiguration.ServerConfiguration != null)
      configuration = (ServerBaseConfiguration) applicationConfiguration.ServerConfiguration;
    else if (applicationConfiguration.DiscoveryServerConfiguration != null)
      configuration = (ServerBaseConfiguration) applicationConfiguration.DiscoveryServerConfiguration;
    if (configuration != null)
    {
      securedApplication2.BaseAddresses = SecuredApplication.ToListOfBaseAddresses(configuration);
      securedApplication2.SecurityProfiles = SecuredApplication.ToListOfSecurityProfiles(configuration.SecurityPolicies);
    }
    return securedApplication2;
  }

  private XmlElement Find(XmlNode parent, string localName, string namespaceUri)
  {
    for (XmlNode parent1 = parent.FirstChild; parent1 != null; parent1 = parent1.NextSibling)
    {
      if (parent1 is XmlElement && parent1.LocalName == "SecuredApplication" && parent1.NamespaceURI == "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")
        return (XmlElement) parent1;
      XmlElement xmlElement = this.Find(parent1, localName, namespaceUri);
      if (xmlElement != null)
        return xmlElement;
    }
    return (XmlElement) null;
  }

  public void WriteConfiguration(string filePath, SecuredApplication configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
    {
      XmlDocument xmlDocument = new XmlDocument();
      using (FileStream input = new FileStream(filePath, FileMode.Open))
      {
        using (XmlReader reader = XmlReader.Create((Stream) input, Utils.DefaultXmlReaderSettings()))
          xmlDocument.Load(reader);
      }
      XmlElement xmlElement = this.Find((XmlNode) xmlDocument.DocumentElement, "SecuredApplication", "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd");
      if (xmlElement != null)
      {
        configuration.LastExportTime = DateTime.UtcNow;
        xmlElement.InnerXml = SecurityConfigurationManager.SetObject(typeof (SecuredApplication), (object) configuration);
      }
      else
        SecurityConfigurationManager.UpdateDocument(xmlDocument.DocumentElement, configuration);
      try
      {
        StreamWriter writer = new StreamWriter((Stream) File.Open(filePath, FileMode.Create, FileAccess.Write), Encoding.UTF8);
        try
        {
          xmlDocument.Save((TextWriter) writer);
        }
        finally
        {
          writer.Flush();
          writer.Dispose();
        }
      }
      catch (Exception ex)
      {
        throw ServiceResultException.Create(2151350272U /*0x803B0000*/, ex, "Cannot update the configuration file: {0}", (object) configuration.ConfigurationFile);
      }
    }
    else
      throw ServiceResultException.Create(2151284736U /*0x803A0000*/, "Cannot find the configuration file: {0}", (object) configuration.ConfigurationFile);
  }

  private static void UpdateDocument(XmlElement element, SecuredApplication application)
  {
    for (XmlNode element1 = element.FirstChild; element1 != null; element1 = element1.NextSibling)
    {
      if (element1.Name == "ApplicationName" && element1.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
        element1.InnerText = application.ApplicationName;
      else if (element1.Name == "ApplicationUri" && element1.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
        element1.InnerText = application.ApplicationUri;
      else if (element1.Name == "SecurityConfiguration" && element1.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
      {
        SecurityConfiguration securityConfiguration = (SecurityConfiguration) SecurityConfigurationManager.GetObject(typeof (SecurityConfiguration), element1);
        if (application.ApplicationCertificate != null)
          securityConfiguration.ApplicationCertificate = SecuredApplication.FromCertificateIdentifier(application.ApplicationCertificate);
        securityConfiguration.TrustedIssuerCertificates = SecuredApplication.FromCertificateStoreIdentifierToTrustList(application.IssuerCertificateStore);
        securityConfiguration.TrustedIssuerCertificates.TrustedCertificates = SecuredApplication.FromCertificateList(application.IssuerCertificates);
        securityConfiguration.TrustedPeerCertificates = SecuredApplication.FromCertificateStoreIdentifierToTrustList(application.TrustedCertificateStore);
        securityConfiguration.TrustedPeerCertificates.TrustedCertificates = SecuredApplication.FromCertificateList(application.TrustedCertificates);
        securityConfiguration.RejectedCertificateStore = SecuredApplication.FromCertificateStoreIdentifier(application.RejectedCertificatesStore);
        element1.InnerXml = SecurityConfigurationManager.SetObject(typeof (SecurityConfiguration), (object) securityConfiguration);
      }
      else if (element1.Name == "ServerConfiguration" && element1.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
      {
        ServerConfiguration configuration = (ServerConfiguration) SecurityConfigurationManager.GetObject(typeof (ServerConfiguration), element1);
        SecuredApplication.FromListOfBaseAddresses((ServerBaseConfiguration) configuration, application.BaseAddresses);
        configuration.SecurityPolicies = SecuredApplication.FromListOfSecurityProfiles(application.SecurityProfiles);
        element1.InnerXml = SecurityConfigurationManager.SetObject(typeof (ServerConfiguration), (object) configuration);
      }
      else if (element1.Name == "DiscoveryServerConfiguration" && element1.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
      {
        DiscoveryServerConfiguration configuration = (DiscoveryServerConfiguration) SecurityConfigurationManager.GetObject(typeof (DiscoveryServerConfiguration), element1);
        SecuredApplication.FromListOfBaseAddresses((ServerBaseConfiguration) configuration, application.BaseAddresses);
        configuration.SecurityPolicies = SecuredApplication.FromListOfSecurityProfiles(application.SecurityProfiles);
        element1.InnerXml = SecurityConfigurationManager.SetObject(typeof (DiscoveryServerConfiguration), (object) configuration);
      }
    }
  }

  private static object GetObject(Type type, XmlNode element)
  {
    using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(element.InnerXml)))
    {
      XmlDictionaryReader textReader = XmlDictionaryReader.CreateTextReader((Stream) memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), (OnXmlDictionaryReaderClose) null);
      return new DataContractSerializer(type).ReadObject(textReader);
    }
  }

  private static string SetObject(Type type, object value)
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      new DataContractSerializer(value.GetType()).WriteObject((Stream) memoryStream, value);
      XmlDocument doc = new XmlDocument();
      doc.LoadInnerXml(Encoding.UTF8.GetString(memoryStream.ToArray()));
      return doc.DocumentElement.InnerXml;
    }
  }
}
