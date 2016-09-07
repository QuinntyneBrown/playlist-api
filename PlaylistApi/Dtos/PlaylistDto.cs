namespace PlaylistApi.Dtos
{
    public class PlaylistDto
    {
        public PlaylistDto()
        {

        }

        public PlaylistDto(Models.Playlist entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
