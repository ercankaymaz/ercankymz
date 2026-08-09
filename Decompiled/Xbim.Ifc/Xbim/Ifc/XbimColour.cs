using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public class XbimColour
{
	private string _name;

	public readonly float DiffuseFactor;

	public readonly float TransmissionFactor;

	public float DiffuseTransmissionFactor;

	public readonly float ReflectionFactor;

	public readonly float SpecularFactor;

	public static readonly XbimColour DefaultColour;

	public string Name
	{
		get
		{
			if (string.IsNullOrWhiteSpace(_name))
			{
				return "";
			}
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public bool IsTransparent => Alpha < 1f;

	public float Red { get; set; }

	public float Green { get; set; }

	public float Blue { get; set; }

	public float Alpha { get; set; }

	public override bool Equals(object obj)
	{
		XbimColour xbimColour = obj as XbimColour;
		float num = 1E-05f;
		if (xbimColour == null)
		{
			return false;
		}
		if (Math.Abs(xbimColour.Red - Red) < num && Math.Abs(xbimColour.Green - Green) < num && Math.Abs(xbimColour.Blue - Blue) < num && Math.Abs(xbimColour.Alpha - Alpha) < num && Math.Abs(xbimColour.DiffuseFactor - DiffuseFactor) < num && Math.Abs(xbimColour.TransmissionFactor - TransmissionFactor) < num && Math.Abs(xbimColour.DiffuseTransmissionFactor - DiffuseTransmissionFactor) < num && Math.Abs(xbimColour.ReflectionFactor - ReflectionFactor) < num)
		{
			return Math.Abs(xbimColour.SpecularFactor - SpecularFactor) < num;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode() ^ Alpha.GetHashCode();
		float diffuseFactor = DiffuseFactor;
		int num2 = num ^ diffuseFactor.GetHashCode();
		diffuseFactor = TransmissionFactor;
		int num3 = num2 ^ diffuseFactor.GetHashCode() ^ DiffuseTransmissionFactor.GetHashCode();
		diffuseFactor = ReflectionFactor;
		int num4 = num3 ^ diffuseFactor.GetHashCode();
		diffuseFactor = SpecularFactor;
		return num4 ^ diffuseFactor.GetHashCode();
	}

	public XbimColour()
	{
	}

	public XbimColour(string name, float red, float green, float blue, float alpha = 1f)
	{
		Name = name;
		Red = red;
		Green = green;
		Blue = blue;
		Alpha = alpha;
	}

	public XbimColour(string name, double red, double green, double blue, double alpha = 1.0)
		: this(name, (float)red, (float)green, (float)blue, (float)alpha)
	{
	}

	public static XbimColour FromHSV(string name, double hue, double saturation, double value)
	{
		int num = Convert.ToInt32(Math.Floor(hue / 60.0)) % 6;
		double num2 = hue / 60.0 - Math.Floor(hue / 60.0);
		double num3 = Convert.ToDouble(value);
		double num4 = Convert.ToDouble(value * (1.0 - saturation));
		double num5 = Convert.ToDouble(value * (1.0 - num2 * saturation));
		double num6 = Convert.ToDouble(value * (1.0 - (1.0 - num2) * saturation));
		return num switch
		{
			0 => new XbimColour(name, num3, num6, num4), 
			1 => new XbimColour(name, num5, num3, num4), 
			2 => new XbimColour(name, num4, num3, num6), 
			3 => new XbimColour(name, num4, num5, num3), 
			4 => new XbimColour(name, num6, num4, num3), 
			_ => new XbimColour(name, num3, num4, num5), 
		};
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "R:{0:r} G:{1:r} B:{2:r} A:{3:r} DF:{4:r} TF:{5:r} DTF:{6:r} RF:{7:r} SF:{8:r}", Red, Green, Blue, Alpha, DiffuseFactor, TransmissionFactor, DiffuseTransmissionFactor, ReflectionFactor, SpecularFactor);
	}

	public static XbimColour FromString(string source)
	{
		source = source.Replace(',', '.');
		Match match = new Regex("R:([\\d.]+) G:([\\d.]+) B:([\\d.]+) A:([\\d.]+)( DF:([\\d.]+) TF:([\\d.]+) DTF:([\\d.]+) RF:([\\d.]+) SF:([\\d.]+))*").Match(source);
		if (!match.Success)
		{
			return DefaultColour;
		}
		float red = float.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
		float green = float.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
		float blue = float.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
		float alpha = float.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);
		if (match.Groups[5].Value == string.Empty)
		{
			return new XbimColour(red, green, blue, alpha);
		}
		float diffuseFactor = float.Parse(match.Groups[6].Value, CultureInfo.InvariantCulture);
		float transmissionFactor = float.Parse(match.Groups[7].Value, CultureInfo.InvariantCulture);
		float diffuseTransmissionFactor = float.Parse(match.Groups[8].Value, CultureInfo.InvariantCulture);
		float reflectionFactor = float.Parse(match.Groups[9].Value, CultureInfo.InvariantCulture);
		float specularFactor = float.Parse(match.Groups[10].Value, CultureInfo.InvariantCulture);
		return new XbimColour(red, green, blue, alpha, diffuseFactor, transmissionFactor, diffuseTransmissionFactor, reflectionFactor, specularFactor);
	}

	static XbimColour()
	{
		DefaultColour = new XbimColour("Default", 1f, 1f, 1f);
	}

	public XbimColour(IIfcSurfaceStyle style)
	{
		IIfcSurfaceStyleShading ifcSurfaceStyleShading = style.Styles.OfType<IIfcSurfaceStyleShading>().FirstOrDefault();
		if (ifcSurfaceStyleShading != null)
		{
			IIfcColourRgb surfaceColour = ifcSurfaceStyleShading.SurfaceColour;
			Red = (float)(double)surfaceColour.Red;
			Green = (float)(double)surfaceColour.Green;
			Blue = (float)(double)surfaceColour.Blue;
			Alpha = (float)((1.0 - (double?)ifcSurfaceStyleShading.Transparency) ?? 1.0);
		}
	}

	internal XbimColour(IIfcColourRgb rgbColour)
	{
		Red = (float)(double)rgbColour.Red;
		Green = (float)(double)rgbColour.Green;
		Blue = (float)(double)rgbColour.Blue;
		Alpha = 1f;
	}

	public XbimColour(IIfcColourRgb ifcColourRgb, double opacity = 1.0, double diffuseFactor = 1.0, double specularFactor = 0.0, double transmissionFactor = 1.0, double reflectanceFactor = 0.0)
		: this(ifcColourRgb)
	{
		Alpha = (float)opacity;
		DiffuseFactor = (float)diffuseFactor;
		SpecularFactor = (float)specularFactor;
		TransmissionFactor = (float)transmissionFactor;
		ReflectionFactor = (float)reflectanceFactor;
	}

	public XbimColour(float red, float green, float blue, float alpha = 1f, float diffuseFactor = 1f, float transmissionFactor = 1f, float diffuseTransmissionFactor = 1f, float reflectionFactor = 0f, float specularFactor = 0f)
	{
		Red = red;
		Green = green;
		Blue = blue;
		Alpha = alpha;
		DiffuseFactor = diffuseFactor;
		TransmissionFactor = transmissionFactor;
		DiffuseTransmissionFactor = diffuseTransmissionFactor;
		ReflectionFactor = reflectionFactor;
		SpecularFactor = specularFactor;
	}
}
