using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Microsoft.Isam.Esent.Interop.Implementation;

namespace Microsoft.Isam.Esent.Interop;

public static class Api
{
	internal delegate void ErrorHandler(JET_err error);

	private static readonly Encoding AsciiDecoder;

	internal static IJetApi Impl { get; set; }

	internal static event ErrorHandler HandleError;

	static Api()
	{
		AsciiDecoder = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
		Impl = new JetApi();
	}

	public static void JetCreateInstance(out JET_INSTANCE instance, string name)
	{
		Check(Impl.JetCreateInstance(out instance, name));
	}

	public static void JetCreateInstance2(out JET_INSTANCE instance, string name, string displayName, CreateInstanceGrbit grbit)
	{
		Check(Impl.JetCreateInstance2(out instance, name, displayName, grbit));
	}

	public static void JetInit(ref JET_INSTANCE instance)
	{
		Check(Impl.JetInit(ref instance));
	}

	public static JET_wrn JetInit2(ref JET_INSTANCE instance, InitGrbit grbit)
	{
		return Check(Impl.JetInit2(ref instance, grbit));
	}

	public static void JetGetInstanceInfo(out int numInstances, out JET_INSTANCE_INFO[] instances)
	{
		Check(Impl.JetGetInstanceInfo(out numInstances, out instances));
	}

	public static void JetStopBackupInstance(JET_INSTANCE instance)
	{
		Check(Impl.JetStopBackupInstance(instance));
	}

	public static void JetStopServiceInstance(JET_INSTANCE instance)
	{
		Check(Impl.JetStopServiceInstance(instance));
	}

	public static void JetTerm(JET_INSTANCE instance)
	{
		Check(Impl.JetTerm(instance));
	}

	public static void JetTerm2(JET_INSTANCE instance, TermGrbit grbit)
	{
		Check(Impl.JetTerm2(instance, grbit));
	}

