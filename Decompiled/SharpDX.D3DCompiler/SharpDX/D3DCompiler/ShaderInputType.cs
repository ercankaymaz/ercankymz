namespace SharpDX.D3DCompiler;

public enum ShaderInputType
{
	ConstantBuffer,
	TextureBuffer,
	Texture,
	Sampler,
	UnorderedAccessViewRWTyped,
	Structured,
	UnorderedAccessViewRWStructured,
	ByteAddress,
	UnorderedAccessViewRWByteAddress,
	UnorderedAccessViewAppendStructured,
	UnorderedAccessViewConsumeStructured,
	UnorderedAccessViewRWStructuredWithCounter
}
