using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Numerics;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;

namespace System.ServiceModel.Channels;

internal static class HttpTransportSecurityHelpers
{
	private static Dictionary<string, int> s_targetNameCounter = new Dictionary<string, int>();

	public static void AddIdentityMapping(EndpointAddress target, Message message)
	{
		string value = GeIdentityHostHeader(target);
		if (!message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out HttpRequestMessageProperty property))
		{
			property = new HttpRequestMessageProperty();
			message.Properties.Add(HttpRequestMessageProperty.Name, property);
		}
		property.Headers[HttpRequestHeader.Host] = value;
	}

	public static string GeIdentityHostHeader(EndpointAddress target)
	{
		EndpointIdentity identity = target.Identity;
		string text = ((identity == null || identity is X509CertificateEndpointIdentity) ? SecurityUtils.GetSpnFromTarget(target) : SecurityUtils.GetSpnFromIdentity(identity, target));
		if (!text.StartsWith("host/", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("http/", StringComparison.OrdinalIgnoreCase))
		{
			throw Fx.Exception.AsError(new InvalidOperationException(System.SR.OnlyDefaultSpnServiceSupported));
		}
		return text.Substring(5);
	}

	public static void AddServerCertIdentityValidation(HttpClientHandler httpClientHandler, EndpointAddress to)
	{
		byte[] rawData;
		string thumbprint;
		if (to.Identity is X509CertificateEndpointIdentity x509CertificateEndpointIdentity)
		{
			rawData = x509CertificateEndpointIdentity.Certificates[0].GetRawCertData();
			thumbprint = x509CertificateEndpointIdentity.Certificates[0].Thumbprint;
			SetServerCertificateValidationCallback(httpClientHandler, identityValidator);
		}
		bool identityValidator(HttpRequestMessage requestMessage, X509Certificate2 cert, X509Chain chain, SslPolicyErrors policyErrors)
		{
			try
			{
				ValidateServerCertificate(cert, rawData, thumbprint);
			}
			catch (SecurityNegotiationException exception)
			{
				DiagnosticUtility.TraceHandledException(exception, TraceEventType.Information);
				return false;
			}
			return policyErrors == SslPolicyErrors.None;
		}
	}

	public static void SetServerCertificateValidationCallback(HttpClientHandler handler, Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> validator)
	{
		handler.ServerCertificateCustomValidationCallback = ChainValidator(handler.ServerCertificateCustomValidationCallback, validator);
	}

	private static Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> ChainValidator(Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> previousValidator, Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> validator)
	{
		if (previousValidator == null)
		{
			return validator;
		}
		return chained;
		bool chained(HttpRequestMessage request, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (validator(request, certificate, chain, sslPolicyErrors))
			{
				return previousValidator(request, certificate, chain, sslPolicyErrors);
			}
			return false;
		}
	}

	private static void ValidateServerCertificate(X509Certificate2 certificate, byte[] rawData, string thumbprint)
	{
		byte[] rawCertData = certificate.GetRawCertData();
		bool flag = true;
		if (rawData.Length != rawCertData.Length)
		{
			flag = false;
		}
		else
		{
			int i = 0;
			while (true)
			{
				if (i + Vector<byte>.Count > rawCertData.Length)
				{
					for (; i < rawCertData.Length; i++)
					{
						if (rawCertData[i] != rawData[i])
						{
							flag = false;
							break;
						}
					}
					break;
				}
				Vector<byte> vector = new Vector<byte>(rawCertData, i);
				Vector<byte> other = new Vector<byte>(rawData, i);
				if (!vector.Equals(other))
				{
					flag = false;
					break;
				}
				i += Vector<byte>.Count;
			}
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.HttpsServerCertThumbprintMismatch, certificate.Subject, certificate.Thumbprint, thumbprint)));
		}
	}
}
