using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IReferenceResolver
{
	object ResolveReference(object context, string reference);

	string GetReference(object context, object value);

	bool IsReferenced(object context, object value);

	void AddReference(object context, string reference, object value);
}
