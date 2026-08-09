using System.IO;

namespace Org.BouncyCastle.Crypto;

public interface IStreamCalculator<out TResult>
{
	Stream Stream { get; }

	TResult GetResult();
}
