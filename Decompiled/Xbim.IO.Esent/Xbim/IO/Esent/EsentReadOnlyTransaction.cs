using System;
using Microsoft.Isam.Esent.Interop;

namespace Xbim.IO.Esent;

public struct EsentReadOnlyTransaction : IDisposable
{
	private readonly JET_SESID _sesid;

	public EsentReadOnlyTransaction(JET_SESID sesid)
	{
		_sesid = sesid;
		Api.JetBeginTransaction2(_sesid, BeginTransactionGrbit.ReadOnly);
	}

	public void Dispose()
	{
		Api.JetCommitTransaction(_sesid, CommitTransactionGrbit.LazyFlush);
	}
}
