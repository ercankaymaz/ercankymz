using Microsoft.Isam.Esent.Interop;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

public class EsentShapeGeometryCursor : EsentCursor
{
	private Int32ColumnValue _colValShapeLabel;

	private Int32ColumnValue _colValIfcShapeLabel;

	private Int32ColumnValue _colValGeometryHash;

	private Int32ColumnValue _colValCost;

	private Int32ColumnValue _colValReferenceCount;

	private ByteColumnValue _colValLOD;

	private ByteColumnValue _colValFormat;

	private BytesColumnValue _colValBoundingBox;

	private BytesColumnValue _colValShapeData;

	public static string GeometryTableName = "ShapeGeometry";

	private const string geometryTablePrimaryIndex = "ShapeGeomPrimaryIndex";

	private const string geometryTableHashIndex = "ShapeGeomHashIndex";

	private const string geometryTableReferenceIndex = "ShapeGeomReferenceIndex";

	private const string colNameShapeLabel = "ShapeGeomLabel";

	private JET_COLUMNID _colIdShapeLabel;

	private const string colNameIfcShapeLabel = "ShapeGeomIfcLabel";

	private JET_COLUMNID _colIdIfcShapeLabel;

	private const string colNameShapeData = "ShapeGeomData";

	private JET_COLUMNID _colIdShapeData;

	private const string colNameGeometryHash = "ShapeGeomHash";

	private JET_COLUMNID _colIdGeometryHash;

	private const string colNameCost = "ShapeGeomCost";

	private JET_COLUMNID _colIdCost;

	private const string colNameReferenceCount = "ShapeGeomReferenceCount";

	private JET_COLUMNID _colIdReferenceCount;

	private const string colNameLOD = "ShapeGeomLOD";

	private JET_COLUMNID _colIdLOD;

	private const string colNameBoundingBox = "BoundingBox";

	private JET_COLUMNID _colIdBoundingBox;

	private const string colNameFormat = "ShapeGeomFormat";

	private JET_COLUMNID _colIdFormat;

	private ColumnValue[] _colValues;

	public EsentShapeGeometryCursor(EsentModel model, string database)
		: this(model, database, OpenDatabaseGrbit.None)
	{
	}

	public EsentShapeGeometryCursor(EsentModel model, string database, OpenDatabaseGrbit mode)
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

	private void InitColumns()
	{
		_colIdShapeLabel = Api.GetTableColumnid(Sesid, Table, "ShapeGeomLabel");
		_colIdIfcShapeLabel = Api.GetTableColumnid(Sesid, Table, "ShapeGeomIfcLabel");
		_colIdGeometryHash = Api.GetTableColumnid(Sesid, Table, "ShapeGeomHash");
		_colIdCost = Api.GetTableColumnid(Sesid, Table, "ShapeGeomCost");
		_colIdReferenceCount = Api.GetTableColumnid(Sesid, Table, "ShapeGeomReferenceCount");
		_colIdLOD = Api.GetTableColumnid(Sesid, Table, "ShapeGeomLOD");
		_colIdFormat = Api.GetTableColumnid(Sesid, Table, "ShapeGeomFormat");
		_colIdBoundingBox = Api.GetTableColumnid(Sesid, Table, "BoundingBox");
		_colIdShapeData = Api.GetTableColumnid(Sesid, Table, "ShapeGeomData");
		_colValShapeLabel = new Int32ColumnValue
		{
			Columnid = _colIdShapeLabel
		};
		_colValIfcShapeLabel = new Int32ColumnValue
		{
			Columnid = _colIdIfcShapeLabel
		};
		_colValGeometryHash = new Int32ColumnValue
		{
			Columnid = _colIdGeometryHash
		};
		_colValCost = new Int32ColumnValue
		{
			Columnid = _colIdCost
		};
		_colValReferenceCount = new Int32ColumnValue
		{
			Columnid = _colIdReferenceCount
		};
		_colValLOD = new ByteColumnValue
		{
			Columnid = _colIdLOD
		};
		_colValFormat = new ByteColumnValue
		{
			Columnid = _colIdFormat
		};
		_colValBoundingBox = new BytesColumnValue
		{
			Columnid = _colIdBoundingBox
		};
		_colValShapeData = new BytesColumnValue
		{
			Columnid = _colIdShapeData
		};
		_colValues = new ColumnValue[8] { _colValIfcShapeLabel, _colValGeometryHash, _colValCost, _colValReferenceCount, _colValLOD, _colValFormat, _colValBoundingBox, _colValShapeData };
	}

	internal static void CreateTable(JET_SESID sesid, JET_DBID dbid)
	{
		Api.JetCreateTable(sesid, dbid, GeometryTableName, 8, 80, out var tableid);
		using Transaction transaction = new Transaction(sesid);
		JET_COLUMNDEF jET_COLUMNDEF = new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = (ColumndefGrbit.ColumnNotNULL | ColumndefGrbit.ColumnAutoincrement)
		};
		Api.JetAddColumn(sesid, tableid, "ShapeGeomLabel", jET_COLUMNDEF, null, 0, out var columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomIfcLabel", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnMaybeNull;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomHash", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomCost", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomReferenceCount", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.UnsignedByte;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomLOD", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.UnsignedByte;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomFormat", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Binary;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "BoundingBox", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.LongBinary;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomData", jET_COLUMNDEF, null, 0, out columnid);
		string text = string.Format("+{0}\0\0", "ShapeGeomLabel");
		Api.JetCreateIndex(sesid, tableid, "ShapeGeomPrimaryIndex", CreateIndexGrbit.IndexPrimary | CreateIndexGrbit.IndexDisallowNull, text, text.Length, 100);
		text = string.Format("+{0}\0\0", "ShapeGeomHash");
		text = string.Format("-{0}\0{1}\0{2}\0\0", "ShapeGeomCost", "ShapeGeomReferenceCount", "ShapeGeomLabel");
		Api.JetCreateIndex(sesid, tableid, "ShapeGeomReferenceIndex", CreateIndexGrbit.None, text, text.Length, 100);
		Api.JetCloseTable(sesid, tableid);
		transaction.Commit(CommitTransactionGrbit.LazyFlush);
	}

