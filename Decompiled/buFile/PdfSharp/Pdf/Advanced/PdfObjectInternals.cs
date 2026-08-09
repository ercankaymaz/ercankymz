namespace PdfSharp.Pdf.Advanced;

public class PdfObjectInternals
{
	private readonly PdfObject _obj;

	public PdfObjectID ObjectID => _obj.ObjectID;

	public int ObjectNumber => _obj.ObjectID.ObjectNumber;

	public int GenerationNumber => _obj.ObjectID.GenerationNumber;

	public string TypeID
	{
		get
		{
			if (_obj is PdfArray)
			{
				return "array";
			}
			if (_obj is PdfDictionary)
			{
				return "dictionary";
			}
			return _obj.GetType().Name;
		}
	}

	internal PdfObjectInternals(PdfObject obj)
	{
		_obj = obj;
	}
}
