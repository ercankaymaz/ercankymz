using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadLAS : ReadFastPointCloudBase
{
	internal struct _0023_003DzQTx352EjZEwEWE3_6w_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003DzrnO5_Vc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003DzEycLS_0024w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003DzPmrgK4vUqTXf;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzvIuOvOuzlX55wkgAqeWNE1c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003DzEoAgfuY3Q3ZRNYyS9Ur9xtQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003Dz7CW6uNWQuYKLqOxqMqTIxB0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003Dz_6bc2cCYLvS6l_C7ux4_0024RMU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003DzuPHLATs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003DzqsDQ9rA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003DzDCLRIivG29Ml;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003DziShyoW02UtzHoS_0024R8g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003Dz3t9xwIVphUkvEUn7IA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003DzO9BHCg579wSe;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003Dz6Qv_00241QQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DznSi5pqkwgCScs5Z3ytIq77WUt22c;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dz5t7mL0_8EoGTXJHyng_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003Dzw7Iv9dtCgXci;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ushort _0023_003DzoMWVq5mADAI_0024;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzQSLscbj_mnAYoyaWBWQQ7hStiEtsmx_0024byQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzHGmuydiQcDsaEM_0024b4ZNPbVQSvgovkaMTIg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DztVksuYCJdx1HbC5h4w5GZW89yeaDr7oFQQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dzgh5DnOpavY55ddRUuYEF4CCcO4fKW0EQ1w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dzs7wvG5bsVzSyifmK5L6uQh75_8kXvOSOIg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzlaFFS5sFF_0024z1m4PyzcJBY98_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzqwktqDZxVsfFfkpkHCRWmtI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz19u37FroMkBSGP80Uy88L9k_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzlViLJ0fZfUEK;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzRE1hEW4xVq_w;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzaWXkQj6_0024IeWb;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzueQi_IQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzgxEO_Ds_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzKnTEIEE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzPkYBqKE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzuBiD7yI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzRN68t7g_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003DzmQBDUYUClTUG;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ulong _0023_003Dz5N5W2k6AQ69lBUXllh_s1cQKWQhhMJBYHQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ulong _0023_003DzBkUhTZ1lceUKTE70LCVmslJT_nTmoFnk_A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzY0iQmc69KwOg_pchDedu8dzAqhwU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ulong _0023_003DzOPkjXwmSoOKWNO7T1lxZ0Wm_66nyttfLFQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ulong[] _0023_003DzmqJcAu8ISQ7oKD_5cFPdklejPffIAZ1QHIh1Bug_003D;
	}

	internal sealed class _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D
	{
		public ushort _0023_003DzvLwBG_A_003D;

		public byte[] _0023_003Dzns1uvRXi5fbS = new byte[16];

		public ushort _0023_003Dzh39g0_1WT7q9;

		public ushort _0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D;

		public byte[] _0023_003DzmAgXdRQ_003D = new byte[32];

		public byte[] _0023_003DzELu0Pss_003D;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzMblV7SmGLyQKnLs3ag_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAZve1UXFL6tUXlmnC7SmOTQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz5KguOoA_003D = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzrniFR72vIpvS = new byte[11]
	{
		0, 255, 0, 0, 255, 255, 0, 255, 255, 255,
		255
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzjO85yJH7rFcG = new byte[11]
	{
		0, 0, 255, 0, 255, 0, 255, 255, 255, 255,
		255
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzAdQeVzCQ4FMt = new byte[11]
	{
		0, 0, 0, 255, 0, 255, 255, 255, 255, 255,
		255
	};

	public byte[] Classifications
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D;
		}
	}

	public bool FillClassifications
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAZve1UXFL6tUXlmnC7SmOTQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAZve1UXFL6tUXlmnC7SmOTQ_003D = value;
		}
	}

	public ReadLAS(string filePath, formatType formatType = formatType.Plain)
		: base(filePath, formatType)
	{
	}

	public ReadLAS(Stream stream, formatType formatType = formatType.Plain)
		: base(stream, formatType)
	{
	}

	private void _0023_003Dzs30RVB3jHgpN(byte[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzcBHLGWHzEbPe(progress, ct);
	}

	private void _0023_003DzcBHLGWHzEbPe(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			bool flag = FillClassifications || _formatType == formatType.Classification;
			bool flag2 = base.FillIntensities || _formatType == formatType.Intensity;
			bool flag3 = base.FillColors || _formatType == formatType.Colors;
			Point3D maxValue = Point3D.MaxValue;
			Point3D minValue = Point3D.MinValue;
			int num = 0;
			BinaryReader binaryReader = new BinaryReader(base.Stream);
			_0023_003DzQTx352EjZEwEWE3_6w_003D_003D _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2 = default(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D);
			_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzrnO5_Vc_003D = binaryReader.ReadBytes(4);
			if (Encoding.ASCII.GetString(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzrnO5_Vc_003D) == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008285))
			{
				if (!UpdateProgressAndCheckCancelled(0.0, 100.0, base.ReadingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					base.Result = false;
				}
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzEycLS_0024w_003D = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzPmrgK4vUqTXf = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzvIuOvOuzlX55wkgAqeWNE1c_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzEoAgfuY3Q3ZRNYyS9Ur9xtQ_003D = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz7CW6uNWQuYKLqOxqMqTIxB0_003D = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz_6bc2cCYLvS6l_C7ux4_0024RMU_003D = binaryReader.ReadBytes(8);
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzuPHLATs_003D = binaryReader.ReadByte();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzqsDQ9rA_003D = binaryReader.ReadByte();
				num = _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzuPHLATs_003D * 10 + _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzqsDQ9rA_003D;
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzDCLRIivG29Ml = binaryReader.ReadBytes(32);
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DziShyoW02UtzHoS_0024R8g_003D_003D = binaryReader.ReadBytes(32);
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz3t9xwIVphUkvEUn7IA_003D_003D = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzO9BHCg579wSe = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6Qv_00241QQ_003D = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DznSi5pqkwgCScs5Z3ytIq77WUt22c = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz5t7mL0_8EoGTXJHyng_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci = binaryReader.ReadByte();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzoMWVq5mADAI_0024 = binaryReader.ReadUInt16();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzQSLscbj_mnAYoyaWBWQQ7hStiEtsmx_0024byQ_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzHGmuydiQcDsaEM_0024b4ZNPbVQSvgovkaMTIg_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DztVksuYCJdx1HbC5h4w5GZW89yeaDr7oFQQ_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzgh5DnOpavY55ddRUuYEF4CCcO4fKW0EQ1w_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzs7wvG5bsVzSyifmK5L6uQh75_8kXvOSOIg_003D_003D = binaryReader.ReadUInt32();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzlaFFS5sFF_0024z1m4PyzcJBY98_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzqwktqDZxVsfFfkpkHCRWmtI_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz19u37FroMkBSGP80Uy88L9k_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzlViLJ0fZfUEK = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzRE1hEW4xVq_w = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzaWXkQj6_0024IeWb = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzueQi_IQ_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzgxEO_Ds_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzKnTEIEE_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzPkYBqKE_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzuBiD7yI_003D = binaryReader.ReadDouble();
				_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzRN68t7g_003D = binaryReader.ReadDouble();
				if (num == 13 || num == 14)
				{
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz5N5W2k6AQ69lBUXllh_s1cQKWQhhMJBYHQ_003D_003D = binaryReader.ReadUInt64();
				}
				if (num == 14)
				{
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzBkUhTZ1lceUKTE70LCVmslJT_nTmoFnk_A_003D_003D = binaryReader.ReadUInt64();
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzY0iQmc69KwOg_pchDedu8dzAqhwU = binaryReader.ReadUInt32();
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzOPkjXwmSoOKWNO7T1lxZ0Wm_66nyttfLFQ_003D_003D = binaryReader.ReadUInt64();
					ulong[] array = new ulong[15];
					for (int i = 0; i <= 14; i++)
					{
						array[i] = binaryReader.ReadUInt64();
					}
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzmqJcAu8ISQ7oKD_5cFPdklejPffIAZ1QHIh1Bug_003D = array;
					if (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D == 0 && _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzOPkjXwmSoOKWNO7T1lxZ0Wm_66nyttfLFQ_003D_003D != 0)
					{
						if (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzOPkjXwmSoOKWNO7T1lxZ0Wm_66nyttfLFQ_003D_003D >= 2147483646)
						{
							_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D = 2147483646u;
						}
						else
						{
							_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D = Convert.ToUInt32(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzOPkjXwmSoOKWNO7T1lxZ0Wm_66nyttfLFQ_003D_003D);
						}
					}
				}
				if (_0023_003DzSOzRD9c_003D(binaryReader, _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz5t7mL0_8EoGTXJHyng_003D_003D, _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DznSi5pqkwgCScs5Z3ytIq77WUt22c, _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6Qv_00241QQ_003D, out var _, out var _))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008266));
				}
				if (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DznSi5pqkwgCScs5Z3ytIq77WUt22c - _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6Qv_00241QQ_003D != 0)
				{
					_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzmQBDUYUClTUG = binaryReader.ReadBytes(Convert.ToInt32(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DznSi5pqkwgCScs5Z3ytIq77WUt22c - _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6Qv_00241QQ_003D));
				}
				if (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D != 0 && _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci >= 0 && _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci <= 10)
				{
					int num2 = 15;
					if (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci >= 6 && _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci <= 10)
					{
						num2 = 17;
					}
					int startIndex = 0;
					int startIndex2 = 0;
					int startIndex3 = 0;
					switch (_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dzw7Iv9dtCgXci)
					{
					case 2:
						startIndex = 20;
						startIndex2 = 22;
						startIndex3 = 24;
						break;
					case 3:
					case 5:
						startIndex = 28;
						startIndex2 = 30;
						startIndex3 = 32;
						break;
					case 7:
					case 8:
					case 10:
						startIndex = 30;
						startIndex2 = 32;
						startIndex3 = 34;
						break;
					default:
						flag3 = false;
						break;
					}
					int num3 = Convert.ToInt32(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D);
					if (base.FillCoordinates)
					{
						base.Coordinates = new double[num3 * 3];
					}
					points = new float[num3 * 3];
					int num4 = 0;
					if (flag2)
					{
						base.Intensities = new ushort[num3];
					}
					if (flag)
					{
						_0023_003Dzs30RVB3jHgpN(new byte[num3]);
					}
					if (flag3)
					{
						base.Colors = new byte[num3 * 3];
						_0023_003DzMblV7SmGLyQKnLs3ag_003D_003D = new byte[num3 * 3];
					}
					int _0023_003DzoMWVq5mADAI_0024 = _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzoMWVq5mADAI_0024;
					byte[] array2 = new byte[_0023_003DzoMWVq5mADAI_0024 - 1 + 1];
					int num5 = Convert.ToInt32(_0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz6zrSERsXyByVccTv9EuFHctY67jQ976S6A_003D_003D);
					bool flag4 = true;
					bool flag5 = false;
					for (int j = 0; j < num5; j++)
					{
						array2 = binaryReader.ReadBytes(_0023_003DzoMWVq5mADAI_0024);
						double num6 = (double)BitConverter.ToInt32(array2, 0) * _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzlaFFS5sFF_0024z1m4PyzcJBY98_003D + _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzlViLJ0fZfUEK;
						double num7 = (double)BitConverter.ToInt32(array2, 4) * _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzqwktqDZxVsfFfkpkHCRWmtI_003D + _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzRE1hEW4xVq_w;
						double num8 = (double)BitConverter.ToInt32(array2, 8) * _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003Dz19u37FroMkBSGP80Uy88L9k_003D + _0023_003DzQTx352EjZEwEWE3_6w_003D_003D2._0023_003DzaWXkQj6_0024IeWb;
						if (num6 < maxValue.X)
						{
							maxValue.X = num6;
						}
						if (num7 < maxValue.Y)
						{
							maxValue.Y = num7;
						}
						if (num8 < maxValue.Z)
						{
							maxValue.Z = num8;
						}
						if (num6 > minValue.X)
						{
							minValue.X = num6;
						}
						if (num7 > minValue.Y)
						{
							minValue.Y = num7;
						}
						if (num8 > minValue.Z)
						{
							minValue.Z = num8;
						}
						int num9 = num4;
						points[num4++] = (float)num6;
						points[num4++] = (float)num7;
						points[num4++] = (float)num8;
						if (base.FillCoordinates)
						{
							base.Coordinates[num9] = num6;
							base.Coordinates[num9 + 1] = num7;
							base.Coordinates[num9 + 2] = num8;
						}
						if (flag2)
						{
							ushort num10 = BitConverter.ToUInt16(array2, 12);
							base.Intensities[j] = num10;
							if (num10 > maxIntensity)
							{
								maxIntensity = num10;
							}
							if (num10 < minIntensity)
							{
								minIntensity = num10;
							}
						}
						if (flag)
						{
							Classifications[j] = Convert.ToByte(array2[num2] & -225);
						}
						if (flag3)
						{
							if (!flag5)
							{
								int num11 = _0023_003DzP7mXgEk_003D(BitConverter.ToUInt16(array2, startIndex));
								int num12 = _0023_003DzP7mXgEk_003D(BitConverter.ToUInt16(array2, startIndex2));
								int num13 = _0023_003DzP7mXgEk_003D(BitConverter.ToUInt16(array2, startIndex3));
								if (num11 > 255)
								{
									num11 = 255;
								}
								if (num12 > 255)
								{
									num12 = 255;
								}
								if (num13 > 255)
								{
									num13 = 255;
								}
								base.Colors[num9] = Convert.ToByte(num11);
								base.Colors[num9 + 1] = Convert.ToByte(num12);
								base.Colors[num9 + 2] = Convert.ToByte(num13);
								if (flag4 && (num11 != 255 || num12 != 255 || num13 != 255))
								{
									flag4 = false;
								}
							}
							if (flag4)
							{
								flag5 = true;
								int num14 = Convert.ToInt32((double)(int)BitConverter.ToUInt16(array2, startIndex) / 257.0);
								int num15 = Convert.ToInt32((double)(int)BitConverter.ToUInt16(array2, startIndex2) / 257.0);
								int num16 = Convert.ToInt32((double)(int)BitConverter.ToUInt16(array2, startIndex3) / 257.0);
								if (num14 > 255)
								{
									num14 = 255;
								}
								if (num15 > 255)
								{
									num15 = 255;
								}
								if (num16 > 255)
								{
									num16 = 255;
								}
								_0023_003DzMblV7SmGLyQKnLs3ag_003D_003D[num9] = Convert.ToByte(num14);
								_0023_003DzMblV7SmGLyQKnLs3ag_003D_003D[num9 + 1] = Convert.ToByte(num15);
								_0023_003DzMblV7SmGLyQKnLs3ag_003D_003D[num9 + 2] = Convert.ToByte(num16);
							}
						}
						if (!UpdateProgressAndCheckCancelled(j, num5, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
						{
							base.Result = false;
							return;
						}
					}
					if (flag4)
					{
						base.Colors = _0023_003DzMblV7SmGLyQKnLs3ag_003D_003D;
					}
				}
				FastPointCloud fastPointCloud = GetFastPointCloud(_formatType);
				fastPointCloud.localMin = maxValue;
				fastPointCloud.localMax = minValue;
				fastPointCloud.UpdateBoundingBoxSphere();
				fastPointCloud.RegenMode = regenType.CompileOnly;
				base.Entities.Add(fastPointCloud);
				base.Result = true;
				UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
				return;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008467));
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
			base.Result = false;
		}
		finally
		{
			CloseStream();
		}
	}

	private FastPointCloud _0023_003DzvdEI5MBi016q(float[] _0023_003DzrdSL0CI_003D, formatType _0023_003DzSDg6E4o_003D)
	{
		byte[] array = _0023_003DzZVV_npk_003D(_0023_003DzSDg6E4o_003D);
		if (array.Length == 0)
		{
			return new FastPointCloud(_0023_003DzrdSL0CI_003D);
		}
		return new FastPointCloud(_0023_003DzrdSL0CI_003D, array);
	}

	public FastPointCloud GetFastPointCloud(formatType formatType)
	{
		return _0023_003DzvdEI5MBi016q(points, formatType);
	}

	public Block GetFastPointCloudAsBlock(formatType formatType, out Point3D insertionPoint, string blockName = null)
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		double num5 = double.MinValue;
		double num6 = double.MinValue;
		for (int i = 0; i < points.Length; i++)
		{
			double[] coordinates = base.Coordinates;
			double num7;
			double num8;
			double num9;
			if (coordinates != null && coordinates.Length != 0)
			{
				num7 = base.Coordinates[i++];
				num8 = base.Coordinates[i++];
				num9 = base.Coordinates[i];
			}
			else
			{
				num7 = points[i++];
				num8 = points[i++];
				num9 = points[i];
			}
			if (num > num7)
			{
				num = num7;
			}
			if (num2 > num8)
			{
				num2 = num8;
			}
			if (num3 > num9)
			{
				num3 = num9;
			}
			if (num4 < num7)
			{
				num4 = num7;
			}
			if (num5 < num8)
			{
				num5 = num8;
			}
			if (num6 < num9)
			{
				num6 = num9;
			}
		}
		double num10 = (num + num4) / 2.0;
		double num11 = (num2 + num5) / 2.0;
		double num12 = (num3 + num6) / 2.0;
		float[] array = new float[points.Length];
		int num13 = 0;
		for (int j = 0; j < points.Length; j++)
		{
			double[] coordinates2 = base.Coordinates;
			if (coordinates2 != null && coordinates2.Length != 0)
			{
				array[num13++] = Convert.ToSingle(base.Coordinates[j++] - num10);
				array[num13++] = Convert.ToSingle(base.Coordinates[j++] - num11);
				array[num13++] = Convert.ToSingle(base.Coordinates[j] - num12);
			}
			else
			{
				array[num13++] = Convert.ToSingle((double)points[j++] - num10);
				array[num13++] = Convert.ToSingle((double)points[j++] - num11);
				array[num13++] = Convert.ToSingle((double)points[j] - num12);
			}
		}
		FastPointCloud item = _0023_003DzvdEI5MBi016q(array, formatType);
		insertionPoint = new Point3D(num10, num11, num12);
		if (string.IsNullOrEmpty(blockName))
		{
			blockName = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008463), _0023_003Dz5KguOoA_003D++);
		}
		return new Block(blockName)
		{
			Entities = { (Entity)item }
		};
	}

	public List<FastPointCloud> GetFastPointClouds(formatType formatType, int batchSize = 60000)
	{
		int num = points.Length / 3;
		int num2 = (num + batchSize - 1) / batchSize;
		byte[] array;
		int num3;
		if (formatType == formatType.Colors && base.Colors != null && base.Colors.Length == num * 3)
		{
			array = base.Colors;
			num3 = 3;
		}
		else if (formatType == formatType.Intensity && base.Intensities != null && base.Intensities.Length == num)
		{
			array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (byte)(base.Intensities[i] >> 8);
			}
			num3 = 1;
		}
		else if (formatType == formatType.Classification && Classifications != null && Classifications.Length == num)
		{
			array = new byte[num * 3];
			for (int j = 0; j < num; j++)
			{
				array[j * 3 + 2] = (array[j * 3 + 1] = (array[j * 3] = Classifications[j]));
			}
			num3 = 3;
		}
		else
		{
			array = null;
			num3 = 0;
		}
		List<FastPointCloud> list = new List<FastPointCloud>(num2);
		for (int k = 0; k < num2; k++)
		{
			int num4 = k * batchSize;
			int num5 = Math.Min(batchSize, num - num4);
			float[] array2 = new float[num5 * 3];
			Array.Copy(points, num4 * 3, array2, 0, num5 * 3);
			FastPointCloud item;
			if (num3 > 0)
			{
				byte[] array3 = new byte[num5 * num3];
				Array.Copy(array, num4 * num3, array3, 0, num5 * num3);
				item = new FastPointCloud(array2, array3);
			}
			else
			{
				item = new FastPointCloud(array2);
			}
			list.Add(item);
		}
		return list;
	}

	private byte[] _0023_003DzZVV_npk_003D(formatType _0023_003DzSDg6E4o_003D)
	{
		byte[] array = new byte[0];
		switch (_0023_003DzSDg6E4o_003D)
		{
		case formatType.Colors:
			if (base.Colors != null && points.Length == base.Colors.Length)
			{
				array = base.Colors;
				break;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008417));
		case formatType.Classification:
		{
			int num2 = Classifications.Length;
			if (points.Length / 3 == num2)
			{
				array = new byte[num2 * 3];
				int num3 = 0;
				for (int j = 0; j < num2; j++)
				{
					byte b = Classifications[j];
					if (b > 10)
					{
						b = 10;
					}
					array[num3++] = _0023_003DzrniFR72vIpvS[b];
					array[num3++] = _0023_003DzjO85yJH7rFcG[b];
					array[num3++] = _0023_003DzAdQeVzCQ4FMt[b];
				}
				break;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009150));
		}
		case formatType.Intensity:
		{
			int num = base.Intensities.Length;
			if (points.Length / 3 == num)
			{
				array = new byte[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = Utility._0023_003DzdceBluUVGYUs((int)base.Intensities[i], (int)minIntensity, (int)maxIntensity);
				}
				break;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009087));
		}
		default:
			throw new ArgumentOutOfRangeException();
		case formatType.Plain:
			break;
		}
		return array;
	}

	private bool _0023_003DzSOzRD9c_003D(BinaryReader _0023_003DzgyYoHow_003D, uint _0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D, uint _0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog, ushort _0023_003Dzf1yAfSU_003D, out string _0023_003DzNqOFiDE_003D, out string _0023_003Dz7R4nzv0_003D)
	{
		long position = base.Stream.Position;
		_0023_003DzNqOFiDE_003D = string.Empty;
		_0023_003Dz7R4nzv0_003D = string.Empty;
		uint num = 0u;
		byte[] array = new byte[32];
		bool result = false;
		if (_0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D != 0)
		{
			for (int i = 0; i < _0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D; i++)
			{
				_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2 = new _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D();
				if ((int)_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog - num - _0023_003Dzf1yAfSU_003D < 54)
				{
					_0023_003DzNqOFiDE_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009277), (int)_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog - num - _0023_003Dzf1yAfSU_003D, i, _0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D);
					_0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D = (uint)i;
					break;
				}
				if (_0023_003DzgyYoHow_003D.Read(array, 0, 2) != 2)
				{
					_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009183), i);
					break;
				}
				_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzvLwBG_A_003D = BitConverter.ToUInt16(array, 0);
				if (_0023_003DzgyYoHow_003D.Read(_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzns1uvRXi5fbS, 0, 16) != 16)
				{
					_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008871), i);
					break;
				}
				if (_0023_003DzgyYoHow_003D.Read(array, 0, 2) != 2)
				{
					_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008848), i);
					break;
				}
				_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzh39g0_1WT7q9 = BitConverter.ToUInt16(array, 0);
				if (_0023_003DzgyYoHow_003D.Read(array, 0, 2) != 2)
				{
					_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008791), i);
					break;
				}
				_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D = BitConverter.ToUInt16(array, 0);
				if (_0023_003DzgyYoHow_003D.Read(_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzmAgXdRQ_003D, 0, 32) != 32)
				{
					_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008977), i);
					break;
				}
				num += 54;
				if (_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzvLwBG_A_003D != 43707)
				{
					_0023_003DzNqOFiDE_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008958), i, _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzvLwBG_A_003D);
				}
				if ((int)_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog - num - _0023_003Dzf1yAfSU_003D < _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D)
				{
					_0023_003DzNqOFiDE_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009649), (int)_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog - num - _0023_003Dzf1yAfSU_003D, _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D, i);
					_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D = (ushort)(_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog - num - _0023_003Dzf1yAfSU_003D);
				}
				string text = string.Empty;
				for (int j = 0; j < _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzns1uvRXi5fbS.Length && _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzns1uvRXi5fbS[j] != 0; j++)
				{
					string text2 = text;
					char c = (char)_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzns1uvRXi5fbS[j];
					text = text2 + c;
				}
				if (_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D != 0)
				{
					if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009553))
					{
						result = true;
						break;
					}
					_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzELu0Pss_003D = new byte[_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D];
					if (_0023_003DzgyYoHow_003D.Read(_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzELu0Pss_003D, 0, _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D) != _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D)
					{
						_0023_003Dz7R4nzv0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009544), _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D, i);
						break;
					}
				}
				else
				{
					_0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003DzELu0Pss_003D = null;
				}
				num += _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D;
				if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009553))
				{
					_0023_003DzPrNN4JrbCBcP6xipEj0S9scGHyog -= (uint)(54 + _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D);
					num -= (uint)(54 + _0023_003DzTB1c4RY6LUT2CEwPug_003D_003D2._0023_003Dzg8EqPUFq9hgf_0024i4GTQ_003D_003D);
					i--;
					_0023_003Dzi_SYtHa_oMT0x_A84g_003D_003D--;
				}
			}
		}
		base.Stream.Position = position;
		return result;
	}

	private static byte _0023_003DzP7mXgEk_003D(ushort _0023_003DzPzO_0024GUk_003D)
	{
		byte[] bytes = BitConverter.GetBytes(_0023_003DzPzO_0024GUk_003D);
		if (bytes[0] == 0)
		{
			return bytes[1];
		}
		return bytes[0];
	}

	internal static void _0023_003DzTGq9tzM22U_0024U<T>(ref T[] _0023_003DzxwaSN1c_003D, int _0023_003Dz14lzA48_003D, bool _0023_003DzrDrboos_003D)
	{
		T[] array = new T[_0023_003Dz14lzA48_003D];
		if (_0023_003DzrDrboos_003D)
		{
			Array.Copy(_0023_003DzxwaSN1c_003D, array, _0023_003DzxwaSN1c_003D.Length);
		}
		_0023_003DzxwaSN1c_003D = array;
	}
}
