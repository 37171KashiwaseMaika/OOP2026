using System.Text.Json;
using Microsoft.AspNetCore.Http;
namespace SelfOrderSystem.Services;
public static class SessionExtensions // ISession に保存・取得メソッドを追加
{
    // オブジェクトをJSON で保存
    public static void SetObject<T>(this ISession session, string key, T value) {
        string json = JsonSerializer.Serialize(value); // C#オブジェクトをJSON 化
        session.SetString(key, json); // Session へ保存
    }

    public static T? GetObject<T>(this ISession session, string key) // JSON を指定した型へ戻す
    {
        string? json = session.GetString(key); // JSON を取得
        if (string.IsNullOrEmpty(json)) {
            return default;
        }
        return JsonSerializer.Deserialize<T>(json); // C#オブジェクトへ戻す
    }
}