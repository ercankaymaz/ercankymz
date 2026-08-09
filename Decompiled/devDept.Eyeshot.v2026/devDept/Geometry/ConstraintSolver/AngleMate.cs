using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class AngleMate : Mate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;

	public double Angle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
		}
	}

	internal AngleMate(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D, double _0023_003DzPzO_0024GUk_003D = 0.0, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan)
	{
		_0023_003DzXMb_0024_0024gSbeddO(_0023_003DzPzO_0024GUk_003D);
	}

	protected internal AngleMate(AngleMateSurrogate surrogate)
		: base(surrogate)
	{
		_0023_003DzXMb_0024_0024gSbeddO(surrogate.Angle);
		UpdateName();
	}

	internal void _0023_003DzXMb_0024_0024gSbeddO(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new AngleMateSurrogate(this);
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655238) + Angle + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655478) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
		if (base.Flipped)
		{
			_0023_003DzS_00246o7tc_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655488);
		}
	}

	protected override void UpdateEquationsInternal()
	{
		_0023_003DzKQRQajdIkCVIaRin_0024tJtZVabqBH8(out var _0023_003Dz5DNWc7LoRIbU, out var _0023_003DzsIMS3mX44piL, out var _, out var _);
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2 = _0023_003Dz5DNWc7LoRIbU.Component._0023_003DzCvxG2A3KpWd8();
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3 = _0023_003DzsIMS3mX44piL.Component._0023_003DzCvxG2A3KpWd8();
		if (_0023_003Dz5DNWc7LoRIbU is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is PlanarConstraintData planarConstraintData2 && !(planarConstraintData2 is RevolvedConstraintData))
			{
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(planarConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector _0023_003DzjbqS1qE_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D2, _0023_003Dz1v6oPQk_003D2) - Math.Sin(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D2, _0023_003Dz1v6oPQk_003D2) + Math.Sin(Utility.DegToRad(Angle)));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData2)
			{
				ExpVector _0023_003DzjbqS1qE_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D3, _0023_003Dz1v6oPQk_003D3) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D3, _0023_003Dz1v6oPQk_003D3) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData)
			{
				ExpVector _0023_003DzjbqS1qE_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D4, _0023_003Dz1v6oPQk_003D4) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D4, _0023_003Dz1v6oPQk_003D4) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector _0023_003DzjbqS1qE_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D5, _0023_003Dz1v6oPQk_003D5) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D5, _0023_003Dz1v6oPQk_003D5) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is RevolvedConstraintData revolvedConstraintData2)
		{
			if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData3)
			{
				ExpVector _0023_003DzjbqS1qE_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D6, _0023_003Dz1v6oPQk_003D6) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D6, _0023_003Dz1v6oPQk_003D6) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData3)
			{
				ExpVector _0023_003DzjbqS1qE_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D7, _0023_003Dz1v6oPQk_003D7) - Math.Cos(Utility.DegToRad(Angle)));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D7, _0023_003Dz1v6oPQk_003D7) + Math.Cos(Utility.DegToRad(Angle)));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData4 && _0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData5)
		{
			ExpVector _0023_003DzjbqS1qE_003D8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
			ExpVector _0023_003Dz1v6oPQk_003D8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Direction);
			if (base.Flipped)
			{
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D8, _0023_003Dz1v6oPQk_003D8) - Math.Cos(Utility.DegToRad(Angle)));
			}
			else
			{
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D8, _0023_003Dz1v6oPQk_003D8) + Math.Cos(Utility.DegToRad(Angle)));
			}
		}
	}

	public void ChangeAngle(double newAngle)
	{
		_0023_003DzXMb_0024_0024gSbeddO(newAngle);
		_0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D();
	}

	public override bool IsFlippable()
	{
		return true;
	}
}
