namespace System.ServiceModel.Channels;

public interface ITransportCompressionSupport
{
	bool IsCompressionFormatSupported(CompressionFormat compressionFormat);
}
