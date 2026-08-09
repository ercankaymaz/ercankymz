using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using devDept.Diagnostic;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Eyeshot.Milling;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ViewportConverter))]
public class Viewport : DisposableBase, IViewport, ICloneable, IViewportInternal, IUserInterfaceElement, IUserInterfaceElementBase
{
	internal sealed class _0023_003Dz7XrVzbNXMo8q
	{
		public bool _0023_003DzshGHYXMIRfsi;

		public Color _0023_003DzNLGcq5k_003D;

		public Workspace _0023_003Dzy4MPItw_003D;

		public Size _0023_003DzxFNeIFWItLae;

		public RectangleF _0023_003DzLCFtN0k_003D;

		public float _0023_003DzCzsr4CTVr_Ea;

		public float _0023_003DzCs_ZxbN2mZ30;

		public bool _0023_003DzbUBvby4V64DY;

		public bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D;

		public bool _0023_003Dz0W4nCS2oJwWK;

		public bool _0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D;

		public bool _0023_003DzmAezgho6pU2i;

		public TextureBase _0023_003Dzjgn1DPI_003D;

		public IUserInterfaceElement _0023_003Dz_0024wNiWEC_IG_0024k;

		public RenderContextBase.drawSceneFuncDelegate _0023_003DzHdL9CKamSnvn;

		private Size _0023_003DznG6txhfx0o1q;

		public _0023_003Dz7XrVzbNXMo8q()
		{
			_0023_003DzNLGcq5k_003D = Color.White;
		}
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ToolBar, bool> _0023_003DzAhnLnWfi98H7bA6ZbQ_003D_003D;

		public static Func<ToolBar, bool> _0023_003DzkAdtYdjlOba4Yb7DCQ_003D_003D;

		public static Func<OriginSymbol, bool> _0023_003Dz0IHx0EcMeecGjct_00247Q_003D_003D;

		public static Func<devDept.Eyeshot.Control.Labels.Label, bool> _0023_003Dz_0024cTq2wJPTmEsiThCFQ_003D_003D;

		public static Func<devDept.Eyeshot.Control.Labels.Label, bool> _0023_003DzZTYtBtoCFWNBraj16A_003D_003D;

		internal bool _0023_003DzHRlY7RdCpPxlYL61ELCI76W3ZKXg(ToolBar _0023_003Dz8GBMuoM_003D)
		{
			return !_0023_003Dz8GBMuoM_003D._0023_003Dz6IiAnIkiGeJ4c1d3fnMBUNw_003D();
		}

		internal bool _0023_003DzDO2YN9mgqCrH_7FeV7WwIyU_003D(ToolBar _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D._0023_003DzL28lpFu5le27();
		}

		internal bool _0023_003DzluskAhxwYC5A4NeVyo3_0024YaY_003D(OriginSymbol _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D?._0023_003DzL28lpFu5le27() ?? false;
		}

		internal bool _0023_003Dz_yksj_xQrtsp862atv9WbEcgqjy_(devDept.Eyeshot.Control.Labels.Label _0023_003DzevtAwuM_003D)
		{
			return _0023_003DzevtAwuM_003D.AutoHide;
		}

		internal bool _0023_003DzdPWxYkv0iE8a7L4of0qQOvTas07_0024(devDept.Eyeshot.Control.Labels.Label _0023_003Dz8l4HZIo_003D)
		{
			return _0023_003Dz8l4HZIo_003D.AutoHide;
		}
	}

	[TypeConverter(typeof(SavedViewsConverter))]
	public class SavedViewsManager : ICloneable
	{
		public class ViewEventArgs : ICloneable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private Point3D _0023_003Dz4NQ1ESapn5zvwWkt_0024Q_003D_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private Quaternion _0023_003Dz_0024bT0ta1oZK3XD5vWBg_003D_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private double _0023_003Dzc_0024TcfrmWC_0024NRxcAYBg_003D_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private projectionType _0023_003DzEwCqB81vIoZ4dsVSEywlw5s_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private double _0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D;

			public Point3D Target
			{
				[CompilerGenerated]
				get
				{
					return _0023_003Dz4NQ1ESapn5zvwWkt_0024Q_003D_003D;
				}
				[CompilerGenerated]
				set
				{
					_0023_003Dz4NQ1ESapn5zvwWkt_0024Q_003D_003D = value;
				}
			}

			public Quaternion Rotation
			{
				[CompilerGenerated]
				get
				{
					return _0023_003Dz_0024bT0ta1oZK3XD5vWBg_003D_003D;
				}
				[CompilerGenerated]
				set
				{
					_0023_003Dz_0024bT0ta1oZK3XD5vWBg_003D_003D = value;
				}
			}

			public double Distance
			{
				[CompilerGenerated]
				get
				{
					return _0023_003Dzc_0024TcfrmWC_0024NRxcAYBg_003D_003D;
				}
				[CompilerGenerated]
				set
				{
					_0023_003Dzc_0024TcfrmWC_0024NRxcAYBg_003D_003D = value;
				}
			}

			public projectionType ProjectionMode
			{
				[CompilerGenerated]
				get
				{
					return _0023_003DzEwCqB81vIoZ4dsVSEywlw5s_003D;
				}
				[CompilerGenerated]
				set
				{
					_0023_003DzEwCqB81vIoZ4dsVSEywlw5s_003D = value;
				}
			}

			public double ZoomFactor
			{
				[CompilerGenerated]
				get
				{
					return _0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D;
				}
				[CompilerGenerated]
				set
				{
					_0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D = value;
				}
			}

			public ViewEventArgs(ViewEventArgs another)
			{
				Target = (Point3D)another.Target.Clone();
				Rotation = (Quaternion)another.Rotation.Clone();
				Distance = another.Distance;
				ProjectionMode = another.ProjectionMode;
				ZoomFactor = another.ZoomFactor;
			}

			public ViewEventArgs(Camera camera)
			{
				Target = camera.Target;
				Rotation = camera.Rotation;
				Distance = camera.Distance;
				ProjectionMode = camera.ProjectionMode;
				ZoomFactor = camera.ZoomFactor;
			}

			public void Restore(Camera camera)
			{
				camera.ProjectionMode = ProjectionMode;
				camera.Target = Target;
				camera.Rotation = Rotation;
				camera.Distance = Distance;
				camera.ZoomFactor = ZoomFactor;
			}

			public virtual object Clone()
			{
				return new ViewEventArgs(this);
			}

			public static bool operator ==(ViewEventArgs left, ViewEventArgs right)
			{
				return object.Equals(left, right);
			}

			public bool Equals(ViewEventArgs obj)
			{
				if ((object)obj == null)
				{
					return false;
				}
				if ((object)this == obj)
				{
					return true;
				}
				if (Target != obj.Target)
				{
					return false;
				}
				if (Utility.Compare(Distance, obj.Distance) != 0)
				{
					return false;
				}
				if (Utility.Compare(ZoomFactor, obj.ZoomFactor) != 0)
				{
					return false;
				}
				if (ProjectionMode != obj.ProjectionMode)
				{
					return false;
				}
				if (Rotation != obj.Rotation)
				{
					return false;
				}
				return true;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (this == obj)
				{
					return true;
				}
				if (obj.GetType() != typeof(ViewEventArgs))
				{
					return false;
				}
				return Equals((ViewEventArgs)obj);
			}

