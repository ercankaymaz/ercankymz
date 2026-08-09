using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Isam.Esent.Interop;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;

namespace Xbim.IO.Esent;

public class EsentEntityCursor : EsentCursor
{
	private ILogger _logger;

	private const string ifcEntityTableName = "IfcEntities";

	private const string entityTableTypeLabelIndex = "EntByTypeLabel";

	private const string entityTableLabelIndex = "EntByLabel";

	private const string colNameEntityLabel = "EntityLabel";

	private const string colNameIfcType = "IfcType";

	private const string colNameEntityData = "EntityData";

	private const string colNameIsIndexedClass = "IsIndexedClass";

	private JET_COLUMNID _colIdEntityLabel;

	private JET_COLUMNID _colIdIfcType;

	private JET_COLUMNID _colIdEntityData;

	private JET_COLUMNID _colIdIsIndexedClass;

	private Int32ColumnValue _colValEntityLabel;

	private Int16ColumnValue _colValTypeId;

	private BytesColumnValue _colValData;

	private BoolColumnValue _colValIsIndexedClass;

	private ColumnValue[] _colValues;

	private static string ifcEntityIndexTableName = "IfcEntitiesIndex";

	private const string colNameSecondaryKey = "SecondaryKey";

	private JET_TABLEID _indexTable;

	private JET_COLUMNID _colIdIdxIfcType;

	private JET_COLUMNID _colIdIdxKey;

	private JET_COLUMNID _colIdIdxEntityLabel;

	private Int16ColumnValue _colValIdxIfcType;

	private Int32ColumnValue _colValIdxKey;

	private Int32ColumnValue _colValIdxEntityLabel;

	private ColumnValue[] _colIdxValues;

	public ColumnValue[] ColumnValues => _colValues;

	public string PrimaryIndex => "EntByTypeLabel";

	public JET_COLUMNID ColIdEntityLabel => _colIdEntityLabel;

	public JET_COLUMNID ColIdIfcType => _colIdIfcType;

	public JET_COLUMNID ColIdEntityData => _colIdEntityData;

