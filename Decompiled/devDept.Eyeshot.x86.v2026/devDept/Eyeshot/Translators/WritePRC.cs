using System;
using System.IO;
using System.Linq;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using ODA.Prc.OdPrcModule;

namespace devDept.Eyeshot.Translators;

public class WritePRC : WriteDatabase
{
	public WritePRC(WritePrcParams writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	public WritePRC(WritePrcParams writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	private void _0023_003DzqNFgFJPR60_B(WritePrcParams _0023_003DzPE_0024Wv_0024xbODq9)
	{
		saveGeometry = _0023_003DzPE_0024Wv_0024xbODq9.SaveGeometry;
		aciColors = false;
	}

	protected override void WriteFile(OdDbDatabase pDb)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003DzrEK3CUvFSVRj(pDb);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzrEK3CUvFSVRj(OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		OdStreamBuf odStreamBuf = _0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003Dz_P5boncdw1JJ(_0023_003DzR8GRspk_003D, log);
		if (odStreamBuf == null)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517444));
		}
		if (base.Stream != null)
		{
			OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
			_0023_003DzhIpkc2O_00244sPx(odStreamBuf, odMemoryStream);
			int num = (int)odMemoryStream.length();
			OdUInt8Array odUInt8Array = new OdUInt8Array(num);
			odMemoryStream.getBytesByNum(odUInt8Array, 0uL, (uint)num);
			base.Stream.Write(odUInt8Array.ToArray(), 0, num);
		}
		else
		{
			if (!string.Equals(Path.GetExtension(base.FilePath), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355520327), StringComparison.InvariantCultureIgnoreCase))
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527533));
			}
			OdStreamBuf _0023_003DztBhO_2ck9nlX = TD_RootIntegrated_Globals.odrxSystemServices().createFile(base.FilePath, Oda_FileAccessMode.kFileWrite, Oda_FileShareMode.kShareDenyNo, Oda_FileCreationDisposition.kCreateAlways);
			_0023_003DzhIpkc2O_00244sPx(odStreamBuf, _0023_003DztBhO_2ck9nlX);
		}
	}

	private void _0023_003DzhIpkc2O_00244sPx(OdStreamBuf _0023_003Dzl0Ng4CZ22M39, OdStreamBuf _0023_003DztBhO_2ck9nlX)
	{
		OdPrcFile odPrcFile = OdPrcFile.createObject();
		odPrcFile.readFile(_0023_003Dzl0Ng4CZ22M39);
		odPrcFile.writeFile(_0023_003DztBhO_2ck9nlX);
	}
}
