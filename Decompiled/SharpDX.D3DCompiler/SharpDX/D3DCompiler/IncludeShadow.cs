using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Collections;

namespace SharpDX.D3DCompiler;

internal class IncludeShadow : CppObjectShadow
{
	private struct Frame(Stream stream, GCHandle handle)
	{
		public Stream Stream = stream;

		public GCHandle Handle = handle;

		public void Close()
		{
			if (Handle.IsAllocated)
			{
				Handle.Free();
			}
		}
	}

	private class IncludeVtbl : CppObjectVtbl
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate Result OpenDelegate(IntPtr thisPtr, IncludeType includeType, IntPtr fileNameRef, IntPtr pParentData, ref IntPtr dataRef, ref int bytesRef);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate Result CloseDelegate(IntPtr thisPtr, IntPtr pData);

		public IncludeVtbl()
			: base(2)
		{
			AddMethod(new OpenDelegate(OpenImpl));
			AddMethod(new CloseDelegate(CloseImpl));
		}

		private static Result OpenImpl(IntPtr thisPtr, IncludeType includeType, IntPtr fileNameRef, IntPtr pParentData, ref IntPtr dataRef, ref int bytesRef)
		{
			try
			{
				IncludeShadow includeShadow = CppObjectShadow.ToShadow<IncludeShadow>(thisPtr);
				Include obj = (Include)includeShadow.Callback;
				Stream stream = null;
				Stream parentStream = null;
				if (includeShadow.frames.ContainsKey(pParentData))
				{
					parentStream = includeShadow.frames[pParentData].Stream;
				}
				stream = obj.Open(includeType, Marshal.PtrToStringAnsi(fileNameRef), parentStream);
				if (stream == null)
				{
					return Result.Fail;
				}
				GCHandle handle;
				if (stream is DataStream)
				{
					DataStream dataStream = (DataStream)stream;
					dataRef = dataStream.PositionPointer;
					bytesRef = (int)(dataStream.Length - dataStream.Position);
					handle = default(GCHandle);
				}
				else
				{
					byte[] array = Utilities.ReadStream(stream);
					handle = GCHandle.Alloc(array, GCHandleType.Pinned);
					dataRef = handle.AddrOfPinnedObject();
					bytesRef = array.Length;
				}
				includeShadow.frames.Add(dataRef, new Frame(stream, handle));
				return Result.Ok;
			}
			catch (SharpDXException ex)
			{
				return ex.ResultCode.Code;
			}
			catch (Exception)
			{
				return Result.Fail;
			}
		}

		private static Result CloseImpl(IntPtr thisPtr, IntPtr pData)
		{
			try
			{
				IncludeShadow includeShadow = CppObjectShadow.ToShadow<IncludeShadow>(thisPtr);
				Include include = (Include)includeShadow.Callback;
				if (includeShadow.frames.TryGetValue(pData, out var value))
				{
					includeShadow.frames.Remove(pData);
					include.Close(value.Stream);
					value.Close();
				}
				return Result.Ok;
			}
			catch (SharpDXException ex)
			{
				return ex.ResultCode.Code;
			}
			catch (Exception)
			{
				return Result.Fail;
			}
		}
	}

	private static readonly IncludeVtbl Vtbl = new IncludeVtbl();

	private readonly Dictionary<IntPtr, Frame> frames = new Dictionary<IntPtr, Frame>(EqualityComparer.DefaultIntPtr);

	protected override CppObjectVtbl GetVtbl => Vtbl;

	public static IntPtr ToIntPtr(Include callback)
	{
		return CppObject.ToCallbackPtr<Include>(callback);
	}
}
