using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IGrabResult : IDisposable, IImage
{
	IDataContainer Container { get; }

	long SkippedImageCount { get; }

	long ImageNumber { get; }

	long ID { get; }

	object BufferUserData { get; }

	object StreamGrabberUserData { get; }

	long Timestamp { get; }

	long BlockID { get; }

	long PayloadSize { get; }

	bool HasCRC
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	IParameterCollection ChunkData { get; }

	bool HasChunkData
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	string ErrorDescription { get; }

	int ErrorCode { get; }

	bool GrabSucceeded
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	int OffsetY { get; }

	int OffsetX { get; }

	int PaddingY { get; }

	PayloadType PayloadTypeValue { get; }

	[return: MarshalAs(UnmanagedType.U1)]
	bool CheckCRC();

	IGrabResult Clone();
}
