using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using DSTV.Net.Contracts;

namespace DSTV.Net.Data;

public record DstvRecord : IDstv
{
	public IEnumerable<DstvElement> Elements { get; init; } = new List<DstvElement>();

	public IDstvHeader? Header { get; init; }

	public string ToSvg()
	{
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		try
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
			return $"<svg viewbox=\"0 0 {Header?.Length} {Header?.ProfileHeight}\" width=\"{Header?.Length}\" height=\"{Header?.ProfileHeight}\" xmlns=\"http://www.w3.org/2000/svg\">{string.Concat(from d in Elements
				orderby d is Contour descending
				select d.ToSvg())}</svg>";
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = currentCulture;
		}
	}
}
