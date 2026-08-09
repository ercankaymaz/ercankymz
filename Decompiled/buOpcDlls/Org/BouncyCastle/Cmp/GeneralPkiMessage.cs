using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;

namespace Org.BouncyCastle.Cmp;

public class GeneralPkiMessage
{
	private readonly PkiMessage m_pkiMessage;

	public virtual PkiHeader Header => m_pkiMessage.Header;

	public virtual PkiBody Body => m_pkiMessage.Body;

	public virtual bool HasProtection => m_pkiMessage.Protection != null;

	private static PkiMessage ParseBytes(byte[] encoding)
	{
		return PkiMessage.GetInstance(Asn1Object.FromByteArray(encoding));
	}

	public GeneralPkiMessage(PkiMessage pkiMessage)
	{
		m_pkiMessage = pkiMessage;
	}

	public GeneralPkiMessage(byte[] encoding)
		: this(ParseBytes(encoding))
	{
	}

	public virtual PkiMessage ToAsn1Structure()
	{
		return m_pkiMessage;
	}
}
