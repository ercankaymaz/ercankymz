using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiShellToolkit : OdRxObject
{
	public class OdGiShellFaceOrientationCallback : IDisposable
	{
		public delegate bool SwigDelegateOdGiShellFaceOrientationCallback_0(IntPtr arg0, int arg1);

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateOdGiShellFaceOrientationCallback_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[2]
		{
			typeof(OdGePoint3d),
			typeof(int)
		};

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellFaceOrientationCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellFaceOrientationCallback obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellFaceOrientationCallback()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellFaceOrientationCallback(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual bool isFaceOrientedCorrectly(OdGePoint3d arg0, int arg1)
		{
			bool result = (SwigDerivedClassHasMethod("isFaceOrientedCorrectly", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellFaceOrientationCallback_isFaceOrientedCorrectlySwigExplicitOdGiShellFaceOrientationCallback(swigCPtr, OdGePoint3d.getCPtr(arg0), arg1) : TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellFaceOrientationCallback_isFaceOrientedCorrectly(swigCPtr, OdGePoint3d.getCPtr(arg0), arg1));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdGiShellFaceOrientationCallback()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellFaceOrientationCallback(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(OdGiShellFaceOrientationCallback) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("isFaceOrientedCorrectly", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodisFaceOrientedCorrectly;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellFaceOrientationCallback_director_connect(swigCPtr, swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiShellFaceOrientationCallback));
		}

		private bool SwigDirectorMethodisFaceOrientedCorrectly(IntPtr arg0, int arg1)
		{
			return isFaceOrientedCorrectly((arg0 == IntPtr.Zero) ? null : new OdGePoint3d(arg0, cMemoryOwn: false), arg1);
		}
	}

	public class OdGiShellOriginalFaceDescription : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint nShell
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellOriginalFaceDescription_nShell_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellOriginalFaceDescription_nShell_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint nOffset
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellOriginalFaceDescription_nOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellOriginalFaceDescription_nOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellOriginalFaceDescription(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellOriginalFaceDescription obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellOriginalFaceDescription()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellOriginalFaceDescription(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGiShellOriginalFaceDescription()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellOriginalFaceDescription(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class OdGiShellFaceDescription : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint nOffset
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellFaceDescription_nOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellFaceDescription_nOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellFaceDescription(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellFaceDescription obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellFaceDescription()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellFaceDescription(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGiShellFaceDescription()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellFaceDescription(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class OdGiShellEdgeDescription : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGiShellFaceDescription face
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeDescription_face_get(swigCPtr);
				OdGiShellFaceDescription result = ((intPtr == IntPtr.Zero) ? null : new OdGiShellFaceDescription(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeDescription_face_set(swigCPtr, OdGiShellFaceDescription.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint nEdge
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeDescription_nEdge_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeDescription_nEdge_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellEdgeDescription(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellEdgeDescription obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellEdgeDescription()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellEdgeDescription(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGiShellEdgeDescription()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellEdgeDescription(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class OdGiShellEdgeVisibilityDescription : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGiShellEdgeDescription edge
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_edge_get(swigCPtr);
				OdGiShellEdgeDescription result = ((intPtr == IntPtr.Zero) ? null : new OdGiShellEdgeDescription(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_edge_set(swigCPtr, OdGiShellEdgeDescription.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool bVisible
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_bVisible_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_bVisible_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellEdgeVisibilityDescription(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellEdgeVisibilityDescription obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellEdgeVisibilityDescription()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGiShellEdgeVisibilityDescription()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class OdGiShellEdgeVisibilityOptions : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public bool bDuplicateEdges
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bDuplicateEdges_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bDuplicateEdges_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool bVisibleOnly
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bVisibleOnly_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bVisibleOnly_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool bIgnoreFlatHoles
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bIgnoreFlatHoles_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_OdGiShellEdgeVisibilityOptions_bIgnoreFlatHoles_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiShellEdgeVisibilityOptions(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiShellEdgeVisibilityOptions obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGiShellEdgeVisibilityOptions()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit_OdGiShellEdgeVisibilityOptions(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGiShellEdgeVisibilityOptions()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellEdgeVisibilityOptions__SWIG_0(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiShellEdgeVisibilityOptions(bool bDuplicate, bool bVisible, bool bNoFlatHoles)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellEdgeVisibilityOptions__SWIG_1(bDuplicate, bVisible, bNoFlatHoles), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiShellEdgeVisibilityOptions(bool bDuplicate, bool bVisible)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShellToolkit_OdGiShellEdgeVisibilityOptions__SWIG_2(bDuplicate, bVisible), cMemoryOwn: true)
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
	public OdGiShellToolkit(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiShellToolkit obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShellToolkit(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiShellToolkit cast(OdRxObject pObj)
	{
		OdGiShellToolkit rXObject = Helpers.GetRXObject<OdGiShellToolkit>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiShellToolkit createObject()
	{
		OdGiShellToolkit rXObject = Helpers.GetRXObject<OdGiShellToolkit>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiShellToolkit create()
	{
		OdGiShellToolkit rXObject = Helpers.GetRXObject<OdGiShellToolkit>(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_create(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool addShell(OdGePoint3d[] nPoints, int[] nFaces, byte options)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nPoints);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(nFaces);
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_addShell__SWIG_0(swigCPtr, intPtr, intPtr2, options);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}
	}

	public virtual bool addShell(OdGePoint3d[] nPoints, int[] nFaces)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nPoints);
		IntPtr intPtr2 = Helpers.MarshalInt32FixedArray(nFaces);
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_addShell__SWIG_1(swigCPtr, intPtr, intPtr2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}
	}

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasDupilcateVertices()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_hasDupilcateVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numSharpEdges(bool bOnlyCount)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numSharpEdges__SWIG_0(swigCPtr, bOnlyCount);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numSharpEdges()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numSharpEdges__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numSingularEdges(bool bOnlyCount)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numSingularEdges__SWIG_0(swigCPtr, bOnlyCount);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numSingularEdges()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numSingularEdges__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numDegeneratedFaces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numDegeneratedFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasDuplicateFaces(ref uint pFirstDuplicateFace, bool bRollFaces)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_hasDuplicateFaces__SWIG_0(swigCPtr, ref pFirstDuplicateFace, bRollFaces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasDuplicateFaces(ref uint pFirstDuplicateFace)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_hasDuplicateFaces__SWIG_1(swigCPtr, ref pFirstDuplicateFace);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasDuplicateFaces()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_hasDuplicateFaces__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool checkFacesOrientation()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_checkFacesOrientation__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool checkFacesOrientation(OdGiShellFaceOrientationCallback pCallback)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_checkFacesOrientation__SWIG_1(swigCPtr, OdGiShellFaceOrientationCallback.getCPtr(pCallback));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void unifyVertices()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_unifyVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeDegenerateFaces()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_removeDegenerateFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeDuplicateFaces(bool bRollFaces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_removeDuplicateFaces__SWIG_0(swigCPtr, bRollFaces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeDuplicateFaces()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_removeDuplicateFaces__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool fixFaceOrientation(bool bRestoreModel)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_fixFaceOrientation__SWIG_0(swigCPtr, bRestoreModel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool fixFaceOrientation()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_fixFaceOrientation__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool fixFaceOrientation(OdGiShellFaceOrientationCallback pCallback, bool bRestoreModel)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_fixFaceOrientation__SWIG_2(swigCPtr, OdGiShellFaceOrientationCallback.getCPtr(pCallback), bRestoreModel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool fixFaceOrientation(OdGiShellFaceOrientationCallback pCallback)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_fixFaceOrientation__SWIG_3(swigCPtr, OdGiShellFaceOrientationCallback.getCPtr(pCallback));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_tolerance__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numVertices()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d[] vertices()
	{
		return Helpers.UnMarshalPoint3dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_vertices(swigCPtr));
	}

	public virtual uint faceListSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_faceListSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int[] faceList()
	{
		return Helpers.UnMarshalInt32FixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_faceList(swigCPtr));
	}

	public virtual void getSharpEdges(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges, bool bOnlyCount, bool bIgnoreZeroHoldes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getSharpEdges__SWIG_0(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges), bOnlyCount, bIgnoreZeroHoldes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSharpEdges(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges, bool bOnlyCount)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getSharpEdges__SWIG_1(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges), bOnlyCount);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSharpEdges(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getSharpEdges__SWIG_2(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSingularEdges(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges, bool bOnlyCount)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getSingularEdges__SWIG_0(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges), bOnlyCount);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSingularEdges(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getSingularEdges__SWIG_1(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getIncorrectOrientedFaces(OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator faces, bool bAddNotOriented)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getIncorrectOrientedFaces__SWIG_0(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator.getCPtr(faces), bAddNotOriented);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getIncorrectOrientedFaces(OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator faces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getIncorrectOrientedFaces__SWIG_1(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator.getCPtr(faces));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getIncorrectOrientedFaces(OdGiShellFaceOrientationCallback pCallback, OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator faces, bool bAddNotOriented)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getIncorrectOrientedFaces__SWIG_2(swigCPtr, OdGiShellFaceOrientationCallback.getCPtr(pCallback), OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator.getCPtr(faces), bAddNotOriented);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getIncorrectOrientedFaces(OdGiShellFaceOrientationCallback pCallback, OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator faces)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getIncorrectOrientedFaces__SWIG_3(swigCPtr, OdGiShellFaceOrientationCallback.getCPtr(pCallback), OdArray_OdGiShellToolkit_OdGiShellFaceDescription_OdObjectsAllocator.getCPtr(faces));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getOriginalFaceDescription(uint nFaceOffset, OdGiShellOriginalFaceDescription result)
	{
		bool result2 = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getOriginalFaceDescription(swigCPtr, nFaceOffset, OdGiShellOriginalFaceDescription.getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result2;
	}

	public virtual void filterEdgesByCreaseAngle(OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator edges, double dAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_filterEdgesByCreaseAngle(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeDescription_OdObjectsAllocator.getCPtr(edges), dAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numNonTriangleFaces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_numNonTriangleFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void triangulate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_triangulate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool calculateFaceNormals(OdArray_OdGeVector3d_OdObjectsAllocator normals)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateFaceNormals(swigCPtr, OdArray_OdGeVector3d_OdObjectsAllocator.getCPtr(normals));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateAverageVertexNormals(OdArray_OdGeVector3d_OdObjectsAllocator normals)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateAverageVertexNormals__SWIG_0(swigCPtr, OdArray_OdGeVector3d_OdObjectsAllocator.getCPtr(normals));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateAverageVertexNormals(OdArray_OdGeVector3d_OdObjectsAllocator normals, double creaseAngelLimit, TD_RootIntegrated_Globals.OdGiCalculateNormalCallbackDelegate pCallback)
	{
		TD_RootIntegrated_Globals.OdGiCalculateNormalCallbackDelegateNative odGiCalculateNormalCallbackDelegateNative = null;
		if (pCallback != null)
		{
			odGiCalculateNormalCallbackDelegateNative = (IntPtr pToolkit, uint nVertexIndex) => OdMarshalHelper.ObjectToPtr<OdGeVector3d>(pCallback(OdMarshalHelper.PtrToObject<OdGiShellToolkit>(pToolkit), nVertexIndex));
		}
		IntPtr jarg = ((pCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odGiCalculateNormalCallbackDelegateNative));
		DelegateHolder.Add(odGiCalculateNormalCallbackDelegateNative);
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateAverageVertexNormals__SWIG_1(swigCPtr, OdArray_OdGeVector3d_OdObjectsAllocator.getCPtr(normals), creaseAngelLimit, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateAverageVertexNormals(OdArray_OdGeVector3d_OdObjectsAllocator normals, double creaseAngelLimit)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateAverageVertexNormals__SWIG_2(swigCPtr, OdArray_OdGeVector3d_OdObjectsAllocator.getCPtr(normals), creaseAngelLimit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateEdgeVisibilitiesByCreaseAngle(OdBoolValuesArray visibilities, double creaseAngle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateEdgeVisibilitiesByCreaseAngle__SWIG_0(swigCPtr, OdBoolValuesArray.getCPtr(visibilities), creaseAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateEdgeVisibilitiesByCreaseAngle(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator visibilities, double creaseAngle, OdGiShellEdgeVisibilityOptions options)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateEdgeVisibilitiesByCreaseAngle__SWIG_1(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator.getCPtr(visibilities), creaseAngle, OdGiShellEdgeVisibilityOptions.getCPtr(options));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateEdgeVisibilitiesByCreaseAngle(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator visibilities, double creaseAngle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_calculateEdgeVisibilitiesByCreaseAngle__SWIG_2(swigCPtr, OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator.getCPtr(visibilities), creaseAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShellToolkit_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
