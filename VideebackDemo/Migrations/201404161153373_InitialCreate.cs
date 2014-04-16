namespace VideebackDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        userId = c.Int(),
                        groupId = c.Int(),
                        title = c.String(),
                        description = c.String(),
                        path = c.String(),
                        videoType = c.Int(),
                        videoStatus = c.Int(),
                        dateCreated = c.DateTime(),
                        trending = c.Int(),
                        technicId = c.Int(),
                        tutorial = c.Int(),
                        youtubeVideoId = c.Int(),
                        duration = c.Int(),
                        skillId = c.Int(),
                        showcase = c.Int(),
                        training = c.Int(),
                        views = c.Int(),
                        hidden = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}
