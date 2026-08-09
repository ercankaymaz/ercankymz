using System;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUnitsFormatter_Internal : OdDbUnitsFormatter
{
	public OdDbUnitsFormatter_Internal(IntPtr cPtr, bool cMemoryOwn)
		: base(cPtr, cMemoryOwn)
	{
	}

	public override double toUserAngle(double wcsAngle)
	{
		return TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_toUserAngle(OdDbUnitsFormatter.getCPtr(this), wcsAngle);
	}

	public override double fromUserAngle(double ucsAngle)
	{
		return TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_fromUserAngle(OdDbUnitsFormatter.getCPtr(this), ucsAngle);
	}

	public override string formatPoint(OdGePoint3d value)
	{
		return TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_formatPoint(OdDbUnitsFormatter.getCPtr(this), OdGePoint3d.getCPtr(value));
	}

	public override OdGePoint3d unformatPoint(string arg0)
	{
		return new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_unformatPoint(OdDbUnitsFormatter.getCPtr(this), arg0), cMemoryOwn: false);
	}

	public override OdGePoint3d toUCS(OdGePoint3d wcsPt)
	{
		return new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_toUCS(OdDbUnitsFormatter.getCPtr(this), OdGePoint3d.getCPtr(wcsPt)), cMemoryOwn: false);
	}

	public override OdGePoint3d fromUCS(OdGePoint3d ucsPt)
	{
		return new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnitsFormatter_fromUCS(OdDbUnitsFormatter.getCPtr(this), OdGePoint3d.getCPtr(ucsPt)), cMemoryOwn: false);
	}
}
