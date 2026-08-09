using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace devDept.Eyeshot.Control.Mouse3D;

internal static class tdx
{
	public interface _0023_003DzAukc9xtzVSPmr_V_0024uA_003D_003D
	{
		eNavigation _0023_003DzCfC2btroh5Se();

		ePivot _0023_003Dz3zjzUFBvKxvU();

		ePivotVisibility _0023_003Dz5VT6M5i1eQH_();

		bool _0023_003Dzkdj2mMDXsxr6BGZmjA_003D_003D();

		bool _0023_003DzbNGa_002433AD25XXkRfvg_003D_003D();

		void _0023_003DzFzC0auaQinVhyDa5mQ_003D_003D(bool _0023_003DzfszjSok_003D);

		void _0023_003DzCC6n4t2B0l9N(eNavigation _0023_003DzXwc9fSc_003D);

		void _0023_003DzDWnKTX8phBue(ePivot _0023_003DzEPP3sKE_003D);

		void _0023_003Dz9zSTbBnFoV3L(ePivotVisibility _0023_003DzUfTVrl0_003D);

		void _0023_003DztEteZ3FfaQtS7YlzIg_003D_003D(bool _0023_003DzfszjSok_003D);
	}

	public sealed class _0023_003DzLtoeZ7sPG9wi
	{
		public eSpeed _0023_003DzcU2W_0024IwZm_0024cF;

		public uint _0023_003DzQjy_0024yqw_003D;
	}

	public static class _0023_003DzQrZIT4w_003D
	{
		internal static virtualKey[] _0023_003DzgwropBYDt99e = new virtualKey[16]
		{
			virtualKey.V3DkInvalid,
			virtualKey.V3Dk1,
			virtualKey.V3Dk2,
			virtualKey.V3DkTop,
			virtualKey.V3DkLeft,
			virtualKey.V3DkRight,
			virtualKey.V3DkFront,
			virtualKey.V3DkEsc,
			virtualKey.V3DkAlt,
			virtualKey.V3DkShift,
			virtualKey.V3DkCtrl,
			virtualKey.V3DkFit,
			virtualKey.V3DkMenu,
			virtualKey.V3DkPlus,
			virtualKey.V3DkMinus,
			virtualKey.V3DkRotate
		};

		internal static virtualKey[] _0023_003DzcHD_3Rf_0024KbgBokKm1w_003D_003D = new virtualKey[22]
		{
			virtualKey.V3DkInvalid,
			virtualKey.V3Dk1,
			virtualKey.V3Dk2,
			virtualKey.V3Dk3,
			virtualKey.V3Dk4,
			virtualKey.V3Dk5,
			virtualKey.V3Dk6,
			virtualKey.V3DkTop,
			virtualKey.V3DkLeft,
			virtualKey.V3DkRight,
			virtualKey.V3DkFront,
			virtualKey.V3DkEsc,
			virtualKey.V3DkAlt,
			virtualKey.V3DkShift,
			virtualKey.V3DkCtrl,
			virtualKey.V3DkFit,
			virtualKey.V3DkMenu,
			virtualKey.V3DkPlus,
			virtualKey.V3DkMinus,
			virtualKey.V3DkDominant,
			virtualKey.V3DkRotate,
			(virtualKey)65537
		};

		internal static virtualKey[] _0023_003DzT4UjUAllmt2U = new virtualKey[3]
		{
			virtualKey.V3DkInvalid,
			virtualKey.V3DkMenu,
			virtualKey.V3DkFit
		};

