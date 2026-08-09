using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace devDept.Eyeshot.Designer;

[DefaultProperty("Color")]
[DefaultEvent("ColorChanged")]
[ToolboxItem(false)]
public class ColorPicker : System.Windows.Forms.Control
{
	private sealed class _0023_003Dz_0024W6XCK97EhLq : Form
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzCoXI3hw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzJmJQUAUl_k1ubqKmpw_003D_003D;

		public _0023_003Dz_0024W6XCK97EhLq()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			base.KeyPreview = true;
			base.StartPosition = FormStartPosition.Manual;
			Panel value = new Panel
			{
				BorderStyle = BorderStyle.FixedSingle,
				Dock = DockStyle.Fill
			};
			base.Controls.Add(value);
		}

		public void _0023_003DzrMNj1x0_003D(System.Windows.Forms.Control _0023_003DzAHes4Iw_003D)
		{
			((Panel)base.Controls[0]).Controls.Add(_0023_003DzAHes4Iw_003D);
		}

		public bool _0023_003Dz3lE0aY8w9eEG()
		{
			return _0023_003DzCoXI3hw_003D;
		}

		public void _0023_003Dz25AXz_HR4EsH()
		{
			_0023_003DzJmJQUAUl_k1ubqKmpw_003D_003D = true;
			Hide();
		}

		protected override void OnKeyDown(KeyEventArgs _0023_003Dz9I8ZVlc_003D)
		{
			base.OnKeyDown(_0023_003Dz9I8ZVlc_003D);
			if (_0023_003Dz9I8ZVlc_003D.Modifiers == Keys.None && _0023_003Dz9I8ZVlc_003D.KeyCode == Keys.Escape)
			{
				Hide();
			}
		}

		protected override void OnDeactivate(EventArgs _0023_003Dz9I8ZVlc_003D)
		{
			base.Owner = null;
			base.OnDeactivate(_0023_003Dz9I8ZVlc_003D);
			if (!_0023_003DzJmJQUAUl_k1ubqKmpw_003D_003D)
			{
				_0023_003DzCoXI3hw_003D = true;
			}
			Hide();
		}
	}

	private sealed class _0023_003Dzls7gyKE_003D : IWindowsFormsEditorService, IServiceProvider
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ColorPicker _0023_003DzqkzYmzE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dz_0024W6XCK97EhLq _0023_003DzqSrwmueKmW0g;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzCoXI3hw_003D;

		public _0023_003Dzls7gyKE_003D(ColorPicker _0023_003Dz7AorRIk_003D)
		{
			_0023_003DzqkzYmzE_003D = _0023_003Dz7AorRIk_003D;
		}

		public bool _0023_003Dz3lE0aY8w9eEG()
		{
			return _0023_003DzCoXI3hw_003D;
		}

		public void CloseDropDown()
		{
			if (_0023_003DzqSrwmueKmW0g != null)
			{
				_0023_003DzqSrwmueKmW0g._0023_003Dz25AXz_HR4EsH();
			}
		}

		public void DropDownControl(System.Windows.Forms.Control _0023_003Dznpp9uyU_003D)
		{
			_0023_003DzCoXI3hw_003D = false;
			_0023_003DzqSrwmueKmW0g = new _0023_003Dz_0024W6XCK97EhLq();
			_0023_003DzqSrwmueKmW0g.Bounds = _0023_003Dznpp9uyU_003D.Bounds;
			_0023_003DzqSrwmueKmW0g._0023_003DzrMNj1x0_003D(_0023_003Dznpp9uyU_003D);
			System.Windows.Forms.Control control = _0023_003Dz3LVmu9209B3S(_0023_003DzqkzYmzE_003D);
			if (control != null && control is Form)
			{
				_0023_003DzqSrwmueKmW0g.Owner = (Form)control;
			}
			_0023_003DzthLJpacCPs_1OdPnrg_003D_003D();
			_0023_003DzqSrwmueKmW0g.Show();
			_0023_003DzNc_0024Nrfx1HtbQ();
			_0023_003DzCoXI3hw_003D = _0023_003DzqSrwmueKmW0g._0023_003Dz3lE0aY8w9eEG();
			_0023_003DzqSrwmueKmW0g.Dispose();
			_0023_003DzqSrwmueKmW0g = null;
		}

		public DialogResult ShowDialog(Form _0023_003Dzr1mjhy4_003D)
		{
			throw new NotSupportedException();
		}

		public object GetService(Type _0023_003DzdFQpxZI_003D)
		{
			if (_0023_003DzdFQpxZI_003D.Equals(typeof(IWindowsFormsEditorService)))
			{
				return this;
			}
			return null;
		}

		private void _0023_003DzNc_0024Nrfx1HtbQ()
		{
			while (_0023_003DzqSrwmueKmW0g.Visible)
			{
				Application.DoEvents();
				_0023_003DzpVpCALUpGwuqYUrSgA_003D_003D(1, IntPtr.Zero, 1, 5, 255);
			}
		}

		[DllImport("User32", EntryPoint = "MsgWaitForMultipleObjects", SetLastError = true)]
		private static extern int _0023_003DzpVpCALUpGwuqYUrSgA_003D_003D(int _0023_003DzumNsN_c_003D, IntPtr _0023_003DzM3Mt7AQ_003D, short _0023_003DzY_0024xhmMXxiL3L, int _0023_003DzG6TbRW54kOY6, int _0023_003DzomYVYusUubFQ);

		private void _0023_003DzthLJpacCPs_1OdPnrg_003D_003D()
		{
			Point location = _0023_003DzqkzYmzE_003D.Parent.PointToScreen(_0023_003DzqkzYmzE_003D.Location);
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			if (location.X < workingArea.X)
			{
				location.X = workingArea.X;
			}
			else if (location.X + _0023_003DzqSrwmueKmW0g.Width > workingArea.Right)
			{
				location.X = workingArea.Right - _0023_003DzqSrwmueKmW0g.Width;
			}
			if (location.Y + _0023_003DzqkzYmzE_003D.Height + _0023_003DzqSrwmueKmW0g.Height > workingArea.Bottom)
			{
				location.Offset(0, -_0023_003DzqSrwmueKmW0g.Height);
			}
			else
			{
				location.Offset(0, _0023_003DzqkzYmzE_003D.Height);
			}
			_0023_003DzqSrwmueKmW0g.Location = location;
		}

		private System.Windows.Forms.Control _0023_003Dz3LVmu9209B3S(System.Windows.Forms.Control _0023_003DzAHes4Iw_003D)
		{
			while (_0023_003DzAHes4Iw_003D.Parent != null)
			{
				_0023_003DzAHes4Iw_003D = _0023_003DzAHes4Iw_003D.Parent;
			}
			return _0023_003DzAHes4Iw_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox _0023_003Dzz4aQcrMALX37BRkztQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox _0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzG52vi6FLFz5p = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dzls7gyKE_003D _0023_003DzLEnVgOmckP_0024f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler _0023_003Dz2mWJ75s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzyJjK_pKYAhgc;

	[Description("The currently selected color.")]
	[Category("Appearance")]
	[DefaultValue(typeof(Color), "Black")]
	public Color Color
	{
		get
		{
			return _0023_003DzFW3vSa4uTflX().BackColor;
		}
		set
		{
			_0023_003Dzu0GKswI_003D(value);
			if (_0023_003Dz2mWJ75s_003D != null)
			{
				_0023_003Dz2mWJ75s_003D(this, EventArgs.Empty);
			}
		}
	}

	[Description("True meanse the control displays the currently selected color's name, False otherwise.")]
	[Category("Appearance")]
	[DefaultValue(true)]
	public bool TextDisplayed
	{
		get
		{
			return _0023_003DzG52vi6FLFz5p;
		}
		set
		{
			_0023_003DzG52vi6FLFz5p = value;
			_0023_003Dzu0GKswI_003D(Color);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	public event EventHandler ColorChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _0023_003Dz2mWJ75s_003D;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz2mWJ75s_003D, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _0023_003Dz2mWJ75s_003D;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz2mWJ75s_003D, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ColorPicker(Color c)
	{
		_0023_003DzFiDziNYCYV76(new CheckBox());
		_0023_003DzFW3vSa4uTflX().Appearance = Appearance.Button;
		_0023_003DzFW3vSa4uTflX().Dock = DockStyle.Left;
		_0023_003DzFW3vSa4uTflX().TextAlign = ContentAlignment.MiddleCenter;
		_0023_003Dzu0GKswI_003D(c);
		base.Controls.Add(_0023_003DzFW3vSa4uTflX());
		_0023_003Dzfd_uSTyc9mnCR6FWBw_003D_003D(new CheckBox());
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Appearance = Appearance.Button;
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Dock = DockStyle.Right;
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().BackgroundImage = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz_leWhi_1Rp_0024S();
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().BackgroundImageLayout = ImageLayout.Center;
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Size = new Size(base.Size.Height, base.Size.Height);
		base.Controls.Add(_0023_003Dzonz1mtFuZs13q8No0w_003D_003D());
		_0023_003DzLEnVgOmckP_0024f = new _0023_003Dzls7gyKE_003D(this);
	}

	public ColorPicker()
		: this(Color.FromName(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313373)))
	{
	}

	private CheckBox _0023_003DzFW3vSa4uTflX()
	{
		return _0023_003Dzz4aQcrMALX37BRkztQ_003D_003D;
	}

	private void _0023_003DzFiDziNYCYV76(CheckBox _0023_003Dzu52ZPXg_003D)
	{
		if (_0023_003Dzz4aQcrMALX37BRkztQ_003D_003D != null)
		{
			_0023_003Dzz4aQcrMALX37BRkztQ_003D_003D.CheckStateChanged -= delegate
			{
				if (!_0023_003DzyJjK_pKYAhgc)
				{
					_0023_003DzyJjK_pKYAhgc = true;
					if (_0023_003DzFW3vSa4uTflX().CheckState == CheckState.Checked || _0023_003Dzonz1mtFuZs13q8No0w_003D_003D().CheckState == CheckState.Checked)
					{
						_0023_003Dzlpkr0vbN_e_h();
						CheckBox checkBox = _0023_003DzFW3vSa4uTflX();
						bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = true);
						checkBox.Checked = flag;
					}
					else
					{
						_0023_003Dz25AXz_HR4EsH();
						CheckBox checkBox2 = _0023_003DzFW3vSa4uTflX();
						bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = false);
						checkBox2.Checked = flag;
					}
					_0023_003DzyJjK_pKYAhgc = false;
				}
			};
		}
		_0023_003Dzz4aQcrMALX37BRkztQ_003D_003D = _0023_003Dzu52ZPXg_003D;
		if (_0023_003Dzz4aQcrMALX37BRkztQ_003D_003D == null)
		{
			return;
		}
		_0023_003Dzz4aQcrMALX37BRkztQ_003D_003D.CheckStateChanged += delegate
		{
			if (!_0023_003DzyJjK_pKYAhgc)
			{
				_0023_003DzyJjK_pKYAhgc = true;
				if (_0023_003DzFW3vSa4uTflX().CheckState == CheckState.Checked || _0023_003Dzonz1mtFuZs13q8No0w_003D_003D().CheckState == CheckState.Checked)
				{
					_0023_003Dzlpkr0vbN_e_h();
					CheckBox checkBox = _0023_003DzFW3vSa4uTflX();
					bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = true);
					checkBox.Checked = flag;
				}
				else
				{
					_0023_003Dz25AXz_HR4EsH();
					CheckBox checkBox2 = _0023_003DzFW3vSa4uTflX();
					bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = false);
					checkBox2.Checked = flag;
				}
				_0023_003DzyJjK_pKYAhgc = false;
			}
		};
	}

	private CheckBox _0023_003Dzonz1mtFuZs13q8No0w_003D_003D()
	{
		return _0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D;
	}

	private void _0023_003Dzfd_uSTyc9mnCR6FWBw_003D_003D(CheckBox _0023_003Dzu52ZPXg_003D)
	{
		if (_0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D != null)
		{
			_0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D.Click -= delegate
			{
				if (!_0023_003DzyJjK_pKYAhgc)
				{
					_0023_003DzyJjK_pKYAhgc = true;
					if (_0023_003DzFW3vSa4uTflX().CheckState == CheckState.Checked || _0023_003Dzonz1mtFuZs13q8No0w_003D_003D().CheckState == CheckState.Checked)
					{
						_0023_003Dzlpkr0vbN_e_h();
						CheckBox checkBox = _0023_003DzFW3vSa4uTflX();
						bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = true);
						checkBox.Checked = flag;
					}
					else
					{
						_0023_003Dz25AXz_HR4EsH();
						CheckBox checkBox2 = _0023_003DzFW3vSa4uTflX();
						bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = false);
						checkBox2.Checked = flag;
					}
					_0023_003DzyJjK_pKYAhgc = false;
				}
			};
		}
		_0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D = _0023_003Dzu52ZPXg_003D;
		if (_0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D == null)
		{
			return;
		}
		_0023_003DzJvdCPLV99CbvXXF6YktYRjY_003D.Click += delegate
		{
			if (!_0023_003DzyJjK_pKYAhgc)
			{
				_0023_003DzyJjK_pKYAhgc = true;
				if (_0023_003DzFW3vSa4uTflX().CheckState == CheckState.Checked || _0023_003Dzonz1mtFuZs13q8No0w_003D_003D().CheckState == CheckState.Checked)
				{
					_0023_003Dzlpkr0vbN_e_h();
					CheckBox checkBox = _0023_003DzFW3vSa4uTflX();
					bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = true);
					checkBox.Checked = flag;
				}
				else
				{
					_0023_003Dz25AXz_HR4EsH();
					CheckBox checkBox2 = _0023_003DzFW3vSa4uTflX();
					bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = false);
					checkBox2.Checked = flag;
				}
				_0023_003DzyJjK_pKYAhgc = false;
			}
		};
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Size = new Size(base.Size.Height, base.Size.Height);
		_0023_003DzFW3vSa4uTflX().Size = new Size(base.Size.Width - base.Size.Height, base.Size.Height);
	}

	private void _0023_003Dzu0GKswI_003D(Color _0023_003DziiEv3wQ_003D)
	{
		_0023_003DzFW3vSa4uTflX().BackColor = _0023_003DziiEv3wQ_003D;
		_0023_003DzFW3vSa4uTflX().ForeColor = _0023_003DzxVHKvgiHHvTq(_0023_003DziiEv3wQ_003D);
		if (_0023_003DzG52vi6FLFz5p)
		{
			_0023_003DzFW3vSa4uTflX().Text = _0023_003DziiEv3wQ_003D.Name;
		}
		else
		{
			_0023_003DzFW3vSa4uTflX().Text = string.Empty;
		}
	}

	private Color _0023_003DzxVHKvgiHHvTq(Color _0023_003DziiEv3wQ_003D)
	{
		if (Convert.ToInt32(_0023_003DziiEv3wQ_003D.R) + Convert.ToInt32(_0023_003DziiEv3wQ_003D.G) + Convert.ToInt32(_0023_003DziiEv3wQ_003D.B) > 382)
		{
			return Color.Black;
		}
		return Color.White;
	}

	private void _0023_003DzXB_0024Zsr5_q8Wn(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (!_0023_003DzyJjK_pKYAhgc)
		{
			_0023_003DzyJjK_pKYAhgc = true;
			if (_0023_003DzFW3vSa4uTflX().CheckState == CheckState.Checked || _0023_003Dzonz1mtFuZs13q8No0w_003D_003D().CheckState == CheckState.Checked)
			{
				_0023_003Dzlpkr0vbN_e_h();
				CheckBox checkBox = _0023_003DzFW3vSa4uTflX();
				bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = true);
				checkBox.Checked = flag;
			}
			else
			{
				_0023_003Dz25AXz_HR4EsH();
				CheckBox checkBox2 = _0023_003DzFW3vSa4uTflX();
				bool flag = (_0023_003Dzonz1mtFuZs13q8No0w_003D_003D().Checked = false);
				checkBox2.Checked = flag;
			}
			_0023_003DzyJjK_pKYAhgc = false;
		}
	}

	private void _0023_003Dzlpkr0vbN_e_h()
	{
		try
		{
			object obj = new ColorEditor().EditValue(value: Color, provider: _0023_003DzLEnVgOmckP_0024f);
			if (obj != null && !_0023_003DzLEnVgOmckP_0024f._0023_003Dz3lE0aY8w9eEG())
			{
				Color = (Color)obj;
			}
			_0023_003DzFW3vSa4uTflX().CheckState = CheckState.Unchecked;
		}
		catch (Exception)
		{
		}
	}

	private void _0023_003Dz25AXz_HR4EsH()
	{
		_0023_003DzLEnVgOmckP_0024f.CloseDropDown();
	}
}
