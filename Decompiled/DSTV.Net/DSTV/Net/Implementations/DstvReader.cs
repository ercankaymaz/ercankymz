using System;
using System.IO;
using System.Threading.Tasks;
using DSTV.Net.Contracts;
using DSTV.Net.Data;
using DSTV.Net.Exceptions;

namespace DSTV.Net.Implementations;

public sealed class DstvReader : IDstvReader
{
	public async Task<IDstv> ParseAsync(string dstvData)
	{
		using StringReader stringReader = new StringReader(dstvData);
		return await ParseAsync(stringReader).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<IDstv> ParseAsync(TextReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		ReaderContext context = new ReaderContext(reader);
		if (!string.Equals(await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false), "ST", StringComparison.Ordinal))
		{
			throw new MissingStartOfFileException(context);
		}
		context.IncrementLineNumber();
		DstvRecord dstvRecord = new DstvRecord();
		DstvRecord dstvRecord2 = dstvRecord;
		dstvRecord2.Header = await HeaderReader.ParseAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		DstvRecord dstvRecord3 = dstvRecord;
		dstvRecord3.Elements = await BodyReader.GetElementsAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		return dstvRecord;
	}
}
