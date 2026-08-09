using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class Constraint : SketchItem
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Exp, double> _0023_003DzY8Uv_M2imvzS6Z9OgQ_003D_003D;

		internal double _0023_003DzwPJdDzXhV3g0FUkau6fInk7j3p9t(Exp _0023_003DzbfrNXYE_003D)
		{
			return Math.Abs(_0023_003DzbfrNXYE_003D._0023_003DzBUjqlpM_003D());
		}
	}

	private sealed class _0023_003DzhN1G_yP69AggrQt6OA_003D_003D : IEnumerable<ISketchBase>, IEnumerable, IEnumerator<ISketchBase>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ISketchBase _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Constraint _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<IdPath>.Enumerator _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerHidden]
		public _0023_003DzhN1G_yP69AggrQt6OA_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				}
			}
			_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = default(List<IdPath>.Enumerator);
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			try
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				Constraint constraint = _0023_003DzopRx0_MBcTQs;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = constraint._ids.GetEnumerator();
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				}
				if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.MoveNext())
				{
					IdPath current = _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Current;
					_0023_003DzezVIuujSK1H9 = constraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzXKRytQoXWc2o(current, 0);
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = default(List<IdPath>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				_0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _0023_003Dza_5rxXxkeiYaHduTng_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -1;
			((IDisposable)_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		private ISketchBase _0023_003Dz_0024CIHY9gGoMBrgxc8xPDtKOYW_uuA5iNScNF2o2mB7k42cUeEL08PqXiNUMR4()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		ISketchBase IEnumerator<ISketchBase>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=z$CIHY9gGoMBrgxc8xPDtKOYW_uuA5iNScNF2o2mB7k42cUeEL08PqXiNUMR4
			return this._0023_003Dz_0024CIHY9gGoMBrgxc8xPDtKOYW_uuA5iNScNF2o2mB7k42cUeEL08PqXiNUMR4();
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
		private IEnumerator<ISketchBase> _0023_003Dzsnj4qtwFB9xoGu32MrlD_xkb3S2ALQrxTZu2P9harSSE2fn7KNKy_0Yd_YOe()
		{
			_0023_003DzhN1G_yP69AggrQt6OA_003D_003D _0023_003DzhN1G_yP69AggrQt6OA_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzhN1G_yP69AggrQt6OA_003D_003D2 = this;
			}
			else
			{
				_0023_003DzhN1G_yP69AggrQt6OA_003D_003D2 = new _0023_003DzhN1G_yP69AggrQt6OA_003D_003D(0);
				_0023_003DzhN1G_yP69AggrQt6OA_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzhN1G_yP69AggrQt6OA_003D_003D2;
		}

		IEnumerator<ISketchBase> IEnumerable<ISketchBase>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zsnj4qtwFB9xoGu32MrlD_xkb3S2ALQrxTZu2P9harSSE2fn7KNKy_0Yd_YOe
			return this._0023_003Dzsnj4qtwFB9xoGu32MrlD_xkb3S2ALQrxTZu2P9harSSE2fn7KNKy_0Yd_YOe();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dzsnj4qtwFB9xoGu32MrlD_xkb3S2ALQrxTZu2P9harSSE2fn7KNKy_0Yd_YOe();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	internal enum option : byte
	{
		Positive,
		Negative
	}

	internal global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Constraint, VisualConstraint> constraintLink;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dzybw_4Fg_003D;

	internal List<IdPath> _ids = new List<IdPath>();

	internal Vector3D[] refPoints = new Vector3D[2];

	private readonly List<Constraint> _usedInConstraints = new List<Constraint>();

	public bool Visible { get; set; } = true;

	internal Constraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		constraintLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Constraint, VisualConstraint>(this);
		_0023_003DzjCETKTg_003D?._0023_003Dz55vCXok_003D(this);
	}

	protected Constraint(Constraint another)
		: base(another)
	{
		constraintLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Constraint, VisualConstraint>(this);
		foreach (IdPath id in another._ids)
		{
			_ids.Add(id.Clone());
		}
		Visible = another.Visible;
	}

	protected Constraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		constraintLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Constraint, VisualConstraint>(this);
		_ids = (List<IdPath>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655439), typeof(List<IdPath>));
		Visible = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510));
	}

	internal VisualConstraint _0023_003DzzRLCjkBKJt17()
	{
		return constraintLink._0023_003DzUtOYa_o_003D();
	}

	internal void _0023_003DzEC3e5jYoyfEe(VisualConstraint _0023_003DzPzO_0024GUk_003D)
	{
		constraintLink._0023_003Dzdlp53MQ_003D(_0023_003DzPzO_0024GUk_003D._0023_003DzhSxXfaw_003D);
	}

	internal void _0023_003DzsiBrP5k_003D(IEnumerable<IdPath> _0023_003DzDay5tlg_003D)
	{
		foreach (IdPath item in _0023_003DzDay5tlg_003D)
		{
			_ids.Add(item);
		}
	}

	internal virtual Enum _0023_003DzO2eKyem9cuf9()
	{
		return option.Positive;
	}

	internal virtual void _0023_003DzDESu9hNNQZcg(Enum _0023_003DzPzO_0024GUk_003D)
	{
	}

	private protected void _0023_003DzRCrpdGA_003D<T>(T _0023_003DzbfrNXYE_003D) where T : SketchCurve
	{
		_0023_003DzbfrNXYE_003D?._0023_003Dz55vCXok_003D(this);
		_ids.Add(_0023_003DzbfrNXYE_003D.ObjectId);
	}

	protected internal void AddObject(ISketchBase o)
	{
		if (o is SketchCurve _0023_003DzbfrNXYE_003D)
		{
			_0023_003DzRCrpdGA_003D(_0023_003DzbfrNXYE_003D);
		}
		if (o is Constraint _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dz55vCXok_003D(_0023_003Dzt_m8zV0_003D);
		}
	}

	private protected void _0023_003Dz55vCXok_003D(Constraint _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzt_m8zV0_003D._usedInConstraints.Add(this);
		_ids.Add(_0023_003Dzt_m8zV0_003D.ObjectId);
	}

	public override void Destroy()
	{
		if (base.IsDestroyed)
		{
			return;
		}
		while (_usedInConstraints.Count > 0)
		{
			_usedInConstraints[0].Destroy();
		}
		base.Destroy();
		for (int i = 0; i < _ids.Count; i++)
		{
			SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(i);
			if (sketchCurve != null)
			{
				sketchCurve._0023_003Dze64dfX0_003D(this);
			}
			else
			{
				_0023_003DzTLROap4_003D(i)?._usedInConstraints.Remove(this);
			}
		}
	}

	private protected override void _0023_003DzAuRWtKw_003D()
	{
	}

	internal virtual void _0023_003DzzzMmR6wZVKHE()
	{
		_0023_003DzBnBmC5F1_Gf3();
	}

	private protected virtual void _0023_003DzBnBmC5F1_Gf3()
	{
		Type type = _0023_003DzO2eKyem9cuf9().GetType();
		string[] names = Enum.GetNames(type);
		if (names.Length < 2)
		{
			return;
		}
		double num = -1.0;
		int num2 = 0;
		for (int i = 0; i < names.Length; i++)
		{
			_0023_003DzDESu9hNNQZcg((Enum)Enum.Parse(type, names[i]));
			double num3 = ((IEnumerable<Exp>)_0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D().ToList()).Sum((Func<Exp, double>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzwPJdDzXhV3g0FUkau6fInk7j3p9t);
			if (num < 0.0 || num3 < num)
			{
				num = num3;
				num2 = i;
			}
		}
		_0023_003DzDESu9hNNQZcg((Enum)Enum.Parse(type, names[num2]));
	}

	internal override void _0023_003Dzqx2DhVY_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655417));
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404), GetType().FullName);
		if (Enum.GetNames(_0023_003DzO2eKyem9cuf9().GetType()).Length >= 2)
		{
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655381), _0023_003DzO2eKyem9cuf9().ToString());
		}
		base._0023_003Dzqx2DhVY_003D(_0023_003Dzzic3a9w_003D);
		foreach (IdPath id in _ids)
		{
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655365));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655090), id.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
		}
		_0023_003Dzzic3a9w_003D.WriteEndElement();
	}

	internal override void _0023_003DzVemZ00E_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		_ids.Clear();
		if (Enum.GetNames(_0023_003DzO2eKyem9cuf9().GetType()).Length >= 2)
		{
			Enum _0023_003DzbfrNXYE_003D = _0023_003DzO2eKyem9cuf9();
			_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655381)].Value._0023_003DzzlWCyhw_003D(ref _0023_003DzbfrNXYE_003D);
			_0023_003DzDESu9hNNQZcg(_0023_003DzbfrNXYE_003D);
		}
		foreach (XmlNode childNode in _0023_003Dzzic3a9w_003D.ChildNodes)
		{
			if (!(childNode.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655099)) || !(childNode.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655365)))
			{
				IdPath idPath = IdPath.From(childNode.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655090)].Value);
				ISketchBase sketchBase = null;
				sketchBase = ((_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().idMapping == null) ? _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzXKRytQoXWc2o(idPath, 0) : _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzCzT7cK4_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().idMapping[idPath.path.Last()]));
				AddObject(sketchBase);
			}
		}
		base._0023_003DzVemZ00E_003D(_0023_003Dzzic3a9w_003D);
	}

	internal SketchCurve _0023_003Dzjrbkyo8_003D(int _0023_003Dz437_00244ak_003D)
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzXKRytQoXWc2o(_ids[_0023_003Dz437_00244ak_003D], 0) as SketchCurve;
	}

	public SketchCurve[] GetEntities()
	{
		int num = _0023_003DzpK4oXctemjLc();
		SketchCurve[] array = new SketchCurve[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003Dzjrbkyo8_003D(i);
		}
		return array;
	}

	[IteratorStateMachine(typeof(_0023_003DzhN1G_yP69AggrQt6OA_003D_003D))]
	internal IEnumerable<ISketchBase> _0023_003DzKb_DhLZ_k_0024NZ()
	{
		return new _0023_003DzhN1G_yP69AggrQt6OA_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal Constraint _0023_003DzTLROap4_003D(int _0023_003Dz437_00244ak_003D)
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzXKRytQoXWc2o(_ids[_0023_003Dz437_00244ak_003D], 0) as Constraint;
	}

	internal int _0023_003DzpK4oXctemjLc()
	{
		return _ids.Count;
	}

	internal bool _0023_003Dz1uzJIBKKgWz8<T>(int _0023_003DziLqibCI_003D) where T : SketchCurve
	{
		int num = 0;
		for (int i = 0; i < _0023_003DzpK4oXctemjLc(); i++)
		{
			if (_0023_003Dzjrbkyo8_003D(i).GetType() == typeof(T))
			{
				num++;
			}
		}
		return num == _0023_003DziLqibCI_003D;
	}

	internal SketchCurve _0023_003DzCobWdDk49r6E<T>(int _0023_003DzyzK8swU_003D) where T : SketchCurve
	{
		int num = 0;
		for (int i = 0; i < _0023_003DzpK4oXctemjLc(); i++)
		{
			SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(i);
			if (!(sketchCurve.GetType() != typeof(T)))
			{
				if (num == _0023_003DzyzK8swU_003D)
				{
					return sketchCurve;
				}
				num++;
			}
		}
		return null;
	}

	internal virtual Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D)
	{
		return null;
	}

	private protected void _0023_003Dz9x52aV0_003D(int _0023_003Dz437_00244ak_003D, SketchCurve _0023_003DzbfrNXYE_003D)
	{
		_0023_003Dzjrbkyo8_003D(_0023_003Dz437_00244ak_003D)?._0023_003Dze64dfX0_003D(this);
		_ids[_0023_003Dz437_00244ak_003D] = _0023_003DzbfrNXYE_003D.ObjectId;
		_0023_003Dzjrbkyo8_003D(_0023_003Dz437_00244ak_003D)?._0023_003Dz55vCXok_003D(this);
		_0023_003Dzybw_4Fg_003D = true;
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!base._0023_003Dztl9hmdI_003D())
		{
			return _0023_003Dzybw_4Fg_003D;
		}
		return true;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new ConstraintSurrogate(this);
	}

	internal bool _0023_003DzzBmoNc__0024b_i9(SketchCurve _0023_003Dzt9CFZSo_003D, SketchCurve _0023_003Dz1w6W_Pc_003D)
	{
		bool result = false;
		IdPath objectId = _0023_003Dzt9CFZSo_003D.ObjectId;
		for (int i = 0; i < _ids.Count; i++)
		{
			if (!(_ids[i] != objectId))
			{
				_0023_003Dz9x52aV0_003D(i, _0023_003Dz1w6W_Pc_003D);
				result = true;
			}
		}
		return result;
	}

	internal _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzNY5YUv279_SW()
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane;
	}

	internal Transformation _0023_003Dzw_0024BlG4ni0FuJ8eKFhw_003D_003D(Vector3D _0023_003Dzop_0024it39_ZL_0024_, Vector3D _0023_003DzrKXgunQO4p3G, Vector3D _0023_003DzR6UMaNQ_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		Vector3D vector3D = _0023_003Dzop_0024it39_ZL_0024_;
		Vector3D vector3D2 = _0023_003DzrKXgunQO4p3G;
		Vector3D vector3D3 = _0023_003DzR6UMaNQ_003D;
		if (_0023_003Dzrgqz890sj_0024X9 != null)
		{
			vector3D = _0023_003Dzrgqz890sj_0024X9._0023_003Dzr2vS35aBVpn3(vector3D);
			vector3D2 = _0023_003Dzrgqz890sj_0024X9._0023_003Dzr2vS35aBVpn3(vector3D2);
			vector3D3 = _0023_003Dzrgqz890sj_0024X9._0023_003Dzr2vS35aBVpn3(vector3D3);
		}
		Vector3D vector3D4 = vector3D2 - vector3D;
		vector3D4.Normalize();
		Vector3D vector3D5 = vector3D + vector3D4 * Vector3D.Dot(vector3D3 - vector3D, vector3D4);
		Vector3D vector3D6 = vector3D5 - vector3D3;
		vector3D6.Normalize();
		Vector3D vector3D7 = vector3D4;
		Vector3D.Cross(vector3D6, vector3D7).Normalize();
		Vector3D vector3D8 = (vector3D3 + vector3D5) * 0.5;
		return new Align3D(Plane.XY, new Plane(new Point3D(vector3D8.ToArray()), vector3D6, vector3D7));
	}

	internal Transformation _0023_003DzfMtoRYsslA7_(Vector3D _0023_003DzHb_bLrY_003D, Vector3D _0023_003DzooV0J_0024g_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return new Translation((_0023_003DzHb_bLrY_003D + _0023_003DzooV0J_0024g_003D) / 2.0);
		}
		Vector3D b = _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D();
		Vector3D vector3D = _0023_003Dzrgqz890sj_0024X9._0023_003Dzr2vS35aBVpn3(_0023_003DzHb_bLrY_003D);
		Vector3D vector3D2 = _0023_003Dzrgqz890sj_0024X9._0023_003Dzr2vS35aBVpn3(_0023_003DzooV0J_0024g_003D);
		Vector3D vector3D3 = vector3D2 - vector3D;
		vector3D3.Normalize();
		Vector3D vector3D4 = Vector3D.Cross(vector3D3, b);
		vector3D4.Normalize();
		Vector3D vector3D5 = (vector3D + vector3D2) * 0.5;
		return new Align3D(Plane.XY, new Plane(new Point3D(vector3D5.ToArray()), vector3D3, vector3D4));
	}

	private protected Vector3D _0023_003DzT2c33_0024R33ol4(Vector3D _0023_003DzB68dg9Q_003D, Vector3D _0023_003DzDVubtvo_003D, Vector3D _0023_003DzFj_0024IqDQ_003D)
	{
		Vector3D vector3D = _0023_003DzFj_0024IqDQ_003D - _0023_003DzDVubtvo_003D;
		double num = Vector3D.Dot(_0023_003DzB68dg9Q_003D - _0023_003DzDVubtvo_003D, vector3D) / Vector3D.Dot(vector3D, vector3D);
		return _0023_003DzDVubtvo_003D + vector3D * num;
	}

	private double _0023_003DzMEdRYUbyvlctvj_e4w_003D_003D(Vector3D _0023_003DzB68dg9Q_003D, Vector3D _0023_003DzDVubtvo_003D, Vector3D _0023_003DzFj_0024IqDQ_003D)
	{
		Vector3D vector3D = _0023_003DzFj_0024IqDQ_003D - _0023_003DzDVubtvo_003D;
		return Vector3D.Dot(_0023_003DzB68dg9Q_003D - _0023_003DzDVubtvo_003D, vector3D) / Vector3D.Dot(vector3D, vector3D);
	}

	private Vector3D _0023_003DzcLVz9FLcmeRyIzd48Q_003D_003D(Vector3D _0023_003Dzctaqbks_003D)
	{
		if (_0023_003DzNY5YUv279_SW() != null)
		{
			return _0023_003DzNY5YUv279_SW()._0023_003DzhuTGsQI_003D();
		}
		return _0023_003Dzctaqbks_003D;
	}

	internal Vector3D _0023_003DzAS0chZ4fwzsLqtZoFQ_003D_003D(Vector3D _0023_003Dzctaqbks_003D)
	{
		if (_0023_003DzNY5YUv279_SW() != null)
		{
			return _0023_003DzNY5YUv279_SW()._0023_003DzhuTGsQI_003D();
		}
		return _0023_003Dzctaqbks_003D;
	}

	internal static Constraint _0023_003DzSfMvOM4_003D(string _0023_003DzuAHwq4M_003D, SketchInternal _0023_003DzjCETKTg_003D)
	{
		Type[] types = new Type[1] { typeof(SketchInternal) };
		object[] parameters = new object[1] { _0023_003DzjCETKTg_003D };
		Type type = Type.GetType(_0023_003DzuAHwq4M_003D);
		if (type == null)
		{
			return null;
		}
		return type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, types, null).Invoke(parameters) as Constraint;
	}

	public override object Clone()
	{
		return new Constraint(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655439), _ids);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510), Visible);
	}
}
