using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Interop;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

public class XbimGeometryCursor : EsentCursor
{
	public static string GeometryTableName = "Geometry";

	private const string GeometryTablePrimaryIndex = "GeomPrimaryIndex";

	private const string GeometryTableGeomTypeIndex = "GeomTypeIndex";

	private const string GeometryTableStyleIndex = "GeomStyleIndex";

	private const string GeometryTableHashIndex = "GeomHashIndex";

	private const string ColNameGeometryLabel = "GeometryLabel";

	private const string ColNameProductLabel = "GeomProductLabel";

	private const string ColNameGeomType = "GeomType";

	private const string ColNameProductIfcTypeId = "GeomIfcType";

	private const string ColNameSubPart = "GeomSubPart";

	private const string ColNameTransformMatrix = "GeomTransformMatrix";

	private const string ColNameShapeData = "GeomShapeData";

	private const string ColNameGeometryHash = "GeomGeometryHash";

	private const string ColNameStyleLabel = "GeomRepStyleLabel";

	private JET_COLUMNID _colIdProductLabel;

	private JET_COLUMNID _colIdGeometryLabel;

	private JET_COLUMNID _colIdGeomType;

	private JET_COLUMNID _colIdProductIfcTypeId;

	private JET_COLUMNID _colIdGeometryHash;

	private JET_COLUMNID _colIdShapeData;

	private JET_COLUMNID _colIdSubPart;

	private JET_COLUMNID _colIdTransformMatrix;

	private JET_COLUMNID _colIdStyleLabel;

	private Int32ColumnValue _colValGeometryLabel;

	private Int32ColumnValue _colValProductLabel;

	private ByteColumnValue _colValGeomType;

	private Int16ColumnValue _colValProductIfcTypeId;

	private Int16ColumnValue _colValSubPart;

	private BytesColumnValue _colValTransformMatrix;

	private BytesColumnValue _colValShapeData;

	private Int32ColumnValue _colValGeometryHash;

	private Int32ColumnValue _colValStyleLabel;

	private ColumnValue[] _colValues;

	public string PrimaryIndex => "GeomPrimaryIndex";

