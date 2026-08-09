using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(BoundingBoxConverter))]
public class BoundingBoxSettings : IDisposable, IBoundingBoxSettings
{
	private Workspace _parentWorkspace;

	private Font _labelFont;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextOnly _0023_003Dz2TOCTXsyZLWU;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType? _0023_003Dz84_I676fuBCp;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003DzD4HjvLi8HsVr = Point3D.MinValue;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003Dze4TpmVqI26AF = Point3D.MaxValue;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzDFTJsrsRDL5Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static ushort _0023_003DzTNt0iJCDndSA = 3855;

	private ushort _linePattern = _0023_003DzTNt0iJCDndSA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003Dz_hYdiVw_003D = false;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003DzXT0RpmDe7oYn = false;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Point3D _0023_003Dzzpl1lf8_003D = Point3D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Point3D _0023_003DzNHUILfw_003D = new Point3D(1.0, 1.0, 1.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003Dz6Rybf98_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651266);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzQE2fhlcyxvEG = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651306);

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

	public linearUnitsType? UnitsOverride
	{
		get
		{
			return _0023_003Dz84_I676fuBCp;
		}
		set
		{
			_0023_003Dz84_I676fuBCp = value;
			_0023_003Dz2TOCTXsyZLWU.RegenMode = regenType.RegenAndCompile;
		}
	}

	[Description("Label font.")]
	public Font LabelFont => _labelFont;

	[Description("Gets or sets the pattern used to draw the wireframe box.")]
	[CLSCompliant(false)]
	public ushort LinePattern
	{
		get
		{
			return _linePattern;
		}
		set
		{
			_linePattern = value;
		}
	}

	[Description("The visibility status.")]
	public bool Visible { get; set; }

	[Description("When true, the BoundingBox.Min and BoundingBox.Max properties override the scene extension.")]
	public bool OverrideSceneExtents { get; set; }

	[Description("Defines the minimum extension of the scene (for viewport fitting and visualization puroposes).")]
	public Point3D Min { get; set; }

	[Description("Defines the maximum extension of the scene (for viewport fitting and visualization puroposes).")]
	public Point3D Max { get; set; }

	[Description("The format string describing the bounding box's label.")]
	public string FormatString { get; set; }

	[Description("The text displayed when the entity list is empty.")]
	public string NotApplicableText { get; set; }

	public BoundingBoxSettings()
		: this(_0023_003DzTNt0iJCDndSA, _0023_003Dz_hYdiVw_003D, _0023_003DzXT0RpmDe7oYn, _0023_003Dzzpl1lf8_003D, _0023_003DzNHUILfw_003D, _0023_003Dz6Rybf98_003D, _0023_003DzQE2fhlcyxvEG)
	{
	}

	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max)
	{
		_labelFont = labelFont;
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = _0023_003Dz6Rybf98_003D;
		NotApplicableText = _0023_003DzQE2fhlcyxvEG;
		_0023_003DzexZbUdHzo2EE(null);
	}

	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont)
		: this(labelFont, _0023_003DzTNt0iJCDndSA, _0023_003Dz_hYdiVw_003D, _0023_003DzXT0RpmDe7oYn, _0023_003Dzzpl1lf8_003D, _0023_003DzNHUILfw_003D)
	{
	}

	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont, ushort linePattern)
		: this(labelFont, linePattern, _0023_003Dz_hYdiVw_003D, _0023_003DzXT0RpmDe7oYn, _0023_003Dzzpl1lf8_003D, _0023_003DzNHUILfw_003D)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont, Color labelColor, Color lineColor, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max)
		: this(labelFont, linePattern, visible, overrideSceneExtents, min, max)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont, Color labelColor, Color lineColor, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max, string textSuffix, string notApplicableText = "(Not applicable)")
	{
		_labelFont = labelFont;
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = _0023_003Dz6Rybf98_003D;
		NotApplicableText = notApplicableText;
		_0023_003DzexZbUdHzo2EE(null);
	}

	[Obsolete("This constructor is deprecated.")]
	[CLSCompliant(false)]
	public BoundingBoxSettings(Color labelColor, Color lineColor, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max, string textSuffix, string notApplicableText = "(Not applicable)")
	{
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = _0023_003Dz6Rybf98_003D;
		NotApplicableText = notApplicableText;
		_0023_003DzexZbUdHzo2EE(null);
	}

	[Obsolete("This constructor is deprecated.")]
	[CLSCompliant(false)]
	public BoundingBoxSettings(Font labelFont, Color labelColor, Color lineColor, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max, string textSuffix, string notApplicableText, bool lighting)
	{
		_labelFont = labelFont;
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = _0023_003Dz6Rybf98_003D;
		NotApplicableText = notApplicableText;
		_0023_003DzexZbUdHzo2EE(null);
	}

	[Obsolete("This constructor is deprecated.")]
	[CLSCompliant(false)]
	public BoundingBoxSettings(Color labelColor, Color lineColor, ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max, string textSuffix, string notApplicableText, bool lighting)
	{
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = _0023_003Dz6Rybf98_003D;
		NotApplicableText = notApplicableText;
		_0023_003DzexZbUdHzo2EE(null);
	}

	[CLSCompliant(false)]
	public BoundingBoxSettings(ushort linePattern, bool visible, bool overrideSceneExtents, Point3D min, Point3D max, string formatString, string notApplicableText)
	{
		_linePattern = linePattern;
		Visible = visible;
		OverrideSceneExtents = overrideSceneExtents;
		Min = min;
		Max = max;
		FormatString = formatString;
		NotApplicableText = notApplicableText;
		_0023_003DzexZbUdHzo2EE(null);
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		if (_0023_003Dz2TOCTXsyZLWU != null)
		{
			_0023_003Dz2TOCTXsyZLWU._0023_003DzPY_0024ulDyKjEOA();
		}
	}

	public void Dispose()
	{
		_0023_003DzGtc_uLD6StwG();
		if (_0023_003Dz2TOCTXsyZLWU != null)
		{
			_0023_003Dz2TOCTXsyZLWU.Dispose();
		}
		ParentWorkspace = null;
	}

	internal void _0023_003DzGtc_uLD6StwG()
	{
		if (_labelFont != null)
		{
			_labelFont.Dispose();
			_labelFont = null;
		}
	}

	internal void _0023_003DzFiyIoy6yqiQC()
	{
		_0023_003Dz17aPV6RdiCXU();
	}

	internal void _0023_003Dz17aPV6RdiCXU()
	{
		if (_labelFont == null)
		{
			if (ParentWorkspace != null)
			{
				_labelFont = (Font)ParentWorkspace.Font.Clone();
			}
			else
			{
				_labelFont = (Font)System.Windows.Forms.Control.DefaultFont.Clone();
			}
		}
		if (_0023_003Dz2TOCTXsyZLWU != null)
		{
			_0023_003Dz2TOCTXsyZLWU.Dispose();
			if (ParentWorkspace != null)
			{
				_0023_003Dz2TOCTXsyZLWU.Regen(ParentWorkspace._0023_003DzmNZD0Zs_003D, 1f);
			}
			else
			{
				_0023_003Dz2TOCTXsyZLWU.Font = (Font)_labelFont.Clone();
			}
		}
	}

	protected internal virtual void Draw(Viewport viewport, RenderContextBase context, float lineSize, Point3D min, Point3D max)
	{
		context.SetLighting(enable: false);
		context.SetShader(shaderType.NoLights);
		context.SetLineSize(lineSize, setShader: false);
		context.EnableXOR(enable: true);
		context.SetLineStipple(1, _linePattern, viewport.Camera);
		context.EnableLineStipple(enable: true);
		context.DrawLineLoop(new Point3D[4]
		{
			new Point3D(min.X, min.Y, min.Z),
			new Point3D(max.X, min.Y, min.Z),
			new Point3D(max.X, max.Y, min.Z),
			new Point3D(min.X, max.Y, min.Z)
		});
		context.DrawLineLoop(new Point3D[4]
		{
			new Point3D(min.X, min.Y, max.Z),
			new Point3D(max.X, min.Y, max.Z),
			new Point3D(max.X, max.Y, max.Z),
			new Point3D(min.X, max.Y, max.Z)
		});
		context.DrawLines(new Point3D[8]
		{
			new Point3D(min.X, min.Y, min.Z),
			new Point3D(min.X, min.Y, max.Z),
			new Point3D(max.X, min.Y, min.Z),
			new Point3D(max.X, min.Y, max.Z),
			new Point3D(max.X, max.Y, min.Z),
			new Point3D(max.X, max.Y, max.Z),
			new Point3D(min.X, max.Y, min.Z),
			new Point3D(min.X, max.Y, max.Z)
		});
		context.EnableLineStipple(enable: false);
		context.EnableXOR(enable: false);
	}

	protected internal virtual void DrawLabel(DrawSceneParams myParams)
	{
		myParams.RenderContext.PushShader();
		myParams.RenderContext.SetShader(shaderType.Texture2DNoLights);
		myParams.RenderContext.EnableXORForTexture(enable: true, myParams.ShaderParams);
		_0023_003Dz2TOCTXsyZLWU.DrawWithOffset(myParams.RenderContext, 0, 10, myParams.DrawScale);
		myParams.RenderContext.EnableXORForTexture(enable: false, myParams.ShaderParams);
		myParams.RenderContext.PopShader();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(BoundingBoxSettings _0023_003DzAbAO3f4_003D)
	{
		if (LinePattern == _0023_003DzAbAO3f4_003D.LinePattern && Visible == _0023_003DzAbAO3f4_003D.Visible && OverrideSceneExtents == _0023_003DzAbAO3f4_003D.OverrideSceneExtents && !(Min != _0023_003DzAbAO3f4_003D.Min) && !(Max != _0023_003DzAbAO3f4_003D.Max))
		{
			return NotApplicableText != _0023_003DzAbAO3f4_003D.NotApplicableText;
		}
		return true;
	}

	internal void _0023_003DzKFkHb4MBq9bk(RenderContextBase _0023_003DzoC62DbA_003D, double _0023_003DzmURGwPefc2yc, double _0023_003DzYJqmA_0024fVdGmi, double _0023_003DzKjt97ZDd4NMn, int _0023_003DzALy2Obg_003D, Point3D _0023_003DzHHHyVBQ_003D, Viewport _0023_003DzYzWi5Yw_003D, linearUnitsType _0023_003DzdW8_eCI_003D)
	{
		_0023_003DzFiyIoy6yqiQC();
		if (_0023_003DzALy2Obg_003D > 0)
		{
			_0023_003Dz2TOCTXsyZLWU.Text = string.Format(FormatString ?? _0023_003Dz6Rybf98_003D, _0023_003DzKjt97ZDd4NMn.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651315), CultureInfo.InvariantCulture), _0023_003DzmURGwPefc2yc.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651315), CultureInfo.InvariantCulture), _0023_003DzYJqmA_0024fVdGmi.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651315), CultureInfo.InvariantCulture), Utility.GetUnitsAbbreviation(_0023_003DzdW8_eCI_003D));
		}
		else
		{
			_0023_003Dz2TOCTXsyZLWU.Text = NotApplicableText + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338) + _0023_003DzdW8_eCI_003D;
		}
		_0023_003Dz2TOCTXsyZLWU.AnchorPoint = _0023_003DzHHHyVBQ_003D;
		_0023_003Dz2TOCTXsyZLWU.Regen(_0023_003DzoC62DbA_003D, 1f);
	}

	internal void _0023_003DzexZbUdHzo2EE(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003Dz17aPV6RdiCXU();
		if (_0023_003Dz2TOCTXsyZLWU != null)
		{
			_0023_003Dz2TOCTXsyZLWU.Dispose();
			_0023_003Dz2TOCTXsyZLWU = null;
		}
		_0023_003Dz2TOCTXsyZLWU = new TextOnly(Point3D.Origin, string.Empty, LabelFont, Color.White);
	}

	internal void _0023_003DzqDGueC67yP8K(RenderContextBase _0023_003DzmNZD0Zs_003D, double[] _0023_003DzYgijFM_0024VNOEd, int[] _0023_003DzBppTnBIbeUl7)
	{
		_0023_003Dz2TOCTXsyZLWU.UpdatePos(_0023_003DzmNZD0Zs_003D, _0023_003DzYgijFM_0024VNOEd, _0023_003DzBppTnBIbeUl7);
	}
}
