using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class ValueConstraint : Constraint
{
	private sealed class _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ValueConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			int num = _0023_003DzU7pGb3X7Zp4G;
			ValueConstraint valueConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (!valueConstraint.Reference)
				{
					return false;
				}
				_0023_003DzezVIuujSK1H9 = valueConstraint.value;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				return false;
			}
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
			_0023_003DznRyq1GsKr9YXTkaYDg_003D_003D _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DznRyq1GsKr9YXTkaYDg_003D_003D2 = this;
			}
			else
			{
				_0023_003DznRyq1GsKr9YXTkaYDg_003D_003D2 = new _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D(0);
				_0023_003DznRyq1GsKr9YXTkaYDg_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D2;
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

	internal Param value = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909632));

	private bool _reference;

	private protected bool _selectByRefPoints;

	public Point3D DimPos;

	public virtual bool Reference
	{
		get
		{
			return _reference;
		}
		set
		{
			_reference = value;
		}
	}

	internal ValueConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	protected ValueConstraint(ValueConstraint another)
		: base(another)
	{
		value = another.value._0023_003DzqZwFarHnpOoH();
		Reference = another.Reference;
		DimPos = ((another.DimPos == null) ? null : ((Point3D)another.DimPos.Clone()));
	}

	protected ValueConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		value = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820), typeof(Param));
		Reference = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006426));
		DimPos = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657196), typeof(Point3D));
	}

	internal virtual bool _0023_003DzJ9zJNpOhSoUG()
	{
		return true;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DznRyq1GsKr9YXTkaYDg_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DznRyq1GsKr9YXTkaYDg_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal Transformation _0023_003DzG9wQeg0_003D()
	{
		return _0023_003DzKPUxzjlpDSMi();
	}

	private protected virtual Transformation _0023_003DzKPUxzjlpDSMi()
	{
		return new Identity();
	}

	public virtual double GetValue()
	{
		return value._0023_003DzV29zQ3g_003D();
	}

	public virtual void SetValue(double val)
	{
		value._0023_003DzO_0024HwSzQ_003D(val);
	}

	internal Param _0023_003Dzl9_0024CU_0024ixjyyw()
	{
		return value;
	}

	private protected virtual bool _0023_003DzX91pvtI_003D()
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D obj = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		obj._0023_003DzFZC8G3iHtBMiEUB3b_0024Ox7_0024E_003D = false;
		obj._0023_003Dz2AL_0024zf8_003D(value);
		obj._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(_0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
		return obj._0023_003DzOykoXtw_003D() == solveFailureType.Success;
	}

	internal bool _0023_003Dz_09KxNE_003D()
	{
		return _0023_003DzX91pvtI_003D();
	}

	private protected void _0023_003DzRMfIthrUpPBi(Vector3D _0023_003DzpdeSbFA_003D)
	{
		refPoints[0] = _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003DzUEEs1tMn0naq(_0023_003DzpdeSbFA_003D);
	}

	private protected sealed override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909632), GetValue()._0023_003Dz1eU15ZU_003D());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657175), Reference.ToString());
		if (DimPos != null)
		{
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657159), DimPos.X._0023_003Dz1eU15ZU_003D());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657909), DimPos.Y._0023_003Dz1eU15ZU_003D());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657891), DimPos.Z._0023_003Dz1eU15ZU_003D());
		}
		_0023_003DzGwY28g5pY8a7(_0023_003Dzzic3a9w_003D);
	}

	private protected virtual void _0023_003DzGwY28g5pY8a7(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
	}

	private protected sealed override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		SetValue(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909632)].Value._0023_003DzR61OsnE_003D());
		if (_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657175)] != null)
		{
			Reference = Convert.ToBoolean(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657175)].Value);
		}
		if (_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657159)] != null)
		{
			double x = _0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657159)].Value._0023_003DzR61OsnE_003D();
			double y = _0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657909)].Value._0023_003DzR61OsnE_003D();
			double z = _0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657891)].Value._0023_003DzR61OsnE_003D();
			DimPos = new Point3D(x, y, z);
		}
		_0023_003DzIq_QSAJB6ejc(_0023_003Dzzic3a9w_003D);
	}

	private protected virtual void _0023_003DzIq_QSAJB6ejc(XmlNode _0023_003Dzzic3a9w_003D)
	{
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new ValueConstraintSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820), value);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006426), Reference);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657196), DimPos);
	}

	public override object Clone()
	{
		return new ValueConstraint(this);
	}
}
