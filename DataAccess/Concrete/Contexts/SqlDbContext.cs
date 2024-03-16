using Core.Entities;
using Core.Identity.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = Entities.Concrete.File;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.Contexts
{
    public class SqlDbContext : IdentityDbContext<User,Role,Guid>
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
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Receiver).HasColumnName("Receiver");
                a.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
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
                a.HasOne(p => p.User).WithMany().HasForeignKey(b => b.UserId); 
                a.HasQueryFilter(b => b.Status);
            });

            modelBuilder.Entity<Basket>(a =>
            {
                a.ToTable("Baskets").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
                a.Property(p => p.TotalProduct).HasColumnName("TotalProduct");
                a.Property(p => p.IsActive).HasColumnName("IsActive");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.BasketItems).WithOne(p => p.Basket).HasForeignKey(p => p.BasketId);
                a.HasOne(p => p.Order).WithOne(p => p.Basket).HasForeignKey<Order>(p => p.BasketId);
                a.HasOne(p => p.User).WithMany().HasForeignKey(b => b.UserId);
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
            });

            modelBuilder.Entity<Draft>(a =>
            {
                a.ToTable("Drafts").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Title).HasColumnName("Title");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.TypeId).HasColumnName("TypeId").IsRequired(false);
                a.Property(p => p.Size).HasColumnName("Size").IsRequired(false);
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.IsCompleted).HasColumnName("IsCompleted").HasDefaultValue(false);
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Type).WithMany(p => p.Drafts).HasForeignKey(p => p.TypeId);
                a.HasOne(p => p.User).WithMany().HasForeignKey(b => b.UserId);
                a.HasMany(p => p.DraftImages).WithOne(p => p.Draft).HasForeignKey(p => p.DraftId);
                a.HasMany(p => p.Products).WithOne(p => p.Draft).HasForeignKey(p => p.DraftId);
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
            });
            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.DraftId).HasColumnName("DraftId");
                a.Property(p => p.LikeCount).HasColumnName("LikeCount").HasDefaultValue(0);
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Price).HasColumnName("Price");
                a.Property(p => p.IsPrivate).HasColumnName("IsPrivate").HasDefaultValue(false);
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Draft).WithMany(p => p.Products).HasForeignKey(p => p.DraftId);
                a.HasQueryFilter(b => b.Status);
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
                a.HasQueryFilter(b => b.Status);
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
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
    
}