	internal static void CreateTable(JET_SESID sesid, JET_DBID dbid)
	{
		Api.JetCreateTable(sesid, dbid, GeometryTableName, 8, 80, out var tableid);
		using Transaction transaction = new Transaction(sesid);
		JET_COLUMNDEF jET_COLUMNDEF = new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = ColumndefGrbit.ColumnAutoincrement
		};
		Api.JetAddColumn(sesid, tableid, "GeometryLabel", jET_COLUMNDEF, null, 0, out var columnid);
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "GeomProductLabel", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.UnsignedByte;
		Api.JetAddColumn(sesid, tableid, "GeomType", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Short;
		Api.JetAddColumn(sesid, tableid, "GeomIfcType", jET_COLUMNDEF, null, 0, out columnid);
		Api.JetAddColumn(sesid, tableid, "GeomSubPart", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Binary;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnMaybeNull;
		Api.JetAddColumn(sesid, tableid, "GeomTransformMatrix", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.LongBinary;
		Api.JetAddColumn(sesid, tableid, "GeomShapeData", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "GeomGeometryHash", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "GeomRepStyleLabel", jET_COLUMNDEF, null, 0, out columnid);
		string text = string.Format("+{0}\0\0", "GeometryLabel");
		Api.JetCreateIndex(sesid, tableid, "GeomPrimaryIndex", CreateIndexGrbit.IndexPrimary, text, text.Length, 100);
		text = string.Format("+{0}\0\0", "GeomGeometryHash");
		Api.JetCreateIndex(sesid, tableid, "GeomHashIndex", CreateIndexGrbit.IndexDisallowNull, text, text.Length, 100);
		text = string.Format("+{0}\0{1}\0{2}\0{3}\0{4}\0\0", "GeomType", "GeomIfcType", "GeomProductLabel", "GeomSubPart", "GeomRepStyleLabel");
		Api.JetCreateIndex(sesid, tableid, "GeomTypeIndex", CreateIndexGrbit.IndexUnique, text, text.Length, 100);
		text = string.Format("+{0}\0{1}\0{2}\0{3}\0{4}\0\0", "GeomType", "GeomRepStyleLabel", "GeomIfcType", "GeomProductLabel", "GeometryLabel");
		Api.JetCreateIndex(sesid, tableid, "GeomStyleIndex", CreateIndexGrbit.None, text, text.Length, 100);
		Api.JetCloseTable(sesid, tableid);
		transaction.Commit(CommitTransactionGrbit.LazyFlush);
	}

	private void InitColumns()
	{
		_colIdGeometryLabel = Api.GetTableColumnid(Sesid, Table, "GeometryLabel");
		_colIdGeomType = Api.GetTableColumnid(Sesid, Table, "GeomType");
		_colIdProductIfcTypeId = Api.GetTableColumnid(Sesid, Table, "GeomIfcType");
		_colIdProductLabel = Api.GetTableColumnid(Sesid, Table, "GeomProductLabel");
		_colIdSubPart = Api.GetTableColumnid(Sesid, Table, "GeomSubPart");
		_colIdTransformMatrix = Api.GetTableColumnid(Sesid, Table, "GeomTransformMatrix");
		_colIdShapeData = Api.GetTableColumnid(Sesid, Table, "GeomShapeData");
		_colIdGeometryHash = Api.GetTableColumnid(Sesid, Table, "GeomGeometryHash");
		_colIdStyleLabel = Api.GetTableColumnid(Sesid, Table, "GeomRepStyleLabel");
		_colValGeometryLabel = new Int32ColumnValue
		{
			Columnid = _colIdGeometryLabel
		};
		_colValGeomType = new ByteColumnValue
		{
			Columnid = _colIdGeomType
		};
		_colValProductIfcTypeId = new Int16ColumnValue
		{
			Columnid = _colIdProductIfcTypeId
		};
		_colValProductLabel = new Int32ColumnValue
		{
			Columnid = _colIdProductLabel
		};
		_colValSubPart = new Int16ColumnValue
		{
			Columnid = _colIdSubPart
		};
		_colValTransformMatrix = new BytesColumnValue
		{
			Columnid = _colIdTransformMatrix
		};
		_colValShapeData = new BytesColumnValue
		{
			Columnid = _colIdShapeData
		};
		_colValGeometryHash = new Int32ColumnValue
		{
			Columnid = _colIdGeometryHash
		};
		_colValStyleLabel = new Int32ColumnValue
		{
			Columnid = _colIdStyleLabel
		};
		_colValues = new ColumnValue[8] { _colValGeomType, _colValProductLabel, _colValProductIfcTypeId, _colValSubPart, _colValTransformMatrix, _colValShapeData, _colValGeometryHash, _colValStyleLabel };
	}

	public XbimGeometryCursor(EsentModel model, string database)
		: this(model, database, OpenDatabaseGrbit.None)
	{
	}

	public XbimGeometryCursor(EsentModel model, string database, OpenDatabaseGrbit mode)
		: base(model, database, mode)
	{
		Api.JetOpenTable(Sesid, DbId, GeometryTableName, null, 0, mode switch
		{
			OpenDatabaseGrbit.Exclusive => OpenTableGrbit.DenyWrite, 
			OpenDatabaseGrbit.ReadOnly => OpenTableGrbit.ReadOnly, 
			_ => OpenTableGrbit.None, 
		}, out Table);
		InitColumns();
	}

	public int AddGeometry(int prodLabel, XbimGeometryType type, short expressType, byte[] transform, byte[] shapeData, short subPart = 0, int styleLabel = 0, int? geometryHash = null)
	{
		int result = -1;
		using (Update update = new Update(Sesid, Table, JET_prep.Insert))
		{
			_colValProductLabel.Value = prodLabel;
			_colValGeomType.Value = (byte)type;
			_colValProductIfcTypeId.Value = expressType;
			_colValSubPart.Value = subPart;
			_colValTransformMatrix.Value = transform;
			_colValShapeData.Value = shapeData;
			_colValGeometryHash.Value = geometryHash.GetValueOrDefault();
			_colValStyleLabel.Value = styleLabel;
			Api.SetColumns(Sesid, Table, _colValues);
			try
			{
				int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel, RetrieveColumnGrbit.RetrieveCopy);
				if (num.HasValue)
				{
					result = num.Value;
				}
				update.Save();
				UpdateCount(1);
			}
			catch (Exception)
			{
			}
		}
		return result;
	}

	public int AddMapGeometry(int geomId, int prodLabel, short expressType, byte[] transform, int styleLabel = 0)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, geomId, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			using (Update update = new Update(Sesid, Table, JET_prep.InsertCopy))
			{
				Api.SetColumn(Sesid, Table, _colIdProductLabel, prodLabel);
				Api.SetColumn(Sesid, Table, _colIdProductIfcTypeId, expressType);
				Api.SetColumn(Sesid, Table, _colIdTransformMatrix, transform);
				if (styleLabel > 0)
				{
					Api.SetColumn(Sesid, Table, _colIdStyleLabel, styleLabel);
				}
				else
				{
					Api.SetColumn(Sesid, Table, _colIdStyleLabel, -expressType);
				}
				UpdateCount(1);
				int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel, RetrieveColumnGrbit.RetrieveCopy);
				update.Save();
				_ = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryHash, RetrieveColumnGrbit.RetrieveCopy).Value;
				_ = Api.RetrieveColumnAsByte(Sesid, Table, _colIdGeomType, RetrieveColumnGrbit.RetrieveCopy).Value;
				return num.Value;
			}
		}
		throw new XbimException("Mapped geometry not found = #" + geomId);
	}

	internal IEnumerable<XbimGeometryData> GeometryData(short typeId, int productLabel, XbimGeometryType geomType)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomTypeIndex");
		Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, Table, typeId, MakeKeyGrbit.None);
		Api.MakeKey(Sesid, Table, productLabel, MakeKeyGrbit.None);
		if (!Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			yield break;
		}
		Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, Table, typeId, MakeKeyGrbit.None);
		Api.MakeKey(Sesid, Table, productLabel, MakeKeyGrbit.FullColumnEndLimit);
		if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
		{
			do
			{
				Api.RetrieveColumns(Sesid, Table, _colValues);
				_colValGeometryLabel.Value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
				yield return new XbimGeometryData(_colValGeometryLabel.Value.Value, productLabel, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
			}
			while (Api.TryMoveNext(Sesid, Table));
		}
	}

	internal IEnumerable<XbimGeometryData> GetGeometryData(XbimGeometryType ofType)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomTypeIndex");
		Api.MakeKey(Sesid, Table, (byte)ofType, MakeKeyGrbit.NewKey);
		if (!Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			yield break;
		}
		Api.MakeKey(Sesid, Table, (byte)ofType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
		if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
		{
			do
			{
				Api.RetrieveColumns(Sesid, Table, _colValues);
				_colValGeometryLabel.Value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
				yield return new XbimGeometryData(_colValGeometryLabel.Value.Value, _colValProductLabel.Value.Value, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
			}
			while (Api.TryMoveNext(Sesid, Table));
		}
	}

	internal override int RetrieveCount()
	{
		return Api.RetrieveColumnAsInt32(Sesid, GlobalsTable, GeometryCountColumn).Value;
	}

	protected override void UpdateCount(int delta)
	{
		Api.EscrowUpdate(Sesid, GlobalsTable, GeometryCountColumn, delta);
	}

	internal XbimGeometryHandleCollection GetGeometryHandles(XbimGeometryType geomType, XbimGeometrySort sortOrder)
	{
		return sortOrder switch
		{
			XbimGeometrySort.OrderByIfcSurfaceStyleThenIfcType => GetGeometryHandlesBySurfaceStyle(geomType), 
			XbimGeometrySort.OrderByIfcTypeThenIfcProduct => GetGeometryHandlesByIfcType(geomType), 
			XbimGeometrySort.OrderByGeometryID => GetGeometryHandlesById(geomType), 
			_ => throw new XbimException("Illegal geometry sort order"), 
		};
	}

	private XbimGeometryHandleCollection GetGeometryHandlesById(XbimGeometryType geomType)
	{
		XbimGeometryHandleCollection xbimGeometryHandleCollection = new XbimGeometryHandleCollection();
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				do
				{
					int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel);
					short? num2 = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdProductIfcTypeId);
					int? num3 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdProductLabel);
					int? num4 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
					int? num5 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryHash);
					xbimGeometryHandleCollection.Add(new XbimGeometryHandle(num4.Value, geomType, num3.Value, num2.Value, num.Value, num5.Value));
				}
				while (Api.TryMoveNext(Sesid, Table));
			}
		}
		return xbimGeometryHandleCollection;
	}

	private XbimGeometryHandleCollection GetGeometryHandlesByIfcType(XbimGeometryType geomType)
	{
		XbimGeometryHandleCollection xbimGeometryHandleCollection = new XbimGeometryHandleCollection();
		Api.JetSetCurrentIndex(Sesid, Table, "GeomTypeIndex");
		Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				do
				{
					int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex);
					short? num2 = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdProductIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex);
					int? num3 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdProductLabel, RetrieveColumnGrbit.RetrieveFromIndex);
					int? num4 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel, RetrieveColumnGrbit.RetrieveFromIndex);
					xbimGeometryHandleCollection.Add(new XbimGeometryHandle(num4.Value, geomType, num3.Value, num2.Value, num.Value, num4.Value));
				}
				while (Api.TryMoveNext(Sesid, Table));
			}
		}
		return xbimGeometryHandleCollection;
	}

	private XbimGeometryHandleCollection GetGeometryHandlesBySurfaceStyle(XbimGeometryType geomType)
	{
		XbimGeometryHandleCollection xbimGeometryHandleCollection = new XbimGeometryHandleCollection();
		Api.JetSetCurrentIndex(Sesid, Table, "GeomStyleIndex");
		Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, (byte)geomType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				do
				{
					int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex);
					short? num2 = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdProductIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex);
					int? num3 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdProductLabel, RetrieveColumnGrbit.RetrieveFromIndex);
					xbimGeometryHandleCollection.Add(new XbimGeometryHandle(Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value, geomType, num3.Value, num2.Value, num.Value));
				}
				while (Api.TryMoveNext(Sesid, Table));
			}
		}
		return xbimGeometryHandleCollection;
	}

	internal XbimGeometryHandle GetGeometryHandle(int geometryLabel)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, geometryLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			Api.RetrieveColumns(Sesid, Table, _colValues);
			int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel);
			short? num2 = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdProductIfcTypeId);
			int? num3 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdProductLabel);
			byte? b = Api.RetrieveColumnAsByte(Sesid, Table, _colIdGeomType);
			int? num4 = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryHash);
			return new XbimGeometryHandle(geometryLabel, (XbimGeometryType)b.Value, num3.Value, num2.Value, num.Value, num4.Value);
		}
		return default(XbimGeometryHandle);
	}

	internal XbimGeometryData GetGeometryData(XbimGeometryHandle handle)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, handle.GeometryLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			Api.RetrieveColumns(Sesid, Table, _colValues);
			_colValGeometryLabel.Value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
			return new XbimGeometryData(_colValGeometryLabel.Value.Value, _colValProductLabel.Value.Value, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
		}
		return null;
	}

	internal IEnumerable<XbimGeometryData> GetGeometryData(IEnumerable<XbimGeometryHandle> handles)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		foreach (XbimGeometryHandle handle in handles)
		{
			Api.MakeKey(Sesid, Table, handle.GeometryLabel, MakeKeyGrbit.NewKey);
			if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
			{
				Api.RetrieveColumns(Sesid, Table, _colValues);
				_colValGeometryLabel.Value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
				yield return new XbimGeometryData(_colValGeometryLabel.Value.Value, _colValProductLabel.Value.Value, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
			}
		}
	}

	public XbimGeometryData GetGeometryData(int geomLabel)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, geomLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			Api.RetrieveColumns(Sesid, Table, _colValues);
			return new XbimGeometryData(geomLabel, _colValProductLabel.Value.Value, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
		}
		return null;
	}

	public int UpdateReferenceCount(int geomLabel, int refCount)
	{
		if (refCount < 1)
		{
			return 0;
		}
		Api.JetSetCurrentIndex(Sesid, Table, "GeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, geomLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			short value = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdSubPart, RetrieveColumnGrbit.RetrieveCopy).Value;
			short data = (short)Math.Min(refCount, 32767);
			using (Update update = new Update(Sesid, Table, JET_prep.Replace))
			{
				Api.SetColumn(Sesid, Table, _colIdSubPart, data);
				update.Save();
			}
			return (value + 1) * refCount;
		}
		return 0;
	}

	public IEnumerable<XbimGeometryData> GeometryData(XbimGeometryType xbimGeometryType)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeomTypeIndex");
		Api.MakeKey(Sesid, Table, (byte)xbimGeometryType, MakeKeyGrbit.NewKey);
		if (!Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			yield break;
		}
		Api.MakeKey(Sesid, Table, (byte)xbimGeometryType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
		if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
		{
			do
			{
				Api.RetrieveColumns(Sesid, Table, _colValues);
				_colValGeometryLabel.Value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdGeometryLabel);
				yield return new XbimGeometryData(_colValGeometryLabel.Value.Value, _colValProductLabel.Value.Value, (XbimGeometryType)_colValGeomType.Value.Value, _colValProductIfcTypeId.Value.Value, _colValShapeData.Value, _colValTransformMatrix.Value, _colValGeometryHash.Value.Value, _colValStyleLabel.Value.HasValue ? _colValStyleLabel.Value.Value : 0, _colValSubPart.Value.HasValue ? _colValSubPart.Value.Value : 0);
			}
			while (Api.TryMoveNext(Sesid, Table));
		}
	}
}
