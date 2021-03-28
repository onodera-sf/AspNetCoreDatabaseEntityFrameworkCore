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
    /// �ҏW���郆�[�U�[�����i�[���܂��B
    /// </summary>
    [BindProperty]
    public User UserInfo { get; set; }

    /// <summary>
    /// DI �� TestDatabaseDbContext ���󂯎��܂��B
    /// </summary>
    /// <param name="dbContext"></param>
    public EditModel(TestDatabaseDbContext dbContext)
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
    public IActionResult OnPost()
    {
      // �G���[������ꍇ�͕ҏW��ʂɖ߂�
      if (ModelState.IsValid == false) return Page();

      // �X�V�����ݒ�
      UserInfo.UpdateDateTime = DateTime.Now;

      // ���͓��e���X�V����
      _dbContext.Users.Update(UserInfo);

      // �ύX���m�肷��
      _dbContext.SaveChanges();

      // �ꗗ��ʂɑJ��
      return RedirectToPage("List");
    }
  }
}