		internal static virtualKey[] _0023_003Dzn63wBp8EmGjUHFxjTA_003D_003D = new virtualKey[32]
		{
			virtualKey.V3DkInvalid,
			virtualKey.V3DkMenu,
			virtualKey.V3DkFit,
			virtualKey.V3DkTop,
			virtualKey.V3DkLeft,
			virtualKey.V3DkRight,
			virtualKey.V3DkFront,
			virtualKey.V3DkBottom,
			virtualKey.V3DkBack,
			virtualKey.V3DkRollCw,
			virtualKey.V3DkRollCcw,
			virtualKey.V3DkIso1,
			virtualKey.V3DkIso2,
			virtualKey.V3Dk1,
			virtualKey.V3Dk2,
			virtualKey.V3Dk3,
			virtualKey.V3Dk4,
			virtualKey.V3Dk5,
			virtualKey.V3Dk6,
			virtualKey.V3Dk7,
			virtualKey.V3Dk8,
			virtualKey.V3Dk9,
			virtualKey.V3Dk10,
			virtualKey.V3DkEsc,
			virtualKey.V3DkAlt,
			virtualKey.V3DkShift,
			virtualKey.V3DkCtrl,
			virtualKey.V3DkRotate,
			virtualKey.V3DkPanzoom,
			virtualKey.V3DkDominant,
			virtualKey.V3DkPlus,
			virtualKey.V3DkMinus
		};

		internal static virtualKey[] _0023_003Dz6gXErkyeIXDw2GIXHQ_003D_003D = new virtualKey[28]
		{
			virtualKey.V3DkInvalid,
			virtualKey.V3DkMenu,
			virtualKey.V3DkFit,
			virtualKey.V3DkTop,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkRight,
			virtualKey.V3DkFront,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkRollCw,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3Dk1,
			virtualKey.V3Dk2,
			virtualKey.V3Dk3,
			virtualKey.V3Dk4,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkInvalid,
			virtualKey.V3DkEsc,
			virtualKey.V3DkAlt,
			virtualKey.V3DkShift,
			virtualKey.V3DkCtrl,
			virtualKey.V3DkRotate
		};

