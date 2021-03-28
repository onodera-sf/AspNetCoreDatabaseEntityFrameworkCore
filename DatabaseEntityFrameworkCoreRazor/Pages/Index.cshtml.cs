using DatabaseEntityFrameworkCoreRazor.Models.Database;  // 追加
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseEntityFrameworkCoreRazor.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		// 追加
		private readonly TestDatabaseDbContext _dbContext;

		public IndexModel(ILogger<IndexModel> logger, TestDatabaseDbContext dbContext)  // 追加
		{
			_logger = logger;
			_dbContext = dbContext;  // 追加
		}

		public void OnGet()
		{

		}
	}
}
