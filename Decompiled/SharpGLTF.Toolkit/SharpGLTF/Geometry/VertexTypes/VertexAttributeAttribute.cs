using System;
using System.ComponentModel;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("The usage of this attribute has been removed because it's not AOT friendly. Implement IVertexReflection.GetEncodingAttributes() instead.", true)]
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class VertexAttributeAttribute : Attribute
{
	public string Name { get; private set; }

	public EncodingType Encoding { get; private set; }

	public bool Normalized { get; private set; }

	public VertexAttributeAttribute(string attributeName)
	{
		Name = attributeName;
		Encoding = EncodingType.FLOAT;
		Normalized = false;
	}

	public VertexAttributeAttribute(string attributeName, EncodingType encoding, bool normalized)
	{
		Name = attributeName;
		Encoding = encoding;
		Normalized = normalized;
	}
}
