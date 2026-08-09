using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class ParallelMate : Mate
{
	internal ParallelMate(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan)
	{
	}

	protected internal ParallelMate(ParallelMateSurrogate surrogate)
		: base(surrogate)
	{
		UpdateName();
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new ParallelMateSurrogate(this);
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656861) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
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
				ExpVector expVector = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(planarConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector + expVector2);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector - expVector2);
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D));
			}
		}
		if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData2)
			{
				ExpVector expVector3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector3 + expVector4);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector3 - expVector4);
				}
			}
			else if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData)
			{
				ExpVector expVector5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector5 + expVector6);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector5 - expVector6);
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector expVector7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 + expVector8);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 - expVector8);
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is RevolvedConstraintData revolvedConstraintData2)
		{
			if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData3)
			{
				ExpVector expVector9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector expVector10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector9 + expVector10);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector9 - expVector10);
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData3)
			{
				ExpVector expVector11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisZ);
				ExpVector expVector12 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector11 + expVector12);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector11 - expVector12);
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData4 && _0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData5)
		{
			ExpVector expVector13 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
			ExpVector expVector14 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Direction);
			if (base.Flipped)
			{
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector13 + expVector14);
			}
			else
			{
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector13 - expVector14);
			}
		}
	}

	public override bool IsFlippable()
	{
		if ((_0023_003DzgM8TwmWg2tsG is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData) && _0023_003DzdH0ws20LmJv0 is LinearConstraintData) || (_0023_003DzgM8TwmWg2tsG is LinearConstraintData && _0023_003DzdH0ws20LmJv0 is PlanarConstraintData planarConstraintData2 && !(planarConstraintData2 is RevolvedConstraintData)))
		{
			return false;
		}
		return true;
	}
}
