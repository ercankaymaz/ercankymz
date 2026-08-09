namespace devDept.Graphics;

public interface IShader
{
	bool IsCompiled { get; }

	bool Compile(RenderContextBase renderContext);

	void SetParameters(object shaderParams);

	void SetEnvironmentIntensity(float intensity);

	void Validate();

	void Disable(RenderContextBase context);

	void Dispose();

	void SetParametersForShadow(object shaderParams);
}
