using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public static class ColorSpaceExtensions
{
	public static ColorSpaceFamily GetFamily(this ColorSpace colorSpace)
	{
		switch (colorSpace)
		{
		case ColorSpace.DeviceGray:
		case ColorSpace.DeviceRGB:
		case ColorSpace.DeviceCMYK:
			return ColorSpaceFamily.Device;
		case ColorSpace.CalGray:
		case ColorSpace.CalRGB:
		case ColorSpace.Lab:
		case ColorSpace.ICCBased:
			return ColorSpaceFamily.CIEBased;
		case ColorSpace.Indexed:
		case ColorSpace.Pattern:
		case ColorSpace.Separation:
		case ColorSpace.DeviceN:
			return ColorSpaceFamily.Special;
		default:
			throw new ArgumentException($"Unrecognized colorspace: {colorSpace}.");
		}
	}

	public static bool TryMapToColorSpace(this NameToken name, out ColorSpace colorspace)
	{
		colorspace = ColorSpace.DeviceGray;
		if (name.Data == NameToken.Devicegray.Data || name.Data == "G")
		{
			colorspace = ColorSpace.DeviceGray;
		}
		else if (name.Data == NameToken.Devicergb.Data || name.Data == "RGB")
		{
			colorspace = ColorSpace.DeviceRGB;
		}
		else if (name.Data == NameToken.Devicecmyk.Data || name.Data == "CMYK")
		{
			colorspace = ColorSpace.DeviceCMYK;
		}
		else if (name.Data == NameToken.Calgray.Data)
		{
			colorspace = ColorSpace.CalGray;
		}
		else if (name.Data == NameToken.Calrgb.Data)
		{
			colorspace = ColorSpace.CalRGB;
		}
		else if (name.Data == NameToken.Lab.Data)
		{
			colorspace = ColorSpace.Lab;
		}
		else if (name.Data == NameToken.Iccbased.Data)
		{
			colorspace = ColorSpace.ICCBased;
		}
		else if (name.Data == NameToken.Indexed.Data || name.Data == "I")
		{
			colorspace = ColorSpace.Indexed;
		}
		else if (name.Data == NameToken.Pattern.Data)
		{
			colorspace = ColorSpace.Pattern;
		}
		else if (name.Data == NameToken.Separation.Data)
		{
			colorspace = ColorSpace.Separation;
		}
		else
		{
			if (!(name.Data == NameToken.Devicen.Data))
			{
				return false;
			}
			colorspace = ColorSpace.DeviceN;
		}
		return true;
	}

	public static NameToken ToNameToken(this ColorSpace colorSpace)
	{
		return colorSpace switch
		{
			ColorSpace.DeviceGray => NameToken.Devicegray, 
			ColorSpace.DeviceRGB => NameToken.Devicergb, 
			ColorSpace.DeviceCMYK => NameToken.Devicecmyk, 
			ColorSpace.CalGray => NameToken.Calgray, 
			ColorSpace.CalRGB => NameToken.Calrgb, 
			ColorSpace.Lab => NameToken.Lab, 
			ColorSpace.ICCBased => NameToken.Iccbased, 
			ColorSpace.Indexed => NameToken.Indexed, 
			ColorSpace.Pattern => NameToken.Pattern, 
			ColorSpace.Separation => NameToken.Separation, 
			ColorSpace.DeviceN => NameToken.Devicen, 
			_ => throw new ArgumentException($"Unrecognized colorspace: {colorSpace}."), 
		};
	}
}