		internal static _0023_003DzfGpVGFuVOu8G[] _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y = new _0023_003DzfGpVGFuVOu8G[6]
		{
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50725,
				_0023_003DzsY_uUL0_003D = _0023_003DzcHD_3Rf_0024KbgBokKm1w_003D_003D.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003DzcHD_3Rf_0024KbgBokKm1w_003D_003D,
				_0023_003Dzwiks7NE_003D = _0023_003DzcHD_3Rf_0024KbgBokKm1w_003D_003D.Length - 1
			},
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50727,
				_0023_003DzsY_uUL0_003D = _0023_003DzgwropBYDt99e.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003DzgwropBYDt99e,
				_0023_003Dzwiks7NE_003D = _0023_003DzgwropBYDt99e.Length - 1
			},
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50726,
				_0023_003DzsY_uUL0_003D = _0023_003DzT4UjUAllmt2U.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003DzT4UjUAllmt2U,
				_0023_003Dzwiks7NE_003D = _0023_003DzT4UjUAllmt2U.Length - 1
			},
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50728,
				_0023_003DzsY_uUL0_003D = _0023_003DzT4UjUAllmt2U.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003DzT4UjUAllmt2U,
				_0023_003Dzwiks7NE_003D = _0023_003DzT4UjUAllmt2U.Length - 1
			},
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50729,
				_0023_003DzsY_uUL0_003D = _0023_003Dzn63wBp8EmGjUHFxjTA_003D_003D.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003Dzn63wBp8EmGjUHFxjTA_003D_003D,
				_0023_003Dzwiks7NE_003D = _0023_003Dzn63wBp8EmGjUHFxjTA_003D_003D.Length - 1
			},
			new _0023_003DzfGpVGFuVOu8G
			{
				_0023_003Dzz7FlTSI_003D = (_0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D)50731,
				_0023_003DzsY_uUL0_003D = _0023_003Dz6gXErkyeIXDw2GIXHQ_003D_003D.Length,
				_0023_003DzvuFeTSJbjtSm = _0023_003Dz6gXErkyeIXDw2GIXHQ_003D_003D,
				_0023_003Dzwiks7NE_003D = 15
			}
		};

		internal static virtualKey _0023_003Dz9mKByVHLf2A5(uint _0023_003Dzz7FlTSI_003D, ushort _0023_003Dzw6Oo3TLmV0bQ)
		{
			virtualKey result = (virtualKey)_0023_003Dzw6Oo3TLmV0bQ;
			for (uint num = 0u; num < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y.Length; num++)
			{
				if ((ulong)_0023_003Dzz7FlTSI_003D == (ulong)_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzz7FlTSI_003D)
				{
					result = ((_0023_003Dzw6Oo3TLmV0bQ < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzsY_uUL0_003D) ? _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzvuFeTSJbjtSm[_0023_003Dzw6Oo3TLmV0bQ] : virtualKey.V3DkInvalid);
					break;
				}
			}
			return result;
		}

		public static ushort _0023_003DzGCzl1_0024s7cu_C(uint _0023_003Dzz7FlTSI_003D, virtualKey _0023_003Dz_FrdqGB0zFPpofv8rA_003D_003D)
		{
			for (uint num = 0u; num < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y.Length; num++)
			{
				if ((ulong)_0023_003Dzz7FlTSI_003D != (ulong)_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzz7FlTSI_003D)
				{
					continue;
				}
				for (ushort num2 = 0; num2 < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzsY_uUL0_003D; num2++)
				{
					if (_0023_003Dz_FrdqGB0zFPpofv8rA_003D_003D == _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzvuFeTSJbjtSm[num2])
					{
						return num2;
					}
				}
				return 0;
			}
			return (ushort)_0023_003Dz_FrdqGB0zFPpofv8rA_003D_003D;
		}

		public static int _0023_003DzXEebbVFMvuSK(uint _0023_003Dzz7FlTSI_003D)
		{
			for (uint num = 0u; num < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y.Length; num++)
			{
				if ((ulong)_0023_003Dzz7FlTSI_003D == (ulong)_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzz7FlTSI_003D)
				{
					return _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzwiks7NE_003D;
				}
			}
			return 0;
		}

		public static int _0023_003DzPrSPQKLcZ1lL(uint _0023_003Dzz7FlTSI_003D, ushort _0023_003Dzw6Oo3TLmV0bQ)
		{
			for (uint num = 0u; num < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y.Length; num++)
			{
				if (_0023_003Dzz7FlTSI_003D != (uint)_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzz7FlTSI_003D)
				{
					continue;
				}
				int num2 = -1;
				if (_0023_003Dzw6Oo3TLmV0bQ < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzsY_uUL0_003D && _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzvuFeTSJbjtSm[_0023_003Dzw6Oo3TLmV0bQ] != virtualKey.V3DkInvalid)
				{
					for (int i = 1; i <= _0023_003Dzw6Oo3TLmV0bQ; i++)
					{
						if (_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzvuFeTSJbjtSm[i] != virtualKey.V3DkInvalid)
						{
							num2++;
						}
					}
				}
				return num2;
			}
			return _0023_003Dzw6Oo3TLmV0bQ - 1;
		}

		public static ushort _0023_003DzM0wHsdQ5sp4O(uint _0023_003Dzz7FlTSI_003D, int _0023_003DznRRpGN8_003D)
		{
			if (_0023_003DznRRpGN8_003D < 0)
			{
				return 0;
			}
			for (uint num = 0u; num < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y.Length; num++)
			{
				if (_0023_003Dzz7FlTSI_003D != (uint)_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003Dzz7FlTSI_003D)
				{
					continue;
				}
				if (_0023_003DznRRpGN8_003D < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzsY_uUL0_003D)
				{
					for (uint num2 = 1u; num2 < _0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzsY_uUL0_003D; num2++)
					{
						if (_0023_003Dz5ngAVJnvqkHFJuVE33IQuCV8BH2Y[num]._0023_003DzvuFeTSJbjtSm[num2] != virtualKey.V3DkInvalid)
						{
							_0023_003DznRRpGN8_003D--;
							if (_0023_003DznRRpGN8_003D == -1)
							{
								return (ushort)num2;
							}
						}
					}
				}
				return 0;
			}
			return (ushort)(_0023_003DznRRpGN8_003D + 1);
		}
	}

	public sealed class _0023_003DzU92UmS0FCr2P
	{
		public eNavigation _0023_003DzmrtMJ48_003D;

		public uint _0023_003DzQjy_0024yqw_003D;
	}

	[ToolboxItem(false)]
	public sealed class _0023_003DzXtx9sC7_3JFy8PHscwUUAyI_003D : ContextMenuStrip
	{
		public _0023_003DzXtx9sC7_3JFy8PHscwUUAyI_003D()
		{
			_0023_003Dz2oGMMXtbG3U3yWji9RS7_JI_003D();
		}

		public _0023_003DzXtx9sC7_3JFy8PHscwUUAyI_003D(IContainer _0023_003DzhX3k_fU_003D)
			: base(_0023_003DzhX3k_fU_003D)
		{
			_0023_003Dz2oGMMXtbG3U3yWji9RS7_JI_003D();
		}

		private void _0023_003Dz2oGMMXtbG3U3yWji9RS7_JI_003D()
		{
			Items.Add(new ToolStripControlHost(new CheckBox(), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586046)));
			Items.Add(new ToolStripControlHost(new CheckBox(), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586033)));
			Items.Add(new ToolStripSeparator());
			Items.Add(new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648790)));
			Items.Add(new ToolStripSeparator());
			Items.Add(new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588005)));
		}
	}

	public interface _0023_003Dzei4BwKmu8m0eB7YWAxBE5Ao_003D
	{
		bool _0023_003DzjNHsBLIPuHQi();

		bool _0023_003DzfCFacxHAH779();

		bool _0023_003DzglI63bk_003D();

		double _0023_003DzQucg3Fw_003D();

		void _0023_003DzEJojt83_0024fX8g(bool _0023_003DzDuFgIHtVgjTN);

		void _0023_003DzObzhR_0024w_003D(bool _0023_003Dzx_00248pUoI_003D);

		void _0023_003DzX1bCrY8_003D(double _0023_003DzcU2W_0024IwZm_0024cF);

		void _0023_003DzvUR5jyyZ7jzc(bool _0023_003DzYvunAdQ_003D);
	}

	public sealed class _0023_003DzfGpVGFuVOu8G
	{
		public _0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D _0023_003Dzz7FlTSI_003D;

		public int _0023_003DzsY_uUL0_003D;

		public virtualKey[] _0023_003DzvuFeTSJbjtSm;

		public int _0023_003Dzwiks7NE_003D;
	}

	public sealed class _0023_003DzgFNbvZmPsHHH
	{
		public ePivotVisibility _0023_003DzUfTVrl0_003D;

		public uint _0023_003DzQjy_0024yqw_003D;
	}

	public enum _0023_003DziJ6wK0j3RSd7xYUXedUPD_00240_003D
	{

	}

	public interface _0023_003DzmLqTbd4e1_YiJS44CQ_003D_003D : _0023_003Dzei4BwKmu8m0eB7YWAxBE5Ao_003D, _0023_003DzAukc9xtzVSPmr_V_0024uA_003D_003D
	{
		void _0023_003DzOfoLFl0_003D();

		void _0023_003DzKZF8cIk_003D();
	}

	[Serializable]
	public sealed class C3dmouseParams : _0023_003DzmLqTbd4e1_YiJS44CQ_003D_003D, _0023_003Dzei4BwKmu8m0eB7YWAxBE5Ao_003D, _0023_003DzAukc9xtzVSPmr_V_0024uA_003D_003D
	{
		private eNavigation m_eNavigation = eNavigation.helicopterMode;

		private ePivot m_ePivot;

		private ePivotVisibility m_ePivotVisibility;

		private bool m_bIsLockHorizon;

		private bool m_bIsSingleAxisFilter;

		private bool m_bIsPanZoom;

		private bool m_bIsRotate;

		private double m_eSpeed;

		private bool m_bSelectionFollower;

		public C3dmouseParams()
		{
			m_ePivot = ePivot.AutoPivot;
			m_ePivotVisibility = ePivotVisibility.showMovingPivot;
			m_bIsLockHorizon = false;
			m_bIsPanZoom = (m_bIsRotate = true);
			m_eSpeed = 0.25;
			m_bIsSingleAxisFilter = (m_bSelectionFollower = false);
		}

		public void _0023_003DzOfoLFl0_003D()
		{
		}

		public void _0023_003DzKZF8cIk_003D()
		{
		}

		public bool _0023_003DzjNHsBLIPuHQi()
		{
			return m_bIsSingleAxisFilter;
		}

		public bool _0023_003DzfCFacxHAH779()
		{
			return m_bIsPanZoom;
		}

		public bool _0023_003DzglI63bk_003D()
		{
			return m_bIsRotate;
		}

		public double _0023_003DzQucg3Fw_003D()
		{
			return m_eSpeed;
		}

		public void _0023_003DzEJojt83_0024fX8g(bool _0023_003DzDuFgIHtVgjTN)
		{
			m_bIsPanZoom = _0023_003DzDuFgIHtVgjTN;
		}

		public void _0023_003DzObzhR_0024w_003D(bool _0023_003Dzx_00248pUoI_003D)
		{
			m_bIsRotate = _0023_003Dzx_00248pUoI_003D;
		}

		public void _0023_003DzX1bCrY8_003D(double _0023_003DzcU2W_0024IwZm_0024cF)
		{
			m_eSpeed = _0023_003DzcU2W_0024IwZm_0024cF;
		}

		public void _0023_003DzvUR5jyyZ7jzc(bool _0023_003DzYvunAdQ_003D)
		{
			m_bIsSingleAxisFilter = _0023_003DzYvunAdQ_003D;
		}

		public eNavigation _0023_003DzCfC2btroh5Se()
		{
			return m_eNavigation;
		}

		public ePivot _0023_003Dz3zjzUFBvKxvU()
		{
			return m_ePivot;
		}

		public ePivotVisibility _0023_003Dz5VT6M5i1eQH_()
		{
			return m_ePivotVisibility;
		}

		public bool _0023_003Dzkdj2mMDXsxr6BGZmjA_003D_003D()
		{
			return m_bIsLockHorizon;
		}

		public bool _0023_003DzbNGa_002433AD25XXkRfvg_003D_003D()
		{
			return m_bSelectionFollower;
		}

		public void _0023_003DzFzC0auaQinVhyDa5mQ_003D_003D(bool _0023_003DzfszjSok_003D)
		{
			m_bIsLockHorizon = _0023_003DzfszjSok_003D;
		}

		public void _0023_003DzCC6n4t2B0l9N(eNavigation _0023_003DzXwc9fSc_003D)
		{
			m_eNavigation = _0023_003DzXwc9fSc_003D;
		}

		public void _0023_003DztEteZ3FfaQtS7YlzIg_003D_003D(bool _0023_003DzfszjSok_003D)
		{
			m_bSelectionFollower = _0023_003DzfszjSok_003D;
		}

		public void _0023_003DzDWnKTX8phBue(ePivot _0023_003DzEPP3sKE_003D)
		{
			m_ePivot = _0023_003DzEPP3sKE_003D;
		}

		public void _0023_003Dz9zSTbBnFoV3L(ePivotVisibility _0023_003DzUfTVrl0_003D)
		{
			m_ePivotVisibility = _0023_003DzUfTVrl0_003D;
		}
	}

	public enum eNavigation
	{
		objectMode,
		cameraMode,
		flyMode,
		walkMode,
		helicopterMode,
		targetCameraMode
	}

	public enum ePivot
	{
		ManualPivot,
		AutoPivot
	}

	public enum ePivotVisibility
	{
		hidePivot,
		showPivot,
		showMovingPivot
	}

	public enum eSpeed
	{
		lowSpeed,
		slowerSpeed,
		midSpeed,
		fasterSpeed,
		highSpeed
	}

	public static readonly _0023_003DzU92UmS0FCr2P[] _0023_003DzcK9JtPb6XC7E = new _0023_003DzU92UmS0FCr2P[6]
	{
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.objectMode,
			_0023_003DzQjy_0024yqw_003D = 40992u
		},
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.cameraMode,
			_0023_003DzQjy_0024yqw_003D = 40993u
		},
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.helicopterMode,
			_0023_003DzQjy_0024yqw_003D = 40994u
		},
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.walkMode,
			_0023_003DzQjy_0024yqw_003D = 40995u
		},
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.flyMode,
			_0023_003DzQjy_0024yqw_003D = 40996u
		},
		new _0023_003DzU92UmS0FCr2P
		{
			_0023_003DzmrtMJ48_003D = eNavigation.targetCameraMode,
			_0023_003DzQjy_0024yqw_003D = 40997u
		}
	};

	public static readonly _0023_003DzLtoeZ7sPG9wi[] _0023_003DzVfDN0c6C1Lxc = new _0023_003DzLtoeZ7sPG9wi[5]
	{
		new _0023_003DzLtoeZ7sPG9wi
		{
			_0023_003DzcU2W_0024IwZm_0024cF = eSpeed.lowSpeed,
			_0023_003DzQjy_0024yqw_003D = 40977u
		},
		new _0023_003DzLtoeZ7sPG9wi
		{
			_0023_003DzcU2W_0024IwZm_0024cF = eSpeed.slowerSpeed,
			_0023_003DzQjy_0024yqw_003D = 40978u
		},
		new _0023_003DzLtoeZ7sPG9wi
		{
			_0023_003DzcU2W_0024IwZm_0024cF = eSpeed.midSpeed,
			_0023_003DzQjy_0024yqw_003D = 40979u
		},
		new _0023_003DzLtoeZ7sPG9wi
		{
			_0023_003DzcU2W_0024IwZm_0024cF = eSpeed.fasterSpeed,
			_0023_003DzQjy_0024yqw_003D = 40980u
		},
		new _0023_003DzLtoeZ7sPG9wi
		{
			_0023_003DzcU2W_0024IwZm_0024cF = eSpeed.highSpeed,
			_0023_003DzQjy_0024yqw_003D = 40981u
		}
	};

	public static readonly _0023_003DzgFNbvZmPsHHH[] _0023_003DzCOcFdJUrC5Lc = new _0023_003DzgFNbvZmPsHHH[3]
	{
		new _0023_003DzgFNbvZmPsHHH
		{
			_0023_003DzUfTVrl0_003D = ePivotVisibility.showPivot,
			_0023_003DzQjy_0024yqw_003D = 40967u
		},
		new _0023_003DzgFNbvZmPsHHH
		{
			_0023_003DzUfTVrl0_003D = ePivotVisibility.hidePivot,
			_0023_003DzQjy_0024yqw_003D = 40968u
		},
		new _0023_003DzgFNbvZmPsHHH
		{
			_0023_003DzUfTVrl0_003D = ePivotVisibility.showMovingPivot,
			_0023_003DzQjy_0024yqw_003D = 40969u
		}
	};

	public static readonly float[] _0023_003DzUiPCQHxNFWkm = new float[5] { 0.25f, 0.5f, 1f, 2f, 4f };

	public static float[] _0023_003DzxbaFJ7Rfcr9BMZS9ZgZ5wfxa02VkPJfq_0024A_003D_003D(float[] _0023_003Dze9_MsQo_003D, float[] _0023_003DzSlUCucc_003D)
	{
		_0023_003Dze9_MsQo_003D[0] = _0023_003DzSlUCucc_003D[1];
		_0023_003Dze9_MsQo_003D[1] = _0023_003DzSlUCucc_003D[0];
		_0023_003Dze9_MsQo_003D[2] = 0f - _0023_003DzSlUCucc_003D[2];
		_0023_003Dze9_MsQo_003D[3] = _0023_003DzSlUCucc_003D[4];
		_0023_003Dze9_MsQo_003D[4] = _0023_003DzSlUCucc_003D[3];
		_0023_003Dze9_MsQo_003D[5] = 0f - _0023_003DzSlUCucc_003D[5];
		return _0023_003Dze9_MsQo_003D;
	}
}