			public static bool operator !=(ViewEventArgs left, ViewEventArgs right)
			{
				return !object.Equals(left, right);
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal Viewport _0023_003Dzn3NpqgY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU2oeWx4biJW_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LinkedList<ViewEventArgs> _0023_003Dzjc4gJTN3KQlQ = new LinkedList<ViewEventArgs>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LinkedListNode<ViewEventArgs> _0023_003Dz_0024Q9nVt4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzKFUreKCtSAuA;

		[Browsable(false)]
		public int NumberOfPrevious
		{
			get
			{
				if (_0023_003Dz_0024Q9nVt4_003D == null)
				{
					return 0;
				}
				LinkedListNode<ViewEventArgs> linkedListNode = _0023_003Dzjc4gJTN3KQlQ.First;
				int num = 0;
				while (linkedListNode != _0023_003Dz_0024Q9nVt4_003D && linkedListNode != null)
				{
					linkedListNode = linkedListNode.Next;
					num++;
				}
				return num;
			}
		}

		[Browsable(false)]
		public int NumberOfNext
		{
			get
			{
				if (_0023_003Dz_0024Q9nVt4_003D == null)
				{
					return _0023_003Dzjc4gJTN3KQlQ.Count;
				}
				LinkedListNode<ViewEventArgs> next = _0023_003Dz_0024Q9nVt4_003D.Next;
				int num = 0;
				while (next != null)
				{
					num++;
					next = next.Next;
				}
				return num;
			}
		}

		[Description("Maximum number of saved views.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int MaximumNumber
		{
			get
			{
				return _0023_003DzU2oeWx4biJW_;
			}
			set
			{
				Clear();
				_0023_003DzU2oeWx4biJW_ = value;
			}
		}

		static SavedViewsManager()
		{
			_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
			object[] array = null;
			array = new object[1] { _0023_003DzL07WkTo_003D };
			_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
		}

		public SavedViewsManager(SavedViewsManager another)
		{
			MaximumNumber = another.MaximumNumber;
			_0023_003Dzjc4gJTN3KQlQ = new LinkedList<ViewEventArgs>();
			foreach (ViewEventArgs item in _0023_003Dzjc4gJTN3KQlQ)
			{
				_0023_003Dzjc4gJTN3KQlQ.AddLast((ViewEventArgs)item.Clone());
			}
		}

		public SavedViewsManager()
			: this(_0023_003DzPQkuRLiTnRyZ())
		{
		}

		public SavedViewsManager(int maximumNumber)
		{
			MaximumNumber = maximumNumber;
		}

		public void Clear()
		{
			_0023_003Dzjc4gJTN3KQlQ.Clear();
			_0023_003Dz_0024Q9nVt4_003D = null;
		}

		public void Suspend()
		{
			_0023_003DzKFUreKCtSAuA = true;
		}

		public void Resume()
		{
			_0023_003DzKFUreKCtSAuA = false;
		}

		internal void _0023_003DzBWHJkhEXTRTU()
		{
			if (_0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D)
			{
				_0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D = false;
				if (_0023_003Dzn3NpqgY_003D._0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D != null)
				{
					_0023_003Dzn3NpqgY_003D._0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D(_0023_003Dzn3NpqgY_003D, _0023_003Dz_0024Q9nVt4_003D.Value);
				}
			}
			else
			{
				Save();
			}
		}

		public void Save()
		{
			if (_0023_003DzKFUreKCtSAuA || _0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D)
			{
				return;
			}
			ViewEventArgs e = new ViewEventArgs(_0023_003Dzn3NpqgY_003D.Camera);
			if (_0023_003Dz_0024Q9nVt4_003D == null)
			{
				if (NumberOfPrevious == 0)
				{
					_0023_003Dzjc4gJTN3KQlQ.Clear();
				}
			}
			else
			{
				while (_0023_003Dz_0024Q9nVt4_003D.Next != null)
				{
					_0023_003Dzjc4gJTN3KQlQ.Remove(_0023_003Dz_0024Q9nVt4_003D.Next);
				}
				if (_0023_003Dz_0024Q9nVt4_003D.Value == e)
				{
					return;
				}
			}
			_0023_003Dzjc4gJTN3KQlQ.AddLast(e);
			_0023_003Dz_0024Q9nVt4_003D = _0023_003Dzjc4gJTN3KQlQ.Last;
			if (_0023_003Dzjc4gJTN3KQlQ.Count > _0023_003DzU2oeWx4biJW_)
			{
				_0023_003Dzjc4gJTN3KQlQ.RemoveFirst();
			}
			if (_0023_003Dzn3NpqgY_003D._0023_003DzzBfPzNI_003D != null)
			{
				_0023_003Dzn3NpqgY_003D._0023_003DzzBfPzNI_003D(_0023_003Dzn3NpqgY_003D, e);
			}
		}

		public void Previous()
		{
			if ((_0023_003Dz_0024Q9nVt4_003D != null || NumberOfPrevious != 0) && !_0023_003Dzn3NpqgY_003D._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
			{
				if (_0023_003Dz_0024Q9nVt4_003D == null)
				{
					_0023_003Dz_0024Q9nVt4_003D = _0023_003Dzjc4gJTN3KQlQ.Last;
				}
				_0023_003Dz_0024Q9nVt4_003D = _0023_003Dz_0024Q9nVt4_003D.Previous;
				if (_0023_003Dz_0024Q9nVt4_003D != null)
				{
					_0023_003Dz_0024VKnf4K46Rz5();
				}
				else
				{
					_0023_003Dz_0024Q9nVt4_003D = _0023_003Dzjc4gJTN3KQlQ.First;
				}
				_0023_003Dzn3NpqgY_003D.AdjustNearAndFarPlanes();
			}
		}

		public void Next()
		{
			if ((_0023_003Dz_0024Q9nVt4_003D != null || NumberOfNext != 0) && !_0023_003Dzn3NpqgY_003D._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
			{
				if (_0023_003Dz_0024Q9nVt4_003D == null)
				{
					_0023_003Dz_0024Q9nVt4_003D = _0023_003Dzjc4gJTN3KQlQ.First;
				}
				_0023_003Dz_0024Q9nVt4_003D = _0023_003Dz_0024Q9nVt4_003D.Next;
				if (_0023_003Dz_0024Q9nVt4_003D != null)
				{
					_0023_003Dz_0024VKnf4K46Rz5();
				}
				else
				{
					_0023_003Dz_0024Q9nVt4_003D = _0023_003Dzjc4gJTN3KQlQ.Last;
				}
				_0023_003Dzn3NpqgY_003D.AdjustNearAndFarPlanes();
			}
		}

		private void _0023_003Dz_0024VKnf4K46Rz5()
		{
			_0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D = true;
			_0023_003Dzn3NpqgY_003D.Camera.ProjectionMode = _0023_003Dz_0024Q9nVt4_003D.Value.ProjectionMode;
			_0023_003Dzn3NpqgY_003D.SetView(_0023_003Dz_0024Q9nVt4_003D.Value.Rotation, _0023_003Dz_0024Q9nVt4_003D.Value.Target, _0023_003Dz_0024Q9nVt4_003D.Value.Distance, _0023_003Dz_0024Q9nVt4_003D.Value.ZoomFactor);
			if (!_0023_003Dzn3NpqgY_003D._0023_003Dz0TvaYNo_003D.AnimateCamera)
			{
				_0023_003Dzyhlf1jVbqwNLWYrk7Q_003D_003D = false;
				if (_0023_003Dzn3NpqgY_003D._0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D != null)
				{
					_0023_003Dzn3NpqgY_003D._0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D(_0023_003Dzn3NpqgY_003D, _0023_003Dz_0024Q9nVt4_003D.Value);
				}
			}
		}

		private static int _0023_003DzPQkuRLiTnRyZ()
		{
			return 8;
		}

		public virtual object Clone()
		{
			return new SavedViewsManager(this);
		}

		internal bool _0023_003Dz4XAvJ5aCRLKs(SavedViewsManager _0023_003DzAbAO3f4_003D)
		{
			return MaximumNumber != _0023_003DzAbAO3f4_003D.MaximumNumber;
		}
	}

	public delegate void UpdateGraphicsHandler();

	public delegate void ViewRestoredHandler(object sender, SavedViewsManager.ViewEventArgs e);

	public delegate void ViewSavedEventHandler(object sender, SavedViewsManager.ViewEventArgs e);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Vector3D _0023_003DzF3n3vDE_003D = new Vector3D(0.0, 0.0, 0.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzecyGgNmi_gHSE5rozuTdmViP0SuHgkFLUA_003D_003D = 20.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UpdateGraphicsHandler _0023_003DzGBZgP_0024g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Workspace _0023_003Dz0TvaYNo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SavedViewsManager _0023_003DzmRv1YOfzt2TT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float _0023_003DzIjzPUT72VTAG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003DzWYBO1c4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzgTjCWc4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzZ_0024IejP0R_0024_Cw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ToolBar[] _0023_003DzXldEn8dxMaC2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBar _0023_003DziEOSyE543t4chjccPw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal displayType _0023_003DzK_00241ezHQJ9Z3c = _0023_003DzuZSYlpGVHVDP();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ScaleBar _0023_003Dz5tj8j11PShCE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzwfKBrot1LuuC = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzyBPwOa1siDegABKoKg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dze_0024CNZ_Memiiw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzl8iYFG8_0024fwR_0024 = 10;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_YdQ6QENQ_6w;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Grid[] _0023_003Dzmm4AR2_v0bxl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal OriginSymbol[] _0023_003DzMUeJTCp30C0O;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Legend[] _0023_003Dz6SHaVGO9Xhk5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BackgroundSettings _0023_003Dz2bwAPoQwFwzX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace.SelectionChangedEventHandler _0023_003DzT6PtKP0Nd2u9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Camera.ViewAnimator _0023_003DzDjhJAu3TqX_chipY9w_003D_003D = new Camera.ViewPositionAnimator();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzzYz_GKqrxJj2Y_0024cofw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal CoordinateSystemIcon _0023_003DzFfOjsSRCbzpd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Histogram _0023_003DznPu5SKE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ViewCubeIcon _0023_003Dz4ry2vZefVkxX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ViewSavedEventHandler _0023_003DzzBfPzNI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ViewSavedEventHandler _0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Dictionary<shaderType, IShaderTechnique> _0023_003DzSSWqFoUldB87dazEjA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ILabelFactory _0023_003DzvNOHJE5oNS5SePyH9cyIVLnA0oC0sZgIvA2Z0tggGzaY6ZM6Lg_003D_003D = new _0023_003DzMnIJwbhtChS2KE7grYiDXALwkYSgeRt1T9siSJA_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal LabelList _0023_003DzF5TdZcc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLvweZtO44VEY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLIwPv16B13qilCw_jA_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzKcjcHP9Ku7D9 = Color.Gray;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal long _0023_003DzZUaotclMqnW0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DzdrGk9pgq7KoJ = new Vector3D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzDCV7KMgcH_0024l5stDfAA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal System.Drawing.Point _0023_003Dzl94UA_0024lVBcra;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal RotateSettings _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal NavigationSettings _0023_003DzfUoqKzYFbxTn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ZoomSettings _0023_003DzwmhQ1QBAhe1s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal PanSettings _0023_003DzeOnNd5rq7WMN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzTH_0024xtLSkHa0V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera.navigationType _0023_003Dz_tpIHYJrCA7U;

	IRotateSettings IViewport.Rotate => Rotate;

	IBackgroundSettings IViewport.Background => Background;

	public string InstanceId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Saved views settings.")]
	public SavedViewsManager SavedViews
	{
		get
		{
			return _0023_003DzmRv1YOfzt2TT;
		}
		set
		{
			_0023_003DzmRv1YOfzt2TT = value;
			_0023_003DzmRv1YOfzt2TT._0023_003Dzn3NpqgY_003D = this;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The coordinates of the upper-left corner of the viewport relative to the upper-left corner of its container.")]
	public System.Drawing.Point Location
	{
		get
		{
			return _0023_003DzWYBO1c4_003D;
		}
		set
		{
			_0023_003DzWYBO1c4_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The size of the viewport in pixels.")]
	public Size Size
	{
		get
		{
			return _0023_003DzgTjCWc4_003D;
		}
		set
		{
			_0023_003DzgTjCWc4_003D = value;
			if (_0023_003DzgTjCWc4_003D.Width < 1 || _0023_003DzgTjCWc4_003D.Height < 1)
			{
				_0023_003DzgTjCWc4_003D = new Size(Math.Max(1, _0023_003DzgTjCWc4_003D.Width), Math.Max(1, _0023_003DzgTjCWc4_003D.Height));
			}
			Camera.UpdateSize(Size);
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzjDuhintYzbDe(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: false);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Camera settings.")]
	public Camera Camera
	{
		get
		{
			return _0023_003DzZ_0024IejP0R_0024_Cw;
		}
		set
		{
			if (_0023_003DzZ_0024IejP0R_0024_Cw != null)
			{
				_0023_003DzZ_0024IejP0R_0024_Cw.Dispose();
			}
			_0023_003DzZ_0024IejP0R_0024_Cw = value;
			if (_0023_003DzZ_0024IejP0R_0024_Cw != null)
			{
				if (_0023_003Dz0TvaYNo_003D != null)
				{
					_0023_003DzZ_0024IejP0R_0024_Cw.SetRenderContext(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
				}
				_0023_003DzZ_0024IejP0R_0024_Cw.UpdateSize(Size);
				_0023_003DzZ_0024IejP0R_0024_Cw.RecomputeViewport(Size);
				if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
				{
					_0023_003DzZ_0024IejP0R_0024_Cw.UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
				}
				_0023_003DzZ_0024IejP0R_0024_Cw.projectedMin = Point3D.Origin;
				_0023_003DzZ_0024IejP0R_0024_Cw.projectedMax = new Point3D(1.0, 1.0, 1.0);
				if (_0023_003Dz0TvaYNo_003D != null)
				{
					_0023_003DzZ_0024IejP0R_0024_Cw.sharedData = _0023_003Dz0TvaYNo_003D._0023_003DzB63nHjW2QzvePp6sgQ_003D_003D;
					AdjustNearAndFarPlanes();
					_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
				}
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Toolbar settings.")]
	public ToolBar ToolBar
	{
		get
		{
			if (_0023_003DzXldEn8dxMaC2 == null || _0023_003DzXldEn8dxMaC2.Length == 0)
			{
				return null;
			}
			return _0023_003DzXldEn8dxMaC2[0];
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("User Interface")]
	[Description("ToolBar settings.")]
	[Editor("devDept.Eyeshot.Designer.Converters.ToolBarCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	public ToolBar[] ToolBars
	{
		get
		{
			return _0023_003DzXldEn8dxMaC2;
		}
		set
		{
			_0023_003DzXldEn8dxMaC2 = value;
			_0023_003Dz0TvaYNo_003D?._0023_003Dzk4Sj9EO3_i4N(this);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Active display mode.")]
	public displayType DisplayMode
	{
		get
		{
			return _0023_003DzK_00241ezHQJ9Z3c;
		}
		set
		{
			_0023_003Dze5zV_b_HQ_0024C_0024(value, this);
		}
	}

	[Category("User Interface")]
	[Description("ScaleBar settings.")]
	[NotifyParentProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ScaleBar ScaleBar
	{
		get
		{
			return _0023_003Dz5tj8j11PShCE;
		}
		set
		{
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			if (_0023_003Dz5tj8j11PShCE != null)
			{
				_0023_003Dz5tj8j11PShCE.Dispose();
			}
			_0023_003Dz5tj8j11PShCE = value;
			if (_0023_003Dz5tj8j11PShCE != null)
			{
				_0023_003Dz5tj8j11PShCE.ParentViewport = this;
			}
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements();
				_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Hide/Show")]
	[Description("Labels visibility status")]
	public bool ShowLabels
	{
		get
		{
			return _0023_003DzwfKBrot1LuuC;
		}
		set
		{
			_0023_003DzwfKBrot1LuuC = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Hide/Show")]
	[Description("Model vertices visibility status.")]
	public bool ShowVertices
	{
		get
		{
			return _0023_003DzyBPwOa1siDegABKoKg_003D_003D;
		}
		set
		{
			_0023_003DzyBPwOa1siDegABKoKg_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Hide/Show")]
	[Description("Model vertex indices visibility status.")]
	public bool ShowVertexIndices
	{
		get
		{
			return _0023_003Dze_0024CNZ_Memiiw;
		}
		set
		{
			_0023_003Dze_0024CNZ_Memiiw = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Hide/Show")]
	[Description("Model vertex size.")]
	public int VertexSize
	{
		get
		{
			return _0023_003Dzl8iYFG8_0024fwR_0024;
		}
		set
		{
			if (value < 1)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590120));
			}
			_0023_003Dzl8iYFG8_0024fwR_0024 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Hide/Show")]
	[Description("Auto hide labels flag. If true labels are hidden automatically when behind the model.")]
	[Obsolete("Please refer to Label.AutoHide property.")]
	public bool AutoHideLabels
	{
		get
		{
			return _0023_003Dz_YdQ6QENQ_6w;
		}
		set
		{
			_0023_003Dz_YdQ6QENQ_6w = value;
			foreach (devDept.Eyeshot.Control.Labels.Label label in Labels)
			{
				label.AutoHide = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("First planar grid settings.")]
	public Grid Grid
	{
		get
		{
			if (_0023_003Dzmm4AR2_v0bxl == null || _0023_003Dzmm4AR2_v0bxl.Length == 0)
			{
				return null;
			}
			return _0023_003Dzmm4AR2_v0bxl[0];
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("User Interface")]
	[Description("Planar grids settings.")]
	[Editor("devDept.Eyeshot.Designer.Converters.GridCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	public Grid[] Grids
	{
		get
		{
			return _0023_003Dzmm4AR2_v0bxl;
		}
		set
		{
			_0023_003Dzmm4AR2_v0bxl = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Origin symbol settings.")]
	public OriginSymbol OriginSymbol
	{
		get
		{
			if (_0023_003DzMUeJTCp30C0O == null || _0023_003DzMUeJTCp30C0O.Length == 0)
			{
				return null;
			}
			return _0023_003DzMUeJTCp30C0O[0];
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("User Interface")]
	[Description("OriginSymbol settings array.")]
	[Editor("devDept.Eyeshot.Designer.Converters.OriginSymbolCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	public OriginSymbol[] OriginSymbols
	{
		get
		{
			return _0023_003DzMUeJTCp30C0O;
		}
		set
		{
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			_0023_003DzMUeJTCp30C0O = value;
			OriginSymbol[] originSymbols = OriginSymbols;
			foreach (OriginSymbol originSymbol in originSymbols)
			{
				if (originSymbol != null)
				{
					originSymbol.ParentViewport = this;
					originSymbol.CheckAndFixDefaultLayerName();
				}
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("First legend settings.")]
	public Legend Legend
	{
		get
		{
			if (_0023_003Dz6SHaVGO9Xhk5 == null || _0023_003Dz6SHaVGO9Xhk5.Length == 0)
			{
				return null;
			}
			return _0023_003Dz6SHaVGO9Xhk5[0];
		}
	}

	[Category("User Interface")]
	[Description("Legends settings.")]
	[Editor("devDept.Eyeshot.Designer.Converters.LegendCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	[NotifyParentProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Legend[] Legends
	{
		get
		{
			return _0023_003Dz6SHaVGO9Xhk5;
		}
		set
		{
			_0023_003Dz6SHaVGO9Xhk5 = value;
		}
	}

	[Description("The background settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public BackgroundSettings Background
	{
		get
		{
			return _0023_003Dz2bwAPoQwFwzX;
		}
		set
		{
			if (_0023_003Dz2bwAPoQwFwzX != null)
			{
				_0023_003Dz2bwAPoQwFwzX.ParentViewport = null;
			}
			_0023_003Dz2bwAPoQwFwzX = value;
			if (_0023_003Dz2bwAPoQwFwzX != null)
			{
				_0023_003Dz2bwAPoQwFwzX.ParentViewport = this;
			}
		}
	}

	[Category("User Interface")]
	[Description("Coordinate system icon settings.")]
	[NotifyParentProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public CoordinateSystemIcon CoordinateSystemIcon
	{
		get
		{
			return _0023_003DzFfOjsSRCbzpd;
		}
		set
		{
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			if (_0023_003DzFfOjsSRCbzpd != null)
			{
				_0023_003DzFfOjsSRCbzpd.Dispose();
			}
			_0023_003DzFfOjsSRCbzpd = value;
			if (_0023_003DzFfOjsSRCbzpd != null)
			{
				_0023_003DzFfOjsSRCbzpd.ParentViewport = this;
				_0023_003DzFfOjsSRCbzpd.CheckAndFixDefaultLayerName();
			}
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements();
				_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[Category("User Interface")]
	[Description("Histogram settings.")]
	[NotifyParentProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Histogram Histogram
	{
		get
		{
			return _0023_003DznPu5SKE_003D;
		}
		set
		{
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			if (_0023_003DznPu5SKE_003D != null)
			{
				_0023_003DznPu5SKE_003D.Dispose();
			}
			_0023_003DznPu5SKE_003D = value;
			if (_0023_003DznPu5SKE_003D != null)
			{
				_0023_003DznPu5SKE_003D.ParentViewport = this;
			}
		}
	}

	[Category("User Interface")]
	[Description("View Cube icon settings.")]
	[NotifyParentProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ViewCubeIcon ViewCubeIcon
	{
		get
		{
			return _0023_003Dz4ry2vZefVkxX;
		}
		set
		{
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			if (_0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003Dz4ry2vZefVkxX.Dispose();
			}
			_0023_003Dz4ry2vZefVkxX = value;
			if (_0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003Dz4ry2vZefVkxX.ParentViewport = this;
				_0023_003Dz4ry2vZefVkxX.CheckAndFixDefaultLayerName();
			}
			if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements();
				_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Sort the Labels using the depth from the viewer.")]
	public bool SortLabels
	{
		get
		{
			return _0023_003DzLvweZtO44VEY;
		}
		set
		{
			_0023_003DzLvweZtO44VEY = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public LabelList Labels
	{
		get
		{
			return _0023_003DzF5TdZcc_003D;
		}
		set
		{
			_0023_003DzF5TdZcc_003D = value;
			_0023_003DzF5TdZcc_003D._0023_003DzYzWi5Yw_003D = this;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Commands")]
	[Description("Rotate settings.")]
	public RotateSettings Rotate
	{
		get
		{
			return _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D;
		}
		set
		{
			Workspace._0023_003DzbksQw_5VXML8(value.MouseButton);
			_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D = value;
		}
	}

	[Browsable(false)]
	public Point3D CenterOfRotation => Camera.centerOfRotation;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Commands")]
	[Description("Navigation settings.")]
	public NavigationSettings Navigation
	{
		get
		{
			return _0023_003DzfUoqKzYFbxTn;
		}
		set
		{
			_0023_003DzfUoqKzYFbxTn = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Commands")]
	[Description("Zoom settings.")]
	public ZoomSettings Zoom
	{
		get
		{
			return _0023_003DzwmhQ1QBAhe1s;
		}
		set
		{
			Workspace._0023_003DzbksQw_5VXML8(value.MouseButton);
			_0023_003DzwmhQ1QBAhe1s = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Commands")]
	[Description("Pan settings.")]
	public PanSettings Pan
	{
		get
		{
			return _0023_003DzeOnNd5rq7WMN;
		}
		set
		{
			Workspace._0023_003DzbksQw_5VXML8(value.MouseButton);
			_0023_003DzeOnNd5rq7WMN = value;
		}
	}

	[Browsable(false)]
	internal event UpdateGraphicsHandler UpdateGraphics
	{
		[CompilerGenerated]
		add
		{
			UpdateGraphicsHandler updateGraphicsHandler = _0023_003DzGBZgP_0024g_003D;
			UpdateGraphicsHandler updateGraphicsHandler2;
			do
			{
				updateGraphicsHandler2 = updateGraphicsHandler;
				UpdateGraphicsHandler value2 = (UpdateGraphicsHandler)Delegate.Combine(updateGraphicsHandler2, value);
				updateGraphicsHandler = Interlocked.CompareExchange(ref _0023_003DzGBZgP_0024g_003D, value2, updateGraphicsHandler2);
			}
			while ((object)updateGraphicsHandler != updateGraphicsHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UpdateGraphicsHandler updateGraphicsHandler = _0023_003DzGBZgP_0024g_003D;
			UpdateGraphicsHandler updateGraphicsHandler2;
			do
			{
				updateGraphicsHandler2 = updateGraphicsHandler;
				UpdateGraphicsHandler value2 = (UpdateGraphicsHandler)Delegate.Remove(updateGraphicsHandler2, value);
				updateGraphicsHandler = Interlocked.CompareExchange(ref _0023_003DzGBZgP_0024g_003D, value2, updateGraphicsHandler2);
			}
			while ((object)updateGraphicsHandler != updateGraphicsHandler2);
		}
	}

	[Description("Occurs when label selection has changed.")]
	[Category("Selection")]
	public event Workspace.SelectionChangedEventHandler LabelSelectionChanged
	{
		[CompilerGenerated]
		add
		{
			Workspace.SelectionChangedEventHandler selectionChangedEventHandler = _0023_003DzT6PtKP0Nd2u9;
			Workspace.SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				Workspace.SelectionChangedEventHandler value2 = (Workspace.SelectionChangedEventHandler)Delegate.Combine(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzT6PtKP0Nd2u9, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			Workspace.SelectionChangedEventHandler selectionChangedEventHandler = _0023_003DzT6PtKP0Nd2u9;
			Workspace.SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				Workspace.SelectionChangedEventHandler value2 = (Workspace.SelectionChangedEventHandler)Delegate.Remove(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzT6PtKP0Nd2u9, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
	}

	public event ViewSavedEventHandler ViewSaved
	{
		[CompilerGenerated]
		add
		{
			ViewSavedEventHandler viewSavedEventHandler = _0023_003DzzBfPzNI_003D;
			ViewSavedEventHandler viewSavedEventHandler2;
			do
			{
				viewSavedEventHandler2 = viewSavedEventHandler;
				ViewSavedEventHandler value2 = (ViewSavedEventHandler)Delegate.Combine(viewSavedEventHandler2, value);
				viewSavedEventHandler = Interlocked.CompareExchange(ref _0023_003DzzBfPzNI_003D, value2, viewSavedEventHandler2);
			}
			while ((object)viewSavedEventHandler != viewSavedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ViewSavedEventHandler viewSavedEventHandler = _0023_003DzzBfPzNI_003D;
			ViewSavedEventHandler viewSavedEventHandler2;
			do
			{
				viewSavedEventHandler2 = viewSavedEventHandler;
				ViewSavedEventHandler value2 = (ViewSavedEventHandler)Delegate.Remove(viewSavedEventHandler2, value);
				viewSavedEventHandler = Interlocked.CompareExchange(ref _0023_003DzzBfPzNI_003D, value2, viewSavedEventHandler2);
			}
			while ((object)viewSavedEventHandler != viewSavedEventHandler2);
		}
	}

	public event ViewSavedEventHandler ViewRestored
	{
		[CompilerGenerated]
		add
		{
			ViewSavedEventHandler viewSavedEventHandler = _0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D;
			ViewSavedEventHandler viewSavedEventHandler2;
			do
			{
				viewSavedEventHandler2 = viewSavedEventHandler;
				ViewSavedEventHandler value2 = (ViewSavedEventHandler)Delegate.Combine(viewSavedEventHandler2, value);
				viewSavedEventHandler = Interlocked.CompareExchange(ref _0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D, value2, viewSavedEventHandler2);
			}
			while ((object)viewSavedEventHandler != viewSavedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ViewSavedEventHandler viewSavedEventHandler = _0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D;
			ViewSavedEventHandler viewSavedEventHandler2;
			do
			{
				viewSavedEventHandler2 = viewSavedEventHandler;
				ViewSavedEventHandler value2 = (ViewSavedEventHandler)Delegate.Remove(viewSavedEventHandler2, value);
				viewSavedEventHandler = Interlocked.CompareExchange(ref _0023_003DzUL1pt_JMJH4HDfmMmg_003D_003D, value2, viewSavedEventHandler2);
			}
			while ((object)viewSavedEventHandler != viewSavedEventHandler2);
		}
	}

	static Viewport()
	{
		Type typeFromHandle = typeof(Document);
		object[] array = null;
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2 = null;
		Stream stream = null;
		bool flag = false;
		Exception ex = default(Exception);
		array = new object[2] { typeFromHandle, ex };
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2 = _0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D();
		stream = _0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D();
		try
		{
			flag = (bool)_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzTIoStId_0024_0024GHgBSutm03Gs9I_003D(stream, "aSl,<q\"acn", array);
		}
		finally
		{
			ex = (Exception)array[1];
		}
		if (!flag)
		{
			Exception ex2 = ex;
			object[] array2 = null;
			array2 = new object[1] { ex2 };
			_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "\"TA?\"q\"acS", array2);
		}
	}

	public Viewport()
		: this(_0023_003Dzw8TPRvHHS4hl(), _0023_003DzmuZmjj_0024WEUbi(), _0023_003DzfFA_QshWCz0g(), _0023_003DzUuEDRsCIpmOw(), ToolBar._0023_003Dz7RqBmFdBIbpl(), _0023_003DzQI88UEUjGvywumkl0w_003D_003D(), _0023_003DzKVWnYtP5kRnz(), _0023_003DzuZSYlpGVHVDP(), showLabels: true, showVertices: false, showVertexIndices: false, _0023_003DzPXyrw2E6o4RQGd1eLQ_003D_003D(), _0023_003DzK_0024ClK_0024YmZACa(), sortLabels: false, _0023_003Dz42L6chYC_bJg(), _0023_003Dz8loivQseZbHR(), _0023_003DzGTB7AdJZmaiw(), _0023_003DzB7g_iJWNK2TU(), _0023_003Dz2S256D9h3YRq(), _0023_003Dzh1Aj7zFAmigJ(), _0023_003Dz1f2OmgsPSjqP())
	{
	}

	protected Viewport(Viewport another)
	{
		_0023_003DzshPEPAc_003D(another.Location, another.Size, another._0023_003Dz2bwAPoQwFwzX, another.Camera, another.ToolBars, another.Legends, another.Histogram, another.DisplayMode, another.ShowLabels, another.AutoHideLabels, another.ShowVertices, another.ShowVertexIndices, another.Grids, another.OriginSymbols, another.SortLabels, another.Rotate, another.Zoom, another.Pan, another.Navigation, another._0023_003DzFfOjsSRCbzpd, another.ViewCubeIcon, another.SavedViews, another.ScaleBar, _0023_003DzwmQOnB8_003D: true);
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan, navigation)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, legends, displayMode, showLabels, showVertices, showVertexIndices, autoHideLabels, grid, originSymbol, sortLabels, rotate, zoom, pan, navigation, initialView)
	{
	}

	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, toolBars, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan, navigation, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, viewType initialView)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, showVertices, autoHideLabels, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool autoHideLabels, Grid grid, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, viewType initialView)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, showVertices, autoHideLabels, new Grid[1] { grid }, originSymbol, sortLabels, rotate, zoom, pan, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool autoHideLabels, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices: false, grids, originSymbol, sortLabels, rotate, zoom, pan)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool showVertices, bool autoHideLabels, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, viewType initialView)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices: false, grids, originSymbol, sortLabels, rotate, zoom, pan, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, _0023_003DzB7g_iJWNK2TU())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, viewType initialView)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, _0023_003DzB7g_iJWNK2TU(), initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation)
		: this(location, size, background, camera, toolBar, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, navigation, new CoordinateSystemIcon(), new ViewCubeIcon())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, navigation, initialView)
	{
	}

	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, toolBars, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, navigation, new CoordinateSystemIcon(), new ViewCubeIcon(), initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, legends, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbol, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, Legend[] legends, Histogram histogram, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon)
	{
		_0023_003DzshPEPAc_003D(location, size, background, camera, new ToolBar[1] { toolBar }, legends, histogram, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, new OriginSymbol[1] { originSymbol }, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, _0023_003DzsxyOBbcBRnzg(), ScaleBar.GetDefaultScaleBar(), _0023_003DzwmQOnB8_003D: false);
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon)
	{
		_0023_003DzshPEPAc_003D(location, size, background, camera, toolBars, legends, _0023_003DzKVWnYtP5kRnz(), displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, new OriginSymbol[1] { originSymbol }, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, _0023_003DzsxyOBbcBRnzg(), ScaleBar.GetDefaultScaleBar(), _0023_003DzwmQOnB8_003D: false);
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar toolBar, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, new ToolBar[1] { toolBar }, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, sortLabels, rotate, zoom, pan, navigation, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, toolBars, _0023_003DzQI88UEUjGvywumkl0w_003D_003D(), _0023_003DzKVWnYtP5kRnz(), displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, new OriginSymbol[1] { OriginSymbol.GetDefaultOriginSymbol() }, sortLabels, rotate, zoom, pan, navigation, CoordinateSystemIcon.GetDefaultCoordinateSystemIcon(), ViewCubeIcon.GetDefaultViewCubeIcon(), initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, viewType initialView)
		: this(location, size, background, camera, toolBars, _0023_003DzQI88UEUjGvywumkl0w_003D_003D(), _0023_003DzKVWnYtP5kRnz(), displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, CoordinateSystemIcon.GetDefaultCoordinateSystemIcon(), ViewCubeIcon.GetDefaultViewCubeIcon(), initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol originSymbol, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView)
		: this(location, size, background, camera, toolBars, legends, _0023_003DzKVWnYtP5kRnz(), displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, new OriginSymbol[1] { originSymbol }, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView)
		: this(location, size, background, camera, toolBars, legends, _0023_003DzKVWnYtP5kRnz(), displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, initialView)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, Histogram histogram, displayType displayMode, bool showLabels, bool autoHideLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView)
	{
		camera.Rotation = initialView;
		_0023_003DzshPEPAc_003D(location, size, background, camera, toolBars, legends, histogram, displayMode, showLabels, autoHideLabels, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, _0023_003DzsxyOBbcBRnzg(), ScaleBar.GetDefaultScaleBar(), _0023_003DzwmQOnB8_003D: false);
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, Histogram histogram, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView)
		: this(location, size, background, camera, toolBars, legends, histogram, displayMode, showLabels, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, initialView, ScaleBar.GetDefaultScaleBar())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, Histogram histogram, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, viewType initialView, ScaleBar scaleBar)
	{
		camera.Rotation = initialView;
		_0023_003DzshPEPAc_003D(location, size, background, camera, toolBars, legends, histogram, displayMode, showLabels, _0023_003Dz_YdQ6QENQ_6w, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, _0023_003DzsxyOBbcBRnzg(), scaleBar, _0023_003DzwmQOnB8_003D: false);
	}

	public Viewport(System.Drawing.Point location, Size size, BackgroundSettings background, Camera camera, ToolBar[] toolBars, Legend[] legends, Histogram histogram, displayType displayMode, bool showLabels, bool showVertices, bool showVertexIndices, Grid[] grids, OriginSymbol[] originSymbols, bool sortLabels, RotateSettings rotate, ZoomSettings zoom, PanSettings pan, NavigationSettings navigation, CoordinateSystemIcon coordinateSystemIcon, ViewCubeIcon viewCubeIcon, ScaleBar scaleBar)
	{
		_0023_003DzshPEPAc_003D(location, size, background, camera, toolBars, legends, histogram, displayMode, showLabels, _0023_003Dz_YdQ6QENQ_6w, showVertices, showVertexIndices, grids, originSymbols, sortLabels, rotate, zoom, pan, navigation, coordinateSystemIcon, viewCubeIcon, _0023_003DzsxyOBbcBRnzg(), scaleBar, _0023_003DzwmQOnB8_003D: false);
	}

	private void _0023_003DznjpKDdCYLd5X(Camera.navigationType _0023_003DzmrtMJ48_003D, double _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D, double _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D, double _0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D)
	{
		_0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D = 0.0 - _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D;
		_0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D = 0.0 - _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D;
		_0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D = 0.0 - _0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D;
		switch (_0023_003DzmrtMJ48_003D)
		{
		case Camera.navigationType.Walk:
			_0023_003DzXzwEmtInU_0024rH(_0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D, _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D);
			break;
		case Camera.navigationType.Fly:
			_0023_003Dzlmc8gL_0024r3WgZK3P_lg_003D_003D(_0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D, _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D, _0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D);
			break;
		}
	}

	private void _0023_003Dzlmc8gL_0024r3WgZK3P_lg_003D_003D(double _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D, double _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D, double _0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D)
	{
		Quaternion quaternion = new Quaternion(0.0, 0.0, 0.0, 0.0);
		bool flag = false;
		if (_0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D != 0.0)
		{
			quaternion.FromAxisAngle(Vector3D.AxisX, _0023_003DzNjM6QiOGzMNNn6lmAg_003D_003D);
			Camera.cameraRotation = Camera.Rotation * quaternion;
			flag = true;
		}
		if (_0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D != 0.0)
		{
			quaternion.FromAxisAngle(Vector3D.AxisY, _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D);
			Camera.cameraRotation = Camera.Rotation * quaternion;
			flag = true;
		}
		if (_0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D != 0.0)
		{
			quaternion.FromAxisAngle(Vector3D.AxisZ, _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D);
			Camera.cameraRotation = Camera.Rotation * quaternion;
			flag = true;
		}
		if (flag)
		{
			Camera.UpdateTarget();
		}
	}

	private void _0023_003DzXzwEmtInU_0024rH(double _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D, double _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D)
	{
		_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D += _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D;
		if (_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D > 90.0)
		{
			_0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D = 90.0 - (_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D - _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D);
			_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D = 90.0;
		}
		if (_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D < -90.0)
		{
			_0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D = -90.0 - (_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D - _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D);
			_0023_003Dzi5F_J_kyNfH7ve_wl2rl7QI_003D = -90.0;
		}
		Quaternion quaternion = new Quaternion(0.0, 0.0, 0.0, 1.0);
		Quaternion quaternion2 = new Quaternion(0.0, 0.0, 0.0, 1.0);
		bool flag = false;
		if (_0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D != 0.0)
		{
			quaternion.FromAxisAngle(Vector3D.AxisZ, _0023_003DzHMcxSHdD2SnTCfYQmVIGr5o_003D);
			flag = true;
		}
		if (_0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D != 0.0)
		{
			quaternion2.FromAxisAngle(Vector3D.AxisY, _0023_003Dz8PBdG34DhQtZkJDu6KqZqW0_003D);
			flag = true;
		}
		if (flag)
		{
			Camera.cameraRotation = quaternion * Camera.Rotation * quaternion2;
			Camera.UpdateTarget();
		}
	}

	private Vector3D _0023_003DzTAutB_0024mXnomC(Vector3D _0023_003DzusPIN8Q_003D, double _0023_003Dzp5u2Maw_003D, NavigationSettings _0023_003DzXwc9fSc_003D)
	{
		if (_0023_003DzF3n3vDE_003D.LengthSquared != 0.0)
		{
			double num = 0.005 * _0023_003DzXwc9fSc_003D.Acceleration;
			Vector3D vector3D = _0023_003DzF3n3vDE_003D * _0023_003Dzp5u2Maw_003D;
			vector3D += new Vector3D((double)Math.Sign(vector3D.X) * num, (double)Math.Sign(vector3D.Y) * num, (double)Math.Sign(vector3D.Z) * num);
			if (_0023_003DzusPIN8Q_003D.X == 0.0 && _0023_003DzwZ9rSymvRVOP(_0023_003DzF3n3vDE_003D.X, 0.0))
			{
				vector3D.X = 0.0;
			}
			if (_0023_003DzusPIN8Q_003D.Y == 0.0 && _0023_003DzwZ9rSymvRVOP(_0023_003DzF3n3vDE_003D.Y, 0.0))
			{
				vector3D.Y = 0.0;
			}
			if (_0023_003DzusPIN8Q_003D.Z == 0.0 && _0023_003DzwZ9rSymvRVOP(_0023_003DzF3n3vDE_003D.Z, 0.0))
			{
				vector3D.Z = 0.0;
			}
			return _0023_003DzdNvn1iIs4kC6cAm_uA_003D_003D(vector3D.X, vector3D.Y, vector3D.Z, _0023_003DzXwc9fSc_003D);
		}
		return new Vector3D();
	}

	internal void _0023_003Dzjj21PP8_003D(Vector3D _0023_003DzusPIN8Q_003D, double _0023_003Dzp5u2Maw_003D, NavigationSettings _0023_003DzXwc9fSc_003D)
	{
		_0023_003DzF3n3vDE_003D.X = _0023_003Dz6aagEH80HjrL9_78Yw_003D_003D(_0023_003DzF3n3vDE_003D.X, _0023_003DzusPIN8Q_003D.X, _0023_003DzXwc9fSc_003D.Speed, _0023_003DzXwc9fSc_003D.Acceleration, _0023_003Dzp5u2Maw_003D);
		_0023_003DzF3n3vDE_003D.Y = _0023_003Dz6aagEH80HjrL9_78Yw_003D_003D(_0023_003DzF3n3vDE_003D.Y, _0023_003DzusPIN8Q_003D.Y, _0023_003DzXwc9fSc_003D.Speed, _0023_003DzXwc9fSc_003D.Acceleration, _0023_003Dzp5u2Maw_003D);
		_0023_003DzF3n3vDE_003D.Z = _0023_003Dz6aagEH80HjrL9_78Yw_003D_003D(_0023_003DzF3n3vDE_003D.Z, _0023_003DzusPIN8Q_003D.Z, _0023_003DzXwc9fSc_003D.Speed, _0023_003DzXwc9fSc_003D.Acceleration, _0023_003Dzp5u2Maw_003D);
	}

	private static double _0023_003Dz6aagEH80HjrL9_78Yw_003D_003D(double _0023_003DzcZsmQOc_003D, double _0023_003DzusPIN8Q_003D, double _0023_003DzDAOAf_0024MtflaA, double _0023_003Dzt9p2qD3grZdNK7Dt0aCBSy4_003D, double _0023_003Dzp5u2Maw_003D)
	{
		if (_0023_003DzusPIN8Q_003D != 0.0)
		{
			_0023_003DzcZsmQOc_003D += _0023_003DzusPIN8Q_003D * _0023_003Dzt9p2qD3grZdNK7Dt0aCBSy4_003D * _0023_003Dzp5u2Maw_003D;
			if (_0023_003DzcZsmQOc_003D > _0023_003DzDAOAf_0024MtflaA)
			{
				_0023_003DzcZsmQOc_003D = _0023_003DzDAOAf_0024MtflaA;
			}
			else if (_0023_003DzcZsmQOc_003D < 0.0 - _0023_003DzDAOAf_0024MtflaA)
			{
				_0023_003DzcZsmQOc_003D = 0.0 - _0023_003DzDAOAf_0024MtflaA;
			}
		}
		else if (_0023_003DzcZsmQOc_003D > 0.0)
		{
			if ((_0023_003DzcZsmQOc_003D -= _0023_003Dzt9p2qD3grZdNK7Dt0aCBSy4_003D * _0023_003Dzp5u2Maw_003D) < 0.0)
			{
				_0023_003DzcZsmQOc_003D = 0.0;
			}
		}
		else if ((_0023_003DzcZsmQOc_003D += _0023_003Dzt9p2qD3grZdNK7Dt0aCBSy4_003D * _0023_003Dzp5u2Maw_003D) > 0.0)
		{
			_0023_003DzcZsmQOc_003D = 0.0;
		}
		return _0023_003DzcZsmQOc_003D;
	}

	private Vector3D _0023_003DzdNvn1iIs4kC6cAm_uA_003D_003D(double _0023_003DzDI8Y9ks_003D, double _0023_003DzJx6crCU_003D, double _0023_003Dz3NAt4oE_003D, NavigationSettings _0023_003DzXwc9fSc_003D)
	{
		Camera.GetFrame(out var _, out var camX, out var _, out var camZ);
		Vector3D vector3D;
		if (_0023_003DzXwc9fSc_003D.Mode == Camera.navigationType.Walk)
		{
			vector3D = Vector3D.Cross(Vector3D.AxisZ, camX);
			vector3D.Normalize();
		}
		else
		{
			vector3D = camZ;
			vector3D.Negate();
		}
		vector3D.Normalize();
		Vector3D vector3D2 = camX * _0023_003DzDI8Y9ks_003D;
		vector3D2 += vector3D * _0023_003DzJx6crCU_003D;
		vector3D2 += Vector3D.AxisZ * _0023_003Dz3NAt4oE_003D;
		if (vector3D2.X == 0.0 && vector3D2.Y == 0.0 && vector3D2.Z == 0.0)
		{
			return new Vector3D();
		}
		return vector3D2;
	}

	private static bool _0023_003DzwZ9rSymvRVOP(double _0023_003Dza3F5O2M_003D, double _0023_003Dzsvj3qxQ_003D)
	{
		return Math.Abs((_0023_003Dza3F5O2M_003D - _0023_003Dzsvj3qxQ_003D) / ((_0023_003Dzsvj3qxQ_003D == 0.0) ? 1.0 : _0023_003Dzsvj3qxQ_003D)) < 1E-06;
	}

	private Vector3D _0023_003DzdXuMALb_g8nt(NavigationSettings _0023_003DzXwc9fSc_003D)
	{
		Vector3D vector3D = new Vector3D(Camera.Location.ToArray());
		Vector3D vector3D2 = new Vector3D(Camera.Location.ToArray());
		if (vector3D.X > _0023_003DzXwc9fSc_003D.Max.X)
		{
			vector3D2.X = _0023_003DzXwc9fSc_003D.Max.X;
		}
		if (vector3D.X < _0023_003DzXwc9fSc_003D.Min.X)
		{
			vector3D2.X = _0023_003DzXwc9fSc_003D.Min.X;
		}
		if (vector3D.Y > _0023_003DzXwc9fSc_003D.Max.Y)
		{
			vector3D2.Y = _0023_003DzXwc9fSc_003D.Max.Y;
		}
		if (vector3D.Y < _0023_003DzXwc9fSc_003D.Min.Y)
		{
			vector3D2.Y = _0023_003DzXwc9fSc_003D.Min.Y;
		}
		if (vector3D.Z > _0023_003DzXwc9fSc_003D.Max.Z)
		{
			vector3D2.Z = _0023_003DzXwc9fSc_003D.Max.Z;
		}
		if (vector3D.Z < _0023_003DzXwc9fSc_003D.Min.Z)
		{
			vector3D2.Z = _0023_003DzXwc9fSc_003D.Min.Z;
		}
		return vector3D2;
	}

	internal void _0023_003Dz3w_00240eHwLabq0(Workspace _0023_003Dz0TvaYNo_003D, _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi _0023_003DzY7PoD1c_003D, _0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5 _0023_003DzxIgINtc_003D, double _0023_003Dzp5u2Maw_003D)
	{
		double _0023_003DzHpR00Qtuc8ec = 0.0;
		double _0023_003DzBwj24DC4DXtX = 0.0;
		double _0023_003DzkTIxJ_0024qMOs_0024 = 0.0;
		NavigationSettings navigation = _0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp().Navigation;
		Vector3D _0023_003DzusPIN8Q_003D = _0023_003Dzx08CEcJZOycn(_0023_003DzY7PoD1c_003D);
		bool flag = navigation._0023_003DzAC5kXfU_003D(_0023_003DzxIgINtc_003D, _0023_003DzY7PoD1c_003D);
		double num = 0.1;
		double num2 = 0.1;
		_0023_003Dzjj21PP8_003D(_0023_003DzusPIN8Q_003D, _0023_003Dzp5u2Maw_003D, navigation);
		switch (navigation.Mode)
		{
		case Camera.navigationType.Walk:
			if (flag)
			{
				_0023_003DzBwj24DC4DXtX = _0023_003DzxIgINtc_003D._0023_003DzHpyw44b5UiDs.Y * num;
				_0023_003DzHpR00Qtuc8ec = (0.0 - _0023_003DzxIgINtc_003D._0023_003DzHpyw44b5UiDs.X) * num2;
			}
			break;
		case Camera.navigationType.Fly:
			if (flag)
			{
				_0023_003DzBwj24DC4DXtX = _0023_003DzxIgINtc_003D._0023_003DzHpyw44b5UiDs.Y * num;
				_0023_003DzkTIxJ_0024qMOs_0024 = (0.0 - _0023_003DzxIgINtc_003D._0023_003DzHpyw44b5UiDs.X) * num2;
			}
			else
			{
				_0023_003DzBwj24DC4DXtX = 0.0;
				_0023_003DzkTIxJ_0024qMOs_0024 = 0.0;
			}
			_0023_003DzHpR00Qtuc8ec = (0.0 - _0023_003DzF3n3vDE_003D.X) / navigation.Speed;
			break;
		}
		_0023_003DzxhCLN2MBwEHE(_0023_003Dz0TvaYNo_003D, navigation, flag, _0023_003Dzp5u2Maw_003D, _0023_003DzusPIN8Q_003D, _0023_003DzHpR00Qtuc8ec, _0023_003DzBwj24DC4DXtX, _0023_003DzkTIxJ_0024qMOs_0024);
		if (flag)
		{
			_0023_003DzxIgINtc_003D._0023_003Dzgv3CpKlqLndg(_0023_003Dz0TvaYNo_003D);
		}
	}

	internal void _0023_003DzxhCLN2MBwEHE(Workspace _0023_003Dz0TvaYNo_003D, NavigationSettings _0023_003DzXwc9fSc_003D, bool _0023_003DzPboEI8Kj2KeL, double _0023_003Dzp5u2Maw_003D, Vector3D _0023_003DzusPIN8Q_003D, double _0023_003DzHpR00Qtuc8ec, double _0023_003DzBwj24DC4DXtX, double _0023_003DzkTIxJ_0024qMOs_00244)
	{
		double x = _0023_003DzF3n3vDE_003D.X;
		_0023_003DzBwj24DC4DXtX *= _0023_003DzXwc9fSc_003D.RotationSpeed;
		_0023_003DzkTIxJ_0024qMOs_00244 *= _0023_003DzXwc9fSc_003D.RotationSpeed;
		_0023_003DzHpR00Qtuc8ec *= _0023_003DzXwc9fSc_003D.RotationSpeed;
		switch (_0023_003DzXwc9fSc_003D.Mode)
		{
		case Camera.navigationType.Walk:
			if (_0023_003DzPboEI8Kj2KeL)
			{
				_0023_003DznjpKDdCYLd5X(_0023_003DzXwc9fSc_003D.Mode, _0023_003DzHpR00Qtuc8ec, _0023_003DzBwj24DC4DXtX, 0.0);
				Camera.Tilt(Vector3D.AxisZ);
			}
			break;
		case Camera.navigationType.Fly:
			if (_0023_003DzusPIN8Q_003D.Y != 0.0)
			{
				_0023_003DzHpR00Qtuc8ec *= (double)Math.Sign(_0023_003DzusPIN8Q_003D.Y);
			}
			_0023_003DznjpKDdCYLd5X(_0023_003DzXwc9fSc_003D.Mode, _0023_003DzHpR00Qtuc8ec, _0023_003DzBwj24DC4DXtX, _0023_003DzkTIxJ_0024qMOs_00244);
			_0023_003DzusPIN8Q_003D.X = 0.0;
			x = _0023_003DzF3n3vDE_003D.X;
			_0023_003DzF3n3vDE_003D.X = 0.0;
			break;
		}
		Camera.Location += _0023_003DzTAutB_0024mXnomC(_0023_003DzusPIN8Q_003D, _0023_003Dzp5u2Maw_003D, _0023_003DzXwc9fSc_003D);
		_0023_003DzF3n3vDE_003D.X = x;
		Camera.Location = _0023_003DzdXuMALb_g8nt(_0023_003DzXwc9fSc_003D).AsPoint;
		_0023_003Dz0TvaYNo_003D.AdjustNearAndFarPlanes();
	}

	private Vector3D _0023_003Dzx08CEcJZOycn(_0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi _0023_003DzY7PoD1c_003D)
	{
		Vector3D vector3D = new Vector3D(0.0, 0.0, 0.0);
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.W))
		{
			vector3D.Y += 1.0;
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.S))
		{
			vector3D.Y -= 1.0;
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.D))
		{
			vector3D.X += 1.0;
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.A))
		{
			vector3D.X -= 1.0;
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.E))
		{
			vector3D.Z += 1.0;
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(Keys.Q))
		{
			vector3D.Z -= 1.0;
		}
		return vector3D;
	}

	private IWorkspaceInternal _0023_003DzoMowD04mt4vKC4cSDkFRUjCSQN6tForrDM9wPbQ_003D()
	{
		return _0023_003Dz0TvaYNo_003D;
	}

	IWorkspaceInternal IViewportInternal.get_parent()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoMowD04mt4vKC4cSDkFRUjCSQN6tForrDM9wPbQ=
		return this._0023_003DzoMowD04mt4vKC4cSDkFRUjCSQN6tForrDM9wPbQ_003D();
	}

	private void _0023_003DzoqxUtuBN57mB_0024fEohMvzQCHDwJ1RSki6pKBgPe4_003D(bool _0023_003Dz5lra25Q_003D)
	{
		_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D);
	}

	void IViewportInternal.SuspendNavigation(bool _0023_003Dz5lra25Q_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoqxUtuBN57mB$fEohMvzQCHDwJ1RSki6pKBgPe4=
		this._0023_003DzoqxUtuBN57mB_0024fEohMvzQCHDwJ1RSki6pKBgPe4_003D(_0023_003Dz5lra25Q_003D);
	}

	private float _0023_003DzgRGydxI0js4H2FiOzNOIWMN85Fv1CZGJDT01pEo8e4Wh()
	{
		return _0023_003DzIjzPUT72VTAG;
	}

	float IViewportInternal.get_screenToWorld()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zgRGydxI0js4H2FiOzNOIWMN85Fv1CZGJDT01pEo8e4Wh
		return this._0023_003DzgRGydxI0js4H2FiOzNOIWMN85Fv1CZGJDT01pEo8e4Wh();
	}

	internal bool _0023_003Dz6PIi18cHVS03g7KqxAAkgsk_003D()
	{
		if (_0023_003DzK_00241ezHQJ9Z3c == displayType.Wireframe && Camera.ProjectionMode == projectionType.Orthographic && Vector3D.AreCoincident(Vector3D.AxisZ, Camera.ViewNormal))
		{
			return !_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.Enabled;
		}
		return false;
	}

	private void _0023_003DzfNItCpw2edTCIA0bipE7CIpgb3Jq_XVoKKLltwk_003D()
	{
		_0023_003Dz3tGL3rg_003D();
	}

	void IViewportInternal.UpdateWorkspace()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zfNItCpw2edTCIA0bipE7CIpgb3Jq_XVoKKLltwk=
		this._0023_003DzfNItCpw2edTCIA0bipE7CIpgb3Jq_XVoKKLltwk_003D();
	}

	internal void _0023_003Dz3tGL3rg_003D()
	{
		if (_0023_003DzGBZgP_0024g_003D != null)
		{
			_0023_003DzGBZgP_0024g_003D();
		}
		else if (_0023_003Dz0TvaYNo_003D != null)
		{
			_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
		}
	}

	internal void _0023_003DzzgjrOMU_003D(Workspace _0023_003DzopDrLGk_003D)
	{
		_0023_003Dz0TvaYNo_003D = _0023_003DzopDrLGk_003D;
		_0023_003Dzp32v61d0n0nb(_0023_003DzopDrLGk_003D.InstanceId);
	}

	private void _0023_003Dzp32v61d0n0nb(string _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal string _0023_003DzkOgRqj2Di0m4()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590286) + _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
	}

	private void _0023_003DzshPEPAc_003D(System.Drawing.Point _0023_003DzunVj9yQ_003D, Size _0023_003Dz0ERMHbg_003D, BackgroundSettings _0023_003DzRaVp1sk_003D, Camera _0023_003DzZ_0024IejP0R_0024_Cw, ToolBar[] _0023_003DzXldEn8dxMaC2, Legend[] _0023_003Dz6SHaVGO9Xhk5, Histogram _0023_003DznPu5SKE_003D, displayType _0023_003DzK_00241ezHQJ9Z3c, bool _0023_003DzwfKBrot1LuuC, bool _0023_003Dz_YdQ6QENQ_6w, bool _0023_003DzyBPwOa1siDegABKoKg_003D_003D, bool _0023_003Dze_0024CNZ_Memiiw, Grid[] _0023_003Dzmm4AR2_v0bxl, OriginSymbol[] _0023_003DzMUeJTCp30C0O, bool _0023_003DzKjafUBuffx5v, RotateSettings _0023_003DzPboEI8Kj2KeL, ZoomSettings _0023_003Dzx_7wwGM_003D, PanSettings _0023_003DzZf7Qlt4_003D, NavigationSettings _0023_003DzXwc9fSc_003D, CoordinateSystemIcon _0023_003DzbNsLMppcArIJ, ViewCubeIcon _0023_003DzovvUHLLq3d_U, SavedViewsManager _0023_003DzjLarMls1qESh, ScaleBar _0023_003DzL2288gEE0_0D, bool _0023_003DzwmQOnB8_003D)
	{
		Camera = (_0023_003DzwmQOnB8_003D ? ((Camera)_0023_003DzZ_0024IejP0R_0024_Cw.Clone()) : _0023_003DzZ_0024IejP0R_0024_Cw);
		Location = _0023_003DzunVj9yQ_003D;
		Size = _0023_003Dz0ERMHbg_003D;
		Background = (_0023_003DzwmQOnB8_003D ? ((BackgroundSettings)_0023_003DzRaVp1sk_003D.Clone()) : _0023_003DzRaVp1sk_003D);
		DisplayMode = _0023_003DzK_00241ezHQJ9Z3c;
		this._0023_003DzwfKBrot1LuuC = _0023_003DzwfKBrot1LuuC;
		this._0023_003DzyBPwOa1siDegABKoKg_003D_003D = _0023_003DzyBPwOa1siDegABKoKg_003D_003D;
		this._0023_003Dze_0024CNZ_Memiiw = _0023_003Dze_0024CNZ_Memiiw;
		this._0023_003Dz_YdQ6QENQ_6w = _0023_003Dz_YdQ6QENQ_6w;
		_0023_003DzF5TdZcc_003D = new LabelList(this);
		_0023_003DzLvweZtO44VEY = _0023_003DzKjafUBuffx5v;
		Zoom = (_0023_003DzwmQOnB8_003D ? ((ZoomSettings)_0023_003Dzx_7wwGM_003D.Clone()) : _0023_003Dzx_7wwGM_003D);
		Rotate = (_0023_003DzwmQOnB8_003D ? ((RotateSettings)_0023_003DzPboEI8Kj2KeL.Clone()) : _0023_003DzPboEI8Kj2KeL);
		Pan = (_0023_003DzwmQOnB8_003D ? ((PanSettings)_0023_003DzZf7Qlt4_003D.Clone()) : _0023_003DzZf7Qlt4_003D);
		Navigation = (_0023_003DzwmQOnB8_003D ? ((NavigationSettings)_0023_003DzXwc9fSc_003D.Clone()) : _0023_003DzXwc9fSc_003D);
		if (!_0023_003DzwmQOnB8_003D)
		{
			Grids = _0023_003Dzmm4AR2_v0bxl;
			ToolBars = _0023_003DzXldEn8dxMaC2;
			Legends = _0023_003Dz6SHaVGO9Xhk5;
			OriginSymbols = _0023_003DzMUeJTCp30C0O;
			Histogram = _0023_003DznPu5SKE_003D;
			CoordinateSystemIcon = _0023_003DzbNsLMppcArIJ;
			ViewCubeIcon = _0023_003DzovvUHLLq3d_U;
			SavedViews = _0023_003DzjLarMls1qESh;
			ScaleBar = _0023_003DzL2288gEE0_0D;
		}
		else
		{
			this._0023_003Dzmm4AR2_v0bxl = new Grid[_0023_003Dzmm4AR2_v0bxl.Length];
			for (int i = 0; i < _0023_003Dzmm4AR2_v0bxl.Length; i++)
			{
				this._0023_003Dzmm4AR2_v0bxl[i] = (Grid)_0023_003Dzmm4AR2_v0bxl[i].Clone();
				this._0023_003Dzmm4AR2_v0bxl[i].Recompute = true;
			}
			this._0023_003DzXldEn8dxMaC2 = new ToolBar[_0023_003DzXldEn8dxMaC2.Length];
			for (int j = 0; j < _0023_003DzXldEn8dxMaC2.Length; j++)
			{
				this._0023_003DzXldEn8dxMaC2[j] = (ToolBar)_0023_003DzXldEn8dxMaC2[j].Clone();
			}
			this._0023_003Dz6SHaVGO9Xhk5 = new Legend[_0023_003Dz6SHaVGO9Xhk5.Length];
			for (int k = 0; k < _0023_003Dz6SHaVGO9Xhk5.Length; k++)
			{
				this._0023_003Dz6SHaVGO9Xhk5[k] = (Legend)_0023_003Dz6SHaVGO9Xhk5[k].Clone();
			}
			if (_0023_003DzMUeJTCp30C0O != null)
			{
				this._0023_003DzMUeJTCp30C0O = new OriginSymbol[_0023_003DzMUeJTCp30C0O.Length];
				for (int l = 0; l < _0023_003DzMUeJTCp30C0O.Length; l++)
				{
					this._0023_003DzMUeJTCp30C0O[l] = (OriginSymbol)_0023_003DzMUeJTCp30C0O[l].Clone();
					this._0023_003DzMUeJTCp30C0O[l].ParentViewport = this;
				}
			}
			if (_0023_003DznPu5SKE_003D != null)
			{
				Histogram = (Histogram)_0023_003DznPu5SKE_003D.Clone();
				Histogram.ParentViewport = this;
			}
			if (_0023_003DzbNsLMppcArIJ != null)
			{
				CoordinateSystemIcon = (CoordinateSystemIcon)_0023_003DzbNsLMppcArIJ.Clone();
				CoordinateSystemIcon.ParentViewport = this;
			}
			if (_0023_003DzovvUHLLq3d_U != null)
			{
				ViewCubeIcon = (ViewCubeIcon)_0023_003DzovvUHLLq3d_U.Clone();
				ViewCubeIcon.ParentViewport = this;
			}
			if (_0023_003DzL2288gEE0_0D != null)
			{
				ScaleBar = (ScaleBar)_0023_003DzL2288gEE0_0D.Clone();
				ScaleBar.ParentViewport = this;
			}
			SavedViews = (SavedViewsManager)_0023_003DzjLarMls1qESh.Clone();
		}
		if (_0023_003Dz0TvaYNo_003D != null)
		{
			_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements();
		}
	}

	internal bool _0023_003DzPxrSykdhxj_0024ErGq9Jg_003D_003D(bool _0023_003DzKgAu6qDy__0024H_0024)
	{
		bool result = false;
		if ((Background.ColorTheme == colorThemeType.Auto || !_0023_003DzKgAu6qDy__0024H_0024) && Legends != null)
		{
			Legend[] legends = Legends;
			foreach (Legend legend in legends)
			{
				if (legend.Visible)
				{
					legend.dirtyTextures = true;
					result = true;
				}
			}
		}
		return result;
	}

	public virtual object Clone()
	{
		return new Viewport(this);
	}

	private bool _0023_003DzUYu8Sa4j9DllylomgQ_003D_003D()
	{
		return SavedViews._0023_003Dz4XAvJ5aCRLKs(_0023_003DzsxyOBbcBRnzg());
	}

	internal void _0023_003DzZ_0024OTi14BtYm4()
	{
		SavedViews = _0023_003DzsxyOBbcBRnzg();
	}

	private static SavedViewsManager _0023_003DzsxyOBbcBRnzg()
	{
		return new SavedViewsManager();
	}

	public void SaveView(out Camera saved)
	{
		saved = (Camera)Camera.Clone();
	}

	public void RestoreView(Camera saved)
	{
		_0023_003DzCT80Hxfj1Pym(saved);
	}

	internal void _0023_003DzCT80Hxfj1Pym(Camera _0023_003DzU_jO8v8_003D)
	{
		if (_0023_003Dz0TvaYNo_003D.AnimateCamera)
		{
			SetView(_0023_003DzU_jO8v8_003D.Rotation, _0023_003DzU_jO8v8_003D.Target, _0023_003DzU_jO8v8_003D.Distance, _0023_003DzU_jO8v8_003D.ZoomFactor);
			return;
		}
		Camera = (Camera)_0023_003DzU_jO8v8_003D.Clone();
		_0023_003DzjDuhintYzbDe(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
		AdjustNearAndFarPlanes();
	}

	internal bool _0023_003DzL1WU50o_003D(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D)
	{
		if (_0023_003Dz8GBMuoM_003D >= 0 && _0023_003Dz8GBMuoM_003D < Size.Width && _0023_003DzJU0R6e0_003D > 0)
		{
			return _0023_003DzJU0R6e0_003D <= Size.Height;
		}
		return false;
	}

	internal int[] _0023_003DzdzRS8TI_003D()
	{
		int[] viewFrame = GetViewFrame();
		Camera.SetViewport(viewFrame);
		return viewFrame;
	}

	internal int[] _0023_003DzdzRS8TI_003D(float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk)
	{
		int[] viewFrame = GetViewFrame();
		Camera.SetViewport(viewFrame, _0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk);
		return viewFrame;
	}

	internal void _0023_003DzsDZysFFbOXiw(int _0023_003DzatgWgTMc3NTm)
	{
		_0023_003DzsDZysFFbOXiw(_0023_003DzatgWgTMc3NTm, default(RectangleF), _0023_003Dz9Rnv95_0024TldTZ: false);
	}

	internal void _0023_003DzsDZysFFbOXiw(int _0023_003DzatgWgTMc3NTm, RectangleF _0023_003DzF7kGEgqMZE2_, bool _0023_003Dz9Rnv95_0024TldTZ)
	{
		_0023_003Dz0TvaYNo_003D._0023_003DzsDZysFFbOXiw(_0023_003DzF7kGEgqMZE2_, GetViewFrame(), Size, this, _0023_003Dz9Rnv95_0024TldTZ);
	}

	internal void _0023_003Dz_lRXhjlDOTvb(int _0023_003DznCapsq3EyzM5, bool _0023_003DzbWHNjOg_003D, Bitmap _0023_003DzO_o8M3HUNFVt, Bitmap _0023_003DzPHIgywQ0bPFl, Bitmap _0023_003DzBlHCDVjJXeoG, Bitmap _0023_003DzAekJM0ZtENTE, Bitmap _0023_003DzkP4DGwYcuX5B)
	{
		if (_0023_003DznCapsq3EyzM5 == 0 || _0023_003Dz0TvaYNo_003D.Renderer == rendererType.OpenGL)
		{
			_0023_003DzsDZysFFbOXiw(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
			_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawBorder(_0023_003Dz0TvaYNo_003D.StandardShaders, RenderContextUtility.ConvertColor(_0023_003Dz0TvaYNo_003D._0023_003DzOLP90s_0024AN26E.Color), Size, _0023_003DznCapsq3EyzM5, _0023_003DzbWHNjOg_003D, _0023_003DzO_o8M3HUNFVt, _0023_003DzPHIgywQ0bPFl, _0023_003DzBlHCDVjJXeoG, _0023_003DzAekJM0ZtENTE, _0023_003DzkP4DGwYcuX5B);
		}
	}

	public override void Dispose()
	{
		if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		}
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590277), _0023_003DzkOgRqj2Di0m4());
		base.Dispose();
		_0023_003DzPY_0024ulDyKjEOA();
		if (_0023_003DzF5TdZcc_003D != null)
		{
			_0023_003DzF5TdZcc_003D.Clear();
		}
		if (_0023_003Dz6SHaVGO9Xhk5 != null)
		{
			Legend[] array = _0023_003Dz6SHaVGO9Xhk5;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
		}
		if (_0023_003DzXldEn8dxMaC2 != null)
		{
			ToolBar[] array2 = _0023_003DzXldEn8dxMaC2;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Dispose();
			}
			_0023_003DzXldEn8dxMaC2 = null;
		}
		if (_0023_003DzMUeJTCp30C0O != null)
		{
			_0023_003DzMUeJTCp30C0O = null;
		}
		if (ViewCubeIcon != null)
		{
			ViewCubeIcon.Dispose();
		}
		if (CoordinateSystemIcon != null)
		{
			CoordinateSystemIcon.Dispose();
		}
		if (Histogram != null)
		{
			Histogram.Dispose();
		}
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590317), _0023_003DzkOgRqj2Di0m4());
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		_0023_003Dzh2BJvfFX_KvX(_0023_003DzsLHxXyo_003D: true);
		if (_0023_003DzXldEn8dxMaC2 != null)
		{
			ToolBar[] array = _0023_003DzXldEn8dxMaC2;
			for (int i = 0; i < array.Length; i++)
			{
				array[i]._0023_003DzPY_0024ulDyKjEOA();
			}
		}
		if (_0023_003Dz6SHaVGO9Xhk5 != null)
		{
			Legend[] array2 = _0023_003Dz6SHaVGO9Xhk5;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i]._0023_003DzPY_0024ulDyKjEOA();
			}
		}
		Camera.Dispose();
		Grid[] array3 = _0023_003Dzmm4AR2_v0bxl;
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i].Dispose();
		}
		if (_0023_003DzMUeJTCp30C0O != null)
		{
			OriginSymbol[] array4 = _0023_003DzMUeJTCp30C0O;
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i].Dispose();
			}
		}
		if (_0023_003Dz2bwAPoQwFwzX.Texture != null)
		{
			_0023_003Dz2bwAPoQwFwzX.Texture.FreeResources();
		}
		if (_0023_003DzFfOjsSRCbzpd != null)
		{
			_0023_003DzFfOjsSRCbzpd.Dispose();
		}
		if (_0023_003Dz4ry2vZefVkxX != null)
		{
			_0023_003Dz4ry2vZefVkxX.Dispose();
		}
		if (Histogram != null)
		{
			Histogram.Dispose();
		}
		foreach (devDept.Eyeshot.Control.Labels.Label label in Labels)
		{
			label.Dispose();
		}
	}

	internal void _0023_003Dz_XtI6E7WTKpM()
	{
		Camera.InitializeGraphicsResources(this);
		Camera.UpdateSize(Size);
		if (Labels != null)
		{
			Labels.InitializeGraphicsResources();
		}
	}

	internal void _0023_003Dzl_s8qNo_003D(float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk)
	{
		Camera.SetCurrent(GetViewFrame(), _0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk);
	}

	internal void _0023_003DzEoxSq3a9jDkF(int[] _0023_003DzBppTnBIbeUl7)
	{
		_0023_003DzIjzPUT72VTAG = (float)Camera.ComputeScreenToWorldFactor(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzBppTnBIbeUl7);
	}

	internal float _0023_003DzuPo9xTkqnag6(int[] _0023_003DzBppTnBIbeUl7, Point3D _0023_003DzhEjPeMs_003D)
	{
		double[] modelViewProjectionMatrix = Camera.GetModelViewProjectionMatrix();
		_0023_003DzotopW_0024w_003D(modelViewProjectionMatrix, _0023_003DzBppTnBIbeUl7, _0023_003DzhEjPeMs_003D.X, _0023_003DzhEjPeMs_003D.Y, _0023_003DzhEjPeMs_003D.Z, out var _, out var _, out var _0023_003DzdGO9IS3DR52i);
		return (float)Camera.ComputeScreenToWorldFactor(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzdGO9IS3DR52i, _0023_003DzBppTnBIbeUl7);
	}

	private int _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D()
	{
		return Size.Height / 10;
	}

	internal void _0023_003DzHKNzRfUCOkwd()
	{
		ToolBar toolBar = ToolBar;
		if (toolBar != null && (toolBar.Buttons == null || toolBar._0023_003Dz39dJVf2fnvi4() == 0))
		{
			toolBar._0023_003DzjqbeLD0f8nPN();
		}
	}

	[DebuggerStepThrough]
	public int[] GetViewFrame()
	{
		return Camera.GetViewFrame(Location, Size, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
	}

	[DebuggerStepThrough]
	internal int[] _0023_003DzOUJ4xSBfxwu9(int _0023_003DzatgWgTMc3NTm)
	{
		return Camera.GetViewFrame(Location, Size, _0023_003DzatgWgTMc3NTm);
	}

	internal Rectangle _0023_003Dzr_AjDsvNuuYG()
	{
		int[] viewFrame = GetViewFrame();
		return new Rectangle(viewFrame[0], viewFrame[1], viewFrame[2], viewFrame[3]);
	}

	internal Size _0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D()
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003Dz5rO_0024Fj2CJdsU() != null && _0023_003Dz0TvaYNo_003D._0023_003Dz5rO_0024Fj2CJdsU().Visible)
		{
			return new Size(Size.Width, Size.Height - _0023_003Dz0TvaYNo_003D._0023_003Dz5rO_0024Fj2CJdsU().Thickness);
		}
		return _0023_003DzgTjCWc4_003D;
	}

	private static System.Drawing.Point _0023_003Dzw8TPRvHHS4hl()
	{
		return new System.Drawing.Point(0, 0);
	}

	private static Size _0023_003DzmuZmjj_0024WEUbi()
	{
		return new Size(300, 300);
	}

	private bool _0023_003DzeTnCxNmg20Yd()
	{
		return Camera.ShouldSerialize(_0023_003DzUuEDRsCIpmOw());
	}

	internal void _0023_003Dzh5oNOz3ChcaX()
	{
		Camera = _0023_003DzUuEDRsCIpmOw();
	}

	internal static Camera _0023_003DzUuEDRsCIpmOw()
	{
		return new Camera();
	}

	private static CoordinateSystemIcon _0023_003Dz2S256D9h3YRq()
	{
		return new CoordinateSystemIcon();
	}

	private static ViewCubeIcon _0023_003Dzh1Aj7zFAmigJ()
	{
		return new ViewCubeIcon();
	}

	private static SavedViewsManager _0023_003Dz2tD3Mi93ncaj3oC2uw_003D_003D()
	{
		return new SavedViewsManager();
	}

	private static ScaleBar _0023_003Dz1f2OmgsPSjqP()
	{
		return new ScaleBar();
	}

	private bool _0023_003DzUei9sz3k9TKTRUt6pw_003D_003D()
	{
		if (ToolBars.Length == 1)
		{
			return ToolBars[0]._0023_003Dz4XAvJ5aCRLKs(ToolBar._0023_003Dz7RqBmFdBIbpl()[0]);
		}
		return true;
	}

	private void _0023_003Dz_8xwjiZYF1bX()
	{
		ToolBars = ToolBar._0023_003Dz7RqBmFdBIbpl();
	}

	internal ToolBar _0023_003DzAmQmFnNJkaOUqpvwTQ_003D_003D()
	{
		if (_0023_003DziEOSyE543t4chjccPw_003D_003D == null)
		{
			_0023_003DziEOSyE543t4chjccPw_003D_003D = ToolBars?.Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzHRlY7RdCpPxlYL61ELCI76W3ZKXg).FirstOrDefault();
			if (_0023_003DziEOSyE543t4chjccPw_003D_003D == null)
			{
				_0023_003DziEOSyE543t4chjccPw_003D_003D = new ToolBar(ToolBar._0023_003DzPkO7IBwkBx9t(), visible: true, new ToolBarButton[0]);
				_0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D = ToolBars.Length;
				Array.Resize(ref _0023_003DzXldEn8dxMaC2, ToolBars.Length + 1);
				ToolBars[_0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D] = _0023_003DziEOSyE543t4chjccPw_003D_003D;
			}
		}
		return _0023_003DziEOSyE543t4chjccPw_003D_003D;
	}

	internal void _0023_003Dz_0024vGIP8ipyEwE()
	{
		if (_0023_003DziEOSyE543t4chjccPw_003D_003D != null && _0023_003DziEOSyE543t4chjccPw_003D_003D.Buttons != null)
		{
			ToolBarButtonList toolBarButtonList = new ToolBarButtonList(_0023_003DziEOSyE543t4chjccPw_003D_003D, _0023_003DziEOSyE543t4chjccPw_003D_003D.Buttons.ToArray());
			for (int num = toolBarButtonList.Count - 1; num >= 0; num--)
			{
				if (toolBarButtonList[num]._0023_003DzVCRPD_0024GbQNCA)
				{
					toolBarButtonList.RemoveAt(num);
					break;
				}
			}
			_0023_003DziEOSyE543t4chjccPw_003D_003D.Buttons = toolBarButtonList;
		}
		if (_0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D > -1)
		{
			int num2 = ToolBars.Length;
			ToolBar[] array = new ToolBar[num2 - 1];
			for (int i = 0; i < num2; i++)
			{
				if (i < _0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D)
				{
					array[i] = _0023_003DzXldEn8dxMaC2[i];
				}
				else if (i > _0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D)
				{
					array[i - 1] = _0023_003DzXldEn8dxMaC2[i];
				}
			}
			_0023_003DzXldEn8dxMaC2 = array;
			_0023_003DziEOSyE543t4chjccPw_003D_003D.Dispose();
		}
		_0023_003DziEOSyE543t4chjccPw_003D_003D = null;
		_0023_003DzUha_0024UYGek5yZzKbZ5A_003D_003D = -1;
	}

	private static Legend[] _0023_003DzQI88UEUjGvywumkl0w_003D_003D()
	{
		return new Legend[0];
	}

	private static void _0023_003Dze5zV_b_HQ_0024C_0024(displayType _0023_003DzsLHxXyo_003D, Viewport _0023_003Dz7Xo5EoA_003D)
	{
		if (_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D != null && !_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D._0023_003Dz86gBZCqRMtpL())
		{
			_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D._0023_003DzA8RsYfRdfWs4a5OLJCwF9X66ETqDRbikkg_003D_003D(_0023_003DzsLHxXyo_003D);
			if (_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D.ActionMode != actionType.None)
			{
				_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D.UpdateVisibleSelection();
			}
			if (_0023_003Dz7Xo5EoA_003D._0023_003DzK_00241ezHQJ9Z3c != _0023_003DzsLHxXyo_003D)
			{
				_0023_003Dz7Xo5EoA_003D._0023_003Dz0TvaYNo_003D._0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: true);
			}
			Logger.Instance.Info(_0023_003Dz7Xo5EoA_003D.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590327), _0023_003Dz7Xo5EoA_003D._0023_003DzkOgRqj2Di0m4(), _0023_003Dz7Xo5EoA_003D._0023_003DzK_00241ezHQJ9Z3c, _0023_003DzsLHxXyo_003D));
		}
		_0023_003Dz7Xo5EoA_003D._0023_003DzK_00241ezHQJ9Z3c = _0023_003DzsLHxXyo_003D;
	}

	private bool _0023_003DzVDVgwCp2DQOlX1Eqag_003D_003D()
	{
		return DisplayMode != _0023_003DzuZSYlpGVHVDP();
	}

	internal void _0023_003DzYX9Kdawasl3c()
	{
		DisplayMode = _0023_003DzuZSYlpGVHVDP();
	}

	internal bool _0023_003Dz4YeDLF0TcPsR3WCduA_003D_003D()
	{
		if (_0023_003Dz5tj8j11PShCE != null)
		{
			return _0023_003Dz5tj8j11PShCE._0023_003Dz4XAvJ5aCRLKs();
		}
		return false;
	}

	internal void _0023_003DzKSl8ry1JQbbZ()
	{
		if (_0023_003Dz5tj8j11PShCE != null)
		{
			_0023_003Dz5tj8j11PShCE.Dispose();
		}
		ScaleBar = ScaleBar.GetDefaultScaleBar();
	}

	private bool _0023_003DzUoQzAZDiuX6rdLAnUA_003D_003D()
	{
		return !ShowLabels;
	}

	internal void _0023_003DzuXrjbjOpmHCP()
	{
		ShowLabels = true;
	}

	private bool _0023_003Dz6Zo8IMU2gF2mWk6NhtmMHmM_003D()
	{
		return ShowVertices;
	}

	internal void _0023_003DzVYRWJddBe0p8v3fRYWhRtL0_003D()
	{
		ShowVertices = false;
	}

	private bool _0023_003Dziweod4ekmyc2YzB94w_003D_003D()
	{
		return ShowVertexIndices;
	}

	internal void _0023_003DzG4cX_0024UH8TpyKK_mRLQ_003D_003D()
	{
		ShowVertexIndices = false;
	}

	private bool _0023_003DzzwT8q1nzGpzk()
	{
		return VertexSize != 10;
	}

	internal void _0023_003DzaXQ6BonGm_zy()
	{
		VertexSize = 10;
	}

	private bool _0023_003DzULCf_0024NqzTNhIFvDO0g_003D_003D()
	{
		return AutoHideLabels;
	}

	internal void _0023_003Dzl_0024rVWdzl5kTu7tb_3A_003D_003D()
	{
		AutoHideLabels = false;
	}

	private static Grid[] _0023_003DzPXyrw2E6o4RQGd1eLQ_003D_003D()
	{
		return new Grid[1]
		{
			new Grid()
		};
	}

	private bool _0023_003Dzvk4cYBVF1ccVXWye5A_003D_003D()
	{
		if (Grids.Length == 1)
		{
			return Grids[0]._0023_003Dz4XAvJ5aCRLKs(new Grid());
		}
		return true;
	}

	private void _0023_003DzXazsplQU2R_0024n()
	{
		Grids = _0023_003DzPXyrw2E6o4RQGd1eLQ_003D_003D();
	}

	private static OriginSymbol[] _0023_003DzK_0024ClK_0024YmZACa()
	{
		return new OriginSymbol[1] { OriginSymbol.GetDefaultOriginSymbol() };
	}

	private bool _0023_003Dz_0024m0HldvEVbaoVFTWYw_003D_003D()
	{
		if (OriginSymbols.Length == 1)
		{
			return OriginSymbols[0]._0023_003Dz4XAvJ5aCRLKs(_0023_003DzK_0024ClK_0024YmZACa()[0]);
		}
		return true;
	}

	internal void _0023_003DzKgTUMhrU4ulq()
	{
		OriginSymbols = _0023_003DzK_0024ClK_0024YmZACa();
	}

	internal bool _0023_003DzTwvf8s4UWIEi()
	{
		return true;
	}

	private static displayType _0023_003DzuZSYlpGVHVDP()
	{
		return displayType.Rendered;
	}

	public override string ToString()
	{
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587829), Location, Size);
	}

	private bool _0023_003DziNrl9JB35rrnox4uhQ_003D_003D()
	{
		return Legends.Length != 0;
	}

	internal void _0023_003DzjjNSugn5H3py0TMYGg_003D_003D()
	{
		Legends = new Legend[0];
	}

	internal int[] _0023_003DzjDuhintYzbDe(int _0023_003DzatgWgTMc3NTm, bool _0023_003DzR3sFNCI_003D)
	{
		Camera.RecomputeViewport(Size);
		int[] array = _0023_003DzOUJ4xSBfxwu9(_0023_003DzatgWgTMc3NTm);
		if (_0023_003DzR3sFNCI_003D)
		{
			Camera.SetViewport(array);
		}
		return array;
	}

	internal void _0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(int _0023_003DzatgWgTMc3NTm, RenderContextBase _0023_003DzmNZD0Zs_003D, bool _0023_003DzqJnmoiGKtpts)
	{
		_0023_003DzjDuhintYzbDe(_0023_003DzatgWgTMc3NTm, _0023_003DzqJnmoiGKtpts);
		Camera.UpdateMatrices(_0023_003DzqJnmoiGKtpts);
	}

	internal bool _0023_003DzCJy6o9PkJ45N(IList<Entity> _0023_003DzHyqiRqo_003D, bool _0023_003DzGhkfdMlbGS2U, bool _0023_003DzhQd3_0024ARpbtAn, bool _0023_003DztCnZIL5yoxwm)
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D == null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590172));
		}
		return Camera.UpdateBoundingBox(GetViewFrame(), _0023_003DzHyqiRqo_003D, _0023_003Dz0TvaYNo_003D.Document, _0023_003DzGhkfdMlbGS2U, _0023_003DzhQd3_0024ARpbtAn, _0023_003DztCnZIL5yoxwm);
	}

	private bool _0023_003DzPGxnVyTKGM9N()
	{
		return Background.ShouldSerialize(_0023_003DzfFA_QshWCz0g());
	}

	private void _0023_003DzZ51EZb0ReihX()
	{
		Background = _0023_003DzfFA_QshWCz0g();
	}

	internal static BackgroundSettings _0023_003DzfFA_QshWCz0g()
	{
		return new BackgroundSettings();
	}

	internal Vector3D _0023_003DzMB83XGDinl92OIp2qQ_003D_003D(int _0023_003DzKLc12hw_003D, int _0023_003DzZmkJseI_003D, rotationCenterType _0023_003DzdsGv5Zw_003D, int _0023_003DzatgWgTMc3NTm)
	{
		if (_0023_003DzDCV7KMgcH_0024l5stDfAA_003D_003D)
		{
			_0023_003DzdsGv5Zw_003D = rotationCenterType.ViewportCenter;
		}
		int width = Size.Width;
		int height = Size.Height;
		double num = 2.0 * (double)_0023_003DzKLc12hw_003D - (double)width;
		double num2 = (double)height - 2.0 * (double)_0023_003DzZmkJseI_003D;
		System.Drawing.Point point = System.Drawing.Point.Empty;
		bool flag = false;
		if (_0023_003DzdsGv5Zw_003D != rotationCenterType.ViewportCenter)
		{
			Point2D point2D = Camera.WorldToScreen(Camera.centerOfRotation, GetViewFrame());
			point = _0023_003DzSeGspan5F6gF(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			flag = true;
		}
		else if (_0023_003Dzl94UA_0024lVBcra != System.Drawing.Point.Empty)
		{
			point = _0023_003Dzl94UA_0024lVBcra;
			flag = true;
		}
		if (flag)
		{
			num -= 2.0 * ((double)point.X - (double)width / 2.0);
			num2 -= 2.0 * ((double)height / 2.0 - (double)point.Y);
		}
		double num3 = (double)Math.Max(width, height) / 2.0;
		double num4 = num * num + num2 * num2;
		double num5 = ((num4 != 0.0) ? Math.Sqrt(num4) : 0.0);
		double x = ((!(num5 <= num3 / 1.4142135623730951)) ? (num3 * num3 / (2.0 * num5)) : Math.Sqrt(num3 * num3 - num4));
		Vector3D vector3D = new Vector3D(x, num, num2);
		vector3D.Normalize();
		return vector3D;
	}

	internal bool _0023_003DzL28lpFu5le27()
	{
		if ((_0023_003Dz2bwAPoQwFwzX.StyleMode == backgroundStyleType.Image && Background.Texture == null) || (_0023_003Dz2bwAPoQwFwzX.StyleMode == backgroundStyleType.CubicGradient && !Background.Texture.IsValid()) || _0023_003DzXldEn8dxMaC2.Count(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzDO2YN9mgqCrH_7FeV7WwIyU_003D) > 0)
		{
			return true;
		}
		if (_0023_003DzMUeJTCp30C0O != null && _0023_003DzMUeJTCp30C0O.Count((OriginSymbol _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D?._0023_003DzL28lpFu5le27() ?? false) > 0)
		{
			return true;
		}
		return false;
	}

	public PlaneEquation[] GetCameraFrustum()
	{
		return Camera.GetFrustum(GetViewFrame(), _0023_003Dz_OlmZyU_003D: false);
	}

	internal PlaneEquation[] _0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(bool _0023_003DzPHqp5dQ_003D)
	{
		return Camera.GetFrustum(GetViewFrame(), _0023_003DzPHqp5dQ_003D);
	}

	internal void _0023_003Dz8WTvZ9I_003D(TextureBase _0023_003DzrRiTzRDcSNK7)
	{
		CompileBackground();
		if (_0023_003DzMUeJTCp30C0O != null)
		{
			OriginSymbol[] array = _0023_003DzMUeJTCp30C0O;
			foreach (OriginSymbol originSymbol in array)
			{
				originSymbol.CreateLabels(this, _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
				originSymbol._0023_003Dz8WTvZ9I_003D(_0023_003Dz0TvaYNo_003D, _0023_003DzrRiTzRDcSNK7);
			}
		}
		if (_0023_003DzFfOjsSRCbzpd == null)
		{
			_0023_003DzkPsfwLNwb5PBfcO83g_003D_003D();
		}
		if (_0023_003DznPu5SKE_003D != null)
		{
			_0023_003DznPu5SKE_003D._0023_003Dz8WTvZ9I_003D(_0023_003Dz0TvaYNo_003D, this);
		}
		if (_0023_003DzFfOjsSRCbzpd != null)
		{
			_0023_003DzFfOjsSRCbzpd.CreateLabels(this, _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
			_0023_003DzFfOjsSRCbzpd._0023_003Dz8WTvZ9I_003D(_0023_003Dz0TvaYNo_003D, _0023_003DzrRiTzRDcSNK7);
		}
		if (_0023_003Dz4ry2vZefVkxX != null)
		{
			_0023_003Dz4ry2vZefVkxX._0023_003DztTeP7_0024pDa3AKQJRYIg_003D_003D(this, new CompileParams(_0023_003Dz0TvaYNo_003D), new RegenParams(_0023_003Dz0TvaYNo_003D.Entities), _0023_003Dz0TvaYNo_003D._0023_003Dz0fqXN00AlqdN);
		}
		Grid[] grids = Grids;
		for (int i = 0; i < grids.Length; i++)
		{
			grids[i]._0023_003Dz8WTvZ9I_003D(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
		}
		Legend[] array2 = _0023_003Dz6SHaVGO9Xhk5;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i]._0023_003Dz8WTvZ9I_003D();
		}
	}

	public bool Contains(System.Drawing.Point mousePos)
	{
		return new Rectangle(_0023_003DzWYBO1c4_003D, Size).Contains(mousePos);
	}

	protected internal void FireLabelSelectionChanged(SelectionChangedEventArgs eventArgs)
	{
		if (_0023_003DzT6PtKP0Nd2u9 != null)
		{
			_0023_003DzT6PtKP0Nd2u9(this, eventArgs);
		}
	}

	public void SetView(viewType view)
	{
		SetView(view, fit: false, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public void SetView(viewType view, bool fit, bool animate)
	{
		SetView(view, fit, animate, Zoom.FitMargin);
	}

	public void SetView(Quaternion rotation, bool fit, bool animate)
	{
		SetView(rotation, fit, animate, Zoom.FitMargin);
	}

	public void SetView(viewType view, bool fit, bool animate, int margin, bool selectedOnly = false, int duration = 0)
	{
		_0023_003DzX3oLMGz_0024hdot(view, fit, animate, margin, selectedOnly, (duration <= 0) ? _0023_003Dz0TvaYNo_003D.AnimateCameraDuration : duration, _0023_003DzcrzHsdlHfHM0: false);
	}

	public void SetView(Quaternion rotation, bool fit, bool animate, int margin, bool selectedOnly = false, int duration = 0)
	{
		_0023_003DzX3oLMGz_0024hdot(viewType.Other, rotation, fit, animate, margin, selectedOnly, (duration <= 0) ? _0023_003Dz0TvaYNo_003D.AnimateCameraDuration : duration, _0023_003DzcrzHsdlHfHM0: false, null);
	}

	public void StopCameraAnimation()
	{
		_0023_003DzfLdirBQzz65VaJxkHQ_003D_003D();
		_0023_003DzfZLR91_0024cZ_00242T(_0023_003DzU3EkUPI_003D: true);
	}

	private void _0023_003DzfLdirBQzz65VaJxkHQ_003D_003D()
	{
		_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Stop();
		if (_0023_003Dz4ry2vZefVkxX != null)
		{
			_0023_003Dz4ry2vZefVkxX._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: false);
		}
	}

	public bool IsCameraAnimating()
	{
		return _0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning;
	}

	private void _0023_003DzX3oLMGz_0024hdot(viewType _0023_003Dzm1Aquqk_003D, bool _0023_003DzWrfLNCo_003D, bool _0023_003DzBQC8k3F0wJN4, int _0023_003DzPG6BDWw_003D, bool _0023_003DzGhkfdMlbGS2U, int _0023_003Dz1MUVfpg_003D, bool _0023_003DzcrzHsdlHfHM0)
	{
		_0023_003DzX3oLMGz_0024hdot(_0023_003Dzm1Aquqk_003D, GetCameraRotation(_0023_003Dzm1Aquqk_003D, (ViewCubeIcon != null) ? ViewCubeIcon.InitialRotation : null), _0023_003DzWrfLNCo_003D, _0023_003DzBQC8k3F0wJN4, _0023_003DzPG6BDWw_003D, _0023_003DzGhkfdMlbGS2U, _0023_003Dz1MUVfpg_003D, _0023_003DzcrzHsdlHfHM0, null);
	}

	private void _0023_003DzX3oLMGz_0024hdot(viewType _0023_003Dzm1Aquqk_003D, Quaternion _0023_003DzcJhMAdM_003D, bool _0023_003DzWrfLNCo_003D, bool _0023_003DzBQC8k3F0wJN4, int _0023_003DzPG6BDWw_003D, bool _0023_003DzGhkfdMlbGS2U, int _0023_003Dz1MUVfpg_003D, bool _0023_003DzcrzHsdlHfHM0, IList<Entity> _0023_003DzHyqiRqo_003D)
	{
		if (!_0023_003DzWrfLNCo_003D)
		{
			Workspace workspace = _0023_003Dz0TvaYNo_003D;
			bool flag = true;
			Workspace workspace2 = workspace;
			object[] array = null;
			array = new object[2] { workspace2, flag };
			_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		}
		if (!_0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: true);
			if (_0023_003DzcJhMAdM_003D == null)
			{
				_0023_003DzcJhMAdM_003D = Camera.Rotation;
			}
			if (_0023_003DzcrzHsdlHfHM0)
			{
				Camera.Rotation = _0023_003DzcJhMAdM_003D;
			}
			else
			{
				_0023_003DzJga0vcj4OAT_0024(_0023_003Dzm1Aquqk_003D, _0023_003DzcJhMAdM_003D, _0023_003DzWrfLNCo_003D, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4, _0023_003DzGhkfdMlbGS2U, _0023_003Dz1MUVfpg_003D, _0023_003Dzk7pNhlbdSzPJ: true, _0023_003DzHyqiRqo_003D);
			}
			SavedViews.Save();
			if (!_0023_003DzBQC8k3F0wJN4)
			{
				_0023_003Dz0TvaYNo_003D._0023_003Dz8fFk9aTlvPdc(this, _0023_003Dzm1Aquqk_003D);
			}
		}
	}

	public void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor)
	{
		SetView(rotation, target, distance, zoomFactor, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor, bool animate)
	{
		Workspace workspace = _0023_003Dz0TvaYNo_003D;
		bool flag = true;
		Workspace workspace2 = workspace;
		object[] array = null;
		array = new object[2] { workspace2, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		if (!_0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: true);
			if (animate)
			{
				_0023_003Dzng_0024CGOsQn8X8(viewType.Other, _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this), _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, Camera.Rotation, Camera.Target, Camera.Distance, Camera.ZoomFactor, rotation, target, distance, zoomFactor);
				return;
			}
			Camera.Rotation = rotation;
			Camera.Target = target;
			Camera.Distance = distance;
			Camera.ZoomFactor = zoomFactor;
			AdjustNearAndFarPlanes();
			SavedViews.Save();
			_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
			_0023_003Dz11CadYMOXmz_();
		}
	}

	public Quaternion GetCameraRotation(viewType view, Quaternion initialRotation = null)
	{
		Quaternion _0023_003DzBmN_0024U9I_003D = Camera.GetViewRotation(view);
		if (_0023_003DzBmN_0024U9I_003D == null)
		{
			_0023_003DzBmN_0024U9I_003D = Camera.InitialRotation;
		}
		if (_0023_003Dz0TvaYNo_003D._0023_003Dz0fqXN00AlqdN == orientationType.UpAxisY)
		{
			_0023_003DzBmN_0024U9I_003D = new Quaternion(Vector3D.AxisX, 90.0) * _0023_003DzBmN_0024U9I_003D;
		}
		if (initialRotation != null)
		{
			_0023_003DzBmN_0024U9I_003D = initialRotation * _0023_003DzBmN_0024U9I_003D;
		}
		if (!_0023_003Dz0TvaYNo_003D._0023_003Dzsr62oKVDDQue_0024_0024wA43zLq0s_003D())
		{
			_0023_003Dzi5Tl7KWlzbTh7HXfHw_003D_003D(ref _0023_003DzBmN_0024U9I_003D);
		}
		return _0023_003DzBmN_0024U9I_003D;
	}

	internal void _0023_003Dzi5Tl7KWlzbTh7HXfHw_003D_003D(ref Quaternion _0023_003DzBmN_0024U9I_003D)
	{
		Quaternion rotation = Camera.Rotation;
		Camera.Rotation = _0023_003DzBmN_0024U9I_003D;
		Camera.GetFrame(out var origin, out var camX, out var camY, out var camZ);
		Camera.Rotation = rotation;
		if (!(camZ != null))
		{
			return;
		}
		Camera.GetFrame(out origin, out var _, out var camY2, out var _);
		double num = Math.Abs(Vector3D.AngleBetween(camY2, camY));
		double num2 = Math.Abs(Vector3D.AngleBetween(camY2, camX));
		double num3 = Math.Abs(Vector3D.AngleBetween(camY2, -1.0 * camY));
		double num4 = Math.Abs(Vector3D.AngleBetween(camY2, -1.0 * camX));
		int num5 = 0;
		double num6 = num;
		if (!Utility.AreEqual(num2, num6, Math.PI * 2.0) && num2 < num6)
		{
			num6 = num2;
			num5 = 1;
		}
		if (!Utility.AreEqual(num3, num6, Math.PI * 2.0) && num3 < num6)
		{
			num6 = num3;
			num5 = 2;
		}
		if (!Utility.AreEqual(num4, num6, Math.PI * 2.0) && num4 < num6)
		{
			num6 = num4;
			num5 = 3;
		}
		if (num5 == 0 && Utility.AreEqual(num6, Math.PI / 2.0, Math.PI * 2.0))
		{
			Camera.GetFrame(out origin, out var camX3, out var _, out var _);
			double a = Vector3D.Dot(camX3, camX);
			if (Utility.AreEqual(a, 1.0, 1.0))
			{
				num5 = 0;
			}
			else if (Utility.AreEqual(a, -1.0, 1.0))
			{
				num5 = 2;
			}
			else if (Utility.AreEqual(a, 0.0, 1.0))
			{
				a = Vector3D.Dot(camX3, camY);
				if (Utility.AreEqual(a, 1.0, 1.0))
				{
					num5 = 3;
				}
				else if (Utility.AreEqual(a, -1.0, 1.0))
				{
					num5 = 1;
				}
			}
		}
		switch (num5)
		{
		case 1:
			_0023_003DzBmN_0024U9I_003D = new Quaternion(camZ, 90.0) * _0023_003DzBmN_0024U9I_003D;
			break;
		case 2:
			_0023_003DzBmN_0024U9I_003D = new Quaternion(camZ, 180.0) * _0023_003DzBmN_0024U9I_003D;
			break;
		case 3:
			_0023_003DzBmN_0024U9I_003D = new Quaternion(camZ, 270.0) * _0023_003DzBmN_0024U9I_003D;
			break;
		case 0:
			break;
		}
	}

	private void _0023_003DzJga0vcj4OAT_0024(viewType _0023_003Dzm1Aquqk_003D, Quaternion _0023_003DzcJhMAdM_003D, bool _0023_003DzWrfLNCo_003D, int _0023_003DzPG6BDWw_003D, bool _0023_003DzBQC8k3F0wJN4, bool _0023_003DzGhkfdMlbGS2U, int _0023_003Dz1MUVfpg_003D, bool _0023_003Dzk7pNhlbdSzPJ, IList<Entity> _0023_003DzY_0024ABPwh9wryC)
	{
		if (_0023_003DzBQC8k3F0wJN4)
		{
			Point3D target = Camera.Target;
			double distance = Camera.Distance;
			double zoomFactor = Camera.ZoomFactor;
			Quaternion rotation = Camera.Rotation;
			Point3D point3D = null;
			double num = 0.0;
			double num2 = 0.0;
			if (_0023_003DzWrfLNCo_003D)
			{
				Camera.Rotation = _0023_003DzcJhMAdM_003D;
				if (_0023_003Dzk7pNhlbdSzPJ)
				{
					_0023_003DzcJhMAdM_003D = Camera.Rotation;
				}
				IList<Entity> _0023_003DzY_0024ABPwh9wryC2;
				if (_0023_003DzY_0024ABPwh9wryC != null)
				{
					_0023_003DzY_0024ABPwh9wryC2 = _0023_003DzY_0024ABPwh9wryC;
				}
				else
				{
					IList<Entity> list = new List<Entity> { _0023_003Dz0TvaYNo_003D._0023_003DzpU_kB1T_2Sae() };
					_0023_003DzY_0024ABPwh9wryC2 = list;
				}
				_0023_003Dz7hZyO75hkvCs(_0023_003DzY_0024ABPwh9wryC2, _0023_003DzGhkfdMlbGS2U, Zoom.FitLabels, Zoom.PerspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: false, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4: false, _0023_003Dz_00246Jev2I_003D: false, _0023_003DzhQd3_0024ARpbtAn: false);
				point3D = Camera.Target;
				num = Camera.Distance;
				num2 = Camera.ZoomFactor;
				Camera.Target = target;
				Camera.Distance = distance;
				Camera.ZoomFactor = zoomFactor;
				Camera.Rotation = rotation;
			}
			else
			{
				Camera.ApplyCenterOfRotation(GetViewFrame(), Rotate.RotationCenter);
				Camera.Rotation = _0023_003DzcJhMAdM_003D;
				if (_0023_003Dzk7pNhlbdSzPJ)
				{
					_0023_003DzcJhMAdM_003D = Camera.Rotation;
				}
				Camera.UpdateLocation();
				Camera.RemoveOffsetForRotation();
				point3D = Camera.Target;
				num = Camera.Distance;
				num2 = Camera.ZoomFactor;
				Camera.Target = target;
				Camera.Distance = distance;
				Camera.ZoomFactor = zoomFactor;
				Camera.Rotation = rotation;
			}
			_0023_003Dzng_0024CGOsQn8X8(_0023_003Dzm1Aquqk_003D, _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this), _0023_003Dz1MUVfpg_003D, Camera.Rotation, Camera.Target, Camera.Distance, Camera.ZoomFactor, _0023_003DzcJhMAdM_003D, point3D, num, num2);
			return;
		}
		if (_0023_003DzcJhMAdM_003D != null)
		{
			Camera.ApplyCenterOfRotation(GetViewFrame(), Rotate.RotationCenter);
			Camera.Rotation = _0023_003DzcJhMAdM_003D;
			Camera.UpdateLocation();
			Camera.RemoveOffsetForRotation();
		}
		if (_0023_003DzWrfLNCo_003D)
		{
			IList<Entity> _0023_003DzY_0024ABPwh9wryC3;
			if (_0023_003DzY_0024ABPwh9wryC != null)
			{
				_0023_003DzY_0024ABPwh9wryC3 = _0023_003DzY_0024ABPwh9wryC;
			}
			else
			{
				IList<Entity> list = new List<Entity> { _0023_003Dz0TvaYNo_003D._0023_003DzpU_kB1T_2Sae() };
				_0023_003DzY_0024ABPwh9wryC3 = list;
			}
			_0023_003Dz7hZyO75hkvCs(_0023_003DzY_0024ABPwh9wryC3, _0023_003DzGhkfdMlbGS2U: false, Zoom.FitLabels, Zoom.PerspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: false, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4: false, _0023_003Dz_00246Jev2I_003D: false, _0023_003DzhQd3_0024ARpbtAn: false);
		}
		else
		{
			AdjustNearAndFarPlanes();
			_0023_003Dz11CadYMOXmz_();
		}
		_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
	}

	internal void _0023_003Dzng_0024CGOsQn8X8(viewType _0023_003Dzm1Aquqk_003D, int _0023_003DzZnwLfu4_003D, int _0023_003DzhikinKj9EXc_0024, Quaternion _0023_003Dz46XyMQpz32rO, Point3D _0023_003DzYQjkBbk_003D, double _0023_003DzgB209ewmsp5_0024, double _0023_003Dzi0o8q5bhQ78t, Quaternion _0023_003DzcJhMAdM_003D, Point3D _0023_003Dz6h6hSPo_003D, double _0023_003DzfAlSRac_003D, double _0023_003Dz6f9Nj0FD50hd)
	{
		if (!_0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D = new Camera.ViewOrientationAnimator(this, _0023_003Dzm1Aquqk_003D, _0023_003Dz46XyMQpz32rO, _0023_003DzYQjkBbk_003D, _0023_003DzgB209ewmsp5_0024, _0023_003Dzi0o8q5bhQ78t, _0023_003DzcJhMAdM_003D, _0023_003Dz6h6hSPo_003D, _0023_003DzfAlSRac_003D, _0023_003Dz6f9Nj0FD50hd, _0023_003DzhikinKj9EXc_0024, _0023_003DzquoqIfkvPe1jPST4OlipOoU_003D);
			if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Start(_0023_003DzZnwLfu4_003D) && _0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003Dz4ry2vZefVkxX._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: true);
			}
		}
	}

	internal bool _0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D()
	{
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D != null)
		{
			return _0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning;
		}
		return false;
	}

	internal void _0023_003DzDela6KtNzcrF(int _0023_003DzZnwLfu4_003D, Point3D _0023_003DzYQjkBbk_003D, double _0023_003DzgB209ewmsp5_0024, double _0023_003Dzi0o8q5bhQ78t)
	{
		Point3D target = _0023_003DzZ_0024IejP0R_0024_Cw.Target;
		double distance = _0023_003DzZ_0024IejP0R_0024_Cw.Distance;
		double zoomFactor = _0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor;
		_0023_003DzZ_0024IejP0R_0024_Cw.Target = _0023_003DzYQjkBbk_003D;
		_0023_003DzZ_0024IejP0R_0024_Cw.Distance = _0023_003DzgB209ewmsp5_0024;
		_0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor = _0023_003Dzi0o8q5bhQ78t;
		if (!_0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D = new Camera.ViewPositionAnimator(this, _0023_003DzYQjkBbk_003D, _0023_003DzgB209ewmsp5_0024, _0023_003Dzi0o8q5bhQ78t, target, distance, zoomFactor, _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, _0023_003DzquoqIfkvPe1jPST4OlipOoU_003D);
			if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Start(_0023_003DzZnwLfu4_003D) && _0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003Dz4ry2vZefVkxX._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: true);
			}
		}
	}

	private void _0023_003DzquoqIfkvPe1jPST4OlipOoU_003D(object _0023_003Dz45rq_i0_003D)
	{
		try
		{
			if (_0023_003Dz0TvaYNo_003D.InvokeRequired)
			{
				_0023_003Dz0TvaYNo_003D.BeginInvoke((MethodInvoker)delegate
				{
					if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null && !base.Disposed)
					{
						_0023_003Dz0TvaYNo_003D.Moving = true;
						bool isFinished = _0023_003DzDjhJAu3TqX_chipY9w_003D_003D.IsFinished;
						if (isFinished)
						{
							_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Stop();
							if (_0023_003Dz4ry2vZefVkxX != null)
							{
								_0023_003Dz4ry2vZefVkxX._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: false);
							}
							_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.FinalFrame(this);
						}
						else
						{
							_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.NextFrame(this);
						}
						Camera.Update(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Camera);
						AdjustNearAndFarPlanes();
						if (isFinished)
						{
							_0023_003DzfLdirBQzz65VaJxkHQ_003D_003D();
							_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.FinalFrame(this);
						}
						else
						{
							_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.NextFrame(this);
						}
						Camera.Update(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Camera);
						AdjustNearAndFarPlanes();
						_0023_003DzfZLR91_0024cZ_00242T(isFinished);
					}
				});
			}
			else
			{
				_0023_003DzOvmuANEjbc4kZJ_0024kmA_003D_003D();
			}
		}
		catch (ObjectDisposedException)
		{
		}
	}

	private void _0023_003DzOvmuANEjbc4kZJ_0024kmA_003D_003D()
	{
		if (!_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning || _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D == null || base.Disposed)
		{
			return;
		}
		_0023_003Dz0TvaYNo_003D.Moving = true;
		bool isFinished = _0023_003DzDjhJAu3TqX_chipY9w_003D_003D.IsFinished;
		if (isFinished)
		{
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Stop();
			if (_0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003Dz4ry2vZefVkxX._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: false);
			}
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.FinalFrame(this);
		}
		else
		{
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.NextFrame(this);
		}
		Camera.Update(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Camera);
		AdjustNearAndFarPlanes();
		if (isFinished)
		{
			_0023_003DzfLdirBQzz65VaJxkHQ_003D_003D();
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.FinalFrame(this);
		}
		else
		{
			_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.NextFrame(this);
		}
		Camera.Update(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.Camera);
		AdjustNearAndFarPlanes();
		_0023_003DzfZLR91_0024cZ_00242T(isFinished);
	}

	private void _0023_003DzfZLR91_0024cZ_00242T(bool _0023_003DzU3EkUPI_003D)
	{
		if (_0023_003DzU3EkUPI_003D)
		{
			SavedViews.Save();
			if (!base.Disposed)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzswdnfpGrZ2Nx(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.viewportIndex);
				_0023_003Dz0TvaYNo_003D._0023_003DzqCYquA6AxCkt(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.viewportIndex);
			}
		}
		else
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzxGGgnz7xWECo(_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.viewportIndex);
		}
	}

	internal void _0023_003DzhXjMbKHjJh6K(RenderContextBase _0023_003DzmNZD0Zs_003D, Viewport _0023_003DzYzWi5Yw_003D, SelectionBoxColorsSettings _0023_003Dz_0024nm97RAN4Qmp, int _0023_003DzkQAiKLA_003D, actionType _0023_003DzfcUzrRi_0024u6FZ, System.Drawing.Point _0023_003DzGMZeB6x0cGrU, System.Drawing.Point _0023_003DzjRmmVH2Hj_0024KY)
	{
		_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
		int y = _0023_003DzkQAiKLA_003D - _0023_003DzGMZeB6x0cGrU.Y - 1;
		int y2 = _0023_003DzkQAiKLA_003D - _0023_003DzjRmmVH2Hj_0024KY.Y - 1;
		int alpha = (int)(_0023_003DzYzWi5Yw_003D.Background.ColorThemeTransparency * 255.0);
		bool borderXOR = _0023_003Dz0TvaYNo_003D.SelectionBoxColors.BorderXOR;
		switch (_0023_003DzfcUzrRi_0024u6FZ)
		{
		case actionType.ZoomWindow:
			_0023_003DzQgzvSCbrth65(new System.Drawing.Point(_0023_003DzGMZeB6x0cGrU.X, y), new System.Drawing.Point(_0023_003DzjRmmVH2Hj_0024KY.X, y2));
			break;
		case actionType.SelectByBox:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Crossing);
			_0023_003Dz2O0qUCk0lSlB(new System.Drawing.Point(_0023_003DzGMZeB6x0cGrU.X, y), new System.Drawing.Point(_0023_003DzjRmmVH2Hj_0024KY.X, y2), borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz6E6bsdvtECEG: true, _0023_003Dzuz9UipUHOZ6d3RT7iw_003D_003D: true);
			break;
		}
		case actionType.SelectByBoxEnclosed:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Enclosed);
			_0023_003Dz2O0qUCk0lSlB(new System.Drawing.Point(_0023_003DzGMZeB6x0cGrU.X, y), new System.Drawing.Point(_0023_003DzjRmmVH2Hj_0024KY.X, y2), borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz6E6bsdvtECEG: true, _0023_003Dzuz9UipUHOZ6d3RT7iw_003D_003D: false);
			break;
		}
		case actionType.SelectVisibleByBox:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Visible);
			_0023_003Dz2O0qUCk0lSlB(new System.Drawing.Point(_0023_003DzGMZeB6x0cGrU.X, y), new System.Drawing.Point(_0023_003DzjRmmVH2Hj_0024KY.X, y2), borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz6E6bsdvtECEG: true, _0023_003Dzuz9UipUHOZ6d3RT7iw_003D_003D: false);
			break;
		}
		case actionType.SelectByPolygon:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Crossing);
			_0023_003Dz0TvaYNo_003D._0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzhXjMbKHjJh6K(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzGMZeB6x0cGrU, _0023_003Dz0TvaYNo_003D, borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz2Z9zjjRdA2Ai: true);
			break;
		}
		case actionType.SelectByPolygonEnclosed:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Enclosed);
			_0023_003Dz0TvaYNo_003D._0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzhXjMbKHjJh6K(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzGMZeB6x0cGrU, _0023_003Dz0TvaYNo_003D, borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz2Z9zjjRdA2Ai: false);
			break;
		}
		case actionType.SelectVisibleByPolygon:
		{
			Color selectionBoxColor = Background.GetSelectionBoxColor(_0023_003Dz_0024nm97RAN4Qmp.Visible);
			_0023_003Dz0TvaYNo_003D._0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzhXjMbKHjJh6K(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzGMZeB6x0cGrU, _0023_003Dz0TvaYNo_003D, borderXOR, Color.FromArgb(alpha, selectionBoxColor), _0023_003Dz2Z9zjjRdA2Ai: true);
			break;
		}
		case actionType.MagnifyingGlass:
		case actionType.SelectByPick:
		case actionType.SelectVisibleByPick:
		case actionType.SelectVisibleByPickDynamic:
			break;
		}
	}

	private void _0023_003DzQgzvSCbrth65(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D)
	{
		RenderContextBase _0023_003DzmNZD0Zs_003D = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D;
		_0023_003DzIVnnC2LpYijNTM5v7Q_003D_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, out var _0023_003DzY0quLqCMCBkJ, out var _0023_003DzE72eMc0nSfD);
		Point3D[] _0023_003Dz_KfgXoE_003D = _0023_003DzuwFNAl0kzJ9x(_0023_003DzY0quLqCMCBkJ, _0023_003DzE72eMc0nSfD);
		Color _0023_003DzeTmvM9c_003D = Background.GetContrastColorSemiTransparent();
		if (!Zoom.BoxColor.IsEmpty)
		{
			_0023_003DzeTmvM9c_003D = Color.FromArgb(_0023_003DzeTmvM9c_003D.A, Zoom.BoxColor);
		}
		_0023_003DzvHesaw7SJTao(_0023_003DzmNZD0Zs_003D, _0023_003DzeTmvM9c_003D, _0023_003Dz_KfgXoE_003D);
		float num = (float)(_0023_003DzE72eMc0nSfD.X - _0023_003DzY0quLqCMCBkJ.X);
		float num2 = (float)(_0023_003DzE72eMc0nSfD.Y - _0023_003DzY0quLqCMCBkJ.Y);
		float num3 = Math.Min(num, num2);
		int num4 = 20;
		float num5 = num4;
		if (num3 / 2f < (float)num4)
		{
			num5 = num3 / 2f;
		}
		if (Zoom.BorderXOR)
		{
			_0023_003DzmNZD0Zs_003D.EnableXOR(enable: true);
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(255, Zoom.BoxColor));
		}
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
		float num6 = (float)_0023_003DzY0quLqCMCBkJ.X;
		float num7 = (float)_0023_003DzE72eMc0nSfD.X;
		float num8 = (float)_0023_003DzY0quLqCMCBkJ.Y;
		float num9 = (float)_0023_003DzE72eMc0nSfD.Y;
		_0023_003DzmNZD0Zs_003D.DrawLineStrip(new float[9]
		{
			num6,
			num8 + num5,
			0f,
			num6,
			num8,
			0f,
			num6 + num5,
			num8,
			0f
		});
		_0023_003DzmNZD0Zs_003D.DrawLineStrip(new float[9]
		{
			num6,
			num9 - num5,
			0f,
			num6,
			num9,
			0f,
			num6 + num5,
			num9,
			0f
		});
		_0023_003DzmNZD0Zs_003D.DrawLineStrip(new float[9]
		{
			num7,
			num9 - num5,
			0f,
			num7,
			num9,
			0f,
			num7 - num5,
			num9,
			0f
		});
		_0023_003DzmNZD0Zs_003D.DrawLineStrip(new float[9]
		{
			num7 - num5,
			num8,
			0f,
			num7,
			num8,
			0f,
			num7,
			num8 + num5,
			0f
		});
		float num10 = num6 + num / 2f;
		float num11 = num8 + num2 / 2f;
		float num12 = num5 / 2f;
		_0023_003DzmNZD0Zs_003D.DrawLines(new float[12]
		{
			num10 - num12,
			num11,
			0f,
			num10 + num12,
			num11,
			0f,
			num10,
			num11 - num12,
			0f,
			num10,
			num11 + num12,
			0f
		});
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		if (Zoom.BorderXOR)
		{
			_0023_003DzmNZD0Zs_003D.EnableXOR(enable: false);
		}
	}

