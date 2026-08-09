using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public abstract class Mate
{
	private delegate _0023_003DzWWgGxds_003D _0023_003Dz0pKRdyyKu839OX4_00243A_003D_003D<_0023_003DzWWgGxds_003D>(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D);

	private sealed class _0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D
	{
		public bool _0023_003Dzbu8BV15Qqzan;

		internal ParallelMate _0023_003Dz6UxQv6Ubp6RJsva_z1quvU4_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new ParallelMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D
	{
		public double _0023_003DzYUMqwZQ_003D;

		public bool _0023_003Dzbu8BV15Qqzan;

		internal DistanceMate _0023_003DzYojGundFADw1_00242youvWujSc_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new DistanceMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzYUMqwZQ_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D
	{
		public bool _0023_003Dzbu8BV15Qqzan;

		internal CoincidentMate _0023_003DzdMIPUUReGBrJYSvUMf6SNG0ircklfJmRjw_003D_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new CoincidentMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003Dzh_1lgvsiK9pRoIXcMrOMAwk_003D
	{
		public double _0023_003Dz6pajdGM_003D;

		public bool _0023_003Dzbu8BV15Qqzan;

		internal AngleMate _0023_003Dz_0024QJb6FHWODP6HyDCkJi4124_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new AngleMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dz6pajdGM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D
	{
		public bool _0023_003Dzbu8BV15Qqzan;

		internal PerpendicularMate _0023_003DzTbhFhvhJGLkgC8R2QzmqkbDSzzrCC_0024xt2k1VnLA_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new PerpendicularMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D
	{
		public bool _0023_003Dzbu8BV15Qqzan;

		internal ConcentricMate _0023_003DzU2XsbGKEFg75q2OG_00242n2FrLiqOx9da9srg_003D_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new ConcentricMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	private sealed class _0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D
	{
		public bool _0023_003Dzbu8BV15Qqzan;

		internal TangentMate _0023_003DzyaJo2Wa82amFrNTJripOzIE_003D(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D)
		{
			return new TangentMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzGiZHZwLvm6Pc0NpYm6Vd_po_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003DzS_00246o7tc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ConstraintData _0023_003DzgM8TwmWg2tsG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ConstraintData _0023_003DzdH0ws20LmJv0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<ExpVector> _0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Exp> _0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Dictionary<Param, Exp>> _0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Param> _0023_003DzBlBnvuA_003D;

	public bool Flipped
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGiZHZwLvm6Pc0NpYm6Vd_po_003D;
		}
	}

	public BlockReference Component1 => _0023_003DzgM8TwmWg2tsG.Component;

	public BlockReference Component2 => _0023_003DzdH0ws20LmJv0.Component;

	internal Mate(ConstraintData _0023_003DzLlLRwFw_003D, ConstraintData _0023_003Dz2QNSBWU_003D, bool _0023_003Dzbu8BV15Qqzan = false)
	{
		_0023_003DzgM8TwmWg2tsG = _0023_003DzLlLRwFw_003D;
		_0023_003DzdH0ws20LmJv0 = _0023_003Dz2QNSBWU_003D;
		_0023_003Dz0HVxh14IoLpq8Z8kpg_003D_003D(_0023_003Dzbu8BV15Qqzan);
		UpdateName();
		_0023_003DzA7sZpY4FueHg();
		Telemetry.Instance.AddUsage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656869), Telemetry.moduleType.Generic);
	}

	protected internal Mate(MateSurrogate surrogate)
		: this(surrogate.constraintData1, surrogate.constraintData2, surrogate.Flipped)
	{
	}

	internal void _0023_003Dz0HVxh14IoLpq8Z8kpg_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzGiZHZwLvm6Pc0NpYm6Vd_po_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal double _0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D()
	{
		return Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzM_0024o1stE_003D;
	}

	internal double _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D()
	{
		return Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzM_0024o1stE_003D;
	}

	public abstract MateSurrogate ConvertToSurrogate();

	public void Flip()
	{
		if (IsFlippable())
		{
			_0023_003Dz0HVxh14IoLpq8Z8kpg_003D_003D(!Flipped);
			_0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D();
		}
	}

	public abstract bool IsFlippable();

	public override string ToString()
	{
		return _0023_003DzS_00246o7tc_003D;
	}

	internal void _0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D()
	{
		_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D = new List<ExpVector>();
		_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D = new List<Exp>();
		UpdateEquationsInternal();
		UpdateDerivatives();
		UpdateName();
	}

	protected abstract void UpdateEquationsInternal();

	protected abstract void UpdateName();

	protected void UpdateDerivatives()
	{
		_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D = new List<Dictionary<Param, Exp>>();
		foreach (ExpVector item in _0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D)
		{
			Dictionary<Param, Exp> dictionary = new Dictionary<Param, Exp>();
			Dictionary<Param, Exp> dictionary2 = new Dictionary<Param, Exp>();
			Dictionary<Param, Exp> dictionary3 = new Dictionary<Param, Exp>();
			foreach (Param item2 in _0023_003DzBlBnvuA_003D)
			{
				dictionary.Add(item2, item.x._0023_003DzSOlfnhbkZ12J(item2));
				dictionary2.Add(item2, item.y._0023_003DzSOlfnhbkZ12J(item2));
				dictionary3.Add(item2, item.z._0023_003DzSOlfnhbkZ12J(item2));
			}
			_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Add(dictionary);
			_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Add(dictionary2);
			_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Add(dictionary3);
		}
		foreach (Exp item3 in _0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D)
		{
			Dictionary<Param, Exp> dictionary4 = new Dictionary<Param, Exp>();
			foreach (Param item4 in _0023_003DzBlBnvuA_003D)
			{
				dictionary4.Add(item4, item3._0023_003DzSOlfnhbkZ12J(item4));
			}
			_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Add(dictionary4);
		}
	}

	private void _0023_003DzA7sZpY4FueHg()
	{
		_0023_003DzBlBnvuA_003D = Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzGVWngirLnmOL().Concat(Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzGVWngirLnmOL())
			.ToList();
	}

	internal void _0023_003DzKQRQajdIkCVIaRin_0024tJtZVabqBH8(out ConstraintData _0023_003Dz5DNWc7LoRIbU, out ConstraintData _0023_003DzsIMS3mX44piL, out double _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D, out double _0023_003Dznu9klRRS___00245FhlvqA_003D_003D)
	{
		if (_0023_003DzgM8TwmWg2tsG.Order <= _0023_003DzdH0ws20LmJv0.Order)
		{
			_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D = _0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D();
			_0023_003Dznu9klRRS___00245FhlvqA_003D_003D = _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D();
			_0023_003Dz5DNWc7LoRIbU = _0023_003DzgM8TwmWg2tsG;
			_0023_003DzsIMS3mX44piL = _0023_003DzdH0ws20LmJv0;
		}
		else
		{
			_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D = _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D();
			_0023_003Dznu9klRRS___00245FhlvqA_003D_003D = _0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D();
			_0023_003Dz5DNWc7LoRIbU = _0023_003DzdH0ws20LmJv0;
			_0023_003DzsIMS3mX44piL = _0023_003DzgM8TwmWg2tsG;
		}
	}

	private static T _0023_003DzPZCaHdFQiKqM<T>(IMateable _0023_003DzBjCSW4c_003D, Stack<BlockReference> _0023_003DzUEXALWo_003D, IMateable _0023_003DzKwRxV8s_003D, Stack<BlockReference> _0023_003Dz7URySbs_003D, _0023_003Dz0pKRdyyKu839OX4_00243A_003D_003D<T> _0023_003Dz7ZOIbM9mmmTq_6Cuuw_003D_003D) where T : Mate
	{
		ConstraintData constraintData = _0023_003DzBjCSW4c_003D._0023_003DzZLWpXBA94C8J(_0023_003DzUEXALWo_003D);
		ConstraintData constraintData2 = _0023_003DzKwRxV8s_003D._0023_003DzZLWpXBA94C8J(_0023_003Dz7URySbs_003D);
		if (constraintData == null || constraintData2 == null)
		{
			return null;
		}
		Mate mate = _0023_003Dz7ZOIbM9mmmTq_6Cuuw_003D_003D(constraintData, constraintData2);
		mate._0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D();
		if (mate._0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Count != 0 || mate._0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Count != 0)
		{
			return (T)mate;
		}
		return null;
	}

	public static AngleMate CreateAngleMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, double angle = 0.0, bool flip = false)
	{
		_0023_003Dzh_1lgvsiK9pRoIXcMrOMAwk_003D CS_0024_003C_003E8__locals4 = new _0023_003Dzh_1lgvsiK9pRoIXcMrOMAwk_003D();
		CS_0024_003C_003E8__locals4._0023_003Dz6pajdGM_003D = angle;
		CS_0024_003C_003E8__locals4._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, (ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D) => new AngleMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, CS_0024_003C_003E8__locals4._0023_003Dz6pajdGM_003D, CS_0024_003C_003E8__locals4._0023_003Dzbu8BV15Qqzan));
	}

	public static ConcentricMate CreateConcentricMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D CS_0024_003C_003E8__locals2 = new _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D();
		CS_0024_003C_003E8__locals2._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, (ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D) => new ConcentricMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, CS_0024_003C_003E8__locals2._0023_003Dzbu8BV15Qqzan));
	}

	public static CoincidentMate CreateCoincidentMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2 = new _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D();
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzdMIPUUReGBrJYSvUMf6SNG0ircklfJmRjw_003D_003D);
	}

	public static DistanceMate CreateDistanceMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, double distance = 0.0, bool flip = false)
	{
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D CS_0024_003C_003E8__locals4 = new _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D();
		CS_0024_003C_003E8__locals4._0023_003DzYUMqwZQ_003D = distance;
		CS_0024_003C_003E8__locals4._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, (ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D) => new DistanceMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, CS_0024_003C_003E8__locals4._0023_003DzYUMqwZQ_003D, CS_0024_003C_003E8__locals4._0023_003Dzbu8BV15Qqzan));
	}

	public static ParallelMate CreateParallelMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		_0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D _0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D2 = new _0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D();
		_0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D2._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, _0023_003DzM_0024EYrXCz_0024vOPJCwCDn_0024XX7U_003D2._0023_003Dz6UxQv6Ubp6RJsva_z1quvU4_003D);
	}

	public static PerpendicularMate CreatePerpendicularMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D CS_0024_003C_003E8__locals2 = new _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D();
		CS_0024_003C_003E8__locals2._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, (ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D) => new PerpendicularMate(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, CS_0024_003C_003E8__locals2._0023_003Dzbu8BV15Qqzan));
	}

	public static TangentMate CreateTangentMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		_0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D _0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D2 = new _0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D();
		_0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D2._0023_003Dzbu8BV15Qqzan = flip;
		return _0023_003DzPZCaHdFQiKqM(obj1, parents1, obj2, parents2, _0023_003DznxQ038nPgtnLfPhnWmJE7Ro_003D2._0023_003DzyaJo2Wa82amFrNTJripOzIE_003D);
	}
}
