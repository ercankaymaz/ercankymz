using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimPackedNormal
{
	private ushort _packedData;

	private const double PackSize = 252.0;

	public byte U => (byte)(_packedData >> 8);

	public byte V => (byte)(_packedData & 0xFF);

	public XbimVector3D Normal
	{
		get
		{
			double num = (double)(int)U / 252.0 * Math.PI * 2.0;
			double num2 = (double)(int)V / 252.0 * Math.PI;
			double vy = Math.Cos(num2);
			double vx = Math.Sin(num) * Math.Sin(num2);
			double vz = Math.Cos(num) * Math.Sin(num2);
			return new XbimVector3D(vx, vy, vz).Normalized();
		}
	}

	public ushort ToUnit16()
	{
		return _packedData;
	}

	public XbimPackedNormal(ushort packedData)
	{
		_packedData = packedData;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(U);
		bw.Write(V);
	}

	public void Read(BinaryReader br)
	{
		_packedData = br.ReadUInt16();
	}

	public XbimPackedNormal(byte u, byte v)
	{
		_packedData = (ushort)((u << 8) | v);
	}

	public XbimPackedNormal(double x, double y, double z)
	{
		if (Math.Abs(1.0 - y) < 0.0001)
		{
			_packedData = 0;
			return;
		}
		if (Math.Abs(y + 1.0) < 0.0001)
		{
			_packedData = 64764;
			return;
		}
		double num;
		double num2;
		if (Math.Abs(z - 1.0) < 0.0001)
		{
			num = 0.0;
			num2 = Math.PI / 2.0;
		}
		else if (Math.Abs(z + 1.0) < 0.0001)
		{
			num = Math.PI;
			num2 = Math.PI / 2.0;
		}
		else if (Math.Abs(x - 1.0) < 0.0001)
		{
			num = Math.PI / 2.0;
			num2 = Math.PI / 2.0;
		}
		else if (Math.Abs(x + 1.0) < 0.0001)
		{
			num = 4.71238898038469;
			num2 = Math.PI / 2.0;
		}
		else
		{
			num = Math.Atan2(x, z);
			num2 = Math.Acos(y);
		}
		num /= Math.PI * 2.0;
		num2 /= Math.PI;
		int num3 = (int)(num * 252.0);
		byte b = (byte)(num2 * 252.0);
		_packedData = (ushort)((num3 << 8) | b);
	}

	public XbimPackedNormal(XbimVector3D vec)
	{
		this = new XbimPackedNormal(vec.X, vec.Y, vec.Z);
	}

	public XbimPackedNormal Transform(XbimQuaternion q)
	{
		XbimVector3D vector = Normal;
		XbimQuaternion.Transform(ref vector, ref q, out var result);
		return new XbimPackedNormal(result);
	}
}
