#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonProfessionalRenderer : ToolStripProfessionalRenderer
{
	private KryptonColorTable _kct;

	public KryptonColorTable KCT => _kct;

	public KryptonProfessionalRenderer(KryptonColorTable kct)
		: base(kct)
	{
		Debug.Assert(kct != null);
		_kct = kct;
	}

	protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
	{
		if (e.Item.GetType().ToString() == "System.Windows.Forms.MdiControlStrip+ControlBoxMenuItem" && e.ToolStrip.Parent.TopLevelControl is Form obj)
		{
			PropertyInfo property = typeof(Form).GetProperty("MdiControlStrip", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			if (property != null)
			{
				object value = property.GetValue(obj, null);
				if (value != null)
				{
					Type type = value.GetType();
					FieldInfo field = type.GetField("minimize", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
					FieldInfo field2 = type.GetField("restore", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
					FieldInfo field3 = type.GetField("close", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
					if (field != null && field2 != null && field3 != null)
					{
						ToolStripMenuItem toolStripMenuItem = field.GetValue(value) as ToolStripMenuItem;
						ToolStripMenuItem toolStripMenuItem2 = field2.GetValue(value) as ToolStripMenuItem;
						ToolStripMenuItem toolStripMenuItem3 = field3.GetValue(value) as ToolStripMenuItem;
						if (toolStripMenuItem != null && toolStripMenuItem2 != null && toolStripMenuItem3 != null)
						{
							PaletteButtonSpecStyle paletteButtonSpecStyle = PaletteButtonSpecStyle.Generic;
							if (toolStripMenuItem.Image == e.Image)
							{
								paletteButtonSpecStyle = PaletteButtonSpecStyle.PendantMin;
							}
							else if (toolStripMenuItem2.Image == e.Image)
							{
								paletteButtonSpecStyle = PaletteButtonSpecStyle.PendantRestore;
							}
							else if (toolStripMenuItem3.Image == e.Image)
							{
								paletteButtonSpecStyle = PaletteButtonSpecStyle.PendantClose;
							}
							if (paletteButtonSpecStyle != PaletteButtonSpecStyle.Generic)
							{
								Image buttonSpecImage = KCT.Palette.GetButtonSpecImage(paletteButtonSpecStyle, PaletteState.Normal);
								Color buttonSpecImageTransparentColor = KCT.Palette.GetButtonSpecImageTransparentColor(paletteButtonSpecStyle);
								if (buttonSpecImage != null)
								{
									using (ImageAttributes imageAttributes = new ImageAttributes())
									{
										ColorMap colorMap = new ColorMap();
										colorMap.OldColor = buttonSpecImageTransparentColor;
										colorMap.NewColor = Color.Transparent;
										imageAttributes.SetRemapTable(new ColorMap[1] { colorMap });
										e.Graphics.DrawImage(buttonSpecImage, e.ImageRectangle, 0, 0, e.Image.Width, e.Image.Height, GraphicsUnit.Pixel, imageAttributes);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		base.OnRenderItemImage(e);
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
		if (!(e.ToolStrip is StatusStrip))
		{
			base.OnRenderToolStripBorder(e);
		}
	}
}
