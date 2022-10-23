﻿// <auto-generated />
using System;
using Capstone_Connect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Capstone_Connect.Migrations
{
    [DbContext(typeof(CapstoneConnectDBContext))]
    partial class CapstoneConnectDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Capstone_Connect.Model.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdminID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Approach")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Award1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Award2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Award3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Award4")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FinalThoughts")
                        .HasColumnType("TEXT");

                    b.Property<string>("Img")
                        .HasColumnType("TEXT");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectOverview")
                        .HasColumnType("TEXT");

                    b.Property<string>("Semester")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Video")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VisitorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("VisitorID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Visitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("ProjectStudent", b =>
                {
                    b.Property<int>("LikedProjectsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LikedProjectsID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("ProjectStudent");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Comment", b =>
                {
                    b.HasOne("Capstone_Connect.Model.Project", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capstone_Connect.Model.Project", b =>
                {
                    b.HasOne("Capstone_Connect.Model.Admin", null)
                        .WithMany("LikedProjects")
                        .HasForeignKey("AdminID");

                    b.HasOne("Capstone_Connect.Model.Visitor", null)
                        .WithMany("LikedProjects")
                        .HasForeignKey("VisitorID");
                });

            modelBuilder.Entity("ProjectStudent", b =>
                {
                    b.HasOne("Capstone_Connect.Model.Project", null)
                        .WithMany()
                        .HasForeignKey("LikedProjectsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Capstone_Connect.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capstone_Connect.Model.Admin", b =>
                {
                    b.Navigation("LikedProjects");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Project", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Capstone_Connect.Model.Visitor", b =>
                {
                    b.Navigation("LikedProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
