using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCompressedFilerDumper : OdPrcCompressedFiler
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCompressedFilerDumper(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCompressedFilerDumper obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCompressedFilerDumper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcCompressedFilerDumper cast(OdRxObject pObj)
	{
		OdPrcCompressedFilerDumper rXObject = Helpers.GetRXObject<OdPrcCompressedFilerDumper>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcCompressedFilerDumper createObject()
	{
		OdPrcCompressedFilerDumper rXObject = Helpers.GetRXObject<OdPrcCompressedFilerDumper>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override ulong tell()
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_tell(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong length()
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_length(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_seek(swigCPtr, offset, (int)seekType);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFiler(OdPrcCompressedFiler pFiler)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_setFiler(swigCPtr, OdPrcCompressedFiler.getCPtr(pFiler));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCompressedFiler getFiler()
	{
		OdPrcCompressedFiler rXObject = Helpers.GetRXObject<OdPrcCompressedFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_getFiler(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void savePosition()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_savePosition(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void restorePosition()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_restorePosition(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeBits(uint numBits, byte pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeBits__SWIG_0(swigCPtr, numBits, pBuf);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readBits(uint numBits, out byte pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readBits__SWIG_0(swigCPtr, numBits, out pBuf);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeBits(uint numBits, byte[] pBuf)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeBits__SWIG_1(swigCPtr, numBits, Helpers.MarshalbyteFixedArray(pBuf));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeUnsignedIntegerWithVariableBitNumber(uint bit_number, uint value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeUnsignedIntegerWithVariableBitNumber(swigCPtr, bit_number, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint readUnsignedIntegerWithVariableBitNumber(uint num_of_bits)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readUnsignedIntegerWithVariableBitNumber(swigCPtr, num_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeNumberOfBitsThenUnsignedInteger(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeNumberOfBitsThenUnsignedInteger(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint readNumberOfBitsThenUnsignedInteger()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readNumberOfBitsThenUnsignedInteger(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeUnsignedInteger(uint i, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeUnsignedInteger__SWIG_0(swigCPtr, i, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeUnsignedInteger(uint i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeUnsignedInteger__SWIG_1(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint readUnsignedInteger(string pName)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readUnsignedInteger__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint readUnsignedInteger()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readUnsignedInteger__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeInteger(int i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeInteger(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override int readInteger()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readInteger(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeDouble(double i, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeDouble__SWIG_0(swigCPtr, i, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeDouble(double i)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeDouble__SWIG_1(swigCPtr, i);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double readDouble(string pName)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readDouble__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double readDouble()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readDouble__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeString(string str, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeString__SWIG_0(swigCPtr, str, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeString(string str)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeString__SWIG_1(swigCPtr, str);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string readString(string pName)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readString__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string readString()
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readString__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeBoolean(bool value, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeBoolean__SWIG_0(swigCPtr, value, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeBoolean(bool value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeBoolean__SWIG_1(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool readBoolean(string pName)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readBoolean__SWIG_0(swigCPtr, pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool readBoolean()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readBoolean__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeVector2d(OdGeVector2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeVector2d(swigCPtr, OdGeVector2d.getCPtr(value).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d readVector2d()
	{
		OdGeVector2d result = new OdGeVector2d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readVector2d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeVector3d(OdGeVector3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeVector3d(swigCPtr, OdGeVector3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector3d readVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readVector3d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writePoint2d(OdGePoint2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writePoint2d(swigCPtr, OdGePoint2d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint2d readPoint2d()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readPoint2d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writePoint3d(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writePoint3d(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint3d readPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readPoint3d(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeCharacter(char value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCharacter(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override char readCharacter()
	{
		char result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCharacter(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint readEntityType(bool bStepBack)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readEntityType__SWIG_0(swigCPtr, bStepBack);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint readEntityType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readEntityType__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeEntityType(uint type)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeEntityType(swigCPtr, type);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint readCompressedEntityType(bool bStepBack, bool isCurveOrSurface)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCompressedEntityType__SWIG_0(swigCPtr, bStepBack, isCurveOrSurface);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint readCompressedEntityType(bool bStepBack)
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCompressedEntityType__SWIG_1(swigCPtr, bStepBack);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeCompressedEntityType(bool isCurveType, uint type)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCompressedEntityType(swigCPtr, isCurveType, type);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double readDoubleWithVariableBitNumber(double tolerance, uint number_of_bits)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readDoubleWithVariableBitNumber(swigCPtr, tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writeDoubleWithVariableBitNumber(double value, double tolerance, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeDoubleWithVariableBitNumber(swigCPtr, value, tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint3d readPoint3DWithVariableBitNumber(double tolerance, uint number_of_bits)
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readPoint3DWithVariableBitNumber(swigCPtr, tolerance, number_of_bits), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void writePoint3DWithVariableBitNumber(OdGePoint3d point, double tolerance, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writePoint3DWithVariableBitNumber(swigCPtr, OdGePoint3d.getCPtr(point), tolerance, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readCompressedIntegerArray(OdInt32Array points_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCompressedIntegerArray(swigCPtr, OdInt32Array.getCPtr(points_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readCharacterArray(OdInt8Array character_array, uint number_of_bits, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCharacterArray__SWIG_0(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readCharacterArray(OdInt8Array character_array, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCharacterArray__SWIG_1(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override int readIntegerWithVariableBitNumber(uint bit_number)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readIntegerWithVariableBitNumber(swigCPtr, bit_number);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void readShortArray(OdUInt16Array normal_angle_array, uint number_of_bit)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readShortArray(swigCPtr, OdUInt16Array.getCPtr(normal_angle_array).Handle, number_of_bit);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readCompressedIndiceArray(OdInt32Array integer_array, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCompressedIndiceArray__SWIG_0(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void readCompressedIndiceArray(OdInt32Array integer_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_readCompressedIndiceArray__SWIG_1(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeCompressedIntegerArray(OdInt32Array points_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCompressedIntegerArray(swigCPtr, OdInt32Array.getCPtr(points_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeCharacterArray(OdInt8Array character_array, uint number_of_bits, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCharacterArray__SWIG_0(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeCharacterArray(OdInt8Array character_array, uint number_of_bits)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCharacterArray__SWIG_1(swigCPtr, OdInt8Array.getCPtr(character_array).Handle, number_of_bits);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeIntegerWithVariableBitNumber(int value, uint bit_number)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeIntegerWithVariableBitNumber(swigCPtr, value, bit_number);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeShortArray(OdUInt16Array normal_angle_array, uint number_of_bit)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeShortArray(swigCPtr, OdUInt16Array.getCPtr(normal_angle_array).Handle, number_of_bit);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeCompressedIndiceArray(OdInt32Array integer_array, OdPrcCompressedFiler_CompressedBitStrategy bReadCompressStrategy)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCompressedIndiceArray__SWIG_0(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle, (int)bReadCompressStrategy);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeCompressedIndiceArray(OdInt32Array integer_array)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_writeCompressedIndiceArray__SWIG_1(swigCPtr, OdInt32Array.getCPtr(integer_array).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCompressedFilerDumper_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
