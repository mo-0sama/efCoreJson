namespace Infra.EntityFrameworkCore.Configuration;
public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Request");
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.HasOne(x => x.BasicInformation);
    }
}