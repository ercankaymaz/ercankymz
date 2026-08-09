using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.IO;
using Xbim.Ifc;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;
using Xbim.Ifc4x3.PresentationOrganizationResource;
using Xbim.Ifc4x3.ProductExtension;
using Xbim.Ifc4x3.ProfileResource;
using Xbim.Ifc4x3.PropertyResource;
using Xbim.Ifc4x3.RepresentationResource;
using Xbim.Ifc4x3.SharedBldgElements;
using Xbim.Ifc4x3.StructuralElementsDomain;
using Xbim.Ifc4x3.TopologyResource;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteIFC : WriteFileAsyncWithUnits
{
	private sealed class _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D
	{
		public IfcGeometricRepresentationContext _0023_003DzV0QqRpQ_003D;

		internal void _0023_003DzhNTedbh2Wu5lfOvFrA_003D_003D(IfcGeometricRepresentationSubContext _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dzt_m8zV0_003D.ParentContext = _0023_003DzV0QqRpQ_003D;
			_0023_003Dzt_m8zV0_003D.ContextIdentifier = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445);
			_0023_003Dzt_m8zV0_003D.ContextType = _0023_003DzV0QqRpQ_003D.ContextType;
		}
	}

	private sealed class _0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D
	{
		public string _0023_003DzkRYWt2a_0024teGb;

		public Dictionary<string, object> _0023_003Dz3mCbtDmJcG4_0024;

		public _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		public Action<IfcPropertySet> _0023_003DzJjT3dOU3oUsg;

		internal void _0023_003DzuyZ18UiZRRtuxnCb_Q_003D_003D(IfcRelDefinesByProperties _0023_003DzD_8KOiQ_003D)
		{
			_0023_003DzD_8KOiQ_003D.RelatedObjects.Add(_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dz2t9nEMs_003D);
			_0023_003DzD_8KOiQ_003D.RelatingPropertyDefinition = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcPropertySet _0023_003DzYLrWcNfK99Pc)
			{
				_0023_003DzYLrWcNfK99Pc.Name = _0023_003DzkRYWt2a_0024teGb;
				foreach (KeyValuePair<string, object> item2 in _0023_003Dz3mCbtDmJcG4_0024)
				{
					_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D _0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2 = new _0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D();
					_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzLqUGe70_003D = item2.Key ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012856);
					_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzYgyCuKI_003D = item2.Value;
					IfcPropertySingleValue item = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcPropertySingleValue>(_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzN89ZIz7dI8Cilt5Rfw_003D_003D);
					_0023_003DzYLrWcNfK99Pc.HasProperties.Add(item);
				}
			});
		}

		internal void _0023_003DzM_WI21skjYLeR7yo_0024Q_003D_003D(IfcPropertySet _0023_003DzYLrWcNfK99Pc)
		{
			_0023_003DzYLrWcNfK99Pc.Name = _0023_003DzkRYWt2a_0024teGb;
			foreach (KeyValuePair<string, object> item2 in _0023_003Dz3mCbtDmJcG4_0024)
			{
				_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D _0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2 = new _0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D();
				_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzLqUGe70_003D = item2.Key ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012856);
				_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzYgyCuKI_003D = item2.Value;
				IfcPropertySingleValue item = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcPropertySingleValue>(_0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D2._0023_003DzN89ZIz7dI8Cilt5Rfw_003D_003D);
				_0023_003DzYLrWcNfK99Pc.HasProperties.Add(item);
			}
		}
	}

	private sealed class _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public Point3D _0023_003DzB68dg9Q_003D;

		internal void _0023_003Dz2qLXMfp5Shhj0WxWL4usO5o_003D(IfcVertexPoint _0023_003Dz77g161c_003D)
		{
			_0023_003Dz77g161c_003D.VertexGeometry = _0023_003DzopRx0_MBcTQs._0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003DzB68dg9Q_003D, 3);
		}
	}

	private sealed class _0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D
	{
		public IfcCurve _0023_003DzYbZQw3SBCmck;

		public Brep.Edge _0023_003DzJSE0zYhXeN9U;

		public _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D;

		internal void _0023_003Dz6ZVetAPEW89V7auUaAYMnpQ_003D(IfcEdgeCurve _0023_003DzbfrNXYE_003D)
		{
			_0023_003DzbfrNXYE_003D.EdgeGeometry = _0023_003DzYbZQw3SBCmck;
			_0023_003DzbfrNXYE_003D.EdgeStart = _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzdGpTIwzYxL4U2qFSlw_003D_003D[_0023_003DzJSE0zYhXeN9U.StartPointIndex];
			_0023_003DzbfrNXYE_003D.EdgeEnd = _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzdGpTIwzYxL4U2qFSlw_003D_003D[_0023_003DzJSE0zYhXeN9U.EndPointIndex];
			_0023_003DzbfrNXYE_003D.SameSense = true;
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Action<IfcSIUnit> _0023_003DzMj0BD8rSnks5VxBWig_003D_003D;

		public static Func<Entity, bool> _0023_003Dzy7nEv89xDomyXIe12g_003D_003D;

		public static Func<double, IfcLengthMeasure> _0023_003DzTo4XDDj1vwXNMGu8Og_003D_003D;

		public static Func<int, IfcPositiveInteger> _0023_003Dz3WxhRwASRK2YMpomkg_003D_003D;

		public static Func<Point4D, IfcReal> _0023_003Dz3Csc5F5Pt_002463lCSDCQ_003D_003D;

		public static Func<double, IfcParameterValue> _0023_003Dzxp7xNXOAagU4emu62A_003D_003D;

		public static Func<double, IfcParameterValue> _0023_003Dz3tlucKrMSsWnoztRrg_003D_003D;

		public static Func<double, IfcInteger> _0023_003Dz3hZGMlWtcfcjZZk_0024ig_003D_003D;

		public static Func<double, IfcParameterValue> _0023_003DznX_0024HijiNGW07Ua6_0024aQ_003D_003D;

		public static Func<double, IfcInteger> _0023_003DzSnf8vgYMZ2kmjZVFVg_003D_003D;

		internal void _0023_003DzWTj2EHpv1u1iMOGeBhHIGJo_003D(IfcSIUnit _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.UnitType = IfcUnitEnum.PLANEANGLEUNIT;
			_0023_003DzuwH5j5s_003D.Name = IfcSIUnitName.RADIAN;
		}

		internal bool _0023_003DzrLunVwsoAg_0024cBAo6dIeEc20_003D(Entity _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D.IfcProperties?.GUID != null;
		}

		internal IfcLengthMeasure _0023_003DzN8sktxPFxpCEhssFCNIZcePqbLkG(double _0023_003Dz77g161c_003D)
		{
			return new IfcLengthMeasure(_0023_003Dz77g161c_003D);
		}

		internal IfcPositiveInteger _0023_003DzivUUON58vnb56TlHy0H7pIiN_0024T_0024X(int _0023_003Dz77g161c_003D)
		{
			return new IfcPositiveInteger(_0023_003Dz77g161c_003D + 1);
		}

		internal IfcReal _0023_003DzORKlKxrDoywRUjLi8V7d5VeM1fvS(Point4D _0023_003Dzt_m8zV0_003D)
		{
			return new IfcReal(_0023_003Dzt_m8zV0_003D.W);
		}

		internal IfcParameterValue _0023_003DzDVFbYFtEnT_002460NMRlof91RWR3ObX(double _0023_003DzN6G05Lg_003D)
		{
			return new IfcParameterValue(_0023_003DzN6G05Lg_003D);
		}

		internal IfcParameterValue _0023_003DzhAKpmMsfJHEK4tPPgdd98_00244_003D(double _0023_003DzN6G05Lg_003D)
		{
			return new IfcParameterValue(_0023_003DzN6G05Lg_003D);
		}

		internal IfcInteger _0023_003DzWoc_0024MuoSiN15rLC60GykrwU_003D(double _0023_003DzBJFJHwk_003D)
		{
			return new IfcInteger(1L);
		}

		internal IfcParameterValue _0023_003DzIUDwML9wU6KPZAbfeSJVq9M_003D(double _0023_003DzN6G05Lg_003D)
		{
			return new IfcParameterValue(_0023_003DzN6G05Lg_003D);
		}

		internal IfcInteger _0023_003DzO_0024DL1k1Z58BUMI9FDzud1Is_003D(double _0023_003DzBJFJHwk_003D)
		{
			return new IfcInteger(1L);
		}
	}

	private sealed class _0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public Plane _0023_003Dzrgqz890sj_0024X9;

		public Action<IfcCartesianPoint> _0023_003DzJjT3dOU3oUsg;

		public Action<IfcDirection> _0023_003DzzaljjvyD9N9t;

		internal void _0023_003DzCrSXwcuvH34t9LXprmZktIk_003D(IfcAxis1Placement _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Location = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
			{
				_0023_003Dz1cdkDps_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y, _0023_003Dzrgqz890sj_0024X9.Origin.Z);
			});
			_0023_003DzB68dg9Q_003D.Axis = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(_0023_003DziHYAvWObvJBgVJQGlIvDVmU_003D);
		}

		internal void _0023_003Dz3c_u2Sg_0024OvAF0sn0rdGwTjs_003D(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
		{
			_0023_003Dz1cdkDps_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y, _0023_003Dzrgqz890sj_0024X9.Origin.Z);
		}

		internal void _0023_003DziHYAvWObvJBgVJQGlIvDVmU_003D(IfcDirection _0023_003DzXrexKjY_003D)
		{
			_0023_003DzXrexKjY_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.AxisZ.X, _0023_003Dzrgqz890sj_0024X9.AxisZ.Y, _0023_003Dzrgqz890sj_0024X9.AxisZ.Z);
		}
	}

	private sealed class _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public IfcVertex[] _0023_003DzdGpTIwzYxL4U2qFSlw_003D_003D;

		public IfcEdge[] _0023_003DzVnEG1RlCHq_0024a;

		public IfcFace[] _0023_003Dzq93XqX4D_0024_00246X_0024B1HJQ_003D_003D;

		public Action<IfcClosedShell> _0023_003DzBrlADxmFfW_T;

		internal void _0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D(IfcAdvancedBrep _0023_003Dz1v6oPQk_003D)
		{
			_0023_003Dz1v6oPQk_003D.Outer = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcClosedShell _0023_003DzuwH5j5s_003D)
			{
				_0023_003DzuwH5j5s_003D.CfsFaces.AddRange(_0023_003Dzq93XqX4D_0024_00246X_0024B1HJQ_003D_003D);
			});
		}

		internal void _0023_003Dz_gw2fbg0oTb_0024FPuxXxYKj6k_003D(IfcClosedShell _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.CfsFaces.AddRange(_0023_003Dzq93XqX4D_0024_00246X_0024B1HJQ_003D_003D);
		}
	}

	private sealed class _0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D
	{
		public double[] _0023_003Dz1MMYB1g_003D;

		public _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		public Action<IfcColourRgb> _0023_003DzdT8kPTzaWkIC;

		public Action<IfcSurfaceStyleRendering> _0023_003DzzaljjvyD9N9t;

		internal void _0023_003DzJNtHbIIW6e_V5bm3DQ_003D_003D(IfcSurfaceStyle _0023_003Dz_0024wQZnFQ_003D)
		{
			_0023_003Dz_0024wQZnFQ_003D.Side = IfcSurfaceSide.BOTH;
			_0023_003Dz_0024wQZnFQ_003D.Styles.Add(_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceStyleRendering>(_0023_003DzBN3UfOmBFKkgGpj4LQ_003D_003D));
		}

		internal void _0023_003DzBN3UfOmBFKkgGpj4LQ_003D_003D(IfcSurfaceStyleRendering _0023_003Dz0aMijCyekOhAUfolBw_003D_003D)
		{
			_0023_003Dz0aMijCyekOhAUfolBw_003D_003D.SurfaceColour = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcColourRgb>(_0023_003DzmhMIMBkkiDkA1wAGBQ_003D_003D);
			_0023_003Dz0aMijCyekOhAUfolBw_003D_003D.Transparency = 1.0 - _0023_003Dz1MMYB1g_003D[3];
		}

		internal void _0023_003DzmhMIMBkkiDkA1wAGBQ_003D_003D(IfcColourRgb _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dzt_m8zV0_003D.Red = _0023_003Dz1MMYB1g_003D[0];
			_0023_003Dzt_m8zV0_003D.Green = _0023_003Dz1MMYB1g_003D[1];
			_0023_003Dzt_m8zV0_003D.Blue = _0023_003Dz1MMYB1g_003D[2];
		}
	}

	private sealed class _0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public ICurve _0023_003DziiiMrhXhZ8sK;

		internal void _0023_003DzzNOeXLeeG4q2aR0DklS8ru5xUR9d54zItg_003D_003D(IfcArbitraryClosedProfileDef _0023_003DzrasF10y2WHoh)
		{
			_0023_003DzrasF10y2WHoh.OuterCurve = _0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(_0023_003DziiiMrhXhZ8sK, 2);
		}
	}

	private sealed class _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public IfcObjectPlacement _0023_003DzhXgvnRtdjeYO;

		public IfcElement _0023_003Dz9j4kMjs_003D;

		internal void _0023_003DzLtXe1H8JNNM7SWSWMg_003D_003D(IfcLocalPlacement _0023_003DzHPC6WX8_003D)
		{
			_0023_003DzHPC6WX8_003D.RelativePlacement = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(Plane.XY);
			_0023_003DzHPC6WX8_003D.PlacementRelTo = _0023_003DzhXgvnRtdjeYO;
		}
	}

	private sealed class _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D
	{
		public int _0023_003Dzr_3OnS8_003D;

		public Point3D _0023_003DzB68dg9Q_003D;

		internal void _0023_003DzUhOr4myML98YCVwCTdRwpAE3i6gUu9MhCQ_003D_003D(IfcCartesianPoint _0023_003Dzukhh1F5vpApN)
		{
			if (_0023_003Dzr_3OnS8_003D == 2)
			{
				_0023_003Dzukhh1F5vpApN.SetXY(_0023_003DzB68dg9Q_003D.X, _0023_003DzB68dg9Q_003D.Y);
			}
			else
			{
				_0023_003Dzukhh1F5vpApN.SetXYZ(_0023_003DzB68dg9Q_003D.X, _0023_003DzB68dg9Q_003D.Y, _0023_003DzB68dg9Q_003D.Z);
			}
		}
	}

	private sealed class _0023_003DzGOWHJOJdHJnQn0HLtYvTwFA_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public Plane _0023_003Dzrgqz890sj_0024X9;

		public Action<IfcCartesianPoint> _0023_003DzJjT3dOU3oUsg;

		public Action<IfcDirection> _0023_003DzzaljjvyD9N9t;

		public Action<IfcDirection> _0023_003DzdT8kPTzaWkIC;

		internal void _0023_003DzeoqAKi_0024lgM7eBUGOJ1Bp5poo5wOp(IfcAxis2Placement3D _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Location = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
			{
				_0023_003Dz1cdkDps_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y, _0023_003Dzrgqz890sj_0024X9.Origin.Z);
			});
			_0023_003DzB68dg9Q_003D.RefDirection = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(_0023_003DzTMmTob4Um0KVJM0_SFQbndvx6JEp);
			_0023_003DzB68dg9Q_003D.Axis = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(_0023_003Dz28i371rYZqoa8TmjzJ3EApqIqF3X);
		}

		internal void _0023_003DzEypg6ch1ZLgk5K4x7Q7j_0024kNyr5Cn(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
		{
			_0023_003Dz1cdkDps_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y, _0023_003Dzrgqz890sj_0024X9.Origin.Z);
		}

		internal void _0023_003DzTMmTob4Um0KVJM0_SFQbndvx6JEp(IfcDirection _0023_003DzXrexKjY_003D)
		{
			_0023_003DzXrexKjY_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.AxisX.X, _0023_003Dzrgqz890sj_0024X9.AxisX.Y, _0023_003Dzrgqz890sj_0024X9.AxisX.Z);
		}

		internal void _0023_003Dz28i371rYZqoa8TmjzJ3EApqIqF3X(IfcDirection _0023_003DzXrexKjY_003D)
		{
			_0023_003DzXrexKjY_003D.SetXYZ(_0023_003Dzrgqz890sj_0024X9.AxisZ.X, _0023_003Dzrgqz890sj_0024X9.AxisZ.Y, _0023_003Dzrgqz890sj_0024X9.AxisZ.Z);
		}
	}

	private sealed class _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public ICurve[] _0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D;

		public Region _0023_003DzCRq4LBU_003D;

		public Vector3D _0023_003DzCJkr8nY_003D;

		public Vector3D _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D;

		internal void _0023_003Dz_0024EaXFUfJ4F1udi8MatX7CYs12xoV(IfcExtrudedAreaSolid _0023_003Dz28FDiEs_003D)
		{
			_0023_003Dz28FDiEs_003D.SweptArea = _0023_003DzopRx0_MBcTQs._0023_003Dz_0024eiwUEyChs5pRCQLHQ_003D_003D(_0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D);
			_0023_003Dz28FDiEs_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003DzCRq4LBU_003D.Plane);
			_0023_003Dz28FDiEs_003D.ExtrudedDirection = _0023_003DzopRx0_MBcTQs._0023_003Dz2X4EMKT5qHte(_0023_003DzCJkr8nY_003D, 3);
			_0023_003Dz28FDiEs_003D.Depth = _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Length;
		}
	}

	private sealed class _0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D
	{
		public Entity _0023_003DzVlqgr54_003D;

		public _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D _0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D;

		internal void _0023_003DzcXl41NNh4JUzsOUEug_003D_003D(IfcRelVoidsElement _0023_003DzScZnOHkeNEJ_0024)
		{
			_0023_003DzScZnOHkeNEJ_0024.RelatingBuildingElement = _0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003Dz9j4kMjs_003D;
			_0023_003DzScZnOHkeNEJ_0024.RelatedOpeningElement = (IfcFeatureElementSubtraction)_0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003DzopRx0_MBcTQs._0023_003DzhraSr_0024zjynpp(_0023_003DzVlqgr54_003D, typeof(IfcOpeningElement), _0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003DzhXgvnRtdjeYO);
		}
	}

	private sealed class _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public NurbsSurf _0023_003DzZHWJg951G82UzLZjrMqdeao_003D;

		public SphericalSurf _0023_003DzH8NMsuQtF4V_AybMOpDZ84VLd3Cn;

		public CylindricalSurf _0023_003DzBVoJR8rfR43RyonlhEeGWgoQnvKA1IdPoQ_003D_003D;

		public IfcProfileDef _0023_003Dz1QMSv2HWVtLc;

		public Plane _0023_003Dzpyw2kZk_003D;

		public RevolvedSurf _0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9;

		public ToroidalSurf _0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8;

		public PlanarSurf _0023_003DzKMDSIZhwizM1J_0024GpnHfwZpq198gq;

		public IfcProfileDef _0023_003DzN43NmNMGjNKB;

		public Plane _0023_003Dzrgqz890sj_0024X9;

		public Vector3D _0023_003DzCJkr8nY_003D;

		public TabulatedSurf _0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf;

		internal void _0023_003Dz5QS5wLq39uvLb6MKBcRXLtc_003D(IfcRationalBSplineSurfaceWithKnots _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.UDegree = _0023_003DzZHWJg951G82UzLZjrMqdeao_003D.DegreeU;
			_0023_003DzuwH5j5s_003D.VDegree = _0023_003DzZHWJg951G82UzLZjrMqdeao_003D.DegreeV;
			_0023_003DzuwH5j5s_003D.SurfaceForm = IfcBSplineSurfaceForm.UNSPECIFIED;
			_0023_003DzuwH5j5s_003D.KnotSpec = IfcKnotType.UNSPECIFIED;
		}

		internal void _0023_003DzeqJ3ur8tEgTBnjIt0nMGugQ_003D(IfcSphericalSurface _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.Radius = _0023_003DzH8NMsuQtF4V_AybMOpDZ84VLd3Cn.Radius;
			_0023_003DzuwH5j5s_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003DzH8NMsuQtF4V_AybMOpDZ84VLd3Cn.Plane);
		}

		internal void _0023_003DzOJc3IHVw4mFoDcZl3eb6VFY_003D(IfcCylindricalSurface _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dzt_m8zV0_003D.Radius = _0023_003DzBVoJR8rfR43RyonlhEeGWgoQnvKA1IdPoQ_003D_003D.Radius;
			_0023_003Dzt_m8zV0_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003DzBVoJR8rfR43RyonlhEeGWgoQnvKA1IdPoQ_003D_003D.Plane);
		}

		internal void _0023_003DzIiB3wpAuu674UYvap7V0O24_003D(IfcSurfaceOfRevolution _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.SweptCurve = _0023_003Dz1QMSv2HWVtLc;
			_0023_003DzuwH5j5s_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dzpyw2kZk_003D);
			_0023_003DzuwH5j5s_003D.AxisPosition = _0023_003DzopRx0_MBcTQs._0023_003Dz2xhirm6y59i5l6ZkhA_003D_003D(_0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9.Plane);
		}

		internal void _0023_003DzF0SgPkkIHD0UbTl0JzXOf4k_003D(IfcToroidalSurface _0023_003DzNDQ_E88_003D)
		{
			_0023_003DzNDQ_E88_003D.MinorRadius = _0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8.MinorRadius;
			_0023_003DzNDQ_E88_003D.MajorRadius = _0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8.MajorRadius;
			_0023_003DzNDQ_E88_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8.Plane);
		}

		internal void _0023_003Dz9D9323S1hhrF2X6MA5IEouw_003D(IfcPlane _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003DzKMDSIZhwizM1J_0024GpnHfwZpq198gq.Plane);
		}

		internal void _0023_003DzxslUh_ct5H5Zk3e3pI2oFpI_003D(IfcSurfaceOfLinearExtrusion _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.SweptCurve = _0023_003DzN43NmNMGjNKB;
			_0023_003DzuwH5j5s_003D.Position = _0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dzrgqz890sj_0024X9);
			_0023_003DzuwH5j5s_003D.ExtrudedDirection = _0023_003DzopRx0_MBcTQs._0023_003Dz2X4EMKT5qHte(_0023_003DzCJkr8nY_003D, 3);
			_0023_003DzuwH5j5s_003D.Depth = _0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.Generatrix.Length;
		}
	}

	private sealed class _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public IReadOnlyList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D;

		public Func<ICurve, IfcCurve> _0023_003DzJjT3dOU3oUsg;

		internal void _0023_003DzcBM43sC2mqZZ0Sr2G_0024mLYT11S9t4t91ZXzqxktoO0Z00(IfcArbitraryProfileDefWithVoids _0023_003DzrasF10y2WHoh)
		{
			_0023_003DzrasF10y2WHoh.ProfileType = IfcProfileTypeEnum.AREA;
			_0023_003DzrasF10y2WHoh.OuterCurve = _0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[0], 2);
			_0023_003DzrasF10y2WHoh.InnerCurves.AddRange(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Skip(1).Select(_0023_003DzB8RcG8aoDoEGdq3j2Xm60cvqJ4bP8L7IqxdjnC_iJqs2));
		}

		internal IfcCurve _0023_003DzB8RcG8aoDoEGdq3j2Xm60cvqJ4bP8L7IqxdjnC_iJqs2(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(_0023_003Dzt_m8zV0_003D, 2);
		}
	}

	private sealed class _0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public Line _0023_003DzQ9zpGF0_003D;

		public int _0023_003Dzr_3OnS8_003D;

		internal void _0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D(IfcPolyline _0023_003Dzi4cdUYM_003D)
		{
			_0023_003Dzi4cdUYM_003D.Points.AddRange(_0023_003DzopRx0_MBcTQs._0023_003Dz4_0024_0024dqN8cEutytsVAlxBIFwEWUQpi(_0023_003DzQ9zpGF0_003D.Vertices, _0023_003Dzr_3OnS8_003D));
		}
	}

	private sealed class _0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D
	{
		public ICurve _0023_003DzzmfUkNI_003D;

		public _0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D(IfcCompositeCurveSegment _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzuwH5j5s_003D.ParentCurve = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(_0023_003DzzmfUkNI_003D, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dzr_3OnS8_003D);
			_0023_003DzuwH5j5s_003D.Transition = IfcTransitionCode.CONTINUOUS;
			_0023_003DzuwH5j5s_003D.SameSense = true;
		}
	}

	private sealed class _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public Plane _0023_003Dzrgqz890sj_0024X9;

		public Action<IfcCartesianPoint> _0023_003DzJjT3dOU3oUsg;

		public Action<IfcDirection> _0023_003DzzaljjvyD9N9t;

		internal void _0023_003Dz6RaUgbTLHdPjndDXQkvRCDH4x0oO(IfcAxis2Placement2D _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Location = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
			{
				_0023_003Dz1cdkDps_003D.SetXY(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y);
			});
			_0023_003DzB68dg9Q_003D.RefDirection = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(_0023_003Dz5S2g1lJdLqNTXtNdFI6V6S7oSaKH);
		}

		internal void _0023_003DzWdanHYUVkF6ap5S3RIqWVL_00241syyK(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
		{
			_0023_003Dz1cdkDps_003D.SetXY(_0023_003Dzrgqz890sj_0024X9.Origin.X, _0023_003Dzrgqz890sj_0024X9.Origin.Y);
		}

		internal void _0023_003Dz5S2g1lJdLqNTXtNdFI6V6S7oSaKH(IfcDirection _0023_003DzXrexKjY_003D)
		{
			_0023_003DzXrexKjY_003D.SetXY(_0023_003Dzrgqz890sj_0024X9.AxisX.X, _0023_003Dzrgqz890sj_0024X9.AxisX.Y);
		}
	}

	private sealed class _0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D
	{
		public IfcRepresentationItem _0023_003DzY00lo3g_003D;

		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public double[] _0023_003Dz1MMYB1g_003D;

		public Action<IfcColourRgb> _0023_003DzdT8kPTzaWkIC;

		public Action<IfcSurfaceStyleRendering> _0023_003DzzaljjvyD9N9t;

		public Action<IfcSurfaceStyle> _0023_003DzJjT3dOU3oUsg;

		internal void _0023_003DzwGUFJy3uO_0024ggQ_00242tMg_003D_003D(IfcStyledItem _0023_003DzUBZd570_003D)
		{
			_0023_003DzUBZd570_003D.Item = _0023_003DzY00lo3g_003D;
			_0023_003DzUBZd570_003D.Styles.Add(_0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceStyle>(_0023_003Dz21HUDEVUHEpSH5mpkw_003D_003D));
		}

		internal void _0023_003Dz21HUDEVUHEpSH5mpkw_003D_003D(IfcSurfaceStyle _0023_003Dz_0024wQZnFQ_003D)
		{
			_0023_003Dz_0024wQZnFQ_003D.Side = IfcSurfaceSide.BOTH;
			_0023_003Dz_0024wQZnFQ_003D.Styles.Add(_0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceStyleRendering>(_0023_003Dzi8BNuW9yn81gW6GBmQ_003D_003D));
		}

		internal void _0023_003Dzi8BNuW9yn81gW6GBmQ_003D_003D(IfcSurfaceStyleRendering _0023_003Dz0aMijCyekOhAUfolBw_003D_003D)
		{
			_0023_003Dz0aMijCyekOhAUfolBw_003D_003D.SurfaceColour = _0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcColourRgb>(_0023_003Dzqlzg6E6gJN1JluENYg_003D_003D);
			_0023_003Dz0aMijCyekOhAUfolBw_003D_003D.Transparency = 1.0 - _0023_003Dz1MMYB1g_003D[3];
		}

		internal void _0023_003Dzqlzg6E6gJN1JluENYg_003D_003D(IfcColourRgb _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dzt_m8zV0_003D.Red = _0023_003Dz1MMYB1g_003D[0];
			_0023_003Dzt_m8zV0_003D.Green = _0023_003Dz1MMYB1g_003D[1];
			_0023_003Dzt_m8zV0_003D.Blue = _0023_003Dz1MMYB1g_003D[2];
		}
	}

	private sealed class _0023_003DzZK2pOM_00244OCZLhux1lrnZwYE_003D
	{
		public Plane _0023_003Dzrgqz890sj_0024X9;

		public IfcLocalPlacement _0023_003DzF1aUqeqCVqhl;

		public IfcElement[] _0023_003DzCCkC6mESLh79;

		public _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003Dz_0024R5tp4MkZz2TbVdq9w_003D_003D(IfcLocalPlacement _0023_003DzHPC6WX8_003D)
		{
			_0023_003DzHPC6WX8_003D.RelativePlacement = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dzrgqz890sj_0024X9);
			_0023_003DzHPC6WX8_003D.PlacementRelTo = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzhXgvnRtdjeYO;
		}

		internal IfcElement _0023_003DzLm4ApDafCn4xxzwbrA_003D_003D(Entity _0023_003DzbfrNXYE_003D)
		{
			return _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzhraSr_0024zjynpp(_0023_003DzbfrNXYE_003D, _0023_003DztBA2IMU_003D(_0023_003DzbfrNXYE_003D), _0023_003DzF1aUqeqCVqhl);
		}

		internal void _0023_003DzXXjO6Vtud3dDArzUCg_003D_003D(IfcRelAggregates _0023_003DzD_8KOiQ_003D)
		{
			_0023_003DzD_8KOiQ_003D.RelatingObject = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dz9j4kMjs_003D;
			_0023_003DzD_8KOiQ_003D.RelatedObjects.AddRange(_0023_003DzCCkC6mESLh79);
		}
	}

	private sealed class _0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dzr_3OnS8_003D;
	}

	private sealed class _0023_003Dza7lnd7YZzLw5dECkAmpz8_0024c_003D
	{
		public string _0023_003DzT3RVAR0_003D;

		public IfcRepresentationItem _0023_003DzY00lo3g_003D;

		public _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D;

		public Action<IfcShapeRepresentation> _0023_003DzBrlADxmFfW_T;

		internal void _0023_003Dz_0024R5tp4MkZz3tZQcvZQ_003D_003D(IfcProductDefinitionShape _0023_003Dz2t9nEMs_003D)
		{
			_0023_003Dz2t9nEMs_003D.Representations.Add(_0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcShapeRepresentation _0023_003DzwaU_0024oWk_003D)
			{
				_0023_003DzwaU_0024oWk_003D.ContextOfItems = _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().OfType<IfcGeometricRepresentationSubContext>().FirstOrDefault();
				_0023_003DzwaU_0024oWk_003D.RepresentationIdentifier = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445);
				_0023_003DzwaU_0024oWk_003D.RepresentationType = _0023_003DzT3RVAR0_003D;
				_0023_003DzwaU_0024oWk_003D.Items.Add(_0023_003DzY00lo3g_003D);
			}));
		}

		internal void _0023_003DzoitXHO7ZOb_0024hkQT1mg_003D_003D(IfcShapeRepresentation _0023_003DzwaU_0024oWk_003D)
		{
			_0023_003DzwaU_0024oWk_003D.ContextOfItems = _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().OfType<IfcGeometricRepresentationSubContext>().FirstOrDefault();
			_0023_003DzwaU_0024oWk_003D.RepresentationIdentifier = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445);
			_0023_003DzwaU_0024oWk_003D.RepresentationType = _0023_003DzT3RVAR0_003D;
			_0023_003DzwaU_0024oWk_003D.Items.Add(_0023_003DzY00lo3g_003D);
		}
	}

	private sealed class _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D
	{
		public Layer _0023_003DztIaJjPw_003D;

		public WriteIFC _0023_003DzopRx0_MBcTQs;

		internal void _0023_003Dz1Jnt6dQRxyAvrKhZuQ_003D_003D(IfcPresentationLayerWithStyle _0023_003DzGcl_0024E9o_003D)
		{
			_0023_003DzGcl_0024E9o_003D.Name = _0023_003DztIaJjPw_003D.Name;
			_0023_003DzGcl_0024E9o_003D.Description = _0023_003DztIaJjPw_003D.Description;
			_0023_003DzGcl_0024E9o_003D.Identifier = _0023_003DztIaJjPw_003D.Identifier;
		}
	}

	private sealed class _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D
	{
		public IfcOrientedEdge[] _0023_003DzHA50zAK6cV3tjZSm6M9PKZk_003D;

		public _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D _0023_003DqKEkg_ZrVnCodYhedSScMAdDNS4zMHt63qfZivuzl04A_003D;

		internal void _0023_003DzJuEEDg2ralUpMGYntVoZ3fw_003D(IfcEdgeLoop _0023_003Dzx63Fsgc_003D)
		{
			_0023_003Dzx63Fsgc_003D.EdgeList.AddRange(_0023_003DzHA50zAK6cV3tjZSm6M9PKZk_003D);
		}
	}

	private sealed class _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dzr_3OnS8_003D;

		internal IfcCartesianPoint _0023_003DzS4lO1Vy4DljFdXsAAnZOrwM_003D(Point4D _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzopRx0_MBcTQs._0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003DzB68dg9Q_003D, _0023_003Dzr_3OnS8_003D);
		}
	}

	private sealed class _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D
	{
		public IfcProduct _0023_003Dz2t9nEMs_003D;

		public WriteIFC _0023_003DzopRx0_MBcTQs;
	}

	private sealed class _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D
	{
		public int _0023_003Dzr_3OnS8_003D;

		public Vector3D _0023_003DzhLyxqqrgjQmH;

		internal void _0023_003DzgQ1vqkiM8NAt6Pa7Rkn0J_I_003D(IfcDirection _0023_003DzXrexKjY_003D)
		{
			if (_0023_003Dzr_3OnS8_003D == 2)
			{
				_0023_003DzXrexKjY_003D.SetXY(_0023_003DzhLyxqqrgjQmH.X, _0023_003DzhLyxqqrgjQmH.Y);
			}
			else
			{
				_0023_003DzXrexKjY_003D.SetXYZ(_0023_003DzhLyxqqrgjQmH.X, _0023_003DzhLyxqqrgjQmH.Y, _0023_003DzhLyxqqrgjQmH.Z);
			}
		}
	}

	private sealed class _0023_003DzjyxOC_00245BGEHAD9ifHhFIqaE_003D
	{
		public string _0023_003DzLqUGe70_003D;

		public object _0023_003DzYgyCuKI_003D;

		internal void _0023_003DzN89ZIz7dI8Cilt5Rfw_003D_003D(IfcPropertySingleValue _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Name = _0023_003DzLqUGe70_003D;
			_0023_003DzB68dg9Q_003D.NominalValue = _0023_003Dz16jHTM4IwUFi(_0023_003DzYgyCuKI_003D);
		}
	}

	private sealed class _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public ICurve _0023_003Dz8fpRyMu9aKjE;

		internal void _0023_003DzTcN3Hor1NAWpKfus5KZCARmZqiewWjw1Yw_003D_003D(IfcArbitraryOpenProfileDef _0023_003DzrasF10y2WHoh)
		{
			_0023_003DzrasF10y2WHoh.Curve = (IfcBoundedCurve)_0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(_0023_003Dz8fpRyMu9aKjE, 2);
		}
	}

	private sealed class _0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D
	{
		public Brep.OrientedEdge _0023_003DzJSE0zYhXeN9U;

		public _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D _0023_003DqwdA2p6nTT6BYp3F6lGPgH1kvw71IQwcC2cuWWyy0pUI_003D;

		internal void _0023_003Dz0sSVCN3lHxlyTzDqVcCFWi0_003D(IfcOrientedEdge _0023_003DzbfrNXYE_003D)
		{
			_0023_003DzbfrNXYE_003D.EdgeElement = _0023_003DqwdA2p6nTT6BYp3F6lGPgH1kvw71IQwcC2cuWWyy0pUI_003D._0023_003DqKEkg_ZrVnCodYhedSScMAdDNS4zMHt63qfZivuzl04A_003D._0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003DzVnEG1RlCHq_0024a[_0023_003DzJSE0zYhXeN9U.CurveIndex];
			_0023_003DzbfrNXYE_003D.Orientation = _0023_003DzJSE0zYhXeN9U.Sense;
		}
	}

	private sealed class _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D
	{
		public IfcFaceBound[] _0023_003DzD0ui41JsDUqJ;

		public Brep.Face _0023_003DzVxEs24GGIW60;

		public _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D _0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D;

		internal void _0023_003DzUX5gUS0iM_FlgUPVjjRMff0_003D(IfcAdvancedFace _0023_003DzhidJeNw_003D)
		{
			_0023_003DzhidJeNw_003D.Bounds.AddRange(_0023_003DzD0ui41JsDUqJ);
			_0023_003DzhidJeNw_003D.FaceSurface = _0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003DzopRx0_MBcTQs._0023_003DzSMhxGs3YAoH9(_0023_003DzVxEs24GGIW60.Surface);
			_0023_003DzhidJeNw_003D.SameSense = _0023_003DzVxEs24GGIW60.Sense;
		}
	}

	private sealed class _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D
	{
		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		internal void _0023_003Dqdkw96eG5LSuBhVPrmhBMcpC2fPzocncfJyKQQ0z0L7jIe_AgzvSd9cTALPQFERzV(int _0023_003Dz_7P0FDT12WXe, object _0023_003Dzz1OXOoQ_003D)
		{
			_0023_003DzopRx0_MBcTQs.UpdateProgress(_0023_003Dz_7P0FDT12WXe, 100.0, _0023_003DzopRx0_MBcTQs.WritingText, _0023_003DzmHS7frs_003D);
		}
	}

	private sealed class _0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D
	{
		public Point3D _0023_003DzkEYxO1SuR1Kw;

		public _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003DzS4lO1Vy4DljFdXsAAnZOrwM_003D(IfcVertexPoint _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.VertexGeometry = _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003DzkEYxO1SuR1Kw, 3);
		}
	}

	private sealed class _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D
	{
		public IfcCurve _0023_003DzDuY36bOR3A1N;

		public WriteIFC _0023_003DzopRx0_MBcTQs;

		public ICurve _0023_003Dz8fpRyMu9aKjE;

		public int _0023_003Dzr_3OnS8_003D;

		internal void _0023_003Dzn0hKGUjbjrZem7CtHmIhSiU_003D(IfcTrimmedCurve _0023_003DzTjnkGyI_003D)
		{
			_0023_003DzTjnkGyI_003D.BasisCurve = _0023_003DzDuY36bOR3A1N;
			_0023_003DzTjnkGyI_003D.MasterRepresentation = IfcTrimmingPreference.CARTESIAN;
			_0023_003DzTjnkGyI_003D.SenseAgreement = true;
			_0023_003DzTjnkGyI_003D.Trim1.Add(_0023_003DzopRx0_MBcTQs._0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dzr_3OnS8_003D));
			_0023_003DzTjnkGyI_003D.Trim2.Add(_0023_003DzopRx0_MBcTQs._0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003Dz8fpRyMu9aKjE.EndPoint, _0023_003Dzr_3OnS8_003D));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IfcStore _0023_003DzEJNBHGTz5yBl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<string, IfcRepresentationMap> _0023_003DzMm0lSfNSTaF1W1rLvg_003D_003D = new Dictionary<string, IfcRepresentationMap>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<string, IfcPresentationLayerWithStyle> _0023_003DzREmownUeweSatiBnxw_003D_003D = new Dictionary<string, IfcPresentationLayerWithStyle>();

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers | supportedLinearUnitsType.Yards | supportedLinearUnitsType.Nanometers | supportedLinearUnitsType.Decimeters | supportedLinearUnitsType.Decameters | supportedLinearUnitsType.Hectometers | supportedLinearUnitsType.Gigameters;

	public WriteIFC(IWorkspace workspace, string filePath)
		: this(workspace.Document, filePath)
	{
	}

	public WriteIFC(Document document, string filePath)
		: this(new WriteParamsWithUnits(document), filePath)
	{
	}

	public WriteIFC(IWorkspace workspace, Stream stream)
		: this(workspace.Document, stream)
	{
	}

	public WriteIFC(Document document, Stream stream)
		: this(new WriteParamsWithUnits(document), stream)
	{
	}

	public WriteIFC(WriteParamsWithUnits writeParams, string filePath)
		: base(writeParams, filePath)
	{
	}

	public WriteIFC(WriteParamsWithUnits writeParams, Stream stream)
		: base(writeParams, stream)
	{
	}

	private IEntityCollection _0023_003DzHOHdAUGvQ5_0024T()
	{
		return _0023_003DzEJNBHGTz5yBl.Instances;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzKou7i4SEAMz9(progress, ct);
	}

	private void _0023_003DzKou7i4SEAMz9(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2 = new _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D();
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		try
		{
			using (_0023_003DzEJNBHGTz5yBl = _0023_003DzKf43eWU_003D())
			{
				_0023_003Dz4ENzUjpRdRaY((base.FilePath != null) ? Path.GetFileName(base.FilePath) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943569), out var _0023_003DztAHTixqEBWMObrzq5g_003D_003D);
				_0023_003DzTgdiMpI_003D();
				IList<Entity> list = GetEntities();
				for (int i = 0; i < list.Count; i++)
				{
					Entity entity = list[i];
					try
					{
						_0023_003Dz5v26jTE_003D(entity, _0023_003DztAHTixqEBWMObrzq5g_003D_003D);
					}
					catch (Exception ex)
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012838) + i + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012802) + entity.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012815) + ex.Message);
					}
					if (!UpdateProgressAndCheckCancelled(i, list.Count, base.ComposingEntitiesText, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						break;
					}
				}
				UpdateProgressTo100(base.ComposingEntitiesText, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzmHS7frs_003D);
				try
				{
					if (base.Stream != null)
					{
						_0023_003DzEJNBHGTz5yBl.SaveAsIfc(base.Stream, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003Dqdkw96eG5LSuBhVPrmhBMcpC2fPzocncfJyKQQ0z0L7jIe_AgzvSd9cTALPQFERzV, leaveOpen: true);
						return;
					}
					IfcStore ifcStore = _0023_003DzEJNBHGTz5yBl;
					string filePath = base.FilePath;
					ReportProgressDelegate progDelegate = _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003Dqdkw96eG5LSuBhVPrmhBMcpC2fPzocncfJyKQQ0z0L7jIe_AgzvSd9cTALPQFERzV;
					ifcStore.SaveAs(filePath, null, progDelegate);
				}
				catch (Exception ex2)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012780));
					log.AppendLine(ex2.Message);
				}
			}
		}
		catch (Exception ex3)
		{
			log.AppendLine(ex3.Message);
			throw new EyeshotException(ex3.Message, ex3);
		}
		finally
		{
			CloseStream();
		}
	}

	private IfcStore _0023_003DzKf43eWU_003D()
	{
		IfcStore ifcStore = IfcStore.Create(new XbimEditorCredentials
		{
			ApplicationDevelopersName = organization,
			ApplicationFullName = string.Empty,
			ApplicationIdentifier = string.Empty,
			ApplicationVersion = string.Empty,
			EditorsFamilyName = author,
			EditorsOrganisationName = organization
		}, XbimSchemaVersion.Ifc4x3, XbimStoreType.InMemoryModel);
		ifcStore.Header.FileName.AuthorName.Add(author);
		ifcStore.Header.FileName.Organization.Add(organization);
		ifcStore.Header.FileName.OriginatingSystem = originatingSystem;
		LicenseManager._0023_003DzNrvBEfk_003D(out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
		ifcStore.Header.FileName.PreprocessorVersion = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012745), _0023_003DzQ3hPewo_003D.Major, _0023_003DzQ3hPewo_003D.Minor, _0023_003DzQ3hPewo_003D.Build);
		return ifcStore;
	}

	private void _0023_003Dz4ENzUjpRdRaY(string _0023_003DzrE_0024rpFc_003D, out IfcBuilding _0023_003DztAHTixqEBWMObrzq5g_003D_003D)
	{
		using ITransaction transaction = _0023_003DzEJNBHGTz5yBl.BeginTransaction(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012451));
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2 = new _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D();
		IfcProject ifcProject = _0023_003DzHOHdAUGvQ5_0024T().New<IfcProject>();
		ifcProject.Name = _0023_003DzrE_0024rpFc_003D;
		_0023_003Dzrj7tCC30goeZ(ifcProject);
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzV0QqRpQ_003D = _0023_003DzHOHdAUGvQ5_0024T().New<IfcGeometricRepresentationContext>(_0023_003DzEuZYWlcXDDzbznjR00k_OEk_003D);
		_0023_003DzHOHdAUGvQ5_0024T().New<IfcGeometricRepresentationSubContext>(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzhNTedbh2Wu5lfOvFrA_003D_003D);
		ifcProject.RepresentationContexts.Add(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzV0QqRpQ_003D);
		_0023_003DztAHTixqEBWMObrzq5g_003D_003D = _0023_003DzHOHdAUGvQ5_0024T().New<IfcBuilding>(_0023_003DzxXLQxSOlUpp29kxKUY8chR8_003D);
		_0023_003DzHOHdAUGvQ5_0024T().New<IfcRelContainedInSpatialStructure>().RelatingStructure = _0023_003DztAHTixqEBWMObrzq5g_003D_003D;
		ifcProject.AddBuilding(_0023_003DztAHTixqEBWMObrzq5g_003D_003D);
		transaction.Commit();
	}

	private void _0023_003Dzrj7tCC30goeZ(IfcProject _0023_003DzBEvOagU_003D)
	{
		IfcUnitAssignment ifcUnitAssignment = _0023_003DzHOHdAUGvQ5_0024T().New<IfcUnitAssignment>();
		switch (units)
		{
		case linearUnitsType.Inches:
		case linearUnitsType.Microinches:
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.LENGTHUNIT, Xbim.Ifc4x3.MeasureResource.ConversionBasedUnit.Inch);
			break;
		case linearUnitsType.Feet:
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.LENGTHUNIT, Xbim.Ifc4x3.MeasureResource.ConversionBasedUnit.Foot);
			break;
		case linearUnitsType.Miles:
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.LENGTHUNIT, Xbim.Ifc4x3.MeasureResource.ConversionBasedUnit.Mile);
			break;
		case linearUnitsType.Yards:
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.LENGTHUNIT, Xbim.Ifc4x3.MeasureResource.ConversionBasedUnit.Yard);
			break;
		default:
			ifcUnitAssignment.Units.Add(_0023_003DzHOHdAUGvQ5_0024T().New<IfcSIUnit>(_0023_003DzdNbun9nCoIFdswE7PfoszwU_003D));
			break;
		}
		ifcUnitAssignment.Units.Add(_0023_003DzHOHdAUGvQ5_0024T().New<IfcSIUnit>(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzWTj2EHpv1u1iMOGeBhHIGJo_003D));
		_0023_003DzBEvOagU_003D.UnitsInContext = ifcUnitAssignment;
	}

	private void _0023_003Dz5v26jTE_003D(Entity _0023_003Dz9j7EUB0_003D, IfcBuilding _0023_003DztAHTixqEBWMObrzq5g_003D_003D)
	{
		using ITransaction transaction = _0023_003DzEJNBHGTz5yBl.BeginTransaction(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012444));
		Type _0023_003DzNDQ_E88_003D = _0023_003DztBA2IMU_003D(_0023_003Dz9j7EUB0_003D);
		IfcElement item = _0023_003DzhraSr_0024zjynpp(_0023_003Dz9j7EUB0_003D, _0023_003DzNDQ_E88_003D, null);
		_0023_003DztAHTixqEBWMObrzq5g_003D_003D.ContainsElements.First().RelatedElements.Add(item);
		transaction.Commit();
	}

	private IfcElement _0023_003DzhraSr_0024zjynpp(Entity _0023_003Dz9j7EUB0_003D, Type _0023_003DzNDQ_E88_003D, IfcObjectPlacement _0023_003DzhXgvnRtdjeYO)
	{
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2 = new _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D();
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DzhXgvnRtdjeYO = _0023_003DzhXgvnRtdjeYO;
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D = (IfcElement)_0023_003DzHOHdAUGvQ5_0024T().New(_0023_003DzNDQ_E88_003D);
		if (_0023_003Dz9j7EUB0_003D is BlockReference blockReference && blocks[blockReference.BlockName].Entities.Any((Entity _0023_003DzbfrNXYE_003D) => _0023_003DzbfrNXYE_003D.IfcProperties?.GUID != null))
		{
			_0023_003DzZK2pOM_00244OCZLhux1lrnZwYE_003D CS_0024_003C_003E8__locals19 = new _0023_003DzZK2pOM_00244OCZLhux1lrnZwYE_003D();
			CS_0024_003C_003E8__locals19._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2;
			blockReference.Transformation.GetFrame(out var origin, out var axisX, out var axisY, out var _);
			CS_0024_003C_003E8__locals19._0023_003Dzrgqz890sj_0024X9 = new Plane(origin, axisX, axisY);
			CS_0024_003C_003E8__locals19._0023_003DzF1aUqeqCVqhl = _0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcLocalPlacement _0023_003DzHPC6WX8_003D)
			{
				_0023_003DzHPC6WX8_003D.RelativePlacement = CS_0024_003C_003E8__locals19._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(CS_0024_003C_003E8__locals19._0023_003Dzrgqz890sj_0024X9);
				_0023_003DzHPC6WX8_003D.PlacementRelTo = CS_0024_003C_003E8__locals19._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzhXgvnRtdjeYO;
			});
			CS_0024_003C_003E8__locals19._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dz9j4kMjs_003D.ObjectPlacement = CS_0024_003C_003E8__locals19._0023_003DzF1aUqeqCVqhl;
			CS_0024_003C_003E8__locals19._0023_003DzCCkC6mESLh79 = blocks[blockReference.BlockName].Entities.Select(CS_0024_003C_003E8__locals19._0023_003DzLm4ApDafCn4xxzwbrA_003D_003D).ToArray();
			_0023_003DzHOHdAUGvQ5_0024T().New<IfcRelAggregates>(CS_0024_003C_003E8__locals19._0023_003DzXXjO6Vtud3dDArzUCg_003D_003D);
		}
		else
		{
			_0023_003Dza7lnd7YZzLw5dECkAmpz8_0024c_003D CS_0024_003C_003E8__locals23 = new _0023_003Dza7lnd7YZzLw5dECkAmpz8_0024c_003D();
			CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D = _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2;
			CS_0024_003C_003E8__locals23._0023_003DzY00lo3g_003D = _0023_003DzDzv42v4D2Pvm(_0023_003Dz9j7EUB0_003D, out CS_0024_003C_003E8__locals23._0023_003DzT3RVAR0_003D);
			if (CS_0024_003C_003E8__locals23._0023_003DzY00lo3g_003D != null)
			{
				CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003Dz9j4kMjs_003D.Representation = _0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcProductDefinitionShape _0023_003Dz2t9nEMs_003D)
				{
					_0023_003Dz2t9nEMs_003D.Representations.Add(CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcShapeRepresentation _0023_003DzwaU_0024oWk_003D)
					{
						_0023_003DzwaU_0024oWk_003D.ContextOfItems = CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().OfType<IfcGeometricRepresentationSubContext>().FirstOrDefault();
						_0023_003DzwaU_0024oWk_003D.RepresentationIdentifier = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445);
						_0023_003DzwaU_0024oWk_003D.RepresentationType = CS_0024_003C_003E8__locals23._0023_003DzT3RVAR0_003D;
						_0023_003DzwaU_0024oWk_003D.Items.Add(CS_0024_003C_003E8__locals23._0023_003DzY00lo3g_003D);
					}));
				});
				CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003Dz9j4kMjs_003D.ObjectPlacement = _0023_003DzHOHdAUGvQ5_0024T().New<IfcLocalPlacement>(CS_0024_003C_003E8__locals23._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzLtXe1H8JNNM7SWSWMg_003D_003D);
			}
		}
		if (_0023_003Dz9j7EUB0_003D.IfcProperties?.Openings != null)
		{
			using List<Entity>.Enumerator enumerator = _0023_003Dz9j7EUB0_003D.IfcProperties.Openings.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D _0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D2 = new _0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D();
				_0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D2._0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D = _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2;
				_0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D2._0023_003DzVlqgr54_003D = enumerator.Current;
				_0023_003DzHOHdAUGvQ5_0024T().New<IfcRelVoidsElement>(_0023_003DzL02qUCChxQqmGw_0024qoHMR5bY_003D2._0023_003DzcXl41NNh4JUzsOUEug_003D_003D);
			}
		}
		_0023_003DzsXWLaSI_003D(_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D, _0023_003Dz9j7EUB0_003D.IfcProperties);
		if (!_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D.Name.HasValue)
		{
			if (_0023_003Dz9j7EUB0_003D is BlockReference blockReference2)
			{
				_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D.Name = blockReference2.BlockName;
			}
			else if (_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D is IfcBuildingElementProxy)
			{
				_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D.Name = _0023_003Dz9j7EUB0_003D.GetType().Name;
			}
		}
		return _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9j4kMjs_003D;
	}

	private void _0023_003DzLHa4pskdzOao(Entity _0023_003Dz9j7EUB0_003D, IfcRepresentationItem _0023_003DzY00lo3g_003D)
	{
		_0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D CS_0024_003C_003E8__locals7 = new _0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D();
		CS_0024_003C_003E8__locals7._0023_003DzY00lo3g_003D = _0023_003DzY00lo3g_003D;
		CS_0024_003C_003E8__locals7._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzREmownUeweSatiBnxw_003D_003D[_0023_003Dz9j7EUB0_003D.LayerName].AssignedItems.Add(CS_0024_003C_003E8__locals7._0023_003DzY00lo3g_003D);
		if (_0023_003Dz9j7EUB0_003D.ColorMethod == colorMethodType.byEntity)
		{
			CS_0024_003C_003E8__locals7._0023_003Dz1MMYB1g_003D = Utility.ColorToDoubleArray(_0023_003Dz9j7EUB0_003D.Color);
			_0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcStyledItem _0023_003DzUBZd570_003D)
			{
				_0023_003DzUBZd570_003D.Item = CS_0024_003C_003E8__locals7._0023_003DzY00lo3g_003D;
				_0023_003DzUBZd570_003D.Styles.Add(CS_0024_003C_003E8__locals7._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceStyle>(CS_0024_003C_003E8__locals7._0023_003Dz21HUDEVUHEpSH5mpkw_003D_003D));
			});
		}
	}

	private void _0023_003DzTgdiMpI_003D()
	{
		using ITransaction transaction = _0023_003DzEJNBHGTz5yBl.BeginTransaction(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012427));
		using (IEnumerator<Layer> enumerator = layers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2 = new _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D();
				_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2._0023_003DzopRx0_MBcTQs = this;
				_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2._0023_003DztIaJjPw_003D = enumerator.Current;
				_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D _0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2 = new _0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D();
				_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2;
				IfcPresentationLayerWithStyle ifcPresentationLayerWithStyle = _0023_003DzHOHdAUGvQ5_0024T().New<IfcPresentationLayerWithStyle>(_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dz1Jnt6dQRxyAvrKhZuQ_003D_003D);
				_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003Dz1MMYB1g_003D = Utility.ColorToDoubleArray(_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DztIaJjPw_003D.Color);
				IfcSurfaceStyle item = _0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceStyle>(_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003DzJNtHbIIW6e_V5bm3DQ_003D_003D);
				ifcPresentationLayerWithStyle.LayerStyles.Add(item);
				_0023_003DzREmownUeweSatiBnxw_003D_003D.Add(_0023_003Dz6qv54f1K__g1MoxxEdjUf54_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DztIaJjPw_003D.Name, ifcPresentationLayerWithStyle);
			}
		}
		transaction.Commit();
	}

	private IfcCartesianPoint[] _0023_003Dz4_0024_0024dqN8cEutytsVAlxBIFwEWUQpi(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003Dzr_3OnS8_003D)
	{
		IfcCartesianPoint[] array = new IfcCartesianPoint[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length];
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			array[i] = _0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzr_3OnS8_003D);
		}
		return array;
	}

	private IfcCartesianPoint _0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(Point3D _0023_003DzB68dg9Q_003D, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D2 = new _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D();
		_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D2._0023_003DzB68dg9Q_003D = _0023_003DzB68dg9Q_003D;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcCartesianPoint>(_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D2._0023_003DzUhOr4myML98YCVwCTdRwpAE3i6gUu9MhCQ_003D_003D);
	}

	private IfcVertexPoint _0023_003DzrH8XYcQ_ivq_5Azi_0024A_003D_003D(Point3D _0023_003DzB68dg9Q_003D)
	{
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2 = new _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D();
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003DzB68dg9Q_003D = _0023_003DzB68dg9Q_003D;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcVertexPoint>(_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003Dz2qLXMfp5Shhj0WxWL4usO5o_003D);
	}

	private IfcAxis1Placement _0023_003Dz2xhirm6y59i5l6ZkhA_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D _0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D2 = new _0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D();
		_0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D2._0023_003Dzrgqz890sj_0024X9 = _0023_003Dzrgqz890sj_0024X9;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcAxis1Placement>(_0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D2._0023_003DzCrSXwcuvH34t9LXprmZktIk_003D);
	}

	private IfcAxis2Placement2D _0023_003DznMo_0024O0WT8rrRk5usSQ_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2 = new _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D();
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003Dzrgqz890sj_0024X9 = _0023_003Dzrgqz890sj_0024X9;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcAxis2Placement2D>(_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D2._0023_003Dz6RaUgbTLHdPjndDXQkvRCDH4x0oO);
	}

	private IfcAxis2Placement3D _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003DzGOWHJOJdHJnQn0HLtYvTwFA_003D CS_0024_003C_003E8__locals10 = new _0023_003DzGOWHJOJdHJnQn0HLtYvTwFA_003D();
		CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals10._0023_003Dzrgqz890sj_0024X9 = _0023_003Dzrgqz890sj_0024X9;
		return _0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcAxis2Placement3D _0023_003DzB68dg9Q_003D)
		{
			_0023_003DzB68dg9Q_003D.Location = CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcCartesianPoint _0023_003Dz1cdkDps_003D)
			{
				_0023_003Dz1cdkDps_003D.SetXYZ(CS_0024_003C_003E8__locals10._0023_003Dzrgqz890sj_0024X9.Origin.X, CS_0024_003C_003E8__locals10._0023_003Dzrgqz890sj_0024X9.Origin.Y, CS_0024_003C_003E8__locals10._0023_003Dzrgqz890sj_0024X9.Origin.Z);
			});
			_0023_003DzB68dg9Q_003D.RefDirection = CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(CS_0024_003C_003E8__locals10._0023_003DzTMmTob4Um0KVJM0_SFQbndvx6JEp);
			_0023_003DzB68dg9Q_003D.Axis = CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs._0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(CS_0024_003C_003E8__locals10._0023_003Dz28i371rYZqoa8TmjzJ3EApqIqF3X);
		});
	}

	private IfcDirection _0023_003Dz2X4EMKT5qHte(Vector3D _0023_003DzhLyxqqrgjQmH, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2 = new _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D();
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzhLyxqqrgjQmH = _0023_003DzhLyxqqrgjQmH;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcDirection>(_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzgQ1vqkiM8NAt6Pa7Rkn0J_I_003D);
	}

	private IfcExtrudedAreaSolid _0023_003Dzwss2asTOwvMBS1Z1owkF_s4_003D(Region _0023_003DzCRq4LBU_003D, Vector3D _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D)
	{
		_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D CS_0024_003C_003E8__locals22 = new _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D();
		CS_0024_003C_003E8__locals22._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals22._0023_003DzCRq4LBU_003D = _0023_003DzCRq4LBU_003D;
		CS_0024_003C_003E8__locals22._0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D = _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D;
		Transformation xform = Transformation.CreateAlignment(CS_0024_003C_003E8__locals22._0023_003DzCRq4LBU_003D.Plane, Plane.XY);
		CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D = new ICurve[CS_0024_003C_003E8__locals22._0023_003DzCRq4LBU_003D.ContourList.Count];
		for (int i = 0; i < CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D.Length; i++)
		{
			CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D[i] = (ICurve)CS_0024_003C_003E8__locals22._0023_003DzCRq4LBU_003D.ContourList[i].Clone();
			((Entity)CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D[i]).TransformBy(xform);
			if (i > 0)
			{
				CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D[i].Reverse();
			}
		}
		CS_0024_003C_003E8__locals22._0023_003DzCJkr8nY_003D = (Vector3D)CS_0024_003C_003E8__locals22._0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Clone();
		CS_0024_003C_003E8__locals22._0023_003DzCJkr8nY_003D.Normalize();
		CS_0024_003C_003E8__locals22._0023_003DzCJkr8nY_003D.TransformBy(xform);
		return _0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcExtrudedAreaSolid _0023_003Dz28FDiEs_003D)
		{
			_0023_003Dz28FDiEs_003D.SweptArea = CS_0024_003C_003E8__locals22._0023_003DzopRx0_MBcTQs._0023_003Dz_0024eiwUEyChs5pRCQLHQ_003D_003D(CS_0024_003C_003E8__locals22._0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D);
			_0023_003Dz28FDiEs_003D.Position = CS_0024_003C_003E8__locals22._0023_003DzopRx0_MBcTQs._0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(CS_0024_003C_003E8__locals22._0023_003DzCRq4LBU_003D.Plane);
			_0023_003Dz28FDiEs_003D.ExtrudedDirection = CS_0024_003C_003E8__locals22._0023_003DzopRx0_MBcTQs._0023_003Dz2X4EMKT5qHte(CS_0024_003C_003E8__locals22._0023_003DzCJkr8nY_003D, 3);
			_0023_003Dz28FDiEs_003D.Depth = CS_0024_003C_003E8__locals22._0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Length;
		});
	}

	private IfcArbitraryClosedProfileDef _0023_003Dz_0024eiwUEyChs5pRCQLHQ_003D_003D(IReadOnlyList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		IfcArbitraryClosedProfileDef obj = ((_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count == 1) ? _0023_003DzZhF4vKBCPT2PCydGyJD6ixubMckG(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[0]) : _0023_003Dzh9tqbJctfJznlzohaACsZ4Yev6Dy6TQO5w_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D));
		obj.ProfileType = IfcProfileTypeEnum.AREA;
		return obj;
	}

	private IfcArbitraryClosedProfileDef _0023_003DzZhF4vKBCPT2PCydGyJD6ixubMckG(ICurve _0023_003DziiiMrhXhZ8sK)
	{
		_0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D _0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D2 = new _0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D();
		_0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D2._0023_003DziiiMrhXhZ8sK = _0023_003DziiiMrhXhZ8sK;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcArbitraryClosedProfileDef>(_0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D2._0023_003DzzNOeXLeeG4q2aR0DklS8ru5xUR9d54zItg_003D_003D);
	}

	private IfcArbitraryProfileDefWithVoids _0023_003Dzh9tqbJctfJznlzohaACsZ4Yev6Dy6TQO5w_003D_003D(IReadOnlyList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D CS_0024_003C_003E8__locals6 = new _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D();
		CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals6._0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D;
		return _0023_003DzHOHdAUGvQ5_0024T().New(delegate(IfcArbitraryProfileDefWithVoids _0023_003DzrasF10y2WHoh)
		{
			_0023_003DzrasF10y2WHoh.ProfileType = IfcProfileTypeEnum.AREA;
			_0023_003DzrasF10y2WHoh.OuterCurve = CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs._0023_003Dz9AYS91Khm9S5(CS_0024_003C_003E8__locals6._0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[0], 2);
			_0023_003DzrasF10y2WHoh.InnerCurves.AddRange(CS_0024_003C_003E8__locals6._0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Skip(1).Select(CS_0024_003C_003E8__locals6._0023_003DzB8RcG8aoDoEGdq3j2Xm60cvqJ4bP8L7IqxdjnC_iJqs2));
		});
	}

	private IfcProfileDef _0023_003DzrQZQ07zOg6tEq4523A_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (!_0023_003Dz8fpRyMu9aKjE.IsClosed)
		{
			return _0023_003DzGHeDi9OBB8IUbcUeSdDMQgYMhN3c(_0023_003Dz8fpRyMu9aKjE);
		}
		return _0023_003DzZhF4vKBCPT2PCydGyJD6ixubMckG(_0023_003Dz8fpRyMu9aKjE);
	}

	private IfcArbitraryOpenProfileDef _0023_003DzGHeDi9OBB8IUbcUeSdDMQgYMhN3c(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2 = new _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D();
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz8fpRyMu9aKjE = _0023_003Dz8fpRyMu9aKjE;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcArbitraryOpenProfileDef>(_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzTcN3Hor1NAWpKfus5KZCARmZqiewWjw1Yw_003D_003D);
	}

	private void _0023_003DzsXWLaSI_003D(IfcProduct _0023_003Dz2t9nEMs_003D, IfcProperties _0023_003Dz6aNFuJ9YxDVt)
	{
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2 = new _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D();
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz2t9nEMs_003D = _0023_003Dz2t9nEMs_003D;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzopRx0_MBcTQs = this;
		if (_0023_003Dz6aNFuJ9YxDVt == null)
		{
			return;
		}
		if (_0023_003Dz6aNFuJ9YxDVt.GUID != null)
		{
			_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz2t9nEMs_003D.GlobalId = _0023_003Dz6aNFuJ9YxDVt.GUID;
		}
		if (_0023_003Dz6aNFuJ9YxDVt.Identification.TryGetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), out var value))
		{
			_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz2t9nEMs_003D.Name = value;
		}
		if (_0023_003Dz6aNFuJ9YxDVt.Identification.TryGetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), out var value2))
		{
			_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz2t9nEMs_003D.Description = value2;
		}
		if (_0023_003Dz6aNFuJ9YxDVt.Properties == null)
		{
			return;
		}
		foreach (KeyValuePair<string, Dictionary<string, object>> property in _0023_003Dz6aNFuJ9YxDVt.Properties)
		{
			_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D _0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D2 = new _0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D();
			_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2;
			_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D2._0023_003DzkRYWt2a_0024teGb = property.Key ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012414);
			_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D2._0023_003Dz3mCbtDmJcG4_0024 = property.Value ?? new Dictionary<string, object>();
			_0023_003DzHOHdAUGvQ5_0024T().New<IfcRelDefinesByProperties>(_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D2._0023_003DzuyZ18UiZRRtuxnCb_Q_003D_003D);
		}
	}

	private static IfcValue _0023_003Dz16jHTM4IwUFi(object _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D == null)
		{
			return new IfcText(string.Empty);
		}
		if (_0023_003DzPzO_0024GUk_003D is Tuple<string, double> tuple)
		{
			return new IfcReal(tuple.Item2);
		}
		if (!(_0023_003DzPzO_0024GUk_003D is bool value))
		{
			if (!(_0023_003DzPzO_0024GUk_003D is int num))
			{
				if (!(_0023_003DzPzO_0024GUk_003D is long value2))
				{
					if (!(_0023_003DzPzO_0024GUk_003D is double val))
					{
						if (!(_0023_003DzPzO_0024GUk_003D is float value3))
						{
							if (!(_0023_003DzPzO_0024GUk_003D is decimal value4))
							{
								if (!(_0023_003DzPzO_0024GUk_003D is DateTime dateTime))
								{
									if (_0023_003DzPzO_0024GUk_003D is string val2)
									{
										return new IfcText(val2);
									}
									return new IfcText(_0023_003DzPzO_0024GUk_003D.ToString());
								}
								return new IfcText(dateTime.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010443), CultureInfo.InvariantCulture));
							}
							return new IfcNumericMeasure(Convert.ToDouble(value4));
						}
						return new IfcNumericMeasure(Convert.ToDouble(value3));
					}
					return new IfcNumericMeasure(val);
				}
				return new IfcInteger(Convert.ToInt64(value2));
			}
			return new IfcInteger(num);
		}
		return new IfcLogical(value);
	}

	private static Type _0023_003DztBA2IMU_003D(Entity _0023_003Dz9j7EUB0_003D)
	{
		ifcElementType ifcElementType2 = _0023_003Dz9j7EUB0_003D.IfcProperties?.ElementType ?? ifcElementType.IfcBuildingElementProxy;
		switch (ifcElementType2)
		{
		case ifcElementType.IfcWall:
			return typeof(IfcWall);
		case ifcElementType.IfcWallStandardCase:
			return typeof(IfcWallStandardCase);
		case ifcElementType.IfcSlab:
			return typeof(IfcSlab);
		case ifcElementType.IfcRoof:
			return typeof(IfcRoof);
		case ifcElementType.IfcColumn:
			return typeof(IfcColumn);
		case ifcElementType.IfcBeam:
			return typeof(IfcBeam);
		case ifcElementType.IfcFooting:
			return typeof(IfcFooting);
		case ifcElementType.IfcWindow:
			return typeof(IfcWindow);
		case ifcElementType.IfcDoor:
			return typeof(IfcDoor);
		case ifcElementType.IfcMember:
			return typeof(IfcMember);
		case ifcElementType.IfcFurnishingElement:
			return typeof(IfcFurnishingElement);
		case ifcElementType.IfcOpeningElement:
			return typeof(IfcOpeningElement);
		case ifcElementType.IfcElementAssembly:
			return typeof(IfcElementAssembly);
		case ifcElementType.Undefined:
		case ifcElementType.IfcBuildingElementProxy:
			return typeof(IfcBuildingElementProxy);
		default:
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012400), ifcElementType2, null);
		}
	}

	private IfcRepresentationItem _0023_003DzDzv42v4D2Pvm(Entity _0023_003Dz9j7EUB0_003D, out string _0023_003DzT3RVAR0_003D)
	{
		IfcRepresentationItem ifcRepresentationItem;
		if (_0023_003Dz9j7EUB0_003D.IfcProperties?.ProfileDef != null && _0023_003Dz9j7EUB0_003D.IfcProperties?.ExtrusionAmount != null)
		{
			_0023_003DzT3RVAR0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012354);
			ifcRepresentationItem = _0023_003Dzwss2asTOwvMBS1Z1owkF_s4_003D(_0023_003Dz9j7EUB0_003D.IfcProperties.ProfileDef, _0023_003Dz9j7EUB0_003D.IfcProperties.ExtrusionAmount);
		}
		else
		{
			_0023_003DzT3RVAR0_003D = string.Empty;
			IfcRepresentationItem ifcRepresentationItem2 = ((_0023_003Dz9j7EUB0_003D is Mesh _0023_003DzGGJSiQk_003D) ? _0023_003DzDzv42v4D2Pvm(_0023_003DzGGJSiQk_003D, out _0023_003DzT3RVAR0_003D) : ((_0023_003Dz9j7EUB0_003D is Solid _0023_003DzjpT7ebA_003D) ? _0023_003DzDzv42v4D2Pvm(_0023_003DzjpT7ebA_003D, out _0023_003DzT3RVAR0_003D) : ((_0023_003Dz9j7EUB0_003D is Brep _0023_003DzGb8kdyZ1x5nj) ? _0023_003DzDzv42v4D2Pvm(_0023_003DzGb8kdyZ1x5nj, out _0023_003DzT3RVAR0_003D) : ((_0023_003Dz9j7EUB0_003D is BlockReference _0023_003Dz5I3b_GM_003D) ? _0023_003DzDzv42v4D2Pvm(_0023_003Dz5I3b_GM_003D, out _0023_003DzT3RVAR0_003D) : ((!(_0023_003Dz9j7EUB0_003D is ICurve _0023_003Dz8fpRyMu9aKjE)) ? _0023_003Dz7RhVPwnxEPI2(_0023_003Dz9j7EUB0_003D) : _0023_003DzDzv42v4D2Pvm(_0023_003Dz8fpRyMu9aKjE, 3, out _0023_003DzT3RVAR0_003D))))));
			ifcRepresentationItem = ifcRepresentationItem2;
		}
		if (ifcRepresentationItem != null)
		{
			_0023_003DzLHa4pskdzOao(_0023_003Dz9j7EUB0_003D, ifcRepresentationItem);
		}
		return ifcRepresentationItem;
	}

	private IfcRepresentationItem _0023_003Dz7RhVPwnxEPI2(Entity _0023_003Dz9j7EUB0_003D)
	{
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012593) + _0023_003Dz9j7EUB0_003D.GetType().Name);
		return null;
	}

	private IfcMappedItem _0023_003DzDzv42v4D2Pvm(BlockReference _0023_003Dz5I3b_GM_003D, out string _0023_003DzT3RVAR0_003D)
	{
		_0023_003DzT3RVAR0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012576);
		IfcMappedItem ifcMappedItem = _0023_003DzHOHdAUGvQ5_0024T().New<IfcMappedItem>();
		ifcMappedItem.MappingSource = _0023_003Dzmen01USZsjj8(blocks[_0023_003Dz5I3b_GM_003D.BlockName]);
		_0023_003Dz5I3b_GM_003D.Transformation.GetFrame(out var origin, out var axisX, out var axisY, out var axisZ);
		double scaleFactorX = _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorX;
		double scaleFactorY = _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorY;
		double scaleFactorZ = _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorZ;
		axisX /= _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorX;
		axisY /= _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorY;
		axisZ /= _0023_003Dz5I3b_GM_003D.Transformation.ScaleFactorZ;
		IfcCartesianTransformationOperator3D ifcCartesianTransformationOperator3D;
		if (_0023_003Dz5I3b_GM_003D.Transformation.IsScaleFactorUniform())
		{
			ifcCartesianTransformationOperator3D = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCartesianTransformationOperator3D>();
			ifcCartesianTransformationOperator3D.Scale = scaleFactorX;
		}
		else
		{
			IfcCartesianTransformationOperator3DnonUniform ifcCartesianTransformationOperator3DnonUniform = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCartesianTransformationOperator3DnonUniform>();
			ifcCartesianTransformationOperator3DnonUniform.Scale = scaleFactorX;
			ifcCartesianTransformationOperator3DnonUniform.Scale2 = scaleFactorY;
			ifcCartesianTransformationOperator3DnonUniform.Scale3 = scaleFactorZ;
			ifcCartesianTransformationOperator3D = ifcCartesianTransformationOperator3DnonUniform;
		}
		ifcCartesianTransformationOperator3D.LocalOrigin = _0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(origin, 3);
		ifcCartesianTransformationOperator3D.Axis1 = _0023_003Dz2X4EMKT5qHte(axisX, 3);
		ifcCartesianTransformationOperator3D.Axis2 = _0023_003Dz2X4EMKT5qHte(axisY, 3);
		ifcCartesianTransformationOperator3D.Axis3 = _0023_003Dz2X4EMKT5qHte(axisZ, 3);
		ifcMappedItem.MappingTarget = ifcCartesianTransformationOperator3D;
		return ifcMappedItem;
	}

	private IfcRepresentationMap _0023_003Dzmen01USZsjj8(Block _0023_003DzLeyHB00_003D)
	{
		if (!_0023_003DzMm0lSfNSTaF1W1rLvg_003D_003D.TryGetValue(_0023_003DzLeyHB00_003D.Name, out var value))
		{
			value = _0023_003DzHOHdAUGvQ5_0024T().New<IfcRepresentationMap>();
			Plane _0023_003Dzrgqz890sj_0024X = new Plane(_0023_003DzLeyHB00_003D.BasePoint, Vector3D.AxisX, Vector3D.AxisY);
			value.MappingOrigin = _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dzrgqz890sj_0024X);
			IfcShapeRepresentation ifcShapeRepresentation = _0023_003DzHOHdAUGvQ5_0024T().New<IfcShapeRepresentation>();
			ifcShapeRepresentation.RepresentationIdentifier = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445);
			ifcShapeRepresentation.RepresentationType = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012576);
			foreach (Entity entity in _0023_003DzLeyHB00_003D.Entities)
			{
				string _0023_003DzT3RVAR0_003D;
				IfcRepresentationItem item = _0023_003DzDzv42v4D2Pvm(entity, out _0023_003DzT3RVAR0_003D);
				ifcShapeRepresentation.Items.Add(item);
			}
			value.MappedRepresentation = ifcShapeRepresentation;
			_0023_003DzMm0lSfNSTaF1W1rLvg_003D_003D.Add(_0023_003DzLeyHB00_003D.Name, value);
		}
		return value;
	}

	private IfcTriangulatedFaceSet _0023_003DzDzv42v4D2Pvm(Solid _0023_003DzjpT7ebA_003D, out string _0023_003DzT3RVAR0_003D)
	{
		return _0023_003DzDzv42v4D2Pvm(_0023_003DzjpT7ebA_003D.ConvertToMesh(), out _0023_003DzT3RVAR0_003D);
	}

	private IfcTriangulatedFaceSet _0023_003DzDzv42v4D2Pvm(Mesh _0023_003DzGGJSiQk_003D, out string _0023_003DzT3RVAR0_003D)
	{
		_0023_003DzT3RVAR0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012537);
		IfcTriangulatedFaceSet ifcTriangulatedFaceSet = _0023_003DzHOHdAUGvQ5_0024T().New<IfcTriangulatedFaceSet>();
		ifcTriangulatedFaceSet.Closed = _0023_003DzGGJSiQk_003D.IsClosed;
		IfcCartesianPointList3D ifcCartesianPointList3D = (ifcTriangulatedFaceSet.Coordinates = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCartesianPointList3D>());
		for (int i = 0; i < _0023_003DzGGJSiQk_003D.Vertices.Length; i++)
		{
			IEnumerable<IfcLengthMeasure> values = _0023_003DzGGJSiQk_003D.Vertices[i].ToArray().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzN8sktxPFxpCEhssFCNIZcePqbLkG);
			ifcCartesianPointList3D.CoordList.GetAt(i).AddRange(values);
		}
		for (int j = 0; j < _0023_003DzGGJSiQk_003D.Triangles.Length; j++)
		{
			IEnumerable<IfcPositiveInteger> values2 = from _0023_003Dz77g161c_003D in _0023_003DzGGJSiQk_003D.Triangles[j].ToArray()
				select new IfcPositiveInteger(_0023_003Dz77g161c_003D + 1);
			ifcTriangulatedFaceSet.CoordIndex.GetAt(j).AddRange(values2);
		}
		return ifcTriangulatedFaceSet;
	}

	private IfcCurve _0023_003Dz9AYS91Khm9S5(ICurve _0023_003Dz8fpRyMu9aKjE, int _0023_003Dzr_3OnS8_003D)
	{
		string _0023_003DzT3RVAR0_003D;
		return (IfcCurve)_0023_003DzDzv42v4D2Pvm(_0023_003Dz8fpRyMu9aKjE, _0023_003Dzr_3OnS8_003D, out _0023_003DzT3RVAR0_003D);
	}

	private IfcRepresentationItem _0023_003DzDzv42v4D2Pvm(ICurve _0023_003Dz8fpRyMu9aKjE, int _0023_003Dzr_3OnS8_003D, out string _0023_003DzT3RVAR0_003D)
	{
		_0023_003DzT3RVAR0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012526);
		if (!(_0023_003Dz8fpRyMu9aKjE is Arc _0023_003DzN4MDZ_0024c_003D))
		{
			if (!(_0023_003Dz8fpRyMu9aKjE is Circle _0023_003Dzw6jQxH4k7cf_0024))
			{
				if (!(_0023_003Dz8fpRyMu9aKjE is CompositeCurve _0023_003DzLQVT3gk_003D))
				{
					if (!(_0023_003Dz8fpRyMu9aKjE is Curve _0023_003Dz8fpRyMu9aKjE2))
					{
						if (!(_0023_003Dz8fpRyMu9aKjE is EllipticalArc _0023_003DzN9YG4_1LCGXe))
						{
							if (!(_0023_003Dz8fpRyMu9aKjE is Ellipse _0023_003DzWUywqIo_003D))
							{
								if (!(_0023_003Dz8fpRyMu9aKjE is Line _0023_003DzQ9zpGF0_003D))
								{
									if (_0023_003Dz8fpRyMu9aKjE is LinearPath _0023_003DzHPC6WX8_003D)
									{
										return _0023_003DzDzv42v4D2Pvm(_0023_003DzHPC6WX8_003D, _0023_003Dzr_3OnS8_003D);
									}
									return _0023_003Dz7RhVPwnxEPI2((Entity)_0023_003Dz8fpRyMu9aKjE);
								}
								return _0023_003DzDzv42v4D2Pvm(_0023_003DzQ9zpGF0_003D, _0023_003Dzr_3OnS8_003D);
							}
							return _0023_003DzDzv42v4D2Pvm(_0023_003DzWUywqIo_003D, _0023_003Dzr_3OnS8_003D);
						}
						return _0023_003DzDzv42v4D2Pvm(_0023_003DzN9YG4_1LCGXe, _0023_003Dzr_3OnS8_003D);
					}
					return _0023_003DzDzv42v4D2Pvm(_0023_003Dz8fpRyMu9aKjE2, _0023_003Dzr_3OnS8_003D);
				}
				return _0023_003DzDzv42v4D2Pvm(_0023_003DzLQVT3gk_003D, _0023_003Dzr_3OnS8_003D);
			}
			return _0023_003DzDzv42v4D2Pvm(_0023_003Dzw6jQxH4k7cf_0024, _0023_003Dzr_3OnS8_003D);
		}
		return _0023_003DzDzv42v4D2Pvm(_0023_003DzN4MDZ_0024c_003D, _0023_003Dzr_3OnS8_003D);
	}

	private IfcCircle _0023_003DzDzv42v4D2Pvm(Circle _0023_003Dzw6jQxH4k7cf_0024, int _0023_003Dzr_3OnS8_003D)
	{
		IfcCircle ifcCircle = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCircle>();
		ifcCircle.Radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
		IfcAxis2Placement position;
		if (_0023_003Dzr_3OnS8_003D != 2)
		{
			IfcAxis2Placement ifcAxis2Placement = _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003Dzw6jQxH4k7cf_0024.Plane);
			position = ifcAxis2Placement;
		}
		else
		{
			IfcAxis2Placement ifcAxis2Placement = _0023_003DznMo_0024O0WT8rrRk5usSQ_003D_003D(_0023_003Dzw6jQxH4k7cf_0024.Plane);
			position = ifcAxis2Placement;
		}
		ifcCircle.Position = position;
		return ifcCircle;
	}

	private IfcEllipse _0023_003DzDzv42v4D2Pvm(Ellipse _0023_003DzWUywqIo_003D, int _0023_003Dzr_3OnS8_003D)
	{
		IfcEllipse ifcEllipse = _0023_003DzHOHdAUGvQ5_0024T().New<IfcEllipse>();
		ifcEllipse.SemiAxis1 = _0023_003DzWUywqIo_003D.RadiusX;
		ifcEllipse.SemiAxis2 = _0023_003DzWUywqIo_003D.RadiusY;
		IfcAxis2Placement position;
		if (_0023_003Dzr_3OnS8_003D != 2)
		{
			IfcAxis2Placement ifcAxis2Placement = _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(_0023_003DzWUywqIo_003D.Plane);
			position = ifcAxis2Placement;
		}
		else
		{
			IfcAxis2Placement ifcAxis2Placement = _0023_003DznMo_0024O0WT8rrRk5usSQ_003D_003D(_0023_003DzWUywqIo_003D.Plane);
			position = ifcAxis2Placement;
		}
		ifcEllipse.Position = position;
		return ifcEllipse;
	}

	private IfcTrimmedCurve _0023_003DzDzv42v4D2Pvm(Arc _0023_003DzN4MDZ_0024c_003D, int _0023_003Dzr_3OnS8_003D)
	{
		return _0023_003DzwcI1u3OT7L975z9L9w_003D_003D(_0023_003DzN4MDZ_0024c_003D, _0023_003DzDzv42v4D2Pvm((Circle)_0023_003DzN4MDZ_0024c_003D, _0023_003Dzr_3OnS8_003D), _0023_003Dzr_3OnS8_003D);
	}

	private IfcTrimmedCurve _0023_003DzDzv42v4D2Pvm(EllipticalArc _0023_003DzN9YG4_1LCGXe, int _0023_003Dzr_3OnS8_003D)
	{
		return _0023_003DzwcI1u3OT7L975z9L9w_003D_003D(_0023_003DzN9YG4_1LCGXe, _0023_003DzDzv42v4D2Pvm((Ellipse)_0023_003DzN9YG4_1LCGXe, _0023_003Dzr_3OnS8_003D), _0023_003Dzr_3OnS8_003D);
	}

	private IfcTrimmedCurve _0023_003DzwcI1u3OT7L975z9L9w_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, IfcCurve _0023_003DzDuY36bOR3A1N, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2 = new _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D();
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2._0023_003DzDuY36bOR3A1N = _0023_003DzDuY36bOR3A1N;
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2._0023_003Dz8fpRyMu9aKjE = _0023_003Dz8fpRyMu9aKjE;
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcTrimmedCurve>(_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D2._0023_003Dzn0hKGUjbjrZem7CtHmIhSiU_003D);
	}

	private IfcPolyline _0023_003DzDzv42v4D2Pvm(Line _0023_003DzQ9zpGF0_003D, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D _0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D2 = new _0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D();
		_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D2._0023_003DzQ9zpGF0_003D = _0023_003DzQ9zpGF0_003D;
		_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcPolyline>(_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D2._0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D);
	}

	private IfcPolyline _0023_003DzDzv42v4D2Pvm(LinearPath _0023_003DzHPC6WX8_003D, int _0023_003Dzr_3OnS8_003D)
	{
		IfcPolyline ifcPolyline = _0023_003DzHOHdAUGvQ5_0024T().New<IfcPolyline>();
		IfcCartesianPoint[] values = _0023_003Dz4_0024_0024dqN8cEutytsVAlxBIFwEWUQpi(_0023_003DzHPC6WX8_003D.Vertices, _0023_003Dzr_3OnS8_003D);
		ifcPolyline.Points.AddRange(values);
		return ifcPolyline;
	}

	private IfcCompositeCurve _0023_003DzDzv42v4D2Pvm(CompositeCurve _0023_003DzLQVT3gk_003D, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D _0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D2 = new _0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D();
		_0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		IfcCompositeCurve ifcCompositeCurve = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCompositeCurve>();
		for (int i = 0; i < _0023_003DzLQVT3gk_003D.CurveList.Count; i++)
		{
			_0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D _0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D2 = new _0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D();
			_0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003Dz_x5SNawQJhJWgPUTNpVZNXw_003D2;
			_0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D2._0023_003DzzmfUkNI_003D = _0023_003DzLQVT3gk_003D.CurveList[i];
			IfcCompositeCurveSegment item = _0023_003DzHOHdAUGvQ5_0024T().New<IfcCompositeCurveSegment>(_0023_003DzTQyqvt2t26vsWqaibrHLEC0_003D2._0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D);
			ifcCompositeCurve.Segments.Add(item);
		}
		return ifcCompositeCurve;
	}

	private IfcBSplineCurveWithKnots _0023_003DzDzv42v4D2Pvm(Curve _0023_003Dz8fpRyMu9aKjE, int _0023_003Dzr_3OnS8_003D)
	{
		_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2 = new _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D();
		_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2._0023_003Dzr_3OnS8_003D = _0023_003Dzr_3OnS8_003D;
		IfcBSplineCurveWithKnots ifcBSplineCurveWithKnots;
		if (_0023_003Dz8fpRyMu9aKjE.IsRational)
		{
			IfcRationalBSplineCurveWithKnots ifcRationalBSplineCurveWithKnots = _0023_003DzHOHdAUGvQ5_0024T().New<IfcRationalBSplineCurveWithKnots>();
			ifcRationalBSplineCurveWithKnots.WeightsData.AddRange(_0023_003Dz8fpRyMu9aKjE.ControlPoints.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzORKlKxrDoywRUjLi8V7d5VeM1fvS));
			ifcBSplineCurveWithKnots = ifcRationalBSplineCurveWithKnots;
		}
		else
		{
			ifcBSplineCurveWithKnots = _0023_003DzHOHdAUGvQ5_0024T().New<IfcBSplineCurveWithKnots>();
		}
		ifcBSplineCurveWithKnots.Knots.AddRange(_0023_003Dz8fpRyMu9aKjE.KnotVector.Select((double _0023_003DzN6G05Lg_003D) => new IfcParameterValue(_0023_003DzN6G05Lg_003D)));
		ifcBSplineCurveWithKnots.ControlPointsList.AddRange(_0023_003Dz8fpRyMu9aKjE.ControlPoints.Select(_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2._0023_003DzS4lO1Vy4DljFdXsAAnZOrwM_003D));
		ifcBSplineCurveWithKnots.Degree = _0023_003Dz8fpRyMu9aKjE.Degree;
		ifcBSplineCurveWithKnots.ClosedCurve = _0023_003Dz8fpRyMu9aKjE.IsClosed;
		ifcBSplineCurveWithKnots.KnotSpec = IfcKnotType.UNSPECIFIED;
		return ifcBSplineCurveWithKnots;
	}

	private IfcAdvancedBrep _0023_003DzDzv42v4D2Pvm(Brep _0023_003DzGb8kdyZ1x5nj, out string _0023_003DzT3RVAR0_003D)
	{
		_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2 = new _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D();
		_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzT3RVAR0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012508);
		_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2._0023_003DzdGpTIwzYxL4U2qFSlw_003D_003D = new IfcVertex[_0023_003DzGb8kdyZ1x5nj.Vertices.Length];
		for (int i = 0; i < _0023_003DzGb8kdyZ1x5nj.Vertices.Length; i++)
		{
			_0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D _0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D2 = new _0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D();
			_0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2;
			_0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D2._0023_003DzkEYxO1SuR1Kw = _0023_003DzGb8kdyZ1x5nj.Vertices[i];
			_0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzdGpTIwzYxL4U2qFSlw_003D_003D[i] = _0023_003DzHOHdAUGvQ5_0024T().New<IfcVertexPoint>(_0023_003DztgM5moqRrCvv7rdTnl00Gn0_003D2._0023_003DzS4lO1Vy4DljFdXsAAnZOrwM_003D);
		}
		_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2._0023_003DzVnEG1RlCHq_0024a = new IfcEdge[_0023_003DzGb8kdyZ1x5nj.Edges.Length];
		for (int j = 0; j < _0023_003DzGb8kdyZ1x5nj.Edges.Length; j++)
		{
			_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D _0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2 = new _0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D();
			_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D = _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2;
			_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003DzJSE0zYhXeN9U = _0023_003DzGb8kdyZ1x5nj.Edges[j];
			ICurve curve = _0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003DzJSE0zYhXeN9U.Curve;
			if (curve is Arc arc)
			{
				curve = new Circle(arc.Plane, arc.Radius);
			}
			else if (curve is EllipticalArc ellipticalArc)
			{
				curve = new Ellipse(ellipticalArc.Plane, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
			}
			_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003DzYbZQw3SBCmck = _0023_003Dz9AYS91Khm9S5(curve, 3);
			IfcEdgeCurve ifcEdgeCurve = _0023_003DzHOHdAUGvQ5_0024T().New<IfcEdgeCurve>(_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003Dz6ZVetAPEW89V7auUaAYMnpQ_003D);
			_0023_003Dz1zxq_0024rGiSUwNzjwScGYtFEo_003D2._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzVnEG1RlCHq_0024a[j] = ifcEdgeCurve;
		}
		_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2._0023_003Dzq93XqX4D_0024_00246X_0024B1HJQ_003D_003D = new IfcFace[_0023_003DzGb8kdyZ1x5nj.Faces.Length];
		for (int k = 0; k < _0023_003DzGb8kdyZ1x5nj.Faces.Length; k++)
		{
			_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2 = new _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D();
			_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D = _0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2;
			_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DzVxEs24GGIW60 = _0023_003DzGb8kdyZ1x5nj.Faces[k];
			_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DzD0ui41JsDUqJ = new IfcFaceBound[_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DzVxEs24GGIW60.Loops.Length];
			for (int l = 0; l < _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DzVxEs24GGIW60.Loops.Length; l++)
			{
				_0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2 = new _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D();
				_0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2._0023_003DqKEkg_ZrVnCodYhedSScMAdDNS4zMHt63qfZivuzl04A_003D = _0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2;
				Brep.Loop loop = _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2._0023_003DqKEkg_ZrVnCodYhedSScMAdDNS4zMHt63qfZivuzl04A_003D._0023_003DzVxEs24GGIW60.Loops[l];
				_0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2._0023_003DzHA50zAK6cV3tjZSm6M9PKZk_003D = new IfcOrientedEdge[loop.Segments.Length];
				for (int m = 0; m < loop.Segments.Length; m++)
				{
					_0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D _0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D2 = new _0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D();
					_0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D2._0023_003DqwdA2p6nTT6BYp3F6lGPgH1kvw71IQwcC2cuWWyy0pUI_003D = _0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2;
					_0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D2._0023_003DzJSE0zYhXeN9U = loop.Segments[m];
					IfcOrientedEdge ifcOrientedEdge = _0023_003DzHOHdAUGvQ5_0024T().New<IfcOrientedEdge>(_0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D2._0023_003Dz0sSVCN3lHxlyTzDqVcCFWi0_003D);
					_0023_003DzpBbascrYhADN7tJhv_8J9Gk_003D2._0023_003DqwdA2p6nTT6BYp3F6lGPgH1kvw71IQwcC2cuWWyy0pUI_003D._0023_003DzHA50zAK6cV3tjZSm6M9PKZk_003D[m] = ifcOrientedEdge;
				}
				IfcEdgeLoop bound = _0023_003DzHOHdAUGvQ5_0024T().New<IfcEdgeLoop>(_0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2._0023_003DzJuEEDg2ralUpMGYntVoZ3fw_003D);
				IfcFaceBound ifcFaceBound = ((l == 0) ? _0023_003DzHOHdAUGvQ5_0024T().New<IfcFaceOuterBound>() : _0023_003DzHOHdAUGvQ5_0024T().New<IfcFaceBound>());
				ifcFaceBound.Bound = bound;
				ifcFaceBound.Orientation = loop.Sense;
				_0023_003Dzd7hDzwRSrihBQenJq3rEhBo_003D2._0023_003DqKEkg_ZrVnCodYhedSScMAdDNS4zMHt63qfZivuzl04A_003D._0023_003DzD0ui41JsDUqJ[l] = ifcFaceBound;
			}
			IfcAdvancedFace ifcAdvancedFace = _0023_003DzHOHdAUGvQ5_0024T().New<IfcAdvancedFace>(_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DzUX5gUS0iM_FlgUPVjjRMff0_003D);
			_0023_003DzpgjiBl92Gp4DMMBmsHFWinc_003D2._0023_003DqPsogbfsaK_0024DhioggI7udxiyXHsO8g1Gt0S9F_0024PSK_Xo_003D._0023_003Dzq93XqX4D_0024_00246X_0024B1HJQ_003D_003D[k] = ifcAdvancedFace;
		}
		return _0023_003DzHOHdAUGvQ5_0024T().New<IfcAdvancedBrep>(_0023_003Dz4ZdjChvl0taJlx6E8OBAjzE_003D2._0023_003Dzps_D85Hfu8cnM3DoytxhJ9c_003D);
	}

	private IfcSurface _0023_003DzSMhxGs3YAoH9(AnalyticSurf _0023_003Dz_0024KKopL9T7nzT)
	{
		_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2 = new _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D();
		_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D = _0023_003Dz_0024KKopL9T7nzT as NurbsSurf;
		if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D == null)
		{
			if (!(_0023_003Dz_0024KKopL9T7nzT is ConicalSurf { Plane: var plane } conicalSurf))
			{
				_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzH8NMsuQtF4V_AybMOpDZ84VLd3Cn = _0023_003Dz_0024KKopL9T7nzT as SphericalSurf;
				if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzH8NMsuQtF4V_AybMOpDZ84VLd3Cn == null)
				{
					_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzBVoJR8rfR43RyonlhEeGWgoQnvKA1IdPoQ_003D_003D = _0023_003Dz_0024KKopL9T7nzT as CylindricalSurf;
					if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzBVoJR8rfR43RyonlhEeGWgoQnvKA1IdPoQ_003D_003D == null)
					{
						_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9 = _0023_003Dz_0024KKopL9T7nzT as RevolvedSurf;
						if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9 == null)
						{
							_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8 = _0023_003Dz_0024KKopL9T7nzT as ToroidalSurf;
							if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz5iT5tBk4CKpyDhLcvwBd7FBAy9T8 == null)
							{
								_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzKMDSIZhwizM1J_0024GpnHfwZpq198gq = _0023_003Dz_0024KKopL9T7nzT as PlanarSurf;
								if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzKMDSIZhwizM1J_0024GpnHfwZpq198gq == null)
								{
									_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf = _0023_003Dz_0024KKopL9T7nzT as TabulatedSurf;
									if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf != null)
									{
										_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzrgqz890sj_0024X9 = Plane.XY;
										if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.Directrix.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane2))
										{
											_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzrgqz890sj_0024X9 = plane2;
											Transformation xform = Transformation.CreateAlignment(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzrgqz890sj_0024X9, Plane.XY);
											_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf = (TabulatedSurf)_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.Clone();
											_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.TransformBy(xform);
										}
										_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzN43NmNMGjNKB = _0023_003DzrQZQ07zOg6tEq4523A_003D_003D(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.Directrix);
										_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzN43NmNMGjNKB.ProfileType = IfcProfileTypeEnum.CURVE;
										_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzCJkr8nY_003D = (Vector3D)_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DztsxKA2PyYVW2sd382vIFyPIdWsQf.Generatrix.Clone();
										_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzCJkr8nY_003D.Normalize();
										return _0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceOfLinearExtrusion>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzxslUh_ct5H5Zk3e3pI2oFpI_003D);
									}
									throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012493));
								}
								return _0023_003DzHOHdAUGvQ5_0024T().New<IfcPlane>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz9D9323S1hhrF2X6MA5IEouw_003D);
							}
							return _0023_003DzHOHdAUGvQ5_0024T().New<IfcToroidalSurface>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzF0SgPkkIHD0UbTl0JzXOf4k_003D);
						}
						_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzpyw2kZk_003D = Plane.XY;
						if (_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9.Generatrix.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane3))
						{
							_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzpyw2kZk_003D = plane3;
							Transformation xform2 = Transformation.CreateAlignment(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzpyw2kZk_003D, Plane.XY);
							_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9 = (RevolvedSurf)_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9.Clone();
							_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9.TransformBy(xform2);
						}
						_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz1QMSv2HWVtLc = _0023_003DzrQZQ07zOg6tEq4523A_003D_003D(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz7IIVsfJ1j4kUltFWOdYd14Cpniy9.Generatrix);
						_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz1QMSv2HWVtLc.ProfileType = IfcProfileTypeEnum.CURVE;
						return _0023_003DzHOHdAUGvQ5_0024T().New<IfcSurfaceOfRevolution>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzIiB3wpAuu674UYvap7V0O24_003D);
					}
					return _0023_003DzHOHdAUGvQ5_0024T().New<IfcCylindricalSurface>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzOJc3IHVw4mFoDcZl3eb6VFY_003D);
				}
				return _0023_003DzHOHdAUGvQ5_0024T().New<IfcSphericalSurface>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzeqJ3ur8tEgTBnjIt0nMGugQ_003D);
			}
			Point3D start = plane.Origin + plane.AxisX * conicalSurf.Radius;
			Point3D tip = conicalSurf.Tip;
			Line generatrix = new Line(start, tip);
			RevolvedSurf _0023_003Dz_0024KKopL9T7nzT2 = new RevolvedSurf(plane.Origin, plane.AxisZ, plane.AxisX, generatrix);
			return _0023_003DzSMhxGs3YAoH9(_0023_003Dz_0024KKopL9T7nzT2);
		}
		IfcRationalBSplineSurfaceWithKnots ifcRationalBSplineSurfaceWithKnots = _0023_003DzHOHdAUGvQ5_0024T().New<IfcRationalBSplineSurfaceWithKnots>(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz5QS5wLq39uvLb6MKBcRXLtc_003D);
		for (int i = 0; i < _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.ControlPoints.GetLength(0); i++)
		{
			for (int j = 0; j < _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.ControlPoints.GetLength(1); j++)
			{
				ifcRationalBSplineSurfaceWithKnots.ControlPointsList.GetAt(i).Add(_0023_003DzbiZvlcz_XxT41bN00BEoi_00248_003D(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.ControlPoints[i, j], 3));
				ifcRationalBSplineSurfaceWithKnots.WeightsData.GetAt(i).Add(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.ControlPoints[i, j].W);
			}
		}
		ifcRationalBSplineSurfaceWithKnots.UKnots.AddRange(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.KnotVectorU.Select((double _0023_003DzN6G05Lg_003D) => new IfcParameterValue(_0023_003DzN6G05Lg_003D)));
		ifcRationalBSplineSurfaceWithKnots.UMultiplicities.AddRange(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.KnotVectorU.Select((double _0023_003DzBJFJHwk_003D) => new IfcInteger(1L)));
		ifcRationalBSplineSurfaceWithKnots.VKnots.AddRange(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.KnotVectorV.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzIUDwML9wU6KPZAbfeSJVq9M_003D));
		ifcRationalBSplineSurfaceWithKnots.VMultiplicities.AddRange(_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzZHWJg951G82UzLZjrMqdeao_003D.KnotVectorV.Select((double _0023_003DzBJFJHwk_003D) => new IfcInteger(1L)));
		return ifcRationalBSplineSurfaceWithKnots;
	}

	private void _0023_003DzEuZYWlcXDDzbznjR00k_OEk_003D(IfcGeometricRepresentationContext _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzt_m8zV0_003D.ContextType = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943975);
		_0023_003Dzt_m8zV0_003D.CoordinateSpaceDimension = 3L;
		_0023_003Dzt_m8zV0_003D.WorldCoordinateSystem = _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(Plane.XY);
	}

	private void _0023_003DzxXLQxSOlUpp29kxKUY8chR8_003D(IfcBuilding _0023_003Dz1v6oPQk_003D)
	{
		_0023_003Dz1v6oPQk_003D.Name = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013242);
		_0023_003Dz1v6oPQk_003D.CompositionType = IfcElementCompositionEnum.ELEMENT;
		_0023_003Dz1v6oPQk_003D.ObjectPlacement = _0023_003DzHOHdAUGvQ5_0024T().New<IfcLocalPlacement>(_0023_003Dz73GmXkS1BEZJh4XJgsAPlPQ_003D);
	}

	private void _0023_003Dz73GmXkS1BEZJh4XJgsAPlPQ_003D(IfcLocalPlacement _0023_003DzHPC6WX8_003D)
	{
		_0023_003DzHPC6WX8_003D.RelativePlacement = _0023_003Dznc_WYlMbVotcCnav_0024Q_003D_003D(Plane.XY);
	}

	private void _0023_003DzdNbun9nCoIFdswE7PfoszwU_003D(IfcSIUnit _0023_003DzuwH5j5s_003D)
	{
		_0023_003DzuwH5j5s_003D.UnitType = IfcUnitEnum.LENGTHUNIT;
		_0023_003DzuwH5j5s_003D.Name = IfcSIUnitName.METRE;
		_0023_003DzuwH5j5s_003D.Prefix = units switch
		{
			linearUnitsType.Microns => IfcSIPrefix.MICRO, 
			linearUnitsType.Nanometers => IfcSIPrefix.NANO, 
			linearUnitsType.Millimeters => IfcSIPrefix.MILLI, 
			linearUnitsType.Centimeters => IfcSIPrefix.CENTI, 
			linearUnitsType.Decimeters => IfcSIPrefix.DECI, 
			linearUnitsType.Decameters => IfcSIPrefix.DECA, 
			linearUnitsType.Hectometers => IfcSIPrefix.HECTO, 
			linearUnitsType.Kilometers => IfcSIPrefix.KILO, 
			linearUnitsType.Gigameters => IfcSIPrefix.GIGA, 
			linearUnitsType.Meters => null, 
			_ => null, 
		};
	}
}
