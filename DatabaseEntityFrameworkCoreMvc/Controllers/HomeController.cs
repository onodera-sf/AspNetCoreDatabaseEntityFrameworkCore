using DatabaseEntityFrameworkCoreMvc.Models;
using DatabaseEntityFrameworkCoreMvc.Models.Database;  // 追加
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseEntityFrameworkCoreMvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		// 追加
		private readonly TestDatabaseDbContext _dbContext;

		public HomeController(ILogger<HomeController> logger, TestDatabaseDbContext dbContext)  // 追加
		{
			_logger = logger;
			_dbContext = dbContext;  // 追加
		}

		public IActionResult Index()
		{
			return View();
		}

		// ここから追加

		/// <summary>
		/// ユーザー一覧表示アクション。
		/// </summary>
		public IActionResult List()
		{
			// データベースから User 一覧を取得する
			var users = _dbContext.Users.ToList();

			// ビューに渡す
			return View(users);
		}

		/// <summary>
		/// ユーザー一新規登録画面。
		/// </summary>
		public IActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// ユーザー新規登録処理。
		/// </summary>
		/// <param name="user">登録するユーザー情報。</param>
		[HttpPost]
		public IActionResult Create(User user)
		{
			// エラーがある場合は登録画面に戻る
			if (ModelState.IsValid == false) View(user);

			// 更新日時設定
			user.UpdateDateTime = DateTime.Now;

			// 登録リストにユーザー追加
			_dbContext.Users.Add(user);

			// 登録を確定する
			_dbContext.SaveChanges();

			// 一覧画面に遷移
			return RedirectToAction(nameof(List));
		}

		/// <summary>
		/// ユーザーの詳細情報表示。
		/// </summary>
		/// <param name="id">ユーザーを識別するID。</param>
		public IActionResult Details(int id)
		{
			// 指定した ID のユーザーをデータベースから取得
			// 本来存在しない ID を指定された場合の処理も追加すべき
			var user = _dbContext.Users.Where(x => x.ID == id).FirstOrDefault();
			return View(user);
		}

		/// <summary>
		/// ユーザー情報編集画面表示。
		/// </summary>
		/// <param name="id">ユーザーを識別するID。</param>
		public IActionResult Edit(int id)
		{
			// 指定した ID のユーザーをデータベースから取得
			// 本来存在しない ID を指定された場合の処理も追加すべき
			var user = _dbContext.Users.Where(x => x.ID == id).FirstOrDefault();
			return View(user);
		}

		/// <summary>
		/// ユーザー情報更新。
		/// </summary>
		/// <param name="user">更新するユーザー情報。</param>
		[HttpPost]
		public IActionResult Edit(User user)
		{
			// エラーがある場合は編集画面に戻る
			if (ModelState.IsValid == false) View(user);

			// 更新日時設定
			user.UpdateDateTime = DateTime.Now;

			// 入力内容を更新する
			_dbContext.Users.Update(user);

			// 変更を確定する
			_dbContext.SaveChanges();

			// 一覧画面に遷移
			return RedirectToAction(nameof(List));
		}

		/// <summary>
		/// ユーザー削除画面。
		/// </summary>
		/// <param name="id">ユーザーを識別するID。</param>
		public IActionResult Delete(int id)
		{
			// 指定した ID のユーザーをデータベースから取得
			// 本来存在しない ID を指定された場合の処理も追加すべき
			var user = _dbContext.Users.Where(x => x.ID == id).FirstOrDefault();
			return View(user);
		}

		/// <summary>
		/// ユーザー削除。
		/// </summary>
		/// <param name="id">削除するユーザー情報。</param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Delete(User user)
		{
			// エラーがある場合は削除画面に戻る
			if (ModelState.IsValid == false) View(user);

			// 削除するデータを登録
			_dbContext.Users.Remove(user);

			// 変更を確定する
			_dbContext.SaveChanges();

			// 一覧画面に遷移
			return RedirectToAction(nameof(List));
		}

		// ここまで追加

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