	public static implicit operator JET_TABLEID(EsentEntityCursor table)
	{
		return table;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			Api.JetCloseTable(Sesid, _indexTable);
		}
		catch (Exception)
		{
		}
		base.Dispose(disposing);
	}

	internal static void CreateTable(JET_SESID sesid, JET_DBID dbid)
	{
		JET_TABLEID tableid;
		using (Transaction transaction = new Transaction(sesid))
		{
			Api.JetCreateTable(sesid, dbid, "IfcEntities", 8, 100, out tableid);
			JET_COLUMNDEF columndef = new JET_COLUMNDEF
			{
				coltyp = JET_coltyp.Long,
				grbit = ColumndefGrbit.ColumnNotNULL
			};
			Api.JetAddColumn(sesid, tableid, "EntityLabel", columndef, null, 0, out var columnid);
			columndef = new JET_COLUMNDEF
			{
				coltyp = JET_coltyp.Short,
				grbit = ColumndefGrbit.ColumnMaybeNull
			};
			Api.JetAddColumn(sesid, tableid, "IfcType", columndef, null, 0, out columnid);
			columndef = new JET_COLUMNDEF
			{
				coltyp = JET_coltyp.LongBinary,
				grbit = ColumndefGrbit.ColumnMaybeNull
			};
			Api.JetAddColumn(sesid, tableid, "EntityData", columndef, null, 0, out columnid);
			columndef = new JET_COLUMNDEF
			{
				coltyp = JET_coltyp.Bit,
				grbit = ColumndefGrbit.None
			};
			Api.JetAddColumn(sesid, tableid, "IsIndexedClass", columndef, null, 0, out columnid);
			string text = string.Format("+{0}\0\0", "EntityLabel");
			Api.JetCreateIndex(sesid, tableid, "EntByLabel", CreateIndexGrbit.IndexPrimary, text, text.Length, 100);
			Api.JetCloseTable(sesid, tableid);
			transaction.Commit(CommitTransactionGrbit.LazyFlush);
		}
		using Transaction transaction2 = new Transaction(sesid);
		Api.JetCreateTable(sesid, dbid, ifcEntityIndexTableName, 8, 100, out tableid);
		JET_COLUMNDEF columndef2 = new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Short,
			grbit = ColumndefGrbit.ColumnNotNULL
		};
		Api.JetAddColumn(sesid, tableid, "IfcType", columndef2, null, 0, out var columnid2);
		columndef2 = new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = ColumndefGrbit.ColumnNotNULL
		};
		Api.JetAddColumn(sesid, tableid, "SecondaryKey", columndef2, null, 0, out columnid2);
		Api.JetAddColumn(sesid, tableid, "EntityLabel", columndef2, null, 0, out columnid2);
		string text2 = string.Format("+{0}\0{1}\0{2}\0\0", "IfcType", "SecondaryKey", "EntityLabel");
		Api.JetCreateIndex(sesid, tableid, "EntByLabel", CreateIndexGrbit.IndexPrimary, text2, text2.Length, 100);
		Api.JetCloseTable(sesid, tableid);
		transaction2.Commit(CommitTransactionGrbit.LazyFlush);
	}

	private void InitColumns()
	{
		_colIdEntityLabel = Api.GetTableColumnid(Sesid, Table, "EntityLabel");
		_colIdIfcType = Api.GetTableColumnid(Sesid, Table, "IfcType");
		_colIdEntityData = Api.GetTableColumnid(Sesid, Table, "EntityData");
		_colIdIsIndexedClass = Api.GetTableColumnid(Sesid, Table, "IsIndexedClass");
		_colValEntityLabel = new Int32ColumnValue
		{
			Columnid = _colIdEntityLabel
		};
		_colValTypeId = new Int16ColumnValue
		{
			Columnid = _colIdIfcType
		};
		_colValData = new BytesColumnValue
		{
			Columnid = _colIdEntityData
		};
		_colValIsIndexedClass = new BoolColumnValue
		{
			Columnid = _colIdIsIndexedClass
		};
		_colValues = new ColumnValue[4] { _colValEntityLabel, _colValTypeId, _colValData, _colValIsIndexedClass };
		_colIdIdxIfcType = Api.GetTableColumnid(Sesid, _indexTable, "IfcType");
		_colValIdxIfcType = new Int16ColumnValue
		{
			Columnid = _colIdIdxIfcType
		};
		_colIdIdxKey = Api.GetTableColumnid(Sesid, _indexTable, "SecondaryKey");
		_colValIdxKey = new Int32ColumnValue
		{
			Columnid = _colIdIdxKey
		};
		_colIdIdxEntityLabel = Api.GetTableColumnid(Sesid, _indexTable, "EntityLabel");
		_colValIdxEntityLabel = new Int32ColumnValue
		{
			Columnid = _colIdIdxEntityLabel
		};
		_colIdxValues = new ColumnValue[3] { _colValIdxIfcType, _colValIdxKey, _colValIdxEntityLabel };
	}

	public EsentEntityCursor(EsentModel model, string database)
		: this(model, database, OpenDatabaseGrbit.None, null)
	{
	}

	public EsentEntityCursor(EsentModel model, string database, OpenDatabaseGrbit mode, ILoggerFactory loggerFactory)
		: base(model, database, mode)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		_logger = loggerFactory.CreateLogger<EsentEntityCursor>();
		Api.JetOpenTable(Sesid, DbId, "IfcEntities", null, 0, mode switch
		{
			OpenDatabaseGrbit.Exclusive => OpenTableGrbit.DenyWrite, 
			OpenDatabaseGrbit.ReadOnly => OpenTableGrbit.ReadOnly, 
			_ => OpenTableGrbit.None, 
		}, out Table);
		Api.JetOpenTable(Sesid, DbId, ifcEntityIndexTableName, null, 0, mode switch
		{
			OpenDatabaseGrbit.Exclusive => OpenTableGrbit.DenyWrite, 
			OpenDatabaseGrbit.ReadOnly => OpenTableGrbit.ReadOnly, 
			_ => OpenTableGrbit.None, 
		}, out _indexTable);
		InitColumns();
	}

	internal void SetEntityRowValues(int primaryKey, short type, byte[] data, bool? index)
	{
		_colValEntityLabel.Value = primaryKey;
		_colValTypeId.Value = type;
		_colValData.Value = data;
		_colValIsIndexedClass.Value = index;
	}

	internal void SetEntityIndexRowValues(short type, int indexKey, int primaryKey)
	{
		_colValIdxEntityLabel.Value = primaryKey;
		_colValIdxIfcType.Value = type;
		_colValIdxKey.Value = indexKey;
	}

	internal void WriteHeader(IStepFileHeader ifcFileHeader)
	{
		MemoryStream memoryStream = new MemoryStream(4096);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		ifcFileHeader.Write(binaryWriter);
		if (Api.TryMoveFirst(Sesid, GlobalsTable))
		{
			using (Update update = new Update(Sesid, GlobalsTable, JET_prep.Replace))
			{
				Api.SetColumn(Sesid, GlobalsTable, IfcHeaderColumn, memoryStream.ToArray());
				update.Save();
			}
		}
	}

	internal IStepFileHeader ReadHeader()
	{
		if (Api.TryMoveFirst(Sesid, GlobalsTable))
		{
			byte[] array = Api.RetrieveColumn(Sesid, GlobalsTable, IfcHeaderColumn);
			if (array == null)
			{
				return null;
			}
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));
			StepFileHeader stepFileHeader = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, Model);
			stepFileHeader.Read(binaryReader);
			return stepFileHeader;
		}
		return null;
	}

	internal void UpdateEntity(IPersistEntity toWrite)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter entityWriter = new BinaryWriter(memoryStream);
		toWrite.WriteEntity(entityWriter, Model.Metadata);
		ExpressType expressType = Model.Metadata.ExpressType(toWrite);
		UpdateEntity(toWrite.EntityLabel, expressType.TypeId, expressType.GetIndexedValues(toWrite), memoryStream.ToArray(), expressType.IndexedClass);
	}

	internal void UpdateEntity(int currentLabel, short typeId, IEnumerable<int> indexKeys, byte[] data, bool? indexed)
	{
		try
		{
			if (indexed.HasValue && !indexed.Value)
			{
				indexed = null;
			}
			if (!TrySeekEntityLabel(currentLabel))
			{
				throw new XbimException("Attempt to update an entity that does not exist in the model");
			}
			using (Update update = new Update(Sesid, Table, JET_prep.Replace))
			{
				SetEntityRowValues(currentLabel, typeId, data, indexed);
				Api.SetColumns(Sesid, Table, _colValues);
				update.Save();
			}
			if (indexed.HasValue && indexed.Value && !TrySeekEntityType(typeId, -1, currentLabel))
			{
				throw new XbimException("It is illegal to change an entities type, please delete and insert the entity as a new type");
			}
			if (indexKeys == null || !indexKeys.Any())
			{
				return;
			}
			SetEntityIndexRowValues(typeId, -1, currentLabel);
			foreach (int item in indexKeys.Distinct().Cast<int>())
			{
				if (!TrySeekEntityType(typeId, item, currentLabel))
				{
					using Update update2 = new Update(Sesid, _indexTable, JET_prep.Insert);
					_colValIdxKey.Value = item;
					Api.SetColumns(Sesid, _indexTable, _colIdxValues);
					update2.Save();
				}
			}
		}
		catch (Exception inner)
		{
			throw new XbimException("Error updating an entity in the database", inner);
		}
	}

	internal void AddEntity(IPersistEntity toWrite)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter entityWriter = new BinaryWriter(memoryStream);
		toWrite.WriteEntity(entityWriter, Model.Metadata);
		ExpressType expressType = Model.Metadata.ExpressType(toWrite);
		AddEntity(toWrite.EntityLabel, expressType.TypeId, expressType.GetIndexedValues(toWrite), memoryStream.ToArray(), expressType.IndexedClass);
	}

	internal void AddEntity(int currentLabel, short typeId, IEnumerable<int> indexKeys, byte[] data, bool? indexed, EsentLazyDBTransaction? trans = null)
	{
		try
		{
			if (indexed.HasValue && !indexed.Value)
			{
				indexed = null;
			}
			using (Update update = new Update(Sesid, Table, JET_prep.Insert))
			{
				try
				{
					SetEntityRowValues(currentLabel, typeId, data, indexed);
					Api.SetColumns(Sesid, Table, _colValues);
					update.Save();
					UpdateCount(1);
				}
				catch (Exception ex)
				{
					update.Cancel();
					string message = $"Failed to add (probably clashing) entity #{currentLabel} to the database";
					_logger?.LogError(message, ex);
					return;
				}
			}
			SetEntityIndexRowValues(typeId, -1, currentLabel);
			if (indexed.HasValue && indexed.Value)
			{
				using Update update2 = new Update(Sesid, _indexTable, JET_prep.Insert);
				Api.SetColumns(Sesid, _indexTable, _colIdxValues);
				update2.Save();
			}
			if (indexKeys == null)
			{
				return;
			}
			int num = 0;
			foreach (int item in indexKeys.Distinct())
			{
				using Update update3 = new Update(Sesid, _indexTable, JET_prep.Insert);
				_colValIdxKey.Value = item;
				Api.SetColumns(Sesid, _indexTable, _colIdxValues);
				update3.Save();
				num++;
				if (trans.HasValue && num % 100 == 0)
				{
					trans.Value.Commit();
					trans.Value.Begin();
				}
			}
		}
		catch (Exception inner)
		{
			throw new XbimException($"Failed to add entity #{currentLabel} to the database", inner);
		}
	}

	internal XbimInstanceHandle AddEntity(Type type)
	{
		int num = RetrieveHighestLabel();
		ExpressType expressType = Model.Metadata.ExpressType(type);
		XbimInstanceHandle result = new XbimInstanceHandle(Model, num + 1, expressType.TypeId);
		AddEntity(result.EntityLabel, result.EntityTypeId, null, null, expressType.IndexedClass);
		return result;
	}

	internal XbimInstanceHandle AddEntity(Type type, int entityLabel)
	{
		ExpressType expressType = Model.Metadata.ExpressType(type);
		XbimInstanceHandle result = new XbimInstanceHandle(Model, entityLabel, expressType.TypeId);
		AddEntity(result.EntityLabel, result.EntityTypeId, null, null, expressType.IndexedClass);
		return result;
	}

	public bool TrySeekEntityLabel(int key)
	{
		Api.MakeKey(Sesid, Table, key, MakeKeyGrbit.NewKey);
		return Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ);
	}

	public bool TrySeekEntityType(short typeId, out XbimInstanceHandle ih)
	{
		return TrySeekEntityType(typeId, out ih, -1);
	}

	private bool TrySeekEntityType(short typeId, int key, int currentLabel)
	{
		Api.MakeKey(Sesid, _indexTable, typeId, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, _indexTable, key, MakeKeyGrbit.None);
		Api.MakeKey(Sesid, _indexTable, currentLabel, MakeKeyGrbit.None);
		return Api.TrySeek(Sesid, _indexTable, SeekGrbit.SeekEQ);
	}

	public bool TrySeekEntityType(short typeId, out XbimInstanceHandle ih, int lookupKey)
	{
		Api.MakeKey(Sesid, _indexTable, typeId, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, _indexTable, lookupKey, MakeKeyGrbit.None);
		if (Api.TrySeek(Sesid, _indexTable, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, _indexTable, typeId, MakeKeyGrbit.NewKey);
			Api.MakeKey(Sesid, _indexTable, lookupKey, MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, _indexTable, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				ih = new XbimInstanceHandle(Model, Api.RetrieveColumnAsInt32(Sesid, _indexTable, _colIdIdxEntityLabel, RetrieveColumnGrbit.RetrieveFromIndex), Api.RetrieveColumnAsInt16(Sesid, _indexTable, _colIdIdxIfcType, RetrieveColumnGrbit.RetrieveFromIndex));
				return true;
			}
		}
		ih = default(XbimInstanceHandle);
		return false;
	}

	public bool TrySeekEntityType(short typeId)
	{
		Api.MakeKey(Sesid, _indexTable, typeId, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, _indexTable, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, _indexTable, typeId, MakeKeyGrbit.NewKey);
			return Api.TrySetIndexRange(Sesid, _indexTable, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit);
		}
		return false;
	}

	internal XbimInstanceHandle GetInstanceHandle()
	{
		int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdEntityLabel);
		short? num2 = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcType);
		return new XbimInstanceHandle(Model, num.Value, num2.Value);
	}

	internal byte[] GetProperties()
	{
		return Api.RetrieveColumn(Sesid, Table, _colIdEntityData);
	}

	internal override int RetrieveCount()
	{
		return Api.RetrieveColumnAsInt32(Sesid, GlobalsTable, EntityCountColumn).Value;
	}

	protected override void UpdateCount(int delta)
	{
		Api.EscrowUpdate(Sesid, GlobalsTable, EntityCountColumn, delta);
	}

	internal int RetrieveHighestLabel()
	{
		if (TryMoveLast())
		{
			int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdEntityLabel, RetrieveColumnGrbit.RetrieveFromIndex);
			if (num.HasValue)
			{
				return num.Value;
			}
		}
		return 0;
	}

	public short GetIfcType()
	{
		short? num = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcType);
		if (num.HasValue)
		{
			return num.Value;
		}
		return 0;
	}

	public int GetLabel()
	{
		int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdEntityLabel);
		if (num.HasValue)
		{
			return num.Value;
		}
		return 0;
	}

	public bool TryMoveNextEntityType(out XbimInstanceHandle ih)
	{
		if (Api.TryMoveNext(Sesid, _indexTable))
		{
			ih = new XbimInstanceHandle(Model, Api.RetrieveColumnAsInt32(Sesid, _indexTable, _colIdIdxEntityLabel, RetrieveColumnGrbit.RetrieveFromIndex), Api.RetrieveColumnAsInt16(Sesid, _indexTable, _colIdIdxIfcType, RetrieveColumnGrbit.RetrieveFromIndex));
			return true;
		}
		ih = default(XbimInstanceHandle);
		return false;
	}

	internal bool TryMoveFirstLabel(out int label)
	{
		if (TryMoveFirst())
		{
			label = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdEntityLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
			return true;
		}
		label = 0;
		return false;
	}

	internal bool TryMoveNextLabel(out int label)
	{
		if (TryMoveNext())
		{
			label = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdEntityLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
			return true;
		}
		label = 0;
		return false;
	}
}
