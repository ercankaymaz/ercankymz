using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(ProgressBarConverter))]
public class ProgressBar : BarBase, IDisposable, ICloneable
{
	private delegate Rectangle _0023_003DzB_we3VWzlAGc(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003Dzy93CwkuWDHzq, Color _0023_003DztZyx6rs_003D);

	private delegate void _0023_003DzuOgSCbhlyZOm(Span<(uint, uint)> _0023_003DzjgFw0oQ_003D, Span<(uint, uint)> _0023_003Dz8jTMOh8_003D, out bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);

	private sealed class _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D
	{
		internal sealed class _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D : _0023_003DzauqPsW59rmLG
		{
			private double _0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D;

			private double _0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D;

			private bool _0023_003Dzv4ICjEMIbgWLcwzULZIxP0O8Pf5j;

			private bool _0023_003DzxgbMSjoAnGwIwwDV0W4HimGifevrWEnKYw_003D_003D;

			public _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D(bool _0023_003DzQVsx1WI_003D, double _0023_003Dzy50wP2s_003D, double _0023_003Dz51kNFoRhUGYl, bool _0023_003Dz9IS__yM0NwRnsVTVIA_003D_003D = false, bool _0023_003Dz8Ffp76An4CV6hWgsJHAMTu0_003D = false)
				: base(_0023_003DzQVsx1WI_003D)
			{
				_0023_003DzL3LVYV6kZv9W(_0023_003Dzy50wP2s_003D);
				_0023_003DzEJBzYIr76y9M(_0023_003Dz51kNFoRhUGYl);
				_0023_003Dz54ffAUb1hWEp7qZR0w_003D_003D(_0023_003Dz9IS__yM0NwRnsVTVIA_003D_003D);
				_0023_003DzPP_0024cdOfuk2pfCRCSDRph6IU_003D(_0023_003Dz8Ffp76An4CV6hWgsJHAMTu0_003D);
			}

			public double _0023_003DzbNj9_0024R_0024dgd0J()
			{
				return _0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D;
			}

			private void _0023_003DzL3LVYV6kZv9W(double _0023_003DzsLHxXyo_003D)
			{
				_0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D = _0023_003DzsLHxXyo_003D;
			}

			public double _0023_003DzLfZejrZ8xCH3()
			{
				return _0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D;
			}

			private void _0023_003DzEJBzYIr76y9M(double _0023_003DzsLHxXyo_003D)
			{
				_0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D = _0023_003DzsLHxXyo_003D;
			}

			public bool _0023_003Dz_xrM6DbBLqch1rs9Bg_003D_003D()
			{
				return _0023_003Dzv4ICjEMIbgWLcwzULZIxP0O8Pf5j;
			}

			private void _0023_003Dz54ffAUb1hWEp7qZR0w_003D_003D(bool _0023_003DzsLHxXyo_003D)
			{
				_0023_003Dzv4ICjEMIbgWLcwzULZIxP0O8Pf5j = _0023_003DzsLHxXyo_003D;
			}

			public bool _0023_003DzdpevWaXz6Z753IYSl1dZy9w_003D()
			{
				return _0023_003DzxgbMSjoAnGwIwwDV0W4HimGifevrWEnKYw_003D_003D;
			}

			private void _0023_003DzPP_0024cdOfuk2pfCRCSDRph6IU_003D(bool _0023_003DzsLHxXyo_003D)
			{
				_0023_003DzxgbMSjoAnGwIwwDV0W4HimGifevrWEnKYw_003D_003D = _0023_003DzsLHxXyo_003D;
			}
		}

		internal sealed class _0023_003DzKplahCAXWZcCuUaKhQ_003D_003D : _0023_003DzauqPsW59rmLG
		{
			private double _0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D;

			private double _0023_003Dz8CzZZg75QX1WsEFTK4Yd3SI_003D;

			private double _0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D;

			public _0023_003DzKplahCAXWZcCuUaKhQ_003D_003D(bool _0023_003DzQVsx1WI_003D, double _0023_003Dzy50wP2s_003D, double _0023_003DzcGi3Cixanvmi, double _0023_003Dz51kNFoRhUGYl)
				: base(_0023_003DzQVsx1WI_003D)
			{
				_0023_003DzL3LVYV6kZv9W(_0023_003Dzy50wP2s_003D);
				_0023_003Dzo5gow0RSHZbt(_0023_003DzcGi3Cixanvmi);
				_0023_003DzEJBzYIr76y9M(_0023_003Dz51kNFoRhUGYl);
			}

			public double _0023_003DzbNj9_0024R_0024dgd0J()
			{
				return _0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D;
			}

			private void _0023_003DzL3LVYV6kZv9W(double _0023_003DzsLHxXyo_003D)
			{
				_0023_003DzuX_0024i_00249YKqll1mCNgsA_003D_003D = _0023_003DzsLHxXyo_003D;
			}

			public double _0023_003Dzq_a2pdxqJNzJ()
			{
				return _0023_003Dz8CzZZg75QX1WsEFTK4Yd3SI_003D;
			}

			private void _0023_003Dzo5gow0RSHZbt(double _0023_003DzsLHxXyo_003D)
			{
				_0023_003Dz8CzZZg75QX1WsEFTK4Yd3SI_003D = _0023_003DzsLHxXyo_003D;
			}

			public double _0023_003DzLfZejrZ8xCH3()
			{
				return _0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D;
			}

			private void _0023_003DzEJBzYIr76y9M(double _0023_003DzsLHxXyo_003D)
			{
				_0023_003Dz256Qa9qD38uiRJsitnv_8Rg_003D = _0023_003DzsLHxXyo_003D;
			}
		}

		internal abstract class _0023_003DzauqPsW59rmLG
		{
			private bool _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;

			public _0023_003DzauqPsW59rmLG(bool _0023_003DzQVsx1WI_003D)
			{
				_0023_003DzoDJTka6IGpKo(_0023_003DzQVsx1WI_003D);
			}

			public bool _0023_003DzmTTi6DOQsqq7()
			{
				return _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;
			}

			private void _0023_003DzoDJTka6IGpKo(bool _0023_003DzsLHxXyo_003D)
			{
				_0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D = _0023_003DzsLHxXyo_003D;
			}
		}

		private int _0023_003DzItK0ZYCeePjzvqgH4Q0sSOI_003D;

		private bool _0023_003DzYdeqoOxZCw3aEGt3qA_003D_003D;

		private double _0023_003Dz32pxELfktw6f9NK24IK8a_ohNHci;

		private double _0023_003DzVpKq6jRahNpJeaktZkX_0024lKkftnoN;

		private _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003Dzk8xsXqXyLvZ9fC9Dzat6JtZBO3TT;

		private _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzWYBmhbpp6v5TpNnonQQbUepOudz9;

		private _0023_003DzKplahCAXWZcCuUaKhQ_003D_003D _0023_003DzBXzQ59_uJ7Q_5AMWzvTGLjQ_003D;

		private Interval _0023_003Dze6Z_0024vlw3w_0024HXPVhdXg_003D_003D;

		private double _0023_003DzCS6jw8I_0024MiVvwc4L_UfJ_7g_003D;

		internal _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D(double _0023_003DzYfC6eDL8U80flPvp3d5ZapQ_003D, double _0023_003DzcF1aAkDbTXPQVpUPuKRuQCU_003D, int _0023_003DzgJsyR_00249gUSYp = 0, _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzWbRzr6YrCXCSZqRLtA_003D_003D = null, _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzzoAQJJBC_NalKMNl2Q_003D_003D = null, _0023_003DzKplahCAXWZcCuUaKhQ_003D_003D _0023_003Dzxk1tj3Mw8tAF = null)
		{
			_0023_003Dzqa_kyeo_YseEgGdilH0Nujg_003D(_0023_003DzYfC6eDL8U80flPvp3d5ZapQ_003D);
			_0023_003DztgzeTrO4cw3ydF5q1MRF5oE_003D(_0023_003DzcF1aAkDbTXPQVpUPuKRuQCU_003D);
			_0023_003DzFM5xPTG73E_0024_(_0023_003DzgJsyR_00249gUSYp);
			_0023_003Dz8FsN3tFzXN_00248(_0023_003DzgJsyR_00249gUSYp > 0);
			_0023_003Dzmt7hLDqaupSgts4Q_0024w_003D_003D(_0023_003DzWbRzr6YrCXCSZqRLtA_003D_003D);
			_0023_003Dzt_6EveD3EfaQ9megGg_003D_003D(_0023_003DzzoAQJJBC_NalKMNl2Q_003D_003D);
			_0023_003DzotLVzzz1t00whfFFyw_003D_003D(_0023_003Dzxk1tj3Mw8tAF);
			_0023_003DzSwQcMMBNxHng(new Interval(_0023_003DzYfC6eDL8U80flPvp3d5ZapQ_003D, _0023_003DzcF1aAkDbTXPQVpUPuKRuQCU_003D));
			_0023_003DzZvGzix4thQZd((_0023_003DzzuahzePi3_0024lp().Length < 0.0) ? (Math.PI * 2.0 + _0023_003DzzuahzePi3_0024lp().Length) : _0023_003DzzuahzePi3_0024lp().Length);
		}

