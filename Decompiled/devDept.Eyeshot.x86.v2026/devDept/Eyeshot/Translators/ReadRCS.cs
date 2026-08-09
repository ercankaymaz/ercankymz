using System;
using System.IO;
using System.Threading;
using ODA.Kernel.TD_RootIntegrated;
using ODA.PointCloud.RcsFileServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot.Translators;

public class ReadRCS : ReadFastPointCloudBase
{
	public ReadRCS(string filePath, formatType formatType = formatType.Colors)
		: base(filePath, formatType)
	{
		if (formatType == formatType.Classification)
		{
			throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531748), formatType.Classification));
		}
	}

	public ReadRCS(Stream stream, formatType formatType = formatType.Colors)
		: base(stream, formatType)
	{
		if (formatType == formatType.Classification)
		{
			throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531748), formatType.Classification));
		}
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		_0023_003DziqfddJqpi_jk(progress, ct);
	}

	private void _0023_003DziqfddJqpi_jk(IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			Autodesk.InitializeServices();
			OdRxModule odRxModule = TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531709));
			if (odRxModule == null)
			{
				log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531655));
				log.AppendLine();
				return;
			}
			OdRxRcsFileServices odRxRcsFileServices = new OdRxRcsFileServices(OdRxModule.getCPtr(odRxModule).Handle, cMemoryOwn: false);
			try
			{
				OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
				_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(base.Stream, odMemoryStream);
				using OdPointCloudScanDatabase _0023_003DzzUXQ_00241ZCh8c_0024 = odRxRcsFileServices.readRcsFile(odMemoryStream);
				FastPointCloud fastPointCloud = _0023_003DzMwzKDQcyuShx(_0023_003DzzUXQ_00241ZCh8c_0024, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
				if (fastPointCloud != null)
				{
					base.Result = true;
					base.Entities.Add(fastPointCloud);
				}
				else
				{
					base.Result = false;
				}
			}
			finally
			{
				((IDisposable)odRxRcsFileServices).Dispose();
			}
			TD_RootIntegrated_Globals.odrxDynamicLinker().unloadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531709));
		}
		catch (OdError odError)
		{
			log.AppendLine(odError.description());
			log.AppendLine();
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(value);
			CloseStream();
		}
	}

	private FastPointCloud _0023_003DzMwzKDQcyuShx(OdPointCloudScanDatabase _0023_003DzzUXQ_00241ZCh8c_0024, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		bool flag = (base.FillColors || _formatType == formatType.Colors) && _0023_003DzzUXQ_00241ZCh8c_0024.hasRGB();
		bool flag2 = (base.FillIntensities || _formatType == formatType.Intensity) && _0023_003DzzUXQ_00241ZCh8c_0024.hasIntensity();
		int num = (int)_0023_003DzzUXQ_00241ZCh8c_0024.getTotalAmountOfPoints();
		points = new float[num * 3];
		if (flag)
		{
			base.Colors = new byte[num * 3];
		}
		if (flag2)
		{
			base.Intensities = new ushort[num];
			minIntensity = (ushort)_0023_003DzzUXQ_00241ZCh8c_0024.getMinIntensity();
			maxIntensity = (ushort)_0023_003DzzUXQ_00241ZCh8c_0024.getMaxIntensity();
		}
		OdGeMatrix3d transformMatrix = _0023_003DzzUXQ_00241ZCh8c_0024.getTransformMatrix();
		int num2 = 0;
		OdRcsVoxelIterator voxelIterator = _0023_003DzzUXQ_00241ZCh8c_0024.getVoxelIterator();
		int num3 = 0;
		while (!voxelIterator.done())
		{
			OdRcsVoxel voxel = voxelIterator.getVoxel();
			OdGeExtents3d extents = voxel.getExtents();
			extents.transformBy(transformMatrix);
			OdGePoint3d odGePoint3d = extents.minPoint();
			uint totalNumberOfPoints = voxel.getTotalNumberOfPoints();
			OdRcsPointDataIterator pointDataIterator = voxel.getPointDataIterator();
			OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray();
			OdCmEntityColorArray odCmEntityColorArray = new OdCmEntityColorArray();
			OdUInt16Array normalIndexes = new OdUInt16Array();
			OdUInt8Array odUInt8Array = new OdUInt8Array();
			pointDataIterator.getPoints(odGePoint3dArray, odCmEntityColorArray, normalIndexes, odUInt8Array, totalNumberOfPoints);
			for (int i = 0; i < totalNumberOfPoints; i++)
			{
				OdGeVector3d odGeVector3d = odGePoint3dArray[i].asVector();
				odGeVector3d = transformMatrix * odGeVector3d;
				odGeVector3d += odGePoint3d.asVector();
				int num4 = num2;
				points[num2++] = (float)odGeVector3d.x;
				points[num2++] = (float)odGeVector3d.y;
				points[num2++] = (float)odGeVector3d.z;
				if (base.FillCoordinates)
				{
					base.Coordinates[num4] = odGeVector3d.x;
					base.Coordinates[num4 + 1] = odGeVector3d.y;
					base.Coordinates[num4 + 2] = odGeVector3d.z;
				}
				if (flag2)
				{
					base.Intensities[num4 / 3] = odUInt8Array[i];
				}
				if (flag)
				{
					base.Colors[num4] = odCmEntityColorArray[i].red();
					base.Colors[num4 + 1] = odCmEntityColorArray[i].green();
					base.Colors[num4 + 2] = odCmEntityColorArray[i].blue();
				}
				if (!UpdateProgressAndCheckCancelled(num2 / 3, num, base.ParsingText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
				{
					return null;
				}
			}
			UpdateProgressTo100(base.ParsingText, _0023_003DzIzeJ4Qs_003D);
			voxelIterator.step();
			num3++;
		}
		switch (_formatType)
		{
		case formatType.Plain:
			return new FastPointCloud(points);
		case formatType.Colors:
			return new FastPointCloud(points, base.Colors);
		case formatType.Intensity:
		{
			int num5 = base.Intensities.Length;
			byte[] array = new byte[num5];
			for (int j = 0; j < num5; j++)
			{
				array[j] = (byte)base.Intensities[j];
			}
			return new FastPointCloud(points, array);
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
