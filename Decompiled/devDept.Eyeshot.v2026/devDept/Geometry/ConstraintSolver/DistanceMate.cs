using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

public class DistanceMate : Mate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D;

	public double Distance
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D;
		}
	}

	internal DistanceMate(ConstraintData _0023_003Dzfm4oGj8_003D, ConstraintData _0023_003DzCVdPoWM_003D, double _0023_003DzPzO_0024GUk_003D = 0.0, bool _0023_003Dzbu8BV15Qqzan = false)
		: base(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003Dzbu8BV15Qqzan)
	{
		_0023_003DzSojbXu_0024fxxce(_0023_003DzPzO_0024GUk_003D);
	}

	protected internal DistanceMate(DistanceMateSurrogate surrogate)
		: base(surrogate)
	{
		_0023_003DzSojbXu_0024fxxce(surrogate.Distance);
		UpdateName();
	}

	internal void _0023_003DzSojbXu_0024fxxce(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	protected override void UpdateName()
	{
		_0023_003DzS_00246o7tc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655082) + Distance + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + base.Component1.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + base.Component2.BlockName;
		if (base.Flipped)
		{
			_0023_003DzS_00246o7tc_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655488);
		}
	}

	public override MateSurrogate ConvertToSurrogate()
	{
		return new DistanceMateSurrogate(this);
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
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector4, expVector) - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector3 - expVector4, expVector) + Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData && !(cylindricalConstraintData is ConicalConstraintData) && !(cylindricalConstraintData is ToroidalConstraintData))
			{
				ExpVector expVector5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData.AxisZ);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector5, _0023_003Dz1v6oPQk_003D));
				ExpVector expVector6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector7 - expVector6, expVector5) + cylindricalConstraintData.Radius + Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector7 - expVector6, expVector5) - cylindricalConstraintData.Radius - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData && !(sphericalConstraintData is CylindricalConstraintData))
			{
				ExpVector _0023_003Dz1v6oPQk_003D2 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (base.Flipped)
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector8 - expVector9, _0023_003Dz1v6oPQk_003D2) + sphericalConstraintData.Radius + Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector8 - expVector9, _0023_003Dz1v6oPQk_003D2) - sphericalConstraintData.Radius - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D3 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.Direction);
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D3));
				ExpVector expVector10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector10 - expVector11, _0023_003Dz1v6oPQk_003D3) - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData)
			{
				ExpVector _0023_003Dz1v6oPQk_003D4 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.AxisZ);
				ExpVector expVector12 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(planarConstraintData.Origin) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector13 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzBWYOAtM_003D(expVector12 - expVector13, _0023_003Dz1v6oPQk_003D4) - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is ConicalConstraintData conicalConstraintData)
		{
			if (_0023_003DzsIMS3mX44piL is ConicalConstraintData conicalConstraintData2)
			{
				ExpVector expVector14 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(conicalConstraintData.AxisZ);
				ExpVector _0023_003Dz1v6oPQk_003D5 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData2.AxisZ);
				double d = (base.Flipped ? (conicalConstraintData.HalfAngle - conicalConstraintData2.HalfAngle) : (conicalConstraintData.HalfAngle + conicalConstraintData2.HalfAngle));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector14, _0023_003Dz1v6oPQk_003D5) - Math.Cos(d));
				ExpVector expVector15 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(conicalConstraintData.Tip) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector16 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(conicalConstraintData2.Tip) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector16 - expVector15, ExpVector._0023_003DzyJipUOg_003D(expVector14, _0023_003Dz1v6oPQk_003D5)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector16 - expVector15, expVector14)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - ExpVector._0023_003DzBWYOAtM_003D(expVector16 - expVector15, expVector14) * Math.Tan(conicalConstraintData.HalfAngle) - Distance / Math.Cos(conicalConstraintData.HalfAngle)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is CylindricalConstraintData cylindricalConstraintData2 && !(cylindricalConstraintData2 is ToroidalConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is CylindricalConstraintData cylindricalConstraintData3 && !(cylindricalConstraintData3 is ConicalConstraintData) && !(cylindricalConstraintData3 is ToroidalConstraintData))
			{
				ExpVector expVector17 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector expVector18 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData3.AxisZ);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector17 + expVector18);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector17 - expVector18);
				}
				ExpVector expVector19 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector20 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(cylindricalConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				double num = Math.Abs(cylindricalConstraintData2.Radius + cylindricalConstraintData3.Radius + Distance);
				if (num < 1E-12)
				{
					ExpVector _0023_003Dz1v6oPQk_003D6 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisX);
					ExpVector _0023_003Dz1v6oPQk_003D7 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisY);
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D6) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector19 - expVector20, _0023_003Dz1v6oPQk_003D7) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector19 - expVector20, expVector17)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData2)
			{
				ExpVector expVector21 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector expVector22 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector21 + expVector22);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector21 - expVector22);
				}
				ExpVector expVector23 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector24 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData2.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector23 - expVector24, expVector21)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - cylindricalConstraintData2.Radius - Distance) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData2)
			{
				ExpVector _0023_003Dz1v6oPQk_003D8 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisZ);
				ExpVector expVector25 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector26 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData2.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				double num2 = Math.Abs(cylindricalConstraintData2.Radius + Distance);
				if (num2 < 1E-12)
				{
					ExpVector _0023_003Dz1v6oPQk_003D9 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisX);
					ExpVector _0023_003Dz1v6oPQk_003D10 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(cylindricalConstraintData2.AxisY);
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector25 - expVector26, _0023_003Dz1v6oPQk_003D9) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(ExpVector._0023_003DzBWYOAtM_003D(expVector25 - expVector26, _0023_003Dz1v6oPQk_003D10) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector25 - expVector26, _0023_003Dz1v6oPQk_003D8)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num2) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is SphericalConstraintData sphericalConstraintData2 && !(sphericalConstraintData2 is CylindricalConstraintData))
		{
			if (_0023_003DzsIMS3mX44piL is SphericalConstraintData sphericalConstraintData3 && !(sphericalConstraintData3 is CylindricalConstraintData))
			{
				ExpVector expVector27 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector28 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(sphericalConstraintData3.Center) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				double num3 = (base.Flipped ? Math.Abs(sphericalConstraintData2.Radius - sphericalConstraintData3.Radius - Distance) : Math.Abs(sphericalConstraintData2.Radius + sphericalConstraintData3.Radius + Distance));
				if (num3 < 1E-12)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector27 - expVector28) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector27 - expVector28)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num3) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData3)
			{
				ExpVector expVector29 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector30 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Start) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				ExpVector _0023_003Dz1v6oPQk_003D11 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData3.Direction);
				double num4 = Math.Abs(sphericalConstraintData2.Radius + Distance);
				if (num4 < 1E-12)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector29 - expVector30, _0023_003Dz1v6oPQk_003D11) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector29 - expVector30, _0023_003Dz1v6oPQk_003D11)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num4) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData3)
			{
				ExpVector expVector31 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(sphericalConstraintData2.Center) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector32 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData3.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				if (Math.Abs(sphericalConstraintData2.Radius + Distance) < 1E-12)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector31 - expVector32) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector31 - expVector32)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - Math.Abs(sphericalConstraintData2.Radius + Distance)) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is LinearConstraintData linearConstraintData4)
		{
			if (_0023_003DzsIMS3mX44piL is LinearConstraintData linearConstraintData5)
			{
				ExpVector expVector33 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
				ExpVector expVector34 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.Direction);
				if (base.Flipped)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector33 + expVector34);
				}
				else
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(expVector33 - expVector34);
				}
				ExpVector expVector35 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(linearConstraintData4.End) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector36 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(linearConstraintData5.End) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				double num5 = Math.Abs(Distance);
				if (num5 < 1E-12)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector35 - expVector36, expVector33) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector35 - expVector36, expVector33)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num5) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
			else if (_0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData4)
			{
				ExpVector _0023_003Dz1v6oPQk_003D12 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(linearConstraintData4.Direction);
				ExpVector expVector37 = base.Component1._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(linearConstraintData4.End) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
				ExpVector expVector38 = base.Component2._0023_003DzCvxG2A3KpWd8()._0023_003DzK48Px00_003D(pointConstraintData4.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
				double num6 = Math.Abs(Distance);
				if (num6 < 1E-12)
				{
					_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add(ExpVector._0023_003DzyJipUOg_003D(expVector37 - expVector38, _0023_003Dz1v6oPQk_003D12) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
				else
				{
					_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add((ExpVector._0023_003DzyJipUOg_003D(expVector37 - expVector38, _0023_003Dz1v6oPQk_003D12)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num6) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
				}
			}
		}
		else if (_0023_003Dz5DNWc7LoRIbU is PointConstraintData pointConstraintData5 && _0023_003DzsIMS3mX44piL is PointConstraintData pointConstraintData6)
		{
			ExpVector expVector39 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK2._0023_003DzK48Px00_003D(pointConstraintData5.Position) / _0023_003DzIYiCGYCVW34jZBH2BA_003D_003D;
			ExpVector expVector40 = _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK3._0023_003DzK48Px00_003D(pointConstraintData6.Position) / _0023_003Dznu9klRRS___00245FhlvqA_003D_003D;
			double num7 = Math.Abs(Distance);
			if (num7 < 1E-12)
			{
				_0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D.Add((expVector39 - expVector40) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
			else
			{
				_0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D.Add(((expVector39 - expVector40)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - num7) * (_0023_003DzIYiCGYCVW34jZBH2BA_003D_003D + _0023_003Dznu9klRRS___00245FhlvqA_003D_003D));
			}
		}
	}

	public void ChangeDistance(double newDistance)
	{
		_0023_003DzSojbXu_0024fxxce(newDistance);
		_0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D();
	}

	public override bool IsFlippable()
	{
		if ((_0023_003DzgM8TwmWg2tsG is PlanarConstraintData planarConstraintData && !(planarConstraintData is RevolvedConstraintData) && _0023_003DzdH0ws20LmJv0 is LinearConstraintData) || (_0023_003DzgM8TwmWg2tsG is LinearConstraintData && _0023_003DzdH0ws20LmJv0 is PlanarConstraintData planarConstraintData2 && !(planarConstraintData2 is RevolvedConstraintData)) || (_0023_003DzgM8TwmWg2tsG is SphericalConstraintData sphericalConstraintData && !(sphericalConstraintData is CylindricalConstraintData) && _0023_003DzdH0ws20LmJv0 is LinearConstraintData) || (_0023_003DzgM8TwmWg2tsG is LinearConstraintData && _0023_003DzdH0ws20LmJv0 is SphericalConstraintData sphericalConstraintData2 && !(sphericalConstraintData2 is CylindricalConstraintData)) || _0023_003DzgM8TwmWg2tsG is PointConstraintData || _0023_003DzdH0ws20LmJv0 is PointConstraintData)
		{
			return false;
		}
		return true;
	}
}
