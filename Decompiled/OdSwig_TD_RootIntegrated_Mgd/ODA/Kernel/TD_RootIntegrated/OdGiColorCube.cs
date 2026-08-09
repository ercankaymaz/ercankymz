using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiColorCube : OdRxObject
{
	public class DtMatchResult : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public int[] m_fitColors
		{
			get
			{
				int[] result = Helpers.UnMarshalInt32FixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_DtMatchResult_m_fitColors_get(swigCPtr));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_DtMatchResult_m_fitColors_set(swigCPtr, Helpers.MarshalInt32FixedArray(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public int[] m_pattern
		{
			get
			{
				int[] result = Helpers.UnMarshalInt32FixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_DtMatchResult_m_pattern_get(swigCPtr));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_DtMatchResult_m_pattern_set(swigCPtr, Helpers.MarshalInt32FixedArray(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DtMatchResult(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DtMatchResult obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DtMatchResult()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiColorCube_DtMatchResult(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DtMatchResult()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiColorCube_DtMatchResult(), cMemoryOwn: true)
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
	public OdGiColorCube(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiColorCube obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiColorCube()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiColorCube(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGiColorCube createDynamic(OdGiIntRGB nGridDivs, float fIntensity, int nBaseOffset)
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_createDynamic__SWIG_0(OdGiIntRGB.getCPtr(nGridDivs), fIntensity, nBaseOffset), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiColorCube createDynamic(OdGiIntRGB nGridDivs, float fIntensity)
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_createDynamic__SWIG_1(OdGiIntRGB.getCPtr(nGridDivs), fIntensity), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiColorCube createDynamic(OdGiIntRGB nGridDivs)
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_createDynamic__SWIG_2(OdGiIntRGB.getCPtr(nGridDivs)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiColorCube createDynamic()
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_createDynamic__SWIG_3(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiColorCube cloneIfNeed()
	{
		OdGiColorCube rXObject = Helpers.GetRXObject<OdGiColorCube>(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_cloneIfNeed(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public int baseOffset()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_baseOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiIntRGB gridDivisions()
	{
		OdGiIntRGB result = new OdGiIntRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_gridDivisions(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public float intensity()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_intensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int gridSize()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_gridSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiIntRGB offsets()
	{
		OdGiIntRGB result = new OdGiIntRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_offsets(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiIntRGB dimensions()
	{
		OdGiIntRGB result = new OdGiIntRGB(TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_dimensions(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint color(int nColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_color(swigCPtr, nColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int closestMatch(uint cref)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_closestMatch(swigCPtr, cref);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int ditheredMatch(uint cref, DtMatchResult results)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_ditheredMatch(swigCPtr, cref, DtMatchResult.getCPtr(results));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiColorCube_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
