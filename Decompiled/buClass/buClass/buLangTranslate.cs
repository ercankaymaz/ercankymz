using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CmdLanguage.API;
using Newtonsoft.Json;

namespace buClass;

public static class buLangTranslate
{
	public static preCaption_Class preCaption = new preCaption_Class();

	public static preCaptionFoam_Class preCaptionFoam = new preCaptionFoam_Class();

	public static preCaptionMarble_Class preCaptionMarble = new preCaptionMarble_Class();

	public static preCaptionProfile_Class preCaptionProfile = new preCaptionProfile_Class();

	public static preChar_Class preChar = new preChar_Class();

	public static preDef_Class preDef = new preDef_Class();

	public static preHelp_Class preHelp = new preHelp_Class();

	public static preHelpFoam_Class preHelpFoam = new preHelpFoam_Class();

	public static preHelpMarble_Class preHelpMarble = new preHelpMarble_Class();

	public static preHelpProfile_Class preHelpProfile = new preHelpProfile_Class();

	public static preMotionAxisError_Class preMotionAxisError = new preMotionAxisError_Class();

	public static preMotionAxisWarning_Class preMotionAxisWarning = new preMotionAxisWarning_Class();

	public static preMotionError_Class preMotionError = new preMotionError_Class();

	public static preMotionMessage_Class preMotionMessage = new preMotionMessage_Class();

	public static preMotionStatus_Class preMotionStatus = new preMotionStatus_Class();

	public static preMotionWarning_Class preMotionWarning = new preMotionWarning_Class();

	public static preSentenceFoam_Class preSentenceFoam = new preSentenceFoam_Class();

	public static preSentences_Class preSentences = new preSentences_Class();

	public static preSentencesMarble_Class preSentencesMarble = new preSentencesMarble_Class();

	public static preSentencesNesting_Class preSentencesNesting = new preSentencesNesting_Class();

	public static preSentencesProfile_Class preSentencesProfile = new preSentencesProfile_Class();

	private static LanguageDatabase _database;

	public static void InitializeDatabase(string dataDllPath)
	{
		if (!File.Exists(dataDllPath))
		{
			throw new FileNotFoundException("Dil veritabanı bulunamadı!");
		}
		string text = File.ReadAllText(dataDllPath);
		string value = CryptoManager.Decrypt(text) ?? text;
		_database = JsonConvert.DeserializeObject<LanguageDatabase>(value);
	}

	public static void ChangeLanguage(string targetLanguage)
	{
		if (_database == null)
		{
			throw new Exception("Önce InitializeDatabase çağrılmalıdır!");
		}
		if (_database.SupportedLanguages.Contains(targetLanguage))
		{
			InjectTranslations("preCaption", preCaption, targetLanguage);
			InjectTranslations("preCaptionFoam", preCaptionFoam, targetLanguage);
			InjectTranslations("preCaptionMarble", preCaptionMarble, targetLanguage);
			InjectTranslations("preCaptionProfile", preCaptionProfile, targetLanguage);
			InjectTranslations("preChar", preChar, targetLanguage);
			InjectTranslations("preDef", preDef, targetLanguage);
			InjectTranslations("preHelp", preHelp, targetLanguage);
			InjectTranslations("preHelpFoam", preHelpFoam, targetLanguage);
			InjectTranslations("preHelpMarble", preHelpMarble, targetLanguage);
			InjectTranslations("preHelpProfile", preHelpProfile, targetLanguage);
			InjectTranslations("preMotionAxisError", preMotionAxisError, targetLanguage);
			InjectTranslations("preMotionAxisWarning", preMotionAxisWarning, targetLanguage);
			InjectTranslations("preMotionError", preMotionError, targetLanguage);
			InjectTranslations("preMotionMessage", preMotionMessage, targetLanguage);
			InjectTranslations("preMotionStatus", preMotionStatus, targetLanguage);
			InjectTranslations("preMotionWarning", preMotionWarning, targetLanguage);
			InjectTranslations("preSentenceFoam", preSentenceFoam, targetLanguage);
			InjectTranslations("preSentences", preSentences, targetLanguage);
			InjectTranslations("preSentencesMarble", preSentencesMarble, targetLanguage);
			InjectTranslations("preSentencesNesting", preSentencesNesting, targetLanguage);
			InjectTranslations("preSentencesProfile", preSentencesProfile, targetLanguage);
		}
	}

	private static void InjectTranslations(string categoryName, object classInstance, string targetLanguage)
	{
		FieldInfo[] fields = classInstance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
		FieldInfo[] array = fields;
		foreach (FieldInfo field in array)
		{
			if (!(field.FieldType == typeof(string)))
			{
				continue;
			}
			LanguageItem languageItem = _database.Items.FirstOrDefault((LanguageItem x) => x.Category == categoryName && x.Key == field.Name);
			if (languageItem != null && languageItem.Translations.ContainsKey(targetLanguage))
			{
				string value = languageItem.Translations[targetLanguage];
				if (!string.IsNullOrWhiteSpace(value))
				{
					field.SetValue(classInstance, value);
				}
			}
		}
	}

	public static string EnumToLang(Enum baseEnum)
	{
		try
		{
			string s = "";
			if (AppLanguage.EnumBase.Count > 0)
			{
				s = Enum.GetName(baseEnum.GetType(), baseEnum);
				string name = baseEnum.GetType().Name;
				string[] names = Enum.GetNames(baseEnum.GetType());
				if (names != null && names.Length != 0)
				{
					List<string> list = new List<string>();
					list.AddRange(names.ToArray());
					List<string> CalcList = new List<string>();
					List<string> CalcList2 = new List<string>();
					buStatics.ListToSpecificList("<" + name + ">", "</" + name + ">", AddStartEndKey: false, AppLanguage.EnumBase, ref CalcList);
					GetItemsAccordingToTheLang(CalcList, AppLanguage.SelectedLanguage, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						int num = list.FindIndex((string x) => x.StartsWith(s));
						if ((num >= 0) & (num <= CalcList2.Count - 1))
						{
							return CalcList2[num];
						}
					}
				}
				s = Enum.GetName(baseEnum.GetType(), baseEnum);
				return s;
			}
			s = Enum.GetName(baseEnum.GetType(), baseEnum);
			return s;
		}
		catch (Exception)
		{
			return Enum.GetName(baseEnum.GetType(), baseEnum);
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, List<string> CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length > 1)
				{
					string[] array2 = array[1].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = RefList[i].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, ref List<string> CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length > 1)
				{
					string[] array2 = array[1].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = RefList[i].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, ref ArrayList CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length > 1)
				{
					string[] array2 = array[1].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = RefList[i].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(string RefString, int Language, ref string CalcStirng)
	{
		try
		{
			string[] array = RefString.Split('|');
			if (array.Length > 1)
			{
				string[] array2 = array[1].Split(';');
				if (Language <= array2.Length - 1)
				{
					CalcStirng = array2[Language].Trim();
				}
			}
			else
			{
				string[] array3 = RefString.Split(';');
				if (Language <= array3.Length - 1)
				{
					CalcStirng = array3[Language].Trim();
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}
}
