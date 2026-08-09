using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderServerPolicies
{
	IApplicationConfigurationBuilderServerSelected AddUnsecurePolicyNone(bool addPolicy = true);

	IApplicationConfigurationBuilderServerSelected AddSignPolicies(bool addPolicies = true);

	IApplicationConfigurationBuilderServerSelected AddSignAndEncryptPolicies(bool addPolicies = true);

	IApplicationConfigurationBuilderServerSelected AddPolicy(MessageSecurityMode securityMode, string securityPolicy);

	IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(UserTokenType userTokenType);

	IApplicationConfigurationBuilderServerSelected AddUserTokenPolicy(UserTokenPolicy userTokenPolicy);
}
