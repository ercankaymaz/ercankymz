using devDept.Eyeshot;

namespace devDept.Serialization;

public class HatchPatternSurrogate : Surrogate<HatchPattern>
{
	public string Name;

	public HatchPatternLine[] Lines;

	public string Description;

	public HatchPatternSurrogate(HatchPattern hatchPattern)
		: base(hatchPattern)
	{
	}

	protected override HatchPattern ConvertToObject()
	{
		if (Lines == null)
		{
			Lines = new HatchPatternLine[0];
		}
		HatchPattern hatchPattern = new HatchPattern(this);
		CopyDataToObject(hatchPattern);
		return hatchPattern;
	}

	protected override void CopyDataToObject(HatchPattern hatchPattern)
	{
	}

	protected override void CopyDataFromObject(HatchPattern hatchPattern)
	{
		Name = hatchPattern.Name;
		Lines = hatchPattern.Lines;
		Description = hatchPattern.Description;
	}

	public static implicit operator HatchPattern(HatchPatternSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator HatchPatternSurrogate(HatchPattern source)
	{
		return source?.ConvertToSurrogate();
	}
}
