#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteGrids : Storage
{
	private KryptonPaletteGrid _gridCommon;

	private KryptonPaletteGrid _gridList;

	private KryptonPaletteGrid _gridSheet;

	private KryptonPaletteGrid _gridCustom1;

	public override bool IsDefault => _gridCommon.IsDefault && _gridList.IsDefault && _gridSheet.IsDefault && _gridCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteGrid GridCommon => _gridCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining list grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteGrid GridList => _gridList;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining sheet grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteGrid GridSheet => _gridSheet;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteGrid GridCustom1 => _gridCustom1;

	internal KryptonPaletteGrids(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_gridCommon = new KryptonPaletteGrid(redirector, GridStyle.List, needPaint);
		_gridList = new KryptonPaletteGrid(redirector, GridStyle.List, needPaint);
		_gridSheet = new KryptonPaletteGrid(redirector, GridStyle.Sheet, needPaint);
		_gridCustom1 = new KryptonPaletteGrid(redirector, GridStyle.Custom1, needPaint);
		PaletteRedirectGrids redirector2 = new PaletteRedirectGrids(redirector, _gridCommon);
		_gridList.SetRedirector(redirector2);
		_gridSheet.SetRedirector(redirector2);
		_gridCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		_gridList.PopulateFromBase(common, GridStyle.List);
		_gridSheet.PopulateFromBase(common, GridStyle.Sheet);
	}

	private bool ShouldSerializeGridCommon()
	{
		return !_gridCommon.IsDefault;
	}

	private bool ShouldSerializeGridList()
	{
		return !_gridList.IsDefault;
	}

	private bool ShouldSerializeGridSheet()
	{
		return !_gridSheet.IsDefault;
	}

	private bool ShouldSerializeGridCustom1()
	{
		return !_gridCustom1.IsDefault;
	}
}
