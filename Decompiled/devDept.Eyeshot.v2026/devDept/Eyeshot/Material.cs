using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Eyeshot.Converters;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
[TypeConverter(typeof(MaterialConverter))]
public class Material : IDisposable, ICloneable, ISerializable, IEquatable<Material>, IKeyedCollectionDisposableItem<Material>, IKeyedCollectionItem<Material>, INotifyKeyChanged
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static Color _0023_003DzCgPLpuQ_003D = Color.FromArgb(255, Color.Gray);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static Material _0023_003DzovlSUnojZWZr = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989291), _0023_003DzCgPLpuQ_003D, _0023_003DzCgPLpuQ_003D, Color.Black, 0f, 0f);

	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	protected double[,] D;

	private Color _wireColor;

	[CompilerGenerated]
	private TextureBase _003CTexture_003Ek__BackingField;

	[CompilerGenerated]
	private TextureBase _003CAlphaMap_003Ek__BackingField;

	internal textureFilteringFunctionType minFunc = textureFilteringFunctionType.NearestMipmapLinear;

	internal textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear;

	private Color _diffuse;

	private float _shininess;

	private bool repeatX = true;

	private bool repeatY = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz5KguOoA_003D = 1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Material name.")]
	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!string.Equals(_name, value, StringComparison.OrdinalIgnoreCase))
			{
				OnKeyChanged(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
				_name = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Material description.")]
	public string Description { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Ambient reflectance of the material.")]
	public Color Ambient { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Diffuse reflectance of the material.")]
	public Color Diffuse
	{
		get
		{
			return _diffuse;
		}
		set
		{
			_diffuse = value;
			_0023_003DzIQplSf_Uzh2h();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Specular reflectance of the material.")]
	public Color Specular { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	[Description("Environment reflectance of the material (range 0-1).")]
	public float Environment { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Specular exponent of the material (range 0-1).")]
	[TypeConverter(typeof(OpacityConverter))]
	public float Shininess
	{
		get
		{
			return _shininess;
		}
		set
		{
			if (value < 0f || value > 1f)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989280));
			}
			_shininess = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Young { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Poisson { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double YieldStrength { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Density { get; set; } = 1.0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double CoeffOfThermalExp { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public elementType ElementType { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public double[,] Matrix => D;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ElementThickness { get; set; }

	public Color WireColor => _wireColor;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public TextureBase Texture
	{
		[CompilerGenerated]
		get
		{
			return _003CTexture_003Ek__BackingField;
		}
		internal set
		{
			_003CTexture_003Ek__BackingField = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public TextureBase AlphaMap
	{
		[CompilerGenerated]
		get
		{
			return _003CAlphaMap_003Ek__BackingField;
		}
		internal set
		{
			_003CAlphaMap_003Ek__BackingField = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[Description("The material texture image.")]
	public byte[] TextureImage { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The material texture image.")]
	public bool TextureImageOverExposure { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[Description("The material alpha image.")]
	public byte[] AlphaMapImage { get; set; }

	public IEnvironment EnvironmentMappingTexture { get; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[Description("The material environment mapping image.")]
	public byte[] EnvironmentMappingImage { get; set; }

	public linearUnitsType LinearUnits { get; set; } = linearUnitsType.Meters;

	public massUnitsType MassUnits { get; set; } = massUnitsType.Kilograms;

	public float TextureLength { get; set; } = 1f;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The texture minifying function.")]
	public textureFilteringFunctionType MinifyingFunction
	{
		get
		{
			return minFunc;
		}
		set
		{
			minFunc = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The texture magnifying function.")]
	public textureFilteringFunctionType MagnifyingFunction
	{
		get
		{
			return magFunc;
		}
		set
		{
			magFunc = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The texture repeat mode in the X direction.")]
	public bool RepeatX
	{
		get
		{
			return repeatX;
		}
		set
		{
			repeatX = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The texture repeat mode in the Y direction.")]
	public bool RepeatY
	{
		get
		{
			return repeatY;
		}
		set
		{
			repeatY = value;
		}
	}

	public static Material Brass => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989210), new float[4] { 0.329412f, 0.223529f, 0.027451f, 1f }, new float[4] { 0.780392f, 0.568627f, 0.113725f, 1f }, new float[4] { 0.992157f, 0.941176f, 0.807843f, 1f }, 27.8974f, 0.05f, 110000.0, 0.34, 950.0, 8610.0);

	public static Material Bronze => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989190), new float[4] { 0.2125f, 0.1275f, 0.054f, 1f }, new float[4] { 0.714f, 0.4284f, 0.18144f, 1f }, new float[4] { 0.393548f, 0.271906f, 0.166721f, 1f }, 25.6f, 0.05f, 120000.0, 0.34, 1050.0, 8890.0);

	public static Material PolishedBronze => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988913), new float[4] { 0.25f, 0.148f, 0.06475f, 1f }, new float[4] { 0.4f, 0.2368f, 0.1036f, 1f }, new float[4] { 0.774597f, 0.458561f, 0.200621f, 1f }, 76.8f, 0.05f, 120000.0, 0.34, 1050.0, 8890.0);

	public static Material Chrome => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988904), new float[4] { 0.25f, 0.25f, 0.25f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, new float[4] { 0.774597f, 0.774597f, 0.774597f, 1f }, 76.8f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Copper => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988883), new float[4] { 0.19125f, 0.0735f, 0.0225f, 1f }, new float[4] { 0.7038f, 0.27048f, 0.0828f, 1f }, new float[4] { 0.256777f, 0.137622f, 0.086014f, 1f }, 12.8f, 0.05f, 110000.0, 0.34, 280.0, 8300.0);

	public static Material PolishedCopper => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988866), new float[4] { 0.2295f, 0.08825f, 0.0275f, 1f }, new float[4] { 0.5508f, 0.2118f, 0.066f, 1f }, new float[4] { 0.580594f, 0.223257f, 0.06957f, 1f }, 51.2f, 0.05f, 110000.0, 0.34, 280.0, 8300.0);

	public static Material Gold => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988853), new float[4] { 0.24725f, 0.1995f, 0.0745f, 1f }, new float[4] { 0.75164f, 0.60648f, 0.22648f, 1f }, new float[4] { 0.628281f, 0.555802f, 0.366065f, 1f }, 51.2f, 0.05f, 83000.0, 0.44, 0.0, 19320.0);

	public static Material PolishedGold => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988834), new float[4] { 0.24725f, 0.2245f, 0.0645f, 1f }, new float[4] { 0.34615f, 0.3143f, 0.0903f, 1f }, new float[4] { 0.797357f, 0.723991f, 0.208006f, 1f }, 83.2f, 0.05f, 0.0, 0.0, 0.0, 19320.0);

	public static Material Pewter => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988819), new float[4] { 0.105882f, 0.058824f, 0.113725f, 1f }, new float[4] { 0.427451f, 0.470588f, 0.541176f, 1f }, new float[4] { 0.333333f, 0.333333f, 0.521569f, 1f }, 9.84615f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Silver => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988802), new float[4] { 0.19225f, 0.19225f, 0.19225f, 1f }, new float[4] { 0.50754f, 0.50754f, 0.50754f, 1f }, new float[4] { 0.508273f, 0.508273f, 0.508273f, 1f }, 51.2f, 0.05f, 0.0, 0.0, 0.0, 10490.0);

	public static Material PolishedSilver => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988813), new float[4]
	{
		37f / 160f,
		37f / 160f,
		37f / 160f,
		1f
	}, new float[4] { 0.2775f, 0.2775f, 0.2775f, 1f }, new float[4] { 0.773911f, 0.773911f, 0.773911f, 1f }, 89.6f, 0.05f, 0.0, 0.0, 0.0, 10490.0);

	public static Material Emerald => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989028), new float[4] { 0.0215f, 0.1745f, 0.0215f, 0.55f }, new float[4] { 0.07568f, 0.61424f, 0.07568f, 0.55f }, new float[4] { 0.633f, 0.727811f, 0.633f, 0.55f }, 76.8f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Jade => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989010), new float[4] { 0.135f, 0.2225f, 0.1575f, 0.95f }, new float[4] { 0.54f, 0.89f, 0.63f, 0.95f }, new float[4] { 0.316228f, 0.316228f, 0.316228f, 0.95f }, 12.800003f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Obsidian => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989019), new float[4] { 0.05375f, 0.05f, 0.06625f, 0.82f }, new float[4] { 0.18275f, 0.17f, 0.22525f, 0.82f }, new float[4] { 0.332741f, 0.328634f, 0.346435f, 0.82f }, 38.4f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Pearl => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989004), new float[4] { 0.25f, 0.20725f, 0.20725f, 0.922f }, new float[4] { 1f, 0.829f, 0.829f, 0.922f }, new float[4] { 0.296648f, 0.296648f, 0.296648f, 0.922f }, 11.264f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Ruby => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988984), new float[4] { 0.1745f, 0.01175f, 0.01175f, 0.55f }, new float[4] { 0.61424f, 0.04136f, 0.04136f, 0.55f }, new float[4] { 0.727811f, 0.626959f, 0.626959f, 0.55f }, 76.8f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material Turquoise => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988961), new float[4] { 0.1f, 0.18725f, 0.1745f, 0.8f }, new float[4] { 0.396f, 0.74151f, 0.69102f, 0.8f }, new float[4] { 0.297254f, 0.30829f, 0.306678f, 0.8f }, 12.8f, 0.05f, 0.0, 0.0, 0.0, 0.0);

	public static Material BlackRubber => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988945), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.01f, 0.01f, 0.01f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 10f, 0.05f, 4.0, 0.45, 0.0, 1100.0);

	public static Material Aluminium => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988931), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.5f, 0.5f, 0.6f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 15f, 0.05f, 71000.0, 0.33, 280.0, 2770.0);

	public static Material StructuralSteel => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989683), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.5f, 0.5f, 0.5f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 15f, 0.05f, 200000.0, 0.3, 250.0, 7850.0);

	public static Material StainlessSteel => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989673), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.6f, 0.6f, 0.6f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 15f, 0.05f, 193000.0, 0.31, 207.0, 7750.0);

	public static Material Titanium => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989664), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.3f, 0.3f, 0.3f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 15f, 0.05f, 96000.0, 0.36, 930.0, 4620.0);

	public static Material Magnesium => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989645), new float[4] { 0.02f, 0.02f, 0.02f, 1f }, new float[4] { 0.5f, 0.5f, 0.5f, 1f }, new float[4] { 0.4f, 0.4f, 0.4f, 1f }, 15f, 0.05f, 45000.0, 0.35, 193.0, 1800.0);

	public double ShearModulus => Young / (2.0 * (Poisson + 1.0));

	public event KeyChangedEventHandler KeyChanged
	{
		[CompilerGenerated]
		add
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Combine(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Remove(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
	}

	public Material(string name)
		: this(name, 200000.0, 0.3, 250.0, 7850.0, 0.2)
	{
		Description = string.Empty;
		Diffuse = Color.White;
		_0023_003DzMnRLDukscTra();
	}

	internal Material(string _0023_003DzS_00246o7tc_003D, double _0023_003DzXwofP_4n6Lm0, double _0023_003Dzhbqvb2ebra9h, double _0023_003DzK0GapdI_003D, double _0023_003DzWT1C51duPPDt, double _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D, elementType _0023_003DzVaHdB7k_003D = elementType.PlaneStress, double _0023_003DzOzWsoa3hayMy = 1.0)
	{
		Name = _0023_003DzS_00246o7tc_003D;
		Young = _0023_003DzXwofP_4n6Lm0;
		Poisson = _0023_003Dzhbqvb2ebra9h;
		YieldStrength = _0023_003DzK0GapdI_003D;
		Density = _0023_003DzWT1C51duPPDt;
		CoeffOfThermalExp = _0023_003DzpxN6oMLFeo5cgeUIgu_0024hoiw_003D;
		ElementType = _0023_003DzVaHdB7k_003D;
		ElementThickness = _0023_003DzOzWsoa3hayMy;
	}

	public Material(string name, Color diffuse)
		: this(name)
	{
		Diffuse = diffuse;
	}

	public Material(string name, byte[] texture)
		: this(name)
	{
		TextureImage = texture;
		Diffuse = Color.White;
	}

	public Material(string name, Color ambient, Color specular, float shininess, float environment, byte[] texture)
		: this(name, ambient, Color.White, specular, shininess, environment, texture)
	{
	}

	public Material(string name, Color ambient, Color diffuse, Color specular, float shininess)
		: this(name, ambient, diffuse, specular, shininess, 0.05f, null, null)
	{
	}

	public Material(string name, Color ambient, Color diffuse, Color specular, float shininess, float environment)
		: this(name, ambient, diffuse, specular, shininess, environment, null, null)
	{
	}

	public Material(string name, Color ambient, Color diffuse, Color specular, float shininess, float environment, byte[] texture)
		: this(name, ambient, diffuse, specular, shininess, environment, texture, null)
	{
	}

	public Material(string name, Color ambient, Color diffuse, Color specular, float shininess, float environment, byte[] texture, byte[] environmentMapping)
	{
		Name = name;
		Ambient = ambient;
		Specular = specular;
		Shininess = shininess;
		Diffuse = Color.White;
		TextureImage = texture;
		Environment = environment;
		Diffuse = diffuse;
		EnvironmentMappingImage = environmentMapping;
	}

	public Material(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp)
		: this(name, young, poisson, yield, density, coeffOfThermExp)
	{
		Diffuse = diffuse;
		_0023_003DzMnRLDukscTra();
	}

	public Material(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, elementType elType, double elThickness)
		: this(name, young, poisson, yield, density, coeffOfThermExp, elType, elThickness)
	{
		Diffuse = diffuse;
		_0023_003DzMnRLDukscTra();
	}

	public Material(string name, Color ambient, Color specular, float shininess, byte[] texture)
		: this(name, ambient, Color.White, specular, shininess, 0.05f, texture)
	{
	}

	public Material(string name, double density, linearUnitsType linearUnits, massUnitsType massUnits)
		: this(name)
	{
		Density = density;
		MassUnits = massUnits;
		LinearUnits = linearUnits;
	}

	private Material(string _0023_003DzS_00246o7tc_003D, float[] _0023_003Dzipaw82JJGX8g, float[] _0023_003DzAin4TLD5K0aX, float[] _0023_003DzUn9OujHajGs72RBXGg_003D_003D, float _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D, float _0023_003DzbHoYb6Y_003D, double _0023_003DzXwofP_4n6Lm0, double _0023_003Dzhbqvb2ebra9h, double _0023_003DzK0GapdI_003D, double _0023_003DzWT1C51duPPDt)
		: this(_0023_003DzS_00246o7tc_003D, _0023_003DzXwofP_4n6Lm0, _0023_003Dzhbqvb2ebra9h, _0023_003DzK0GapdI_003D, _0023_003DzWT1C51duPPDt, 0.0)
	{
		Ambient = Utility.FloatArrayToColor(_0023_003Dzipaw82JJGX8g);
		Diffuse = Utility.FloatArrayToColor(_0023_003DzAin4TLD5K0aX);
		Specular = Utility.FloatArrayToColor(_0023_003DzUn9OujHajGs72RBXGg_003D_003D);
		Shininess = _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D / 128f;
		Environment = _0023_003DzbHoYb6Y_003D;
		TextureImage = null;
	}

	protected Material(Material another)
		: this(another, _0023_003Dz9iVGZxORnDNTx_P_00241w_003D_003D: false)
	{
	}

	private Material(Material _0023_003DzySgeilxprQOK, bool _0023_003Dz9iVGZxORnDNTx_P_00241w_003D_003D)
	{
		Name = _0023_003DzySgeilxprQOK.Name;
		Description = _0023_003DzySgeilxprQOK.Description;
		Ambient = _0023_003DzySgeilxprQOK.Ambient;
		Diffuse = _0023_003DzySgeilxprQOK.Diffuse;
		Specular = _0023_003DzySgeilxprQOK.Specular;
		Shininess = _0023_003DzySgeilxprQOK.Shininess;
		if (_0023_003Dz9iVGZxORnDNTx_P_00241w_003D_003D)
		{
			TextureImage = _0023_003DzySgeilxprQOK.TextureImage;
			EnvironmentMappingImage = _0023_003DzySgeilxprQOK.EnvironmentMappingImage;
			AlphaMapImage = _0023_003DzySgeilxprQOK.AlphaMapImage;
		}
		else
		{
			if (_0023_003DzySgeilxprQOK.TextureImage != null)
			{
				TextureImage = (byte[])_0023_003DzySgeilxprQOK.TextureImage.Clone();
			}
			if (_0023_003DzySgeilxprQOK.EnvironmentMappingImage != null)
			{
				EnvironmentMappingImage = (byte[])_0023_003DzySgeilxprQOK.EnvironmentMappingImage.Clone();
			}
			if (_0023_003DzySgeilxprQOK.AlphaMapImage != null)
			{
				AlphaMapImage = (byte[])_0023_003DzySgeilxprQOK.AlphaMapImage.Clone();
			}
		}
		Environment = _0023_003DzySgeilxprQOK.Environment;
		TextureImageOverExposure = _0023_003DzySgeilxprQOK.TextureImageOverExposure;
		MagnifyingFunction = _0023_003DzySgeilxprQOK.MagnifyingFunction;
		MinifyingFunction = _0023_003DzySgeilxprQOK.MinifyingFunction;
		RepeatX = _0023_003DzySgeilxprQOK.RepeatX;
		RepeatY = _0023_003DzySgeilxprQOK.RepeatY;
		Young = _0023_003DzySgeilxprQOK.Young;
		Poisson = _0023_003DzySgeilxprQOK.Poisson;
		YieldStrength = _0023_003DzySgeilxprQOK.YieldStrength;
		Density = _0023_003DzySgeilxprQOK.Density;
		CoeffOfThermalExp = _0023_003DzySgeilxprQOK.CoeffOfThermalExp;
		ElementType = _0023_003DzySgeilxprQOK.ElementType;
		ElementThickness = _0023_003DzySgeilxprQOK.ElementThickness;
		LinearUnits = _0023_003DzySgeilxprQOK.LinearUnits;
		MassUnits = _0023_003DzySgeilxprQOK.MassUnits;
		TextureLength = _0023_003DzySgeilxprQOK.TextureLength;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Material()
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988358), _0023_003Dz5KguOoA_003D++))
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Material(Color diffuse)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988358), _0023_003Dz5KguOoA_003D++), diffuse)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Material(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988358), _0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Material(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, elementType elType, double elThickness)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988358), _0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, elType, elThickness)
	{
	}

	protected Material(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		Description = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019));
		Ambient = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953522), typeof(Color));
		Diffuse = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953536), typeof(Color));
		Specular = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953970), typeof(Color));
		Shininess = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953518));
		Environment = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953502));
		TextureImage = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974225), typeof(byte[]));
		EnvironmentMappingImage = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988352), typeof(byte[]));
		AlphaMapImage = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988318), typeof(byte[]));
		TextureImageOverExposure = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988530));
		minFunc = (textureFilteringFunctionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988527), typeof(textureFilteringFunctionType));
		magFunc = (textureFilteringFunctionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988490), typeof(textureFilteringFunctionType));
		repeatX = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988452));
		repeatY = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988434));
		Young = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988448));
		Poisson = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988428));
		YieldStrength = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989178));
		Density = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989158));
		CoeffOfThermalExp = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989140));
		ElementType = (elementType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989113), typeof(elementType));
		ElementThickness = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989102));
		LinearUnits = (linearUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989062), typeof(linearUnitsType));
		MassUnits = (massUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951035), typeof(massUnitsType));
		TextureLength = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989304));
	}

	protected internal Material(MaterialSurrogate surrogate)
		: this(surrogate.Name)
	{
	}

	protected virtual void OnKeyChanged(string newKey, [CallerMemberName] string propertyName = null)
	{
		_0023_003Dzs0Yhv2U_003D?.Invoke(this, new KeyChangedEventArgs(propertyName, newKey));
	}

	public string GetKey()
	{
		return Name;
	}

	public void SetKey(string value)
	{
		Name = value;
	}

	internal void _0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(IEnvironment _0023_003DzPzO_0024GUk_003D)
	{
		EnvironmentMappingTexture = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzIQplSf_Uzh2h()
	{
		if (Texture == null || Texture.Bitmap == null)
		{
			_wireColor = Diffuse;
			return;
		}
		double num = (double)(int)Diffuse.R / 255.0;
		double num2 = (double)(int)Diffuse.G / 255.0;
		double num3 = (double)(int)Diffuse.B / 255.0;
		_wireColor = Color.FromArgb(Diffuse.A, (int)((double)(int)Texture.FirstPixelColor.R * num), (int)((double)(int)Texture.FirstPixelColor.G * num2), (int)((double)(int)Texture.FirstPixelColor.B * num3));
	}

	internal void _0023_003DzMnRLDukscTra()
	{
		Ambient = Color.FromArgb(25, 25, 25);
		Specular = Color.White;
		Shininess = 1f;
		_0023_003DzhrE6poBx7AWX();
		Environment = 0.05f;
	}

	private void _0023_003DzhrE6poBx7AWX()
	{
		if (Texture != null)
		{
			Texture.Dispose();
		}
		if (AlphaMap != null)
		{
			AlphaMap.Dispose();
		}
		Texture = null;
		AlphaMap = null;
	}

	internal virtual Material SoftClone()
	{
		return new Material(this, _0023_003Dz9iVGZxORnDNTx_P_00241w_003D_003D: true);
	}

	public virtual object Clone()
	{
		return new Material(this, _0023_003Dz9iVGZxORnDNTx_P_00241w_003D_003D: false);
	}

	public void Dispose()
	{
		_0023_003DzhrE6poBx7AWX();
		if (EnvironmentMappingTexture != null)
		{
			EnvironmentMappingTexture.Dispose();
		}
		_0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(null);
	}

	public void LoadTexture(RenderContextBase renderContext)
	{
		bool anisotropicFiltering = true;
		if (minFunc == textureFilteringFunctionType.Nearest || minFunc == textureFilteringFunctionType.NearestMipmapNearest || magFunc == textureFilteringFunctionType.Nearest || magFunc == textureFilteringFunctionType.NearestMipmapNearest)
		{
			anisotropicFiltering = false;
		}
		if (TextureImage != null)
		{
			if (Texture == null)
			{
				Texture = renderContext.CreateTexture2D();
			}
			Texture.SetImage(TextureImage);
			Texture.Load(renderContext, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY);
			_0023_003DzIQplSf_Uzh2h();
		}
		if (AlphaMapImage != null)
		{
			if (AlphaMap == null)
			{
				AlphaMap = renderContext.CreateTexture2D();
			}
			AlphaMap.SetImage(AlphaMapImage);
			AlphaMap.Load(renderContext, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY);
		}
		if (EnvironmentMappingImage != null)
		{
			if (EnvironmentMappingTexture == null)
			{
				_0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(renderContext.CreateEnvironment(EnvironmentMappingImage));
			}
			else
			{
				((TextureBase)EnvironmentMappingTexture).SetImage(EnvironmentMappingImage);
			}
			((TextureBase)EnvironmentMappingTexture).Load(renderContext, minFunc, magFunc, anisotropicFiltering);
		}
	}

	public virtual void CalcMaterialPropertyMatrix(int numberOfDimensions, elementType elType)
	{
		double[,] array = null;
		switch (numberOfDimensions)
		{
		case 2:
			switch (elType)
			{
			case elementType.PlaneStress:
			{
				array = new double[3, 3];
				double num = (array[1, 1] = (array[0, 0] = Young / (1.0 - Poisson * Poisson)));
				array[0, 1] = num * Poisson;
				array[1, 0] = array[0, 1];
				array[2, 2] = (1.0 - Poisson) * num / 2.0;
				break;
			}
			case elementType.PlaneStrain:
			{
				array = new double[3, 3];
				double num = (array[1, 1] = (array[0, 0] = Young * (1.0 - Poisson) / ((1.0 + Poisson) * (1.0 - 2.0 * Poisson))));
				array[0, 1] = num * Poisson / (1.0 - Poisson);
				array[1, 0] = array[0, 1];
				array[2, 2] = (1.0 - 2.0 * Poisson) * num / (2.0 * (1.0 - Poisson));
				break;
			}
			case elementType.Axisymmetric:
			{
				array = new double[4, 4];
				double num = (array[0, 0] = Young * (1.0 - Poisson) / ((1.0 + Poisson) * (1.0 - 2.0 * Poisson)));
				array[1, 0] = num * Poisson / (1.0 - Poisson);
				array[2, 0] = num * Poisson / (1.0 - Poisson);
				array[0, 1] = num * Poisson / (1.0 - Poisson);
				array[1, 1] = num;
				array[2, 1] = num * Poisson / (1.0 - Poisson);
				array[0, 2] = num * Poisson / (1.0 - Poisson);
				array[1, 2] = num * Poisson / (1.0 - Poisson);
				array[2, 2] = num;
				array[3, 3] = (1.0 - 2.0 * Poisson) * num / (2.0 * (1.0 - Poisson));
				break;
			}
			}
			break;
		case 3:
		{
			array = new double[6, 6];
			double num = (array[2, 2] = (array[1, 1] = (array[0, 0] = Young * (1.0 - Poisson) / ((1.0 + Poisson) * (1.0 - 2.0 * Poisson)))));
			array[3, 3] = num * (1.0 - 2.0 * Poisson) / (2.0 * (1.0 - Poisson));
			array[4, 4] = array[3, 3];
			array[5, 5] = array[4, 4];
			array[0, 1] = num * Poisson / (1.0 - Poisson);
			array[1, 0] = array[0, 1];
			array[0, 2] = array[1, 0];
			array[2, 0] = array[0, 2];
			array[1, 2] = array[2, 0];
			array[2, 1] = array[1, 2];
			break;
		}
		}
		D = array;
	}

	public void ClearTexture()
	{
		_0023_003DzhrE6poBx7AWX();
		TextureImage = null;
		AlphaMapImage = null;
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Name);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), Description);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953522), Ambient);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953536), Diffuse);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953970), Specular);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953518), Shininess);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953502), Environment);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974225), TextureImage);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988352), EnvironmentMappingImage);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988318), AlphaMapImage);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988530), TextureImageOverExposure);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988527), minFunc);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988490), magFunc);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988452), repeatX);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988434), repeatY);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988448), Young);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988428), Poisson);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989178), YieldStrength);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989158), Density);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989140), CoeffOfThermalExp);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989113), ElementType);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989102), ElementThickness);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989062), LinearUnits);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951035), MassUnits);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989304), TextureLength);
	}

	public override string ToString()
	{
		return Name;
	}

	public bool Equals(Material other)
	{
		if (other != null)
		{
			return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
	}

	private static void _0023_003DzdBp9Yuc_003D(string _0023_003Dz9ETXvT8_003D, TextWriter _0023_003DzzvTcRNc_003D, string _0023_003DzCJkr8nY_003D, string _0023_003Dzalvl9z8_003D, string _0023_003DzfPTdgzI_003D, TextureBase _0023_003DzqeyvB5U_003D, byte[] _0023_003DzqwYd0N8_003D)
	{
		if (_0023_003DzqwYd0N8_003D != null)
		{
			string text = WriteFileAsync.RemoveInvalidChars(_0023_003Dz9ETXvT8_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989229);
			string fullPath = Path.GetFullPath(string.IsNullOrEmpty(_0023_003DzCJkr8nY_003D) ? text : Path.Combine(_0023_003DzCJkr8nY_003D, text));
			Utility._0023_003DzJf6X3nCs4sU4hFurtQ_003D_003D(_0023_003DzqwYd0N8_003D, fullPath);
			_0023_003DzzvTcRNc_003D.WriteLine(Path.Combine(_0023_003DzfPTdgzI_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dzalvl9z8_003D, text));
		}
	}

	public virtual MaterialSurrogate ConvertToSurrogate()
	{
		return new MaterialSurrogate(this);
	}

	public void FreeResources()
	{
		if (Texture != null)
		{
			Texture.FreeResources();
		}
		if (EnvironmentMappingTexture != null)
		{
			((TextureBase)EnvironmentMappingTexture).FreeResources();
		}
		Texture = null;
		_0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(null);
		if (AlphaMap != null)
		{
			AlphaMap.FreeResources();
		}
	}

	internal void _0023_003DzxQ8X8IjIfcvf35mk1A_003D_003D()
	{
	}

	public static double GetPoissonFromShearModulus(double young, double shearModulus)
	{
		return young / (2.0 * shearModulus) - 1.0;
	}

	public bool SetTexture(RenderContextBase renderContext)
	{
		bool result = renderContext.SetTexture(Texture);
		renderContext.SetAlphaTexture(AlphaMap);
		return result;
	}

	public bool IsTransparent()
	{
		if (AlphaMapImage != null)
		{
			return true;
		}
		return Diffuse.A < byte.MaxValue;
	}
}
