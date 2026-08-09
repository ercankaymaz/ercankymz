using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPalette : OdRxObject
{
	public class Addressation : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public int m_nSrcFrom
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nSrcFrom_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nSrcFrom_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public int m_nDstTo
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nDstTo_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nDstTo_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public int m_nNumColors
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nNumColors_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_m_nNumColors_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Addressation(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Addressation obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Addressation()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPalette_Addressation(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Addressation(int nFrom, int nTo, int nNum)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPalette_Addressation__SWIG_0(nFrom, nTo, nNum), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public Addressation(int nFrom, int nTo)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPalette_Addressation__SWIG_1(nFrom, nTo), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public Addressation(int nFrom)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPalette_Addressation__SWIG_2(nFrom), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public Addressation()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPalette_Addressation__SWIG_3(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool validate()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_validate(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool fullRange()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Addressation_fullRange(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPalette(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPalette obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPalette()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPalette(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGiPalette createDynamic()
	{
		OdGiPalette rXObject = Helpers.GetRXObject<OdGiPalette>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_createDynamic(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiPalette Assign(OdGiPalette obj)
	{
		OdGiPalette rXObject = Helpers.GetRXObject<OdGiPalette>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_Assign(swigCPtr, getCPtr(obj)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiPalette cloneIfNeed()
	{
		OdGiPalette rXObject = Helpers.GetRXObject<OdGiPalette>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_cloneIfNeed(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint color(int nColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_color(swigCPtr, nColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool entryActivity(int nColor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_entryActivity(swigCPtr, nColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(int nColor, uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_setColor(swigCPtr, nColor, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEntryActivity(int nColor, bool bActivity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_setEntryActivity(swigCPtr, nColor, bActivity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint[] asArray()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_asArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public OdGiColorCube colorCube()
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_colorCube(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setColorCube(OdGiColorCube pColorCube)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_setColorCube(swigCPtr, OdGiColorCube.getCPtr(pColorCube));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetColorCube()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_resetColorCube(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiGrayRamp grayRamp()
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_grayRamp(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setGrayRamp(OdGiGrayRamp pGrayRamp)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_setGrayRamp(swigCPtr, OdGiGrayRamp.getCPtr(pGrayRamp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetGrayRamp()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_resetGrayRamp(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool install(OdGiColorCube pColorCube, bool bForceUpdate)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_0(swigCPtr, OdGiColorCube.getCPtr(pColorCube), bForceUpdate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiColorCube pColorCube)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_1(swigCPtr, OdGiColorCube.getCPtr(pColorCube));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiGrayRamp pGrayRamp, bool bForceUpdate)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_2(swigCPtr, OdGiGrayRamp.getCPtr(pGrayRamp), bForceUpdate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiGrayRamp pGrayRamp)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_3(swigCPtr, OdGiGrayRamp.getCPtr(pGrayRamp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiPalette pPalette, bool bForceUpdate, Addressation address)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_4(swigCPtr, getCPtr(pPalette), bForceUpdate, Addressation.getCPtr(address));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiPalette pPalette, bool bForceUpdate)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_5(swigCPtr, getCPtr(pPalette), bForceUpdate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(OdGiPalette pPalette)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_6(swigCPtr, getCPtr(pPalette));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(uint[] pColors, bool bForceUpdate, Addressation address)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_7(swigCPtr, pColors, bForceUpdate, Addressation.getCPtr(address));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(uint[] pColors, bool bForceUpdate)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_8(swigCPtr, pColors, bForceUpdate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool install(uint[] pColors)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_install__SWIG_9(swigCPtr, pColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int closestMatch(uint cref, bool bThroughPal)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_closestMatch__SWIG_0(swigCPtr, cref, bThroughPal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int closestMatch(uint cref)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_closestMatch__SWIG_1(swigCPtr, cref);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int firstAvailableBlock(int blockSize)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_firstAvailableBlock(swigCPtr, blockSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGiPalette pPalette, Addressation address)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_isEqualTo__SWIG_0(swigCPtr, getCPtr(pPalette), Addressation.getCPtr(address));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGiPalette pPalette)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_isEqualTo__SWIG_1(swigCPtr, getCPtr(pPalette));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool remove(OdGiPalette pPalette, bool bForceUpdate, Addressation address)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_remove__SWIG_0(swigCPtr, getCPtr(pPalette), bForceUpdate, Addressation.getCPtr(address));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool remove(OdGiPalette pPalette, bool bForceUpdate)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_remove__SWIG_1(swigCPtr, getCPtr(pPalette), bForceUpdate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool remove(OdGiPalette pPalette)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_remove__SWIG_2(swigCPtr, getCPtr(pPalette));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPalette_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
