using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Annotations;

public sealed class PdfRubberStampAnnotation : PdfAnnotation
{
	internal new class Keys : PdfAnnotation.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Name = "/Name";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public PdfRubberStampAnnotationIcon Icon
	{
		get
		{
			string name = base.Elements.GetName("/Name");
			if (name == "")
			{
				return PdfRubberStampAnnotationIcon.NoIcon;
			}
			name = name.Substring(1);
			if (!Enum.IsDefined(typeof(PdfRubberStampAnnotationIcon), name))
			{
				return PdfRubberStampAnnotationIcon.NoIcon;
			}
			return (PdfRubberStampAnnotationIcon)Enum.Parse(typeof(PdfRubberStampAnnotationIcon), name, ignoreCase: false);
		}
		set
		{
			if (Enum.IsDefined(typeof(PdfRubberStampAnnotationIcon), value) && value != PdfRubberStampAnnotationIcon.NoIcon)
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

	public PdfRubberStampAnnotation()
	{
		Initialize();
	}

	public PdfRubberStampAnnotation(PdfDocument document)
		: base(document)
	{
		Initialize();
	}

	private void Initialize()
	{
		base.Elements.SetName("/Subtype", "/Stamp");
		base.Color = XColors.Yellow;
	}
}
