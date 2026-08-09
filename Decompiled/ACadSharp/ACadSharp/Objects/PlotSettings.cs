using System;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("PLOTSETTINGS")]
[DxfSubClass("AcDbPlotSettings")]
public class PlotSettings : NonGraphicalObject
{
	private double _denominatorScale = 1.0;

	private double _numeratorScale = 1.0;

	private short _shadePlotDPI = 300;

	[DxfCodeValue(new int[] { 143 })]
	public double DenominatorScale
	{
		get
		{
			return _denominatorScale;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("DenominatorScale", value, "Value must be greater than zero");
			}
			_denominatorScale = value;
		}
	}

	[DxfCodeValue(new int[] { 70 })]
	public PlotFlags Flags { get; set; } = PlotFlags.UseStandardScale | PlotFlags.PlotPlotStyles | PlotFlags.PrintLineweights | PlotFlags.DrawViewportsFirst;

	[DxfCodeValue(new int[] { 142 })]
	public double NumeratorScale
	{
		get
		{
			return _numeratorScale;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("NumeratorScale", value, "Value must be greater than zero");
			}
			_numeratorScale = value;
		}
	}

	public override string ObjectName => "PLOTSETTINGS";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 1 })]
	public string PageName { get; set; } = "none_device";

	[DxfCodeValue(new int[] { 45 })]
	public double PaperHeight { get; set; }

	public XY PaperImageOrigin { get; set; }

	[DxfCodeValue(new int[] { 148 })]
	public double PaperImageOriginX { get; set; }

	[DxfCodeValue(new int[] { 149 })]
	public double PaperImageOriginY { get; set; }

	[DxfCodeValue(new int[] { 73 })]
	public PlotRotation PaperRotation { get; set; }

	[DxfCodeValue(new int[] { 4 })]
	public string PaperSize { get; set; } = "ISO_A4_(210.00_x_297.00_MM)";

	[DxfCodeValue(new int[] { 72 })]
	public PlotPaperUnits PaperUnits { get; set; } = PlotPaperUnits.Millimeters;

	[DxfCodeValue(new int[] { 44 })]
	public double PaperWidth { get; set; }

	[DxfCodeValue(new int[] { 46 })]
	public double PlotOriginX { get; set; }

	[DxfCodeValue(new int[] { 47 })]
	public double PlotOriginY { get; set; }

	[DxfCodeValue(new int[] { 74 })]
	public PlotType PlotType { get; set; } = PlotType.DrawingExtents;

	[DxfCodeValue(new int[] { 6 })]
	public string PlotViewName { get; set; }

	public double PrintScale => NumeratorScale / DenominatorScale;

	[DxfCodeValue(new int[] { 75 })]
	public ScaledType ScaledFit { get; set; }

	[DxfCodeValue(new int[] { 78 })]
	public short ShadePlotDPI
	{
		get
		{
			return _shadePlotDPI;
		}
		set
		{
			if (value < 100 || value > short.MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", value, "The valid shade plot DPI values range from 100 to 23767.");
			}
			_shadePlotDPI = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 333 })]
	public ulong ShadePlotIDHandle { get; set; }

	[DxfCodeValue(new int[] { 76 })]
	public ShadePlotMode ShadePlotMode { get; set; }

	[DxfCodeValue(new int[] { 77 })]
	public ShadePlotResolutionMode ShadePlotResolutionMode { get; set; }

	[DxfCodeValue(new int[] { 147 })]
	public double StandardScale { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 7 })]
	public string StyleSheet { get; set; }

	public override string SubclassMarker => "AcDbPlotSettings";

	[DxfCodeValue(new int[] { 2 })]
	public string SystemPrinterName { get; set; }

	[DxfCodeValue(new int[] { 40, 41, 42, 43 })]
	public PaperMargin UnprintableMargin { get; set; }

	[DxfCodeValue(new int[] { 48 })]
	public double WindowLowerLeftX { get; set; }

	[DxfCodeValue(new int[] { 49 })]
	public double WindowLowerLeftY { get; set; }

	[DxfCodeValue(new int[] { 140 })]
	public double WindowUpperLeftX { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double WindowUpperLeftY { get; set; }

	public PlotSettings()
	{
	}

	public PlotSettings(string name)
		: base(name)
	{
	}
}
