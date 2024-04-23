// vai verificar se uma palavra é palindromo

using System;
using System.Text;
using System.Globalization;
using static System.Console;


namespace VerificaPalindromo
{
    class Program
    {
        static void Main()
        {
            string texto;
            string textoInvertido;
            WriteLine("Diga um texto para verificar se é palindromo:");
            texto = ReadLine();
            texto = ValidandoTexto(texto);
            textoInvertido = InvertendoString(texto);
            WriteLine(ResultadoPalindromo(texto, textoInvertido));
        }
        static string InvertendoString(string texto)
        {
            char[] arr = texto.ToCharArray();
            arr.Reverse();
            return new string(arr);
        }
        static string ValidandoTexto(string texto)
        {
            string removendo = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            var validacao = UnicodeCategory.OtherPunctuation & UnicodeCategory.NonSpacingMark & UnicodeCategory.UppercaseLetter;
            foreach (char c in removendo)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != validacao)
                    sb.Append(c);
            }
            return sb.ToString();
        }
        static string ResultadoPalindromo(string texto, string textoInvertido)
        {
            if (texto == textoInvertido)
                return "Esse texto é um palindromo.";
            else
                return "Esse texto não é um palindromo";
        }
    }
}