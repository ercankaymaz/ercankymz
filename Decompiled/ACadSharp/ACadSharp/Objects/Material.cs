using ACadSharp.Attributes;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Objects;

[DxfName("MATERIAL")]
[DxfSubClass("AcDbMaterial")]
public class Material : NonGraphicalObject
{
	private double _ambientColorFactor = 1.0;

	private double _diffuseColorFactor = 1.0;

	private double _specularColorFactor = 1.0;

	[DxfCodeValue(new int[] { 90 })]
	public Color AmbientColor { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double AmbientColorFactor
	{
		get
		{
			return _ambientColorFactor;
		}
		set
		{
			value.InRange(0.0, 1.0, inclusive: true, "AmbientColorFactor");
			_ambientColorFactor = value;
		}
	}

	[DxfCodeValue(new int[] { 70 })]
	public ColorMethod AmbientColorMethod { get; set; }

	[DxfCodeValue(new int[] { 272 })]
	public AutoTransformMethodFlags BumpAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 143 })]
	public double BumpMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 8 })]
	public string BumpMapFileName { get; set; }

	[DxfCodeValue(new int[] { 179 })]
	public MapSource BumpMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 144 })]
	public Matrix4 BumpMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 270 })]
	public ProjectionMethod BumpProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 271 })]
	public TilingMethod BumpTilingMethod { get; set; } = TilingMethod.Tile;

	[DxfCodeValue(new int[] { 94 })]
	public int ChannelFlags { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public string Description { get; set; }

	[DxfCodeValue(new int[] { 75 })]
	public AutoTransformMethodFlags DiffuseAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 91 })]
	public Color DiffuseColor { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double DiffuseColorFactor
	{
		get
		{
			return _diffuseColorFactor;
		}
		set
		{
			value.InRange(0.0, 1.0, inclusive: true, "DiffuseColorFactor");
			_diffuseColorFactor = value;
		}
	}

	[DxfCodeValue(new int[] { 71 })]
	public ColorMethod DiffuseColorMethod { get; set; }

	[DxfCodeValue(new int[] { 42 })]
	public double DiffuseMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 3 })]
	public string DiffuseMapFileName { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public MapSource DiffuseMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 43 })]
	public Matrix4 DiffuseMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 73 })]
	public ProjectionMethod DiffuseProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 74 })]
	public TilingMethod DiffuseTilingMethod { get; set; } = TilingMethod.Tile;

	[DxfCodeValue(new int[] { 93 })]
	public int IlluminationModel { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public override string ObjectName => "MATERIAL";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 140 })]
	public double Opacity { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 178 })]
	public AutoTransformMethodFlags OpacityAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 141 })]
	public double OpacityMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 7 })]
	public string OpacityMapFileName { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public MapSource OpacityMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 142 })]
	public Matrix4 OpacityMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 176 })]
	public ProjectionMethod OpacityProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 177 })]
	public TilingMethod OpacityTilingMethod { get; set; } = TilingMethod.Tile;

	[DxfCodeValue(new int[] { 174 })]
	public AutoTransformMethodFlags ReflectionAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 48 })]
	public double ReflectionMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 6 })]
	public string ReflectionMapFileName { get; set; }

	[DxfCodeValue(new int[] { 171 })]
	public MapSource ReflectionMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 49 })]
	public Matrix4 ReflectionMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 172 })]
	public ProjectionMethod ReflectionProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 173 })]
	public TilingMethod ReflectionTilingMethod { get; set; } = TilingMethod.Tile;

	[DxfCodeValue(new int[] { 468 })]
	public double Reflectivity { get; set; }

	[DxfCodeValue(new int[] { 276 })]
	public AutoTransformMethodFlags RefractionAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 145 })]
	public double RefractionIndex { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 146 })]
	public double RefractionMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 9 })]
	public string RefractionMapFileName { get; set; }

	[DxfCodeValue(new int[] { 273 })]
	public MapSource RefractionMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 147 })]
	public Matrix4 RefractionMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 274 })]
	public ProjectionMethod RefractionProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 275 })]
	public TilingMethod RefractionTilingMethod { get; set; } = TilingMethod.Tile;

	[DxfCodeValue(new int[] { 170 })]
	public AutoTransformMethodFlags SpecularAutoTransform { get; set; } = AutoTransformMethodFlags.NoAutoTransform;

	[DxfCodeValue(new int[] { 92 })]
	public Color SpecularColor { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double SpecularColorFactor
	{
		get
		{
			return _specularColorFactor;
		}
		set
		{
			value.InRange(0.0, 1.0, inclusive: true, "SpecularColorFactor");
			_specularColorFactor = value;
		}
	}

	[DxfCodeValue(new int[] { 76 })]
	public ColorMethod SpecularColorMethod { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double SpecularGlossFactor { get; set; } = 0.5;

	[DxfCodeValue(new int[] { 46 })]
	public double SpecularMapBlendFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 4 })]
	public string SpecularMapFileName { get; set; }

	[DxfCodeValue(new int[] { 77 })]
	public MapSource SpecularMapSource { get; set; } = MapSource.UseImageFile;

	[DxfCodeValue(new int[] { 47 })]
	public Matrix4 SpecularMatrix { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 78 })]
	public ProjectionMethod SpecularProjectionMethod { get; set; } = ProjectionMethod.Planar;

	[DxfCodeValue(new int[] { 79 })]
	public TilingMethod SpecularTilingMethod { get; set; } = TilingMethod.Tile;

	public override string SubclassMarker => "AcDbMaterial";

	[DxfCodeValue(new int[] { 148 })]
	public double Translucence { get; set; }

	public Material(string name)
		: base(name)
	{
	}

	internal Material()
	{
	}
}
