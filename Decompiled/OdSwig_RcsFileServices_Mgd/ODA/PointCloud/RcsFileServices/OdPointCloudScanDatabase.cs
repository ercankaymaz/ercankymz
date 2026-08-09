using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudScanDatabase : IDisposable
{
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudScanDatabase_0();

	public delegate ulong SwigDelegateOdPointCloudScanDatabase_1();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudScanDatabase_2();

	public delegate bool SwigDelegateOdPointCloudScanDatabase_3();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_4();

	public delegate ulong SwigDelegateOdPointCloudScanDatabase_5();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_6();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_7();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_8();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_9();

	public delegate bool SwigDelegateOdPointCloudScanDatabase_10();

	public delegate bool SwigDelegateOdPointCloudScanDatabase_11();

	public delegate bool SwigDelegateOdPointCloudScanDatabase_12();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_13();

	public delegate IntPtr SwigDelegateOdPointCloudScanDatabase_14();

	public delegate bool SwigDelegateOdPointCloudScanDatabase_15();

	public delegate float SwigDelegateOdPointCloudScanDatabase_16();

	public delegate float SwigDelegateOdPointCloudScanDatabase_17();

	public delegate uint SwigDelegateOdPointCloudScanDatabase_18();

	public delegate uint SwigDelegateOdPointCloudScanDatabase_19();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudScanDatabase_0 swigDelegate0;

	private SwigDelegateOdPointCloudScanDatabase_1 swigDelegate1;

	private SwigDelegateOdPointCloudScanDatabase_2 swigDelegate2;

	private SwigDelegateOdPointCloudScanDatabase_3 swigDelegate3;

	private SwigDelegateOdPointCloudScanDatabase_4 swigDelegate4;

	private SwigDelegateOdPointCloudScanDatabase_5 swigDelegate5;

	private SwigDelegateOdPointCloudScanDatabase_6 swigDelegate6;

	private SwigDelegateOdPointCloudScanDatabase_7 swigDelegate7;

	private SwigDelegateOdPointCloudScanDatabase_8 swigDelegate8;

	private SwigDelegateOdPointCloudScanDatabase_9 swigDelegate9;

	private SwigDelegateOdPointCloudScanDatabase_10 swigDelegate10;

	private SwigDelegateOdPointCloudScanDatabase_11 swigDelegate11;

	private SwigDelegateOdPointCloudScanDatabase_12 swigDelegate12;

	private SwigDelegateOdPointCloudScanDatabase_13 swigDelegate13;

	private SwigDelegateOdPointCloudScanDatabase_14 swigDelegate14;

	private SwigDelegateOdPointCloudScanDatabase_15 swigDelegate15;

	private SwigDelegateOdPointCloudScanDatabase_16 swigDelegate16;

	private SwigDelegateOdPointCloudScanDatabase_17 swigDelegate17;

	private SwigDelegateOdPointCloudScanDatabase_18 swigDelegate18;

	private SwigDelegateOdPointCloudScanDatabase_19 swigDelegate19;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudScanDatabase(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudScanDatabase obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudScanDatabase()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudScanDatabase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual string getScanDatabaseFilePath()
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getScanDatabaseFilePath(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong getTotalAmountOfPoints()
	{
		ulong result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getTotalAmountOfPoints(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getScanId()
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getScanId(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLidarData()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_isLidarData(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRcsVoxelIterator getVoxelIterator()
	{
		OdRcsVoxelIterator result = Helpers.GetObject<OdRcsVoxelIterator>(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getVoxelIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong getAmountOfVoxels()
	{
		ulong result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getAmountOfVoxels(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getTranslation()
	{
		OdGeVector3d result = new OdGeVector3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getTranslation(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getRotation()
	{
		OdGeVector3d result = new OdGeVector3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getRotation(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getScale()
	{
		OdGeVector3d result = new OdGeVector3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getScale(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getTransformMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getTransformMatrix(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasRGB()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_hasRGB(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasNormals()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_hasNormals(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasIntensity()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_hasIntensity(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getExtents(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getTransformedExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getTransformedExtents(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getNormalizeIntensity()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getNormalizeIntensity(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual float getMaxIntensity()
	{
		float result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getMaxIntensity(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual float getMinIntensity()
	{
		float result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getMinIntensity(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getRangeImageWidth()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getRangeImageWidth(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getRangeImageHeight()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getRangeImageHeight(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudScanDatabase()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudScanDatabase(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudScanDatabase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getScanDatabaseFilePath", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetScanDatabaseFilePath;
		}
		if (SwigDerivedClassHasMethod("getTotalAmountOfPoints", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetTotalAmountOfPoints;
		}
		if (SwigDerivedClassHasMethod("getScanId", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetScanId;
		}
		if (SwigDerivedClassHasMethod("isLidarData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisLidarData;
		}
		if (SwigDerivedClassHasMethod("getVoxelIterator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetVoxelIterator;
		}
		if (SwigDerivedClassHasMethod("getAmountOfVoxels", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetAmountOfVoxels;
		}
		if (SwigDerivedClassHasMethod("getTranslation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetTranslation;
		}
		if (SwigDerivedClassHasMethod("getRotation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetRotation;
		}
		if (SwigDerivedClassHasMethod("getScale", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetScale;
		}
		if (SwigDerivedClassHasMethod("getTransformMatrix", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetTransformMatrix;
		}
		if (SwigDerivedClassHasMethod("hasRGB", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodhasRGB;
		}
		if (SwigDerivedClassHasMethod("hasNormals", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodhasNormals;
		}
		if (SwigDerivedClassHasMethod("hasIntensity", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodhasIntensity;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("getTransformedExtents", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetTransformedExtents;
		}
		if (SwigDerivedClassHasMethod("getNormalizeIntensity", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetNormalizeIntensity;
		}
		if (SwigDerivedClassHasMethod("getMaxIntensity", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetMaxIntensity;
		}
		if (SwigDerivedClassHasMethod("getMinIntensity", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetMinIntensity;
		}
		if (SwigDerivedClassHasMethod("getRangeImageWidth", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetRangeImageWidth;
		}
		if (SwigDerivedClassHasMethod("getRangeImageHeight", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetRangeImageHeight;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudScanDatabase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudScanDatabase));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetScanDatabaseFilePath()
	{
		return getScanDatabaseFilePath();
	}

	private ulong SwigDirectorMethodgetTotalAmountOfPoints()
	{
		return getTotalAmountOfPoints();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetScanId()
	{
		return getScanId();
	}

	private bool SwigDirectorMethodisLidarData()
	{
		return isLidarData();
	}

	private IntPtr SwigDirectorMethodgetVoxelIterator()
	{
		return OdRcsVoxelIterator.getCPtr(getVoxelIterator()).Handle;
	}

	private ulong SwigDirectorMethodgetAmountOfVoxels()
	{
		return getAmountOfVoxels();
	}

	private IntPtr SwigDirectorMethodgetTranslation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getTranslation()).Handle;
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

	private IntPtr SwigDirectorMethodgetRotation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getRotation()).Handle;
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

	private IntPtr SwigDirectorMethodgetScale()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getScale()).Handle;
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

	private IntPtr SwigDirectorMethodgetTransformMatrix()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getTransformMatrix()).Handle;
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

	private bool SwigDirectorMethodhasRGB()
	{
		return hasRGB();
	}

	private bool SwigDirectorMethodhasNormals()
	{
		return hasNormals();
	}

	private bool SwigDirectorMethodhasIntensity()
	{
		return hasIntensity();
	}

	private IntPtr SwigDirectorMethodgetExtents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(getExtents()).Handle;
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

	private IntPtr SwigDirectorMethodgetTransformedExtents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(getTransformedExtents()).Handle;
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

	private bool SwigDirectorMethodgetNormalizeIntensity()
	{
		return getNormalizeIntensity();
	}

	private float SwigDirectorMethodgetMaxIntensity()
	{
		return getMaxIntensity();
	}

	private float SwigDirectorMethodgetMinIntensity()
	{
		return getMinIntensity();
	}

	private uint SwigDirectorMethodgetRangeImageWidth()
	{
		return getRangeImageWidth();
	}

	private uint SwigDirectorMethodgetRangeImageHeight()
	{
		return getRangeImageHeight();
	}
}
