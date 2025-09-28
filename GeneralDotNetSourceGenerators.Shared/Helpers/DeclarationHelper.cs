using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace GeneralDotNetSourceGenerators.Shared.Helpers;

public static class DeclarationHelper
{
	public static string GetModifiers(INamedTypeSymbol symbol)
	{
		var parts = new List<string>();

		// Accessibility
		switch (symbol.DeclaredAccessibility)
		{
			case Accessibility.Public: parts.Add("public"); break;
			case Accessibility.Internal: parts.Add("internal"); break;
			case Accessibility.Private: parts.Add("private"); break;
			case Accessibility.Protected: parts.Add("protected"); break;
			case Accessibility.ProtectedAndInternal: parts.Add("protected internal"); break;
			case Accessibility.ProtectedOrInternal: parts.Add("internal protected"); break;
		}

		// Modifiers
		if (symbol.IsAbstract && symbol.TypeKind == TypeKind.Class) parts.Add("abstract");
		if (symbol.IsSealed && symbol.TypeKind == TypeKind.Class) parts.Add("sealed");
		if (symbol.IsStatic) parts.Add("static");

		// Partial (safe to always include in generated code)
		parts.Add("partial");

		return string.Join(" ", parts);
	}

	public static string GetTypeKind(TypeKind kind) => kind switch
	{
		TypeKind.Class => "class",
		TypeKind.Struct => "struct",
		TypeKind.Interface => "interface",
		TypeKind.Enum => "enum",
		_ => "class" // fallback
	};
}