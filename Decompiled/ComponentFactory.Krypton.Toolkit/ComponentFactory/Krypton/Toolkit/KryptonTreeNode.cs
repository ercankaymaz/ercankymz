using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class KryptonTreeNode : TreeNode
{
	private string _longText;

	private Color _longForeColor;

	private Font _longNodeFont;

	[Category("Appearance")]
	[Description("Supplementary text.")]
	[Localizable(true)]
	public string LongText
	{
		get
		{
			return _longText;
		}
		set
		{
			if (_longText != value)
			{
				_longText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LongText"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Foreground color of the long text")]
	public Color LongForeColor
	{
		get
		{
			return _longForeColor;
		}
		set
		{
			if (_longForeColor != value)
			{
				_longForeColor = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LongForeColor"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Font of the long text")]
	public Font LongNodeFont
	{
		get
		{
			return _longNodeFont;
		}
		set
		{
			if (_longNodeFont != value)
			{
				_longNodeFont = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LongNodeFont"));
			}
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonTreeNode()
	{
		Init();
	}

	public KryptonTreeNode(string text)
		: base(text)
	{
		Init();
	}

	public KryptonTreeNode(string text, TreeNode[] children)
		: base(text, children)
	{
		Init();
	}

	public KryptonTreeNode(string text, int imageIndex, int selectedImageIndex)
		: base(text, imageIndex, selectedImageIndex)
	{
		Init();
	}

	public KryptonTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
		: base(text, imageIndex, selectedImageIndex, children)
	{
		Init();
	}

	private void Init()
	{
		_longText = string.Empty;
		_longForeColor = Color.Empty;
		_longNodeFont = null;
	}

	private bool ShouldSerializeLongText()
	{
		return !string.IsNullOrEmpty(_longText);
	}

	private bool ShouldSerializeLongForeColor()
	{
		return _longForeColor != Color.Empty;
	}

	private bool ShouldSerializeLongNodeFont()
	{
		return _longNodeFont != null;
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}
}
