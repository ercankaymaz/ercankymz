using System.Collections.Generic;
using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("XRECORD")]
[DxfSubClass("AcDbXrecord")]
public class XRecord : NonGraphicalObject
{
	public class Entry
	{
		public int Code { get; }

		public object Value { get; set; }

		public GroupCodeValueType GroupCode => GroupCodeValue.TransformValue(Code);

		public bool HasLinkedObject
		{
			get
			{
				GroupCodeValueType groupCode = GroupCode;
				if ((uint)(groupCode - 8) <= 1u || groupCode == GroupCodeValueType.ExtendedDataHandle)
				{
					return true;
				}
				return false;
			}
		}

		public XRecord Owner { get; set; }

		internal Entry(int code, object value, XRecord owner)
		{
			Code = code;
			Value = value;
			Owner = owner;
		}

		public CadObject GetReference()
		{
			if (!HasLinkedObject)
			{
				return null;
			}
			if (Value is CadObject cadObject)
			{
				if (cadObject.Document != Owner.Document)
				{
					return null;
				}
				return cadObject;
			}
			return null;
		}

		public override string ToString()
		{
			return $"{Code}:{Value}";
		}
	}

	private readonly List<Entry> _entries = new List<Entry>();

	[DxfCodeValue(new int[] { 280 })]
	public DictionaryCloningFlags CloningFlags { get; set; }

	public IEnumerable<Entry> Entries => _entries;

	public override string ObjectName => "XRECORD";

	public override ObjectType ObjectType => ObjectType.XRECORD;

	public override string SubclassMarker => "AcDbXrecord";

	public XRecord()
	{
	}

	public XRecord(string name)
		: base(name)
	{
	}

	public void CreateEntry(int code, object value)
	{
		_entries.Add(new Entry(code, value, this));
	}
}
