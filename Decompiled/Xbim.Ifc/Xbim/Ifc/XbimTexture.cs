using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xbim.Common.Configuration;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public class XbimTexture
{
	private readonly ILogger logger;

	public readonly XbimColourMap ColourMap = new XbimColourMap();

	private bool _renderBothFaces = true;

	private bool _switchFrontAndRearFaces;

	public XbimColour DiffuseTransmissionColour;

	public XbimColour TransmissionColour;

	public XbimColour DiffuseReflectionColour;

	public XbimColour ReflectanceColour;

	public int DefinedObjectId { get; set; }

	public bool IsTransparent => ColourMap.IsTransparent;

	public bool RenderBothFaces => _renderBothFaces;

	public bool SwitchFrontAndRearFaces => _switchFrontAndRearFaces;

	public XbimTexture()
	{
		logger = XbimServices.Current.ServiceProvider.GetRequiredService<ILogger<XbimTexture>>();
	}

	public static XbimTexture Create(IIfcSurfaceStyle surfaceStyle)
	{
		return new XbimTexture().CreateTexture(surfaceStyle);
	}

	private XbimTexture CreateTexture(IIfcSurfaceStyle surfaceStyle)
	{
		DefinedObjectId = surfaceStyle.EntityLabel;
		_renderBothFaces = surfaceStyle.Side == IfcSurfaceSide.BOTH;
		_switchFrontAndRearFaces = surfaceStyle.Side == IfcSurfaceSide.NEGATIVE;
		ColourMap.Clear();
		foreach (IIfcSurfaceStyleElementSelect style in surfaceStyle.Styles)
		{
			if (style is IIfcSurfaceStyleRendering)
			{
				AddColour((IIfcSurfaceStyleRendering)style);
			}
			else if (style is IIfcSurfaceStyleShading)
			{
				AddColour((IIfcSurfaceStyleShading)style);
			}
			else if (style is IIfcSurfaceStyleLighting)
			{
				AddLighting((IIfcSurfaceStyleLighting)style);
			}
		}
		return this;
	}

	public override int GetHashCode()
	{
		int num = (int)((uint)ColourMap.GetHashCode() ^ (_renderBothFaces ? 1u : 0u)) ^ (_switchFrontAndRearFaces ? 1 : 0);
		if (DiffuseTransmissionColour != null)
		{
			num ^= DiffuseTransmissionColour.GetHashCode();
		}
		if (TransmissionColour != null)
		{
			num ^= TransmissionColour.GetHashCode();
		}
		if (DiffuseReflectionColour != null)
		{
			num ^= DiffuseReflectionColour.GetHashCode();
		}
		if (ReflectanceColour != null)
		{
			num ^= ReflectanceColour.GetHashCode();
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is XbimTexture xbimTexture))
		{
			return false;
		}
		if (xbimTexture.ColourMap.Equals(ColourMap) && xbimTexture.RenderBothFaces == RenderBothFaces && xbimTexture.SwitchFrontAndRearFaces == SwitchFrontAndRearFaces && xbimTexture.DiffuseTransmissionColour == DiffuseTransmissionColour && xbimTexture.TransmissionColour == TransmissionColour && xbimTexture.DiffuseReflectionColour == DiffuseReflectionColour)
		{
			return xbimTexture.ReflectanceColour == ReflectanceColour;
		}
		return false;
	}

	private void AddColour(IIfcSurfaceStyleShading shading)
	{
		double opacity = 1.0;
		if (shading.Transparency.HasValue)
		{
			opacity = 1.0 - (double)shading.Transparency.Value;
		}
		ColourMap.Add(new XbimColour(shading.SurfaceColour, opacity));
	}

	private void AddColour(IIfcSurfaceStyleRendering rendering)
	{
		try
		{
			double opacity = 1.0;
			if (rendering.Transparency.HasValue)
			{
				opacity = 1.0 - (double)rendering.Transparency.Value;
			}
			if (rendering.DiffuseColour is IfcNormalisedRatioMeasure)
			{
				ColourMap.Add(new XbimColour(rendering.SurfaceColour, opacity, (IfcNormalisedRatioMeasure)(object)rendering.DiffuseColour));
			}
			else if (rendering.DiffuseColour is IIfcColourRgb)
			{
				ColourMap.Add(new XbimColour((IIfcColourRgb)rendering.DiffuseColour, opacity));
			}
			else if (rendering.DiffuseColour == null)
			{
				ColourMap.Add(new XbimColour(rendering.SurfaceColour, opacity));
			}
			else if (rendering.SpecularColour is IfcNormalisedRatioMeasure)
			{
				ColourMap.Add(new XbimColour(rendering.SurfaceColour, opacity, (IfcNormalisedRatioMeasure)(object)rendering.SpecularColour));
			}
			else if (rendering.SpecularColour is IIfcColourRgb)
			{
				ColourMap.Add(new XbimColour((IIfcColourRgb)rendering.SpecularColour, opacity));
			}
		}
		catch (Exception ex)
		{
			logger.LogWarning($"#{DefinedObjectId} attempted to add a duplicate colour (same name).", ex);
		}
	}

	private void AddLighting(IIfcSurfaceStyleLighting lighting)
	{
		DiffuseReflectionColour = new XbimColour(lighting.DiffuseReflectionColour);
		DiffuseTransmissionColour = new XbimColour(lighting.DiffuseTransmissionColour);
		TransmissionColour = new XbimColour(lighting.TransmissionColour);
		ReflectanceColour = new XbimColour(lighting.ReflectanceColour);
	}

	public static XbimTexture Create(IIfcColourRgb colour)
	{
		return new XbimTexture().CreateTexture(colour);
	}

	private XbimTexture CreateTexture(IIfcColourRgb colour)
	{
		DefinedObjectId = colour.EntityLabel;
		ColourMap.Clear();
		ColourMap.Add(new XbimColour(colour));
		return this;
	}

	public static XbimTexture Create(IIfcSurfaceStyleRendering rendering)
	{
		return new XbimTexture().CreateTexture(rendering);
	}

	private XbimTexture CreateTexture(IIfcSurfaceStyleRendering rendering)
	{
		DefinedObjectId = rendering.EntityLabel;
		ColourMap.Clear();
		AddColour(rendering);
		return this;
	}

	public static XbimTexture Create(IIfcSurfaceStyleShading shading)
	{
		return new XbimTexture().CreateTexture(shading);
	}

	private XbimTexture CreateTexture(IIfcSurfaceStyleShading shading)
	{
		DefinedObjectId = shading.EntityLabel;
		ColourMap.Clear();
		if (shading is IIfcSurfaceStyleRendering)
		{
			AddColour((IIfcSurfaceStyleRendering)shading);
		}
		else
		{
			AddColour(shading);
		}
		return this;
	}

	public static XbimTexture Create(byte red = byte.MaxValue, byte green = byte.MaxValue, byte blue = byte.MaxValue, byte alpha = byte.MaxValue)
	{
		return new XbimTexture().CreateTexture(red, green, blue, alpha);
	}

	private XbimTexture CreateTexture(byte red = byte.MaxValue, byte green = byte.MaxValue, byte blue = byte.MaxValue, byte alpha = byte.MaxValue)
	{
		ColourMap.Clear();
		ColourMap.Add(new XbimColour("C1", (float)(int)red / 255f, (float)(int)green / 255f, (float)(int)blue / 255f, (float)(int)alpha / 255f));
		return this;
	}

	public XbimTexture CreateTexture(float red = 1f, float green = 1f, float blue = 1f, float alpha = 1f)
	{
		ColourMap.Clear();
		ColourMap.Add(new XbimColour("C1", red, green, blue, alpha));
		return this;
	}

	private XbimTexture CreateTexture(XbimColour colour)
	{
		ColourMap.Clear();
		AddColour(colour);
		return this;
	}

	public static XbimTexture Create(XbimColour colour)
	{
		return new XbimTexture().CreateTexture(colour);
	}

	private void AddColour(XbimColour colour)
	{
		if (string.IsNullOrEmpty(colour.Name))
		{
			colour.Name = "C" + (ColourMap.Count + 1);
		}
		ColourMap.Add(colour);
	}
}
