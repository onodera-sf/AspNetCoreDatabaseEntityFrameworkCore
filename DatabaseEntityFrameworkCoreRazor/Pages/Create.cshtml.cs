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
    /// �o�^���郆�[�U�[�����i�[���܂��B
    /// </summary>
    [BindProperty]
    public User UserInfo { get; set; }

    /// <summary>
    /// DI �� TestDatabaseDbContext ���󂯎��܂��B
    /// </summary>
    /// <param name="dbContext"></param>
    public CreateModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// �y�[�W�ɃA�N�Z�X���ꂽ�Ƃ��ɌĂ΂�܂��B
    /// </summary>
    public void OnGet()
    {
      // ��ʕ\�����͉������܂���B
    }

    /// <summary>
    /// POST �����M���ꂽ�Ƃ��ɌĂ΂��B
    /// </summary>
    public IActionResult OnPost()
    {
      // �G���[������ꍇ�͓o�^��ʂɖ߂�
      if (ModelState.IsValid == false) return Page();

      // �X�V�����ݒ�
      UserInfo.UpdateDateTime = DateTime.Now;

      // �o�^���X�g�Ƀ��[�U�[�ǉ�
      _dbContext.Users.Add(UserInfo);

      // �o�^���m�肷��
      _dbContext.SaveChanges();

      // �ꗗ��ʂɑJ��
      return RedirectToPage("List");
    }
  }
}
