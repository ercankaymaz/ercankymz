using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public class VolumeMesher : Mesher, IFaceMesherCreator, ICurveMesherCreator
{
	public class Statistics
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzpeGtiA6RDDyeJ3YnNDgTZwo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzkOSj2UXVDf9ZE_0024AtWNAm9Nc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzwRjqNULry5azAZE_00246FU7WrWh_0024op4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzgwPDwTO3TiVRqAtIXksygoo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzJPfMdXAupNb86jMch58mzlk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003Dz41yMHLj2bT43GMVzorcFnpwwgAkl;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzH_00242h58bl29n8ujchMQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzUnJCLHbAlxNZbGPsmOJ3npM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzCv1QZl25O6_SXvTY3mbql4A_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003Dz5i793Ffk6X4_0024ctmZTpe0w6zACGLg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzbSzeOMO2vCwnL5Wy_0024A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003Dz_7MfSadkGGnG3y6rxMnZqfc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzXF6FYp5LaT6Qs3x_GExhxjOZ3HibgGfffMjnveo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003Dznpyk2jUvb2vxzUlcE8RD_0024q_eiZJL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly TimeSpan _0023_003Dzul8dpjVV33G_P7OMPw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly TimeSpan _0023_003DzQBtRG9sNP_6p9Mjqkg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly TimeSpan _0023_003DzeBJvb9_vj3VI42Zjyw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly TimeSpan _0023_003Dzv6mFl_zG4XWJBouCWQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Tuple<int, string> _0023_003Dz27v74C8quKCQsn8VVA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Tuple<int, string> _0023_003DzN_YKwlwAyfnfpGMzPw_003D_003D;

		public HistogramData EdgeShapeQualities;

		public HistogramData ElementShapeQualities;

		public int HardNodesOut
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzpeGtiA6RDDyeJ3YnNDgTZwo_003D;
			}
		}

		public int HardEdgesOut
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzkOSj2UXVDf9ZE_0024AtWNAm9Nc_003D;
			}
		}

		public int HardFacesOut
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzwRjqNULry5azAZE_00246FU7WrWh_0024op4;
			}
		}

		public int HardNodesIn
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzgwPDwTO3TiVRqAtIXksygoo_003D;
			}
		}

		public int HardEdgesIn
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzJPfMdXAupNb86jMch58mzlk_003D;
			}
		}

		public int HardFacesIn
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz41yMHLj2bT43GMVzorcFnpwwgAkl;
			}
		}

		public int Nodes
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzH_00242h58bl29n8ujchMQ_003D_003D;
			}
		}

		public int Tets
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzUnJCLHbAlxNZbGPsmOJ3npM_003D;
			}
		}

		public int MissingFaces
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzCv1QZl25O6_SXvTY3mbql4A_003D;
			}
		}

		public int Subdomains
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz5i793Ffk6X4_0024ctmZTpe0w6zACGLg;
			}
		}

		public double Volume
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzbSzeOMO2vCwnL5Wy_0024A_003D_003D;
			}
		}

		public double MinQuality
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz_7MfSadkGGnG3y6rxMnZqfc_003D;
			}
		}

		public double BestAchievableMinQuality
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzXF6FYp5LaT6Qs3x_GExhxjOZ3HibgGfffMjnveo_003D;
			}
		}

		public int SteinerNodes
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dznpyk2jUvb2vxzUlcE8RD_0024q_eiZJL;
			}
		}

		public TimeSpan FrontTime
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dzul8dpjVV33G_P7OMPw_003D_003D;
			}
		}

		public TimeSpan RefineTime
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzQBtRG9sNP_6p9Mjqkg_003D_003D;
			}
		}

		public TimeSpan OptimizationTime
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzeBJvb9_vj3VI42Zjyw_003D_003D;
			}
		}

		public TimeSpan TotalTime
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dzv6mFl_zG4XWJBouCWQ_003D_003D;
			}
		}

		public double Speed
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D;
			}
		}

		public Tuple<int, string> Warning
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz27v74C8quKCQsn8VVA_003D_003D;
			}
		}

		public Tuple<int, string> Error
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzN_YKwlwAyfnfpGMzPw_003D_003D;
			}
		}

		internal Statistics(_0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa _0023_003Dzv2w0z_0024soYoTS)
		{
			_0023_003DzpeGtiA6RDDyeJ3YnNDgTZwo_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzP_0024xBud0vpCbb3KxtaQ_003D_003D;
			_0023_003DzkOSj2UXVDf9ZE_0024AtWNAm9Nc_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzwW3JslXbAFqC_0024cnx3195zvw_003D;
			_0023_003DzwRjqNULry5azAZE_00246FU7WrWh_0024op4 = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzuwwPVpp_K11A5WcA_0024TotspM_003D;
			_0023_003DzgwPDwTO3TiVRqAtIXksygoo_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzBuLNbsVnRtSJPAVzvg_003D_003D;
			_0023_003DzJPfMdXAupNb86jMch58mzlk_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003Dzm4YaBPkeb0G08SavIJSTlI8_003D;
			_0023_003Dz41yMHLj2bT43GMVzorcFnpwwgAkl = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzTMD_flQlbF0qlVy3cI3NYf8_003D;
			_0023_003DzH_00242h58bl29n8ujchMQ_003D_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003Dzva7BZITJ_faa;
			_0023_003DzUnJCLHbAlxNZbGPsmOJ3npM_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003Dz919Srlp4O7cL;
			_0023_003DzCv1QZl25O6_SXvTY3mbql4A_003D = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzFJ2iWmUjaUMpwyDObVp4dqsGkFeB._0023_003Dz14lzA48_003D();
			_0023_003Dz5i793Ffk6X4_0024ctmZTpe0w6zACGLg = _0023_003Dzv2w0z_0024soYoTS._0023_003DzMNS2407y5IguZ6LxVw_003D_003D;
			_0023_003DzbSzeOMO2vCwnL5Wy_0024A_003D_003D = _0023_003Dzv2w0z_0024soYoTS._0023_003DzhKcriekaIolc;
			_0023_003Dz_7MfSadkGGnG3y6rxMnZqfc_003D = _0023_003Dzv2w0z_0024soYoTS._0023_003DzR7YfVeure30J;
			_0023_003DzXF6FYp5LaT6Qs3x_GExhxjOZ3HibgGfffMjnveo_003D = _0023_003Dzv2w0z_0024soYoTS._0023_003DzOrQli_0024PbeB4iqrLXR9IOa4KyVJsO;
			_0023_003Dznpyk2jUvb2vxzUlcE8RD_0024q_eiZJL = (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzOdF_L660_0024Zt7EdpeuA_003D_003D;
			_0023_003Dzul8dpjVV33G_P7OMPw_003D_003D = new TimeSpan(0, 0, 0, (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzHwZck27UvORM);
			_0023_003DzQBtRG9sNP_6p9Mjqkg_003D_003D = new TimeSpan(0, 0, 0, (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzfP5O9OEgcrVZ4BqU0Q_003D_003D);
			_0023_003DzeBJvb9_vj3VI42Zjyw_003D_003D = new TimeSpan(0, 0, 0, (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzQg1KVytJuOCD_9T1CQ_003D_003D);
			_0023_003Dzv6mFl_zG4XWJBouCWQ_003D_003D = new TimeSpan(0, 0, 0, (int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzJVcurc7aC3ye);
			_0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D = _0023_003Dzv2w0z_0024soYoTS._0023_003Dz1v8WebVg_QJi;
			_0023_003DzHC5zlvCTgVHr(_0023_003Dzv2w0z_0024soYoTS._0023_003DzNua_0024O2eShpSLq3OghA_003D_003D, ref EdgeShapeQualities);
			_0023_003DzHC5zlvCTgVHr(_0023_003Dzv2w0z_0024soYoTS._0023_003DzhiZN7sb_GFxPPq7ZVA_003D_003D, ref ElementShapeQualities);
			_0023_003Dz27v74C8quKCQsn8VVA_003D_003D = new Tuple<int, string>((int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzNEJQb9Emq9QE, _0023_003Dzmj1Wi_0024fCRIMJ((int)_0023_003Dzv2w0z_0024soYoTS._0023_003DzNEJQb9Emq9QE));
			_0023_003DzN_YKwlwAyfnfpGMzPw_003D_003D = new Tuple<int, string>((int)_0023_003Dzv2w0z_0024soYoTS._0023_003Dzt_0024bwB94yNa7O, _0023_003DzdAN5DiY_003D((int)_0023_003Dzv2w0z_0024soYoTS._0023_003Dzt_0024bwB94yNa7O));
		}

		private void _0023_003DzHC5zlvCTgVHr(_0023_003Dz4E_o8GASGYaw8T_0024k8bKfJhqx77su _0023_003Dzb7SPTpc_003D, ref HistogramData _0023_003DzaoQTclc_003D)
		{
			if (_0023_003Dzb7SPTpc_003D._0023_003Dzk3XcQZ8iarFJ() != 0)
			{
				Tuple<double, double, int>[] array = new Tuple<double, double, int>[_0023_003Dzb7SPTpc_003D._0023_003DzI1zpEBqLLdeB()];
				for (uint num = 1u; num <= _0023_003Dzb7SPTpc_003D._0023_003DzI1zpEBqLLdeB(); num++)
				{
					array[num - 1] = new Tuple<double, double, int>(_0023_003Dzb7SPTpc_003D._0023_003DzUI0x3mHkXYRRlBd35w_003D_003D(num - 1), _0023_003Dzb7SPTpc_003D._0023_003DzUI0x3mHkXYRRlBd35w_003D_003D(num), (int)_0023_003Dzb7SPTpc_003D._0023_003DzuOMylKfpuJP0(num - 1));
				}
				_0023_003DzaoQTclc_003D = new HistogramData((int)_0023_003Dzb7SPTpc_003D._0023_003Dzk3XcQZ8iarFJ(), (int)_0023_003Dzb7SPTpc_003D._0023_003DzZiZ9Fzu8lvps(), (int)_0023_003Dzb7SPTpc_003D._0023_003DzGWppTVCB4FLS(), _0023_003Dzb7SPTpc_003D._0023_003DzrXB9c9B0CxqT(), _0023_003Dzb7SPTpc_003D._0023_003DzXY_0024U5XwJu_Sq(), _0023_003Dzb7SPTpc_003D._0023_003DzlfhuqoXyledi(), array);
			}
		}

		private string _0023_003Dzmj1Wi_0024fCRIMJ(int _0023_003Dzt5H1UjY_003D)
		{
			return _0023_003Dzt5H1UjY_003D switch
			{
				-10 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992320), 
				-11 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992264), 
				-12 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991967), 
				-13 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991880), 
				-14 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992051), 
				-15 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992014), 
				-16 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992658), 
				_ => string.Empty, 
			};
		}

		private string _0023_003DzdAN5DiY_003D(int _0023_003DzWtT0XNA_003D)
		{
			return _0023_003DzWtT0XNA_003D switch
			{
				-101 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992880), 
				-102 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992839), 
				-103 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992264), 
				-104 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991967), 
				-105 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992497), 
				-106 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992051), 
				-107 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992445), 
				-108 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992600), 
				-109 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993277), 
				-199 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993382), 
				-200 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993353), 
				_ => string.Empty, 
			};
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IndexTriangle[] _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzCGnGN9qHxd0V22c4_0024A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzBvvEXs6OFwd9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Brep _0023_003DzNHwVp3TiNZt7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SizesOnCurve[] _0023_003DzQddq8l18szqa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DznMvzbHf85IRNW6MFvw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz8iGqQ7BNIELcd9xToy7VhtUqnHSE = 0.5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzXJ0QtZVtbWQPJeu2uierR1g_003D = 3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz0_0024W5xYrXSIB6w3fti6nPRI8_003D = 0.6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Statistics _0023_003Dzu2CfzBlGO3HdOUA9TA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993344);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFIrgoGMXjKXK5o5wCQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993302);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzi_0024Xe_rXmrJwDhJIgQprC5HoL5aZQ = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993288);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzckZvuw8j3oOmEQ1FmQKPb7EjpCsq = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993018);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzlTbToDM7PCYH9_0024lEizrjDW4_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993006);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzwdklr_0024UxP2iXImfJ72yLAdS7uNJi = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992971);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzU1BoqL0wJowRsrOMBCljMOQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzPQ_ujslkQlzTvH_uFz44jxw_003D = new Point3D[0];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IndexLine[] _0023_003Dzad6MoSXssgZtLlaZsV26cC0_003D = new IndexLine[0];

	public double TargetMetric
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DznMvzbHf85IRNW6MFvw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DznMvzbHf85IRNW6MFvw_003D_003D = value;
		}
	}

	public double MaxGradation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz8iGqQ7BNIELcd9xToy7VhtUqnHSE;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz8iGqQ7BNIELcd9xToy7VhtUqnHSE = value;
		}
	}

	public int OptimizationLevel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXJ0QtZVtbWQPJeu2uierR1g_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXJ0QtZVtbWQPJeu2uierR1g_003D = value;
		}
	}

	public double ShapeQualityWeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0_0024W5xYrXSIB6w3fti6nPRI8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0_0024W5xYrXSIB6w3fti6nPRI8_003D = value;
		}
	}

	public Statistics Stats
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzu2CfzBlGO3HdOUA9TA_003D_003D;
		}
	}

	public string InitializingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D = value;
		}
	}

	public string BuildingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFIrgoGMXjKXK5o5wCQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFIrgoGMXjKXK5o5wCQ_003D_003D = value;
		}
	}

	public string RefiningText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzi_0024Xe_rXmrJwDhJIgQprC5HoL5aZQ;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzi_0024Xe_rXmrJwDhJIgQprC5HoL5aZQ = value;
		}
	}

	public string OptimizingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzckZvuw8j3oOmEQ1FmQKPb7EjpCsq;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzckZvuw8j3oOmEQ1FmQKPb7EjpCsq = value;
		}
	}

	public string MidSideNodesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlTbToDM7PCYH9_0024lEizrjDW4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzlTbToDM7PCYH9_0024lEizrjDW4_003D = value;
		}
	}

	public string MeshingFaceText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzwdklr_0024UxP2iXImfJ72yLAdS7uNJi;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzwdklr_0024UxP2iXImfJ72yLAdS7uNJi = value;
		}
	}

	public bool ComputeEdgeQuality
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzU1BoqL0wJowRsrOMBCljMOQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzU1BoqL0wJowRsrOMBCljMOQ_003D = value;
		}
	}

	public Point3D[] HardNodes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPQ_ujslkQlzTvH_uFz44jxw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPQ_ujslkQlzTvH_uFz44jxw_003D = value;
		}
	}

	public IndexLine[] HardEdges
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzad6MoSXssgZtLlaZsV26cC0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzad6MoSXssgZtLlaZsV26cC0_003D = value;
		}
	}

	public VolumeMesher(Mesh boundary, MaterialKeyedCollection materials = null)
	{
		_0023_003DzCGnGN9qHxd0V22c4_0024A_003D_003D = boundary.MaterialName;
		_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = materials;
		_0023_003DzME2BuaSnJsM4mEn84A_003D_003D = boundary.Vertices;
		_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D = boundary.Triangles;
	}

	public VolumeMesher(Brep brep, double size, bool quadratic = false, MaterialKeyedCollection materials = null)
		: this(brep, Enumerable.Repeat(size, brep.Vertices.Length).ToArray(), quadratic, materials)
	{
	}

	public VolumeMesher(Brep brep, double[] sizeOnVertices, bool quadratic = false, MaterialKeyedCollection materials = null)
		: this(brep, brep._0023_003DzV6U3UVUo5N46(sizeOnVertices), quadratic, materials)
	{
	}

	public VolumeMesher(Brep brep, SizesOnCurve[] sizeOnEdges, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		if (brep == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992942));
		}
		if (sizeOnEdges == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992919));
		}
		_0023_003DzCGnGN9qHxd0V22c4_0024A_003D_003D = brep.MaterialName;
		_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = materials;
		if (!brep.IsClosed)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302992900), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993139));
		}
		if (sizeOnEdges.Length < brep.Edges.Length)
		{
			throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993152), sizeOnEdges.Length, brep.Edges.Length), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993051));
		}
		_0023_003DzNHwVp3TiNZt7 = brep;
		_0023_003DzQddq8l18szqa = sizeOnEdges;
		_0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D = quadratic;
	}

	public VolumeMesher(IList<Point3D> vertices, IList<IndexTriangle> triangles)
	{
		_0023_003DzME2BuaSnJsM4mEn84A_003D_003D = vertices.ToArray();
		_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D = triangles.ToArray();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		bool flag2 = true;
		if (_0023_003DzNHwVp3TiNZt7 != null)
		{
			flag2 = ((!_0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D) ? _0023_003DzNHwVp3TiNZt7._0023_003Dz1td33yCcgI1ZRbAOew_003D_003D(_0023_003DzQddq8l18szqa, this, MeshingFaceText, log, out _0023_003DzME2BuaSnJsM4mEn84A_003D_003D, out _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D, out _0023_003DzBvvEXs6OFwd9, progress, ct) : _0023_003DzNHwVp3TiNZt7._0023_003DzqVbueJBALRcMy_0024MhR5DmES0_003D(_0023_003DzQddq8l18szqa, this, progress, ct, MeshingFaceText, log, out _0023_003DzME2BuaSnJsM4mEn84A_003D_003D, out _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D, out _0023_003DzBvvEXs6OFwd9));
		}
		if (flag2)
		{
			base.Result = null;
			Mesh mesh = new Mesh(_0023_003DzME2BuaSnJsM4mEn84A_003D_003D, _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D);
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993032), _0023_003DzME2BuaSnJsM4mEn84A_003D_003D.Length, _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D.Length) + (_0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993735) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993756)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + (mesh.IsClosed ? string.Empty : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993719)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993700));
			_0023_003Dzz8DDgng_003D(progress, ct);
		}
	}

	private void _0023_003Dzz8DDgng_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzsWnj47U_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzEBehidw_003D = _0023_003Dzjvn7P10_003D;
		_0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa _0023_003Dzd912TYYGXpaa = new _0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa();
		int num = _0023_003DzME2BuaSnJsM4mEn84A_003D_003D.Length;
		_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzroU3nqY_003D(3u, (uint)(num + HardNodes.Length));
		for (uint num2 = 0u; num2 < num; num2++)
		{
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(0u, num2, _0023_003DzME2BuaSnJsM4mEn84A_003D_003D[num2].X);
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(1u, num2, _0023_003DzME2BuaSnJsM4mEn84A_003D_003D[num2].Y);
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(2u, num2, _0023_003DzME2BuaSnJsM4mEn84A_003D_003D[num2].Z);
		}
		for (uint num3 = 0u; num3 < HardNodes.Length; num3++)
		{
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(0u, (uint)num + num3, HardNodes[num3].X);
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(1u, (uint)num + num3, HardNodes[num3].Y);
			_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003DzQmya_mnFMQ1t(2u, (uint)num + num3, HardNodes[num3].Z);
		}
		int num4 = _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D.Length;
		if (_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[0].GetType() == typeof(QuadraticTriangle))
		{
			_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzroU3nqY_003D(6u, (uint)num4);
			for (uint num5 = 0u; num5 < num4; num5++)
			{
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(0u, num5, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5].V1);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(1u, num5, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5].V2);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(2u, num5, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5].V3);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(3u, num5, (uint)((QuadraticTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5]).V5);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(4u, num5, (uint)((QuadraticTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5]).V6);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(5u, num5, (uint)((QuadraticTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num5]).V4);
			}
		}
		else
		{
			_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzroU3nqY_003D(3u, (uint)num4);
			for (uint num6 = 0u; num6 < num4; num6++)
			{
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(0u, num6, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num6].V1);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(1u, num6, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num6].V2);
				_0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D._0023_003DzQmya_mnFMQ1t(2u, num6, (uint)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[num6].V3);
			}
		}
		_0023_003Dzd912TYYGXpaa._0023_003DzscfWrKk_003D._0023_003DzroU3nqY_003D(2u, (uint)HardEdges.Length);
		if (HardEdges.Length != 0)
		{
			for (uint num7 = 0u; num7 < HardEdges.Length; num7++)
			{
				_0023_003Dzd912TYYGXpaa._0023_003DzscfWrKk_003D._0023_003DzQmya_mnFMQ1t(0u, num7, (uint)(num + HardEdges[num7].V1));
				_0023_003Dzd912TYYGXpaa._0023_003DzscfWrKk_003D._0023_003DzQmya_mnFMQ1t(1u, num7, (uint)(num + HardEdges[num7].V2));
			}
		}
		else
		{
			for (uint num8 = 0u; num8 < HardNodes.Length; num8++)
			{
				_0023_003Dzd912TYYGXpaa._0023_003DzgwJqtK5fa0Ek9YEjTg_003D_003D._0023_003DzccHNBKidQXxY((uint)num + num8);
			}
		}
		_0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D obj = new _0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D();
		obj._0023_003DzxB3cR94_003D._0023_003Dz5Z0e1TPvRJxr = TargetMetric;
		obj._0023_003DzxB3cR94_003D._0023_003DzZSyoUlOgPyhZHVLrrLlLcvc_003D = MaxGradation;
		obj._0023_003DzxB3cR94_003D._0023_003Dz13DS61_mEHvdjGpqGA_003D_003D = (uint)OptimizationLevel;
		obj._0023_003DzxB3cR94_003D._0023_003DzGtjd_1UzfTU_0024FSTAIg_003D_003D = ShapeQualityWeight;
		obj._0023_003DzxB3cR94_003D._0023_003DzFmXY2nHtypSm2_0024lECg_003D_003D = true;
		obj._0023_003DzxB3cR94_003D._0023_003DzLWgHlUtl6lyLQnLgAw_003D_003D = ComputeEdgeQuality;
		obj._0023_003DzxB3cR94_003D._0023_003DzdZPfNR0wFaM6E3i0l9rKJ_A_003D = true;
		obj._0023_003Dzc_0024pb7t4_003D(_0023_003Dzd912TYYGXpaa, _0023_003DzYfD3DtJSv0t_jVsV1A_003D_003D, new string[5]
		{
			InitializingText,
			BuildingText,
			RefiningText,
			OptimizingText,
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993711)
		}, log);
		Stopwatch stopwatch = new Stopwatch();
		int _0023_003Dz919Srlp4O7cL;
		if (_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[0].GetType() == typeof(QuadraticTriangle))
		{
			_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2 = new _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D();
			_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2 = new _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D();
			stopwatch.Reset();
			stopwatch.Start();
			_0023_003Dzd912TYYGXpaa._0023_003DzcQefntM_003D(_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2);
			if (_0023_003Dzraga7EV2nOfAD3F1J_JRa9xRLh1L._0023_003DzFfjylH7xmpiw(_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2, 1u, 0u, 0u, _0023_003Dzd912TYYGXpaa._0023_003DzCwOHtrY_003D, new _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D(), this, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D, MidSideNodesText) < 0)
			{
				return;
			}
			stopwatch.Stop();
			_0023_003Dzd912TYYGXpaa._0023_003DzQsUs0Ilg_t6FCsgJLsT4pf8_003D((float)stopwatch.ElapsedMilliseconds / 1000f);
			int num9 = (int)_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2._0023_003DzmVsXTy4_003D();
			_0023_003Dz919Srlp4O7cL = (int)_0023_003Dzd912TYYGXpaa._0023_003Dz919Srlp4O7cL;
			if (_0023_003Dz919Srlp4O7cL == 0)
			{
				return;
			}
			base.Result = new FemMesh(num9, _0023_003Dz919Srlp4O7cL);
			for (uint num10 = 0u; num10 < num9; num10++)
			{
				base.Result.Vertices[num10] = new Node(_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, num10), _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(1u, num10), _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(2u, num10));
			}
			for (uint num11 = 0u; num11 < _0023_003Dz919Srlp4O7cL; num11++)
			{
				Material mat = _0023_003Dzjl5IbJ4_003D();
				Element element = new Tetra10((int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(5u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(2u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(4u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(1u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(6u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(7u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(9u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(8u, num11), (int)_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D2._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(3u, num11), mat);
				base.Result.Elements[num11] = element;
			}
		}
		else
		{
			int _0023_003DzEmcyRCs6F8nL = (int)_0023_003Dzd912TYYGXpaa._0023_003DzEmcyRCs6F8nL;
			_0023_003Dz919Srlp4O7cL = (int)_0023_003Dzd912TYYGXpaa._0023_003Dz919Srlp4O7cL;
			if (_0023_003Dz919Srlp4O7cL == 0)
			{
				return;
			}
			base.Result = new FemMesh(_0023_003DzEmcyRCs6F8nL, _0023_003Dz919Srlp4O7cL);
			for (uint num12 = 0u; num12 < _0023_003DzEmcyRCs6F8nL; num12++)
			{
				base.Result.Vertices[num12] = new Node(_0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, num12), _0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(1u, num12), _0023_003Dzd912TYYGXpaa._0023_003DzpdeSbFA_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(2u, num12));
			}
			for (uint num13 = 0u; num13 < _0023_003Dz919Srlp4O7cL; num13++)
			{
				Material mat2 = _0023_003Dzjl5IbJ4_003D();
				Element element2 = new Tetra4((int)_0023_003Dzd912TYYGXpaa._0023_003DzwrNSpXc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(1u, num13), (int)_0023_003Dzd912TYYGXpaa._0023_003DzwrNSpXc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, num13), (int)_0023_003Dzd912TYYGXpaa._0023_003DzwrNSpXc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(2u, num13), (int)_0023_003Dzd912TYYGXpaa._0023_003DzwrNSpXc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(3u, num13), mat2);
				base.Result.Elements[num13] = element2;
			}
		}
		if (_0023_003DzBvvEXs6OFwd9 != null && _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D != null && _0023_003DzBvvEXs6OFwd9.Distinct().Count() > 1)
		{
			stopwatch.Reset();
			stopwatch.Start();
			Dictionary<int, Material> dictionary = _0023_003DzEla_0024FevopU_0024_0024_CYmKBwXIn87Nd8nC90PgQ_003D_003D(_0023_003Dzd912TYYGXpaa);
			for (uint num14 = 0u; num14 < _0023_003Dz919Srlp4O7cL; num14++)
			{
				base.Result.Elements[num14].Material = dictionary[_0023_003Dzd912TYYGXpaa._0023_003DzZQ2HyLn4R0pl[num14]];
			}
			stopwatch.Stop();
			_0023_003Dzd912TYYGXpaa._0023_003DzQeuDFU6iPKlx((float)stopwatch.ElapsedMilliseconds / 1000f);
		}
		_0023_003DzKl0nneoLQjT5(_0023_003Dzd912TYYGXpaa);
		_0023_003DzkPPLofqulhZU(new Statistics(_0023_003Dzd912TYYGXpaa));
		base.Result.ElementShapeQualities = Stats.ElementShapeQualities;
		base.Result.EdgeShapeQualities = Stats.EdgeShapeQualities;
	}

	public static double EstimateSizeByNumber(int numberOfTets, Brep brep)
	{
		if (brep.Faces.Length != 0 && brep.Faces[0].Tessellation == null)
		{
			Utility.ComputeBoundingBox(brep.EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
			double deviation = new Size3D(boxMin, boxMax).Diagonal / 100.0;
			brep.Regen(deviation);
		}
		Point3D centroid;
		return Math.Pow(brep.GetVolume(out centroid) / (double)numberOfTets * 6.0 * 1.4142135623730951, 1.0 / 3.0);
	}

	private Dictionary<int, Material> _0023_003DzEla_0024FevopU_0024_0024_CYmKBwXIn87Nd8nC90PgQ_003D_003D(_0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa _0023_003Dzv2w0z_0024soYoTS)
	{
		Dictionary<int, Material> dictionary = new Dictionary<int, Material>();
		for (uint num = 0u; num < _0023_003Dzv2w0z_0024soYoTS._0023_003DzCwOHtrY_003D._0023_003DzmVsXTy4_003D(); num++)
		{
			int num2 = _0023_003DzBvvEXs6OFwd9[num];
			if (num2 == 0)
			{
				continue;
			}
			uint num3 = _0023_003Dzv2w0z_0024soYoTS._0023_003DzCwOHtrY_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, num);
			uint num4 = _0023_003Dzv2w0z_0024soYoTS._0023_003DzCwOHtrY_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(1u, num);
			uint num5 = _0023_003Dzv2w0z_0024soYoTS._0023_003DzCwOHtrY_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(2u, num);
			uint num6;
			for (num6 = 0u; num6 < _0023_003Dzv2w0z_0024soYoTS._0023_003DzwrNSpXc_003D._0023_003DzmVsXTy4_003D(); num6++)
			{
				int num7 = 0;
				for (uint num8 = 0u; num8 < 4; num8++)
				{
					uint num9 = _0023_003Dzv2w0z_0024soYoTS._0023_003DzwrNSpXc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num8, num6);
					if (num9 == num3 || num9 == num4 || num9 == num5)
					{
						num7++;
					}
				}
				if (num7 == 3)
				{
					break;
				}
			}
			int key = _0023_003Dzv2w0z_0024soYoTS._0023_003DzZQ2HyLn4R0pl[num6];
			if (!dictionary.ContainsKey(key))
			{
				Material value = _0023_003Dz_YGD1I9bY_b9(num2);
				dictionary.Add(key, value);
			}
		}
		return dictionary;
	}

	private static bool _0023_003Dzmj_0024pmedaOAgd(Dictionary<int, Material> _0023_003DzqAZX1x0_003D, int _0023_003Dz1MMYB1g_003D)
	{
		foreach (KeyValuePair<int, Material> item in _0023_003DzqAZX1x0_003D)
		{
			if (item.Value.Name.GetHashCode() == _0023_003Dz1MMYB1g_003D)
			{
				return true;
			}
		}
		return false;
	}

	private Material _0023_003Dz_YGD1I9bY_b9(int _0023_003Dz1MMYB1g_003D)
	{
		foreach (Material item in _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D)
		{
			if (item.Name.GetHashCode() == _0023_003Dz1MMYB1g_003D)
			{
				return item;
			}
		}
		return null;
	}

	private Material _0023_003Dzjl5IbJ4_003D()
	{
		Material result = base.DefaultMaterial;
		if (!string.IsNullOrEmpty(_0023_003DzCGnGN9qHxd0V22c4_0024A_003D_003D) && _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D != null)
		{
			result = _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D[_0023_003DzCGnGN9qHxd0V22c4_0024A_003D_003D];
		}
		return result;
	}

	internal void _0023_003DzkPPLofqulhZU(Statistics _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzu2CfzBlGO3HdOUA9TA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private bool _0023_003DzYfD3DtJSv0t_jVsV1A_003D_003D(string _0023_003DzwyYng5o_003D, int _0023_003Dzo_0024IKNWU_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003Dzo_0024IKNWU_003D, 100.0, _0023_003DzwyYng5o_003D, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			return false;
		}
		return true;
	}

	private void _0023_003DzKl0nneoLQjT5(_0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa _0023_003Dz9lrNnXY_003D)
	{
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993669) + _0023_003Dz9lrNnXY_003D._0023_003DzP_0024xBud0vpCbb3KxtaQ_003D_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + _0023_003Dz9lrNnXY_003D._0023_003DzBuLNbsVnRtSJPAVzvg_003D_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993919));
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993900) + _0023_003Dz9lrNnXY_003D._0023_003DzwW3JslXbAFqC_0024cnx3195zvw_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + _0023_003Dz9lrNnXY_003D._0023_003Dzm4YaBPkeb0G08SavIJSTlI8_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993919));
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993862) + _0023_003Dz9lrNnXY_003D._0023_003DzuwwPVpp_K11A5WcA_0024TotspM_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + _0023_003Dz9lrNnXY_003D._0023_003DzTMD_flQlbF0qlVy3cI3NYf8_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993919));
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993856) + _0023_003Dz9lrNnXY_003D._0023_003Dzva7BZITJ_faa);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993818) + _0023_003Dz9lrNnXY_003D._0023_003Dz919Srlp4O7cL);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993524) + _0023_003Dz9lrNnXY_003D._0023_003DzFJ2iWmUjaUMpwyDObVp4dqsGkFeB._0023_003Dz14lzA48_003D());
		StringBuilder stringBuilder = log;
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993518);
		uint _0023_003DzMNS2407y5IguZ6LxVw_003D_003D = (uint)_0023_003Dz9lrNnXY_003D._0023_003DzMNS2407y5IguZ6LxVw_003D_003D;
		stringBuilder.AppendLine(text + _0023_003DzMNS2407y5IguZ6LxVw_003D_003D);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993480) + _0023_003Dz9lrNnXY_003D._0023_003DzhKcriekaIolc);
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993442), _0023_003Dz9lrNnXY_003D._0023_003DzR7YfVeure30J, _0023_003Dz9lrNnXY_003D._0023_003DzOrQli_0024PbeB4iqrLXR9IOa4KyVJsO));
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993422) + _0023_003Dz9lrNnXY_003D._0023_003DzOdF_L660_0024Zt7EdpeuA_003D_003D);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993640) + (float)_0023_003Dz9lrNnXY_003D._0023_003DzHwZck27UvORM);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993602) + (float)_0023_003Dz9lrNnXY_003D._0023_003DzfP5O9OEgcrVZ4BqU0Q_003D_003D);
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993596) + (float)_0023_003Dz9lrNnXY_003D._0023_003DzQg1KVytJuOCD_9T1CQ_003D_003D);
		if (_0023_003Dz9lrNnXY_003D._0023_003Dz1v8WebVg_QJi < 3.4028234663852886E+38)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993558) + (float)_0023_003Dz9lrNnXY_003D._0023_003DzJVcurc7aC3ye + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993552) + (float)_0023_003Dz9lrNnXY_003D._0023_003Dz1v8WebVg_QJi + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994300));
		}
		else
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993558) + (float)_0023_003Dz9lrNnXY_003D._0023_003DzJVcurc7aC3ye + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994282));
		}
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994272) + _0023_003Dz9lrNnXY_003D._0023_003Dzy4KjtXDBEOcHDYWn0s_0024ifJc_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994235));
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994213) + _0023_003Dz9lrNnXY_003D._0023_003DzSByIfIlBK7dZ() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994235));
		if (_0023_003Dz9lrNnXY_003D._0023_003Dzt_0024bwB94yNa7O != _0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa._0023_003DzrZycdFCM18XS.CM2_NO_ERROR)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994207) + _0023_003Dz9lrNnXY_003D._0023_003Dzt_0024bwB94yNa7O.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + _0023_003Dz9lrNnXY_003D._0023_003DzPgx1Ggk_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936860));
			log.AppendLine(_0023_003Dz9lrNnXY_003D._0023_003Dz2IEZG0k_003D);
		}
		else if (_0023_003Dz9lrNnXY_003D._0023_003DzNEJQb9Emq9QE != _0023_003DzR5pKiY95vhgx6pCdhiT6q5dEiMblwKjse1v32yU_003D._0023_003Dzd912TYYGXpaa._0023_003Dz9d_0024B1uwZ_0024Ebg.CM2_NO_WARNING)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994189) + _0023_003Dz9lrNnXY_003D._0023_003DzNEJQb9Emq9QE.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + _0023_003Dz9lrNnXY_003D._0023_003DzPgx1Ggk_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936860));
			log.AppendLine(_0023_003Dz9lrNnXY_003D._0023_003Dz2IEZG0k_003D);
		}
		if (!_0023_003Dz9lrNnXY_003D._0023_003Dznhk1IeJNMlLDW970Vw_003D_003D())
		{
			if (_0023_003Dz9lrNnXY_003D._0023_003DzhiZN7sb_GFxPPq7ZVA_003D_003D._0023_003Dzk3XcQZ8iarFJ() != 0)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994429));
				_0023_003Dzj84QQwSo_0024vtOyF2y7A_003D_003D(_0023_003Dz9lrNnXY_003D._0023_003DzhiZN7sb_GFxPPq7ZVA_003D_003D);
			}
			if (_0023_003Dz9lrNnXY_003D._0023_003DzNua_0024O2eShpSLq3OghA_003D_003D._0023_003Dzk3XcQZ8iarFJ() != 0)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994382));
				_0023_003Dzj84QQwSo_0024vtOyF2y7A_003D_003D(_0023_003Dz9lrNnXY_003D._0023_003DzNua_0024O2eShpSLq3OghA_003D_003D);
			}
			log.AppendLine();
		}
	}

	private void _0023_003Dzj84QQwSo_0024vtOyF2y7A_003D_003D(_0023_003Dz4E_o8GASGYaw8T_0024k8bKfJhqx77su _0023_003DzNDN2q2o_003D)
	{
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994331) + _0023_003DzNDN2q2o_003D._0023_003DzI1zpEBqLLdeB());
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994045) + _0023_003DzNDN2q2o_003D._0023_003Dzk3XcQZ8iarFJ());
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994015) + _0023_003DzNDN2q2o_003D._0023_003DzZiZ9Fzu8lvps());
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993953) + _0023_003DzNDN2q2o_003D._0023_003DzGWppTVCB4FLS());
		if (_0023_003DzNDN2q2o_003D._0023_003Dzk3XcQZ8iarFJ() != 0)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993923) + _0023_003DzNDN2q2o_003D._0023_003DzrXB9c9B0CxqT().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994164)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994149) + _0023_003DzNDN2q2o_003D._0023_003DzlfhuqoXyledi().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994164)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994134) + _0023_003DzNDN2q2o_003D._0023_003DzXY_0024U5XwJu_Sq().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994164)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			log.AppendLine();
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994115));
			string format = string.Empty;
			for (uint num = _0023_003DzNDN2q2o_003D._0023_003DzI1zpEBqLLdeB(); num >= 1; num--)
			{
				double num2 = _0023_003DzNDN2q2o_003D._0023_003DzUI0x3mHkXYRRlBd35w_003D_003D(num - 1);
				double num3 = _0023_003DzNDN2q2o_003D._0023_003DzUI0x3mHkXYRRlBd35w_003D_003D(num);
				uint num4 = _0023_003DzNDN2q2o_003D._0023_003DzuOMylKfpuJP0(num - 1);
				format = ((num2 > double.MinValue && num3 < double.MaxValue) ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994096), (int)(num - 1), num2, num3, num4) : ((!(num3 < double.MaxValue)) ? ((!(num2 > double.MinValue)) ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994694), (int)(num - 1), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994940), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994897), num4) : string.Format(format, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994766), (int)(num - 1), num2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994732), num4)) : string.Format(format, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994806), (int)(num - 1), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994799), num3, num4)));
				log.AppendLine(num - 1 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994891) + num2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007) + num3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994891) + num4);
			}
		}
	}

	public virtual CurveMesher CreateCurveMesher(ICurve curve, SizesOnCurve sizes)
	{
		return new CurveMesher(curve, sizes);
	}

	public virtual Mesher CreateFaceMesher(Surface surface, IList<Polygon2D> trimPolylines, double[] uniqueSizes, double uScale = 1.0, double vScale = 1.0)
	{
		return _0023_003DzqGVCgrBynBx__0zpNyyIoDq1UDfHNc80x4V1z5BRniPJF0BHLg_003D_003D._0023_003DzmotpphEGix2EvyQplA_003D_003D(surface, trimPolylines, uniqueSizes, uScale, vScale);
	}
}
