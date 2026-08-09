using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFile : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcFile_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcFile_1();

	public delegate void SwigDelegateOdPrcFile_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcFile_3([MarshalAs(UnmanagedType.LPWStr)] string file, IntPtr pAuditInfo);

	public delegate void SwigDelegateOdPrcFile_4([MarshalAs(UnmanagedType.LPWStr)] string file);

	public delegate void SwigDelegateOdPrcFile_5(IntPtr pStream, IntPtr pAuditInfo);

	public delegate void SwigDelegateOdPrcFile_6(IntPtr pStream);

	public delegate void SwigDelegateOdPrcFile_7(IntPtr pGsNode);

	public delegate IntPtr SwigDelegateOdPrcFile_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcFile_0 swigDelegate0;

	private SwigDelegateOdPrcFile_1 swigDelegate1;

	private SwigDelegateOdPrcFile_2 swigDelegate2;

	private SwigDelegateOdPrcFile_3 swigDelegate3;

	private SwigDelegateOdPrcFile_4 swigDelegate4;

	private SwigDelegateOdPrcFile_5 swigDelegate5;

	private SwigDelegateOdPrcFile_6 swigDelegate6;

	private SwigDelegateOdPrcFile_7 swigDelegate7;

	private SwigDelegateOdPrcFile_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdPrcAuditInfo)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdPrcAuditInfo)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGsCache) };

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcFile(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcFile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFile obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcFile()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFile(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcFile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcFile cast(OdRxObject pObj)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcFile_isASwigExplicitOdPrcFile(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFile_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcFile_queryXSwigExplicitOdPrcFile(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcFile_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcFile createObject()
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcModelFileData modelFileData()
	{
		OdPrcModelFileData rXObject = Helpers.GetRXObject<OdPrcModelFileData>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_modelFileData__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcSchema schema()
	{
		OdPrcSchema rXObject = Helpers.GetRXObject<OdPrcSchema>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_schema__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcFileStructurePtrArray fileStructures()
	{
		OdPrcFileStructurePtrArray result = Helpers.GetObject<OdPrcFileStructurePtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_fileStructures__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUncompressedFiles uncompressedFiles()
	{
		OdPrcUncompressedFiles result = new OdPrcUncompressedFiles(OdPrcModule_GlobalsPINVOKE.OdPrcFile_uncompressedFiles__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUniqueId applicationId()
	{
		OdPrcUniqueId result = new OdPrcUniqueId(OdPrcModule_GlobalsPINVOKE.OdPrcFile_applicationId__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUniqueId fileStructureId()
	{
		OdPrcUniqueId result = new OdPrcUniqueId(OdPrcModule_GlobalsPINVOKE.OdPrcFile_fileStructureId__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setVersions(uint minimal_version_for_read, uint authoring_version)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_setVersions(swigCPtr, minimal_version_for_read, authoring_version);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint minimalVersionForRead()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_minimalVersionForRead(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint authoringVersion()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_authoringVersion(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcFileStructure findFileStructureByUID(OdPrcUniqueId uuid)
	{
		OdPrcFileStructure rXObject = Helpers.GetRXObject<OdPrcFileStructure>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_findFileStructureByUID(swigCPtr, OdPrcUniqueId.getCPtr(uuid)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void decompressCompressedBreps(OdPrcFile pFile)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_decompressCompressedBreps(getCPtr(pFile));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readFile(string file, OdPrcAuditInfo pAuditInfo)
	{
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFileSwigExplicitOdPrcFile__SWIG_0(swigCPtr, file, OdPrcAuditInfo.getCPtr(pAuditInfo));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFile__SWIG_0(swigCPtr, file, OdPrcAuditInfo.getCPtr(pAuditInfo));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readFile(string file)
	{
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFileSwigExplicitOdPrcFile__SWIG_1(swigCPtr, file);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFile__SWIG_1(swigCPtr, file);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readFile(OdStreamBuf pStream, OdPrcAuditInfo pAuditInfo)
	{
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes5))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFileSwigExplicitOdPrcFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStream), OdPrcAuditInfo.getCPtr(pAuditInfo));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStream), OdPrcAuditInfo.getCPtr(pAuditInfo));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readFile(OdStreamBuf pStream)
	{
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes6))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFileSwigExplicitOdPrcFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_readFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void compressFile(OdPrcFileSettings settings)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_compressFile(swigCPtr, OdPrcFileSettings.getCPtr(settings));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(OdStreamBuf pStream, OdPrcFileSettings pSettings)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_writeFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStream), OdPrcFileSettings.getCPtr(pSettings));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(OdStreamBuf pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_writeFile__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addFileStructure(ref OdPrcFileStructure fileStructure)
	{
		IntPtr jarg = ((fileStructure == null) ? IntPtr.Zero : OdPrcFileStructure.getCPtr(fileStructure).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_addFileStructure(swigCPtr, ref jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileStructure = null;
			}
			if (jarg != intPtr)
			{
				fileStructure = Helpers.GetRXObject<OdPrcFileStructure>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdPrcHostAppServices getAppServices()
	{
		OdPrcHostAppServices rXObject = Helpers.GetRXObject<OdPrcHostAppServices>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getAppServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setAppServices(OdPrcHostAppServices svcs)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_setAppServices(swigCPtr, OdPrcHostAppServices.getCPtr(svcs));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initialize(bool isDef)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_initialize(swigCPtr, isDef);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setActiveView(OdGsView pActiveView)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_setActiveView(swigCPtr, OdGsView.getCPtr(pActiveView));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsView getActiveView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getActiveView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcUnitsFormatter formatter()
	{
		OdPrcUnitsFormatter rXObject = Helpers.GetRXObject<OdPrcUnitsFormatter>(OdPrcModule_GlobalsPINVOKE.OdPrcFile_formatter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setGsNode(OdGsCache pGsNode)
	{
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes7))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_setGsNodeSwigExplicitOdPrcFile(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_setGsNode(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsCache gsNode()
	{
		OdGsCache rXObject = Helpers.GetRXObject<OdGsCache>(SwigDerivedClassHasMethod("gsNode", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcFile_gsNodeSwigExplicitOdPrcFile(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFile_gsNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint getNumberOfIsolines()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_getNumberOfIsolines(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumberOfIsolines(uint numIsolines)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_setNumberOfIsolines(swigCPtr, numIsolines);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getFilename()
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_getFilename(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcObjectId getCurrentViewId()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getCurrentViewId(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdArray_OdPrcViewNode_OdObjectsAllocator getViewNodes(bool bUpdate)
	{
		OdArray_OdPrcViewNode_OdObjectsAllocator result = new OdArray_OdPrcViewNode_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getViewNodes__SWIG_0(swigCPtr, bUpdate), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdArray_OdPrcViewNode_OdObjectsAllocator getViewNodes()
	{
		OdArray_OdPrcViewNode_OdObjectsAllocator result = new OdArray_OdPrcViewNode_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getViewNodes__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setViewNode(int nViewNodeIndex)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_setViewNode(swigCPtr, nViewNodeIndex);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setDefaultViewNode()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_setDefaultViewNode(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getCurrentViewNode()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_getCurrentViewNode(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcObjectId getObjectId(OdDbHandle h)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcFile_getObjectId(swigCPtr, OdDbHandle.getCPtr(h)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool applyCurrentView()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_applyCurrentView(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUnit unit()
	{
		OdPrcUnit result = new OdPrcUnit(OdPrcModule_GlobalsPINVOKE.OdPrcFile_unit(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void decompressCompressed3dTess(OdPrcFile pFile, Decompress3dTessParams params_)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_decompressCompressed3dTess(getCPtr(pFile), Decompress3dTessParams.getCPtr(params_));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void compress3dTess(OdPrcFile pFile)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_compress3dTess(getCPtr(pFile));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void updateFileStructuresReferences(ref OdPrcFile file)
	{
		IntPtr jarg = ((file == null) ? IntPtr.Zero : getCPtr(file).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFile_updateFileStructuresReferences(ref jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				file = null;
			}
			if (jarg != intPtr)
			{
				file = Helpers.GetRXObject<OdPrcFile>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFile_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setfileStructureId(OdPrcUniqueId value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_setfileStructureId(swigCPtr, OdPrcUniqueId.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addFileStructurePtr(OdPrcFileStructure value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_addFileStructurePtr(swigCPtr, OdPrcFileStructure.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
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
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodreadFile__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodreadFile__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodreadFile__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("readFile", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodreadFile__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetGsNode;
		}
		if (SwigDerivedClassHasMethod("gsNode", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgsNode;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcFile_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcFile));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodreadFile__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string file, IntPtr pAuditInfo)
	{
		try
		{
			readFile(file, Helpers.GetRXObject<OdPrcAuditInfo>(pAuditInfo, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodreadFile__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string file)
	{
		try
		{
			readFile(file);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodreadFile__SWIG_2(IntPtr pStream, IntPtr pAuditInfo)
	{
		try
		{
			readFile(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdPrcAuditInfo>(pAuditInfo, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodreadFile__SWIG_3(IntPtr pStream)
	{
		try
		{
			readFile(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: true, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGsNode(IntPtr pGsNode)
	{
		try
		{
			setGsNode(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgsNode()
	{
		return OdGsCache.getCPtr(gsNode()).Handle;
	}
}
