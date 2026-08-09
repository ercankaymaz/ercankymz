namespace devDept.Graphics;

public interface IDataPerObject
{
	float[] WorldViewProj { get; }

	float[] WorldView { get; }

	float[] WorldViewInvTranspose { get; }

	float[] Model { get; }

	float[] View { get; }

	float[] Projection { get; }

	float[] InverseModel { get; }

	float[] InverseView { get; }

	float[] InverseProjection { get; }

	IGraphicMaterial FrontMaterial { get; }

	IGraphicMaterial BackMaterial { get; }

	float[] Color { get; }

	bool Clippable { get; }
}
