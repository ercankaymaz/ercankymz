using System;
using System.IO;
using System.Threading;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Drawings.TD_Dwf7Import;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadDWF : ReadAutodesk
{
	public ReadDWF(string filePath)
		: base(filePath)
	{
	}

	public ReadDWF(Stream stream)
		: base(stream)
	{
	}

	internal override bool _0023_003DzJa3j1wQ3AeK7(ExHostAppServices _0023_003DzkiD5er_7LNMn, Stream _0023_003DzFjm4l2xeIERx, out linearUnitsType _0023_003DziUdFLu7DM8yM, out Entity[] _0023_003DzEHxwjvyQNA39, out BlockReference[] _0023_003DzLytbDApFrGRv, ref Point3D _0023_003DzyHsnlWIJMfQY, ref Point3D _0023_003DzGzGDbQK7gG2H, ref Point2D _0023_003Dzl30fPoKrRg7J, ref Point2D _0023_003DzbDPeJXcCFu7n, ref bool _0023_003DzAkdKkjuQJu0t, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbDatabase odDbDatabase = _0023_003DzkiD5er_7LNMn.createDatabase();
		if (string.IsNullOrEmpty(base.Password))
		{
			base.Password = string.Empty;
		}
		_0023_003Dz0wfZ_00245U_003D(base.Password, odDbDatabase, _0023_003DzFjm4l2xeIERx);
		if (!_0023_003DzJa3j1wQ3AeK7(out _0023_003DzEHxwjvyQNA39, out _0023_003DzLytbDApFrGRv, ref _0023_003DzyHsnlWIJMfQY, ref _0023_003DzGzGDbQK7gG2H, ref _0023_003Dzl30fPoKrRg7J, ref _0023_003DzbDPeJXcCFu7n, ref _0023_003DzAkdKkjuQJu0t, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D, odDbDatabase))
		{
			_0023_003DziUdFLu7DM8yM = linearUnitsType.Unitless;
			return false;
		}
		_0023_003DzbX1f48x0MIYi = WriteAutodesk._0023_003DzILmOAAaXA_EU8Ikxh34yB6I_003D(odDbDatabase.originalFileVersion());
		if (_0023_003DzbX1f48x0MIYi == autodeskVersionType.Release12 || _0023_003DzbX1f48x0MIYi == autodeskVersionType.Release13 || _0023_003DzbX1f48x0MIYi == autodeskVersionType.Release14)
		{
			_0023_003DziUdFLu7DM8yM = linearUnitsType.Unitless;
		}
		else
		{
			_0023_003DziUdFLu7DM8yM = WriteDatabase._0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(odDbDatabase.getINSUNITS());
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return true;
	}

	private void _0023_003Dz0wfZ_00245U_003D(string _0023_003Dzr8rfJIs_003D, OdDbDatabase _0023_003DzR8GRspk_003D, Stream _0023_003DzxsTI0C0_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(_0023_003DzxsTI0C0_003D, odMemoryStream);
		odMemoryStream.rewind();
		TD_DWF_IMPORT_OdDwfImport tD_DWF_IMPORT_OdDwfImport = new TD_DWF_IMPORT_OdDwfImportModule(OdRxModule.getCPtr(TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530764))).Handle, cMemoryOwn: false).create();
		OdRxDictionary odRxDictionary = tD_DWF_IMPORT_OdDwfImport.properties();
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530776), _0023_003DzR8GRspk_003D);
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530859), odMemoryStream);
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530876), new OdRxVariantValue(_0023_003Dzr8rfJIs_003D));
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530831), new OdRxVariantValue(297.0));
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530844), new OdRxVariantValue(210.0));
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530922), new OdRxVariantValue(value: false));
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530929), new OdRxVariantValue(-1));
		odRxDictionary.putAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530908), new OdRxVariantValue(value: true));
		switch (tD_DWF_IMPORT_OdDwfImport.import())
		{
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.bad_database:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530988));
			break;
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.bad_file:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530953));
			break;
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.bad_password:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531558));
			break;
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.encrypted_file:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531523));
			break;
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.fail:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531642));
			break;
		default:
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531602));
			break;
		case TD_DWF_IMPORT_OdDwfImport_ImportResult.success:
			break;
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}
}
