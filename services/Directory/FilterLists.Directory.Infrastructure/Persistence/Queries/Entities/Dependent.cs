﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Directory.Infrastructure.Persistence.Queries.Entities;

public record Dependent
{
    public int DependencyFilterListId { get; private init; }
    public FilterList DependencyFilterList { get; } = null!;
    public int DependentFilterListId { get; private init; }
    public FilterList DependentFilterList { get; } = null!;
}

internal class DependentTypeConfiguration : IEntityTypeConfiguration<Dependent>
{
    public virtual void Configure(EntityTypeBuilder<Dependent> builder)
    {
        builder.ToTable(nameof(Dependent) + "s");
        builder.HasKey(d => new { d.DependencyFilterListId, d.DependentFilterListId });
        builder.HasOne(d => d.DependencyFilterList)
            .WithMany(fl => fl.DependentFilterLists)
            .HasForeignKey(d => d.DependencyFilterListId);
        builder.HasOne(d => d.DependentFilterList)
            .WithMany(fl => fl.DependencyFilterLists)
            .HasForeignKey(d => d.DependentFilterListId);
        builder.HasDataJsonFile<Dependent>();
    }
}
