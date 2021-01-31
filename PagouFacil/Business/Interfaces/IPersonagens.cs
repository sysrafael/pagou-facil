﻿using PagouFacil.DTO;
using System.Threading.Tasks;

namespace PagouFacil.Business.Interfaces
{
    public interface IPersonagens
    {
        public Task<SucessDTO> getPersonagensMarvel();
        public Task<string> createFile(MarvelContentLists marvelContentLists);
    }
}
