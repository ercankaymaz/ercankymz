using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ServerProperties
{
	private string m_productUri;

	private string m_productName;

	private string m_manufacturerName;

	private string m_softwareVersion;

	private string m_buildNumber;

	private DateTime m_buildDate;

	private StringCollection m_datatypeAssemblies;

	private SignedSoftwareCertificateCollection m_softwareCertificates;

	public string ProductUri
	{
		get
		{
			return m_productUri;
		}
		set
		{
			m_productUri = value;
		}
	}

	public string ProductName
	{
		get
		{
			return m_productName;
		}
		set
		{
			m_productName = value;
		}
	}

	public string ManufacturerName
	{
		get
		{
			return m_manufacturerName;
		}
		set
		{
			m_manufacturerName = value;
		}
	}

	public string SoftwareVersion
	{
		get
		{
			return m_softwareVersion;
		}
		set
		{
			m_softwareVersion = value;
		}
	}

	public string BuildNumber
	{
		get
		{
			return m_buildNumber;
		}
		set
		{
			m_buildNumber = value;
		}
	}

	public DateTime BuildDate
	{
		get
		{
			return m_buildDate;
		}
		set
		{
			m_buildDate = value;
		}
	}

	public StringCollection DatatypeAssemblies => m_datatypeAssemblies;

	public SignedSoftwareCertificateCollection SoftwareCertificates => m_softwareCertificates;

	public ServerProperties()
	{
		m_productUri = string.Empty;
		m_manufacturerName = string.Empty;
		m_productName = string.Empty;
		m_softwareVersion = string.Empty;
		m_buildNumber = string.Empty;
		m_buildDate = DateTime.MinValue;
		m_datatypeAssemblies = new StringCollection();
		m_softwareCertificates = new SignedSoftwareCertificateCollection();
	}
}
