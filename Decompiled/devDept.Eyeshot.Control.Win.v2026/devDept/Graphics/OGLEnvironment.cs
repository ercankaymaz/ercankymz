using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace devDept.Graphics;

[Serializable]
public class OGLEnvironment : OGLTexture, IEnvironment
{
	public OGLEnvironment()
	{
	}

	public OGLEnvironment(byte[] environmentImage)
		: this()
	{
		SetImage(environmentImage);
	}

	public OGLEnvironment(Image environmentImage)
		: this()
	{
		_0023_003DzCT0ooac_003D(environmentImage, _0023_003DzYI_0024_E9M_003D: false);
	}

	protected OGLEnvironment(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public void Enable(RenderContextBase context, float intensity)
	{
		SetTextureInternal(context, textureUnitType.Environment);
	}

	public void Disable(RenderContextBase context)
	{
		context.CloseTexture(this);
	}
}
