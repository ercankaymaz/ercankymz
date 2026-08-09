using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsEntityNode : OdGsNode, OdSiEntity
{
	public class MetafileEx : OdGsUpdateManager.OdGsUpdateManagerElement
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MetafileEx(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MetafileEx obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsEntityNode_MetafileEx(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public void setDevice(OdRxObject dev)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_setDevice(swigCPtr, OdRxObject.getCPtr(dev));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdRxObject device()
		{
			OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_device(swigCPtr), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public void setMetafileLength(ulong l)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_setMetafileLength(swigCPtr, l);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public ulong metafileLength()
		{
			ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_metafileLength(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		protected static string getRealClassName(IntPtr ptr)
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileEx_getRealClassName(ptr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class MetafilePtrArray : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MetafilePtrArray(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MetafilePtrArray obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~MetafilePtrArray()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsEntityNode_MetafilePtrArray(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public MetafilePtrArray()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode_MetafilePtrArray(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class MetafileHolder : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public const int kArray = 1;

		public const int kVpDependent = 2;

		public const int kAwareFlagsRegenType = 4;

		public const int kRegenTypeStandard = 8;

		public const int kRegenTypeHideOrShade = 16;

		public const int kRegenTypeRenderCommand = 32;

		public const int kRegenTypeMask = 56;

		public const int kDependentGeometry = 64;

		public const int kLayerDependent = 128;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MetafileHolder(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MetafileHolder obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~MetafileHolder()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsEntityNode_MetafileHolder(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public MetafileHolder()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode_MetafileHolder__SWIG_0(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public MetafileHolder(MetafileHolder c)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode_MetafileHolder__SWIG_1(getCPtr(c)), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isValid()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isValid(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isArray()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isArray(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isVpDependent()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isVpDependent(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setVpDependent(bool bOn)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_setVpDependent(swigCPtr, bOn);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isAwareFlagsRegenType()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isAwareFlagsRegenType(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isRegenTypeDependent()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isRegenTypeDependent(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setDependentGeometry(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_setDependentGeometry(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isDependentGeometry()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isDependentGeometry(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setLayerDependent(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_setLayerDependent(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isLayerDependent()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_isLayerDependent(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public MetafilePtrArray getArray()
		{
			MetafilePtrArray result = new MetafilePtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_getArray__SWIG_0(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void allocateArray()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_allocateArray(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void destroy()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_destroy(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public int checkValid()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_checkValid(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void moveTo(MetafileHolder c, out int n)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_moveTo(swigCPtr, getCPtr(c), out n);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public uint awareFlags(uint nVpID)
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_MetafileHolder_awareFlags(swigCPtr, nVpID);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class TransformedExtents : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformedExtents(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(TransformedExtents obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~TransformedExtents()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsEntityNode_TransformedExtents(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public TransformedExtents(OdGsEntityNode pNode)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode_TransformedExtents(OdGsEntityNode.getCPtr(pNode)), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsEntityNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsEntityNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsEntityNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdSiEntity.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_OdSiEntity_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public static IntPtr Alloc(uint nBytes)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_Alloc(nBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void Free(IntPtr pMemBlock)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_Free(pMemBlock);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static IntPtr Realloc(IntPtr pMemBlock, uint newSize, uint arg2)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_Realloc(pMemBlock, newSize, arg2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject findFirstGsMetafile(OdGsViewImpl view, bool bContainsNested, OdGsEntityNode_MetafileCompatibilityLevel findCompatibleLevel)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_findFirstGsMetafile__SWIG_0(swigCPtr, OdGsViewImpl.getCPtr(view), bContainsNested, (int)findCompatibleLevel), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject findFirstGsMetafile(OdGsViewImpl view, bool bContainsNested)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_findFirstGsMetafile__SWIG_1(swigCPtr, OdGsViewImpl.getCPtr(view), bContainsNested), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject findFirstGsMetafile(OdGsViewImpl view)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_findFirstGsMetafile__SWIG_2(swigCPtr, OdGsViewImpl.getCPtr(view)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsEntityNode cast(OdRxObject pObj)
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsEntityNode createObject()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsEntityNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsEntityNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsEntityNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNextEntity(OdGsEntityNode pNextEntity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setNextEntity__SWIG_0(swigCPtr, getCPtr(pNextEntity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNextEntity(uint nVpId, OdGsEntityNode pNextEntity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setNextEntity__SWIG_1(swigCPtr, nVpId, getCPtr(pNextEntity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsEntityNode nextEntity()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_nextEntity__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsEntityNode nextEntity(uint nVpId)
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_nextEntity__SWIG_1(swigCPtr, nVpId), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint numNextEntity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_numNextEntity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableMultipleNextEntities(uint nMaxVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_enableMultipleNextEntities(swigCPtr, nMaxVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void updateVisible(OdGsViewImpl pViewImpl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_updateVisible(swigCPtr, OdGsViewImpl.getCPtr(pViewImpl));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint awareFlags(uint viewportId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_awareFlags(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual ENodeType nodeType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_nodeType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ENodeType)result;
	}

	public virtual bool isReference()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isReference(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isLight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSelfReferential()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isSelfReferential(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void select(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_select(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool Extents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_Extents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool spatiallyIndexed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_spatiallyIndexed__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool spatiallyIndexed(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_spatiallyIndexed__SWIG_1(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSpatiallyIndexed(bool spatiallyIndexed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setSpatiallyIndexed__SWIG_0(swigCPtr, spatiallyIndexed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSpatiallyIndexed(uint nVpId, bool spatiallyIndexed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setSpatiallyIndexed__SWIG_1(swigCPtr, nVpId, spatiallyIndexed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool owned()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_owned__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool owned(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_owned__SWIG_1(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOwned(bool owned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setOwned__SWIG_0(swigCPtr, owned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOwned(uint nVpId, bool owned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setOwned__SWIG_1(swigCPtr, nVpId, owned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool markedByUpdateManager()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markedByUpdateManager(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMarkedByUpdateManager(bool marked)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setMarkedByUpdateManager(swigCPtr, marked);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hasExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d extents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_extents__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasFrozenLayers()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hasFrozenLayers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool markedToSkip(uint mask)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markedToSkip(swigCPtr, mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void markToSkip(uint mask, bool markToSkip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markToSkip(swigCPtr, mask, markToSkip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void markToSkipAll()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markToSkipAll(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint markToSkipMask(uint threadIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markToSkipMask(threadIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool layersChanged(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_layersChanged(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				view = null;
			}
			if (jarg != intPtr)
			{
				view = Helpers.GetRXObject<OdGsViewImpl>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public bool markedAsNonSelectable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markedAsNonSelectable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void markAsNonSelectable(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markAsNonSelectable(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMarkedSkipSelection()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isMarkedSkipSelection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void markSkipSelection(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markSkipSelection(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMarkedErased()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isMarkedErased(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void markErased(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_markErased(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInWorkset()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isInWorkset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInWorkset(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setInWorkset(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isRegenOnDraw()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isRegenOnDraw(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRegenOnDraw(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setRegenOnDraw(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isSingleThreaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isSingleThreaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSingleThreaded(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setSingleThreaded(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool skipDisplayClipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_skipDisplayClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSkipDisplayClipping(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setSkipDisplayClipping(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isXref()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isXref(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void highlight(bool bDoIt, bool bWholeBranch, uint nSelStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_highlight__SWIG_0(swigCPtr, bDoIt, bWholeBranch, nSelStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(bool bDoIt, bool bWholeBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_highlight__SWIG_1(swigCPtr, bDoIt, bWholeBranch);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void hide(bool bDoIt, bool bSelectable, bool bWholeBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hide__SWIG_0(swigCPtr, bDoIt, bSelectable, bWholeBranch);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(bool bDoIt, bool bSelectable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hide__SWIG_1(swigCPtr, bDoIt, bSelectable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hide__SWIG_2(swigCPtr, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setStateBranch(OdGsStateBranch pBr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setStateBranch(swigCPtr, OdGsStateBranch.getCPtr(pBr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetStateBranch(OdGsStateBranch_BranchType branchType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_resetStateBranch__SWIG_0(swigCPtr, (int)branchType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetStateBranch()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_resetStateBranch__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranch stateBranch(OdGsStateBranch_BranchType branchType)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_stateBranch__SWIG_0(swigCPtr, (int)branchType), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch stateBranch()
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_stateBranch__SWIG_1(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasAnyStateBranch()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_hasAnyStateBranch(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void playAsGeometry(OdGsBaseVectorizer view, EMetafilePlayMode eMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_playAsGeometry(swigCPtr, OdGsBaseVectorizer.getCPtr(view), (int)eMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool extents(OdGsView pView, OdGeExtents3d ext)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_extents__SWIG_1(swigCPtr, OdGsView.getCPtr(pView), OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual LineWeight getMaxLineweightUsed()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_getMaxLineweightUsed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void addMaxLineweightUsed(LineWeight lwd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_addMaxLineweightUsed(swigCPtr, (int)lwd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMaxLineweightUsed(LineWeight lwd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setMaxLineweightUsed(swigCPtr, (int)lwd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool entityUnerased()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_entityUnerased(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEntityUnerased(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setEntityUnerased(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInvisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isInvisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtentsOutOfModelSpace()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isExtentsOutOfModelSpace(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExtentsOutOfModelSpace(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setExtentsOutOfModelSpace(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetInvalidVpFlag()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_resetInvalidVpFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAsLightSourceOwner(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_setAsLightSourceOwner(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLightSourceOwner()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isLightSourceOwner(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRequireRegenOnHighlightChange()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_isRequireRegenOnHighlightChange(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void makeStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_makeStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void releaseStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_releaseStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void propagateLayerChangesStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_propagateLayerChangesStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool saveNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_saveNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_saveNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool loadNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_loadNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_loadNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void transformExtents(OdGeExtents3d ext, OdGsStateBranch pTransformBr, bool bInverse)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_transformExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(ext), OdGsStateBranch.getCPtr(pTransformBr), bInverse);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformExtents(OdGeExtents3d ext, OdGsStateBranch pTransformBr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_transformExtents__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(ext), OdGsStateBranch.getCPtr(pTransformBr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformExtents(OdGeExtents3d ext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_transformExtents__SWIG_2(swigCPtr, OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void insertToSpatialIndex(uint nVpId, ref OdSiSpatialIndex parentIndex, OdGeExtents3d prevExtents)
	{
		IntPtr jarg = ((parentIndex == null) ? IntPtr.Zero : OdSiSpatialIndex.getCPtr(parentIndex).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_insertToSpatialIndex(swigCPtr, nVpId, ref jarg, OdGeExtents3d.getCPtr(prevExtents));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				parentIndex = null;
			}
			if (jarg != intPtr)
			{
				parentIndex = Helpers.GetRXObject<OdSiSpatialIndex>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void addContentToUpdateManager(uint viewportId, OdGsUpdateManager pManager, UpdateManagerContext context)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_addContentToUpdateManager(swigCPtr, viewportId, OdGsUpdateManager.getCPtr(pManager), UpdateManagerContext.getCPtr(context));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsEntityNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
