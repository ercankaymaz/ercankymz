using System;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class CoincidentMate : Mate
{
	internal CoincidentMate(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan)
	{
	}

	protected internal CoincidentMate(CoincidentMateSurrogate surrogate)
		: base(surrogate)
	{
		UpdateName();
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655465) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
		if (base.Flipped)
		{
			_0023_003DzS_00246o7tc_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655488);
		}
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new CoincidentMateSurrogate(this);
	}

	protected override void UpdateEquationsInternal()
	{
		_0023_003DzKQRQajdIkCVIaRin_0024tJtZVabqBH8(out var _0023_003Dz5DNWc7LoRIbU, out var _0023_003DzsIMS3mX44piL, out var _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D, out var _0023_003Dznu9klRRS___00245FhlvqA_003D_003D);
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
				ExpVector expVector3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(planarConstraintData2.Origin) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector4, expVector) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D));
				ExpVector expVector5 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector6 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(linearConstraintData.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector5 - expVector6, _0023_003Dz1v6oPQk_003D) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData)
			{
				ExpVector expVector7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 + expVector8);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector7 - expVector8);
				}
				ExpVector expVector9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector9 - expVector10, expVector7) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D2 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector11 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(planarConstraintData.Origin);
				ExpVector expVector12 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(pointConstraintData.Position);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector11 / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D - expVector12 / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D, _0023_003Dz1v6oPQk_003D2) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData && !(cylindricalConstraintData is ConicalConstraintData) && !(cylindricalConstraintData is ToroidalConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector expVector13 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector14 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector13 + expVector14);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector13 - expVector14);
				}
				ExpVector expVector15 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector16 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector15 - expVector16, expVector13)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData2)
			{
				ExpVector expVector17 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector18 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector17 - expVector18);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector17 + expVector18);
				}
				ExpVector expVector19 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector20 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData2.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector19 - expVector20, expVector17)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData.Radius - circleConstraintData2.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData2)
			{
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				ExpVector expVector21 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector22 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData2.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector21 - expVector22, _0023_003Dz1v6oPQk_003D3)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is SphericalConstraintData sphericalConstraintData && !(sphericalConstraintData is CylindricalConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData3)
			{
				ExpVector expVector23 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector24 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData3.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector23 - expVector24)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - sphericalConstraintData.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D * _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is ConicalConstraintData conicalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is ConicalConstraintData conicalConstraintData2 && Math.Abs(conicalConstraintData.HalfAngle - conicalConstraintData2.HalfAngle) < 1E-12)
			{
				ExpVector expVector25 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(conicalConstraintData.AxisZ);
				ExpVector expVector26 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData2.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector25 + expVector26);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector25 - expVector26);
				}
				ExpVector expVector27 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(conicalConstraintData.Tip) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector28 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(conicalConstraintData2.Tip) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector27 - expVector28) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData4)
			{
				ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(conicalConstraintData.AxisZ);
				ExpVector expVector29 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(conicalConstraintData.Tip) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector30 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData4.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector29 - expVector30, _0023_003Dz1v6oPQk_003D4) + (expVector29 - expVector30)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() * Math.Cos(conicalConstraintData.HalfAngle)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData3)
		{
			if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData4)
			{
				ExpVector expVector31 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				ExpVector expVector32 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector31 + expVector32);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector31 - expVector32);
				}
				ExpVector expVector33 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData3.End) / _0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D();
				ExpVector expVector34 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData4.End) / _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D();
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector33 - expVector34, expVector31) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData5)
			{
				ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				ExpVector expVector35 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData3.End) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector36 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData5.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector35 - expVector36, _0023_003Dz1v6oPQk_003D5) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CircleConstraintData circleConstraintData3)
		{
			if (_0023_003DzsIMS3mX44piL is CircleConstraintData circleConstraintData4)
			{
				ExpVector expVector37 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData3.AxisZ);
				ExpVector expVector38 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector37 + expVector38);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector37 - expVector38);
				}
				ExpVector expVector39 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData3.Center) / _0023_003Dzqt5Cs5JoIqeaSbJrmEPsvDE_003D();
				ExpVector expVector40 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(circleConstraintData4.Center) / _0023_003DzdwpTbb37XkgXsZleHJK10Ic_003D();
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector39 - expVector40) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData6)
			{
				ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData3.AxisZ);
				ExpVector expVector41 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(circleConstraintData3.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector42 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData6.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector41 - expVector42, _0023_003Dz1v6oPQk_003D6) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector41 - expVector42)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - circleConstraintData3.Radius) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is PointConstraintData pointConstraintData7 && _0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData8)
		{
			ExpVector expVector43 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(pointConstraintData7.Position) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
			ExpVector expVector44 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData8.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
			_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector43 - expVector44) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
		}
	}

	public override bool IsFlippable()
	{
		if ((_0023_003DzgM8TwmWg2tsG is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData) && _0023_003DzdH0ws20LmJv0 is LinearConstraintData) || (_0023_003DzgM8TwmWg2tsG is LinearConstraintData && _0023_003DzdH0ws20LmJv0 is PlanarConstraintData planarConstraintData2 && !(planarConstraintData2 is RevolvedConstraintData)) || _0023_003DzgM8TwmWg2tsG is PointConstraintData || _0023_003DzdH0ws20LmJv0 is PointConstraintData)
		{
			return false;
		}
		return true;
	}
}
