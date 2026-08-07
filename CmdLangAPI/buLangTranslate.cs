// Decompiled with JetBrains decompiler
// Type: CmdLanguage.API.buLangTranslate
// Assembly: CmdLangAPI, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDC57675-BB9D-4653-8FAD-2A25490EEE99
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\CmdLangAPI.dll

using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

#nullable disable
namespace CmdLanguage.API;

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
    string cipherText = File.Exists(dataDllPath) ? File.ReadAllText(dataDllPath) : throw new FileNotFoundException("Dil veritabanı bulunamadı!");
    buLangTranslate._database = JsonConvert.DeserializeObject<LanguageDatabase>(CryptoManager.Decrypt(cipherText) ?? cipherText);
  }

  public static void ChangeLanguage(string targetLanguage)
  {
    if (buLangTranslate._database == null)
      throw new Exception("Önce InitializeDatabase çağrılmalıdır!");
    if (!buLangTranslate._database.SupportedLanguages.Contains(targetLanguage))
      return;
    buLangTranslate.InjectTranslations("preCaption", (object) buLangTranslate.preCaption, targetLanguage);
    buLangTranslate.InjectTranslations("preCaptionFoam", (object) buLangTranslate.preCaptionFoam, targetLanguage);
    buLangTranslate.InjectTranslations("preCaptionMarble", (object) buLangTranslate.preCaptionMarble, targetLanguage);
    buLangTranslate.InjectTranslations("preCaptionProfile", (object) buLangTranslate.preCaptionProfile, targetLanguage);
    buLangTranslate.InjectTranslations("preChar", (object) buLangTranslate.preChar, targetLanguage);
    buLangTranslate.InjectTranslations("preDef", (object) buLangTranslate.preDef, targetLanguage);
    buLangTranslate.InjectTranslations("preHelp", (object) buLangTranslate.preHelp, targetLanguage);
    buLangTranslate.InjectTranslations("preHelpFoam", (object) buLangTranslate.preHelpFoam, targetLanguage);
    buLangTranslate.InjectTranslations("preHelpMarble", (object) buLangTranslate.preHelpMarble, targetLanguage);
    buLangTranslate.InjectTranslations("preHelpProfile", (object) buLangTranslate.preHelpProfile, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionAxisError", (object) buLangTranslate.preMotionAxisError, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionAxisWarning", (object) buLangTranslate.preMotionAxisWarning, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionError", (object) buLangTranslate.preMotionError, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionMessage", (object) buLangTranslate.preMotionMessage, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionStatus", (object) buLangTranslate.preMotionStatus, targetLanguage);
    buLangTranslate.InjectTranslations("preMotionWarning", (object) buLangTranslate.preMotionWarning, targetLanguage);
    buLangTranslate.InjectTranslations("preSentenceFoam", (object) buLangTranslate.preSentenceFoam, targetLanguage);
    buLangTranslate.InjectTranslations("preSentences", (object) buLangTranslate.preSentences, targetLanguage);
    buLangTranslate.InjectTranslations("preSentencesMarble", (object) buLangTranslate.preSentencesMarble, targetLanguage);
    buLangTranslate.InjectTranslations("preSentencesNesting", (object) buLangTranslate.preSentencesNesting, targetLanguage);
    buLangTranslate.InjectTranslations("preSentencesProfile", (object) buLangTranslate.preSentencesProfile, targetLanguage);
  }

  private static void InjectTranslations(
    string categoryName,
    object classInstance,
    string targetLanguage)
  {
    foreach (FieldInfo field1 in classInstance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
    {
      FieldInfo field = field1;
      if (field.FieldType == typeof (string))
      {
        LanguageItem languageItem = buLangTranslate._database.Items.FirstOrDefault<LanguageItem>((Func<LanguageItem, bool>) (x => x.Category == categoryName && x.Key == field.Name));
        if (languageItem != null && languageItem.Translations.ContainsKey(targetLanguage))
        {
          string translation = languageItem.Translations[targetLanguage];
          if (!string.IsNullOrWhiteSpace(translation))
            field.SetValue(classInstance, (object) translation);
        }
      }
    }
  }
}
