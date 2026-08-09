using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Opc.Ua.Security;

[ComVisible(true)]
public class SecurityConfigurationManager : ISecurityConfigurationManager
{
	public SecuredApplication ReadConfiguration(string filePath)
	{
		if (filePath == null)
		{
			throw new ArgumentNullException("filePath");
		}
		string text = filePath;
		string executableFile = null;
		if (!File.Exists(filePath))
		{
			throw ServiceResultException.Create(2151284736u, "Cannot find the executable or configuration file: {0}", filePath);
		}
		if (filePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
		{
			executableFile = filePath;
			try
			{
				FileInfo fileInfo = new FileInfo(filePath);
				string name = fileInfo.Name;
				name = name.Substring(0, name.Length - fileInfo.Extension.Length);
				text = ApplicationConfiguration.GetFilePathFromAppConfig(name);
				if (text == null)
				{
					text = filePath + ".config";
				}
			}
			catch (Exception e)
			{
				throw ServiceResultException.Create(2151284736u, e, "Cannot find the configuration file for the executable: {0}", filePath);
			}
			if (!File.Exists(text))
			{
				throw ServiceResultException.Create(2151284736u, "Cannot find the configuration file: {0}", text);
			}
		}
		SecuredApplication securedApplication = null;
		ApplicationConfiguration applicationConfiguration = null;
		try
		{
			FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, (int)fileStream.Length);
				if (array.ToString().Contains("SecuredApplication"))
				{
					securedApplication = new DataContractSerializer(typeof(SecuredApplication)).ReadObject(fileStream) as SecuredApplication;
					securedApplication.ConfigurationFile = text;
					securedApplication.ExecutableFile = executableFile;
				}
				else
				{
					fileStream.Dispose();
					fileStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.Read);
					applicationConfiguration = new DataContractSerializer(typeof(ApplicationConfiguration)).ReadObject(fileStream) as ApplicationConfiguration;
				}
			}
			finally
			{
				fileStream.Dispose();
			}
		}
		catch (Exception e2)
		{
			throw ServiceResultException.Create(2151284736u, e2, "Cannot load the configuration file: {0}", filePath);
		}
		if (securedApplication != null)
		{
			return securedApplication;
		}
		securedApplication = new SecuredApplication();
		securedApplication.ApplicationName = applicationConfiguration.ApplicationName;
		securedApplication.ApplicationUri = applicationConfiguration.ApplicationUri;
		securedApplication.ProductName = applicationConfiguration.ProductUri;
		securedApplication.ApplicationType = (ApplicationType)applicationConfiguration.ApplicationType;
		securedApplication.ConfigurationFile = text;
		securedApplication.ExecutableFile = executableFile;
		securedApplication.ConfigurationMode = "http://opcfoundation.org/UASDK/ConfigurationTool";
		securedApplication.LastExportTime = DateTime.UtcNow;
		if (applicationConfiguration.SecurityConfiguration != null)
		{
			securedApplication.ApplicationCertificate = SecuredApplication.ToCertificateIdentifier(applicationConfiguration.SecurityConfiguration.ApplicationCertificate);
			if (applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates != null)
			{
				securedApplication.IssuerCertificateStore = SecuredApplication.ToCertificateStoreIdentifier(applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates);
				if (applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates != null)
				{
					securedApplication.IssuerCertificates = SecuredApplication.ToCertificateList(applicationConfiguration.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates);
				}
			}
			if (applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates != null)
			{
				securedApplication.TrustedCertificateStore = SecuredApplication.ToCertificateStoreIdentifier(applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates);
				if (applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates != null)
				{
					securedApplication.TrustedCertificates = SecuredApplication.ToCertificateList(applicationConfiguration.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates);
				}
			}
			if (applicationConfiguration.SecurityConfiguration.RejectedCertificateStore != null)
			{
				securedApplication.RejectedCertificatesStore = SecuredApplication.ToCertificateStoreIdentifier(applicationConfiguration.SecurityConfiguration.RejectedCertificateStore);
			}
		}
		ServerBaseConfiguration serverBaseConfiguration = null;
		if (applicationConfiguration.ServerConfiguration != null)
		{
			serverBaseConfiguration = applicationConfiguration.ServerConfiguration;
		}
		else if (applicationConfiguration.DiscoveryServerConfiguration != null)
		{
			serverBaseConfiguration = applicationConfiguration.DiscoveryServerConfiguration;
		}
		if (serverBaseConfiguration != null)
		{
			securedApplication.BaseAddresses = SecuredApplication.ToListOfBaseAddresses(serverBaseConfiguration);
			securedApplication.SecurityProfiles = SecuredApplication.ToListOfSecurityProfiles(serverBaseConfiguration.SecurityPolicies);
		}
		return securedApplication;
	}

	private XmlElement Find(XmlNode parent, string localName, string namespaceUri)
	{
		for (XmlNode xmlNode = parent.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode is XmlElement && xmlNode.LocalName == "SecuredApplication" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")
			{
				return (XmlElement)xmlNode;
			}
			XmlElement xmlElement = Find(xmlNode, localName, namespaceUri);
			if (xmlElement != null)
			{
				return xmlElement;
			}
		}
		return null;
	}

	public void WriteConfiguration(string filePath, SecuredApplication configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
		{
			throw ServiceResultException.Create(2151284736u, "Cannot find the configuration file: {0}", configuration.ConfigurationFile);
		}
		XmlDocument xmlDocument = new XmlDocument();
		using (FileStream input = new FileStream(filePath, FileMode.Open))
		{
			using XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
			xmlDocument.Load(reader);
		}
		XmlElement xmlElement = Find(xmlDocument.DocumentElement, "SecuredApplication", "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd");
		if (xmlElement != null)
		{
			configuration.LastExportTime = DateTime.UtcNow;
			xmlElement.InnerXml = SetObject(typeof(SecuredApplication), configuration);
		}
		else
		{
			UpdateDocument(xmlDocument.DocumentElement, configuration);
		}
		try
		{
			StreamWriter streamWriter = new StreamWriter(File.Open(filePath, FileMode.Create, FileAccess.Write), Encoding.UTF8);
			try
			{
				xmlDocument.Save(streamWriter);
			}
			finally
			{
				streamWriter.Flush();
				streamWriter.Dispose();
			}
		}
		catch (Exception e)
		{
			throw ServiceResultException.Create(2151350272u, e, "Cannot update the configuration file: {0}", configuration.ConfigurationFile);
		}
	}

	private static void UpdateDocument(XmlElement element, SecuredApplication application)
	{
		for (XmlNode xmlNode = element.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.Name == "ApplicationName" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
			{
				xmlNode.InnerText = application.ApplicationName;
			}
			else if (xmlNode.Name == "ApplicationUri" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
			{
				xmlNode.InnerText = application.ApplicationUri;
			}
			else if (xmlNode.Name == "SecurityConfiguration" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
			{
				SecurityConfiguration securityConfiguration = (SecurityConfiguration)GetObject(typeof(SecurityConfiguration), xmlNode);
				if (application.ApplicationCertificate != null)
				{
					securityConfiguration.ApplicationCertificate = SecuredApplication.FromCertificateIdentifier(application.ApplicationCertificate);
				}
				securityConfiguration.TrustedIssuerCertificates = SecuredApplication.FromCertificateStoreIdentifierToTrustList(application.IssuerCertificateStore);
				securityConfiguration.TrustedIssuerCertificates.TrustedCertificates = SecuredApplication.FromCertificateList(application.IssuerCertificates);
				securityConfiguration.TrustedPeerCertificates = SecuredApplication.FromCertificateStoreIdentifierToTrustList(application.TrustedCertificateStore);
				securityConfiguration.TrustedPeerCertificates.TrustedCertificates = SecuredApplication.FromCertificateList(application.TrustedCertificates);
				securityConfiguration.RejectedCertificateStore = SecuredApplication.FromCertificateStoreIdentifier(application.RejectedCertificatesStore);
				xmlNode.InnerXml = SetObject(typeof(SecurityConfiguration), securityConfiguration);
			}
			else if (xmlNode.Name == "ServerConfiguration" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
			{
				ServerConfiguration serverConfiguration = (ServerConfiguration)GetObject(typeof(ServerConfiguration), xmlNode);
				SecuredApplication.FromListOfBaseAddresses(serverConfiguration, application.BaseAddresses);
				serverConfiguration.SecurityPolicies = SecuredApplication.FromListOfSecurityProfiles(application.SecurityProfiles);
				xmlNode.InnerXml = SetObject(typeof(ServerConfiguration), serverConfiguration);
			}
			else if (xmlNode.Name == "DiscoveryServerConfiguration" && xmlNode.NamespaceURI == "http://opcfoundation.org/UA/SDK/Configuration.xsd")
			{
				DiscoveryServerConfiguration discoveryServerConfiguration = (DiscoveryServerConfiguration)GetObject(typeof(DiscoveryServerConfiguration), xmlNode);
				SecuredApplication.FromListOfBaseAddresses(discoveryServerConfiguration, application.BaseAddresses);
				discoveryServerConfiguration.SecurityPolicies = SecuredApplication.FromListOfSecurityProfiles(application.SecurityProfiles);
				xmlNode.InnerXml = SetObject(typeof(DiscoveryServerConfiguration), discoveryServerConfiguration);
			}
		}
	}

	private static object GetObject(Type type, XmlNode element)
	{
		using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(element.InnerXml));
		XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
		return new DataContractSerializer(type).ReadObject(reader);
	}

	private static string SetObject(Type type, object value)
	{
		using MemoryStream memoryStream = new MemoryStream();
		new DataContractSerializer(value.GetType()).WriteObject(memoryStream, value);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadInnerXml(Encoding.UTF8.GetString(memoryStream.ToArray()));
		return xmlDocument.DocumentElement.InnerXml;
	}
}
