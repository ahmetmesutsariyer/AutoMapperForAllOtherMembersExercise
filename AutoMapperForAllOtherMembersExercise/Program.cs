using System.Text.Json;
using AutoMapper;

namespace AutoMapperForAllOtherMembersExercise;

static class Program
{
    public static void Main()
    {
        var cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Sample, SampleDto>()
                .IgnoreAllMembers()
                .ForMember(dest=> dest.Id,mem=> mem.MapFrom(y=>y.Id));
        });
        
        IMapper mapper = cfg.CreateMapper();
        
        var sample = new Sample()
        {
            Id = 1,
            Name = "ahmet",
            Current = DateTime.Now
        };
        var destination = mapper.Map<Sample, SampleDto>(sample);
        Console.WriteLine(JsonSerializer.Serialize(destination));
        Console.ReadKey();
    }
}

public record Sample
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime Current { get; init; }
}

public record SampleDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime? Current { get; init; }
}