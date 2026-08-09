using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class PerpendicularMate : Mate
{
	internal PerpendicularMate(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan)
	{
	}

	protected internal PerpendicularMate(PerpendicularMateSurrogate surrogate)
		: base(surrogate)
	{
		UpdateName();
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new PerpendicularMateSurrogate(this);
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656831) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
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
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector expVector = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector + expVector2);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector - expVector2);
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData2)
			{
				ExpVector _0023_003DzjbqS1qE_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D2, _0023_003Dz1v6oPQk_003D2));
			}
			else if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData)
			{
				ExpVector _0023_003DzjbqS1qE_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData.AxisZ);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D3, _0023_003Dz1v6oPQk_003D3));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector _0023_003DzjbqS1qE_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D4, _0023_003Dz1v6oPQk_003D4));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is RevolvedConstraintData revolvedConstraintData2)
		{
			if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData3)
			{
				ExpVector _0023_003DzjbqS1qE_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D5, _0023_003Dz1v6oPQk_003D5));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData3)
			{
				ExpVector _0023_003DzjbqS1qE_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D6, _0023_003Dz1v6oPQk_003D6));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData4 && _0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData5)
		{
			ExpVector _0023_003DzjbqS1qE_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
			ExpVector _0023_003Dz1v6oPQk_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Direction);
			_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D7, _0023_003Dz1v6oPQk_003D7));
		}
	}

	public override bool IsFlippable()
	{
		if ((_0023_003DzgM8TwmWg2tsG is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData) && _0023_003DzdH0ws20LmJv0 is LinearConstraintData) || (_0023_003DzgM8TwmWg2tsG is LinearConstraintData && _0023_003DzdH0ws20LmJv0 is PlanarConstraintData planarConstraintData2 && !(planarConstraintData2 is RevolvedConstraintData)))
		{
			return true;
		}
		return false;
	}
}
