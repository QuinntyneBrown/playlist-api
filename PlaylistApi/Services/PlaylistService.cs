using System;
using System.Collections.Generic;
using PlaylistApi.Dtos;
using PlaylistApi.Data;
using System.Linq;

namespace PlaylistApi.Services
{
    public class PlaylistService : IPlaylistService
    {
        public PlaylistService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Playlists;
            _cache = cacheProvider.GetCache();
        }

        public PlaylistAddOrUpdateResponseDto AddOrUpdate(PlaylistAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Playlist());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new PlaylistAddOrUpdateResponseDto(entity);
        }

        public ICollection<PlaylistDto> Get()
        {
            ICollection<PlaylistDto> response = new HashSet<PlaylistDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new PlaylistDto(entity)); }
            return response;
        }

        public PlaylistDto GetById(int id)
        {
            return new PlaylistDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Playlist> _repository;
        protected readonly ICache _cache;
    }
}
