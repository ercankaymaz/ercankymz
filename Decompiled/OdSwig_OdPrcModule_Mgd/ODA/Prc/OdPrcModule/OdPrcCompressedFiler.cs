using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCompressedFiler : OdPrcFiler
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCompressedFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCompressedFiler obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCompressedFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcCompressedFiler cast(OdRxObject pObj)
	{
		OdPrcCompressedFiler rXObject = Helpers.GetRXObject<OdPrcCompressedFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcCompressedFiler createObject()
	{
		OdPrcCompressedFiler rXObject = Helpers.GetRXObject<OdPrcCompressedFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void savePosition()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_savePosition(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void restorePosition()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_restorePosition(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeBits(uint numBits, byte pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeBits__SWIG_0(swigCPtr, numBits, pBuf);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeBits(uint numBits, byte[] pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeBits__SWIG_1(swigCPtr, numBits, Helpers.MarshalbyteFixedArray(pBuf));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readBits(uint numBits, out byte pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readBits__SWIG_0(swigCPtr, numBits, out pBuf);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeUnsignedIntegerWithVariableBitNumber(uint bit_number, uint value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeUnsignedIntegerWithVariableBitNumber(swigCPtr, bit_number, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint readUnsignedIntegerWithVariableBitNumber(uint num_of_bits)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readUnsignedIntegerWithVariableBitNumber(swigCPtr, num_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeNumberOfBitsThenUnsignedInteger(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeNumberOfBitsThenUnsignedInteger(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint readNumberOfBitsThenUnsignedInteger()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readNumberOfBitsThenUnsignedInteger(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeUnsignedInteger(uint i, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeUnsignedInteger__SWIG_0(swigCPtr, i, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeUnsignedInteger(uint i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeUnsignedInteger__SWIG_1(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint readUnsignedInteger(string pName)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readUnsignedInteger__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint readUnsignedInteger()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readUnsignedInteger__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeInteger(int i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeInteger(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int readInteger()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readInteger(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeDouble(double i, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeDouble__SWIG_0(swigCPtr, i, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeDouble(double i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeDouble__SWIG_1(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double readDouble(string pName)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readDouble__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double readDouble()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readDouble__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeString(string str, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeString__SWIG_0(swigCPtr, str, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeString(string str)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeString__SWIG_1(swigCPtr, str);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string readString(string pName)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readString__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string readString()
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readString__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeBoolean(bool value, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeBoolean__SWIG_0(swigCPtr, value, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeBoolean(bool value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeBoolean__SWIG_1(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool readBoolean(string pName)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readBoolean__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool readBoolean()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readBoolean__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeVector2d(OdGeVector2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeVector2d(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector2d readVector2d()
	{
		OdGeVector2d result = new OdGeVector2d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readVector2d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeVector3d(OdGeVector3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeVector3d(swigCPtr, OdGeVector3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d readVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readVector3d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writePoint2d(OdGePoint2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writePoint2d(swigCPtr, OdGePoint2d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint2d readPoint2d()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readPoint2d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writePoint3d(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writePoint3d(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d readPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readPoint3d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeCharacter(char value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCharacter(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual char readCharacter()
	{
		char result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCharacter(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint readEntityType(bool bStepBack)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readEntityType__SWIG_0(swigCPtr, bStepBack);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint readEntityType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readEntityType__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeEntityType(uint type)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeEntityType(swigCPtr, type);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint readCompressedEntityType(bool bStepBack, bool isCurveOrSurface)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCompressedEntityType__SWIG_0(swigCPtr, bStepBack, isCurveOrSurface);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint readCompressedEntityType(bool bStepBack)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCompressedEntityType__SWIG_1(swigCPtr, bStepBack);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeCompressedEntityType(bool isCurveType, uint type)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCompressedEntityType(swigCPtr, isCurveType, type);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double readDoubleWithVariableBitNumber(double tolerance, uint number_of_bits)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readDoubleWithVariableBitNumber(swigCPtr, tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writeDoubleWithVariableBitNumber(double value, double tolerance, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeDoubleWithVariableBitNumber(swigCPtr, value, tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d readPoint3DWithVariableBitNumber(double tolerance, uint number_of_bits)
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readPoint3DWithVariableBitNumber(swigCPtr, tolerance, number_of_bits), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void writePoint3DWithVariableBitNumber(OdGePoint3d point, double tolerance, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writePoint3DWithVariableBitNumber(swigCPtr, OdGePoint3d.getCPtr(point), tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readCompressedIntegerArray(OdInt32Array points_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCompressedIntegerArray(swigCPtr, OdInt32Array.getCPtr(points_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readCharacterArray(OdInt8Array character_array, uint number_of_bits, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCharacterArray__SWIG_0(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readCharacterArray(OdInt8Array character_array, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCharacterArray__SWIG_1(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int readIntegerWithVariableBitNumber(uint bit_number)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readIntegerWithVariableBitNumber(swigCPtr, bit_number);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void readShortArray(OdUInt16Array normal_angle_array, uint number_of_bit)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readShortArray(swigCPtr, OdUInt16Array.getCPtr(normal_angle_array).Handle, number_of_bit);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readCompressedIndiceArray(OdInt32Array integer_array, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCompressedIndiceArray__SWIG_0(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void readCompressedIndiceArray(OdInt32Array integer_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_readCompressedIndiceArray__SWIG_1(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeCompressedIntegerArray(OdInt32Array points_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCompressedIntegerArray(swigCPtr, OdInt32Array.getCPtr(points_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeCharacterArray(OdInt8Array character_array, uint number_of_bits, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCharacterArray__SWIG_0(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeCharacterArray(OdInt8Array character_array, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCharacterArray__SWIG_1(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeIntegerWithVariableBitNumber(int value, uint bit_number)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeIntegerWithVariableBitNumber(swigCPtr, value, bit_number);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeShortArray(OdUInt16Array normal_angle_array, uint number_of_bit)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeShortArray(swigCPtr, OdUInt16Array.getCPtr(normal_angle_array).Handle, number_of_bit);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeCompressedIndiceArray(OdInt32Array integer_array, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCompressedIndiceArray__SWIG_0(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void writeCompressedIndiceArray(OdInt32Array integer_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_writeCompressedIndiceArray__SWIG_1(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFiler_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
