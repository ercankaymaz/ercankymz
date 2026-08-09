using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_DBINFOMISC : IEquatable<JET_DBINFOMISC>
{
	private int _ulVersion;

	private int _ulUpdate;

	private JET_SIGNATURE _signDb;

	private JET_dbstate _dbstate;

	private JET_LGPOS _lgposConsistent;

	private JET_LOGTIME _logtimeConsistent;

	private JET_LOGTIME _logtimeAttach;

	private JET_LGPOS _lgposAttach;

	private JET_LOGTIME _logtimeDetach;

	private JET_LGPOS _lgposDetach;

	private JET_SIGNATURE _signLog;

	private JET_BKINFO _bkinfoFullPrev;

	private JET_BKINFO _bkinfoIncPrev;

	private JET_BKINFO _bkinfoFullCur;

	private bool _fShadowingDisabled;

	private bool _fUpgradeDb;

	private int _dwMajorVersion;

	private int _dwMinorVersion;

	private int _dwBuildNumber;

	private int _lSPNumber;

	private int _cbPageSize;

	private int _genMinRequired;

	private int _genMaxRequired;

	private JET_LOGTIME _logtimeGenMaxCreate;

	private int _ulRepairCount;

	private JET_LOGTIME _logtimeRepair;

	private int _ulRepairCountOld;

	private int _ulECCFixSuccess;

	private JET_LOGTIME _logtimeECCFixSuccess;

	private int _ulECCFixSuccessOld;

	private int _ulECCFixFail;

	private JET_LOGTIME _logtimeECCFixFail;

	private int _ulECCFixFailOld;

	private int _ulBadChecksum;

	private JET_LOGTIME _logtimeBadChecksum;

	private int _ulBadChecksumOld;

	private int _genCommitted;

	private JET_BKINFO _bkinfoCopyPrev;

	private JET_BKINFO _bkinfoDiffPrev;

	public int ulVersion
	{
		[DebuggerStepThrough]
		get
		{
			return _ulVersion;
		}
		internal set
		{
			_ulVersion = value;
		}
	}

	public int ulUpdate
	{
		[DebuggerStepThrough]
		get
		{
			return _ulUpdate;
		}
		internal set
		{
			_ulUpdate = value;
		}
	}

	public JET_SIGNATURE signDb
	{
		[DebuggerStepThrough]
		get
		{
			return _signDb;
		}
		internal set
		{
			_signDb = value;
		}
	}

	public JET_dbstate dbstate
	{
		[DebuggerStepThrough]
		get
		{
			return _dbstate;
		}
		internal set
		{
			_dbstate = value;
		}
	}

	public JET_LGPOS lgposConsistent
	{
		[DebuggerStepThrough]
		get
		{
			return _lgposConsistent;
		}
		internal set
		{
			_lgposConsistent = value;
		}
	}

	public JET_LOGTIME logtimeConsistent
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeConsistent;
		}
		internal set
		{
			_logtimeConsistent = value;
		}
	}

	public JET_LOGTIME logtimeAttach
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeAttach;
		}
		internal set
		{
			_logtimeAttach = value;
		}
	}

	public JET_LGPOS lgposAttach
	{
		[DebuggerStepThrough]
		get
		{
			return _lgposAttach;
		}
		internal set
		{
			_lgposAttach = value;
		}
	}

	public JET_LOGTIME logtimeDetach
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeDetach;
		}
		internal set
		{
			_logtimeDetach = value;
		}
	}

	public JET_LGPOS lgposDetach
	{
		[DebuggerStepThrough]
		get
		{
			return _lgposDetach;
		}
		internal set
		{
			_lgposDetach = value;
		}
	}

	public JET_SIGNATURE signLog
	{
		[DebuggerStepThrough]
		get
		{
			return _signLog;
		}
		internal set
		{
			_signLog = value;
		}
	}

	public JET_BKINFO bkinfoFullPrev
	{
		[DebuggerStepThrough]
		get
		{
			return _bkinfoFullPrev;
		}
		internal set
		{
			_bkinfoFullPrev = value;
		}
	}

	public JET_BKINFO bkinfoIncPrev
	{
		[DebuggerStepThrough]
		get
		{
			return _bkinfoIncPrev;
		}
		internal set
		{
			_bkinfoIncPrev = value;
		}
	}

	public JET_BKINFO bkinfoFullCur
	{
		[DebuggerStepThrough]
		get
		{
			return _bkinfoFullCur;
		}
		internal set
		{
			_bkinfoFullCur = value;
		}
	}

	public bool fShadowingDisabled
	{
		[DebuggerStepThrough]
		get
		{
			return _fShadowingDisabled;
		}
		internal set
		{
			_fShadowingDisabled = value;
		}
	}

	public bool fUpgradeDb
	{
		[DebuggerStepThrough]
		get
		{
			return _fUpgradeDb;
		}
		internal set
		{
			_fUpgradeDb = value;
		}
	}

	public int dwMajorVersion
	{
		[DebuggerStepThrough]
		get
		{
			return _dwMajorVersion;
		}
		internal set
		{
			_dwMajorVersion = value;
		}
	}

	public int dwMinorVersion
	{
		[DebuggerStepThrough]
		get
		{
			return _dwMinorVersion;
		}
		internal set
		{
			_dwMinorVersion = value;
		}
	}

	public int dwBuildNumber
	{
		[DebuggerStepThrough]
		get
		{
			return _dwBuildNumber;
		}
		internal set
		{
			_dwBuildNumber = value;
		}
	}

	public int lSPNumber
	{
		[DebuggerStepThrough]
		get
		{
			return _lSPNumber;
		}
		internal set
		{
			_lSPNumber = value;
		}
	}

	public int cbPageSize
	{
		[DebuggerStepThrough]
		get
		{
			return _cbPageSize;
		}
		internal set
		{
			_cbPageSize = value;
		}
	}

	public int genMinRequired
	{
		[DebuggerStepThrough]
		get
		{
			return _genMinRequired;
		}
		internal set
		{
			_genMinRequired = value;
		}
	}

	public int genMaxRequired
	{
		[DebuggerStepThrough]
		get
		{
			return _genMaxRequired;
		}
		internal set
		{
			_genMaxRequired = value;
		}
	}

	public JET_LOGTIME logtimeGenMaxCreate
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeGenMaxCreate;
		}
		internal set
		{
			_logtimeGenMaxCreate = value;
		}
	}

	public int ulRepairCount
	{
		[DebuggerStepThrough]
		get
		{
			return _ulRepairCount;
		}
		internal set
		{
			_ulRepairCount = value;
		}
	}

	public JET_LOGTIME logtimeRepair
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeRepair;
		}
		internal set
		{
			_logtimeRepair = value;
		}
	}

	public int ulRepairCountOld
	{
		[DebuggerStepThrough]
		get
		{
			return _ulRepairCountOld;
		}
		internal set
		{
			_ulRepairCountOld = value;
		}
	}

	public int ulECCFixSuccess
	{
		[DebuggerStepThrough]
		get
		{
			return _ulECCFixSuccess;
		}
		internal set
		{
			_ulECCFixSuccess = value;
		}
	}

	public JET_LOGTIME logtimeECCFixSuccess
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeECCFixSuccess;
		}
		internal set
		{
			_logtimeECCFixSuccess = value;
		}
	}

	public int ulECCFixSuccessOld
	{
		[DebuggerStepThrough]
		get
		{
			return _ulECCFixSuccessOld;
		}
		internal set
		{
			_ulECCFixSuccessOld = value;
		}
	}

	public int ulECCFixFail
	{
		[DebuggerStepThrough]
		get
		{
			return _ulECCFixFail;
		}
		internal set
		{
			_ulECCFixFail = value;
		}
	}

	public JET_LOGTIME logtimeECCFixFail
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeECCFixFail;
		}
		internal set
		{
			_logtimeECCFixFail = value;
		}
	}

	public int ulECCFixFailOld
	{
		[DebuggerStepThrough]
		get
		{
			return _ulECCFixFailOld;
		}
		internal set
		{
			_ulECCFixFailOld = value;
		}
	}

	public int ulBadChecksum
	{
		[DebuggerStepThrough]
		get
		{
			return _ulBadChecksum;
		}
		internal set
		{
			_ulBadChecksum = value;
		}
	}

	public JET_LOGTIME logtimeBadChecksum
	{
		[DebuggerStepThrough]
		get
		{
			return _logtimeBadChecksum;
		}
		internal set
		{
			_logtimeBadChecksum = value;
		}
	}

	public int ulBadChecksumOld
	{
		[DebuggerStepThrough]
		get
		{
			return _ulBadChecksumOld;
		}
		internal set
		{
			_ulBadChecksumOld = value;
		}
	}

	public int genCommitted
	{
		[DebuggerStepThrough]
		get
		{
			return _genCommitted;
		}
		internal set
		{
			_genCommitted = value;
		}
	}

	public JET_BKINFO bkinfoCopyPrev
	{
		[DebuggerStepThrough]
		get
		{
			return _bkinfoCopyPrev;
		}
		internal set
		{
			_bkinfoCopyPrev = value;
		}
	}

	public JET_BKINFO bkinfoDiffPrev
	{
		[DebuggerStepThrough]
		get
		{
			return _bkinfoDiffPrev;
		}
		internal set
		{
			_bkinfoDiffPrev = value;
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_DBINFOMISC({0})", _signDb);
	}

	public override int GetHashCode()
	{
		return Util.CalculateHashCode(new List<int>(new int[39]
		{
			_ulVersion,
			_ulUpdate,
			_signDb.GetHashCode(),
			_dbstate.GetHashCode(),
			_lgposConsistent.GetHashCode(),
			_logtimeConsistent.GetHashCode(),
			_logtimeAttach.GetHashCode(),
			_lgposAttach.GetHashCode(),
			_logtimeDetach.GetHashCode(),
			_lgposDetach.GetHashCode(),
			_signLog.GetHashCode(),
			_bkinfoFullPrev.GetHashCode(),
			_bkinfoIncPrev.GetHashCode(),
			_bkinfoFullCur.GetHashCode(),
			_fShadowingDisabled.GetHashCode(),
			_fUpgradeDb.GetHashCode(),
			_dwMajorVersion,
			_dwMinorVersion,
			_dwBuildNumber,
			_lSPNumber,
			_cbPageSize,
			_genMinRequired,
			_genMaxRequired,
			_logtimeGenMaxCreate.GetHashCode(),
			_ulRepairCount,
			_logtimeRepair.GetHashCode(),
			_ulRepairCountOld,
			_ulECCFixSuccess,
			_logtimeECCFixSuccess.GetHashCode(),
			_ulECCFixSuccessOld,
			_ulECCFixFail,
			_logtimeECCFixFail.GetHashCode(),
			_ulECCFixFailOld,
			_ulBadChecksum,
			_logtimeBadChecksum.GetHashCode(),
			_ulBadChecksumOld,
			_genCommitted,
			_bkinfoCopyPrev.GetHashCode(),
			_bkinfoDiffPrev.GetHashCode()
		}));
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_DBINFOMISC)obj);
	}

	public bool Equals(JET_DBINFOMISC other)
	{
		if (other == null)
		{
			return false;
		}
		if (true && _ulVersion == other._ulVersion && _ulUpdate == other._ulUpdate && _signDb == other._signDb && _dbstate == other._dbstate && _lgposConsistent == other._lgposConsistent && _logtimeConsistent == other._logtimeConsistent && _logtimeAttach == other._logtimeAttach && _lgposAttach == other._lgposAttach && _logtimeDetach == other._logtimeDetach && _lgposDetach == other._lgposDetach && _signLog == other._signLog && _bkinfoFullPrev == other._bkinfoFullPrev && _bkinfoIncPrev == other._bkinfoIncPrev && _bkinfoFullCur == other._bkinfoFullCur && _fShadowingDisabled == other._fShadowingDisabled && _fUpgradeDb == other._fUpgradeDb && _dwMajorVersion == other._dwMajorVersion && _dwMinorVersion == other._dwMinorVersion && _dwBuildNumber == other._dwBuildNumber && _lSPNumber == other._lSPNumber && _cbPageSize == other._cbPageSize && _genMinRequired == other._genMinRequired && _genMaxRequired == other._genMaxRequired && _logtimeGenMaxCreate == other._logtimeGenMaxCreate && _ulRepairCount == other._ulRepairCount && _logtimeRepair == other._logtimeRepair && _ulRepairCountOld == other._ulRepairCountOld && _ulECCFixSuccess == other._ulECCFixSuccess && _logtimeECCFixSuccess == other._logtimeECCFixSuccess && _ulECCFixSuccessOld == other._ulECCFixSuccessOld && _ulECCFixFail == other._ulECCFixFail && _logtimeECCFixFail == other._logtimeECCFixFail && _ulECCFixFailOld == other._ulECCFixFailOld && _ulBadChecksum == other._ulBadChecksum && _logtimeBadChecksum == other._logtimeBadChecksum && _ulBadChecksumOld == other._ulBadChecksumOld && _genCommitted == other._genCommitted && _bkinfoCopyPrev == other._bkinfoCopyPrev)
		{
			return _bkinfoDiffPrev == other._bkinfoDiffPrev;
		}
		return false;
	}

	internal void SetFromNativeDbinfoMisc(ref NATIVE_DBINFOMISC native)
	{
		_ulVersion = (int)native.ulVersion;
		_ulUpdate = (int)native.ulUpdate;
		_signDb = new JET_SIGNATURE(native.signDb);
		_dbstate = (JET_dbstate)native.dbstate;
		_lgposConsistent = native.lgposConsistent;
		_logtimeConsistent = native.logtimeConsistent;
		_logtimeAttach = native.logtimeAttach;
		_lgposAttach = native.lgposAttach;
		_logtimeDetach = native.logtimeDetach;
		_lgposDetach = native.lgposDetach;
		_signLog = new JET_SIGNATURE(native.signLog);
		_bkinfoFullPrev = native.bkinfoFullPrev;
		_bkinfoIncPrev = native.bkinfoIncPrev;
		_bkinfoFullCur = native.bkinfoFullCur;
		_fShadowingDisabled = native.fShadowingDisabled != 0;
		_fUpgradeDb = native.fUpgradeDb != 0;
		_dwMajorVersion = (int)native.dwMajorVersion;
		_dwMinorVersion = (int)native.dwMinorVersion;
		_dwBuildNumber = (int)native.dwBuildNumber;
		_lSPNumber = (int)native.lSPNumber;
		_cbPageSize = (int)native.cbPageSize;
	}

	internal void SetFromNativeDbinfoMisc(ref NATIVE_DBINFOMISC4 native)
	{
		SetFromNativeDbinfoMisc(ref native.dbinfo);
		_genMinRequired = (int)native.genMinRequired;
		_genMaxRequired = (int)native.genMaxRequired;
		_logtimeGenMaxCreate = native.logtimeGenMaxCreate;
		_ulRepairCount = (int)native.ulRepairCount;
		_logtimeRepair = native.logtimeRepair;
		_ulRepairCountOld = (int)native.ulRepairCountOld;
		_ulECCFixSuccess = (int)native.ulECCFixSuccess;
		_logtimeECCFixSuccess = native.logtimeECCFixSuccess;
		_ulECCFixSuccessOld = (int)native.ulECCFixSuccessOld;
		_ulECCFixFail = (int)native.ulECCFixFail;
		_logtimeECCFixFail = native.logtimeECCFixFail;
		_ulECCFixFailOld = (int)native.ulECCFixFailOld;
		_ulBadChecksum = (int)native.ulBadChecksum;
		_logtimeBadChecksum = native.logtimeBadChecksum;
		_ulBadChecksumOld = (int)native.ulBadChecksumOld;
		_genCommitted = (int)native.genCommitted;
		_bkinfoCopyPrev = native.bkinfoCopyPrev;
		_bkinfoDiffPrev = native.bkinfoDiffPrev;
	}

	internal NATIVE_DBINFOMISC GetNativeDbinfomisc()
	{
		return new NATIVE_DBINFOMISC
		{
			ulVersion = (uint)_ulVersion,
			ulUpdate = (uint)_ulUpdate,
			signDb = _signDb.GetNativeSignature(),
			dbstate = (uint)_dbstate,
			lgposConsistent = _lgposConsistent,
			logtimeConsistent = _logtimeConsistent,
			logtimeAttach = _logtimeAttach,
			lgposAttach = _lgposAttach,
			logtimeDetach = _logtimeDetach,
			lgposDetach = _lgposDetach,
			signLog = _signLog.GetNativeSignature(),
			bkinfoFullPrev = _bkinfoFullPrev,
			bkinfoIncPrev = _bkinfoIncPrev,
			bkinfoFullCur = _bkinfoFullCur,
			fShadowingDisabled = (_fShadowingDisabled ? 1u : 0u),
			fUpgradeDb = (_fUpgradeDb ? 1u : 0u),
			dwMajorVersion = (uint)_dwMajorVersion,
			dwMinorVersion = (uint)_dwMinorVersion,
			dwBuildNumber = (uint)_dwBuildNumber,
			lSPNumber = (uint)_lSPNumber,
			cbPageSize = (uint)_cbPageSize
		};
	}

	internal NATIVE_DBINFOMISC4 GetNativeDbinfomisc4()
	{
		return new NATIVE_DBINFOMISC4
		{
			dbinfo = GetNativeDbinfomisc(),
			genMinRequired = (uint)_genMinRequired,
			genMaxRequired = (uint)_genMaxRequired,
			logtimeGenMaxCreate = _logtimeGenMaxCreate,
			ulRepairCount = (uint)_ulRepairCount,
			logtimeRepair = _logtimeRepair,
			ulRepairCountOld = (uint)_ulRepairCountOld,
			ulECCFixSuccess = (uint)_ulECCFixSuccess,
			logtimeECCFixSuccess = _logtimeECCFixSuccess,
			ulECCFixSuccessOld = (uint)_ulECCFixSuccessOld,
			ulECCFixFail = (uint)_ulECCFixFail,
			logtimeECCFixFail = _logtimeECCFixFail,
			ulECCFixFailOld = (uint)_ulECCFixFailOld,
			ulBadChecksum = (uint)_ulBadChecksum,
			logtimeBadChecksum = _logtimeBadChecksum,
			ulBadChecksumOld = (uint)_ulBadChecksumOld,
			genCommitted = (uint)_genCommitted,
			bkinfoCopyPrev = _bkinfoCopyPrev,
			bkinfoDiffPrev = _bkinfoDiffPrev
		};
	}
}
