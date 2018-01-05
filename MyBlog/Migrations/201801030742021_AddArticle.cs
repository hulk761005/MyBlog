namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(),
                        Summary = c.String(),
                        ContentText = c.String(),
                        ViewCount = c.Int(nullable: false),
                        CreateUser = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
