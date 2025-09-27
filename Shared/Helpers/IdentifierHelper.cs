using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GeneralSourceGenerators.Shared.Helpers;
public static class IdentifierHelper
{
	// C# keywords + contextual keywords
	private static readonly HashSet<string> CSharpKeywords = new HashSet<string>
	{
		"abstract","as","base","bool","break","byte","case","catch","char","checked","class",
		"const","continue","decimal","default","delegate","do","double","else","enum","event",
		"explicit","extern","false","finally","fixed","float","for","foreach","goto","if",
		"implicit","in","int","interface","internal","is","lock","long","namespace","new",
		"null","object","operator","out","override","params","private","protected","public",
		"readonly","ref","return","sbyte","sealed","short","sizeof","stackalloc","static",
		"string","struct","switch","this","throw","true","try","typeof","uint","ulong",
		"unchecked","unsafe","ushort","using","virtual","void","volatile","while",

		// contextual keywords
		"add","alias","ascending","async","await","by","descending","dynamic","equals",
		"from","get","global","group","into","join","let","nameof","on","orderby",
		"partial","remove","select","set","unmanaged","value","var","when","where","yield"
	};

	public static string MakeSafeIdentifier(string candidate)
	{
		if (string.IsNullOrWhiteSpace(candidate))
			return "_"; // fallback if nothing is usable

		// Trim and replace invalid chars with underscore
		var result = "";
		foreach (char c in candidate)
		{
			if (char.IsLetterOrDigit(c) || c == '_')
				result += c;
			else
				result += '_';
		}

		// Identifiers can't start with a digit, escape if needed
		if (char.IsDigit(result[0]))
			result = "@" + result;

		// Escape if keyword
		if (CSharpKeywords.Contains(result))
			result = "@" + result;

		return result;
	}

	public static string MakeSafePascalCaseIdentifier(string candidate)
	{
		string safeIdentifier = MakeSafeIdentifier(candidate);
		return string.Concat(safeIdentifier.Split('_').Select(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase));
	}
}