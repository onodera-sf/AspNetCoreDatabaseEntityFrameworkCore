using System.Collections.Generic;
using System.Linq;
using DatabaseEntityFrameworkCoreRazor.Models.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEntityFrameworkCoreRazor.Pages
{
	public class ListModel : PageModel
  {
    private readonly TestDatabaseDbContext _dbContext;

    /// <summary>
    /// 一覧に表示するためのユーザー一覧を格納します。
    /// </summary>
    public List<User> Users { get; set; }

    /// <summary>
    /// DI で TestDatabaseDbContext を受け取ります。
    /// </summary>
    /// <param name="dbContext"></param>
    public ListModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// ページにアクセスされたときに呼ばれます。
    /// </summary>
    public void OnGet()
    {
      // データベースからユーザー一覧を取得します。
      Users = _dbContext.Users.ToList();
    }
  }
}
