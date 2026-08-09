using Microsoft.Isam.Esent.Interop;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

public class EsentShapeInstanceCursor : EsentCursor
{
	private const int MaxSizeOfTransformation = 128;

	private Int32ColumnValue _colValInstanceLabel;

	private Int16ColumnValue _colValIfcTypeId;

	private Int32ColumnValue _colValIfcProductLabel;

	private Int32ColumnValue _colValStyleLabel;

	private Int32ColumnValue _colValShapeLabel;

	private Int32ColumnValue _colValRepresentationContext;

	private ByteColumnValue _colValRepType;

	private BytesColumnValue _colValTransformation;

	private BytesColumnValue _colValBoundingBox;

	public static string InstanceTableName = "ShapeInstances";

	private const string instanceTablePrimaryIndex = "ShapeInstancePrimaryIndex";

	private const string productTypeIndex = "ProductTypeIndex";

	private const string productIndex = "ProductIndex";

	private const string geometryShapeIndex = "GeometryShapeIndex";

	private const string colNameInstanceLabel = "InstanceLabel";

	private JET_COLUMNID _colIdInstanceLabel;

	private const string colNameIfcTypeId = "IfcTypeId";

	private JET_COLUMNID _colIdIfcTypeId;

	private const string colNameIfcProductLabel = "IfcProductLabel";

	private JET_COLUMNID _colIdIfcProductLabel;

	private const string colNameStyleLabel = "StyleLabel";

	private JET_COLUMNID _colIdStyleLabel;

	private const string colNameShapeLabel = "ShapeLabel";

	private JET_COLUMNID _colIdShapeLabel;

	private const string colNameRepresentationContext = "RepresentationContext";

	private JET_COLUMNID _colIdRepresentationContext;

	private const string colNameRepType = "ShapeGeomRepType";

	private JET_COLUMNID _colIdRepType;

	private const string colNameTransformation = "Transformation";

	private JET_COLUMNID _colIdTransformation;

	private const string colNameBoundingBox = "BoundingBox";

	private JET_COLUMNID _colIdBoundingBox;

	private ColumnValue[] _colValues;

	public EsentShapeInstanceCursor(EsentModel model, string database)
		: this(model, database, OpenDatabaseGrbit.None)
	{
	}

	public EsentShapeInstanceCursor(EsentModel model, string database, OpenDatabaseGrbit mode)
		: base(model, database, mode)
	{
		Api.JetOpenTable(Sesid, DbId, InstanceTableName, null, 0, mode switch
		{
			OpenDatabaseGrbit.Exclusive => OpenTableGrbit.DenyWrite, 
			OpenDatabaseGrbit.ReadOnly => OpenTableGrbit.ReadOnly, 
			_ => OpenTableGrbit.None, 
		}, out Table);
		InitColumns();
	}

	private void InitColumns()
	{
		_colIdInstanceLabel = Api.GetTableColumnid(Sesid, Table, "InstanceLabel");
		_colIdIfcTypeId = Api.GetTableColumnid(Sesid, Table, "IfcTypeId");
		_colIdIfcProductLabel = Api.GetTableColumnid(Sesid, Table, "IfcProductLabel");
		_colIdStyleLabel = Api.GetTableColumnid(Sesid, Table, "StyleLabel");
		_colIdShapeLabel = Api.GetTableColumnid(Sesid, Table, "ShapeLabel");
		_colIdRepresentationContext = Api.GetTableColumnid(Sesid, Table, "RepresentationContext");
		_colIdRepType = Api.GetTableColumnid(Sesid, Table, "ShapeGeomRepType");
		_colIdTransformation = Api.GetTableColumnid(Sesid, Table, "Transformation");
		_colIdBoundingBox = Api.GetTableColumnid(Sesid, Table, "BoundingBox");
		_colValInstanceLabel = new Int32ColumnValue
		{
			Columnid = _colIdInstanceLabel
		};
		_colValIfcTypeId = new Int16ColumnValue
		{
			Columnid = _colIdIfcTypeId
		};
		_colValIfcProductLabel = new Int32ColumnValue
		{
			Columnid = _colIdIfcProductLabel
		};
		_colValStyleLabel = new Int32ColumnValue
		{
			Columnid = _colIdStyleLabel
		};
		_colValShapeLabel = new Int32ColumnValue
		{
			Columnid = _colIdShapeLabel
		};
		_colValRepresentationContext = new Int32ColumnValue
		{
			Columnid = _colIdRepresentationContext
		};
		_colValRepType = new ByteColumnValue
		{
			Columnid = _colIdRepType
		};
		_colValTransformation = new BytesColumnValue
		{
			Columnid = _colIdTransformation
		};
		_colValBoundingBox = new BytesColumnValue
		{
			Columnid = _colIdBoundingBox
		};
		_colValues = new ColumnValue[8] { _colValIfcTypeId, _colValIfcProductLabel, _colValStyleLabel, _colValShapeLabel, _colValRepresentationContext, _colValRepType, _colValTransformation, _colValBoundingBox };
	}

