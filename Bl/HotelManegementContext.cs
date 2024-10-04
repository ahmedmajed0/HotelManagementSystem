using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bl
{
    public partial class HotelManegementContext : IdentityDbContext<ApplicationUser>
    {
        public HotelManegementContext() {}
        public HotelManegementContext(DbContextOptions<HotelManegementContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TbClientFood> TbClientFood { get; set; }
        public virtual DbSet<TbOrder> TbOrder { get; set; }
        public virtual DbSet<TbClients> TbClients { get; set; }
        public virtual DbSet<TbEmployees> TbEmployees { get; set; }
        public virtual DbSet<TbFood> TbFood { get; set; }
        public virtual DbSet<TbFoodCategory> TbFoodCategory { get; set; }
        public virtual DbSet<TbMeels> TbMeels { get; set; }
        public virtual DbSet<TbPayments> TbPayments { get; set; }
        public virtual DbSet<TbReservations> TbReservations { get; set; }
        public virtual DbSet<TbRoomReservations> TbRoomReservations { get; set; }
        public virtual DbSet<TbRooms> TbRooms { get; set; }
        public virtual DbSet<TbSupplierGoods> TbSupplierGoods { get; set; }
        public virtual DbSet<TbSuppliers> TbSuppliers { get; set; }
        public virtual DbSet<TbViews> TbViews { get; set; }
        public virtual DbSet<TbRoomService> TbRoomService { get; set; }
        public virtual DbSet<VwClientOrder> VwClientOrder { get; set; }
        public virtual DbSet<VwClientRoom> VwClientRoom { get; set; }
        public virtual DbSet<VwFoodCategory> VwFoodCategory { get; set; }
        public virtual DbSet<VwRoomMeel> VwRoomMeel { get; set; }
        public virtual DbSet<VwMeelNumber> VwMeelNumber { get; set; }
        public virtual DbSet<VwRoomReservation> VwRoomReservation { get; set; }
        public virtual DbSet<VwRoomEmployee> VwRoomEmployee { get; set; }
        public virtual DbSet<VwRoomReservedEmployee> VwRoomReservedEmployee { get; set; }
        public virtual DbSet<VwRooms> VwRooms { get; set; }
        public virtual DbSet<VwCheckingRoomAvailablity> VwCheckingRoomAvailablity { get; set; }
        public virtual DbSet<VwClientFoodPayment> VwClientFoodPayment { get; set; }
        public virtual DbSet<VwAfterRoomReservation> VwAfterRoomReservation { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "Security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTomens", "Security");



            modelBuilder.Entity<TbClientFood>(entity =>
            {
                entity.HasKey(e => e.ClientFoodId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");


            });

            modelBuilder.Entity<TbOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.FoodName).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ClientFood)
                       .WithMany(p => p.Orders)
                       .HasForeignKey(d => d.ClientFoodId)
                       .HasConstraintName("FK_TbClientFood_TbOrder");


            });



            modelBuilder.Entity<TbRoomService>(entity =>
            {
                entity.HasKey(e => e.RoomServiceId);

                entity.Property(e => e.CleaningDay).HasMaxLength(20);

                entity.Property(e => e.PM).HasMaxLength(3);

                entity.Property(e => e.Status).HasMaxLength(20);

            });

            modelBuilder.Entity<TbClients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
            });


            modelBuilder.Entity<TbEmployees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DepartMent)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Salary).HasColumnType("decimal(12, 2)");
            });




            modelBuilder.Entity<TbViews>(entity =>
            {
                entity.HasKey(e => e.ViewId);

                entity.Property(e => e.ViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Rooms)
                    .WithOne(p => p.Views)
                    .HasForeignKey<TbRooms>(d => d.ViewId)
                    .HasConstraintName("FK_ViewRoom");

            });



            modelBuilder.Entity<TbFood>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.Property(e => e.FoodDescription).HasMaxLength(250);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FoodImage)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FoodPrice).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.TbFoodCategory)
                .WithMany(p => p.Food)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_TbFoodrCategory_TbFood");
            });

            modelBuilder.Entity<TbFoodCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName).HasMaxLength(30);

            });

            modelBuilder.Entity<TbMeels>(entity =>
            {
                entity.HasKey(e => e.MeelId);

                entity.Property(e => e.MeelDetails).HasMaxLength(200);

                entity.Property(e => e.MeelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MeelTime)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.MeelPrice).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<TbPayments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.Method)
                    .HasMaxLength(100);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPaidPrice).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.ClientFood)
                    .WithMany(p => p.TbPayments)
                    .HasForeignKey(d => d.ClientFoodId)
                    .HasConstraintName("FK_TbPayments_TbClientFood");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.TbPayments)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK_TbPayments_TbReservations");
            });

            modelBuilder.Entity<TbReservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.Property(e => e.ArrivingDate).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.LeavingDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(150);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TbReservations)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_TbReservations_TbClients");

                entity.HasOne(d => d.Meel)
                    .WithMany(p => p.TbReservations)
                    .HasForeignKey(d => d.MeelId)
                    .HasConstraintName("FK_TbReservations_TbMeels");
            });

            modelBuilder.Entity<TbRoomReservations>(entity =>
            {
                entity.HasKey(e => e.RoomReservationId);

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.TbRoomReservations)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK_TbRoomReservations_TbReservations");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TbRoomReservations)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_TbRoomReservations_TbRooms");
            });

            modelBuilder.Entity<TbRooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LongDescription).HasMaxLength(500);

                entity.Property(e => e.RoomPrice).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.RoomView)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortDescription).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TbRooms)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TbRooms_TbEmployees");
            });

            modelBuilder.Entity<TbSupplierGoods>(entity =>
            {
                entity.HasKey(e => e.SupplierGoodId)
                    .HasName("PK_TbSupplierCategory");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfArrival).HasColumnType("datetime");

                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Quantity).IsRequired().HasColumnType("double");

                entity.Property(e => e.QuantityUnit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TbSupplierGoods)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSupplierCategory_TbSuppliers");
            });

            modelBuilder.Entity<TbSuppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(100);


                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SupplierPhone)
                    .IsRequired()
                    .HasMaxLength(20);
            });



            modelBuilder.Entity<VwClientOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwClientOrder");

            });



            modelBuilder.Entity<VwClientRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwClientRoom");

            });

            modelBuilder.Entity<VwFoodCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwFoodCategory");

            });


            modelBuilder.Entity<VwAfterRoomReservation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAfterRoomReservation");

            });
            


            modelBuilder.Entity<VwClientFoodPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwClientFoodPayment");

            });


            


            modelBuilder.Entity<VwCheckingRoomAvailablity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCheckingRoomAvailablity");

            });
            

            modelBuilder.Entity<VwRoomMeel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRoomMeel");

            });




            modelBuilder.Entity<VwRoomReservation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRoomReservation");

            });


            modelBuilder.Entity<VwRoomEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRoomEmployee");

            });


            modelBuilder.Entity<VwRoomReservedEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRoomReservedEmployee");

            });


            modelBuilder.Entity<VwRooms>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwRooms");

            });

            


            modelBuilder.Entity<VwMeelNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwMeelNumber");

            });


            


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
