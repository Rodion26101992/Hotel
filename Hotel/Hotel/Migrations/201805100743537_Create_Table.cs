namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car_Table",
                c => new
                    {
                        Car_TableId = c.Int(nullable: false, identity: true),
                        Info_Car = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Car_TableId);
            
            CreateTable(
                "dbo.Client_Tenant",
                c => new
                    {
                        Client_TenantId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Mobile_Id = c.Int(nullable: false),
                        Car_Id = c.Int(nullable: false),
                        Email_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                        Pass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Client_TenantId)
                .ForeignKey("dbo.Car_Table", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.Email_Table", t => t.Email_Id, cascadeDelete: true)
                .ForeignKey("dbo.Food_Table", t => t.Food_Id, cascadeDelete: true)
                .ForeignKey("dbo.Mobile_Table", t => t.Mobile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Password_Table", t => t.Pass_Id, cascadeDelete: true)
                .Index(t => t.Mobile_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.Email_Id)
                .Index(t => t.Food_Id)
                .Index(t => t.Pass_Id);
            
            CreateTable(
                "dbo.Email_Table",
                c => new
                    {
                        Email_TableId = c.Int(nullable: false, identity: true),
                        Info_Email = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Email_TableId)
                .Index(t => t.Info_Email, unique: true);
            
            CreateTable(
                "dbo.Food_Table",
                c => new
                    {
                        Food_TableId = c.Int(nullable: false, identity: true),
                        Info_Food = c.String(),
                    })
                .PrimaryKey(t => t.Food_TableId);
            
            CreateTable(
                "dbo.Mobile_Table",
                c => new
                    {
                        Mobile_TableId = c.Int(nullable: false, identity: true),
                        Nuber = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Mobile_TableId)
                .Index(t => t.Nuber, unique: true);
            
            CreateTable(
                "dbo.Password_Table",
                c => new
                    {
                        Password_TableId = c.Int(nullable: false, identity: true),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Password_TableId);
            
            CreateTable(
                "dbo.Room_Table",
                c => new
                    {
                        Room_TableId = c.Int(nullable: false, identity: true),
                        Info_Room = c.String(maxLength: 450),
                        col_peopls_Room = c.Int(nullable: false),
                        Images = c.Binary(),
                    })
                .PrimaryKey(t => t.Room_TableId)
                .Index(t => t.Info_Room, unique: true);
            
            CreateTable(
                "dbo.Time_Arrival",
                c => new
                    {
                        Time_ArrivalId = c.Int(nullable: false, identity: true),
                        Room_ID = c.Int(nullable: false),
                        Time_Arri_begin = c.DateTime(nullable: false),
                        Time_Arri_end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Time_ArrivalId)
                .ForeignKey("dbo.Room_Table", t => t.Room_ID, cascadeDelete: true)
                .Index(t => t.Room_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Time_Arrival", "Room_ID", "dbo.Room_Table");
            DropForeignKey("dbo.Client_Tenant", "Pass_Id", "dbo.Password_Table");
            DropForeignKey("dbo.Client_Tenant", "Mobile_Id", "dbo.Mobile_Table");
            DropForeignKey("dbo.Client_Tenant", "Food_Id", "dbo.Food_Table");
            DropForeignKey("dbo.Client_Tenant", "Email_Id", "dbo.Email_Table");
            DropForeignKey("dbo.Client_Tenant", "Car_Id", "dbo.Car_Table");
            DropIndex("dbo.Time_Arrival", new[] { "Room_ID" });
            DropIndex("dbo.Room_Table", new[] { "Info_Room" });
            DropIndex("dbo.Mobile_Table", new[] { "Nuber" });
            DropIndex("dbo.Email_Table", new[] { "Info_Email" });
            DropIndex("dbo.Client_Tenant", new[] { "Pass_Id" });
            DropIndex("dbo.Client_Tenant", new[] { "Food_Id" });
            DropIndex("dbo.Client_Tenant", new[] { "Email_Id" });
            DropIndex("dbo.Client_Tenant", new[] { "Car_Id" });
            DropIndex("dbo.Client_Tenant", new[] { "Mobile_Id" });
            DropTable("dbo.Time_Arrival");
            DropTable("dbo.Room_Table");
            DropTable("dbo.Password_Table");
            DropTable("dbo.Mobile_Table");
            DropTable("dbo.Food_Table");
            DropTable("dbo.Email_Table");
            DropTable("dbo.Client_Tenant");
            DropTable("dbo.Car_Table");
        }
    }
}
