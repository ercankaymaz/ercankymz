using devDept.Eyeshot;

namespace devDept.Graphics;

public class HqrData
{
	public bool EnvironmentMapping;

	public IEnvironment EnvironmentMap;

	public Material Material;

	public HqrData()
	{
	}

	public HqrData(RenderContextBase renderContext, IEnvironment environmentMap, bool environmentMapping)
	{
		EnvironmentMap = environmentMap;
		EnvironmentMapping = environmentMapping;
	}
}
