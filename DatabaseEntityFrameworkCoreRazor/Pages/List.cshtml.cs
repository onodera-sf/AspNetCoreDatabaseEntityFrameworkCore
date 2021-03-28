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
    /// �ꗗ�ɕ\�����邽�߂̃��[�U�[�ꗗ���i�[���܂��B
    /// </summary>
    public List<User> Users { get; set; }

    /// <summary>
    /// DI �� TestDatabaseDbContext ���󂯎��܂��B
    /// </summary>
    /// <param name="dbContext"></param>
    public ListModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// �y�[�W�ɃA�N�Z�X���ꂽ�Ƃ��ɌĂ΂�܂��B
    /// </summary>
    public void OnGet()
    {
      // �f�[�^�x�[�X���烆�[�U�[�ꗗ���擾���܂��B
      Users = _dbContext.Users.ToList();
    }
  }
}
