using System.IO;
using System.Threading.Tasks;

namespace DSTV.Net.Contracts;

public interface IDstvReader
{
	Task<IDstv> ParseAsync(string dstvData);

	Task<IDstv> ParseAsync(TextReader reader);
}
