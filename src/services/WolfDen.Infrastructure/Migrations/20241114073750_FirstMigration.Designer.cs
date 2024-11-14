﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WolfDen.Infrastructure.Data;

#nullable disable

namespace WolfDen.Infrastructure.Migrations
{
    [DbContext(typeof(WolfDenContext))]
    [Migration("20241114073750_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WolfDen.Domain.Entity.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateOnly?>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RFId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveBalanceId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TypeId");

                    b.ToTable("LeaveBalances");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveDayId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("LeaveDate")
                        .HasColumnType("date");

                    b.Property<int>("LeaveRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaveRequestId");

                    b.ToTable("LeaveDays");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveIncrementLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveIncrementLogId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("int");

                    b.Property<int>("IncrementValue")
                        .HasColumnType("int");

                    b.Property<int>("LeaveBalanceId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LogDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("LeaveBalanceId");

                    b.ToTable("LeaveIncrementLogs");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveRequestId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ApplyDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date");

                    b.Property<bool>("HalfDay")
                        .HasColumnType("bit");

                    b.Property<int>("LeaveRequestStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProcessedBy");

                    b.HasIndex("TypeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveSettingId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxNegativeBalanceLimit")
                        .HasColumnType("int");

                    b.Property<int>("MinDaysForLeaveCreditJoining")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LeaveSettings");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LeaveTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CarryForward")
                        .HasColumnType("bit");

                    b.Property<int>("CarryForwardLimit")
                        .HasColumnType("int");

                    b.Property<int>("DaysCheck")
                        .HasColumnType("int");

                    b.Property<int>("DaysCheckEqualOrLess")
                        .HasColumnType("int");

                    b.Property<int>("DaysChekcMore")
                        .HasColumnType("int");

                    b.Property<int>("DutyDaysRequired")
                        .HasColumnType("int");

                    b.Property<bool>("HalfDay")
                        .HasColumnType("bit");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<int>("IncrementCount")
                        .HasColumnType("int");

                    b.Property<int>("IncrementGap")
                        .HasColumnType("int");

                    b.Property<int>("MaxDays")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LeaveType");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.Employee", b =>
                {
                    b.HasOne("WolfDen.Domain.Entity.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WolfDen.Domain.Entity.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WolfDen.Domain.Entity.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveBalance", b =>
                {
                    b.HasOne("WolfDen.Domain.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WolfDen.Domain.Entity.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveDay", b =>
                {
                    b.HasOne("WolfDen.Domain.Entity.LeaveRequest", "LeaveRequest")
                        .WithMany()
                        .HasForeignKey("LeaveRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveRequest");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveIncrementLog", b =>
                {
                    b.HasOne("WolfDen.Domain.Entity.LeaveBalance", "LeaveBalance")
                        .WithMany()
                        .HasForeignKey("LeaveBalanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveBalance");
                });

            modelBuilder.Entity("WolfDen.Domain.Entity.LeaveRequest", b =>
                {
                    b.HasOne("WolfDen.Domain.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WolfDen.Domain.Entity.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ProcessedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WolfDen.Domain.Entity.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");

                    b.Navigation("Manager");
                });
#pragma warning restore 612, 618
        }
    }
}
