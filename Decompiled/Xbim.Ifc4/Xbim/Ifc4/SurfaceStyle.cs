using System;
using System.ComponentModel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4;

public class SurfaceStyle : IPhongMaterial
{
	private readonly IIfcSurfaceStyle _surfaceStyle;

	public IIfcPixelTexture DiffuseMap;

	public IIfcPixelTexture DisplacementMap;

	public IIfcPixelTexture NormalMap;

	public static SurfaceStyle NullSurfaceStyle { get; private set; }

	public string Name { get; set; }

	public IfcSurfaceSide Side
	{
		get
		{
			if (_surfaceStyle != null)
			{
				return _surfaceStyle.Side;
			}
			return IfcSurfaceSide.BOTH;
		}
	}

	string IPhongMaterial.Name { get; set; }

	public RgbaColour AmbientColour { get; set; }

	public RgbaColour DiffuseColour { get; set; }

	public RgbaColour EmissiveColour { get; set; }

	public RgbaColour SpecularColour { get; set; }

	public double SpecularShininess { get; set; }

	public bool IsEmpty
	{
		get
		{
			if (Math.Abs(DiffuseColour.Alpha) < 1E-09 && Math.Abs(DiffuseColour.Red) < 1E-09 && Math.Abs(DiffuseColour.Green) < 1E-09)
			{
				return Math.Abs(DiffuseColour.Blue) < 1E-09;
			}
			return false;
		}
	}

	IIfcPixelTexture IPhongMaterial.DiffuseMap
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	IIfcPixelTexture IPhongMaterial.DisplacementMap
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	IIfcPixelTexture IPhongMaterial.NormalMap
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	static SurfaceStyle()
	{
		NullSurfaceStyle = new SurfaceStyle();
	}

	public SurfaceStyle(IIfcSurfaceStyle surfaceStyle)
	{
		_surfaceStyle = surfaceStyle;
		if (_surfaceStyle == null)
		{
			Name = "NullStyle";
		}
		else
		{
			Name = _surfaceStyle.Name ?? ((IfcLabel)"Default");
		}
		InitialiseStyles();
	}

	public SurfaceStyle()
	{
	}

	public SurfaceStyle(IPhongMaterial surfaceStyle)
	{
		AmbientColour = surfaceStyle.AmbientColour;
		DiffuseColour = surfaceStyle.DiffuseColour;
		DisplacementMap = surfaceStyle.DisplacementMap;
		EmissiveColour = surfaceStyle.EmissiveColour;
		Name = surfaceStyle.Name;
		NormalMap = surfaceStyle.NormalMap;
		SpecularColour = surfaceStyle.SpecularColour;
		SpecularShininess = surfaceStyle.SpecularShininess;
		DiffuseMap = surfaceStyle.DiffuseMap;
	}

	private void SurfaceStyle_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		InitialiseStyles();
	}

	private void InitialiseStyles()
	{
		AmbientColour = new RgbaColour(0.0, 0.0, 0.0, 1.0);
		DiffuseColour = new RgbaColour(0.0, 0.0, 0.0, 1.0);
		SpecularColour = new RgbaColour(0.0, 0.0, 0.0, 1.0);
		EmissiveColour = new RgbaColour(0.0, 0.0, 0.0, 1.0);
		SpecularShininess = 0.0;
		if (_surfaceStyle == null)
		{
			return;
		}
		((INotifyPropertyChanged)_surfaceStyle).PropertyChanged += SurfaceStyle_PropertyChanged;
		foreach (IIfcSurfaceStyleElementSelect style in _surfaceStyle.Styles)
		{
			IIfcSurfaceStyleShading ifcSurfaceStyleShading = style as IIfcSurfaceStyleShading;
			if (style is IIfcSurfaceStyleRendering ifcSurfaceStyleRendering)
			{
				AmbientColour = new RgbaColour(ifcSurfaceStyleRendering.SurfaceColour, ifcSurfaceStyleRendering.Transparency);
				if (ifcSurfaceStyleRendering.DiffuseColour != null)
				{
					if (ifcSurfaceStyleRendering.DiffuseColour is IIfcColourRgb colour)
					{
						DiffuseColour = new RgbaColour(colour, ifcSurfaceStyleRendering.Transparency);
					}
					else
					{
						DiffuseColour = AmbientColour * (IfcNormalisedRatioMeasure)(object)ifcSurfaceStyleRendering.DiffuseColour;
					}
				}
				else
				{
					DiffuseColour = AmbientColour;
				}
				if (ifcSurfaceStyleRendering.SpecularColour != null)
				{
					if (ifcSurfaceStyleRendering.SpecularColour is IIfcColourRgb colour2)
					{
						SpecularColour = new RgbaColour(colour2, ifcSurfaceStyleRendering.Transparency);
					}
					else
					{
						SpecularColour = AmbientColour * (IfcNormalisedRatioMeasure)(object)ifcSurfaceStyleRendering.SpecularColour;
					}
				}
				if (ifcSurfaceStyleRendering.SpecularHighlight == null)
				{
					SpecularShininess = 0.0;
				}
				else if (ifcSurfaceStyleRendering.SpecularHighlight.GetType().Name == "IfcSpecularExponent")
				{
					SpecularShininess = (float)(double)ifcSurfaceStyleRendering.SpecularHighlight.Value / 255f;
				}
				else
				{
					SpecularShininess = (float)(double)ifcSurfaceStyleRendering.SpecularHighlight.Value;
				}
			}
			else if (ifcSurfaceStyleShading != null)
			{
				RgbaColour ambientColour = (DiffuseColour = new RgbaColour(ifcSurfaceStyleShading.SurfaceColour, ifcSurfaceStyleShading.Transparency));
				AmbientColour = ambientColour;
			}
			else if (!(style is IIfcSurfaceStyleLighting) && !(style is IIfcSurfaceStyleWithTextures) && !(style is IIfcExternallyDefinedSurfaceStyle))
			{
				_ = style is IIfcSurfaceStyleRefraction;
			}
		}
	}

	public SurfaceStyle Clone()
	{
		return new SurfaceStyle
		{
			AmbientColour = AmbientColour,
			DiffuseColour = DiffuseColour,
			DisplacementMap = DisplacementMap,
			EmissiveColour = EmissiveColour,
			Name = Name,
			NormalMap = NormalMap,
			SpecularColour = SpecularColour,
			SpecularShininess = SpecularShininess,
			DiffuseMap = DiffuseMap
		};
	}
}
