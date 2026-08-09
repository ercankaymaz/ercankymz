#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfAcroField : PdfDictionary
{
	public sealed class PdfAcroFieldCollection : PdfArray
	{
		public int Count => base.Elements.Count;

		public string[] Names
		{
			get
			{
				int count = base.Elements.Count;
				string[] array = new string[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = ((PdfDictionary)((PdfReference)base.Elements[i]).Value).Elements.GetString("/T");
				}
				return array;
			}
		}

		public string[] DescendantNames
		{
			get
			{
				List<string> names = new List<string>();
				GetDescendantNames(ref names, null);
				return names.ToArray();
			}
		}

		public PdfAcroField this[int index]
		{
			get
			{
				PdfItem pdfItem = base.Elements[index];
				Debug.Assert(pdfItem is PdfReference);
				PdfDictionary pdfDictionary = ((PdfReference)pdfItem).Value as PdfDictionary;
				Debug.Assert(pdfDictionary != null);
				PdfAcroField pdfAcroField = pdfDictionary as PdfAcroField;
				if (pdfAcroField == null && pdfDictionary != null)
				{
					pdfAcroField = CreateAcroField(pdfDictionary);
				}
				return pdfAcroField;
			}
		}

		public PdfAcroField this[string name] => GetValue(name);

		private PdfAcroFieldCollection(PdfArray array)
			: base(array)
		{
		}

		internal void GetDescendantNames(ref List<string> names, string partialName)
		{
			int count = base.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				this[i]?.GetDescendantNames(ref names, partialName);
			}
		}

		internal PdfAcroField GetValue(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			int num = name.IndexOf('.');
			string text = ((num == -1) ? name : name.Substring(0, num));
			string name2 = ((num == -1) ? "" : name.Substring(num + 1));
			int count = base.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfAcroField pdfAcroField = this[i];
				if (pdfAcroField.Name == text)
				{
					return pdfAcroField.GetValue(name2);
				}
			}
			return null;
		}

		private PdfAcroField CreateAcroField(PdfDictionary dict)
		{
			string name = dict.Elements.GetName("/FT");
			PdfAcroFieldFlags integer = (PdfAcroFieldFlags)dict.Elements.GetInteger("/Ff");
			switch (name)
			{
			case "/Btn":
				if ((integer & PdfAcroFieldFlags.Pushbutton) != 0)
				{
					return new PdfPushButtonField(dict);
				}
				if ((integer & PdfAcroFieldFlags.Radio) != 0)
				{
					return new PdfRadioButtonField(dict);
				}
				return new PdfCheckBoxField(dict);
			case "/Tx":
				return new PdfTextField(dict);
			case "/Ch":
				if ((integer & PdfAcroFieldFlags.Combo) != 0)
				{
					return new PdfComboBoxField(dict);
				}
				return new PdfListBoxField(dict);
			case "/Sig":
				return new PdfSignatureField(dict);
			default:
				return new PdfGenericField(dict);
			}
		}
	}

	public class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string FT = "/FT";

		[KeyInfo(KeyType.Dictionary)]
		public const string Parent = "/Parent";

		[KeyInfo(KeyType.Array | KeyType.Optional, typeof(PdfAcroFieldCollection))]
		public const string Kids = "/Kids";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string T = "/T";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string TU = "/TU";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string TM = "/TM";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string Ff = "/Ff";

		[KeyInfo(KeyType.Various | KeyType.Optional)]
		public const string V = "/V";

		[KeyInfo(KeyType.Various | KeyType.Optional)]
		public const string DV = "/DV";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string AA = "/AA";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string DR = "/DR";

		[KeyInfo(KeyType.String | KeyType.Required)]
		public const string DA = "/DA";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string Q = "/Q";
	}

	private PdfAcroFieldCollection _fields;

	public string Name => base.Elements.GetString("/T");

	public PdfAcroFieldFlags Flags => (PdfAcroFieldFlags)base.Elements.GetInteger("/Ff");

	internal PdfAcroFieldFlags SetFlags
	{
		get
		{
			return (PdfAcroFieldFlags)base.Elements.GetInteger("/Ff");
		}
		set
		{
			base.Elements.SetInteger("/Ff", (int)value);
		}
	}

	public virtual PdfItem Value
	{
		get
		{
			return base.Elements["/V"];
		}
		set
		{
			if (ReadOnly)
			{
				throw new InvalidOperationException("The field is read only.");
			}
			if (value is PdfString || value is PdfName)
			{
				base.Elements["/V"] = value;
				return;
			}
			throw new NotImplementedException("Values other than string cannot be set.");
		}
	}

	public bool ReadOnly
	{
		get
		{
			return (Flags & PdfAcroFieldFlags.ReadOnly) != 0;
		}
		set
		{
			if (value)
			{
				SetFlags |= PdfAcroFieldFlags.ReadOnly;
			}
			else
			{
				SetFlags &= ~PdfAcroFieldFlags.ReadOnly;
			}
		}
	}

	public PdfAcroField this[string name] => GetValue(name);

	public bool HasKids
	{
		get
		{
			PdfItem pdfItem = base.Elements["/Kids"];
			if (pdfItem == null)
			{
				return false;
			}
			if (pdfItem is PdfArray)
			{
				return ((PdfArray)pdfItem).Elements.Count > 0;
			}
			return false;
		}
	}

	[Obsolete("Use GetDescendantNames")]
	public string[] DescendantNames => GetDescendantNames();

	public PdfAcroFieldCollection Fields
	{
		get
		{
			if (_fields == null)
			{
				object value = base.Elements.GetValue("/Kids", VCF.CreateIndirect);
				_fields = (PdfAcroFieldCollection)value;
			}
			return _fields;
		}
	}

	internal PdfAcroField(PdfDocument document)
		: base(document)
	{
	}

	protected PdfAcroField(PdfDictionary dict)
		: base(dict)
	{
	}

	protected virtual PdfAcroField GetValue(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return this;
		}
		if (HasKids)
		{
			return Fields.GetValue(name);
		}
		return null;
	}

	public string[] GetDescendantNames()
	{
		List<string> names = new List<string>();
		if (HasKids)
		{
			PdfAcroFieldCollection fields = Fields;
			fields.GetDescendantNames(ref names, null);
		}
		List<string> list = new List<string>();
		foreach (string item in names)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	public string[] GetAppearanceNames()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (base.Elements["/AP"] is PdfDictionary dict)
		{
			AppDict(dict, dictionary);
			if (HasKids)
			{
				PdfItem[] items = Fields.Elements.Items;
				PdfItem[] array = items;
				foreach (PdfItem pdfItem in array)
				{
					if (pdfItem is PdfReference && ((PdfReference)pdfItem).Value is PdfDictionary dict2)
					{
						AppDict(dict2, dictionary);
					}
				}
			}
		}
		string[] array2 = new string[dictionary.Count];
		dictionary.Keys.CopyTo(array2, 0);
		return array2;
	}

	private static void AppDict(PdfDictionary dict, Dictionary<string, object> names)
	{
		if (dict.Elements["/D"] is PdfDictionary dict2)
		{
			AppDict2(dict2, names);
		}
		if (dict.Elements["/N"] is PdfDictionary dict3)
		{
			AppDict2(dict3, names);
		}
	}

	private static void AppDict2(PdfDictionary dict, Dictionary<string, object> names)
	{
		foreach (string key in dict.Elements.Keys)
		{
			if (!names.ContainsKey(key))
			{
				names.Add(key, null);
			}
		}
	}

	internal virtual void GetDescendantNames(ref List<string> names, string partialName)
	{
		if (HasKids)
		{
			PdfAcroFieldCollection fields = Fields;
			string text = base.Elements.GetString("/T");
			Debug.Assert(text != "");
			if (text.Length > 0)
			{
				partialName = (string.IsNullOrEmpty(partialName) ? text : (partialName + "." + text));
				fields.GetDescendantNames(ref names, partialName);
			}
			return;
		}
		string text2 = base.Elements.GetString("/T");
		Debug.Assert(text2 != "");
		if (text2.Length > 0)
		{
			if (!string.IsNullOrEmpty(partialName))
			{
				names.Add(partialName + "." + text2);
			}
			else
			{
				names.Add(text2);
			}
		}
	}
}
