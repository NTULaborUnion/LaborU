using AutoMapper;

namespace LaborU.Mappers;

public static class MapConfig
{
    public static Mapper GetMapper()
    {
        return new Mapper(new MapperConfiguration(config =>
        {
            config.AddProfile<ContactProfile>();
            config.AddProfile<UserProfile>();
        }));
    }
}