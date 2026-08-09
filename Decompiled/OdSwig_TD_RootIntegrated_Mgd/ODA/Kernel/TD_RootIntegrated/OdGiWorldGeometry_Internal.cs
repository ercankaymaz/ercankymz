using System;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWorldGeometry_Internal : OdGiWorldGeometry
{
	public OdGiWorldGeometry_Internal(IntPtr cPtr, bool cMemoryOwn)
		: base(cPtr, cMemoryOwn)
	{
	}

	public override void setExtents(OdGePoint3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldGeometry_setExtents(OdGiWorldGeometry.getCPtr(this), OdGePoint3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
