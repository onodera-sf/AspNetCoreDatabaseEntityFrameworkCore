using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseEntityFrameworkCoreRazor.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseEntityFrameworkCoreRazor.Pages
{
  public class DeleteModel : PageModel
  {
    private readonly TestDatabaseDbContext _dbContext;

    /// <summary>
    /// �ҏW���郆�[�U�[�����i�[���܂��B
    /// </summary>
    [BindProperty]
    public User UserInfo { get; set; }

    /// <summary>
    /// DI �� TestDatabaseDbContext ���󂯎��܂��B
    /// </summary>
    /// <param name="dbContext"></param>
    public DeleteModel(TestDatabaseDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// �y�[�W�ɃA�N�Z�X���ꂽ�Ƃ��ɌĂ΂�܂��B
    /// </summary>
    public void OnGet(int? id)
    {
      // �w�肵�� ID �̃��[�U�[���f�[�^�x�[�X����擾
      // �{�����݂��Ȃ� ID ���w�肳�ꂽ�ꍇ�̏������ǉ����ׂ�
      UserInfo = _dbContext.Users.Where(x => x.ID == id).FirstOrDefault();
    }

    /// <summary>
    /// POST �����M���ꂽ�Ƃ��ɌĂ΂��B
    /// </summary>
    public IActionResult OnPost(int? id)
    {
      // �G���[������ꍇ�͍폜��ʂɖ߂�
      if (ModelState.IsValid == false) return Page();

      // �폜����f�[�^��o�^
      _dbContext.Users.Remove(new User() { ID = id.Value });

      // �ύX���m�肷��
      _dbContext.SaveChanges();

      // �ꗗ��ʂɑJ��
      return RedirectToPage("List");
    }
  }
}
