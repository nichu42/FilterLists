﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Directory.Infrastructure.Persistence.Queries.Entities;

public record FilterList
{
    public int Id { get; private init; }
    public string Name { get; private init; } = null!;
    public string? Description { get; private init; }
    public int? LicenseId { get; private init; }
    public License? License { get; }
    public IReadOnlyCollection<FilterListSyntax> FilterListSyntaxes { get; } = new HashSet<FilterListSyntax>();
    public IReadOnlyCollection<FilterListLanguage> FilterListLanguages { get; } = new HashSet<FilterListLanguage>();
    public IReadOnlyCollection<FilterListTag> FilterListTags { get; } = new HashSet<FilterListTag>();
    public IReadOnlyCollection<FilterListViewUrl> ViewUrls { get; } = new HashSet<FilterListViewUrl>();
    public Uri? HomeUrl { get; private init; }
    public Uri? OnionUrl { get; private init; }
    public Uri? PolicyUrl { get; private init; }
    public Uri? SubmissionUrl { get; private init; }
    public Uri? IssuesUrl { get; private init; }
    public Uri? ForumUrl { get; private init; }
    public Uri? ChatUrl { get; private init; }
    public string? EmailAddress { get; private init; }
    public Uri? DonateUrl { get; private init; }
    public IReadOnlyCollection<FilterListMaintainer> FilterListMaintainers { get; } = new HashSet<FilterListMaintainer>();
    public IReadOnlyCollection<Fork> UpstreamFilterLists { get; } = new HashSet<Fork>();
    public IReadOnlyCollection<Fork> ForkFilterLists { get; } = new HashSet<Fork>();
    public IReadOnlyCollection<Merge> IncludedInFilterLists { get; } = new HashSet<Merge>();
    public IReadOnlyCollection<Merge> IncludesFilterLists { get; } = new HashSet<Merge>();
    public IReadOnlyCollection<Dependent> DependencyFilterLists { get; } = new HashSet<Dependent>();
    public IReadOnlyCollection<Dependent> DependentFilterLists { get; } = new HashSet<Dependent>();
}

internal class FilterListTypeConfiguration : IEntityTypeConfiguration<FilterList>
{
    public virtual void Configure(EntityTypeBuilder<FilterList> builder)
    {
        builder.HasDataJsonFile<FilterList>();
    }
}
