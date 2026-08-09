using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ToolBarConverter))]
public class ToolBar : BarBase, IDisposable, ICloneable
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ToolBarButton, bool> _0023_003DzJuvbzOkcJYLORKzQuQ_003D_003D;

		public static Func<ToolBarButton, bool> _0023_003Dzv6_0024lMQOwMDQzIzNU3g_003D_003D;

		internal bool _0023_003DzmVM_pSTETdcSi_0024gdLADj5Cgj2DW8b4z5XQ_003D_003D(ToolBarButton _0023_003Dz8GBMuoM_003D)
		{
			if (_0023_003Dz8GBMuoM_003D is DefaultToolBarButton defaultToolBarButton)
			{
				return defaultToolBarButton._0023_003DzN1MCycjcfHnNXgRZrliT_Ns_003D();
			}
			return false;
		}

		internal bool _0023_003DzuWoYM_0024ucinn_0024r4SX0_0024dmVHE_003D(ToolBarButton _0023_003Dz8GBMuoM_003D)
		{
			if (_0023_003Dz8GBMuoM_003D is DefaultToolBarButton defaultToolBarButton)
			{
				return defaultToolBarButton._0023_003DznD4RJAAzruL6();
			}
			return false;
		}
	}

	public enum positionType
	{
		HorizontalTopLeft,
		HorizontalTopCenter,
		HorizontalTopRight,
		VerticalTopRight,
		VerticalMiddleRight,
		VerticalBottomRight,
		HorizontalBottomRight,
		HorizontalBottomCenter,
		HorizontalBottomLeft,
		VerticalBottomLeft,
		VerticalMiddleLeft,
		VerticalTopLeft
	}

	public enum styleType
	{
		Legacy,
		Win10
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBarButtonList _0023_003Dzhm487aI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8fksAyc1vaOoUj_0024mjQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzORGsSEPF10q9amKqpg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzad5Z2SomPQQNoHdABQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzndHxit81vRw2Xyc55js8ghU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzmjTCbarcyVz_0024QXkcsEsemEs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzKkBj28hYdKHtuWW708avY3E_003D = _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DznZb9Hv4kLFb_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DzVhvZQg9SrGtM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CompositeCurve _0023_003Dz7aZKRnXMM_0024aU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003Dzj50S4o0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace.CursorContainer _0023_003Dz1S1Y_jdD_NCL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private positionType _0023_003DzABDpBS0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBarButton[] _0023_003Dz9QdwAbMe_bt_0024ycdnbc88J88_003D;

	[Description("ToolBar visibility status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D = value;
		}
	}

	[Description("ToolBar position.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public positionType Position
	{
		get
		{
			return _0023_003DzABDpBS0_003D;
		}
		set
		{
			_0023_003DzABDpBS0_003D = value;
			_0023_003Dzj50S4o0_003D = Rectangle.Empty;
		}
	}

	[Description("The list of toolBar buttons.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Editor("devDept.Eyeshot.Designer.Converters.ToolBarButtonsCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	public ToolBarButtonList Buttons
	{
		get
		{
			return _0023_003Dzhm487aI_003D;
		}
		set
		{
			_0023_003Dzhm487aI_003D = value;
			_0023_003DzshPEPAc_003D(Position, Visible, _0023_003Dzhm487aI_003D, Margin, Padding, BackgroundColor, BackgroundCornerRadius, BackgroundBorderColor, BackgroundBorderWidth, _0023_003DzXbUGNUdn2gMv: false);
		}
	}

	[Description("Distance between ToolBar and Viewport Edge")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Margin
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz8fksAyc1vaOoUj_0024mjQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz8fksAyc1vaOoUj_0024mjQ_003D_003D = value;
		}
	}

	[Description("Distance between ToolBar background and buttons")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Padding
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzORGsSEPF10q9amKqpg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzORGsSEPF10q9amKqpg_003D_003D = value;
		}
	}

	[Description("Background color of the toolbar")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzad5Z2SomPQQNoHdABQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzad5Z2SomPQQNoHdABQ_003D_003D = value;
		}
	}

	[Description("Background corner radius")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double BackgroundCornerRadius
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzndHxit81vRw2Xyc55js8ghU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzndHxit81vRw2Xyc55js8ghU_003D = value;
		}
	}

	[Description("Background border color")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackgroundBorderColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmjTCbarcyVz_0024QXkcsEsemEs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzmjTCbarcyVz_0024QXkcsEsemEs_003D = value;
		}
	}

	[Description("Background border width")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double BackgroundBorderWidth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzKkBj28hYdKHtuWW708avY3E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzKkBj28hYdKHtuWW708avY3E_003D = value;
		}
	}

	public ToolBar()
		: this(_0023_003DzPkO7IBwkBx9t(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DznYiWbQfUOKb6(), _0023_003DzmlCEdVNjNClt(), _0023_003DzcIFLVkl29SCe(), _0023_003DzwBusyTBDWRBW(), _0023_003DzWZ1wZtYaexFLGASUjw_003D_003D(), _0023_003DzaSRpQs9VpokBMAypTg_003D_003D(), _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D())
	{
	}

	[Obsolete]
	public ToolBar(positionType position, bool visible, ToolBarButton[] buttons)
	{
		_0023_003DzshPEPAc_003D(position, visible, new ToolBarButtonList(this, buttons), _0023_003DzmlCEdVNjNClt(), _0023_003DzcIFLVkl29SCe(), _0023_003DzwBusyTBDWRBW(), _0023_003DzWZ1wZtYaexFLGASUjw_003D_003D(), _0023_003DzaSRpQs9VpokBMAypTg_003D_003D(), _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D(), _0023_003DzXbUGNUdn2gMv: false);
	}

	public ToolBar(positionType position, bool visible, ToolBarButton[] buttons, int margin, int padding, Color backgroundColor, double backgroundCornerRadius, Color backgroundBorderColor, double backgroundBorderWidth)
	{
		_0023_003DzshPEPAc_003D(position, visible, new ToolBarButtonList(this, buttons), margin, padding, backgroundColor, backgroundCornerRadius, backgroundBorderColor, backgroundBorderWidth, _0023_003DzXbUGNUdn2gMv: false);
	}

	public ToolBar(ToolBar another)
	{
		_0023_003DzshPEPAc_003D(another.Position, another.Visible, another.Buttons, another.Margin, another.Padding, RenderContextUtility.ConvertColor(another.BackgroundColor), another.BackgroundCornerRadius, RenderContextUtility.ConvertColor(another.BackgroundBorderColor), another.BackgroundBorderWidth, _0023_003DzXbUGNUdn2gMv: true);
	}

	internal static ToolBar[] _0023_003Dz7RqBmFdBIbpl()
	{
		return new ToolBar[1]
		{
			new ToolBar()
		};
	}

	public static ToolBar GetDefaultToolBar()
	{
		ToolBar toolBar = new ToolBar();
		toolBar.Buttons = new ToolBarButtonList(toolBar, new ToolBarButton[7]
		{
			_0023_003DzFgbh_HWPcJne(),
			_0023_003Dzyhpgjvis8EuX_0024ojbtWcku9GHzjgG(),
			_0023_003DzeGIXhgrati7e(),
			_0023_003Dzz2Z6Ps2Iz3Hf(),
			_0023_003Dzwnx4pVr7dYod(),
			_0023_003DzGRHQntizPzkp(),
			_0023_003DzXRi8cpoFZN11jyMG3g_003D_003D()
		});
		return toolBar;
	}

	internal bool _0023_003Dz6IiAnIkiGeJ4c1d3fnMBUNw_003D()
	{
		ToolBarButtonList buttons = Buttons;
		if (buttons == null)
		{
			return false;
		}
		return buttons.ToArray()?.Count((ToolBarButton _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D is DefaultToolBarButton defaultToolBarButton && defaultToolBarButton._0023_003DzN1MCycjcfHnNXgRZrliT_Ns_003D()) > 0;
	}

	internal bool _0023_003DzMtJdeBwDLtvi()
	{
		ToolBarButtonList buttons = Buttons;
		if (buttons == null)
		{
			return false;
		}
		return buttons.ToArray()?.Count((ToolBarButton _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D is DefaultToolBarButton defaultToolBarButton && defaultToolBarButton._0023_003DznD4RJAAzruL6()) > 0;
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private bool _0023_003DzbUxkg_0024pX8GiH()
	{
		return Position != _0023_003DzPkO7IBwkBx9t();
	}

	private void _0023_003Dz4T4pGdvYHA7k()
	{
		Position = _0023_003DzPkO7IBwkBx9t();
	}

	internal bool _0023_003DzOce1OewfzxkY()
	{
		if (_0023_003Dz39dJVf2fnvi4() == 8 && Buttons[0].IsDefaultButton() && Buttons[1].IsDefaultButton() && Buttons[2].IsDefaultButton() && Buttons[3].IsDefaultButton() && Buttons[4].IsDefaultButton() && Buttons[5].IsDefaultButton() && Buttons[6].IsDefaultButton())
		{
			return !Buttons[7].IsDefaultButton();
		}
		return true;
	}

	internal void _0023_003DzjqbeLD0f8nPN()
	{
		Buttons = new ToolBarButtonList(this, _0023_003DznYiWbQfUOKb6());
	}

	private static ToolBarButton[] _0023_003DznYiWbQfUOKb6()
	{
		return new ToolBarButton[7]
		{
			_0023_003DzFgbh_HWPcJne(),
			_0023_003Dzyhpgjvis8EuX_0024ojbtWcku9GHzjgG(),
			_0023_003DzeGIXhgrati7e(),
			_0023_003Dzz2Z6Ps2Iz3Hf(),
			_0023_003Dzwnx4pVr7dYod(),
			_0023_003DzGRHQntizPzkp(),
			_0023_003DzXRi8cpoFZN11jyMG3g_003D_003D()
		};
	}

	internal static ToolBarButton _0023_003Dzyhpgjvis8EuX_0024ojbtWcku9GHzjgG()
	{
		return new MagnifyingGlassToolBarButton();
	}

	internal static ToolBarButton _0023_003DzeGIXhgrati7e()
	{
		return new ZoomWindowToolBarButton();
	}

	internal static ToolBarButton _0023_003Dzz2Z6Ps2Iz3Hf()
	{
		return new ZoomToolBarButton();
	}

	internal static ToolBarButton _0023_003Dzwnx4pVr7dYod()
	{
		return new PanToolBarButton();
	}

	internal static ToolBarButton _0023_003DzGRHQntizPzkp()
	{
		return new RotateToolBarButton();
	}

	internal static ToolBarButton _0023_003DzXRi8cpoFZN11jyMG3g_003D_003D()
	{
		return new ZoomFitToolBarButton();
	}

	internal static ToolBarButton _0023_003DzFgbh_HWPcJne()
	{
		return new HomeToolBarButton();
	}

	internal bool _0023_003DzfMsni7Nw6IN4()
	{
		return Margin != _0023_003DzmlCEdVNjNClt();
	}

	internal void _0023_003DzN9IxsmAcV4Db()
	{
		Margin = _0023_003DzmlCEdVNjNClt();
	}

	internal bool _0023_003DzOL288Vtt1Ayd()
	{
		return Padding != _0023_003DzcIFLVkl29SCe();
	}

	internal void _0023_003Dzr6_ypl8lmVvt()
	{
		Padding = _0023_003DzcIFLVkl29SCe();
	}

	internal bool _0023_003DzeO7bcoEYNoO5()
	{
		return BackgroundColor != _0023_003DzwBusyTBDWRBW();
	}

	internal void _0023_003DzPc_Y3Ko9gyHq()
	{
		BackgroundColor = _0023_003DzwBusyTBDWRBW();
	}

	internal bool _0023_003DzBFUGweoaapuijfra46_XwIs_003D()
	{
		return Math.Abs(BackgroundCornerRadius - _0023_003DzWZ1wZtYaexFLGASUjw_003D_003D()) > 1E-12;
	}

	internal void _0023_003Dzv0wRhNIbCsGClUmyzQ_003D_003D()
	{
		BackgroundCornerRadius = _0023_003DzWZ1wZtYaexFLGASUjw_003D_003D();
	}

	internal bool _0023_003Dza5pMqo_0024T7ebAJlbbkA_003D_003D()
	{
		return BackgroundBorderColor != _0023_003DzaSRpQs9VpokBMAypTg_003D_003D();
	}

	internal void _0023_003Dz7k_00245e1ifqNGB()
	{
		BackgroundBorderColor = _0023_003DzaSRpQs9VpokBMAypTg_003D_003D();
	}

	internal bool _0023_003DzXkptt6EnbaCHBlkXIg_003D_003D()
	{
		return Math.Abs(BackgroundBorderWidth - _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D()) > 1E-12;
	}

	internal void _0023_003Dzif_6y_0024yNl5HqtsM7TA_003D_003D()
	{
		BackgroundBorderWidth = _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D();
	}

	internal static positionType _0023_003DzPkO7IBwkBx9t()
	{
		return positionType.HorizontalTopCenter;
	}

	internal static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	internal static int _0023_003DzmlCEdVNjNClt()
	{
		return 5;
	}

	internal static int _0023_003DzcIFLVkl29SCe()
	{
		return 0;
	}

	internal static Color _0023_003DzwBusyTBDWRBW()
	{
		return Color.FromArgb(0, 0, 0, 0);
	}

	internal static double _0023_003DzWZ1wZtYaexFLGASUjw_003D_003D()
	{
		return 0.0;
	}

	internal static Color _0023_003DzaSRpQs9VpokBMAypTg_003D_003D()
	{
		return Color.FromArgb(0, 0, 0, 0);
	}

	internal static double _0023_003Dz02jkMpjyxRP7fuaj3w_003D_003D()
	{
		return 0.0;
	}

	private void _0023_003DzshPEPAc_003D(positionType _0023_003DzhEjPeMs_003D, bool _0023_003DzbWHNjOg_003D, ToolBarButtonList _0023_003DzKN4rwIk_003D, int _0023_003DzPG6BDWw_003D, int _0023_003DzaKWaM48_003D, Color _0023_003DzNLGcq5k_003D, double _0023_003DzlLgbe6mDUjCD, Color _0023_003DzJOJ83WrxNUzn, double _0023_003DzSUTgbl3g_0024Chp, bool _0023_003DzXbUGNUdn2gMv)
	{
		Position = _0023_003DzhEjPeMs_003D;
		Visible = _0023_003DzbWHNjOg_003D;
		Margin = _0023_003DzPG6BDWw_003D;
		Padding = _0023_003DzaKWaM48_003D;
		BackgroundColor = RenderContextUtility.ConvertColor(_0023_003DzNLGcq5k_003D);
		BackgroundCornerRadius = _0023_003DzlLgbe6mDUjCD;
		BackgroundBorderColor = RenderContextUtility.ConvertColor(_0023_003DzJOJ83WrxNUzn);
		BackgroundBorderWidth = _0023_003DzSUTgbl3g_0024Chp;
		if (_0023_003DzKN4rwIk_003D == null)
		{
			return;
		}
		ToolBarButton[] array = (_0023_003DzXbUGNUdn2gMv ? new ToolBarButton[_0023_003DzKN4rwIk_003D.Count] : _0023_003DzKN4rwIk_003D.ToArray());
		for (int i = 0; i < _0023_003DzKN4rwIk_003D.Count; i++)
		{
			ToolBarButton toolBarButton = _0023_003DzKN4rwIk_003D[i];
			if (_0023_003DzXbUGNUdn2gMv)
			{
				array[i] = (ToolBarButton)toolBarButton.Clone();
			}
			else
			{
				array[i] = toolBarButton;
			}
			array[i]._0023_003Dz4iBK5_0024N3N5g7 = this;
		}
		_0023_003Dzhm487aI_003D = new ToolBarButtonList(this, array);
	}

	internal override void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D == null)
		{
			return;
		}
		ButtonSettings buttonStyle = _0023_003DzU0f5_qE_003D.ButtonStyle;
		_0023_003DzFUz_0024MNfUBEtX(buttonStyle.CornerRadius, buttonStyle.Size, buttonStyle.Size, out var _0023_003DzlCoElfk_003D, out var _0023_003DzZadiaCI_003D);
		int dim = buttonStyle.Size;
		TextureBase.MakePowerOfTwoBigger(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, ref dim);
		foreach (ToolBarButton button in Buttons)
		{
			button._0023_003DzPY_0024ulDyKjEOA();
			if (button._0023_003Dzt8M7jZkZ__VNpsLmCQ_003D_003D() == null)
			{
				button.CreateTextures(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003DzU0f5_qE_003D, _0023_003DzlCoElfk_003D, _0023_003DzZadiaCI_003D, dim, dim, buttonStyle.Size, buttonStyle.Size, RenderContextUtility.ConvertColor(buttonStyle.HighlightColor));
			}
		}
		_0023_003DzlCoElfk_003D.Dispose();
		_0023_003DzZadiaCI_003D?.Dispose();
		_0023_003DzuPfidIbEEwFO(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, out var _0023_003DzmfOeHIQ_003D, out var _0023_003DzdvPAr2jJd9Me, out var _0023_003DzzMr_oog7U3hL);
		_0023_003DzXu3JDeA_003D(_0023_003DzdvPAr2jJd9Me, _0023_003DzzMr_oog7U3hL);
		_0023_003Dzvs0hvAzXL2F_yOS_0024gQ_003D_003D(_0023_003DzU0f5_qE_003D);
		_0023_003Dz191ozMVp28cu(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D);
		_0023_003DzZNHB2grUVV5M(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzmfOeHIQ_003D, _0023_003DzdvPAr2jJd9Me, _0023_003DzzMr_oog7U3hL);
	}

	public override bool Contains(System.Drawing.Point mousePos)
	{
		if (!Visible)
		{
			return false;
		}
		foreach (ToolBarButton button in Buttons)
		{
			if (button.Contains(mousePos))
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzFUz_0024MNfUBEtX(int _0023_003DzvjTHbaTV_0024Ffg, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, out GraphicsPath _0023_003DzlCoElfk_003D, out GraphicsPath _0023_003DzZadiaCI_003D)
	{
		Rectangle rectangle = new Rectangle(0, 0, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D);
		_0023_003DzlCoElfk_003D = _0023_003DzcEByg_3wjQog(rectangle, _0023_003DzvjTHbaTV_0024Ffg, _0023_003DzvjTHbaTV_0024Ffg, _0023_003DzvjTHbaTV_0024Ffg, _0023_003DzvjTHbaTV_0024Ffg);
		_0023_003DzZadiaCI_003D = null;
	}

	protected internal override void Draw(DrawSceneParams myParams)
	{
		Workspace _0023_003DzU0f5_qE_003D = (Workspace)myParams.Workspace;
		_0023_003DzPHOrvtU_uKZw0eZiJQ_003D_003D(_0023_003DzU0f5_qE_003D);
		if (_0023_003DzzL5IpUnrTwJugl0U9w_003D_003D())
		{
			myParams.RenderContext.SetShader(shaderType.Texture2DNoLightsModulate);
			myParams.RenderContext.SetColorWireframe(Color.FromArgb(127, Color.White));
			myParams.RenderContext.UpdateConstantBufferPerFrame();
		}
		else
		{
			myParams.RenderContext.SetShader(shaderType.Texture2DNoLights);
		}
		if (Visible && Buttons != null && _0023_003Dz39dJVf2fnvi4() != 0)
		{
			Viewport _0023_003DzYzWi5Yw_003D = (Viewport)myParams.Viewport;
			if (_0023_003DzuPfidIbEEwFO(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, out var _0023_003DzmfOeHIQ_003D, out var _0023_003DzdvPAr2jJd9Me, out var _0023_003DzzMr_oog7U3hL))
			{
				_0023_003DzXu3JDeA_003D(_0023_003DzdvPAr2jJd9Me, _0023_003DzzMr_oog7U3hL);
				_0023_003Dz191ozMVp28cu(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D);
				_0023_003DzZNHB2grUVV5M(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzmfOeHIQ_003D, _0023_003DzdvPAr2jJd9Me, _0023_003DzzMr_oog7U3hL);
			}
		}
	}

	private void _0023_003DzXu3JDeA_003D(int _0023_003DzdvPAr2jJd9Me, int _0023_003DzzMr_oog7U3hL)
	{
		if (_0023_003DzdvPAr2jJd9Me >= 0)
		{
			Rectangle rectangle = Buttons[_0023_003DzdvPAr2jJd9Me].Rectangle;
			Rectangle rectangle2 = Buttons[_0023_003DzzMr_oog7U3hL].Rectangle;
			_0023_003Dzj50S4o0_003D = new Rectangle(Math.Min(rectangle.X, rectangle2.X), Math.Min(rectangle.Y, rectangle2.Y), Math.Abs(rectangle.X - rectangle2.X) + rectangle2.Width, Math.Abs(rectangle.Y - rectangle2.Y) + rectangle2.Height);
		}
	}

	internal int _0023_003Dz39dJVf2fnvi4()
	{
		return Buttons.Count;
	}

	private int _0023_003Dz5NxDG0CF14UfJBJwnA_003D_003D()
	{
		return (int)((BackgroundCornerRadius / 2.0 > (double)Padding) ? BackgroundCornerRadius : 0.0);
	}

	private System.Drawing.Point _0023_003DzBV0j3auMLVC4()
	{
		int num = _0023_003Dz5NxDG0CF14UfJBJwnA_003D_003D();
		int x = _0023_003Dzj50S4o0_003D.X - Padding - num;
		int y = _0023_003Dzj50S4o0_003D.Y - Padding;
		return new System.Drawing.Point(x, y);
	}

	private Size _0023_003DzQHzBIEUl5bN2()
	{
		int num = _0023_003Dz5NxDG0CF14UfJBJwnA_003D_003D();
		int width = _0023_003Dzj50S4o0_003D.Width + Padding * 2 + num * 2;
		int height = _0023_003Dzj50S4o0_003D.Height + Padding * 2;
		return new Size(width, height);
	}

	private void _0023_003Dzvs0hvAzXL2F_yOS_0024gQ_003D_003D(Workspace _0023_003DzU0f5_qE_003D)
	{
		Size size = _0023_003DzQHzBIEUl5bN2();
		double width = size.Width;
		double height = size.Height;
		devDept.Eyeshot.Entities.Region region = ((BackgroundCornerRadius > 0.0) ? devDept.Eyeshot.Entities.Region.CreateRoundedRectangle(0.0, 0.0, width, height, BackgroundCornerRadius) : devDept.Eyeshot.Entities.Region.CreateRectangle(0.0, 0.0, width, height));
		region.Regen(new RegenParams(0.0, Math.PI / 8.0));
		_0023_003DznZb9Hv4kLFb_0024?.Dispose();
		_0023_003DznZb9Hv4kLFb_0024 = region.ConvertToMesh();
		_0023_003DznZb9Hv4kLFb_0024.Regen(0.0);
		_0023_003DznZb9Hv4kLFb_0024.Compile(new CompileParams(_0023_003DzU0f5_qE_003D));
		if (BackgroundBorderWidth > 0.0 && BackgroundBorderWidth <= 1.0)
		{
			_0023_003Dz7aZKRnXMM_0024aU?.Dispose();
			_0023_003Dz7aZKRnXMM_0024aU = (CompositeCurve)region.Offset(1.0)[0];
			_0023_003Dz7aZKRnXMM_0024aU.Regen(0.0);
			_0023_003Dz7aZKRnXMM_0024aU.Compile(new CompileParams(_0023_003DzU0f5_qE_003D));
		}
		else if (BackgroundBorderWidth > 1.0)
		{
			devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(new ICurve[2]
			{
				region.ContourList[0],
				region.Offset(BackgroundBorderWidth, BackgroundCornerRadius == 0.0)[0]
			}, Plane.XY, sortAndOrient: false);
			region2.Regen(new RegenParams(0.0, Math.PI / 8.0));
			_0023_003DzVhvZQg9SrGtM?.Dispose();
			_0023_003DzVhvZQg9SrGtM = region2.ConvertToMesh();
			_0023_003DzVhvZQg9SrGtM.Regen(0.0);
			_0023_003DzVhvZQg9SrGtM.Compile(new CompileParams(_0023_003DzU0f5_qE_003D));
		}
	}

	private bool _0023_003DzuPfidIbEEwFO(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, out bool _0023_003DzmfOeHIQ_003D, out int _0023_003DzdvPAr2jJd9Me, out int _0023_003DzzMr_oog7U3hL)
	{
		ParentViewport = _0023_003DzYzWi5Yw_003D;
		_0023_003DzdvPAr2jJd9Me = -1;
		_0023_003DzzMr_oog7U3hL = -1;
		double _0023_003DzMFTjHfa4_giP = -1.0;
		double _0023_003DzTXlfp6pm_0024l4F = -1.0;
		_0023_003DzmfOeHIQ_003D = false;
		if (!Visible || Buttons == null || _0023_003Dz39dJVf2fnvi4() == 0)
		{
			return false;
		}
		int size = _0023_003DzU0f5_qE_003D.ButtonStyle.Size;
		int gap = _0023_003DzU0f5_qE_003D.ButtonStyle.Gap;
		int margin = Margin;
		int padding = Padding;
		double backgroundBorderWidth = BackgroundBorderWidth;
		bool visible = _0023_003DzU0f5_qE_003D._0023_003DzOLP90s_0024AN26E.Visible;
		int num = size;
		int num2 = size;
		int _0023_003DzwZVr6eS2_DVr = num / 4;
		int _0023_003Dze1y2jXorieKH = num2 / 4;
		int num3 = _0023_003Dz39dJVf2fnvi4();
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		bool flag = _0023_003DzU0f5_qE_003D.ProgressBar._0023_003DzYtNw0JbiTXj2e41uH_0024L5RAU_003D();
		for (int i = 0; i < num3; i++)
		{
			ToolBarButton toolBarButton = Buttons[i];
			if (toolBarButton.Visible && (!flag || toolBarButton._0023_003DzVCRPD_0024GbQNCA != flag))
			{
				if (_0023_003DzdvPAr2jJd9Me == -1)
				{
					_0023_003DzdvPAr2jJd9Me = i;
				}
				_0023_003DzzMr_oog7U3hL = i;
				if (toolBarButton.StyleMode == ToolBarButton.styleType.Separator)
				{
					num5++;
				}
				else
				{
					num6++;
				}
			}
			else
			{
				num4++;
			}
		}
		switch (Position)
		{
		case positionType.HorizontalTopLeft:
			_0023_003DzMFTjHfa4_giP = _0023_003Dz0Emauw6I7KyV(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003DzoAA0L6A9Hhfo(margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.HorizontalTopCenter:
			_0023_003DzMFTjHfa4_giP = _0023_003DzUlgoLp3ys6Pq(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num, gap, num5, _0023_003DzwZVr6eS2_DVr);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003DzoAA0L6A9Hhfo(margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.HorizontalTopRight:
			_0023_003DzMFTjHfa4_giP = _0023_003Dzv1EWUDsWmxRd(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num, gap, margin, padding, num5, _0023_003DzwZVr6eS2_DVr, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003DzoAA0L6A9Hhfo(margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.HorizontalBottomLeft:
			_0023_003DzMFTjHfa4_giP = _0023_003Dz0Emauw6I7KyV(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dz7fJqwwfKj54J(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num2, margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.HorizontalBottomCenter:
			_0023_003DzMFTjHfa4_giP = _0023_003DzUlgoLp3ys6Pq(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num, gap, num5, _0023_003DzwZVr6eS2_DVr);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dz7fJqwwfKj54J(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num2, margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.HorizontalBottomRight:
			_0023_003DzMFTjHfa4_giP = _0023_003Dzv1EWUDsWmxRd(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num, gap, margin, padding, num5, _0023_003DzwZVr6eS2_DVr, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dz7fJqwwfKj54J(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num2, margin, padding, backgroundBorderWidth, visible);
			break;
		case positionType.VerticalTopLeft:
			_0023_003DzMFTjHfa4_giP = _0023_003DzBiMN7mcJpkZu(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dztb5KSlgP9kbH(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		case positionType.VerticalMiddleLeft:
			_0023_003DzMFTjHfa4_giP = _0023_003DzBiMN7mcJpkZu(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003DzW_0024DQfnOUeNaK(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num2, gap, num5, _0023_003Dze1y2jXorieKH);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		case positionType.VerticalBottomLeft:
			_0023_003DzMFTjHfa4_giP = _0023_003DzBiMN7mcJpkZu(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dz6njvfkqvmI25(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num2, gap, margin, padding, num5, _0023_003Dze1y2jXorieKH, backgroundBorderWidth, visible);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		case positionType.VerticalTopRight:
			_0023_003DzMFTjHfa4_giP = _0023_003DzdrPoaLOxjoEG(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num, margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dztb5KSlgP9kbH(margin, padding, backgroundBorderWidth, visible);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		case positionType.VerticalMiddleRight:
			_0023_003DzMFTjHfa4_giP = _0023_003DzdrPoaLOxjoEG(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num, margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003DzW_0024DQfnOUeNaK(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num2, gap, num5, _0023_003Dze1y2jXorieKH);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		case positionType.VerticalBottomRight:
			_0023_003DzMFTjHfa4_giP = _0023_003DzdrPoaLOxjoEG(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num, margin, padding, backgroundBorderWidth, visible);
			_0023_003DzTXlfp6pm_0024l4F = _0023_003Dz6njvfkqvmI25(_0023_003DzYzWi5Yw_003D._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D(), num6, num2, gap, margin, padding, num5, _0023_003Dze1y2jXorieKH, backgroundBorderWidth, visible);
			_0023_003DzmfOeHIQ_003D = true;
			break;
		}
		if (_0023_003DzdvPAr2jJd9Me < 0)
		{
			return false;
		}
		_0023_003DzYzWi5Yw_003D._0023_003Dz99_0024gH6eUUxNX(ref _0023_003DzMFTjHfa4_giP, ref _0023_003DzTXlfp6pm_0024l4F);
		Rectangle rectangle;
		Buttons[_0023_003DzdvPAr2jJd9Me]._0023_003DzLr8pehtIvvdB(rectangle = _0023_003Dz7kYoELxGy5KD(_0023_003DzMFTjHfa4_giP, _0023_003DzTXlfp6pm_0024l4F, _0023_003DzmfOeHIQ_003D, Buttons[_0023_003DzdvPAr2jJd9Me].StyleMode == ToolBarButton.styleType.Separator, num, num2, _0023_003DzwZVr6eS2_DVr, _0023_003Dze1y2jXorieKH));
		Rectangle rectangle2 = rectangle;
		ToolBarButton toolBarButton2 = Buttons[_0023_003DzdvPAr2jJd9Me];
		for (int j = _0023_003DzdvPAr2jJd9Me + 1; j <= _0023_003DzzMr_oog7U3hL; j++)
		{
			toolBarButton2 = Buttons[j];
			if (toolBarButton2.Visible && (!flag || toolBarButton2._0023_003DzVCRPD_0024GbQNCA != flag))
			{
				if (_0023_003DzmfOeHIQ_003D)
				{
					_0023_003DzTXlfp6pm_0024l4F += (double)(gap + rectangle2.Height);
				}
				else
				{
					_0023_003DzMFTjHfa4_giP += (double)(gap + rectangle2.Width);
				}
				toolBarButton2._0023_003DzLr8pehtIvvdB(rectangle = _0023_003Dz7kYoELxGy5KD(_0023_003DzMFTjHfa4_giP, _0023_003DzTXlfp6pm_0024l4F, _0023_003DzmfOeHIQ_003D, toolBarButton2.StyleMode == ToolBarButton.styleType.Separator, num, num2, _0023_003DzwZVr6eS2_DVr, _0023_003Dze1y2jXorieKH));
				rectangle2 = rectangle;
			}
		}
		return true;
	}

	private void _0023_003DzZNHB2grUVV5M(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003DzmfOeHIQ_003D, int _0023_003DzdvPAr2jJd9Me, int _0023_003DzzMr_oog7U3hL)
	{
		if (_0023_003DzdvPAr2jJd9Me < 0)
		{
			return;
		}
		ToolBarButton toolBarButton = Buttons[_0023_003DzdvPAr2jJd9Me];
		_0023_003DzU0f5_qE_003D.RenderContext.PushBlendState();
		_0023_003DzU0f5_qE_003D.RenderContext.SetState(blendStateType.Blend_SrcAlphaOne_DstAlphaOneMinusSrcAlpha);
		_0023_003DzU0f5_qE_003D.RenderContext.PushRasterizerState();
		_0023_003DzU0f5_qE_003D.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		if (_0023_003DzBpQ2yKTJjutl(_0023_003DzU0f5_qE_003D, toolBarButton))
		{
			toolBarButton._0023_003Dz99kJFjE_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003DzVeSTNSfs_UUA: true, _0023_003DzmfOeHIQ_003D, _0023_003DzYzWi5Yw_003D.Size.Height);
		}
		else
		{
			toolBarButton._0023_003Dz99kJFjE_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003DzzL5IpUnrTwJugl0U9w_003D_003D(), _0023_003DzmfOeHIQ_003D, _0023_003DzYzWi5Yw_003D.Size.Height);
		}
		for (int i = _0023_003DzdvPAr2jJd9Me + 1; i <= _0023_003DzzMr_oog7U3hL; i++)
		{
			toolBarButton = Buttons[i];
			if (_0023_003DzBpQ2yKTJjutl(_0023_003DzU0f5_qE_003D, toolBarButton))
			{
				toolBarButton._0023_003Dz99kJFjE_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003DzVeSTNSfs_UUA: true, _0023_003DzmfOeHIQ_003D, _0023_003DzYzWi5Yw_003D.Size.Height);
			}
			else
			{
				toolBarButton._0023_003Dz99kJFjE_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003DzzL5IpUnrTwJugl0U9w_003D_003D(), _0023_003DzmfOeHIQ_003D, _0023_003DzYzWi5Yw_003D.Size.Height);
			}
		}
		_0023_003DzU0f5_qE_003D.RenderContext.PopRasterizerState();
		_0023_003DzU0f5_qE_003D.RenderContext.PopBlendState();
	}

	private void _0023_003Dz191ozMVp28cu(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DznZb9Hv4kLFb_0024 != null)
		{
			System.Drawing.Point pt = _0023_003DzBV0j3auMLVC4();
			System.Drawing.Point point = _0023_003DzYzWi5Yw_003D.ScreenToViewport(pt);
			int x = point.X;
			int num = ParentViewport.Size.Height - point.Y - _0023_003Dzj50S4o0_003D.Height - 2 * Padding;
			_0023_003DzU0f5_qE_003D.RenderContext.PushMatrices();
			_0023_003DzU0f5_qE_003D.RenderContext.MultMatrixModelView(new Translation(x, num));
			_0023_003DzU0f5_qE_003D.RenderContext.PushRasterizerState();
			_0023_003DzU0f5_qE_003D.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			bool lighting = _0023_003DzU0f5_qE_003D.RenderContext.SetLighting(enable: false);
			_0023_003DzU0f5_qE_003D.RenderContext.PushShader();
			_0023_003DzU0f5_qE_003D.RenderContext.PushBlendState();
			_0023_003DzU0f5_qE_003D.RenderContext.PushDepthStencilState();
			_0023_003DzU0f5_qE_003D.RenderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
			_0023_003DzU0f5_qE_003D.RenderContext.SetState(blendStateType.Blend_SrcAlphaOne_DstAlphaOneMinusSrcAlpha);
			_0023_003DzU0f5_qE_003D.RenderContext.SetShader(shaderType.NoLights);
			RenderParams data = new RenderParams(_0023_003DzYzWi5Yw_003D, _0023_003DzU0f5_qE_003D.Blocks);
			_0023_003DzU0f5_qE_003D.RenderContext.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor));
			((IEntityInternal)_0023_003DznZb9Hv4kLFb_0024).Render(data);
			Color color = RenderContextUtility.ConvertColor(BackgroundBorderColor);
			if (_0023_003Dz7aZKRnXMM_0024aU?.Vertices != null && BackgroundBorderWidth > 0.0 && BackgroundBorderWidth <= 1.0)
			{
				_0023_003DzU0f5_qE_003D.RenderContext.SetColorWireframe(color);
				_0023_003DzU0f5_qE_003D.RenderContext.DrawLineLoop(_0023_003Dz7aZKRnXMM_0024aU.Vertices);
			}
			else if (_0023_003DzVhvZQg9SrGtM != null && BackgroundBorderWidth > 1.0)
			{
				_0023_003DzU0f5_qE_003D.RenderContext.SetColorWireframe(color);
				((IEntityInternal)_0023_003DzVhvZQg9SrGtM).Render(data);
			}
			_0023_003DzU0f5_qE_003D.RenderContext.PopDepthStencilState();
			_0023_003DzU0f5_qE_003D.RenderContext.PopBlendState();
			_0023_003DzU0f5_qE_003D.RenderContext.PopShader();
			_0023_003DzU0f5_qE_003D.RenderContext.SetLighting(lighting);
			_0023_003DzU0f5_qE_003D.RenderContext.PopRasterizerState();
			_0023_003DzU0f5_qE_003D.RenderContext.PopMatrices();
		}
	}

	private double _0023_003Dztb5KSlgP9kbH(int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz2W1lxMQXth6Y + _0023_003Dz6Zb3Zuda77Jd + (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num++;
		}
		return num;
	}

	private static int _0023_003DzBiMN7mcJpkZu(int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz2W1lxMQXth6Y + _0023_003Dz6Zb3Zuda77Jd + (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num++;
		}
		return num;
	}

	private static int _0023_003Dz0Emauw6I7KyV(int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz2W1lxMQXth6Y + _0023_003Dz6Zb3Zuda77Jd + (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num++;
		}
		return num;
	}

	private static int _0023_003DzoAA0L6A9Hhfo(int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz2W1lxMQXth6Y + _0023_003Dz6Zb3Zuda77Jd + (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num++;
		}
		return num;
	}

	private static int _0023_003DzdrPoaLOxjoEG(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003DzC9FqcOL3zXY_0024, int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz0_0024_0024VbFw_003D.Width - _0023_003DzC9FqcOL3zXY_0024 - _0023_003Dz2W1lxMQXth6Y - _0023_003Dz6Zb3Zuda77Jd - (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num--;
		}
		return num;
	}

	private static int _0023_003Dz7fJqwwfKj54J(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003DzCwU7FoKVOiJY, int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz0_0024_0024VbFw_003D.Height - _0023_003DzCwU7FoKVOiJY - _0023_003Dz2W1lxMQXth6Y - _0023_003Dz6Zb3Zuda77Jd - (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num--;
		}
		return num;
	}

	private double _0023_003Dz6njvfkqvmI25(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003Dz0wFHZTQ_003D, int _0023_003DzCwU7FoKVOiJY, int _0023_003DzJ_2aCv1BG0mZ, int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, int _0023_003DzBWQI2mM_003D, int _0023_003Dze1y2jXorieKH, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz0_0024_0024VbFw_003D.Height - _0023_003Dz0wFHZTQ_003D * (_0023_003DzCwU7FoKVOiJY + _0023_003DzJ_2aCv1BG0mZ) - _0023_003DzBWQI2mM_003D * (_0023_003Dze1y2jXorieKH + _0023_003DzJ_2aCv1BG0mZ) + _0023_003DzJ_2aCv1BG0mZ - _0023_003Dz6Zb3Zuda77Jd - _0023_003Dz2W1lxMQXth6Y - (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num--;
		}
		return num;
	}

	private static int _0023_003Dzv1EWUDsWmxRd(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003Dz0wFHZTQ_003D, int _0023_003DzC9FqcOL3zXY_0024, int _0023_003DzJ_2aCv1BG0mZ, int _0023_003Dz2W1lxMQXth6Y, int _0023_003Dz6Zb3Zuda77Jd, int _0023_003DzBWQI2mM_003D, int _0023_003DzwZVr6eS2_DVr, double _0023_003DzPA7NrzpKE1pt, bool _0023_003Dz9kLnDK4zWf8i)
	{
		int num = _0023_003Dz0_0024_0024VbFw_003D.Width - _0023_003Dz0wFHZTQ_003D * (_0023_003DzC9FqcOL3zXY_0024 + _0023_003DzJ_2aCv1BG0mZ) - _0023_003DzBWQI2mM_003D * (_0023_003DzwZVr6eS2_DVr + _0023_003DzJ_2aCv1BG0mZ) + _0023_003DzJ_2aCv1BG0mZ - _0023_003Dz2W1lxMQXth6Y - _0023_003Dz6Zb3Zuda77Jd - (int)_0023_003DzPA7NrzpKE1pt;
		if (_0023_003Dz9kLnDK4zWf8i)
		{
			num--;
		}
		return num;
	}

	private static int _0023_003DzUlgoLp3ys6Pq(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003Dz0wFHZTQ_003D, int _0023_003DzC9FqcOL3zXY_0024, int _0023_003DzJ_2aCv1BG0mZ, int _0023_003DzBWQI2mM_003D, int _0023_003DzwZVr6eS2_DVr)
	{
		return (_0023_003Dz0_0024_0024VbFw_003D.Width - _0023_003Dz0wFHZTQ_003D * (_0023_003DzC9FqcOL3zXY_0024 + _0023_003DzJ_2aCv1BG0mZ) - _0023_003DzBWQI2mM_003D * (_0023_003DzwZVr6eS2_DVr + _0023_003DzJ_2aCv1BG0mZ)) / 2;
	}

	private static int _0023_003DzW_0024DQfnOUeNaK(Size _0023_003Dz0_0024_0024VbFw_003D, int _0023_003Dz0wFHZTQ_003D, int _0023_003DzCwU7FoKVOiJY, int _0023_003DzJ_2aCv1BG0mZ, int _0023_003DzBWQI2mM_003D, int _0023_003Dze1y2jXorieKH)
	{
		return (_0023_003Dz0_0024_0024VbFw_003D.Height - _0023_003Dz0wFHZTQ_003D * (_0023_003DzCwU7FoKVOiJY + _0023_003DzJ_2aCv1BG0mZ) - _0023_003DzBWQI2mM_003D * (_0023_003Dze1y2jXorieKH + _0023_003DzJ_2aCv1BG0mZ)) / 2;
	}

	private Rectangle _0023_003Dz7kYoELxGy5KD(double _0023_003DzGuW5l4E_003D, double _0023_003DzVDBzBJQ_003D, bool _0023_003DzHeocugrv_00240D4, bool _0023_003Dzo_mqgYM_003D, int _0023_003DzC9FqcOL3zXY_0024, int _0023_003DzCwU7FoKVOiJY, int _0023_003DzwZVr6eS2_DVr, int _0023_003Dze1y2jXorieKH)
	{
		int width = _0023_003DzC9FqcOL3zXY_0024;
		int height = _0023_003DzCwU7FoKVOiJY;
		if (_0023_003Dzo_mqgYM_003D)
		{
			if (_0023_003DzHeocugrv_00240D4)
			{
				height = _0023_003Dze1y2jXorieKH;
			}
			else
			{
				width = _0023_003DzwZVr6eS2_DVr;
			}
		}
		return new Rectangle((int)_0023_003DzGuW5l4E_003D, (int)_0023_003DzVDBzBJQ_003D, width, height);
	}

	internal override bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003DzzL5IpUnrTwJugl0U9w_003D_003D())
		{
			return false;
		}
		cursorManager._0023_003DzKGntWXtyylZx(_0023_003DzU0f5_qE_003D, _0023_003Dzc3vkuqr_ddi7(_0023_003Dz1SmHC4c_003D.X, _0023_003Dz1SmHC4c_003D.Y), out var _0023_003DzcTbmALo_003D);
		ToolBarButton toolBarButton = _0023_003Dz2SDLYxQiC_K7(_0023_003DzU0f5_qE_003D, _0023_003Dz1SmHC4c_003D, _0023_003DzhSOVEOvXyqe7: false);
		ToolBarButton._0023_003DzJrgugJM_003D[] array = null;
		if (!_0023_003DzcTbmALo_003D && cursorManager._0023_003DzOTCykyo_003D)
		{
			array = new ToolBarButton._0023_003DzJrgugJM_003D[_0023_003Dz39dJVf2fnvi4()];
			for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
			{
				array[i] = Buttons[i]._0023_003Dz0hLnOJ4_003D();
			}
		}
		if (_0023_003Dz1SmHC4c_003D.Button != MouseButtons.Left)
		{
			for (int j = 0; j < _0023_003Dz39dJVf2fnvi4(); j++)
			{
				if (Buttons[j] != toolBarButton && Buttons[j]._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)1)
				{
					Buttons[j]._0023_003Dz7M7UaJs_003D(_0023_003DzYvunAdQ_003D: false);
				}
			}
			Hover(_0023_003DzU0f5_qE_003D, toolBarButton);
		}
		if (!_0023_003DzcTbmALo_003D && cursorManager._0023_003DzOTCykyo_003D)
		{
			for (int k = 0; k < _0023_003Dz39dJVf2fnvi4(); k++)
			{
				if (array[k] != Buttons[k]._0023_003Dz0hLnOJ4_003D())
				{
					_0023_003DzcTbmALo_003D = true;
					break;
				}
			}
		}
		cursorManager._0023_003DzSbnsq6aGahYh(_0023_003DzU0f5_qE_003D, toolBarButton != null);
		if (_0023_003DzcTbmALo_003D)
		{
			BarBase.Repaint(_0023_003DzU0f5_qE_003D);
		}
		return toolBarButton != null;
	}

	internal void _0023_003DzfLrPor1L6i4C(Workspace _0023_003DzU0f5_qE_003D)
	{
		_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Push(_0023_003DzU0f5_qE_003D.ActionMode);
		_0023_003Dz1S1Y_jdD_NCL = _0023_003DzU0f5_qE_003D._0023_003DzzT36TNE_003D();
	}

	internal void _0023_003Dz9ynrbmYOHj_0024Y(Workspace _0023_003DzU0f5_qE_003D)
	{
		if (_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Count > 0)
		{
			_0023_003DzU0f5_qE_003D.ActionMode = _0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Pop();
		}
		if (_0023_003DzU0f5_qE_003D.ActionMode != actionType.None)
		{
			_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(_0023_003DzU0f5_qE_003D._0023_003DzSeMqxa6Bcvxs());
		}
		else
		{
			_0023_003DzU0f5_qE_003D._0023_003DzV0Su6Jg_003D(_0023_003Dz1S1Y_jdD_NCL);
		}
	}

	private bool _0023_003DzL3f91x2KYE3n()
	{
		foreach (ToolBarButton button in Buttons)
		{
			if (button.IsDefaultButton() && button._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				return true;
			}
		}
		return false;
	}

	internal bool _0023_003Dzc3vkuqr_ddi7(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D)
	{
		if (!Visible)
		{
			return false;
		}
		return _0023_003Dzj50S4o0_003D.Contains((int)_0023_003Dz8GBMuoM_003D, (int)_0023_003DzJU0R6e0_003D);
	}

	private ToolBarButton _0023_003Dz2SDLYxQiC_K7(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D, bool _0023_003DzhSOVEOvXyqe7)
	{
		for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
		{
			if (Buttons[i].Contains(_0023_003Dz1SmHC4c_003D.Location))
			{
				if (_0023_003DzhSOVEOvXyqe7 && _0023_003DzBpQ2yKTJjutl(_0023_003DzU0f5_qE_003D, Buttons[i]))
				{
					return null;
				}
				return Buttons[i];
			}
		}
		return null;
	}

	private bool _0023_003DzBpQ2yKTJjutl(Workspace _0023_003DzU0f5_qE_003D, ToolBarButton _0023_003Dz5PxKZP0_003D)
	{
		Viewport viewport = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp();
		if ((!(_0023_003Dz5PxKZP0_003D is RotateToolBarButton) || viewport.Rotate.Enabled) && (!(_0023_003Dz5PxKZP0_003D is ZoomToolBarButton) || viewport.Zoom.Enabled))
		{
			if (_0023_003Dz5PxKZP0_003D is PanToolBarButton)
			{
				return !viewport.Pan.Enabled;
			}
			return false;
		}
		return true;
	}

	internal bool _0023_003Dzu8_0024tRXp_0024yCuW(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz1SmHC4c_003D.Button != MouseButtons.Left || _0023_003DzU0f5_qE_003D._0023_003DzhNfdoTKp7Vp4r6IhAdfMNj6_00248vBW())
		{
			return false;
		}
		OnMouseDown(_0023_003DzU0f5_qE_003D, _0023_003Dz1SmHC4c_003D);
		if (_0023_003DzzL5IpUnrTwJugl0U9w_003D_003D())
		{
			return false;
		}
		ToolBarButton toolBarButton = _0023_003Dz2SDLYxQiC_K7(_0023_003DzU0f5_qE_003D, _0023_003Dz1SmHC4c_003D, _0023_003DzhSOVEOvXyqe7: true);
		if (toolBarButton != null)
		{
			if (toolBarButton.IsDefaultButton())
			{
				bool flag = false;
				ToolBar[] toolBars = ParentViewport.ToolBars;
				foreach (ToolBar toolBar in toolBars)
				{
					for (int j = 0; j < toolBar._0023_003Dz39dJVf2fnvi4(); j++)
					{
						ToolBarButton toolBarButton2 = toolBar.Buttons[j];
						if (toolBarButton2._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2 && toolBarButton2.IsDefaultButton())
						{
							if ((object)toolBarButton != toolBarButton2)
							{
								toolBarButton2._0023_003DzQLjVxM8_003D();
							}
							flag = true;
						}
					}
				}
				if (!flag)
				{
					_0023_003DzfLrPor1L6i4C(_0023_003DzU0f5_qE_003D);
				}
				_0023_003DzU0f5_qE_003D._0023_003DzPWir8SCUhlRqvNwZxA_003D_003D = _0023_003DzU0f5_qE_003D.ActionMode;
				_0023_003DzU0f5_qE_003D._0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = true;
				_0023_003DzU0f5_qE_003D.ActionMode = actionType.None;
				_0023_003DzU0f5_qE_003D._0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = false;
			}
			toolBarButton._0023_003Dzu8_0024tRXp_0024yCuW();
			BarBase.Repaint(_0023_003DzU0f5_qE_003D);
			return true;
		}
		return false;
	}

	internal bool _0023_003DzA_0024ihSwbmVYvs(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D, ToolBarButton.ClickEventHandler _0023_003Dz1ZsJamHwLuTk)
	{
		if (_0023_003Dz1SmHC4c_003D.Button != MouseButtons.Left)
		{
			return false;
		}
		if (_0023_003DzzL5IpUnrTwJugl0U9w_003D_003D())
		{
			return false;
		}
		ToolBarButton toolBarButton = _0023_003Dz2SDLYxQiC_K7(_0023_003DzU0f5_qE_003D, _0023_003Dz1SmHC4c_003D, _0023_003DzhSOVEOvXyqe7: true);
		for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
		{
			if (!Buttons[i]._0023_003DzA_0024ihSwbmVYvs(toolBarButton, _0023_003Dz1ZsJamHwLuTk))
			{
				continue;
			}
			if (toolBarButton == null)
			{
				if (_0023_003DzU0f5_qE_003D.ActionMode == actionType.None)
				{
					_0023_003Dz9ynrbmYOHj_0024Y(_0023_003DzU0f5_qE_003D);
				}
				else
				{
					_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(_0023_003DzU0f5_qE_003D._0023_003DzSeMqxa6Bcvxs());
				}
			}
			return true;
		}
		return false;
	}

	internal static GraphicsPath _0023_003DzcEByg_3wjQog(RectangleF _0023_003DzpGw_0024feA_003D, float _0023_003DzKClhtPc_003D, float _0023_003DzQ7wmRP8_003D, float _0023_003Dzg4_ifKk_003D, float _0023_003Dzf_0024_0024Ar9M_003D)
	{
		float x = _0023_003DzpGw_0024feA_003D.X;
		float y = _0023_003DzpGw_0024feA_003D.Y;
		float width = _0023_003DzpGw_0024feA_003D.Width;
		float height = _0023_003DzpGw_0024feA_003D.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddBezier(x, y + _0023_003DzKClhtPc_003D, x, y, x + _0023_003DzKClhtPc_003D, y, x + _0023_003DzKClhtPc_003D, y);
		graphicsPath.AddLine(x + _0023_003DzKClhtPc_003D, y, x + width - _0023_003DzQ7wmRP8_003D, y);
		graphicsPath.AddBezier(x + width - _0023_003DzQ7wmRP8_003D, y, x + width, y, x + width, y + _0023_003DzQ7wmRP8_003D, x + width, y + _0023_003DzQ7wmRP8_003D);
		graphicsPath.AddLine(x + width, y + _0023_003DzQ7wmRP8_003D, x + width, y + height - _0023_003Dzg4_ifKk_003D);
		graphicsPath.AddBezier(x + width, y + height - _0023_003Dzg4_ifKk_003D, x + width, y + height, x + width - _0023_003Dzg4_ifKk_003D, y + height, x + width - _0023_003Dzg4_ifKk_003D, y + height);
		graphicsPath.AddLine(x + width - _0023_003Dzg4_ifKk_003D, y + height, x + _0023_003Dzf_0024_0024Ar9M_003D, y + height);
		graphicsPath.AddBezier(x + _0023_003Dzf_0024_0024Ar9M_003D, y + height, x, y + height, x, y + height - _0023_003Dzf_0024_0024Ar9M_003D, x, y + height - _0023_003Dzf_0024_0024Ar9M_003D);
		graphicsPath.AddLine(x, y + height - _0023_003Dzf_0024_0024Ar9M_003D, x, y + _0023_003DzKClhtPc_003D);
		return graphicsPath;
	}

	internal static GraphicsPath _0023_003Dz1Uozz9c_003D(RectangleF _0023_003DzpGw_0024feA_003D)
	{
		float x = _0023_003DzpGw_0024feA_003D.X;
		float y = _0023_003DzpGw_0024feA_003D.Y;
		float width = _0023_003DzpGw_0024feA_003D.Width;
		float height = _0023_003DzpGw_0024feA_003D.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(x, y, x + width, y);
		graphicsPath.AddLine(x + width, y, x + width, y + height);
		graphicsPath.AddLine(x + width, y + height, x, y + height);
		graphicsPath.AddLine(x, y + height, x, y);
		return graphicsPath;
	}

	public static GraphicsPath BuildRoundedRectangle(float x, float y, float width, float height, float radius)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(x + radius, y, x + width - radius, y);
		graphicsPath.AddArc(x + width - radius * 2f, y, radius * 2f, radius * 2f, 270f, 90f);
		graphicsPath.AddLine(x + width, y + radius, x + width, y + height - radius);
		graphicsPath.AddArc(x + width - radius * 2f, y + height - radius * 2f, radius * 2f, radius * 2f, 0f, 90f);
		graphicsPath.AddLine(x + width - radius, y + height, x + radius, y + height);
		graphicsPath.AddArc(x, y + height - radius * 2f, radius * 2f, radius * 2f, 90f, 90f);
		graphicsPath.AddLine(x, y + height - radius, x, y + radius);
		graphicsPath.AddArc(x, y, radius * 2f, radius * 2f, 180f, 90f);
		return graphicsPath;
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		if (Buttons != null)
		{
			for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
			{
				Buttons[i]._0023_003DzPY_0024ulDyKjEOA();
			}
		}
		_0023_003DznZb9Hv4kLFb_0024?.Dispose();
		_0023_003DzVhvZQg9SrGtM?.Dispose();
		_0023_003Dz7aZKRnXMM_0024aU?.Dispose();
	}

	public override void Dispose()
	{
		if (Buttons != null)
		{
			for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
			{
				Buttons[i].Dispose();
			}
		}
		_0023_003Dzhm487aI_003D = null;
		_0023_003DznZb9Hv4kLFb_0024?.Dispose();
		_0023_003DzVhvZQg9SrGtM?.Dispose();
		_0023_003Dz7aZKRnXMM_0024aU?.Dispose();
	}

	internal void _0023_003Dz4co0C9w_003D()
	{
		if (Buttons != null)
		{
			for (int i = 0; i < _0023_003Dz39dJVf2fnvi4(); i++)
			{
				Buttons[i]._0023_003Dzbb_0024Bito_003D((ToolBarButton._0023_003DzJrgugJM_003D)0);
			}
		}
	}

	internal ToolBarButton[] _0023_003DzMVyuXyqVJvbyhy5NHg_003D_003D()
	{
		return _0023_003Dz9QdwAbMe_bt_0024ycdnbc88J88_003D;
	}

	internal void _0023_003DzMlszZGKKiGw39j8DSg_003D_003D(ToolBarButton[] _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz9QdwAbMe_bt_0024ycdnbc88J88_003D = _0023_003DzsLHxXyo_003D;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(ToolBar _0023_003DzAbAO3f4_003D)
	{
		if (Position == _0023_003DzAbAO3f4_003D.Position && Visible == _0023_003DzAbAO3f4_003D.Visible && !_0023_003DzOce1OewfzxkY() && Margin == _0023_003DzAbAO3f4_003D.Margin && Padding == _0023_003DzAbAO3f4_003D.Padding && !(BackgroundColor != _0023_003DzAbAO3f4_003D.BackgroundColor) && !(Math.Abs(BackgroundCornerRadius - _0023_003DzAbAO3f4_003D.BackgroundCornerRadius) > 1E-12) && !(BackgroundBorderColor != _0023_003DzAbAO3f4_003D.BackgroundBorderColor))
		{
			return Math.Abs(BackgroundBorderWidth - _0023_003DzAbAO3f4_003D.BackgroundBorderWidth) > 1E-12;
		}
		return true;
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		System.Drawing.Point point = _0023_003DzBV0j3auMLVC4();
		Size size = _0023_003DzQHzBIEUl5bN2();
		int x = point.X - (int)BackgroundBorderWidth;
		int y = point.Y - (int)BackgroundBorderWidth;
		int width = size.Width + (int)(2.0 * BackgroundBorderWidth);
		int height = size.Height + (int)(2.0 * BackgroundBorderWidth);
		System.Drawing.Point location = viewport.ViewportToScreen(new System.Drawing.Point(x, y));
		Size size2 = new Size(width, height);
		return new Rectangle(location, size2);
	}

	public override void Update(IUserInterfaceElement another)
	{
		ToolBar toolBar = (ToolBar)another;
		_0023_003DzshPEPAc_003D(toolBar.Position, toolBar.Visible, toolBar.Buttons, toolBar.Margin, toolBar.Padding, RenderContextUtility.ConvertColor(toolBar.BackgroundColor), toolBar.BackgroundCornerRadius, RenderContextUtility.ConvertColor(toolBar.BackgroundBorderColor), toolBar.BackgroundBorderWidth, _0023_003DzXbUGNUdn2gMv: false);
	}

	public virtual object Clone()
	{
		return new ToolBar(this);
	}

	internal bool _0023_003DzL28lpFu5le27()
	{
		if (_0023_003Dz39dJVf2fnvi4() <= 0 || (Buttons[0]._0023_003Dzt8M7jZkZ__VNpsLmCQ_003D_003D() != null && Buttons[0]._0023_003Dzt8M7jZkZ__VNpsLmCQ_003D_003D()[0] != null))
		{
			return _0023_003Dzj50S4o0_003D.IsEmpty;
		}
		return true;
	}

	public static bool ButtonsAreEquals(ToolBarButtonList objA, ToolBarButtonList objB)
	{
		if (objA == objB)
		{
			return true;
		}
		if (objA != null && objB != null)
		{
			int count = objA.Count;
			int count2 = objB.Count;
			if (count == count2)
			{
				if (count == 0)
				{
					return true;
				}
				for (int i = 0; i < count; i++)
				{
					if (!ToolBarButton.Equals(objA[i], objB[i]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
