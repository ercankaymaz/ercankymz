using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

public interface ISecureConversationSession : ISecuritySession, ISession
{
	void WriteSessionTokenIdentifier(XmlDictionaryWriter writer);

	bool TryReadSessionTokenIdentifier(XmlReader reader);
}
