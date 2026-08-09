using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Serialization;

public class TextureMappingDataSurrogate : Surrogate<TextureMappingData>
{
	public Transformation Transformation;

	public Point3D Max;

	public Point3D Min;

	public byte MappingMode;

	public double ScaleX;

	public double ScaleY;

	public TextureMappingDataSurrogate(TextureMappingData tmd)
		: base(tmd)
	{
	}

	protected override TextureMappingData ConvertToObject()
	{
		TextureMappingData textureMappingData = new TextureMappingData((textureMappingType)MappingMode, ScaleX, ScaleY, Min, Max);
		CopyDataToObject(textureMappingData);
		return textureMappingData;
	}

	protected override void CopyDataToObject(TextureMappingData tmd)
	{
		tmd.Transformation = Transformation;
	}

	protected override void CopyDataFromObject(TextureMappingData tmd)
	{
		MappingMode = (byte)tmd.MappingMode;
		ScaleX = tmd.ScaleX;
		ScaleY = tmd.ScaleY;
		Min = tmd.Min;
		Max = tmd.Max;
		Transformation = tmd.Transformation;
	}

	public static implicit operator TextureMappingData(TextureMappingDataSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator TextureMappingDataSurrogate(TextureMappingData source)
	{
		return source?.ConvertToSurrogate();
	}
}
