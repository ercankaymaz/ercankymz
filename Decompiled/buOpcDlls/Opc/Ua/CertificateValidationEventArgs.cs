using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class CertificateValidationEventArgs : EventArgs
{
	private readonly ServiceResult m_error;

	private readonly X509Certificate2 m_certificate;

	private bool m_accept;

	private bool m_acceptAll;

	private string m_applicationErrorMsg;

	public ServiceResult Error => m_error;

	public X509Certificate2 Certificate => m_certificate;

	public bool Accept
	{
		get
		{
			return m_accept;
		}
		set
		{
			m_accept = value;
		}
	}

	public bool AcceptAll
	{
		get
		{
			return m_acceptAll;
		}
		set
		{
			m_acceptAll = value;
		}
	}

	public string ApplicationErrorMsg
	{
		get
		{
			return m_applicationErrorMsg;
		}
		set
		{
			m_applicationErrorMsg = value;
		}
	}

	public CertificateValidationEventArgs(ServiceResult error, X509Certificate2 certificate)
	{
		m_error = error;
		m_certificate = certificate;
	}
}
