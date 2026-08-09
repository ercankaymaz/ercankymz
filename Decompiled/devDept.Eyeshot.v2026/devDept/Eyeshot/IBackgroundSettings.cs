using System;
using System.Drawing;
using devDept.Graphics;

namespace devDept.Eyeshot;

public interface IBackgroundSettings : ICloneable
{
	backgroundStyleType StyleMode { get; }

	Color GetContrastColor();

	float GetImageScale(int cameraWidth, int cameraHeight, out float bmpWidth, out float bmpHeight);

	void SetTexture(RenderContextBase renderContext, TextureBase.textureUnitType textureUnit);
}
