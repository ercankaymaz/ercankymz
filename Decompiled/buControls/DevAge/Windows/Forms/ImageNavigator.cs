using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class ImageNavigator : UserControl
{
	internal Label label_0;

	internal PictureBox pictureBox_0;

	internal Button button_0;

	internal Button button_1;

	private Container container_0 = null;

	private string string_0 = "{0} of {1}";

	private Image[] image_0;

	internal int int_0 = -1;

	public string StatusFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image[] Images
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
			Class76.smethod_25(this);
		}
	}

	public int CurrentImageIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			Class76.smethod_278(this);
		}
	}

	public Size ImageAreaSize
	{
		get
		{
			return pictureBox_0.Size;
		}
		set
		{
			base.Width += value.Width - pictureBox_0.Width;
			base.Height += value.Height - pictureBox_0.Height;
		}
	}

	public BorderStyle ImageAreaBorderStyle
	{
		get
		{
			return pictureBox_0.BorderStyle;
		}
		set
		{
			pictureBox_0.BorderStyle = value;
		}
	}

	public PictureBoxSizeMode ImageAreaSizeMode
	{
		get
		{
			return pictureBox_0.SizeMode;
		}
		set
		{
			pictureBox_0.SizeMode = value;
		}
	}

	public ImageNavigator()
	{
		Class76.smethod_59(this);
		SetStyle(ControlStyles.Selectable, value: true);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public void NextImage()
	{
		if (Images != null && int_0 < Images.Length - 1)
		{
			CurrentImageIndex++;
		}
	}

	public void PreviousImage()
	{
		if (Images != null && int_0 > 0)
		{
			CurrentImageIndex--;
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Class76.smethod_25(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		PreviousImage();
	}

	internal void method_1(object sender, EventArgs e)
	{
		NextImage();
	}
}
