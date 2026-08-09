using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class Update : EsentResource
{
	private readonly JET_SESID sesid;

	private readonly JET_TABLEID tableid;

	private readonly JET_prep prep;

	public Update(JET_SESID sesid, JET_TABLEID tableid, JET_prep prep)
	{
		if (JET_prep.Cancel == prep)
		{
			throw new ArgumentException("Cannot create an Update for JET_prep.Cancel", "prep");
		}
		this.sesid = sesid;
		this.tableid = tableid;
		this.prep = prep;
		Api.JetPrepareUpdate(this.sesid, this.tableid, this.prep);
		ResourceWasAllocated();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Update ({0})", prep);
	}

	public void Save(byte[] bookmark, int bookmarkSize, out int actualBookmarkSize)
	{
		CheckObjectIsNotDisposed();
		if (!base.HasResource)
		{
			throw new InvalidOperationException("Not in an update");
		}
		Api.JetUpdate(sesid, tableid, bookmark, bookmarkSize, out actualBookmarkSize);
		ResourceWasReleased();
	}

	public void Save()
	{
		Save(null, 0, out var _);
	}

	public void SaveAndGotoBookmark()
	{
		byte[] data = null;
		try
		{
			data = Caches.BookmarkCache.Allocate();
			Save(data, data.Length, out var actualBookmarkSize);
			Api.JetGotoBookmark(sesid, tableid, data, actualBookmarkSize);
		}
		finally
		{
			if (data != null)
			{
				Caches.BookmarkCache.Free(ref data);
			}
		}
	}

	public void Cancel()
	{
		CheckObjectIsNotDisposed();
		if (!base.HasResource)
		{
			throw new InvalidOperationException("Not in an update");
		}
		Api.JetPrepareUpdate(sesid, tableid, JET_prep.Cancel);
		ResourceWasReleased();
	}

	protected override void ReleaseResource()
	{
		Cancel();
	}
}
