using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PesquisaEleitoral_MVC.Utils
{
    public static class StringUtil
    {
        public static string RemoveAcentos(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }

        public static string TratativaProva(string text)
        {
            text = RemoveAcentos(text);
            text = RemoveEspacos(text);
            // Upper
            return text.ToUpper();
        }

        public static string RemoveEspacos(string text)
        {
            text.TrimStart().TrimEnd();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            return text = regex.Replace(text, " ");
        }

    }
}