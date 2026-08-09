namespace devDept.Graphics;

public interface IGraphicMaterial
{
	float[] Ambient { get; }

	float[] Diffuse { get; }

	float[] Specular { get; }

	float Shininess { get; }
}
