using System;
using System.Collections.Generic;
using PlaylistApi.Data;
using PlaylistApi.Dtos;
using System.Data.Entity;
using System.Linq;
using PlaylistApi.Models;

namespace PlaylistApi.Services
{
    public class PlaylistItemService : IPlaylistItemService
    {
        public PlaylistItemService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.PlaylistItems;
            _cache = cacheProvider.GetCache();
        }

        public PlaylistItemAddOrUpdateResponseDto AddOrUpdate(PlaylistItemAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new PlaylistItem());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new PlaylistItemAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<PlaylistItemDto> Get()
        {
            ICollection<PlaylistItemDto> response = new HashSet<PlaylistItemDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new PlaylistItemDto(entity)); }    
            return response;
        }


        public PlaylistItemDto GetById(int id)
        {
            return new PlaylistItemDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<PlaylistItem> _repository;
        protected readonly ICache _cache;
    }
}
