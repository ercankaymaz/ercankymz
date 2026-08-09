using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuSeparator), "ToolboxBitmaps.KryptonContextMenuSeparator.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Horizontal")]
public class KryptonContextMenuSeparator : KryptonContextMenuItemBase
{
	private bool _horizontal;

	private PaletteDoubleRedirect _stateNormal;

	private PaletteRedirectDouble _redirectSeparator;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Is this a horizontal or vertical break in the menu.")]
	[DefaultValue(true)]
	public bool Horizontal
	{
		get
		{
			return _horizontal;
		}
		set
		{
			if (_horizontal != value)
			{
				_horizontal = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Horizontal"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining separator instance specific appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect StateNormal => _stateNormal;

	public KryptonContextMenuSeparator()
	{
		_horizontal = true;
		_redirectSeparator = new PaletteRedirectDouble();
		_stateNormal = new PaletteDoubleRedirect(_redirectSeparator, PaletteBackStyle.ContextMenuSeparator, PaletteBorderStyle.ContextMenuSeparator);
	}

	public override string ToString()
	{
		return "(Separator)";
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		if (Horizontal && parent is KryptonContextMenuItemCollection)
		{
			ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
			ViewDrawContent item = new ViewDrawContent(provider.ProviderStateCommon.ItemImage.Content, new FixedContentValue(null, null, null, Color.Empty), VisualOrientation.Top);
			ViewDrawMenuImageCanvas viewDrawMenuImageCanvas = new ViewDrawMenuImageCanvas(provider.ProviderStateCommon.ItemImage.Back, provider.ProviderStateCommon.ItemImage.Border, 0, zeroHeight: true);
			viewDrawMenuImageCanvas.Add(item);
			viewLayoutDocker.Add(new ViewLayoutCenter(viewDrawMenuImageCanvas), ViewDockStyle.Left);
			viewLayoutDocker.Add(new ViewLayoutSeparator(1, 0), ViewDockStyle.Left);
			viewLayoutDocker.Add(new ViewLayoutMenuSepGap(provider.ProviderStateCommon, standardStyle), ViewDockStyle.Left);
			ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: false);
			viewLayoutStack.Add(new ViewLayoutSeparator(1, 1));
			viewLayoutStack.Add(new ViewDrawMenuSeparator(this, provider.ProviderStateCommon.Separator));
			viewLayoutStack.Add(new ViewLayoutSeparator(1, 1));
			viewLayoutDocker.Add(viewLayoutStack, ViewDockStyle.Fill);
			return viewLayoutDocker;
		}
		return new ViewDrawMenuSeparator(this, provider.ProviderStateCommon.Separator);
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	internal void SetPaletteRedirect(PaletteDoubleRedirect redirector)
	{
		_redirectSeparator.SetRedirectStates(redirector, redirector);
	}
}
