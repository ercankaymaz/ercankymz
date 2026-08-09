using System;
using System.Globalization;
using Microsoft.Isam.Esent.Interop.Windows8;

namespace Microsoft.Isam.Esent.Interop;

public class Transaction : EsentResource
{
	private readonly JET_SESID sesid;

	public int TransactionLevel
	{
		get
		{
			int value = -1;
			if (EsentVersion.SupportsWindows10Features)
			{
				Windows8Api.JetGetSessionParameter(sesid, (JET_sesparam)4099, out value);
			}
			return value;
		}
	}

	public bool IsInTransaction
	{
		get
		{
			CheckObjectIsNotDisposed();
			return base.HasResource;
		}
	}

	public Transaction(JET_SESID sesid)
	{
		this.sesid = sesid;
		Begin();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Transaction (0x{0:x})", sesid.Value);
	}

	public void Begin()
	{
		CheckObjectIsNotDisposed();
		if (IsInTransaction)
		{
			throw new InvalidOperationException("Already in a transaction");
		}
		Api.JetBeginTransaction(sesid);
		ResourceWasAllocated();
	}

	public void Commit(CommitTransactionGrbit grbit)
	{
		CheckObjectIsNotDisposed();
		if (!IsInTransaction)
		{
			throw new InvalidOperationException("Not in a transaction");
		}
		Api.JetCommitTransaction(sesid, grbit);
		ResourceWasReleased();
	}

	public void Commit(CommitTransactionGrbit grbit, TimeSpan durableCommit, out JET_COMMIT_ID commitId)
	{
		CheckObjectIsNotDisposed();
		if (!IsInTransaction)
		{
			throw new InvalidOperationException("Not in a transaction");
		}
		Windows8Api.JetCommitTransaction2(sesid, grbit, durableCommit, out commitId);
		ResourceWasReleased();
	}

	public void Rollback()
	{
		CheckObjectIsNotDisposed();
		if (!IsInTransaction)
		{
			throw new InvalidOperationException("Not in a transaction");
		}
		Api.JetRollback(sesid, RollbackTransactionGrbit.None);
		ResourceWasReleased();
	}

	protected override void ReleaseResource()
	{
		Rollback();
	}
}
