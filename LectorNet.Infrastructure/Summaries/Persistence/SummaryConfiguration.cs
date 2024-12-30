using LectorNet.Domain.Models;
using LectorNet.Domain.Models.Summaries;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Summaries.Persistence;

public class SummaryConfiguration : IEntityTypeConfiguration<Summary>
{
    public void Configure(EntityTypeBuilder<Summary> builder)
    {
        
        builder.HasKey(s => new { s.AuthorId, s.BookId });
        
        builder
            .HasOne(s => s.Author)
            .WithMany()
            .HasForeignKey(s => s.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(s => s.Book)
            .WithMany()
            .HasForeignKey(s => s.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(s => s.Vote)
            .HasConversion(
                vote => vote.Value,
                value => Vote.FromValue(value)
                );
        
        // builder
        //     .Property(s => s.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}