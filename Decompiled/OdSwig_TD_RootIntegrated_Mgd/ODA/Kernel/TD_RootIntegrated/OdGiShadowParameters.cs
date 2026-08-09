using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiShadowParameters : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiShadowParameters(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiShadowParameters obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiShadowParameters()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShadowParameters(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiShadowParameters()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShadowParameters__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiShadowParameters(OdGiShadowParameters parms)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShadowParameters__SWIG_1(getCPtr(parms)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiShadowParameters Assign(OdGiShadowParameters parms)
	{
		OdGiShadowParameters result = new OdGiShadowParameters(TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_Assign(swigCPtr, getCPtr(parms)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiShadowParameters parms)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_IsEqual(swigCPtr, getCPtr(parms));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiShadowParameters parms)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_IsNotEqual(swigCPtr, getCPtr(parms));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadowsOn(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShadowsOn(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool shadowsOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shadowsOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShadowType(OdGiShadowParameters_ShadowType typ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShadowType(swigCPtr, (int)typ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiShadowParameters_ShadowType shadowType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shadowType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiShadowParameters_ShadowType)result;
	}

	public bool setShadowMapSize(ushort sz)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShadowMapSize(swigCPtr, sz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort shadowMapSize()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shadowMapSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setShadowMapSoftness(byte soft)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShadowMapSoftness(swigCPtr, soft);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte shadowMapSoftness()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shadowMapSoftness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setShadowSamples(ushort nSamples)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShadowSamples(swigCPtr, nSamples);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort shadowSamples()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shadowSamples(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShapeVisibility(bool bVisibility)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setShapeVisibility(swigCPtr, bVisibility);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool shapeVisibility()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_shapeVisibility(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExtendedLightShape(OdGiShadowParameters_ExtendedLightShape lightShape)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setExtendedLightShape(swigCPtr, (int)lightShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiShadowParameters_ExtendedLightShape extendedLightShape()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_extendedLightShape(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiShadowParameters_ExtendedLightShape)result;
	}

	public bool setExtendedLightLength(double dLength)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setExtendedLightLength(swigCPtr, dLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double extendedLightLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_extendedLightLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setExtendedLightWidth(double dWidth)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setExtendedLightWidth(swigCPtr, dWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double extendedLightWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_extendedLightWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setExtendedLightRadius(double dRadius)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_setExtendedLightRadius(swigCPtr, dRadius);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double extendedLightRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_extendedLightRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void save(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_save(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void load(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShadowParameters_load(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
