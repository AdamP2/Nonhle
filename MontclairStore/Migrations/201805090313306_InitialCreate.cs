namespace MontclairStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItemEntities",
                c => new
                    {
                        cart_item_id = c.String(nullable: false, maxLength: 128),
                        cart_id = c.String(maxLength: 128),
                        item_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.cart_item_id)
                .ForeignKey("dbo.CartEntities", t => t.cart_id)
                .ForeignKey("dbo.ItemEntities", t => t.item_id, cascadeDelete: true)
                .Index(t => t.cart_id)
                .Index(t => t.item_id);
            
            CreateTable(
                "dbo.CartEntities",
                c => new
                    {
                        cart_id = c.String(nullable: false, maxLength: 128),
                        date_created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cart_id);
            
            CreateTable(
                "dbo.ItemEntities",
                c => new
                    {
                        ItemCode = c.Int(nullable: false, identity: true),
                        Category_ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 255),
                        QuantityInStock = c.Int(nullable: false),
                        Picture = c.Binary(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemCode)
                .ForeignKey("dbo.CategoryEntities", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.CategoryEntities",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 255),
                        Department_Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Category_ID)
                .ForeignKey("dbo.DepartmentEntities", t => t.Department_Department_ID)
                .Index(t => t.Department_Department_ID);
            
            CreateTable(
                "dbo.DepartmentEntities",
                c => new
                    {
                        Department_ID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Department_ID);
            
            CreateTable(
                "dbo.CustomerEntities",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 35),
                        LastName = c.String(nullable: false, maxLength: 35),
                        phone = c.String(nullable: false, maxLength: 10),
                        address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        Order_ID = c.Int(nullable: false, identity: true),
                        date_created = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 128),
                        shipped = c.Boolean(nullable: false),
                        status = c.String(),
                        packed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Order_ID)
                .ForeignKey("dbo.CustomerEntities", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.OrderAddressEntities",
                c => new
                    {
                        address_id = c.Int(nullable: false, identity: true),
                        Order_ID = c.Int(nullable: false),
                        street = c.String(),
                        city = c.String(),
                        zipcode = c.String(),
                    })
                .PrimaryKey(t => t.address_id)
                .ForeignKey("dbo.OrderEntities", t => t.Order_ID, cascadeDelete: true)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.OrderItemEntities",
                c => new
                    {
                        Order_Item_id = c.Int(nullable: false, identity: true),
                        Order_id = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        replied = c.Boolean(nullable: false),
                        date_replied = c.DateTime(),
                        accepted = c.Boolean(nullable: false),
                        date_accepted = c.DateTime(),
                        shipped = c.Boolean(nullable: false),
                        status = c.String(),
                        date_shipped = c.DateTime(),
                    })
                .PrimaryKey(t => t.Order_Item_id)
                .ForeignKey("dbo.ItemEntities", t => t.item_id, cascadeDelete: true)
                .ForeignKey("dbo.OrderEntities", t => t.Order_id, cascadeDelete: true)
                .Index(t => t.Order_id)
                .Index(t => t.item_id);
            
            CreateTable(
                "dbo.OrderTrackingEntities",
                c => new
                    {
                        tracking_ID = c.Int(nullable: false, identity: true),
                        order_ID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        status = c.String(),
                        Recipient = c.String(),
                    })
                .PrimaryKey(t => t.tracking_ID)
                .ForeignKey("dbo.OrderEntities", t => t.order_ID, cascadeDelete: true)
                .Index(t => t.order_ID);
            
            CreateTable(
                "dbo.PaymentEntities",
                c => new
                    {
                        payment_ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        PaymentFor = c.String(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.payment_ID)
                .ForeignKey("dbo.CustomerEntities", t => t.Email, cascadeDelete: true)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PaymentEntities", "Email", "dbo.CustomerEntities");
            DropForeignKey("dbo.OrderTrackingEntities", "order_ID", "dbo.OrderEntities");
            DropForeignKey("dbo.OrderItemEntities", "Order_id", "dbo.OrderEntities");
            DropForeignKey("dbo.OrderItemEntities", "item_id", "dbo.ItemEntities");
            DropForeignKey("dbo.OrderAddressEntities", "Order_ID", "dbo.OrderEntities");
            DropForeignKey("dbo.OrderEntities", "Email", "dbo.CustomerEntities");
            DropForeignKey("dbo.CartItemEntities", "item_id", "dbo.ItemEntities");
            DropForeignKey("dbo.ItemEntities", "Category_ID", "dbo.CategoryEntities");
            DropForeignKey("dbo.CategoryEntities", "Department_Department_ID", "dbo.DepartmentEntities");
            DropForeignKey("dbo.CartItemEntities", "cart_id", "dbo.CartEntities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PaymentEntities", new[] { "Email" });
            DropIndex("dbo.OrderTrackingEntities", new[] { "order_ID" });
            DropIndex("dbo.OrderItemEntities", new[] { "item_id" });
            DropIndex("dbo.OrderItemEntities", new[] { "Order_id" });
            DropIndex("dbo.OrderAddressEntities", new[] { "Order_ID" });
            DropIndex("dbo.OrderEntities", new[] { "Email" });
            DropIndex("dbo.CategoryEntities", new[] { "Department_Department_ID" });
            DropIndex("dbo.ItemEntities", new[] { "Category_ID" });
            DropIndex("dbo.CartItemEntities", new[] { "item_id" });
            DropIndex("dbo.CartItemEntities", new[] { "cart_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentEntities");
            DropTable("dbo.OrderTrackingEntities");
            DropTable("dbo.OrderItemEntities");
            DropTable("dbo.OrderAddressEntities");
            DropTable("dbo.OrderEntities");
            DropTable("dbo.CustomerEntities");
            DropTable("dbo.DepartmentEntities");
            DropTable("dbo.CategoryEntities");
            DropTable("dbo.ItemEntities");
            DropTable("dbo.CartEntities");
            DropTable("dbo.CartItemEntities");
        }
    }
}
