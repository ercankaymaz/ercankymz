using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTextBoxActionList : DesignerActionList
{
	private KryptonTextBox _textBox;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _textBox.PaletteMode;
		}
		set
		{
			if (_textBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_textBox, null, _textBox.PaletteMode, value);
				_textBox.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _textBox.InputControlStyle;
		}
		set
		{
			if (_textBox.InputControlStyle != value)
			{
				_service.OnComponentChanged(_textBox, null, _textBox.InputControlStyle, value);
				_textBox.InputControlStyle = value;
			}
		}
	}

	public bool Multiline
	{
		get
		{
			return _textBox.Multiline;
		}
		set
		{
			if (_textBox.Multiline != value)
			{
				_service.OnComponentChanged(_textBox, null, _textBox.Multiline, value);
				_textBox.Multiline = value;
			}
		}
	}

	public bool WordWrap
	{
		get
		{
			return _textBox.WordWrap;
		}
		set
		{
			if (_textBox.WordWrap != value)
			{
				_service.OnComponentChanged(_textBox, null, _textBox.WordWrap, value);
				_textBox.WordWrap = value;
			}
		}
	}

	public bool UseSystemPasswordChar
	{
		get
		{
			return _textBox.UseSystemPasswordChar;
		}
		set
		{
			if (_textBox.UseSystemPasswordChar != value)
			{
				_service.OnComponentChanged(_textBox, null, _textBox.UseSystemPasswordChar, value);
				_textBox.UseSystemPasswordChar = value;
			}
		}
	}

	public KryptonTextBoxActionList(KryptonTextBoxDesigner owner)
		: base(owner.Component)
	{
		_textBox = owner.Component as KryptonTextBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_textBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "TextBox display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("TextBox"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Multiline", "Multiline", "TextBox", "Should text span multiple lines."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("WordWrap", "WordWrap", "TextBox", "Should words be wrapped over multiple lines."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("UseSystemPasswordChar", "UseSystemPasswordChar", "TextBox", "Should characters be displayed in password characters."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}
