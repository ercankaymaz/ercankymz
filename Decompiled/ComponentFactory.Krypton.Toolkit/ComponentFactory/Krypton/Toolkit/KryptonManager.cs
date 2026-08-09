#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonManager), "ToolboxBitmaps.KryptonManager.bmp")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonManagerDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DefaultProperty("GlobalPaletteMode")]
[Description("Access global Krypton settings.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public sealed class KryptonManager : Component
{
	private static bool _globalApplyToolstrips;

	private static bool _globalAllowFormChrome;

	private static GlobalStrings _globalStrings;

	private static PaletteModeManager _globalPaletteMode;

	private static IPalette _globalPalette;

	private static PaletteProfessionalOffice2003 _paletteProfessionalOffice2003;

	private static PaletteProfessionalSystem _paletteProfessionalSystem;

	private static PaletteOffice2007Blue _paletteOffice2007Blue;

	private static PaletteOffice2007Silver _paletteOffice2007Silver;

	private static PaletteOffice2007Black _paletteOffice2007Black;

	private static PaletteOffice2010Blue _paletteOffice2010Blue;

	private static PaletteOffice2010Silver _paletteOffice2010Silver;

	private static PaletteOffice2010Black _paletteOffice2010Black;

	private static PaletteSparkleBlue _paletteSparkleBlue;

	private static PaletteSparkleOrange _paletteSparkleOrange;

	private static PaletteSparklePurple _paletteSparklePurple;

	private static RenderStandard _renderStandard;

	private static RenderProfessional _renderProfessional;

	private static RenderOffice2007 _renderOffice2007;

	private static RenderOffice2010 _renderOffice2010;

	private static RenderSparkle _renderSparkle;

	[Category("Visuals")]
	[Description("Global palette applied to drawing.")]
	[DefaultValue(typeof(PaletteModeManager), "Office2010Blue")]
	public PaletteModeManager GlobalPaletteMode
	{
		get
		{
			return _globalPaletteMode;
		}
		set
		{
			if (_globalPaletteMode == value)
			{
				return;
			}
			if (value != PaletteModeManager.Custom)
			{
				PaletteModeManager globalPaletteMode = _globalPaletteMode;
				IPalette globalPalette = _globalPalette;
				_globalPaletteMode = value;
				_globalPalette = null;
				if (HasCircularReference())
				{
					_globalPaletteMode = globalPaletteMode;
					_globalPalette = globalPalette;
					throw new ArgumentOutOfRangeException("value", "Cannot use palette that would create a circular reference");
				}
				_globalPalette = globalPalette;
				SetPalette(CurrentGlobalPalette);
				OnGlobalPaletteChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Visuals")]
	[Description("Global custom palette applied to drawing.")]
	[DefaultValue(null)]
	public IPalette GlobalPalette
	{
		get
		{
			return _globalPalette;
		}
		set
		{
			if (_globalPalette != value)
			{
				PaletteModeManager globalPaletteMode = _globalPaletteMode;
				IPalette globalPalette = _globalPalette;
				_globalPaletteMode = ((value == null) ? PaletteModeManager.Office2010Blue : PaletteModeManager.Custom);
				_globalPalette = value;
				if (HasCircularReference())
				{
					_globalPaletteMode = globalPaletteMode;
					_globalPalette = globalPalette;
					throw new ArgumentOutOfRangeException("value", "Cannot use palette that would create a circular reference");
				}
				_globalPalette = globalPalette;
				SetPalette(value);
				if (value == null)
				{
					SetPalette(CurrentGlobalPalette);
				}
				else
				{
					_globalPaletteMode = PaletteModeManager.Custom;
				}
				OnGlobalPaletteChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Visuals")]
	[Description("Should the palette colors be applied to the toolstrips.")]
	[DefaultValue(true)]
	public bool GlobalApplyToolstrips
	{
		get
		{
			return ApplyToolstrips;
		}
		set
		{
			ApplyToolstrips = value;
		}
	}

	[Category("Visuals")]
	[Description("Should KryptonForm instances be allowed to show custom chrome.")]
	[DefaultValue(true)]
	public bool GlobalAllowFormChrome
	{
		get
		{
			return AllowFormChrome;
		}
		set
		{
			AllowFormChrome = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of global strings.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	public GlobalStrings GlobalStrings => _globalStrings;

	public static bool ApplyToolstrips
	{
		get
		{
			return _globalApplyToolstrips;
		}
		set
		{
			if (_globalApplyToolstrips != value)
			{
				_globalApplyToolstrips = value;
				if (_globalApplyToolstrips)
				{
					UpdateToolStripManager();
				}
				else
				{
					ResetToolStripManager();
				}
			}
		}
	}

	public static bool AllowFormChrome
	{
		get
		{
			return _globalAllowFormChrome;
		}
		set
		{
			if (_globalAllowFormChrome != value)
			{
				_globalAllowFormChrome = value;
				OnGlobalAllowFormChromeChanged(EventArgs.Empty);
			}
		}
	}

	public static GlobalStrings Strings => _globalStrings;

	public static IPalette CurrentGlobalPalette
	{
		get
		{
			switch (_globalPaletteMode)
			{
			case PaletteModeManager.ProfessionalSystem:
				return PaletteProfessionalSystem;
			case PaletteModeManager.ProfessionalOffice2003:
				return PaletteProfessionalOffice2003;
			case PaletteModeManager.Office2007Blue:
				return PaletteOffice2007Blue;
			case PaletteModeManager.Office2007Silver:
				return PaletteOffice2007Silver;
			case PaletteModeManager.Office2007Black:
				return PaletteOffice2007Black;
			case PaletteModeManager.Office2010Blue:
				return PaletteOffice2010Blue;
			case PaletteModeManager.Office2010Silver:
				return PaletteOffice2010Silver;
			case PaletteModeManager.Office2010Black:
				return PaletteOffice2010Black;
			case PaletteModeManager.SparkleBlue:
				return PaletteSparkleBlue;
			case PaletteModeManager.SparkleOrange:
				return PaletteSparkleOrange;
			case PaletteModeManager.SparklePurple:
				return PaletteSparklePurple;
			case PaletteModeManager.Custom:
				return _globalPalette;
			default:
				Debug.Assert(condition: false);
				return null;
			}
		}
	}

	public static PaletteProfessionalSystem PaletteProfessionalSystem
	{
		get
		{
			if (_paletteProfessionalSystem == null)
			{
				_paletteProfessionalSystem = new PaletteProfessionalSystem();
			}
			return _paletteProfessionalSystem;
		}
	}

	public static PaletteProfessionalOffice2003 PaletteProfessionalOffice2003
	{
		get
		{
			if (_paletteProfessionalOffice2003 == null)
			{
				_paletteProfessionalOffice2003 = new PaletteProfessionalOffice2003();
			}
			return _paletteProfessionalOffice2003;
		}
	}

	public static PaletteOffice2007Blue PaletteOffice2007Blue
	{
		get
		{
			if (_paletteOffice2007Blue == null)
			{
				_paletteOffice2007Blue = new PaletteOffice2007Blue();
			}
			return _paletteOffice2007Blue;
		}
	}

	public static PaletteOffice2007Silver PaletteOffice2007Silver
	{
		get
		{
			if (_paletteOffice2007Silver == null)
			{
				_paletteOffice2007Silver = new PaletteOffice2007Silver();
			}
			return _paletteOffice2007Silver;
		}
	}

	public static PaletteOffice2007Black PaletteOffice2007Black
	{
		get
		{
			if (_paletteOffice2007Black == null)
			{
				_paletteOffice2007Black = new PaletteOffice2007Black();
			}
			return _paletteOffice2007Black;
		}
	}

	public static PaletteOffice2010Blue PaletteOffice2010Blue
	{
		get
		{
			if (_paletteOffice2010Blue == null)
			{
				_paletteOffice2010Blue = new PaletteOffice2010Blue();
			}
			return _paletteOffice2010Blue;
		}
	}

	public static PaletteOffice2010Silver PaletteOffice2010Silver
	{
		get
		{
			if (_paletteOffice2010Silver == null)
			{
				_paletteOffice2010Silver = new PaletteOffice2010Silver();
			}
			return _paletteOffice2010Silver;
		}
	}

	public static PaletteOffice2010Black PaletteOffice2010Black
	{
		get
		{
			if (_paletteOffice2010Black == null)
			{
				_paletteOffice2010Black = new PaletteOffice2010Black();
			}
			return _paletteOffice2010Black;
		}
	}

	public static PaletteSparkleBlue PaletteSparkleBlue
	{
		get
		{
			if (_paletteSparkleBlue == null)
			{
				_paletteSparkleBlue = new PaletteSparkleBlue();
			}
			return _paletteSparkleBlue;
		}
	}

	public static PaletteSparkleOrange PaletteSparkleOrange
	{
		get
		{
			if (_paletteSparkleOrange == null)
			{
				_paletteSparkleOrange = new PaletteSparkleOrange();
			}
			return _paletteSparkleOrange;
		}
	}

	public static PaletteSparklePurple PaletteSparklePurple
	{
		get
		{
			if (_paletteSparklePurple == null)
			{
				_paletteSparklePurple = new PaletteSparklePurple();
			}
			return _paletteSparklePurple;
		}
	}

	public static RenderSparkle RenderSparkle
	{
		get
		{
			if (_renderSparkle == null)
			{
				_renderSparkle = new RenderSparkle();
			}
			return _renderSparkle;
		}
	}

	public static RenderOffice2007 RenderOffice2007
	{
		get
		{
			if (_renderOffice2007 == null)
			{
				_renderOffice2007 = new RenderOffice2007();
			}
			return _renderOffice2007;
		}
	}

	public static RenderOffice2010 RenderOffice2010
	{
		get
		{
			if (_renderOffice2010 == null)
			{
				_renderOffice2010 = new RenderOffice2010();
			}
			return _renderOffice2010;
		}
	}

	public static RenderProfessional RenderProfessional
	{
		get
		{
			if (_renderProfessional == null)
			{
				_renderProfessional = new RenderProfessional();
			}
			return _renderProfessional;
		}
	}

	public static RenderStandard RenderStandard
	{
		get
		{
			if (_renderStandard == null)
			{
				_renderStandard = new RenderStandard();
			}
			return _renderProfessional;
		}
	}

	internal static PaletteModeManager InternalGlobalPaletteMode => _globalPaletteMode;

	internal static IPalette InternalGlobalPalette => _globalPalette;

	[Category("Property Changed")]
	[Description("Occurs when the value of the GlobalPalette property is changed.")]
	public static event EventHandler GlobalPaletteChanged;

	[Category("Property Changed")]
	[Description("Occurs when the value of the GlobalAllowFormChrome property is changed.")]
	public static event EventHandler GlobalAllowFormChromeChanged;

	static KryptonManager()
	{
		_globalApplyToolstrips = true;
		_globalAllowFormChrome = true;
		_globalStrings = new GlobalStrings();
		_globalPaletteMode = PaletteModeManager.Office2010Blue;
		_globalPalette = CurrentGlobalPalette;
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
		UpdateToolStripManager();
	}

	public KryptonManager()
	{
	}

	public KryptonManager(IContainer container)
		: this()
	{
		Debug.Assert(container != null);
		if (container == null)
		{
			throw new ArgumentNullException("container");
		}
		container.Add(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeGlobalPaletteMode()
	{
		return GlobalPaletteMode != PaletteModeManager.Office2010Blue;
	}

	public void ResetGlobalPaletteMode()
	{
		GlobalPaletteMode = PaletteModeManager.Office2010Blue;
	}

	public void ResetGlobalPalette()
	{
		GlobalPaletteMode = PaletteModeManager.Office2010Blue;
	}

	private bool ShouldSerializeGlobalApplyToolstrips()
	{
		return !GlobalApplyToolstrips;
	}

	public void ResetGlobalApplyToolstrips()
	{
		GlobalApplyToolstrips = true;
	}

	private bool ShouldSerializeGlobalAllowFormChrome()
	{
		return !GlobalAllowFormChrome;
	}

	public void ResetGlobalAllowFormChrome()
	{
		GlobalAllowFormChrome = true;
	}

	private bool ShouldSerializeGlobalStrings()
	{
		return !_globalStrings.IsDefault;
	}

	public void ResetGlobalStrings()
	{
		_globalStrings.Reset();
	}

	public static IPalette GetPaletteForMode(PaletteMode mode)
	{
		switch (mode)
		{
		case PaletteMode.ProfessionalSystem:
			return PaletteProfessionalSystem;
		case PaletteMode.ProfessionalOffice2003:
			return PaletteProfessionalOffice2003;
		case PaletteMode.Office2007Blue:
			return PaletteOffice2007Blue;
		case PaletteMode.Office2007Silver:
			return PaletteOffice2007Silver;
		case PaletteMode.Office2007Black:
			return PaletteOffice2007Black;
		case PaletteMode.Office2010Blue:
			return PaletteOffice2010Blue;
		case PaletteMode.Office2010Silver:
			return PaletteOffice2010Silver;
		case PaletteMode.Office2010Black:
			return PaletteOffice2010Black;
		case PaletteMode.SparkleBlue:
			return PaletteSparkleBlue;
		case PaletteMode.SparkleOrange:
			return PaletteSparkleOrange;
		case PaletteMode.SparklePurple:
			return PaletteSparklePurple;
		case PaletteMode.Global:
			return CurrentGlobalPalette;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	public static IRenderer GetRendererForMode(RendererMode mode)
	{
		switch (mode)
		{
		case RendererMode.Sparkle:
			return RenderSparkle;
		case RendererMode.Office2007:
			return RenderOffice2007;
		case RendererMode.Professional:
			return RenderProfessional;
		case RendererMode.Standard:
			return RenderStandard;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	internal static bool HasCircularReference()
	{
		Dictionary<IPalette, bool> dictionary = new Dictionary<IPalette, bool>();
		IPalette palette = null;
		if (InternalGlobalPaletteMode == PaletteModeManager.Custom)
		{
			palette = InternalGlobalPalette;
		}
		while (palette != null)
		{
			if (dictionary.ContainsKey(palette))
			{
				return true;
			}
			dictionary.Add(palette, value: true);
			if (palette is KryptonPalette)
			{
				KryptonPalette kryptonPalette = (KryptonPalette)palette;
				palette = ((kryptonPalette.BasePaletteMode != PaletteMode.Custom) ? ((kryptonPalette.BasePaletteMode != PaletteMode.Global) ? null : InternalGlobalPalette) : kryptonPalette.BasePalette);
			}
			else
			{
				palette = null;
			}
		}
		return false;
	}

	private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		if (_paletteProfessionalOffice2003 != null)
		{
			_paletteProfessionalOffice2003.UserPreferenceChanged();
		}
		if (_paletteProfessionalSystem != null)
		{
			_paletteProfessionalSystem.UserPreferenceChanged();
		}
		if (_paletteOffice2007Blue != null)
		{
			_paletteOffice2007Blue.UserPreferenceChanged();
		}
		if (_paletteOffice2007Silver != null)
		{
			_paletteOffice2007Silver.UserPreferenceChanged();
		}
		if (_paletteOffice2007Black != null)
		{
			_paletteOffice2007Black.UserPreferenceChanged();
		}
		if (_paletteOffice2010Blue != null)
		{
			_paletteOffice2010Blue.UserPreferenceChanged();
		}
		if (_paletteOffice2010Silver != null)
		{
			_paletteOffice2010Silver.UserPreferenceChanged();
		}
		if (_paletteOffice2010Black != null)
		{
			_paletteOffice2010Black.UserPreferenceChanged();
		}
		if (_paletteSparkleBlue != null)
		{
			_paletteSparkleBlue.UserPreferenceChanged();
		}
		if (_paletteSparkleOrange != null)
		{
			_paletteSparkleOrange.UserPreferenceChanged();
		}
		if (_paletteSparklePurple != null)
		{
			_paletteSparklePurple.UserPreferenceChanged();
		}
		UpdateToolStripManager();
	}

	private static void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
	{
		if (e.NeedColorTable)
		{
			UpdateToolStripManager();
		}
	}

	private static void SetPalette(IPalette globalPalette)
	{
		if (globalPalette != _globalPalette)
		{
			if (_globalPalette != null)
			{
				_globalPalette.PalettePaint -= OnPalettePaint;
			}
			_globalPalette = globalPalette;
			if (_globalPalette != null)
			{
				_globalPalette.PalettePaint += OnPalettePaint;
			}
		}
	}

	private static void OnGlobalAllowFormChromeChanged(EventArgs e)
	{
		if (KryptonManager.GlobalAllowFormChromeChanged != null)
		{
			KryptonManager.GlobalAllowFormChromeChanged(null, e);
		}
	}

	private static void OnGlobalPaletteChanged(EventArgs e)
	{
		UpdateToolStripManager();
		if (KryptonManager.GlobalPaletteChanged != null)
		{
			KryptonManager.GlobalPaletteChanged(null, e);
		}
	}

	private static void UpdateToolStripManager()
	{
		if (_globalApplyToolstrips)
		{
			ToolStripManager.Renderer = _globalPalette.GetRenderer().RenderToolStrip(_globalPalette);
		}
	}

	private static void ResetToolStripManager()
	{
		ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
	}
}
