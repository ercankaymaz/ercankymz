using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGroupIterator_Internal : OdDbGroupIterator
{
	public OdDbGroupIterator_Internal(IntPtr cPtr, bool cMemoryOwn)
		: base(cPtr, cMemoryOwn)
	{
	}

	public override OdDbObject getObject(OdDb_OpenMode openMode)
	{
		return new OdDbObject(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGroupIterator_getObject(OdDbGroupIterator.getCPtr(this), (int)openMode), cMemoryOwn: false);
	}

	public override OdDbObjectId objectId()
	{
		return new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGroupIterator_objectId(OdDbGroupIterator.getCPtr(this)), cMemoryOwn: false);
	}

	public override bool done()
	{
		return TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGroupIterator_done(OdDbGroupIterator.getCPtr(this));
	}

	public override bool next()
	{
		return TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGroupIterator_next(OdDbGroupIterator.getCPtr(this));
	}
}
