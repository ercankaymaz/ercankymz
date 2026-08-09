using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public abstract class SketchItem : SketchBase
{
	private sealed class _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerHidden]
		public _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			if (_0023_003DzU7pGb3X7Zp4G != 0)
			{
				return false;
			}
			_0023_003DzU7pGb3X7Zp4G = -1;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private Param _0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Param IEnumerator<Param>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcbi5nOQLxptNo77Yg$Jc8aWyZ$460IrsvT18voWlqLZB4j6K0Q==
			return this._0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<Param> _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D()
		{
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				return this;
			}
			return new _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(0);
		}

		IEnumerator<Param> IEnumerable<Param>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxNlvRhfIQy$WVUDjMQaY8aVUHXYxmRLXzqjrr$kou4GwVwkDgQ==
			return this._0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerHidden]
		public _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			if (_0023_003DzU7pGb3X7Zp4G != 0)
			{
				return false;
			}
			_0023_003DzU7pGb3X7Zp4G = -1;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private Exp _0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Exp IEnumerator<Exp>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg==
			return this._0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<Exp> _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D()
		{
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				return this;
			}
			return new _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(0);
		}

		IEnumerator<Exp> IEnumerable<Exp>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv$MbIdl_IomwTLQ==
			return this._0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	internal global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<SketchItem, Entity> entityLink;

	private SketchInternal _sketchInternal;

	[CompilerGenerated]
	private Id _003Cguid_003Ek__BackingField;

	public bool IsDestroyed { get; }

	protected SketchItem(SketchItem another)
		: base(another)
	{
		_0023_003DzFEM_9wUwFnxN(another.IsDestroyed);
		_0023_003DzxWZ7yqG65a6T(another._0023_003DzDQs07gDx7oDr());
		_0023_003DzZEJDfL4_003D();
	}

	protected SketchItem()
	{
		entityLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<SketchItem, Entity>(this);
		_0023_003DzZEJDfL4_003D();
	}

	internal SketchItem(SketchInternal _0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D)
	{
		if (_0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D != null)
		{
			_0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(_0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D);
			_0023_003DzxWZ7yqG65a6T(_0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D.idGenerator.New());
		}
		_0023_003DzZEJDfL4_003D();
	}

	protected SketchItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D((SketchInternal)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656781), typeof(SketchInternal)));
		_0023_003DzZEJDfL4_003D();
	}

	private void _0023_003DzZEJDfL4_003D()
	{
		entityLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<SketchItem, Entity>(this);
	}

	internal virtual SketchInternal _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()
	{
		return _sketchInternal;
	}

	internal virtual void _0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(SketchInternal _0023_003DzPzO_0024GUk_003D)
	{
		_sketchInternal = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzFEM_9wUwFnxN(bool _0023_003DzPzO_0024GUk_003D)
	{
		IsDestroyed = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	[CompilerGenerated]
	internal override Id _0023_003DzDQs07gDx7oDr()
	{
		return _003Cguid_003Ek__BackingField;
	}

	[SpecialName]
	[CompilerGenerated]
	internal override void _0023_003DzxWZ7yqG65a6T(Id _0023_003DzPzO_0024GUk_003D)
	{
		_003Cguid_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	internal override SketchBase _0023_003DziNzzmPCarBGC()
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D();
	}

	internal override ISketchBase _0023_003DzCzT7cK4_003D(Id _0023_003DzG5EGDUs_003D)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D))]
	internal virtual IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(-2);
	}

	[IteratorStateMachine(typeof(_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof))]
	internal virtual IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(-2);
	}

	public virtual void Destroy()
	{
		if (!IsDestroyed)
		{
			_0023_003DzFEM_9wUwFnxN(_0023_003DzPzO_0024GUk_003D: true);
			if (_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D() != null)
			{
				_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzmSyvi00_003D(this);
			}
			_0023_003DzAuRWtKw_003D();
		}
	}

	private protected virtual void _0023_003DzAuRWtKw_003D()
	{
	}

	internal virtual void _0023_003Dzqx2DhVY_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657259), _0023_003DzDQs07gDx7oDr().ToString());
		_0023_003DzLMYk8jQ_003D(_0023_003Dzzic3a9w_003D);
	}

	private protected virtual void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
	}

	internal virtual void _0023_003DzVemZ00E_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzk7PWAPc_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657259)].Value);
		_0023_003Dzy_0024vnioE_003D(_0023_003Dzzic3a9w_003D);
	}

	internal void _0023_003Dzk7PWAPc_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		Id id = _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().idGenerator.Create(_0023_003DzPzO_0024GUk_003D);
		if (_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().idMapping != null)
		{
			_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().idMapping[id] = _0023_003DzDQs07gDx7oDr();
		}
		else
		{
			_0023_003DzxWZ7yqG65a6T(id);
		}
	}

	private protected virtual void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
	}

	internal virtual bool _0023_003Dztl9hmdI_003D()
	{
		return _0023_003DzfgkGlWk_003D();
	}

	private protected virtual bool _0023_003DzfgkGlWk_003D()
	{
		return false;
	}

	public virtual SketchItemSurrogate ConvertToSurrogate()
	{
		return null;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656781), _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D());
	}

	public solveFailureType SolveForConnectedEntities()
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		_sketchInternal._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, null, this);
		return _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
	}
}
