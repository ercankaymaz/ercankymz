using System;
using System.Text;
using Microsoft.Isam.Esent.Interop;

namespace Xbim.IO.Esent;

public abstract class EsentCursor : IDisposable
{
	protected const int TransactionBatchSize = 100;

	protected readonly JET_INSTANCE Instance;

	protected readonly Session Sesid;

	protected readonly JET_DBID DbId;

	protected JET_TABLEID Table;

	protected EsentModel Model;

	protected JET_TABLEID GlobalsTable;

	protected static string GlobalsTableName = "MetaData";

	protected static string EntityCountColumnName = "EntityCount";

	protected static string GeometryCountColumnName = "GeometryCount";

	protected static string FlushColumnName = "FlushColumn";

	protected JET_COLUMNID EntityCountColumn;

	protected JET_COLUMNID GeometryCountColumn;

	protected JET_COLUMNID FlushColumn;

	protected JET_COLUMNID IfcHeaderColumn;

	protected static string VersionColumnName = "Version";

	protected static string Version = "2.4.1";

	protected readonly object LockObject;

	private static string ifcHeaderColumnName = "IfcHeader";

	private bool disposedValue;

	public Session Session => Sesid;

	public bool ReadOnly { get; set; }

	protected EsentCursor(EsentModel model, string database, OpenDatabaseGrbit mode)
	{
		try
		{
			LockObject = new object();
			Model = model;
			Instance = model.Cache.JetInstance;
			Sesid = new Session(Instance);
			Api.JetOpenDatabase(Sesid, database, string.Empty, out DbId, mode);
			Api.JetOpenTable(Sesid, DbId, GlobalsTableName, null, 0, mode switch
			{
				OpenDatabaseGrbit.Exclusive => OpenTableGrbit.DenyWrite, 
				OpenDatabaseGrbit.ReadOnly => OpenTableGrbit.ReadOnly, 
				_ => OpenTableGrbit.None, 
			}, out GlobalsTable);
			EntityCountColumn = Api.GetTableColumnid(Sesid, GlobalsTable, EntityCountColumnName);
			GeometryCountColumn = Api.GetTableColumnid(Sesid, GlobalsTable, GeometryCountColumnName);
			FlushColumn = Api.GetTableColumnid(Sesid, GlobalsTable, FlushColumnName);
			IfcHeaderColumn = Api.GetTableColumnid(Sesid, GlobalsTable, ifcHeaderColumnName);
			ReadOnly = mode == OpenDatabaseGrbit.ReadOnly;
		}
		catch
		{
			if (Sesid != null)
			{
				if (Table != JET_TABLEID.Nil && !Table.IsInvalid)
				{
					Api.JetCloseTable(Sesid, Table);
				}
				if (GlobalsTable != JET_TABLEID.Nil && !GlobalsTable.IsInvalid)
				{
					Api.JetCloseTable(Sesid, GlobalsTable);
				}
				if (DbId != JET_DBID.Nil && DbId != default(JET_DBID))
				{
					Api.JetCloseDatabase(Sesid, DbId, CloseDatabaseGrbit.None);
				}
				Api.JetEndSession(Sesid, EndSessionGrbit.None);
			}
			throw;
		}
	}

	internal abstract int RetrieveCount();

	protected abstract void UpdateCount(int delta);

	public static void CreateGlobalsTable(JET_SESID sesid, JET_DBID dbid)
	{
		using Transaction transaction = new Transaction(sesid);
		Api.JetCreateTable(sesid, dbid, GlobalsTableName, 1, 100, out var tableid);
		Api.JetAddColumn(sesid, tableid, VersionColumnName, new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.LongText
		}, null, 0, out var columnid);
		byte[] bytes = BitConverter.GetBytes(0);
		Api.JetAddColumn(sesid, tableid, EntityCountColumnName, new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = ColumndefGrbit.ColumnEscrowUpdate
		}, bytes, bytes.Length, out var columnid2);
		Api.JetAddColumn(sesid, tableid, GeometryCountColumnName, new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = ColumndefGrbit.ColumnEscrowUpdate
		}, bytes, bytes.Length, out columnid2);
		Api.JetAddColumn(sesid, tableid, FlushColumnName, new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = ColumndefGrbit.ColumnEscrowUpdate
		}, bytes, bytes.Length, out columnid2);
		Api.JetAddColumn(sesid, tableid, ifcHeaderColumnName, new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.LongBinary
		}, null, 0, out columnid2);
		using (Update update = new Update(sesid, tableid, JET_prep.Insert))
		{
			Api.SetColumn(sesid, tableid, columnid, Version, Encoding.Unicode);
			update.Save();
		}
		Api.JetCloseTable(sesid, tableid);
		transaction.Commit(CommitTransactionGrbit.LazyFlush);
	}

	public EsentLazyDBTransaction BeginLazyTransaction()
	{
		return new EsentLazyDBTransaction(Sesid);
	}

	internal Transaction BeginTransaction()
	{
		return new Transaction(Sesid);
	}

	public EsentReadOnlyTransaction BeginReadOnlyTransaction()
	{
		return new EsentReadOnlyTransaction(Sesid);
	}

	internal void Flush()
	{
		using Transaction transaction = BeginTransaction();
		Api.EscrowUpdate(Sesid, GlobalsTable, FlushColumn, 1);
		transaction.Commit(CommitTransactionGrbit.WaitLastLevel0Commit);
	}

	internal bool TryMoveNext()
	{
		return Api.TryMoveNext(Sesid, Table);
	}

	internal virtual bool TryMoveFirst()
	{
		return Api.TryMoveFirst(Sesid, Table);
	}

	internal bool TryMoveLast()
	{
		return Api.TryMoveLast(Sesid, Table);
	}

	internal void SetCurrentIndex(string indexName)
	{
		Api.JetSetCurrentIndex(Sesid, Table, indexName);
	}

	internal void MoveBeforeFirst()
	{
		Api.MoveBeforeFirst(Sesid, Table);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposedValue)
		{
			return;
		}
		if (disposing)
		{
			try
			{
				Api.JetCloseTable(Sesid, Table);
				Api.JetCloseTable(Sesid, GlobalsTable);
				Api.JetCloseDatabase(Sesid, DbId, CloseDatabaseGrbit.None);
				Api.JetEndSession(Sesid, EndSessionGrbit.None);
			}
			catch (Exception)
			{
			}
		}
		disposedValue = true;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
