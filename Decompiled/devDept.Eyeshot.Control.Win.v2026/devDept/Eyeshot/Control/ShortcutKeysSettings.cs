using System;
using System.ComponentModel;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(ShortcutKeysSettingsConverter))]
public class ShortcutKeysSettings
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Select all shortcut.")]
	public Keys SelectAll { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Invert selection.")]
	public Keys InvertSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Delete selection shortcut.")]
	public Keys DeleteSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description(" shortcut.")]
	public Keys ZoomFit { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Copy selection shortcut.")]
	public Keys CopySelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Paste selection shortcut.")]
	public Keys PasteSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Cut selection shortcut.")]
	public Keys CutSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Group selection shortcut.")]
	public Keys GroupSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Ungroup selection shortcut.")]
	public Keys UngroupSelection { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom in shortcut.")]
	public Keys ZoomIn { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom out shortcut.")]
	public Keys ZoomOut { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotate right shortcut.")]
	public Keys RotateRight { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotate up shortcut.")]
	public Keys RotateUp { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotate left shortcut.")]
	public Keys RotateLeft { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotate down shortcut.")]
	public Keys RotateDown { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pan right shortcut.")]
	public Keys PanRight { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pan up shortcut.")]
	public Keys PanUp { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pan left shortcut.")]
	public Keys PanLeft { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pan down shortcut.")]
	public Keys PanDown { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Cancel background work shortcut.")]
	public Keys CancelBackgroundWork { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Right navigation movement shortcut.")]
	public Keys NavigationRight { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Left navigation movement shortcut.")]
	public Keys NavigationLeft { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Up navigation movement shortcut.")]
	public Keys NavigationUp { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Down navigation movement shortcut.")]
	public Keys NavigationDown { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Forward navigation movement shortcut.")]
	public Keys NavigationForward { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Backward navigation movement shortcut.")]
	public Keys NavigationBackward { get; set; }

	public ShortcutKeysSettings()
		: this(_0023_003DzT_0024x_0024RUuh3Jpr(), _0023_003DzOJqIJTgECebf(), _0023_003DznURqjHEyE40t(), _0023_003DzUeUD0pKM9762(), _0023_003DzXk8yWxsNGZUe(), _0023_003DzzLMq5_0024TmLT_2(), _0023_003DzIDIcflBVehJX(), _0023_003DzNijeqVt32DaH(), _0023_003DzY1mr5DIiMPdc(), _0023_003Dz_00244J8D5xsQW99(), _0023_003DzRxfj_0024Hag7JUJ(), _0023_003DzqPEqZ0KL26e0(), _0023_003DzCpgyC_i_0024U1qS(), _0023_003DzX_TC8a8lwOF7(), _0023_003DzhLuKYHl4SOcx(), _0023_003DzIcv_vZgo_omM(), _0023_003Dzjl0fisAlIIlY(), _0023_003DztDnIWZH3HNq4(), _0023_003DzCdMMvifXPUxM(), _0023_003DzIolDsyamzvdg3tUbbg_003D_003D(), _0023_003DzVr1QI9FQRAp7(), _0023_003DzK37uPxuPuLa7(), _0023_003Dz8qzXzflFQymZ(), _0023_003Dz6jM0QAbePpQg(), _0023_003DzLMwj0PuZBQ0m(), _0023_003Dz4i8giEmJKJf8())
	{
	}

	public ShortcutKeysSettings(Keys selectAll, Keys invertSelection, Keys deleteSelection, Keys zoomFit, Keys zoomIn, Keys zoomOut, Keys copySelection, Keys pasteSelection, Keys cutSelection, Keys groupSelection, Keys ungroupSelection, Keys rotateRight, Keys rotateUp, Keys rotateLeft, Keys rotateDown, Keys panRight, Keys panUp, Keys panLeft, Keys panDown, Keys cancelBackgroundWork)
		: this(selectAll, invertSelection, deleteSelection, zoomFit, zoomIn, zoomOut, copySelection, pasteSelection, cutSelection, groupSelection, ungroupSelection, rotateRight, rotateUp, rotateLeft, rotateDown, panRight, panUp, panLeft, panDown, cancelBackgroundWork, _0023_003DzVr1QI9FQRAp7(), _0023_003DzK37uPxuPuLa7(), _0023_003Dz8qzXzflFQymZ(), _0023_003Dz6jM0QAbePpQg(), _0023_003DzLMwj0PuZBQ0m(), _0023_003Dz4i8giEmJKJf8())
	{
	}

	public ShortcutKeysSettings(Keys selectAll, Keys invertSelection, Keys deleteSelection, Keys zoomFit, Keys zoomIn, Keys zoomOut, Keys copySelection, Keys pasteSelection, Keys cutSelection, Keys groupSelection, Keys ungroupSelection, Keys rotateRight, Keys rotateUp, Keys rotateLeft, Keys rotateDown, Keys panRight, Keys panUp, Keys panLeft, Keys panDown, Keys cancelBackgroundWork, Keys navigationRight, Keys navigationLeft, Keys navigationUp, Keys navigationDown, Keys navigationForward, Keys navigationBackward)
	{
		SelectAll = selectAll;
		InvertSelection = invertSelection;
		DeleteSelection = deleteSelection;
		ZoomFit = zoomFit;
		ZoomIn = zoomIn;
		ZoomOut = zoomOut;
		CopySelection = copySelection;
		PasteSelection = pasteSelection;
		CutSelection = cutSelection;
		GroupSelection = groupSelection;
		UngroupSelection = ungroupSelection;
		RotateRight = rotateRight;
		RotateUp = rotateUp;
		RotateLeft = rotateLeft;
		RotateDown = rotateDown;
		PanRight = panRight;
		PanUp = panUp;
		PanLeft = panLeft;
		PanDown = panDown;
		CancelBackgroundWork = cancelBackgroundWork;
		NavigationRight = navigationRight;
		NavigationLeft = navigationLeft;
		NavigationForward = navigationForward;
		NavigationBackward = navigationBackward;
		NavigationUp = navigationUp;
		NavigationDown = navigationDown;
	}

	private static Keys _0023_003DzT_0024x_0024RUuh3Jpr()
	{
		return Keys.A | Keys.Control;
	}

	private static Keys _0023_003DzOJqIJTgECebf()
	{
		return Keys.I | Keys.Control;
	}

	private static Keys _0023_003DznURqjHEyE40t()
	{
		return Keys.Delete;
	}

	private static Keys _0023_003DzUeUD0pKM9762()
	{
		return Keys.F | Keys.Control;
	}

	private static Keys _0023_003DzXk8yWxsNGZUe()
	{
		return Keys.Add | Keys.Control;
	}

	private static Keys _0023_003DzzLMq5_0024TmLT_2()
	{
		return Keys.Subtract | Keys.Control;
	}

	private static Keys _0023_003DzIDIcflBVehJX()
	{
		return Keys.C | Keys.Control;
	}

	private static Keys _0023_003DzNijeqVt32DaH()
	{
		return Keys.V | Keys.Control;
	}

	private static Keys _0023_003DzY1mr5DIiMPdc()
	{
		return Keys.X | Keys.Control;
	}

	private static Keys _0023_003Dz_00244J8D5xsQW99()
	{
		return Keys.G | Keys.Control;
	}

	private static Keys _0023_003DzRxfj_0024Hag7JUJ()
	{
		return Keys.G | Keys.Shift | Keys.Control;
	}

	private static Keys _0023_003DzqPEqZ0KL26e0()
	{
		return Keys.Right;
	}

	private static Keys _0023_003DzCpgyC_i_0024U1qS()
	{
		return Keys.Up;
	}

	private static Keys _0023_003DzX_TC8a8lwOF7()
	{
		return Keys.Left;
	}

	private static Keys _0023_003DzhLuKYHl4SOcx()
	{
		return Keys.Down;
	}

	private static Keys _0023_003DzIcv_vZgo_omM()
	{
		return Keys.Right | Keys.Control;
	}

	private static Keys _0023_003Dzjl0fisAlIIlY()
	{
		return Keys.Up | Keys.Control;
	}

	private static Keys _0023_003DztDnIWZH3HNq4()
	{
		return Keys.Left | Keys.Control;
	}

	private static Keys _0023_003DzCdMMvifXPUxM()
	{
		return Keys.Down | Keys.Control;
	}

	private static Keys _0023_003DzIolDsyamzvdg3tUbbg_003D_003D()
	{
		return Keys.Escape;
	}

	private static Keys _0023_003DzVr1QI9FQRAp7()
	{
		return Keys.D;
	}

	private static Keys _0023_003DzK37uPxuPuLa7()
	{
		return Keys.A;
	}

	private static Keys _0023_003Dz8qzXzflFQymZ()
	{
		return Keys.E;
	}

	private static Keys _0023_003Dz6jM0QAbePpQg()
	{
		return Keys.Q;
	}

	private static Keys _0023_003DzLMwj0PuZBQ0m()
	{
		return Keys.W;
	}

	private static Keys _0023_003Dz4i8giEmJKJf8()
	{
		return Keys.S;
	}

	internal virtual bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (SelectAll == _0023_003DzT_0024x_0024RUuh3Jpr() && InvertSelection == _0023_003DzOJqIJTgECebf() && DeleteSelection == _0023_003DznURqjHEyE40t() && ZoomFit == _0023_003DzUeUD0pKM9762() && ZoomIn == _0023_003DzXk8yWxsNGZUe() && ZoomOut == _0023_003DzzLMq5_0024TmLT_2() && CopySelection == _0023_003DzIDIcflBVehJX() && PasteSelection == _0023_003DzNijeqVt32DaH() && CutSelection == _0023_003DzY1mr5DIiMPdc() && GroupSelection == _0023_003Dz_00244J8D5xsQW99() && UngroupSelection == _0023_003DzRxfj_0024Hag7JUJ() && RotateRight == _0023_003DzqPEqZ0KL26e0() && RotateUp == _0023_003DzCpgyC_i_0024U1qS() && RotateLeft == _0023_003DzX_TC8a8lwOF7() && RotateDown == _0023_003DzhLuKYHl4SOcx() && PanRight == _0023_003DzIcv_vZgo_omM() && PanUp == _0023_003Dzjl0fisAlIIlY() && PanLeft == _0023_003DztDnIWZH3HNq4() && PanDown == _0023_003DzCdMMvifXPUxM() && CancelBackgroundWork == _0023_003DzIolDsyamzvdg3tUbbg_003D_003D() && NavigationRight == _0023_003DzVr1QI9FQRAp7() && NavigationLeft == _0023_003DzK37uPxuPuLa7() && NavigationUp == _0023_003Dz8qzXzflFQymZ() && NavigationDown == _0023_003Dz6jM0QAbePpQg() && NavigationForward == _0023_003DzLMwj0PuZBQ0m())
		{
			return NavigationBackward != _0023_003Dz4i8giEmJKJf8();
		}
		return true;
	}
}
