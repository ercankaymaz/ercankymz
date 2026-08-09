using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdRcsVisibleVoxelsIterator : IDisposable
{
	public delegate void SwigDelegateOdRcsVisibleVoxelsIterator_0();

	public delegate void SwigDelegateOdRcsVisibleVoxelsIterator_1();

	public delegate bool SwigDelegateOdRcsVisibleVoxelsIterator_2();

	public delegate void SwigDelegateOdRcsVisibleVoxelsIterator_3(uint componentsToProcess, IntPtr pComponentsRaws, uint rawsNumber, uint flags, ulong voxelIndex, uint numberOfPointsToDraw, uint loadedPointsNumber);

	public delegate uint SwigDelegateOdRcsVisibleVoxelsIterator_4();

	public delegate bool SwigDelegateOdRcsVisibleVoxelsIterator_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRcsVisibleVoxelsIterator_0 swigDelegate0;

	private SwigDelegateOdRcsVisibleVoxelsIterator_1 swigDelegate1;

	private SwigDelegateOdRcsVisibleVoxelsIterator_2 swigDelegate2;

	private SwigDelegateOdRcsVisibleVoxelsIterator_3 swigDelegate3;

	private SwigDelegateOdRcsVisibleVoxelsIterator_4 swigDelegate4;

	private SwigDelegateOdRcsVisibleVoxelsIterator_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[7]
	{
		typeof(uint),
		typeof(OdGiPointCloud.ComponentsRaw).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(ulong).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRcsVisibleVoxelsIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRcsVisibleVoxelsIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRcsVisibleVoxelsIterator()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdRcsVisibleVoxelsIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void start()
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_start(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step()
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_step(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_done(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getVoxelBuffer(uint componentsToProcess, out OdGiPointCloud.ComponentsRaw pComponentsRaws, out uint rawsNumber, out uint flags, out ulong voxelIndex, out uint numberOfPointsToDraw, out uint loadedPointsNumber)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_getVoxelBuffer(swigCPtr, componentsToProcess, out jarg, out rawsNumber, out flags, out voxelIndex, out numberOfPointsToDraw, out loadedPointsNumber);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, bIsWrapperOwnNativeObject: true));
			pComponentsRaws = Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, currentTransaction == null);
		}
	}

	public virtual uint getNumberOfLoadedPointsToDraw()
	{
		uint result = RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_getNumberOfLoadedPointsToDraw(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasPointsLoaded()
	{
		bool result = RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_hasPointsLoaded(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRcsVisibleVoxelsIterator()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdRcsVisibleVoxelsIterator(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRcsVisibleVoxelsIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodstep;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getVoxelBuffer", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetVoxelBuffer;
		}
		if (SwigDerivedClassHasMethod("getNumberOfLoadedPointsToDraw", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetNumberOfLoadedPointsToDraw;
		}
		if (SwigDerivedClassHasMethod("hasPointsLoaded", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodhasPointsLoaded;
		}
		RcsFileServices_GlobalsPINVOKE.OdRcsVisibleVoxelsIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRcsVisibleVoxelsIterator));
	}

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodstep()
	{
		try
		{
			step();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private void SwigDirectorMethodgetVoxelBuffer(uint componentsToProcess, IntPtr pComponentsRaws, uint rawsNumber, uint flags, ulong voxelIndex, uint numberOfPointsToDraw, uint loadedPointsNumber)
	{
		OdGiPointCloud.ComponentsRaw pComponentsRaws2 = new OdGiPointCloud.ComponentsRaw(pComponentsRaws, cMemoryOwn: true);
		try
		{
			getVoxelBuffer(componentsToProcess, out pComponentsRaws2, out rawsNumber, out flags, out voxelIndex, out numberOfPointsToDraw, out loadedPointsNumber);
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
		finally
		{
			pComponentsRaws = OdGiPointCloud.ComponentsRaw.getCPtr(pComponentsRaws2).Handle;
		}
	}

	private uint SwigDirectorMethodgetNumberOfLoadedPointsToDraw()
	{
		return getNumberOfLoadedPointsToDraw();
	}

	private bool SwigDirectorMethodhasPointsLoaded()
	{
		return hasPointsLoaded();
	}
}
