using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ViewCubeConverter))]
public class ViewCubeIcon : UserInterfaceSymbolBase
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<double, float> _0023_003DzRX9VEX6y_00249Gjkp32_g_003D_003D;

		public static Func<Point3D, IEnumerable<float>> _0023_003Dz2EcZC9a7hJCFlDabQQ_003D_003D;

		public static Func<Point3D, IEnumerable<byte>> _0023_003DzfUpRL_NI_0024ZOLOkBl6A_003D_003D;

		internal IEnumerable<float> _0023_003Dz1CJzZXaLgqCEMonF_xcAFHs_003D(Point3D _0023_003DzfOC0YjY_003D)
		{
			return from _0023_003Dz8GBMuoM_003D in _0023_003DzfOC0YjY_003D.ToArray()
				select (float)_0023_003Dz8GBMuoM_003D;
		}

		internal float _0023_003DzzLh2ySi1OMdufXDFkb0l8_00240_003D(double _0023_003Dz8GBMuoM_003D)
		{
			return (float)_0023_003Dz8GBMuoM_003D;
		}

		internal IEnumerable<byte> _0023_003DzAjgdk37DrzMp7_2BiJZIVV0_003D(Point3D _0023_003DzfOC0YjY_003D)
		{
			return new byte[3] { 0, 255, 0 };
		}
	}

	private sealed class _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D
	{
		public Point3D[] _0023_003Dz_KfgXoE_003D;

		internal void _0023_003DzF3kamYAVEe74bYltbA_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, object _0023_003DzwTjaOnc_003D)
		{
			_0023_003DzoC62DbA_003D.DrawLines(_0023_003Dz_KfgXoE_003D);
		}
	}

	internal enum _0023_003DzhnRTKA3LdwJJ
	{

	}

	public delegate void ViewCubeClickEventHandler(object sender, Workspace.ViewChangedEventArgs e);

	public class ViewCubePartEntity : Mesh
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool _0023_003DzSKCV_Nx_0024CMrR;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ViewCubePartEntity _0023_003DzcJIdS_jd32ls;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal _0023_003DzhnRTKA3LdwJJ _0023_003DzGpFd0Ls_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double[] _0023_003DzndAYios_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double[] _0023_003Dzzctk2i7kbyes;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003Dz2BMvif782sEhugxKkw_02ec_003D;

		internal ViewCubePartEntity(string _0023_003DzD8mZsz8_003D, natureType _0023_003DzTsQcYDaMpSSrW05csA_003D_003D, Entity _0023_003DzvvYnXdc5A6im, _0023_003DzhnRTKA3LdwJJ _0023_003DzemvFlrg_003D, bool _0023_003DzqB2xjzR00djX = true)
			: base(_0023_003DzTsQcYDaMpSSrW05csA_003D_003D)
		{
			LayerName = _0023_003DzD8mZsz8_003D;
			_0023_003DzGpFd0Ls_003D = _0023_003DzemvFlrg_003D;
			base.LightWeight = _0023_003DzqB2xjzR00djX;
			_0023_003DzcJIdS_jd32ls = (ViewCubePartEntity)_0023_003DzvvYnXdc5A6im;
		}

		public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
		{
			throw new NotImplementedException();
		}

		public override object Clone()
		{
			throw new NotImplementedException();
		}

		public void SetTransform(Transformation t)
		{
			_0023_003DzndAYios_003D = t.MatrixAsVectorByColumn;
		}

		private void _0023_003DzHjfFC64_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
		{
			_0023_003DzmNZD0Zs_003D.MultMatrixModelView(_0023_003DzndAYios_003D);
		}

		protected internal override void DrawEdges(DrawParams data)
		{
			Pre(data.RenderContext);
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003DzcJIdS_jd32ls.DrawEdges(data);
			}
			else
			{
				base.DrawEdges(data);
			}
			Post(data.RenderContext);
		}

		protected void Post(RenderContextBase renderContext)
		{
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003DzcJIdS_jd32ls._0023_003DzndAYios_003D = _0023_003Dzzctk2i7kbyes;
			}
			else
			{
				renderContext.PopMatrices();
			}
		}

		protected void Pre(RenderContextBase renderContext)
		{
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003Dzzctk2i7kbyes = _0023_003DzcJIdS_jd32ls._0023_003DzndAYios_003D;
				_0023_003DzcJIdS_jd32ls._0023_003DzndAYios_003D = _0023_003DzndAYios_003D;
			}
			else
			{
				renderContext.PushMatrices();
				_0023_003DzHjfFC64_003D(renderContext);
			}
		}

		protected internal override void Render(RenderParams data)
		{
			Pre(data.RenderContext);
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003DzcJIdS_jd32ls.Render(data);
			}
			else
			{
				base.Render(data);
			}
			Post(data.RenderContext);
		}

		protected internal override void Draw(DrawParams data)
		{
			Pre(data.RenderContext);
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003DzcJIdS_jd32ls.Draw(data);
			}
			else
			{
				base.Draw(data);
			}
			Post(data.RenderContext);
		}

		internal override bool AvoidSmallSizeCulling()
		{
			return true;
		}

		internal bool _0023_003DzMnHPwvAiaswMqmHzqg_003D_003D()
		{
			return _0023_003Dz2BMvif782sEhugxKkw_02ec_003D;
		}

		internal void _0023_003DzQtMuyrqqoYVwwpMGMQ_003D_003D(bool _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz2BMvif782sEhugxKkw_02ec_003D = _0023_003DzsLHxXyo_003D;
		}

		protected internal override bool IsVisibleAndInFrustum(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
		{
			return Visible;
		}

		protected internal override void DrawForSelection(DrawForSelectionParams data)
		{
			if (_0023_003DzSKCV_Nx_0024CMrR)
			{
				data.RenderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLess);
			}
			Pre(data.RenderContext);
			if (_0023_003DzcJIdS_jd32ls != null)
			{
				_0023_003DzcJIdS_jd32ls.DrawForSelection(data);
			}
			else
			{
				rasterizerStateType state = rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset;
				if (_0023_003DzMnHPwvAiaswMqmHzqg_003D_003D())
				{
					state = data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_Minus3Minus2);
				}
				base.Draw((DrawParams)data);
				if (_0023_003DzMnHPwvAiaswMqmHzqg_003D_003D())
				{
					data.RenderContext.SetState(state);
				}
			}
			Post(data.RenderContext);
			if (_0023_003DzSKCV_Nx_0024CMrR)
			{
				data.RenderContext.SetState(depthStencilStateType.DepthTestLess);
			}
		}

		public override void Compile(CompileParams data)
		{
			if (_0023_003DzcJIdS_jd32ls == null)
			{
				InitGraphicsData(data.RenderContext);
				base.Compile(data);
			}
			RegenMode = regenType.NotNeeded;
		}

		public override void Dispose()
		{
			if (_0023_003DzcJIdS_jd32ls == null)
			{
				base.Dispose();
			}
		}

		public override void Regen(RegenParams data)
		{
			if (_0023_003DzcJIdS_jd32ls == null)
			{
				base.Regen(data);
			}
			RegenMode = regenType.CompileOnly;
		}

		public viewType GetView()
		{
			return _0023_003DzGpFd0Ls_003D switch
			{
				(_0023_003DzhnRTKA3LdwJJ)5 => viewType.Front, 
				(_0023_003DzhnRTKA3LdwJJ)6 => viewType.Rear, 
				(_0023_003DzhnRTKA3LdwJJ)7 => viewType.Left, 
				(_0023_003DzhnRTKA3LdwJJ)8 => viewType.Right, 
				(_0023_003DzhnRTKA3LdwJJ)9 => viewType.Top, 
				(_0023_003DzhnRTKA3LdwJJ)10 => viewType.Bottom, 
				(_0023_003DzhnRTKA3LdwJJ)11 => viewType.vcFrontFaceBottom, 
				(_0023_003DzhnRTKA3LdwJJ)12 => viewType.vcFrontFaceRight, 
				(_0023_003DzhnRTKA3LdwJJ)13 => viewType.vcFrontFaceTop, 
				(_0023_003DzhnRTKA3LdwJJ)14 => viewType.vcFrontFaceLeft, 
				(_0023_003DzhnRTKA3LdwJJ)15 => viewType.vcRightFaceBottom, 
				(_0023_003DzhnRTKA3LdwJJ)16 => viewType.vcRightFaceRight, 
				(_0023_003DzhnRTKA3LdwJJ)17 => viewType.vcRightFaceTop, 
				(_0023_003DzhnRTKA3LdwJJ)18 => viewType.vcBackFaceBottom, 
				(_0023_003DzhnRTKA3LdwJJ)19 => viewType.vcBackFaceRight, 
				(_0023_003DzhnRTKA3LdwJJ)20 => viewType.vcBackFaceTop, 
				(_0023_003DzhnRTKA3LdwJJ)21 => viewType.vcLeftFaceBottom, 
				(_0023_003DzhnRTKA3LdwJJ)22 => viewType.vcLeftFaceTop, 
				(_0023_003DzhnRTKA3LdwJJ)23 => viewType.vcFrontFaceBottomLeft, 
				(_0023_003DzhnRTKA3LdwJJ)24 => viewType.vcFrontFaceBottomRight, 
				(_0023_003DzhnRTKA3LdwJJ)25 => viewType.vcFrontFaceTopRight, 
				(_0023_003DzhnRTKA3LdwJJ)26 => viewType.vcFrontFaceTopLeft, 
				(_0023_003DzhnRTKA3LdwJJ)27 => viewType.vcBackFaceBottomLeft, 
				(_0023_003DzhnRTKA3LdwJJ)28 => viewType.vcBackFaceBottomRight, 
				(_0023_003DzhnRTKA3LdwJJ)29 => viewType.vcBackFaceTopRight, 
				(_0023_003DzhnRTKA3LdwJJ)30 => viewType.vcBackFaceTopLeft, 
				(_0023_003DzhnRTKA3LdwJJ)0 => viewType.Front, 
				(_0023_003DzhnRTKA3LdwJJ)1 => viewType.Rear, 
				(_0023_003DzhnRTKA3LdwJJ)2 => viewType.Left, 
				(_0023_003DzhnRTKA3LdwJJ)3 => viewType.Right, 
				_ => viewType.Front, 
			};
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzWYCX4lIjnsvyO6G1gQ_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Color _0023_003Dz3MVwIAY_003D = Color.FromArgb(240, 77, 77, 77);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color[] _0023_003DzVJOrahxTBhxs = new Color[11]
	{
		_0023_003DzvtaOXtfiDS67(),
		_0023_003DzuUhPA_m9XuTe(),
		_0023_003DzfUh6VPC_bZHa(),
		_0023_003DzRqCT6qmSZeGN(),
		_0023_003DzvtaOXtfiDS67(),
		_0023_003DzvtaOXtfiDS67(),
		_0023_003DzuUhPA_m9XuTe(),
		_0023_003DzfUh6VPC_bZHa(),
		_0023_003DzRqCT6qmSZeGN(),
		_0023_003DzeBSAOgJFNIX6(),
		_0023_003Dznt6fRDzSS_Uu()
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase[] _0023_003DzqfdQGdahQhTaVYqegA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextureBase _0023_003DzsAhONGYIFGM7z4Wwaw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char _0023_003DzYCs2uYLOIjY6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char _0023_003Dz0E5SXrdFlxsm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char _0023_003Dz5VCW3kEST6C9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char _0023_003DzCP86SpSmd4Hk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzJhnylsHlav_0024n;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzl0rQjB56pvgx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzs6ItxaoSvWSK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzotTLcZKqbFIi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzo3AbU72pphvP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzpd_bKQ2b24bi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpKFzCtY482Oo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003Dz1GGW9_00245jaVamXwl_0024ZCwDx4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003Dz0esUVDERPMddhWaEkMd77zhHFxiL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DzILppBvc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzwR3x56TitafR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzUBk4TZqYfPWF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Mesh> _0023_003Dz5H3rW_0024dVy_0024oE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzt9Q8KTjIVRld;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzjLBWHMet83P3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1ASo95sQ6BrF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzlF34zmbjU9Ww = 1.5f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz_0024Q0mYHi123_00243 = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003Dz1CzoYMjXhxGb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003DzDt5ar2MD0YHQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzIGoimFbYfxcJ = 20;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzBVawHt4YAYHR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace._0023_003DzVFaPvPVltPa6 _0023_003Dzt8x9ym4_003D = new Workspace._0023_003DzVFaPvPVltPa6();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ViewCubeClickEventHandler _0023_003DzNG9r6_c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzDUVBhsOhu44_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzUS40q9lzVpgV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Font _0023_003DzTENXXYw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private coordinateSystemPositionType _0023_003DzJ3YOJQ7DIc_0024gSLiabQ_003D_003D = _0023_003DzPkO7IBwkBx9t();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image[] _0023_003Dzeo4dRkMWhA0i = new Image[6];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Quaternion _0023_003DzQc6Wy7TUe4es = _0023_003DzB2KdYGrGs0O0();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D;

	[Description("If true, animates the camera when changing the orientation.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AnimateCamera
	{
		get
		{
			return _0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D;
		}
		set
		{
			_0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Lighting
	{
		get
		{
			return _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D;
		}
		set
		{
			_0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D = value;
		}
	}

	[Description("When true, fits the view when the view orientation changes.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool FitAfterViewChange
	{
		get
		{
			return _0023_003DzWYCX4lIjnsvyO6G1gQ_003D_003D;
		}
		set
		{
			_0023_003DzWYCX4lIjnsvyO6G1gQ_003D_003D = value;
		}
	}

	[Description("Gets or sets the visibility of the ring under the view cube.")]
	[Category("Ring")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowRing
	{
		get
		{
			return _0023_003DzjLBWHMet83P3;
		}
		set
		{
			_0023_003DzjLBWHMet83P3 = value;
			if (_0023_003Dz5H3rW_0024dVy_0024oE != null)
			{
				_0023_003DzAiaKlpPWYeDS();
			}
		}
	}

	[Description("Gets or sets the visibility of the shadow under the view cube.")]
	[Category("Shadow")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowShadow
	{
		get
		{
			return _0023_003Dz1ASo95sQ6BrF;
		}
		set
		{
			_0023_003Dz1ASo95sQ6BrF = value;
		}
	}

	[Description("Label on the ring for front orientation.")]
	[Category("Ring")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public char FrontRingLabel
	{
		get
		{
			return _0023_003DzYCs2uYLOIjY6;
		}
		set
		{
			_0023_003DzYCs2uYLOIjY6 = value;
		}
	}

	[Description("Label on the ring for front orientation.")]
	[Category("Ring")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public char BackRingLabel
	{
		get
		{
			return _0023_003Dz0E5SXrdFlxsm;
		}
		set
		{
			_0023_003Dz0E5SXrdFlxsm = value;
		}
	}

	[Description("Label on the ring for left orientation.")]
	[Category("Ring")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public char LeftRingLabel
	{
		get
		{
			return _0023_003Dz5VCW3kEST6C9;
		}
		set
		{
			_0023_003Dz5VCW3kEST6C9 = value;
		}
	}

	[Description("Label on the ring for right orientatione.")]
	[Category("Ring")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public char RightRingLabel
	{
		get
		{
			return _0023_003DzCP86SpSmd4Hk;
		}
		set
		{
			_0023_003DzCP86SpSmd4Hk = value;
		}
	}

	[Description("Color of the front face.")]
	[Category("Face - Front")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color FrontColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[5];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[5] = value;
		}
	}

	[Description("Color of the back face.")]
	[Category("Face - Back")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[6];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[6] = value;
		}
	}

	[Description("Color of the left face.")]
	[Category("Face - Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color LeftColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[7];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[7] = value;
		}
	}

	[Description("Color of the right face.")]
	[Category("Face - Right")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color RightColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[8];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[8] = value;
		}
	}

	[Description("Color of the top face.")]
	[Category("Face - Top")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TopColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[9];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[9] = value;
		}
	}

	[Description("Color of the bottom face.")]
	[Category("Face - Bottom")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BottomColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[10];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[10] = value;
		}
	}

	[Description("Color of the front ring label.")]
	[Category("Ring - Front")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color FrontRingColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[0];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[0] = value;
		}
	}

	[Description("Color of the back ring label.")]
	[Category("Ring - Back")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackRingColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[1];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[1] = value;
		}
	}

	[Description("Color of the left ring label.")]
	[Category("Ring - Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color LeftRingColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[2];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[2] = value;
		}
	}

	[Description("Color of the left ring label.")]
	[Category("Ring - Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color RightRingColor
	{
		get
		{
			return _0023_003DzVJOrahxTBhxs[3];
		}
		set
		{
			_0023_003DzVJOrahxTBhxs[3] = value;
		}
	}

	[Description("The highlight color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color HighlightColor
	{
		get
		{
			return _0023_003DzJhnylsHlav_0024n;
		}
		set
		{
			_0023_003DzJhnylsHlav_0024n = value;
		}
	}

	[Description("Text of the front face.")]
	[Category("Face - Front")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string FrontText
	{
		get
		{
			return _0023_003Dzl0rQjB56pvgx;
		}
		set
		{
			_0023_003Dzl0rQjB56pvgx = value;
		}
	}

	[Description("Text of the back face.")]
	[Category("Face - Back")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string BackText
	{
		get
		{
			return _0023_003Dzs6ItxaoSvWSK;
		}
		set
		{
			_0023_003Dzs6ItxaoSvWSK = value;
		}
	}

	[Description("Text of the left face.")]
	[Category("Face - Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string LeftText
	{
		get
		{
			return _0023_003DzotTLcZKqbFIi;
		}
		set
		{
			_0023_003DzotTLcZKqbFIi = value;
		}
	}

	[Description("Text of the right face.")]
	[Category("Face - Right")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string RightText
	{
		get
		{
			return _0023_003Dzo3AbU72pphvP;
		}
		set
		{
			_0023_003Dzo3AbU72pphvP = value;
		}
	}

	[Description("Text of the bottom face.")]
	[Category("Face - Bottom")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string BottomText
	{
		get
		{
			return _0023_003Dzpd_bKQ2b24bi;
		}
		set
		{
			_0023_003Dzpd_bKQ2b24bi = value;
		}
	}

	[Description("Text of the top face.")]
	[Category("Face - Top")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string TopText
	{
		get
		{
			return _0023_003DzpKFzCtY482Oo;
		}
		set
		{
			_0023_003DzpKFzCtY482Oo = value;
		}
	}

	[Description("The color of the texts on the cube faces.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TextColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzDUVBhsOhu44_0024);
		}
		set
		{
			_0023_003DzDUVBhsOhu44_0024 = value;
		}
	}

	[Description("The edge color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color EdgeColor
	{
		get
		{
			return _0023_003DzUS40q9lzVpgV;
		}
		set
		{
			_0023_003DzUS40q9lzVpgV = value;
		}
	}

	[Description("Gets or sets the font of the texts on the cube faces.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Font Font
	{
		get
		{
			return _0023_003DzTENXXYw_003D;
		}
		set
		{
			_0023_003DzTENXXYw_003D = value;
		}
	}

	[Description("Initial rotation.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Quaternion InitialRotation
	{
		get
		{
			return _0023_003DzQc6Wy7TUe4es;
		}
		set
		{
			if (value == null)
			{
				value = _0023_003DzB2KdYGrGs0O0();
			}
			_0023_003DzQc6Wy7TUe4es = value;
			value.ToAxisAngle(out var rotAxis, out var rotAngleInDegrees);
			_0023_003DzCVX3lmbKk25C9btg4A_003D_003D(new Rotation(Utility.DegToRad(rotAngleInDegrees), rotAxis));
			_0023_003DzRrP3HCHc7ZmnCZX_0024XQ_003D_003D(new Rotation(0.0 - Utility.DegToRad(rotAngleInDegrees), rotAxis));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the enabled status.")]
	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public coordinateSystemPositionType Position
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJ3YOJQ7DIc_0024gSLiabQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJ3YOJQ7DIc_0024gSLiabQ_003D_003D = value;
		}
	}

	[Description("Front face image.")]
	[Category("Face - Front")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image FrontImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[0];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[0] = value;
		}
	}

	[Description("Back face image.")]
	[Category("Face - Back")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image BackImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[1];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[1] = value;
		}
	}

	[Description("Left face image.")]
	[Category("Face - Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image LeftImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[2];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[2] = value;
		}
	}

	[Description("Right face image.")]
	[Category("Face - Right")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image RightImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[3];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[3] = value;
		}
	}

	[Description("Top face image.")]
	[Category("Face - Top")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image TopImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[4];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[4] = value;
		}
	}

	[Description("Bottom face image.")]
	[Category("Face - Bottom")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image BottomImage
	{
		get
		{
			return _0023_003Dzeo4dRkMWhA0i[5];
		}
		set
		{
			_0023_003Dzeo4dRkMWhA0i[5] = value;
		}
	}

	[Description("Occurs when the ViewCubeIcon is clicked.")]
	public event ViewCubeClickEventHandler Click
	{
		[CompilerGenerated]
		add
		{
			ViewCubeClickEventHandler viewCubeClickEventHandler = _0023_003DzNG9r6_c_003D;
			ViewCubeClickEventHandler viewCubeClickEventHandler2;
			do
			{
				viewCubeClickEventHandler2 = viewCubeClickEventHandler;
				ViewCubeClickEventHandler value2 = (ViewCubeClickEventHandler)Delegate.Combine(viewCubeClickEventHandler2, value);
				viewCubeClickEventHandler = Interlocked.CompareExchange(ref _0023_003DzNG9r6_c_003D, value2, viewCubeClickEventHandler2);
			}
			while ((object)viewCubeClickEventHandler != viewCubeClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ViewCubeClickEventHandler viewCubeClickEventHandler = _0023_003DzNG9r6_c_003D;
			ViewCubeClickEventHandler viewCubeClickEventHandler2;
			do
			{
				viewCubeClickEventHandler2 = viewCubeClickEventHandler;
				ViewCubeClickEventHandler value2 = (ViewCubeClickEventHandler)Delegate.Remove(viewCubeClickEventHandler2, value);
				viewCubeClickEventHandler = Interlocked.CompareExchange(ref _0023_003DzNG9r6_c_003D, value2, viewCubeClickEventHandler2);
			}
			while ((object)viewCubeClickEventHandler != viewCubeClickEventHandler2);
		}
	}

	public ViewCubeIcon()
		: this(_0023_003DzPkO7IBwkBx9t(), UserInterfaceSymbolBase._0023_003DzndG2TcxO_tb_0024(), _0023_003DztG7oqeEsiGCP(), animateCamera: true, 300, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591103), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591091), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590856), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590877), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590865), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590887), _0023_003Dz4g6Kybvxk2B1hI1R7A_003D_003D(), _0023_003Dz4Db1a_ZpPQIkpQ4edg_003D_003D(), _0023_003DzhJk5rMfvpemuyshtXg_003D_003D(), _0023_003Dz27T9yLMGME1Z8NaUHQ_003D_003D(), _0023_003Dz_0024uBMM0AYjBFX(), _0023_003Dz0UloR3WvSVa2(), _0023_003DzSKb0W00Eht0_0024(), 120, fitAfterViewChange: true, enabled: true)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, int size)
		: this(position, visible, highlightColor, animateCamera, animateCameraDuration, frontText, backText, leftText, rightText, topText, bottomText, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, size, fitAfterViewChange: true, enabled: true)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, int size, bool fitAfterViewChange)
		: this(position, visible, highlightColor, animateCamera, animateCameraDuration, frontText, backText, leftText, rightText, topText, bottomText, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, size, fitAfterViewChange, enabled: true)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, int size, bool fitAfterViewChange, bool enabled)
		: this(position, visible, highlightColor, animateCamera, animateCameraDuration, frontText, backText, leftText, rightText, topText, bottomText, _0023_003DzvtaOXtfiDS67(), _0023_003DzuUhPA_m9XuTe(), _0023_003DzfUh6VPC_bZHa(), _0023_003DzRqCT6qmSZeGN(), _0023_003DzeBSAOgJFNIX6(), _0023_003Dznt6fRDzSS_Uu(), frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, _0023_003DzcL0q2vquhdai(), size, fitAfterViewChange, enabled)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled)
		: this(position, visible, highlightColor, animateCamera, animateCameraDuration, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, null, null, null, null, null, null, lighting: true)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage)
		: this(position, visible, highlightColor, animateCamera, animateCameraDuration, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, null, null, null, null, null, null, lighting: true)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, int animateCameraDuration, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting)
		: this(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting)
	{
		base.CustomViewport = true;
		_0023_003DzshPEPAc_003D(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting, null, _0023_003DzceB6_0024Tf3bbvr());
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting, Quaternion initialRotation)
		: this(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting, initialRotation, _0023_003DzceB6_0024Tf3bbvr())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting)
		: this(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting, _0023_003DzceB6_0024Tf3bbvr())
	{
	}

	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Font font, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting, Quaternion initialRotation, bool showShadow)
	{
		base.CustomViewport = true;
		_0023_003DzshPEPAc_003D(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, font, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting, initialRotation, showShadow);
	}

	public ViewCubeIcon(coordinateSystemPositionType position, bool visible, Color highlightColor, bool animateCamera, string frontText, string backText, string leftText, string rightText, string topText, string bottomText, Color frontColor, Color backColor, Color leftColor, Color rightColor, Color topColor, Color bottomColor, char frontRingLabel, char backRingLabel, char leftRingLabel, char rightRingLabel, bool showRing, Color textColor, Color edgeColor, int size, bool fitAfterViewChange, bool enabled, Image frontImage, Image backImage, Image leftImage, Image rightImage, Image topImage, Image bottomImage, bool lighting, bool showShadow)
		: this(position, visible, highlightColor, animateCamera, frontText, backText, leftText, rightText, topText, bottomText, frontColor, backColor, leftColor, rightColor, topColor, bottomColor, frontRingLabel, backRingLabel, leftRingLabel, rightRingLabel, showRing, null, textColor, edgeColor, size, fitAfterViewChange, enabled, frontImage, backImage, leftImage, rightImage, topImage, bottomImage, lighting, null, showShadow)
	{
	}

	public ViewCubeIcon(ViewCubeIcon other)
		: this(other.Position, other.Visible, other._0023_003DzJhnylsHlav_0024n, other.AnimateCamera, other.FrontText, other.BackText, other.LeftText, other.RightText, other.TopText, other.BottomText, RenderContextUtility.ConvertColor(other.FrontColor), RenderContextUtility.ConvertColor(other.BackColor), RenderContextUtility.ConvertColor(other.LeftColor), RenderContextUtility.ConvertColor(other.RightColor), RenderContextUtility.ConvertColor(other.TopColor), RenderContextUtility.ConvertColor(other.BottomColor), other.FrontRingLabel, other.BackRingLabel, other.LeftRingLabel, other.RightRingLabel, other.ShowRing, other.Font, other._0023_003DzDUVBhsOhu44_0024, other._0023_003DzUS40q9lzVpgV, other._0023_003DzgTjCWc4_003D, other.FitAfterViewChange, other.Enabled, other.FrontImage, other.BackImage, other.LeftImage, other.RightImage, other.TopImage, other.BottomImage, other.Lighting, null, other.ShowShadow)
	{
	}

	public static ViewCubeIcon GetDefaultViewCubeIcon()
	{
		return new ViewCubeIcon();
	}

	private bool _0023_003DzNPEigGjpSk6OE9wN6rw_002477Y_003D()
	{
		return !AnimateCamera;
	}

	internal void _0023_003Dzu7G0f7BUNmf8GKXHSQ_003D_003D()
	{
		AnimateCamera = true;
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting;
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = false;
	}

	private bool _0023_003Dzyjb1i1EPyhf479Jk0A_003D_003D()
	{
		return !FitAfterViewChange;
	}

	internal void _0023_003Dz5n8UNKhfiX6J5zx_mQ_003D_003D()
	{
		FitAfterViewChange = true;
	}

	private bool _0023_003DzYQ_0024kOv1CUnrkJMsgPw_003D_003D()
	{
		return ShowRing != _0023_003Dz_0024uBMM0AYjBFX();
	}

	internal void _0023_003DzLsy24sD2ag98()
	{
		ShowRing = _0023_003Dz_0024uBMM0AYjBFX();
	}

	private bool _0023_003Dz1_0024Qf3S1IkS6GOC410g_003D_003D()
	{
		return ShowShadow != _0023_003DzceB6_0024Tf3bbvr();
	}

	internal void _0023_003Dz_0024AURPCt8MJU_0024()
	{
		ShowShadow = _0023_003DzceB6_0024Tf3bbvr();
	}

	private static Color _0023_003DzvtaOXtfiDS67()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003DzuUhPA_m9XuTe()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003DzfUh6VPC_bZHa()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003DzRqCT6qmSZeGN()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003DzeBSAOgJFNIX6()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003Dznt6fRDzSS_Uu()
	{
		return _0023_003Dz3MVwIAY_003D;
	}

	private static Color _0023_003DzupqzgSgZqYIePoCECw_003D_003D()
	{
		return Color.White;
	}

	private static Color _0023_003DzUtTEhKr302p2HWmAag_003D_003D()
	{
		return Color.White;
	}

	private static Color _0023_003Dz64hyxYJhsoH_0024IDI10Q_003D_003D()
	{
		return Color.White;
	}

	private static Color _0023_003DzFFLRfqacDSqBSB8j4A_003D_003D()
	{
		return Color.White;
	}

	internal static Color _0023_003DztG7oqeEsiGCP()
	{
		return Color.FromArgb(255, ButtonSettings._0023_003DztG7oqeEsiGCP());
	}

	private static char _0023_003DzhJk5rMfvpemuyshtXg_003D_003D()
	{
		return 'W';
	}

	private static char _0023_003Dz27T9yLMGME1Z8NaUHQ_003D_003D()
	{
		return 'E';
	}

	private static char _0023_003Dz4g6Kybvxk2B1hI1R7A_003D_003D()
	{
		return 'S';
	}

	private static char _0023_003Dz4Db1a_ZpPQIkpQ4edg_003D_003D()
	{
		return 'N';
	}

	private static bool _0023_003Dz_0024uBMM0AYjBFX()
	{
		return true;
	}

	private static bool _0023_003DzceB6_0024Tf3bbvr()
	{
		return true;
	}

	internal static coordinateSystemPositionType _0023_003DzPkO7IBwkBx9t()
	{
		return coordinateSystemPositionType.TopRight;
	}

	private Transformation _0023_003DzKOn0HLg_003D(int _0023_003DzDp118Pw_003D, orientationType _0023_003DzKj0sBus_003D)
	{
		Transformation transformation = new Scaling(12.0, 12.0, 12.0);
		Transformation transformation2 = null;
		transformation2 = _0023_003DzDp118Pw_003D switch
		{
			0 => new Translation(0.0, -13.0, -5.0) * new Rotation(Math.PI, Vector3D.AxisX) * new Scaling(6.0, 6.0, 6.0), 
			1 => new Translation(0.0, 13.0, -5.0) * new Rotation(Math.PI, Vector3D.AxisX) * new Scaling(6.0, 6.0, 6.0), 
			2 => new Translation(-13.0, 0.0, -5.0) * new Rotation(Math.PI, Vector3D.AxisX) * new Scaling(6.0, 6.0, 6.0), 
			3 => new Translation(13.0, 0.0, -5.0) * new Rotation(Math.PI, Vector3D.AxisX) * new Scaling(6.0, 6.0, 6.0), 
			4 => new Translation(0.0, 0.0, -5.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisX) * new Scaling(3.0, 3.0, 3.0), 
			5 => new Translation(-6.0, -6.0, -6.0) * transformation, 
			6 => new Translation(6.0, 6.0, -6.0) * new Rotation(Math.PI, Vector3D.AxisZ) * transformation, 
			7 => new Translation(-6.0, 6.0, -6.0) * new Rotation(4.71238898038469, Vector3D.AxisZ) * transformation, 
			8 => new Translation(6.0, -6.0, -6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * transformation, 
			9 => new Translation(-6.0, -6.0, 6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisX) * transformation, 
			10 => new Translation(-6.0, 6.0, -6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisX) * transformation, 
			11 => new Translation(-6.0, -6.0, -6.0) * transformation, 
			12 => new Translation(6.0, -6.0, -6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisY) * transformation, 
			13 => new Translation(6.0, -6.0, 6.0) * new Rotation(Math.PI, Vector3D.AxisY) * transformation, 
			14 => new Translation(-6.0, -6.0, 6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisY) * transformation, 
			15 => new Translation(6.0, -6.0, -6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * transformation, 
			16 => new Translation(6.0, 6.0, -6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * new Rotation(-Math.PI / 2.0, Vector3D.AxisY) * transformation, 
			17 => new Translation(6.0, 6.0, 6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * new Rotation(Math.PI, Vector3D.AxisY) * transformation, 
			18 => new Translation(6.0, 6.0, -6.0) * new Rotation(Math.PI, Vector3D.AxisZ) * transformation, 
			19 => new Translation(-6.0, 6.0, -6.0) * new Rotation(Math.PI, Vector3D.AxisZ) * new Rotation(-Math.PI / 2.0, Vector3D.AxisY) * transformation, 
			20 => new Translation(-6.0, 6.0, 6.0) * new Rotation(Math.PI, Vector3D.AxisZ) * new Rotation(Math.PI, Vector3D.AxisY) * transformation, 
			21 => new Translation(-6.0, 6.0, -6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisZ) * transformation, 
			22 => new Translation(-6.0, -6.0, 6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisZ) * new Rotation(Math.PI, Vector3D.AxisY) * transformation, 
			23 => new Translation(-6.0, -6.0, -6.0) * transformation, 
			24 => new Translation(6.0, -6.0, -6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * transformation, 
			25 => new Translation(6.0, -6.0, 6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisY) * new Rotation(Math.PI / 2.0, Vector3D.AxisZ) * transformation, 
			26 => new Translation(-6.0, -6.0, 6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisY) * transformation, 
			27 => new Translation(6.0, 6.0, -6.0) * new Rotation(Math.PI, Vector3D.AxisZ) * transformation, 
			28 => new Translation(-6.0, 6.0, -6.0) * new Rotation(4.71238898038469, Vector3D.AxisZ) * transformation, 
			29 => new Translation(-6.0, 6.0, 6.0) * new Rotation(Math.PI / 2.0, Vector3D.AxisX) * new Rotation(Math.PI / 2.0, Vector3D.AxisY) * new Rotation(Math.PI, Vector3D.AxisZ) * transformation, 
			30 => new Translation(6.0, 6.0, 6.0) * new Rotation(-Math.PI / 2.0, Vector3D.AxisY) * new Rotation(Math.PI, Vector3D.AxisZ) * transformation, 
			_ => throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590906)), 
		};
		if (_0023_003DzKj0sBus_003D == orientationType.UpAxisY)
		{
			transformation2 = new Rotation(-Math.PI / 2.0, Vector3D.AxisX) * transformation2;
		}
		return transformation2;
	}

	private void _0023_003DzRq4V5fHKrgLGafYRCH3ALvHb6K5s(ViewCubePartEntity _0023_003DztJCl_0024mM_003D, int _0023_003DzDp118Pw_003D, orientationType _0023_003DzKj0sBus_003D)
	{
		_0023_003DztJCl_0024mM_003D.SetTransform(_0023_003DzKOn0HLg_003D(_0023_003DzDp118Pw_003D, _0023_003DzKj0sBus_003D));
	}

	private static Color _0023_003DzSKb0W00Eht0_0024()
	{
		return Color.White;
	}

	private static Font _0023_003Dz0UloR3WvSVa2()
	{
		return null;
	}

	private void _0023_003DzijdGYxPbhvgl(Viewport _0023_003DzYzWi5Yw_003D, CompileParams _0023_003Dzt5jpbHs_003D, RegenParams _0023_003DzdX_UyD6KYF4G)
	{
		_0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D();
		_0023_003DzqfdQGdahQhTaVYqegA_003D_003D = new TextureBase[11];
		for (int i = 0; i < _0023_003DzqfdQGdahQhTaVYqegA_003D_003D.Length; i++)
		{
			_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[i] = _0023_003Dzt5jpbHs_003D.RenderContext.CreateTexture2D();
		}
		bool flag = false;
		if (Font == null)
		{
			if (_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null)
			{
				Font = new Font(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D.Font.FontFamily, 24f, FontStyle.Bold);
			}
			else
			{
				Font = new Font(System.Windows.Forms.Control.DefaultFont.FontFamily, 24f, FontStyle.Bold);
			}
			flag = true;
		}
		Bitmap bitmap = new Bitmap(128, 128);
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
		{
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
			try
			{
				graphics.FillRectangle(solidBrush, 0, 0, 128, 128);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear;
		string[] array = new string[6] { FrontText, BackText, LeftText, RightText, TopText, BottomText };
		for (int j = 0; j < 6; j++)
		{
			Image image = RenderContextUtility.ConvertImage(_0023_003Dzeo4dRkMWhA0i[j]);
			Bitmap bitmap2 = null;
			bool flag2 = false;
			if (image == null)
			{
				bitmap2 = _0023_003DzUWYBtnyxLPMt(array[j], Font, Lighting ? _0023_003DzDUVBhsOhu44_0024 : _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), bitmap);
				flag2 = true;
			}
			else if (image is Bitmap)
			{
				bitmap2 = (Bitmap)image;
			}
			else
			{
				bitmap2 = new Bitmap(image);
				flag2 = true;
			}
			_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[5 + j].Load(_0023_003Dzt5jpbHs_003D.RenderContext, bitmap2, minFunc);
			if (flag2)
			{
				bitmap2.Dispose();
			}
		}
		bitmap.Dispose();
		Font font = new Font(Font.FontFamily, Font.Size * 2.33f / GetScalingLevel().Height, FontStyle.Bold);
		bitmap = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
		string[] array2 = new string[4]
		{
			FrontRingLabel.ToString(),
			BackRingLabel.ToString(),
			LeftRingLabel.ToString(),
			RightRingLabel.ToString()
		};
		Color[] array3;
		if (Lighting)
		{
			array3 = new Color[4]
			{
				RenderContextUtility.ConvertColor(FrontRingColor),
				RenderContextUtility.ConvertColor(BackRingColor),
				RenderContextUtility.ConvertColor(LeftRingColor),
				RenderContextUtility.ConvertColor(RightRingColor)
			};
		}
		else
		{
			Color contrastColorInverted = _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted();
			array3 = new Color[4] { contrastColorInverted, contrastColorInverted, contrastColorInverted, contrastColorInverted };
		}
		for (int k = 0; k < array2.Length; k++)
		{
			Bitmap bitmap3 = _0023_003Dz_0it0s2VoqMp(array2[k], font, array3[k], bitmap, Lighting, _0023_003DzYzWi5Yw_003D);
			_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[k].Load(_0023_003Dzt5jpbHs_003D.RenderContext, bitmap3, textureFilteringFunctionType.Linear);
			bitmap3.Dispose();
		}
		font.Dispose();
		if (flag)
		{
			_0023_003DzTENXXYw_003D.Dispose();
			_0023_003DzTENXXYw_003D = null;
		}
		bitmap.Dispose();
	}

	private Bitmap _0023_003DzUWYBtnyxLPMt(string _0023_003DzgWGS4uo_003D, Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzhpb8QNg_003D, Bitmap _0023_003DzmPRo6QY_003D)
	{
		Bitmap bitmap = (Bitmap)_0023_003DzmPRo6QY_003D.Clone();
		Bitmap bitmap2 = Workspace._0023_003DzRFGA2zTmmjXj(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, _0023_003Dzhpb8QNg_003D, Color.Empty, IntPtr.Zero, RotateFlipType.RotateNoneFlipNone, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		float width = GetScalingLevel().Width;
		float num = (float)bitmap2.Width * 0.8f / width;
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
		{
			float _0023_003DzwBouG0w_003D = num;
			float _0023_003DzQizPEX8_003D = (float)bitmap2.Height / width;
			_0023_003DzMEaSidc_003D(bitmap.Width, bitmap.Height, ref _0023_003DzwBouG0w_003D, ref _0023_003DzQizPEX8_003D);
			float num2 = (float)(bitmap.Width / 2) - _0023_003DzwBouG0w_003D / 2f + 1f;
			float num3 = (float)(bitmap.Height / 2) - _0023_003DzQizPEX8_003D / 2f + 2f;
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			graphics.DrawImage(bitmap2, num2, num3, _0023_003DzwBouG0w_003D, _0023_003DzQizPEX8_003D);
		}
		bitmap2.Dispose();
		return bitmap;
	}

	private static void _0023_003DzMEaSidc_003D(float _0023_003Dz7PIPnGI_003D, float _0023_003DzkQAiKLA_003D, ref float _0023_003DzwBouG0w_003D, ref float _0023_003DzQizPEX8_003D)
	{
		float num = 1f;
		if (_0023_003DzwBouG0w_003D > _0023_003Dz7PIPnGI_003D)
		{
			num = _0023_003Dz7PIPnGI_003D / _0023_003DzwBouG0w_003D;
			_0023_003DzwBouG0w_003D = _0023_003Dz7PIPnGI_003D;
			_0023_003DzQizPEX8_003D *= num;
		}
		if (_0023_003DzQizPEX8_003D > _0023_003DzkQAiKLA_003D)
		{
			num = _0023_003DzkQAiKLA_003D / _0023_003DzQizPEX8_003D;
			_0023_003DzQizPEX8_003D = _0023_003DzkQAiKLA_003D;
			_0023_003DzwBouG0w_003D *= num;
		}
	}

	private static Bitmap _0023_003Dz_0it0s2VoqMp(string _0023_003DzgWGS4uo_003D, Font _0023_003DzYRYfccJxXYvO, Color _0023_003Dzhpb8QNg_003D, Bitmap _0023_003DzmPRo6QY_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		Bitmap bitmap = (Bitmap)_0023_003DzmPRo6QY_003D.Clone();
		Image image = ((!_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D) ? Workspace.GetTextOutlinedImage(_0023_003DzgWGS4uo_003D, _0023_003DzYRYfccJxXYvO, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor(), _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), RotateFlipType.Rotate180FlipX, 4f) : Workspace._0023_003DzRFGA2zTmmjXj(_0023_003DzgWGS4uo_003D, _0023_003DzYRYfccJxXYvO, _0023_003Dzhpb8QNg_003D, Color.Empty, IntPtr.Zero, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0));
		int num = -5;
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
		{
			float _0023_003DzwBouG0w_003D = image.Width;
			float _0023_003DzQizPEX8_003D = image.Height;
			_0023_003DzMEaSidc_003D(bitmap.Width, bitmap.Height, ref _0023_003DzwBouG0w_003D, ref _0023_003DzQizPEX8_003D);
			graphics.DrawImage(image, (float)(bitmap.Width / 2) - _0023_003DzwBouG0w_003D / 2f, (float)(bitmap.Height / 2) - _0023_003DzQizPEX8_003D / 2f + (float)num, _0023_003DzwBouG0w_003D, _0023_003DzQizPEX8_003D);
		}
		image.Dispose();
		return bitmap;
	}

	private bool _0023_003DzcNyaT9wSnyi8YqFRVw_003D_003D()
	{
		return FrontRingLabel != _0023_003Dz4g6Kybvxk2B1hI1R7A_003D_003D();
	}

	internal void _0023_003DzFEc1n6pQhNDZbE3hJw_003D_003D()
	{
		FrontRingLabel = _0023_003Dz4g6Kybvxk2B1hI1R7A_003D_003D();
	}

	private bool _0023_003Dz0w_0024IeiosEA7qenWJsA_003D_003D()
	{
		return BackRingLabel != _0023_003Dz4Db1a_ZpPQIkpQ4edg_003D_003D();
	}

	internal void _0023_003DzyGkNPJOvgNgUBCRhoQ_003D_003D()
	{
		BackRingLabel = _0023_003Dz4Db1a_ZpPQIkpQ4edg_003D_003D();
	}

	private bool _0023_003Dz_0024GzzREs1P__QWAg6rA_003D_003D()
	{
		return LeftRingLabel != _0023_003DzhJk5rMfvpemuyshtXg_003D_003D();
	}

	internal void _0023_003Dz3WL1ok_0024_LhePY0h0_0024Q_003D_003D()
	{
		LeftRingLabel = _0023_003DzhJk5rMfvpemuyshtXg_003D_003D();
	}

	private bool _0023_003DzZIX2Cwx_uQ5EupLNIA_003D_003D()
	{
		return RightRingLabel != _0023_003Dz27T9yLMGME1Z8NaUHQ_003D_003D();
	}

	internal void _0023_003DzgarhEgA55APwR8kV_0024A_003D_003D()
	{
		RightRingLabel = _0023_003Dz27T9yLMGME1Z8NaUHQ_003D_003D();
	}

	private bool _0023_003Dzs3H_PlG_NpTu()
	{
		return FrontColor.ToArgb() != _0023_003DzvtaOXtfiDS67().ToArgb();
	}

	internal void _0023_003DzKVgmAzBMd5mb()
	{
		FrontColor = _0023_003DzvtaOXtfiDS67();
	}

	private bool _0023_003Dz1UxiuEyPOCou()
	{
		return BackColor.ToArgb() != _0023_003DzuUhPA_m9XuTe().ToArgb();
	}

	internal void _0023_003Dz_sK1DKTlZVYU()
	{
		BackColor = _0023_003DzuUhPA_m9XuTe();
	}

	private bool _0023_003DzGrT56pGE7Bsi()
	{
		return LeftColor.ToArgb() != _0023_003DzfUh6VPC_bZHa().ToArgb();
	}

	internal void _0023_003Dzt57_0024MDxQnQsq()
	{
		LeftColor = _0023_003DzfUh6VPC_bZHa();
	}

	private bool _0023_003DzIXLu4SZQwbeF()
	{
		return RightColor.ToArgb() != _0023_003DzRqCT6qmSZeGN().ToArgb();
	}

	internal void _0023_003DzbeCo0Yp_I_hg()
	{
		RightColor = _0023_003DzRqCT6qmSZeGN();
	}

	private bool _0023_003DzFDUkog5fF3U_0024()
	{
		return TopColor.ToArgb() != _0023_003DzeBSAOgJFNIX6().ToArgb();
	}

	internal void _0023_003DztcqN_NjlHx_c()
	{
		TopColor = _0023_003DzeBSAOgJFNIX6();
	}

	private bool _0023_003Dz0xRhvVad5bYl()
	{
		return BottomColor.ToArgb() != _0023_003Dznt6fRDzSS_Uu().ToArgb();
	}

	internal void _0023_003DzEMhqFSkLGhzg()
	{
		BottomColor = _0023_003Dznt6fRDzSS_Uu();
	}

	private bool _0023_003Dze5NgEonaZucM063MSw_003D_003D()
	{
		return FrontRingColor.ToArgb() != _0023_003DzupqzgSgZqYIePoCECw_003D_003D().ToArgb();
	}

	internal void _0023_003DzDe9poXi5qwsH()
	{
		FrontRingColor = _0023_003DzupqzgSgZqYIePoCECw_003D_003D();
	}

	private bool _0023_003Dz5CdCGTQd7OhKT7qb7g_003D_003D()
	{
		return BackRingColor.ToArgb() != _0023_003DzUtTEhKr302p2HWmAag_003D_003D().ToArgb();
	}

	internal void _0023_003DzOQK_0IoDT1fX()
	{
		BackRingColor = _0023_003DzUtTEhKr302p2HWmAag_003D_003D();
	}

	private bool _0023_003Dz4GAGln9dm_00246h1Fg_Tg_003D_003D()
	{
		return LeftRingColor.ToArgb() != _0023_003Dz64hyxYJhsoH_0024IDI10Q_003D_003D().ToArgb();
	}

	internal void _0023_003Dzd40KhJyV2TLF()
	{
		LeftRingColor = _0023_003Dz64hyxYJhsoH_0024IDI10Q_003D_003D();
	}

	private bool _0023_003DzIFpngiSnf04dhZq_HQ_003D_003D()
	{
		return RightRingColor.ToArgb() != _0023_003DzFFLRfqacDSqBSB8j4A_003D_003D().ToArgb();
	}

	internal void _0023_003DziP2vCvRaHtAD()
	{
		RightRingColor = _0023_003DzFFLRfqacDSqBSB8j4A_003D_003D();
	}

	private bool _0023_003DztwUFLIoIz_0024k_0024()
	{
		return HighlightColor.ToArgb() != _0023_003DztG7oqeEsiGCP().ToArgb();
	}

	internal void _0023_003Dz9ioQqruPEIL8()
	{
		HighlightColor = _0023_003DztG7oqeEsiGCP();
	}

	private bool _0023_003DzGmtSoGMlSsxt()
	{
		return FrontText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591103);
	}

	internal void _0023_003Dz5ALdUnb4mOkt()
	{
		FrontText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591103);
	}

	private bool _0023_003DzphhD3osGU4Lq()
	{
		return BackText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591091);
	}

	internal void _0023_003DzmpX_K0qRo9YD()
	{
		BackText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591091);
	}

	private bool _0023_003Dzu0_002419eTrdT7G()
	{
		return LeftText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590856);
	}

	internal void _0023_003DzseoPDw_0024T1Fm9()
	{
		LeftText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590856);
	}

	private bool _0023_003Dzc2_guhe_0024scvb()
	{
		return RightText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590877);
	}

	internal void _0023_003DzhGeDnacdGHw2()
	{
		RightText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590877);
	}

	private bool _0023_003Dzu5fozSCHXJ2M()
	{
		return BottomText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590887);
	}

	internal void _0023_003Dz_7GhhCHnPjsl()
	{
		BottomText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590887);
	}

	private bool _0023_003DzfVeHjMRwbyXT()
	{
		return TopText != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590865);
	}

	internal void _0023_003DzF4kC734EqMjT()
	{
		TopText = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590865);
	}

	private static Color _0023_003DzcL0q2vquhdai()
	{
		return Color.Black;
	}

	public override void Update(IUserInterfaceElement another)
	{
		ViewCubeIcon viewCubeIcon = (ViewCubeIcon)another;
		_0023_003DzshPEPAc_003D(viewCubeIcon.Position, viewCubeIcon.Visible, viewCubeIcon._0023_003DzJhnylsHlav_0024n, viewCubeIcon.AnimateCamera, viewCubeIcon.FrontText, viewCubeIcon.BackText, viewCubeIcon.LeftText, viewCubeIcon.RightText, viewCubeIcon.TopText, viewCubeIcon.BottomText, RenderContextUtility.ConvertColor(viewCubeIcon.FrontColor), RenderContextUtility.ConvertColor(viewCubeIcon.BackColor), RenderContextUtility.ConvertColor(viewCubeIcon.LeftColor), RenderContextUtility.ConvertColor(viewCubeIcon.RightColor), RenderContextUtility.ConvertColor(viewCubeIcon.TopColor), RenderContextUtility.ConvertColor(viewCubeIcon.BottomColor), viewCubeIcon.FrontRingLabel, viewCubeIcon.BackRingLabel, viewCubeIcon.LeftRingLabel, viewCubeIcon.RightRingLabel, viewCubeIcon.ShowRing, viewCubeIcon.Font, RenderContextUtility.ConvertColor(viewCubeIcon.TextColor), RenderContextUtility.ConvertColor(viewCubeIcon.EdgeColor), viewCubeIcon.Size, viewCubeIcon.FitAfterViewChange, viewCubeIcon.Enabled, viewCubeIcon.FrontImage, viewCubeIcon.BackImage, viewCubeIcon.LeftImage, viewCubeIcon.RightImage, viewCubeIcon.TopImage, viewCubeIcon.BottomImage, viewCubeIcon.Lighting, null, viewCubeIcon.ShowShadow);
	}

	private void _0023_003DzshPEPAc_003D(coordinateSystemPositionType _0023_003DzhEjPeMs_003D, bool _0023_003DzbWHNjOg_003D, Color _0023_003DzxJGJhjg_003D, bool _0023_003Dzih7KYPJPPtiZweMh6g_003D_003D, string _0023_003DzCe305Ls_003D, string _0023_003Dzf2zlq_0024c_003D, string _0023_003Dz95n42dc_003D, string _0023_003Dz6aR6y_0024g_003D, string _0023_003Dzd8cUMRg_003D, string _0023_003Dzddc4r7Y_003D, Color _0023_003DzgHSXAeA_003D, Color _0023_003DzakC65tE_003D, Color _0023_003DztFdlmHE_003D, Color _0023_003DzQSnW_0024vc_003D, Color _0023_003DzHMURIcY_003D, Color _0023_003DzZvQhtZQ_003D, char _0023_003DzE_0024LckJ6M5RSW, char _0023_003DzPgsOQ9kxc3V8, char _0023_003DzgPm58oFetOo6, char _0023_003DzQWKMstL0CzMx, bool _0023_003Dz5osd2n7W1t5x, Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzlxpb_Og_003D, Color _0023_003Dz7o8thHE_003D, int _0023_003Dz0ERMHbg_003D, bool _0023_003Dzp4BMaMCoHeOy18qo7Q_003D_003D, bool _0023_003DzQVsx1WI_003D, Image _0023_003DzcgTadHvfPtoJ, Image _0023_003Dzz4tUL_0024ryED6o, Image _0023_003DzeKGpiIyJeLDg, Image _0023_003DzI72ZBO5hAn0u, Image _0023_003Dz_0024GbvBoJEISoU, Image _0023_003Dz7lv5tg8lphG6, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, Quaternion _0023_003DzToxHUmeFWGvf, bool _0023_003DzZa40Y6RGl7ai)
	{
		Position = _0023_003DzhEjPeMs_003D;
		Size = _0023_003Dz0ERMHbg_003D;
		Enabled = _0023_003DzQVsx1WI_003D;
		FrontColor = RenderContextUtility.ConvertColor(_0023_003DzgHSXAeA_003D);
		BackColor = RenderContextUtility.ConvertColor(_0023_003DzakC65tE_003D);
		LeftColor = RenderContextUtility.ConvertColor(_0023_003DztFdlmHE_003D);
		RightColor = RenderContextUtility.ConvertColor(_0023_003DzQSnW_0024vc_003D);
		TopColor = RenderContextUtility.ConvertColor(_0023_003DzHMURIcY_003D);
		BottomColor = RenderContextUtility.ConvertColor(_0023_003DzZvQhtZQ_003D);
		FrontRingLabel = _0023_003DzE_0024LckJ6M5RSW;
		BackRingLabel = _0023_003DzPgsOQ9kxc3V8;
		LeftRingLabel = _0023_003DzgPm58oFetOo6;
		RightRingLabel = _0023_003DzQWKMstL0CzMx;
		base.Visible = _0023_003DzbWHNjOg_003D;
		HighlightColor = RenderContextUtility.ConvertColor(_0023_003DzxJGJhjg_003D);
		AnimateCamera = _0023_003Dzih7KYPJPPtiZweMh6g_003D_003D;
		FrontText = _0023_003DzCe305Ls_003D;
		BackText = _0023_003Dzf2zlq_0024c_003D;
		LeftText = _0023_003Dz95n42dc_003D;
		RightText = _0023_003Dz6aR6y_0024g_003D;
		TopText = _0023_003Dzd8cUMRg_003D;
		BottomText = _0023_003Dzddc4r7Y_003D;
		ShowRing = _0023_003Dz5osd2n7W1t5x;
		Font = _0023_003Dz6FupbG0_003D;
		TextColor = RenderContextUtility.ConvertColor(_0023_003Dzlxpb_Og_003D);
		EdgeColor = RenderContextUtility.ConvertColor(_0023_003Dz7o8thHE_003D);
		FitAfterViewChange = _0023_003Dzp4BMaMCoHeOy18qo7Q_003D_003D;
		FrontImage = _0023_003DzcgTadHvfPtoJ;
		BackImage = _0023_003Dzz4tUL_0024ryED6o;
		LeftImage = _0023_003DzeKGpiIyJeLDg;
		RightImage = _0023_003DzI72ZBO5hAn0u;
		TopImage = _0023_003Dz_0024GbvBoJEISoU;
		BottomImage = _0023_003Dz7lv5tg8lphG6;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		if (_0023_003DzToxHUmeFWGvf != null)
		{
			InitialRotation = _0023_003DzToxHUmeFWGvf;
		}
		ShowShadow = _0023_003DzZa40Y6RGl7ai;
	}

	private bool _0023_003DzR7lfdPM5Ly7X()
	{
		return TextColor.ToArgb() != _0023_003DzSKb0W00Eht0_0024().ToArgb();
	}

	internal void _0023_003DzXYtd_0024aXemTQ_0024()
	{
		TextColor = _0023_003DzSKb0W00Eht0_0024();
	}

	private bool _0023_003DzCHiptfgvMoLc()
	{
		return EdgeColor != _0023_003DzcL0q2vquhdai();
	}

	internal void _0023_003Dz7_f8kaanAepu()
	{
		EdgeColor = _0023_003DzcL0q2vquhdai();
	}

	public override void ScaleForDPI()
	{
		base.ScaleForDPI();
		Font = UtilityEx._0023_003DzowV4NhAf418J(Font, _0023_003DzzihtqSXtvdcF: true, UtilityEx.GetScalingLevel());
	}

	private bool _0023_003DzA2IdS7HzSfL8()
	{
		return Font != null;
	}

	internal void _0023_003DzSUzU94BBHzFv()
	{
		Font = _0023_003Dz0UloR3WvSVa2();
	}

	private static Quaternion _0023_003DzB2KdYGrGs0O0()
	{
		return new Quaternion(0.0, 0.0, 0.0, 1.0);
	}

	private bool _0023_003Dzidnu5yxFkbU4otGn5w_003D_003D()
	{
		return InitialRotation != _0023_003DzB2KdYGrGs0O0();
	}

	internal void _0023_003Dzdz2w9zkEV4QC()
	{
		InitialRotation = _0023_003DzB2KdYGrGs0O0();
	}

	private Transformation _0023_003DzIvXrzRQ62QZDsqSHjw_003D_003D()
	{
		return _0023_003Dz1GGW9_00245jaVamXwl_0024ZCwDx4w_003D;
	}

	private void _0023_003DzCVX3lmbKk25C9btg4A_003D_003D(Transformation _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz1GGW9_00245jaVamXwl_0024ZCwDx4w_003D = _0023_003DzsLHxXyo_003D;
	}

	private Transformation _0023_003Dznyxag0_0024jYazKemw4vQ_003D_003D()
	{
		return _0023_003Dz0esUVDERPMddhWaEkMd77zhHFxiL;
	}

	private void _0023_003DzRrP3HCHc7ZmnCZX_0024XQ_003D_003D(Transformation _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz0esUVDERPMddhWaEkMd77zhHFxiL = _0023_003DzsLHxXyo_003D;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003Dz5H3rW_0024dVy_0024oE != null)
		{
			foreach (Mesh item in _0023_003Dz5H3rW_0024dVy_0024oE)
			{
				item.Dispose();
			}
			_0023_003Dz5H3rW_0024dVy_0024oE = null;
		}
		_0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D();
		_0023_003DzqfdQGdahQhTaVYqegA_003D_003D = null;
		_0023_003DzUBk4TZqYfPWF?.Dispose();
		if (_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D != null)
		{
			_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Dispose();
		}
		if (_0023_003DzILppBvc_003D != null)
		{
			_0023_003DzILppBvc_003D.Dispose();
		}
	}

	private void _0023_003Dzt8j9a78g1ynn(RenderParams _0023_003Dzt5jpbHs_003D, bool _0023_003DzR32FDYEeEjiQ, bool _0023_003DzEcFLE2I_003D)
	{
		if (!_0023_003DzEcFLE2I_003D)
		{
			Color color = Color.FromArgb(60, Color.Black);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
			bool lighting = _0023_003Dzt5jpbHs_003D.RenderContext.SetLighting(enable: false);
			_0023_003Dzt5jpbHs_003D.RenderContext.PushShader();
			_0023_003Dzt5jpbHs_003D.RenderContext.PushBlendState();
			_0023_003Dzt5jpbHs_003D.RenderContext.PushDepthStencilState();
			_0023_003Dzt5jpbHs_003D.RenderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetState(blendStateType.Blend_SrcAlphaOne_DstAlphaOneMinusSrcAlpha);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetShader(shaderType.Texture2DNoLightsModulate);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetTexture(_0023_003DzwR3x56TitafR);
			((IEntityInternal)_0023_003DzILppBvc_003D).Render(_0023_003Dzt5jpbHs_003D);
			_0023_003Dzt5jpbHs_003D.RenderContext.PopDepthStencilState();
			_0023_003Dzt5jpbHs_003D.RenderContext.PopBlendState();
			_0023_003Dzt5jpbHs_003D.RenderContext.PopShader();
			_0023_003Dzt5jpbHs_003D.RenderContext.SetLighting(lighting);
		}
	}

	private void _0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D()
	{
		if (_0023_003DzqfdQGdahQhTaVYqegA_003D_003D != null)
		{
			for (int i = 0; i < _0023_003DzqfdQGdahQhTaVYqegA_003D_003D.Length; i++)
			{
				if (_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[i] != null)
				{
					_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[i].Dispose();
				}
			}
		}
		if (_0023_003DzwR3x56TitafR != null)
		{
			_0023_003DzwR3x56TitafR.Dispose();
		}
	}

	private double _0023_003DzbkMByFEyJWIi(double _0023_003DzSgZxUH0_003D, double _0023_003DzFkEdLw6Gu1_0024c)
	{
		double num = _0023_003DzxhIOvupdVmxl9WWQ8w_003D_003D(_0023_003DzSgZxUH0_003D / _0023_003DzFkEdLw6Gu1_0024c);
		return (1.0 - num) * (1.0 - num);
	}

	private double _0023_003DzxhIOvupdVmxl9WWQ8w_003D_003D(double _0023_003DzSgZxUH0_003D)
	{
		return Math.Max(0.0, Math.Min(1.0, _0023_003DzSgZxUH0_003D));
	}

	private void _0023_003DzGgZXVnbytxjG(CompileParams _0023_003DzCBM7XJK4_5H_0024, int _0023_003Dz0ERMHbg_003D, double _0023_003DzFODDPNc_003D)
	{
		double[,] array = new double[_0023_003Dz0ERMHbg_003D, _0023_003Dz0ERMHbg_003D];
		for (int i = 0; i < _0023_003Dz0ERMHbg_003D; i++)
		{
			for (int j = 0; j < _0023_003Dz0ERMHbg_003D; j++)
			{
				double value = ((double)i - (double)_0023_003Dz0ERMHbg_003D / 2.0) / ((double)_0023_003Dz0ERMHbg_003D / 2.0);
				double value2 = ((double)j - (double)_0023_003Dz0ERMHbg_003D / 2.0) / ((double)_0023_003Dz0ERMHbg_003D / 2.0);
				value = Math.Abs(value);
				value2 = Math.Abs(value2);
				Vector2D vector2D = new Vector3D(Math.Max(value, value2) - (1.0 - _0023_003DzFODDPNc_003D), Math.Max(0.0, Math.Min(value, value2) - (1.0 - _0023_003DzFODDPNc_003D)));
				double val = vector2D.Length * (double)Math.Sign(vector2D.X);
				array[i, j] = Math.Max(0.0, val);
			}
		}
		Bitmap bitmap = new Bitmap(_0023_003Dz0ERMHbg_003D, _0023_003Dz0ERMHbg_003D, PixelFormat.Format32bppArgb);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		byte[] array2 = new byte[bitmap.Width * bitmap.Height * 4];
		int num = 0;
		for (int num2 = _0023_003Dz0ERMHbg_003D - 1; num2 >= 0; num2--)
		{
			for (int k = 0; k < _0023_003Dz0ERMHbg_003D; k++)
			{
				array2[num++] = 0;
				array2[num++] = 0;
				array2[num++] = 0;
				array2[num++] = (byte)(int)(_0023_003DzbkMByFEyJWIi(array[k, num2], _0023_003DzFODDPNc_003D) * 255.0);
			}
		}
		Marshal.Copy(array2, 0, bitmapData.Scan0, array2.Length);
		bitmap.UnlockBits(bitmapData);
		if (_0023_003DzwR3x56TitafR != null)
		{
			_0023_003DzwR3x56TitafR.Dispose();
		}
		_0023_003DzwR3x56TitafR = _0023_003DzCBM7XJK4_5H_0024.RenderContext.CreateTexture2D(bitmap, textureFilteringFunctionType.LinearMipmapLinear);
		bitmap.Dispose();
	}

	internal virtual void _0023_003DztTeP7_0024pDa3AKQJRYIg_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, CompileParams _0023_003DzWdU0336Bq925, RegenParams _0023_003DzdX_UyD6KYF4G, orientationType _0023_003DzKj0sBus_003D)
	{
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D() != null)
		{
			for (int i = 0; i < _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count; i++)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].Dispose();
			}
		}
		string defaultLayerName = GetDefaultLayerName();
		_0023_003DzijdGYxPbhvgl(_0023_003DzYzWi5Yw_003D, _0023_003DzWdU0336Bq925, _0023_003DzdX_UyD6KYF4G);
		Point3D[] vertices = new Point3D[4]
		{
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 1.0),
			new Point3D(0.0, 0.0, 1.0)
		};
		RichTriangle[] array = new RichTriangle[2]
		{
			new RichTriangle(0, 1, 2, 0, 1, 2),
			new RichTriangle(2, 3, 0, 2, 3, 0)
		};
		PointF[] textureCoords = new PointF[4]
		{
			new PointF(0f, 0f),
			new PointF(1f, 0f),
			new PointF(1f, 1f),
			new PointF(0f, 1f)
		};
		_0023_003DzJ68739VSGtxjhT1AxA_003D_003D(new EyeshotDisposableCollection<Mesh>());
		double num = 0.8;
		Point3D[] vertices2 = new Point3D[4]
		{
			new Point3D(0.0 - num, 0.0 - num, 0.0),
			new Point3D(num, 0.0 - num, 0.0),
			new Point3D(num, num, 0.0),
			new Point3D(0.0 - num, num, 0.0)
		};
		RichTriangle[] array2 = new RichTriangle[2]
		{
			new RichTriangle(0, 2, 1, 0, 2, 1),
			new RichTriangle(2, 0, 3, 2, 0, 3)
		};
		PointF[] textureCoords2 = new PointF[4]
		{
			new PointF(0f, 0f),
			new PointF(1f, 0f),
			new PointF(1f, 1f),
			new PointF(0f, 1f)
		};
		ViewCubePartEntity viewCubePartEntity = new ViewCubePartEntity(defaultLayerName, Mesh.natureType.RichPlain, null, (_0023_003DzhnRTKA3LdwJJ)0);
		viewCubePartEntity._0023_003DzQtMuyrqqoYVwwpMGMQ_003D_003D(_0023_003DzsLHxXyo_003D: true);
		viewCubePartEntity.Vertices = vertices2;
		ViewCubePartEntity viewCubePartEntity2 = viewCubePartEntity;
		IndexTriangle[] triangles = array2;
		viewCubePartEntity2.Triangles = triangles;
		viewCubePartEntity.TextureCoords = textureCoords2;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(viewCubePartEntity);
		Entity _0023_003DzvvYnXdc5A6im = viewCubePartEntity;
		for (int j = 1; j < 4; j++)
		{
			viewCubePartEntity = new ViewCubePartEntity(defaultLayerName, Mesh.natureType.RichPlain, _0023_003DzvvYnXdc5A6im, (_0023_003DzhnRTKA3LdwJJ)j);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(viewCubePartEntity);
		}
		Circle outer = new Circle(Plane.ZX, Point2D.Origin, 4.5);
		Circle circle = new Circle(Plane.ZX, Point2D.Origin, 3.5);
		circle.Reverse();
		Mesh mesh = Mesh.CreatePlanar(outer, new ICurve[1] { circle }, 0.05, Mesh.natureType.Plain);
		viewCubePartEntity = new ViewCubePartEntity(defaultLayerName, Mesh.natureType.Plain, null, (_0023_003DzhnRTKA3LdwJJ)4);
		viewCubePartEntity.Vertices = mesh.Vertices;
		viewCubePartEntity.Triangles = mesh.Triangles;
		viewCubePartEntity.Normals = new Vector3D[viewCubePartEntity.Triangles.Length];
		for (int k = 0; k < viewCubePartEntity.Normals.Length; k++)
		{
			viewCubePartEntity.Normals[k] = new Vector3D(1.0, 0.0, 0.0);
		}
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(viewCubePartEntity);
		viewCubePartEntity = new ViewCubePartEntity(defaultLayerName, Mesh.natureType.RichPlain, null, (_0023_003DzhnRTKA3LdwJJ)5);
		viewCubePartEntity.Vertices = vertices;
		ViewCubePartEntity viewCubePartEntity3 = viewCubePartEntity;
		triangles = array;
		viewCubePartEntity3.Triangles = triangles;
		viewCubePartEntity.TextureCoords = textureCoords;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(viewCubePartEntity);
		_0023_003DzvvYnXdc5A6im = viewCubePartEntity;
		for (int l = 6; l < 11; l++)
		{
			viewCubePartEntity = new ViewCubePartEntity(defaultLayerName, Mesh.natureType.RichPlain, _0023_003DzvvYnXdc5A6im, (_0023_003DzhnRTKA3LdwJJ)l);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(viewCubePartEntity);
		}
		for (int m = 0; m < _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count; m++)
		{
			Entity entity = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[m];
			entity.Regen(_0023_003DzdX_UyD6KYF4G);
			entity.visibleAndInFrustum = true;
			entity.Compile(_0023_003DzWdU0336Bq925);
			_0023_003DzRq4V5fHKrgLGafYRCH3ALvHb6K5s((ViewCubePartEntity)entity, m, _0023_003DzKj0sBus_003D);
		}
		if (_0023_003DzILppBvc_003D != null)
		{
			_0023_003DzILppBvc_003D.Dispose();
		}
		_0023_003DzILppBvc_003D = new Mesh(new Point3D[4]
		{
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 0.0),
			new Point3D(1.0, 0.0, 1.0),
			new Point3D(0.0, 0.0, 1.0)
		}, new IndexTriangle[2]
		{
			new RichTriangle(0, 2, 1, 0, 2, 1),
			new RichTriangle(0, 3, 2, 0, 3, 2)
		});
		_0023_003DzILppBvc_003D.TextureCoords = new PointF[4]
		{
			new PointF(0f, 0f),
			new PointF(1f, 0f),
			new PointF(1f, 1f),
			new PointF(0f, 1f)
		};
		Transformation xform = new Scaling(1.6, 1.6, 1.3) * _0023_003DzKOn0HLg_003D(10, _0023_003DzKj0sBus_003D);
		_0023_003DzILppBvc_003D.TransformBy(xform);
		_0023_003DzILppBvc_003D.Regen(_0023_003DzdX_UyD6KYF4G);
		_0023_003DzILppBvc_003D.visibleAndInFrustum = true;
		_0023_003DzILppBvc_003D.Compile(_0023_003DzWdU0336Bq925);
		_0023_003DzGgZXVnbytxjG(_0023_003DzWdU0336Bq925, 128, 0.4);
		_0023_003DzAkoXtcr3b0UH(_0023_003DzWdU0336Bq925, _0023_003DzKj0sBus_003D);
		_0023_003DzxFjofAtqXbH9(_0023_003DzWdU0336Bq925.RenderContext);
		if (_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D != null)
		{
			_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Dispose();
		}
		_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D = Mesh.CreateBox(1.0, 1.0, 1.0);
		_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Scale(12.0);
		_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Translate(-6.0, -6.0, -6.0);
		_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Regen(0.0);
		_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D.Compile(_0023_003DzWdU0336Bq925);
	}

	private void _0023_003DzSJDeNOUaWXnt(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (_0023_003DzUBk4TZqYfPWF == null)
		{
			_0023_003DzUBk4TZqYfPWF = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		}
	}

	private void _0023_003DzxFjofAtqXbH9(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2 = new _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D();
		_0023_003DzSJDeNOUaWXnt(_0023_003DzmNZD0Zs_003D);
		_0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2._0023_003Dz_KfgXoE_003D = new Point3D[24]
		{
			new Point3D(-6.0, -6.0, -6.0),
			new Point3D(-6.0, -6.0, 6.0),
			new Point3D(-6.0, -6.0, -6.0),
			new Point3D(-6.0, 6.0, -6.0),
			new Point3D(-6.0, -6.0, -6.0),
			new Point3D(6.0, -6.0, -6.0),
			new Point3D(-6.0, -6.0, 6.0),
			new Point3D(-6.0, 6.0, 6.0),
			new Point3D(-6.0, -6.0, 6.0),
			new Point3D(6.0, -6.0, 6.0),
			new Point3D(-6.0, 6.0, -6.0),
			new Point3D(-6.0, 6.0, 6.0),
			new Point3D(-6.0, 6.0, -6.0),
			new Point3D(6.0, 6.0, -6.0),
			new Point3D(-6.0, 6.0, 6.0),
			new Point3D(6.0, 6.0, 6.0),
			new Point3D(6.0, -6.0, -6.0),
			new Point3D(6.0, -6.0, 6.0),
			new Point3D(6.0, -6.0, -6.0),
			new Point3D(6.0, 6.0, -6.0),
			new Point3D(6.0, -6.0, 6.0),
			new Point3D(6.0, 6.0, 6.0),
			new Point3D(6.0, 6.0, -6.0),
			new Point3D(6.0, 6.0, 6.0)
		};
		VBOParams myParams = new VBOParams
		{
			vertices = _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2._0023_003Dz_KfgXoE_003D.SelectMany(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz1CJzZXaLgqCEMonF_xcAFHs_003D).ToArray(),
			indices = Enumerable.Range(0, _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2._0023_003Dz_KfgXoE_003D.Length).ToArray(),
			colors = _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2._0023_003Dz_KfgXoE_003D.SelectMany(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzAjgdk37DrzMp7_2BiJZIVV0_003D).ToArray(),
			primitiveMode = primitiveType.LineList
		};
		_0023_003DzmNZD0Zs_003D.Compile(_0023_003DzUBk4TZqYfPWF, _0023_003DzVN8cvlEq9IcYgE_00245oaAtows_003D2._0023_003DzF3kamYAVEe74bYltbA_003D_003D, myParams);
	}

	private void _0023_003DzAkoXtcr3b0UH(CompileParams _0023_003DzWdU0336Bq925, orientationType _0023_003DzKj0sBus_003D)
	{
		int num = -1;
		if (_0023_003Dz5H3rW_0024dVy_0024oE != null)
		{
			for (int i = 0; i < _0023_003Dz5H3rW_0024dVy_0024oE.Count; i++)
			{
				Mesh mesh = _0023_003Dz5H3rW_0024dVy_0024oE[i];
				if (mesh == PickedEntity)
				{
					num = i;
				}
				mesh.Dispose();
			}
		}
		_0023_003Dz5H3rW_0024dVy_0024oE = new List<Mesh>();
		string layerName = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].LayerName;
		ViewCubePartEntity item;
		for (int j = 0; j < 4; j++)
		{
			item = new ViewCubePartEntity(layerName, Mesh.natureType.Plain, _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[j], (_0023_003DzhnRTKA3LdwJJ)j);
			_0023_003Dz5H3rW_0024dVy_0024oE.Add(item);
		}
		item = new ViewCubePartEntity(layerName, Mesh.natureType.Plain, _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4], (_0023_003DzhnRTKA3LdwJJ)4);
		item._0023_003DzSKCV_Nx_0024CMrR = true;
		_0023_003Dz5H3rW_0024dVy_0024oE.Add(item);
		Point3D[] vertices = new Point3D[4]
		{
			new Point3D(0.2, 0.0, 0.2),
			new Point3D(0.8, 0.0, 0.2),
			new Point3D(0.8, 0.0, 0.8),
			new Point3D(0.2, 0.0, 0.8)
		};
		RichTriangle[] array = new RichTriangle[2]
		{
			new RichTriangle(0, 1, 2),
			new RichTriangle(2, 3, 0)
		};
		item = new ViewCubePartEntity(layerName, Mesh.natureType.Plain, null, (_0023_003DzhnRTKA3LdwJJ)5, _0023_003DzqB2xjzR00djX: false);
		item.Vertices = vertices;
		ViewCubePartEntity viewCubePartEntity = item;
		IndexTriangle[] triangles = array;
		viewCubePartEntity.Triangles = triangles;
		_0023_003Dz5H3rW_0024dVy_0024oE.Add(item);
		ViewCubePartEntity _0023_003DzvvYnXdc5A6im = item;
		for (int k = 6; k < 11; k++)
		{
			_0023_003Dz5H3rW_0024dVy_0024oE.Add(new ViewCubePartEntity(layerName, Mesh.natureType.Plain, _0023_003DzvvYnXdc5A6im, (_0023_003DzhnRTKA3LdwJJ)k));
		}
		Point3D[] vertices2 = new Point3D[6]
		{
			new Point3D(0.2, 0.0, 0.0),
			new Point3D(0.8, 0.0, 0.0),
			new Point3D(0.8, 0.0, 0.2),
			new Point3D(0.2, 0.0, 0.2),
			new Point3D(0.2, 0.2, 0.0),
			new Point3D(0.8, 0.2, 0.0)
		};
		IndexTriangle[] triangles2 = new IndexTriangle[4]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(2, 3, 0),
			new IndexTriangle(0, 4, 5),
			new IndexTriangle(0, 5, 1)
		};
		item = new ViewCubePartEntity(layerName, Mesh.natureType.Plain, null, (_0023_003DzhnRTKA3LdwJJ)11, _0023_003DzqB2xjzR00djX: false);
		item.Vertices = vertices2;
		item.Triangles = triangles2;
		_0023_003Dz5H3rW_0024dVy_0024oE.Add(item);
		_0023_003DzvvYnXdc5A6im = item;
		for (int l = 12; l < 23; l++)
		{
			_0023_003Dz5H3rW_0024dVy_0024oE.Add(new ViewCubePartEntity(layerName, Mesh.natureType.Plain, _0023_003DzvvYnXdc5A6im, (_0023_003DzhnRTKA3LdwJJ)l));
		}
		Point3D[] vertices3 = new Point3D[7]
		{
			new Point3D(0.0, 0.0, 0.0),
			new Point3D(0.2, 0.0, 0.0),
			new Point3D(0.2, 0.0, 0.2),
			new Point3D(0.0, 0.0, 0.2),
			new Point3D(0.0, 0.2, 0.0),
			new Point3D(0.2, 0.2, 0.0),
			new Point3D(0.0, 0.2, 0.2)
		};
		IndexTriangle[] triangles3 = new IndexTriangle[6]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(2, 3, 0),
			new IndexTriangle(0, 4, 5),
			new IndexTriangle(0, 5, 1),
			new IndexTriangle(0, 3, 6),
			new IndexTriangle(0, 6, 4)
		};
		item = new ViewCubePartEntity(layerName, Mesh.natureType.Plain, null, (_0023_003DzhnRTKA3LdwJJ)23, _0023_003DzqB2xjzR00djX: false);
		item.Vertices = vertices3;
		item.Triangles = triangles3;
		_0023_003Dz5H3rW_0024dVy_0024oE.Add(item);
		_0023_003DzvvYnXdc5A6im = item;
		for (int m = 24; m < 31; m++)
		{
			_0023_003Dz5H3rW_0024dVy_0024oE.Add(new ViewCubePartEntity(layerName, Mesh.natureType.Plain, _0023_003DzvvYnXdc5A6im, (_0023_003DzhnRTKA3LdwJJ)m));
		}
		for (int n = 0; n < _0023_003Dz5H3rW_0024dVy_0024oE.Count; n++)
		{
			Entity entity = _0023_003Dz5H3rW_0024dVy_0024oE[n];
			entity.Regen(1.0);
			entity.visibleAndInFrustum = true;
			_0023_003DzRq4V5fHKrgLGafYRCH3ALvHb6K5s((ViewCubePartEntity)entity, n, _0023_003DzKj0sBus_003D);
			entity.Compile(_0023_003DzWdU0336Bq925);
		}
		if (num != -1)
		{
			PickedEntity = _0023_003Dz5H3rW_0024dVy_0024oE[num];
			PickedEntity.Selected = true;
		}
		_0023_003DzAiaKlpPWYeDS();
	}

	private void _0023_003DzAiaKlpPWYeDS()
	{
		bool showRing = ShowRing;
		int num = Math.Min(4, _0023_003Dz5H3rW_0024dVy_0024oE.Count - 1);
		for (int i = 0; i <= num; i++)
		{
			_0023_003Dz5H3rW_0024dVy_0024oE[i].visibleAndInFrustum = showRing;
		}
	}

	protected internal override void DrawInternal(DrawSceneParams data)
	{
		if (_0023_003DzEnSwckvY9L5_0024yBIrhA_003D_003D(data, Lighting, _0023_003DzFXbolQ32pxbU: false))
		{
			data.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
			_0023_003Dzt9Q8KTjIVRld = data.IsCurrentViewport();
			_ = data.RenderContext;
			Draw(new RenderParams(data.Viewport, data.Blocks));
			data.RenderContext.SetState(depthStencilStateType.DepthTestLess);
		}
	}

	private void _0023_003Dzl9Ajpi3D2U27(RenderParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dzt5jpbHs_003D.Viewport.Camera.SetViewport(new int[4]
		{
			0,
			0,
			_0023_003Dzt5jpbHs_003D.TextureSize.Width,
			_0023_003Dzt5jpbHs_003D.TextureSize.Height
		});
		if (_0023_003Dzt5jpbHs_003D.RenderContext.HasFBO())
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.ClearColor(Color.FromArgb(0, 255, 255, 255));
			_0023_003Dzt5jpbHs_003D.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
			_0023_003DzlF34zmbjU9Ww = (float)_0023_003Dzt5jpbHs_003D.TextureSize.Width / (float)Size;
		}
		Draw(_0023_003Dzt5jpbHs_003D);
		_0023_003DzlF34zmbjU9Ww = 1f;
	}

	internal void _0023_003DzXf9LYl4_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzoC62DbA_003D.ScaleMatrixModelView(5.0, 5.0, 5.0);
	}

	internal bool _0023_003DzEnSwckvY9L5_0024yBIrhA_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzpIzHYHy1ug2w, bool _0023_003DzFXbolQ32pxbU)
	{
		double dist = 230.0;
		int x = 0;
		int y = 0;
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		GetPosition(viewport, _0023_003DzCBM7XJK4_5H_0024.ViewFrame, out x, out y);
		Vector3D vector3D = new Vector3D();
		if (x < 0)
		{
			vector3D.X = x;
			x = 0;
		}
		if (y < 0)
		{
			vector3D.Y = y;
			y = 0;
		}
		RectangleF zoomRect = _0023_003DzCBM7XJK4_5H_0024.ZoomRect;
		Transformation transformation = null;
		if (!_0023_003DzFXbolQ32pxbU)
		{
			if (!base.LocationAtOrigin)
			{
				if (!_0023_003Dz0EBR_0024Inq_W2W(_0023_003DzCBM7XJK4_5H_0024.ViewFrame, _0023_003DzCBM7XJK4_5H_0024.DrawScale, zoomRect, x, y, out var _0023_003Dz8IZlQW4_003D, out var _0023_003DzM6JZjeA_003D, out var _0023_003Dz0ERMHbg_003D))
				{
					return false;
				}
				viewport.Camera.SetViewport(new int[4] { _0023_003Dz8IZlQW4_003D, _0023_003DzM6JZjeA_003D, _0023_003Dz0ERMHbg_003D, _0023_003Dz0ERMHbg_003D });
				if (viewport._0023_003Dz0TvaYNo_003D.Renderer != rendererType.OpenGL)
				{
					int num = viewport._0023_003Dz0TvaYNo_003D.Size.Height - _0023_003DzM6JZjeA_003D - _0023_003Dz0ERMHbg_003D;
					if (num < 0)
					{
						transformation = new Translation(0.0, -num);
					}
				}
			}
			else
			{
				viewport.Camera.SetViewport(new int[4]
				{
					0,
					0,
					_0023_003DzCBM7XJK4_5H_0024.ViewportSize.Width,
					_0023_003DzCBM7XJK4_5H_0024.ViewportSize.Height
				});
			}
		}
		double[] array = GetProjectionMatrix(_0023_003DzCBM7XJK4_5H_0024, dist);
		if (transformation != null)
		{
			array = Utility.MultMatrixd(transformation.MatrixAsVectorByColumn, array);
		}
		if (vector3D.LengthSquared != 0.0)
		{
			array = Utility.MultMatrixd(new Translation(vector3D).MatrixAsVectorByColumn, array);
		}
		if (!zoomRect.IsEmpty)
		{
			RectangleF rectangle = ((!base.LocationAtOrigin) ? new RectangleF(Math.Max(0f, zoomRect.X - (float)x), Math.Max(0f, zoomRect.Y - (float)y), Size, Size) : new RectangleF((zoomRect.X - _0023_003DzCBM7XJK4_5H_0024.startZoomPt.X) / _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio, (zoomRect.Y - _0023_003DzCBM7XJK4_5H_0024.startZoomPt.Y) / _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio, zoomRect.Width / _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio, zoomRect.Height / _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio));
			array = Camera.ApplyPickMatrix(_0023_003DzCBM7XJK4_5H_0024.RenderContext.ComputePickMatrix(rectangle, new Size(Size, Size), _0023_003DzCBM7XJK4_5H_0024.ViewFrame), array);
		}
		viewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetMatrices(null, null);
		if (_0023_003DzpIzHYHy1ug2w)
		{
			SetupLights(viewport, viewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, 1f);
		}
		Transformation transformation2 = new Transformation(GetModelViewMatrix(viewport.Camera, dist), byRow: false);
		transformation2 *= (Transformation)new Scaling(5.0);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetMatrices(array, transformation2.MatrixAsVectorByColumn);
		return true;
	}

	private bool _0023_003Dz0EBR_0024Inq_W2W(int[] _0023_003DzBppTnBIbeUl7, float _0023_003DzCzsr4CTVr_Ea, RectangleF _0023_003DzF7kGEgqMZE2_, int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, out int _0023_003Dz8IZlQW4_003D, out int _0023_003DzM6JZjeA_003D, out int _0023_003Dz0ERMHbg_003D)
	{
		if (!_0023_003DzF7kGEgqMZE2_.IsEmpty && (_0023_003DzF7kGEgqMZE2_.Right < (float)_0023_003Dz8GBMuoM_003D || _0023_003DzF7kGEgqMZE2_.Bottom < (float)_0023_003DzJU0R6e0_003D))
		{
			_0023_003Dz8IZlQW4_003D = 0;
			_0023_003DzM6JZjeA_003D = 0;
			_0023_003Dz0ERMHbg_003D = 0;
			return false;
		}
		_0023_003Dz8IZlQW4_003D = (int)(((float)(_0023_003DzBppTnBIbeUl7[0] + _0023_003Dz8GBMuoM_003D) - _0023_003DzF7kGEgqMZE2_.X) * _0023_003DzCzsr4CTVr_Ea);
		_0023_003DzM6JZjeA_003D = (int)(((float)(_0023_003DzBppTnBIbeUl7[1] + _0023_003DzJU0R6e0_003D) - _0023_003DzF7kGEgqMZE2_.Y) * _0023_003DzCzsr4CTVr_Ea);
		if (_0023_003Dz8IZlQW4_003D < 0)
		{
			_0023_003Dz8IZlQW4_003D = 0;
		}
		if (_0023_003DzM6JZjeA_003D < 0)
		{
			_0023_003DzM6JZjeA_003D = 0;
		}
		_0023_003Dz0ERMHbg_003D = (int)((float)Size * _0023_003DzCzsr4CTVr_Ea);
		return true;
	}

	protected virtual double[] GetProjectionMatrix(DrawSceneParams data, double dist)
	{
		return data.Viewport.Camera.myPerspective(data.RenderContext, 45.0, 1.0, dist - 150.0, dist + 150.0);
	}

	protected override double[] GetModelViewMatrix(Camera camera, double dist)
	{
		Transformation transformation = new Transformation(camera.GetModelViewCsIcon(dist), byRow: false);
		if (InitialRotation == _0023_003DzB2KdYGrGs0O0())
		{
			return transformation.MatrixAsVectorByColumn;
		}
		transformation *= _0023_003Dznyxag0_0024jYazKemw4vQ_003D_003D();
		return transformation.MatrixAsVectorByColumn;
	}

	protected virtual void GetPosition(Viewport viewport, int[] viewFrame, out int x, out int y)
	{
		x = (y = 0);
		int num = (int)(ShowRing ? ((double)Size) : ((double)Size / 1.2));
		int num2 = viewport.Size.Height - viewport._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D().Height;
		int num3 = (int)(ShowRing ? 0.0 : ((double)(-Size) / 6.0)) + num2;
		int num4 = 0;
		if (ParentViewport != null)
		{
			num4 = ((ParentViewport.ToolBar == null) ? (ParentViewport._0023_003Dz0TvaYNo_003D.ButtonStyle.Size + ParentViewport._0023_003Dz0TvaYNo_003D.ButtonStyle.Gap) : (ParentViewport._0023_003Dz0TvaYNo_003D.ButtonStyle.Size + ParentViewport.ToolBar.Margin + ParentViewport.ToolBar.Padding * 2));
		}
		switch (Position)
		{
		case coordinateSystemPositionType.BottomRight:
			x = viewFrame[2] - num;
			y = num3;
			break;
		case coordinateSystemPositionType.BottomLeft:
			x = num3;
			y = num3;
			break;
		case coordinateSystemPositionType.TopLeft:
			x = num3;
			y = viewFrame[3] - num;
			break;
		case coordinateSystemPositionType.TopRight:
		{
			x = viewFrame[2] - num;
			y = viewFrame[3] - num;
			bool flag = false;
			bool flag2 = false;
			ToolBar[] toolBars = viewport.ToolBars;
			foreach (ToolBar toolBar in toolBars)
			{
				if (!flag2 && toolBar.Position == ToolBar.positionType.HorizontalTopRight)
				{
					y -= num4;
					flag2 = true;
				}
				if (!flag && toolBar.Position == ToolBar.positionType.VerticalTopRight)
				{
					x -= num4;
					flag = true;
				}
				if (flag && flag2)
				{
					break;
				}
			}
			break;
		}
		}
	}

	private void _0023_003Dz4dLtHO4iZhtf_E1333jN_0024hQ_003D(RenderParams _0023_003Dzt5jpbHs_003D)
	{
		RenderContextBase renderContext = _0023_003Dzt5jpbHs_003D.RenderContext;
		renderContext.PushRasterizerState();
		renderContext.PushDepthStencilState();
		renderContext.PushBlendState();
		renderContext.SetState(blendStateType.ColorMaskOff);
		renderContext.SetState(depthStencilStateType.DepthTestAlways);
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_Plus2Plus2);
		for (int i = 5; i < 11; i++)
		{
			((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i]).Render(_0023_003Dzt5jpbHs_003D);
		}
		renderContext.PopRasterizerState();
		renderContext.PopDepthStencilState();
		renderContext.PopBlendState();
	}

	public override void Draw(RenderParams data)
	{
		RenderContextBase renderContext = data.RenderContext;
		renderContext.SetLighting(Lighting);
		Viewport viewport = (Viewport)data.Viewport;
		BackgroundSettings background = viewport.Background;
		int num = (Lighting ? 127 : ((int)(255.0 * background.ColorThemeTransparency)));
		int num2 = 255;
		bool flag = _0023_003DzMZW4OwhqWTGs();
		if (flag)
		{
			num /= 2;
			num2 /= 2;
		}
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		ObjectManipulator objectManipulator = viewport._0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D;
		PreDrawOnDepthBuffer(renderContext);
		if (objectManipulator.Dragging)
		{
			for (int i = 5; i < 11; i++)
			{
				((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i]).Render(data);
			}
		}
		renderContext.SetLineSize(_0023_003Dz_0024Q0mYHi123_00243);
		data.RenderContext.Draw(_0023_003DzUBk4TZqYfPWF);
		PostDrawOnDepthBuffer(renderContext);
		renderContext.InitializeCurrentWireColor();
		if (!Lighting)
		{
			renderContext.SetColorWireframe(Color.FromArgb(num2, background.GetContrastColorInverted()));
		}
		else
		{
			renderContext.SetColorWireframe(Color.FromArgb(num2, RenderContextUtility.ConvertColor(EdgeColor)));
		}
		renderContext.SetState(blendStateType.Blend_SrcAlphaOne_DstAlphaOneMinusSrcAlpha);
		if (!Lighting)
		{
			double[] a = renderContext.CurrentModelViewMatrix();
			double[] b = renderContext.CurrentProjectionMatrix();
			double[] modelViewProj = Utility.MultMatrixd(a, b);
			DrawSilhouettesParams data2 = new DrawSilhouettesParams(ParentViewport, ParentViewport._0023_003Dz0TvaYNo_003D.Blocks, projectionType.Orthographic, modelViewProj, data.ScreenToWorld)
			{
				Transformation = null
			};
			renderContext.SetLineSize(_0023_003DzlF34zmbjU9Ww);
			data.RenderContext.UpdateConstantBufferPerFrame();
			((IEntityInternal)_0023_003Dz_vAWvZalaoVkTvFjBg_003D_003D).DrawSilhouettes(data2);
		}
		renderContext.SetLineSize(_0023_003Dz_0024Q0mYHi123_00243);
		renderContext.Draw(_0023_003DzUBk4TZqYfPWF);
		if (!Lighting)
		{
			renderContext.SetShader(shaderType.Texture2DNoLightsDecal, data.ShaderParams);
		}
		else
		{
			renderContext.SetLighting(enable: true);
			if (data.ShaderParams != null)
			{
				data.ShaderParams.Lighting = true;
			}
			renderContext.SetShader(shaderType.Texture2DDecal, data.ShaderParams);
			renderContext.SetMaterial(Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 12, 12, 12), Color.FromArgb(255, 0, 0, 0), 0.25f);
		}
		ShaderParameters data3 = viewport._0023_003Dzms3vFmj75BNW();
		renderContext.UpdateConstantBufferPerFrame(data3);
		Color _0023_003Dzhpb8QNg_003D = (Lighting ? Color.Empty : background.GetContrastColor());
		for (int j = 5; j < 11; j++)
		{
			_0023_003DzqyiJkGs3eOf8(data, j, _0023_003DzR32FDYEeEjiQ: false, flag, _0023_003Dzhpb8QNg_003D);
		}
		if (ShowShadow)
		{
			_0023_003Dzt8j9a78g1ynn(data, _0023_003DzR32FDYEeEjiQ: false, flag);
		}
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
		ViewCubePartEntity viewCubePartEntity = (_0023_003Dzt9Q8KTjIVRld ? ((ViewCubePartEntity)PickedEntity) : null);
		renderContext.CloseTexture();
		renderContext.SetShader(shaderType.NoLights);
		if (viewCubePartEntity != null && viewCubePartEntity._0023_003DzGpFd0Ls_003D >= (_0023_003DzhnRTKA3LdwJJ)5 && viewCubePartEntity._0023_003DzGpFd0Ls_003D < (_0023_003DzhnRTKA3LdwJJ)31)
		{
			Entity pickedEntity = PickedEntity;
			if (pickedEntity.Selected)
			{
				_0023_003Dz4dLtHO4iZhtf_E1333jN_0024hQ_003D(data);
				renderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
				renderContext.SetLighting(enable: false);
				renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				renderContext.SetColorWireframe(_0023_003DzJhnylsHlav_0024n);
				renderContext.SetLineSize(_0023_003Dz_0024Q0mYHi123_00243, setShader: false);
				((IEntityInternal)pickedEntity).DrawEdges((DrawParams)data);
				if (!Lighting && background.GetContrastColor().ToArgb() == Color.Black.ToArgb())
				{
					renderContext.SetState(blendStateType.Blend_Mask_RGB);
				}
				else
				{
					renderContext.SetState(blendStateType.Blend_DstZero_Mask_RGB);
				}
				renderContext.SetColorWireframe(Color.FromArgb(127, _0023_003DzJhnylsHlav_0024n));
				renderContext.SetShader(shaderType.NoLights);
				((IEntityInternal)pickedEntity).Render(data);
				renderContext.SetState(blendStateType.NoBlend);
			}
			renderContext.ColorMaterialMode = colorMaterialType.Disabled;
		}
		if (ShowRing)
		{
			renderContext.SetState(blendStateType.Blend_SrcAlphaOne_DstAlphaOneMinusSrcAlpha);
			renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
			renderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
			renderContext.SetLighting(enable: false);
			renderContext.CloseTexture();
			renderContext.SetShader(shaderType.NoLights);
			if (viewCubePartEntity != null && viewCubePartEntity._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)4)
			{
				renderContext.SetColorWireframe(Color.FromArgb(127, _0023_003DzJhnylsHlav_0024n));
			}
			else if (Lighting)
			{
				renderContext.SetColorWireframe(Color.FromArgb(num, 127, 127, 127));
			}
			else
			{
				renderContext.SetColorWireframe(Color.FromArgb(num, background.GetContrastColor()));
			}
			if (objectManipulator.Dragging)
			{
				PreDrawOnDepthBuffer(data.RenderContext);
				((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4]).Render(data);
				for (int k = 5; k < 11; k++)
				{
					((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[k]).Render(data);
				}
				PostDrawOnDepthBuffer(data.RenderContext);
			}
			((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4]).Render(data);
			renderContext.SetLighting(Lighting);
			renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			renderContext.SetShader(Lighting ? shaderType.Texture2D : shaderType.Texture2DNoLightsModulate);
			if (!Lighting)
			{
				renderContext.SetColorWireframe(Color.FromArgb(num, Color.White));
			}
			renderContext.UpdateConstantBufferPerFrame(data3);
			bool flag2 = false;
			renderContext.SetState(blendStateType.Blend);
			if (objectManipulator.Dragging)
			{
				PreDrawOnDepthBuffer(data.RenderContext);
				for (int l = 0; l < 4; l++)
				{
					((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[l]).Render(data);
				}
				for (int m = 5; m < 11; m++)
				{
					((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[m]).Render(data);
				}
				PostDrawOnDepthBuffer(data.RenderContext);
			}
			for (int n = 0; n < 4; n++)
			{
				bool _0023_003DzR32FDYEeEjiQ = false;
				if (viewCubePartEntity != null && viewCubePartEntity._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)n)
				{
					if (!Lighting)
					{
						renderContext.SetShader(shaderType.Texture2DNoLightsModulate);
						flag2 = true;
					}
					_0023_003DzR32FDYEeEjiQ = true;
				}
				_0023_003DzqyiJkGs3eOf8(data, n, _0023_003DzR32FDYEeEjiQ, flag, Color.White);
				if (flag2)
				{
					flag2 = false;
					renderContext.SetShader(Lighting ? shaderType.Texture2D : shaderType.Texture2DNoLights);
				}
			}
		}
		renderContext.SetState(blendStateType.NoBlend);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		renderContext.CloseTexture(force: true);
	}

	private bool _0023_003DzcY1SwfFv_M8s()
	{
		return !Enabled;
	}

	internal void _0023_003DzNSayyTKTSOmA()
	{
		Enabled = true;
	}

	private bool _0023_003DzMZW4OwhqWTGs()
	{
		if (Enabled)
		{
			if (ParentViewport != null)
			{
				if (!ParentViewport._0023_003Dz0TvaYNo_003D._0023_003Dz1h04P8XycEellhFbXA_003D_003D())
				{
					return !ParentViewport.Rotate.Enabled;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private void _0023_003DzqyiJkGs3eOf8(RenderParams _0023_003Dzt5jpbHs_003D, int _0023_003DzDp118Pw_003D, bool _0023_003DzR32FDYEeEjiQ, bool _0023_003DzEcFLE2I_003D, Color _0023_003Dzhpb8QNg_003D)
	{
		_0023_003Dzt5jpbHs_003D.RenderContext.SetTexture(_0023_003DzqfdQGdahQhTaVYqegA_003D_003D[_0023_003DzDp118Pw_003D]);
		Color color = ((!Lighting) ? (_0023_003DzR32FDYEeEjiQ ? _0023_003DzJhnylsHlav_0024n : _0023_003Dzhpb8QNg_003D) : (_0023_003DzR32FDYEeEjiQ ? _0023_003DzJhnylsHlav_0024n : _0023_003DzVJOrahxTBhxs[_0023_003DzDp118Pw_003D]));
		if (_0023_003DzEcFLE2I_003D)
		{
			color = Color.FromArgb(color.A / 2, color);
		}
		if (Lighting)
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAndBackDiffuse(color);
		}
		else
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
		}
		((IEntityInternal)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[_0023_003DzDp118Pw_003D]).Render(_0023_003Dzt5jpbHs_003D);
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		int[] viewFrame = viewport.GetViewFrame();
		GetPosition(viewport, viewFrame, out var x, out var y);
		System.Drawing.Point point = viewport._0023_003Dz_0WcPl0XuxCA(new System.Drawing.Point(x, y));
		return new Rectangle(point.X, point.Y - Size, Size, Size);
	}

	internal bool _0023_003Dzc3vkuqr_ddi7(Viewport _0023_003DzYzWi5Yw_003D, int[] _0023_003DzBppTnBIbeUl7, System.Drawing.Point _0023_003DzxGL6Kng_003D)
	{
		if (!base.Visible)
		{
			return false;
		}
		GetPosition(_0023_003DzYzWi5Yw_003D, _0023_003DzBppTnBIbeUl7, out var x, out var y);
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D._0023_003Dz_0WcPl0XuxCA(new System.Drawing.Point(x, y + Size));
		if (_0023_003DzxGL6Kng_003D.X >= point.X && _0023_003DzxGL6Kng_003D.X <= point.X + Size && _0023_003DzxGL6Kng_003D.Y >= point.Y)
		{
			return _0023_003DzxGL6Kng_003D.Y <= point.Y + Size;
		}
		return false;
	}

	public bool Contains(System.Drawing.Point mousePos)
	{
		if (base.Visible)
		{
			Viewport parentViewport = ParentViewport;
			int[] viewFrame = parentViewport.GetViewFrame();
			GetPosition(parentViewport, viewFrame, out var x, out var y);
			if (_0023_003Dz0EBR_0024Inq_W2W(viewFrame, 1f, RectangleF.Empty, x, y, out var _0023_003Dz8IZlQW4_003D, out var _0023_003DzM6JZjeA_003D, out var _0023_003Dz0ERMHbg_003D))
			{
				return new Rectangle(_0023_003Dz8IZlQW4_003D, _0023_003DzM6JZjeA_003D, _0023_003Dz0ERMHbg_003D, _0023_003Dz0ERMHbg_003D).Contains(new System.Drawing.Point(mousePos.X, viewFrame[3] - mousePos.Y));
			}
		}
		return false;
	}

	protected internal override bool OnMouseDown(MouseEventArgs e, Viewport viewport)
	{
		if (e.Button != MouseButtons.Left || viewport._0023_003Dz0TvaYNo_003D._0023_003DzhNfdoTKp7Vp4r6IhAdfMNj6_00248vBW())
		{
			return false;
		}
		if (!_0023_003Dzc3vkuqr_ddi7(viewport, viewport.GetViewFrame(), e.Location))
		{
			return false;
		}
		base.OnMouseDown(e, viewport);
		MouseEventArgs _0023_003Dz1SmHC4c_003D = e;
		Workspace._0023_003Dz_feN2jsfs6O0(viewport, ref _0023_003Dz1SmHC4c_003D);
		if (PickedEntity != null)
		{
			viewport._0023_003Dz0TvaYNo_003D._0023_003DzNEH_0024_00242U_003D(_0023_003Dz1SmHC4c_003D, viewport, rotationType.Turntable);
			Dragging = true;
			if (((ViewCubePartEntity)PickedEntity)._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)4 || ((ViewCubePartEntity)PickedEntity)._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)0 || ((ViewCubePartEntity)PickedEntity)._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)1 || ((ViewCubePartEntity)PickedEntity)._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)2 || ((ViewCubePartEntity)PickedEntity)._0023_003DzGpFd0Ls_003D == (_0023_003DzhnRTKA3LdwJJ)3)
			{
				_0023_003DzBVawHt4YAYHR = true;
			}
		}
		_0023_003Dz1CzoYMjXhxGb = e.Location;
		_0023_003DzDt5ar2MD0YHQ = System.Drawing.Point.Empty;
		return PickedEntity != null;
	}

	public virtual bool OnMouseMove(MouseEventArgs e, Viewport viewport, bool overButtons)
	{
		if (!base.Visible || viewport._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			return false;
		}
		if (_0023_003DzMZW4OwhqWTGs() || e.Button != MouseButtons.None)
		{
			PickedEntity = null;
			return false;
		}
		bool flag = _0023_003Dzc3vkuqr_ddi7(viewport, viewport.GetViewFrame(), e.Location);
		_0023_003Dzt8x9ym4_003D._0023_003DzKGntWXtyylZx(ParentViewport._0023_003Dz0TvaYNo_003D, flag, out var _0023_003DzcTbmALo_003D);
		bool flag2 = false;
		if (flag)
		{
			flag2 = _0023_003Dzh46LtHR_00243Trc(ParentViewport._0023_003Dz0TvaYNo_003D, viewport, e.Location, (Workspace._0023_003DzhFBmu_0024RpnRJ7)16, overButtons);
		}
		else
		{
			PickedEntity = null;
		}
		_0023_003Dzt8x9ym4_003D._0023_003DzSbnsq6aGahYh(ParentViewport._0023_003Dz0TvaYNo_003D, PickedEntity != null);
		return flag2 || _0023_003DzcTbmALo_003D;
	}

	internal void _0023_003DzqTTMKmE_003D(MouseEventArgs _0023_003Dz1SmHC4c_003D, Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzunVj9yQ_003D, int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D)
	{
		if (_0023_003DzBVawHt4YAYHR)
		{
			_0023_003DzDI8Y9ks_003D = ((Math.Abs(_0023_003DzDI8Y9ks_003D) > Math.Abs(_0023_003DzJx6crCU_003D)) ? _0023_003DzDI8Y9ks_003D : _0023_003DzJx6crCU_003D);
			_0023_003DzJx6crCU_003D = 0;
		}
		_0023_003DzDt5ar2MD0YHQ = new System.Drawing.Point(_0023_003DzDt5ar2MD0YHQ.X + Math.Abs(_0023_003Dz1SmHC4c_003D.Location.X - _0023_003Dz1CzoYMjXhxGb.X), _0023_003DzDt5ar2MD0YHQ.Y + Math.Abs(_0023_003Dz1SmHC4c_003D.Location.Y - _0023_003Dz1CzoYMjXhxGb.Y));
		if (_0023_003DzDt5ar2MD0YHQ.X > _0023_003DzIGoimFbYfxcJ || _0023_003DzDt5ar2MD0YHQ.Y > _0023_003DzIGoimFbYfxcJ)
		{
			PickedEntity = null;
		}
		_0023_003DzYzWi5Yw_003D._0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003DzYzWi5Yw_003D.ScreenToViewport(_0023_003DzunVj9yQ_003D), _0023_003DzDI8Y9ks_003D * 3, _0023_003DzJx6crCU_003D * 3, _0023_003DzBQC8k3F0wJN4: false);
	}

	protected internal override bool OnMouseUp(MouseEventArgs e, Viewport viewport)
	{
		Workspace _0023_003Dz0TvaYNo_003D = viewport._0023_003Dz0TvaYNo_003D;
		if (e.Button != MouseButtons.Left)
		{
			return false;
		}
		if (!base.Visible || (!Dragging && (PickedEntity == null || (_0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzF3HKD2trntQC() && _0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Dragging))))
		{
			return false;
		}
		base.OnMouseUp(e, viewport);
		_0023_003DzBVawHt4YAYHR = false;
		if (Dragging)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzcWhtcC8_003D(viewport);
			Dragging = false;
			if (PickedEntity == null)
			{
				return false;
			}
		}
		if (PickedEntity != null)
		{
			SelectedItem[] array = _0023_003Dz0TvaYNo_003D._0023_003DzqbHFKAkQdkNK4Y2H5A_003D_003D(viewport, e.Location, new List<Entity>(_0023_003DzE2brWRjSvZMG()), (Workspace._0023_003DzhFBmu_0024RpnRJ7)16, _0023_003Dz_bIfLEkNPFmB: true, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: true, _0023_003DzCq_00248LrgCN_f9: false);
			if (array.Length != 0)
			{
				ViewCubePartEntity viewCubePartEntity = (ViewCubePartEntity)array[0].Item;
				if (viewCubePartEntity != null && viewCubePartEntity == PickedEntity && viewCubePartEntity._0023_003DzGpFd0Ls_003D != (_0023_003DzhnRTKA3LdwJJ)4)
				{
					viewType view = ((ViewCubePartEntity)PickedEntity).GetView();
					_0023_003Dz0TvaYNo_003D._0023_003Dzkxa5rh7IEj_gGwqk6w_003D_003D = true;
					Workspace.ViewChangedEventArgs e2 = new Workspace.ViewChangedEventArgs(view);
					_0023_003DzNG9r6_c_003D?.Invoke(this, e2);
					if (!e2.Handled)
					{
						SetView(viewport, view);
					}
					_0023_003Dz0TvaYNo_003D._0023_003DzEve6E9qqZPdg = _0023_003Dz0TvaYNo_003D._0023_003DzBn2ByFKdwrou;
					_0023_003Dz0TvaYNo_003D._0023_003Dzkxa5rh7IEj_gGwqk6w_003D_003D = false;
				}
				else
				{
					PickedEntity.Selected = false;
				}
				PickedEntity = null;
				return true;
			}
		}
		if (PickedEntity != null)
		{
			PickedEntity.Selected = false;
		}
		return PickedEntity != null;
	}

	protected virtual void SetView(Viewport viewport, viewType viewOrientation)
	{
		if (InitialRotation.Equals(_0023_003DzB2KdYGrGs0O0()))
		{
			viewport.SetView(viewOrientation, FitAfterViewChange, AnimateCamera, viewport.Zoom.FitMargin, selectedOnly: false, viewport._0023_003Dz0TvaYNo_003D.AnimateCameraDuration);
			return;
		}
		Quaternion cameraRotation = viewport.GetCameraRotation(viewOrientation, InitialRotation);
		viewport.SetView(cameraRotation, FitAfterViewChange, AnimateCamera, viewport.Zoom.FitMargin, selectedOnly: false, viewport._0023_003Dz0TvaYNo_003D.AnimateCameraDuration);
	}

	[SpecialName]
	internal override IList<Mesh> _0023_003DzE2brWRjSvZMG()
	{
		return _0023_003Dz5H3rW_0024dVy_0024oE;
	}

	private bool _0023_003DzbUxkg_0024pX8GiH()
	{
		return Position != _0023_003DzPkO7IBwkBx9t();
	}

	internal void _0023_003Dz4T4pGdvYHA7k()
	{
		Position = _0023_003DzPkO7IBwkBx9t();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (RenderContextUtility.ConvertColor(FrontColor).ToArgb() == _0023_003DzvtaOXtfiDS67().ToArgb() && RenderContextUtility.ConvertColor(BackColor).ToArgb() == _0023_003DzuUhPA_m9XuTe().ToArgb() && RenderContextUtility.ConvertColor(LeftColor).ToArgb() == _0023_003DzfUh6VPC_bZHa().ToArgb() && RenderContextUtility.ConvertColor(RightColor).ToArgb() == _0023_003DzRqCT6qmSZeGN().ToArgb() && RenderContextUtility.ConvertColor(TopColor).ToArgb() == _0023_003DzeBSAOgJFNIX6().ToArgb() && RenderContextUtility.ConvertColor(BottomColor).ToArgb() == _0023_003Dznt6fRDzSS_Uu().ToArgb() && Position == _0023_003DzPkO7IBwkBx9t() && base.Visible == UserInterfaceSymbolBase._0023_003DzndG2TcxO_tb_0024() && RenderContextUtility.ConvertColor(HighlightColor).ToArgb() == _0023_003DztG7oqeEsiGCP().ToArgb() && AnimateCamera && string.Compare(FrontText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591103), StringComparison.InvariantCulture) <= 0 && string.Compare(BackText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591091), StringComparison.InvariantCulture) <= 0 && string.Compare(LeftText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590856), StringComparison.InvariantCulture) <= 0 && string.Compare(RightText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590877), StringComparison.InvariantCulture) <= 0 && string.Compare(TopText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590865), StringComparison.InvariantCulture) <= 0 && string.Compare(BottomText, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590887), StringComparison.InvariantCulture) <= 0 && FrontRingLabel == _0023_003Dz4g6Kybvxk2B1hI1R7A_003D_003D() && BackRingLabel == _0023_003Dz4Db1a_ZpPQIkpQ4edg_003D_003D() && LeftRingLabel == _0023_003DzhJk5rMfvpemuyshtXg_003D_003D() && RightRingLabel == _0023_003Dz27T9yLMGME1Z8NaUHQ_003D_003D() && ShowRing == _0023_003Dz_0024uBMM0AYjBFX() && (Font == _0023_003Dz0UloR3WvSVa2() || Font.Equals(_0023_003Dz0UloR3WvSVa2())) && _0023_003DzDUVBhsOhu44_0024.ToArgb() == _0023_003DzSKb0W00Eht0_0024().ToArgb() && Size == 120 && FitAfterViewChange && Enabled && Lighting)
		{
			return ShowShadow != _0023_003DzceB6_0024Tf3bbvr();
		}
		return true;
	}

	public override object Clone()
	{
		return new ViewCubeIcon(this)
		{
			_0023_003DzTENXXYw_003D = _0023_003DzTENXXYw_003D
		};
	}

	private bool _0023_003DzgcAaPcoaPoUzF7hNZQ_003D_003D()
	{
		return FrontImage != null;
	}

	private void _0023_003DzD3a_0024WPO4mqWW()
	{
		FrontImage = null;
	}

	private bool _0023_003Dz0usk_xYUPZ_00241fftDXQ_003D_003D()
	{
		return BackImage != null;
	}

	internal void _0023_003Dz3I9RmHbUYqYA()
	{
		BackImage = null;
	}

	private bool _0023_003DzWMTC5I1zCCWQyQonbg_003D_003D()
	{
		return LeftImage != null;
	}

	private void _0023_003DzPbq0NWWk_0024_0024Iu()
	{
		LeftImage = null;
	}

	private bool _0023_003DzgoNCh645KFBGe4qw4A_003D_003D()
	{
		return RightImage != null;
	}

	private void _0023_003Dz45FJL5LI9GR7()
	{
		RightImage = null;
	}

	private void _0023_003Dz4MwfFU1BA_jx()
	{
		TopImage = null;
	}

	private bool _0023_003Dz9jILoSF_00244AoeQJowqA_003D_003D()
	{
		return BottomImage != null;
	}

	private void _0023_003DzJ5vgw_0024iVlfEJ()
	{
		BottomImage = null;
	}

	public void ResetImages()
	{
		_0023_003DzD3a_0024WPO4mqWW();
		_0023_003Dz3I9RmHbUYqYA();
		_0023_003Dz4MwfFU1BA_jx();
		_0023_003DzJ5vgw_0024iVlfEJ();
		_0023_003DzPbq0NWWk_0024_0024Iu();
		_0023_003Dz45FJL5LI9GR7();
	}

	public void SetImages(Image[] images)
	{
		if (images == null)
		{
			ResetImages();
			return;
		}
		if (images.Length != 6)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590935));
		}
		FrontImage = images[0];
		BackImage = images[1];
		TopImage = images[2];
		BottomImage = images[3];
		LeftImage = images[4];
		RightImage = images[5];
	}
}
