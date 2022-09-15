namespace Infra.EntityFrameworkCore.Configuration;
public class BasicInformationConfiguration : IEntityTypeConfiguration<BasicInformation>
{
    public void Configure(EntityTypeBuilder<BasicInformation> builder)
    {
        builder.ToTable("BasicInformation").HasKey(b => b.RequestId);
        builder.HasKey(x => x.RequestId);
        builder.Property(e => e.UserInfo).HasJsonConversion();
    }
}