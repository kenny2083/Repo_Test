using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Language
/// </summary>
/// 

namespace BusinessLogic
{
    public class Language
    {
        public string Name { get; set; }
        public string Culture { get; set; }
        public string UICulture { get; set; }
        public TextDirection Direction { get; set; }
        public bool IsDefault { get; set; }


        public static List<Language> GetLanguagesList(string LanguageString)
        {
            List<Language> LanguageList = new List<Language>();
            string[] LangStrArr = LanguageString.Split(';');
            foreach (string LangStr in LangStrArr)
            {
                string[] LangArr = LangStr.Split(',');
                Language Lang = new Language();
                Lang.Name = LangArr[0].Split('=')[1];
                Lang.Culture = LangArr[1].Split('=')[1];
                Lang.UICulture = LangArr[2].Split('=')[1];
                Lang.Direction = (TextDirection)Enum.Parse(typeof(TextDirection), LangArr[3].Split('=')[1], true);
                Lang.IsDefault = Convert.ToBoolean(LangArr[4].Split('=')[1]);
                LanguageList.Add(Lang);
            }
            return LanguageList;
        }

        public static Language GetLanguageByName(string LanguageString, string LanguageName)
        {
            List<Language> LanguageList = Language.GetLanguagesList(LanguageString);
            foreach (Language Lang in LanguageList)
            {
                if (Lang.Name == LanguageName)
                {
                    return Lang;
                }
            }

            return null;
        }

        public static Language GetDefaultLanguage(string LanguageString)
        {
            List<Language> LanguageList = Language.GetLanguagesList(LanguageString);
            foreach (Language Lang in LanguageList)
            {
                if (Lang.IsDefault)
                {
                    return Lang;
                }
            }

            return null;
        }

        public enum TextDirection
        {
            ltr = 1,
            rtl = 2
        };
    }
}