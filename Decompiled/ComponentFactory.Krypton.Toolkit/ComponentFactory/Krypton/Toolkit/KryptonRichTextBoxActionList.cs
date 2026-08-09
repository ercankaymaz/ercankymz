using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonRichTextBoxActionList : DesignerActionList
{
	private KryptonRichTextBox _richTextBox;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _richTextBox.PaletteMode;
		}
		set
		{
			if (_richTextBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_richTextBox, null, _richTextBox.PaletteMode, value);
				_richTextBox.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _richTextBox.InputControlStyle;
		}
		set
		{
			if (_richTextBox.InputControlStyle != value)
			{
				_service.OnComponentChanged(_richTextBox, null, _richTextBox.InputControlStyle, value);
				_richTextBox.InputControlStyle = value;
			}
		}
	}

	public bool Multiline
	{
		get
		{
			return _richTextBox.Multiline;
		}
		set
		{
			if (_richTextBox.Multiline != value)
			{
				_service.OnComponentChanged(_richTextBox, null, _richTextBox.Multiline, value);
				_richTextBox.Multiline = value;
			}
		}
	}

	public bool WordWrap
	{
		get
		{
			return _richTextBox.WordWrap;
		}
		set
		{
			if (_richTextBox.WordWrap != value)
			{
				_service.OnComponentChanged(_richTextBox, null, _richTextBox.WordWrap, value);
				_richTextBox.WordWrap = value;
			}
		}
	}

	public KryptonRichTextBoxActionList(KryptonRichTextBoxDesigner owner)
		: base(owner.Component)
	{
		_richTextBox = owner.Component as KryptonRichTextBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_richTextBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "TextBox display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("TextBox"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Multiline", "Multiline", "TextBox", "Should text span multiple lines."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("WordWrap", "WordWrap", "TextBox", "Should words be wrapped over multiple lines."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}
