using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MentorsASPCore.Models;

namespace MentorsASPCore.Migrations
{
    [DbContext(typeof(MentorsContext))]
    [Migration("20161031164425_MigrateDB")]
    partial class MigrateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MentorsASPCore.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("ExperienceInYear");

                    b.Property<int>("MaxStudentCount");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PlaceOfWork");

                    b.Property<int>("PublicStudentCount");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("MentorsASPCore.Models.MentorStudent", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("StudentId");

                    b.HasKey("MentorId", "StudentId");

                    b.HasIndex("MentorId");

                    b.HasIndex("StudentId");

                    b.ToTable("MentorStudent");
                });

            modelBuilder.Entity("MentorsASPCore.Models.MentorTecnology", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("TecnologyId");

                    b.HasKey("MentorId", "TecnologyId");

                    b.HasIndex("MentorId");

                    b.HasIndex("TecnologyId");

                    b.ToTable("MentorTecnology");
                });

            modelBuilder.Entity("MentorsASPCore.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MentorsASPCore.Models.StudentTecnology", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("TecnologyId");

                    b.HasKey("StudentId", "TecnologyId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TecnologyId");

                    b.ToTable("StudentTecnology");
                });

            modelBuilder.Entity("MentorsASPCore.Models.Tecnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tecnologies");
                });

            modelBuilder.Entity("MentorsASPCore.Models.MentorStudent", b =>
                {
                    b.HasOne("MentorsASPCore.Models.Mentor", "Mentor")
                        .WithMany("MentorStudent")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentorsASPCore.Models.Student", "Student")
                        .WithMany("MentorStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MentorsASPCore.Models.MentorTecnology", b =>
                {
                    b.HasOne("MentorsASPCore.Models.Mentor", "Mentor")
                        .WithMany("MentorTecnology")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentorsASPCore.Models.Tecnology", "Tecnology")
                        .WithMany("MentorTecnology")
                        .HasForeignKey("TecnologyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MentorsASPCore.Models.StudentTecnology", b =>
                {
                    b.HasOne("MentorsASPCore.Models.Student", "Student")
                        .WithMany("StudentTecnology")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentorsASPCore.Models.Tecnology", "Tecnology")
                        .WithMany("StudentTecnology")
                        .HasForeignKey("TecnologyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
