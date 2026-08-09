using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPsLinetypes : IDisposable
{
	public class PsLinetypeDef : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public int m_numDashes
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeDef_m_numDashes_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeDef_m_numDashes_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double[] m_dashLength
		{
			get
			{
				double[] result = Helpers.UnMarshaldoubleFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeDef_m_dashLength_get(swigCPtr));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeDef_m_dashLength_set(swigCPtr, Helpers.MarshaldoubleFixedArray(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PsLinetypeDef(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PsLinetypeDef obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PsLinetypeDef()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPsLinetypes_PsLinetypeDef(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public double patternLength()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeDef_patternLength(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public PsLinetypeDef()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes_PsLinetypeDef(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class PsLinetypeGDI : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint m_numDashes
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_m_numDashes_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_m_numDashes_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint[] m_dashLength
		{
			get
			{
				uint[] result = Helpers.UnMarshalUInt32FixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_m_dashLength_get(swigCPtr));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_m_dashLength_set(swigCPtr, Helpers.MarshalUInt32FixedArray(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PsLinetypeGDI(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PsLinetypeGDI obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PsLinetypeGDI()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPsLinetypes_PsLinetypeGDI(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public uint patternLength()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_patternLength(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void clean()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeGDI_clean(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public PsLinetypeGDI()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes_PsLinetypeGDI(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class PsLinetypeOGL : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public ushort m_patternLength
		{
			get
			{
				ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeOGL_m_patternLength_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeOGL_m_patternLength_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ushort m_pattern
		{
			get
			{
				ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeOGL_m_pattern_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_PsLinetypeOGL_m_pattern_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PsLinetypeOGL(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PsLinetypeOGL obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PsLinetypeOGL()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPsLinetypes_PsLinetypeOGL(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public PsLinetypeOGL()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes_PsLinetypeOGL(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPsLinetypes(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPsLinetypes obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPsLinetypes()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPsLinetypes(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPsLinetypes(bool bInitialize, uint nDefs)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes__SWIG_0(bInitialize, nDefs), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPsLinetypes(bool bInitialize)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes__SWIG_1(bInitialize), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPsLinetypes()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsLinetypes__SWIG_2(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInitialized(uint nDefs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_isInitialized__SWIG_0(swigCPtr, nDefs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_isInitialized__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void initialize(uint nDefs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_initialize__SWIG_0(swigCPtr, nDefs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_initialize__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void uninitialize(uint nDefs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_uninitialize__SWIG_0(swigCPtr, nDefs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void uninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_uninitialize__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PsLinetypeDef getPsDefinitions()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getPsDefinitions(swigCPtr);
		PsLinetypeDef result = ((intPtr == IntPtr.Zero) ? null : new PsLinetypeDef(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PsLinetypeDef getPsDefinition(OdPs_LineType psLtp)
	{
		PsLinetypeDef result = new PsLinetypeDef(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getPsDefinition(swigCPtr, (int)psLtp), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator getGiDefinitions()
	{
		OdArray_OdGiLinetype_OdObjectsAllocator result = new OdArray_OdGiLinetype_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getGiDefinitions(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLinetype getGiDefinition(OdPs_LineType psLtp)
	{
		OdGiLinetype result = new OdGiLinetype(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getGiDefinition(swigCPtr, (int)psLtp), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeLinetype(OdPs_LineType psLtp, uint numRepititions, byte ltpValue)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetype__SWIG_0(swigCPtr, (int)psLtp, numRepititions, ltpValue), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeLinetype(OdPs_LineType psLtp, uint numRepititions)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetype__SWIG_1(swigCPtr, (int)psLtp, numRepititions), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeLinetype(OdPs_LineType psLtp)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetype__SWIG_2(swigCPtr, (int)psLtp), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImage rasterizeLinetypeImage(OdPs_LineType psLtp, uint numRepititions, uint numLevels, uint backgroundColor, uint foregroundColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetypeImage__SWIG_0(swigCPtr, (int)psLtp, numRepititions, numLevels, backgroundColor, foregroundColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeLinetypeImage(OdPs_LineType psLtp, uint numRepititions, uint numLevels, uint backgroundColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetypeImage__SWIG_1(swigCPtr, (int)psLtp, numRepititions, numLevels, backgroundColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeLinetypeImage(OdPs_LineType psLtp, uint numRepititions, uint numLevels)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetypeImage__SWIG_2(swigCPtr, (int)psLtp, numRepititions, numLevels), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeLinetypeImage(OdPs_LineType psLtp, uint numRepititions)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetypeImage__SWIG_3(swigCPtr, (int)psLtp, numRepititions), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeLinetypeImage(OdPs_LineType psLtp)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_rasterizeLinetypeImage__SWIG_4(swigCPtr, (int)psLtp), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public PsLinetypeGDI getGDIDefinitions()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getGDIDefinitions(swigCPtr);
		PsLinetypeGDI result = ((intPtr == IntPtr.Zero) ? null : new PsLinetypeGDI(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PsLinetypeGDI getGDIDefinition(OdPs_LineType psLtp)
	{
		PsLinetypeGDI result = new PsLinetypeGDI(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getGDIDefinition(swigCPtr, (int)psLtp), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PsLinetypeOGL getOpenGLDefinitions()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getOpenGLDefinitions(swigCPtr);
		PsLinetypeOGL result = ((intPtr == IntPtr.Zero) ? null : new PsLinetypeOGL(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public PsLinetypeOGL getOpenGLDefinition(OdPs_LineType psLtp)
	{
		PsLinetypeOGL result = new PsLinetypeOGL(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsLinetypes_getOpenGLDefinition(swigCPtr, (int)psLtp), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
