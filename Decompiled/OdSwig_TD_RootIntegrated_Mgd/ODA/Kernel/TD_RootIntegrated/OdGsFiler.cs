using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFiler : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFiler obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsFiler cast(OdRxObject pObj)
	{
		OdGsFiler rXObject = Helpers.GetRXObject<OdGsFiler>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsFiler createObject()
	{
		OdGsFiler rXObject = Helpers.GetRXObject<OdGsFiler>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint version()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_version(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVersion(uint nVersion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_setVersion(swigCPtr, nVersion);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsFiler_FilerType filerType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_filerType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFiler_FilerType)result;
	}

	public virtual bool hasExtension(OdGsFilerExtension_Type arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_hasExtension(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsFilerExtension getExtension(OdGsFilerExtension_Type arg0)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_getExtension(swigCPtr, (int)arg0);
		OdGsFilerExtension result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtension(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool installExtension(OdGsFilerExtension arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_installExtension(swigCPtr, OdGsFilerExtension.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool uninstallExtension(OdGsFilerExtension_Type arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_uninstallExtension(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrHandle(OdDbStub pHandle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrHandle(swigCPtr, OdDbStub.getCPtr(pHandle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub rdHandle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdHandle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrClass(OdRxObject pObj)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrClass(swigCPtr, OdRxObject.getCPtr(pObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject rdClass()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdClass(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void wrRawData(IntPtr pData, uint nDataSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrRawData(swigCPtr, pData, nDataSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdRawData(IntPtr pData, uint nDataSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdRawData(swigCPtr, pData, nDataSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrBool(bool bVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrBool(swigCPtr, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool rdBool()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdBool(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrInt(int val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrInt(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int rdInt()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdInt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt(uint val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint rdUInt()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrChar(char val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrChar(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual char rdChar()
	{
		char result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdChar(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt8(byte val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt8(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte rdUInt8()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt8(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrInt16(short val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrInt16(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short rdInt16()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdInt16(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt16(ushort val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt16(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort rdUInt16()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt16(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrInt32(int val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrInt32(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int rdInt32()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdInt32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt32(uint val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt32(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint rdUInt32()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrInt64(long val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrInt64(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual long rdInt64()
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt64(ulong val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt64(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong rdUInt64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrIntPtr(IntPtr val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrIntPtr(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual IntPtr rdIntPtr()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdIntPtr(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void wrPtr(IntPtr pPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrPtr(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr rdPtr()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdPtr(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrCOLORREF(uint val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrCOLORREF(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint rdCOLORREF()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdCOLORREF(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrFloat(float val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrFloat(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual float rdFloat()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdFloat(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrDouble(double val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrDouble(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double rdDouble()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdDouble(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrPoint2d(OdGePoint2d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrPoint2d(swigCPtr, OdGePoint2d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdPoint2d(OdGePoint2d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdPoint2d(swigCPtr, OdGePoint2d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector2d(OdGeVector2d vec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrVector2d(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdVector2d(OdGeVector2d vec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdVector2d(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint3d(OdGePoint3d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrPoint3d(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdPoint3d(OdGePoint3d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdPoint3d(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrVector3d(OdGeVector3d vec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrVector3d(swigCPtr, OdGeVector3d.getCPtr(vec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdVector3d(OdGeVector3d vec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdVector3d(swigCPtr, OdGeVector3d.getCPtr(vec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrMatrix3d(OdGeMatrix3d mat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrMatrix3d(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdMatrix3d(OdGeMatrix3d mat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdMatrix3d(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrExtents3d(OdGeExtents3d ext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrExtents3d(swigCPtr, OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdExtents3d(OdGeExtents3d ext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdExtents3d(swigCPtr, OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrAnsiString(string str)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrAnsiString(swigCPtr, str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdAnsiString(ref string str)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(str);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdAnsiString(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				str = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public string rdAnsiStringRet()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdAnsiStringRet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrString(string str)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrString(swigCPtr, str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdString(ref string str)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(str);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdString(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				str = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public string rdStringRet()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdStringRet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrUInt8Array(OdUInt8Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt8Array(swigCPtr, OdUInt8Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt16Array(OdUInt16Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt16Array(swigCPtr, OdUInt16Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt32Array(OdUInt32Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt32Array(swigCPtr, OdUInt32Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrUInt64Array(OdUInt64Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrUInt64Array(swigCPtr, OdUInt64Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrIntArray(OdIntArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrIntArray(swigCPtr, OdIntArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrFloatArray(OdFloatArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrFloatArray(swigCPtr, OdFloatArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint2dArray(OdGePoint2dArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrPoint2dArray(swigCPtr, OdGePoint2dArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrPoint3dArray(OdGePoint3dArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrPoint3dArray(swigCPtr, OdGePoint3dArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrDbStubPtrArray(OdDbStubPtrArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrDbStubPtrArray(swigCPtr, OdDbStubPtrArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrGsDCRect(OdGsDCRect rc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrGsDCRect(swigCPtr, OdGsDCRect.getCPtr(rc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrGsDCRectDouble(OdGsDCRectDouble rcd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_wrGsDCRectDouble(swigCPtr, OdGsDCRectDouble.getCPtr(rcd));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdUInt8Array(OdUInt8Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt8Array(swigCPtr, OdUInt8Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdUInt16Array(OdUInt16Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt16Array(swigCPtr, OdUInt16Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdUInt32Array(OdUInt32Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt32Array(swigCPtr, OdUInt32Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdUInt64Array(OdUInt64Array arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdUInt64Array(swigCPtr, OdUInt64Array.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdIntArray(OdIntArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdIntArray(swigCPtr, OdIntArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdFloatArray(OdFloatArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdFloatArray(swigCPtr, OdFloatArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdPoint2dArray(OdGePoint2dArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdPoint2dArray(swigCPtr, OdGePoint2dArray.getCPtr(arr).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdPoint3dArray(OdGePoint3dArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdPoint3dArray(swigCPtr, OdGePoint3dArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdDbStubPtrArray(OdDbStubPtrArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdDbStubPtrArray(swigCPtr, OdDbStubPtrArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdGsDCRect(OdGsDCRect dcrc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdGsDCRect(swigCPtr, OdGsDCRect.getCPtr(dcrc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rdGsDCRectDouble(OdGsDCRectDouble dcrcd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_rdGsDCRectDouble(swigCPtr, OdGsDCRectDouble.getCPtr(dcrcd));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFiler_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
