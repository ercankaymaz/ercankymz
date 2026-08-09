using System.Globalization;
using System.Text;

namespace Microsoft.Isam.Esent.Interop;

internal abstract class IndexInfoEnumerator : TableEnumerator<IndexInfo>
{
	protected JET_INDEXLIST Indexlist { get; set; }

	protected IndexInfoEnumerator(JET_SESID sesid)
		: base(sesid)
	{
	}

	protected override IndexInfo GetCurrent()
	{
		return GetIndexInfoFromIndexlist(base.Sesid, Indexlist);
	}

	protected abstract void GetIndexInfo(JET_SESID sesid, string indexname, out string result, JET_IdxInfo infoLevel);

	private static IndexSegment[] GetIndexSegmentsFromIndexlist(JET_SESID sesid, JET_INDEXLIST indexlist)
	{
		int value = Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidcColumn).Value;
		Encoding encoding = (EsentVersion.SupportsVistaFeatures ? Encoding.Unicode : LibraryHelpers.EncodingASCII);
		IndexSegment[] array = new IndexSegment[value];
		for (int i = 0; i < value; i = checked(i + 1))
		{
			string s = Api.RetrieveColumnAsString(sesid, indexlist.tableid, indexlist.columnidcolumnname, encoding, RetrieveColumnGrbit.None);
			s = StringCache.TryToIntern(s);
			JET_coltyp value2 = (JET_coltyp)Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidcoltyp).Value;
			IndexKeyGrbit value3 = (IndexKeyGrbit)Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidgrbitColumn).Value;
			bool isAscending = value3 == IndexKeyGrbit.Ascending;
			JET_CP value4 = (JET_CP)Api.RetrieveColumnAsInt16(sesid, indexlist.tableid, indexlist.columnidCp).Value;
			bool isASCII = JET_CP.ASCII == value4;
			array[i] = new IndexSegment(s, value2, isAscending, isASCII);
			if (i < checked(value - 1))
			{
				Api.JetMove(sesid, indexlist.tableid, JET_Move.Next, MoveGrbit.None);
			}
		}
		return array;
	}

	private IndexInfo GetIndexInfoFromIndexlist(JET_SESID sesid, JET_INDEXLIST indexlist)
	{
		Encoding encoding = (EsentVersion.SupportsVistaFeatures ? Encoding.Unicode : LibraryHelpers.EncodingASCII);
		string s = Api.RetrieveColumnAsString(sesid, indexlist.tableid, indexlist.columnidindexname, encoding, RetrieveColumnGrbit.None);
		s = StringCache.TryToIntern(s);
		CultureInfo cultureInfo = null;
		if (EsentVersion.SupportsWindows8Features)
		{
			GetIndexInfo(sesid, s, out var result, (JET_IdxInfo)14);
			cultureInfo = new CultureInfo(result);
		}
		else
		{
			cultureInfo = LibraryHelpers.CreateCultureInfoByLcid(Api.RetrieveColumnAsInt16(sesid, indexlist.tableid, indexlist.columnidLangid).Value);
		}
		CompareOptions compareOptions = Conversions.CompareOptionsFromLCMapFlags(Api.RetrieveColumnAsUInt32(sesid, indexlist.tableid, indexlist.columnidLCMapFlags).Value);
		uint value = Api.RetrieveColumnAsUInt32(sesid, indexlist.tableid, indexlist.columnidgrbitIndex).Value;
		int value2 = Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidcKey).Value;
		int value3 = Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidcEntry).Value;
		int value4 = Api.RetrieveColumnAsInt32(sesid, indexlist.tableid, indexlist.columnidcPage).Value;
		IndexSegment[] indexSegmentsFromIndexlist = GetIndexSegmentsFromIndexlist(sesid, indexlist);
		return new IndexInfo(s, cultureInfo, compareOptions, indexSegmentsFromIndexlist, (CreateIndexGrbit)checked((int)value), value2, value3, value4);
	}
}
