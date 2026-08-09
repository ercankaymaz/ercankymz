using System.IO;
using System.IO.Compression;

namespace System.ServiceModel.Channels;

internal static class MessageEncoderCompressionHandler
{
	internal const string GZipContentEncoding = "gzip";

	internal const string DeflateContentEncoding = "deflate";

	private const int DecompressBlockSize = 1024;

	internal static void DecompressBuffer(ref ArraySegment<byte> buffer, BufferManager bufferManager, CompressionFormat compressionFormat, long maxReceivedMessageSize)
	{
		MemoryStream stream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count);
		int maxSize = (int)Math.Min(maxReceivedMessageSize, 2147483647L);
		using BufferManagerOutputStream bufferManagerOutputStream = new BufferManagerOutputStream(System.SR.MaxReceivedMessageSizeExceeded, 1024, maxSize, bufferManager);
		bufferManagerOutputStream.Write(buffer.Array, 0, buffer.Offset);
		byte[] buffer2 = bufferManager.TakeBuffer(1024);
		try
		{
			using Stream stream2 = ((compressionFormat == CompressionFormat.GZip) ? ((Stream)new GZipStream(stream, CompressionMode.Decompress)) : ((Stream)new DeflateStream(stream, CompressionMode.Decompress)));
			while (true)
			{
				int num = stream2.Read(buffer2, 0, 1024);
				if (num > 0)
				{
					bufferManagerOutputStream.Write(buffer2, 0, num);
					continue;
				}
				break;
			}
		}
		finally
		{
			bufferManager.ReturnBuffer(buffer2);
		}
		int bufferSize = 0;
		byte[] array = bufferManagerOutputStream.ToArray(out bufferSize);
		bufferManager.ReturnBuffer(buffer.Array);
		buffer = new ArraySegment<byte>(array, buffer.Offset, bufferSize - buffer.Offset);
	}

	internal static void CompressBuffer(ref ArraySegment<byte> buffer, BufferManager bufferManager, CompressionFormat compressionFormat)
	{
		using BufferManagerOutputStream bufferManagerOutputStream = new BufferManagerOutputStream(System.SR.MaxSentMessageSizeExceeded, 1024, int.MaxValue, bufferManager);
		bufferManagerOutputStream.Write(buffer.Array, 0, buffer.Offset);
		using (Stream stream = ((compressionFormat == CompressionFormat.GZip) ? ((Stream)new GZipStream(bufferManagerOutputStream, CompressionMode.Compress, leaveOpen: true)) : ((Stream)new DeflateStream(bufferManagerOutputStream, CompressionMode.Compress, leaveOpen: true))))
		{
			stream.Write(buffer.Array, buffer.Offset, buffer.Count);
		}
		int bufferSize = 0;
		byte[] array = bufferManagerOutputStream.ToArray(out bufferSize);
		bufferManager.ReturnBuffer(buffer.Array);
		buffer = new ArraySegment<byte>(array, buffer.Offset, bufferSize - buffer.Offset);
	}

	internal static Stream GetDecompressStream(Stream compressedStream, CompressionFormat compressionFormat)
	{
		if (compressionFormat != CompressionFormat.GZip)
		{
			return new DeflateStream(compressedStream, CompressionMode.Decompress, leaveOpen: false);
		}
		return new GZipStream(compressedStream, CompressionMode.Decompress, leaveOpen: false);
	}

	internal static Stream GetCompressStream(Stream uncompressedStream, CompressionFormat compressionFormat)
	{
		if (compressionFormat != CompressionFormat.GZip)
		{
			return new DeflateStream(uncompressedStream, CompressionMode.Compress, leaveOpen: true);
		}
		return new GZipStream(uncompressedStream, CompressionMode.Compress, leaveOpen: true);
	}
}
