using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Filters;

public abstract class Filter
{
	public abstract byte[] Encode(byte[] data);

	public virtual byte[] Encode(string rawString)
	{
		byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
		return Encode(bytes);
	}

	public abstract byte[] Decode(byte[] data, FilterParms parms);

	public byte[] Decode(byte[] data)
	{
		return Decode(data, null);
	}

	public virtual string DecodeToString(byte[] data, FilterParms parms)
	{
		byte[] array = Decode(data, parms);
		return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
	}

	public string DecodeToString(byte[] data)
	{
		return DecodeToString(data, null);
	}

	protected byte[] RemoveWhiteSpace(byte[] data)
	{
		int num = data.Length;
		int num2 = 0;
		int num3 = 0;
		while (num3 < num)
		{
			switch (data[num3])
			{
			case 0:
			case 9:
			case 10:
			case 12:
			case 13:
			case 32:
				num2--;
				break;
			default:
				if (num3 != num2)
				{
					data[num2] = data[num3];
				}
				break;
			}
			num3++;
			num2++;
		}
		if (num2 < num)
		{
			byte[] array = data;
			data = new byte[num2];
			for (int i = 0; i < num2; i++)
			{
				data[i] = array[i];
			}
		}
		return data;
	}
}
