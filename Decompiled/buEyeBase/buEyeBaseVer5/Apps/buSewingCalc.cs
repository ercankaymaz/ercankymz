using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

public class buSewingCalc
{
	public static List<string> LangSewingStatus = new List<string>();

	public static List<string> LangSewingMessage = new List<string>();

	public static List<string> LangSewingCaptions = new List<string>();

	public static List<string> LangSewingCommands = new List<string>();

	public static List<string> LangSewingMainForm = new List<string>();

	public static string UnlockString = "";

	public bool AddCodeSewingJobItem(ref SewingJobItem S, int Code)
	{
		if (S.Code1 != 0)
		{
			if (S.Code2 != 0)
			{
				if (S.Code3 != 0)
				{
					if (S.Code4 != 0)
					{
						if (S.Code5 != 0)
						{
							return false;
						}
						S.Code5 = Code;
						return true;
					}
					S.Code4 = Code;
					return true;
				}
				S.Code3 = Code;
				return true;
			}
			S.Code2 = Code;
			return true;
		}
		S.Code1 = Code;
		return true;
	}

	public void ClearCodeSewingJobItem(ref SewingJobItem S)
	{
		S.Code0 = 0;
		S.Code1 = 0;
		S.Code2 = 0;
		S.Code3 = 0;
		S.Code4 = 0;
		S.Code5 = 0;
	}

	public void GetVertexCodes(ref SewingJobItem S, SewingVertex Vertex)
	{
		for (int i = 0; i <= Vertex.Codes.Count - 1; i++)
		{
			if (i == 0)
			{
				S.Code1 = (int)Vertex.Codes[i].Codes;
			}
			if (i == 1)
			{
				S.Code2 = (int)Vertex.Codes[i].Codes;
			}
			if (i == 2)
			{
				S.Code3 = (int)Vertex.Codes[i].Codes;
			}
			if (i == 3)
			{
				S.Code4 = (int)Vertex.Codes[i].Codes;
			}
			if (i == 4)
			{
				S.Code5 = (int)Vertex.Codes[i].Codes;
			}
		}
	}

	public int TreeJobImageIndex(buEntity refEntity)
	{
		if (refEntity.Sewing != null)
		{
			if (!refEntity.Sewing.isStitchDrawing)
			{
				return 3;
			}
			if (refEntity is buLine)
			{
				return 1;
			}
			if (refEntity is buArc)
			{
				return 2;
			}
		}
		return -1;
	}

	public string TreeJobDefination(buEntity refEntity)
	{
		string result = "";
		if (refEntity.Sewing == null)
		{
			return "No Defination";
		}
		if (!refEntity.Sewing.isStitchDrawing)
		{
			result = buLangTranslate.preDef.Jump + " " + buLangTranslate.preDef.Line + " - " + buLangTranslate.preDef.Length + " : " + refEntity.Sewing.StitchLengt.ToString("f1") + " , " + buLangTranslate.preDef.Speed + " : " + refEntity.Sewing.HeadSpeed.ToString("f0");
		}
		else
		{
			if (refEntity is buLine)
			{
				result = buLangTranslate.preDef.Stitch + " " + buLangTranslate.preDef.Line + " - " + buLangTranslate.preDef.Length + " : " + refEntity.Sewing.StitchLengt.ToString("f1") + " , " + buLangTranslate.preDef.Speed + " : " + refEntity.Sewing.HeadSpeed.ToString("f0");
			}
			if (refEntity is buArc)
			{
				result = buLangTranslate.preDef.Stitch + " " + buLangTranslate.preDef.Arc + " - " + buLangTranslate.preDef.Length + " : " + refEntity.Sewing.StitchLengt.ToString("f1") + " , " + buLangTranslate.preDef.Speed + " : " + refEntity.Sewing.HeadSpeed.ToString("f0");
			}
		}
		return result;
	}

	public bool isCodeAvailable(SewingJobItem S, int Code)
	{
		if (S.Code0 != Code)
		{
			if (S.Code1 != Code)
			{
				if (S.Code2 != Code)
				{
					if (S.Code3 != Code)
					{
						if (S.Code4 != Code)
						{
							if (S.Code5 != Code)
							{
								return false;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public bool isCodeAvailable(SewingJobItem S, int Code, ref int Index)
	{
		Index = -1;
		if (S.Code0 != Code)
		{
			if (S.Code1 != Code)
			{
				if (S.Code2 != Code)
				{
					if (S.Code3 != Code)
					{
						if (S.Code4 != Code)
						{
							if (S.Code5 != Code)
							{
								return false;
							}
							Index = 5;
							return true;
						}
						Index = 4;
						return true;
					}
					Index = 3;
					return true;
				}
				Index = 2;
				return true;
			}
			Index = 1;
			return true;
		}
		Index = 0;
		return true;
	}

	public int FreeAvailableCodeSequence(SewingJobItem S)
	{
		if (S.Code1 != 0)
		{
			if (S.Code2 != 0)
			{
				if (S.Code3 != 0)
				{
					if (S.Code4 != 0)
					{
						if (S.Code5 != 0)
						{
							return -1;
						}
						return 5;
					}
					return 4;
				}
				return 3;
			}
			return 2;
		}
		return 1;
	}

	public buSewingCalc()
	{
		if (!buVector5.smethod_0("buSewingCalc"))
		{
			throw new RegisterException("buSewingCalc");
		}
	}
}
