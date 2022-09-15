using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.Json.Nodes;

namespace Infra.EntityFrameworkCore.Extensions;
public static class EFCoreJsonExtentions
{
    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class
    {
        ValueConverter<T, string> converter = new(
            v => v.ToJSON(),
            v => v.ToModel<T>()
        );
        ValueComparer<T> comparer = new(
            (l, r) => l.ToJSON() == r.ToJSON(),
            v => v == null ? 0 : v.ToJSON().GetHashCode(),
            v => v.ToJSON().ToModel<T>()
        );
        propertyBuilder.HasConversion(converter);
        propertyBuilder.Metadata.SetValueConverter(converter);
        propertyBuilder.Metadata.SetValueComparer(comparer);
        propertyBuilder.HasColumnType("nvarchar(max)");
        return propertyBuilder;
    }
    public static string ToJSON(this object obj)
        => JsonSerializer.Serialize(obj);
    public static T ToModel<T>(this string strJSON)
    {
        if (!string.IsNullOrWhiteSpace(strJSON))
            return JsonSerializer.Deserialize<T>(strJSON);
        return default;
    }
    public static string JsonValue(this object jsonColumn, [NotParameterized] string property)
    {
        throw new NotImplementedException();
    }

    public static void UseJsonValueFunc(this ModelBuilder builder)
    {
        
        var funBuilder = builder.HasDbFunction(typeof(EFCoreJsonExtentions)
                .GetMethod(nameof(EFCoreJsonExtentions.JsonValue),
                new[] { typeof(string), typeof(string) }))
                .HasTranslation(args => new SqlFunctionExpression("JSON_VALUE", args, nullable: true, argumentsPropagateNullability: new[] { false, false }, typeof(string), null));
        funBuilder.HasParameter("jsonColumn").Metadata.TypeMapping = new StringTypeMapping("NVARCHAR(MAX)", System.Data.DbType.String);
    }
}