using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;

namespace DAL
{
    //    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {

            context.Services.AddOrUpdate(new Service() { ServiceId = 1, ServiceName = "Tallinn" });
            context.SaveChanges();

            var pwdHasher = new PasswordHasher();

            // Roles
            context.RolesInt.Add(new RoleInt()
            {
                Name = "Admin"
            });

            context.SaveChanges();

            // Users
            context.UsersInt.Add(new UserInt()
            {
                UserName = "1@eesti.ee",
                Email = "1@eesti.ee",
                FirstName = "Super",
                LastName = "User",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.SaveChanges();



            // Users in Roles
            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "1@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Admin")
            });

            context.SaveChanges();
            var sql = @"CREATE PROCEDURE [dbo].[PostDb]
	@ServiceId int output,
	@UserId int output,

	@ANumber varchar(50) output,
	@BNumber varchar(50) output,
	
	 @StartDate	datetime output,
 @AudioFileName varchar(50) output,
	@InOut varchar(50) output,
	@Duration varchar(50) output,
	@StorageDir varchar(50) output,

	@Custom1 varchar(50) output
AS  
BEGIN 
SELECT @ServiceId = 1;
SELECT @ANumber = '51080089';
SELECT @UserId=1;
END";
            context.Database.ExecuteSqlCommand(sql);

            var articleHeadLine = "<h1>ASP.NET</h1>";
            var articleBody =
                "<p class=\"lead\">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.<br/>" +
                "As a demo, here is simple Contact application - log in and save your contacts!</p>";
            var article = new Article()
            {
                ArticleName = "HomeIndex",
                ArticleHeadline =
                    new MultiLangString(articleHeadLine, "en", articleHeadLine, "Article.HomeIndex.ArticleHeadline"),
                ArticleBody = new MultiLangString(articleBody, "en", articleBody, "Article.HomeIndex.ArticleBody")
            };
            context.Articles.Add(article);
            context.SaveChanges();

            context.Translations.Add(new Translation()
            {
                Value = "<h1>ASP.NET on suurepärane!</h1>",
                Culture = "et",
                MultiLangString = article.ArticleHeadline
            });

            context.Translations.Add(new Translation()
            {
                Value =
                    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.<br/>" +
                    "Demona on siin lihtne Kontaktirakendus - logi sisse ja salvesta enda kontakte</p>",
                Culture = "et",
                MultiLangString = article.ArticleBody
            });
            context.SaveChanges();



            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Skype", "en", "Skype", "ContactType.0")
            });
            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Email", "en", "Email", "ContactType.0")
            });
            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Phone", "en", "Phone", "ContactType.0")
            });

            context.SaveChanges();

            //articleHeadLine = "<h1>ASP.NET</h1>";
            //articleBody =
            //    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.</p>";
            //article.ArticleHeadline = new MultiLangString(articleHeadLine, "et", articleHeadLine);
            //article.ArticleBody = new MultiLangString(articleBody, "et", articleBody);
            //context.Articles.Attach(article);
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}