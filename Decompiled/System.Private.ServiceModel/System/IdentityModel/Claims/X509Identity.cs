using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

internal class X509Identity : GenericIdentity, IDisposable
{
	private const string X509 = "X509";

	private const string Thumbprint = "; ";

	private X500DistinguishedName _x500DistinguishedName;

	private X509Certificate2 _certificate;

	private string _name;

	private bool _disposed;

	private bool _disposable = true;

	public override string Name
	{
		get
		{
			ThrowIfDisposed();
			if (_name == null)
			{
				_name = GetName() + "; " + _certificate.Thumbprint;
			}
			return _name;
		}
	}

	public X509Identity(X509Certificate2 certificate)
		: this(certificate, clone: true, disposable: true)
	{
	}

	public X509Identity(X500DistinguishedName x500DistinguishedName)
		: base("X509", "X509")
	{
		_x500DistinguishedName = x500DistinguishedName;
	}

	internal X509Identity(X509Certificate2 certificate, bool clone, bool disposable)
		: base("X509", "X509")
	{
		_certificate = (clone ? new X509Certificate2(certificate) : certificate);
		_disposable = clone || disposable;
	}

	private string GetName()
	{
		if (_x500DistinguishedName != null)
		{
			return _x500DistinguishedName.Name;
		}
		string name = _certificate.SubjectName.Name;
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		name = _certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		name = _certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		name = _certificate.GetNameInfo(X509NameType.EmailName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		name = _certificate.GetNameInfo(X509NameType.UpnName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		return string.Empty;
	}

	public override ClaimsIdentity Clone()
	{
		if (_certificate == null)
		{
			return new X509Identity(_x500DistinguishedName);
		}
		return new X509Identity(_certificate);
	}

	public void Dispose()
	{
		if (_disposable && !_disposed)
		{
			_disposed = true;
			if (_certificate != null)
			{
				_certificate.Dispose();
			}
		}
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
