﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5);

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.Freight)
                .HasColumnType("decimal(5,2)");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.RequiredDate).HasColumnType("datetime");

            builder.Property(e => e.ShipAddress).HasMaxLength(60);

            builder.Property(e => e.ShipCity).HasMaxLength(15);

            builder.Property(e => e.ShipCountry).HasMaxLength(15);

            builder.Property(e => e.ShipName).HasMaxLength(40);

            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);

            builder.Property(e => e.ShipRegion).HasMaxLength(15);

            builder.Property(e => e.ShippedDate).HasColumnType("datetime");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");

            builder.HasOne(d => d.Shipper)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
