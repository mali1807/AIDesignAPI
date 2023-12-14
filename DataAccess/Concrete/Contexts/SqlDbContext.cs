using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = Entities.Concrete.File;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.Contexts
{
    public class SqlDbContext : IdentityDbContext<User,Role,string>
    {
        public SqlDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DraftImage> DraftImages { get; set; }
        public DbSet<Type> Types { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Address>(a =>
            {
                a.ToTable("Addresses").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Title).HasColumnName("Title");
                a.Property(p => p.City).HasColumnName("City");
                a.Property(p => p.Country).HasColumnName("Country");
                a.Property(p => p.District).HasColumnName("District");
                a.Property(p => p.Neighbourhood).HasColumnName("Neighbourhood");
                a.Property(p => p.AddressDetail).HasColumnName("AddressDetail");
                a.Property(p => p.ZipCode).HasColumnName("ZipCode");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<Basket>(a =>
            {
                a.ToTable("Baskets").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
                a.Property(p => p.TotalProduct).HasColumnName("TotalProduct");
                a.Property(p => p.IsActive).HasColumnName("IsActive");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.BasketItems).WithOne(p => p.Basket).HasForeignKey(p => p.BasketId);
                a.HasOne(p => p.Order).WithOne(p => p.Basket).HasForeignKey<Order>(p => p.BasketId);
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<BasketItem>(a =>
            {
                a.ToTable("BasketItems").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProductId).HasColumnName("ProductId");
                a.Property(p => p.BasketId).HasColumnName("BasketId");
                a.Property(p => p.Quantity).HasColumnName("Quantity");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Product).WithMany(p => p.BasketItems).HasForeignKey(p => p.ProductId);
                a.HasOne(p => p.Basket).WithMany(p => p.BasketItems).HasForeignKey(p => p.BasketId);
            });

            modelBuilder.Entity<Order>(a =>
            {
                a.ToTable("Orders").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.BasketId).HasColumnName("BasketId");
                a.Property(p => p.IsCompleted).HasColumnName("IsCompleted").HasDefaultValue(false);
                a.Property(p => p.IsCanceled).HasColumnName("IsCanceled").HasDefaultValue(false);
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Basket).WithOne(p => p.Order).HasForeignKey<Order>(p => p.BasketId);
            });

            modelBuilder.Entity<Draft>(a =>
            {
                a.ToTable("Drafts").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.TypeId).HasColumnName("TypeId");
                a.Property(p => p.Size).HasColumnName("Size");
                a.Property(p => p.IsPrivate).HasColumnName("IsPrivate").HasDefaultValue(false);
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Type).WithMany(p => p.Drafts).HasForeignKey(p => p.TypeId);
                a.HasOne(p => p.User);
                a.HasMany(p => p.DraftImages).WithOne(p => p.Draft).HasForeignKey(p => p.DraftId);
                a.HasMany(p => p.Products).WithOne(p => p.Draft).HasForeignKey(p => p.DraftId);
            });

            modelBuilder.Entity<File>(a =>
            {
                a.ToTable("Files").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Path).HasColumnName("Path");
                a.Property(p => p.Storage).HasColumnName("Storage");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Image).WithOne(p => p.File).HasForeignKey<Image>(p => p.FileId);
            });

            modelBuilder.Entity<Image>(a =>
            {
                a.ToTable("Images").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FileId).HasColumnName("FileId");
                a.Property(p => p.IsAi).HasColumnName("IsAi");
                a.Property(p => p.IsPrivate).HasColumnName("IsPrivate");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.File).WithOne(p => p.Image).HasForeignKey<Image>(p => p.FileId);
                a.HasMany(p => p.DraftImages).WithOne(p => p.Image).HasForeignKey(p => p.ImageId);
            });
            modelBuilder.Entity<DraftImage>(a =>
            {
                a.ToTable("DraftImages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ImageId).HasColumnName("ImageId");
                a.Property(p => p.DraftId).HasColumnName("DraftId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Image).WithMany(p => p.DraftImages).HasForeignKey(p => p.ImageId);
                a.HasOne(p => p.Draft).WithMany(p => p.DraftImages).HasForeignKey(p => p.DraftId);
            });
            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.DraftId).HasColumnName("DraftId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Draft).WithMany(p => p.Products).HasForeignKey(p => p.DraftId);
            });
            modelBuilder.Entity<Type>(a =>
            {
                a.ToTable("Types").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.Drafts).WithOne(p => p.Type).HasForeignKey(p => p.TypeId);

            });


            base.OnModelCreating(modelBuilder);
        }

            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Entity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                }
                if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.UtcNow;
                }
                if (data.State == EntityState.Deleted)
                {
                    data.Entity.DeletedDate = DateTime.UtcNow;
                    data.Entity.Status = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
    
}
