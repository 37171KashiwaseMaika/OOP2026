using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;//modelsにアクセス可

namespace MvcBasicSample.Controllers;

//URLのHelloに対する要求を受け取るController
public class HelloController : Controller {

    //../Hello/Indexで呼び出されるAction
    public IActionResult Index() {
        //商品1件のオブジェクトを作る
        var product = new List<Product> {
            new Product{
                Name = "ハンバーガー",
                Price = 500
        },
            new Product {
                Name ="紅茶",
                Price=450
        },
            new Product {
                Name="オレンジジュース",
                Price=320
            },
            new Product {
                Name="スパゲッティ",
                Price=980
            },
            new Product {
                Name="オムライス",
                Price=830
            }
        };

        return View(product);
    }
}


