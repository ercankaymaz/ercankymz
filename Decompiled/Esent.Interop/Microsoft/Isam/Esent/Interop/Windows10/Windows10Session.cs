using Microsoft.Isam.Esent.Interop.Windows8;

namespace Microsoft.Isam.Esent.Interop.Windows10;

public static class Windows10Session
{
	public static int GetTransactionLevel(this Session session)
	{
		Windows8Api.JetGetSessionParameter(session.JetSesid, (JET_sesparam)4099, out var value);
		return value;
	}

	public static JET_OPERATIONCONTEXT GetOperationContext(this Session session)
	{
		Windows10Api.JetGetSessionParameter(session.JetSesid, (JET_sesparam)4100, out var operationContext);
		return operationContext;
	}

	public static void SetOperationContext(this Session session, JET_OPERATIONCONTEXT operationcontext)
	{
		Windows10Api.JetSetSessionParameter(session.JetSesid, (JET_sesparam)4100, operationcontext);
	}

	public static int GetCorrelationID(this Session session)
	{
		Windows8Api.JetGetSessionParameter(session.JetSesid, (JET_sesparam)4101, out var value);
		return value;
	}

	public static void SetCorrelationID(this Session session, int correlationId)
	{
		Windows8Api.JetSetSessionParameter(session.JetSesid, (JET_sesparam)4101, correlationId);
	}
}
