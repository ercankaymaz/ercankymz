using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdShxFont : OdFont
{
	public class CharLoc : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public int m_FileLoc
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_CharLoc_m_FileLoc_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_CharLoc_m_FileLoc_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ushort m_ShapeNo
		{
			get
			{
				ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_CharLoc_m_ShapeNo_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_CharLoc_m_ShapeNo_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CharLoc(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(CharLoc obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~CharLoc()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdShxFont_CharLoc(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public CharLoc()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdShxFont_CharLoc(), cMemoryOwn: true)
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
	public OdShxFont(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdShxFont obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdShxFont(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdShxFont cast(OdRxObject pObj)
	{
		OdShxFont rXObject = Helpers.GetRXObject<OdShxFont>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdShxFont createObject()
	{
		OdShxFont rXObject = Helpers.GetRXObject<OdShxFont>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public byte getBfWidth()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getBfWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte getBfHeight()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getBfHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double getAbove()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getAbove(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double getBelow()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getBelow(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdResult initialize(OdStreamBuf io)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_initialize(swigCPtr, OdStreamBuf.getCPtr(io));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdResult drawCharacter(char character, OdGePoint2d advance, OdGiCommonDraw pWd, OdTextProperties textFlags)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_drawCharacter__SWIG_0(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGiCommonDraw.getCPtr(pWd), OdTextProperties.getCPtr(textFlags));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual OdResult drawCharacter(char character, OdGePoint2d advance, OdGiConveyorGeometry pGeom, OdTextProperties textFlags)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_drawCharacter__SWIG_1(swigCPtr, character, OdGePoint2d.getCPtr(advance), pGeom.GetInterfaceCPtr(), OdTextProperties.getCPtr(textFlags));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string shapeNameByIndex(ushort index)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_shapeNameByIndex(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort shapeIndexByName(string name)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_shapeIndexByName(swigCPtr, name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint getAvailableChars(OdCharArray retArray)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getAvailableChars(swigCPtr, OdCharArray.getCPtr(retArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool hasCharacter(char character)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_hasCharacter(swigCPtr, character);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdShxFont createFont(OdStreamBuf io)
	{
		OdShxFont rXObject = Helpers.GetRXObject<OdShxFont>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_createFont(OdStreamBuf.getCPtr(io)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult loadFromInitFile(OdStreamBuf io, int numEntries, int dataSize, int above, int below, int modes, int subType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_loadFromInitFile(swigCPtr, OdStreamBuf.getCPtr(io), numEntries, dataSize, above, below, modes, subType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void setMainShxFont(OdShxFont font)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_setMainShxFont(swigCPtr, getCPtr(font));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdShxFont getMainShxFont()
	{
		OdShxFont rXObject = Helpers.GetRXObject<OdShxFont>(TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getMainShxFont(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void getScore(char character, OdGePoint2d advance, OdGePoint3d pointsOver, OdGePoint3d pointsUnder, OdTextProperties textFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getScore(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGePoint3d.getCPtr(pointsOver), OdGePoint3d.getCPtr(pointsUnder), OdTextProperties.getCPtr(textFlags));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool supportsVerticalMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_supportsVerticalMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFileName(string fileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_setFileName(swigCPtr, fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual string getFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void getDescriptor(OdTtfDescriptor descr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getDescriptor(swigCPtr, OdTtfDescriptor.getCPtr(descr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult drawCharacterImp(char character, OdGePoint2d advance, OdGiCommonDraw pWd, OdTextProperties textFlags, OdShxTextData pOdShxTextData)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_drawCharacterImp__SWIG_0(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGiCommonDraw.getCPtr(pWd), OdTextProperties.getCPtr(textFlags), OdShxTextData.getCPtr(pOdShxTextData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult drawCharacterImp(char character, OdGePoint2d advance, OdGiConveyorGeometry pGeom, OdTextProperties textFlags, OdShxTextData pOdShxTextData)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_drawCharacterImp__SWIG_1(swigCPtr, character, OdGePoint2d.getCPtr(advance), pGeom.GetInterfaceCPtr(), OdTextProperties.getCPtr(textFlags), OdShxTextData.getCPtr(pOdShxTextData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdShxFont_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
