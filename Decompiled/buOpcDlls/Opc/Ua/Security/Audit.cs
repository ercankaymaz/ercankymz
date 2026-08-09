using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security;

[ComVisible(true)]
public static class Audit
{
	public static void SecureChannelCreated(string implementationInfo, string endpointUrl, string secureChannelId, EndpointDescription endpoint, X509Certificate2 clientCertificate, X509Certificate2 serverCertificate, BinaryEncodingSupport encodingSupport)
	{
		if ((Utils.TraceMask & 0x200) == 0)
		{
			return;
		}
		if (endpoint != null)
		{
			string text = encodingSupport switch
			{
				BinaryEncodingSupport.Required => "Binary", 
				BinaryEncodingSupport.None => "Xml", 
				_ => "BinaryOrXml", 
			};
			Utils.LogInfo("SECURE CHANNEL CREATED [{0}] [ID={1}] Connected To: {2} [{3}/{4}/{5}]", implementationInfo, secureChannelId, endpointUrl, endpoint.SecurityMode.ToString(), SecurityPolicies.GetDisplayName(endpoint.SecurityPolicyUri), text);
			if (endpoint.SecurityMode != MessageSecurityMode.None)
			{
				Utils.LogCertificate("Client Certificate: ", clientCertificate);
				Utils.LogCertificate("Server Certificate: ", serverCertificate);
			}
		}
		else
		{
			Utils.LogInfo("SECURE CHANNEL CREATED [{0}] [ID={1}] Connected To: {2}", implementationInfo, secureChannelId, endpointUrl);
		}
	}

	public static void SecureChannelRenewed(string implementationInfo, string secureChannelId)
	{
		if ((Utils.TraceMask & 0x200) != 0)
		{
			Utils.LogInfo("SECURE CHANNEL RENEWED [{0}] [ID={1}]", implementationInfo, secureChannelId);
		}
	}
}
