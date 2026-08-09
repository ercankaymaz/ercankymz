using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ToolBarButtonConverter))]
public class ToolBarButton : DisposableBase, ICloneable
{
	internal enum _0023_003DzJrgugJM_003D
	{

	}

	private enum _0023_003DzsEXEDPk_003D
	{

	}

	public delegate void ClickEventHandler(object sender, HandledEventArgs e);

	public enum styleType
	{
		PushButton = 1,
		ToggleButton,
		Separator
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ToolBar _0023_003Dz4iBK5_0024N3N5g7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzVCRPD_0024GbQNCA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ClickEventHandler _0023_003DzNG9r6_c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private styleType _0023_003Dzp3jg0wwRHRrc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003DzqCi9q5T_Zeu6ZDjsuw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzJrgugJM_003D _0023_003DzEmzoudE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase[] _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image[] _0023_003DzgbGkbyk_003D = new Image[3];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image _0023_003DzWZMDPRS4mnWdwpGktbij8Hc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image _0023_003DzjNb_acBPgoah2Ny6dtocrY8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float[] _0023_003DzQQZT2l6aHW72pl7m2v1fFYA_003D = new float[8] { 0f, 1f, 0f, 0f, 1f, 0f, 1f, 1f };

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float[] _0023_003DzTGkQRKm5IPuFCSuTtQ_003D_003D = new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f };

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static byte _0023_003DzWF_88dH0j5aa = 180;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQAUDROLZVDUV7_0024RAxJP8wKY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz7VEML1w_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzN2a_0024fLwg6rGOGtrx2VvPmAo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _0023_003DzY61nlWuMn1sAQHdmgQ_003D_003D;

