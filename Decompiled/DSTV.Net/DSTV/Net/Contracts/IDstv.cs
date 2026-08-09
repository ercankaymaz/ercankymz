using System.Collections.Generic;
using DSTV.Net.Data;

namespace DSTV.Net.Contracts;

public interface IDstv
{
	IDstvHeader? Header { get; }

	IEnumerable<DstvElement> Elements { get; }

	string ToSvg();
}
