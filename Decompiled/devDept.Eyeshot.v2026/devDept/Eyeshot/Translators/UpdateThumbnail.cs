using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class UpdateThumbnail : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzTN7ut6NLAlW4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FileSerializer _0023_003DzYGQF6PlDuJWb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz9_kdDxdCDXGE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzVMWf_afz0_0024_rrxVw6w_003D_003D;

	public UpdateThumbnail(string filePath, FileSerializer fileSerializer, byte[] thumbnail)
	{
		if (fileSerializer.FileHeader == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011715));
		}
		_0023_003DzTN7ut6NLAlW4 = filePath;
		_0023_003DzYGQF6PlDuJWb = fileSerializer;
		_0023_003Dz9_kdDxdCDXGE = fileSerializer.FileHeader.Thumbnail;
		_0023_003DzVMWf_afz0_0024_rrxVw6w_003D_003D = thumbnail;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		Stream stream = null;
		try
		{
			using (Stream stream2 = File.Open(_0023_003DzTN7ut6NLAlW4, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				_0023_003DzYGQF6PlDuJWb._0023_003DzXNfmF6NWSjv_0024(stream2);
				long position = stream2.Position;
				stream = new MemoryStream(new byte[stream2.Length - position], writable: true);
				stream2.CopyTo(stream);
			}
			_0023_003DzYGQF6PlDuJWb.FileHeader._0023_003Dz9TTXsLAw_0024c31(_0023_003DzVMWf_afz0_0024_rrxVw6w_003D_003D);
			using Stream stream3 = File.Open(_0023_003DzTN7ut6NLAlW4, FileMode.Create, FileAccess.Write);
			_0023_003DzYGQF6PlDuJWb._0023_003DzIWkxaBcMUUs2(stream3, _0023_003DzYGQF6PlDuJWb.FileHeader);
			stream.Seek(0L, SeekOrigin.Begin);
			stream.CopyTo(stream3);
		}
		catch (Exception ex)
		{
			if (_0023_003DzYGQF6PlDuJWb != null && !string.IsNullOrEmpty(_0023_003DzYGQF6PlDuJWb.Log))
			{
				log.AppendLine(_0023_003DzYGQF6PlDuJWb.Log);
			}
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			_0023_003DzYGQF6PlDuJWb.FileHeader._0023_003Dz9TTXsLAw_0024c31(_0023_003Dz9_kdDxdCDXGE);
			if (stream != null)
			{
				stream.Close();
				stream.Dispose();
			}
		}
	}
}
