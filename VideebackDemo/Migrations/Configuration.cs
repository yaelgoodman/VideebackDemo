namespace VideebackDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideebackDemo.Models.UserProfileContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideebackDemo.Models.UserProfileContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            string[] videoIds = new string[] {"9SaShn8OkJI"
                                                ,"e9Nk-aoKOyc"
                                                ,"NrmknXUiAWo"
                                                ,"B8Ui8IAEap4"
                                                ,"Ka2vnJWQxyo"
                                                ,"xTLlOwdawoo"
                                                ,"9SaShn8OkJI"
                                                ,"NrmknXUiAWo"
                                                ,"B8Ui8IAEap4"
                                                ,"Ka2vnJWQxyo"
                                                ,"xTLlOwdawoo"};

            for (int i = 0; i < 11; i++)
            {
                VideebackDemo.Models.UserProfile profile = new VideebackDemo.Models.UserProfile();
                profile.id = i + 1;
                profile.groupId = 12;
                profile.title = "User profile num " + i + " - title";
                profile.path = videoIds[i];
                profile.description = "Description for user num" + i;
                profile.name = "User #" + i;
                profile.dateCreated = DateTime.Now;
                profile.views = i;
                context.UserProfiles.AddOrUpdate(profile);
            }
        }
    }
}
