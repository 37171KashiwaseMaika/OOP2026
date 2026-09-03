using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;

namespace SQLiteProductSample;

// Productsテーブルに対するDB操作をまとめたクラス
// CRUD（Create / Read / Update / Delete）を担当する
public class ProductRepository
{
    // 全商品を取得する。Read（SELECT）に相当する
    public List<Product> GetAll() {

        var products = new List<Product>();

        using var connection = Database.GetConnection();
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        // Productsテーブルを作るSQL
        command.CommandText =
            """
            SELECT Id, Name, Price
            FROM Products
            ORDER BY Id;
            """;

        // SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()) {
            products.Add(new Product {
                Id = reader.GetInt32(0),    // 0列目: Id
                Name = reader.GetString(1), // 1列目: Name
                Price = reader.GetInt32(2)  // 2列目: Price
            });
        }
        return products;

    }


    //商品を1件追加する。Create(INSERT)に相当する
    //戻り値として自動採番されたIDを返す
    public int Add(string name,int price) {
        // 接続オブジェクトを生成する。
        using var connection = Database.GetConnection();

        //DBを開く
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        // Productsテーブルを作るSQL
        // IF NOT EXISTS により、既にテーブルがあってもエラーにならない
        command.CommandText =
            """
            INSERT INTO Products (Name,Price)
            VALUES ($name,$price); 
            
            SELECT last_insert_rowid();

            """;

        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$price", price);


        //1つの値を返すSQLを実行する
        var result = command.ExecuteScalar();

        if (result is null)
            throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");

        //SQLiteのINTEFERはlongとして返るため、intへ変換する
        return Convert.ToInt32((long)result);
    }

    public void Update(Product product) {
        // 接続オブジェクトを生成する。
        using var connection = Database.GetConnection();

        //DBを開く
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        
        command.CommandText =
            """
            UPDATE Products
            SET Name = $name,
                Price = $price
            WHERE Id = $id;

            """;

        command.Parameters.AddWithValue("$name", product.Name);
        command.Parameters.AddWithValue("$price", product.Price);
        command.Parameters.AddWithValue("$id", product.Id);


        //更新件数が0なら対象が存在しない
        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("修正対象の商品が見つかりませんでした。");

    }

    public void Delete(int id) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
             """
            DELETE FROM Products
            WHERE Id = $id;

            """;

        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

}
