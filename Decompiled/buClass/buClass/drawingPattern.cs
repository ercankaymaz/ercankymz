using System;

namespace buClass;

[Serializable]
public class drawingPattern : buSerilization
{
	public float[] Type = new float[2] { 5f, -0.001f };

	public string Name = "Solid";

	public drawingPattern()
	{
	}

	public drawingPattern(drawingPattern pattern)
	{
		Name = pattern.Name;
		Type = new float[pattern.Type.Length];
		for (int i = 0; i <= pattern.Type.Length - 1; i++)
		{
			Type[i] = pattern.Type[i];
		}
	}

	public override string ToString()
	{
		return Name;
	}
}
