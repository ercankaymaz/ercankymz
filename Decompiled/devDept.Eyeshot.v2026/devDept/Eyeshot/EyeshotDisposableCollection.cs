using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace devDept.Eyeshot;

[Serializable]
public class EyeshotDisposableCollection<T> : EyeshotCollection<T> where T : IDisposable
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz_0024K13JUGPpnyv4u3d6g_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EyeshotDisposableCollection<T> _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public T _0023_003DzUBZd570_003D;

		private void MoveNext()
		{
			EyeshotDisposableCollection<T> eyeshotDisposableCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				eyeshotDisposableCollection._0023_003DzsHOPLaXVRRYt(_0023_003DzUBZd570_003D);
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz5THLtxDAnmvxKqAnBg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EyeshotDisposableCollection<T> _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public T _0023_003DzUBZd570_003D;

		private void MoveNext()
		{
			EyeshotDisposableCollection<T> eyeshotDisposableCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				eyeshotDisposableCollection._0023_003Dz10xO6jmZZfus(_0023_003DzyzK8swU_003D, _0023_003DzUBZd570_003D);
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzcspDC2Ct54_zMUUB2Q_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<T> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EyeshotDisposableCollection<T> _0023_003DzopRx0_MBcTQs;

		private void MoveNext()
		{
			EyeshotDisposableCollection<T> eyeshotDisposableCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				IList<T> list = _0023_003DzcrILBXg_003D as IList<T>;
				if (list == null)
				{
					list = _0023_003DzcrILBXg_003D.ToList();
				}
				eyeshotDisposableCollection._0023_003Dz6o91qlpB3dZY(list);
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzmYtqNxeyqb_0024yWt3GwtB1dtQ_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<T> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EyeshotDisposableCollection<T> _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		private void MoveNext()
		{
			EyeshotDisposableCollection<T> eyeshotDisposableCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				IList<T> list = _0023_003DzcrILBXg_003D as IList<T>;
				if (list == null)
				{
					list = _0023_003DzcrILBXg_003D.ToList();
				}
				eyeshotDisposableCollection._0023_003Dz0OEC_00246Jly68n(_0023_003DzyzK8swU_003D, list);
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Document _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;

	protected internal Document Document
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;
		}
	}

	public override T this[int index]
	{
		get
		{
			return baseList[index];
		}
		set
		{
			_0023_003DznvxBzE3KPAch(value, null);
			if (_0023_003Dzo60vEkkaRGxX() != null)
			{
				_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
				baseList[index].Dispose();
			}
			baseList[index] = value;
		}
	}

	internal EyeshotDisposableCollection()
	{
	}

	private void _0023_003DzSrVa3io_003D(Document _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal IWorkspaceInternal _0023_003Dzo60vEkkaRGxX()
	{
		return Document?.workspace;
	}

	internal virtual void SetDocument(Document _0023_003DzoPlwCJA_003D)
	{
		_0023_003DzSrVa3io_003D(_0023_003DzoPlwCJA_003D);
	}

	private protected virtual void _0023_003DznvxBzE3KPAch(T _0023_003DzPzO_0024GUk_003D, RegenOptions _0023_003DzZcrk_0024oE_003D)
	{
	}

	public override void Add(T item)
	{
		_0023_003DznvxBzE3KPAch(item, null);
		base.Add(item);
	}

	public void Add(T item, RegenOptions ro)
	{
		_0023_003DznvxBzE3KPAch(item, ro);
		base.Add(item);
	}

	public virtual async Task AddAsync(T item, RegenOptions ro = null)
	{
		_0023_003DzsHOPLaXVRRYt(item);
	}

	public override void AddRange(IEnumerable<T> collection)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz5MnY2mTEV4BM(list, null);
		base.AddRange(list);
	}

	public void AddRange(IEnumerable<T> collection, RegenOptions ro)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz5MnY2mTEV4BM(list, ro);
		base.AddRange(list);
	}

	public virtual async Task AddRangeAsync(IEnumerable<T> collection, RegenOptions ro = null)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz6o91qlpB3dZY(list);
	}

	private protected virtual void _0023_003Dz5MnY2mTEV4BM(IList<T> _0023_003DzcrILBXg_003D, RegenOptions _0023_003DzZcrk_0024oE_003D)
	{
	}

	public override void Insert(int index, T item)
	{
		_0023_003DznvxBzE3KPAch(item, null);
		base.Insert(index, item);
	}

	public void Insert(int index, T item, RegenOptions ro)
	{
		_0023_003DznvxBzE3KPAch(item, ro);
		base.Insert(index, item);
	}

	public virtual async Task InsertAsync(int index, T item, RegenOptions ro = null)
	{
		_0023_003Dz10xO6jmZZfus(index, item);
	}

	public override void InsertRange(int index, IEnumerable<T> collection)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz5MnY2mTEV4BM(list, null);
		base.InsertRange(index, list);
	}

	public void InsertRange(int index, IEnumerable<T> collection, RegenOptions ro)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz5MnY2mTEV4BM(list, ro);
		base.InsertRange(index, list);
	}

	public virtual async Task InsertRangeAsync(int index, IEnumerable<T> collection, RegenOptions ro = null)
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		_0023_003Dz0OEC_00246Jly68n(index, list);
	}

	public override bool Remove(T item)
	{
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			item.Dispose();
		}
		return baseList.Remove(item);
	}

	public override void RemoveAt(int index)
	{
		T val = baseList[index];
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().RenderContext != null)
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			val.Dispose();
		}
		baseList.RemoveAt(index);
	}

	public override void RemoveRange(int index, int count)
	{
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			for (int i = index; i < count; i++)
			{
				baseList[i].Dispose();
			}
		}
		baseList.RemoveRange(index, count);
	}

	public override int RemoveAll(Predicate<T> match)
	{
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			foreach (T item in FindAll(match))
			{
				item.Dispose();
			}
		}
		return baseList.RemoveAll(match);
	}

	public override void Clear()
	{
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			FreeGraphicsResources();
		}
		baseList.Clear();
	}

	internal void FreeGraphicsResources()
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			return;
		}
		foreach (T @base in baseList)
		{
			@base.Dispose();
		}
	}

	[DebuggerHidden]
	private void _0023_003DzsHOPLaXVRRYt(T _0023_003DzUBZd570_003D)
	{
		base.Add(_0023_003DzUBZd570_003D);
	}

	[DebuggerHidden]
	private void _0023_003Dz6o91qlpB3dZY(IEnumerable<T> _0023_003DzcrILBXg_003D)
	{
		base.AddRange(_0023_003DzcrILBXg_003D);
	}

	[DebuggerHidden]
	private void _0023_003Dz10xO6jmZZfus(int _0023_003DzyzK8swU_003D, T _0023_003DzUBZd570_003D)
	{
		base.Insert(_0023_003DzyzK8swU_003D, _0023_003DzUBZd570_003D);
	}

	[DebuggerHidden]
	private void _0023_003Dz0OEC_00246Jly68n(int _0023_003DzyzK8swU_003D, IEnumerable<T> _0023_003DzcrILBXg_003D)
	{
		base.InsertRange(_0023_003DzyzK8swU_003D, _0023_003DzcrILBXg_003D);
	}
}
