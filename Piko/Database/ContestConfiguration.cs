using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Piko.Models.Entities;
using Newtonsoft.Json;


namespace Piko.Database
{
    public class ContestConfiguration : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.Property(e => e.Options).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings 
                { 
                    NullValueHandling = NullValueHandling.Ignore 
                }),
                v => JsonConvert.DeserializeObject<List<Option>>(v, new JsonSerializerSettings 
                { 
                    NullValueHandling = NullValueHandling.Ignore 
                }));
        }
    }
}