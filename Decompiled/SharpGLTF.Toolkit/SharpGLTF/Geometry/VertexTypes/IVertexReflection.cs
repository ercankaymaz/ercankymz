using System.Collections.Generic;
using SharpGLTF.Memory;

namespace SharpGLTF.Geometry.VertexTypes;

public interface IVertexReflection
{
	IEnumerable<KeyValuePair<string, AttributeFormat>> GetEncodingAttributes();
}
