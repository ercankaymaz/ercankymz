using System;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class TextureMappingData : ICloneable
{
	public Transformation Transformation { get; set; }

	public Point3D Max { get; set; }

	public Point3D Min { get; set; }

	public textureMappingType MappingMode { get; set; }

	public double ScaleX { get; set; }

	public double ScaleY { get; set; }

	public TextureMappingData(textureMappingType mappingMode, double scaleX, double scaleY, Point3D min, Point3D max)
		: this(mappingMode, scaleX, scaleY, min, max, null)
	{
	}

	public TextureMappingData(textureMappingType mappingMode, double scaleX, double scaleY, Point3D min, Point3D max, Transformation transformation)
	{
		Max = max;
		Min = min;
		MappingMode = mappingMode;
		ScaleX = scaleX;
		ScaleY = scaleY;
		Transformation = transformation;
	}

	public TextureMappingData(TextureMappingData another)
	{
		ScaleX = another.ScaleX;
		ScaleY = another.ScaleY;
		Min = (Point3D)another.Min.Clone();
		Max = (Point3D)another.Max.Clone();
		MappingMode = another.MappingMode;
		if (another.Transformation != null)
		{
			Transformation = (Transformation)another.Transformation.Clone();
		}
	}

	public virtual object Clone()
	{
		return new TextureMappingData(this);
	}

	public TextureMappingDataSurrogate ConvertToSurrogate()
	{
		return new TextureMappingDataSurrogate(this);
	}
}
