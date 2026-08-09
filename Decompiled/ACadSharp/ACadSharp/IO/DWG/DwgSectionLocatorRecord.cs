namespace ACadSharp.IO.DWG;

internal class DwgSectionLocatorRecord
{
	public int? Number { get; set; }

	public long Seeker { get; set; }

	public long Size { get; set; }

	public DwgSectionLocatorRecord()
	{
	}

	public DwgSectionLocatorRecord(int? number)
	{
		Number = number;
	}

	public DwgSectionLocatorRecord(int? number, int seeker, int size)
	{
		Number = number;
		Seeker = seeker;
		Size = size;
	}

	public bool IsInTheRecord(int position)
	{
		if (position >= Seeker)
		{
			return position < Seeker + Size;
		}
		return false;
	}

	public override string ToString()
	{
		return $"Number : {Number} | Seeker : {Seeker} | Size : {Size}";
	}
}
