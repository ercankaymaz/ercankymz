using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class HttpChannelUtilities
{
	internal static class StatusDescriptionStrings
	{
		internal const string HttpContentTypeMissing = "Missing Content Type";

		internal const string HttpContentTypeMismatch = "Cannot process the message because the content type '{0}' was not the expected type '{1}'.";

		internal const string HttpStatusServiceActivationException = "System.ServiceModel.ServiceActivationException";
	}

	internal const string HttpStatusCodeExceptionKey = "System.ServiceModel.Channels.HttpInput.HttpStatusCode";

	internal const string HttpStatusDescriptionExceptionKey = "System.ServiceModel.Channels.HttpInput.HttpStatusDescription";

	internal const string HttpRequestHeadersTypeName = "System.Net.Http.Headers.HttpRequestHeaders";

	internal const int ResponseStreamExcerptSize = 1024;

	internal const string MIMEVersionHeader = "MIME-Version";

	internal const string ContentEncodingHeader = "Content-Encoding";

	internal const uint CURLE_SSL_CERTPROBLEM = 58u;

	internal const uint CURLE_SSL_CACERT = 60u;

	internal const uint WININET_E_NAME_NOT_RESOLVED = 2147954407u;

	internal const uint WININET_E_CONNECTION_RESET = 2147954431u;

	internal const uint WININET_E_INCORRECT_HANDLE_STATE = 2147954419u;

	internal const uint ERROR_WINHTTP_SECURE_FAILURE = 2147954575u;

	public static Task<NetworkCredential> GetCredentialAsync(AuthenticationSchemes authenticationScheme, SecurityTokenProviderContainer credentialProvider, OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper, OutWrapper<AuthenticationLevel> authenticationLevelWrapper, TimeSpan timeout)
	{
		impersonationLevelWrapper.Value = TokenImpersonationLevel.None;
		authenticationLevelWrapper.Value = AuthenticationLevel.None;
		if (authenticationScheme == AuthenticationSchemes.Anonymous)
		{
			return Task.FromResult<NetworkCredential>(null);
		}
		return GetCredentialCoreAsync(authenticationScheme, credentialProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static async Task<NetworkCredential> GetCredentialCoreAsync(AuthenticationSchemes authenticationScheme, SecurityTokenProviderContainer credentialProvider, OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper, OutWrapper<AuthenticationLevel> authenticationLevelWrapper, TimeSpan timeout)
	{
		impersonationLevelWrapper.Value = TokenImpersonationLevel.None;
		authenticationLevelWrapper.Value = AuthenticationLevel.None;
		NetworkCredential result;
		switch (authenticationScheme)
		{
		case AuthenticationSchemes.Basic:
			result = await TransportSecurityHelpers.GetUserNameCredentialAsync(credentialProvider, timeout);
			impersonationLevelWrapper.Value = TokenImpersonationLevel.Delegation;
			break;
		case AuthenticationSchemes.Digest:
			result = await TransportSecurityHelpers.GetSspiCredentialAsync(credentialProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
			break;
		case AuthenticationSchemes.Negotiate:
			result = await TransportSecurityHelpers.GetSspiCredentialAsync(credentialProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
			break;
		case AuthenticationSchemes.Ntlm:
		case AuthenticationSchemes.IntegratedWindowsAuthentication:
			result = await TransportSecurityHelpers.GetSspiCredentialAsync(credentialProvider, impersonationLevelWrapper, authenticationLevelWrapper, timeout);
			if (authenticationLevelWrapper.Value == AuthenticationLevel.MutualAuthRequired)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.CredentialDisallowsNtlm));
			}
			break;
		default:
			throw Fx.AssertAndThrow("GetCredential: Invalid authentication scheme");
		}
		return result;
	}

	public static HttpResponseMessage ProcessGetResponseWebException(HttpRequestException requestException, HttpRequestMessage request, HttpAbortReason abortReason)
	{
		Exception innerException = requestException.InnerException;
		if (innerException != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertHttpRequestException(requestException, request, abortReason));
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(requestException.Message, requestException));
	}

	public static Exception ConvertHttpRequestException(HttpRequestException exception, HttpRequestMessage request, HttpAbortReason abortReason)
	{
		uint hResult = (uint)exception.InnerException.HResult;
		if (exception.InnerException is SocketException { SocketErrorCode: var socketErrorCode } && (uint)(socketErrorCode - 11001) <= 3u)
		{
			return new EndpointNotFoundException(System.SR.Format(System.SR.EndpointNotFound, request.RequestUri.AbsoluteUri), exception);
		}
		if (exception.InnerException is AuthenticationException)
		{
			return new SecurityNegotiationException(System.SR.Format(System.SR.TrustFailure, request.RequestUri.Authority), exception);
		}
		switch (hResult)
		{
		case 2147954419u:
		case 2147954431u:
			return new CommunicationException(System.SR.Format(System.SR.HttpReceiveFailure, request.RequestUri), exception);
		case 2147954407u:
		case 6u:
			return new EndpointNotFoundException(System.SR.Format(System.SR.EndpointNotFound, request.RequestUri.AbsoluteUri), exception);
		case 2147954575u:
		case 58u:
		case 60u:
			return new SecurityNegotiationException(System.SR.Format(System.SR.TrustFailure, request.RequestUri.Authority), exception);
		default:
			return new CommunicationException(exception.Message, exception);
		}
	}

	internal static Exception CreateUnexpectedResponseException(HttpResponseMessage response)
	{
		string text = response.ReasonPhrase;
		if (string.IsNullOrEmpty(text))
		{
			text = response.StatusCode.ToString();
		}
		return TraceResponseException(new ProtocolException(System.SR.Format(System.SR.UnexpectedHttpResponseCode, (int)response.StatusCode, text)));
	}

	internal static string GetResponseStreamExcerptString(Stream responseStream, ref int bytesToRead)
	{
		long num = bytesToRead;
		if (num < 0 || num > 1024)
		{
			num = 1024L;
		}
		byte[] array = Fx.AllocateByteArray(checked((int)num));
		bytesToRead = responseStream.Read(array, 0, (int)num);
		responseStream.Dispose();
		return Encoding.UTF8.GetString(array, 0, bytesToRead);
	}

	internal static Exception TraceResponseException(Exception exception)
	{
		return exception;
	}

	internal static ProtocolException CreateHttpProtocolException(string message, HttpStatusCode statusCode, string statusDescription)
	{
		ProtocolException ex = new ProtocolException(message);
		ex.Data.Add("System.ServiceModel.Channels.HttpInput.HttpStatusCode", statusCode);
		if (statusDescription != null && statusDescription.Length > 0)
		{
			ex.Data.Add("System.ServiceModel.Channels.HttpInput.HttpStatusDescription", statusDescription);
		}
		return ex;
	}
}
