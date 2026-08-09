using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcAttributeExternal : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public string entryName
	{
		get
		{
			string result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_entryName_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_entryName_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int data
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_data_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_data_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool useSameAppIDAsFileStructure
	{
		get
		{
			bool result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_useSameAppIDAsFileStructure_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_useSameAppIDAsFileStructure_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int IDPart1
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart1_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart1_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int IDPart2
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart2_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart2_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int IDPart3
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart3_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart3_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int IDPart4
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart4_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_IDPart4_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcAttributeExternal(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcAttributeExternal obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcAttributeExternal()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcAttributeExternal(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcAttributeExternal()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcAttributeExternal__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcAttributeExternal(string entryName, int data)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcAttributeExternal__SWIG_1(entryName, data), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValid()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcAttributeExternal_isValid(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
