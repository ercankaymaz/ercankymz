using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfCheckBoxField : PdfButtonField
{
	public new class Keys : PdfButtonField.Keys
	{
		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string Opt = "/Opt";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private string _checkedName = "/Yes";

	private string _uncheckedName = "/Off";

	public bool Checked
	{
		get
		{
			if (!base.HasKids)
			{
				string text = base.Elements.GetString("/V");
				return text.Length != 0 && text != "/Off";
			}
			if (base.Fields.Elements.Items.Length == 2)
			{
				string text2 = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.GetString("/V");
				return text2.Length != 0 && text2 != "/Off" && text2 != "/Nein";
			}
			return false;
		}
		set
		{
			if (!base.HasKids)
			{
				string value2 = (value ? GetNonOffValue() : "/Off");
				base.Elements.SetName("/V", value2);
				base.Elements.SetName("/AS", value2);
			}
			else
			{
				if (base.Fields.Elements.Items.Length != 2)
				{
					return;
				}
				if (value)
				{
					string text = "";
					if (((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements["/AP"] is PdfDictionary pdfDictionary && pdfDictionary.Elements["/N"] is PdfDictionary pdfDictionary2)
					{
						foreach (string key in pdfDictionary2.Elements.Keys)
						{
							if (key != "/Off")
							{
								text = key;
								break;
							}
						}
					}
					if (text.Length != 0)
					{
						((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/V", text);
						((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", text);
					}
					if (((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements["/AP"] is PdfDictionary pdfDictionary3 && pdfDictionary3.Elements["/N"] is PdfDictionary pdfDictionary4)
					{
						foreach (string key2 in pdfDictionary4.Elements.Keys)
						{
							if (key2 == "/Off")
							{
								text = key2;
								break;
							}
						}
					}
					if (text.Length != 0)
					{
						((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/V", text);
						((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", text);
					}
					return;
				}
				string text2 = "";
				if (((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements["/AP"] is PdfDictionary pdfDictionary5 && pdfDictionary5.Elements["/N"] is PdfDictionary pdfDictionary6)
				{
					foreach (string key3 in pdfDictionary6.Elements.Keys)
					{
						if (key3 != "/Off")
						{
							text2 = key3;
							break;
						}
					}
				}
				if (text2.Length != 0)
				{
					((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/V", text2);
					((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", text2);
				}
				if (((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements["/AP"] is PdfDictionary pdfDictionary7 && pdfDictionary7.Elements["/N"] is PdfDictionary pdfDictionary8)
				{
					foreach (string key4 in pdfDictionary8.Elements.Keys)
					{
						if (key4 == "/Off")
						{
							text2 = key4;
							break;
						}
					}
				}
				if (text2.Length != 0)
				{
					((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/V", text2);
					((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", text2);
				}
			}
		}
	}

	public string CheckedName
	{
		get
		{
			return _checkedName;
		}
		set
		{
			_checkedName = value;
		}
	}

	public string UncheckedName
	{
		get
		{
			return _uncheckedName;
		}
		set
		{
			_uncheckedName = value;
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfCheckBoxField(PdfDocument document)
		: base(document)
	{
		_document = document;
	}

	internal PdfCheckBoxField(PdfDictionary dict)
		: base(dict)
	{
	}
}
