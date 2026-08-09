namespace devDept.Graphics;

public interface ILightsData
{
	float[] Position { get; }

	float[] Direction { get; }

	float[] Ambient { get; }

	float[] Diffuse { get; }

	float[] Specular { get; }

	float ConstantAttenuation { get; }

	float LinearAttenuation { get; }

	float QuadraticAttenuation { get; }

	float SpotCosCutoff { get; }

	float SpotExponent { get; }

	int YieldShadow { get; }

	lightType Type { get; }
}