		public int _0023_003DzQDPlya_0024AzIAl()
		{
			return _0023_003DzItK0ZYCeePjzvqgH4Q0sSOI_003D;
		}

		private void _0023_003DzFM5xPTG73E_0024_(int _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzItK0ZYCeePjzvqgH4Q0sSOI_003D = _0023_003DzsLHxXyo_003D;
		}

		public bool _0023_003DzGo1Oq1ngcbBi()
		{
			return _0023_003DzYdeqoOxZCw3aEGt3qA_003D_003D;
		}

		private void _0023_003Dz8FsN3tFzXN_00248(bool _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzYdeqoOxZCw3aEGt3qA_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		public double _0023_003DztZ0US5XCBzyJIz0AQJKUPi0_003D()
		{
			return _0023_003Dz32pxELfktw6f9NK24IK8a_ohNHci;
		}

		private void _0023_003Dzqa_kyeo_YseEgGdilH0Nujg_003D(double _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz32pxELfktw6f9NK24IK8a_ohNHci = _0023_003DzsLHxXyo_003D;
		}

		public double _0023_003Dz3zn9P_nRqb_jyMFkU1sgtbg_003D()
		{
			return _0023_003DzVpKq6jRahNpJeaktZkX_0024lKkftnoN;
		}

		private void _0023_003DztgzeTrO4cw3ydF5q1MRF5oE_003D(double _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzVpKq6jRahNpJeaktZkX_0024lKkftnoN = _0023_003DzsLHxXyo_003D;
		}

		public _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()
		{
			return _0023_003Dzk8xsXqXyLvZ9fC9Dzat6JtZBO3TT;
		}

		private void _0023_003Dzmt7hLDqaupSgts4Q_0024w_003D_003D(_0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dzk8xsXqXyLvZ9fC9Dzat6JtZBO3TT = _0023_003DzsLHxXyo_003D;
		}

		public _0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()
		{
			return _0023_003DzWYBmhbpp6v5TpNnonQQbUepOudz9;
		}

		private void _0023_003Dzt_6EveD3EfaQ9megGg_003D_003D(_0023_003Dz77P2CznSUWIDA1vlhw_003D_003D _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzWYBmhbpp6v5TpNnonQQbUepOudz9 = _0023_003DzsLHxXyo_003D;
		}

		public _0023_003DzKplahCAXWZcCuUaKhQ_003D_003D _0023_003DznynynDwur6eZimyjqA_003D_003D()
		{
			return _0023_003DzBXzQ59_uJ7Q_5AMWzvTGLjQ_003D;
		}

		private void _0023_003DzotLVzzz1t00whfFFyw_003D_003D(_0023_003DzKplahCAXWZcCuUaKhQ_003D_003D _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzBXzQ59_uJ7Q_5AMWzvTGLjQ_003D = _0023_003DzsLHxXyo_003D;
		}

		public Interval _0023_003DzzuahzePi3_0024lp()
		{
			return _0023_003Dze6Z_0024vlw3w_0024HXPVhdXg_003D_003D;
		}

		private void _0023_003DzSwQcMMBNxHng(Interval _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dze6Z_0024vlw3w_0024HXPVhdXg_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		public double _0023_003Dz1_WqrEDPLmKA()
		{
			return _0023_003DzCS6jw8I_0024MiVvwc4L_UfJ_7g_003D;
		}

		private void _0023_003DzZvGzix4thQZd(double _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzCS6jw8I_0024MiVvwc4L_UfJ_7g_003D = _0023_003DzsLHxXyo_003D;
		}

		public bool[] _0023_003Dz_xrM6DbBLqch1rs9Bg_003D_003D()
		{
			return new bool[3]
			{
				_0023_003DzNVkcE6w_003D(_0023_003DznynynDwur6eZimyjqA_003D_003D()),
				_0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()?._0023_003Dz_xrM6DbBLqch1rs9Bg_003D_003D() ?? false,
				_0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()?._0023_003Dz_xrM6DbBLqch1rs9Bg_003D_003D() ?? false
			};
		}

		public bool[] _0023_003Dz0k6VgmiAjsPE5XK0xKyvaKeZPcrk()
		{
			return new bool[3]
			{
				false,
				_0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()?._0023_003DzdpevWaXz6Z753IYSl1dZy9w_003D() ?? false,
				_0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()?._0023_003DzdpevWaXz6Z753IYSl1dZy9w_003D() ?? false
			};
		}

		internal static bool _0023_003DzNVkcE6w_003D(_0023_003DzauqPsW59rmLG _0023_003Dz7Ch8YDs_003D)
		{
			return _0023_003Dz7Ch8YDs_003D?._0023_003DzmTTi6DOQsqq7() ?? false;
		}
	}

	public enum styleType
	{
		Linear,
		Docked,
		Circular,
		Speedometer
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Color _0023_003DzoJttSzK_0024LWjTxlGa9JhDQik_003D = Color.Black;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Color _0023_003DzCvGnlcRhcYUN8ggh3YuQByOZpb7jokZIyQ_003D_003D = Color.Transparent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Color _0023_003DzWDIBUYYXYnWA = Color.Green;

	private readonly _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D CircularBodyParams = new _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D(Utility.DegToRad(90.0), Utility.DegToRad(450.0));

	private readonly _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D SpeedometerBodyParams = new _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D(Utility.DegToRad(330.0), Utility.DegToRad(210.0), 11, new _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003Dz77P2CznSUWIDA1vlhw_003D_003D(_0023_003DzQVsx1WI_003D: true, 0.2, 0.15), new _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003Dz77P2CznSUWIDA1vlhw_003D_003D(_0023_003DzQVsx1WI_003D: true, 0.2, 0.15, _0023_003Dz9IS__yM0NwRnsVTVIA_003D_003D: true), new _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzKplahCAXWZcCuUaKhQ_003D_003D(_0023_003DzQVsx1WI_003D: true, 0.0, 6.2, 0.5));

	private System.Threading.Timer _animationTimer;

	private Workspace _parentWorkspace;

	private object _lockObj = new object();

	private AutoResetEvent _done = new AutoResetEvent(initialState: false);

	private bool _dirtyBounds;

	private styleType _styleMode;

	private List<Point2D> _boundsPts = new List<Point2D>();

	private int _lenCompletedSpan;

	private int _lenRemainingSpan;

	private _0023_003DzuOgSCbhlyZOm _drawMethod;

	private _0023_003DzB_we3VWzlAGc _drawTextMethod;

	private FastMesh _progressBarBody;

	private FastMesh _spikesBody;

	private System.Drawing.Point _textPos;

	private bool _isDirty = true;

	internal bool previousVisibility;

	internal int previousValue;

	internal bool cancelling;

	[CompilerGenerated]
	private bool _003Ccontinuous_003Ek__BackingField;

	private double _lengthFactor;

	private string _text;

	private string _defaultText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852);

	private double _thicknessFactor;

	private int _value;

	protected internal override Viewport ParentViewport
	{
		get
		{
			if (_parentWorkspace != null)
			{
				return _parentWorkspace._0023_003DzipBYly6zFKAp();
			}
			return null;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592873));
		}
	}

	protected internal virtual Workspace ParentWorkspace
	{
		get
		{
			return _parentWorkspace;
		}
		set
		{
			_parentWorkspace = value;
		}
	}

