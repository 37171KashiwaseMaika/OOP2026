using Microsoft.AspNetCore.Mvc;         // MVCの機能を使用 
using Microsoft.EntityFrameworkCore;    // ToListAsyncを使用 
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcBasicSample.Data;
using System.Collections.Immutable;              // AppDbContextを使用

namespace MvcBasicSample.Controllers;

    public class ProductsController : Controller {
    private readonly AppDbContext _db; // DBへ問い合わせるためのフィールド 

    public ProductsController(AppDbContext db) {
        _db = db;
    }

    // /Products/Index　で商品一覧を取得する(非同期メソッド)
    public async Task<IActionResult> Index() {

        //Idの昇順で取得し結果をList<Products>する
        var products = await _db.Products.OrderBy(product => product.Price).Where(product => product.Price >= 500).ToListAsync();

        //商品一覧をViewへ渡す
        return View(products);
    }
}