	internal static void CreateTable(JET_SESID sesid, JET_DBID dbid)
	{
		Api.JetCreateTable(sesid, dbid, InstanceTableName, 8, 80, out var tableid);
		using Transaction transaction = new Transaction(sesid);
		JET_COLUMNDEF jET_COLUMNDEF = new JET_COLUMNDEF
		{
			coltyp = JET_coltyp.Long,
			grbit = (ColumndefGrbit.ColumnNotNULL | ColumndefGrbit.ColumnAutoincrement)
		};
		Api.JetAddColumn(sesid, tableid, "InstanceLabel", jET_COLUMNDEF, null, 0, out var columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Short;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "IfcTypeId", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "IfcProductLabel", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "StyleLabel", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeLabel", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Long;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "RepresentationContext", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.UnsignedByte;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "ShapeGeomRepType", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Binary;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		jET_COLUMNDEF.cbMax = 128;
		Api.JetAddColumn(sesid, tableid, "Transformation", jET_COLUMNDEF, null, 0, out columnid);
		jET_COLUMNDEF.coltyp = JET_coltyp.Binary;
		jET_COLUMNDEF.grbit = ColumndefGrbit.ColumnNotNULL;
		Api.JetAddColumn(sesid, tableid, "BoundingBox", jET_COLUMNDEF, null, 0, out columnid);
		string text = string.Format("+{0}\0\0", "ShapeLabel");
		Api.JetCreateIndex(sesid, tableid, "GeometryShapeIndex", CreateIndexGrbit.IndexDisallowNull, text, text.Length, 100);
		text = string.Format("+{0}\0\0", "IfcProductLabel");
		Api.JetCreateIndex(sesid, tableid, "ProductIndex", CreateIndexGrbit.IndexDisallowNull, text, text.Length, 100);
		text = string.Format("+{0}\0\0", "IfcTypeId");
		Api.JetCreateIndex(sesid, tableid, "ProductTypeIndex", CreateIndexGrbit.IndexDisallowNull, text, text.Length, 100);
		text = string.Format("+{0}\0{1}\0{2}\0{3}\0\0", "RepresentationContext", "StyleLabel", "IfcTypeId", "InstanceLabel");
		Api.JetCreateIndex(sesid, tableid, "ShapeInstancePrimaryIndex", CreateIndexGrbit.IndexPrimary, text, text.Length, 100);
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

	public int AddInstance(IXbimShapeInstanceData instanceData)
	{
		using (Update update = new Update(Sesid, Table, JET_prep.Insert))
		{
			_colValRepresentationContext.Value = instanceData.RepresentationContext;
			_colValIfcProductLabel.Value = instanceData.IfcProductLabel;
			_colValIfcTypeId.Value = instanceData.IfcTypeId;
			_colValShapeLabel.Value = instanceData.ShapeGeometryLabel;
			_colValStyleLabel.Value = instanceData.StyleLabel;
			_colValRepType.Value = instanceData.RepresentationType;
			_colValTransformation.Value = instanceData.Transformation;
			_colValBoundingBox.Value = instanceData.BoundingBox;
			Api.SetColumns(Sesid, Table, _colValues);
			int? num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdInstanceLabel, RetrieveColumnGrbit.RetrieveCopy);
			if (num.HasValue)
			{
				instanceData.InstanceLabel = num.Value;
			}
			update.Save();
			UpdateCount(1);
		}
		return instanceData.InstanceLabel;
	}

	public int AddInstance(int ctxtId, int shapeLabel, int styleLabel, short typeId, int productLabel, XbimGeometryRepresentationType repType, byte[] transform)
	{
		int num = -1;
		using Update update = new Update(Sesid, Table, JET_prep.Insert);
		_colValRepresentationContext.Value = ctxtId;
		_colValIfcProductLabel.Value = productLabel;
		_colValIfcTypeId.Value = typeId;
		_colValShapeLabel.Value = shapeLabel;
		_colValStyleLabel.Value = styleLabel;
		_colValRepType.Value = (byte)repType;
		_colValTransformation.Value = transform;
		Api.SetColumns(Sesid, Table, _colValues);
		num = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdInstanceLabel, RetrieveColumnGrbit.RetrieveCopy).Value;
		update.Save();
		UpdateCount(1);
		return num;
	}

