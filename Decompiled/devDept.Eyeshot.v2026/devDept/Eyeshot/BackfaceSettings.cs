using System;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
[TypeConverter(typeof(BackfaceConverter))]
public class BackfaceSettings
{
	private backfaceColorMethodType colorMethod = backfaceColorMethodType.EntityColor;

	private Color color = Color.LightGreen;

	[Description("Color method.")]
	public backfaceColorMethodType ColorMethod
	{
		get
		{
			return colorMethod;
		}
		set
		{
			colorMethod = value;
		}
	}

	[Description("Backface color, applies only to single color style mode.")]
	public Color Color
	{
		get
		{
			return color;
		}
		set
		{
			color = value;
		}
	}

	public BackfaceSettings()
	{
	}

	public BackfaceSettings(backfaceColorMethodType colorMode, Color color)
	{
		colorMethod = colorMode;
		this.color = color;
	}
}
