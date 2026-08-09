using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace devDept.Eyeshot.Control;

public class ToolBarButtonList : CollectionBase, ISerializable, IEnumerable<ToolBarButton>, IEnumerable
{
	private sealed class _0023_003DqlH9Yq48j5oa0dvx6EhiJbjE_00247as_00246q9oYwyooM0froMXrjKsMGQVLj_0024NMjv9fUjnO7k_I67hxnonrj_g47mYgBWlunnwi8bkb0yxeFnVe77sBzT_puNvd25bNtdxgGW1s8wtrlOPHUwX40tQSaNL8A_003D_003D : IEnumerator<ToolBarButton>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ToolBarButton _0023_003Dzn0gRlKh1Xs_0024z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ToolBarButtonList _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator _0023_003DzwC9MT_0K4rtIobKEuA_003D_003D;

		[DebuggerHidden]
		public _0023_003DqlH9Yq48j5oa0dvx6EhiJbjE_00247as_00246q9oYwyooM0froMXrjKsMGQVLj_0024NMjv9fUjnO7k_I67hxnonrj_g47mYgBWlunnwi8bkb0yxeFnVe77sBzT_puNvd25bNtdxgGW1s8wtrlOPHUwX40tQSaNL8A_003D_003D(int _0023_003Dz0FVSO5LFyxyq)
		{
			this._0023_003Dz0FVSO5LFyxyq = _0023_003Dz0FVSO5LFyxyq;
		}

