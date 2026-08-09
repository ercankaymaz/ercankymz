using System;

namespace PdfSharp.Pdf.Annotations;

public sealed class PdfTextAnnotation : PdfAnnotation
{
	internal new class Keys : PdfAnnotation.Keys
	{
		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string Open = "/Open";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Name = "/Name";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public bool Open
	{
		get
		{
			return base.Elements.GetBoolean("/Open");
		}
		set
		{
			base.Elements.SetBoolean("/Open", value);
		}
	}

	public PdfTextAnnotationIcon Icon
	{
		get
		{
			string name = base.Elements.GetName("/Name");
			if (name == "")
			{
				return PdfTextAnnotationIcon.NoIcon;
			}
			name = name.Substring(1);
			if (!Enum.IsDefined(typeof(PdfTextAnnotationIcon), name))
			{
				return PdfTextAnnotationIcon.NoIcon;
			}
			return (PdfTextAnnotationIcon)Enum.Parse(typeof(PdfTextAnnotationIcon), name, ignoreCase: false);
		}
		set
		{
			if (Enum.IsDefined(typeof(PdfTextAnnotationIcon), value) && value != PdfTextAnnotationIcon.NoIcon)
			{
				base.Elements.SetName("/Name", "/" + value);
			}
			else
			{
				base.Elements.Remove("/Name");
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfTextAnnotation()
	{
		Initialize();
	}

	public PdfTextAnnotation(PdfDocument document)
		: base(document)
	{
		Initialize();
	}

	private void Initialize()
	{
		base.Elements.SetName("/Subtype", "/Text");
		Icon = PdfTextAnnotationIcon.Comment;
	}
}
