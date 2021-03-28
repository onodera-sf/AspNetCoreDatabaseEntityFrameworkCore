using DatabaseEntityFrameworkCoreMvc.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseEntityFrameworkCoreMvc
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// このメソッドはランタイムによって呼び出されます。 このメソッドを使用して、コンテナーにサービスを追加します。
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			// 追加
			services.AddDbContext<TestDatabaseDbContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("TestDatabaseDbContext")));
		}

		// このメソッドはランタイムによって呼び出されます。 このメソッドを使用して、HTTP要求パイプラインを構成します。
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// デフォルトの HSTS 値は30日です。 本番シナリオではこれを変更することをお勧めします。https://aka.ms/aspnetcore-hsts を参照してください。
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
