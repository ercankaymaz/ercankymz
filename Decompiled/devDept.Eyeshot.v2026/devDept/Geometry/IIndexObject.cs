using System.Collections.Generic;

namespace devDept.Geometry;

public interface IIndexObject
{
	bool WouldContainDuplicates(IReadOnlyList<int> mappings);

	void Reindex(IReadOnlyList<int> mappings);
}
