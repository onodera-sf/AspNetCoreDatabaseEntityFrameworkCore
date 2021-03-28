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

		// ���̃��\�b�h�̓����^�C���ɂ���ČĂяo����܂��B ���̃��\�b�h���g�p���āA�R���e�i�[�ɃT�[�r�X��ǉ����܂��B
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			// �ǉ�
			services.AddDbContext<TestDatabaseDbContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("TestDatabaseDbContext")));
		}

		// ���̃��\�b�h�̓����^�C���ɂ���ČĂяo����܂��B ���̃��\�b�h���g�p���āAHTTP�v���p�C�v���C�����\�����܂��B
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// �f�t�H���g�� HSTS �l��30���ł��B �{�ԃV�i���I�ł͂����ύX���邱�Ƃ������߂��܂��Bhttps://aka.ms/aspnetcore-hsts ���Q�Ƃ��Ă��������B
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
