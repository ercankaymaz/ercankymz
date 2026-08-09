using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using CSMath;
using CSUtilities.IO;

namespace ACadSharp.IO.Templates;

internal class CadOle2FrameTemplate : CadEntityTemplate<Ole2Frame>
{
	public List<byte[]> Chunks { get; set; } = new List<byte[]>();

	public CadOle2FrameTemplate(Ole2Frame ole)
		: base(ole)
	{
	}

	public CadOle2FrameTemplate()
		: base(new Ole2Frame())
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (Chunks.Any())
		{
			base.CadObject.BinaryData = Chunks.SelectMany((byte[] c) => c).ToArray();
		}
		StreamIO streamIO = new StreamIO(base.CadObject.BinaryData);
		streamIO.ReadByte();
		streamIO.ReadByte();
		base.CadObject.UpperLeftCorner = read3Double(streamIO);
		read3Double(streamIO);
		base.CadObject.LowerRightCorner = read3Double(streamIO);
		read3Double(streamIO);
	}

	private XYZ read3Double(StreamIO reader)
	{
		double x = reader.ReadDouble();
		double y = reader.ReadDouble();
		double z = reader.ReadDouble();
		return new XYZ(x, y, z);
	}
}