		[DebuggerHidden]
		private void _0023_003DztGebTB5LtngkpFRyVA_003D_003D()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D();
				}
			}
			_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D = null;
			_0023_003Dz0FVSO5LFyxyq = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ztGebTB5LtngkpFRyVA==
			this._0023_003DztGebTB5LtngkpFRyVA_003D_003D();
		}

		private bool MoveNext()
		{
			try
			{
				int num = _0023_003Dz0FVSO5LFyxyq;
				ToolBarButtonList toolBarButtonList = _0023_003DzKdgtcDsi34jL;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003Dz0FVSO5LFyxyq = -1;
					_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D = toolBarButtonList.List.GetEnumerator();
					_0023_003Dz0FVSO5LFyxyq = -3;
					break;
				case 1:
					_0023_003Dz0FVSO5LFyxyq = -3;
					break;
				}
				if (_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D.MoveNext())
				{
					ToolBarButton toolBarButton = (ToolBarButton)_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D.Current;
					_0023_003Dzn0gRlKh1Xs_0024z = toolBarButton;
					_0023_003Dz0FVSO5LFyxyq = 1;
					return true;
				}
				_0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D();
				_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D = null;
				return false;
			}
			catch
			{
				//try-fault
				_0023_003DztGebTB5LtngkpFRyVA_003D_003D();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D()
		{
			_0023_003Dz0FVSO5LFyxyq = -1;
			if (_0023_003DzwC9MT_0K4rtIobKEuA_003D_003D is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		[DebuggerHidden]
		private ToolBarButton _0023_003DzlsHw_aCm5wa_0024eLSZKJejelG7RaFtWBv_0024_0024qgB0hPBYbh3H0q870BaM6c_003D()
		{
			return _0023_003Dzn0gRlKh1Xs_0024z;
		}

		ToolBarButton IEnumerator<ToolBarButton>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zlsHw_aCm5wa$eLSZKJejelG7RaFtWBv$$qgB0hPBYbh3H0q870BaM6c=
			return this._0023_003DzlsHw_aCm5wa_0024eLSZKJejelG7RaFtWBv_0024_0024qgB0hPBYbh3H0q870BaM6c_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zSJDwxsp$EPiLsdD2FQ==
			this._0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D()
		{
			return _0023_003Dzn0gRlKh1Xs_0024z;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zmzmoZTP$PubEDyNMJew_S2I=
			return this._0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBar _0023_003DzeBYwLXPcmkX3;

	public ToolBar ParentToolBar => _0023_003DzeBYwLXPcmkX3;

	[NotifyParentProperty(true)]
	public ToolBarButton this[int index]
	{
		get
		{
			return (ToolBarButton)base.List[index];
		}
		set
		{
			((ToolBarButton)base.List[index]).Dispose();
			base.List[index] = value;
			_0023_003Dz_0024vDumkOiIBps(value);
		}
	}

	public ToolBarButtonList(ToolBar parentToolBar)
	{
		_0023_003DzeBYwLXPcmkX3 = parentToolBar;
	}

	public ToolBarButtonList(ToolBar parentToolBar, ToolBarButton[] buttons)
		: this(parentToolBar)
	{
		AddRange(buttons);
	}

	internal void _0023_003DzG60zt6f1sY5J(ToolBar _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz_0024vDumkOiIBps(_0023_003DzsLHxXyo_003D);
	}

	internal void _0023_003Dz_0024vDumkOiIBps(ToolBar _0023_003Dz0TvaYNo_003D)
	{
		_0023_003DzeBYwLXPcmkX3 = _0023_003Dz0TvaYNo_003D;
		foreach (ToolBarButton item in base.List)
		{
			_0023_003Dz_0024vDumkOiIBps(item);
		}
	}

	private void _0023_003Dz_0024vDumkOiIBps(ToolBarButton _0023_003DzkGobcLg_003D)
	{
		_0023_003DzkGobcLg_003D._0023_003Dz4iBK5_0024N3N5g7 = _0023_003DzeBYwLXPcmkX3;
	}

	public int Add(ToolBarButton value)
	{
		return base.List.Add(value);
	}

	public int AddRange(IEnumerable<ToolBarButton> value)
	{
		int result = 0;
		foreach (ToolBarButton item in value)
		{
			result = base.List.Add(item);
		}
		return result;
	}

	public int IndexOf(ToolBarButton value)
	{
		return base.List.IndexOf(value);
	}

	public void Insert(int index, ToolBarButton value)
	{
		base.List.Insert(index, value);
	}

	public void Remove(ToolBarButton value)
	{
		base.List.Remove(value);
	}

	protected override void OnClear()
	{
		foreach (ToolBarButton item in base.List)
		{
			item.Dispose();
		}
		base.OnClear();
	}

	public bool Contains(ToolBarButton value)
	{
		return base.List.Contains(value);
	}

	protected override void OnInsert(int index, object value)
	{
		base.OnInsert(index, value);
		_0023_003Dz_0024vDumkOiIBps((ToolBarButton)value);
	}

	protected override void OnRemove(int index, object value)
	{
		ToolBarButton toolBarButton = value as ToolBarButton;
		toolBarButton._0023_003Dz4iBK5_0024N3N5g7 = null;
		if (!toolBarButton._0023_003DzVCRPD_0024GbQNCA)
		{
			toolBarButton.Dispose();
		}
	}

	protected override void OnSet(int index, object oldValue, object newValue)
	{
		base.OnSet(index, oldValue, newValue);
		((ToolBarButton)newValue)._0023_003Dz4iBK5_0024N3N5g7 = _0023_003DzeBYwLXPcmkX3;
	}

	[IteratorStateMachine(typeof(_0023_003DqlH9Yq48j5oa0dvx6EhiJbjE_00247as_00246q9oYwyooM0froMXrjKsMGQVLj_0024NMjv9fUjnO7k_I67hxnonrj_g47mYgBWlunnwi8bkb0yxeFnVe77sBzT_puNvd25bNtdxgGW1s8wtrlOPHUwX40tQSaNL8A_003D_003D))]
	IEnumerator<ToolBarButton> IEnumerable<ToolBarButton>.GetEnumerator()
	{
		return new _0023_003DqlH9Yq48j5oa0dvx6EhiJbjE_00247as_00246q9oYwyooM0froMXrjKsMGQVLj_0024NMjv9fUjnO7k_I67hxnonrj_g47mYgBWlunnwi8bkb0yxeFnVe77sBzT_puNvd25bNtdxgGW1s8wtrlOPHUwX40tQSaNL8A_003D_003D(0)
		{
			_0023_003DzKdgtcDsi34jL = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	protected override void OnValidate(object value)
	{
		if (!(value is ToolBarButton))
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591003), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591024));
		}
	}

	public ToolBarButton[] ToArray()
	{
		ToolBarButton[] array = new ToolBarButton[base.List.Count];
		base.List.CopyTo(array, 0);
		return array;
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591045), ParentToolBar);
	}
}
