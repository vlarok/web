using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain;
using Domain.Identity;
using Domain.Rights;
using Microsoft.AspNet.Identity;

namespace DAL
{
    //    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {

            context.Services.AddOrUpdate(new Service() { ServiceId = 1, ServiceName = "Helsinki" });
            context.SaveChanges();
            context.Services.AddOrUpdate(new Service() { ServiceId = 2, ServiceName = "Tallinn" });
            context.SaveChanges();
            context.Services.AddOrUpdate(new Service() { ServiceId = 3, ServiceName = "Stockholm" });
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


            #region Privilege execution
            context.Privileges.Add(new Privilege() { PrivilegeName = "listenallcalls" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "team_calllisten" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "listenowncalls" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "listenservicecalls" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "listenrulecalls" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "calldownload" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "evautosel" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "evaluateselonly" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "evreportsagent" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "team_callevaluate" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "mantainevforms" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "seeevalutaionforms" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "evreports" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "evaluate" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "selectiverec" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "actionreports" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "summaryreports" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "listenreports" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "services" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "userroles" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "teamadd" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "roleprivis" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "findusers" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "insertusers" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "rolelist" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "roleadd" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "paramsset" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "callscopy" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "archivefiles" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "folders" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "foldersAdmin" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "pqmsclient" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "pqmsonlineclient" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "workstationext" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "linestates" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "changepass" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "screenrecordings" });
            context.SaveChanges();
            context.Privileges.Add(new Privilege() { PrivilegeName = "licenseesAdmin" });
            context.SaveChanges();


            #endregion


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    context.Calls.AddOrUpdate(new Call()
                    {
                        AudioDir = @"2015\04\27\22\",
                        AudioFileName = "20150427225942_001_50336869",
                        Anumber = "16684" + i.ToString(),
                        Bnumber = i.ToString() + "98991",
                        Dir = "in",
                        Duration = "1" + i.ToString(),
                        UserId = 1,
                        ServiceId = 1,
                        Created = DateTime.Now.AddMinutes(j).AddDays(i),
                        Custom1 = "1"

                    });
                    context.SaveChanges();
                }

            }

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