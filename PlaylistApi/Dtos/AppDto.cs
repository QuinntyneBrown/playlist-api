namespace PlaylistApi.Dtos
{
    public class AppDto
    {
        public AppDto(PlaylistApi.Models.App entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public AppDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
