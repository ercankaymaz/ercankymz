using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using ODA.Kernel.TD_RootIntegrated;
using ODA.PointCloud.RcsFileServices;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadRCP : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzCrmL9jUp3JcpNLSVCw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003Dz5AijCx2C59PPoG_0024bcY6YzFA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003DzyJW5KJU0SxtrnFOi5iakzB8_003D = new string[0];

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCrmL9jUp3JcpNLSVCw_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzCrmL9jUp3JcpNLSVCw_003D_003D = value;
		}
	}

	public Transformation GlobalTransformation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5AijCx2C59PPoG_0024bcY6YzFA_003D;
		}
	}

	public string[] RcsFilesPaths
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyJW5KJU0SxtrnFOi5iakzB8_003D;
		}
	}

	public ReadRCP(string filePath)
	{
		FilePath = filePath;
	}

	private void _0023_003DzeycidLovpNeW(Transformation _0023_003Dzdc1k2Kc_003D)
	{
		_0023_003Dz5AijCx2C59PPoG_0024bcY6YzFA_003D = _0023_003Dzdc1k2Kc_003D;
	}

	private void _0023_003Dz8gtZWgg2YQqs2oHe0w_003D_003D(string[] _0023_003Dzdc1k2Kc_003D)
	{
		_0023_003DzyJW5KJU0SxtrnFOi5iakzB8_003D = _0023_003Dzdc1k2Kc_003D;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		_0023_003DzLKs4psLKtLQJ(progress, ct);
	}

	private void _0023_003DzLKs4psLKtLQJ(IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			Autodesk.InitializeServices();
			OdRxModule odRxModule = TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531709));
			if (odRxModule == null)
			{
				log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531655));
				return;
			}
			OdRxRcsFileServices odRxRcsFileServices = new OdRxRcsFileServices(OdRxModule.getCPtr(odRxModule).Handle, cMemoryOwn: false);
			try
			{
				using OdPointCloudProjectDatabase _0023_003DzGMAusJtSzIDR = odRxRcsFileServices.readRcpFile(FilePath, null);
				_0023_003DzV2wIMrJUzAsu(_0023_003DzGMAusJtSzIDR);
			}
			finally
			{
				((IDisposable)odRxRcsFileServices).Dispose();
			}
			TD_RootIntegrated_Globals.odrxDynamicLinker().unloadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531709));
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(value);
		}
	}

	private void _0023_003DzV2wIMrJUzAsu(OdPointCloudProjectDatabase _0023_003DzGMAusJtSzIDR)
	{
		OdGeMatrix3d globalTransformation = _0023_003DzGMAusJtSzIDR.getGlobalTransformation();
		OdGeVector3d csXAxis = globalTransformation.getCsXAxis();
		OdGeVector3d csYAxis = globalTransformation.getCsYAxis();
		OdGeVector3d csZAxis = globalTransformation.getCsZAxis();
		OdGePoint3d csOrigin = globalTransformation.getCsOrigin();
		_0023_003DzeycidLovpNeW(new Transformation(ReadAutodesk._0023_003DzHLWQmn1CvBx2(csOrigin), ReadAutodesk._0023_003DzBTaQ_0024K9mCK1O(csXAxis), ReadAutodesk._0023_003DzBTaQ_0024K9mCK1O(csYAxis), ReadAutodesk._0023_003DzBTaQ_0024K9mCK1O(csZAxis)));
		uint totalScansCount = _0023_003DzGMAusJtSzIDR.getTotalScansCount();
		_0023_003Dz8gtZWgg2YQqs2oHe0w_003D_003D(new string[totalScansCount]);
		OdPointCloudScanIterator scanIterator = _0023_003DzGMAusJtSzIDR.getScanIterator();
		int num = 0;
		while (!scanIterator.done())
		{
			OdPointCloudScanDatabase scanDb = scanIterator.getScanDb();
			RcsFilesPaths[num] = scanDb.getScanDatabaseFilePath();
			scanIterator.step();
			num++;
		}
	}
}
