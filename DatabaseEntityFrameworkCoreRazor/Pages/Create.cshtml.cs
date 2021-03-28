using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseEntityFrameworkCoreRazor.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEntityFrameworkCoreRazor.Pages
{
  public class CreateModel : PageModel
  {
    private readonly TestDatabaseDbContext _dbContext;

    /// <summary>
    /// 登録するユーザー情報を格納します。
    /// </summary>
    [BindProperty]
    public User UserInfo { get; set; }

    /// <summary>
    /// DI で TestDatabaseDbContext を受け取ります。
    /// </summary>
    /// <param name="dbContext"></param>
    public CreateModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// ページにアクセスされたときに呼ばれます。
    /// </summary>
    public void OnGet()
    {
      // 画面表示時は何もしません。
    }

    /// <summary>
    /// POST が送信されたときに呼ばれる。
    /// </summary>
    public IActionResult OnPost()
    {
      // エラーがある場合は登録画面に戻る
      if (ModelState.IsValid == false) return Page();

      // 更新日時設定
      UserInfo.UpdateDateTime = DateTime.Now;

      // 登録リストにユーザー追加
      _dbContext.Users.Add(UserInfo);

      // 登録を確定する
      _dbContext.SaveChanges();

      // 一覧画面に遷移
      return RedirectToPage("List");
    }
  }
}
