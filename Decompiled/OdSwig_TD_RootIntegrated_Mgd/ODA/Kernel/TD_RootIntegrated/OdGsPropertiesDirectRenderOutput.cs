using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsPropertiesDirectRenderOutput : IDisposable
{
	public class DirectRenderImageUV : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public double u
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageUV_u_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageUV_u_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double v
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageUV_v_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageUV_v_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DirectRenderImageUV(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DirectRenderImageUV obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DirectRenderImageUV()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsPropertiesDirectRenderOutput_DirectRenderImageUV(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DirectRenderImageUV()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPropertiesDirectRenderOutput_DirectRenderImageUV(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class DirectRenderImageParams : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public DirectRenderImageUV uvCoords
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_uvCoords_get(swigCPtr);
				DirectRenderImageUV result = ((intPtr == IntPtr.Zero) ? null : new DirectRenderImageUV(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_uvCoords_set(swigCPtr, DirectRenderImageUV.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiDrawable pDrawable
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_pDrawable_get(swigCPtr);
				OdGiDrawable result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawable(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_pDrawable_set(swigCPtr, OdGiDrawable.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool bUpdate
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_bUpdate_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_DirectRenderImageParams_bUpdate_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DirectRenderImageParams(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DirectRenderImageParams obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DirectRenderImageParams()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsPropertiesDirectRenderOutput_DirectRenderImageParams(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DirectRenderImageParams()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPropertiesDirectRenderOutput_DirectRenderImageParams(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_0(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_1(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_2(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_3(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_4(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_5(uint arg0, IntPtr arg1, IntPtr arg2);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_6(uint arg0, IntPtr arg1, IntPtr arg2);

	public delegate void SwigDelegateOdGsPropertiesDirectRenderOutput_7(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate uint SwigDelegateOdGsPropertiesDirectRenderOutput_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_0 swigDelegate0;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_1 swigDelegate1;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_2 swigDelegate2;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_3 swigDelegate3;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_4 swigDelegate4;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_5 swigDelegate5;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_6 swigDelegate6;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_7 swigDelegate7;

	private SwigDelegateOdGsPropertiesDirectRenderOutput_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes2 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes4 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor),
		typeof(OdCmEntityColor),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGiRasterImage),
		typeof(DirectRenderImageParams)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsPropertiesDirectRenderOutput(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsPropertiesDirectRenderOutput obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsPropertiesDirectRenderOutput()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsPropertiesDirectRenderOutput(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void directRenderOutputPoint(OdGePoint3d arg0, OdCmEntityColor arg1)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputPoint", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPointSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdCmEntityColor.getCPtr(arg1));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPoint(swigCPtr, OdGePoint3d.getCPtr(arg0), OdCmEntityColor.getCPtr(arg1));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputLineFlat(OdGePoint3d arg0, OdGePoint3d arg1, OdCmEntityColor arg2)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputLineFlat", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputLineFlatSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputLineFlat(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputLineGouraud(OdGePoint3d arg0, OdGePoint3d arg1, OdCmEntityColor arg2, OdCmEntityColor arg3)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputLineGouraud", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputLineGouraudSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputLineGouraud(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputTriangleFlat(OdGePoint3d arg0, OdGePoint3d arg1, OdGePoint3d arg2, OdCmEntityColor arg3)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputTriangleFlat", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputTriangleFlatSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdGePoint3d.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputTriangleFlat(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdGePoint3d.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputTriangleGouraud(OdGePoint3d arg0, OdGePoint3d arg1, OdGePoint3d arg2, OdCmEntityColor arg3, OdCmEntityColor arg4, OdCmEntityColor arg5)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputTriangleGouraud", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputTriangleGouraudSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdGePoint3d.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3), OdCmEntityColor.getCPtr(arg4), OdCmEntityColor.getCPtr(arg5));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputTriangleGouraud(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGePoint3d.getCPtr(arg1), OdGePoint3d.getCPtr(arg2), OdCmEntityColor.getCPtr(arg3), OdCmEntityColor.getCPtr(arg4), OdCmEntityColor.getCPtr(arg5));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputPolygoneFlat(uint arg0, OdGePoint3d arg1, OdCmEntityColor arg2)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputPolygoneFlat", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPolygoneFlatSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, arg0, OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPolygoneFlat(swigCPtr, arg0, OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputPolygoneGouraud(uint arg0, OdGePoint3d arg1, OdCmEntityColor arg2)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputPolygoneGouraud", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPolygoneGouraudSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, arg0, OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputPolygoneGouraud(swigCPtr, arg0, OdGePoint3d.getCPtr(arg1), OdCmEntityColor.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void directRenderOutputImage(OdGePoint3d arg0, OdGiRasterImage arg1, DirectRenderImageParams arg2)
	{
		if (SwigDerivedClassHasMethod("directRenderOutputImage", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputImageSwigExplicitOdGsPropertiesDirectRenderOutput(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGiRasterImage.getCPtr(arg1), DirectRenderImageParams.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputImage(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGiRasterImage.getCPtr(arg1), DirectRenderImageParams.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint directRenderOutputFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_directRenderOutputFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsPropertiesDirectRenderOutput()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPropertiesDirectRenderOutput(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsPropertiesDirectRenderOutput) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("directRenderOutputPoint", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethoddirectRenderOutputPoint;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputLineFlat", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethoddirectRenderOutputLineFlat;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputLineGouraud", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethoddirectRenderOutputLineGouraud;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputTriangleFlat", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddirectRenderOutputTriangleFlat;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputTriangleGouraud", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddirectRenderOutputTriangleGouraud;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputPolygoneFlat", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddirectRenderOutputPolygoneFlat;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputPolygoneGouraud", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddirectRenderOutputPolygoneGouraud;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputImage", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddirectRenderOutputImage;
		}
		if (SwigDerivedClassHasMethod("directRenderOutputFlags", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddirectRenderOutputFlags;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPropertiesDirectRenderOutput_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsPropertiesDirectRenderOutput));
	}

	private void SwigDirectorMethoddirectRenderOutputPoint(IntPtr arg0, IntPtr arg1)
	{
		try
		{
			directRenderOutputPoint(new OdGePoint3d(arg0, cMemoryOwn: false), new OdCmEntityColor(arg1, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputLineFlat(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			directRenderOutputLineFlat(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGePoint3d(arg1, cMemoryOwn: false), new OdCmEntityColor(arg2, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputLineGouraud(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3)
	{
		try
		{
			directRenderOutputLineGouraud(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGePoint3d(arg1, cMemoryOwn: false), new OdCmEntityColor(arg2, cMemoryOwn: false), new OdCmEntityColor(arg3, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputTriangleFlat(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3)
	{
		try
		{
			directRenderOutputTriangleFlat(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGePoint3d(arg1, cMemoryOwn: false), new OdGePoint3d(arg2, cMemoryOwn: false), new OdCmEntityColor(arg3, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputTriangleGouraud(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5)
	{
		try
		{
			directRenderOutputTriangleGouraud(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGePoint3d(arg1, cMemoryOwn: false), new OdGePoint3d(arg2, cMemoryOwn: false), new OdCmEntityColor(arg3, cMemoryOwn: false), new OdCmEntityColor(arg4, cMemoryOwn: false), new OdCmEntityColor(arg5, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputPolygoneFlat(uint arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			directRenderOutputPolygoneFlat(arg0, (arg1 == IntPtr.Zero) ? null : new OdGePoint3d(arg1, cMemoryOwn: false), new OdCmEntityColor(arg2, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputPolygoneGouraud(uint arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			directRenderOutputPolygoneGouraud(arg0, (arg1 == IntPtr.Zero) ? null : new OdGePoint3d(arg1, cMemoryOwn: false), (arg2 == IntPtr.Zero) ? null : new OdCmEntityColor(arg2, cMemoryOwn: false));
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

	private void SwigDirectorMethoddirectRenderOutputImage(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			directRenderOutputImage((arg0 == IntPtr.Zero) ? null : new OdGePoint3d(arg0, cMemoryOwn: false), Helpers.GetRXObject<OdGiRasterImage>(arg1, bOwn: false, bTryAddToTransaction: false), new DirectRenderImageParams(arg2, cMemoryOwn: false));
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

	private uint SwigDirectorMethoddirectRenderOutputFlags()
	{
		return directRenderOutputFlags();
	}
}
