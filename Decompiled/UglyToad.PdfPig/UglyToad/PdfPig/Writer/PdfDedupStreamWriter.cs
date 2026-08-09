using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal sealed class PdfDedupStreamWriter(Stream stream, bool dispose, ITokenWriter? tokenWriter = null, Action<double>? recordVersion = null) : PdfStreamWriter(stream, dispose, tokenWriter, recordVersion)
{
	private sealed class FNVByteComparison : IEqualityComparer<byte[]>
	{
		public bool Equals(byte[] x, byte[] y)
		{
			return x.AsSpan().SequenceEqual(y.AsSpan());
		}

		public int GetHashCode(byte[] obj)
		{
			FnvHash fnvHash = FnvHash.Create();
			foreach (byte data in obj)
			{
				fnvHash.Combine(data);
			}
			return fnvHash.HashCode;
		}
	}

	private struct FnvHash
	{
		public const int Offset = -2128831035;

		private const int Prime = 16777619;

		public int HashCode { get; private set; }

		public static FnvHash Create()
		{
			return new FnvHash
			{
				HashCode = -2128831035
			};
		}

		public void Combine(byte data)
		{
			HashCode ^= data;
			HashCode *= 16777619;
		}

		public void Combine(int data)
		{
			Combine((byte)data);
			Combine((byte)(data >> 8));
			Combine((byte)(data >> 16));
			Combine((byte)(data >> 24));
		}
	}

	private readonly Dictionary<byte[], IndirectReferenceToken> hashes = new Dictionary<byte[], IndirectReferenceToken>(new FNVByteComparison());

	private readonly MemoryStream ms = new MemoryStream();

	public override IndirectReferenceToken WriteToken(IToken token)
	{
		if (!base.Initialized)
		{
			InitializePdf(1.2);
		}
		ms.SetLength(0L);
		TokenWriter.WriteToken(token, ms);
		byte[] array = ms.ToArray();
		if (base.AttemptDeduplication && hashes.TryGetValue(array, out IndirectReferenceToken value))
		{
			return value;
		}
		IndirectReferenceToken indirectReferenceToken = ReserveObjectNumber();
		if (base.AttemptDeduplication)
		{
			hashes.Add(array, indirectReferenceToken);
		}
		offsets.Add(indirectReferenceToken.Data, base.Stream.Position);
		TokenWriter.WriteObject(indirectReferenceToken.Data.ObjectNumber, indirectReferenceToken.Data.Generation, array, base.Stream);
		return indirectReferenceToken;
	}

	public override IndirectReferenceToken WriteToken(IToken token, IndirectReferenceToken indirectReference)
	{
		if (!base.Initialized)
		{
			InitializePdf(1.2);
		}
		ms.SetLength(0L);
		TokenWriter.WriteToken(token, ms);
		byte[] array = ms.ToArray();
		hashes.Add(array, indirectReference);
		offsets.Add(indirectReference.Data, base.Stream.Position);
		TokenWriter.WriteObject(indirectReference.Data.ObjectNumber, indirectReference.Data.Generation, array, base.Stream);
		return indirectReference;
	}

	public new void Dispose()
	{
		hashes.Clear();
		base.Dispose();
	}
}
