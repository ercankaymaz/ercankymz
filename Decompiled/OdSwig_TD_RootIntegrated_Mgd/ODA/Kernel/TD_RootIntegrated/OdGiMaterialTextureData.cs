using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTextureData : OdRxObject
{
	public class DevDataVariant : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DevDataVariant(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DevDataVariant obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DevDataVariant()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureData_DevDataVariant(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DevDataVariant()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureData_DevDataVariant__SWIG_0(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public DevDataVariant(IntPtr ptr)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureData_DevDataVariant__SWIG_1(ptr), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public DevDataVariant(OdRxObject ptr)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureData_DevDataVariant__SWIG_2(OdRxObject.getCPtr(ptr)), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiMaterialTextureData_DevDataVariant_DevDataVariantType type()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_type(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiMaterialTextureData_DevDataVariant_DevDataVariantType)result;
		}

		public IntPtr getPtr()
		{
			IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_getPtr(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdRxObject getRxObject()
		{
			OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_getRxObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public DevDataVariant Assign(IntPtr ptr)
		{
			DevDataVariant result = new DevDataVariant(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_Assign__SWIG_0(swigCPtr, ptr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public DevDataVariant Assign(OdRxObject ptr)
		{
			DevDataVariant result = new DevDataVariant(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_Assign__SWIG_1(swigCPtr, OdRxObject.getCPtr(ptr)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public DevDataVariant setPtr(IntPtr ptr)
		{
			DevDataVariant result = new DevDataVariant(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_setPtr(swigCPtr, ptr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public DevDataVariant setRxObject(OdRxObject ptr)
		{
			DevDataVariant result = new DevDataVariant(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_setRxObject(swigCPtr, OdRxObject.getCPtr(ptr)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void clear()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_DevDataVariant_clear(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGiMaterialTextureData_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureData_1();

	public delegate void SwigDelegateOdGiMaterialTextureData_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiMaterialTextureData_3(bool arg0);

	public delegate void SwigDelegateOdGiMaterialTextureData_4();

	public delegate void SwigDelegateOdGiMaterialTextureData_5(IntPtr pDeviceInfo, IntPtr image);

	public delegate void SwigDelegateOdGiMaterialTextureData_6(IntPtr data, uint width, uint height);

	public delegate bool SwigDelegateOdGiMaterialTextureData_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialTextureData_0 swigDelegate0;

	private SwigDelegateOdGiMaterialTextureData_1 swigDelegate1;

	private SwigDelegateOdGiMaterialTextureData_2 swigDelegate2;

	private SwigDelegateOdGiMaterialTextureData_3 swigDelegate3;

	private SwigDelegateOdGiMaterialTextureData_4 swigDelegate4;

	private SwigDelegateOdGiMaterialTextureData_5 swigDelegate5;

	private SwigDelegateOdGiMaterialTextureData_6 swigDelegate6;

	private SwigDelegateOdGiMaterialTextureData_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(DevDataVariant),
		typeof(OdGiImageBGRA32)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdGiPixelBGRA32Array),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTextureData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTextureData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTextureData cast(OdRxObject pObj)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_isASwigExplicitOdGiMaterialTextureData(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_queryXSwigExplicitOdGiMaterialTextureData(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialTextureData createObject()
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void textureDataUnlinked(bool arg0)
	{
		if (SwigDerivedClassHasMethod("textureDataUnlinked", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_textureDataUnlinkedSwigExplicitOdGiMaterialTextureData__SWIG_0(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_textureDataUnlinked__SWIG_0(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void textureDataUnlinked()
	{
		if (SwigDerivedClassHasMethod("textureDataUnlinked", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_textureDataUnlinkedSwigExplicitOdGiMaterialTextureData__SWIG_1(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_textureDataUnlinked__SWIG_1(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextureData(DevDataVariant pDeviceInfo, OdGiImageBGRA32 image)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_setTextureData(swigCPtr, DevDataVariant.getCPtr(pDeviceInfo), OdGiImageBGRA32.getCPtr(image));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void textureData(OdGiPixelBGRA32Array data, out uint width, out uint height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_textureData(swigCPtr, OdGiPixelBGRA32Array.getCPtr(data), out width, out height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_haveData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiMaterialTextureData createDefaultTextureDataImplementation()
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_createDefaultTextureDataImplementation(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass defaultTextureDataImplementationDesc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_defaultTextureDataImplementationDesc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTextureData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialTextureData) != GetType();
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
		if (SwigDerivedClassHasMethod("textureDataUnlinked", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtextureDataUnlinked__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("textureDataUnlinked", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtextureDataUnlinked__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setTextureData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetTextureData;
		}
		if (SwigDerivedClassHasMethod("textureData", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtextureData;
		}
		if (SwigDerivedClassHasMethod("haveData", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhaveData;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialTextureData));
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtextureDataUnlinked__SWIG_0(bool arg0)
	{
		try
		{
			textureDataUnlinked(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtextureDataUnlinked__SWIG_1()
	{
		try
		{
			textureDataUnlinked();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTextureData(IntPtr pDeviceInfo, IntPtr image)
	{
		try
		{
			setTextureData(new DevDataVariant(pDeviceInfo, cMemoryOwn: true), new OdGiImageBGRA32(image, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodtextureData(IntPtr data, uint width, uint height)
	{
		try
		{
			textureData(new OdGiPixelBGRA32Array(data, cMemoryOwn: false), out width, out height);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodhaveData()
	{
		return haveData();
	}
}
