using System;

namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfComboBoxField : PdfChoiceField
{
	public new class Keys : PdfAcroField.Keys
	{
		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta
		{
			get
			{
				if (_meta == null)
				{
					_meta = KeysBase.CreateMeta(typeof(Keys));
				}
				return _meta;
			}
		}
	}

	public int SelectedIndex
	{
		get
		{
			string value = base.Elements.GetString("/V");
			return IndexInOptArray(value);
		}
		set
		{
			if (value != -1)
			{
				string value2 = ValueInOptArray(value);
				base.Elements.SetString("/V", value2);
				base.Elements.SetInteger("/I", value);
			}
		}
	}

	public override PdfItem Value
	{
		get
		{
			return base.Elements["/V"];
		}
		set
		{
			if (base.ReadOnly)
			{
				throw new InvalidOperationException("The field is read only.");
			}
			if (value is PdfString || value is PdfName)
			{
				base.Elements["/V"] = value;
				SelectedIndex = SelectedIndex;
				if (SelectedIndex == -1)
				{
					try
					{
						((PdfArray)((PdfItem[])base.Elements.Values)[2]).Elements.Add(Value);
						SelectedIndex = SelectedIndex;
						return;
					}
					catch
					{
						return;
					}
				}
				return;
			}
			throw new NotImplementedException("Values other than string cannot be set.");
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfComboBoxField(PdfDocument document)
		: base(document)
	{
	}

	internal PdfComboBoxField(PdfDictionary dict)
		: base(dict)
	{
	}
}
