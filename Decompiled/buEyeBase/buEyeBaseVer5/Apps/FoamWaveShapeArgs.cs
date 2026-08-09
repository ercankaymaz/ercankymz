using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class FoamWaveShapeArgs : buSerilization5
{
	public double StartWidthOffset = 0.0;

	public double ZPos = 0.0;

	public double Height = 0.0;

	public double Width;

	public double BaseHeight = 0.0;

	public int WaveCount = 0;

	public int RepeatCount = 0;

	public double ZOffset = 0.0;

	public FoamPlaneType refPlane = FoamPlaneType.XZ;

	public SizeObject Size = new SizeObject();

	public double CuttingSpeed = 0.0;

	public double RoundRadius = 0.0;

	public double ChamferLen = 0.0;

	public FoamWaveShapeArgs()
	{
	}

	public FoamWaveShapeArgs(double startWidthOffset, double zPos, double height, double width, double baseHeight, int waveCount, int repeatCount, double zOffset, double cuttingSpeed, double roundRadius, double chamferLen, FoamPlaneType refplane, SizeObject size)
	{
		StartWidthOffset = startWidthOffset;
		ZPos = zPos;
		Height = height;
		Width = width;
		BaseHeight = baseHeight;
		WaveCount = waveCount;
		RepeatCount = repeatCount;
		CuttingSpeed = cuttingSpeed;
		RoundRadius = roundRadius;
		ChamferLen = chamferLen;
		refPlane = refplane;
		Size = new SizeObject(size);
		ZOffset = zOffset;
	}

	public FoamWaveShapeArgs(FoamWaveShapeArgs data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
