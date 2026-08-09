using System;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class TangentMate : Mate
{
	internal TangentMate(ConstraintData _0023_003DzLlLRwFw_003D, ConstraintData _0023_003Dz2QNSBWU_003D, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003DzLlLRwFw_003D, _0023_003Dz2QNSBWU_003D, _0023_003Dzbu8BV15Qqzan)
	{
	}

	protected internal TangentMate(TangentMateSurrogate surrogate)
		: base(surrogate)
	{
		UpdateName();
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657212) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
		if (base.Flipped)
		{
			_0023_003DzS_00246o7tc_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655488);
		}
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new TangentMateSurrogate(this);
	}

	protected override void UpdateEquationsInternal()
	{
		_0023_003DzKQRQajdIkCVIaRin_0024tJtZVabqBH8(out var _0023_003Dz5DNWc7LoRIbU, out var _0023_003DzsIMS3mX44piL, out var _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D, out var _0023_003Dznu9klRRS___00245FhlvqA_003D_003D);
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2 = _0023_003Dz5DNWc7LoRIbU.Component._0023_003DzCvxG2A3KpWd8();
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3 = _0023_003DzsIMS3mX44piL.Component._0023_003DzCvxG2A3KpWd8();
		if (_0023_003Dz5DNWc7LoRIbU is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData && !(cylindricalConstraintData is ConicalConstraintData) && !(cylindricalConstraintData is ToroidalConstraintData))
			{
				ExpVector expVector = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector, _0023_003Dz1v6oPQk_003D));
				ExpVector expVector2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector2, expVector) + cylindricalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector2, expVector) - cylindricalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData && !(sphericalConstraintData is CylindricalConstraintData))
			{
				ExpVector _0023_003Dz1v6oPQk_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector5 - expVector4, _0023_003Dz1v6oPQk_003D2) - sphericalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector5 - expVector4, _0023_003Dz1v6oPQk_003D2) + sphericalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is ConicalConstraintData conicalConstraintData)
			{
				ExpVector expVector6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector6, _0023_003Dz1v6oPQk_003D3) - Math.Sin(conicalConstraintData.HalfAngle));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector6, _0023_003Dz1v6oPQk_003D3) + Math.Sin(conicalConstraintData.HalfAngle));
				}
				ExpVector expVector7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData.Tip) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector8 - expVector7, expVector6) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData2 && !(cylindricalConstraintData2 is ConicalConstraintData) && !(cylindricalConstraintData2 is ToroidalConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData3 && !(cylindricalConstraintData3 is ConicalConstraintData) && !(cylindricalConstraintData3 is ToroidalConstraintData))
			{
				ExpVector expVector9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector expVector10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData3.AxisZ);
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector9 - expVector10);
				ExpVector expVector11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector12 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					double num = Math.Abs(cylindricalConstraintData2.Radius - cylindricalConstraintData3.Radius);
					if (num < 1E-12)
					{
						ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisX);
						ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisY);
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector11 - expVector12, _0023_003Dz1v6oPQk_003D4) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector11 - expVector12, _0023_003Dz1v6oPQk_003D5) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
					else
					{
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector11 - expVector12, expVector9)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector11 - expVector12, expVector9)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData2.Radius - cylindricalConstraintData3.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData2 && !(sphericalConstraintData2 is CylindricalConstraintData))
			{
				ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector expVector13 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector14 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					double num2 = Math.Abs(cylindricalConstraintData2.Radius - sphericalConstraintData2.Radius);
					if (num2 < 1E-12)
					{
						ExpVector _0023_003Dz1v6oPQk_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisX);
						ExpVector _0023_003Dz1v6oPQk_003D8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisY);
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector13 - expVector14, _0023_003Dz1v6oPQk_003D7) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector13 - expVector14, _0023_003Dz1v6oPQk_003D8) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
					else
					{
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector13 - expVector14, _0023_003Dz1v6oPQk_003D6)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num2) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector13 - expVector14, _0023_003Dz1v6oPQk_003D6)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData2.Radius - sphericalConstraintData2.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				ExpVector expVector15 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector16 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((Exp._0023_003Dz0v89Hn0_003D(ExpVector._0023_003DzBWYOAtM_003D(expVector16 - expVector15, ExpVector._0023_003DzyJipUOg_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D9))) - cylindricalConstraintData2.Radius * ExpVector._0023_003DzyJipUOg_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D9)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D()) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else
		{
			if (!(_0023_003Dz5DNWc7LoRIbU is SphericalConstraintData sphericalConstraintData3) || sphericalConstraintData3 is CylindricalConstraintData)
			{
				return;
			}
			if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData4 && !(sphericalConstraintData4 is CylindricalConstraintData))
			{
				ExpVector expVector17 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData3.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector18 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData4.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					double num3 = Math.Abs(sphericalConstraintData3.Radius - sphericalConstraintData4.Radius);
					if (num3 < 1E-12)
					{
						_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector17 - expVector18) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
					else
					{
						_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector17 - expVector18)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num3) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					}
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector17 - expVector18)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - sphericalConstraintData3.Radius - sphericalConstraintData4.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is ConicalConstraintData conicalConstraintData2)
			{
				ExpVector _0023_003Dz1v6oPQk_003D10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData2.AxisZ);
				ExpVector expVector19 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData3.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector20 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData2.Tip) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D10)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() + ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D10) * Math.Tan(conicalConstraintData2.HalfAngle) - sphericalConstraintData3.Radius / Math.Cos(conicalConstraintData2.HalfAngle)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D10)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D10) * Math.Tan(conicalConstraintData2.HalfAngle) - sphericalConstraintData3.Radius / Math.Cos(conicalConstraintData2.HalfAngle)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector expVector21 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData3.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector22 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				ExpVector _0023_003Dz1v6oPQk_003D11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector21 - expVector22)._0023_003Dzv2_0024_0024bTe2Lsf7qf9MBkQarAU_003D() - Exp._0023_003DzKSdA2AY_003D(ExpVector._0023_003DzBWYOAtM_003D(expVector21 - expVector22, _0023_003Dz1v6oPQk_003D11)) - sphericalConstraintData3.Radius * sphericalConstraintData3.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
	}

	public override bool IsFlippable()
	{
		if (_0023_003DzgM8TwmWg2tsG is LinearConstraintData || _0023_003DzdH0ws20LmJv0 is LinearConstraintData)
		{
			return false;
		}
		return true;
	}
}
