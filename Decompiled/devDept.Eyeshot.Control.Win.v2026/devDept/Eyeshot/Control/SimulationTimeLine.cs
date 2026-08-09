using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(SimulationTimeLineConverter))]
public class SimulationTimeLine : BarBase, ICloneable
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<Toolpath.Motion, bool> _0023_003DzuS561X8EAfyQylQWkg_003D_003D;

		internal bool _0023_003Dzs0v7UgdsUDRUgTn5T8lPFLyocsDL(Toolpath.Motion _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Code == motionType.G00;
		}
	}

	private sealed class _0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D
	{
		public double _0023_003DzbQRK6SU_003D;

		internal bool _0023_003Dzkcaf4Bw1ahJLSb7c6g_003D_003D(Toolpath.Motion _0023_003DzLtLprGE_003D)
		{
			if (_0023_003DzLtLprGE_003D.lengthUpTo <= _0023_003DzbQRK6SU_003D)
			{
				return _0023_003DzLtLprGE_003D.lengthUpTo + _0023_003DzLtLprGE_003D.Length() > _0023_003DzbQRK6SU_003D;
			}
			return false;
		}
	}

	private Manufacture _parentWorkspace;

	internal int Thickness;

	private int viewportIndex;

	private Color _hoveringColor;

	private Color _collisionColor;

	private Color _thumbColor;

	private bool _visible = _0023_003DzndG2TcxO_tb_0024();

	private List<Point2D> boundsPts = new List<Point2D>();

	private Point2D mousePos;

	private string toolTipText = string.Empty;

	internal bool isDirty = true;

	private List<List<int>> _rapidsIndexList = new List<List<int>>();

	private List<List<int>> _collisionIndexList = new List<List<int>>();

	internal List<Toolpath> simulationToolPaths = new List<Toolpath>();

	internal List<EndMill> tools = new List<EndMill>();

	private double _totalPathDistance;

	internal double currentDistance;

	private int _currentPixelId;

	internal int currentPathIndex;

	internal bool resetTool;

	internal EndMill currentTool;

	internal int[] colorPixelsArray;

	internal bool enabled = true;

	private Color _rapidColor;

	private Color _color;

	private double _exactMotionsPerPixel;

	private int[] _operationMarksPixelsId;

	protected internal override Viewport ParentViewport
	{
		get
		{
			if (_parentWorkspace != null)
			{
				return _parentWorkspace.ActiveViewport;
			}
			return null;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593263));
		}
	}

	protected internal virtual Manufacture ParentWorkspace
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

	[Description("The SimulationTimeLine thickness factor (range 0-1).")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	public double ThicknessFactor { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("SimulationTimeLine visibility status.")]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	[Description("The SimulationTimeLine color to highligth the cursor location.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color HoveringColor
	{
		get
		{
			return _hoveringColor;
		}
		set
		{
			_hoveringColor = value;
		}
	}

	[Description("The SimulationTimeLine color of the rapids movements.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color RapidColor
	{
		get
		{
			return _rapidColor;
		}
		set
		{
			_rapidColor = value;
		}
	}

	[Description("The SimulationTimeLine color of the timeline thumb")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color ThumbColor
	{
		get
		{
			return _thumbColor;
		}
		set
		{
			_thumbColor = value;
		}
	}

	[Description("The SimulationTimeLine color of the movements without collision")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
		}
	}

	[Description("The SimulationTimeLine color of the collision movements")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color CollisionColor
	{
		get
		{
			return _collisionColor;
		}
		set
		{
			_collisionColor = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Scale of the progress bar.")]
	public double DrawScale { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ViewportIndex
	{
		get
		{
			return viewportIndex;
		}
		internal set
		{
			if (value != viewportIndex)
			{
				viewportIndex = value;
			}
		}
	}

	public SimulationTimeLine()
		: this(_0023_003DzZkzmAvUVQ_hh(), _0023_003Dzr_0024djVmZKoX2oP7IBc6TNyGs_003D(), _0023_003Dz3S5baIME1gm5(), _0023_003DzmHBwUyK6dkVN(), _0023_003DzO_wV64rjbZ_K4yjvuQ_003D_003D(), _0023_003DzHGVNiEosRKPc(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzscjlTsnoezaC())
	{
	}

	public SimulationTimeLine(Color thumbColor, Color cursorLocationColor, Color safeMovementsColor, Color collisionColor, Color rapidsColor, double drawScale, bool visible, double thicknessFactor)
	{
		_0023_003DzshPEPAc_003D(thumbColor, cursorLocationColor, safeMovementsColor, collisionColor, rapidsColor, drawScale, visible, thicknessFactor);
	}

	public SimulationTimeLine(SimulationTimeLine another)
	{
		_0023_003DzshPEPAc_003D(another._thumbColor, another._hoveringColor, another._color, another._collisionColor, another._rapidColor, another.DrawScale, another.Visible, another.ThicknessFactor);
	}

	private void _0023_003DzshPEPAc_003D(Color _0023_003Dza_0024yTnsF8LvEl, Color _0023_003DzFVZKi_00242JcDO1, Color _0023_003DzsdEUB6_u1bN7Tv9R48Z2hbU_003D, Color _0023_003DzaWm4CW_0024BnJnu3L3o0Q_003D_003D, Color _0023_003DzgBFrgkarFRlU, double _0023_003DzCzsr4CTVr_Ea, bool _0023_003DzbWHNjOg_003D, double _0023_003DzwuU7bst7n7guH9ZuFQ_003D_003D)
	{
		_hoveringColor = _0023_003DzFVZKi_00242JcDO1;
		_collisionColor = _0023_003DzaWm4CW_0024BnJnu3L3o0Q_003D_003D;
		_rapidColor = _0023_003DzgBFrgkarFRlU;
		_color = _0023_003DzsdEUB6_u1bN7Tv9R48Z2hbU_003D;
		_thumbColor = _0023_003Dza_0024yTnsF8LvEl;
		DrawScale = _0023_003DzCzsr4CTVr_Ea;
		Visible = _0023_003DzbWHNjOg_003D;
		ThicknessFactor = _0023_003DzwuU7bst7n7guH9ZuFQ_003D_003D;
	}

	private static double _0023_003DzHGVNiEosRKPc()
	{
		return 1.0;
	}

	private static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	private static double _0023_003DzscjlTsnoezaC()
	{
		return 0.01;
	}

	private static Color _0023_003DzO_wV64rjbZ_K4yjvuQ_003D_003D()
	{
		return Color.LightGray;
	}

	private static Color _0023_003DzmHBwUyK6dkVN()
	{
		return Color.Red;
	}

	private static Color _0023_003Dz3S5baIME1gm5()
	{
		return Color.Green;
	}

	private static Color _0023_003Dzr_0024djVmZKoX2oP7IBc6TNyGs_003D()
	{
		return Color.Orange;
	}

	private static Color _0023_003DzZkzmAvUVQ_hh()
	{
		return Color.Black;
	}

	private void _0023_003DziFg8bNGi4HTc()
	{
		ThicknessFactor = _0023_003DzscjlTsnoezaC();
	}

	private bool _0023_003DzT70_mhuE6obDr0yY_0024Q_003D_003D()
	{
		return ThicknessFactor != _0023_003DzscjlTsnoezaC();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (!_0023_003Dzp1MY8XdGBFgV() && !_0023_003DzlHVE2s47uF6hZ5wfHA_003D_003D() && !_0023_003Dz72Tp0q_0024i6pM85HqzMg_003D_003D() && !_0023_003Dz3SV_00249FPfwz1J())
		{
			return _0023_003DzT70_mhuE6obDr0yY_0024Q_003D_003D();
		}
		return true;
	}

	public void Init()
	{
		_0023_003Dz_qVeHI93jfLr_00243Rv4A_003D_003D();
		_0023_003Dz38_7SROPt_Yu();
		_0023_003DzCKgO2G0_003D();
		isDirty = false;
	}

	internal void _0023_003DzxEpSi5o_003D()
	{
		currentDistance = 0.0;
		_totalPathDistance = 0.0;
		simulationToolPaths = new List<Toolpath>();
		_rapidsIndexList = new List<List<int>>();
		_collisionIndexList = new List<List<int>>();
		colorPixelsArray = new int[0];
		isDirty = true;
		_currentPixelId = 0;
		currentPathIndex = 0;
		resetTool = false;
		_operationMarksPixelsId = new int[0];
		tools = new List<EndMill>();
	}

	internal void _0023_003Dz1BiD_wY_003D(Toolpath _0023_003DzalfEYyI_003D)
	{
		if (!simulationToolPaths.Contains(_0023_003DzalfEYyI_003D))
		{
			simulationToolPaths.Add(_0023_003DzalfEYyI_003D);
			_totalPathDistance += _0023_003DzalfEYyI_003D.Length();
		}
	}

	internal void _0023_003DzEnEOg3EifJXc(EndMill _0023_003DzqhWU5eA_003D)
	{
		if (!tools.Contains(_0023_003DzqhWU5eA_003D))
		{
			tools.Add(_0023_003DzqhWU5eA_003D);
			currentTool = _0023_003DzqhWU5eA_003D;
			currentPathIndex++;
		}
	}

	internal void _0023_003DzlGvHHDocBoCZ(double _0023_003DzsLHxXyo_003D)
	{
		currentDistance += _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz_qVeHI93jfLr_00243Rv4A_003D_003D()
	{
		_rapidsIndexList = new List<List<int>>();
		foreach (Toolpath simulationToolPath in simulationToolPaths)
		{
			List<int> list = new List<int>();
			foreach (Toolpath.Motion item in simulationToolPath.MotionList.Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dzs0v7UgdsUDRUgTn5T8lPFLyocsDL))
			{
				list.Add(simulationToolPath.MotionList.IndexOf(item));
			}
			_rapidsIndexList.Add(list);
			_collisionIndexList.Add(new List<int>());
		}
	}

	private void _0023_003Dz38_7SROPt_Yu()
	{
		_totalPathDistance = 0.0;
		foreach (Toolpath simulationToolPath in simulationToolPaths)
		{
			_totalPathDistance += simulationToolPath.Length();
		}
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzINoPNMv4DdnR()
	{
		HoveringColor = RenderContextUtility.ConvertColor(_0023_003Dzr_0024djVmZKoX2oP7IBc6TNyGs_003D());
	}

	private void _0023_003DzHLl5arGpDTD_0024Vh_VuQ_003D_003D()
	{
		RapidColor = RenderContextUtility.ConvertColor(_0023_003DzO_wV64rjbZ_K4yjvuQ_003D_003D());
	}

	private bool _0023_003DzlHVE2s47uF6hZ5wfHA_003D_003D()
	{
		return !RenderContextUtility.AreEqual(RapidColor, _0023_003DzO_wV64rjbZ_K4yjvuQ_003D_003D());
	}

	private bool _0023_003Dzlz5QWTuESFP5()
	{
		return _thumbColor.ToArgb() != _0023_003DzZkzmAvUVQ_hh().ToArgb();
	}

	private void _0023_003DzvkcG0V85nVmB()
	{
		ThumbColor = RenderContextUtility.ConvertColor(_0023_003DzZkzmAvUVQ_hh());
	}

	private bool _0023_003Dz03FyqHnF4Qsp()
	{
		return _color.ToArgb() != _0023_003Dz3S5baIME1gm5().ToArgb();
	}

	private void _0023_003DzIgBloT8_003D()
	{
		Color = RenderContextUtility.ConvertColor(_0023_003Dz3S5baIME1gm5());
	}

	private bool _0023_003Dzp1MY8XdGBFgV()
	{
		return _collisionColor.ToArgb() != _0023_003DzmHBwUyK6dkVN().ToArgb();
	}

	private void _0023_003DzWtHKHFUrtEw7()
	{
		CollisionColor = RenderContextUtility.ConvertColor(_0023_003DzmHBwUyK6dkVN());
	}

	private bool _0023_003Dz72Tp0q_0024i6pM85HqzMg_003D_003D()
	{
		return DrawScale != _0023_003DzHGVNiEosRKPc();
	}

	private void _0023_003Dz_0024wIoK2Gqi7N2()
	{
		DrawScale = _0023_003DzHGVNiEosRKPc();
	}

	internal override void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
	}

	protected internal override void Draw(DrawSceneParams myParams)
	{
		if (!Visible)
		{
			return;
		}
		Viewport activeViewport = ParentWorkspace.ActiveViewport;
		if (ParentWorkspace.Viewports[ViewportIndex] != activeViewport)
		{
			return;
		}
		Thickness = (int)(ThicknessFactor * DrawScale * (double)activeViewport.Size.Height);
		myParams.RenderContext.PushBlendState();
		myParams.RenderContext.PushShader();
		myParams.RenderContext.SetState(blendStateType.Blend);
		myParams.RenderContext.SetShader(shaderType.NoLights);
		_0023_003DzNbwAFLd9B6eqFd0rw_BQtcc_003D(myParams.RenderContext, activeViewport);
		if (mousePos != null)
		{
			_0023_003DzMcNA0ge0k7tUKGKLrg_003D_003D(myParams.RenderContext);
		}
		if (ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D != null)
		{
			_0023_003Dzalxr6RoFyiqa(myParams.RenderContext, ParentWorkspace, activeViewport);
			if (mousePos != null)
			{
				_0023_003DzMcNA0ge0k7tUKGKLrg_003D_003D(myParams.RenderContext);
			}
		}
		myParams.RenderContext.PopShader();
		myParams.RenderContext.PopBlendState();
	}

	private void _0023_003DzMcNA0ge0k7tUKGKLrg_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(_hoveringColor);
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF((float)mousePos.X - 4f, 0f, 8f, Thickness));
	}

	private void _0023_003DzNbwAFLd9B6eqFd0rw_BQtcc_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		int alpha = (int)(_0023_003DzYzWi5Yw_003D.Background.ColorThemeTransparency * 255.0) / 4;
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(alpha, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor()));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(0f, 0f, _0023_003DzYzWi5Yw_003D.Size.Width, Thickness));
	}

	private void _0023_003Dzalxr6RoFyiqa(RenderContextBase _0023_003DzmNZD0Zs_003D, Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		if ((ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dz0_4_A89QUv3z() || ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dzxi5Dd3Y_003D != 0.0) && _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationToolpath != null && _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D != null)
		{
			int width = _0023_003DzYzWi5Yw_003D.Size.Width;
			_currentPixelId = (int)((currentDistance + ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dzxi5Dd3Y_003D) / _totalPathDistance * (double)width);
			if (_currentPixelId > width)
			{
				_currentPixelId = width;
			}
			_0023_003DzzjYyz17H__oH8HmD_0024g_003D_003D(_0023_003DzmNZD0Zs_003D, _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D);
			_0023_003DztgMoI5OEDegM9pN6Ag_003D_003D(_0023_003DzmNZD0Zs_003D);
			_0023_003DzGWin9GoadWG_0024(_0023_003DzmNZD0Zs_003D);
		}
	}

	internal void _0023_003DzCKgO2G0_003D()
	{
		if (simulationToolPaths.Count == 0)
		{
			return;
		}
		int _0023_003DzhlCpXt8_003D = 0;
		colorPixelsArray = new int[ParentWorkspace.ActiveViewport.Size.Width];
		foreach (Toolpath simulationToolPath in simulationToolPaths)
		{
			_0023_003Dz_0024lygvhHEXd8Y(_0023_003DzhlCpXt8_003D, simulationToolPaths.IndexOf(simulationToolPath));
			_0023_003DzhlCpXt8_003D = _0023_003DzMsDcA4xFf02b(simulationToolPath.Length());
		}
		_0023_003Dzkvv_FEVQfxQD();
	}

	private int _0023_003DzMsDcA4xFf02b(double _0023_003DzMIKRg0jeWZcJ)
	{
		if (_totalPathDistance == 0.0)
		{
			return 0;
		}
		return (int)Math.Round(_0023_003DzMIKRg0jeWZcJ / _totalPathDistance * (double)ParentWorkspace.ActiveViewport.Size.Width, MidpointRounding.AwayFromZero);
	}

	private void _0023_003Dz_0024lygvhHEXd8Y(int _0023_003DzhlCpXt8_003D, int _0023_003DzWKhsK5c_003D)
	{
		if (_rapidsIndexList.Count == 0 || _0023_003DzWKhsK5c_003D >= _rapidsIndexList.Count)
		{
			return;
		}
		if (_rapidsIndexList[_0023_003DzWKhsK5c_003D] != null && _rapidsIndexList[_0023_003DzWKhsK5c_003D].Count > 0)
		{
			foreach (int item in _rapidsIndexList[_0023_003DzWKhsK5c_003D])
			{
				int num = _0023_003DzhlCpXt8_003D + _0023_003DzMsDcA4xFf02b(simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList[item].lengthUpTo);
				int num2 = _0023_003DzMsDcA4xFf02b(simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList[item].Length()) + num;
				if (num2 > ParentWorkspace.ActiveViewport.Size.Width)
				{
					num2 = ParentWorkspace.ActiveViewport.Size.Width;
				}
				for (int i = num; i < num2; i++)
				{
					colorPixelsArray[i] = 1;
				}
			}
		}
		if (_collisionIndexList == null || _collisionIndexList[_0023_003DzWKhsK5c_003D].Count <= 0)
		{
			return;
		}
		foreach (int item2 in _collisionIndexList[_0023_003DzWKhsK5c_003D])
		{
			int num3 = _0023_003DzhlCpXt8_003D + _0023_003DzMsDcA4xFf02b(simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList[item2].lengthUpTo);
			int num4 = _0023_003DzMsDcA4xFf02b(simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList[item2].Length()) + num3;
			if (num4 == ParentWorkspace.ActiveViewport.Size.Width)
			{
				num4--;
			}
			for (int j = num3; j <= num4; j++)
			{
				colorPixelsArray[j] = 2;
			}
		}
	}

	internal void _0023_003DzaRI1GtM_003D(double _0023_003DzPLzl0NFSK_es, double _0023_003DzpRKORuAYWrG9, int _0023_003DzpULMxlKjV_0024DL, int _0023_003DzWKhsK5c_003D)
	{
		int num = _0023_003DzMsDcA4xFf02b(currentDistance + _0023_003DzPLzl0NFSK_es);
		int num2 = _0023_003DzMsDcA4xFf02b(_0023_003DzpRKORuAYWrG9) + num;
		if (num2 == ParentWorkspace.ActiveViewport.Size.Width)
		{
			num2--;
		}
		for (int i = num; i <= num2; i++)
		{
			colorPixelsArray[i] = 2;
		}
		_collisionIndexList[_0023_003DzWKhsK5c_003D].Add(_0023_003DzpULMxlKjV_0024DL);
	}

	private void _0023_003DzGWin9GoadWG_0024(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (simulationToolPaths.Count < 2)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.PopBlendState();
		if (_operationMarksPixelsId != null)
		{
			for (int i = 0; i < _operationMarksPixelsId.Length; i++)
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(_thumbColor);
				_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_operationMarksPixelsId[i], 0f, 1f, Thickness));
			}
		}
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
	}

	private void _0023_003Dzkvv_FEVQfxQD()
	{
		if (simulationToolPaths.Count >= 2)
		{
			_operationMarksPixelsId = new int[simulationToolPaths.Count - 1];
			double num = 0.0;
			for (int i = 0; i < _operationMarksPixelsId.Length; i++)
			{
				Toolpath toolpath = simulationToolPaths[i];
				num += toolpath.Length();
				int num2 = (int)(num / _totalPathDistance * (double)ParentWorkspace.ActiveViewport.Size.Width);
				_operationMarksPixelsId[i] = num2;
			}
		}
	}

	private void _0023_003DzzjYyz17H__oH8HmD_0024g_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D)
	{
		int alpha = (int)Math.Min(255.0, _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.Background.ColorThemeTransparency * 255.0 * 2.0);
		if (colorPixelsArray == null)
		{
			return;
		}
		for (int i = 0; i < Math.Min(_currentPixelId, colorPixelsArray.Length); i++)
		{
			if (colorPixelsArray[i] == 0)
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(alpha, _color));
			}
			else if (colorPixelsArray[i] == 1)
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(alpha, _rapidColor));
			}
			else
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(alpha, _collisionColor));
			}
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(i, 0f, 1f, Thickness));
		}
	}

	private void _0023_003DztgMoI5OEDegM9pN6Ag_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzmNZD0Zs_003D.PopBlendState();
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(_thumbColor);
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_currentPixelId, 0f, 5f, Thickness));
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
	}

	public override void Dispose()
	{
		_0023_003DzxEpSi5o_003D();
		base.Dispose();
		ParentWorkspace = null;
	}

	public virtual string GetToolTipText(Toolpath.Motion motion, int operationIndex, bool collision)
	{
		if (collision)
		{
			return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593587) + _collisionIndexList[operationIndex].IndexOf(simulationToolPaths[operationIndex].MotionList.IndexOf(motion));
		}
		string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593601) + motion.Code;
		string text2 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593620) + motion.Feed;
		string text3 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593639) + motion.Speed;
		string text4 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593657) + string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593420), motion.StartPoint.X, motion.StartPoint.Y, motion.StartPoint.Z);
		Point3D endPoint = motion.EndPoint;
		string text5 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593454) + string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593443), endPoint.X, endPoint.Y, endPoint.Z);
		string text6 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593476) + (motion.lengthUpTo / simulationToolPaths[operationIndex].Length() * 100.0).ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593491));
		text6 += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593512);
		return text + Environment.NewLine + text2 + Environment.NewLine + text3 + Environment.NewLine + text4 + Environment.NewLine + text5 + Environment.NewLine + text6;
	}

	private double _0023_003Dz_00248Ff6HTpRCvD14UQsA_003D_003D(int _0023_003Dz8GBMuoM_003D, out int _0023_003DzWKhsK5c_003D)
	{
		_0023_003DzWKhsK5c_003D = 0;
		double num = 0.0;
		double num2 = (double)_0023_003Dz8GBMuoM_003D / (double)ParentWorkspace.ActiveViewport.Size.Width * _totalPathDistance;
		for (int i = 0; i < simulationToolPaths.Count; i++)
		{
			Toolpath toolpath = simulationToolPaths[i];
			double num3 = toolpath.Length();
			if (num2 >= num && num2 <= num + num3)
			{
				_0023_003DzWKhsK5c_003D = i;
				break;
			}
			num += toolpath.Length();
		}
		return num2;
	}

	private Toolpath.Motion _0023_003DzQb03YXvsIexZ(MouseEventArgs _0023_003Dz1SmHC4c_003D, out int _0023_003DzWKhsK5c_003D, out bool _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D)
	{
		_0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D _0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D2 = new _0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D();
		_0023_003DzGXRK8GYwmXjPflrP_g_003D_003D = false;
		_0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D2._0023_003DzbQRK6SU_003D = _0023_003Dz_00248Ff6HTpRCvD14UQsA_003D_003D(_0023_003Dz1SmHC4c_003D.Location.X, out _0023_003DzWKhsK5c_003D);
		if (_0023_003DzWKhsK5c_003D >= simulationToolPaths.Count)
		{
			return null;
		}
		double num = 0.0;
		for (int i = 0; i < _0023_003DzWKhsK5c_003D; i++)
		{
			num += simulationToolPaths[i].Length();
		}
		_0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D2._0023_003DzbQRK6SU_003D -= num;
		Toolpath.Motion motion = simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList.FirstOrDefault(_0023_003DzfVgh_0024UzahONMP8H0O7wQ3i4_003D2._0023_003Dzkcaf4Bw1ahJLSb7c6g_003D_003D) ?? simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList.Last();
		int item = simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList.IndexOf(motion);
		_0023_003DzGXRK8GYwmXjPflrP_g_003D_003D = _collisionIndexList.Count > _0023_003DzWKhsK5c_003D && _collisionIndexList[_0023_003DzWKhsK5c_003D].Contains(item);
		return motion;
	}

	private void _0023_003Dze4bCZA_S7dsL(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003DzU0f5_qE_003D._0023_003Dz32fCUXg4rkVM._0023_003Dzw1jKay_0024z8meP())
		{
			return;
		}
		int _0023_003DzWKhsK5c_003D;
		bool _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D;
		Toolpath.Motion motion = _0023_003DzQb03YXvsIexZ(_0023_003Dz1SmHC4c_003D, out _0023_003DzWKhsK5c_003D, out _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D);
		if (motion != null)
		{
			string text = GetToolTipText(motion, _0023_003DzWKhsK5c_003D, _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D);
			if (toolTipText != text)
			{
				toolTipText = text;
				((Manufacture)_0023_003DzU0f5_qE_003D)._0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D.SetToolTip(_0023_003DzU0f5_qE_003D, toolTipText);
				((Manufacture)_0023_003DzU0f5_qE_003D)._0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D.Active = true;
			}
		}
	}

	internal override bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (Contains(_0023_003Dz1SmHC4c_003D.Location))
		{
			mousePos = new Point2D(_0023_003Dz1SmHC4c_003D.Location.X, _0023_003Dz1SmHC4c_003D.Location.Y);
			if (ParentWorkspace.SimulationSetup != null && ParentWorkspace.SimulationTool != null && ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D != null)
			{
				_0023_003Dze4bCZA_S7dsL(_0023_003DzU0f5_qE_003D, _0023_003Dz1SmHC4c_003D);
			}
			BarBase.Repaint(_0023_003DzU0f5_qE_003D);
			return true;
		}
		if (mousePos != null)
		{
			mousePos = null;
			BarBase.Repaint(_0023_003DzU0f5_qE_003D);
		}
		((Manufacture)_0023_003DzU0f5_qE_003D)._0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D.Active = false;
		return false;
	}

	internal void _0023_003DzA_0024DikLW4dIhx(EventArgs _0023_003Dz1SmHC4c_003D)
	{
		mousePos = null;
	}

	internal bool _0023_003DznLFqJ0dXjXHS(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz1SmHC4c_003D.Button != MouseButtons.Left || !Contains(_0023_003Dz1SmHC4c_003D.Location) || ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D == null)
		{
			return false;
		}
		if (mousePos.X > (double)_currentPixelId)
		{
			return false;
		}
		if (ParentWorkspace._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D != null && ParentWorkspace.ToolBlockRef != null && ParentWorkspace._0023_003DzGrg75r5OtcLP)
		{
			_0023_003DztA2YLIc5LE8O(_0023_003Dz1SmHC4c_003D);
			_0023_003DzU0f5_qE_003D.UpdateBoundingBox();
		}
		return true;
	}

	private void _0023_003DztA2YLIc5LE8O(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		int _0023_003DzWKhsK5c_003D;
		bool _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D;
		Toolpath.Motion motion = _0023_003DzQb03YXvsIexZ(_0023_003Dz1SmHC4c_003D, out _0023_003DzWKhsK5c_003D, out _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D);
		if (motion != null)
		{
			_0023_003DztYy7TLbBY6ja(_0023_003DzWKhsK5c_003D);
			Point3D startPoint = motion.StartPoint;
			Manufacture._0023_003DzKLccc_A_003D(startPoint, ParentWorkspace, ParentWorkspace.ToolBlockRef, new CompileParams(ParentWorkspace), _0023_003DzUFCuHpQ_003D: false, !ParentWorkspace._0023_003DzFrVxU64BV0ac);
			ParentWorkspace._0023_003DzLibvUa2axNVJ(new PointCL(startPoint.X, startPoint.Y, startPoint.Z, 0, motion), 0);
			ParentWorkspace._0023_003DzFrVxU64BV0ac = true;
			bool _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D2 = _collisionIndexList[_0023_003DzWKhsK5c_003D].Contains(simulationToolPaths[_0023_003DzWKhsK5c_003D].MotionList.IndexOf(motion));
			ParentWorkspace._0023_003DzFrByqiXF9Gb8(_0023_003DzGXRK8GYwmXjPflrP_g_003D_003D2);
		}
	}

	private void _0023_003DztYy7TLbBY6ja(int _0023_003DzlY_lWP0_003D)
	{
		ParentWorkspace.Blocks[ParentWorkspace._0023_003DzMK_SXXTeS2YU].Entities.Clear();
		Entity visualRep = tools[_0023_003DzlY_lWP0_003D].GetVisualRep();
		ParentWorkspace._0023_003DzFq4cQqFyw187(visualRep);
		ParentWorkspace.Blocks[ParentWorkspace._0023_003DzMK_SXXTeS2YU].Entities.Add(visualRep);
		resetTool = true;
		ParentWorkspace._0023_003DzUSdcpYGibIjc(ParentWorkspace.Blocks[ParentWorkspace._0023_003DzMK_SXXTeS2YU].Entities[0].Clone() as Mesh);
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
		if (viewport != viewport._0023_003Dz0TvaYNo_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[ViewportIndex])
		{
			return Rectangle.Empty;
		}
		_0023_003DzDtqIzro_003D(viewport);
		return new Rectangle(viewport.Location.X, viewport.Location.Y + viewport.Size.Height - Thickness, viewport.Size.Width, Thickness);
	}

	public override bool Contains(System.Drawing.Point mousePos)
	{
		if (Visible && _parentWorkspace.ActiveViewport != null)
		{
			return GetBounds(_parentWorkspace.ActiveViewport).Contains(mousePos);
		}
		return false;
	}

	private void _0023_003DzDtqIzro_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		boundsPts = new List<Point2D>();
		boundsPts.AddRange(_0023_003DzyjwNDZUP2gPT(new Rectangle(0, _0023_003DzYzWi5Yw_003D.Size.Height, _0023_003DzYzWi5Yw_003D.Size.Width, Thickness)));
	}

	public override void Update(IUserInterfaceElement another)
	{
		SimulationTimeLine simulationTimeLine = (SimulationTimeLine)another;
		_0023_003DzshPEPAc_003D(simulationTimeLine._thumbColor, simulationTimeLine._hoveringColor, simulationTimeLine._color, simulationTimeLine._collisionColor, simulationTimeLine._rapidColor, simulationTimeLine.DrawScale, simulationTimeLine.Visible, simulationTimeLine.ThicknessFactor);
	}

	internal void _0023_003DzkuKAZi1FqBH8FSpngg_003D_003D()
	{
	}

	public virtual object Clone()
	{
		return new SimulationTimeLine(this);
	}
}
