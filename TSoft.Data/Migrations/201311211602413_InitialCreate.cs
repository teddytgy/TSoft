namespace TSoft.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //            Email = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.Person",
            //    c => new
            //        {
            //            PersonId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            Email = c.String(),
            //            Phone = c.String(),
            //        })
            //    .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Person");
            //DropTable("dbo.UserProfile");
        }
    }
}
