using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class X509SecurityToken : SecurityToken, IDisposable
{
	private string _id;

	private X509Certificate2 _certificate;

	private ReadOnlyCollection<SecurityKey> _securityKeys;

	private DateTime _effectiveTime = SecurityUtils.MaxUtcDateTime;

	private DateTime _expirationTime = SecurityUtils.MinUtcDateTime;

	private bool _disposed;

	private bool _disposable;

	public override string Id => _id;

	public override ReadOnlyCollection<SecurityKey> SecurityKeys
	{
		get
		{
			ThrowIfDisposed();
			if (_securityKeys == null)
			{
				List<SecurityKey> list = new List<SecurityKey>(1);
				list.Add(new X509AsymmetricSecurityKey(_certificate));
				_securityKeys = list.AsReadOnly();
			}
			return _securityKeys;
		}
	}

	public override DateTime ValidFrom
	{
		get
		{
			ThrowIfDisposed();
			if (_effectiveTime == SecurityUtils.MaxUtcDateTime)
			{
				_effectiveTime = _certificate.NotBefore.ToUniversalTime();
			}
			return _effectiveTime;
		}
	}

	public override DateTime ValidTo
	{
		get
		{
			ThrowIfDisposed();
			if (_expirationTime == SecurityUtils.MinUtcDateTime)
			{
				_expirationTime = _certificate.NotAfter.ToUniversalTime();
			}
			return _expirationTime;
		}
	}

	public X509Certificate2 Certificate
	{
		get
		{
			ThrowIfDisposed();
			return _certificate;
		}
	}

	public X509SecurityToken(X509Certificate2 certificate)
		: this(certificate, SecurityUniqueId.Create().Value)
	{
	}

	public X509SecurityToken(X509Certificate2 certificate, string id)
		: this(certificate, id, clone: true)
	{
	}

	internal X509SecurityToken(X509Certificate2 certificate, bool clone)
		: this(certificate, SecurityUniqueId.Create().Value, clone)
	{
	}

	internal X509SecurityToken(X509Certificate2 certificate, bool clone, bool disposable)
		: this(certificate, SecurityUniqueId.Create().Value, clone, disposable)
	{
	}

	internal X509SecurityToken(X509Certificate2 certificate, string id, bool clone)
		: this(certificate, id, clone, disposable: true)
	{
	}

	internal X509SecurityToken(X509Certificate2 certificate, string id, bool clone, bool disposable)
	{
		if (certificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
		}
		_id = id ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("id");
		_certificate = (clone ? new X509Certificate2(certificate) : certificate);
		_disposable = clone || disposable;
	}

	public virtual void Dispose()
	{
		if (_disposable && !_disposed)
		{
			_disposed = true;
			_certificate.Dispose();
			_certificate = null;
		}
	}

	protected void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
