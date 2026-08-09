using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuItems), "ToolboxBitmaps.KryptonContextMenuItems.bmp")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemsDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Items")]
public class KryptonContextMenuItems : KryptonContextMenuItemBase
{
	private bool _standardStyle;

	private bool _imageColumn;

	private KryptonContextMenuItemCollection _items;

	private PaletteDoubleRedirect _stateNormal;

	private PaletteRedirectDouble _redirectImageColumn;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => Items.Count;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => Items[index];

	[Category("Data")]
	[Description("Collection of standard menu items.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemCollectionEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public KryptonContextMenuItemCollection Items => _items;

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Determines if collection appears as standard or alternate items.")]
	[DefaultValue(true)]
	public bool StandardStyle
	{
		get
		{
			return _standardStyle;
		}
		set
		{
			if (_standardStyle != value)
			{
				_standardStyle = value;
				OnPropertyChanged(new PropertyChangedEventArgs("StandardStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Determines if an image column is provided for background of images.")]
	[DefaultValue(true)]
	public bool ImageColumn
	{
		get
		{
			return _imageColumn;
		}
		set
		{
			if (_imageColumn != value)
			{
				_imageColumn = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageColumn"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining image column specific appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect StateNormal => _stateNormal;

	public KryptonContextMenuItems()
		: this(null)
	{
	}

	public KryptonContextMenuItems(KryptonContextMenuItemBase[] children)
	{
		_standardStyle = true;
		_imageColumn = true;
		_items = new KryptonContextMenuItemCollection();
		if (children != null)
		{
			_items.AddRange(children);
		}
		_redirectImageColumn = new PaletteRedirectDouble();
		_stateNormal = new PaletteDoubleRedirect(_redirectImageColumn, PaletteBackStyle.ContextMenuItemImageColumn, PaletteBorderStyle.ContextMenuItemImageColumn);
	}

	public override string ToString()
	{
		return "(Items)";
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return Items.ProcessShortcut(keyData);
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: true);
		Items.GenerateView(provider, this, this, viewLayoutStack, StandardStyle, ImageColumn);
		return viewLayoutStack;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	internal void SetPaletteRedirect(PaletteDoubleRedirect redirector)
	{
		_redirectImageColumn.SetRedirectStates(redirector, redirector);
	}
}