	private void _0023_003DzIVnnC2LpYijNTM5v7Q_003D_003D(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D, out Point2D _0023_003DzY0quLqCMCBkJ, out Point2D _0023_003DzE72eMc0nSfD3)
	{
		Utility.NormalizeBox(ref _0023_003DzkW_0024DzQk_003D, ref _0023_003Dz8ecWqr4_003D);
		_0023_003DzY0quLqCMCBkJ = new Point2D((double)_0023_003DzkW_0024DzQk_003D.X + 0.5, (double)_0023_003DzkW_0024DzQk_003D.Y + 0.5);
		_0023_003DzE72eMc0nSfD3 = new Point2D((double)_0023_003Dz8ecWqr4_003D.X + 0.5, (double)_0023_003Dz8ecWqr4_003D.Y + 0.5);
	}

	private void _0023_003Dz2O0qUCk0lSlB(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D, bool _0023_003DzhhJGE92__aK9, Color _0023_003DzeTmvM9c_003D, bool _0023_003Dz6E6bsdvtECEG, bool _0023_003Dzuz9UipUHOZ6d3RT7iw_003D_003D)
	{
		RenderContextBase _0023_003DzmNZD0Zs_003D = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D;
		_0023_003DzIVnnC2LpYijNTM5v7Q_003D_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, out var _0023_003DzY0quLqCMCBkJ, out var _0023_003DzE72eMc0nSfD);
		Point3D[] array = _0023_003DzuwFNAl0kzJ9x(_0023_003DzY0quLqCMCBkJ, _0023_003DzE72eMc0nSfD);
		if (_0023_003Dz6E6bsdvtECEG)
		{
			if (_0023_003DzhhJGE92__aK9)
			{
				_0023_003DzmNZD0Zs_003D.EnableXOR(enable: true);
			}
			else
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(255, _0023_003DzeTmvM9c_003D));
			}
			if (_0023_003Dzuz9UipUHOZ6d3RT7iw_003D_003D)
			{
				_0023_003DzmNZD0Zs_003D.SetLineStipple(1, 3855, Camera);
				_0023_003DzmNZD0Zs_003D.EnableLineStipple(enable: true);
			}
			_0023_003DzmNZD0Zs_003D.DrawLineLoop(new Point3D[4]
			{
				array[0],
				array[1],
				array[2],
				array[5]
			});
			_0023_003DzmNZD0Zs_003D.EnableLineStipple(enable: false);
			if (_0023_003DzhhJGE92__aK9)
			{
				_0023_003DzmNZD0Zs_003D.EnableXOR(enable: false);
			}
		}
		_0023_003DzvHesaw7SJTao(_0023_003DzmNZD0Zs_003D, _0023_003DzeTmvM9c_003D, array);
	}

	private static void _0023_003DzvHesaw7SJTao(RenderContextBase _0023_003DzmNZD0Zs_003D, Color _0023_003DzeTmvM9c_003D, Point3D[] _0023_003Dz_KfgXoE_003D)
	{
		_0023_003DzmNZD0Zs_003D.PushBlendState();
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		if (_0023_003DzmNZD0Zs_003D.HasStencil())
		{
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Always_1_1_Op_Replace_Replace_Replace);
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
			_0023_003DzmNZD0Zs_003D.SetState(blendStateType.ColorMaskOff);
			_0023_003DzmNZD0Zs_003D.DrawLineLoop(new Point3D[4]
			{
				new Point3D(_0023_003Dz_KfgXoE_003D[0].X, _0023_003Dz_KfgXoE_003D[0].Y, -0.99),
				new Point3D(_0023_003Dz_KfgXoE_003D[1].X, _0023_003Dz_KfgXoE_003D[1].Y, -0.99),
				new Point3D(_0023_003Dz_KfgXoE_003D[2].X, _0023_003Dz_KfgXoE_003D[2].Y, -0.99),
				new Point3D(_0023_003Dz_KfgXoE_003D[5].X, _0023_003Dz_KfgXoE_003D[5].Y, -0.99)
			});
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_NotEqual_1_FF_Op_Keep_keep_keep);
		}
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzeTmvM9c_003D);
		_0023_003DzmNZD0Zs_003D.DrawTriangles(_0023_003Dz_KfgXoE_003D, Vector3D.AxisZ);
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		_0023_003DzmNZD0Zs_003D.PopBlendState();
	}

	private static Point3D[] _0023_003DzuwFNAl0kzJ9x(Point2D _0023_003DzY0quLqCMCBkJ, Point2D _0023_003DzE72eMc0nSfD3)
	{
		float num = (float)(_0023_003DzE72eMc0nSfD3.X - _0023_003DzY0quLqCMCBkJ.X);
		float num2 = (float)(_0023_003DzE72eMc0nSfD3.Y - _0023_003DzY0quLqCMCBkJ.Y);
		float num3 = (float)_0023_003DzY0quLqCMCBkJ.X;
		float num4 = (float)_0023_003DzY0quLqCMCBkJ.Y;
		float num5 = -0.995f;
		return new Point3D[6]
		{
			new Point3D(num3, num4, num5),
			new Point3D(num3 + num, num4, num5),
			new Point3D(num3 + num, num4 + num2, num5),
			new Point3D(num3, num4, num5),
			new Point3D(num3 + num, num4 + num2, num5),
			new Point3D(num3, num4 + num2, num5)
		};
	}

	private void _0023_003Dz_feN2jsfs6O0(ref double _0023_003DzMFTjHfa4_giP, ref double _0023_003DzTXlfp6pm_0024l4F)
	{
		_0023_003DzMFTjHfa4_giP -= _0023_003DzWYBO1c4_003D.X;
		_0023_003DzTXlfp6pm_0024l4F -= _0023_003DzWYBO1c4_003D.Y;
	}

	private void _0023_003Dz_feN2jsfs6O0(ref int _0023_003DzMFTjHfa4_giP, ref int _0023_003DzTXlfp6pm_0024l4F)
	{
		_0023_003DzMFTjHfa4_giP -= _0023_003DzWYBO1c4_003D.X;
		_0023_003DzTXlfp6pm_0024l4F -= _0023_003DzWYBO1c4_003D.Y;
	}

	internal void _0023_003Dz99_0024gH6eUUxNX(ref double _0023_003DzMFTjHfa4_giP, ref double _0023_003DzTXlfp6pm_0024l4F)
	{
		_0023_003DzMFTjHfa4_giP += _0023_003DzWYBO1c4_003D.X;
		_0023_003DzTXlfp6pm_0024l4F += _0023_003DzWYBO1c4_003D.Y;
	}

	internal void _0023_003Dz99_0024gH6eUUxNX(ref int _0023_003DzMFTjHfa4_giP, ref int _0023_003DzTXlfp6pm_0024l4F)
	{
		_0023_003DzMFTjHfa4_giP += _0023_003DzWYBO1c4_003D.X;
		_0023_003DzTXlfp6pm_0024l4F += _0023_003DzWYBO1c4_003D.Y;
	}

	internal System.Drawing.Point _0023_003Dzc1MVb2VApXOF(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		_0023_003DzfOC0YjY_003D.Y = Size.Height - _0023_003DzfOC0YjY_003D.Y;
		return _0023_003DzfOC0YjY_003D;
	}

	internal System.Drawing.Point _0023_003DzXE5TU6bFQi1B(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		_0023_003DzfOC0YjY_003D.Y = Size.Height - _0023_003DzfOC0YjY_003D.Y;
		return _0023_003DzfOC0YjY_003D;
	}

	public System.Drawing.Point ViewportToCameraScreen(System.Drawing.Point pt)
	{
		return _0023_003Dzobb8hRaeYuXz(ViewportToScreen(pt));
	}

	internal System.Drawing.Point _0023_003DzSeGspan5F6gF(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		return ScreenToViewport(_0023_003Dz3Pn_Al_lWy7g(_0023_003DzfOC0YjY_003D));
	}

	public System.Drawing.Point ScreenToViewport(System.Drawing.Point pt)
	{
		double _0023_003DzMFTjHfa4_giP = pt.X;
		double _0023_003DzTXlfp6pm_0024l4F = pt.Y;
		_0023_003Dz_feN2jsfs6O0(ref _0023_003DzMFTjHfa4_giP, ref _0023_003DzTXlfp6pm_0024l4F);
		return new System.Drawing.Point((int)_0023_003DzMFTjHfa4_giP, (int)_0023_003DzTXlfp6pm_0024l4F);
	}

	public PointF ScreenToViewport(PointF pt)
	{
		double _0023_003DzMFTjHfa4_giP = pt.X;
		double _0023_003DzTXlfp6pm_0024l4F = pt.Y;
		_0023_003Dz_feN2jsfs6O0(ref _0023_003DzMFTjHfa4_giP, ref _0023_003DzTXlfp6pm_0024l4F);
		return new PointF((float)_0023_003DzMFTjHfa4_giP, (float)_0023_003DzTXlfp6pm_0024l4F);
	}

	public System.Drawing.Point ViewportToScreen(System.Drawing.Point pt)
	{
		double _0023_003DzMFTjHfa4_giP = pt.X;
		double _0023_003DzTXlfp6pm_0024l4F = pt.Y;
		_0023_003Dz99_0024gH6eUUxNX(ref _0023_003DzMFTjHfa4_giP, ref _0023_003DzTXlfp6pm_0024l4F);
		return new System.Drawing.Point((int)_0023_003DzMFTjHfa4_giP, (int)_0023_003DzTXlfp6pm_0024l4F);
	}

	[DebuggerStepThrough]
	internal System.Drawing.Point _0023_003Dzobb8hRaeYuXz(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		return new System.Drawing.Point(_0023_003DzfOC0YjY_003D.X, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - _0023_003DzfOC0YjY_003D.Y);
	}

	internal PointF _0023_003Dzobb8hRaeYuXz(PointF _0023_003DzfOC0YjY_003D)
	{
		return new PointF(_0023_003DzfOC0YjY_003D.X, (float)_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - _0023_003DzfOC0YjY_003D.Y);
	}

	internal System.Drawing.Point _0023_003Dz3Pn_Al_lWy7g(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		return new System.Drawing.Point(_0023_003DzfOC0YjY_003D.X, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - _0023_003DzfOC0YjY_003D.Y);
	}

	internal System.Drawing.Point _0023_003Dz_0WcPl0XuxCA(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		System.Drawing.Point pt = new System.Drawing.Point(_0023_003DzfOC0YjY_003D.X, Size.Height - _0023_003DzfOC0YjY_003D.Y);
		return ViewportToScreen(pt);
	}

	internal System.Drawing.Point _0023_003Dz_0WcPl0XuxCA(System.Drawing.Point _0023_003DzfOC0YjY_003D, int[] _0023_003DzBppTnBIbeUl7)
	{
		System.Drawing.Point pt = new System.Drawing.Point(_0023_003DzfOC0YjY_003D.X, _0023_003DzBppTnBIbeUl7[3] - _0023_003DzfOC0YjY_003D.Y);
		return ViewportToScreen(pt);
	}

	public bool Project(int controlHeight, double objx, double objy, double objz, out double winx, out double winy, out double winz)
	{
		return _0023_003DzotopW_0024w_003D(Camera.GetModelViewProjectionMatrix(), GetViewFrame(), objx, objy, objz, out winx, out winy, out winz);
	}

	internal bool _0023_003DzotopW_0024w_003D(double[] _0023_003DzYgijFM_0024VNOEd, int[] _0023_003DzBppTnBIbeUl7, double _0023_003Dz7TLLaFU2lIpc, double _0023_003DzdaxMqsuT8oAm, double _0023_003DzP0yxPwsLUJDR, out double _0023_003DzMFTjHfa4_giP, out double _0023_003DzTXlfp6pm_0024l4F, out double _0023_003DzdGO9IS3DR52i)
	{
		bool result = Camera.Project(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzYgijFM_0024VNOEd, _0023_003DzBppTnBIbeUl7, _0023_003Dz7TLLaFU2lIpc, _0023_003DzdaxMqsuT8oAm, _0023_003DzP0yxPwsLUJDR, out _0023_003DzMFTjHfa4_giP, out _0023_003DzTXlfp6pm_0024l4F, out _0023_003DzdGO9IS3DR52i);
		_0023_003DzMFTjHfa4_giP -= _0023_003DzBppTnBIbeUl7[0];
		_0023_003DzTXlfp6pm_0024l4F -= _0023_003DzBppTnBIbeUl7[1];
		return result;
	}

	public Point2D[] Project(IList<Point3D> points, int controlHeight)
	{
		int count = points.Count;
		Point2D[] array = new Point2D[count];
		int[] viewFrame = GetViewFrame();
		double[] modelViewProjectionMatrix = Camera.GetModelViewProjectionMatrix();
		for (int i = 0; i < count; i++)
		{
			_0023_003DzotopW_0024w_003D(modelViewProjectionMatrix, viewFrame, points[i].X, points[i].Y, points[i].Z, out var _0023_003DzMFTjHfa4_giP, out var _0023_003DzTXlfp6pm_0024l4F, out var _0023_003DzdGO9IS3DR52i);
			array[i] = new Point3D(_0023_003DzMFTjHfa4_giP, _0023_003DzTXlfp6pm_0024l4F, _0023_003DzdGO9IS3DR52i);
		}
		return array;
	}

	public bool UnProject(int controlHeight, double winx, double winy, double winz, out double objx, out double objy, out double objz)
	{
		int[] viewFrame = GetViewFrame();
		return _0023_003Dz_0024kitxvo_003D(viewFrame, winx, winy, winz, out objx, out objy, out objz);
	}

	public Point3D[] UnProject(IList<Point3D> points, int controlHeight)
	{
		int[] viewFrame = GetViewFrame();
		return Camera.UnProject(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, points, viewFrame);
	}

	internal bool _0023_003Dz_0024kitxvo_003D(int[] _0023_003DzBppTnBIbeUl7, double _0023_003DzMFTjHfa4_giP, double _0023_003DzTXlfp6pm_0024l4F, double _0023_003DzdGO9IS3DR52i, out double _0023_003Dz7TLLaFU2lIpc, out double _0023_003DzdaxMqsuT8oAm, out double _0023_003DzP0yxPwsLUJDR)
	{
		return Camera.UnProject(_0023_003DzBppTnBIbeUl7, _0023_003DzMFTjHfa4_giP, _0023_003DzTXlfp6pm_0024l4F, _0023_003DzdGO9IS3DR52i, out _0023_003Dz7TLLaFU2lIpc, out _0023_003DzdaxMqsuT8oAm, out _0023_003DzP0yxPwsLUJDR);
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, Plane plane, out Point3D intPoint)
	{
		return ScreenToPlane(mousePos, plane.Equation, out intPoint);
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, PlaneEquation pe, out Point3D intPoint)
	{
		return _0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePos, pe, out intPoint);
	}

	internal bool _0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(System.Drawing.Point _0023_003DzTYCHRugcseEq, PlaneEquation _0023_003Dzs90KSyw_003D, out Point3D _0023_003DzeuEsCgu3geDT)
	{
		return Camera.ScreenToPlane(_0023_003DzTYCHRugcseEq, _0023_003Dzs90KSyw_003D, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), GetViewFrame(), out _0023_003DzeuEsCgu3geDT);
	}

	public Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, Plane pe)
	{
		return _0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePointList, pe.Equation);
	}

	public Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, PlaneEquation pe)
	{
		return _0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePointList, pe);
	}

	internal Point3D[] _0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(IList<System.Drawing.Point> _0023_003DzvhgRj9Kxhm1X, PlaneEquation _0023_003Dzs90KSyw_003D)
	{
		return Camera.ScreenToPlane(_0023_003DzvhgRj9Kxhm1X, _0023_003Dzs90KSyw_003D, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), GetViewFrame());
	}

	public Point3D[] ScreenToWorld(IList<System.Drawing.Point> mousePointList)
	{
		int[] viewFrame = GetViewFrame();
		List<Point3D> list = new List<Point3D>();
		List<int> list2 = new List<int>();
		Size size = new Size(1, 1);
		_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.BeginReadDepthValues(size, out var _);
		for (int i = 0; i < mousePointList.Count; i++)
		{
			System.Drawing.Point point = new System.Drawing.Point(mousePointList[i].X, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - mousePointList[i].Y);
			short[] array = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.ReadDepthValues(point.X, point.Y, size);
			if (array != null)
			{
				double num = (double)array[0] / 32767.0;
				if (num != 0.0 && num != 1.0)
				{
					Point3D item = new Point3D(mousePointList[i].X - viewFrame[0], _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - mousePointList[i].Y - viewFrame[1], ZBuffer._0023_003Dzb5ze3RGxKPAJ(num));
					list.Add(item);
					list2.Add(i);
				}
			}
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.EndReadDepthValues();
		Point3D[] array2 = UnProject(list, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
		if (array2 == null)
		{
			return new Point3D[1] { Point3D.MinValue };
		}
		Point3D[] array3 = new Point3D[mousePointList.Count];
		for (int j = 0; j < array2.Length; j++)
		{
			array3[list2[j]] = array2[j];
		}
		return array3;
	}

	public Point3D ScreenToWorld(System.Drawing.Point mousePos)
	{
		return ScreenToWorld(new System.Drawing.Point[1] { mousePos })[0];
	}

	public Point3D WorldToScreen(Point3D point)
	{
		return _0023_003Dzr5tJNXIIzUWm(point);
	}

	internal Point3D _0023_003Dzr5tJNXIIzUWm(Point3D _0023_003DzxGL6Kng_003D)
	{
		return _0023_003Dzr5tJNXIIzUWm(_0023_003DzxGL6Kng_003D.X, _0023_003DzxGL6Kng_003D.Y, _0023_003DzxGL6Kng_003D.Z);
	}

	public Point3D WorldToScreen(double x, double y, double z)
	{
		return _0023_003Dzr5tJNXIIzUWm(x, y, z);
	}

	internal Point3D _0023_003Dzr5tJNXIIzUWm(double _0023_003Dz8GBMuoM_003D, double _0023_003DzJU0R6e0_003D, double _0023_003DzmZWYhFQ_003D)
	{
		return Camera.WorldToScreen(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzmZWYhFQ_003D, GetViewFrame());
	}

	public Point3D[] WorldToScreen(IList<Point3D> pointList)
	{
		return _0023_003Dzr5tJNXIIzUWm(pointList);
	}

	internal Point3D[] _0023_003Dzr5tJNXIIzUWm(IList<Point3D> _0023_003Dz7C7jDF4_003D)
	{
		return Camera.WorldToScreen(_0023_003Dz7C7jDF4_003D, GetViewFrame());
	}

	public void AdjustNearAndFarPlanes()
	{
		_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
	}

	internal void _0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(List<Point3D> _0023_003DzqXBOy1c_003D)
	{
		if (_0023_003DzqXBOy1c_003D.Count > 0)
		{
			Camera.AdjustNearAndFarPlanes(_0023_003DzqXBOy1c_003D.ToArray());
		}
	}

	public void Invalidate()
	{
		_0023_003Dz0TvaYNo_003D.Invalidate();
	}

	internal void _0023_003Dz1ezwJ4KH2Yxl(EventArgs _0023_003DzdXQchgXOgG_0024e)
	{
		if (OriginSymbol != null)
		{
			OriginSymbol.ParentViewport = this;
		}
		if (CoordinateSystemIcon != null)
		{
			CoordinateSystemIcon.ParentViewport = this;
		}
		if (Histogram != null)
		{
			Histogram.ParentViewport = this;
		}
		if (ViewCubeIcon != null)
		{
			ViewCubeIcon.ParentViewport = this;
		}
		_0023_003Dzh2BJvfFX_KvX(_0023_003DzsLHxXyo_003D: false);
	}

	internal void _0023_003DzHqqvNbsad_LE(Workspace _0023_003Dz0TvaYNo_003D)
	{
		_0023_003DzjML9C_0024w_003D(_0023_003Dz0TvaYNo_003D);
		int width = Size.Width;
		int height = Size.Height;
		if (Size.Width > _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t())
		{
			width = _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t();
		}
		if (Size.Height > _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy())
		{
			height = _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy();
		}
		Size = new Size(width, height);
		Camera.sharedData = _0023_003Dz0TvaYNo_003D._0023_003DzB63nHjW2QzvePp6sgQ_003D_003D;
		_0023_003DzkPsfwLNwb5PBfcO83g_003D_003D();
	}

	internal void _0023_003DzjML9C_0024w_003D(Workspace _0023_003Dz0TvaYNo_003D)
	{
		_0023_003DzzgjrOMU_003D(_0023_003Dz0TvaYNo_003D);
		Camera.SetRenderContext(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
		if (_0023_003Dz0TvaYNo_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
		{
			Camera.SceneTransformation = (Transformation)(_0023_003Dz0TvaYNo_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].Camera.SceneTransformation?.Clone());
			Camera.SceneTransformationInverted = (Transformation)(_0023_003Dz0TvaYNo_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].Camera.SceneTransformationInverted?.Clone());
		}
	}

	internal PlaneEquation[] _0023_003DzRyGJqASiXH0u(Rectangle _0023_003DzCiKS5oMdHowF, out Segment3D[] _0023_003DzscOHRT_KSu11SqtX2w_003D_003D)
	{
		_0023_003DzscOHRT_KSu11SqtX2w_003D_003D = new Segment3D[4];
		return Camera.GetFrustum(GetViewFrame(), _0023_003Dz_OlmZyU_003D: false, _0023_003Dzobb8hRaeYuXz(new System.Drawing.Point(_0023_003DzCiKS5oMdHowF.Left, _0023_003DzCiKS5oMdHowF.Bottom)), _0023_003Dzobb8hRaeYuXz(new System.Drawing.Point(_0023_003DzCiKS5oMdHowF.Right, _0023_003DzCiKS5oMdHowF.Top)), out _0023_003DzscOHRT_KSu11SqtX2w_003D_003D[0], out _0023_003DzscOHRT_KSu11SqtX2w_003D_003D[1], out _0023_003DzscOHRT_KSu11SqtX2w_003D_003D[2], out _0023_003DzscOHRT_KSu11SqtX2w_003D_003D[3]);
	}

	public virtual Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor)
	{
		return UserInterfaceBase._0023_003DzxxnnHBbC5r2U(this, viewport, default(Size), GetBounds(viewport), size, backgroundColor, DrawForBitmap);
	}

	protected virtual void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		UserInterfaceBase._0023_003DzKCqq1iC8575l(drawSceneParams);
		IViewportInternal viewportInternal = drawSceneParams2.viewportInternal;
		BoundingBoxSettings boundingBoxSettings = (BoundingBoxSettings)viewportInternal.parent.BoundingBox;
		for (int i = 0; i < Grids.Length; i++)
		{
			Grids[i]._0023_003DzlZ_kJuw_003D(drawSceneParams2.RenderContext, drawSceneParams2.Viewport.Camera, null, boundingBoxSettings._0023_003Dze4TpmVqI26AF, boundingBoxSettings._0023_003DzD4HjvLi8HsVr, viewportInternal.parent.Entities.Count, drawSceneParams2.CameraEyePos);
			Grids[i]._0023_003DzKCqq1iC8575l(drawSceneParams2);
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzxRT2nHwkpqIv(drawSceneParams2);
	}

	[Obsolete("Use the method with no parameters instead.")]
	public virtual Rectangle GetBounds(Viewport viewport)
	{
		return new Rectangle(Location, Size);
	}

	public virtual Rectangle GetBounds()
	{
		return new Rectangle(Location, Size);
	}

	public virtual void Update(IUserInterfaceElement another)
	{
		Viewport viewport = (Viewport)another;
		_0023_003DzshPEPAc_003D(viewport.Location, viewport.Size, viewport.Background, viewport.Camera, viewport.ToolBars, viewport.Legends, viewport.Histogram, viewport.DisplayMode, viewport.ShowLabels, viewport.AutoHideLabels, viewport._0023_003DzyBPwOa1siDegABKoKg_003D_003D, viewport._0023_003Dze_0024CNZ_Memiiw, viewport.Grids, viewport.OriginSymbols, viewport.SortLabels, viewport.Rotate, viewport.Zoom, viewport.Pan, viewport.Navigation, viewport.CoordinateSystemIcon, viewport.ViewCubeIcon, viewport.SavedViews, viewport.ScaleBar, _0023_003DzwmQOnB8_003D: true);
	}

	private CoordinateSystemIcon _0023_003DzlhPnyTpLcuhaJ1GGBg_003D_003D()
	{
		return CoordinateSystemIcon.GetDefaultCoordinateSystemIcon();
	}

	private bool _0023_003DzXgh7Qyf0Ohx0LhDyXQ_003D_003D()
	{
		return CoordinateSystemIcon._0023_003Dz4XAvJ5aCRLKs(_0023_003DzlhPnyTpLcuhaJ1GGBg_003D_003D());
	}

	internal void _0023_003DzjSUMmaTX6tv3VJlDew_003D_003D()
	{
		if (_0023_003DzFfOjsSRCbzpd != null)
		{
			_0023_003DzFfOjsSRCbzpd.Dispose();
		}
		_0023_003DzFfOjsSRCbzpd = CoordinateSystemIcon.GetDefaultCoordinateSystemIcon();
		if (_0023_003Dz0TvaYNo_003D != null && _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements();
			_0023_003Dz0TvaYNo_003D._0023_003Dz3tGL3rg_003D();
		}
	}

	private static Histogram _0023_003DzKVWnYtP5kRnz()
	{
		return Histogram.GetDefaultHistogram();
	}

	private bool _0023_003Dzt_0024XupZsN8T2T()
	{
		return Histogram._0023_003Dz4XAvJ5aCRLKs();
	}

	internal void _0023_003DzPFEuAiG5xhue()
	{
		if (_0023_003DznPu5SKE_003D != null)
		{
			_0023_003DznPu5SKE_003D.Dispose();
		}
		_0023_003DznPu5SKE_003D = Histogram.GetDefaultHistogram();
	}

	internal bool _0023_003DzPPJCGnPxOjTsQFinOw_003D_003D()
	{
		if (_0023_003Dz4ry2vZefVkxX != null)
		{
			return _0023_003Dz4ry2vZefVkxX._0023_003Dz4XAvJ5aCRLKs();
		}
		return false;
	}

	internal void _0023_003DzuR5fFmHevHyW()
	{
		if (_0023_003Dz4ry2vZefVkxX != null)
		{
			_0023_003Dz4ry2vZefVkxX.Dispose();
		}
		ViewCubeIcon = ViewCubeIcon.GetDefaultViewCubeIcon();
	}

	private void _0023_003DzkPsfwLNwb5PBfcO83g_003D_003D()
	{
		if (_0023_003DzFfOjsSRCbzpd == null)
		{
			_0023_003DzFfOjsSRCbzpd = new CoordinateSystemIcon();
		}
		_0023_003DzFfOjsSRCbzpd.ParentViewport = this;
		if (_0023_003Dz4ry2vZefVkxX == null)
		{
			_0023_003Dz4ry2vZefVkxX = new ViewCubeIcon();
		}
		_0023_003Dz4ry2vZefVkxX.ParentViewport = this;
		if (_0023_003Dz5tj8j11PShCE == null)
		{
			_0023_003Dz5tj8j11PShCE = new ScaleBar();
		}
		_0023_003Dz5tj8j11PShCE.ParentViewport = this;
	}

	public void CompileUserInterfaceElements()
	{
		_0023_003Dz0TvaYNo_003D.CompileUserInterfaceElements(this);
	}

	internal void _0023_003DzjXx69XXT9hVV47w_0024YA_003D_003D(Dictionary<shaderType, IShaderTechnique> _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			if (_0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D() != null)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590478));
			}
			((D3DRenderContext)_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D).ReflectionShaders = _0023_003DzsLHxXyo_003D;
		}
		else
		{
			_0023_003DzSSWqFoUldB87dazEjA_003D_003D = _0023_003DzsLHxXyo_003D;
		}
	}

	internal Dictionary<shaderType, IShaderTechnique> _0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D()
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			return ((D3DRenderContext)_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D).ReflectionShaders;
		}
		return _0023_003DzSSWqFoUldB87dazEjA_003D_003D;
	}

	internal void _0023_003Dz6OsFdMKWc7KaMbntUA_003D_003D()
	{
		if (!_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			_0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D();
			_0023_003DzjXx69XXT9hVV47w_0024YA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateReflectionShaders(_0023_003Dz0TvaYNo_003D._0023_003DznKkOfo8_003D.RealisticShadowQuality, _0023_003Dz0TvaYNo_003D._0023_003Dz0fqXN00AlqdN, Background, _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.ActiveLights));
		}
		else if (_0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D() == null)
		{
			_0023_003DzjXx69XXT9hVV47w_0024YA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateReflectionShaders(_0023_003Dz0TvaYNo_003D._0023_003DznKkOfo8_003D.RealisticShadowQuality, _0023_003Dz0TvaYNo_003D._0023_003Dz0fqXN00AlqdN, Background, _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.ActiveLights));
		}
	}

	internal void _0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D()
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			return;
		}
		if (_0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D() != null)
		{
			foreach (KeyValuePair<shaderType, IShaderTechnique> item in _0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D())
			{
				if (item.Value != null)
				{
					item.Value.Dispose();
				}
			}
		}
		_0023_003DzjXx69XXT9hVV47w_0024YA_003D_003D(null);
	}

	internal void _0023_003Dz1aD3FvrMPVZvq2oC0g_003D_003D(Grid._0023_003Dzp2xC_56LDhr6 _0023_003Dza3HTvMWw3UP_0024, bool _0023_003DzPHqp5dQ_003D, int _0023_003Dzcynlfz_Vshyb)
	{
		if (_0023_003DzPHqp5dQ_003D)
		{
			return;
		}
		Grid[] array = _0023_003Dzmm4AR2_v0bxl;
		foreach (Grid grid in array)
		{
			if (!(!grid.Visible || _0023_003DzPHqp5dQ_003D))
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
				if (!grid.AlwaysBehind)
				{
					Camera.SetProjectionMatrixType(Camera.projectionMatrixType.Standard);
					grid._0023_003Dz99kJFjE_003D(this, _0023_003Dzcynlfz_Vshyb, _0023_003Dza3HTvMWw3UP_0024);
				}
			}
		}
	}

	internal void _0023_003DzC9qfRaqDpHaFw3uV_g_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, bool _0023_003DzPHqp5dQ_003D, Point3D _0023_003DzoYJjnU0_003D, Point3D _0023_003DzWRFixiU_003D, int _0023_003Dz9FzxYm0_003D, int _0023_003Dzcynlfz_Vshyb, CameraEyePosType _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D)
	{
		Grid[] array = _0023_003Dzmm4AR2_v0bxl;
		for (int i = 0; i < array.Length; i++)
		{
			array[i]._0023_003DzZZedz_Wv_0024WfT(this, _0023_003DzPHqp5dQ_003D, _0023_003DzoYJjnU0_003D, _0023_003DzWRFixiU_003D, _0023_003Dz9FzxYm0_003D, _0023_003Dzcynlfz_Vshyb, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D);
		}
	}

	public Size GetBitmapSizeToPrintInWorldUnits(GraphicsUnit pageUnits, linearUnitsType designUnits, double scale)
	{
		if (Camera.ProjectionMode == projectionType.Perspective)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590535));
		}
		double num = UtilityEx._0023_003DzSg7URJz1jbSCe_0024oh0g_003D_003D(pageUnits, designUnits);
		double num2 = 1.0 / Camera.ZoomFactor;
		double num3 = scale * num2 / num;
		return new Size((int)Math.Round((double)Size.Width * num3), (int)Math.Round((double)Size.Height * num3));
	}

	internal byte[] _0023_003DzTgPYdNm9og8y(int _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, Color _0023_003DzNLGcq5k_003D)
	{
		return UtilityEx.ConvertImageToBytes(GetThumbnail(_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, _0023_003DzNLGcq5k_003D));
	}

	public Bitmap GetThumbnail(int thumbnailSize, Color backgroundColor)
	{
		if (_0023_003Dz0TvaYNo_003D.InvokeRequired)
		{
			return (Bitmap)_0023_003Dz0TvaYNo_003D.Invoke((Func<int, Color, Bitmap>)delegate(int _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, Color _0023_003DzNLGcq5k_003D)
			{
				_0023_003Dz2bwAPoQwFwzX = Background;
				int num = Grids.Length;
				int num2 = ToolBars.Length;
				int num3 = ((Legends != null) ? Legends.Length : 0);
				backgroundStyleType styleMode = _0023_003Dz2bwAPoQwFwzX.StyleMode;
				Color topColor = _0023_003Dz2bwAPoQwFwzX.TopColor;
				bool? flag = OriginSymbol?.Visible;
				bool? flag2 = ViewCubeIcon?.Visible;
				bool? flag3 = CoordinateSystemIcon?.Visible;
				bool[] array = new bool[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = Grids[i].Visible;
					Grids[i].Visible = false;
				}
				bool[] array2 = new bool[num2];
				for (int j = 0; j < num2; j++)
				{
					array2[j] = ToolBars[j].Visible;
					ToolBars[j].Visible = false;
				}
				bool[] array3 = new bool[num3];
				for (int k = 0; k < num3; k++)
				{
					array3[k] = Legends[k].Visible;
					Legends[k].Visible = false;
				}
				if (!_0023_003DzNLGcq5k_003D.IsEmpty)
				{
					if (_0023_003DzNLGcq5k_003D == Color.Transparent)
					{
						Background.StyleMode = backgroundStyleType.None;
					}
					else
					{
						Background.StyleMode = backgroundStyleType.Solid;
						Background.TopColor = _0023_003DzNLGcq5k_003D;
					}
				}
				if (OriginSymbol != null)
				{
					OriginSymbol.Visible = false;
				}
				if (ViewCubeIcon != null)
				{
					ViewCubeIcon.Visible = false;
				}
				if (CoordinateSystemIcon != null)
				{
					CoordinateSystemIcon.Visible = false;
				}
				if (Histogram != null)
				{
					Histogram.Visible = false;
				}
				Bitmap bitmap = RenderToBitmap(1f);
				if (!_0023_003DzNLGcq5k_003D.IsEmpty)
				{
					Background.StyleMode = styleMode;
					Background.TopColor = topColor;
				}
				for (int l = 0; l < num; l++)
				{
					Grids[l].Visible = array[l];
				}
				for (int m = 0; m < num2; m++)
				{
					ToolBars[m].Visible = array2[m];
				}
				for (int n = 0; n < num3; n++)
				{
					Legends[n].Visible = array3[n];
				}
				if (flag.HasValue)
				{
					OriginSymbol.Visible = flag.Value;
				}
				if (flag2.HasValue)
				{
					ViewCubeIcon.Visible = flag2.Value;
				}
				if (flag3.HasValue)
				{
					CoordinateSystemIcon.Visible = flag3.Value;
				}
				if (_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D > 256)
				{
					_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D = 256;
				}
				Bitmap result = UtilityEx._0023_003Dz3nqRsaSSSvFx(bitmap, Workspace._0023_003DzTRjGTao_003D(Size, _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D));
				bitmap.Dispose();
				return result;
			}, thumbnailSize, backgroundColor);
		}
		return _0023_003DzNcXS8YMdML3vfW58_0024GaKzwU_003D(thumbnailSize, backgroundColor);
	}

	private Bitmap _0023_003DzNcXS8YMdML3vfW58_0024GaKzwU_003D(int _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, Color _0023_003DzNLGcq5k_003D)
	{
		_0023_003Dz2bwAPoQwFwzX = Background;
		int num = Grids.Length;
		int num2 = ToolBars.Length;
		int num3 = ((Legends != null) ? Legends.Length : 0);
		backgroundStyleType styleMode = _0023_003Dz2bwAPoQwFwzX.StyleMode;
		Color topColor = _0023_003Dz2bwAPoQwFwzX.TopColor;
		bool? flag = OriginSymbol?.Visible;
		bool? flag2 = ViewCubeIcon?.Visible;
		bool? flag3 = CoordinateSystemIcon?.Visible;
		bool[] array = new bool[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Grids[i].Visible;
			Grids[i].Visible = false;
		}
		bool[] array2 = new bool[num2];
		for (int j = 0; j < num2; j++)
		{
			array2[j] = ToolBars[j].Visible;
			ToolBars[j].Visible = false;
		}
		bool[] array3 = new bool[num3];
		for (int k = 0; k < num3; k++)
		{
			array3[k] = Legends[k].Visible;
			Legends[k].Visible = false;
		}
		if (!_0023_003DzNLGcq5k_003D.IsEmpty)
		{
			if (_0023_003DzNLGcq5k_003D == Color.Transparent)
			{
				Background.StyleMode = backgroundStyleType.None;
			}
			else
			{
				Background.StyleMode = backgroundStyleType.Solid;
				Background.TopColor = _0023_003DzNLGcq5k_003D;
			}
		}
		if (OriginSymbol != null)
		{
			OriginSymbol.Visible = false;
		}
		if (ViewCubeIcon != null)
		{
			ViewCubeIcon.Visible = false;
		}
		if (CoordinateSystemIcon != null)
		{
			CoordinateSystemIcon.Visible = false;
		}
		if (Histogram != null)
		{
			Histogram.Visible = false;
		}
		Bitmap bitmap = RenderToBitmap(1f);
		if (!_0023_003DzNLGcq5k_003D.IsEmpty)
		{
			Background.StyleMode = styleMode;
			Background.TopColor = topColor;
		}
		for (int l = 0; l < num; l++)
		{
			Grids[l].Visible = array[l];
		}
		for (int m = 0; m < num2; m++)
		{
			ToolBars[m].Visible = array2[m];
		}
		for (int n = 0; n < num3; n++)
		{
			Legends[n].Visible = array3[n];
		}
		if (flag.HasValue)
		{
			OriginSymbol.Visible = flag.Value;
		}
		if (flag2.HasValue)
		{
			ViewCubeIcon.Visible = flag2.Value;
		}
		if (flag3.HasValue)
		{
			CoordinateSystemIcon.Visible = flag3.Value;
		}
		if (_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D > 256)
		{
			_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D = 256;
		}
		Bitmap result = UtilityEx._0023_003Dz3nqRsaSSSvFx(bitmap, Workspace._0023_003DzTRjGTao_003D(Size, _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D));
		bitmap.Dispose();
		return result;
	}

	public virtual void ScaleForDPI()
	{
		ViewCubeIcon.ScaleForDPI();
		CoordinateSystemIcon.ScaleForDPI();
		OriginSymbol[] originSymbols = OriginSymbols;
		for (int i = 0; i < originSymbols.Length; i++)
		{
			originSymbols[i].ScaleForDPI();
		}
		Legend[] legends = Legends;
		for (int i = 0; i < legends.Length; i++)
		{
			legends[i].ScaleForDPI();
		}
		foreach (devDept.Eyeshot.Control.Labels.Label label in Labels)
		{
			label.ScaleForDPI();
		}
	}

	public int AddUserInterfaceElementFor(Setup setup, int size = 5)
	{
		int num = OriginSymbols.Length;
		OriginSymbol[] array = new OriginSymbol[num + 1];
		for (int i = 0; i < num; i++)
		{
			array[i] = OriginSymbols[i];
		}
		array[num] = new OriginSymbol(size, originSymbolStyleType.CoordinateSystem, Color.Black, Color.Orange, Color.Cyan, Color.Magenta, setup.Name, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589209), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589201), visible: true, setup.Transformation, lighting: false);
		OriginSymbols = array;
		CompileUserInterfaceElements();
		return num;
	}

	public Segment3D GetRayUnderCursor(System.Drawing.Point mousePos)
	{
		Segment3D segment3D = new Segment3D();
		_0023_003Dz_feN2jsfs6O0(new System.Drawing.Point(mousePos.X, mousePos.Y), out var _0023_003DzD_hjMo9IBHeB);
		_0023_003DzD_hjMo9IBHeB.Y = Size.Height - _0023_003DzD_hjMo9IBHeB.Y;
		int[] viewFrame = GetViewFrame();
		_0023_003Dz_0024kitxvo_003D(viewFrame, _0023_003DzD_hjMo9IBHeB.X, _0023_003DzD_hjMo9IBHeB.Y, 0.0, out var _0023_003Dz7TLLaFU2lIpc, out var _0023_003DzdaxMqsuT8oAm, out var _0023_003DzP0yxPwsLUJDR);
		segment3D.P0.X = _0023_003Dz7TLLaFU2lIpc;
		segment3D.P0.Y = _0023_003DzdaxMqsuT8oAm;
		segment3D.P0.Z = _0023_003DzP0yxPwsLUJDR;
		_0023_003Dz_0024kitxvo_003D(viewFrame, _0023_003DzD_hjMo9IBHeB.X, _0023_003DzD_hjMo9IBHeB.Y, 1.0, out _0023_003Dz7TLLaFU2lIpc, out _0023_003DzdaxMqsuT8oAm, out _0023_003DzP0yxPwsLUJDR);
		segment3D.P1.X = _0023_003Dz7TLLaFU2lIpc;
		segment3D.P1.Y = _0023_003DzdaxMqsuT8oAm;
		segment3D.P1.Z = _0023_003DzP0yxPwsLUJDR;
		return segment3D;
	}

	private void _0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WXpyb_00242oebLdW6m8pg_003D(ILabel[] _0023_003DzF5TdZcc_003D)
	{
		Labels.AddRange(_0023_003DzF5TdZcc_003D.Cast<devDept.Eyeshot.Control.Labels.Label>());
	}

	void IViewportInternal.AddLabel(ILabel[] _0023_003DzF5TdZcc_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zvRv2q7rL$ZnoPvAjrfwD6WXpyb$2oebLdW6m8pg=
		this._0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WXpyb_00242oebLdW6m8pg_003D(_0023_003DzF5TdZcc_003D);
	}

	private void _0023_003DzO6D_yIijGNjqxQ2aqpsdpfnLA0MXFRemiT3yMJc_003D(ILabel[] _0023_003DzF5TdZcc_003D)
	{
		foreach (devDept.Eyeshot.Control.Labels.Label item in _0023_003DzF5TdZcc_003D.Cast<devDept.Eyeshot.Control.Labels.Label>())
		{
			Labels.Remove(item);
		}
	}

	void IViewportInternal.RemoveLabel(ILabel[] _0023_003DzF5TdZcc_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zO6D_yIijGNjqxQ2aqpsdpfnLA0MXFRemiT3yMJc=
		this._0023_003DzO6D_yIijGNjqxQ2aqpsdpfnLA0MXFRemiT3yMJc_003D(_0023_003DzF5TdZcc_003D);
	}

	private ILabel[] _0023_003Dz3oymsXBrx15Fo6pV41FSjY3zzGoI_0024jX0vx0NX0k_003D()
	{
		return _0023_003DzF5TdZcc_003D.Cast<ILabel>().ToArray();
	}

	ILabel[] IViewportInternal.GetLabels()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z3oymsXBrx15Fo6pV41FSjY3zzGoI$jX0vx0NX0k=
		return this._0023_003Dz3oymsXBrx15Fo6pV41FSjY3zzGoI_0024jX0vx0NX0k_003D();
	}

	private ILabelFactory _0023_003Dz20kuiCLSBgdBr7NEe44fMBdDj_0024SnyCJIB41mF7k_003D()
	{
		return _0023_003DzvNOHJE5oNS5SePyH9cyIVLnA0oC0sZgIvA2Z0tggGzaY6ZM6Lg_003D_003D;
	}

	ILabelFactory IViewportInternal.get_LabelFactory()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z20kuiCLSBgdBr7NEe44fMBdDj$SnyCJIB41mF7k=
		return this._0023_003Dz20kuiCLSBgdBr7NEe44fMBdDj_0024SnyCJIB41mF7k_003D();
	}

	private IGrid _0023_003DzKy96N0rzh7f0L1EGxNwdqFDTkE2zUnjYDdXlrFY_003D()
	{
		return Grid;
	}

	IGrid IViewportInternal.get_Grid()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zKy96N0rzh7f0L1EGxNwdqFDTkE2zUnjYDdXlrFY=
		return this._0023_003DzKy96N0rzh7f0L1EGxNwdqFDTkE2zUnjYDdXlrFY_003D();
	}

	private bool _0023_003DzxUbFoGjxpHZDWLHZ5w_003D_003D()
	{
		return _0023_003DzLvweZtO44VEY;
	}

	private void _0023_003DzALoOL2VkJRQF()
	{
		_0023_003DzLvweZtO44VEY = false;
	}

	internal void _0023_003Dz7kSxzpM_003D()
	{
		if (_0023_003DzF5TdZcc_003D != null)
		{
			_0023_003DzF5TdZcc_003D.Clear();
		}
	}

	internal bool _0023_003Dzgl1V3g7ZZb0NCn4qIg_003D_003D()
	{
		return Labels.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz_yksj_xQrtsp862atv9WbEcgqjy_);
	}

	private void _0023_003DzsEZopnGaSonoe0yo0A_003D_003D(int[] _0023_003DzsANZWJnUZ6LS)
	{
		int num = (int)Math.Ceiling((double)Camera.ViewportPointSize / 2.0);
		int _0023_003Dz6RzQuL_00245pp_0024n = num;
		int _0023_003Dz6PNUVyN5um0U = _0023_003DzsANZWJnUZ6LS[2] - num;
		int _0023_003Dz_duJqf_0024qZ = num;
		int _0023_003Dz_npROhUwuZOb = _0023_003DzsANZWJnUZ6LS[3] - num;
		if (_0023_003DzF5TdZcc_003D.Count < 20)
		{
			Size size = new Size(Camera.ViewportPointSize, Camera.ViewportPointSize);
			int strideInPixels = 0;
			_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.BeginReadDepthValues(size, out strideInPixels);
			foreach (devDept.Eyeshot.Control.Labels.Label item in _0023_003DzF5TdZcc_003D)
			{
				if (item.Visible && item.AutoHide)
				{
					Camera.CheckScreenPointVisibility(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), size, _0023_003DzsANZWJnUZ6LS, item.xPos, item.yPos, item.zPos, _0023_003Dz6RzQuL_00245pp_0024n, _0023_003Dz6PNUVyN5um0U, _0023_003Dz_duJqf_0024qZ, _0023_003Dz_npROhUwuZOb, out item.hidden);
				}
			}
			_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.EndReadDepthValues();
			return;
		}
		int stride;
		short[] _0023_003DzkFiPhp9QI_5j = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.ReadDepthValues(_0023_003DzsANZWJnUZ6LS, out stride);
		foreach (devDept.Eyeshot.Control.Labels.Label item2 in _0023_003DzF5TdZcc_003D)
		{
			if (item2.Visible && item2.AutoHide)
			{
				Camera.CheckScreenPointVisibility(Camera.ViewportPointSize, _0023_003DzkFiPhp9QI_5j, stride, _0023_003DzsANZWJnUZ6LS, item2.xPos, item2.yPos, item2.zPos, _0023_003Dz6RzQuL_00245pp_0024n, _0023_003Dz6PNUVyN5um0U, _0023_003Dz_duJqf_0024qZ, _0023_003Dz_npROhUwuZOb, out item2.hidden);
			}
		}
	}

	protected internal virtual void DrawLabels(RenderContextBase renderContext, float drawScale)
	{
		if (!_0023_003DzwfKBrot1LuuC)
		{
			return;
		}
		if (SortLabels)
		{
			foreach (KeyValuePair<int, devDept.Eyeshot.Control.Labels.Label> sortedLabel in _0023_003DzF5TdZcc_003D.sortedLabels)
			{
				_0023_003Dz02QHtwCD7nRx(sortedLabel.Value, renderContext, drawScale);
			}
			return;
		}
		foreach (devDept.Eyeshot.Control.Labels.Label label in Labels)
		{
			_0023_003Dz02QHtwCD7nRx(label, renderContext, drawScale);
		}
	}

	private void _0023_003Dz02QHtwCD7nRx(devDept.Eyeshot.Control.Labels.Label _0023_003DzaO_0024_BNc_003D, RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003DzCzsr4CTVr_Ea)
	{
		if (_0023_003DzaO_0024_BNc_003D.Visible && (!_0023_003Dzgl1V3g7ZZb0NCn4qIg_003D_003D() || !_0023_003DzaO_0024_BNc_003D.hidden) && !_0023_003DzaO_0024_BNc_003D.IsClipped(_0023_003Dz0TvaYNo_003D._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D))
		{
			if (_0023_003DzaO_0024_BNc_003D.Selected)
			{
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003Dz0TvaYNo_003D.Selection.Color);
				_0023_003DzaO_0024_BNc_003D.DrawSelected(_0023_003DzmNZD0Zs_003D);
			}
			else
			{
				_0023_003DzaO_0024_BNc_003D.Draw(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
			}
		}
	}

	internal void _0023_003Dz4DjPZGU_003D(int[] _0023_003DzsANZWJnUZ6LS)
	{
		if (!_0023_003DzwfKBrot1LuuC)
		{
			return;
		}
		double[] modelViewProjectionMatrix = Camera.GetModelViewProjectionMatrix();
		foreach (devDept.Eyeshot.Control.Labels.Label item in _0023_003DzF5TdZcc_003D)
		{
			if (item.Visible)
			{
				item.UpdatePos(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, modelViewProjectionMatrix, _0023_003DzsANZWJnUZ6LS);
			}
		}
		if (_0023_003DzLIwPv16B13qilCw_jA_003D_003D)
		{
			_0023_003DzsEZopnGaSonoe0yo0A_003D_003D(_0023_003DzsANZWJnUZ6LS);
		}
		if (SortLabels)
		{
			_0023_003DzF5TdZcc_003D._0023_003DzL1xYB6XaQTqb();
		}
	}

	internal Dictionary<int, SelectedItem> _0023_003Dz1eFClLc2ASGZ(int _0023_003Dzsdr_I1A_003D, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D)
	{
		DrawForSelectionParams drawForSelectionParams = new DrawForSelectionParams(this, null);
		drawForSelectionParams.FalseColorIndex = _0023_003Dzsdr_I1A_003D;
		if (_0023_003DzwfKBrot1LuuC)
		{
			bool _0023_003DzQQmo0z6u0mfX = !_0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D;
			if (SortLabels)
			{
				foreach (KeyValuePair<int, devDept.Eyeshot.Control.Labels.Label> sortedLabel in _0023_003DzF5TdZcc_003D.sortedLabels)
				{
					drawForSelectionParams.FalseColorIndex = _0023_003Dzsdr_I1A_003D + sortedLabel.Key;
					_0023_003DzAHUHjEveIrzU(drawForSelectionParams, sortedLabel.Value, _0023_003DzQQmo0z6u0mfX);
				}
			}
			else
			{
				for (int i = 0; i < _0023_003DzF5TdZcc_003D.Count; i++)
				{
					_0023_003DzAHUHjEveIrzU(drawForSelectionParams, _0023_003DzF5TdZcc_003D[i], _0023_003DzQQmo0z6u0mfX);
					drawForSelectionParams.FalseColorIndex++;
				}
			}
		}
		return drawForSelectionParams.IdItemsMap;
	}

	private void _0023_003DzAHUHjEveIrzU(DrawForSelectionParams _0023_003Dz4w87gJW9BvO4, devDept.Eyeshot.Control.Labels.Label _0023_003DzaO_0024_BNc_003D, bool _0023_003DzQQmo0z6u0mfX)
	{
		if ((_0023_003DzaO_0024_BNc_003D.Selectable || _0023_003DzQQmo0z6u0mfX) && _0023_003DzwfKBrot1LuuC && _0023_003DzaO_0024_BNc_003D.Visible && (!_0023_003Dzgl1V3g7ZZb0NCn4qIg_003D_003D() || !_0023_003DzaO_0024_BNc_003D.hidden) && !_0023_003DzaO_0024_BNc_003D.IsClipped(_0023_003Dz0TvaYNo_003D._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D))
		{
			_0023_003Dz0TvaYNo_003D.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(_0023_003Dz4w87gJW9BvO4, _0023_003DzaO_0024_BNc_003D);
			float num = _0023_003DzaO_0024_BNc_003D.xPos + (float)_0023_003DzaO_0024_BNc_003D.Size.Width;
			float num2 = _0023_003DzaO_0024_BNc_003D.yPos + (float)_0023_003DzaO_0024_BNc_003D.Size.Height;
			if (num >= 0f && _0023_003DzaO_0024_BNc_003D.xPos < (float)Size.Width && num2 >= 0f && _0023_003DzaO_0024_BNc_003D.yPos < (float)Size.Height)
			{
				_0023_003DzaO_0024_BNc_003D.DrawForSelection(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D);
			}
		}
	}

	private bool _0023_003DzD1p36iwoWWc7ZaoFBg_003D_003D(devDept.Eyeshot.Control.Labels.Label _0023_003DzQmPeEvw_003D, ClippingPlaneBase[] _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D)
	{
		foreach (ClippingPlaneBase clippingPlaneBase in _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D)
		{
			if (clippingPlaneBase.Active && _0023_003DzQmPeEvw_003D.AnchorPoint.DistanceTo(clippingPlaneBase.Plane) > 0.0)
			{
				return true;
			}
		}
		return false;
	}

	protected internal void DrawText(int x, int y, string text, Font textFont, Color textColor, ContentAlignment textAlign)
	{
		_0023_003Dz0TvaYNo_003D.DrawText(x, y, text, textFont, textColor, textAlign);
	}

	protected internal void DrawText(int x, int y, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign)
	{
		_0023_003Dz0TvaYNo_003D.DrawText(x, y, text, textFont, textColor, fillColor, textAlign);
	}

	protected internal void DrawText(int x, int y, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip)
	{
		_0023_003Dz0TvaYNo_003D.DrawText(x, y, text, textFont, textColor, fillColor, textAlign, rotateFlip);
	}

	public void CompileBackground()
	{
		if (_0023_003Dz0TvaYNo_003D != null)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CompileBackground(_0023_003Dz2bwAPoQwFwzX, Size.Height);
			_0023_003DzKcjcHP9Ku7D9 = Background.GetContrastColor();
		}
	}

	private void _0023_003DzandFr_4vLWrU(Size _0023_003Dz0ERMHbg_003D, out float _0023_003DzhXpC6io_003D, out float _0023_003DzHavyKeA_003D, out float _0023_003DznPWAePU_003D, out float _0023_003DzZvnPBFw_003D)
	{
		float bmpWidth;
		float bmpHeight;
		float imageScale = Background.GetImageScale(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height, out bmpWidth, out bmpHeight);
		float num = (float)_0023_003Dz0ERMHbg_003D.Width / 2f;
		float num2 = (float)_0023_003Dz0ERMHbg_003D.Height / 2f;
		_0023_003DzhXpC6io_003D = (0f - bmpWidth) / 2f * imageScale + num;
		_0023_003DzHavyKeA_003D = bmpWidth / 2f * imageScale + num;
		_0023_003DznPWAePU_003D = (0f - bmpHeight) / 2f * imageScale + num2;
		_0023_003DzZvnPBFw_003D = bmpHeight / 2f * imageScale + num2;
	}

	internal void _0023_003Dz191ozMVp28cu(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzatgWgTMc3NTm, RectangleF _0023_003DzF7kGEgqMZE2_, bool _0023_003DzPHqp5dQ_003D, float _0023_003DzyE_Z4guKNRizEOM1IA_003D_003D, Color _0023_003DzqfS3NMQ_003D, bool _0023_003DzIHwNrERoZxEh)
	{
		if (!_0023_003DzIHwNrERoZxEh)
		{
			_0023_003DzdzRS8TI_003D();
			Transformation transformation = new Transformation(Camera.myOrtho(_0023_003DzmNZD0Zs_003D, 0.0, Size.Width, 0.0, Size.Height, -1.0, 1.0), byRow: false);
			Transformation transformation2 = null;
			if (!_0023_003DzF7kGEgqMZE2_.IsEmpty)
			{
				transformation2 = new Transformation(_0023_003DzmNZD0Zs_003D.ComputePickMatrix(_0023_003DzF7kGEgqMZE2_, new Size(Size.Width, Size.Height), new int[4] { 0, 0, Size.Width, Size.Height }), byRow: false);
				transformation = Camera.ApplyPickMatrix(transformation2, transformation);
			}
			shaderType type = shaderType.MultiColor;
			switch (Background.StyleMode)
			{
			case backgroundStyleType.None:
			case backgroundStyleType.Solid:
			case backgroundStyleType.LinearGradient:
				type = shaderType.MultiColorNoLights;
				break;
			case backgroundStyleType.CubicGradient:
			case backgroundStyleType.Image:
				type = shaderType.Texture2DNoLights;
				break;
			}
			_0023_003DzmNZD0Zs_003D.SetShader(type);
			_0023_003DzmNZD0Zs_003D.SetMatrices(transformation.MatrixAsVectorByColumn, null);
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			DrawBackground(_0023_003DzmNZD0Zs_003D, _0023_003DzPHqp5dQ_003D, _0023_003DzyE_Z4guKNRizEOM1IA_003D_003D, _0023_003DzqfS3NMQ_003D, transformation2);
			_0023_003DzmNZD0Zs_003D.ResetColorDiffuse();
			_0023_003DzmNZD0Zs_003D.PopShader();
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		}
	}

	protected internal virtual void DrawBackground(RenderContextBase context, bool reflection, float reflectionIntensity, Color parentColor, Transformation pickMatrix)
	{
		if (_0023_003Dz2bwAPoQwFwzX.StyleMode == backgroundStyleType.None && _0023_003Dz0TvaYNo_003D._0023_003DzkQRTXiC03yes)
		{
			parentColor = Color.Transparent;
		}
		byte alpha = (reflection ? ((byte)((1.0 - (double)reflectionIntensity) * 255.0)) : byte.MaxValue);
		RectangleF rect = new RectangleF(0f, 0f, Size.Width, Size.Height);
		switch (_0023_003Dz2bwAPoQwFwzX.StyleMode)
		{
		case backgroundStyleType.None:
			context.DrawQuadWithColorRange(rect, parentColor, parentColor, reflection, reflectionIntensity);
			break;
		case backgroundStyleType.Solid:
			context.DrawQuadWithColorRange(rect, RenderContextUtility.ConvertColor(_0023_003Dz2bwAPoQwFwzX.TopColor), RenderContextUtility.ConvertColor(_0023_003Dz2bwAPoQwFwzX.TopColor), reflection, reflectionIntensity);
			break;
		case backgroundStyleType.LinearGradient:
			context.DrawQuadWithColorRange(rect, RenderContextUtility.ConvertColor(_0023_003Dz2bwAPoQwFwzX.BottomColor), RenderContextUtility.ConvertColor(_0023_003Dz2bwAPoQwFwzX.TopColor), reflection, reflectionIntensity);
			break;
		case backgroundStyleType.CubicGradient:
			context.DrawQuadWithTextures(_0023_003Dz2bwAPoQwFwzX.Texture, new float[8] { 1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f }, alpha, rect, 0f, buffered: false);
			break;
		case backgroundStyleType.Image:
			if (_0023_003Dz2bwAPoQwFwzX.Texture != null)
			{
				_0023_003DzandFr_4vLWrU(Size, out var _0023_003DzhXpC6io_003D, out var _0023_003DzHavyKeA_003D, out var _0023_003DznPWAePU_003D, out var _0023_003DzZvnPBFw_003D);
				context.DrawQuadWithTextures(rect: new RectangleF(_0023_003DzhXpC6io_003D, _0023_003DznPWAePU_003D, _0023_003DzHavyKeA_003D - _0023_003DzhXpC6io_003D, _0023_003DzZvnPBFw_003D - _0023_003DznPWAePU_003D), texture: _0023_003Dz2bwAPoQwFwzX.Texture, texCoords: new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f }, alpha: alpha, zCoord: 0f, buffered: false);
			}
			break;
		}
	}

	[Obsolete("Use PreDrawOverlay instead.")]
	protected internal virtual void DrawOverlay(DrawSceneParams myParams)
	{
	}

	protected internal virtual void PreDrawOverlay(DrawSceneParams myParams)
	{
	}

	protected internal virtual void PostDrawOverlay(DrawSceneParams myParams)
	{
	}

	internal void _0023_003DzZaiOpczL4w_C(DrawSceneParams _0023_003Dzt5jpbHs_003D, int _0023_003DzZlBwqPrKrdKq)
	{
		RenderContextBase renderContext = _0023_003Dz0TvaYNo_003D.RenderContext;
		renderContext.PushMatrices();
		if (!_0023_003Dzt5jpbHs_003D.ZoomRect.IsEmpty)
		{
			double[] _0023_003DzwTc0B2NdlyUi = Camera.myOrtho(renderContext, 0.0, _0023_003Dzt5jpbHs_003D.ViewportSize.Width, 0.0, _0023_003Dzt5jpbHs_003D.ViewportSize.Height, -Size.Width * 5, Size.Width * 5);
			_0023_003DzwTc0B2NdlyUi = Camera.ApplyPickMatrix(renderContext.ComputePickMatrix(_0023_003Dzt5jpbHs_003D.ZoomRect, new Size(_0023_003Dzt5jpbHs_003D.ViewportSize.Width, _0023_003Dzt5jpbHs_003D.ViewportSize.Height), new int[4]
			{
				0,
				0,
				_0023_003Dzt5jpbHs_003D.ViewportSize.Width,
				_0023_003Dzt5jpbHs_003D.ViewportSize.Height
			}), _0023_003DzwTc0B2NdlyUi);
			renderContext.SetMatrices(_0023_003DzwTc0B2NdlyUi, null);
		}
		if (_0023_003Dzt5jpbHs_003D.ViewportScaleRatio != 1f)
		{
			renderContext.MultMatrixModelView(Transformation.CreateScaling(_0023_003Dzt5jpbHs_003D.ViewportScaleRatio));
		}
		DrawText(Size.Width - (int)(70f * UtilityEx.GetScalingLevel().Width), (int)(5f * UtilityEx.GetScalingLevel().Height + (float)_0023_003DzZlBwqPrKrdKq), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590347), new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590336), 40f), Color.FromArgb(127, Background.GetContrastColor()), Color.Empty, ContentAlignment.BottomLeft, RotateFlipType.Rotate90FlipX);
		renderContext.PopMatrices();
	}

	public Bitmap RenderToBitmap(float drawScale)
	{
		return RenderToBitmap(drawScale, drawBackground: true);
	}

	public Bitmap RenderToBitmap(float drawScale, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(drawScale, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(float drawScale, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(default(RectangleF), drawScale, lineWeightFactor, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, float drawScale, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(rectangle, drawScale, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, float drawScale, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return _0023_003DzNZ5R7KqLKF7E(new _0023_003Dz7XrVzbNXMo8q
		{
			_0023_003Dzy4MPItw_003D = _0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = Size,
			_0023_003DzLCFtN0k_003D = rectangle,
			_0023_003DzCzsr4CTVr_Ea = drawScale,
			_0023_003DzCs_ZxbN2mZ30 = lineWeightFactor,
			_0023_003DzbUBvby4V64DY = drawBackground,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = hdwAcceleration,
			_0023_003Dz0W4nCS2oJwWK = true,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = true,
			_0023_003DzmAezgho6pU2i = _0023_003Dz0TvaYNo_003D.IsDesignMode(),
			_0023_003DzHdL9CKamSnvn = _0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE
		});
	}

	internal Bitmap _0023_003DzNZ5R7KqLKF7E(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003Dz0TvaYNo_003D.InvokeRequired)
		{
			return (Bitmap)_0023_003Dz0TvaYNo_003D.Invoke(new Func<_0023_003Dz7XrVzbNXMo8q, Bitmap>(_0023_003DzMWyfRlqxWPggi7gFL86dZP_4Hv00), _0023_003DzCBM7XJK4_5H_0024);
		}
		return _0023_003DzMWyfRlqxWPggi7gFL86dZP_4Hv00(_0023_003DzCBM7XJK4_5H_0024);
	}

	internal Bitmap _0023_003DzMWyfRlqxWPggi7gFL86dZP_4Hv00(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024)
	{
		Workspace workspace = _0023_003Dz0TvaYNo_003D;
		bool flag = true;
		Workspace workspace2 = workspace;
		object[] array = null;
		array = new object[2] { workspace2, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		if (_0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea <= 0f)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589295), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590379));
		}
		if (_0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590395));
		}
		Background.FreezeBrightness(freeze: true);
		new Rectangle(Location, Size);
		if (_0023_003DzCBM7XJK4_5H_0024._0023_003DzCs_ZxbN2mZ30 <= 0f)
		{
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzCs_ZxbN2mZ30 = _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea;
		}
		_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzgES1H_48XRD7GgtPkA_003D_003D();
		_0023_003DzjDuhintYzbDe(_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
		_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzyU8zEa9rYhPN(this));
		Size _0023_003DzDHWkcCNifSS = (_0023_003DzCBM7XJK4_5H_0024._0023_003DzxFNeIFWItLae.IsEmpty ? Size : _0023_003DzCBM7XJK4_5H_0024._0023_003DzxFNeIFWItLae);
		if (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.IsEmpty)
		{
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D = new Rectangle(Location.X, Location.Y, _0023_003DzDHWkcCNifSS.Width, _0023_003DzDHWkcCNifSS.Height);
		}
		else if (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width < 1f || _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height < 1f)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590459), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591784));
		}
		RectangleF _0023_003DzF7kGEgqMZE2_ = default(Rectangle);
		Size size = new Size((int)(_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width * _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea), (int)(_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height * _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea));
		Size size2 = Size;
		System.Drawing.Point location = Location;
		RectangleF _0023_003DzLCFtN0k_003D = _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D;
		float _0023_003DzCzsr4CTVr_Ea = _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea;
		double zoomFactor = Camera.ZoomFactor;
		Size size3 = (Size = _0023_003Dz8ASVHGVfEpKc(_0023_003DzDHWkcCNifSS, _0023_003Dz0TvaYNo_003D.Size, _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea, _0023_003Dzt4E1aSFxKoQEFRsMTQ_003D_003D: false));
		_0023_003DzDHWkcCNifSS = size3;
		float num = ((!_0023_003DzCBM7XJK4_5H_0024._0023_003DzxFNeIFWItLae.IsEmpty) ? ((float)_0023_003DzDHWkcCNifSS.Width / (float)_0023_003DzCBM7XJK4_5H_0024._0023_003DzxFNeIFWItLae.Width) : ((float)_0023_003DzDHWkcCNifSS.Width / (float)size2.Width));
		_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D = new RectangleF((_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.X - (float)location.X) * num, (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Y - (float)location.Y) * num, num * _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width, num * _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height);
		Location = new System.Drawing.Point(0, 0);
		Camera.ZoomFactor *= num;
		Size size5 = ((!(num < 1f)) ? _0023_003Dz8ASVHGVfEpKc(size, Size, _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea, _0023_003Dzt4E1aSFxKoQEFRsMTQ_003D_003D: true) : Size);
		int num3;
		int num2 = (num3 = (int)Math.Ceiling((double)size.Width / (double)size5.Width));
		int num5;
		int num4 = (num5 = (int)Math.Ceiling((double)size.Height / (double)size5.Height));
		double[] _0023_003DzF7jvx0NGqi2c = (double[])Camera.ProjectionMatrix.Clone();
		double[] _0023_003DzSjxujsYzN51j = (double[])Camera.ModelViewMatrix.Clone();
		int num6 = size.Width / num3;
		int num7 = size.Height / num5;
		int num8 = size.Width - num3 * num6;
		if (num8 > 0 && num8 < num6)
		{
			num3++;
		}
		int num9 = size.Height - num5 * num7;
		if (num9 > 0 && num9 < num7)
		{
			num5++;
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzkQRTXiC03yes = true;
		backgroundStyleType styleMode = _0023_003Dz2bwAPoQwFwzX.StyleMode;
		Color topColor = _0023_003Dz2bwAPoQwFwzX.TopColor;
		bool flag2 = false;
		if (!_0023_003DzCBM7XJK4_5H_0024._0023_003DzbUBvby4V64DY && _0023_003DzCBM7XJK4_5H_0024._0023_003DzNLGcq5k_003D != Color.Empty && Background.StyleMode != backgroundStyleType.None)
		{
			_0023_003Dz2bwAPoQwFwzX.StyleMode = backgroundStyleType.Solid;
			_0023_003Dz2bwAPoQwFwzX.TopColor = RenderContextUtility.ConvertColor(_0023_003DzCBM7XJK4_5H_0024._0023_003DzNLGcq5k_003D);
			flag2 = true;
		}
		bool _0023_003DzGk93_rs_003D = Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: false);
		Bitmap result = null;
		try
		{
			float num10 = _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width * (float)num8 / (float)size.Width;
			float num11 = _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height * (float)num9 / (float)size.Height;
			float _0023_003DzmoyVYKE_003D = (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width - num10) / (float)num2;
			float _0023_003DzRijuYdw_003D = (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height - num11) / (float)num4;
			_0023_003DzF7kGEgqMZE2_.Width = (float)_0023_003DzDHWkcCNifSS.Width * _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width / (float)size.Width;
			_0023_003DzF7kGEgqMZE2_.Height = (float)_0023_003DzDHWkcCNifSS.Height * _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height / (float)size.Height;
			Rectangle _0023_003Dzsb60IF3_uaUO = new Rectangle(0, 0, num6, num7);
			PointF pointF = new System.Drawing.Point((int)_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.X, (int)_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Y);
			pointF = ScreenToViewport(_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Location);
			Point2D point2D = new Point2D(pointF.X, (float)_0023_003DzDHWkcCNifSS.Height - (pointF.Y + _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height));
			DrawSceneParams _0023_003DzyrRdBi78wMnR = new DrawSceneParams
			{
				UserInterfaceElement = _0023_003DzCBM7XJK4_5H_0024._0023_003Dz_0024wNiWEC_IG_0024k,
				DrawAllUIElements = _0023_003DzCBM7XJK4_5H_0024._0023_003DzmAezgho6pU2i,
				ViewportSize = _0023_003DzDHWkcCNifSS,
				Viewport = this,
				DrawScale = _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea,
				ViewportScaleRatio = num,
				LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024._0023_003DzCs_ZxbN2mZ30,
				startZoomPt = new PointF((float)point2D.X, (float)point2D.Y),
				DrawOverlay = true,
				IsDesignMode = false,
				CaptureSurface = true,
				CameraEyePos = CameraEyePosType.Center,
				IsUIElement = (_0023_003DzCBM7XJK4_5H_0024._0023_003Dz_0024wNiWEC_IG_0024k is UserInterfaceBase),
				Rectangle = _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D,
				Entities = null,
				Blocks = _0023_003Dz0TvaYNo_003D._0023_003DzoE3BE__0024RS_DJ(),
				RenderContext = _0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzmNZD0Zs_003D,
				isSketchActive = (_0023_003Dz0TvaYNo_003D is Design design && design.CurrentSketch != null),
				SkipImageBasedSilho = (num3 != 1 || num5 != 1),
				SkipSsao = (num3 != 1 || num5 != 1),
				DrawLegends = _0023_003DzCBM7XJK4_5H_0024._0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D,
				DrawLabels = _0023_003DzCBM7XJK4_5H_0024._0023_003Dz0W4nCS2oJwWK
			};
			if (_0023_003DzCBM7XJK4_5H_0024._0023_003Dzjgn1DPI_003D == null || !_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzmNZD0Zs_003D.HasFBO())
			{
				result = _0023_003DzkqYnLHHKsb9c(_0023_003DzCBM7XJK4_5H_0024, size, num6, num7, num5, num3, _0023_003DzF7kGEgqMZE2_, point2D, _0023_003DzmoyVYKE_003D, _0023_003DzRijuYdw_003D, _0023_003Dzsb60IF3_uaUO, _0023_003DzyrRdBi78wMnR, _0023_003DzF7jvx0NGqi2c, _0023_003DzSjxujsYzN51j, num, pointF);
			}
			else if (!_0023_003Dz6HvAK7e77C4C(_0023_003DzCBM7XJK4_5H_0024, num3, num5, _0023_003DzF7kGEgqMZE2_, point2D, _0023_003DzmoyVYKE_003D, _0023_003DzRijuYdw_003D, _0023_003DzyrRdBi78wMnR, num6, num7))
			{
				Background.FreezeBrightness(freeze: false);
				return null;
			}
		}
		finally
		{
			Camera.InvalidateZRange(_0023_003DzGk93_rs_003D);
			if (flag2)
			{
				_0023_003Dz2bwAPoQwFwzX.StyleMode = styleMode;
				_0023_003Dz2bwAPoQwFwzX.TopColor = topColor;
			}
			Size = size2;
			Location = location;
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D = _0023_003DzLCFtN0k_003D;
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea = _0023_003DzCzsr4CTVr_Ea;
			Camera.ZoomFactor = zoomFactor;
			_0023_003Dz0TvaYNo_003D._0023_003DzkQRTXiC03yes = false;
		}
		Background.FreezeBrightness(freeze: false);
		return result;
	}

	private static bool _0023_003Dz6HvAK7e77C4C(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024, int _0023_003DzYVeE_OP_B9SkaQ3fSw_003D_003D, int _0023_003DzlJTXeX7_XVgP9qC_0024Gg_003D_003D, RectangleF _0023_003DzF7kGEgqMZE2_, Point2D _0023_003DzZ5eHl_0024x4k5h8, float _0023_003DzmoyVYKE_003D, float _0023_003DzRijuYdw_003D, DrawSceneParams _0023_003DzyrRdBi78wMnR, int _0023_003DzNcT2wHJlbLpO, int _0023_003DzhaMurLM8BvXm)
	{
		if (_0023_003DzYVeE_OP_B9SkaQ3fSw_003D_003D > 1 || _0023_003DzlJTXeX7_XVgP9qC_0024Gg_003D_003D > 1)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzlJTXeX7_XVgP9qC_0024Gg_003D_003D; i++)
		{
			for (int j = 0; j < _0023_003DzYVeE_OP_B9SkaQ3fSw_003D_003D; j++)
			{
				_0023_003DzF7kGEgqMZE2_.X = (float)(_0023_003DzZ5eHl_0024x4k5h8.X + (double)((float)j * _0023_003DzmoyVYKE_003D));
				_0023_003DzF7kGEgqMZE2_.Y = (float)(_0023_003DzZ5eHl_0024x4k5h8.Y + (double)((float)i * _0023_003DzRijuYdw_003D));
				_0023_003DzyrRdBi78wMnR.ZoomRect = _0023_003DzF7kGEgqMZE2_;
				_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzxZAI1cgKJ8nHr9eHHQ_003D_003D(_0023_003DzyrRdBi78wMnR, j, i, _0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, null, _0023_003DzCBM7XJK4_5H_0024._0023_003Dzjgn1DPI_003D, _0023_003DzCBM7XJK4_5H_0024._0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, _0023_003DzCBM7XJK4_5H_0024._0023_003DzHdL9CKamSnvn);
			}
		}
		return true;
	}

	private Bitmap _0023_003DzkqYnLHHKsb9c(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024, Size _0023_003DzGU7h4lvlOSUx, int _0023_003DzNcT2wHJlbLpO, int _0023_003DzhaMurLM8BvXm, int _0023_003DzlJTXeX7_XVgP9qC_0024Gg_003D_003D, int _0023_003DzYVeE_OP_B9SkaQ3fSw_003D_003D, RectangleF _0023_003DzF7kGEgqMZE2_, Point2D _0023_003DzZ5eHl_0024x4k5h8, float _0023_003DzmoyVYKE_003D, float _0023_003DzRijuYdw_003D, Rectangle _0023_003Dzsb60IF3_uaUO, DrawSceneParams _0023_003DzyrRdBi78wMnR, double[] _0023_003DzF7jvx0NGqi2c, double[] _0023_003DzSjxujsYzN51j, float _0023_003Dz9DzCOOE601Zj, PointF _0023_003DzATkjS6BP_0024hP3)
	{
		Bitmap bitmap = null;
		try
		{
			try
			{
				bitmap = new Bitmap(_0023_003DzGU7h4lvlOSUx.Width, _0023_003DzGU7h4lvlOSUx.Height, PixelFormat.Format32bppArgb);
			}
			catch (Exception)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591800));
			}
			int bpp = 3;
			PixelFormat format = PixelFormat.Format24bppRgb;
			if (_0023_003DzyrRdBi78wMnR.TransparentBackground())
			{
				bpp = 4;
				format = PixelFormat.Format32bppArgb;
			}
			_0023_003DzyrRdBi78wMnR.Bpp = bpp;
			Bitmap bitmap2 = new Bitmap(_0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, format);
			if (Labels.Any((devDept.Eyeshot.Control.Labels.Label _0023_003Dz8l4HZIo_003D) => _0023_003Dz8l4HZIo_003D.AutoHide))
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzHcYFj1p87o4J(this, null);
				_0023_003Dz4DjPZGU_003D(_0023_003DzyrRdBi78wMnR.ViewFrame);
			}
			_0023_003DzEjKrfNCIUBvodq6b1UlvfeA_003D(_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D.RenderContext, _0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea, _0023_003DzAzWdP6cAQfYlGyxO3w_003D_003D: false);
			using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			for (int num = 0; num < _0023_003DzlJTXeX7_XVgP9qC_0024Gg_003D_003D; num++)
			{
				for (int num2 = 0; num2 < _0023_003DzYVeE_OP_B9SkaQ3fSw_003D_003D; num2++)
				{
					_0023_003DzF7kGEgqMZE2_.X = (float)(_0023_003DzZ5eHl_0024x4k5h8.X + (double)((float)num2 * _0023_003DzmoyVYKE_003D));
					_0023_003DzF7kGEgqMZE2_.Y = (float)(_0023_003DzZ5eHl_0024x4k5h8.Y + (double)((float)num * _0023_003DzRijuYdw_003D));
					BitmapData bitmapData = bitmap2.LockBits(_0023_003Dzsb60IF3_uaUO, ImageLockMode.WriteOnly, format);
					_0023_003DzyrRdBi78wMnR.ZoomRect = _0023_003DzF7kGEgqMZE2_;
					_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzxZAI1cgKJ8nHr9eHHQ_003D_003D(_0023_003DzyrRdBi78wMnR, num2, num, _0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, bitmapData, null, _0023_003DzCBM7XJK4_5H_0024._0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, _0023_003DzCBM7XJK4_5H_0024._0023_003DzHdL9CKamSnvn);
					bitmap2.UnlockBits(bitmapData);
					graphics.DrawImage(bitmap2, num2 * _0023_003DzNcT2wHJlbLpO, num * _0023_003DzhaMurLM8BvXm);
				}
			}
			bitmap2.Dispose();
			Camera.ProjectionMatrix = _0023_003DzF7jvx0NGqi2c;
			Camera.ModelViewMatrix = _0023_003DzSjxujsYzN51j;
			graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			return bitmap;
		}
		catch (Exception)
		{
			bitmap?.Dispose();
			throw;
		}
		finally
		{
			_0023_003DzEjKrfNCIUBvodq6b1UlvfeA_003D(_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D.RenderContext, 1.0, _0023_003DzAzWdP6cAQfYlGyxO3w_003D_003D: true);
		}
	}

	private void _0023_003DzEjKrfNCIUBvodq6b1UlvfeA_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, double _0023_003DzCzsr4CTVr_Ea, bool _0023_003DzAzWdP6cAQfYlGyxO3w_003D_003D)
	{
		foreach (devDept.Eyeshot.Control.Labels.Label label in Labels)
		{
			label.Regen(_0023_003DzmNZD0Zs_003D, (float)_0023_003DzCzsr4CTVr_Ea);
		}
		OriginSymbol[] array = _0023_003DzMUeJTCp30C0O;
		foreach (OriginSymbol originSymbol in array)
		{
			if (originSymbol.Visible)
			{
				originSymbol.UpdateTexturesForScaledDrawing(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
			}
		}
		if (CoordinateSystemIcon != null && CoordinateSystemIcon.Visible)
		{
			CoordinateSystemIcon.UpdateTexturesForScaledDrawing(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
		}
		if (_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS.Visible)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003Dz2TOCTXsyZLWU.Regen(_0023_003DzmNZD0Zs_003D, (float)_0023_003DzCzsr4CTVr_Ea);
		}
		_0023_003DzLIwPv16B13qilCw_jA_003D_003D = _0023_003DzAzWdP6cAQfYlGyxO3w_003D_003D;
	}

	private static Size _0023_003Dz8ASVHGVfEpKc(Size _0023_003DzDHWkcCNifSS1, Size _0023_003Dzgtx7d7U_003D, double _0023_003Dz8XQ5s7gPiLyb, bool _0023_003Dzt4E1aSFxKoQEFRsMTQ_003D_003D)
	{
		if (!Workspace._0023_003Dz90lrgtZ04hwu(_0023_003Dzgtx7d7U_003D))
		{
			return _0023_003DzDHWkcCNifSS1;
		}
		double num = (double)_0023_003DzDHWkcCNifSS1.Width / (double)_0023_003DzDHWkcCNifSS1.Height;
		int num2;
		int num3;
		if (_0023_003DzDHWkcCNifSS1.Width > _0023_003DzDHWkcCNifSS1.Height)
		{
			num2 = ((!_0023_003Dzt4E1aSFxKoQEFRsMTQ_003D_003D) ? Math.Max(_0023_003DzDHWkcCNifSS1.Height, _0023_003Dzgtx7d7U_003D.Height) : Math.Min(_0023_003DzDHWkcCNifSS1.Height, _0023_003Dzgtx7d7U_003D.Height));
			num3 = (int)Math.Round((double)num2 * num);
			if (num3 > _0023_003Dzgtx7d7U_003D.Width)
			{
				num3 = _0023_003Dzgtx7d7U_003D.Width;
				num2 = (int)((double)num3 / num);
			}
		}
		else
		{
			num3 = ((!_0023_003Dzt4E1aSFxKoQEFRsMTQ_003D_003D) ? Math.Max(_0023_003DzDHWkcCNifSS1.Width, _0023_003Dzgtx7d7U_003D.Width) : Math.Min(_0023_003DzDHWkcCNifSS1.Width, _0023_003Dzgtx7d7U_003D.Width));
			num2 = (int)Math.Round((double)num3 / num);
			if (num2 > _0023_003Dzgtx7d7U_003D.Height)
			{
				num2 = _0023_003Dzgtx7d7U_003D.Height;
				num3 = (int)((double)num2 * num);
			}
		}
		if (num3 > _0023_003Dzgtx7d7U_003D.Width)
		{
			double num4 = (double)_0023_003Dzgtx7d7U_003D.Width / (double)num3;
			num3 = _0023_003Dzgtx7d7U_003D.Width;
			num2 = (int)Math.Round((double)num2 * num4);
		}
		if (num2 > _0023_003Dzgtx7d7U_003D.Height)
		{
			double num5 = (double)_0023_003Dzgtx7d7U_003D.Height / (double)num2;
			num2 = _0023_003Dzgtx7d7U_003D.Height;
			num3 = (int)Math.Round((double)num3 * num5);
		}
		if ((double)((float)num3 / (float)_0023_003DzDHWkcCNifSS1.Width) > _0023_003Dz8XQ5s7gPiLyb)
		{
			num3 = (int)Math.Round((double)_0023_003DzDHWkcCNifSS1.Width * _0023_003Dz8XQ5s7gPiLyb);
			num2 = (int)Math.Round((double)_0023_003DzDHWkcCNifSS1.Height * _0023_003Dz8XQ5s7gPiLyb);
		}
		return new Size(num3, num2);
	}

	public Bitmap RenderToBitmap(Size bitmapSize, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(bitmapSize, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration, drawUiElements: false);
	}

	public Bitmap RenderToBitmap(Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration, bool drawUiElements)
	{
		return RenderToBitmap(default(Rectangle), bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration, drawUiElements);
	}

	public Bitmap RenderToBitmap(Rectangle rectangle, Size bitmapSize, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(rectangle, bitmapSize, 0f, drawBackground, hdwAcceleration);
	}

	internal void _0023_003DzzpG3rT4lYHMG(TextureBase _0023_003Dz_IfKSJY_003D, Rectangle _0023_003DzLCFtN0k_003D, float _0023_003DzCs_ZxbN2mZ30, bool _0023_003DzbUBvby4V64DY, bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, bool _0023_003DzmAezgho6pU2i)
	{
		_0023_003DzzpG3rT4lYHMG(_0023_003Dz_IfKSJY_003D, _0023_003DzLCFtN0k_003D, _0023_003DzCs_ZxbN2mZ30, _0023_003DzbUBvby4V64DY ? Color.Empty : Color.White, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, _0023_003DzmAezgho6pU2i);
	}

	internal void _0023_003DzzpG3rT4lYHMG(TextureBase _0023_003Dz_IfKSJY_003D, Rectangle _0023_003DzLCFtN0k_003D, float _0023_003DzCs_ZxbN2mZ30, Color _0023_003DzNLGcq5k_003D, bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, bool _0023_003DzmAezgho6pU2i)
	{
		_0023_003DzNZ5R7KqLKF7E(new _0023_003Dz7XrVzbNXMo8q
		{
			_0023_003Dzy4MPItw_003D = _0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = Size,
			_0023_003DzLCFtN0k_003D = _0023_003DzLCFtN0k_003D,
			_0023_003DzCs_ZxbN2mZ30 = _0023_003DzCs_ZxbN2mZ30,
			_0023_003DzbUBvby4V64DY = false,
			_0023_003DzNLGcq5k_003D = _0023_003DzNLGcq5k_003D,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D,
			_0023_003Dz0W4nCS2oJwWK = false,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = false,
			_0023_003DzmAezgho6pU2i = _0023_003DzmAezgho6pU2i,
			_0023_003DzHdL9CKamSnvn = _0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE,
			_0023_003Dzjgn1DPI_003D = _0023_003Dz_IfKSJY_003D
		}, _0023_003Dz_IfKSJY_003D.Size);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(rectangle, bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration, drawUiElements: false);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration, bool drawUiElements)
	{
		return RenderToBitmap(rectangle, bitmapSize, lineWeightFactor, drawBackground ? Color.Empty : Color.White, hdwAcceleration, drawUiElements);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, Size bitmapSize, float lineWeightFactor, Color backgroundColor, bool hdwAcceleration, bool drawUiElements)
	{
		return _0023_003DzNZ5R7KqLKF7E(new _0023_003Dz7XrVzbNXMo8q
		{
			_0023_003Dzy4MPItw_003D = _0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = Size,
			_0023_003DzLCFtN0k_003D = rectangle,
			_0023_003DzCs_ZxbN2mZ30 = lineWeightFactor,
			_0023_003DzbUBvby4V64DY = false,
			_0023_003DzNLGcq5k_003D = backgroundColor,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = hdwAcceleration,
			_0023_003Dz0W4nCS2oJwWK = true,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = true,
			_0023_003DzmAezgho6pU2i = drawUiElements,
			_0023_003DzHdL9CKamSnvn = _0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE
		}, bitmapSize);
	}

	internal Bitmap _0023_003DzNZ5R7KqLKF7E(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024, Size _0023_003Dz9UoBAvg_003D)
	{
		if (_0023_003Dz0TvaYNo_003D.InvokeRequired)
		{
			_0023_003Dz0TvaYNo_003D.Invoke(new Action<_0023_003Dz7XrVzbNXMo8q, Size>(_0023_003Dze0RWX0p5Yk8D), _0023_003DzCBM7XJK4_5H_0024, _0023_003Dz9UoBAvg_003D);
		}
		else
		{
			_0023_003Dze0RWX0p5Yk8D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz9UoBAvg_003D);
		}
		return _0023_003DzNZ5R7KqLKF7E(_0023_003DzCBM7XJK4_5H_0024);
	}

	private void _0023_003Dze0RWX0p5Yk8D(_0023_003Dz7XrVzbNXMo8q _0023_003DzCBM7XJK4_5H_0024, Size _0023_003Dz9UoBAvg_003D)
	{
		double num = (double)_0023_003Dz9UoBAvg_003D.Height / (double)_0023_003Dz9UoBAvg_003D.Width;
		_0023_003DzjDuhintYzbDe(_0023_003DzCBM7XJK4_5H_0024._0023_003Dzy4MPItw_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
		if (_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.IsEmpty)
		{
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
		}
		if (num < 1.0)
		{
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea = (float)_0023_003Dz9UoBAvg_003D.Height / _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Height;
		}
		else
		{
			_0023_003DzCBM7XJK4_5H_0024._0023_003DzCzsr4CTVr_Ea = (float)_0023_003Dz9UoBAvg_003D.Width / _0023_003DzCBM7XJK4_5H_0024._0023_003DzLCFtN0k_003D.Width;
		}
	}

	public void WriteToFileRaster(float drawScale, string filePath, ImageFormat format, bool drawBackground, bool hdwAcceleration = true)
	{
		WriteToFileRaster(drawScale, 0f, filePath, format, drawBackground, hdwAcceleration);
	}

	public void WriteToFileRaster(float drawScale, float lineWeightFactor, string filePath, ImageFormat format, bool drawBackground, bool hdwAcceleration = true)
	{
		Bitmap bitmap = _0023_003DzNZ5R7KqLKF7E(new _0023_003Dz7XrVzbNXMo8q
		{
			_0023_003Dzy4MPItw_003D = _0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = Size,
			_0023_003DzLCFtN0k_003D = default(Rectangle),
			_0023_003DzCzsr4CTVr_Ea = drawScale,
			_0023_003DzCs_ZxbN2mZ30 = lineWeightFactor,
			_0023_003DzbUBvby4V64DY = drawBackground,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = hdwAcceleration,
			_0023_003Dz0W4nCS2oJwWK = true,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = true,
			_0023_003DzHdL9CKamSnvn = _0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE
		});
		bitmap.Save(filePath, format);
		bitmap.Dispose();
	}

	public void CopyToClipboardRaster(float drawScale, bool drawBackground, bool hdwAcceleration = true)
	{
		CopyToClipboardRaster(drawScale, 0f, drawBackground, hdwAcceleration);
	}

	public void CopyToClipboardRaster(float drawScale, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		_0023_003DzyTxplglIp34Z1TMeuCdiY4s_003D(drawScale, lineWeightFactor, drawBackground, hdwAcceleration);
	}

	internal void _0023_003DzyTxplglIp34Z1TMeuCdiY4s_003D(float _0023_003DzCzsr4CTVr_Ea, float _0023_003DzCs_ZxbN2mZ30, bool _0023_003DzbUBvby4V64DY, bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D)
	{
		Bitmap bitmap = RenderToBitmap(_0023_003DzCzsr4CTVr_Ea, _0023_003DzCs_ZxbN2mZ30, _0023_003DzbUBvby4V64DY, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D);
		Clipboard.SetImage(bitmap);
		bitmap.Dispose();
	}

	internal void _0023_003Dzpupdtp8TpznE(RenderContextBase _0023_003DzoC62DbA_003D, ShaderParameters _0023_003DzgcK4Z11iT1YA, TextureBase _0023_003Dz_IfKSJY_003D)
	{
		_0023_003DzoC62DbA_003D.PushDepthStencilState();
		_0023_003DzoC62DbA_003D.EnableXORForTexture(enable: true, _0023_003DzgcK4Z11iT1YA);
		_0023_003DzoC62DbA_003D.SetShader(shaderType.Texture2DNoLights);
		_0023_003DzoC62DbA_003D.SetLighting(enable: false);
		_0023_003DzoC62DbA_003D.UpdateConstantBufferPerFrame(_0023_003DzgcK4Z11iT1YA);
		_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestAlways);
		Point3D point = ((Rotate.RotationCenter != rotationCenterType.Point) ? Camera.centerOfRotation : Rotate.Center);
		Point3D point3D = WorldToScreen(point);
		point3D.X -= Location.X;
		point3D.Y -= _0023_003Dz0TvaYNo_003D.Size.Height - (Location.Y + Size.Height);
		int num = (int)Math.Round((float)_0023_003Dz0TvaYNo_003D.PickBoxSize / 2f);
		RectangleF rect = new RectangleF((float)(point3D.X - (double)num), (float)(point3D.Y - (double)num), 2 * num, 2 * num);
		_0023_003DzoC62DbA_003D.DrawQuad(_0023_003Dz_IfKSJY_003D, byte.MaxValue, rect, 0f, flipY: false);
		_0023_003DzoC62DbA_003D.PopDepthStencilState();
		_0023_003DzoC62DbA_003D.EnableXORForTexture(enable: false, _0023_003DzgcK4Z11iT1YA);
	}

	internal ShaderParameters _0023_003Dzms3vFmj75BNW()
	{
		return new ShaderParameters(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, GetViewFrame(), Camera, _0023_003Dz0TvaYNo_003D._0023_003DznKkOfo8_003D.ShadowMode, _0023_003Dz0TvaYNo_003D._0023_003DznKkOfo8_003D.RealisticShadowQuality, Background, _0023_003Dz0TvaYNo_003D._0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D, _0023_003Dz0TvaYNo_003D._0023_003DznKkOfo8_003D.EnvironmentMapping, 1f, RectangleF.Empty, _0023_003Dz0TvaYNo_003D.CurrentTransformation ?? new Identity());
	}

	public virtual void ZoomCamera(int dy)
	{
		ZoomCamera(dy, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void ZoomCamera(int dy, bool animate)
	{
		ZoomCamera(dy, Zoom.Speed, animate);
	}

	public virtual void ZoomCamera(System.Drawing.Point mousePos, int dy)
	{
		_0023_003DzOGB11N54M7E_0024(mousePos, dy, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void ZoomCamera(System.Drawing.Point mousePos, int dy, bool animate)
	{
		_0023_003DzOGB11N54M7E_0024(mousePos, dy, animate);
	}

	public virtual void ZoomCamera(int dy, double zoomSpeed)
	{
		_0023_003DzOGB11N54M7E_0024(dy, zoomSpeed, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void ZoomCamera(int dy, double zoomSpeed, bool animate)
	{
		_0023_003DzOGB11N54M7E_0024(dy, zoomSpeed, animate);
	}

	private void _0023_003Dz11CadYMOXmz_()
	{
		if (_0023_003Dz0TvaYNo_003D._0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D != null && !_0023_003Dz0TvaYNo_003D._0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Enabled)
		{
			_0023_003Dz0TvaYNo_003D._0023_003Dz11CadYMOXmz_(this);
		}
	}

	private void _0023_003DzOGB11N54M7E_0024(int _0023_003DzJx6crCU_003D, double _0023_003Dz_kOvEksRmIyM, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			return;
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzBrC4gBvWiHkA = mouseInputType.Standard;
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		if (Camera.ProjectionMode == projectionType.Perspective)
		{
			if (Camera.ZBufferData.Dirty)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzHcYFj1p87o4J(this, null);
			}
			bool _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D = !Camera.UpdateZBufferRange(System.Drawing.Point.Empty, _0023_003Dz0TvaYNo_003D.PickBoxSize, _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D(), _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
			ZBuffer zBuffer = (ZBuffer)Camera.ZBufferData;
			Camera.Zoom(GetViewFrame(), zBuffer.ModelViewMatrix, zBuffer.ProjectionMatrix, zBuffer.Location, System.Drawing.Point.Empty, _0023_003DzJx6crCU_003D, zBuffer.Min, zBuffer.Max, _0023_003Dz_kOvEksRmIyM, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D);
		}
		else
		{
			Camera.Zoom(GetViewFrame(), Camera.ModelViewMatrix, Camera.ProjectionMatrix, Camera.Location, System.Drawing.Point.Empty, _0023_003DzJx6crCU_003D, 0.0, 1.0, _0023_003Dz_kOvEksRmIyM, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D: false);
		}
		_0023_003DzDPj_N6S1Xq2Y(_0023_003DzBQC8k3F0wJN4);
		if (_0023_003DzBQC8k3F0wJN4)
		{
			int _0023_003DzZnwLfu4_003D = _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
			_0023_003DzDela6KtNzcrF(_0023_003DzZnwLfu4_003D, target, distance, zoomFactor);
		}
		else
		{
			_0023_003Dz11CadYMOXmz_();
		}
	}

	private void _0023_003DzOGB11N54M7E_0024(System.Drawing.Point _0023_003DzTYCHRugcseEq, int _0023_003DzJx6crCU_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			return;
		}
		bool flag = false;
		int[] viewFrame = GetViewFrame();
		System.Drawing.Point _0023_003Dz_002428NCIRAss_ = ViewportToScreen(_0023_003DzTYCHRugcseEq);
		_0023_003Dz_002428NCIRAss_.Y = _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - _0023_003Dz_002428NCIRAss_.Y;
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		if (Camera.ProjectionMode == projectionType.Perspective)
		{
			if (Camera.ZBufferData.Dirty)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzHcYFj1p87o4J(this, null);
			}
			bool isInvalidRange = Camera.ZBufferData.IsInvalidRange;
			flag = Camera.UpdateZBufferRange(ViewportToCameraScreen(_0023_003DzTYCHRugcseEq), _0023_003Dz0TvaYNo_003D.PickBoxSize, _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D(), _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
			ZBuffer zBuffer = (ZBuffer)Camera.ZBufferData;
			if (isInvalidRange && !flag)
			{
				Camera.Zoom(viewFrame, Camera.ModelViewMatrix, Camera.ProjectionMatrix, Camera.Location, _0023_003Dz_002428NCIRAss_, _0023_003DzJx6crCU_003D, zBuffer.Min, zBuffer.Max, Zoom.Speed, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D: true);
			}
			else
			{
				Camera.Zoom(viewFrame, zBuffer.ModelViewMatrix, zBuffer.ProjectionMatrix, zBuffer.Location, _0023_003Dz_002428NCIRAss_, _0023_003DzJx6crCU_003D, zBuffer.Min, zBuffer.Max, Zoom.Speed, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D: false);
			}
		}
		else
		{
			Camera.Zoom(viewFrame, Camera.ModelViewMatrix, Camera.ProjectionMatrix, Camera.Location, _0023_003Dz_002428NCIRAss_, _0023_003DzJx6crCU_003D, 0.0, 1.0, Zoom.Speed, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D: false);
		}
		_0023_003DzDPj_N6S1Xq2Y(_0023_003DzBQC8k3F0wJN4);
		if (_0023_003DzBQC8k3F0wJN4)
		{
			int _0023_003DzZnwLfu4_003D = _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
			_0023_003DzDela6KtNzcrF(_0023_003DzZnwLfu4_003D, target, distance, zoomFactor);
		}
		else
		{
			_0023_003Dz11CadYMOXmz_();
		}
	}

	internal void _0023_003DzDPj_N6S1Xq2Y(bool _0023_003DzBQC8k3F0wJN4)
	{
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
		if (!_0023_003DzBQC8k3F0wJN4)
		{
			_0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
			if (Camera.CheckPlanes())
			{
				AdjustNearAndFarPlanes();
			}
			else
			{
				Camera.RestorePreZoom();
			}
		}
	}

	public virtual void ZoomWindow(System.Drawing.Point p1, System.Drawing.Point p2)
	{
		_0023_003DzRU2PjWez6nJ3(p1, p2, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	private System.Drawing.Point _0023_003DzF00twIX9YjaBfv9f0Q_003D_003D(System.Drawing.Point _0023_003DzfOC0YjY_003D)
	{
		int x = Math.Max(0, Math.Min(_0023_003DzfOC0YjY_003D.X, Size.Width));
		int y = Math.Max(0, Math.Min(_0023_003DzfOC0YjY_003D.Y, Size.Height));
		return new System.Drawing.Point(x, y);
	}

	internal void _0023_003DzRU2PjWez6nJ3(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			return;
		}
		Workspace workspace = _0023_003Dz0TvaYNo_003D;
		bool flag = true;
		Workspace workspace2 = workspace;
		object[] array = null;
		array = new object[2] { workspace2, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		System.Drawing.Point _0023_003DzkW_0024DzQk_003D2 = _0023_003DzF00twIX9YjaBfv9f0Q_003D_003D(_0023_003DzkW_0024DzQk_003D);
		System.Drawing.Point _0023_003Dz8ecWqr4_003D2 = _0023_003DzF00twIX9YjaBfv9f0Q_003D_003D(_0023_003Dz8ecWqr4_003D);
		_0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(_0023_003DzkW_0024DzQk_003D2, _0023_003Dz8ecWqr4_003D2);
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		Camera camera = Camera;
		if (Camera.ProjectionMode == projectionType.Perspective)
		{
			double zMin = 0.0;
			double zMax = 0.0;
			if (camera.ZBufferData.ReadZRange(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, ViewportToCameraScreen(new System.Drawing.Point((_0023_003DzkW_0024DzQk_003D2.X + _0023_003Dz8ecWqr4_003D2.X) / 2, (_0023_003DzkW_0024DzQk_003D2.Y + _0023_003Dz8ecWqr4_003D2.Y) / 2)), Math.Abs(_0023_003DzkW_0024DzQk_003D2.X - _0023_003Dz8ecWqr4_003D2.X), Math.Abs(_0023_003DzkW_0024DzQk_003D2.Y - _0023_003Dz8ecWqr4_003D2.Y), ref zMin, ref zMax, optimizeRead: false, _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy()))
			{
				camera.ZBufferData.Min = zMin;
				camera.ZBufferData.Max = zMax;
			}
			_0023_003DzTYCZxck_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, Zoom.KeysStep, camera.ZBufferData.Min, Zoom.Speed, _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
		}
		else
		{
			_0023_003DzTYCZxck_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, Zoom.KeysStep, 0.0, Zoom.Speed, _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
		}
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
		if (!_0023_003DzBQC8k3F0wJN4)
		{
			AdjustNearAndFarPlanes();
			_0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
		}
		int _0023_003DzZnwLfu4_003D = _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
		camera.ZBufferData.Dirty = true;
		SavedViews.Save();
		if (_0023_003DzBQC8k3F0wJN4)
		{
			_0023_003DzDela6KtNzcrF(_0023_003DzZnwLfu4_003D, target, distance, zoomFactor);
		}
		else
		{
			_0023_003Dz11CadYMOXmz_();
		}
	}

	public virtual void ZoomFit()
	{
		ZoomFit(Zoom.FitMargin);
	}

	public virtual void ZoomFit(int margin)
	{
		ZoomFit(selectedOnly: false, Zoom.PerspectiveFitMode, margin);
	}

	public virtual void ZoomFit(bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode)
	{
		ZoomFit(selectedOnly, perspectiveFitMode, Zoom.FitMargin);
	}

	public virtual void ZoomFit(bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode, int margin)
	{
		_0023_003Dz7hZyO75hkvCs(new List<Entity> { _0023_003Dz0TvaYNo_003D._0023_003DzpU_kB1T_2Sae() }, selectedOnly, _0023_003DzuD1BtN007Uce: false, perspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: false, margin, _0023_003Dz0TvaYNo_003D.AnimateCamera, _0023_003Dz_00246Jev2I_003D: true, _0023_003DzhQd3_0024ARpbtAn: false);
	}

	public virtual void ZoomFit(IList<Entity> entList, bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode)
	{
		ZoomFit(entList, selectedOnly, perspectiveFitMode, Zoom.FitMargin);
	}

	public virtual void ZoomFit(IList<Entity> entList, bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode, int margin, bool fitLabels = false)
	{
		_0023_003Dz7hZyO75hkvCs(entList, selectedOnly, fitLabels, perspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: true, margin, _0023_003Dz0TvaYNo_003D.AnimateCamera, _0023_003Dz_00246Jev2I_003D: true, _0023_003DzhQd3_0024ARpbtAn: false);
	}

	internal void _0023_003Dz7hZyO75hkvCs(IList<Entity> _0023_003DzY_0024ABPwh9wryC, bool _0023_003DzGhkfdMlbGS2U, bool _0023_003DzuD1BtN007Uce, Camera.perspectiveFitType _0023_003Dz3DpORdoi_0024SUsX3ibBavIvd4_003D, bool _0023_003DzuHeqvmo_003D, bool _0023_003DzfcxLpl4Se0Cc, int _0023_003DzPG6BDWw_003D, bool _0023_003DzBQC8k3F0wJN4, bool _0023_003Dz_00246Jev2I_003D, bool _0023_003DzhQd3_0024ARpbtAn)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			return;
		}
		Workspace workspace = _0023_003Dz0TvaYNo_003D;
		bool flag = true;
		Workspace workspace2 = workspace;
		object[] array = null;
		array = new object[2] { workspace2, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: true);
		IList<Entity> _0023_003DzduSfKRsNCJOs = _0023_003DzY_0024ABPwh9wryC;
		if (_0023_003DzGhkfdMlbGS2U && _0023_003DzY_0024ABPwh9wryC.Count == 1 && _0023_003DzY_0024ABPwh9wryC[0] is BlockReference blockReference && blockReference.BlockName == _0023_003Dz0TvaYNo_003D.OpenBlock.Name)
		{
			_0023_003DzduSfKRsNCJOs = _0023_003Dz0TvaYNo_003D.CurrentBlock.Entities;
		}
		if (_0023_003Dz0TvaYNo_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO != null)
		{
			List<Entity> list = new List<Entity>(_0023_003DzY_0024ABPwh9wryC.Count + 1);
			list.AddRange(_0023_003DzY_0024ABPwh9wryC);
			if (Camera.SceneTransformationInverted != null)
			{
				_0023_003Dz0TvaYNo_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation = Camera.SceneTransformationInverted * _0023_003Dz0TvaYNo_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation;
				_0023_003Dz0TvaYNo_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.RegenMode = regenType.NotNeeded;
			}
			list.Add(_0023_003Dz0TvaYNo_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO);
			_0023_003DzduSfKRsNCJOs = list;
		}
		bool flag2 = _0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS.OverrideSceneExtents && !_0023_003DzfcxLpl4Se0Cc;
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		bool flag3 = _0023_003DzCJy6o9PkJ45N(_0023_003DzduSfKRsNCJOs, _0023_003DzGhkfdMlbGS2U, _0023_003DzhQd3_0024ARpbtAn, flag2);
		if ((_0023_003DzGhkfdMlbGS2U || _0023_003DzhQd3_0024ARpbtAn) && !flag3)
		{
			return;
		}
		_0023_003DzaXMvZUE_003D(_0023_003DzPG6BDWw_003D);
		_0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
		if (_0023_003DzuD1BtN007Uce && _0023_003DzF5TdZcc_003D.Count > 0 && !flag2)
		{
			_0023_003DzkdIaKV15YTDX(_0023_003DzPG6BDWw_003D, ref _0023_003DzduSfKRsNCJOs, _0023_003DzhQd3_0024ARpbtAn);
		}
		if (_0023_003Dz0TvaYNo_003D._0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.X < _0023_003Dz0TvaYNo_003D._0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.X)
		{
			Camera.centerOfRotation = Point3D.MidPoint(_0023_003Dz0TvaYNo_003D._0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr, _0023_003Dz0TvaYNo_003D._0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF);
		}
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.Rotate;
		int _0023_003DzZnwLfu4_003D = _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
		if (!_0023_003DzuHeqvmo_003D && Camera.ProjectionMode == projectionType.Perspective && _0023_003Dz3DpORdoi_0024SUsX3ibBavIvd4_003D == Camera.perspectiveFitType.Accurate)
		{
			if (flag2)
			{
				LinearPath linearPath = new LinearPath(Utility.GetBoundingBoxCorners(_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS.Min, _0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS.Max))
				{
					LayerName = _0023_003Dz0TvaYNo_003D.Layers.GetDefaultLayerName()
				};
				if (Camera.SceneTransformationInverted != null)
				{
					linearPath.TransformBy(Camera.SceneTransformationInverted);
				}
				linearPath.Regen(0.0);
				_0023_003DzduSfKRsNCJOs = new List<Entity>(new LinearPath[1] { linearPath });
			}
			_0023_003DzZ_0024IejP0R_0024_Cw.AdjustPerspectiveFit(_0023_003DzduSfKRsNCJOs, _0023_003Dz0TvaYNo_003D, _0023_003DzGhkfdMlbGS2U, _0023_003DzPG6BDWw_003D, _0023_003DzhQd3_0024ARpbtAn);
		}
		if (!_0023_003DzuHeqvmo_003D && !Camera.CheckPlanes())
		{
			Camera.Reset();
			_0023_003Dz7hZyO75hkvCs(_0023_003DzduSfKRsNCJOs, _0023_003DzGhkfdMlbGS2U, _0023_003DzuD1BtN007Uce, _0023_003Dz3DpORdoi_0024SUsX3ibBavIvd4_003D, _0023_003DzuHeqvmo_003D: true, _0023_003DzfcxLpl4Se0Cc, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4, _0023_003Dz_00246Jev2I_003D, _0023_003DzhQd3_0024ARpbtAn: false);
			_0023_003Dz11CadYMOXmz_();
			return;
		}
		Camera.ZBufferData.Dirty = true;
		if (!_0023_003DzuHeqvmo_003D && _0023_003DzBQC8k3F0wJN4)
		{
			_0023_003DzDela6KtNzcrF(_0023_003DzZnwLfu4_003D, target, distance, zoomFactor);
		}
		_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
		if (!_0023_003DzuHeqvmo_003D && _0023_003Dz_00246Jev2I_003D)
		{
			SavedViews.Save();
		}
		_0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
		if (Camera.SceneTransformationInverted != null)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003Dz36GfUMHowvLS();
		}
		_0023_003Dz11CadYMOXmz_();
		stopwatch.Stop();
		_0023_003DzZUaotclMqnW0 = stopwatch.ElapsedMilliseconds;
	}

	public virtual void ZoomFitSelectedLeaves()
	{
		ZoomFitSelectedLeaves(Zoom.FitMargin);
	}

	public virtual void ZoomFitSelectedLeaves(int margin)
	{
		ZoomFitSelectedLeaves(margin, Zoom.PerspectiveFitMode);
	}

	public virtual void ZoomFitSelectedLeaves(int margin, Camera.perspectiveFitType perspectiveFitMode)
	{
		_0023_003Dz7hZyO75hkvCs(_0023_003Dz0TvaYNo_003D.Entities, _0023_003DzGhkfdMlbGS2U: false, _0023_003DzuD1BtN007Uce: false, perspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: true, margin, _0023_003Dz0TvaYNo_003D.AnimateCamera, _0023_003Dz_00246Jev2I_003D: true, _0023_003DzhQd3_0024ARpbtAn: true);
	}

	public virtual void ZoomFit(IList<SelectedItem> items)
	{
		ZoomFit(items, Zoom.FitMargin);
	}

	public virtual void ZoomFit(IList<SelectedItem> items, int margin)
	{
		ZoomFit(items, margin, Zoom.PerspectiveFitMode);
	}

	public virtual void ZoomFit(IList<SelectedItem> items, int margin, Camera.perspectiveFitType perspectiveFitMode)
	{
		_0023_003Dz7hZyO75hkvCs(items, margin, perspectiveFitMode, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	internal virtual void _0023_003Dz7hZyO75hkvCs(IList<SelectedItem> _0023_003DzUl92GdI_003D, int _0023_003DzPG6BDWw_003D, Camera.perspectiveFitType _0023_003Dz3DpORdoi_0024SUsX3ibBavIvd4_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			list.Add(new NestedEntity(_0023_003DzUl92GdI_003D[i], _0023_003Dz0TvaYNo_003D.Layers, _0023_003Dz0TvaYNo_003D.Blocks, _0023_003Dz0TvaYNo_003D._0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
		}
		_0023_003Dz7hZyO75hkvCs(list, _0023_003DzGhkfdMlbGS2U: false, _0023_003DzuD1BtN007Uce: false, _0023_003Dz3DpORdoi_0024SUsX3ibBavIvd4_003D, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc: true, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4, _0023_003Dz_00246Jev2I_003D: true, _0023_003DzhQd3_0024ARpbtAn: false);
	}

	private void _0023_003DzkdIaKV15YTDX(int _0023_003DzPG6BDWw_003D, ref IList<Entity> _0023_003DzduSfKRsNCJOs, bool _0023_003DzhQd3_0024ARpbtAn)
	{
		int[] viewFrame = GetViewFrame();
		_0023_003DzduSfKRsNCJOs = new List<Entity>(_0023_003DzduSfKRsNCJOs);
		List<Point3D> list = new List<Point3D>();
		foreach (devDept.Eyeshot.Control.Labels.Label item in _0023_003DzF5TdZcc_003D)
		{
			if (item.Visible)
			{
				IList<Point3D> collection = item._0023_003DzNOeClJy06sCB(Camera, viewFrame, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
				list.AddRange(collection);
			}
		}
		if (list.Count > 0)
		{
			LinearPath linearPath = new LinearPath(list)
			{
				LayerName = _0023_003Dz0TvaYNo_003D.Layers.GetDefaultLayerName()
			};
			_0023_003DzCJy6o9PkJ45N(_0023_003DzduSfKRsNCJOs, _0023_003DzGhkfdMlbGS2U: false, _0023_003DzhQd3_0024ARpbtAn, _0023_003DztCnZIL5yoxwm: false);
			Point3D projectedMin = Camera.projectedMin;
			Point3D projectedMax = Camera.projectedMax;
			List<Entity> list2 = new List<Entity>();
			list2.Add(linearPath);
			linearPath.RegenMode = regenType.CompileOnly;
			bool visible = _0023_003Dz0TvaYNo_003D.Layers[0].Visible;
			_0023_003Dz0TvaYNo_003D.Layers[0].Visible = true;
			_0023_003DzCJy6o9PkJ45N(list2, _0023_003DzGhkfdMlbGS2U: false, _0023_003DzhQd3_0024ARpbtAn, _0023_003DztCnZIL5yoxwm: false);
			_0023_003Dz0TvaYNo_003D.Layers[0].Visible = visible;
			Point3D maxValue = Point3D.MaxValue;
			Point3D minValue = Point3D.MinValue;
			Utility.UpdateMinMax(null, new Point3D[4] { projectedMin, projectedMax, Camera.projectedMin, Camera.projectedMax }, 4, maxValue, minValue);
			Camera.projectedMin = maxValue;
			Camera.projectedMax = minValue;
			Camera.GetCameraTransform(out var _0023_003DzzRaskB_00243uPOQ, out var _0023_003DzoqgctgRhDmC, out var _0023_003Dz_0024llOZEdbyJnQ);
			Camera.ComputeCenterOfRotation(_0023_003DzCpCzW0s6jJmE: true, _0023_003DzzRaskB_00243uPOQ, _0023_003DzoqgctgRhDmC, _0023_003Dz_0024llOZEdbyJnQ);
			_0023_003DzaXMvZUE_003D(_0023_003DzPG6BDWw_003D);
			_0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
			_0023_003DzduSfKRsNCJOs.Add(linearPath);
		}
	}

	internal bool _0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(int _0023_003DznNNcxy_uo0mZ, int _0023_003DzNdqaEAfJrN_0024r)
	{
		return _0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(_0023_003DznNNcxy_uo0mZ, _0023_003DzNdqaEAfJrN_0024r, 0, 0);
	}

	internal void _0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D)
	{
		_0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D((_0023_003DzkW_0024DzQk_003D.X + _0023_003Dz8ecWqr4_003D.X) / 2, (_0023_003DzkW_0024DzQk_003D.Y + _0023_003Dz8ecWqr4_003D.Y) / 2, Math.Abs(_0023_003Dz8ecWqr4_003D.X - _0023_003DzkW_0024DzQk_003D.X), Math.Abs(_0023_003Dz8ecWqr4_003D.Y - _0023_003DzkW_0024DzQk_003D.Y));
	}

	internal bool _0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(int _0023_003Dz9HqeDSk_003D, int _0023_003DzoruUnG8_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D)
	{
		PlaneEquation[] frustum = Camera.GetFrustum(GetViewFrame(), _0023_003Dz_OlmZyU_003D: false);
		if (frustum == null)
		{
			return false;
		}
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003Dze4TpmVqI26AF, _0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003DzD4HjvLi8HsVr);
		Camera.allModelInsideFrustum = true;
		for (int i = 0; i < boundingBoxCorners.Length; i++)
		{
			if (!Camera.IsInFrustum(boundingBoxCorners[i], frustum))
			{
				Camera.allModelInsideFrustum = false;
				break;
			}
		}
		if (Camera.allModelInsideFrustum && (_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.ViewportCenter || _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.CursorLocation))
		{
			Camera.centerOfRotation = Point3D.MidPoint(_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003Dze4TpmVqI26AF, _0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003DzD4HjvLi8HsVr);
			return true;
		}
		if (Camera.ZBufferData.Dirty && _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter != rotationCenterType.Point)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzHcYFj1p87o4J(this, null);
		}
		return _0023_003Dz6XAKfQicP02A(_0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003Dz9HqeDSk_003D, _0023_003DzoruUnG8_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), _0023_003Dz0TvaYNo_003D.PickBoxSize, _0023_003Dz0TvaYNo_003D.Entities, _0023_003Dz0TvaYNo_003D.Layers);
	}

	public virtual void PanCamera(System.Drawing.Point from, System.Drawing.Point to)
	{
		_0023_003DzOSNsMoG2DfHk(from, to, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void PanCamera(System.Drawing.Point from, System.Drawing.Point to, bool animate)
	{
		_0023_003DzOSNsMoG2DfHk(from, to, animate);
	}

	private void _0023_003DzOSNsMoG2DfHk(System.Drawing.Point _0023_003DzhlCpXt8_003D, System.Drawing.Point _0023_003DzlKY_0024Jbk_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			return;
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzBrC4gBvWiHkA = mouseInputType.Standard;
		double _0023_003DzvxHPuJA_003D = 0.0;
		if (Camera.ProjectionMode == projectionType.Perspective)
		{
			if (Camera.ZBufferData.Dirty)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzHcYFj1p87o4J(this, null);
			}
			bool flag = true;
			if (Camera.ZBufferData.IsInvalidRange)
			{
				flag = Camera.ReadViewportZBufferRange(ViewportToCameraScreen(new System.Drawing.Point(Size.Width / 2, Size.Height / 2)), _0023_003Dzu_0024kNbQmDeTS6: false, _0023_003Dz0TvaYNo_003D.PickBoxSize, _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D(), _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
			}
			if (!flag)
			{
				Camera.ZBufferData.Max = 0.0;
			}
			_0023_003DzvxHPuJA_003D = ((Camera.ZBufferData.Max != 0.0) ? ((Camera.ZBufferData.Min + Camera.ZBufferData.Max) / 2.0) : 1.0);
		}
		System.Drawing.Point _0023_003DzpSZEvLzt7eiw = ViewportToCameraScreen(_0023_003DzhlCpXt8_003D);
		System.Drawing.Point _0023_003Dz1YkB2EvkriNc = ViewportToCameraScreen(_0023_003DzlKY_0024Jbk_003D);
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		Camera.Pan(GetViewFrame(), _0023_003DzpSZEvLzt7eiw, _0023_003Dz1YkB2EvkriNc, _0023_003DzvxHPuJA_003D);
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
		if (_0023_003DzBQC8k3F0wJN4)
		{
			int _0023_003DzZnwLfu4_003D = _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this);
			_0023_003DzDela6KtNzcrF(_0023_003DzZnwLfu4_003D, target, distance, zoomFactor);
		}
		else
		{
			_0023_003Dz11CadYMOXmz_();
		}
	}

	public virtual void RotateCamera(int dx, int dy)
	{
		RotateCamera(dx, dy, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void RotateCamera(int dx, int dy, bool animate)
	{
		Camera.GetFrame(out var _, out var camX, out var _, out var _);
		Vector3D axis = camX;
		double num = dy;
		RotateCamera(axis, (0.0 - num / 2.0) * Rotate.Speed, trackBall: false, animate);
		axis = Vector3D.AxisZ;
		if (_0023_003Dz0TvaYNo_003D._0023_003DzLpjRly40lvq1 == orientationType.UpAxisY)
		{
			axis = Vector3D.AxisY;
		}
		if (ViewCubeIcon?.InitialRotation != null)
		{
			ViewCubeIcon.InitialRotation.ToAxisAngle(out var rotAxis, out var rotAngleInDegrees);
			axis = new devDept.Geometry.Rotation(Utility.DegToRad(rotAngleInDegrees), rotAxis) * axis;
		}
		num = dx;
		RotateCamera(axis, (0.0 - num / 2.0) * Rotate.Speed, trackBall: false, animate);
		_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
	}

	public virtual void OrientCamera(Point3D location, Point3D target)
	{
		if (!_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			Vector3D vector3D = Vector3D.Subtract(location, target);
			double length = vector3D.Length;
			vector3D.Normalize();
			if (_0023_003Dz0TvaYNo_003D.AnimateCamera)
			{
				_0023_003Dz0TvaYNo_003D.AnimateCamera = false;
				Quaternion rotation = _0023_003DzZ_0024IejP0R_0024_Cw.Rotation;
				Point3D target2 = _0023_003DzZ_0024IejP0R_0024_Cw.Target;
				double distance = _0023_003DzZ_0024IejP0R_0024_Cw.Distance;
				double zoomFactor = _0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor;
				SetView(vector3D);
				Quaternion rotation2 = _0023_003DzZ_0024IejP0R_0024_Cw.Rotation;
				double _0023_003DzfAlSRac_003D = length;
				double zoomFactor2 = _0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor;
				_0023_003DzZ_0024IejP0R_0024_Cw.Rotation = rotation;
				_0023_003DzZ_0024IejP0R_0024_Cw.Target = target2;
				_0023_003DzZ_0024IejP0R_0024_Cw.Distance = distance;
				_0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor = zoomFactor;
				_0023_003Dz0TvaYNo_003D.AnimateCamera = true;
				_0023_003Dzng_0024CGOsQn8X8(viewType.Other, _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this), _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, Camera.Rotation, Camera.Target, Camera.Distance, Camera.ZoomFactor, rotation2, target, _0023_003DzfAlSRac_003D, zoomFactor2);
			}
			else
			{
				SetView(vector3D);
				Camera.Target = target;
				Camera.Distance = length;
				_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
				_0023_003Dz11CadYMOXmz_();
			}
			_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
		}
	}

	public virtual void RotateCamera(System.Drawing.Point mousePos1, System.Drawing.Point mousePos2)
	{
		RotateCamera(mousePos1, mousePos2, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void RotateCamera(System.Drawing.Point mousePos1, System.Drawing.Point mousePos2, bool animate)
	{
		System.Drawing.Point _0023_003DzD_hjMo9IBHeB;
		bool num = _0023_003Dz_feN2jsfs6O0(mousePos1, out _0023_003DzD_hjMo9IBHeB);
		System.Drawing.Point _0023_003DzD_hjMo9IBHeB2;
		bool flag = _0023_003Dz_feN2jsfs6O0(mousePos2, out _0023_003DzD_hjMo9IBHeB2);
		if (num && flag)
		{
			_0023_003DzjUZA_0024Ue8Set2(_0023_003DzD_hjMo9IBHeB, _0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D, Rotate.RotationMode);
			_0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003DzD_hjMo9IBHeB2, _0023_003DzD_hjMo9IBHeB.X - _0023_003DzD_hjMo9IBHeB2.X, _0023_003DzD_hjMo9IBHeB.Y - _0023_003DzD_hjMo9IBHeB2.Y, animate);
		}
	}

	internal void _0023_003DzjUZA_0024Ue8Set2(System.Drawing.Point _0023_003DzTYCHRugcseEq, ObjectManipulator _0023_003Dz4nh4XFCNrpsXbtRwdg_003D_003D, rotationType _0023_003DzkBN945tq8dje)
	{
		_0023_003DzDCV7KMgcH_0024l5stDfAA_003D_003D = !_0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(_0023_003DzTYCHRugcseEq.X, _0023_003DzTYCHRugcseEq.Y);
		if (_0023_003DzkBN945tq8dje == rotationType.Trackball)
		{
			_0023_003DzdrGk9pgq7KoJ = _0023_003DzMB83XGDinl92OIp2qQ_003D_003D(_0023_003DzTYCHRugcseEq.X, _0023_003DzTYCHRugcseEq.Y, Rotate.RotationCenter, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
		}
	}

	internal void _0023_003Dzk_0024_0024VvG_00245PP4u(System.Drawing.Point _0023_003DzTYCHRugcseEq, int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (!_0023_003DzDjhJAu3TqX_chipY9w_003D_003D.isRunning)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzBrC4gBvWiHkA = mouseInputType.Standard;
			switch (Rotate.RotationMode)
			{
			case rotationType.Turntable:
				_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D, _0023_003DzBQC8k3F0wJN4);
				break;
			case rotationType.Trackball:
			{
				Vector3D _0023_003DzFcXCpKE_003D = _0023_003DzMB83XGDinl92OIp2qQ_003D_003D(_0023_003DzTYCHRugcseEq.X, _0023_003DzTYCHRugcseEq.Y, Rotate.RotationCenter, _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
				_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003DzdrGk9pgq7KoJ, _0023_003DzFcXCpKE_003D, _0023_003DzBQC8k3F0wJN4);
				_0023_003DzdrGk9pgq7KoJ = _0023_003DzFcXCpKE_003D;
				break;
			}
			}
		}
	}

	public virtual void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall)
	{
		RotateCamera(axis, rotAngleInDegrees, trackBall, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall, bool animate)
	{
		_0023_003DzsRgMRs9HtgvL4vVl1w_003D_003D();
		Camera.RotateByAngle(GetViewFrame(), Rotate.RotationCenter, axis, rotAngleInDegrees, trackBall, animate, out var _0023_003DzZlu3cB4_003D, out var _0023_003DzBKluLAM_003D, out var _0023_003DzxP9oJI8_003D);
		if (animate)
		{
			_0023_003Dzng_0024CGOsQn8X8(viewType.Other, _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this), _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, Camera.Rotation, Camera.Target, Camera.Distance, Camera.ZoomFactor, _0023_003DzBKluLAM_003D, _0023_003DzZlu3cB4_003D, _0023_003DzxP9oJI8_003D, Camera.ZoomFactor);
			return;
		}
		_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
		_0023_003Dz11CadYMOXmz_();
	}

	public virtual void RotateCamera(Vector3D last, Vector3D current)
	{
		_0023_003Dzk_0024_0024VvG_00245PP4u(last, current, _0023_003Dz0TvaYNo_003D.AnimateCamera);
	}

	public virtual void RotateCamera(Vector3D last, Vector3D current, bool animate)
	{
		_0023_003Dzk_0024_0024VvG_00245PP4u(last, current, animate);
	}

	private void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003Dzs8G0wXc_003D, Vector3D _0023_003DzFcXCpKE_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		_0023_003DzsRgMRs9HtgvL4vVl1w_003D_003D();
		double length = (_0023_003DzFcXCpKE_003D - _0023_003Dzs8G0wXc_003D).Length;
		if (length > 0.0)
		{
			Vector3D vector3D = Vector3D.Cross(_0023_003Dzs8G0wXc_003D, _0023_003DzFcXCpKE_003D);
			vector3D.Normalize();
			double _0023_003DzN_00244hHJTN8WML = length * 100.0 * Rotate.Speed;
			Camera.RotateByAngle(GetViewFrame(), Rotate.RotationCenter, vector3D, _0023_003DzN_00244hHJTN8WML, _0023_003DzGkQwE7Vh8NHe: true, _0023_003DzBQC8k3F0wJN4, out var _0023_003DzZlu3cB4_003D, out var _0023_003DzBKluLAM_003D, out var _0023_003DzxP9oJI8_003D);
			_0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003Dz0TvaYNo_003D._0023_003DzyU8zEa9rYhPN(this));
			if (_0023_003DzBQC8k3F0wJN4)
			{
				_0023_003Dzng_0024CGOsQn8X8(viewType.Other, _0023_003Dz0TvaYNo_003D._0023_003DzPEEjwoPxhT6e(this), _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, _0023_003DzZ_0024IejP0R_0024_Cw.Rotation, _0023_003DzZ_0024IejP0R_0024_Cw.Target, _0023_003DzZ_0024IejP0R_0024_Cw.Distance, _0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor, _0023_003DzBKluLAM_003D, _0023_003DzZlu3cB4_003D, _0023_003DzxP9oJI8_003D, _0023_003DzZ_0024IejP0R_0024_Cw.ZoomFactor);
			}
			else
			{
				_0023_003Dz11CadYMOXmz_();
			}
		}
		_0023_003Dz0TvaYNo_003D._0023_003Dz8jvVhZY_003D = actionType.None;
	}

	private bool _0023_003DzsRgMRs9HtgvL4vVl1w_003D_003D()
	{
		if (_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.Point)
		{
			Camera.centerOfRotation = _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.Center;
			return true;
		}
		return false;
	}

	public void SetView(Vector3D direction, bool fit = false, int margin = 10, bool selectedOnly = false)
	{
		SetView(direction, fit, _0023_003Dz0TvaYNo_003D.AnimateCamera, margin, selectedOnly);
	}

	public void SetView(Vector3D direction, bool fit, bool animate, int margin = 10, bool selectedOnly = false)
	{
		_0023_003DzX3oLMGz_0024hdot(direction, null, fit, margin, selectedOnly, animate, null, null);
	}

	public void SetView(Vector3D direction, Vector3D upVector, bool fit = false, int margin = 10, bool selectedOnly = false)
	{
		SetView(direction, upVector, fit, _0023_003Dz0TvaYNo_003D.AnimateCamera, margin, selectedOnly);
	}

	public void SetView(Vector3D direction, Vector3D upVector, bool fit, bool animate, int margin = 10, bool selectedOnly = false, IList<Entity> entList = null)
	{
		Quaternion rotation = Camera.Rotation;
		Point3D target = Camera.Target;
		double distance = Camera.Distance;
		double zoomFactor = Camera.ZoomFactor;
		_0023_003DzX3oLMGz_0024hdot(direction, upVector, fit, margin, selectedOnly, animate, null, entList);
		if (animate)
		{
			Quaternion rotation2 = Camera.Rotation;
			Point3D target2 = Camera.Target;
			double distance2 = Camera.Distance;
			double zoomFactor2 = Camera.ZoomFactor;
			Camera.Rotation = rotation;
			Camera.Distance = distance;
			Camera.Target = target;
			Camera.ZoomFactor = zoomFactor;
			SetView(rotation2, target2, distance2, zoomFactor2);
		}
	}

	private void _0023_003DzX3oLMGz_0024hdot(Vector3D _0023_003DzusPIN8Q_003D, Vector3D _0023_003DzKakUrKWbpelv, bool _0023_003DzWrfLNCo_003D, int _0023_003DzPG6BDWw_003D, bool _0023_003DzGhkfdMlbGS2U, bool _0023_003DzBQC8k3F0wJN4, Transformation _0023_003DziN_0024RcvCUHCHn6TP_ot_00242k_0024Uc8xocyQYdBA_003D_003D, IList<Entity> _0023_003DzY_0024ABPwh9wryC)
	{
		Vector3D vector3D = ((!(_0023_003DzKakUrKWbpelv == null)) ? _0023_003DzKakUrKWbpelv : ((_0023_003Dz0TvaYNo_003D._0023_003Dz0fqXN00AlqdN != orientationType.UpAxisY) ? new Vector3D(0.0, 0.0, 1.0) : new Vector3D(0.0, 1.0, 0.0)));
		if (_0023_003DziN_0024RcvCUHCHn6TP_ot_00242k_0024Uc8xocyQYdBA_003D_003D != null)
		{
			_0023_003DzusPIN8Q_003D = (Vector3D)_0023_003DzusPIN8Q_003D.Clone();
			vector3D = (Vector3D)vector3D.Clone();
			_0023_003DzusPIN8Q_003D.TransformBy(_0023_003DziN_0024RcvCUHCHn6TP_ot_00242k_0024Uc8xocyQYdBA_003D_003D);
			vector3D.TransformBy(_0023_003DziN_0024RcvCUHCHn6TP_ot_00242k_0024Uc8xocyQYdBA_003D_003D);
		}
		Camera.GetFrame(out var _, out var _, out var camY, out var camZ);
		Utility.GetRotationAxisAndAngle(camZ, _0023_003DzusPIN8Q_003D, out var rotAxis, out var angleInDegrees);
		Quaternion quaternion;
		if (rotAxis != null)
		{
			quaternion = new Quaternion(rotAxis, angleInDegrees);
		}
		else if (Vector3D.Dot(_0023_003DzusPIN8Q_003D, camZ) > 0.0)
		{
			quaternion = Quaternion.Identity;
		}
		else
		{
			Plane plane = new Plane(_0023_003DzusPIN8Q_003D);
			rotAxis = plane.AxisX + plane.AxisY;
			rotAxis.Normalize();
			quaternion = new Quaternion(rotAxis, 180.0);
		}
		Quaternion quaternion2 = quaternion * Camera.Rotation;
		quaternion.ToMatrixInverse(out var matrix);
		Transformation transformation = new Transformation(matrix);
		quaternion2 = Camera.Tilt(transformation * camZ, transformation * camY, vector3D) * quaternion2;
		_0023_003DzJga0vcj4OAT_0024(viewType.Other, quaternion2, _0023_003DzWrfLNCo_003D, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4, _0023_003DzGhkfdMlbGS2U, _0023_003Dz0TvaYNo_003D.AnimateCameraDuration, _0023_003Dzk7pNhlbdSzPJ: false, _0023_003DzY_0024ABPwh9wryC);
	}

	public void RotateCamera(System.Drawing.Point mouseLocation)
	{
		_0023_003Dzk_0024_0024VvG_00245PP4u(mouseLocation);
	}

	private void _0023_003Dzk_0024_0024VvG_00245PP4u(System.Drawing.Point _0023_003DzUbpRylvVcgm7)
	{
		_0023_003DzsRgMRs9HtgvL4vVl1w_003D_003D();
		Vector3D vector3D = null;
		SelectedItem itemUnderMouseCursor = _0023_003Dz0TvaYNo_003D.GetItemUnderMouseCursor(_0023_003DzUbpRylvVcgm7, selectableOnly: false);
		if (itemUnderMouseCursor == null)
		{
			return;
		}
		Entity entity = (Entity)itemUnderMouseCursor.Item;
		if (itemUnderMouseCursor.Parents != null && itemUnderMouseCursor.Parents.Count > 0)
		{
			_0023_003Dz0TvaYNo_003D.SetCurrentStack(itemUnderMouseCursor.Parents, updateBoundingBox: false);
		}
		if (entity is Quad)
		{
			vector3D = ((Quad)entity).Normal;
		}
		else if (entity is Triangle)
		{
			vector3D = ((Triangle)entity).Normal;
		}
		else if (entity is IFace)
		{
			IList<HitTriangle> list = null;
			list = _0023_003Dz0TvaYNo_003D._0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D((IFace)entity, _0023_003DzUbpRylvVcgm7);
			if (list.Count > 0)
			{
				HitTriangle hitTriangle = list[0];
				vector3D = GetNormal(entity, hitTriangle.TriangleIndex, hitTriangle.FaceIndex, hitTriangle.ShellOrElementIndex);
			}
		}
		if (vector3D != null)
		{
			Transformation transformation = null;
			if (_0023_003Dz0TvaYNo_003D.CurrentTransformation != null)
			{
				transformation = _0023_003Dz0TvaYNo_003D.CurrentTransformation;
			}
			if (transformation != null)
			{
				transformation = transformation.GetTransformationForNormals();
			}
			_0023_003DzX3oLMGz_0024hdot(vector3D, null, _0023_003DzWrfLNCo_003D: false, Zoom.FitMargin, _0023_003DzGhkfdMlbGS2U: false, _0023_003Dz0TvaYNo_003D.AnimateCamera, transformation, null);
			_0023_003Dz0TvaYNo_003D.Mouse3D._0023_003DzI8QnuD_uT7AD(this);
		}
		for (int i = 0; i < itemUnderMouseCursor.Parents.Count(); i++)
		{
			_0023_003Dz0TvaYNo_003D.SetParentAsCurrent(updateBoundingBox: false);
		}
		_0023_003Dz0TvaYNo_003D._0023_003Dz11CadYMOXmz_(this);
	}

	protected Vector3D GetNormal(Entity ent, int triangle, int faceIndex, int shellIndex)
	{
		Vector3D vector3D = null;
		Point3D[] array = new Point3D[3];
		IFace face = (IFace)ent;
		Mesh[] tessellation = face.GetTessellation();
		if (face is FemMesh)
		{
			FemMesh femMesh = (FemMesh)face;
			Element.Face face2 = femMesh.Elements[shellIndex].Faces[faceIndex];
			array[0] = femMesh.Vertices[face2.Triangles[triangle].V1];
			array[1] = femMesh.Vertices[face2.Triangles[triangle].V2];
			array[2] = femMesh.Vertices[face2.Triangles[triangle].V3];
		}
		else
		{
			Mesh mesh = tessellation[faceIndex];
			array[0] = mesh.Vertices[mesh.Triangles[triangle].V1];
			array[1] = mesh.Vertices[mesh.Triangles[triangle].V2];
			array[2] = mesh.Vertices[mesh.Triangles[triangle].V3];
		}
		if (array[0] != null && array[1] != null && array[2] != null)
		{
			vector3D = Vector3D.Cross(array[0] - array[1], array[0] - array[2]);
			vector3D.Normalize();
		}
		return vector3D;
	}

	private static double[] _0023_003DzxnG3_QzDmKVW(double[,] _0023_003Dz6It9KyA_003D, double[] _0023_003Dz5PxKZP0_003D)
	{
		double[] array = new double[4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i] += _0023_003Dz6It9KyA_003D[i, j] * _0023_003Dz5PxKZP0_003D[j];
			}
		}
		return array;
	}

	internal bool _0023_003Dz6XAKfQicP02A(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz9HqeDSk_003D, int _0023_003DzoruUnG8_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003DzatgWgTMc3NTm, int _0023_003DzHf6SDGPMnIS5wGEGqg_003D_003D, EntityList _0023_003DzHyqiRqo_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ)
	{
		if (_0023_003DzsRgMRs9HtgvL4vVl1w_003D_003D())
		{
			return true;
		}
		bool flag = false;
		double num = 0.0;
		double min = 0.0;
		double max = 1.0;
		_0023_003DzmNZD0Zs_003D.BeginCaptureZBufferOnce();
		if ((_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.CursorLocation || _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.ForcedCursorLocation) && _0023_003Dz7PIPnGI_003D == 0)
		{
			System.Drawing.Point cameraScreenPos = ViewportToCameraScreen(new System.Drawing.Point(_0023_003Dz9HqeDSk_003D, _0023_003DzoruUnG8_003D));
			flag = Camera.ZBufferData.ReadPickBoxZRange(_0023_003DzmNZD0Zs_003D, cameraScreenPos, _0023_003DzHf6SDGPMnIS5wGEGqg_003D_003D, ref min, ref max);
			if (!flag && _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D() > _0023_003DzHf6SDGPMnIS5wGEGqg_003D_003D)
			{
				flag = Camera.ZBufferData.ReadPickBoxZRange(_0023_003DzmNZD0Zs_003D, cameraScreenPos, _0023_003DzD0b_0024eOgBQ_0024rnxDcR1w_003D_003D(), ref min, ref max);
			}
		}
		if (flag)
		{
			num = min;
		}
		else
		{
			if (_0023_003Dz0TvaYNo_003D.CurrentBlockReference != null)
			{
				_0023_003DzmNZD0Zs_003D.EndCaptureZBufferOnce();
				if (_0023_003Dz0TvaYNo_003D.Entities.BoxMin == Point3D.MaxValue)
				{
					_0023_003Dz0TvaYNo_003D.Entities.UpdateBoundingBox();
				}
				Point3D point3D = (_0023_003Dz0TvaYNo_003D.Entities.BoxMin + _0023_003Dz0TvaYNo_003D.Entities.BoxMax) / 2.0;
				point3D.TransformBy(_0023_003Dz0TvaYNo_003D.CurrentTransformation);
				Camera.centerOfRotation = point3D;
				return true;
			}
			if (_0023_003DzZ_0024IejP0R_0024_Cw.allModelInsideFrustum && _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D.RotationCenter == rotationCenterType.ForcedCursorLocation)
			{
				Camera.centerOfRotation = Point3D.MidPoint(_0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003Dze4TpmVqI26AF, _0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003DzD4HjvLi8HsVr);
				return true;
			}
			if (_0023_003Dz7PIPnGI_003D == 0)
			{
				_0023_003Dz9HqeDSk_003D = (int)Math.Ceiling((double)Size.Width / 2.0);
				_0023_003DzoruUnG8_003D = (int)Math.Ceiling((double)Size.Height / 2.0);
				_0023_003Dz7PIPnGI_003D = Size.Width;
				_0023_003DzkQAiKLA_003D = Size.Height;
			}
			System.Drawing.Point cameraScreenPos = ViewportToCameraScreen(new System.Drawing.Point(_0023_003Dz9HqeDSk_003D, _0023_003DzoruUnG8_003D));
			flag = Camera.ZBufferData.ReadZRange(_0023_003DzmNZD0Zs_003D, cameraScreenPos, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, ref min, ref max, optimizeRead: true, _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t(), _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy());
			num = (min + max) / 2.0;
		}
		_0023_003DzmNZD0Zs_003D.EndCaptureZBufferOnce();
		int[] viewFrame = GetViewFrame();
		if (flag && _0023_003Dz0TvaYNo_003D._0023_003DzBrC4gBvWiHkA == mouseInputType.Standard)
		{
			_0023_003Dz_0024kitxvo_003D(viewFrame, _0023_003Dz9HqeDSk_003D, Size.Height - _0023_003DzoruUnG8_003D, num, out var _0023_003Dz7TLLaFU2lIpc, out var _0023_003DzdaxMqsuT8oAm, out var _0023_003DzP0yxPwsLUJDR);
			Point3D centerOfRotation = new Point3D(_0023_003Dz7TLLaFU2lIpc, _0023_003DzdaxMqsuT8oAm, _0023_003DzP0yxPwsLUJDR);
			Camera.centerOfRotation = centerOfRotation;
		}
		return flag;
	}

	internal void _0023_003DzTYCZxck_003D(System.Drawing.Point _0023_003DzkW_0024DzQk_003D, System.Drawing.Point _0023_003Dz8ecWqr4_003D, int _0023_003Dzdb8Ak0QfBH5L, double _0023_003DzaNkZ4Os_003D, double _0023_003Dz_0024QRcKVjquaHq, int _0023_003DzaagFw7oIazzU, int _0023_003DzatgWgTMc3NTm)
	{
		System.Drawing.Point _0023_003Dz6Fveidcfn79x = ViewportToScreen(_0023_003DzkW_0024DzQk_003D);
		System.Drawing.Point _0023_003DzbAIYDunpsR_ = ViewportToScreen(_0023_003Dz8ecWqr4_003D);
		_0023_003Dz6Fveidcfn79x.Y = _0023_003DzatgWgTMc3NTm - _0023_003Dz6Fveidcfn79x.Y;
		_0023_003DzbAIYDunpsR_.Y = _0023_003DzatgWgTMc3NTm - _0023_003DzbAIYDunpsR_.Y;
		Camera.ZoomWindow(GetViewFrame(), Size, _0023_003Dz6Fveidcfn79x, _0023_003DzbAIYDunpsR_, _0023_003Dzdb8Ak0QfBH5L, _0023_003DzaNkZ4Os_003D, _0023_003Dz_0024QRcKVjquaHq);
		_0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003DzatgWgTMc3NTm, _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
	}

	internal void _0023_003DzaXMvZUE_003D(int _0023_003DzPG6BDWw_003D)
	{
		Camera.Fit(Size, _0023_003DzPG6BDWw_003D);
	}

	private bool _0023_003DzDw3dPMSFPic7()
	{
		return _0023_003DzaH0XBqvYSET7CE3VxA_003D_003D._0023_003Dz4XAvJ5aCRLKs(_0023_003Dz42L6chYC_bJg());
	}

	private void _0023_003DzT8Dz_kXi1epc()
	{
		_0023_003DzaH0XBqvYSET7CE3VxA_003D_003D = _0023_003Dz42L6chYC_bJg();
	}

	private static RotateSettings _0023_003Dz42L6chYC_bJg()
	{
		return new RotateSettings();
	}

	private static NavigationSettings _0023_003DzB7g_iJWNK2TU()
	{
		return new NavigationSettings();
	}

	private bool _0023_003DzR7mmnfkxg3B2()
	{
		return _0023_003DzfUoqKzYFbxTn._0023_003Dz4XAvJ5aCRLKs(_0023_003DzB7g_iJWNK2TU());
	}

	private void _0023_003Dz3EJCfwmQGk_0024r()
	{
		_0023_003DzfUoqKzYFbxTn = _0023_003DzB7g_iJWNK2TU();
	}

	private bool _0023_003Dz1YUE9kaauEs4()
	{
		return _0023_003DzwmhQ1QBAhe1s._0023_003Dz4XAvJ5aCRLKs(_0023_003Dz8loivQseZbHR());
	}

	private void _0023_003DzAayHMIGXjKXe()
	{
		_0023_003DzwmhQ1QBAhe1s = _0023_003Dz8loivQseZbHR();
	}

	private static ZoomSettings _0023_003Dz8loivQseZbHR()
	{
		return new ZoomSettings();
	}

	private bool _0023_003DziPKUPI5CE5JW()
	{
		return _0023_003DzeOnNd5rq7WMN._0023_003Dz4XAvJ5aCRLKs(_0023_003DzGTB7AdJZmaiw());
	}

	private void _0023_003Dz9gF9bIOJ0t7e()
	{
		_0023_003DzeOnNd5rq7WMN = _0023_003DzGTB7AdJZmaiw();
	}

	internal static PanSettings _0023_003DzGTB7AdJZmaiw()
	{
		return new PanSettings();
	}

	internal bool _0023_003Dz_feN2jsfs6O0(System.Drawing.Point _0023_003DzDIQP2_0024FoL352, out System.Drawing.Point _0023_003DzD_hjMo9IBHeB)
	{
		_0023_003DzD_hjMo9IBHeB = ScreenToViewport(_0023_003DzDIQP2_0024FoL352);
		return _0023_003DzL1WU50o_003D(_0023_003DzD_hjMo9IBHeB.X, _0023_003DzD_hjMo9IBHeB.Y);
	}

	internal bool _0023_003Dz99_0024gH6eUUxNX(System.Drawing.Point _0023_003DzD_hjMo9IBHeB, out System.Drawing.Point _0023_003DzDIQP2_0024FoL352)
	{
		bool result = _0023_003DzL1WU50o_003D(_0023_003DzD_hjMo9IBHeB.X, _0023_003DzD_hjMo9IBHeB.Y);
		_0023_003DzDIQP2_0024FoL352 = ViewportToScreen(_0023_003DzD_hjMo9IBHeB);
		return result;
	}

	internal void _0023_003Dz_0024J0MwzgL89fc(bool _0023_003Dz5lra25Q_003D)
	{
		if (_0023_003Dz5lra25Q_003D)
		{
			if (_0023_003DzTH_0024xtLSkHa0V == 0)
			{
				_0023_003Dz_tpIHYJrCA7U = Navigation.Mode;
				Navigation.Mode = Camera.navigationType.Examine;
			}
			_0023_003DzTH_0024xtLSkHa0V++;
			return;
		}
		_0023_003DzTH_0024xtLSkHa0V--;
		if (_0023_003DzTH_0024xtLSkHa0V == 0)
		{
			Navigation.Mode = _0023_003Dz_tpIHYJrCA7U;
		}
		if (_0023_003DzTH_0024xtLSkHa0V < 0)
		{
			_0023_003DzTH_0024xtLSkHa0V = 0;
		}
	}
}
