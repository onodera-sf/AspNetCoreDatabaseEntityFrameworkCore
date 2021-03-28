using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseEntityFrameworkCoreRazor.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEntityFrameworkCoreRazor.Pages
{
  public class EditModel : PageModel
  {
    private readonly TestDatabaseDbContext _dbContext;

    /// <summary>
    /// 編集するユーザー情報を格納します。
    /// </summary>
    [BindProperty]
    public User UserInfo { get; set; }

    /// <summary>
    /// DI で TestDatabaseDbContext を受け取ります。
    /// </summary>
    /// <param name="dbContext"></param>
    public EditModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// ページにアクセスされたときに呼ばれます。
    /// </summary>
    public void OnGet(int? id)
    {
      // 指定した ID のユーザーをデータベースから取得
      // 本来存在しない ID を指定された場合の処理も追加すべき
      UserInfo = _dbContext.Users.Where(x => x.ID == id).FirstOrDefault();
    }

    /// <summary>
    /// POST が送信されたときに呼ばれる。
    /// </summary>
    public IActionResult OnPost()
    {
      // エラーがある場合は編集画面に戻る
      if (ModelState.IsValid == false) return Page();

      // 更新日時設定
      UserInfo.UpdateDateTime = DateTime.Now;

      // 入力内容を更新する
      _dbContext.Users.Update(UserInfo);

      // 変更を確定する
      _dbContext.SaveChanges();

      // 一覧画面に遷移
      return RedirectToPage("List");
    }
  }
}
