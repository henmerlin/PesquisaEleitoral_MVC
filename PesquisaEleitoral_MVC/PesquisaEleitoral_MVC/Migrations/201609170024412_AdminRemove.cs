namespace PesquisaEleitoral_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Admin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Admin", c => c.Boolean());
        }
    }
}
