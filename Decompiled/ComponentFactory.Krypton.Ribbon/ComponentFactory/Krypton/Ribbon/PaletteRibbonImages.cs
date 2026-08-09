#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonImages : Storage
{
	private PaletteRedirectCheckBox _redirectCheckBox;

	private PaletteRedirectRadioButton _redirectRadioButton;

	private CheckBoxImages _imagesCheckBox;

	private RadioButtonImages _imagesRadioButton;

	[Browsable(false)]
	public override bool IsDefault => _imagesCheckBox.IsDefault && _imagesRadioButton.IsDefault;

	[Category("Values")]
	[Description("Ribbon check box images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CheckBoxImages CheckBox => _imagesCheckBox;

	[Category("Values")]
	[Description("Ribbon radio button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RadioButtonImages RadioButton => _imagesRadioButton;

	internal PaletteRedirectCheckBox InternalCheckBox => _redirectCheckBox;

	internal PaletteRedirectRadioButton InternalRadioButton => _redirectRadioButton;

	public PaletteRibbonImages(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		Debug.Assert(needPaint != null);
		_imagesCheckBox = new CheckBoxImages(needPaint);
		_imagesRadioButton = new RadioButtonImages(needPaint);
		_redirectCheckBox = new PaletteRedirectCheckBox(redirect, _imagesCheckBox);
		_redirectRadioButton = new PaletteRedirectRadioButton(redirect, _imagesRadioButton);
	}

	private bool ShouldSerializeCheckBox()
	{
		return !_imagesCheckBox.IsDefault;
	}

	private bool ShouldSerializeRadioButton()
	{
		return !_imagesRadioButton.IsDefault;
	}
}
