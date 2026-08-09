using ACadSharp.Classes;
using CSUtilities.IO;

namespace ACadSharp.IO.DWG;

internal class DwgClassesReader : DwgSectionIO
{
	private DwgFileHeader _fileHeader;

	private IDwgStreamReader _sreader;

	public override string SectionName => "AcDb:Classes";

	public DwgClassesReader(ACadVersion version, IDwgStreamReader sreader, DwgFileHeader fileHeader)
		: base(version)
	{
		_sreader = sreader;
		_fileHeader = fileHeader;
	}

	public DxfClassCollection Read()
	{
		DxfClassCollection dxfClassCollection = new DxfClassCollection();
		checkSentinel(_sreader, DwgSectionDefinition.StartSentinels[SectionName]);
		long num = _sreader.ReadRawLong();
		long num2 = _sreader.Position + num;
		if ((_fileHeader.AcadVersion >= ACadVersion.AC1024 && _fileHeader.AcadMaintenanceVersion > 3) || _fileHeader.AcadVersion > ACadVersion.AC1027)
		{
			_sreader.ReadRawLong();
		}
		long num3 = 0L;
		if (R2007Plus)
		{
			num3 = _sreader.PositionInBits() + _sreader.ReadRawLong() - 1;
			long positionInBits = _sreader.PositionInBits();
			num2 = _sreader.SetPositionByFlag(num3);
			_sreader.SetPositionInBits(positionInBits);
			IDwgStreamReader streamHandler = DwgStreamReaderBase.GetStreamHandler(_version, new StreamIO(_sreader.Stream, createCopy: true).Stream);
			streamHandler.SetPositionInBits(num2);
			_sreader = new DwgMergedReader(_sreader, streamHandler, null);
			_sreader.ReadBitLong();
			_sreader.ReadBit();
		}
		if (_fileHeader.AcadVersion == ACadVersion.AC1018)
		{
			_sreader.ReadBitShort();
			_sreader.ReadRawChar();
			_sreader.ReadRawChar();
			_sreader.ReadBit();
		}
		while (getCurrPos(_sreader) < num2)
		{
			DxfClass dxfClass = new DxfClass();
			dxfClass.ClassNumber = _sreader.ReadBitShort();
			dxfClass.ProxyFlags = (ProxyFlags)_sreader.ReadBitShort();
			dxfClass.ApplicationName = _sreader.ReadVariableText();
			dxfClass.CppClassName = _sreader.ReadVariableText();
			dxfClass.DxfName = _sreader.ReadVariableText();
			dxfClass.WasZombie = _sreader.ReadBit();
			dxfClass.ItemClassId = _sreader.ReadBitShort();
			if (dxfClass.ItemClassId == 498)
			{
				dxfClass.IsAnEntity = true;
			}
			else if (dxfClass.ItemClassId == 499)
			{
				dxfClass.IsAnEntity = false;
			}
			else
			{
				notify($"Invalid DxfClass id value: {dxfClass.ItemClassId} for {dxfClass.CppClassName}", NotificationType.Warning);
			}
			if (R2004Plus)
			{
				dxfClass.InstanceCount = _sreader.ReadBitLong();
				dxfClass.DwgVersion = (ACadVersion)_sreader.ReadBitLong();
				dxfClass.MaintenanceVersion = (short)_sreader.ReadBitLong();
				_sreader.ReadBitLong();
				_sreader.ReadBitLong();
			}
			dxfClassCollection.AddOrUpdate(dxfClass);
		}
		if (R2007Plus)
		{
			_sreader.SetPositionInBits(num3 + 1);
		}
		_sreader.ResetShift();
		checkSentinel(_sreader, DwgSectionDefinition.EndSentinels[SectionName]);
		return dxfClassCollection;
	}

	private long getCurrPos(IDwgStreamReader sreader)
	{
		if (R2007Plus)
		{
			return sreader.PositionInBits();
		}
		return sreader.Position;
	}
}
