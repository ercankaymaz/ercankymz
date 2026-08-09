namespace Microsoft.Isam.Esent.Interop;

internal sealed class IntersectIndexesEnumerator : TableEnumerator<byte[]>
{
	private readonly JET_INDEXRANGE[] ranges;

	private JET_RECORDLIST recordlist;

	public IntersectIndexesEnumerator(JET_SESID sesid, JET_INDEXRANGE[] ranges)
		: base(sesid)
	{
		this.ranges = ranges;
	}

	protected override void OpenTable()
	{
		Api.JetIntersectIndexes(base.Sesid, ranges, ranges.Length, out recordlist, IntersectIndexesGrbit.None);
		base.TableidToEnumerate = recordlist.tableid;
	}

	protected override byte[] GetCurrent()
	{
		return Api.RetrieveColumn(base.Sesid, base.TableidToEnumerate, recordlist.columnidBookmark);
	}
}