	public static JET_wrn JetSetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, int paramValue, string paramString)
	{
		return Check(Impl.JetSetSystemParameter(instance, sesid, paramid, new IntPtr(paramValue), paramString));
	}

	public static JET_wrn JetSetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, JET_CALLBACK paramValue, string paramString)
	{
		return Check(Impl.JetSetSystemParameter(instance, sesid, paramid, paramValue, paramString));
	}

	public static JET_wrn JetSetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, IntPtr paramValue, string paramString)
	{
		return Check(Impl.JetSetSystemParameter(instance, sesid, paramid, paramValue, paramString));
	}

	public static JET_wrn JetGetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, ref IntPtr paramValue, out string paramString, int maxParam)
	{
		return Check(Impl.JetGetSystemParameter(instance, sesid, paramid, ref paramValue, out paramString, maxParam));
	}

	public static JET_wrn JetGetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, ref int paramValue, out string paramString, int maxParam)
	{
		IntPtr paramValue2 = new IntPtr(paramValue);
		JET_wrn result = Check(Impl.JetGetSystemParameter(instance, sesid, paramid, ref paramValue2, out paramString, maxParam));
		paramValue = paramValue2.ToInt32();
		return result;
	}

	[CLSCompliant(false)]
	public static void JetGetVersion(JET_SESID sesid, out uint version)
	{
		Check(Impl.JetGetVersion(sesid, out version));
	}

	public static void JetCreateDatabase(JET_SESID sesid, string database, string connect, out JET_DBID dbid, CreateDatabaseGrbit grbit)
	{
		Check(Impl.JetCreateDatabase(sesid, database, connect, out dbid, grbit));
	}

	public static void JetCreateDatabase2(JET_SESID sesid, string database, int maxPages, out JET_DBID dbid, CreateDatabaseGrbit grbit)
	{
		Check(Impl.JetCreateDatabase2(sesid, database, maxPages, out dbid, grbit));
	}

	public static JET_wrn JetAttachDatabase(JET_SESID sesid, string database, AttachDatabaseGrbit grbit)
	{
		return Check(Impl.JetAttachDatabase(sesid, database, grbit));
	}

	public static JET_wrn JetAttachDatabase2(JET_SESID sesid, string database, int maxPages, AttachDatabaseGrbit grbit)
	{
		return Check(Impl.JetAttachDatabase2(sesid, database, maxPages, grbit));
	}

	public static JET_wrn JetOpenDatabase(JET_SESID sesid, string database, string connect, out JET_DBID dbid, OpenDatabaseGrbit grbit)
	{
		return Check(Impl.JetOpenDatabase(sesid, database, connect, out dbid, grbit));
	}

	public static void JetCloseDatabase(JET_SESID sesid, JET_DBID dbid, CloseDatabaseGrbit grbit)
	{
		Check(Impl.JetCloseDatabase(sesid, dbid, grbit));
	}

	public static void JetDetachDatabase(JET_SESID sesid, string database)
	{
		Check(Impl.JetDetachDatabase(sesid, database));
	}

	public static void JetDetachDatabase2(JET_SESID sesid, string database, DetachDatabaseGrbit grbit)
	{
		Check(Impl.JetDetachDatabase2(sesid, database, grbit));
	}

	public static void JetCompact(JET_SESID sesid, string sourceDatabase, string destinationDatabase, JET_PFNSTATUS statusCallback, JET_CONVERT ignored, CompactGrbit grbit)
	{
		Check(Impl.JetCompact(sesid, sourceDatabase, destinationDatabase, statusCallback, ignored, grbit));
	}

	public static void JetGrowDatabase(JET_SESID sesid, JET_DBID dbid, int desiredPages, out int actualPages)
	{
		Check(Impl.JetGrowDatabase(sesid, dbid, desiredPages, out actualPages));
	}

	public static void JetSetDatabaseSize(JET_SESID sesid, string database, int desiredPages, out int actualPages)
	{
		Check(Impl.JetSetDatabaseSize(sesid, database, desiredPages, out actualPages));
	}

	public static void JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out int value, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseInfo(sesid, dbid, out value, infoLevel));
	}

	public static void JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out JET_DBINFOMISC dbinfomisc, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseInfo(sesid, dbid, out dbinfomisc, infoLevel));
	}

	public static void JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out string value, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseInfo(sesid, dbid, out value, infoLevel));
	}

	public static void JetGetDatabaseFileInfo(string databaseName, out int value, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseFileInfo(databaseName, out value, infoLevel));
	}

	public static void JetGetDatabaseFileInfo(string databaseName, out long value, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseFileInfo(databaseName, out value, infoLevel));
	}

	public static void JetGetDatabaseFileInfo(string databaseName, out JET_DBINFOMISC dbinfomisc, JET_DbInfo infoLevel)
	{
		Check(Impl.JetGetDatabaseFileInfo(databaseName, out dbinfomisc, infoLevel));
	}

	public static void JetBackupInstance(JET_INSTANCE instance, string destination, BackupGrbit grbit, JET_PFNSTATUS statusCallback)
	{
		Check(Impl.JetBackupInstance(instance, destination, grbit, statusCallback));
	}

	public static void JetRestoreInstance(JET_INSTANCE instance, string source, string destination, JET_PFNSTATUS statusCallback)
	{
		Check(Impl.JetRestoreInstance(instance, source, destination, statusCallback));
	}

	public static void JetOSSnapshotFreeze(JET_OSSNAPID snapshot, out int numInstances, out JET_INSTANCE_INFO[] instances, SnapshotFreezeGrbit grbit)
	{
		Check(Impl.JetOSSnapshotFreeze(snapshot, out numInstances, out instances, grbit));
	}

	public static void JetOSSnapshotPrepare(out JET_OSSNAPID snapshot, SnapshotPrepareGrbit grbit)
	{
		Check(Impl.JetOSSnapshotPrepare(out snapshot, grbit));
	}

	public static void JetOSSnapshotThaw(JET_OSSNAPID snapshot, SnapshotThawGrbit grbit)
	{
		Check(Impl.JetOSSnapshotThaw(snapshot, grbit));
	}

	public static void JetBeginExternalBackupInstance(JET_INSTANCE instance, BeginExternalBackupGrbit grbit)
	{
		Check(Impl.JetBeginExternalBackupInstance(instance, grbit));
	}

	public static void JetCloseFileInstance(JET_INSTANCE instance, JET_HANDLE handle)
	{
		Check(Impl.JetCloseFileInstance(instance, handle));
	}

	public static void JetEndExternalBackupInstance(JET_INSTANCE instance)
	{
		Check(Impl.JetEndExternalBackupInstance(instance));
	}

	public static void JetEndExternalBackupInstance2(JET_INSTANCE instance, EndExternalBackupGrbit grbit)
	{
		Check(Impl.JetEndExternalBackupInstance2(instance, grbit));
	}

	public static void JetGetAttachInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		Check(Impl.JetGetAttachInfoInstance(instance, out files, maxChars, out actualChars));
	}

	public static void JetGetLogInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		Check(Impl.JetGetLogInfoInstance(instance, out files, maxChars, out actualChars));
	}

	public static void JetGetTruncateLogInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		Check(Impl.JetGetTruncateLogInfoInstance(instance, out files, maxChars, out actualChars));
	}

	public static void JetOpenFileInstance(JET_INSTANCE instance, string file, out JET_HANDLE handle, out long fileSizeLow, out long fileSizeHigh)
	{
		Check(Impl.JetOpenFileInstance(instance, file, out handle, out fileSizeLow, out fileSizeHigh));
	}

	public static void JetReadFileInstance(JET_INSTANCE instance, JET_HANDLE file, byte[] buffer, int bufferSize, out int bytesRead)
	{
		Check(Impl.JetReadFileInstance(instance, file, buffer, bufferSize, out bytesRead));
	}

	public static void JetTruncateLogInstance(JET_INSTANCE instance)
	{
		Check(Impl.JetTruncateLogInstance(instance));
	}

	public static void JetBeginSession(JET_INSTANCE instance, out JET_SESID sesid, string username, string password)
	{
		Check(Impl.JetBeginSession(instance, out sesid, username, password));
	}

	public static void JetSetSessionContext(JET_SESID sesid, IntPtr context)
	{
		Check(Impl.JetSetSessionContext(sesid, context));
	}

	public static void JetResetSessionContext(JET_SESID sesid)
	{
		Check(Impl.JetResetSessionContext(sesid));
	}

	public static void JetEndSession(JET_SESID sesid, EndSessionGrbit grbit)
	{
		Check(Impl.JetEndSession(sesid, grbit));
	}

	public static void JetDupSession(JET_SESID sesid, out JET_SESID newSesid)
	{
		Check(Impl.JetDupSession(sesid, out newSesid));
	}

	public static JET_wrn JetOpenTable(JET_SESID sesid, JET_DBID dbid, string tablename, byte[] parameters, int parametersSize, OpenTableGrbit grbit, out JET_TABLEID tableid)
	{
		return Check(Impl.JetOpenTable(sesid, dbid, tablename, parameters, parametersSize, grbit, out tableid));
	}

	public static void JetCloseTable(JET_SESID sesid, JET_TABLEID tableid)
	{
		Check(Impl.JetCloseTable(sesid, tableid));
	}

	public static void JetDupCursor(JET_SESID sesid, JET_TABLEID tableid, out JET_TABLEID newTableid, DupCursorGrbit grbit)
	{
		Check(Impl.JetDupCursor(sesid, tableid, out newTableid, grbit));
	}

	public static void JetComputeStats(JET_SESID sesid, JET_TABLEID tableid)
	{
		Check(Impl.JetComputeStats(sesid, tableid));
	}

	public static void JetSetLS(JET_SESID sesid, JET_TABLEID tableid, JET_LS ls, LsGrbit grbit)
	{
		Check(Impl.JetSetLS(sesid, tableid, ls, grbit));
	}

	public static void JetGetLS(JET_SESID sesid, JET_TABLEID tableid, out JET_LS ls, LsGrbit grbit)
	{
		Check(Impl.JetGetLS(sesid, tableid, out ls, grbit));
	}

	public static void JetGetCursorInfo(JET_SESID sesid, JET_TABLEID tableid)
	{
		Check(Impl.JetGetCursorInfo(sesid, tableid));
	}

	public static void JetBeginTransaction(JET_SESID sesid)
	{
		Check(Impl.JetBeginTransaction(sesid));
	}

	public static void JetBeginTransaction2(JET_SESID sesid, BeginTransactionGrbit grbit)
	{
		Check(Impl.JetBeginTransaction2(sesid, grbit));
	}

	public static void JetCommitTransaction(JET_SESID sesid, CommitTransactionGrbit grbit)
	{
		Check(Impl.JetCommitTransaction(sesid, grbit));
	}

	public static void JetRollback(JET_SESID sesid, RollbackTransactionGrbit grbit)
	{
		Check(Impl.JetRollback(sesid, grbit));
	}

	public static void JetCreateTable(JET_SESID sesid, JET_DBID dbid, string table, int pages, int density, out JET_TABLEID tableid)
	{
		Check(Impl.JetCreateTable(sesid, dbid, table, pages, density, out tableid));
	}

	public static void JetAddColumn(JET_SESID sesid, JET_TABLEID tableid, string column, JET_COLUMNDEF columndef, byte[] defaultValue, int defaultValueSize, out JET_COLUMNID columnid)
	{
		Check(Impl.JetAddColumn(sesid, tableid, column, columndef, defaultValue, defaultValueSize, out columnid));
	}

	public static void JetDeleteColumn(JET_SESID sesid, JET_TABLEID tableid, string column)
	{
		Check(Impl.JetDeleteColumn(sesid, tableid, column));
	}

	public static void JetDeleteColumn2(JET_SESID sesid, JET_TABLEID tableid, string column, DeleteColumnGrbit grbit)
	{
		Check(Impl.JetDeleteColumn2(sesid, tableid, column, grbit));
	}

	public static void JetDeleteIndex(JET_SESID sesid, JET_TABLEID tableid, string index)
	{
		Check(Impl.JetDeleteIndex(sesid, tableid, index));
	}

	public static void JetDeleteTable(JET_SESID sesid, JET_DBID dbid, string table)
	{
		Check(Impl.JetDeleteTable(sesid, dbid, table));
	}

	public static void JetCreateIndex(JET_SESID sesid, JET_TABLEID tableid, string indexName, CreateIndexGrbit grbit, string keyDescription, int keyDescriptionLength, int density)
	{
		Check(Impl.JetCreateIndex(sesid, tableid, indexName, grbit, keyDescription, keyDescriptionLength, density));
	}

	public static void JetCreateIndex2(JET_SESID sesid, JET_TABLEID tableid, JET_INDEXCREATE[] indexcreates, int numIndexCreates)
	{
		Check(Impl.JetCreateIndex2(sesid, tableid, indexcreates, numIndexCreates));
	}

	public static void JetOpenTempTable(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		Check(Impl.JetOpenTempTable(sesid, columns, numColumns, grbit, out tableid, columnids));
	}

	public static void JetOpenTempTable2(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, int lcid, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		Check(Impl.JetOpenTempTable2(sesid, columns, numColumns, lcid, grbit, out tableid, columnids));
	}

	public static void JetOpenTempTable3(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, JET_UNICODEINDEX unicodeindex, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		Check(Impl.JetOpenTempTable3(sesid, columns, numColumns, unicodeindex, grbit, out tableid, columnids));
	}

	public static void JetCreateTableColumnIndex3(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		Check(Impl.JetCreateTableColumnIndex3(sesid, dbid, tablecreate));
	}

	public static void JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, out JET_COLUMNDEF columndef)
	{
		Check(Impl.JetGetTableColumnInfo(sesid, tableid, columnName, out columndef));
	}

	public static void JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, out JET_COLUMNDEF columndef)
	{
		Check(Impl.JetGetTableColumnInfo(sesid, tableid, columnid, out columndef));
	}

	public static void JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, out JET_COLUMNBASE columnbase)
	{
		Check(Impl.JetGetTableColumnInfo(sesid, tableid, columnName, out columnbase));
	}

	public static void JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, out JET_COLUMNLIST columnlist)
	{
		Check(Impl.JetGetTableColumnInfo(sesid, tableid, columnName, ColInfoGrbit.None, out columnlist));
	}

	public static void JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, ColInfoGrbit grbit, out JET_COLUMNLIST columnlist)
	{
		Check(Impl.JetGetTableColumnInfo(sesid, tableid, columnName, grbit, out columnlist));
	}

	public static void JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string columnName, out JET_COLUMNDEF columndef)
	{
		Check(Impl.JetGetColumnInfo(sesid, dbid, tablename, columnName, out columndef));
	}

	public static void JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string columnName, out JET_COLUMNLIST columnlist)
	{
		Check(Impl.JetGetColumnInfo(sesid, dbid, tablename, columnName, out columnlist));
	}

	public static void JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string columnName, out JET_COLUMNBASE columnbase)
	{
		Check(Impl.JetGetColumnInfo(sesid, dbid, tablename, columnName, out columnbase));
	}

	public static void JetGetObjectInfo(JET_SESID sesid, JET_DBID dbid, out JET_OBJECTLIST objectlist)
	{
		Check(Impl.JetGetObjectInfo(sesid, dbid, out objectlist));
	}

	public static void JetGetObjectInfo(JET_SESID sesid, JET_DBID dbid, JET_objtyp objtyp, string objectName, out JET_OBJECTINFO objectinfo)
	{
		Check(Impl.JetGetObjectInfo(sesid, dbid, objtyp, objectName, out objectinfo));
	}

	public static void JetGetCurrentIndex(JET_SESID sesid, JET_TABLEID tableid, out string indexName, int maxNameLength)
	{
		Check(Impl.JetGetCurrentIndex(sesid, tableid, out indexName, maxNameLength));
	}

	public static void JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out JET_OBJECTINFO result, JET_TblInfo infoLevel)
	{
		Check(Impl.JetGetTableInfo(sesid, tableid, out result, infoLevel));
	}

	public static void JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out string result, JET_TblInfo infoLevel)
	{
		Check(Impl.JetGetTableInfo(sesid, tableid, out result, infoLevel));
	}

	public static void JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out JET_DBID result, JET_TblInfo infoLevel)
	{
		Check(Impl.JetGetTableInfo(sesid, tableid, out result, infoLevel));
	}

	public static void JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, int[] result, JET_TblInfo infoLevel)
	{
		Check(Impl.JetGetTableInfo(sesid, tableid, result, infoLevel));
	}

	public static void JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out int result, JET_TblInfo infoLevel)
	{
		Check(Impl.JetGetTableInfo(sesid, tableid, out result, infoLevel));
	}

	[CLSCompliant(false)]
	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out ushort result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out int result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXID result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXLIST result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXCREATE result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetIndexInfo(sesid, dbid, tablename, indexname, out result, infoLevel));
	}

	[CLSCompliant(false)]
	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out ushort result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out int result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXID result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXLIST result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXCREATE result, JET_IdxInfo infoLevel)
	{
		Check(Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel));
	}

	public static void JetRenameTable(JET_SESID sesid, JET_DBID dbid, string tableName, string newTableName)
	{
		Check(Impl.JetRenameTable(sesid, dbid, tableName, newTableName));
	}

	public static void JetRenameColumn(JET_SESID sesid, JET_TABLEID tableid, string name, string newName, RenameColumnGrbit grbit)
	{
		Check(Impl.JetRenameColumn(sesid, tableid, name, newName, grbit));
	}

	public static void JetSetColumnDefaultValue(JET_SESID sesid, JET_DBID dbid, string tableName, string columnName, byte[] data, int dataSize, SetColumnDefaultValueGrbit grbit)
	{
		Check(Impl.JetSetColumnDefaultValue(sesid, dbid, tableName, columnName, data, dataSize, grbit));
	}

	public static void JetGotoBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize)
	{
		Check(Impl.JetGotoBookmark(sesid, tableid, bookmark, bookmarkSize));
	}

	public static void JetGotoSecondaryIndexBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] secondaryKey, int secondaryKeySize, byte[] primaryKey, int primaryKeySize, GotoSecondaryIndexBookmarkGrbit grbit)
	{
		Check(Impl.JetGotoSecondaryIndexBookmark(sesid, tableid, secondaryKey, secondaryKeySize, primaryKey, primaryKeySize, grbit));
	}

	public static void JetMove(JET_SESID sesid, JET_TABLEID tableid, int numRows, MoveGrbit grbit)
	{
		Check(Impl.JetMove(sesid, tableid, numRows, grbit));
	}

	public static void JetMove(JET_SESID sesid, JET_TABLEID tableid, JET_Move numRows, MoveGrbit grbit)
	{
		Check(Impl.JetMove(sesid, tableid, (int)numRows, grbit));
	}

	public unsafe static void JetMakeKey(JET_SESID sesid, JET_TABLEID tableid, byte[] data, int dataSize, MakeKeyGrbit grbit)
	{
		if ((data == null && dataSize != 0) || (data != null && dataSize > data.Length))
		{
			throw new ArgumentOutOfRangeException("dataSize", dataSize, "cannot be greater than the length of the data");
		}
		fixed (byte* value = data)
		{
			JetMakeKey(sesid, tableid, new IntPtr(value), dataSize, grbit);
		}
	}

	public static JET_wrn JetSeek(JET_SESID sesid, JET_TABLEID tableid, SeekGrbit grbit)
	{
		return Check(Impl.JetSeek(sesid, tableid, grbit));
	}

	public static void JetSetIndexRange(JET_SESID sesid, JET_TABLEID tableid, SetIndexRangeGrbit grbit)
	{
		Check(Impl.JetSetIndexRange(sesid, tableid, grbit));
	}

	public static void JetIntersectIndexes(JET_SESID sesid, JET_INDEXRANGE[] ranges, int numRanges, out JET_RECORDLIST recordlist, IntersectIndexesGrbit grbit)
	{
		Check(Impl.JetIntersectIndexes(sesid, ranges, numRanges, out recordlist, grbit));
	}

	public static void JetSetCurrentIndex(JET_SESID sesid, JET_TABLEID tableid, string index)
	{
		Check(Impl.JetSetCurrentIndex(sesid, tableid, index));
	}

	public static void JetSetCurrentIndex2(JET_SESID sesid, JET_TABLEID tableid, string index, SetCurrentIndexGrbit grbit)
	{
		Check(Impl.JetSetCurrentIndex2(sesid, tableid, index, grbit));
	}

	public static void JetSetCurrentIndex3(JET_SESID sesid, JET_TABLEID tableid, string index, SetCurrentIndexGrbit grbit, int itagSequence)
	{
		Check(Impl.JetSetCurrentIndex3(sesid, tableid, index, grbit, itagSequence));
	}

	public static void JetSetCurrentIndex4(JET_SESID sesid, JET_TABLEID tableid, string index, JET_INDEXID indexid, SetCurrentIndexGrbit grbit, int itagSequence)
	{
		Check(Impl.JetSetCurrentIndex4(sesid, tableid, index, indexid, grbit, itagSequence));
	}

	public static void JetIndexRecordCount(JET_SESID sesid, JET_TABLEID tableid, out int numRecords, int maxRecordsToCount)
	{
		if (maxRecordsToCount == 0)
		{
			maxRecordsToCount = int.MaxValue;
		}
		Check(Impl.JetIndexRecordCount(sesid, tableid, out numRecords, maxRecordsToCount));
	}

	public static void JetIndexRecordCount2(JET_SESID sesid, JET_TABLEID tableid, out long numRecords, long maxRecordsToCount)
	{
		if (maxRecordsToCount == 0L)
		{
			maxRecordsToCount = long.MaxValue;
		}
		Check(Impl.JetIndexRecordCount2(sesid, tableid, out numRecords, maxRecordsToCount));
	}

	public static void JetSetTableSequential(JET_SESID sesid, JET_TABLEID tableid, SetTableSequentialGrbit grbit)
	{
		Check(Impl.JetSetTableSequential(sesid, tableid, grbit));
	}

	public static void JetResetTableSequential(JET_SESID sesid, JET_TABLEID tableid, ResetTableSequentialGrbit grbit)
	{
		Check(Impl.JetResetTableSequential(sesid, tableid, grbit));
	}

	public static void JetGetRecordPosition(JET_SESID sesid, JET_TABLEID tableid, out JET_RECPOS recpos)
	{
		Check(Impl.JetGetRecordPosition(sesid, tableid, out recpos));
	}

	public static void JetGotoPosition(JET_SESID sesid, JET_TABLEID tableid, JET_RECPOS recpos)
	{
		Check(Impl.JetGotoPosition(sesid, tableid, recpos));
	}

	public static void JetGetBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize, out int actualBookmarkSize)
	{
		Check(Impl.JetGetBookmark(sesid, tableid, bookmark, bookmarkSize, out actualBookmarkSize));
	}

	public static void JetGetSecondaryIndexBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] secondaryKey, int secondaryKeySize, out int actualSecondaryKeySize, byte[] primaryKey, int primaryKeySize, out int actualPrimaryKeySize, GetSecondaryIndexBookmarkGrbit grbit)
	{
		Check(Impl.JetGetSecondaryIndexBookmark(sesid, tableid, secondaryKey, secondaryKeySize, out actualSecondaryKeySize, primaryKey, primaryKeySize, out actualPrimaryKeySize, grbit));
	}

	public static void JetRetrieveKey(JET_SESID sesid, JET_TABLEID tableid, byte[] data, int dataSize, out int actualDataSize, RetrieveKeyGrbit grbit)
	{
		Check(Impl.JetRetrieveKey(sesid, tableid, data, dataSize, out actualDataSize, grbit));
	}

	public static JET_wrn JetRetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data, int dataSize, out int actualDataSize, RetrieveColumnGrbit grbit, JET_RETINFO retinfo)
	{
		return JetRetrieveColumn(sesid, tableid, columnid, data, dataSize, 0, out actualDataSize, grbit, retinfo);
	}

	public unsafe static JET_wrn JetRetrieveColumns(JET_SESID sesid, JET_TABLEID tableid, JET_RETRIEVECOLUMN[] retrievecolumns, int numColumns)
	{
		if (retrievecolumns == null)
		{
			throw new ArgumentNullException("retrievecolumns");
		}
		if (numColumns < 0 || numColumns > retrievecolumns.Length)
		{
			throw new ArgumentOutOfRangeException("numColumns", numColumns, "cannot be negative or greater than retrievecolumns.Length");
		}
		NATIVE_RETRIEVECOLUMN* ptr = stackalloc NATIVE_RETRIEVECOLUMN[numColumns];
		int err = PinColumnsAndRetrieve(sesid, tableid, ptr, retrievecolumns, numColumns, 0);
		for (int i = 0; i < numColumns; i = checked(i + 1))
		{
			retrievecolumns[i].UpdateFromNativeRetrievecolumn(ref *(NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))));
		}
		return Check(err);
	}

	[CLSCompliant(false)]
	public static JET_wrn JetEnumerateColumns(JET_SESID sesid, JET_TABLEID tableid, int numColumnids, JET_ENUMCOLUMNID[] columnids, out int numColumnValues, out JET_ENUMCOLUMN[] columnValues, JET_PFNREALLOC allocator, IntPtr allocatorContext, int maxDataSize, EnumerateColumnsGrbit grbit)
	{
		return Check(Impl.JetEnumerateColumns(sesid, tableid, numColumnids, columnids, out numColumnValues, out columnValues, allocator, allocatorContext, maxDataSize, grbit));
	}

	public static JET_wrn JetEnumerateColumns(JET_SESID sesid, JET_TABLEID tableid, EnumerateColumnsGrbit grbit, out IEnumerable<EnumeratedColumn> enumeratedColumns)
	{
		return Check(Impl.JetEnumerateColumns(sesid, tableid, grbit, out enumeratedColumns));
	}

	public static void JetDelete(JET_SESID sesid, JET_TABLEID tableid)
	{
		Check(Impl.JetDelete(sesid, tableid));
	}

	public static void JetPrepareUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_prep prep)
	{
		Check(Impl.JetPrepareUpdate(sesid, tableid, prep));
	}

	public static void JetUpdate(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize, out int actualBookmarkSize)
	{
		Check(Impl.JetUpdate(sesid, tableid, bookmark, bookmarkSize, out actualBookmarkSize));
	}

	public static void JetUpdate(JET_SESID sesid, JET_TABLEID tableid)
	{
		Check(Impl.JetUpdate(sesid, tableid, null, 0, out var _));
	}

	public static JET_wrn JetSetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data, int dataSize, SetColumnGrbit grbit, JET_SETINFO setinfo)
	{
		return JetSetColumn(sesid, tableid, columnid, data, dataSize, 0, grbit, setinfo);
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public unsafe static JET_wrn JetSetColumns(JET_SESID sesid, JET_TABLEID tableid, JET_SETCOLUMN[] setcolumns, int numColumns)
	{
		if (setcolumns == null)
		{
			throw new ArgumentNullException("setcolumns");
		}
		if (numColumns < 0 || numColumns > setcolumns.Length)
		{
			throw new ArgumentOutOfRangeException("numColumns", numColumns, "cannot be negative or greater than setcolumns.Length");
		}
		using GCHandleCollection gCHandleCollection = default(GCHandleCollection);
		NATIVE_SETCOLUMN* ptr = stackalloc NATIVE_SETCOLUMN[numColumns];
		byte* ptr2 = stackalloc byte[128];
		int num = 128;
		for (int i = 0; i < numColumns; i = checked(i + 1))
		{
			setcolumns[i].CheckDataSize();
			*(NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))) = setcolumns[i].GetNativeSetcolumn();
			if (setcolumns[i].pvData == null)
			{
				((NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->pvData = IntPtr.Zero;
			}
			else if (num >= setcolumns[i].cbData)
			{
				((NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->pvData = new IntPtr(ptr2);
				Marshal.Copy(setcolumns[i].pvData, setcolumns[i].ibData, ((NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->pvData, setcolumns[i].cbData);
				ptr2 = (byte*)checked(unchecked((nuint)ptr2) + unchecked((nuint)setcolumns[i].cbData));
				num = checked(num - setcolumns[i].cbData);
			}
			else
			{
				byte* ptr3 = (byte*)gCHandleCollection.Add(setcolumns[i].pvData).ToPointer();
				((NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->pvData = new IntPtr((void*)checked(unchecked((nuint)ptr3) + unchecked((nuint)setcolumns[i].ibData)));
			}
		}
		int err = Impl.JetSetColumns(sesid, tableid, ptr, numColumns);
		for (int j = 0; j < numColumns; j = checked(j + 1))
		{
			setcolumns[j].err = (JET_wrn)checked((int)unchecked((NATIVE_SETCOLUMN*)((byte*)ptr + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->err);
		}
		return Check(err);
	}

	public static void JetGetLock(JET_SESID sesid, JET_TABLEID tableid, GetLockGrbit grbit)
	{
		Check(Impl.JetGetLock(sesid, tableid, grbit));
	}

	public static void JetEscrowUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] delta, int deltaSize, byte[] previousValue, int previousValueLength, out int actualPreviousValueLength, EscrowUpdateGrbit grbit)
	{
		Check(Impl.JetEscrowUpdate(sesid, tableid, columnid, delta, deltaSize, previousValue, previousValueLength, out actualPreviousValueLength, grbit));
	}

	public static void JetRegisterCallback(JET_SESID sesid, JET_TABLEID tableid, JET_cbtyp cbtyp, JET_CALLBACK callback, IntPtr context, out JET_HANDLE callbackId)
	{
		Check(Impl.JetRegisterCallback(sesid, tableid, cbtyp, callback, context, out callbackId));
	}

	public static void JetUnregisterCallback(JET_SESID sesid, JET_TABLEID tableid, JET_cbtyp cbtyp, JET_HANDLE callbackId)
	{
		Check(Impl.JetUnregisterCallback(sesid, tableid, cbtyp, callbackId));
	}

	public static JET_wrn JetDefragment(JET_SESID sesid, JET_DBID dbid, string tableName, ref int passes, ref int seconds, DefragGrbit grbit)
	{
		return Check(Impl.JetDefragment(sesid, dbid, tableName, ref passes, ref seconds, grbit));
	}

	public static JET_wrn JetDefragment2(JET_SESID sesid, JET_DBID dbid, string tableName, ref int passes, ref int seconds, JET_CALLBACK callback, DefragGrbit grbit)
	{
		return Check(Impl.JetDefragment2(sesid, dbid, tableName, ref passes, ref seconds, callback, grbit));
	}

	public static JET_wrn JetIdle(JET_SESID sesid, IdleGrbit grbit)
	{
		return Check(Impl.JetIdle(sesid, grbit));
	}

	public static void JetFreeBuffer(IntPtr buffer)
	{
		Check(Impl.JetFreeBuffer(buffer));
	}

	internal static JET_wrn Check(int err)
	{
		if (err < 0)
		{
			throw CreateErrorException(err);
		}
		return (JET_wrn)err;
	}

	private static Exception CreateErrorException(int err)
	{
		Api.HandleError?.Invoke((JET_err)err);
		return EsentExceptionHelper.JetErrToException((JET_err)err);
	}

	public static bool TryGetLock(JET_SESID sesid, JET_TABLEID tableid, GetLockGrbit grbit)
	{
		JET_err jET_err = (JET_err)Impl.JetGetLock(sesid, tableid, grbit);
		if (JET_err.WriteConflict == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	public unsafe static JET_wrn JetSetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data, int dataSize, int dataOffset, SetColumnGrbit grbit, JET_SETINFO setinfo)
	{
		if (dataOffset < 0 || (data != null && dataSize != 0 && dataOffset >= data.Length) || (data == null && dataOffset != 0))
		{
			throw new ArgumentOutOfRangeException("dataOffset", dataOffset, "must be inside the data buffer");
		}
		if (data != null && dataSize > checked(data.Length - dataOffset) && SetColumnGrbit.SizeLV != (grbit & SetColumnGrbit.SizeLV))
		{
			throw new ArgumentOutOfRangeException("dataSize", dataSize, "cannot be greater than the length of the data (unless the SizeLV option is used)");
		}
		fixed (byte* ptr = data)
		{
			return JetSetColumn(sesid, tableid, columnid, new IntPtr((void*)checked(unchecked((nuint)ptr) + unchecked((nuint)dataOffset))), dataSize, grbit, setinfo);
		}
	}

	public unsafe static JET_wrn JetRetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data, int dataSize, int dataOffset, out int actualDataSize, RetrieveColumnGrbit grbit, JET_RETINFO retinfo)
	{
		if (dataOffset < 0 || (data != null && dataSize != 0 && dataOffset >= data.Length) || (data == null && dataOffset != 0))
		{
			throw new ArgumentOutOfRangeException("dataOffset", dataOffset, "must be inside the data buffer");
		}
		if ((data == null && dataSize > 0) || (data != null && dataSize > data.Length))
		{
			throw new ArgumentOutOfRangeException("dataSize", dataSize, "cannot be greater than the length of the data");
		}
		fixed (byte* ptr = data)
		{
			return JetRetrieveColumn(sesid, tableid, columnid, new IntPtr((void*)checked(unchecked((nuint)ptr) + unchecked((nuint)dataOffset))), dataSize, out actualDataSize, grbit, retinfo);
		}
	}

	internal static JET_wrn JetRetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, IntPtr data, int dataSize, out int actualDataSize, RetrieveColumnGrbit grbit, JET_RETINFO retinfo)
	{
		return Check(Impl.JetRetrieveColumn(sesid, tableid, columnid, data, dataSize, out actualDataSize, grbit, retinfo));
	}

	internal static void JetMakeKey(JET_SESID sesid, JET_TABLEID tableid, IntPtr data, int dataSize, MakeKeyGrbit grbit)
	{
		Check(Impl.JetMakeKey(sesid, tableid, data, dataSize, grbit));
	}

	internal static JET_wrn JetSetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, IntPtr data, int dataSize, SetColumnGrbit grbit, JET_SETINFO setinfo)
	{
		return Check(Impl.JetSetColumn(sesid, tableid, columnid, data, dataSize, grbit, setinfo));
	}

	public static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, byte[] data, MakeKeyGrbit grbit)
	{
		if (data == null)
		{
			JetMakeKey(sesid, tableid, null, 0, grbit);
		}
		else if (data.Length == 0)
		{
			JetMakeKey(sesid, tableid, data, data.Length, grbit | MakeKeyGrbit.KeyDataZeroLength);
		}
		else
		{
			JetMakeKey(sesid, tableid, data, data.Length, grbit);
		}
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, string data, Encoding encoding, MakeKeyGrbit grbit)
	{
		CheckEncodingIsValid(encoding);
		if (data == null)
		{
			JetMakeKey(sesid, tableid, null, 0, grbit);
			return;
		}
		if (data.Length == 0)
		{
			JetMakeKey(sesid, tableid, null, 0, grbit | MakeKeyGrbit.KeyDataZeroLength);
			return;
		}
		if (Encoding.Unicode == encoding)
		{
			fixed (char* value = data)
			{
				JetMakeKey(sesid, tableid, new IntPtr(value), checked(data.Length * 2), grbit);
			}
			return;
		}
		byte[] data2 = null;
		try
		{
			data2 = Caches.ColumnCache.Allocate();
			int bytes2;
			fixed (char* chars = data)
			{
				fixed (byte* bytes = data2)
				{
					bytes2 = encoding.GetBytes(chars, data.Length, bytes, data2.Length);
				}
			}
			JetMakeKey(sesid, tableid, data2, bytes2, grbit);
		}
		finally
		{
			if (data2 != null)
			{
				Caches.ColumnCache.Free(ref data2);
			}
		}
	}

	public static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, bool data, MakeKeyGrbit grbit)
	{
		byte data2 = (byte)(data ? byte.MaxValue : 0);
		MakeKey(sesid, tableid, data2, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, byte data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 1, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, short data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 2, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, int data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 4, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, long data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 8, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, Guid data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 16, grbit);
	}

	public static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, DateTime data, MakeKeyGrbit grbit)
	{
		MakeKey(sesid, tableid, data.ToOADate(), grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, float data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 4, grbit);
	}

	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, double data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 8, grbit);
	}

	[CLSCompliant(false)]
	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, ushort data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 2, grbit);
	}

	[CLSCompliant(false)]
	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, uint data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 4, grbit);
	}

	[CLSCompliant(false)]
	public unsafe static void MakeKey(JET_SESID sesid, JET_TABLEID tableid, ulong data, MakeKeyGrbit grbit)
	{
		IntPtr data2 = new IntPtr(&data);
		JetMakeKey(sesid, tableid, data2, 8, grbit);
	}

	public static void BeginSession(JET_INSTANCE instance, out JET_SESID sesid)
	{
		JetBeginSession(instance, out sesid, null, null);
	}

	public static void CreateDatabase(JET_SESID sesid, string database, out JET_DBID dbid, CreateDatabaseGrbit grbit)
	{
		JetCreateDatabase(sesid, database, null, out dbid, grbit);
	}

	public static JET_wrn OpenDatabase(JET_SESID sesid, string database, out JET_DBID dbid, OpenDatabaseGrbit grbit)
	{
		return JetOpenDatabase(sesid, database, null, out dbid, grbit);
	}

	public static JET_wrn OpenTable(JET_SESID sesid, JET_DBID dbid, string tablename, OpenTableGrbit grbit, out JET_TABLEID tableid)
	{
		return JetOpenTable(sesid, dbid, tablename, null, 0, grbit, out tableid);
	}

	public static bool TryOpenTable(JET_SESID sesid, JET_DBID dbid, string tablename, OpenTableGrbit grbit, out JET_TABLEID tableid)
	{
		JET_err jET_err = (JET_err)Impl.JetOpenTable(sesid, dbid, tablename, null, 0, grbit, out tableid);
		if (JET_err.ObjectNotFound == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	public static IDictionary<string, JET_COLUMNID> GetColumnDictionary(JET_SESID sesid, JET_TABLEID tableid)
	{
		JetGetTableColumnInfo(sesid, tableid, string.Empty, out JET_COLUMNLIST columnlist);
		Encoding encoding = (EsentVersion.SupportsWindows8Features ? Encoding.Unicode : LibraryHelpers.EncodingASCII);
		try
		{
			Dictionary<string, JET_COLUMNID> dictionary = new Dictionary<string, JET_COLUMNID>(columnlist.cRecord, StringComparer.OrdinalIgnoreCase);
			if (columnlist.cRecord > 0 && TryMoveFirst(sesid, columnlist.tableid))
			{
				do
				{
					string s = RetrieveColumnAsString(sesid, columnlist.tableid, columnlist.columnidcolumnname, encoding, RetrieveColumnGrbit.None);
					s = StringCache.TryToIntern(s);
					uint value = RetrieveColumnAsUInt32(sesid, columnlist.tableid, columnlist.columnidcolumnid).Value;
					JET_COLUMNID value2 = new JET_COLUMNID
					{
						Value = value
					};
					dictionary.Add(s, value2);
				}
				while (TryMoveNext(sesid, columnlist.tableid));
			}
			return dictionary;
		}
		finally
		{
			JetCloseTable(sesid, columnlist.tableid);
		}
	}

	public static JET_COLUMNID GetTableColumnid(JET_SESID sesid, JET_TABLEID tableid, string columnName)
	{
		JetGetTableColumnInfo(sesid, tableid, columnName, out JET_COLUMNDEF columndef);
		return columndef.columnid;
	}

	public static IEnumerable<ColumnInfo> GetTableColumns(JET_SESID sesid, JET_TABLEID tableid)
	{
		return new GenericEnumerable<ColumnInfo>(() => new TableidColumnInfoEnumerator(sesid, tableid));
	}

	public static IEnumerable<ColumnInfo> GetTableColumns(JET_SESID sesid, JET_DBID dbid, string tablename)
	{
		if (tablename == null)
		{
			throw new ArgumentNullException("tablename");
		}
		return new GenericEnumerable<ColumnInfo>(() => new TableColumnInfoEnumerator(sesid, dbid, tablename));
	}

	public static IEnumerable<IndexInfo> GetTableIndexes(JET_SESID sesid, JET_TABLEID tableid)
	{
		return new GenericEnumerable<IndexInfo>(() => new TableidIndexInfoEnumerator(sesid, tableid));
	}

	public static IEnumerable<IndexInfo> GetTableIndexes(JET_SESID sesid, JET_DBID dbid, string tablename)
	{
		if (tablename == null)
		{
			throw new ArgumentNullException("tablename");
		}
		return new GenericEnumerable<IndexInfo>(() => new TableIndexInfoEnumerator(sesid, dbid, tablename));
	}

	public static IEnumerable<string> GetTableNames(JET_SESID sesid, JET_DBID dbid)
	{
		return new GenericEnumerable<string>(() => new TableNameEnumerator(sesid, dbid));
	}

	public static bool TryJetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXID result, JET_IdxInfo infoLevel)
	{
		int num = Impl.JetGetTableIndexInfo(sesid, tableid, indexname, out result, infoLevel);
		if (num == -1404)
		{
			return false;
		}
		Check(num);
		return true;
	}

	public static string JetGetCurrentIndex(JET_SESID sesid, JET_TABLEID tableid)
	{
		JetGetCurrentIndex(sesid, tableid, out var indexName, 64);
		if (!string.IsNullOrEmpty(indexName))
		{
			return indexName;
		}
		return null;
	}

	public static void MoveBeforeFirst(JET_SESID sesid, JET_TABLEID tableid)
	{
		TryMoveFirst(sesid, tableid);
		TryMovePrevious(sesid, tableid);
	}

	public static void MoveAfterLast(JET_SESID sesid, JET_TABLEID tableid)
	{
		TryMoveLast(sesid, tableid);
		TryMoveNext(sesid, tableid);
	}

	public static bool TryMove(JET_SESID sesid, JET_TABLEID tableid, JET_Move move, MoveGrbit grbit)
	{
		JET_err jET_err = (JET_err)Impl.JetMove(sesid, tableid, (int)move, grbit);
		if (JET_err.NoCurrentRecord == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	public static bool TryMoveFirst(JET_SESID sesid, JET_TABLEID tableid)
	{
		return TryMove(sesid, tableid, JET_Move.First, MoveGrbit.None);
	}

	public static bool TryMoveLast(JET_SESID sesid, JET_TABLEID tableid)
	{
		return TryMove(sesid, tableid, JET_Move.Last, MoveGrbit.None);
	}

	public static bool TryMoveNext(JET_SESID sesid, JET_TABLEID tableid)
	{
		return TryMove(sesid, tableid, JET_Move.Next, MoveGrbit.None);
	}

	public static bool TryMovePrevious(JET_SESID sesid, JET_TABLEID tableid)
	{
		return TryMove(sesid, tableid, JET_Move.Previous, MoveGrbit.None);
	}

	public static bool TrySeek(JET_SESID sesid, JET_TABLEID tableid, SeekGrbit grbit)
	{
		JET_err jET_err = (JET_err)Impl.JetSeek(sesid, tableid, grbit);
		if (JET_err.RecordNotFound == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	public static bool TrySetIndexRange(JET_SESID sesid, JET_TABLEID tableid, SetIndexRangeGrbit grbit)
	{
		JET_err jET_err = (JET_err)Impl.JetSetIndexRange(sesid, tableid, grbit);
		if (JET_err.NoCurrentRecord == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	public static void ResetIndexRange(JET_SESID sesid, JET_TABLEID tableid)
	{
		JET_err jET_err = (JET_err)Impl.JetSetIndexRange(sesid, tableid, SetIndexRangeGrbit.RangeRemove);
		if (JET_err.InvalidOperation != jET_err)
		{
			Check((int)jET_err);
		}
	}

	public static IEnumerable<byte[]> IntersectIndexes(JET_SESID sesid, params JET_TABLEID[] tableids)
	{
		if (tableids == null)
		{
			throw new ArgumentNullException("tableids");
		}
		JET_INDEXRANGE[] ranges = new JET_INDEXRANGE[tableids.Length];
		for (int i = 0; i < tableids.Length; i = checked(i + 1))
		{
			ranges[i] = new JET_INDEXRANGE
			{
				tableid = tableids[i]
			};
		}
		return new GenericEnumerable<byte[]>(() => new IntersectIndexesEnumerator(sesid, ranges));
	}

	public static bool TryGotoBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize)
	{
		JET_err jET_err = (JET_err)Impl.JetGotoBookmark(sesid, tableid, bookmark, bookmarkSize);
		if (JET_err.RecordDeleted == jET_err)
		{
			return false;
		}
		if (JET_err.NoCurrentRecord == jET_err)
		{
			return false;
		}
		Check((int)jET_err);
		return true;
	}

	[Obsolete("Use the overload that takes a JET_IdxInfo parameter, passing in JET_IdxInfo.List")]
	public static void JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string ignored, out JET_INDEXLIST indexlist)
	{
		JetGetIndexInfo(sesid, dbid, tablename, ignored, out indexlist, JET_IdxInfo.List);
	}

	[Obsolete("Use the overload that takes a JET_IdxInfo parameter, passing in JET_IdxInfo.List")]
	public static void JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXLIST indexlist)
	{
		JetGetTableIndexInfo(sesid, tableid, indexname, out indexlist, JET_IdxInfo.List);
	}

	public static JET_wrn Defragment(JET_SESID sesid, JET_DBID dbid, string tableName, DefragGrbit grbit)
	{
		return Check(Impl.Defragment(sesid, dbid, tableName, grbit));
	}

	public static byte[] GetBookmark(JET_SESID sesid, JET_TABLEID tableid)
	{
		byte[] data = null;
		try
		{
			data = Caches.BookmarkCache.Allocate();
			JetGetBookmark(sesid, tableid, data, data.Length, out var actualBookmarkSize);
			return MemoryCache.Duplicate(data, actualBookmarkSize);
		}
		finally
		{
			if (data != null)
			{
				Caches.BookmarkCache.Free(ref data);
			}
		}
	}

	public static byte[] GetSecondaryBookmark(JET_SESID sesid, JET_TABLEID tableid, out byte[] primaryBookmark)
	{
		byte[] data = null;
		byte[] data2 = null;
		primaryBookmark = null;
		try
		{
			data = Caches.BookmarkCache.Allocate();
			data2 = Caches.SecondaryBookmarkCache.Allocate();
			JetGetSecondaryIndexBookmark(sesid, tableid, data2, data2.Length, out var actualSecondaryKeySize, data, data.Length, out var actualPrimaryKeySize, GetSecondaryIndexBookmarkGrbit.None);
			primaryBookmark = MemoryCache.Duplicate(data, actualPrimaryKeySize);
			return MemoryCache.Duplicate(data2, actualSecondaryKeySize);
		}
		finally
		{
			if (data != null)
			{
				Caches.BookmarkCache.Free(ref data);
			}
			if (data2 != null)
			{
				Caches.BookmarkCache.Free(ref data2);
			}
		}
	}

	public static byte[] RetrieveKey(JET_SESID sesid, JET_TABLEID tableid, RetrieveKeyGrbit grbit)
	{
		byte[] data = null;
		try
		{
			data = Caches.BookmarkCache.Allocate();
			JetRetrieveKey(sesid, tableid, data, data.Length, out var actualDataSize, grbit);
			return MemoryCache.Duplicate(data, actualDataSize);
		}
		finally
		{
			if (data != null)
			{
				Caches.BookmarkCache.Free(ref data);
			}
		}
	}

	public static int? RetrieveColumnSize(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnSize(sesid, tableid, columnid, 1, RetrieveColumnGrbit.None);
	}

	public static int? RetrieveColumnSize(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, int itagSequence, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		JET_RETINFO retinfo = new JET_RETINFO
		{
			itagSequence = itagSequence
		};
		int actualDataSize;
		JET_wrn jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, null, 0, out actualDataSize, grbit, retinfo);
		if (JET_wrn.ColumnNull == jET_wrn)
		{
			return null;
		}
		return actualDataSize;
	}

	public static byte[] RetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit, JET_RETINFO retinfo)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		byte[] data = null;
		byte[] array;
		try
		{
			data = Caches.ColumnCache.Allocate();
			array = data;
			JET_wrn jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, array, array.Length, out var actualDataSize, grbit, retinfo);
			if (JET_wrn.ColumnNull == jET_wrn)
			{
				array = null;
			}
			else if (jET_wrn == JET_wrn.Success)
			{
				array = MemoryCache.Duplicate(array, actualDataSize);
			}
			else
			{
				array = new byte[actualDataSize];
				jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, array, array.Length, out actualDataSize, grbit, retinfo);
				if (JET_wrn.BufferTruncated == jET_wrn)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Column size changed from {0} to {1}. The record was probably updated by another thread.", array.Length, actualDataSize));
				}
			}
		}
		finally
		{
			if (data != null)
			{
				Caches.ColumnCache.Free(ref data);
			}
		}
		return array;
	}

	public static byte[] RetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumn(sesid, tableid, columnid, RetrieveColumnGrbit.None, null);
	}

	public static string RetrieveColumnAsString(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsString(sesid, tableid, columnid, Encoding.Unicode, RetrieveColumnGrbit.None);
	}

	public static string RetrieveColumnAsString(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, Encoding encoding)
	{
		return RetrieveColumnAsString(sesid, tableid, columnid, encoding, RetrieveColumnGrbit.None);
	}

	public static string RetrieveColumnAsString(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, Encoding encoding, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		if (Encoding.Unicode == encoding)
		{
			return RetrieveUnicodeString(sesid, tableid, columnid, grbit);
		}
		byte[] data = null;
		try
		{
			data = Caches.ColumnCache.Allocate();
			byte[] array = data;
			JET_wrn jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, array, array.Length, out var actualDataSize, grbit, null);
			if (JET_wrn.ColumnNull == jET_wrn)
			{
				return null;
			}
			if (JET_wrn.BufferTruncated == jET_wrn)
			{
				array = new byte[actualDataSize];
				jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, array, array.Length, out actualDataSize, grbit, null);
				if (JET_wrn.BufferTruncated == jET_wrn)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Column size changed from {0} to {1}. The record was probably updated by another thread.", array.Length, actualDataSize));
				}
			}
			return encoding.GetString(array, 0, actualDataSize);
		}
		finally
		{
			if (data != null)
			{
				Caches.ColumnCache.Free(ref data);
			}
		}
	}

	public static short? RetrieveColumnAsInt16(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsInt16(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static short? RetrieveColumnAsInt16(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		short data2 = default(short);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 2, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 2, wrn, actualDataSize);
	}

	public static int? RetrieveColumnAsInt32(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsInt32(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static int? RetrieveColumnAsInt32(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		int data2 = default(int);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 4, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 4, wrn, actualDataSize);
	}

	public static long? RetrieveColumnAsInt64(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsInt64(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static long? RetrieveColumnAsInt64(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		long data2 = default(long);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 8, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 8, wrn, actualDataSize);
	}

	public static float? RetrieveColumnAsFloat(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsFloat(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static float? RetrieveColumnAsFloat(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		float data2 = default(float);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 4, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 4, wrn, actualDataSize);
	}

	public static double? RetrieveColumnAsDouble(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsDouble(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static double? RetrieveColumnAsDouble(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		double data2 = default(double);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 8, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 8, wrn, actualDataSize);
	}

	public static bool? RetrieveColumnAsBoolean(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsBoolean(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public static bool? RetrieveColumnAsBoolean(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		byte? b = RetrieveColumnAsByte(sesid, tableid, columnid, grbit);
		if (b.HasValue)
		{
			return b.Value != 0;
		}
		return null;
	}

	public static byte? RetrieveColumnAsByte(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsByte(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static byte? RetrieveColumnAsByte(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		byte data2 = default(byte);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 1, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 1, wrn, actualDataSize);
	}

	public static Guid? RetrieveColumnAsGuid(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsGuid(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public unsafe static Guid? RetrieveColumnAsGuid(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		Guid data2 = default(Guid);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 16, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 16, wrn, actualDataSize);
	}

	public static DateTime? RetrieveColumnAsDateTime(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsDateTime(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	public static DateTime? RetrieveColumnAsDateTime(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		double? num = RetrieveColumnAsDouble(sesid, tableid, columnid, grbit);
		if (num.HasValue)
		{
			return Conversions.ConvertDoubleToDateTime(num.Value);
		}
		return null;
	}

	[CLSCompliant(false)]
	public static ushort? RetrieveColumnAsUInt16(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsUInt16(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	[CLSCompliant(false)]
	public unsafe static ushort? RetrieveColumnAsUInt16(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		ushort data2 = default(ushort);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 2, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 2, wrn, actualDataSize);
	}

	[CLSCompliant(false)]
	public static uint? RetrieveColumnAsUInt32(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsUInt32(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	[CLSCompliant(false)]
	public unsafe static uint? RetrieveColumnAsUInt32(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		uint data2 = default(uint);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 4, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 4, wrn, actualDataSize);
	}

	[CLSCompliant(false)]
	public static ulong? RetrieveColumnAsUInt64(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		return RetrieveColumnAsUInt64(sesid, tableid, columnid, RetrieveColumnGrbit.None);
	}

	[CLSCompliant(false)]
	public unsafe static ulong? RetrieveColumnAsUInt64(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
		ulong data2 = default(ulong);
		IntPtr data = new IntPtr(&data2);
		int actualDataSize;
		JET_wrn wrn = JetRetrieveColumn(sesid, tableid, columnid, data, 8, out actualDataSize, grbit, null);
		return CreateReturnValue(data2, 8, wrn, actualDataSize);
	}

	public static void RetrieveColumns(JET_SESID sesid, JET_TABLEID tableid, params ColumnValue[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length == 0)
		{
			throw new ArgumentOutOfRangeException("values", values.Length, "must have at least one value");
		}
		ColumnValue.RetrieveColumns(sesid, tableid, values);
	}

	public static IEnumerable<EnumeratedColumn> EnumerateColumns(JET_SESID sesid, JET_TABLEID tableid, EnumerateColumnsGrbit grbit)
	{
		JetEnumerateColumns(sesid, tableid, grbit, out var enumeratedColumns);
		return enumeratedColumns;
	}

	private static T? CreateReturnValue<T>(T data, int dataSize, JET_wrn wrn, int actualDataSize) where T : struct
	{
		if (JET_wrn.ColumnNull == wrn)
		{
			return null;
		}
		CheckDataSize(dataSize, actualDataSize);
		return data;
	}

	private static void CheckDataSize(int expectedDataSize, int actualDataSize)
	{
		if (actualDataSize != expectedDataSize)
		{
			throw new EsentInvalidColumnException();
		}
	}

	private unsafe static int PinColumnsAndRetrieve(JET_SESID sesid, JET_TABLEID tableid, NATIVE_RETRIEVECOLUMN* nativeretrievecolumns, IList<JET_RETRIEVECOLUMN> retrievecolumns, int numColumns, int i)
	{
		fixed (byte* pvData = retrievecolumns[i].pvData)
		{
			do
			{
				retrievecolumns[i].CheckDataSize();
				retrievecolumns[i].GetNativeRetrievecolumn(ref *(NATIVE_RETRIEVECOLUMN*)((byte*)nativeretrievecolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))));
				((NATIVE_RETRIEVECOLUMN*)((byte*)nativeretrievecolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->pvData = new IntPtr((void*)checked(unchecked((nuint)pvData) + unchecked((nuint)retrievecolumns[i].ibData)));
				i = checked(i + 1);
			}
			while (i < numColumns && retrievecolumns[i].pvData == retrievecolumns[checked(i - 1)].pvData);
			if (i != numColumns)
			{
				return PinColumnsAndRetrieve(sesid, tableid, nativeretrievecolumns, retrievecolumns, numColumns, i);
			}
			return Impl.JetRetrieveColumns(sesid, tableid, nativeretrievecolumns, numColumns);
		}
	}

	private unsafe static string RetrieveUnicodeString(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, RetrieveColumnGrbit grbit)
	{
		char* value = stackalloc char[512];
		JET_wrn jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, new IntPtr(value), 1024, out var actualDataSize, grbit, null);
		if (JET_wrn.ColumnNull == jET_wrn)
		{
			return null;
		}
		if (jET_wrn == JET_wrn.Success)
		{
			return new string(value, 0, actualDataSize / 2);
		}
		string text = new string('\0', actualDataSize / 2);
		fixed (char* value2 = text)
		{
			jET_wrn = JetRetrieveColumn(sesid, tableid, columnid, new IntPtr(value2), actualDataSize, out var actualDataSize2, grbit, null);
			if (JET_wrn.BufferTruncated == jET_wrn)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Column size changed from {0} to {1}. The record was probably updated by another thread.", actualDataSize, actualDataSize2));
			}
		}
		return text;
	}

	public static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, string data, Encoding encoding)
	{
		SetColumn(sesid, tableid, columnid, data, encoding, SetColumnGrbit.None);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, string data, Encoding encoding, SetColumnGrbit grbit)
	{
		CheckEncodingIsValid(encoding);
		if (data == null)
		{
			JetSetColumn(sesid, tableid, columnid, null, 0, grbit, null);
			return;
		}
		if (data.Length == 0)
		{
			JetSetColumn(sesid, tableid, columnid, null, 0, grbit | SetColumnGrbit.ZeroLength, null);
			return;
		}
		if (Encoding.Unicode == encoding)
		{
			fixed (char* value = data)
			{
				JetSetColumn(sesid, tableid, columnid, new IntPtr(value), checked(data.Length * 2), grbit, null);
			}
			return;
		}
		if (encoding.GetMaxByteCount(data.Length) <= Caches.ColumnCache.BufferSize)
		{
			byte[] data2 = null;
			try
			{
				data2 = Caches.ColumnCache.Allocate();
				fixed (char* chars = data)
				{
					fixed (byte* ptr = data2)
					{
						int bytes = encoding.GetBytes(chars, data.Length, ptr, data2.Length);
						JetSetColumn(sesid, tableid, columnid, new IntPtr(ptr), bytes, grbit, null);
						return;
					}
				}
			}
			finally
			{
				if (data2 != null)
				{
					Caches.ColumnCache.Free(ref data2);
				}
			}
		}
		byte[] bytes2 = encoding.GetBytes(data);
		JetSetColumn(sesid, tableid, columnid, bytes2, bytes2.Length, grbit, null);
	}

	public static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data)
	{
		SetColumn(sesid, tableid, columnid, data, SetColumnGrbit.None);
	}

	public static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] data, SetColumnGrbit grbit)
	{
		if (data != null && data.Length == 0)
		{
			grbit |= SetColumnGrbit.ZeroLength;
		}
		int dataSize = ((data != null) ? data.Length : 0);
		JetSetColumn(sesid, tableid, columnid, data, dataSize, grbit, null);
	}

	public static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, bool data)
	{
		byte data2 = (byte)(data ? byte.MaxValue : 0);
		SetColumn(sesid, tableid, columnid, data2);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 1, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, short data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 2, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, int data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 4, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, long data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 8, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, Guid data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 16, SetColumnGrbit.None, null);
	}

	public static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, DateTime data)
	{
		SetColumn(sesid, tableid, columnid, data.ToOADate());
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, float data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 4, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, double data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 8, SetColumnGrbit.None, null);
	}

	public static int EscrowUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, int delta)
	{
		byte[] array = new byte[4];
		JetEscrowUpdate(sesid, tableid, columnid, BitConverter.GetBytes(delta), 4, array, array.Length, out var _, EscrowUpdateGrbit.None);
		return BitConverter.ToInt32(array, 0);
	}

	public static long EscrowUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, long delta)
	{
		byte[] array = new byte[8];
		JetEscrowUpdate(sesid, tableid, columnid, BitConverter.GetBytes(delta), 8, array, array.Length, out var _, EscrowUpdateGrbit.None);
		return BitConverter.ToInt64(array, 0);
	}

	[CLSCompliant(false)]
	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, ushort data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 2, SetColumnGrbit.None, null);
	}

	[CLSCompliant(false)]
	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, uint data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 4, SetColumnGrbit.None, null);
	}

	[CLSCompliant(false)]
	public unsafe static void SetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, ulong data)
	{
		IntPtr data2 = new IntPtr(&data);
		JetSetColumn(sesid, tableid, columnid, data2, 8, SetColumnGrbit.None, null);
	}

	public unsafe static void SetColumns(JET_SESID sesid, JET_TABLEID tableid, params ColumnValue[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length == 0)
		{
			throw new ArgumentOutOfRangeException("values", values.Length, "must have at least one value");
		}
		NATIVE_SETCOLUMN* nativeColumns = stackalloc NATIVE_SETCOLUMN[values.Length];
		Check(values[0].SetColumns(sesid, tableid, values, nativeColumns, 0));
	}

	private static void CheckEncodingIsValid(Encoding encoding)
	{
		int codePage = encoding.CodePage;
		if (20127 != codePage && 1200 != codePage)
		{
			throw new ArgumentOutOfRangeException("encoding", codePage, "Invalid Encoding type. Only ASCII and Unicode encodings are allowed");
		}
	}
}
