using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;

namespace Basler.Pylon;

internal class GrabResult : IGrabResult
{
	private ObjectState m_objectState;

	private GenApiParameterCollection m_parameterCollection;

	private unsafe CGrabResultPtr* m_pPtrGrabResult;

	private object m_StreamGrabberContextInfo;

	public unsafe virtual IDataContainer Container
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out CPylonDataContainer cPylonDataContainer);
				CPylonDataContainer* ptr = global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetDataContainer(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult), &cPylonDataContainer);
				IDataContainer result;
				try
				{
					result = new DataContainer(ptr, m_pPtrGrabResult);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPylonDataContainer*, void>)(&global::_003CModule_003E.Pylon_002ECPylonDataContainer_002E_007Bdtor_007D), &cPylonDataContainer);
					throw;
				}
				global::_003CModule_003E.Pylon_002ECPylonDataContainer_002E_007Bdtor_007D(&cPylonDataContainer);
				return result;
			}
			return null;
		}
	}

	public unsafe virtual long SkippedImageCount
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetNumberOfSkippedImages(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual long ImageNumber
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetImageNumber(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual long ID
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetID(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual object BufferUserData
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				NativeBufferContext* ptr = (NativeBufferContext*)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBufferContext(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
				if (null != ptr)
				{
					return global::_003CModule_003E.gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)ptr + 12));
				}
			}
			return null;
		}
	}

	public virtual object StreamGrabberUserData
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return m_StreamGrabberContextInfo;
			}
			return null;
		}
	}

	public unsafe virtual long Timestamp
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return (long)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetTimeStamp(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual long BlockID
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				return (long)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBlockID(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual long PayloadSize
	{
		get
		{
			if (IsGrabResultPtrValid() && global::_003CModule_003E.Pylon_002ECGrabResultData_002EGrabSucceeded(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult)))
			{
				return global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPayloadSize(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return 0L;
		}
	}

	public unsafe virtual bool HasCRC
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			bool result = false;
			if (IsGrabResultPtrValid())
			{
				result = global::_003CModule_003E.Pylon_002ECGrabResultData_002EHasCRC(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public virtual IParameterCollection ChunkData => m_parameterCollection;

	public unsafe virtual bool HasChunkData
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			bool result = false;
			if (IsGrabResultPtrValid())
			{
				result = global::_003CModule_003E.Pylon_002ECGrabResultData_002EIsChunkDataAvailable(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual string ErrorDescription
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* from_obj = global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetErrorDescription(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult), &gcstring2);
				string result;
				try
				{
					result = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				return result;
			}
			return "<disposed>";
		}
	}

	public unsafe virtual int ErrorCode
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetErrorCode(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual bool GrabSucceeded
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			bool result = false;
			if (IsGrabResultPtrValid())
			{
				result = global::_003CModule_003E.Pylon_002ECGrabResultData_002EGrabSucceeded(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual PayloadType PayloadTypeValue
	{
		get
		{
			int result = -1;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPayloadType(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return (PayloadType)result;
		}
	}

	public unsafe virtual int OffsetY
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetOffsetY(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual int OffsetX
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetOffsetX(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual int PaddingY
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPaddingY(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual int PaddingX
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPaddingX(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual int Height
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetHeight(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual int Width
	{
		get
		{
			int result = 0;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetWidth(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return result;
		}
	}

	public unsafe virtual PixelType PixelTypeValue
	{
		get
		{
			int result = -1;
			if (IsGrabResultPtrValid())
			{
				result = (int)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPixelType(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
			}
			return (PixelType)result;
		}
	}

	public virtual ImageOrientation Orientation => ImageOrientation.TopDown;

	public unsafe virtual IntPtr PixelDataPointer
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				NativeBufferContext* ptr = (NativeBufferContext*)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBufferContext(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
				if (null != ptr)
				{
					return (IntPtr)global::_003CModule_003E.gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002EP_0024AA__ZVIntPtr_0040System_0040_0040((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)ptr + 8));
				}
			}
			return IntPtr.Zero;
		}
	}

	public unsafe virtual object PixelData
	{
		get
		{
			if (IsGrabResultPtrValid())
			{
				NativeBufferContext* ptr = (NativeBufferContext*)global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetBufferContext(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
				if (null != ptr)
				{
					return global::_003CModule_003E.gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)ptr + 4));
				}
			}
			return null;
		}
	}

	public unsafe virtual bool IsValid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			ScopedObjectStateLock scopedObjectStateLock = null;
			ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_objectState);
			CGrabResultPtr* pPtrGrabResult;
			try
			{
				scopedObjectStateLock = scopedObjectStateLock2;
				if (IsGrabResultPtrValid())
				{
					pPtrGrabResult = m_pPtrGrabResult;
					if (global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPayloadType(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(pPtrGrabResult)) != (EPayloadType)4 || global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPayloadSize(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(pPtrGrabResult)) == 0)
					{
						goto IL_0056;
					}
					goto IL_004d;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			goto IL_0097;
			IL_004d:
			((IDisposable)scopedObjectStateLock).Dispose();
			return true;
			IL_0056:
			try
			{
				if (global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetPixelType(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(pPtrGrabResult)) != (EPixelType)(-1) && global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetWidth(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(pPtrGrabResult)) != 0 && global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetHeight(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(pPtrGrabResult)) != 0)
				{
					goto IL_008f;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)scopedObjectStateLock).Dispose();
				throw;
			}
			goto IL_0097;
			IL_008f:
			((IDisposable)scopedObjectStateLock).Dispose();
			return true;
			IL_0097:
			((IDisposable)scopedObjectStateLock).Dispose();
			return false;
		}
	}

	private unsafe GrabResult(GrabResult rhs)
	{
		m_objectState = rhs.m_objectState;
		m_parameterCollection = rhs.m_parameterCollection;
		CGrabResultPtr* ptr = (CGrabResultPtr*)global::_003CModule_003E.@new(8u);
		CGrabResultPtr* pPtrGrabResult;
		try
		{
			pPtrGrabResult = ((ptr == null) ? null : global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bctor_007D(ptr, rhs.m_pPtrGrabResult));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr, 8u);
			throw;
		}
		m_pPtrGrabResult = pPtrGrabResult;
		m_StreamGrabberContextInfo = rhs.m_StreamGrabberContextInfo;
		base._002Ector();
		global::_003CModule_003E.CPylonLibraryNative_002EInit(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
	}

	public unsafe GrabResult(CGrabResultPtr* ptr, object streamGrabberContextInfo)
	{
		m_objectState = null;
		m_parameterCollection = null;
		CGrabResultPtr* ptr2 = (CGrabResultPtr*)global::_003CModule_003E.@new(8u);
		CGrabResultPtr* pPtrGrabResult;
		try
		{
			pPtrGrabResult = ((ptr2 == null) ? null : global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bctor_007D(ptr2, ptr));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr2, 8u);
			throw;
		}
		m_pPtrGrabResult = pPtrGrabResult;
		m_StreamGrabberContextInfo = streamGrabberContextInfo;
		base._002Ector();
		global::_003CModule_003E.CPylonLibraryNative_002EInit(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
		string name = "GrabResult";
		ObjectState objectState = new ObjectState(this)
		{
			m_name = name,
			m_state = EObjectState.Open
		};
		m_objectState = objectState;
		string nodeMapName = "ChunkData";
		(m_parameterCollection = new GenApiParameterCollection(objectState)).AnnounceWrapper(nodeMapName, needsParentOpen: false);
		m_parameterCollection.Attach(nodeMapName, global::_003CModule_003E.Pylon_002ECGrabResultData_002EGetChunkDataNodeMap(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult)));
	}

	private void _007EGrabResult()
	{
		_0021GrabResult();
	}

	private unsafe void _0021GrabResult()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_objectState);
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			CGrabResultPtr* pPtrGrabResult = m_pPtrGrabResult;
			if (pPtrGrabResult != null)
			{
				m_StreamGrabberContextInfo = null;
				if (global::_003CModule_003E.Pylon_002ECGrabResultPtr_002EIsUnique(pPtrGrabResult))
				{
					m_objectState.m_state = EObjectState.Disposed;
				}
				CGrabResultPtr* pPtrGrabResult2 = m_pPtrGrabResult;
				m_pPtrGrabResult = null;
				if (pPtrGrabResult2 != null)
				{
					global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bdtor_007D(pPtrGrabResult2);
					global::_003CModule_003E.delete(pPtrGrabResult2, 8u);
				}
				global::_003CModule_003E.CPylonLibraryNative_002ERelease(global::_003CModule_003E.CPylonLibraryNative_002EgetInstance());
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool CheckCRC()
	{
		RaiseExceptionIfDisposed();
		bool result = false;
		if (IsGrabResultPtrValid() && global::_003CModule_003E.Pylon_002ECGrabResultData_002EHasCRC(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult)))
		{
			result = global::_003CModule_003E.Pylon_002ECGrabResultData_002ECheckCRC(global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002D_003E(m_pPtrGrabResult));
		}
		return result;
	}

	public virtual IGrabResult Clone()
	{
		ScopedObjectStateLock scopedObjectStateLock = null;
		ScopedObjectStateLock scopedObjectStateLock2 = new ScopedObjectStateLock(m_objectState);
		IGrabResult result;
		try
		{
			scopedObjectStateLock = scopedObjectStateLock2;
			RaiseExceptionIfDisposed();
			result = new GrabResult(this);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedObjectStateLock).Dispose();
			throw;
		}
		((IDisposable)scopedObjectStateLock).Dispose();
		return result;
	}

	private unsafe void RaiseExceptionIfDisposed()
	{
		if (!IsGrabResultPtrValid())
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_003E(new ObjectDisposedException("GrabResult", "The grab result has already been disposed."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BG_0040FPAEOFNE_0040_003F_0024AAG_003F_0024AAr_003F_0024AAa_003F_0024AAb_003F_0024AAR_003F_0024AAe_003F_0024AAs_003F_0024AAu_003F_0024AAl_003F_0024AAt_0040));
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private unsafe bool IsGrabResultPtrValid()
	{
		CGrabResultPtr* pPtrGrabResult = m_pPtrGrabResult;
		if (pPtrGrabResult != null && global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_002E_N(pPtrGrabResult))
		{
			return true;
		}
		return false;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007EGrabResult();
			return;
		}
		try
		{
			_0021GrabResult();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}

	~GrabResult()
	{
		Dispose(A_0: false);
	}
}
