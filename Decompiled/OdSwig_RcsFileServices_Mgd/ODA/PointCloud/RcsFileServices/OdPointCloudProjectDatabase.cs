using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudProjectDatabase : IDisposable
{
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudProjectDatabase_0();

	public delegate IntPtr SwigDelegateOdPointCloudProjectDatabase_1();

	public delegate void SwigDelegateOdPointCloudProjectDatabase_2(IntPtr list);

	public delegate void SwigDelegateOdPointCloudProjectDatabase_3(IntPtr list);

	public delegate IntPtr SwigDelegateOdPointCloudProjectDatabase_4();

	public delegate IntPtr SwigDelegateOdPointCloudProjectDatabase_5([MarshalAs(UnmanagedType.LPWStr)] string guid);

	public delegate uint SwigDelegateOdPointCloudProjectDatabase_6();

	public delegate uint SwigDelegateOdPointCloudProjectDatabase_7();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudProjectDatabase_8();

	public delegate sbyte SwigDelegateOdPointCloudProjectDatabase_9();

	public delegate sbyte SwigDelegateOdPointCloudProjectDatabase_10();

	public delegate sbyte SwigDelegateOdPointCloudProjectDatabase_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudProjectDatabase_12([MarshalAs(UnmanagedType.LPWStr)] string guid);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPointCloudProjectDatabase_13([MarshalAs(UnmanagedType.LPWStr)] string guid);

	public delegate ulong SwigDelegateOdPointCloudProjectDatabase_14();

	public delegate IntPtr SwigDelegateOdPointCloudProjectDatabase_15();

	public delegate void SwigDelegateOdPointCloudProjectDatabase_16(IntPtr s);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudProjectDatabase_0 swigDelegate0;

	private SwigDelegateOdPointCloudProjectDatabase_1 swigDelegate1;

	private SwigDelegateOdPointCloudProjectDatabase_2 swigDelegate2;

	private SwigDelegateOdPointCloudProjectDatabase_3 swigDelegate3;

	private SwigDelegateOdPointCloudProjectDatabase_4 swigDelegate4;

	private SwigDelegateOdPointCloudProjectDatabase_5 swigDelegate5;

	private SwigDelegateOdPointCloudProjectDatabase_6 swigDelegate6;

	private SwigDelegateOdPointCloudProjectDatabase_7 swigDelegate7;

	private SwigDelegateOdPointCloudProjectDatabase_8 swigDelegate8;

	private SwigDelegateOdPointCloudProjectDatabase_9 swigDelegate9;

	private SwigDelegateOdPointCloudProjectDatabase_10 swigDelegate10;

	private SwigDelegateOdPointCloudProjectDatabase_11 swigDelegate11;

	private SwigDelegateOdPointCloudProjectDatabase_12 swigDelegate12;

	private SwigDelegateOdPointCloudProjectDatabase_13 swigDelegate13;

	private SwigDelegateOdPointCloudProjectDatabase_14 swigDelegate14;

	private SwigDelegateOdPointCloudProjectDatabase_15 swigDelegate15;

	private SwigDelegateOdPointCloudProjectDatabase_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdStreamBuf) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudProjectDatabase(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudProjectDatabase obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudProjectDatabase()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudProjectDatabase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual string getProjectDatabaseFilePath()
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getProjectDatabaseFilePath(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudScanIterator getScanIterator()
	{
		OdPointCloudScanIterator result = Helpers.GetObject<OdPointCloudScanIterator>(RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getScanIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getAllRcsFilePaths(OdStringArray list)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getAllRcsFilePaths(swigCPtr, OdStringArray.getCPtr(list).Handle);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getAllRcsRelativeFilePaths(OdStringArray list)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getAllRcsRelativeFilePaths(swigCPtr, OdStringArray.getCPtr(list).Handle);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d getGlobalTransformation()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getGlobalTransformation(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getScanTransform(string guid)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getScanTransform(swigCPtr, guid), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getTotalRegionsCount()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getTotalRegionsCount(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getTotalScansCount()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getTotalScansCount(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCoordinateSystemName()
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getCoordinateSystemName(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte hasRGB()
	{
		sbyte result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_hasRGB(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte hasNormals()
	{
		sbyte result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_hasNormals(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte hasIntensity()
	{
		sbyte result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_hasIntensity(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getRcsFilePath(string guid)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getRcsFilePath(swigCPtr, guid);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getRcsRelativeFilePath(string guid)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getRcsRelativeFilePath(swigCPtr, guid);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong getTotalAmountOfPoints()
	{
		ulong result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getTotalAmountOfPoints(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getExtents(swigCPtr), cMemoryOwn: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeAllXmlDataToStream(OdStreamBuf s)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_writeAllXmlDataToStream(swigCPtr, OdStreamBuf.getCPtr(s));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudProjectDatabase()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudProjectDatabase(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudProjectDatabase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getProjectDatabaseFilePath", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetProjectDatabaseFilePath;
		}
		if (SwigDerivedClassHasMethod("getScanIterator", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetScanIterator;
		}
		if (SwigDerivedClassHasMethod("getAllRcsFilePaths", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetAllRcsFilePaths;
		}
		if (SwigDerivedClassHasMethod("getAllRcsRelativeFilePaths", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetAllRcsRelativeFilePaths;
		}
		if (SwigDerivedClassHasMethod("getGlobalTransformation", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetGlobalTransformation;
		}
		if (SwigDerivedClassHasMethod("getScanTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetScanTransform;
		}
		if (SwigDerivedClassHasMethod("getTotalRegionsCount", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetTotalRegionsCount;
		}
		if (SwigDerivedClassHasMethod("getTotalScansCount", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetTotalScansCount;
		}
		if (SwigDerivedClassHasMethod("getCoordinateSystemName", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetCoordinateSystemName;
		}
		if (SwigDerivedClassHasMethod("hasRGB", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodhasRGB;
		}
		if (SwigDerivedClassHasMethod("hasNormals", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodhasNormals;
		}
		if (SwigDerivedClassHasMethod("hasIntensity", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodhasIntensity;
		}
		if (SwigDerivedClassHasMethod("getRcsFilePath", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetRcsFilePath;
		}
		if (SwigDerivedClassHasMethod("getRcsRelativeFilePath", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetRcsRelativeFilePath;
		}
		if (SwigDerivedClassHasMethod("getTotalAmountOfPoints", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetTotalAmountOfPoints;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("writeAllXmlDataToStream", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwriteAllXmlDataToStream;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectDatabase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudProjectDatabase));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetProjectDatabaseFilePath()
	{
		return getProjectDatabaseFilePath();
	}

	private IntPtr SwigDirectorMethodgetScanIterator()
	{
		return OdPointCloudScanIterator.getCPtr(getScanIterator()).Handle;
	}

	private void SwigDirectorMethodgetAllRcsFilePaths(IntPtr list)
	{
		try
		{
			getAllRcsFilePaths(new OdStringArray(list, cMemoryOwn: true));
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

	private void SwigDirectorMethodgetAllRcsRelativeFilePaths(IntPtr list)
	{
		try
		{
			getAllRcsRelativeFilePaths(new OdStringArray(list, cMemoryOwn: true));
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

	private IntPtr SwigDirectorMethodgetGlobalTransformation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getGlobalTransformation()).Handle;
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

	private IntPtr SwigDirectorMethodgetScanTransform([MarshalAs(UnmanagedType.LPWStr)] string guid)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getScanTransform(guid)).Handle;
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

	private uint SwigDirectorMethodgetTotalRegionsCount()
	{
		return getTotalRegionsCount();
	}

	private uint SwigDirectorMethodgetTotalScansCount()
	{
		return getTotalScansCount();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetCoordinateSystemName()
	{
		return getCoordinateSystemName();
	}

	private sbyte SwigDirectorMethodhasRGB()
	{
		return hasRGB();
	}

	private sbyte SwigDirectorMethodhasNormals()
	{
		return hasNormals();
	}

	private sbyte SwigDirectorMethodhasIntensity()
	{
		return hasIntensity();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetRcsFilePath([MarshalAs(UnmanagedType.LPWStr)] string guid)
	{
		return getRcsFilePath(guid);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetRcsRelativeFilePath([MarshalAs(UnmanagedType.LPWStr)] string guid)
	{
		return getRcsRelativeFilePath(guid);
	}

	private ulong SwigDirectorMethodgetTotalAmountOfPoints()
	{
		return getTotalAmountOfPoints();
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

	private void SwigDirectorMethodwriteAllXmlDataToStream(IntPtr s)
	{
		try
		{
			writeAllXmlDataToStream(Helpers.GetRXObject<OdStreamBuf>(s, bOwn: false, bTryAddToTransaction: false));
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
}
