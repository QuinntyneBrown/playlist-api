namespace PlaylistApi.Dtos
{
    public class PlaylistAddOrUpdateResponseDto: PlaylistDto
    {
        public PlaylistAddOrUpdateResponseDto(Models.Playlist entity)
        :base(entity)
        {

        }
    }
}