	private void GetShapeInstanceData(IXbimShapeInstanceData si)
	{
		Api.RetrieveColumns(Sesid, Table, _colValues);
		si.RepresentationContext = _colValRepresentationContext.Value.Value;
		si.InstanceLabel = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdInstanceLabel).Value;
		si.IfcTypeId = _colValIfcTypeId.Value.Value;
		si.IfcProductLabel = _colValIfcProductLabel.Value.Value;
		si.StyleLabel = _colValStyleLabel.Value.Value;
		si.ShapeGeometryLabel = _colValShapeLabel.Value.Value;
		si.RepresentationType = _colValRepType.Value.Value;
		si.Transformation = _colValTransformation.Value;
		si.BoundingBox = _colValBoundingBox.Value;
	}

	public bool TrySeekShapeInstance(int context, ref IXbimShapeInstanceData si)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeInstancePrimaryIndex");
		Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeInstanceData(si);
				return true;
			}
		}
		return false;
	}

	public bool TryMoveNextShapeInstance(ref IXbimShapeInstanceData si)
	{
		if (Api.TryMoveNext(Sesid, Table))
		{
			GetShapeInstanceData(si);
			return true;
		}
		return false;
	}

	public bool TrySeekShapeInstanceOfProduct(int product, ref IXbimShapeInstanceData si)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ProductIndex");
		Api.MakeKey(Sesid, Table, product, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, product, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeInstanceData(si);
				return true;
			}
		}
		return false;
	}

	public bool TrySeekShapeInstanceOfProduct(int product)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ProductIndex");
		Api.MakeKey(Sesid, Table, product, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, product, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				return true;
			}
		}
		return false;
	}

	public bool TrySeekShapeInstanceOfGeometry(int shapeGeometryLabel, ref IXbimShapeInstanceData si)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "GeometryShapeIndex");
		Api.MakeKey(Sesid, Table, shapeGeometryLabel, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, shapeGeometryLabel, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeInstanceData(si);
				return true;
			}
		}
		return false;
	}

	public bool TryMoveFirstSurfaceStyle(int context, out int surfaceStyle, out short productType)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeInstancePrimaryIndex");
		Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				surfaceStyle = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
				productType = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex).Value;
				return true;
			}
		}
		surfaceStyle = -1;
		productType = 0;
		return false;
	}

	public bool TryMoveNextSurfaceStyle(out int surfaceStyle, out short productType)
	{
		if (Api.TryMoveNext(Sesid, Table))
		{
			surfaceStyle = Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex).Value;
			productType = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex).Value;
			return true;
		}
		surfaceStyle = -1;
		productType = 0;
		return false;
	}

	public int SkipSurfaceStyes(int skipStyle)
	{
		int? num;
		do
		{
			num = ((!Api.TryMoveNext(Sesid, Table)) ? ((int?)null) : Api.RetrieveColumnAsInt32(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex));
		}
		while (num.HasValue && num.Value == skipStyle);
		return num ?? (-1);
	}

	public bool TryMoveFirstProductType(int context, out short productType)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeInstancePrimaryIndex");
		Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				productType = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex).Value;
				short? num;
				do
				{
					num = ((!Api.TryMoveNext(Sesid, Table)) ? ((short?)null) : Api.RetrieveColumnAsInt16(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex));
				}
				while (num.HasValue && num.Value == productType);
				Api.TryMovePrevious(Sesid, Table);
				return true;
			}
		}
		productType = 0;
		return false;
	}

	public bool TryMoveNextProductType(out short productType)
	{
		if (Api.TryMoveNext(Sesid, Table))
		{
			productType = Api.RetrieveColumnAsInt16(Sesid, Table, _colIdIfcTypeId, RetrieveColumnGrbit.RetrieveFromIndex).Value;
			short? num;
			do
			{
				num = ((!Api.TryMoveNext(Sesid, Table)) ? ((short?)null) : Api.RetrieveColumnAsInt16(Sesid, Table, _colIdStyleLabel, RetrieveColumnGrbit.RetrieveFromIndex));
			}
			while (num.HasValue && num.Value == productType);
			Api.TryMovePrevious(Sesid, Table);
			return true;
		}
		productType = 0;
		return false;
	}

	public bool TrySeekProductType(short productType, ref IXbimShapeInstanceData shapeInstance)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ProductTypeIndex");
		Api.MakeKey(Sesid, Table, productType, MakeKeyGrbit.NewKey);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, productType, MakeKeyGrbit.NewKey | MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeInstanceData(shapeInstance);
				return true;
			}
		}
		return false;
	}

	public bool TrySeekSurfaceStyle(int context, int surfaceStyle, ref IXbimShapeInstanceData shapeInstance)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeInstancePrimaryIndex");
		Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey);
		Api.MakeKey(Sesid, Table, surfaceStyle, MakeKeyGrbit.None);
		if (Api.TrySeek(Sesid, Table, SeekGrbit.SeekGE))
		{
			Api.MakeKey(Sesid, Table, context, MakeKeyGrbit.NewKey);
			Api.MakeKey(Sesid, Table, surfaceStyle, MakeKeyGrbit.FullColumnEndLimit);
			if (Api.TrySetIndexRange(Sesid, Table, SetIndexRangeGrbit.RangeInclusive | SetIndexRangeGrbit.RangeUpperLimit))
			{
				GetShapeInstanceData(shapeInstance);
				return true;
			}
		}
		return false;
	}

	internal bool TrySeekShapeInstance(ref IXbimShapeInstanceData shapeInstance)
	{
		Api.JetSetCurrentIndex(Sesid, Table, "ShapeInstancePrimaryIndex");
		if (Api.TryMoveFirst(Sesid, Table))
		{
			GetShapeInstanceData(shapeInstance);
			return true;
		}
		return false;
	}
}