	[Description("Progress bar activation status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Active { get; set; } = true;

	[Description("The animation interval for continuous progress bar.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int AnimationInterval { get; set; } = 40;

	[Description("Progress bar cancelling text.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public string CancellingText { get; set; }

	[Description("Progress bar default cancelling text.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public string DefaultCancellingText { get; set; }

	[Description("The progress bar color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color Color { get; set; }

	[Description("Scale of the progress bar.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double DrawScale { get; set; }

	[Description("The linear progress bar length factor (range 0-1).")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	public double LengthFactor
	{
		get
		{
			return _lengthFactor;
		}
		set
		{
			_lengthFactor = Math.Max(0.0, Math.Min(1.0, value));
		}
	}

	[Description("When false, the UI element is drawn with a flat color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Lighting { get; set; }

	[Description("Progress bar text.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			_0023_003Dz_WlOvqR1pka_();
		}
	}

	[Description("Progress bar default text.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string DefaultText
	{
		get
		{
			return _defaultText;
		}
		set
		{
			_defaultText = value;
			Text = value;
		}
	}

	[Description("The progress bar text background color")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TextBackgroundColor { get; set; }

	[Description("The progress bar text color")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TextColor { get; set; }

	[Description("The progress bar thickness factor (range 0-1).")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	public double ThicknessFactor
	{
		get
		{
			return _thicknessFactor;
		}
		set
		{
			_thicknessFactor = Math.Max(0.0, Math.Min(1.0, value));
		}
	}

	[Description("The percent text visibility status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowPercentText { get; set; }

	[Description("The progress bar style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public styleType StyleMode
	{
		get
		{
			return _styleMode;
		}
		set
		{
			if (ParentWorkspace is Manufacture && (value == styleType.Docked || value == styleType.Linear))
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592704));
			}
			if (value != _styleMode)
			{
				_0023_003Dz_WlOvqR1pka_();
			}
			_styleMode = value;
			_0023_003DzVRx5720_003D();
			_0023_003DzFb4SDdNZ64ti();
		}
	}

	[Description("Progress bar value.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			Utility.LimitRange(0, ref _value, 100);
		}
	}

	[Description("Progress bar visibility status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible { get; set; }

	public ProgressBar()
		: this(styleType.Speedometer, 0, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852), _0023_003DzoJttSzK_0024LWjTxlGa9JhDQik_003D, _0023_003DzCvGnlcRhcYUN8ggh3YuQByOZpb7jokZIyQ_003D_003D, _0023_003DzWDIBUYYXYnWA, 1.0, visible: false, lighting: true, 0.1, 0.333, showPercentText: true, active: true)
	{
		Text = DefaultText;
		CancellingText = DefaultCancellingText;
	}

	[Obsolete("This constructor is deprecated.")]
	public ProgressBar(styleType style, int value, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool active, ToolBarButton button)
	{
		_0023_003DzshPEPAc_003D(style, value, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852), text, RenderContextUtility.ConvertColor(textColor), RenderContextUtility.ConvertColor(textBackgroundColor), RenderContextUtility.ConvertColor(color), drawScale, _0023_003DzbWHNjOg_003D: false, active, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, 0.1, 0.333, _0023_003DzyOP_O0Y3l6bj: true, 40);
	}

	[Obsolete("This constructor is deprecated.")]
	public ProgressBar(styleType style, int value, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool active)
		: this(style, value, text, textColor, textBackgroundColor, color, drawScale, active: false, null)
	{
		Active = active;
	}

	[Obsolete("This constructor is deprecated.")]
	public ProgressBar(styleType style, int value, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool active, ToolBarButton cancelButton, bool lighting)
		: this(style, value, text, textColor, textBackgroundColor, color, drawScale, active: false, cancelButton)
	{
		Lighting = lighting;
		Active = active;
	}

	[Obsolete("This constructor is deprecated.")]
	public ProgressBar(styleType style, int value, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool active, ToolBarButton cancelButton, bool lighting, double thicknessFactor, bool showPercentText)
		: this(style, value, text, textColor, textBackgroundColor, color, drawScale, active: false, cancelButton, lighting)
	{
		ThicknessFactor = thicknessFactor;
		ShowPercentText = showPercentText;
		Active = active;
	}

	[Obsolete("This constructor is deprecated.")]
	public ProgressBar(styleType style, int value, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool active, ToolBarButton cancelButton, bool lighting, double thicknessFactor, double lengthFactor, bool showPercentText)
		: this(style, value, text, textColor, textBackgroundColor, color, drawScale, active: false, cancelButton, lighting)
	{
		ThicknessFactor = thicknessFactor;
		LengthFactor = lengthFactor;
		ShowPercentText = showPercentText;
		Active = active;
	}

	public ProgressBar(styleType style, int value, string defaultText, string text, Color textColor, Color textBackgroundColor, Color color, double drawScale, bool visible, bool lighting, double thicknessFactor, double lengthFactor, bool showPercentText, bool active)
	{
		_0023_003DzshPEPAc_003D(style, value, defaultText, text, RenderContextUtility.ConvertColor(textColor), RenderContextUtility.ConvertColor(textBackgroundColor), RenderContextUtility.ConvertColor(color), drawScale, visible, active, lighting, thicknessFactor, lengthFactor, showPercentText, 40);
	}

	public ProgressBar(ProgressBar another)
	{
		_0023_003DzshPEPAc_003D(another._styleMode, another.Value, another.DefaultText, another.Text, another.TextColor, another.TextBackgroundColor, another.Color, another.DrawScale, another.Visible, another.Active, another.Lighting, another.ThicknessFactor, another.LengthFactor, another.ShowPercentText, another.AnimationInterval);
	}

	private void _0023_003DzshPEPAc_003D(styleType _0023_003DzqheO7Oc_003D, int _0023_003DzsLHxXyo_003D, string _0023_003DzctAqES4_003D, string _0023_003DzgWGS4uo_003D, Color _0023_003Dzlxpb_Og_003D, Color _0023_003DzXn771es_0024NB9x, Color _0023_003Dzhpb8QNg_003D, double _0023_003DzCzsr4CTVr_Ea, bool _0023_003DzbWHNjOg_003D, bool _0023_003DzaAqjzko_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, double _0023_003DzwuU7bst7n7guH9ZuFQ_003D_003D, double _0023_003DzcGi3Cixanvmi, bool _0023_003DzyOP_O0Y3l6bj, int _0023_003DzAPEXg_AnAsyB)
	{
		StyleMode = _0023_003DzqheO7Oc_003D;
		Value = _0023_003DzsLHxXyo_003D;
		DefaultText = _0023_003DzctAqES4_003D;
		Text = _0023_003DzgWGS4uo_003D;
		TextColor = _0023_003Dzlxpb_Og_003D;
		TextBackgroundColor = _0023_003DzXn771es_0024NB9x;
		Color = _0023_003Dzhpb8QNg_003D;
		DrawScale = _0023_003DzCzsr4CTVr_Ea;
		Visible = _0023_003DzbWHNjOg_003D;
		Active = _0023_003DzaAqjzko_003D;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		ThicknessFactor = _0023_003DzwuU7bst7n7guH9ZuFQ_003D_003D;
		LengthFactor = _0023_003DzcGi3Cixanvmi;
		ShowPercentText = _0023_003DzyOP_O0Y3l6bj;
		CancellingText = DefaultCancellingText;
		AnimationInterval = _0023_003DzAPEXg_AnAsyB;
		_0023_003DzFb4SDdNZ64ti();
	}

	public virtual object Clone()
	{
		return new ProgressBar(this);
	}

	internal bool _0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D()
	{
		return _003Ccontinuous_003Ek__BackingField;
	}

	private void _0023_003DzImqYslxNc6Wgq2zhdVPN3Ak_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_003Ccontinuous_003Ek__BackingField = _0023_003DzsLHxXyo_003D;
	}

	private bool _0023_003DzZAredlRIMq3T()
	{
		return !Active;
	}

	private void _0023_003Dzctu1IZJRVpuw()
	{
		Active = true;
	}

	private bool _0023_003DzlotzrR_0024ZJEJGAHUQ_0024Q_003D_003D()
	{
		return AnimationInterval != 40;
	}

	internal void _0023_003DzX57i6b4CdkjE()
	{
		AnimationInterval = 40;
	}

	private bool _0023_003Dzm_0024_0024ZiGESFko5()
	{
		return CancellingText != DefaultCancellingText;
	}

	private void _0023_003DzayxTNb4lDiGa()
	{
		CancellingText = DefaultCancellingText;
	}

	private bool _0023_003DzTR0tEC7SqeoMQ1XLZQ_003D_003D()
	{
		return CancellingText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592692);
	}

	private void _0023_003Dz10C0_hCnNppN()
	{
		CancellingText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592692);
	}

	private bool _0023_003Dz03FyqHnF4Qsp()
	{
		return !RenderContextUtility.AreEqual(Color, _0023_003DzWDIBUYYXYnWA);
	}

	private void _0023_003DzIgBloT8_003D()
	{
		Color = RenderContextUtility.ConvertColor(_0023_003DzWDIBUYYXYnWA);
	}

	private bool _0023_003Dz72Tp0q_0024i6pM85HqzMg_003D_003D()
	{
		return DrawScale != 1.0;
	}

	private void _0023_003Dz_0024wIoK2Gqi7N2()
	{
		DrawScale = 1.0;
	}

	private bool _0023_003Dzr5Bmx_0024tI7N59U9_0024I_0024w_003D_003D()
	{
		return LengthFactor != 0.333;
	}

	private void _0023_003DzVBYAsO_MCCiU()
	{
		LengthFactor = 0.333;
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return !Lighting;
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = true;
	}

	private bool _0023_003DzN8sjRUV1TVE2()
	{
		return Text != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852);
	}

	private void _0023_003DzWxeSJIQ_003D()
	{
		Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852);
	}

	private bool _0023_003DzP57T5Bc556iX()
	{
		return DefaultText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852);
	}

	private void _0023_003DzoBsr__0024TnOZCn()
	{
		DefaultText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592852);
	}

	private bool _0023_003DzotpSg_0024Cq4FMI8VqXCQ_003D_003D()
	{
		return TextBackgroundColor.ToArgb() != _0023_003DzCvGnlcRhcYUN8ggh3YuQByOZpb7jokZIyQ_003D_003D.ToArgb();
	}

	private void _0023_003DzB9_pUr_0024q6fae()
	{
		TextBackgroundColor = RenderContextUtility.ConvertColor(_0023_003DzCvGnlcRhcYUN8ggh3YuQByOZpb7jokZIyQ_003D_003D);
	}

	private bool _0023_003DzR7lfdPM5Ly7X()
	{
		return TextColor.ToArgb() != _0023_003DzoJttSzK_0024LWjTxlGa9JhDQik_003D.ToArgb();
	}

	private void _0023_003DzXYtd_0024aXemTQ_0024()
	{
		TextColor = RenderContextUtility.ConvertColor(_0023_003DzoJttSzK_0024LWjTxlGa9JhDQik_003D);
	}

	private bool _0023_003DzT70_mhuE6obDr0yY_0024Q_003D_003D()
	{
		return ThicknessFactor != 0.1;
	}

	private void _0023_003DziFg8bNGi4HTc()
	{
		ThicknessFactor = 0.1;
	}

	private bool _0023_003Dz2dtLZvc_tmbaKmj_0024ag_003D_003D()
	{
		return !ShowPercentText;
	}

	private void _0023_003DzsBdjQbJx8xys()
	{
		ShowPercentText = true;
	}

	private bool _0023_003DzuooydjCMSwlZPpsh1w_003D_003D()
	{
		return StyleMode != styleType.Speedometer;
	}

	private void _0023_003DzyUvVZflI9bLt()
	{
		StyleMode = styleType.Speedometer;
	}

	private bool _0023_003DzUfUW_0024pZ_3J17()
	{
		return Value != 0;
	}

	private void _0023_003DzoR0j_00249I_003D()
	{
		Value = 0;
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible;
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = false;
	}

	internal override void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003Dz0WkYhbYP0a2Y(_0023_003DzYzWi5Yw_003D);
		}
	}

	internal void _0023_003DzVRx5720_003D()
	{
		_isDirty = true;
	}

	private bool _0023_003Dz0WkYhbYP0a2Y(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzYzWi5Yw_003D == null)
		{
			return false;
		}
		if (_isDirty)
		{
			_0023_003DzWoE5F5BvtWJt();
			switch (StyleMode)
			{
			case styleType.Speedometer:
			{
				_0023_003Dzou9fEZ0JnnwG(SpeedometerBodyParams, _0023_003DzYzWi5Yw_003D, out var _, out var _, out var _0023_003Dz0eUeWUzsrC2, out var _0023_003Dz_ShFbLe5Xnw2, out var _, out var _0023_003DzWiqhAkriCU4_00242, out var _0023_003DzZRq8BPsz1Jpi2);
				_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D speedometerBodyParams = SpeedometerBodyParams;
				if (_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(SpeedometerBodyParams._0023_003DznynynDwur6eZimyjqA_003D_003D()))
				{
					int num3 = 3 * speedometerBodyParams._0023_003DzQDPlya_0024AzIAl();
					int num4 = speedometerBodyParams._0023_003DzQDPlya_0024AzIAl();
					double[] array = (_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(speedometerBodyParams._0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()) ? _0023_003Dz_ShFbLe5Xnw2 : _0023_003Dz0eUeWUzsrC2);
					float num5 = (float)(array[1] - array[3]);
					float num6 = num5 * (float)speedometerBodyParams._0023_003DznynynDwur6eZimyjqA_003D_003D()._0023_003DzbNj9_0024R_0024dgd0J();
					float num7 = num5 * (float)speedometerBodyParams._0023_003DznynynDwur6eZimyjqA_003D_003D()._0023_003Dzq_a2pdxqJNzJ();
					float num8 = num5 * (float)speedometerBodyParams._0023_003DznynynDwur6eZimyjqA_003D_003D()._0023_003DzLfZejrZ8xCH3();
					Point3D point3D = new Point3D(0f - num8 / 2f, array[3] - (double)num6);
					Point3D point3D2 = new Point3D(array[4] + (double)(num8 / 2f), point3D.Y);
					Point3D point3D3 = new Point3D((point3D.X + point3D2.X) / 2.0, (point3D.Y + point3D2.Y) / 2.0 - (double)num7);
					float[] array2 = new float[3 * num3];
					int[] array3 = new int[3 * num4];
					Rotation xform = new Rotation(Utility.DegToRad(_0023_003DzWiqhAkriCU4_00242), Vector3D.AxisMinusZ);
					int num9 = 0;
					for (int i = 0; i < num4; i++)
					{
						point3D.TransformBy(xform);
						point3D3.TransformBy(xform);
						point3D2.TransformBy(xform);
						int num10 = 9 * i;
						array2[num10] = (float)point3D.X;
						array2[num10 + 1] = (float)point3D.Y;
						array2[num10 + 2] = (float)point3D.Z;
						array2[num10 + 3] = (float)point3D3.X;
						array2[num10 + 4] = (float)point3D3.Y;
						array2[num10 + 5] = (float)point3D3.Z;
						array2[num10 + 6] = (float)point3D2.X;
						array2[num10 + 7] = (float)point3D2.Y;
						array2[num10 + 8] = (float)point3D2.Z;
						int num11 = 3 * i;
						array3[num9++] = num11;
						array3[num9++] = num11 + 1;
						array3[num9++] = num11 + 2;
					}
					float[] array4 = new float[array2.Length];
					for (int j = 2; j < array4.Length; j += 3)
					{
						array4[j] = 1f;
					}
					_spikesBody = new FastMesh(array2, array3, array4);
					_spikesBody.TransformBy(_0023_003DzZRq8BPsz1Jpi2);
					_spikesBody.Compile(new CompileParams(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D));
				}
				int y3 = _0023_003DzYzWi5Yw_003D.Size.Height / 4;
				_textPos = new System.Drawing.Point(_0023_003DzYzWi5Yw_003D.Size.Width / 2, y3);
				break;
			}
			case styleType.Circular:
			{
				_0023_003Dzou9fEZ0JnnwG(CircularBodyParams, _0023_003DzYzWi5Yw_003D, out var _, out var _, out var _, out var _, out var _, out var _, out var _);
				int y2 = _0023_003DzYzWi5Yw_003D.Size.Height / 8;
				_textPos = new System.Drawing.Point(_0023_003DzYzWi5Yw_003D.Size.Width / 2, y2);
				break;
			}
			case styleType.Linear:
			{
				int num = (int)((double)_0023_003DzYzWi5Yw_003D.Size.Width * LengthFactor);
				double num2 = (double)(2 * _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D.ButtonStyle.Gap) * DrawScale;
				_0023_003DzPUdpIwPTb5SU(_0023_003DzYzWi5Yw_003D, num, (double)(_0023_003DzYzWi5Yw_003D.Size.Width - num) - num2, num2 * 2.5 + (double)_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D.Font.Size * DrawScale, out var _);
				_textPos = new System.Drawing.Point((int)((double)_0023_003DzYzWi5Yw_003D.Size.Width - num2), (int)num2);
				break;
			}
			case styleType.Docked:
			{
				_0023_003DzPUdpIwPTb5SU(_0023_003DzYzWi5Yw_003D, _0023_003DzYzWi5Yw_003D.Size.Width, 0.0, 0.0, out var _0023_003DzL3Y_7dRVyPx);
				int y = (int)((double)_0023_003DzL3Y_7dRVyPx + (double)_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D.ButtonStyle.Size * DrawScale / 2.0);
				_textPos = new System.Drawing.Point(_0023_003DzYzWi5Yw_003D.Size.Width / 2, y);
				break;
			}
			}
			_isDirty = false;
		}
		return true;
	}

	private void _0023_003DzPUdpIwPTb5SU(Viewport _0023_003DzYzWi5Yw_003D, int _0023_003DzmLin460z8u5N, double _0023_003DzDI8Y9ks_003D, double _0023_003DzJx6crCU_003D, out float _0023_003DzL3Y_7dRVyPx9)
	{
		int num = 202;
		int num2 = num * 3;
		int num3 = 200 * 3;
		_0023_003DzL3Y_7dRVyPx9 = (float)Math.Ceiling(80.0 * ThicknessFactor * DrawScale);
		float num4 = (float)_0023_003DzmLin460z8u5N / 100f;
		float[] array = new float[num2];
		int[] array2 = new int[num3];
		float[] array3 = new float[num2];
		int num5 = 0;
		for (int i = 0; i < num; i++)
		{
			array[num5++] = (float)(i / 2) * num4;
			array[num5++] = (float)(1 - i % 2) * _0023_003DzL3Y_7dRVyPx9;
			array3[num5] = 1f;
			array[num5++] = 0f;
		}
		int num6 = 0;
		for (int j = 0; j < 100; j++)
		{
			int num7 = j * 2;
			int num8 = num7 + 1;
			int num9 = num7 + 2;
			int num10 = num7 + 3;
			array2[num6++] = num7;
			array2[num6++] = num8;
			array2[num6++] = num9;
			array2[num6++] = num8;
			array2[num6++] = num10;
			array2[num6++] = num9;
		}
		Transformation xform = Transformation.CreateTranslation(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D);
		_progressBarBody = new FastMesh(array, array2, array3);
		_progressBarBody.TransformBy(xform);
		_progressBarBody.Compile(new CompileParams(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D));
		_boundsPts.AddRange(_0023_003DzyjwNDZUP2gPT(new Rectangle((int)_0023_003DzDI8Y9ks_003D, (int)_0023_003DzJx6crCU_003D, _0023_003DzmLin460z8u5N, (int)_0023_003DzL3Y_7dRVyPx9)));
	}

	private void _0023_003Dzou9fEZ0JnnwG(_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D, Viewport _0023_003DzYzWi5Yw_003D, out double _0023_003Dzv5Mvn1dZX1fX, out double _0023_003DzRVMoKc5OQtci, out double[] _0023_003Dz0eUeWUzsrC73, out double[] _0023_003Dz_ShFbLe5Xnw0, out double[] _0023_003DzXZlqj_7fWKaY, out double _0023_003DzWiqhAkriCU4_0024, out Transformation _0023_003DzZRq8BPsz1Jpi)
	{
		double num = (double)Math.Min(_0023_003DzYzWi5Yw_003D.Size.Width, _0023_003DzYzWi5Yw_003D.Size.Height) / 4.0;
		double num2 = num * (1.0 - ThicknessFactor);
		if (num - num2 < 4.0)
		{
			num2 = num - 4.0;
		}
		_0023_003Dzv5Mvn1dZX1fX = (double)_0023_003DzYzWi5Yw_003D.Size.Width / 2.0;
		_0023_003DzRVMoKc5OQtci = (double)_0023_003DzYzWi5Yw_003D.Size.Height / 2.0;
		double num3 = Math.Cos(1.5533430342749532);
		double num4 = Math.Sin(1.5533430342749532);
		_0023_003Dz0eUeWUzsrC73 = new double[8]
		{
			0.0,
			num,
			0.0,
			num2,
			num3 * num,
			num4 * num,
			num3 * num2,
			num4 * num2
		};
		double num5 = _0023_003Dz0eUeWUzsrC73[1] - _0023_003Dz0eUeWUzsrC73[3];
		_0023_003Dz_ShFbLe5Xnw0 = new double[8];
		_0023_003DzXZlqj_7fWKaY = new double[8];
		if (_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()))
		{
			double num6 = num5 * _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()._0023_003DzbNj9_0024R_0024dgd0J();
			double num7 = num5 * _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()._0023_003DzLfZejrZ8xCH3();
			_0023_003Dz_ShFbLe5Xnw0[0] = 0.0;
			_0023_003Dz_ShFbLe5Xnw0[1] = _0023_003Dz0eUeWUzsrC73[1] - num5 - num6;
			_0023_003Dz_ShFbLe5Xnw0[2] = 0.0;
			_0023_003Dz_ShFbLe5Xnw0[3] = _0023_003Dz0eUeWUzsrC73[1] - num5 - num6 - num7;
			_0023_003Dz_ShFbLe5Xnw0[4] = num3 * _0023_003Dz_ShFbLe5Xnw0[1];
			_0023_003Dz_ShFbLe5Xnw0[5] = num4 * _0023_003Dz_ShFbLe5Xnw0[1];
			_0023_003Dz_ShFbLe5Xnw0[6] = num3 * _0023_003Dz_ShFbLe5Xnw0[3];
			_0023_003Dz_ShFbLe5Xnw0[7] = num4 * _0023_003Dz_ShFbLe5Xnw0[3];
		}
		if (_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()))
		{
			double num8 = num5 * _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()._0023_003DzbNj9_0024R_0024dgd0J();
			double num9 = num5 * _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()._0023_003DzLfZejrZ8xCH3();
			_0023_003DzXZlqj_7fWKaY[0] = 0.0;
			_0023_003DzXZlqj_7fWKaY[1] = _0023_003Dz0eUeWUzsrC73[1] + num8 + num9;
			_0023_003DzXZlqj_7fWKaY[2] = 0.0;
			_0023_003DzXZlqj_7fWKaY[3] = _0023_003Dz0eUeWUzsrC73[1] + num8;
			_0023_003DzXZlqj_7fWKaY[4] = num3 * _0023_003DzXZlqj_7fWKaY[1];
			_0023_003DzXZlqj_7fWKaY[5] = num4 * _0023_003DzXZlqj_7fWKaY[1];
			_0023_003DzXZlqj_7fWKaY[6] = num3 * _0023_003DzXZlqj_7fWKaY[3];
			_0023_003DzXZlqj_7fWKaY[7] = num4 * _0023_003DzXZlqj_7fWKaY[3];
		}
		Point3D point3D = new Point3D(_0023_003Dz0eUeWUzsrC73[0], _0023_003Dz0eUeWUzsrC73[1]);
		Point3D point3D2 = new Point3D(_0023_003Dz0eUeWUzsrC73[2], _0023_003Dz0eUeWUzsrC73[3]);
		Point3D point3D3 = new Point3D(_0023_003Dz_ShFbLe5Xnw0[0], _0023_003Dz_ShFbLe5Xnw0[1]);
		Point3D point3D4 = new Point3D(_0023_003Dz_ShFbLe5Xnw0[2], _0023_003Dz_ShFbLe5Xnw0[3]);
		Point3D point3D5 = new Point3D(_0023_003DzXZlqj_7fWKaY[0], _0023_003DzXZlqj_7fWKaY[1]);
		Point3D point3D6 = new Point3D(_0023_003DzXZlqj_7fWKaY[2], _0023_003DzXZlqj_7fWKaY[3]);
		Transformation xform = new Rotation(Utility.DegToRad(1.0), Vector3D.AxisMinusZ);
		int num10 = 722;
		int num11 = 3 * num10;
		float[] array = new float[3 * num11];
		int[] array2 = new int[6480];
		Point3D[] array3 = new Point3D[3] { point3D, point3D5, point3D3 };
		Point3D[] array4 = new Point3D[3] { point3D2, point3D6, point3D4 };
		int num12 = 0;
		for (int i = 0; i < 3; i++)
		{
			Point3D point3D7 = array3[i];
			Point3D point3D8 = array4[i];
			for (int j = 0; j < num10 / 2; j++)
			{
				array[num12++] = (float)point3D7.X;
				array[num12++] = (float)point3D7.Y;
				array[num12++] = 0f;
				array[num12++] = (float)point3D8.X;
				array[num12++] = (float)point3D8.Y;
				array[num12++] = 0f;
				point3D7.TransformBy(xform);
				point3D8.TransformBy(xform);
			}
		}
		double num13 = Utility.RadToDeg(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003Dz1_WqrEDPLmKA());
		_0023_003DzWiqhAkriCU4_0024 = num13 / (double)(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzzuahzePi3_0024lp().IsTwoPI ? _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzQDPlya_0024AzIAl() : (_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzQDPlya_0024AzIAl() + 1));
		int num14 = (int)Math.Abs(Math.Floor(_0023_003DzWiqhAkriCU4_0024 / 1.0));
		int num15 = (int)Math.Abs(Math.Floor(num13 / 1.0));
		bool[] array5 = _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003Dz_xrM6DbBLqch1rs9Bg_003D_003D();
		bool[] array6 = _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003Dz0k6VgmiAjsPE5XK0xKyvaKeZPcrk();
		int num16 = 0;
		for (int k = 0; k < 3; k++)
		{
			if ((!_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzLc_p_WnFB0vgX74hVw_003D_003D()) && k == 1) || (!_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzEyzd9yw0h32LSnJDtg_003D_003D()) && k == 2))
			{
				continue;
			}
			for (int l = 0; l < 360; l++)
			{
				if (array5[k] && (array6[k] || (l != 0 && l != num15)) && _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DzGo1Oq1ngcbBi() && l % num14 == 0)
				{
					num16 += 6;
					continue;
				}
				int num17 = 2 * l + k * num10;
				array2[num16++] = num17;
				array2[num16++] = 1 + num17;
				array2[num16++] = 2 + num17;
				array2[num16++] = 1 + num17;
				array2[num16++] = 3 + num17;
				array2[num16++] = 2 + num17;
			}
		}
		float[] array7 = new float[array.Length];
		for (int m = 2; m < array7.Length; m += 3)
		{
			array7[m] = 1f;
		}
		_progressBarBody = new FastMesh(array, array2, array7);
		Transformation transformation = Transformation.CreateTranslation(_0023_003Dzv5Mvn1dZX1fX, _0023_003DzRVMoKc5OQtci);
		Transformation transformation2 = Transformation.CreateRotation(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DztZ0US5XCBzyJIz0AQJKUPi0_003D() - Math.PI / 2.0, Vector3D.AxisMinusZ);
		_0023_003DzZRq8BPsz1Jpi = transformation * transformation2;
		_progressBarBody.TransformBy(_0023_003DzZRq8BPsz1Jpi);
		_progressBarBody.Compile(new CompileParams(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D));
	}

	private void _0023_003DzFb4SDdNZ64ti()
	{
		switch (StyleMode)
		{
		case styleType.Linear:
			_0023_003DqXYe0MRkdybho_00246knxywt3Ag7nBf65a2vG_0024MoRfi6ERVS74LCzefsjlESuRgJn1r2();
			_drawMethod = _0023_003DzePUUAc9xN4E4;
			_drawTextMethod = _0023_003DzxNcBQDv0O4U4;
			break;
		case styleType.Docked:
			_0023_003DqXYe0MRkdybho_00246knxywt3Ag7nBf65a2vG_0024MoRfi6ERVS74LCzefsjlESuRgJn1r2();
			_drawMethod = _0023_003DzePUUAc9xN4E4;
			_drawTextMethod = _0023_003DzxNcBQDv0O4U4;
			break;
		case styleType.Circular:
			_lenCompletedSpan = 2;
			_lenRemainingSpan = 4;
			_drawMethod = _0023_003DzFttiK31GfbWd;
			_drawTextMethod = _0023_003DzF_ClNJV_DVXq;
			break;
		case styleType.Speedometer:
			_lenCompletedSpan = 2;
			_lenRemainingSpan = 4;
			_drawMethod = _0023_003Dzbq3eutCzWnTV4rMHeZnHySA_003D;
			_drawTextMethod = _0023_003DzF_ClNJV_DVXq;
			break;
		}
	}

	protected void GetColors(Viewport viewport, out Color completed, out Color remaining)
	{
		completed = Color.FromArgb((int)Math.Min(255.0, viewport.Background.ColorThemeTransparency * 255.0 * 1.5), RenderContextUtility.ConvertColor(Color));
		remaining = Color.FromArgb((int)(viewport.Background.ColorThemeTransparency * 255.0 / 3.0), viewport.Background.GetContrastColor());
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		RenderContextBase renderContext = drawSceneParams2.RenderContext;
		Workspace workspace = (Workspace)drawSceneParams2.Workspace;
		renderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		_0023_003DzVRx5720_003D();
		Draw(drawSceneParams2);
	}

	protected internal override void Draw(DrawSceneParams myParams)
	{
		Workspace workspace = (Workspace)myParams.Workspace;
		Viewport viewport = (Viewport)myParams.Viewport;
		if (workspace._0023_003DzipBYly6zFKAp() != viewport)
		{
			return;
		}
		_boundsPts = new List<Point2D>();
		if (_0023_003Dz0WkYhbYP0a2Y(viewport))
		{
			myParams.RenderContext.PushBlendState();
			myParams.RenderContext.PushShader();
			myParams.RenderContext.SetState(blendStateType.Blend);
			myParams.RenderContext.SetShader(shaderType.NoLights);
			GetColors(viewport, out var completed, out var remaining);
			Span<(uint, uint)> span = stackalloc(uint, uint)[_lenCompletedSpan];
			Span<(uint, uint)> span2 = stackalloc(uint, uint)[_lenRemainingSpan];
			bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D = false;
			_drawMethod(span, span2, out _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);
			myParams.RenderContext.PushRasterizerState();
			myParams.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			myParams.RenderContext.SetColorWireframe(completed);
			Span<(uint, uint)> span3 = span;
			for (int i = 0; i < span3.Length; i++)
			{
				(uint, uint) tuple = span3[i];
				myParams.RenderContext.Draw(_progressBarBody.drawData, primitiveType.Undefined, tuple.Item1, tuple.Item2);
			}
			myParams.RenderContext.SetColorWireframe(remaining);
			Span<(uint, uint)> span4 = span2;
			for (int i = 0; i < span4.Length; i++)
			{
				(uint, uint) tuple2 = span4[i];
				myParams.RenderContext.Draw(_progressBarBody.drawData, primitiveType.Undefined, tuple2.Item1, tuple2.Item2);
			}
			if (_0023_003DzkhcjylHq1FFu_vQz3A_003D_003D)
			{
				myParams.RenderContext.Draw(_spikesBody.drawData);
			}
			myParams.RenderContext.PopRasterizerState();
			float _0023_003Dzy93CwkuWDHzq = (float)((double)workspace.Font.Size * DrawScale);
			Rectangle _0023_003Dzols9v2M_003D = _drawTextMethod(workspace, viewport, _0023_003Dzy93CwkuWDHzq, remaining);
			myParams.RenderContext.PopShader();
			myParams.RenderContext.PopBlendState();
			_boundsPts.AddRange(_0023_003DzyjwNDZUP2gPT(_0023_003Dzols9v2M_003D));
			_0023_003DzPHOrvtU_uKZw0eZiJQ_003D_003D(workspace);
			_dirtyBounds = false;
		}
	}

	private void _0023_003DzePUUAc9xN4E4(Span<(uint, uint)> _0023_003DzjgFw0oQ_003D, Span<(uint, uint)> _0023_003Dz8jTMOh8_003D, out bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D)
	{
		if (_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D())
		{
			uint num = (uint)Math.Max(0, Value + 6 - 24);
			uint num2 = 24u;
			uint num3 = (6 - num + 1) * num2;
			uint num4 = num * num2;
			uint num5 = (uint)Value * num2;
			_0023_003DzjgFw0oQ_003D[0] = (num5, num3);
			_0023_003DzjgFw0oQ_003D[1] = (0u, num4);
			_0023_003Dz8jTMOh8_003D[0] = (num4, num5 - num4);
			_0023_003Dz8jTMOh8_003D[1] = (num5 + num3, 600u);
		}
		else
		{
			uint num6 = (uint)(6 * Value);
			_0023_003DzjgFw0oQ_003D[0] = (0u, num6);
			_0023_003Dz8jTMOh8_003D[0] = (num6, 600 - num6);
		}
		_0023_003DzkhcjylHq1FFu_vQz3A_003D_003D = false;
	}

	private void _0023_003DzNg7oelvMDOmn(_0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D, double _0023_003Dzxl_gTsYF4D4J, double _0023_003DzsYXNg2bXF6Ik, double _0023_003DzuczAdhBNNLeQ, Span<(uint, uint)> _0023_003DzjgFw0oQ_003D, Span<(uint, uint)> _0023_003Dz8jTMOh8_003D, out bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D)
	{
		double radians = _0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003Dz1_WqrEDPLmKA();
		uint num = 720u;
		uint num2 = (uint)Math.Ceiling(Utility.RadToDeg(radians) / 1.0);
		uint num3 = (uint)Math.Ceiling((double)num2 * _0023_003Dzxl_gTsYF4D4J / 100.0);
		uint num4 = (uint)Math.Ceiling((double)num2 * _0023_003DzsYXNg2bXF6Ik / 100.0);
		uint num5 = (uint)Math.Ceiling((double)num2 * _0023_003DzuczAdhBNNLeQ / 100.0);
		uint num6 = num2 * 6;
		uint num7 = num3 * 6;
		uint num8 = num4 * 6;
		uint num9 = num5 * 6;
		_0023_003DzjgFw0oQ_003D[0] = (0u, num7);
		_0023_003DzjgFw0oQ_003D[1] = (num8, num9 - num8);
		_0023_003Dz8jTMOh8_003D[0] = (num7, num8 - num7);
		_0023_003Dz8jTMOh8_003D[1] = (num9, num6 - num9);
		_0023_003Dz8jTMOh8_003D[2] = (num * 3, num6);
		_0023_003Dz8jTMOh8_003D[3] = (2 * num * 3, num6);
		_0023_003DzkhcjylHq1FFu_vQz3A_003D_003D = _0023_003DzxJOYTmSc2X7LDFdc0Q_003D_003D._0023_003DzNVkcE6w_003D(_0023_003DzxSC_H9NYYZbEz2ba8g_003D_003D._0023_003DznynynDwur6eZimyjqA_003D_003D());
	}

	private void _0023_003Dzbq3eutCzWnTV4rMHeZnHySA_003D(Span<(uint, uint)> _0023_003DzjgFw0oQ_003D, Span<(uint, uint)> _0023_003Dz8jTMOh8_003D, out bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D)
	{
		double num = Utility.DegToRad(330.0);
		double t = Utility.DegToRad(210.0);
		if (_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D())
		{
			double num2 = Utility.DegToRad(15.0) * (double)Value;
			Interval interval = new Interval(num, t);
			if (interval.t1 < interval.t0)
			{
				interval.t1 += Math.PI * 2.0;
			}
			if (interval.Length > Math.PI * 2.0)
			{
				interval.t1 = interval.t0 + Math.PI * 2.0;
			}
			double num3 = 25.0 * (Math.PI * 2.0) / 100.0;
			double t2 = interval.t0;
			double num4 = interval.t0 + Math.PI * 2.0;
			double num5 = (t2 + num2) % num4;
			int num6 = 0;
			int val = 0;
			double num7 = (num5 + num3) % num4;
			if (!(num5 > interval.t1) || !(num7 > interval.t1))
			{
				num6 = (int)Math.Ceiling((num5 - num) * 100.0 / interval.Length);
				if (num7 < num)
				{
					num7 += num;
				}
				val = (int)Math.Ceiling((num7 - num) * 100.0 / interval.Length);
			}
			val = Math.Min(100, val);
			num6 = ((num6 <= val) ? num6 : 0);
			_0023_003DzNg7oelvMDOmn(SpeedometerBodyParams, 0.0, num6, val, _0023_003DzjgFw0oQ_003D, _0023_003Dz8jTMOh8_003D, out _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);
		}
		else
		{
			_0023_003DzNg7oelvMDOmn(SpeedometerBodyParams, 0.0, 0.0, Value, _0023_003DzjgFw0oQ_003D, _0023_003Dz8jTMOh8_003D, out _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);
		}
	}

	private void _0023_003DzFttiK31GfbWd(Span<(uint, uint)> _0023_003DzjgFw0oQ_003D, Span<(uint, uint)> _0023_003Dz8jTMOh8_003D, out bool _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D)
	{
		if (_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D())
		{
			int num = 4;
			int num2 = 0;
			int num3 = Value * num;
			int num4 = num3 + 6 * num;
			if (num4 > 100)
			{
				num2 = num4 - 100;
				num4 = 100;
			}
			_0023_003DzNg7oelvMDOmn(CircularBodyParams, num2, num3, num4, _0023_003DzjgFw0oQ_003D, _0023_003Dz8jTMOh8_003D, out _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);
		}
		else
		{
			_0023_003DzNg7oelvMDOmn(CircularBodyParams, 0.0, 0.0, Value, _0023_003DzjgFw0oQ_003D, _0023_003Dz8jTMOh8_003D, out _0023_003DzkhcjylHq1FFu_vQz3A_003D_003D);
		}
	}

	private Rectangle _0023_003DzqZQ9GuWC9cuo(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003Dzy93CwkuWDHzq, ContentAlignment _0023_003DzKqxja7NdHdvX)
	{
		Font font = new Font(_0023_003DzU0f5_qE_003D.Font.FontFamily, _0023_003Dzy93CwkuWDHzq);
		Rectangle _0023_003DzHk91AdQ7qeHY;
		try
		{
			if (!Lighting)
			{
				_0023_003DzU0f5_qE_003D._0023_003Dz7jAuuGUOjwBrKpkzbPtlK4s_003D(_textPos.X, _textPos.Y, cancelling ? CancellingText : Text, font, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor(), _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), 1f, _0023_003DzKqxja7NdHdvX, out _0023_003DzHk91AdQ7qeHY);
			}
			else
			{
				_0023_003DzU0f5_qE_003D._0023_003Dz4cMrjAkIhb6J(_textPos.X, _textPos.Y, cancelling ? CancellingText : Text, font, RenderContextUtility.ConvertColor(TextColor), RenderContextUtility.ConvertColor(TextBackgroundColor), _0023_003DzKqxja7NdHdvX, RotateFlipType.Rotate180FlipX, out _0023_003DzHk91AdQ7qeHY);
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
		return _0023_003DzHk91AdQ7qeHY;
	}

	private Rectangle _0023_003DzxNcBQDv0O4U4(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003Dzy93CwkuWDHzq, Color _0023_003DztZyx6rs_003D)
	{
		return _0023_003DzqZQ9GuWC9cuo(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, _0023_003Dzy93CwkuWDHzq, ContentAlignment.BottomRight);
	}

	private Rectangle _0023_003DzNOYC_0024gm9qsjN(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003Dzy93CwkuWDHzq, Color _0023_003DztZyx6rs_003D)
	{
		return _0023_003DzqZQ9GuWC9cuo(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, _0023_003Dzy93CwkuWDHzq, ContentAlignment.BottomCenter);
	}

	private Rectangle _0023_003DzF_ClNJV_DVXq(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003Dzy93CwkuWDHzq, Color _0023_003DztZyx6rs_003D)
	{
		RenderContextBase renderContext = _0023_003DzU0f5_qE_003D.RenderContext;
		double num = (double)Math.Min(_0023_003DzYzWi5Yw_003D.Size.Width, _0023_003DzYzWi5Yw_003D.Size.Height) / (_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D() ? 4.0 : 6.0);
		double num2 = (double)_0023_003DzYzWi5Yw_003D.Size.Width / 2.0;
		double num3 = (double)_0023_003DzYzWi5Yw_003D.Size.Height / 2.0;
		Rectangle _0023_003DzHk91AdQ7qeHY = new Rectangle((int)num2 - 1, (int)num3 - 1, 2, 2);
		Color _0023_003DzgUg07Uk_003D = (Lighting ? RenderContextUtility.ConvertColor(TextBackgroundColor) : Color.Empty);
		if (ShowPercentText && !_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D())
		{
			Font font = new Font(_0023_003DzU0f5_qE_003D.Font.FontFamily, (float)num, FontStyle.Regular, GraphicsUnit.Pixel);
			try
			{
				Bitmap bitmap = Workspace._0023_003DzRFGA2zTmmjXj(Value.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593038)), font, _0023_003DztZyx6rs_003D, _0023_003DzgUg07Uk_003D, _0023_003DzU0f5_qE_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
				TextureBase textureBase = renderContext.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, enlargeIfSizeNotSupported: true);
				Size size = ((textureBase.BitmapSize.Width < textureBase.Size.Width) ? textureBase.BitmapSize : textureBase.Size);
				float x = (float)num2 - (float)size.Width / 2f;
				float y = (float)num3 - (float)size.Height / 2f;
				renderContext.PushShader();
				renderContext.PushBlendState();
				renderContext.SetShader(shaderType.Texture2DNoLights);
				renderContext.SetState(blendStateType.Blend);
				float num4 = (float)textureBase.BitmapSize.Width / (float)textureBase.Size.Width;
				float num5 = (float)textureBase.BitmapSize.Height / (float)textureBase.Size.Height;
				renderContext.DrawQuadWithTextures(textureBase, new float[8] { 0f, 0f, num4, 0f, num4, num5, 0f, num5 }, byte.MaxValue, new RectangleF(x, y, size.Width, size.Height), 0f, buffered: false);
				renderContext.PopBlendState();
				renderContext.PopShader();
				textureBase.Dispose();
				bitmap.Dispose();
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
		float num6 = (float)Math.Min(_0023_003DzYzWi5Yw_003D.Size.Width, _0023_003DzYzWi5Yw_003D.Size.Height) / 32f;
		if (num6 < _0023_003Dzy93CwkuWDHzq)
		{
			num6 = _0023_003Dzy93CwkuWDHzq;
		}
		Font font2 = new Font(_0023_003DzU0f5_qE_003D.Font.FontFamily, num6, FontStyle.Regular, GraphicsUnit.Pixel);
		try
		{
			Color _0023_003Dzlxpb_Og_003D = Color.FromArgb(_0023_003DztZyx6rs_003D.A * 2, _0023_003DztZyx6rs_003D);
			_0023_003DzU0f5_qE_003D._0023_003Dz4cMrjAkIhb6J(_textPos.X, _textPos.Y, cancelling ? CancellingText : Text, font2, _0023_003Dzlxpb_Og_003D, _0023_003DzgUg07Uk_003D, ContentAlignment.MiddleCenter, RotateFlipType.Rotate180FlipX, out _0023_003DzHk91AdQ7qeHY);
			return _0023_003DzHk91AdQ7qeHY;
		}
		finally
		{
			((IDisposable)font2).Dispose();
		}
	}

	internal void _0023_003Dzfhv6eFBtERoy()
	{
		if (_animationTimer == null)
		{
			_0023_003DzImqYslxNc6Wgq2zhdVPN3Ak_003D(_0023_003DzsLHxXyo_003D: true);
			_0023_003DzFb4SDdNZ64ti();
			Value = 0;
			_animationTimer = new System.Threading.Timer(_0023_003DzxUDu3gj3zthu, null, 0, AnimationInterval);
		}
	}

	internal void _0023_003DzwdY8uuMuAeqB()
	{
		lock (_lockObj)
		{
			_0023_003DzImqYslxNc6Wgq2zhdVPN3Ak_003D(_0023_003DzsLHxXyo_003D: false);
			_0023_003DzFb4SDdNZ64ti();
			if (_animationTimer != null)
			{
				_animationTimer.Dispose(_done);
				_animationTimer = null;
				_done.WaitOne();
			}
		}
	}

	internal void _0023_003Dze5O5R4s_003D(Workspace _0023_003DzU0f5_qE_003D)
	{
		cursorManager._0023_003DzSbnsq6aGahYh(_0023_003DzU0f5_qE_003D, _0023_003DzSV3KedQ_003D: false);
		Visible = previousVisibility;
		cancelling = false;
		_0023_003DzImqYslxNc6Wgq2zhdVPN3Ak_003D(_0023_003DzsLHxXyo_003D: false);
		_0023_003DzwdY8uuMuAeqB();
		Value = previousValue;
		Text = DefaultText;
		CancellingText = DefaultCancellingText;
	}

	private void _0023_003DzxUDu3gj3zthu(object _0023_003Dz45rq_i0_003D)
	{
		Workspace parentWorkspace = ParentWorkspace;
		try
		{
			if (parentWorkspace.InvokeRequired)
			{
				parentWorkspace.BeginInvoke(new MethodInvoker(_0023_003DzVl398d8_003D));
			}
			else
			{
				_0023_003DzVl398d8_003D();
			}
		}
		catch (ObjectDisposedException)
		{
		}
	}

	private void _0023_003DzVl398d8_003D()
	{
		if (Value < 23)
		{
			Value++;
		}
		else
		{
			Value = 0;
		}
		ParentWorkspace?._0023_003Dz78oB1KCkXEP9();
	}

	internal void _0023_003Dz_WlOvqR1pka_()
	{
		_dirtyBounds = true;
	}

	private Point2D[] _0023_003DzyjwNDZUP2gPT(Rectangle _0023_003Dzols9v2M_003D)
	{
		return new Point2D[2]
		{
			new Point2D(_0023_003Dzols9v2M_003D.Left, _0023_003Dzols9v2M_003D.Bottom),
			new Point2D(_0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Top)
		};
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		if (viewport != viewport._0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp())
		{
			return Rectangle.Empty;
		}
		return new Rectangle(viewport.Location, viewport.Size);
	}

	private void _0023_003DzDtqIzro_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		Draw(new DrawSceneParams
		{
			Viewport = _0023_003DzYzWi5Yw_003D,
			RenderContext = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D
		});
	}

	internal override bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		return false;
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DzWoE5F5BvtWJt();
		_0023_003DzVRx5720_003D();
		_0023_003DzwdY8uuMuAeqB();
		ParentWorkspace = null;
	}

	private void _0023_003DzWoE5F5BvtWJt()
	{
		_progressBarBody?.Dispose();
		_spikesBody?.Dispose();
		_progressBarBody = null;
		_spikesBody = null;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (!_0023_003DzuooydjCMSwlZPpsh1w_003D_003D() && !_0023_003DzUfUW_0024pZ_3J17() && !_0023_003DzN8sjRUV1TVE2() && !_0023_003DzR7lfdPM5Ly7X() && !_0023_003DzotpSg_0024Cq4FMI8VqXCQ_003D_003D() && !_0023_003Dz03FyqHnF4Qsp() && !_0023_003Dz72Tp0q_0024i6pM85HqzMg_003D_003D() && !_0023_003Dz3SV_00249FPfwz1J() && !_0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D() && !_0023_003DzT70_mhuE6obDr0yY_0024Q_003D_003D() && !_0023_003Dzr5Bmx_0024tI7N59U9_0024I_0024w_003D_003D() && !_0023_003Dz2dtLZvc_tmbaKmj_0024ag_003D_003D())
		{
			return _0023_003DzZAredlRIMq3T();
		}
		return true;
	}

	public override void Update(IUserInterfaceElement another)
	{
		ProgressBar progressBar = (ProgressBar)another;
		_0023_003DzshPEPAc_003D(progressBar.StyleMode, progressBar.Value, progressBar.DefaultText, progressBar.Text, progressBar.TextColor, progressBar.TextBackgroundColor, progressBar.Color, progressBar.DrawScale, progressBar.Visible, progressBar.Active, progressBar.Lighting, progressBar.ThicknessFactor, progressBar.LengthFactor, progressBar.ShowPercentText, progressBar.AnimationInterval);
	}

	private void _0023_003DqXYe0MRkdybho_00246knxywt3Ag7nBf65a2vG_0024MoRfi6ERVS74LCzefsjlESuRgJn1r2()
	{
		if (_0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D())
		{
			_lenCompletedSpan = 2;
			_lenRemainingSpan = 2;
		}
		else
		{
			_lenCompletedSpan = 1;
			_lenRemainingSpan = 1;
		}
	}
}
