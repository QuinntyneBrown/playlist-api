using PlaylistApi.Models;

namespace PlaylistApi.Data
{
    public interface IUow
    {
        IRepository<Playlist> Playlists { get; }
        IRepository<PlaylistItem> PlaylistItems { get; }
        IRepository<App> Apps { get; }
        void SaveChanges();
    }
}
