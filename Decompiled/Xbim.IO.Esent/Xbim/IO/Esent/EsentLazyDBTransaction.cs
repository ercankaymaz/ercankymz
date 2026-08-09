using System;
using Microsoft.Isam.Esent.Interop;

namespace Xbim.IO.Esent;

public struct EsentLazyDBTransaction : IDisposable
{
	private readonly JET_SESID _sesid;

	private bool _inTransaction;

	public EsentLazyDBTransaction(JET_SESID sesid)
	{
		_sesid = sesid;
		Api.JetBeginTransaction(_sesid);
		_inTransaction = true;
	}

	public void Commit()
	{
		Api.JetCommitTransaction(_sesid, CommitTransactionGrbit.LazyFlush);
		_inTransaction = false;
	}

	public void RollBack()
	{
		Api.JetRollback(_sesid, RollbackTransactionGrbit.None);
		_inTransaction = false;
	}

	public void Begin()
	{
		Api.JetBeginTransaction(_sesid);
		_inTransaction = true;
	}

	public void Dispose()
	{
		if (_inTransaction)
		{
			Api.JetRollback(_sesid, RollbackTransactionGrbit.None);
		}
	}
}
