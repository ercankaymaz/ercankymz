namespace devDept.Graphics;

public interface IShaderTechnique : IShader
{
	IShader Shader { get; set; }

	IShader GeometryShader { get; set; }

	bool UpdatedInFrame { get; set; }
}
