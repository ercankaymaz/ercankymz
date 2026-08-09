using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFileStructure : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcFileStructure_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcFileStructure_1();

	public delegate void SwigDelegateOdPrcFileStructure_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcFileStructure_0 swigDelegate0;

	private SwigDelegateOdPrcFileStructure_1 swigDelegate1;

	private SwigDelegateOdPrcFileStructure_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcFileStructure(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFileStructure obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFileStructure(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcFileStructure cast(OdRxObject pObj)
	{
		OdPrcFileStructure rXObject = Helpers.GetRXObject<OdPrcFileStructure>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_isASwigExplicitOdPrcFileStructure(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_queryXSwigExplicitOdPrcFileStructure(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcFileStructure createObject()
	{
		OdPrcFileStructure rXObject = Helpers.GetRXObject<OdPrcFileStructure>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcFileStructureGeometry fileStructureGeometry()
	{
		OdPrcFileStructureGeometry rXObject = Helpers.GetRXObject<OdPrcFileStructureGeometry>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_fileStructureGeometry__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcFileStructureTessellation fileStructureTessellation()
	{
		OdPrcFileStructureTessellation rXObject = Helpers.GetRXObject<OdPrcFileStructureTessellation>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_fileStructureTessellation__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcFileStructureTree fileStructureTree()
	{
		OdPrcFileStructureTree rXObject = Helpers.GetRXObject<OdPrcFileStructureTree>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_fileStructureTree__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcFileStructureGlobals fileStructureGlobals()
	{
		OdPrcFileStructureGlobals rXObject = Helpers.GetRXObject<OdPrcFileStructureGlobals>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_fileStructureGlobals__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcSchema schema()
	{
		OdPrcSchema rXObject = Helpers.GetRXObject<OdPrcSchema>(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_schema__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcUncompressedFiles uncompressedFiles()
	{
		OdPrcUncompressedFiles result = new OdPrcUncompressedFiles(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_uncompressedFiles__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUniqueId applicationId()
	{
		OdPrcUniqueId result = new OdPrcUniqueId(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_applicationId__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUniqueId fileStructureId()
	{
		OdPrcUniqueId result = new OdPrcUniqueId(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_fileStructureId__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setVersions(uint minimal_version_for_read, uint authoring_version)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_setVersions(swigCPtr, minimal_version_for_read, authoring_version);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint minimalVersionForRead()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_minimalVersionForRead(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint authoringVersion()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_authoringVersion(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addObject(OdPrcReferencedBase object_)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_addObject__SWIG_0(swigCPtr, OdPrcReferencedBase.getCPtr(object_));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addObject(OdPrcReferencedBase object_, uint uid)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_addObject__SWIG_1(swigCPtr, OdPrcReferencedBase.getCPtr(object_), uid);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addObject(OdPrcBody body)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_addObject__SWIG_2(swigCPtr, OdPrcBody.getCPtr(body));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getObjectId(OdDbHandle h)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_getObjectId(swigCPtr, OdDbHandle.getCPtr(h)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setObjectId(OdDbStub stub)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_setObjectId(swigCPtr, OdDbStub.getCPtr(stub));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId objectId()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_objectId(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void writeExtraGeometry(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_writeExtraGeometry(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readExtraGeometry(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_readExtraGeometry(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setfileStructureId(OdPrcUniqueId value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_setfileStructureId(swigCPtr, OdPrcUniqueId.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setuncompressedFiles(OdPrcUncompressedFiles value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_setuncompressedFiles(swigCPtr, OdPrcUncompressedFiles.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		OdPrcModule_GlobalsPINVOKE.OdPrcFileStructure_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcFileStructure));
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
}
