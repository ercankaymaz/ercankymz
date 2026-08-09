using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdRxRcsFileServices : OdRxModule
{
	public delegate IntPtr SwigDelegateOdRxRcsFileServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_1();

	public delegate void SwigDelegateOdRxRcsFileServices_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_3();

	public delegate void SwigDelegateOdRxRcsFileServices_4();

	public delegate void SwigDelegateOdRxRcsFileServices_5();

	public delegate void SwigDelegateOdRxRcsFileServices_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxRcsFileServices_7();

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_8([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pDbReceiver);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_9([MarshalAs(UnmanagedType.LPWStr)] string filePath);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_10(IntPtr pFile, IntPtr pDbReceiver);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_11(IntPtr pFile);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_12([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pScanStorage, IntPtr pDbReceiver);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_13([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pScanStorage);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_14(IntPtr pFile, IntPtr pScanStorage, IntPtr pDbReceiver);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_15(IntPtr pFile, IntPtr pScanStorage);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_16(IntPtr pDataSource, IntPtr pParams);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_17(IntPtr pDataSource);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_18(IntPtr pScanDb, IntPtr pHostProjectDb);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_19(IntPtr pScanDb);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_20([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex, uint skipLines, [MarshalAs(UnmanagedType.LPWStr)] string separator);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_21([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex, uint skipLines);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_22([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_23([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_24([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_25([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_26([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_27([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_28([MarshalAs(UnmanagedType.LPWStr)] string filePath);

	public delegate IntPtr SwigDelegateOdRxRcsFileServices_29();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxRcsFileServices_0 swigDelegate0;

	private SwigDelegateOdRxRcsFileServices_1 swigDelegate1;

	private SwigDelegateOdRxRcsFileServices_2 swigDelegate2;

	private SwigDelegateOdRxRcsFileServices_3 swigDelegate3;

	private SwigDelegateOdRxRcsFileServices_4 swigDelegate4;

	private SwigDelegateOdRxRcsFileServices_5 swigDelegate5;

	private SwigDelegateOdRxRcsFileServices_6 swigDelegate6;

	private SwigDelegateOdRxRcsFileServices_7 swigDelegate7;

	private SwigDelegateOdRxRcsFileServices_8 swigDelegate8;

	private SwigDelegateOdRxRcsFileServices_9 swigDelegate9;

	private SwigDelegateOdRxRcsFileServices_10 swigDelegate10;

	private SwigDelegateOdRxRcsFileServices_11 swigDelegate11;

	private SwigDelegateOdRxRcsFileServices_12 swigDelegate12;

	private SwigDelegateOdRxRcsFileServices_13 swigDelegate13;

	private SwigDelegateOdRxRcsFileServices_14 swigDelegate14;

	private SwigDelegateOdRxRcsFileServices_15 swigDelegate15;

	private SwigDelegateOdRxRcsFileServices_16 swigDelegate16;

	private SwigDelegateOdRxRcsFileServices_17 swigDelegate17;

	private SwigDelegateOdRxRcsFileServices_18 swigDelegate18;

	private SwigDelegateOdRxRcsFileServices_19 swigDelegate19;

	private SwigDelegateOdRxRcsFileServices_20 swigDelegate20;

	private SwigDelegateOdRxRcsFileServices_21 swigDelegate21;

	private SwigDelegateOdRxRcsFileServices_22 swigDelegate22;

	private SwigDelegateOdRxRcsFileServices_23 swigDelegate23;

	private SwigDelegateOdRxRcsFileServices_24 swigDelegate24;

	private SwigDelegateOdRxRcsFileServices_25 swigDelegate25;

	private SwigDelegateOdRxRcsFileServices_26 swigDelegate26;

	private SwigDelegateOdRxRcsFileServices_27 swigDelegate27;

	private SwigDelegateOdRxRcsFileServices_28 swigDelegate28;

	private SwigDelegateOdRxRcsFileServices_29 swigDelegate29;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(OdPointCloudDatabaseReceiver)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdPointCloudDatabaseReceiver)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(string),
		typeof(OdPointCloudProjectScanStorage),
		typeof(OdPointCloudDatabaseReceiver)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(OdPointCloudProjectScanStorage)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdPointCloudProjectScanStorage),
		typeof(OdPointCloudDatabaseReceiver)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdPointCloudProjectScanStorage)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdPointCloudDataSource),
		typeof(OdPointCloudConverterParams)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdPointCloudDataSource) };

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdPointCloudScanDatabase),
		typeof(OdPointCloudProjectDatabase)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdPointCloudScanDatabase) };

	private static Type[] swigMethodTypes20 = new Type[9]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange),
		typeof(OdUInt32Array),
		typeof(OdUInt32Array),
		typeof(uint),
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes21 = new Type[8]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange),
		typeof(OdUInt32Array),
		typeof(OdUInt32Array),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes22 = new Type[7]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange),
		typeof(OdUInt32Array),
		typeof(OdUInt32Array),
		typeof(uint)
	};

	private static Type[] swigMethodTypes23 = new Type[6]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange),
		typeof(OdUInt32Array),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes24 = new Type[5]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes25 = new Type[4]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint),
		typeof(OdPointCloudDataSource_ColorRange)
	};

	private static Type[] swigMethodTypes26 = new Type[3]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units),
		typeof(uint)
	};

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(string),
		typeof(OdPointCloudDataSource_Units)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes29 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxRcsFileServices(IntPtr cPtr, bool cMemoryOwn)
		: base(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxRcsFileServices obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					RcsFileServices_GlobalsPINVOKE.delete_OdRxRcsFileServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdPointCloudScanDatabase readRcsFile(string filePath, OdPointCloudDatabaseReceiver pDbReceiver)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcsFile__SWIG_0(swigCPtr, filePath, OdPointCloudDatabaseReceiver.getCPtr(pDbReceiver));
		OdPointCloudScanDatabase result = Helpers.odCreateObjectInternal<OdPointCloudScanDatabase>(typeof(OdPointCloudScanDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudScanDatabase readRcsFile(string filePath)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcsFile__SWIG_1(swigCPtr, filePath);
		OdPointCloudScanDatabase result = Helpers.odCreateObjectInternal<OdPointCloudScanDatabase>(typeof(OdPointCloudScanDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudScanDatabase readRcsFile(OdStreamBuf pFile, OdPointCloudDatabaseReceiver pDbReceiver)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcsFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pFile), OdPointCloudDatabaseReceiver.getCPtr(pDbReceiver));
		OdPointCloudScanDatabase result = Helpers.odCreateObjectInternal<OdPointCloudScanDatabase>(typeof(OdPointCloudScanDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudScanDatabase readRcsFile(OdStreamBuf pFile)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcsFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pFile));
		OdPointCloudScanDatabase result = Helpers.odCreateObjectInternal<OdPointCloudScanDatabase>(typeof(OdPointCloudScanDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudProjectDatabase readRcpFile(string filePath, OdPointCloudProjectScanStorage pScanStorage, OdPointCloudDatabaseReceiver pDbReceiver)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcpFile__SWIG_0(swigCPtr, filePath, OdPointCloudProjectScanStorage.getCPtr(pScanStorage), OdPointCloudDatabaseReceiver.getCPtr(pDbReceiver));
		OdPointCloudProjectDatabase result = Helpers.odCreateObjectInternal<OdPointCloudProjectDatabase>(typeof(OdPointCloudProjectDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudProjectDatabase readRcpFile(string filePath, OdPointCloudProjectScanStorage pScanStorage)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcpFile__SWIG_1(swigCPtr, filePath, OdPointCloudProjectScanStorage.getCPtr(pScanStorage));
		OdPointCloudProjectDatabase result = Helpers.odCreateObjectInternal<OdPointCloudProjectDatabase>(typeof(OdPointCloudProjectDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudProjectDatabase readRcpFile(OdStreamBuf pFile, OdPointCloudProjectScanStorage pScanStorage, OdPointCloudDatabaseReceiver pDbReceiver)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcpFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pFile), OdPointCloudProjectScanStorage.getCPtr(pScanStorage), OdPointCloudDatabaseReceiver.getCPtr(pDbReceiver));
		OdPointCloudProjectDatabase result = Helpers.odCreateObjectInternal<OdPointCloudProjectDatabase>(typeof(OdPointCloudProjectDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudProjectDatabase readRcpFile(OdStreamBuf pFile, OdPointCloudProjectScanStorage pScanStorage)
	{
		IntPtr targetNativeObj = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_readRcpFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pFile), OdPointCloudProjectScanStorage.getCPtr(pScanStorage));
		OdPointCloudProjectDatabase result = Helpers.odCreateObjectInternal<OdPointCloudProjectDatabase>(typeof(OdPointCloudProjectDatabase), targetNativeObj, bIsWrapperOwnNativeObject: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudConverter getPointCloudConverter(OdPointCloudDataSource pDataSource, OdPointCloudConverterParams pParams)
	{
		OdPointCloudConverter result = Helpers.GetObject<OdPointCloudConverter>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudConverter__SWIG_0(swigCPtr, OdPointCloudDataSource.getCPtr(pDataSource), OdPointCloudConverterParams.getCPtr(pParams)), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudConverter getPointCloudConverter(OdPointCloudDataSource pDataSource)
	{
		OdPointCloudConverter result = Helpers.GetObject<OdPointCloudConverter>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudConverter__SWIG_1(swigCPtr, OdPointCloudDataSource.getCPtr(pDataSource)), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRcsDataManager getRcsDataManager(OdPointCloudScanDatabase pScanDb, OdPointCloudProjectDatabase pHostProjectDb)
	{
		OdRcsDataManager result = Helpers.GetObject<OdRcsDataManager>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getRcsDataManager__SWIG_0(swigCPtr, OdPointCloudScanDatabase.getCPtr(pScanDb), OdPointCloudProjectDatabase.getCPtr(pHostProjectDb)), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRcsDataManager getRcsDataManager(OdPointCloudScanDatabase pScanDb)
	{
		OdRcsDataManager result = Helpers.GetObject<OdRcsDataManager>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getRcsDataManager__SWIG_1(swigCPtr, OdPointCloudScanDatabase.getCPtr(pScanDb)), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange, OdUInt32Array xyzIndexes, OdUInt32Array rgbIndexes, uint intensityIndex, uint skipLines, string separator)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_0(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange, OdUInt32Array.getCPtr(xyzIndexes).Handle, OdUInt32Array.getCPtr(rgbIndexes).Handle, intensityIndex, skipLines, separator), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange, OdUInt32Array xyzIndexes, OdUInt32Array rgbIndexes, uint intensityIndex, uint skipLines)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_1(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange, OdUInt32Array.getCPtr(xyzIndexes).Handle, OdUInt32Array.getCPtr(rgbIndexes).Handle, intensityIndex, skipLines), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange, OdUInt32Array xyzIndexes, OdUInt32Array rgbIndexes, uint intensityIndex)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_2(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange, OdUInt32Array.getCPtr(xyzIndexes).Handle, OdUInt32Array.getCPtr(rgbIndexes).Handle, intensityIndex), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange, OdUInt32Array xyzIndexes, OdUInt32Array rgbIndexes)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_3(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange, OdUInt32Array.getCPtr(xyzIndexes).Handle, OdUInt32Array.getCPtr(rgbIndexes).Handle), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange, OdUInt32Array xyzIndexes)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_4(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange, OdUInt32Array.getCPtr(xyzIndexes).Handle), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor, OdPointCloudDataSource_ColorRange colorRange)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_5(swigCPtr, filePath, (int)units, defaultColor, (int)colorRange), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units, uint defaultColor)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_6(swigCPtr, filePath, (int)units, defaultColor), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath, OdPointCloudDataSource_Units units)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_7(swigCPtr, filePath, (int)units), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource getPointCloudDataSource(string filePath)
	{
		OdPointCloudDataSource result = Helpers.GetObject<OdPointCloudDataSource>(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getPointCloudDataSource__SWIG_8(swigCPtr, filePath), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual SWIGTYPE_p_OdRcpFileWriterPtr getRcpFileWriter()
	{
		SWIGTYPE_p_OdRcpFileWriterPtr result = new SWIGTYPE_p_OdRcpFileWriterPtr(RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getRcpFileWriter(swigCPtr), futureUse: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxRcsFileServices()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdRxRcsFileServices(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxRcsFileServices) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("readRcsFile", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreadRcsFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readRcsFile", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodreadRcsFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readRcsFile", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodreadRcsFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readRcsFile", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodreadRcsFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("readRcpFile", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodreadRcpFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readRcpFile", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodreadRcpFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readRcpFile", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodreadRcpFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readRcpFile", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodreadRcpFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getPointCloudConverter", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetPointCloudConverter__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPointCloudConverter", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetPointCloudConverter__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getRcsDataManager", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetRcsDataManager__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getRcsDataManager", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetRcsDataManager__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetPointCloudDataSource__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetPointCloudDataSource__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetPointCloudDataSource__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetPointCloudDataSource__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodgetPointCloudDataSource__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetPointCloudDataSource__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetPointCloudDataSource__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetPointCloudDataSource__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("getPointCloudDataSource", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetPointCloudDataSource__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("getRcpFileWriter", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetRcpFileWriter;
		}
		RcsFileServices_GlobalsPINVOKE.OdRxRcsFileServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxRcsFileServices));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private IntPtr SwigDirectorMethodreadRcsFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pDbReceiver)
	{
		return OdPointCloudScanDatabase.getCPtr(readRcsFile(filePath, Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(pDbReceiver, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcsFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filePath)
	{
		return OdPointCloudScanDatabase.getCPtr(readRcsFile(filePath)).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcsFile__SWIG_2(IntPtr pFile, IntPtr pDbReceiver)
	{
		return OdPointCloudScanDatabase.getCPtr(readRcsFile(Helpers.GetRXObject<OdStreamBuf>(pFile, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(pDbReceiver, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcsFile__SWIG_3(IntPtr pFile)
	{
		return OdPointCloudScanDatabase.getCPtr(readRcsFile(Helpers.GetRXObject<OdStreamBuf>(pFile, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcpFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pScanStorage, IntPtr pDbReceiver)
	{
		return OdPointCloudProjectDatabase.getCPtr(readRcpFile(filePath, (pScanStorage == IntPtr.Zero) ? null : new OdPointCloudProjectScanStorage(pScanStorage, cMemoryOwn: false), Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(pDbReceiver, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcpFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filePath, IntPtr pScanStorage)
	{
		return OdPointCloudProjectDatabase.getCPtr(readRcpFile(filePath, (pScanStorage == IntPtr.Zero) ? null : new OdPointCloudProjectScanStorage(pScanStorage, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcpFile__SWIG_2(IntPtr pFile, IntPtr pScanStorage, IntPtr pDbReceiver)
	{
		return OdPointCloudProjectDatabase.getCPtr(readRcpFile(Helpers.GetRXObject<OdStreamBuf>(pFile, bOwn: true, bTryAddToTransaction: false), (pScanStorage == IntPtr.Zero) ? null : new OdPointCloudProjectScanStorage(pScanStorage, cMemoryOwn: false), Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(pDbReceiver, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodreadRcpFile__SWIG_3(IntPtr pFile, IntPtr pScanStorage)
	{
		return OdPointCloudProjectDatabase.getCPtr(readRcpFile(Helpers.GetRXObject<OdStreamBuf>(pFile, bOwn: true, bTryAddToTransaction: false), (pScanStorage == IntPtr.Zero) ? null : new OdPointCloudProjectScanStorage(pScanStorage, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudConverter__SWIG_0(IntPtr pDataSource, IntPtr pParams)
	{
		return OdPointCloudConverter.getCPtr(getPointCloudConverter(Helpers.GetObject<OdPointCloudDataSource>(pDataSource, bOwn: true, bTryAddToTransaction: false), Helpers.GetObject<OdPointCloudConverterParams>(pParams, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudConverter__SWIG_1(IntPtr pDataSource)
	{
		return OdPointCloudConverter.getCPtr(getPointCloudConverter(Helpers.GetObject<OdPointCloudDataSource>(pDataSource, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetRcsDataManager__SWIG_0(IntPtr pScanDb, IntPtr pHostProjectDb)
	{
		return OdRcsDataManager.getCPtr(getRcsDataManager(Helpers.GetObject<OdPointCloudScanDatabase>(pScanDb, bOwn: true, bTryAddToTransaction: false), Helpers.GetObject<OdPointCloudProjectDatabase>(pHostProjectDb, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetRcsDataManager__SWIG_1(IntPtr pScanDb)
	{
		return OdRcsDataManager.getCPtr(getRcsDataManager(Helpers.GetObject<OdPointCloudScanDatabase>(pScanDb, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex, uint skipLines, [MarshalAs(UnmanagedType.LPWStr)] string separator)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange, new OdUInt32Array(xyzIndexes, cMemoryOwn: true), new OdUInt32Array(rgbIndexes, cMemoryOwn: true), intensityIndex, skipLines, separator)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex, uint skipLines)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange, new OdUInt32Array(xyzIndexes, cMemoryOwn: true), new OdUInt32Array(rgbIndexes, cMemoryOwn: true), intensityIndex, skipLines)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes, uint intensityIndex)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange, new OdUInt32Array(xyzIndexes, cMemoryOwn: true), new OdUInt32Array(rgbIndexes, cMemoryOwn: true), intensityIndex)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes, IntPtr rgbIndexes)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange, new OdUInt32Array(xyzIndexes, cMemoryOwn: true), new OdUInt32Array(rgbIndexes, cMemoryOwn: true))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange, IntPtr xyzIndexes)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange, new OdUInt32Array(xyzIndexes, cMemoryOwn: true))).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_5([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor, int colorRange)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor, (OdPointCloudDataSource_ColorRange)colorRange)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_6([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units, uint defaultColor)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units, defaultColor)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_7([MarshalAs(UnmanagedType.LPWStr)] string filePath, int units)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath, (OdPointCloudDataSource_Units)units)).Handle;
	}

	private IntPtr SwigDirectorMethodgetPointCloudDataSource__SWIG_8([MarshalAs(UnmanagedType.LPWStr)] string filePath)
	{
		return OdPointCloudDataSource.getCPtr(getPointCloudDataSource(filePath)).Handle;
	}

	private IntPtr SwigDirectorMethodgetRcpFileWriter()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return SWIGTYPE_p_OdRcpFileWriterPtr.getCPtr(getRcpFileWriter()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				RcsFileServices_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				RcsFileServices_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				RcsFileServices_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
