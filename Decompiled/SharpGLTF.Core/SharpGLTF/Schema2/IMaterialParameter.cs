using System;

namespace SharpGLTF.Schema2;

public interface IMaterialParameter
{
	string Name { get; }

	bool IsDefault { get; }

	Type ValueType { get; }

	object Value { get; set; }
}