	internal override int RetrieveCount()
	{
		return Api.RetrieveColumnAsInt32(Sesid, GlobalsTable, GeometryCountColumn).Value;
	}

	protected override void UpdateCount(int delta)
	{
		Api.EscrowUpdate(Sesid, GlobalsTable, GeometryCountColumn, delta);
	}

	public int AddGeometry(IXbimShapeGeometryData shapeGeom)
	{
		int num = 0;
		using Update update = new Update(Sesid, Table, JET_prep.Insert);
		_colValIfcShapeLabel.Value = shapeGeom.IfcShapeLabel;
		_colValGeometryHash.Value = shapeGeom.GeometryHash;
		_colValCost.Value = shapeGeom.Cost;
		_colValReferenceCount.Value = shapeGeom.ReferenceCount;
		_colValLOD.Value = shapeGeom.LOD;
		_colValFormat.Value = shapeGeom.Format;
		_colValShapeData.Value = shapeGeom.ShapeDataCompressed;
		_colValBoundingBox.Value = shapeGeom.BoundingBox;
		Api.SetColumns(Sesid, Table, _colValues);
		num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdShapeLabel, RetrieveColumnGrbit.RetrieveCopy).Value;
		update.Save();
		UpdateCount(1);
		shapeGeom.ShapeLabel = num;
		return num;
	}

	public void UpdateReferenceCount(int geomLabel, int refCount)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, geomLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			int value = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdCost).Value;
			using Update update = new Update(Sesid, Table, JET_prep.Replace);
			Api.SetColumn(Sesid, Table, _colIdCost, refCount * value);
			Api.SetColumn(Sesid, Table, _colIdReferenceCount, refCount);
			update.Save();
		}
	}

	private void GetShapeGeometryData(IXbimShapeGeometryData sg)
	{
		Api.RetrieveColumns(Sesid, Table, _colValues);
		sg.ShapeLabel = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdShapeLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
		sg.IfcShapeLabel = _colValIfcShapeLabel.Value.Value;
		sg.GeometryHash = _colValGeometryHash.Value.Value;
		sg.ReferenceCount = _colValReferenceCount.Value.Value;
		sg.LOD = _colValLOD.Value.Value;
		sg.Format = _colValFormat.Value.Value;
		sg.ShapeDataCompressed = _colValShapeData.Value;
		sg.BoundingBox = _colValBoundingBox.Value;
	}

	public bool TryMoveFirstShapeGeometry(ref IXbimShapeGeometryData sg)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomPrimaryIndex");
		if (TryMoveFirst())
		{
			GetShapeGeometryData(sg);
			return true;
		}
		return false;
	}

	public bool TryMoveNextShapeGeometry(ref IXbimShapeGeometryData sg)
	{
		if (Api.TryMoveNext(Sesid, Table))
		{
			GetShapeGeometryData(sg);
			return true;
		}
		return false;
	}

	public bool TryGetShapeGeometry(int shapeGeometryLabel, ref IXbimShapeGeometryData sg)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, shapeGeometryLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			GetShapeGeometryData(sg);
			return true;
		}
		return false;
	}

	public int GetReferenceCount(int shapeGeometryLabel)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomPrimaryIndex");
		Api.MakeKey(Sesid, Table, shapeGeometryLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekEQ))
		{
			return Api.RetrieveColumnAsInt32(Sesid, Table, _colIdReferenceCount, RetrieveColumnGrbit.RetrieveFromIndex).Value;
		}
		return 0;
	}

	public bool TryMoveFirstReferenceCounter()
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomReferenceIndex");
		return TryMoveFirst();
	}

	public bool TryMoveFirstRegion(ref IXbimShapeGeometryData sg)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeGeomReferenceIndex");
		Api.MakeKey(Sesid, Table, -1, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, Table, -1, MakeKeyGrbit.None);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, -1, MakeKeyGrbit.NewKey);
			Api.MakeKey(Sesid, Table, -1, MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeGeometryData(sg);
				return true;
			}
		}
		return false;
	}

	public bool TryMoveNextReferenceCounter()
	{
		return TryMoveNext();
	}

	public int GetReferenceCount()
	{
		return Api.RetrieveColumnAsInt32(Sesid, Table, _colIdReferenceCount, RetrieveColumnGrbit.RetrieveFromIndex).Value;
	}

	public int GetCost()
	{
		return Api.RetrieveColumnAsInt32(Sesid, Table, _colIdCost, RetrieveColumnGrbit.RetrieveFromIndex).Value;
	}

	public int GetShapeGeometryLabel()
	{
		return Api.RetrieveColumnAsInt32(Sesid, Table, _colIdShapeLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
	}

	internal bool TryMoveNextRegion(ref IXbimShapeGeometryData regions)
	{
		if (TryMoveNext())
		{
			GetShapeGeometryData(regions);
			return true;
		}
		return false;
	}
}
