// <auto-generated />
using System;
using CakesManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CakesManagement.Migrations
{
    [DbContext(typeof(CakesManagementDBContext))]
    [Migration("20211014021339_add_category_and_cake_1")]
    partial class add_category_and_cake_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CakesManagement.Entities.Cakes", b =>
                {
                    b.Property<int>("CakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CakeName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfManufacture")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expiry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intingredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CakeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("CakesManagement.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Bánh Kem"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Bánh Quy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Bánh Trái Cây"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Bánh Trung Thu"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Bánh Bao"
                        });
                });

            modelBuilder.Entity("CakesManagement.Entities.Cakes", b =>
                {
                    b.HasOne("CakesManagement.Entities.Category", "Category")
                        .WithMany("Cakes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CakesManagement.Entities.Category", b =>
                {
                    b.Navigation("Cakes");
                });
#pragma warning restore 612, 618
        }
    }
}
