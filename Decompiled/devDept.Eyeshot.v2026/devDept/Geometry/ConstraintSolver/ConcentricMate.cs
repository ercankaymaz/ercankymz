using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class ConcentricMate : Mate
{
	internal ConcentricMate(ConstraintData _0023_003DzLlLRwFw_003D, ConstraintData _0023_003Dz2QNSBWU_003D, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003DzLlLRwFw_003D, _0023_003Dz2QNSBWU_003D, _0023_003Dzbu8BV15Qqzan)
	{
	}

	protected internal ConcentricMate(ConcentricMateSurrogate surrogate)
		: base(surrogate)
	{
		UpdateName();
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655454) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
		if (base.Flipped)
		{
			_0023_003DzS_00246o7tc_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655488);
		}
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new ConcentricMateSurrogate(this);
	}

	protected override void UpdateEquationsInternal()
	{
		_0023_003DzKQRQajdIkCVIaRin_0024tJtZVabqBH8(out var _0023_003Dz5DNWc7LoRIbU, out var _0023_003DzsIMS3mX44piL, out var _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D, out var _0023_003Dznu9klRRS___00245FhlvqA_003D_003D);
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2 = _0023_003Dz5DNWc7LoRIbU.Component._0023_003DzCvxG2A3KpWd8();
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3 = _0023_003DzsIMS3mX44piL.Component._0023_003DzCvxG2A3KpWd8();
		if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData2)
			{
				ExpVector expVector = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector + expVector2);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector - expVector2);
				}
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector4, _0023_003Dz1v6oPQk_003D) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector4, _0023_003Dz1v6oPQk_003D2) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector5 - expVector6, _0023_003Dz1v6oPQk_003D3) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector5 - expVector6, _0023_003Dz1v6oPQk_003D4) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData)
			{
				ExpVector expVector7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 + expVector8);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 - expVector8);
				}
				ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData.Origin) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector9 - expVector10, _0023_003Dz1v6oPQk_003D5) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector9 - expVector10, _0023_003Dz1v6oPQk_003D6) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector expVector11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector12 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector11 + expVector12);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector11 - expVector12);
				}
				ExpVector _0023_003Dz1v6oPQk_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector13 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector14 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector14 - expVector13, _0023_003Dz1v6oPQk_003D8) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector14 - expVector13, _0023_003Dz1v6oPQk_003D7) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData)
			{
				ExpVector expVector15 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector16 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector15 + expVector16);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector15 - expVector16);
				}
				ExpVector _0023_003Dz1v6oPQk_003D9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector17 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector18 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector18 - expVector17, _0023_003Dz1v6oPQk_003D9) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector18 - expVector17, _0023_003Dz1v6oPQk_003D10) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D12 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisY);
				ExpVector expVector19 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector20 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D11) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D12) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is SphericalConstraintData sphericalConstraintData2)
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData3)
			{
				ExpVector _0023_003Dz1v6oPQk_003D13 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(cylindricalConstraintData3.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D14 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(cylindricalConstraintData3.AxisY);
				ExpVector expVector21 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector22 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(cylindricalConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector21 - expVector22, _0023_003Dz1v6oPQk_003D13) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector21 - expVector22, _0023_003Dz1v6oPQk_003D14) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData3)
			{
				ExpVector expVector23 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector24 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector23 - expVector24) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData2)
			{
				ExpVector _0023_003Dz1v6oPQk_003D15 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D16 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData2.AxisY);
				ExpVector expVector25 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector26 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData2.Origin) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector25 - expVector26, _0023_003Dz1v6oPQk_003D15) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector25 - expVector26, _0023_003Dz1v6oPQk_003D16) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector expVector27 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector28 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Start) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				ExpVector _0023_003Dz1v6oPQk_003D17 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector27 - expVector28, _0023_003Dz1v6oPQk_003D17) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData2)
			{
				ExpVector _0023_003Dz1v6oPQk_003D18 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData2.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D19 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData2.AxisY);
				ExpVector expVector29 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector30 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData2.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector29 - expVector30, _0023_003Dz1v6oPQk_003D18) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector29 - expVector30, _0023_003Dz1v6oPQk_003D19) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData2)
			{
				ExpVector expVector31 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector32 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData2.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector32 - expVector31) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is RevolvedConstraintData revolvedConstraintData3)
		{
			if (_0023_003DzsIMS3mX44piL is RevolvedConstraintData revolvedConstraintData4)
			{
				ExpVector expVector33 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				ExpVector expVector34 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData4.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector33 + expVector34);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector33 - expVector34);
				}
				ExpVector _0023_003Dz1v6oPQk_003D20 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D21 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisY);
				ExpVector expVector35 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector36 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(revolvedConstraintData4.Origin) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector35 - expVector36, _0023_003Dz1v6oPQk_003D20) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector35 - expVector36, _0023_003Dz1v6oPQk_003D21) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData3)
			{
				ExpVector expVector37 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				ExpVector expVector38 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector37 + expVector38);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector37 - expVector38);
				}
				ExpVector _0023_003Dz1v6oPQk_003D22 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D23 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisY);
				ExpVector expVector39 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector40 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector40 - expVector39, _0023_003Dz1v6oPQk_003D23) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector40 - expVector39, _0023_003Dz1v6oPQk_003D22) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData3)
			{
				ExpVector expVector41 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisZ);
				ExpVector expVector42 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData3.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector41 + expVector42);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector41 - expVector42);
				}
				ExpVector _0023_003Dz1v6oPQk_003D24 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D25 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisY);
				ExpVector expVector43 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector44 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector44 - expVector43, _0023_003Dz1v6oPQk_003D24) * (_0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D() + _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D()));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector44 - expVector43, _0023_003Dz1v6oPQk_003D25) * (_0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D() + _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D()));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData3)
			{
				ExpVector _0023_003Dz1v6oPQk_003D26 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D27 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.AxisY);
				ExpVector expVector45 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(revolvedConstraintData3.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector46 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData3.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector45 - expVector46, _0023_003Dz1v6oPQk_003D26) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector45 - expVector46, _0023_003Dz1v6oPQk_003D27) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData4)
		{
			if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData5)
			{
				ExpVector expVector47 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
				ExpVector expVector48 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector47 + expVector48);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector47 - expVector48);
				}
				ExpVector expVector49 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Start) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector50 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Start) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector49 - expVector50, expVector47) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData4)
			{
				ExpVector expVector51 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
				ExpVector expVector52 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector52 + expVector51);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector52 - expVector51);
				}
				ExpVector _0023_003Dz1v6oPQk_003D28 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.AxisX);
				ExpVector _0023_003Dz1v6oPQk_003D29 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.AxisY);
				ExpVector expVector53 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Start) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector54 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector53 - expVector54, _0023_003Dz1v6oPQk_003D28) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector53 - expVector54, _0023_003Dz1v6oPQk_003D29) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CircleConstraintData circleConstraintData5 && _0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData6)
		{
			ExpVector expVector55 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData5.AxisZ);
			ExpVector expVector56 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData6.AxisZ);
			if (base.Flipped)
			{
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector55 + expVector56);
			}
			else
			{
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector55 - expVector56);
			}
			ExpVector _0023_003Dz1v6oPQk_003D30 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData5.AxisX);
			ExpVector _0023_003Dz1v6oPQk_003D31 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData5.AxisY);
			ExpVector expVector57 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData5.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
			ExpVector expVector58 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData6.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
			_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector57 - expVector58, _0023_003Dz1v6oPQk_003D30) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector57 - expVector58, _0023_003Dz1v6oPQk_003D31) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
		}
	}

	public override bool IsFlippable()
	{
		if ((_0023_003DzgM8TwmWg2tsG is SphericalConstraintData sphericalConstraintData && !(sphericalConstraintData is CylindricalConstraintData)) || (_0023_003DzdH0ws20LmJv0 is SphericalConstraintData sphericalConstraintData2 && !(sphericalConstraintData2 is CylindricalConstraintData)) || _0023_003DzgM8TwmWg2tsG is PointConstraintData || _0023_003DzdH0ws20LmJv0 is PointConstraintData)
		{
			return false;
		}
		return true;
	}
}
