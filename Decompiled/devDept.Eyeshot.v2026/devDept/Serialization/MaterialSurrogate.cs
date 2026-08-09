using System.Drawing;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Serialization;

public class MaterialSurrogate : Surrogate<Material>
{
	public string Name;

	public string Description;

	public ProtoImage AlphaMapImage;

	public Color Ambient;

	public Color Diffuse;

	public Color Specular;

	public float Shininess;

	public float Environment;

	public ProtoImage TextureImage;

	public ProtoImage EnvironmentMappingImage;

	public double CoeffOfThermalExp;

	public double Density;

	public double ElementThickness;

	public byte ElementType;

	public byte MagnifyingFunction;

	public byte MinifyingFunction;

	public double Poisson;

	public bool RepeatX;

	public bool RepeatY;

	public double YieldStrength;

	public double Young;

	public byte LinearUnits;

	public byte MassUnits;

	public float TextureLength;

	public MaterialSurrogate(Material material)
		: base(material)
	{
	}

	protected override Material ConvertToObject()
	{
		Material material = new Material(this);
		CopyDataToObject(material);
		return material;
	}

	protected override void CopyDataToObject(Material material)
	{
		material.Description = Description;
		material.AlphaMapImage = AlphaMapImage?.Data;
		material.Ambient = Ambient;
		material.Diffuse = Diffuse;
		material.Specular = Specular;
		material.Shininess = Shininess;
		material.Environment = Environment;
		material.TextureImage = TextureImage?.Data;
		material.EnvironmentMappingImage = EnvironmentMappingImage?.Data;
		material.CoeffOfThermalExp = CoeffOfThermalExp;
		material.Density = Density;
		material.ElementThickness = ElementThickness;
		material.ElementType = (elementType)ElementType;
		material.MagnifyingFunction = (textureFilteringFunctionType)MagnifyingFunction;
		material.MinifyingFunction = (textureFilteringFunctionType)MinifyingFunction;
		material.Poisson = Poisson;
		material.RepeatX = RepeatX;
		material.RepeatY = RepeatY;
		material.YieldStrength = YieldStrength;
		material.Young = Young;
		if (base.Version < 7)
		{
			material.LinearUnits = linearUnitsType.Unitless;
			material.MassUnits = massUnitsType.Unitless;
			material.TextureLength = 1f;
		}
		else
		{
			material.LinearUnits = (linearUnitsType)LinearUnits;
			material.MassUnits = (massUnitsType)MassUnits;
			material.TextureLength = TextureLength;
		}
	}

	protected override void CopyDataFromObject(Material material)
	{
		Name = material.Name;
		Description = material.Description;
		if (material.AlphaMapImage != null)
		{
			AlphaMapImage = new ProtoImage(material.AlphaMapImage);
		}
		Ambient = material.Ambient;
		Diffuse = material.Diffuse;
		Specular = material.Specular;
		Shininess = material.Shininess;
		Environment = material.Environment;
		if (material.TextureImage != null)
		{
			TextureImage = new ProtoImage(material.TextureImage);
		}
		if (material.EnvironmentMappingImage != null)
		{
			EnvironmentMappingImage = new ProtoImage(material.EnvironmentMappingImage);
		}
		CoeffOfThermalExp = material.CoeffOfThermalExp;
		Density = material.Density;
		ElementThickness = material.ElementThickness;
		ElementType = (byte)material.ElementType;
		MagnifyingFunction = (byte)material.MagnifyingFunction;
		MinifyingFunction = (byte)material.MinifyingFunction;
		Poisson = material.Poisson;
		RepeatX = material.RepeatX;
		RepeatY = material.RepeatY;
		YieldStrength = material.YieldStrength;
		Young = material.Young;
		LinearUnits = (byte)material.LinearUnits;
		MassUnits = (byte)material.MassUnits;
		TextureLength = material.TextureLength;
	}

	public static implicit operator Material(MaterialSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator MaterialSurrogate(Material source)
	{
		return source?.ConvertToSurrogate();
	}
}