	[Description("The toolbar button style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public styleType StyleMode
	{
		get
		{
			return _0023_003Dzp3jg0wwRHRrc;
		}
		set
		{
			_0023_003Dzp3jg0wwRHRrc = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The ToolBarButton name.")]
	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D = value;
		}
	}

	[Description("The visibility status.")]
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

	[Description("The button status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Enabled
	{
		get
		{
			return _0023_003Dz7VEML1w_003D;
		}
		set
		{
			_0023_003Dz7VEML1w_003D = value;
		}
	}

	[Description("The button pushed status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool Pushed
	{
		get
		{
			if (StyleMode == styleType.ToggleButton)
			{
				return _0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)2;
			}
			return false;
		}
		set
		{
			if (StyleMode == styleType.ToggleButton)
			{
				_0023_003Dzbb_0024Bito_003D(value ? ((_0023_003DzJrgugJM_003D)2) : ((_0023_003DzJrgugJM_003D)0));
			}
		}
	}

	public Rectangle Rectangle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqCi9q5T_Zeu6ZDjsuw_003D_003D;
		}
	}

	[Description("The button image.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Image Image
	{
		get
		{
			return _0023_003DzgbGkbyk_003D[0];
		}
		set
		{
			_0023_003DzgbGkbyk_003D[0] = value;
		}
	}

	[Description("The mouse hover state button image.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Image HoverImage
	{
		get
		{
			return _0023_003DzgbGkbyk_003D[1];
		}
		set
		{
			_0023_003DzgbGkbyk_003D[1] = value;
		}
	}

	[Description("The down state button image.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Image DownImage
	{
		get
		{
			return _0023_003DzgbGkbyk_003D[2];
		}
		set
		{
			_0023_003DzgbGkbyk_003D[2] = value;
		}
	}

	[Obsolete("This property is deprecated.")]
	[Description("The ToolBarButton bitmap for the disabled state.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image DisabledImage
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWZMDPRS4mnWdwpGktbij8Hc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWZMDPRS4mnWdwpGktbij8Hc_003D = value;
		}
	}

	[Obsolete("This property is deprecated.")]
	[Description("The ToolBarButton bitmap for the disabled down state.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image DisabledDownImage
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzjNb_acBPgoah2Ny6dtocrY8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzjNb_acBPgoah2Ny6dtocrY8_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Specifies the text to show on the ToolTip.")]
	public string ToolTipText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzN2a_0024fLwg6rGOGtrx2VvPmAo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzN2a_0024fLwg6rGOGtrx2VvPmAo_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual object Tag
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzY61nlWuMn1sAQHdmgQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzY61nlWuMn1sAQHdmgQ_003D_003D = value;
		}
	}

	[Description("Occurs when the button is clicked.")]
	public event ClickEventHandler Click
	{
		[CompilerGenerated]
		add
		{
			ClickEventHandler clickEventHandler = _0023_003DzNG9r6_c_003D;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler value2 = (ClickEventHandler)Delegate.Combine(clickEventHandler2, value);
				clickEventHandler = Interlocked.CompareExchange(ref _0023_003DzNG9r6_c_003D, value2, clickEventHandler2);
			}
			while ((object)clickEventHandler != clickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickEventHandler clickEventHandler = _0023_003DzNG9r6_c_003D;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler value2 = (ClickEventHandler)Delegate.Remove(clickEventHandler2, value);
				clickEventHandler = Interlocked.CompareExchange(ref _0023_003DzNG9r6_c_003D, value2, clickEventHandler2);
			}
			while ((object)clickEventHandler != clickEventHandler2);
		}
	}

	public ToolBarButton()
		: this(null, null, null, styleType.ToggleButton, visible: true)
	{
	}

	public ToolBarButton(Image buttonImage, string name, string toolTipText, styleType style, bool visible)
		: this(buttonImage, name, toolTipText, style, visible, enabled: true)
	{
	}

	public ToolBarButton(Image buttonImage, string name, string toolTipText, styleType style, bool visible, bool enabled)
		: this(buttonImage, name, toolTipText, style, visible, enabled, null, null, null, null)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ToolBarButton(Image buttonImage, string name, string toolTipText, styleType style, bool visible, bool enabled, Image downImage, Image hoverImage, Image disabledImage, Image disabledDownImage)
		: this(buttonImage, name, toolTipText, style, visible, enabled, downImage, hoverImage)
	{
	}

	public ToolBarButton(Image buttonImage, string name, string toolTipText, styleType style, bool visible, bool enabled, Image downImage, Image hoverImage)
	{
		_0023_003DzshPEPAc_003D(buttonImage, name, toolTipText, style, visible, enabled, downImage, hoverImage);
	}

	protected ToolBarButton(ToolBarButton another)
	{
		_0023_003DzshPEPAc_003D(another.Image, another.Name, another.ToolTipText, another.StyleMode, another.Visible, another.Enabled, another.DownImage, another.HoverImage);
	}

	public virtual object Clone()
	{
		return new ToolBarButton(this);
	}

	internal void _0023_003DzshPEPAc_003D(Image _0023_003Dz55KT57fEFPLm, string _0023_003DzYQvHPFc_003D, string _0023_003Dz2ft66hVNYnkY, styleType _0023_003DzqheO7Oc_003D, bool _0023_003DzbWHNjOg_003D, bool _0023_003DzQVsx1WI_003D, Image _0023_003DzCJ2rC8b5QNkD, Image _0023_003DzlVmELkfya4tl)
	{
		Name = _0023_003DzYQvHPFc_003D;
		ToolTipText = _0023_003Dz2ft66hVNYnkY;
		StyleMode = _0023_003DzqheO7Oc_003D;
		Visible = _0023_003DzbWHNjOg_003D;
		Enabled = _0023_003DzQVsx1WI_003D;
		if (_0023_003Dz55KT57fEFPLm != null)
		{
			_0023_003DzgbGkbyk_003D[0] = _0023_003Dz55KT57fEFPLm;
		}
		if (_0023_003DzCJ2rC8b5QNkD != null)
		{
			_0023_003DzgbGkbyk_003D[2] = _0023_003DzCJ2rC8b5QNkD;
		}
		if (_0023_003DzlVmELkfya4tl != null)
		{
			_0023_003DzgbGkbyk_003D[1] = _0023_003DzlVmELkfya4tl;
		}
	}

	public static bool operator ==(ToolBarButton left, ToolBarButton right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(ToolBarButton left, ToolBarButton right)
	{
		return !Equals(left, right);
	}

	public static bool Equals(ToolBarButton objA, ToolBarButton objB)
	{
		if ((object)objA != objB)
		{
			if ((object)objA != null && (object)objB != null && objA.StyleMode == objB.StyleMode && objA.Image == objB.Image && objA.DownImage == objB.DownImage && objA.HoverImage == objB.HoverImage && objA.Name == objB.Name && objA.ToolTipText == objB.ToolTipText)
			{
				return objA.Visible == objB.Visible;
			}
			return false;
		}
		return true;
	}

	protected internal virtual bool IsDefaultButton()
	{
		return false;
	}

	internal bool _0023_003DzuooydjCMSwlZPpsh1w_003D_003D()
	{
		return StyleMode != styleType.ToggleButton;
	}

	internal void _0023_003DzyUvVZflI9bLt()
	{
		StyleMode = styleType.ToggleButton;
	}

	internal bool _0023_003DzH07Ax_2vyPpl()
	{
		return Name != string.Empty;
	}

	internal void _0023_003DzPbOheug_003D()
	{
		Name = string.Empty;
	}

	internal bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return !Visible;
	}

	internal void _0023_003DzGUdRoqIEEze_()
	{
		Visible = true;
	}

	internal bool _0023_003DzcY1SwfFv_M8s()
	{
		return !Enabled;
	}

	internal void _0023_003DzNSayyTKTSOmA()
	{
		Enabled = true;
	}

	internal void _0023_003DzLr8pehtIvvdB(Rectangle _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzqCi9q5T_Zeu6ZDjsuw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal _0023_003DzJrgugJM_003D _0023_003Dz0hLnOJ4_003D()
	{
		if (StyleMode != styleType.Separator)
		{
			return _0023_003DzEmzoudE_003D;
		}
		return (_0023_003DzJrgugJM_003D)0;
	}

	internal void _0023_003Dzbb_0024Bito_003D(_0023_003DzJrgugJM_003D _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzEmzoudE_003D = _0023_003DzsLHxXyo_003D;
	}

	internal TextureBase[] _0023_003Dzt8M7jZkZ__VNpsLmCQ_003D_003D()
	{
		return _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D;
	}

	internal bool _0023_003DzCZlQDubFVGj1()
	{
		return Image != null;
	}

	internal void _0023_003Dz6zqt53PVMvO7()
	{
		Image = null;
	}

	internal bool _0023_003Dz9naQ879chD0T_0024KLbxQ_003D_003D()
	{
		return HoverImage != null;
	}

	internal void _0023_003Dz34RUm0BD8xsx()
	{
		HoverImage = null;
	}

	internal bool _0023_003DzUVat2IvnSe_0024uGLQk0g_003D_003D()
	{
		return DownImage != null;
	}

	internal void _0023_003Dzg6w_00247JXIpqLn()
	{
		DownImage = null;
	}

	internal virtual void _0023_003Dz99kJFjE_003D(Viewport _0023_003DzYzWi5Yw_003D, RenderContextBase _0023_003DzmNZD0Zs_003D, bool _0023_003DzVeSTNSfs_UUA, bool _0023_003DzmfOeHIQ_003D, int _0023_003DzKx6mRu4LmUa4)
	{
		if (_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D != null && Visible)
		{
			bool flag = false;
			byte b = byte.MaxValue;
			if (!Enabled || _0023_003DzVeSTNSfs_UUA)
			{
				flag = true;
				_0023_003DzmNZD0Zs_003D.PushShader();
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLightsModulate);
				b = 127;
				_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(b, Color.White));
				_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame();
			}
			switch (_0023_003Dz0hLnOJ4_003D())
			{
			case (_0023_003DzJrgugJM_003D)0:
				_0023_003DzwCL3lEhabo_0024g(_0023_003DzYzWi5Yw_003D, _0023_003DzmNZD0Zs_003D, _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[0], _0023_003DzmfOeHIQ_003D, _0023_003DzKx6mRu4LmUa4, b);
				break;
			case (_0023_003DzJrgugJM_003D)1:
				_0023_003DzwCL3lEhabo_0024g(_0023_003DzYzWi5Yw_003D, _0023_003DzmNZD0Zs_003D, _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[1], _0023_003DzmfOeHIQ_003D, _0023_003DzKx6mRu4LmUa4, b);
				break;
			case (_0023_003DzJrgugJM_003D)2:
				_0023_003DzwCL3lEhabo_0024g(_0023_003DzYzWi5Yw_003D, _0023_003DzmNZD0Zs_003D, _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[2], _0023_003DzmfOeHIQ_003D, _0023_003DzKx6mRu4LmUa4, b);
				break;
			}
			if (flag)
			{
				_0023_003DzmNZD0Zs_003D.PopShader();
			}
		}
	}

	private void _0023_003DzwCL3lEhabo_0024g(Viewport _0023_003DzYzWi5Yw_003D, RenderContextBase _0023_003DzmNZD0Zs_003D, TextureBase _0023_003Dz_IfKSJY_003D, bool _0023_003DzmfOeHIQ_003D, int _0023_003DzKx6mRu4LmUa4, byte _0023_003DzivuqTrA_003D)
	{
		float num = Rectangle.Height;
		Point point = _0023_003DzYzWi5Yw_003D.ScreenToViewport(Rectangle.Location);
		float y = (float)(_0023_003DzKx6mRu4LmUa4 - point.Y) - num;
		float width = Rectangle.Width;
		float x = point.X;
		float[] texCoords = _0023_003DzTGkQRKm5IPuFCSuTtQ_003D_003D;
		if (StyleMode == styleType.Separator && _0023_003DzmfOeHIQ_003D)
		{
			texCoords = _0023_003DzQQZT2l6aHW72pl7m2v1fFYA_003D;
		}
		_0023_003DzmNZD0Zs_003D.DrawQuadWithTextures(_0023_003Dz_IfKSJY_003D, texCoords, _0023_003DzivuqTrA_003D, new RectangleF(x, y, width, num), 0f, buffered: false);
	}

	public bool Contains(Point mousePos)
	{
		if (Visible && StyleMode != styleType.Separator && Enabled)
		{
			return Rectangle.Contains(mousePos);
		}
		return false;
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DzPY_0024ulDyKjEOA();
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		if (_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D != null)
		{
			for (int i = 0; i < _0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D.Length; i++)
			{
				if (_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[i] != null)
				{
					_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[i].Dispose();
				}
			}
		}
		_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D = null;
	}

	internal void _0023_003Dz7M7UaJs_003D(bool _0023_003DzYvunAdQ_003D)
	{
		if (_0023_003DzYvunAdQ_003D && _0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)0)
		{
			_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)1);
		}
		else if (!_0023_003DzYvunAdQ_003D && _0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)1)
		{
			_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)0);
		}
	}

	internal void _0023_003DzqJuYHyY_003D()
	{
		_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)2);
	}

	internal void _0023_003DzQLjVxM8_003D()
	{
		_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)0);
	}

	internal void _0023_003Dz7M7UaJs_003D()
	{
		_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)1);
	}

	private SizeF _0023_003DztnrgTmT5sBNd()
	{
		return _0023_003Dz4iBK5_0024N3N5g7?.ParentViewport?._0023_003Dz0TvaYNo_003D._0023_003DztnrgTmT5sBNd() ?? UtilityEx.GetScalingLevel();
	}

	protected internal void CreateTextures(RenderContextBase renderContext, Workspace control, GraphicsPath outer, GraphicsPath inner, int width, int height, int bmpWidth, int bmpHeight, Color highlightColor)
	{
		_0023_003DzPY_0024ulDyKjEOA();
		_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D = new TextureBase[3];
		int num = bmpWidth;
		int num2 = bmpHeight;
		_0023_003DzLr8pehtIvvdB(new Rectangle(Rectangle.Location, new Size(width, height)));
		num = bmpWidth - 2;
		num2 = bmpHeight - 2;
		for (int i = 0; i < 3; i++)
		{
			bool _0023_003DzYI_0024_E9M_003D;
			Bitmap bitmap = _0023_003DzZ2MY3KxWfvzR(i, renderContext, control, control._0023_003DzipBYly6zFKAp(), outer, bmpWidth, bmpHeight, highlightColor, num, num2, out _0023_003DzYI_0024_E9M_003D);
			if (bitmap != null)
			{
				if (control.Renderer == rendererType.OpenGL && _0023_003DztnrgTmT5sBNd().Height <= 1f)
				{
					_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[i] = renderContext.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
				}
				else
				{
					_0023_003Dzd6FWrVSfj8IoYqm1Xg_003D_003D[i] = renderContext.CreateTexture2D(bitmap);
				}
				if (_0023_003DzYI_0024_E9M_003D)
				{
					bitmap.Dispose();
				}
			}
		}
	}

	private Bitmap _0023_003DzZ2MY3KxWfvzR(int _0023_003DzMz3PPs4_003D, RenderContextBase _0023_003DzmNZD0Zs_003D, Workspace _0023_003DzA5OxWwM_003D, Viewport _0023_003DzYzWi5Yw_003D, GraphicsPath _0023_003DzlCoElfk_003D, int _0023_003DzC9FqcOL3zXY_0024, int _0023_003DzCwU7FoKVOiJY, Color _0023_003DzxJGJhjg_003D, int _0023_003Dzdo8MyNvhDc2U, int _0023_003DzTVrj1st1mQtt, out bool _0023_003DzYI_0024_E9M_003D)
	{
		_0023_003DzYI_0024_E9M_003D = true;
		bool flag = true;
		Image[] array = _0023_003DzgbGkbyk_003D;
		foreach (Image image in array)
		{
			flag = flag && image != null;
		}
		bool flag2 = _0023_003DzgbGkbyk_003D[_0023_003DzMz3PPs4_003D] != null;
		Bitmap bitmap;
		if (flag)
		{
			if (_0023_003DzgbGkbyk_003D[_0023_003DzMz3PPs4_003D] is Bitmap)
			{
				bitmap = (Bitmap)_0023_003DzgbGkbyk_003D[_0023_003DzMz3PPs4_003D];
				_0023_003DzYI_0024_E9M_003D = false;
			}
			else
			{
				bitmap = new Bitmap(_0023_003DzgbGkbyk_003D[_0023_003DzMz3PPs4_003D]);
			}
		}
		else
		{
			if (StyleMode == styleType.Separator && _0023_003DzMz3PPs4_003D != 0)
			{
				return null;
			}
			bitmap = new Bitmap(_0023_003DzC9FqcOL3zXY_0024, _0023_003DzCwU7FoKVOiJY);
			using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			if (flag2)
			{
				graphics.DrawImage(_0023_003DzgbGkbyk_003D[_0023_003DzMz3PPs4_003D], _0023_003DzC9FqcOL3zXY_0024 / 2 - _0023_003Dzdo8MyNvhDc2U / 2, _0023_003DzCwU7FoKVOiJY / 2 - _0023_003DzTVrj1st1mQtt / 2, _0023_003Dzdo8MyNvhDc2U, _0023_003DzTVrj1st1mQtt);
			}
			else
			{
				if (_0023_003DzMz3PPs4_003D == 2)
				{
					_0023_003Dz191ozMVp28cu(graphics, _0023_003DzlCoElfk_003D, Color.FromArgb(_0023_003DzWF_88dH0j5aa, _0023_003DzxJGJhjg_003D));
				}
				if (_0023_003DzMz3PPs4_003D == 1)
				{
					Color contrastColorSemiTransparent = _0023_003DzYzWi5Yw_003D.Background.GetContrastColorSemiTransparent();
					_0023_003Dz191ozMVp28cu(graphics, _0023_003DzlCoElfk_003D, contrastColorSemiTransparent);
				}
				DrawImage(graphics, _0023_003DzA5OxWwM_003D, _0023_003DzC9FqcOL3zXY_0024 / 2 - _0023_003Dzdo8MyNvhDc2U / 2, _0023_003DzCwU7FoKVOiJY / 2 - _0023_003DzTVrj1st1mQtt / 2, _0023_003Dzdo8MyNvhDc2U, _0023_003DzTVrj1st1mQtt);
			}
		}
		return bitmap;
	}

	protected virtual void DrawImage(System.Drawing.Graphics g, Workspace workspace, int x, int y, int width, int height)
	{
		if (_0023_003DzgbGkbyk_003D[0] != null)
		{
			DrawImage(g, _0023_003DzgbGkbyk_003D[0], x, y, width, height);
		}
		else
		{
			if (StyleMode != styleType.Separator)
			{
				return;
			}
			Viewport viewport = workspace._0023_003DzipBYly6zFKAp();
			bool isDark = viewport.Background.IsDark;
			switch (viewport.Background.ColorTheme)
			{
			case colorThemeType.Light:
				DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz9_0024cB9qsWkl4L(), x, y, width, height);
				return;
			case colorThemeType.Dark:
				DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzQ5i5QU4feGa7(), x, y, width, height);
				return;
			}
			if (isDark)
			{
				DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz9_0024cB9qsWkl4L(), x, y, width, height);
			}
			else
			{
				DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzQ5i5QU4feGa7(), x, y, width, height);
			}
		}
	}

	protected void DrawImage(System.Drawing.Graphics g, Image image, int x, int y, int width, int height)
	{
		g.DrawImage(image, x, y, width, height);
	}

	private static void _0023_003Dzd6F9enhu8lok(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, GraphicsPath _0023_003DzEs1nyGM_003D)
	{
		Pen pen = new Pen(Color.FromArgb(240, Color.White));
		try
		{
			_0023_003DzVC9FBdo_003D.DrawPath(pen, _0023_003DzEs1nyGM_003D);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private static void _0023_003Dz191ozMVp28cu(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, GraphicsPath _0023_003DzEs1nyGM_003D, Color _0023_003Dzhpb8QNg_003D)
	{
		SolidBrush solidBrush = new SolidBrush(_0023_003Dzhpb8QNg_003D);
		try
		{
			_0023_003DzVC9FBdo_003D.FillPath(solidBrush, _0023_003DzEs1nyGM_003D);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	private static void _0023_003Dz_0024SL45FWwsVCZ(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, GraphicsPath _0023_003DzEs1nyGM_003D)
	{
		int num = 200;
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(_0023_003DzEs1nyGM_003D.GetBounds(), Color.FromArgb(num / 4, Color.White), Color.FromArgb(num, Color.White), LinearGradientMode.Vertical);
		try
		{
			_0023_003DzVC9FBdo_003D.FillPath(linearGradientBrush, _0023_003DzEs1nyGM_003D);
		}
		finally
		{
			((IDisposable)linearGradientBrush).Dispose();
		}
	}

	private static void _0023_003DzDFRRnEiiQ0Oo(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, GraphicsPath _0023_003DzEs1nyGM_003D)
	{
		Pen pen = new Pen(Color.FromArgb(80, Color.Black));
		try
		{
			_0023_003DzVC9FBdo_003D.DrawPath(pen, _0023_003DzEs1nyGM_003D);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	internal virtual bool _0023_003DzA_0024ihSwbmVYvs(ToolBarButton _0023_003DzDx8rGzwxy0Do, ClickEventHandler _0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D)
	{
		if ((object)_0023_003DzDx8rGzwxy0Do == this)
		{
			if (_0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)2 || _0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA)
			{
				_0023_003DzW24vQRhf4uWc(_0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D);
				if (StyleMode == styleType.PushButton)
				{
					_0023_003Dz7M7UaJs_003D();
				}
				_0023_003DzQAUDROLZVDUV7_0024RAxJP8wKY_003D = (_0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA = false);
				return true;
			}
		}
		else if (_0023_003DzQAUDROLZVDUV7_0024RAxJP8wKY_003D)
		{
			_0023_003DzQAUDROLZVDUV7_0024RAxJP8wKY_003D = false;
			if (_0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)2)
			{
				_0023_003DzQLjVxM8_003D();
				return true;
			}
		}
		else if (_0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA)
		{
			_0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA = false;
			if (_0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)1)
			{
				_0023_003DzqJuYHyY_003D();
				_0023_003DzW24vQRhf4uWc(_0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D);
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzW24vQRhf4uWc(ClickEventHandler _0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D)
	{
		HandledEventArgs e = new HandledEventArgs();
		if (_0023_003DzNG9r6_c_003D != null)
		{
			_0023_003DzNG9r6_c_003D(this, e);
		}
		_0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D(this, e);
	}

	internal void _0023_003Dzu8_0024tRXp_0024yCuW()
	{
		if (_0023_003Dz0hLnOJ4_003D() == (_0023_003DzJrgugJM_003D)2)
		{
			_0023_003Dzbb_0024Bito_003D((_0023_003DzJrgugJM_003D)1);
			_0023_003DzX87zcQFz_Rl_0024EVcGEFos15FwdWaA = true;
		}
		else
		{
			_0023_003DzqJuYHyY_003D();
			_0023_003DzQAUDROLZVDUV7_0024RAxJP8wKY_003D = true;
		}
	}

	internal bool _0023_003DzOX_00241HEiRKIOFwAX29Q_003D_003D()
	{
		return ToolTipText != string.Empty;
	}

	internal void _0023_003DzMpYVjvywYUc0()
	{
		ToolTipText = string.Empty;
	}
}
