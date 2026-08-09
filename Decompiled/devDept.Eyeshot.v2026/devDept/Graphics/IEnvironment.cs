namespace devDept.Graphics;

public interface IEnvironment
{
	void Enable(RenderContextBase context, float intensity);

	void Disable(RenderContextBase context);

	void Dispose();
}
