using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentTransactionsNotReadyDuringRecoveryException : EsentStateException
{
	public EsentTransactionsNotReadyDuringRecoveryException()
		: base("Recovery has not seen any Begin0/Commit0 records and so does not know what trxBegin0 to assign to this transaction", JET_err.TransactionsNotReadyDuringRecovery)
	{
	}

	private EsentTransactionsNotReadyDuringRecoveryException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
